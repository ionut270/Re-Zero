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
    public int jump_velocity = 100;
    private bool grounded = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        this.jump_velocity = 50;
        rb.position = new Vector2(6, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
        StartCoroutine(Wait());
        jump();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4);
    }

    void jump()
    {
        if (this.grounded)
        {

            rb.velocity = new Vector2(rb.velocity.x, jump_velocity);
            rb.gravityScale = 9;
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, -1); //rb.velocity.y * .5f);
            rb.gravityScale = 1;
        }

    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        this.grounded = true;
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        this.grounded = false;
    }
    private void OnCollisionEnter2D()
    {
        if (!this.grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x * 0, rb.velocity.y);
            player.TakeDmg();

        }
    }
}