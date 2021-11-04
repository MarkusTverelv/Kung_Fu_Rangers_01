using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private const int MAX_HEALTH = 100;
    private float currentHealth = MAX_HEALTH;

    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        CalculateHealth();
    }

    // Use this method to change the fill value of a ui image
    private float CalculateHealth()
    {
        return currentHealth / MAX_HEALTH;
    }

    public void TakeDamage(float damageToTake)
    {
        currentHealth -= damageToTake;
        healthBar.fillAmount = CalculateHealth();
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
