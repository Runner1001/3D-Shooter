using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimator : MonoBehaviour
{
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();

        GetComponent<Health>().OnTookHit += ZombieAnimator_OnTookHit;
        GetComponent<Health>().OnDied += ZombieAnimator_OnDied;
        GetComponent<ZombieAttack>().OnAttack += ZombieAnimator_OnAttack;
    }

    private void ZombieAnimator_OnAttack()
    {
        anim.SetInteger("AttackId", UnityEngine.Random.Range(1, 3));
        anim.SetTrigger("Attack");
    }

    private void ZombieAnimator_OnDied()
    {
        anim.SetTrigger("Die");
    }

    private void ZombieAnimator_OnTookHit()
    {
        anim.SetTrigger("Hit");
    }
}
