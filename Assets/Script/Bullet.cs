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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            col.transform.parent.GetComponent<EnemyMortality>().TakeDamage(damage);
            Destroy(gameObject);
            Debug.Log("TakeDamage");
        }
        else if (col.CompareTag("Enviroment"))
        {
            Destroy(gameObject);
        }
    }
}
