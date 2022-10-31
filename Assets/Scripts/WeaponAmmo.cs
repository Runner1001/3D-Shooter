using System;
using System.Collections;
using UnityEngine;

public class WeaponAmmo : WeaponComponent
{
    [SerializeField] private bool infiniteAmmo;
    [SerializeField] private int maxAmmo = 24;
    [SerializeField] private int maxAmmoPerClip = 6;

    private int ammoInClip;
    private int ammoRemainingNotInClip;

    public event Action OnAmmoChange = delegate { };

    protected override void Awake()
    {
        ammoInClip = maxAmmoPerClip;
        ammoRemainingNotInClip = maxAmmo - ammoInClip;
        base.Awake();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
    }

    public bool IsAmmoReady()
    {
        return ammoInClip > 0;
    }

    protected override void WeaponFired()
    {
        RemoveAmmo();
    }

    private void RemoveAmmo()
    {
        ammoInClip--;
        OnAmmoChange();
    }

    private IEnumerator Reload()
    {
        int ammoMissingFromClip = maxAmmoPerClip - ammoInClip;
        int ammoToMove = Math.Min(ammoMissingFromClip, ammoRemainingNotInClip);

        if (infiniteAmmo)
            ammoToMove = ammoMissingFromClip;

        while(ammoToMove > 0)
        {
            yield return new WaitForSeconds(0.3f);
            ammoInClip += 1;
            ammoRemainingNotInClip -= 1;
            OnAmmoChange();
            ammoToMove--;
        }
    }

    public string GetAmmoText()
    {
        if(infiniteAmmo)
            return string.Format("{0}/∞", ammoInClip, ammoRemainingNotInClip);
        else
            return string.Format("{0}/{1}", ammoInClip, ammoRemainingNotInClip);


    }
}