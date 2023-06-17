using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMaster : MonoBehaviour
{
    public Spawner spawner1;

    public Spawner spawner2;

    public float spawnRate;

    public float spawnRateIncrease;

    public float spawnRateMax;

    private float spawnTimer;

    public CamerController cam;

    public GameObject[] objects;

    public GameObject[] obstacles;

    public GameObject[] initobjects;

    public GameObject[] initobstacles;

    // Start is called before the first frame update
    void Start()
    {
        initobjects = GameObject.FindGameObjectsWithTag("Collect");
        initobstacles = GameObject.FindGameObjectsWithTag("Obstacle");
    }

    // Update is called once per frame
    void Update()
    {
        objects = GameObject.FindGameObjectsWithTag("Collect");
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        if (cam.isMoving)
        {
            foreach (GameObject o in initobjects)
            {
                if (cam.distance > 0)
                {
                    o.SetActive(true);
                }
            }
            foreach (GameObject o in initobstacles)
            {
                if (cam.distance > 0)
                {
                    o.SetActive(true);
                }
            }

            // increment the spawn timer
            spawnTimer += Time.deltaTime;

            // spawn a new object if the timer is up
            if (spawnTimer >= spawnRate)
            {
                SpawnNotes();
                spawnTimer = 0;
            }

            // increase the spawn rate over time
            spawnRate =
                Mathf
                    .Min(spawnRate + (Time.deltaTime * spawnRateIncrease),
                    spawnRateMax);
        }
        else
        {
            foreach (GameObject o in objects)
            {
                if (cam.distance > 0) o.SetActive(false);
            }
            foreach (GameObject o in obstacles)
            {
                if (cam.distance > 0) o.SetActive(false);
            }
        }
    }

    void SpawnNotes()
    {
        int rand = Random.Range(-1, 1);
        int rand2 = Random.Range(1, 3);

        if (rand > 0)
        {
            spawner1.Spawn(1);
        }
        else
        {
            spawner2.Spawn (rand2);
        }
    }
}
