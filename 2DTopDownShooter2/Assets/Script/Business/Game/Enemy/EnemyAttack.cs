using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField] private float damageAmount;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<PlayerController>())
        {
            var healthController = other.gameObject.GetComponent<PlayerHealth>();

            healthController.TakeDamage(damageAmount);
        }
    }
}
