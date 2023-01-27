using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] float bulletsPickupNumber = 50;
    GunScript gunScript;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gunScript = FindObjectOfType<GunScript>();
            gunScript.IncreaseBulletNumber(bulletsPickupNumber);
            Destroy(gameObject);
        }
    }
}
