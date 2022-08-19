using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    public Transform[] generatePoints = null;

    public GameObject[] AsteroidPrefabs = null;

    public float AsteroidGenerateTime = 1f;
    private float asteroidGenerateTimer = 0f;

    private void GenerateAsteroid()
    {
        int asteroidIndex = Random.Range(0, AsteroidPrefabs.Length);
        int pointIndex = Random.Range(0, generatePoints.Length);

        GameObject asteroidPrefab = AsteroidPrefabs[asteroidIndex];
        Transform point = generatePoints[pointIndex];

        Instantiate(asteroidPrefab, point.position, Quaternion.identity);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        asteroidGenerateTimer += Time.deltaTime;
        if (asteroidGenerateTimer >= AsteroidGenerateTime)
        {
            GenerateAsteroid();
            asteroidGenerateTimer = 0;
        }
    }
}
