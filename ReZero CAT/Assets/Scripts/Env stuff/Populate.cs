using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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
        Vector3[] Oposum_Spawn = new Vector3[6];
        Vector3[] Frog_Spawn = new Vector3[6];
        Vector3[] Heal_Spawn = new Vector3[2];
        Vector3[] CheckPoint_Spawn = new Vector3[1];
        Vector3[] miniCheckPoint_Spawn = new Vector3[1];
        TextAsset txtAsset = (TextAsset)Resources.Load("RecordsPopulate", typeof(TextAsset));
        string jsonString = txtAsset.text;
        SimpleJSON.JSONNode data = SimpleJSON.JSON.Parse(jsonString);
        int count = 0;
        foreach (SimpleJSON.JSONNode record in data["Oposum"])
        {
            Oposum_Spawn[count]=new Vector3(record["posX"].AsFloat, record["posY"].AsFloat,0);
            count++;
        }
        count = 0;
        foreach (SimpleJSON.JSONNode record in data["Frog"])
        {
            Frog_Spawn[count] = new Vector3(record["posX"].AsFloat, record["posY"].AsFloat, 0);
            count++;
        }
        count = 0;
        foreach (SimpleJSON.JSONNode record in data["Heal"])
        {
            Heal_Spawn[count] = new Vector3(record["posX"].AsFloat, record["posY"].AsFloat, 0);
            count++;
        }
        count = 0;
        foreach (SimpleJSON.JSONNode record in data["Checkpoints"])
        {
           
            CheckPoint_Spawn[count] = new Vector3(record["posX"].AsFloat, record["posY"].AsFloat, 0);
            count++;
        }
        count = 0;
        foreach (SimpleJSON.JSONNode record in data["miniCheckpoints"])
        {
            miniCheckPoint_Spawn[count] = new Vector3(record["posX"].AsFloat, record["posY"].AsFloat, 0);
            count++;
        }
        count = 0;
        foreach (Vector3 i in Frog_Spawn){
            Instantiate(Frog, i, Quaternion.identity);
        }
        foreach (Vector3 i in Oposum_Spawn){
            Instantiate(Oposum, i, Quaternion.identity);
        }
        foreach (Vector3 i in Heal_Spawn){
            Instantiate(Heal, i, Quaternion.identity);
        }
        foreach (Vector3 i in CheckPoint_Spawn)
        {
            Instantiate(Checkpoint, i, Quaternion.identity);
        }
        foreach (Vector3 i in miniCheckPoint_Spawn)
        {
            Instantiate(miniCheckpoint, i, Quaternion.identity);
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
