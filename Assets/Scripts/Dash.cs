using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{

    [SerializeField]
    public float dashDistance = 5f;
    public float dashDuration = 0.2f;
    public GameObject dashEffectPrefab;
    public string dashTag = "DashingPlayer";

    private PlayerMovementv2 playerMovement;
    private Rigidbody2D rb;
    private string originalTag;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovementv2>();
        rb = GetComponent<Rigidbody2D>();
        originalTag = gameObject.tag;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(PerformDash());
        }
    }

     IEnumerator PerformDash()
    {
        // Disable player movement
        playerMovement.enabled = false;

        // Change tag to indicate dashing
        gameObject.tag = dashTag;

        // Instantiate dash effect
        GameObject dashEffect = Instantiate(dashEffectPrefab, transform.position, transform.rotation);
        Destroy(dashEffect, dashDuration);

        // Calculate dash direction based on player rotation
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector2 dashDirection = new Vector2(horizontalInput, 0f).normalized;

        // Apply dash velocity
        rb.velocity = dashDirection.normalized * (dashDistance / dashDuration);

        yield return new WaitForSeconds(dashDuration);

        // Reset tag and enable player movement
        gameObject.tag = originalTag;
        playerMovement.enabled = true;
    }
}
