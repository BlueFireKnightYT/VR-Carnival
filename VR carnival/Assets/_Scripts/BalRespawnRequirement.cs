using UnityEngine;

public class BalRespawnRequirement : MonoBehaviour
{
    public bool wasChecked = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
    }
}
