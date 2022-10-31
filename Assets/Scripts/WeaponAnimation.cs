using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class WeaponAnimation : WeaponComponent
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    protected override void WeaponFired()
    {
        anim.SetTrigger("Fire");
    }
}
