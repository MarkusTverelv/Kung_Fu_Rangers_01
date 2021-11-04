using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float force;
    public float damage;

    private Rigidbody2D rb;
    private AIMovement aiMove;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        aiMove = FindObjectOfType<AIMovement>();

        transform.up = aiMove.targetDirection;

        rb.AddForce(transform.up * force, ForceMode2D.Impulse);
        Destroy(this.gameObject, 1);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Health>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("Obstacle"))
            Destroy(this.gameObject);

        else
            Destroy(this.gameObject, 3);
    }
}
