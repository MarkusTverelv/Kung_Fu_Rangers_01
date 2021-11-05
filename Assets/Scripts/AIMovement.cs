using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public GameObject laser;
    public Vector2 targetDirection = Vector2.zero;

    public float moveSpeed;
    public float fireRate;
    public float timer;

    private AudioSource audioSource;
    public AudioClip laserSFX;

    private Rigidbody2D rb;
    private Transform targetTransform;

    private const int MAX_DISTANCE_TO_TARGET = 6;
    private float distanceToTarget;

    private void Awake()
    {
        targetTransform = GameObject.Find("Player").transform;
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        targetDirection = targetTransform.position - transform.position;
        distanceToTarget = targetDirection.magnitude;

        LookAtTarget(targetDirection);
        MoveTowardsTarget(distanceToTarget);

        if (Vector2.Distance(targetTransform.position, transform.position) <= 15)
        {
            timer += Time.deltaTime;

            if (timer >= fireRate + Random.Range(.1f, .5f))
                FireLaser(laser);
        }
        else
            return;
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

    private void FireLaser(GameObject laser)
    {
        audioSource.PlayOneShot(laserSFX);
        Instantiate(laser, this.transform.Find("FirePoint").position, transform.rotation);
        timer = 0.0f;
    }
}