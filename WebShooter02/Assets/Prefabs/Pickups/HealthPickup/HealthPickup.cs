using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    PlayerHealth playerHealth;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerHealth = FindObjectOfType<PlayerHealth>();
            playerHealth.RestoreHealth();

            Destroy(gameObject);
        }
    }
}
