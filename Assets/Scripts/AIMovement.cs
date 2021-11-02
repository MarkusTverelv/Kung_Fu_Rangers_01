using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public Transform targetTransform;
    private Vector2 targetDirection = Vector2.zero;
    private float distanceToTarget = 0.0f;
    public float moveSpeed;

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

        if (distance >= 2)
        {
            targetDirection.Normalize();
            rb.velocity = targetDirection * moveSpeed;
        }
    }


}
