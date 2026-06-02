using System.Collections.Generic;
using UnityEngine;

public class BalCheck : MonoBehaviour
{
    int ballsInTrigger;
    GameObject bal;
    BalRespawnRequirement brr;

    [SerializeField] List<GameObject> Balls = new List<GameObject>();
    [SerializeField] List<GameObject> blikken = new List<GameObject>();
    [SerializeField] Transform[] blikRespawnPoints;
    [SerializeField] GameObject blikPrefab;
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
                Balls.Add(bal);
            }

            Debug.Log("Balls found: ");
            Debug.Log(ballsInTrigger);
        }
    }
    private void FixedUpdate()
    {
        if ((Balls.Count - 1) <= 0)
        {
            Instantiate(ballPrefab, respawn1.transform);
            Instantiate(ballPrefab, respawn2.transform);
            Instantiate(ballPrefab, respawn3.transform);

            foreach (GameObject blik in blikken)
            {
                blikken.Remove(blik);
                Destroy(blik);
                Balls.RemoveAll(ball => ball == null);
            }
            foreach(Transform blikTransform in blikRespawnPoints)
            {
                GameObject blik = Instantiate(blikPrefab, blikTransform.position, blikTransform.rotation);
                blikken.Add(blik);
            }
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
