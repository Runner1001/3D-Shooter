using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProjectileLauncher : WeaponComponent
{
    [SerializeField] private Transform firePoint;
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] private float speed = 40f;
    [SerializeField] private float maxDistance = 100;
    [SerializeField] private LayerMask layerMask;

    private RaycastHit hitInfo;

    protected override void WeaponFired()
    {
        Vector3 direction = weapon.IsInAimMode ? GetDirection() : firePoint.forward;

        var projectile = projectilePrefab.Get<Projectile>(firePoint.position, Quaternion.Euler(direction));
        projectile.GetComponent<Rigidbody>().velocity = direction * speed;
    }

    private Vector3 GetDirection()
    {
        var ray =Camera.main.ViewportPointToRay(Vector3.one / 2f);

        Vector3 target = ray.GetPoint(300);

        if(Physics.Raycast(ray, out hitInfo, maxDistance, layerMask))
        {
            target = hitInfo.point;
        }

        Vector3 direction = target - transform.position;
        direction.Normalize();

        return direction;
    }
}
