using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class PlayerMortality : MonoBehaviour
{
    public int health;
    public Image[] healthUI;
    int maxHealth;

    void Start()
    {
        maxHealth = healthUI.Length;
    }

    public void IncreaseHealth(int health)
    {
        this.health += health;

        if (this.health >= maxHealth)
            this.health = maxHealth;
    }
    
    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            health = 0;
            SceneController.Instance.ReloadScene();
        }
        healthUI[health].gameObject.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            SceneController.Instance.ReloadScene();
        }
        healthUI[health].gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }
}

