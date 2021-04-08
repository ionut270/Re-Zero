using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mask : MonoBehaviour
{
    [Range(0.05f, 0.2f)]
    public float flicTime;


    [Range(0.02f, 0.09f)]
    public float addSize;

    float timer = 0;
    private bool bigger = true;
    public Transform target;
    
}
