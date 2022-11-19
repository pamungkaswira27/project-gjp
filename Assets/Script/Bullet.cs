using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed, damage, destroyTime;

    private void Awake()
    {
        Destroy(gameObject,destroyTime);
    }
    void Update()
    {
        transform.Translate(Vector2.right *speed*Time.deltaTime);    
    }
}
