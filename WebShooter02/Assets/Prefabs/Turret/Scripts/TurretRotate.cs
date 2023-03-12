using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotate : MonoBehaviour
{
    [SerializeField] Transform target;

    [SerializeField] float TriggerRange = 19f;
    [SerializeField] float turnSpeed = 20f;

    public float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    private void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (isProvoked)
        {
            GunMove();
        }
        else if (distanceToTarget <= TriggerRange)
        {
            isProvoked = true;
        }
    }

    private void GunMove()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, turnSpeed * Time.deltaTime);
    }
}
