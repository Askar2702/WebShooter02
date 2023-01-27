using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] int moneyForDeath = 125;

    Bank bank;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);

            bank = FindObjectOfType<Bank>();
            bank.GetMoney(moneyForDeath);
        }
    }
}
