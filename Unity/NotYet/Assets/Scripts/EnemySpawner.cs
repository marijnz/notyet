﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

    public List<Transform> EnemyPrefabs;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnEnemies());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(2.0f);

        }
        
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-15, 15);
        float randomY = 18;

        Transform instance = (Transform)Instantiate(EnemyPrefabs[Random.Range(0, EnemyPrefabs.Count - 1)], new Vector3(randomX, randomY), Quaternion.identity);

        instance.GetComponent<Rigidbody2D>().AddForce(new Vector3(Random.Range(-50, 50),0));

    }
}
