using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser2 : MonoBehaviour
{
    public float force;
    public float damage;

    private Rigidbody2D rb;
    private Aim aim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        aim = FindObjectOfType<Aim>();

        transform.up = aim.aimDirection;

        rb.AddForce(transform.up * force, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("Obstacle"))
            Destroy(this.gameObject);

        else
            Destroy(this.gameObject, 3);
    }
}
