using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class Populate : MonoBehaviour
{
    
    public GameObject Frog; 
    public GameObject Oposum;
    public GameObject Heal;
    public GameObject Checkpoint;
    public GameObject miniCheckpoint;
   
    public Vector3[] Frog_Spawn;
    public Vector3[] Oposum_Spawn;
    public Vector3[] Heal_Spawn;
    public Vector3[] CheckPoint_Spawn;
    public Vector3[] miniCheckPoint_Spawn;
    string path;
    string jsonString;
    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        Vector3[] Oposum_Spawn = new Vector3[6];
        Vector3[] Frog_Spawn = new Vector3[6];
        Vector3[] Heal_Spawn = new Vector3[3];
        Vector3[] CheckPoint_Spawn = new Vector3[1];
        Vector3[] miniCheckPoint_Spawn = new Vector3[2];
        TextAsset txtAsset = (TextAsset)Resources.Load("RecordsPopulate", typeof(TextAsset));
        string jsonString = txtAsset.text;
        SimpleJSON.JSONNode data = SimpleJSON.JSON.Parse(jsonString);
        SimpleJSON.JSONNode lvl1 = data["Level1"];
        SimpleJSON.JSONNode lvl2 = data["Level2"];
        int count = 0;
        if (scene.name == "Lvl 1")
        {
            foreach (SimpleJSON.JSONNode record in lvl1["Oposum"])
            {   
                Oposum_Spawn[count] = new Vector3(record["posX"].AsFloat, record["posY"].AsFloat, 0);
                count++;
            }
            count = 0;
            foreach (SimpleJSON.JSONNode record in lvl1["Frog"])
            {
                Frog_Spawn[count] = new Vector3(record["posX"].AsFloat, record["posY"].AsFloat, 0);
                count++;
            }
            count = 0;
            foreach (SimpleJSON.JSONNode record in lvl1["Heal"])
            {
                Heal_Spawn[count] = new Vector3(record["posX"].AsFloat, record["posY"].AsFloat, 0);
                count++;
            }
            count = 0;
            foreach (SimpleJSON.JSONNode record in lvl1["Checkpoints"])
            {

                CheckPoint_Spawn[count] = new Vector3(record["posX"].AsFloat, record["posY"].AsFloat, 0);
                count++;
            }
            count = 0;
            foreach (SimpleJSON.JSONNode record in lvl1["miniCheckpoints"])
            {
                miniCheckPoint_Spawn[count] = new Vector3(record["posX"].AsFloat, record["posY"].AsFloat, 0);
                count++;
            }
            count = 0;
        }
        else if(scene.name == "Lvl 2")
        {

            foreach (SimpleJSON.JSONNode record in lvl2["Oposum"])
            {
                Oposum_Spawn[count] = new Vector3(record["posX"].AsFloat, record["posY"].AsFloat, 0);
                count++;
            }
            count = 0;
            foreach (SimpleJSON.JSONNode record in lvl2["Frog"])
            {
                Frog_Spawn[count] = new Vector3(record["posX"].AsFloat, record["posY"].AsFloat, 0);
                count++;
            }
            count = 0;
            foreach (SimpleJSON.JSONNode record in lvl2["Heal"])
            {
                Heal_Spawn[count] = new Vector3(record["posX"].AsFloat, record["posY"].AsFloat, 0);
                count++;
            }
            count = 0;
            foreach (SimpleJSON.JSONNode record in lvl2["Checkpoints"])
            {

                CheckPoint_Spawn[count] = new Vector3(record["posX"].AsFloat, record["posY"].AsFloat, 0);
                count++;
            }
            count = 0;
            foreach (SimpleJSON.JSONNode record in lvl2["miniCheckpoints"])
            {
                miniCheckPoint_Spawn[count] = new Vector3(record["posX"].AsFloat, record["posY"].AsFloat, 0);
                count++;
            }
            count = 0;
        }
    
        foreach (Vector3 i in Frog_Spawn){
            if(i.x!=0)
            Instantiate(Frog, i, Quaternion.identity);
        }
        foreach (Vector3 i in Oposum_Spawn){
            if (i.x != 0)
            {
                Instantiate(Oposum, i, Quaternion.identity); 
            }
        }
        foreach (Vector3 i in Heal_Spawn){
            if (i.x != 0)
                Instantiate(Heal, i, Quaternion.identity);
        }
        foreach (Vector3 i in miniCheckPoint_Spawn)
        {
            if (i.x != 0)
                Instantiate(miniCheckpoint, i, Quaternion.identity);
        }
        foreach (Vector3 i in CheckPoint_Spawn)
        {
            if (i.x != 0)
                Instantiate(Checkpoint, i, Quaternion.identity);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public class Record
{
    public float posX;
    public float posY;
}

[System.Serializable]

public class ListaRecords
{
    public List<Record> Records;
}
