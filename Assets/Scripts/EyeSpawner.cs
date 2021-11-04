using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeSpawner : MonoBehaviour
{
    public GameObject eyeDrone;
    public Transform spawnPoint;

    private List<GameObject> droneEyes = new List<GameObject>();

    private void Awake()
    {
        droneEyes.Add(eyeDrone);
        droneEyes.Add(eyeDrone);
        droneEyes.Add(eyeDrone);

        foreach (GameObject eye in droneEyes)
            SpawnEyes(eye, spawnPoint);
    }

    // Update is called once per frame
    void Update()
    {
        if (droneEyes.Count == 0)
        {
            droneEyes.Add(eyeDrone);
            droneEyes.Add(eyeDrone);
            droneEyes.Add(eyeDrone);

            foreach (GameObject eye in droneEyes)
                SpawnEyes(eye, spawnPoint);
        }
        else
            return;
    }

    private void SpawnEyes(GameObject eye, Transform spawn)
    {
        Instantiate(eye, new Vector2(spawn.position.x, spawn.position.y + Random.Range(-5, 5)), Quaternion.identity);
    }
}