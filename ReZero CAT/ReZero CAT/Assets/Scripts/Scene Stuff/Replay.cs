using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{
    static int LastScene;
    string LastSceneReturn = "";

    public void SetLastScene(int id)
    {
        LastScene = id;
        string rep = "Replay";
        SetLastSceneReturn(rep);
    }
    public string GetLastScene()
    {
        return LastSceneReturn;
    }
    public void SetLastSceneReturn(string LastSceneReturn)
    {
        this.LastSceneReturn = LastSceneReturn;
    }
    public void EndGameScene(int a)
    {
        string rep = "Replay";
        DataSaved.stage = 1;
        DataSaved.checkReplay = a;
        SetLastSceneReturn(rep);
        SceneManager.LoadScene("Replay");
    }
    public void PlayAgainButton()
    {
        SceneManager.LoadScene(LastScene);
    }
}
