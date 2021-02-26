using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Story : MonoBehaviour
{
    public GameObject continueButton;
    public GameObject skipButton;
    public VideoPlayer vid;
    // Start is called before the first frame update
    void Start()
    {
        skipButton.SetActive(false);
        //  Invoke("skipButtonWait()",2);
        StartCoroutine(skipButtonWait());
        continueButton.SetActive(false);
        vid.loopPointReached += endOfStory;
    }
    public void skipToNextScene() {
        SceneManager.LoadScene("GamePlay");

    }

    public void continueToNextScene() {
        SceneManager.LoadScene("GamePlay");
    }

    IEnumerator skipButtonWait()
    {
        print(Time.time);
        yield return new WaitForSeconds(2);
        print(Time.time);
        skipButton.SetActive(true);
    }
   
    void endOfStory(UnityEngine.Video.VideoPlayer vp)
    {
        continueButton.SetActive(true);
        print("Video Is Over");
    }
}
