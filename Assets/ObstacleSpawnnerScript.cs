
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnnerScript : MonoBehaviour
{
    [Header("Obstacle References")]
    public GameObject trainA;        
    public GameObject trainB;        
    public GameObject trainC;        
    public GameObject trainD;        

    public GameObject trainABObs1;   
    public GameObject trainABObs;    
    public GameObject trainABObsHard;
    public GameObject trainABObs3;   

    [Header("Timing Settings")]
    public float initialDelay = 2f;
    public float spawnInterval = 5f;

    [Header("Difficulty Progression")]
    public float mediumThreshold = 10f; // seconds after which medium obstacles appear
    public float hardThreshold = 20f;   // seconds after which hard obstacles can appear

    private float elapsedTime = 0f;//time has passed since the start of the game




    private void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), initialDelay, spawnInterval);
    }

    private void Update()
    {
        // track elapsed time
        elapsedTime += Time.deltaTime;
    }

    private void SpawnObstacle()
    {
        GameObject obstacleToSpawn = ChooseObstacle();
       
    
        Vector3 spawnPos = new Vector3(0f, 0f, 50f);
        
        //  float[] lanePositions = { -2.5f, 2.5f };
        // float randomX = lanePositions[Random.Range(0, lanePositions.Length)];

        // Spawn position — random lane, fixed Z position
       // Vector3 spawnPos = new Vector3(randomX, 0f, 50f);


        Instantiate(obstacleToSpawn, spawnPos, Quaternion.identity);
    }

    private GameObject ChooseObstacle()
    {
        // Early game :easy obstacles only
        if (elapsedTime < mediumThreshold)
        {
            GameObject[] easySet = { trainA, trainB, trainC, trainD };
            int rand = Random.Range(0, easySet.Length);
            return easySet[rand];
        }
        // Mid game :medium obstacles
        else if (elapsedTime < hardThreshold)
        {
            GameObject[] mediumSet = { trainABObs1, trainABObs };
            int rand = Random.Range(0, mediumSet.Length);
            return mediumSet[rand];
        }
        // Late game : hard obstacles
        else
        {
            GameObject[] hardSet = { trainABObs1, trainABObs, trainABObsHard, trainABObs3 };
            int rand = Random.Range(0, hardSet.Length);
            return hardSet[rand];
        }
    }
}
