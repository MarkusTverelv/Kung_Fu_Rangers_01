using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeSpawner : MonoBehaviour
{
    public GameObject eyeDrone;
    public Transform spawnPoint;
    public List<GameObject> droneEyes = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (droneEyes.Count == 0)
        {
            droneEyes.Add(eyeDrone);
            droneEyes.Add(eyeDrone);
            droneEyes.Add(eyeDrone);

            foreach (GameObject eye in droneEyes)
            {
                SpawnEyes(eye, spawnPoint);
            }
        }

        for (int i = 0; i < droneEyes.Count - 1; i++)
        {
            Vector2 direction = droneEyes[i].transform.position - droneEyes[i + 1].transform.position;

            if (direction.magnitude <= 1)
            {
                droneEyes[i].transform.Translate(direction);
            }
        }
    }

    private void SpawnEyes(GameObject eye, Transform spawn)
    {
        Instantiate(eye, new Vector2(spawn.position.x, spawn.position.y + Random.Range(-5, 5)), Quaternion.identity);
    }
}
