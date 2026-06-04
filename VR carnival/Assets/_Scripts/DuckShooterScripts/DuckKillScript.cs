using UnityEngine;

public class DuckTarget : MonoBehaviour
{
    public float respawnTime = 2f;
    private Vector3 startPos;
    private Quaternion startRot;
    private Rigidbody rb;

    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Hit();
        }
    }
    public void Hit()
    {
        rb.isKinematic = false; // duck falls over
        Invoke(nameof(Respawn), respawnTime);


    }

    void Respawn()
    {
        rb.isKinematic = true;
        transform.position = startPos;
        transform.rotation = startRot;
    }
}
