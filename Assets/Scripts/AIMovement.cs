using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public GameObject laser;
    public LayerMask targetLayerMask;
    public Vector2 targetDirection = Vector2.zero;

    public float moveSpeed;
    public float fireRate;
    public float timer;

    private const int MAX_DISTANCE_TO_TARGET = 4;

    private Rigidbody2D rb;
    private Transform targetTransform;

    private void Awake()
    {
        targetTransform = GameObject.Find("Target").transform;
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

        timer += Time.deltaTime;

        if (timer >= fireRate)
            FireLaser(laser);

        MoveTowardsTarget();
        LookAtTarget(targetDirection);
    }
    private void MoveTowardsTarget()
    {
        float distance = targetDirection.magnitude;
        targetDirection.Normalize();

        if (distance >= MAX_DISTANCE_TO_TARGET)
            rb.velocity = targetDirection * moveSpeed;
    }
    private void LookAtTarget(Vector2 dir)
    {
        float lookAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rb.rotation = lookAngle;
    }
    private void FireLaser(GameObject laser)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, targetDirection, 10, targetLayerMask);

        if (hit)
            Instantiate(laser, transform.position, transform.rotation);

        timer = 0.0f;
    }

}
