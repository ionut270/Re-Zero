using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private enum States { idle, run, fast_run, jump, fall, hurt, climb, crouch };
    //                      0    1       2       3     4     5     6      7
    public HealthBar healthBar;
    public GameManager gameManager;

    private bool face_right = true;
    private int health = 100;
    private float move_speed = 0;
    public bool grounded = false;
    private States state = States.idle;
    private Rigidbody2D rb;
    private int jump_velocity = 20; // 20 seems to be a good value
    private int p_move_speed = 10;  // 10 default movement speed
    private float hangTime = .1f;
    private float hangCounter;
    private float jumpBufferLength = .1f;
    private float jumpBufferCount;

    //camera target
    private float aheadAmount = 2;
    private float aheadSpeed = 1;

    public Transform camTarget;
    public Transform sprite;
    public Animator anim;
    public ParticleSystem footsteps;
    private ParticleSystem.EmissionModule footEmission;
    public ParticleSystem impactEffect;

    public CameraShake camShake;

    //sounds
    public AudioSource jump;
    public AudioSource shock;

    //initialize the player character
    private void Start(){
        rb = GetComponent<Rigidbody2D>();

        //particle sistem handlers
        footEmission = footsteps.emission;

        //default player proprieties
        this.move_speed = p_move_speed;
        this.health = 100;
        this.jump_velocity = 20;
        healthBar.setMaxHealth(this.health);
        //spawn the player
        rb.position = new Vector2(0, 5);
    }

    //updates the proprieties of our player
    private void Update(){
      
        this.Move();
        this.Die(); // Continuously check if the player is dead or not
        this.stateHandler();

        //-------------------------------------BASIC MOVEMENT-------------------------------------\\
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * move_speed, rb.velocity.y);
        //-------------------------------------BASIC MOVEMENT-------------------------------------\\

        //-----------------------------------Change anim state------------------------------------\\
        switch (state)
        {
            case States.idle:
                anim.SetInteger("State", 0);
                break;
            case States.run:
                anim.SetInteger("State", 1);
                break;
            case States.fast_run:
                anim.SetInteger("State", 2);
                break;
            case States.jump:
                anim.SetInteger("State", 3);
                break;
            case States.fall:
                anim.SetInteger("State", 4);
                break;
            case States.hurt:
                anim.SetInteger("State", 5);
                break;
            case States.climb:
                anim.SetInteger("State", 6);
                break;
            case States.crouch:
                anim.SetInteger("State", 7);
                break;
        }
        //-----------------------------------Change anim state------------------------------------\\

        //---------------------------Kill player if he fell off the map---------------------------\\
        if(transform.position.y < -20) this.health = 0;
        //---------------------------Kill player if he fell off the map---------------------------\\

        //--------------------------------------Jump handler--------------------------------------\\
        //manage hang
        if (this.grounded)  hangCounter = hangTime;
        else                hangCounter -= Time.deltaTime;
        //manage jump buffer
        if (Input.GetKeyDown(KeyCode.Space)) jumpBufferCount = jumpBufferLength;
        else                                 jumpBufferCount -= Time.deltaTime;
        //--------------------------------------Jump handler--------------------------------------\\

        //---------------------------------------Move camera--------------------------------------\\
        if(Input.GetAxisRaw("Horizontal") != 0)
            camTarget.localPosition = new Vector3(
                Mathf.Lerp(
                    camTarget.localPosition.x,
                    aheadAmount * Input.GetAxisRaw("Horizontal"),
                    aheadSpeed*Time.deltaTime
                )
                , camTarget.localPosition.y
                , camTarget.localPosition.z
            );
        //---------------------------------------Move camera--------------------------------------\\

        //-------------------------------------Particle effect------------------------------------\\
        if(Input.GetAxisRaw("Horizontal") != 0 && this.grounded) {
            footEmission.rateOverTime = 35f;
        } else {
            footEmission.rateOverTime = 0f;
        }
        //-------------------------------------Particle effect------------------------------------\\
    }

    //handle movement of the character
    private void Move()
    {
        //jump * while jumping allow movement ------------------------------------------------------
        if ((jumpBufferCount >=0) && (this.grounded || hangCounter > 0f) ) {
            Press("Jump");
            jump.Play();
            //reset the jump buffer
            jumpBufferCount = 0;
            rb.velocity = new Vector2(rb.velocity.x, jump_velocity);
        } else
        if(Input.GetKeyUp(KeyCode.Space) && pressed.Contains("Jump")) {
            Release("Jump");
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y *.5f);
        }

        //detect fall ------------------------------------------------------------------------------
        if (rb.velocity.y < -.1f && !this.grounded) state = States.fall;
        

        //left & right------------------------------------------------------------------------------
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
            face_right = true;
            Press("Right");
            sprite.transform.localScale = new Vector3(1, 1, 1);
        } else
        if ((Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))){
            Release("Right");
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
            face_right = false;
            Press("Left");
            sprite.transform.localScale = new Vector3(-1, 1, 1);
        } else
        if ((Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))){
            Release("Left");
        }

        //fast run---------------------------------------------------------------------------------
        if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift)){
            Press("Sprint");
            move_speed = p_move_speed * 1.5f;
        } else
        if ((Input.GetKeyUp(KeyCode.RightShift) || Input.GetKeyUp(KeyCode.LeftShift))){
            Release("Sprint");
            move_speed = p_move_speed;
        }

        //crouch----------------------------------------------------------------------------------
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            jump_velocity += 5;
            Press("Crouch");
            move_speed = 0;

            if (!this.grounded){
                rb.velocity = new Vector2(rb.velocity.x, Mathf.Lerp(rb.velocity.y,-50,5));
            }
        } else 
        if ((Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)))   {
            jump_velocity -= 5;
            Release("Crouch");
            move_speed = p_move_speed;
        }
        

    }
    public int GetHealth() {
        return this.health;
    }
    public void TakeDmg() {
        this.health -= 10;
        healthBar.setHealth(this.health);
    }
    private void Die (){
        if(this.health == 0){
            //Start();
            gameManager.EndGame();
        }
    }

    //coliders
    private void OnTriggerEnter2D(Collider2D col){
        //impact particle effect
        if (col.tag == "map"){

            impactEffect.gameObject.SetActive(true);
            impactEffect.Stop();
            impactEffect.transform.position = footsteps.transform.position;
            impactEffect.Play();

            if (this.pressed.Contains("Crouch"))
            {
                camShake.StartShake(.5f, .1f);
                shock.Play();

                //damage 10 hp
                this.health -= 10;
                healthBar.setHealth(this.health);
            }

            this.state = States.idle;
            this.grounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col){
        if (col.tag == "map"){
            this.grounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.collider.tag);
        if (!this.grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x * 0, rb.velocity.y);
        }
    }

    private void stateHandler(){
        /**
        Define an importance to each key
            Left Right 1
            Sprint 2
            Crouch 3
            Jump 4
         */

        if (pressed.Count == 0 && this.state != States.fall)
            this.state = States.idle;
        else
        if(pressed.Contains("Jump") && this.state != States.fall && !this.grounded){
            this.state = States.jump;
        } else
        if (pressed.Contains("Crouch") && this.state != States.fall){
            this.state = States.crouch;
        } else
        if (pressed.Contains("Sprint") && (pressed.Contains("Left") || pressed.Contains("Right")) && this.state != States.fall){
            this.state = States.fast_run;
        } else
        if ((pressed.Contains("Left") || pressed.Contains("Right")) && this.state != States.fall){
            this.state = States.run;
        }
    }

    //keys handler
    private ArrayList pressed = new ArrayList();
    private void Press(string key) {
        pressed.Add(key);
    }
    private void Release(string key) {
        pressed.Remove(key);
    }
}
