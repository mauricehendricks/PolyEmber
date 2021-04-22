using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Vector2 xRange;
    public float zCoord = 14f;
    public GameObject enemyPrefab;
    public float spawnInterval = 3f;
    float timer = 5f;
    int point=0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SpawnEnemy();
            timer = spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        float randX = Random.Range(xRange.x, xRange.y);

        Instantiate(enemyPrefab, new Vector3(randX, 0, zCoord), Quaternion.identity);
    }
}
