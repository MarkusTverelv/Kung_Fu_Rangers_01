using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public GameObject laser;
    public GameObject healthBar;

    public Vector2 targetDirection = Vector2.zero;

    public float moveSpeed;
    public float fireRate;
    public float timer;

    private Rigidbody2D rb;
    private Transform targetTransform;

    private const int MAX_DISTANCE_TO_TARGET = 6;
    private float distanceToTarget;

    private void Awake()
    {
        targetTransform = GameObject.Find("Target").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Instantiate(healthBar, Camera.main.WorldToScreenPoint(transform.position), Quaternion.identity, GameObject.Find("Canvas").transform);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 followPosition = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + .6f, transform.position.z));
        healthBar.transform.position = followPosition;

        targetDirection = targetTransform.position - transform.position;
        distanceToTarget = targetDirection.magnitude;

        LookAtTarget(targetDirection);
        MoveTowardsTarget(distanceToTarget);
    }
    private void LookAtTarget(Vector2 dir)
    {
        float lookAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rb.rotation = lookAngle;
    }

    private void MoveTowardsTarget(float distance)
    {
        targetDirection.Normalize();

        if (distance > MAX_DISTANCE_TO_TARGET)
            rb.velocity = targetDirection * moveSpeed;

        else if (distance <= MAX_DISTANCE_TO_TARGET)
            transform.RotateAround(targetTransform.position, Vector3.forward, 50 * Time.deltaTime);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timer += Time.deltaTime;

            if (timer >= fireRate)
                FireLaser(laser);
        }
    }

    private void FireLaser(GameObject laser)
    {
        Instantiate(laser, this.transform.Find("FirePoint").position, transform.rotation);
        timer = 0.0f;
    }
}
