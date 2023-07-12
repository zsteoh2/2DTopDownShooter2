using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public static event Action<Enemy> OnEnemyKilled;

    [SerializeField] float health, maxHealth = 3f;


    private void Start()
    {
        health = maxHealth;
    }
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount; //敌人生命进入倒数，直至0 = 敌人已死亡

        if(health <= 0)
        {
            Destroy(gameObject);
            OnEnemyKilled?.Invoke(this);
        }
    }

}
