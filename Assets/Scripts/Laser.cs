using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    Rigidbody2D rb;
    public float force;

    AIMovement aiMove;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        aiMove = FindObjectOfType<AIMovement>();

        transform.up = aiMove.targetDirection;

        rb.AddForce(transform.up * force, ForceMode2D.Impulse);
        Destroy(this.gameObject, 1);
    }
}
