using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawObs : MonoBehaviour
{
    private PlayerMortality _playerMortality;

    private void Awake()
    {
        _playerMortality = FindObjectOfType<PlayerMortality>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Destroy(gameObject);
            _playerMortality.TakeDamage();
        }
        
        else if (col.CompareTag("Enviroment"))
        {
            Destroy(gameObject);
        }
    }
}
