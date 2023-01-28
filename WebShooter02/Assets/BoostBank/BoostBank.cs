using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostBank : MonoBehaviour
{
    [SerializeField] int damageBostCount = 0;
    [SerializeField] int fireRateBoostCount = 0;
    [SerializeField] int speedBoostCount = 0;
    public void AddDamageBoost() 
    {
        damageBostCount++;
    }

    public void AddFireRateBoost()
    {
        fireRateBoostCount++;
    }

    public void AddSpeedBoost()
    {
        speedBoostCount++;
    }
}
