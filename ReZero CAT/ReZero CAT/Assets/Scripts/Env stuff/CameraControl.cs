using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform player;
    private float defHeight;
    private float minHeight = -20;

    void Start()
    {
        defHeight = transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(
            player.position.x,
            player.position.y < minHeight ? minHeight :
                                                    Mathf.Lerp(
                                                        transform.position.y,
                                                        player.position.y,
                                                        Time.deltaTime
                                                    ),
            transform.position.z
        );
    }
}
