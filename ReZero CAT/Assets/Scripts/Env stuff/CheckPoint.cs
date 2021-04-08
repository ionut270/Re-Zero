using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameManager game;
    void Start()
    {
        game = FindObjectOfType<GameManager>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player"){
            Debug.Log("You win");
            game.NextLevel();
        } 
    }
}
