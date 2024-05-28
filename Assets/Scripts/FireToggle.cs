using System;
using UnityEngine;

public class FireToggle : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Transform firePoint;
    public float fireRate = 0.5f;
    public bool toggle = false;

    public KeyCode shootKey = KeyCode.Space; // define a public variable to store the shoot key

    private bool isShooting = false;
    private float nextFireTime = 0f;

    private void Update()
    {
        firePoint = transform;
        if (toggle)
        {
            if (Input.GetKeyDown(shootKey))
            {
                isShooting = !isShooting;
            }

        }
        else
        {
            if (Input.GetKey(shootKey))
            {
                isShooting = true;
            }
            else
            {
                isShooting = false;
            }
        }

        if (isShooting && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    private void Shoot()
    {
      GameObject camera = GameObject.Find("Main Camera");
      Drama dramaScript = camera.GetComponent<Drama>();
      if (!dramaScript.isZooming){
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
      }
    }
}
