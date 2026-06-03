using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class BalCheck : MonoBehaviour
{
    int ballsInTrigger;
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
        if (other.gameObject.CompareTag("Ball"))
        {
            bal = other.gameObject;
            brr = bal.GetComponent<BalRespawnRequirement>();

            if (!brr.wasChecked)
            {
                ballsInTrigger++;
                brr.wasChecked = true;
                Balls.Add(bal);
            }

            Debug.Log("Balls found: ");
            Debug.Log(ballsInTrigger);
        }
    }
    private void FixedUpdate()
    {
        Balls.RemoveAll(ball => ball == null);
        if ((Balls.Count) <= 0)
        {
            Instantiate(ballPrefab, respawn1.transform);
            Instantiate(ballPrefab, respawn2.transform);
            Instantiate(ballPrefab, respawn3.transform);

            foreach (GameObject blik in blikken)
            {
                Rigidbody blikRB = blik.GetComponent<Rigidbody>();
                blikRB.linearVelocity = new Vector3(0, 0, 0);
                blik.transform.rotation = blikRespawnPoints[currentBlik].rotation;
                blik.transform.position = blikRespawnPoints[currentBlik].position;

                currentBlik += 1;
            }
            currentBlik = 0;
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
