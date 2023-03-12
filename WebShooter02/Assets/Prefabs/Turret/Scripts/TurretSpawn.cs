using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawn : MonoBehaviour
{
    [SerializeField] float TriggerRange = 19f;

    [SerializeField] Transform target;

    [SerializeField] TurretRotate towerRotate;
    [SerializeField] CannonRotate cannonRotate;

    public float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    bool canShoot = false;

    void Start()
    {
        towerRotate.enabled = false;
        cannonRotate.enabled = false;
    }

    IEnumerator startCoroutine()
    {
        yield return new WaitForSeconds(1.2f);

        canShoot = true;
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (isProvoked)
        {
            GetComponent<Animator>().SetTrigger("IsProvoked ");
            StartCoroutine(startCoroutine());
        }
        else if (distanceToTarget <= TriggerRange)
        {
            isProvoked = true;
        }

        if (canShoot == true)
        {
            cannonRotate.enabled = true;
            towerRotate.enabled = true;
        }
    }
}
