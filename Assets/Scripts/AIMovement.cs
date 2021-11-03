using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    Rigidbody2D rb;

    private Transform targetTransform;
    public LayerMask targetLayerMask;

    public float moveSpeed;

    private Vector2 targetDirection = Vector2.zero;

    private const int MAX_DISTANCE_TO_TARGET = 4;

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
        targetDirection = targetTransform.position - this.transform.position;

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
}
