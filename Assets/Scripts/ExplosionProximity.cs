using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionProximity : MonoBehaviour
{
    public string playerTag = "Player";
    public float explosionRadius = 2f;
    public GameObject explosionPrefab;

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        if (player != null && Vector3.Distance(transform.position, player.transform.position) < explosionRadius)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}