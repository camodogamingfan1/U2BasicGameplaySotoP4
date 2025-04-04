using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    public GameObject winePrefab;
    private float spawnPosX;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        GameObject prefabToSpawn = animalPrefabs[animalIndex];

        // Adjust Y position based on prefab's original Y position
        float spawnHeight = prefabToSpawn.GetComponent<Collider>().bounds.extents.y;

        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnHeight, spawnPosZ);
        Instantiate(prefabToSpawn, spawnPos, prefabToSpawn.transform.rotation);
    }
    void SpawnWine(string name)
    {
        // Instantiate the wine prefab at position (0, 2, 0)
        GameObject wine = Instantiate(winePrefab, new Vector3(0, 1, 0), Quaternion.identity);

        // Adjust the spawn position based on the object's size (using the collider's bounds)
        Collider wineCollider = wine.GetComponent<Collider>();
        if (wineCollider != null)
        {
            // Adjust the spawn height so it appears above the ground, taking the collider's height into account
            float heightOffset = wineCollider.bounds.extents.y;
            wine.transform.position = new Vector3(wine.transform.position.x, 2 + heightOffset, wine.transform.position.z);
        }

        // Optionally set the name if needed
        wine.name = name;
    }



}
