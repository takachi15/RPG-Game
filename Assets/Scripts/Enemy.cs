using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 0.4f;
    private Transform player;

    private void Start()
    {
        // Find the player GameObject using the "Player" tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        if (player != null)
        {
            // Calculate the direction towards the player
            Vector2 directionToPlayer = (player.position - transform.position).normalized;

            // Move the enemy in the direction of the player
            transform.position += (Vector3)directionToPlayer * moveSpeed * Time.deltaTime;
        }
    }
}

