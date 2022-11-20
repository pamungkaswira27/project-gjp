using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour
{
    public EnemyDetector detector;

    public GameObject bullet;
    public Transform shootPoint;
    public float fireRate;

    float shootTime;

    void Start()
    {
        shootTime = fireRate;
    }

    void Update()
    {
        if (detector.isPlayerDetected)
        {
            fireRate -= Time.deltaTime;

            if (fireRate <= 0)
            {
                Shoot();
                fireRate = shootTime;
            }
        }
    }

    void Shoot()
    {
        Instantiate(bullet, shootPoint.position, Quaternion.identity);
    }
}
