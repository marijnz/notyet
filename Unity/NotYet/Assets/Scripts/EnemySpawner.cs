using UnityEngine;
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
            yield return new WaitForSeconds(1.0f);

        }
        
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-15, 15);
        float randomY = 15;

        Transform instance = (Transform)Instantiate(EnemyPrefabs[Random.Range(0, EnemyPrefabs.Count - 1)], new Vector3(randomX, randomY), Quaternion.identity);


    }
}
