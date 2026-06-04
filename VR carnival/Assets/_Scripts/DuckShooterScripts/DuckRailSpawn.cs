using UnityEngine;

public class DuckSpawner : MonoBehaviour
{
    // een rotation zodat de duck altijd naar je toe kijkt
    public Vector3 duckRotation = new Vector3(-90, 0, -90);

    public Transform leftSpawn;
    public Transform rightSpawn;
    public GameObject duckPrefab;

    void Start()
    {
        SpawnDuck();
    }

    void SpawnDuck()
    {
        GameObject duck = Instantiate(duckPrefab, leftSpawn.position, Quaternion.Euler(duckRotation));

        DuckMover mover = duck.GetComponent<DuckMover>();
        mover.pointA = leftSpawn;
        mover.pointB = rightSpawn;
    }
}
