using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private const int MAX_HEALTH = 100;

    [HideInInspector]
    public float currentHealth = MAX_HEALTH;

    public void TakeDamage(float damageToTake)
    {
        currentHealth -= damageToTake;

        if (currentHealth <= 0)
            Destroy(this.gameObject);
    }
}
