using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    [SerializeField] private float delayBetweenAttacks = 1.5f;
    [SerializeField] private float maximumAttackRange = 1.5f;
    [SerializeField] private int damage = 1;
    [SerializeField] private float delayBetweenAnimationAndDamage = 1f;

    private float attackTimer;

    private Health playerHealth;

    public event Action OnAttack = delegate { };

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerMovement>().GetComponent<Health>();
    }

    private void Update()
    {
        attackTimer += Time.deltaTime;

        if (CanAttack())
        {
            attackTimer = 0;
            Attack();
        }
    }

    private bool CanAttack()
    {
        return attackTimer >= delayBetweenAttacks && Vector3.Distance(transform.position, playerHealth.transform.position) <= maximumAttackRange;
    }
    private void Attack()
    {
        OnAttack();
        StartCoroutine(DealDamageAfterDelay());
    }

    private IEnumerator DealDamageAfterDelay()
    {
        yield return new WaitForSeconds(delayBetweenAnimationAndDamage);
        playerHealth.TakeHit(damage);
    }
}
