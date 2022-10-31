using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] private Transform thirdPersonWeaponPoint;
    [SerializeField] private Transform firstPersonWeaponPoint;

    public bool IsFpsMode { get; set; }

    private void Update()
    {
        if (IsFpsMode)
        {
            transform.position = firstPersonWeaponPoint.position;
            transform.rotation = firstPersonWeaponPoint.rotation;
        }
        else
        {
            transform.position = thirdPersonWeaponPoint.position;
            transform.rotation = thirdPersonWeaponPoint.rotation;
        }
    }
}
