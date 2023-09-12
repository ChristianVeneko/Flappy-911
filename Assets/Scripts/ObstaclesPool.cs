using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesPool : MonoBehaviour
{
    [SerializeField] private GameObject towersPrefab;
    [SerializeField] private float spawnTime = 0.5f;
    [SerializeField] private int poolSize = 5;
    [SerializeField] private float xSpawnPosition;
    [SerializeField] private float minYPosition;
    [SerializeField] private float maxYPosition;



    public float timeElapsed;
    public int obstacleCount;
    private GameObject[] obstacles;
    void Start()
    {
        obstacles = new GameObject[poolSize];
        instanciateObstacles(towersPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= spawnTime && (!GameManager.Instance.isGameOver && GameManager.Instance.gameStarted))
        {
            SpawnObstacle();
        }
    }

    public void instanciateObstacles(GameObject prefab)
    {
        for (int i = 0; i < poolSize; i++)
        {
            obstacles[i] = Instantiate(prefab);
            obstacles[i].SetActive(false);
        }
    }

    public void SpawnObstacle()
    {
        timeElapsed = 0f;
        float ySpawnPosition = Random.Range(minYPosition, maxYPosition);
        Vector2 spawnPosition = new Vector2(xSpawnPosition, ySpawnPosition);
        obstacles[obstacleCount].transform.position = spawnPosition;

        if (!obstacles[obstacleCount].activeSelf)
        {
            obstacles[obstacleCount].SetActive(true);
        }

        obstacleCount++;

        if (obstacleCount == poolSize)
        {
            obstacleCount = 0;
        }
    }
}
