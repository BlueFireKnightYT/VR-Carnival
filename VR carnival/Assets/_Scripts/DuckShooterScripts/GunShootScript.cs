using UnityEngine;
using UnityEngine.InputSystem;

public class GunShooter : MonoBehaviour
{
    [Header("References")]
    public Transform shootPoint;
    public LayerMask hitMask;

    [Header("Bullet (optional)")]
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;

    [Header("XR Input")]
    public InputActionProperty shootAction; // trigger voor XR (VR) controllers

    void Update()
    {
        if (shootAction.action.WasPressedThisFrame())
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Optional visible bullet
        if (bulletPrefab != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.linearVelocity = shootPoint.forward * bulletSpeed;
        }

        // Raycast hit detection
        if (Physics.Raycast(shootPoint.position, shootPoint.forward, out RaycastHit hit, 100f, hitMask))
        {
            DuckTarget duck = hit.collider.GetComponent<DuckTarget>();
            if (duck != null)
            {
                duck.Hit();
            }
        }
    }
}
