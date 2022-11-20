using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootPoint;
    void Update()
    {
        Shoot();
    }
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(bullet, shootPoint.position, transform.rotation);
        }
    }
}
