using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]private float currentHealth;
    [SerializeField] private float maximumHealth;
    public UnityEvent OnDied;
    public UnityEvent OnDamaged;

    public float remainingHealthPercentage
    {
        get
        {
            return currentHealth / maximumHealth;
        }
    }

 public bool isInvincible { get; set; }


    public void TakeDamage(float damageAmount)
    {

        if (currentHealth == 0)
        {
            return;
        }

        if(isInvincible)
        {
            return;
        }

        currentHealth -= damageAmount;

        if(currentHealth < 0)
        {
            currentHealth = 0;
        }

        if(currentHealth == 0)
        {
            OnDied.Invoke();
        }
        else
        {
            OnDamaged.Invoke();
        }
    }

    public void addHealth(float amountToAdd)
    {
        if(currentHealth == maximumHealth)
        {
            return;
        }

        currentHealth += amountToAdd;

        if(currentHealth > maximumHealth)
        {
            currentHealth = maximumHealth;
        }
    }
}
