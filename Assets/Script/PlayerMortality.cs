using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerMortality : MonoBehaviour
{
    public int health;
    public GameObject[] healthUI;


    
    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            health = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        healthUI[health].SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }
}
