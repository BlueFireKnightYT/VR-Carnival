using UnityEngine;

public class BumperSpawner : MonoBehaviour
{
    public GameObject bumperPrefab;
    public Transform leftSpawn;
    public Transform rightSpawn;

    private GameObject leftBumper;
    private GameObject rightBumper;

    public void ToggleBumpers()
    {
        // Als ze bestaan verwijder ze
        if (leftBumper != null || rightBumper != null)
        {
            RemoveBumpers();
            return;
        }

        // Anders spawn ze
        SpawnBumpers();
    }

    private void SpawnBumpers()
    {
        leftBumper = Instantiate(bumperPrefab, leftSpawn.position, leftSpawn.rotation);
        rightBumper = Instantiate(bumperPrefab, rightSpawn.position, rightSpawn.rotation);
    }

    private void RemoveBumpers()
    {
        if (leftBumper != null) Destroy(leftBumper);
        if (rightBumper != null) Destroy(rightBumper);

        leftBumper = null;
        rightBumper = null;
    }
}
