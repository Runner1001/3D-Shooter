using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public event Action OnFire = delegate { };

    [SerializeField] private KeyCode weaponHotKey;
    [SerializeField] private float fireDelay = 0.25f;

    private float fireTimer;
    private WeaponAmmo ammo;

    public KeyCode WeaponHotKey => weaponHotKey;
    public bool IsInAimMode { get { return Input.GetMouseButton(1) == false; } }

    void Awake()
    {
        ammo = GetComponent<WeaponAmmo>();
    }

    void Update()
    {

        fireTimer += Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            if (CanFire())
            {
                Fire();
            }
        }
    }

    private bool CanFire()
    {
        if(ammo != null && ammo.IsAmmoReady() == false)
            return false;

        return fireTimer >= fireDelay;
    }

    private void Fire()
    {
        fireTimer = 0;
        Debug.Log("shooting with a " + gameObject.name);
        OnFire();
    }
}
