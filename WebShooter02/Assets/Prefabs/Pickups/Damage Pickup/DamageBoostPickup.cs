using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoostPickup : MonoBehaviour
{
    BoostBank boostBank;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            boostBank = FindObjectOfType<BoostBank>();
            boostBank.AddDamageBoost();

            Destroy(gameObject);
        }
    }
}
