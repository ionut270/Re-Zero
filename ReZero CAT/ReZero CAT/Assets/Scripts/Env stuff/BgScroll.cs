using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroll : MonoBehaviour
{
    public Transform player;
    public float move = .5f;

    void Update()
    {
        transform.position = new Vector3(player.position.x * move, transform.position.y, transform.position.z);
    }
}

