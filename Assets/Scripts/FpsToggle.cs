using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsToggle : MonoBehaviour
{
    [SerializeField]private GameObject[] firstPersonObjects;
    [SerializeField]private GameObject[] thirdPersonObjects;
    [SerializeField]private KeyCode toggleKey = KeyCode.F1;

    private bool isFpsMode;
    private Weapons weapons;

    private void Awake()
    {
        weapons = GetComponentInChildren<Weapons>();
    }

    private void OnEnable()
    {
        ToggleObjectsForCurrentMode();
    }

    private void Update()
    {
        if (Input.GetKeyUp(toggleKey))
        {
            Toggle();
        }
    }

    private void Toggle()
    {
        isFpsMode = !isFpsMode;
        weapons.IsFpsMode = isFpsMode;

        ToggleObjectsForCurrentMode();
    }

    private void ToggleObjectsForCurrentMode()
    {
        foreach (var gameObject in firstPersonObjects)
        {
            gameObject.SetActive(isFpsMode);
        }

        foreach (var gameObject in thirdPersonObjects)
        {
            gameObject.SetActive(!isFpsMode);
        }
    }
}
