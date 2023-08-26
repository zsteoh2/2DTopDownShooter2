using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
   [SerializeField] private GameObject enemyPrefab;

   [SerializeField] private float minumumSpawnTime;

   [SerializeField] private float maximumSpawnTime;

    private float timeUntilSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        setTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;

        if(timeUntilSpawn <= 0)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            setTimeUntilSpawn();
        }
    }
    private void setTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minumumSpawnTime, maximumSpawnTime);
    }
}
