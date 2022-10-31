using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIAmmoText : MonoBehaviour
{
    private TMP_Text text;
    private WeaponAmmo currentWeaponAmmo;

    void Awake()
    {
        text = GetComponent<TMP_Text>();
        Inventory.OnWeaponChanged += Inventory_OnWeaponChanged;
    }

    private void Inventory_OnWeaponChanged(Weapon weapon)
    {
        if(currentWeaponAmmo != null)
        {
            currentWeaponAmmo.OnAmmoChange -= CurrentWeaponAmmo_OnAmmoChange;
        }

        currentWeaponAmmo = weapon.GetComponent<WeaponAmmo>();

        if(currentWeaponAmmo != null)
        {
            currentWeaponAmmo.OnAmmoChange += CurrentWeaponAmmo_OnAmmoChange;
            text.SetText(currentWeaponAmmo.GetAmmoText());
        }
        else
        {
            text.SetText("Unlimited");
        }
    }

    private void CurrentWeaponAmmo_OnAmmoChange()
    {
        text.SetText(currentWeaponAmmo.GetAmmoText());
    }
}
