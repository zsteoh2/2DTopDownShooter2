using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleController : MonoBehaviour
{
    private PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    public void StartInvincibility(float invincibilityDuration)
    {
        StartCoroutine(InvincibilityCoroutine(invincibilityDuration));
    }

    private IEnumerator InvincibilityCoroutine(float invincibilityDuration)
    {
        playerHealth.isInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        playerHealth.isInvincible = false;
    }

}
