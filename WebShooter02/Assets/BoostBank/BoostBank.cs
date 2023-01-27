using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostBank : MonoBehaviour
{
    [SerializeField] int damageBostCount = 0;

    public void AddDamageBoost(GameObject boost)
    {
        damageBostCount++;
    }
}
