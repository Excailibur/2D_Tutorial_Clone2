using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    [SerializeField] float spawnRate = 2f;
    [SerializeField] GameObject enemyPrefab;

    float xMin;
    float xMax;
    float ySpawn;

    void Start()
    {
        xMin = Camera.main.ViewportToWorldPoint(new Vector3(.1f, 0, 0)).x;
        xMax = Camera.main.ViewportToWorldPoint(new Vector3(.9f, 0, 0)).x;
        ySpawn = Camera.main.ViewportToWorldPoint(new Vector3(0, 1.25f, 0)).y;

        InvokeRepeating("Spawn_Enemies",0,spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn_Enemies()
    {
        float randX = Random.Range(xMin, xMax);
        Vector3 randPos = new Vector3(randX, ySpawn, 0);

        Instantiate(enemyPrefab,randPos,Quaternion.identity);
    }
}
