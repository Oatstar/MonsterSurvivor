using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float moveSpeed = 10f;           // Speed of the character
    float changeDirectionInterval = 0.5f; // Time interval for changing direction
    public string enemyTag = "Monster";      // Tag used to identify enemies
    float detectionRadius = 30f;         // Radius to check for nearest enemies
    
    private Rigidbody2D rb;
    private Vector2 movement;
    private float timeToChangeDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ChangeDirection();
    }

    void Update()
    {
        timeToChangeDirection -= Time.deltaTime;

        if (timeToChangeDirection <= 0f)
        {
            ChangeDirection();
        }

        rb.velocity = movement * moveSpeed;
    }

    void ChangeDirection()
    {
        GameObject nearestEnemy = FindNearestEnemy();
        if (nearestEnemy != null)
        {
            Vector2 directionAwayFromEnemy = (Vector2)(transform.position - nearestEnemy.transform.position).normalized;
            movement = directionAwayFromEnemy;
        }
        else
        {
            // If no enemy found, move in a random direction
            float randomAngle = Random.Range(0f, 360f);
            movement = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle)).normalized;
        }

        // Set time to change direction again
        timeToChangeDirection = changeDirectionInterval;
    }

    GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject nearestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance && distanceToEnemy <= detectionRadius)
            {
                closestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }
}
