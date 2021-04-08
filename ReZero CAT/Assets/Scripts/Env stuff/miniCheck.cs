using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniCheck : MonoBehaviour
{
    public GameManager game;
    //public PlayerController player;
    public GameObject player;
    void Start() {
        game = FindObjectOfType<GameManager>();
        player = GameObject.Find("Player");
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
       if (col.gameObject.tag == "Player")
       {
            game.replayFromCheck(player.transform.position.x,player.transform.position.y);
            Destroy(this.gameObject);
        }
    }
}
