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

    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;
    PlayerAwareness _playerAwarenessController;
    Vector2 targetDirection;

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
            // Wandering behavior when not aware of the player
            if (rb.velocity.magnitude < 0.01f)
            {
                // Change moveDirection to a random direction
                moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            }

            rb.velocity = moveDirection * moveSpeed;
        }
    }

    private void FixedUpdate()
    {
        if (_playerAwarenessController.AwareOfPlayer) 
        {
            if (target)
            {
                rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
            }
           
        }        
    }


    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount; //敌人生命进入倒数，直至0 = 敌人死亡

        if(health <= 0)
        {
            Destroy(gameObject);
            OnEnemyKilled?.Invoke(this);
        }
    }

}
