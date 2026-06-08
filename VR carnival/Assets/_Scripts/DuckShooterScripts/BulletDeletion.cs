using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float time = 20f;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
    void Start() => Destroy(gameObject, time);
}
