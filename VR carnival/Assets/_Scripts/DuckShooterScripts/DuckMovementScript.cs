using UnityEngine;

public class DuckMover : MonoBehaviour
{
    public Transform pointA;   // left/back spawn
    public Transform pointB;   // right/front spawn
    public float speed = 2f;

    private Transform target;

    void Start()
    {
        // Start moving toward point B
        target = pointB;
    }

    void Update()
    {
        // Move toward the current target
        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        // If reached the target, switch direction
        if (Vector3.Distance(transform.position, target.position) < 0.05f)
        {
            target = (target == pointA) ? pointB : pointA;
        }
    }
}
