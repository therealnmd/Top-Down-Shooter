using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float enemySpeed = 5f;
    protected Player player;

    [SerializeField] protected float maxHP = 20f;
    protected float currentHP;
    [SerializeField] protected Image hpBar;

    [SerializeField] protected float firstTouchDmg = 100f; //dmg first hit player
    [SerializeField] protected float persistentDmg = 1f; //dmg continue after hit but player dont run away
    protected virtual void Start() //virtual cho phép các class con có thể ghi đè thêm vào hàm Start này
    {
        player = FindAnyObjectByType<Player>();
        currentHP = maxHP;
        UpdateHpBar();
    }

    protected virtual void Update() //tương tự Start
    {
        MoveToPlayer();
    }

    protected void MoveToPlayer()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime); //enemy luôn di chuyển và hướng về phía player
        }
        FlipEnemy();
    }

    protected void FlipEnemy()
    {
        if (player != null)
        {
            if (player.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (player.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    public virtual void TakenDamage(float dmg)
    {
        currentHP -= dmg;
        currentHP = Mathf.Max(currentHP, 0);
        UpdateHpBar();
        if (currentHP <= 0)
            Die();
    }

    protected virtual void Die()
    {
        currentHP = 0;
        Destroy(gameObject);
    }

    protected void UpdateHpBar()
    {
        if (hpBar != null)
        {
            hpBar.fillAmount = currentHP / maxHP;
        }
    }
}
