using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**Will store hp, & different states of an enemy*/
public class EnemyHandler : MonoBehaviour{

    public int HP = 100;

    private Rigidbody2D rb;
    public  ParticleSystem impactEffect;
    private ParticleSystem.EmissionModule footEmission;

    void Start(){}

    void Update(){
        /*On colision decide who should be hurt.
         If we fall on the top of the enemy damage it.
         If the enemy jumps on you, get damaged
        */
    }

    private void OnTriggerEnter2D(Collider2D col)   { }
    private void OnTriggerExit2D(Collider2D col)    { }
    private void OnCollisionEnter2D(Collision2D col){ }

    void Die(){
        if(this.HP < 1){
            // code to destroy instance & to reward the player
        }
    }
}
