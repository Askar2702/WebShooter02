﻿using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{

    [Tooltip("Furthest distance bullet will look for target")]
    public float maxDistance = 1000000;
    RaycastHit hit;
    [Tooltip("Prefab of wall damange hit. The object needs 'LevelPart' tag to create decal on it.")]
    public GameObject decalHitWall;
    [Tooltip("Decal will need to be sligtly infront of the wall so it doesnt cause rendeing problems so for best feel put from 0.01-0.1.")]
    public float floatInfrontOfWall;
    [Tooltip("Blood prefab particle this bullet will create upoon hitting enemy")]
    public GameObject bloodEffect;
    [Tooltip("Put Weapon layer and Player layer to ignore bullet raycast.")]
    public LayerMask ignoreLayer;

    [HideInInspector] public float damage;

    /*
	* Uppon bullet creation with this script attatched,
	* bullet creates a raycast which searches for corresponding tags.
	* If raycast finds somethig it will create a decal of corresponding tag.
	*/
    void Update()
    {
        ProccessRaycast(damage);
    }

    private void ProccessRaycast(float damage)
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, ~ignoreLayer))
        {
            EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
                CreateHitImpact(bloodEffect);
            }
            else
            {
                CreateHitImpact(decalHitWall);
            }
        }

        Destroy(gameObject, 0.1f);
    }

    private void CreateHitImpact(GameObject hitEffect)
    {
        GameObject hitGo = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));

        Destroy(hitGo, 0.1f);
        Destroy(gameObject);
    }
}
