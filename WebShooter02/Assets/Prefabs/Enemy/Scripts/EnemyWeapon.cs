using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] float damage = 10f;
    [SerializeField] float range = 1000f;

    [SerializeField] GameObject decalHitWall;
    [SerializeField] GameObject bloodEffect;

    private void Update()
    {
        StartCoroutine(Waiter());
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(4f);

        ProcessRaycast();
    }

    private void ProcessRaycast()
    { 
        RaycastHit hit;

        if(Physics.Raycast(gameObject.transform.position, transform.forward, out hit, range))
        {
            PlayerHealth target = hit.transform.GetComponent<PlayerHealth>();

            if(target != null)
            {
                CreateHitImpact(hit, decalHitWall);
                target.TakeDamage(damage);
            }
            else
            {
                CreateHitImpact(hit, bloodEffect);
            }
        }
    }

    private void CreateHitImpact(RaycastHit hit, GameObject hitEffect)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));

        Destroy(impact, 0.1f);
    }
}
