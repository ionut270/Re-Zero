using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public Replay replay;
    bool gameHasEnded = false;
    string path;
    string jsonString;

    public void NextLevel() {
        gameHasEnded = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    private void Start() {
         string lastScene = replay.GetLastScene();
         if (lastScene.Equals("Replay")){
            DataSaved.stage = 1;
         }else{
            TextAsset txtAsset = (TextAsset)Resources.Load("RecordsPopulate", typeof(TextAsset));
            string jsonString = txtAsset.text;
            SimpleJSON.JSONNode data = SimpleJSON.JSON.Parse(jsonString);
            DataSaved.stage = 0; 
         }
 
    }
    public void WinGame() {
        gameHasEnded = true;
        SceneManager.LoadScene("End");
    }

    public void replayFromCheck(float posX, float posY) {
        TextAsset txtAsset = (TextAsset)Resources.Load("RecordsPopulate", typeof(TextAsset));
        string jsonString = txtAsset.text;
        SimpleJSON.JSONNode data = SimpleJSON.JSON.Parse(jsonString);
        float posX2 = posX;
        float posY2 = posY;
        DataSaved.check = new Vector2(posX2, posY2);
    }

    public void EndGame() {
        if (gameHasEnded ==false){
            gameHasEnded = true;
            Debug.Log("GameOver");
            replay.SetLastScene(SceneManager.GetActiveScene().buildIndex);
            replay.EndGameScene();
        }
    }

    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

