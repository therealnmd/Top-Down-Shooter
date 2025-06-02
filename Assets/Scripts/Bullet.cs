using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 35f;
    [SerializeField] private float timeBulletRemain = 1.5f; //thời gian tồn tại của viên đạn sau khi bắn ra
    [SerializeField] private int dmg = 5;
    void Start()
    {
        Destroy(gameObject, timeBulletRemain);
    }

    void Update()
    {
        ShootBullet();
    }

    private void ShootBullet()
    {
        //Hàm Translate dùng để bắn
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakenDamage(dmg);
            }
            Destroy(gameObject);
        }
    }
}
