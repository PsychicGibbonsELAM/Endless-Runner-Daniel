using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Create public array of objects to spawn, we willfill this with unity editor
    public GameObject[] objectsToSpawn;
    float timeToNextSpawn;       //Tracks how long we should wait to spawn a new object
    float timeSinceLastSpawn = 0.0f;    //Tracks time since we last spawned an object
    public float minSpawnTime = 0.5f;    // Minimum amount of time between spawning objects
    public float maxSpawnTime = 3.0f;    // Maximum amount of time between spawning objects
    void Start()
    {
        timeToNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);   //Returns a random float between two values
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn = timeSinceLastSpawn + Time.deltaTime;  // Adding delta time add amount of time since last frame - Creates a float that counts up in seconds 

        //   if weve counted up amount of time we need to wait
        if (timeSinceLastSpawn > timeToNextSpawn)
        {
            int selection = Random.Range(0, objectsToSpawn.Length);    // Selects a random number under the amount of objects that can be randomly spawned
            Instantiate(objectsToSpawn[selection], transform.position, Quaternion.identity);   //this is for the position of the spawned object 
            timeToNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);   //set a new random time till next object is spawned
            timeSinceLastSpawn = 0.0f;
        }
    }
}
