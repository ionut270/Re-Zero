using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{
    static int LastScene;

    public void SetLastScene(int id) {

        LastScene = id;
        Debug.Log(LastScene);
    }

    public void EndGameScene() {
        SceneManager.LoadScene("Replay");

    }

    public void PlayAgainButton() {
        Debug.Log("Repplay");
        SceneManager.LoadScene(LastScene);
    }
}
