using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRatePickup : MonoBehaviour
{
    BoostBank boostBank;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            boostBank = FindObjectOfType<BoostBank>();
            boostBank.AddFireRateBoost();

            Destroy(gameObject);
        }
    }
}
