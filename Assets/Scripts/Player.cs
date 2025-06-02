using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private int maxHP = 50;
    [SerializeField] private float currentHP;
    [SerializeField] private Image hpBar;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHP = maxHP;
        UpdateHpBar();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0f || vertical != 0f)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }

        rb.velocity = new Vector2(horizontal, vertical) * moveSpeed;
    }

    public void TakenDamage(float dmg)
    {
        currentHP -= dmg;
        currentHP = Mathf.Max(currentHP, 0);
        UpdateHpBar();
        if (currentHP <= 0)
        {
            Die();
        }
    }

    public void Heal(float healedHP)
    {
        if (currentHP <= maxHP)
        {
            currentHP += healedHP;
            currentHP = Mathf.Min(currentHP, maxHP);
            UpdateHpBar();
        }
    }

    private void Die()
    {
        currentHP = 0;
        Destroy(gameObject);
    }

    private void UpdateHpBar()
    {
        if (hpBar != null)
        {
            hpBar.fillAmount = currentHP / maxHP;
        }
    }
}
