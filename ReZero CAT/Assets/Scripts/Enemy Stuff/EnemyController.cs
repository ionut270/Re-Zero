using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public PlayerController player;
    public Transform sprite;
    public Animator anim;
    public ParticleSystem footsteps;
    private ParticleSystem.EmissionModule footEmission;
    public ParticleSystem impactEffect;
    private Rigidbody2D rb;

    private float hangCounter;
    private float jumpBufferLength = .1f;
    private float jumpBufferCount;
    private float hangTime = .1f;
    public int jump_velocity = 20;

    private bool jump = false;
    private bool grounded = false;

    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();

        rb.position = new Vector2(6, 7);
        this.jump_velocity = 20;
    }

    // Update is called once per frame
    void Update()
    {
        jumpHandler();

        //manage hang
        if (this.grounded) hangCounter = hangTime;
        else hangCounter -= Time.deltaTime;

        //manage jump buffer
        if (this.jump) jumpBufferCount = jumpBufferLength;
        else jumpBufferCount -= Time.deltaTime;
    }

    void jumpHandler() {
        if (this.grounded) {
            this.jump = true;
            rb.velocity = new Vector2(rb.velocity.x, jump_velocity);
        }
        else { this.jump = false; }
    }
    
    private void OnTriggerEnter2D(Collider2D col){ this.grounded = true; }
    private void OnTriggerExit2D(Collider2D col) { this.grounded = false; }
    private void OnCollisionEnter2D(){ if (!this.grounded) {rb.velocity = new Vector2(rb.velocity.x * 0, rb.velocity.y);}}
}