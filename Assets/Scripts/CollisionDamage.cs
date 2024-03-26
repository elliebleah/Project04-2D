using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    public string[] targetTags;

    bool hasCollided = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasCollided)
        {
            
            foreach (string tag in targetTags)
            {
                if (other.CompareTag(tag) && this.gameObject.tag != "DashingPlayer")
                {
                    Debug.Log(this.gameObject.tag + " was hit by " + other.gameObject.tag);
                    Health health = GetComponent<Health>();
                    if (health != null)
                    {
                        health.TakeDamage(1);
                        hasCollided = true;
                    }
                    break;
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        hasCollided = false;
        Debug.Log("No longer colliding");
    }
}
