using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public Transform targetTransform;
    public LayerMask targetLayerMask;

    public float moveSpeed;

    private Vector2 targetDirection = Vector2.zero;
    private float distanceToTarget = 0.0f;

    private const int MAX_DISTANCE_TO_TARGET = 6;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        targetDirection = targetTransform.position - this.transform.position;
        MoveTowardsTarget(distanceToTarget);
    }
    private void MoveTowardsTarget(float distance)
    {
        distance = targetDirection.magnitude;

        targetDirection.Normalize();

        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, targetDirection, distance, targetLayerMask);

        if (distance >= MAX_DISTANCE_TO_TARGET && !hit)
            rb.velocity = new Vector2(targetDirection.x * moveSpeed, rb.velocity.y);

        else if (distance >= MAX_DISTANCE_TO_TARGET && hit)
            rb.velocity = targetDirection * moveSpeed;
    }
}
