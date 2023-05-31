using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacles;

    private float spawnDelay = 2f;
    private float spawnRate = 2f;

    private PlayerController _playerController;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", spawnDelay, spawnRate);
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (!_playerController.GameOver)
        {
            GameObject randomObstacle = obstacles[Random.Range(0, obstacles.Length)];
            Instantiate(randomObstacle, this.transform.position, randomObstacle.transform.rotation);

        }
    }

    
}
