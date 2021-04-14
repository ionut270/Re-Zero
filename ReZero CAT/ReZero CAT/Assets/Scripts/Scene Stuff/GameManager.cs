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
        DataSaved.actualLevel = handleScene();
        DataSaved.lastLevel = handleScene()-1;
        DataSaved.condForLevel = 0;
        if (DataSaved.actualLevel == 2)
        { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2); }
        else
        { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); }
       
    }

    private void Start() {
        
         string lastScene = replay.GetLastScene();
        if (DataSaved.actualLevel == DataSaved.lastLevel)
        {
            if (lastScene.Equals("Replay") && DataSaved.stage == 0)
            {
                DataSaved.condForLevel = 0;
                DataSaved.checkReplay = 0;
            }
            else if (lastScene.Equals("Replay") && DataSaved.stage == 1)
            {
                TextAsset txtAsset = (TextAsset)Resources.Load("RecordsPopulate", typeof(TextAsset));
                string jsonString = txtAsset.text;
                SimpleJSON.JSONNode data = SimpleJSON.JSON.Parse(jsonString);
                DataSaved.checkReplay = 1;
                DataSaved.condForLevel = 1;
            }
        }
        else {
            DataSaved.checkReplay = 0;
            DataSaved.condForLevel = 0;
        }
        
         
 
    }
    public int returnCheck() {
        return DataSaved.checkReplay;
    }

    public int handleScene() {

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
        return DataSaved.actualLevel;
    }
    public void WinGame() {
        gameHasEnded = true;
        SceneManager.LoadScene("End");
    }

    public void replayFromCheck(float posX, float posY) {
        TextAsset txtAsset = (TextAsset)Resources.Load("RecordsPopulate", typeof(TextAsset));
        string jsonString = txtAsset.text;
        SimpleJSON.JSONNode data = SimpleJSON.JSON.Parse(jsonString);
        float posX2 = posX+6;
        float posY2 = posY+4;
        DataSaved.checkReplay = 1;
        DataSaved.condForLevel = 1;
        DataSaved.check = new Vector2(posX2, posY2);
    }

    public void EndGame() {
        if (gameHasEnded ==false){
            gameHasEnded = true;
            Debug.Log("GameOver");
            DataSaved.lastLevel = handleScene();
            replay.SetLastScene(SceneManager.GetActiveScene().buildIndex);
            replay.EndGameScene(DataSaved.checkReplay);
        }
    }

    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

