using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerObs : MonoBehaviour
{
    public GameObject sawObs;
    public float spawnTime;
    public float xPosMin, xPosMax;
    void Start()
    {
        StartCoroutine(SpawnObs());
    }

    void Update()
    {
    }

    IEnumerator SpawnObs()
    {
        yield return new WaitForSeconds(spawnTime);
        Instantiate(sawObs, new Vector2(Random.Range(xPosMin, xPosMax), transform.position.y), Quaternion.identity);
        StartCoroutine(SpawnObs());

    }
}
