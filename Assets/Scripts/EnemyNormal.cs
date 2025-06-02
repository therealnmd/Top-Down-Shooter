using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNormal : Enemy
{ 
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
}
