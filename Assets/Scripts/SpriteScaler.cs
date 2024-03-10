using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScaler : MonoBehaviour
{
    [SerializeField]
    private float xScale;
    [SerializeField]
    private float yScale;
    void Start()
    {
        // Get the sprite renderer component
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            // Set the local scale to 0.4
            transform.localScale = new Vector3(xScale, yScale, 1f);
        }
        else
        {
            Debug.LogWarning("SpriteRenderer component not found!");
        }
    }

    void Update()
    {
        transform.localScale = new Vector3(xScale, yScale, 1f);
    }
}