using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Transform background;

    private Vector3 offset; // Offset between camera and player
    [SerializeField] private float yOffset = 1.5f;

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player transform not assigned!");
            return;
        }

        if (background == null)
        {
            Debug.LogError("Background transform not assigned!");
            return;
        }

        offset = transform.position - player.position + new Vector3(0, yOffset, 0);
    }

    void Update()
    {
        if (player != null)
        {
            // Follow the player's position
            transform.position = player.position + offset;
            
            // Update background position to follow camera
            background.position = new Vector3(transform.position.x, transform.position.y, 0f);
        }
    }
}
