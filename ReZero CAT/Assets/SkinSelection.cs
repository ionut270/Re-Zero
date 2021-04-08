using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinSelection : MonoBehaviour
{
    public GameObject[] skins;
    private GameObject[] skin= new GameObject[3];
    private int selectedSkin = 0;

    void Start() {
        for (int i = 0; i < 3; i++)
        {
         skin[i] = Instantiate(skins[i], new Vector3(0 * 2.0F, 0, 0), Quaternion.identity) as GameObject;
          
            skin[i].SetActive(false);
            skin[i].transform.SetParent(GameObject.FindGameObjectWithTag("Skin").transform, false);
           
        }

        skin[0].SetActive(true);
        selectedSkin = 0;

    }

    public void NextSkin() {
        Debug.Log(selectedSkin);
        skin[selectedSkin].SetActive(false);
        selectedSkin = (selectedSkin + 1) % skins.Length;
        Debug.Log(selectedSkin);
        skin[selectedSkin].SetActive(true);
        Debug.Log(selectedSkin);
    }
    public void PreviousSkin() {
        skin[selectedSkin].SetActive(false);
        selectedSkin--;
        if (selectedSkin < 0)
        {
            selectedSkin += skins.Length;
        }
        skin[selectedSkin].SetActive(true);
    }

}
