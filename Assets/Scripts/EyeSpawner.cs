using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeSpawner : MonoBehaviour
{
    public GameObject eyeDrone;
    public Transform spawnPoint;

    private void Start()
    {
        InvokeRepeating("SpawnEyes", 3f, 10f);
    }

    private void SpawnEyes()
    {
        Instantiate(eyeDrone, new Vector2(spawnPoint.position.x, spawnPoint.position.y + Random.Range(-5, 5)), Quaternion.identity);
        Instantiate(eyeDrone, new Vector2(spawnPoint.position.x, spawnPoint.position.y + Random.Range(-5, 5)), Quaternion.identity);
    }
}