using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float drawWeaponSpeed;
    [SerializeField] private float delayBeforeWeaponDown = 3f;

    private Coroutine currentFadeRoutine;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(currentFadeRoutine != null)
                StopCoroutine(currentFadeRoutine);

            currentFadeRoutine = StartCoroutine(FadeToShootingLayer());
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            currentFadeRoutine = StartCoroutine(FadeFromShootingLayer());
        }
    }

    private IEnumerator FadeFromShootingLayer()
    {
        yield return currentFadeRoutine;

        yield return new WaitForSeconds(delayBeforeWeaponDown);

        float currentWeight = anim.GetLayerWeight(1);
        float elapsed = 0;

        while (elapsed < drawWeaponSpeed)
        {
            elapsed += Time.deltaTime;
            currentWeight -= Time.deltaTime / drawWeaponSpeed;
            anim.SetLayerWeight(1, currentWeight);
            yield return null;
        }

        anim.SetLayerWeight(1, 0);
    }

    private IEnumerator FadeToShootingLayer()
    {
        float currentWeight = anim.GetLayerWeight(1);
        float elapsed = 0;

        while (elapsed < drawWeaponSpeed)
        {
            elapsed += Time.deltaTime;
            currentWeight += Time.deltaTime / drawWeaponSpeed;
            anim.SetLayerWeight(1, currentWeight);
            yield return null;
        }

        anim.SetLayerWeight(1, 1);
    }
}
