using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public static event Action<Enemy> OnEnemyKilled;

    [SerializeField] float health, maxHealth = 3f;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 180f; // Adjust the rotation speed
    [SerializeField] float screenBorder;


    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;
    PlayerAwareness _playerAwarenessController;
    Vector2 targetDirection;
    float changeDirectionCooldown = 0f; // Add a cooldown timer
    public Camera sceneCamera;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<PlayerAwareness>();
        moveDirection = transform.up;
    }

    private void Start()
    {
        health = maxHealth;
        target = GameObject.Find("Player").transform;
    }



    private void Update()
    {
        if (_playerAwarenessController.AwareOfPlayer)
        {
            if (target)
            {
                Vector3 direction = (target.position - transform.position).normalized;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                rb.rotation = angle;
                moveDirection = direction;
                rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
            }
        }
        else
        {
            // Check if it's time to change direction randomly
            if (changeDirectionCooldown <= 0f)
            {
                // Change moveDirection to a random direction
                moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
                changeDirectionCooldown = Random.Range(1f, 5f); // Set a new cooldown

                // Adjust the enemy's rotation to match the random moveDirection
                float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                rb.rotation = angle;
            }
            else
            {
                changeDirectionCooldown -= Time.deltaTime;
            }

            rb.velocity = moveDirection * moveSpeed;
        }
    }

    private void FixedUpdate()
    {
        handleEnemyOffScreen();

        if (_playerAwarenessController.AwareOfPlayer)
        {
            if (target)
            {
                rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
            }
        }
    }

    private void handleEnemyOffScreen()
    {
        Vector2 screenPosition = sceneCamera.WorldToScreenPoint(transform.position);

        if ((screenPosition.x < screenBorder && moveDirection.x < 0) || (screenPosition.x > sceneCamera.pixelWidth - screenBorder && moveDirection.x > 0))
        {
            moveDirection = new Vector2(-moveDirection.x , moveDirection.y);
            // Adjust the enemy's rotation to match the random moveDirection
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }

        if ((screenPosition.y < screenBorder && moveDirection.y < 0) || (screenPosition.y > sceneCamera.pixelHeight - screenBorder && moveDirection.y > 0))
        {
            moveDirection = new Vector2(moveDirection.x, -moveDirection.y);
            // Adjust the enemy's rotation to match the random moveDirection
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }
    }


    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Destroy(gameObject);
            OnEnemyKilled?.Invoke(this);
        }
    }
}


