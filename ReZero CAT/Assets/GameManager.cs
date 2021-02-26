using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Replay replay=new Replay();
    bool gameHasEnded = false;
    public void EndGame() {
        if (gameHasEnded ==false)
        {
            gameHasEnded = true;
            Debug.Log("GameOver");
            Debug.Log(SceneManager.GetActiveScene().buildIndex);
            replay.SetLastScene(SceneManager.GetActiveScene().buildIndex);
            replay.EndGameScene();


        }
    }

    void Restart() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
