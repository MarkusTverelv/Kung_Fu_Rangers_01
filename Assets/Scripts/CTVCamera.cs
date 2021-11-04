using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTVCamera : MonoBehaviour
{
    public GameObject obstacle;
    private Transform targetTransform;
    float timer;
    public float spawnRate;

    private void Start()
    {
        targetTransform = GameObject.Find("Player").transform;
    }
    private void LookAtTarget(Vector2 dir)
    {
        float lookAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, lookAngle - 90);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timer += Time.deltaTime;
            LookAtTarget(targetTransform.position - transform.position);

            if (timer >= spawnRate)
            {
                Instantiate(obstacle, new Vector2(targetTransform.position.x + 5, targetTransform.position.y), Quaternion.identity);
                timer = 0.0f;
            }
        }
    }
}
