using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**Will store hp, & different states of an enemy*/
public class EnemyHandler : MonoBehaviour{

<<<<<<< HEAD
    public int HP;
=======
    public int HP = 100;
>>>>>>> 6d0c31dca3c90ece208a486ce6852d1cb8974e17

    private Rigidbody2D rb;
    public  ParticleSystem impactEffect;
    private ParticleSystem.EmissionModule footEmission;

<<<<<<< HEAD
    void Start(){

        this.HP = 100;
    
    }
=======
    void Start(){}
>>>>>>> 6d0c31dca3c90ece208a486ce6852d1cb8974e17

    void Update(){
        /*On colision decide who should be hurt.
         If we fall on the top of the enemy damage it.
         If the enemy jumps on you, get damaged
        */
<<<<<<< HEAD
        Die();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
    }
    private void OnTriggerExit2D(Collider2D col)    { }
    private void OnCollisionEnter2D(Collision2D col)
    {
      
        if (col.gameObject.name == "Sword")
        {
            
             if (this.HP < 10)
             {
                 Die();
             }
             else
             {
                 Dmg();
             }
        }
    }

    void Dmg()
    {
        if (this.HP >= 30){
            this.HP -= 30;
        }
        
    }
    void Die(){
        if(this.HP==0)
        Destroy(this.gameObject);
=======
    }

    private void OnTriggerEnter2D(Collider2D col)   { }
    private void OnTriggerExit2D(Collider2D col)    { }
    private void OnCollisionEnter2D(Collision2D col){ }

    void Die(){
        if(this.HP < 1){
            // code to destroy instance & to reward the player
        }
>>>>>>> 6d0c31dca3c90ece208a486ce6852d1cb8974e17
    }
}
