using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
            }
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
        else
        {
            rb.velocity = Vector2.zero;
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
