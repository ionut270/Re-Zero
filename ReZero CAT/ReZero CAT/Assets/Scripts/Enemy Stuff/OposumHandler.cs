using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OposumHandler : MonoBehaviour
{
    Vector2 initialPosition;
    int direction;
    float maxDist, minDist;
    private Rigidbody2D rb;
    public Transform sprite;
    private float movingSpeed = 10;
    public int HP;

    // Start is called before the first frame update
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        initialPosition = rb.position;
        direction = -1;
        maxDist += rb.position.x;
        minDist -= rb.position.x;
        this.HP = 100;
    }

    // Update is called once per frame
    void Update()
    {
       
        switch (direction)
        {
            case -1:
                // Moving Left
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-movingSpeed, GetComponent<Rigidbody2D>().velocity.y);
                    sprite.transform.localScale = new Vector3(1, 1, 1);
                break;
            case 1:
                //Moving Right
                    GetComponent<Rigidbody2D>().velocity = new Vector2(movingSpeed, GetComponent<Rigidbody2D>().velocity.y);
                    sprite.transform.localScale = new Vector3(-1, 1, 1);
                break;
        };
        
    }
    private void OnTriggerEnter2D(Collider2D col) {
       
        if (col.tag == "map") { direction = -direction; }
        //new
        if (col.tag == "player"){ Die(); }
    }

    public void Die() {
        Destroy(this.gameObject);
    }

}
