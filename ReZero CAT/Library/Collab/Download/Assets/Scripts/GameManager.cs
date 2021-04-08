using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{ 
    
    public Replay replay;
    bool gameHasEnded = false;

    public void NextLevel() {
        gameHasEnded = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void WinGame() {
        gameHasEnded = true;
        SceneManager.LoadScene("End");
    }

    public void EndGame() {
        if (gameHasEnded ==false){
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
