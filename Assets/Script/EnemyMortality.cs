using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMortality : MonoBehaviour
{
    public float health;
    public Image healthUI;
    float maxhealth;
    void Start()
    {
        maxhealth = health;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        healthUI.fillAmount = health / maxhealth;
        if (health <= 0)
        {
            Destroy(gameObject) ;
        }

    }
}
