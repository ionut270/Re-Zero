using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class miniCheck : MonoBehaviour
{
    public GameManager game;
    //public PlayerController player;
    public GameObject player;
    void Start()
    {
        game = FindObjectOfType<GameManager>();
        player = GameObject.Find("Player");
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            game.replayFromCheck(this.transform.position.x, this.transform.position.y);
            Scene scene = SceneManager.GetActiveScene();
            switch (scene.name)
            {
                case "Lvl 1":
                    DataSaved.actualLevel = 1;
                    break;

                case "Lvl 2":
                    DataSaved.actualLevel = 2;
                    break;

            }
            DataSaved.stage = 1;
            Destroy(this.gameObject);
        }
    }
}
