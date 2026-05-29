using UnityEngine;

public class BalCheck : MonoBehaviour
{
    int ballsInTrigger;
    GameObject bal;
    BalRespawnRequirement brr;

    [SerializeField] GameObject ballPrefab;
    [SerializeField] GameObject respawn1;
    [SerializeField] GameObject respawn2;
    [SerializeField] GameObject respawn3;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            bal = other.gameObject;
            brr = bal.GetComponent<BalRespawnRequirement>();

            if (!brr.wasChecked)
            {
                ballsInTrigger++;
                brr.wasChecked = true;
            }

            Debug.Log("Balls found: ");
            Debug.Log(ballsInTrigger);
        }
    }
    private void FixedUpdate()
    {
        if (ballsInTrigger <= 0)
        {
            GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
            if (balls.Length > 0)
            {
                Destroy(balls[0]);
            }
            Instantiate(ballPrefab, respawn1.transform);
            Instantiate(ballPrefab, respawn2.transform);
            Instantiate(ballPrefab, respawn3.transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            bal = other.gameObject;
            brr = bal.GetComponent<BalRespawnRequirement>();

            if (brr.wasChecked)
            {
                ballsInTrigger--;
                brr.wasChecked = false;
            }

            Debug.Log("Balls found: ");
            Debug.Log(ballsInTrigger);
        }
    }
}
