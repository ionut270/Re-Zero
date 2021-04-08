using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float shakeTimeRemaining, shakePower, shakeFadeTime, shakeRotation;
    public float rotationMultiplier;
    void Start()
    {
        
    }
    void Update(){
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartShake(.5f, .1f);
        }
    }

    private void LateUpdate()
    {
        if(shakeTimeRemaining > 0)
        {
            shakeTimeRemaining -= Time.deltaTime;

            float xAmount = Random.Range(-1f, 1f) * this.shakePower;
            float yAmount = Random.Range(-1f, 1f) * this.shakePower;

            transform.position += new Vector3(xAmount, yAmount, 0f);

            this.shakePower = Mathf.MoveTowards(this.shakePower, 0f, this.shakeFadeTime * Time.deltaTime);

            this.shakeRotation = Mathf.MoveTowards(this.shakeRotation, 0f, this.shakeFadeTime * rotationMultiplier * Time.deltaTime);
        }

        transform.rotation = Quaternion.Euler(0f, 0f, this.shakeRotation * Random.Range(-1f, 1f));
    }

    public void StartShake(float length, float power){
        this.shakeTimeRemaining = length;
        this.shakePower = power;

        this.shakeFadeTime = power / length;
        this.shakeRotation = power * this.rotationMultiplier;
    }
}
