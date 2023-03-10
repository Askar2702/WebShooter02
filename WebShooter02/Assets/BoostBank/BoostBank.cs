using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BoostBank : MonoBehaviour
{
    [Header("Damage Boost")]
    [SerializeField] int damageBoostCount = 0;
    [SerializeField] float gunDamageMultiplier = 3f;

    [SerializeField] float damageBoostActiveTime = 10f;
    public float damageBoostTime = 0;

    [Header("Fire Rate Boost")]
    [SerializeField] int fireRateBoostCount = 0;
    [SerializeField] float fireRateMultiplier = 2f;

    [SerializeField] float fireRateBoostActiveTime = 10f;
    public float fireRateBoostTime = 0;

    [Header("Speed Boost")]
    [SerializeField] int speedBoostCount = 0;
    [SerializeField] int speedMultiplier = 10;
    [SerializeField] float jumpForceMultiplier = 10f;

    [SerializeField] float speedBoostActiveTime = 10f;
    public float speedBoostTime = 0;


    TextMeshProUGUI damageBoostText;
    TextMeshProUGUI speedBoostText;
    TextMeshProUGUI fireRateBoostText;

    GunScript gunScript;
    PlayerMovementScript playerMovementScript;

    bool damageBoostIsActive = false;
    bool fireRateBoostIsActive = false;
    bool speedBoostIsActive = false;

    private void Update()
    {
        DamageBoost();

        FireRateBoost();

        SpeedBoost();

        // Bost display update
        DamageBoostDisplayUpdate();
        SpeedBoostDisplayUpdate();
        FireRateBoostDisplayUpdate();
    }

    private void DamageBoost()
    {
        gunScript = FindObjectOfType<GunScript>();

        if (Input.GetKeyDown(KeyCode.Alpha1) && damageBoostCount > 0 && damageBoostIsActive != true)
        {
            gunScript.gunDamage = gunScript.gunDamage * gunDamageMultiplier;

            damageBoostIsActive = true;

            damageBoostCount--;
        }

        if (damageBoostIsActive == true)
        {
            damageBoostTime = damageBoostTime + 1f * Time.deltaTime;

            if (damageBoostTime >= damageBoostActiveTime)
            {
                gunScript.gunDamage = gunScript.gunDamage / gunDamageMultiplier;

                damageBoostIsActive = false;

                damageBoostTime = 0;
            }
        }
    }

    private void FireRateBoost()
    {
        gunScript = FindObjectOfType<GunScript>();

        if (Input.GetKeyDown(KeyCode.Alpha2) && fireRateBoostCount > 0 && fireRateBoostIsActive != true)
        {
            gunScript.RoundsPerSecond = gunScript.RoundsPerSecond + fireRateMultiplier;

            fireRateBoostIsActive = true;

            fireRateBoostCount--;
        }

        if (fireRateBoostIsActive == true)
        {
            fireRateBoostTime = fireRateBoostTime + 1f * Time.deltaTime;

            if (fireRateBoostTime >= fireRateBoostActiveTime)
            {
                gunScript.RoundsPerSecond = gunScript.RoundsPerSecond - fireRateMultiplier;

                fireRateBoostIsActive = false;

                fireRateBoostTime = 0;
            }
        }
    }

    private void SpeedBoost()
    {
        playerMovementScript = FindObjectOfType<PlayerMovementScript>();

        if (Input.GetKeyDown(KeyCode.Alpha3) && speedBoostCount > 0 && speedBoostIsActive != true)
        {
            playerMovementScript.accelerationSpeed = playerMovementScript.accelerationSpeed * speedMultiplier;
            playerMovementScript.jumpForce = playerMovementScript.jumpForce * jumpForceMultiplier;

            speedBoostIsActive = true;

            speedBoostCount--;
        }

        if (speedBoostIsActive == true)
        {
            speedBoostTime = speedBoostTime + 1f * Time.deltaTime;

            if (speedBoostTime >= speedBoostActiveTime)
            {
                playerMovementScript.accelerationSpeed = playerMovementScript.accelerationSpeed / speedMultiplier;
                playerMovementScript.jumpForce = playerMovementScript.jumpForce / jumpForceMultiplier;

                speedBoostIsActive = false;

                speedBoostTime = 0;
            }
        }
    }

    public void AddDamageBoost()
    {
        damageBoostCount++;
    }

    public void AddFireRateBoost()
    {
        fireRateBoostCount++;
    }

    public void AddSpeedBoost()
    {
        speedBoostCount++;
    }

    public void DamageBoostDisplayUpdate()
    {
        damageBoostText = GameObject.Find("Damage Boost Text").GetComponent<TextMeshProUGUI>();
        damageBoostText.text = $"{damageBoostCount}";
    }

    public void SpeedBoostDisplayUpdate()
    {
        speedBoostText = GameObject.Find("Speed Boost Text").GetComponent<TextMeshProUGUI>();
        speedBoostText.text = $"{speedBoostCount}";
    }

    public void FireRateBoostDisplayUpdate()
    {
        fireRateBoostText = GameObject.Find("Fire Rate Boost Text").GetComponent<TextMeshProUGUI>();
        fireRateBoostText.text = $"{fireRateBoostCount}";
    }
}
