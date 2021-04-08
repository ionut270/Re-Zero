using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oposumHead : MonoBehaviour
{
    public OposumHandler oposum;

    void Start() { }
    void Update() { }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player") { oposum.Die(); }
    }
}