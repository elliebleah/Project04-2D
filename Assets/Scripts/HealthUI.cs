using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    public TMP_Text healthText;
    public GameObject player; // Assign the player GameObject in the Unity Editor

    private Health playerHealth;

    void Start()
    {
        // Get the Health component from the player GameObject
        playerHealth = player.GetComponent<Health>();

        // Ensure that the healthText reference is set
        if (healthText == null)
        {
            Debug.LogError("Health Text reference not set!");
        }
    }

    void Update()
    {
        // Update the health text to display the current health of the player
        if (playerHealth != null)
        {
            healthText.text = "Health: " + playerHealth.currentHealth.ToString();
        }
    }
}
