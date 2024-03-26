using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    private Vector2 targetDirection;

    void Start()
    {
        targetDirection = (pointA.position - transform.position).normalized;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, pointA.position) < 0.1f)
            targetDirection = (pointB.position - transform.position).normalized;
        else if (Vector2.Distance(transform.position, pointB.position) < 0.1f)
            targetDirection = (pointA.position - transform.position).normalized;

        transform.Translate(targetDirection * speed * Time.deltaTime, Space.World);

        // Rotate towards the direction of movement
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
}
