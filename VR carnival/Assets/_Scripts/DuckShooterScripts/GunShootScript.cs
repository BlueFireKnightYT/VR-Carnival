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
    public InputActionProperty shootActionRight; // trigger voor XR (VR) controller (RECHTS)
    public InputActionProperty shootActionLeft; // Trigger voor XR (VR) Controller (LINKS)

    void Update()
    {
        if (shootActionRight.action.WasPressedThisFrame())
        {
            Shoot();
        }
        if (shootActionLeft.action.WasPressedThisFrame())
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
    }
}
