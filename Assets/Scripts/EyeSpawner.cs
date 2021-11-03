using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeSpawner : MonoBehaviour
{
    public GameObject eyeDrone;
    public Transform spawnPoint;

    public List<GameObject> droneEyes = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

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
            {
                SpawnEyes(eye, spawnPoint);
            }
        }

        for (int i = 1; i < droneEyes.Count -1; i++)
        {
            Vector2 direction = droneEyes[i].
        }
    }

    private void SpawnEyes(GameObject eye, Transform spawn)
    {
        Instantiate(eye, new Vector2(spawn.position.x, spawn.position.y + Random.Range(-5, 5)), Quaternion.identity);
    }
}
