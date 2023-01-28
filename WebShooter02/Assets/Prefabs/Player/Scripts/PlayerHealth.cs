using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxHealth = 150f;
    [SerializeField] float currentHealth = 150f;

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);           
        }
    }

    public void RestoreHealth()
    {
        currentHealth = maxHealth;
    }
}
