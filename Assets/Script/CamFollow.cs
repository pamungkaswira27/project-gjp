using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform playerPos;
    public Vector3 offset;
    public float cameraSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playerPos.position+offset,
            cameraSpeed * Time.deltaTime);
    }
}
