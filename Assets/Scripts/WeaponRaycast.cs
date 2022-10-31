using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRaycast : WeaponComponent
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private PooledMonoBehaviour decalPrefab;
    [SerializeField] private float maxDistance = 100;
    [SerializeField] private LayerMask layerMask;

    private RaycastHit hitInfo;

    protected override void WeaponFired()
    {
        Ray ray = weapon.IsInAimMode ? Camera.main.ViewportPointToRay(Vector3.one / 2f) : new Ray(firePoint.position, firePoint.forward);

        if(Physics.Raycast(ray, out hitInfo, maxDistance, layerMask))
        {
            var health = hitInfo.collider.GetComponent<Health>();

            if(health != null)
            {
                health.TakeHit(1);
            }
            else
            {
                SpawnDecal(hitInfo.point, hitInfo.normal);
            }

        }
    }

    private void SpawnDecal(Vector3 point, Vector3 normal)
    {
        var decal = decalPrefab.Get<PooledMonoBehaviour>(point, Quaternion.LookRotation(-normal));
        decal.ReturnToPool(2f);
    }
}
