using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableChildrenOnEnter : MonoBehaviour
{
    void Awake()
    {      
        ToggleChildren(false);
    }

    private void ToggleChildren(bool state)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(state);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerMovement>() != null)
        {
            ToggleChildren(true);
        }
    }

    void OnValidate()
    {
        var collider = GetComponent<Collider>();

        if(collider == null)
        {
            collider = gameObject.AddComponent<SphereCollider>();
            ((SphereCollider)collider).radius = 15f;
        }

        collider.isTrigger = true;
    }
}
