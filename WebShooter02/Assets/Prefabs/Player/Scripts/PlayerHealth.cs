using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 150f;

    Bank bank;

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);

            bank = FindObjectOfType<Bank>();
            bank.SetStartBalance();
        }
    }
}
