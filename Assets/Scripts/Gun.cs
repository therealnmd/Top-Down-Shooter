using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private float rotateOffset = 180f;

    [SerializeField] private Transform firePos; //vị trí viên đạn bắn ra
    [SerializeField] private GameObject bulletPrefabs; //viên đạn

    [SerializeField] private float shotDelay = 0.1f; //khoảng trễ giữa 2 viên đạn
    private float nextShot; //viên đạn tiếp theo

    [SerializeField] private int maxAmmo = 30;
    [SerializeField] private int currentAmmo;

    private bool isReloading = false; //điều kiện súng khi đang nạp đạn
    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        RotateGun();
        Shoot();
        Reload();
    }

    private void RotateGun()
    {
        if (Input.mousePosition.x < 0 || Input.mousePosition.x > Screen.width || Input.mousePosition.y < 0 || Input.mousePosition.y > Screen.height)
        {
            return;
        }

        Vector3 displacement = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position: vị trí hiện tại của súng
        //Input.mousePosition: vị trí của chuột
        //displacement: là vector hướng từ chuột đến súng (vẽ 1 mũi tên từ chuột tới súng

        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        //Mathf.Atan2(displacement.y, displacement.x): tính góc giữa vector này và trục X dương
        //Mathf.Rad2Deg: vì Atan2 trả về kết quả là radian nên đổi về độ degree
        transform.rotation = Quaternion.Euler(0, 0, angle + rotateOffset);
        //xoay súng quanh trục Z với angle và cộng thêm rotateOffset để điều chỉnh góc xoay thuận lợi
        if (angle < -90 || angle > 90)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && currentAmmo > 0 && Time.time > nextShot && !isReloading)
        {
            nextShot = Time.time + shotDelay;
            Instantiate(bulletPrefabs, firePos.position, firePos.rotation);
            currentAmmo -= 1;
        }
    }

    private IEnumerator ReloadWithDelay()
    {
        isReloading = true;

        yield return new WaitForSeconds(0.5f); // Delay 0.5 giây

        currentAmmo = maxAmmo;
        isReloading = false;
    }


    private void Reload()
    {
        if (Input.GetKey(KeyCode.R) && currentAmmo < maxAmmo && !isReloading)
        {
           StartCoroutine(ReloadWithDelay());
        }
    }
}
