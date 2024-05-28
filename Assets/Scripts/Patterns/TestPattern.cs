using UnityEngine;

public class TestPattern : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Transform firePoint;
    public float fireRate = 0.5f;
    public float divisions = 4f;
    private int intDivisions;

    private bool isShooting = true;
    private float nextFireTime = 0f;
    private void Update()
    {
        firePoint = transform;

        if (isShooting && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    private void Shoot()
    {
        intDivisions = Mathf.FloorToInt(divisions);
        float angleDifference = 360 / divisions;
        for (int i = 0; i < divisions; i++)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            firePoint.eulerAngles += new Vector3(0f, 0f, angleDifference);
        }
    }
}
