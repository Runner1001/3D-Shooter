using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 5;

    private int currentHealth;

    public event Action OnTookHit = delegate { };
    public event Action OnDied = delegate { };
    public event Action<int, int> OnHealthChanged = delegate { };

    private void OnEnable()
    {
        currentHealth = health;
    }

    public void TakeHit(int damage)
    {
        if (currentHealth <= 0)
            return;

        ModifyHealth(-damage);

        if (currentHealth > 0)
        {
            OnTookHit();
        }
        else
        {
            OnDied();
        }
    }

    private void ModifyHealth(int amount)
    {
        currentHealth += amount;
        OnHealthChanged(currentHealth, health);
    }
}
