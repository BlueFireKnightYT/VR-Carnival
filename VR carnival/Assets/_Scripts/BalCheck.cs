using System.Collections.Generic;
using UnityEngine;

public class BalCheck : MonoBehaviour
{
    GameObject bal;
    BalRespawnRequirement brr;

    [SerializeField] List<GameObject> Balls = new List<GameObject>();
    [SerializeField] List<GameObject> blikken = new List<GameObject>();
    [SerializeField] Transform[] blikRespawnPoints;
    [SerializeField] GameObject ballPrefab;
    [SerializeField] GameObject respawn1;
    [SerializeField] GameObject respawn2;
    [SerializeField] GameObject respawn3;

    int currentBlik = 0;


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ball") || other.CompareTag("BowlingBall"))
        {
            bal = other.gameObject;
            brr = bal.GetComponent<BalRespawnRequirement>();

            if (!brr.wasChecked)
            {
                brr.wasChecked = true;
                Balls.Add(bal);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball") || other.CompareTag("BowlingBall"))
        {
            bal = other.gameObject;
            brr = bal.GetComponent<BalRespawnRequirement>();

            if (brr.wasChecked)
            {
                brr.wasChecked = false;
            }
        }
    }

    private void FixedUpdate()
    {
        Balls.RemoveAll(ball => ball == null);

        if (Balls.Count <= 0)
        {
            if (respawn1 != null) Instantiate(ballPrefab, respawn1.transform.position, respawn1.transform.rotation);
            if (respawn2 != null) Instantiate(ballPrefab, respawn2.transform.position, respawn2.transform.rotation);
            if (respawn3 != null) Instantiate(ballPrefab, respawn3.transform.position, respawn3.transform.rotation);
            foreach (GameObject blik in blikken)
            {
                Rigidbody rb = blik.GetComponent<Rigidbody>();
                blik.transform.position = blikRespawnPoints[currentBlik].position;
                blik.transform.rotation = blikRespawnPoints[currentBlik].rotation;
                rb.linearVelocity = Vector3.zero;
                currentBlik++;
            }

            currentBlik = 0;
        }
    }

}
