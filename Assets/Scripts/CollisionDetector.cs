using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public LayerMask groundLayer;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object is not on the ground layer
        if (((1 << collision.gameObject.layer) & groundLayer) == 0)
        {
            Debug.Log("Collided with: " + collision.gameObject.name);
        }
    }
}