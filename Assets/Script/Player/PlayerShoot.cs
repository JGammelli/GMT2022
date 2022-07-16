using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField] private float shootCooldown;
    [SerializeField] private int bulletDamage;
    [SerializeField] private float bulletSpeed;

    [SerializeField] private Transform shootPoint; 
    [SerializeField] private GameObject bulletPrefab;


    private Camera cam;
    private Vector2 mousePos;
    private bool shootButton;
    private float lastShootTime;


    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        shootButton = Input.GetMouseButton(0);
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 dir = (mousePos - (Vector2)transform.position).normalized;

        if (shootButton)
        {
            Shoot(dir);
        }

    }


    private void Shoot(Vector2 dir)
    {
        if (Time.time > lastShootTime + shootCooldown)
        {
            lastShootTime = Time.time;
            var bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().Shoot(dir, bulletSpeed, bulletDamage);
        }
    }

}
