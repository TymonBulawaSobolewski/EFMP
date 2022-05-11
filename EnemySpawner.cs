using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnrate = 0.3f;

    public float lastspawned;

    public List<GameObject> spawnPoints;

    public GameObject enemy;
    int index;

    private GameObject chosenSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastspawned> 1 / spawnrate)
        {
            lastspawned = Time.time;
            Spawn();
            
        }
    }

    void Spawn()
    {
        index = Random.Range(0, spawnPoints.Count);
        chosenSpawn = spawnPoints[index];
        Instantiate(enemy, chosenSpawn.transform.position, chosenSpawn.transform.rotation);
    }
}
