using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxHealth = 150f;
    [SerializeField] float currentHealth = 150f;

    [SerializeField] Image healthBar;

    DeathHandler deathHandler;

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        healthBar.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {     
            deathHandler = FindObjectOfType<DeathHandler>();
            deathHandler.HandleDeath();
        }
    }

    public void RestoreHealth()
    {
        currentHealth = maxHealth;

        healthBar.fillAmount = currentHealth / maxHealth;
    }

    // Тестовая часть
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Dummie")
        {
            TakeDamage(10);
        }

    }        
}
