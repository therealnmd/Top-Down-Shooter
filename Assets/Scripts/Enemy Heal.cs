using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeal : Enemy
{
    [SerializeField] private float healedHP = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.TakenDamage(firstTouchDmg);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.TakenDamage(persistentDmg);
            }
        }
    }

    private void HealPlayer()
    {
        if (player != null)
        {
            player.Heal(healedHP);
        }
    }

    protected override void Die()
    {
        HealPlayer();
        base.Die();
    }
}
