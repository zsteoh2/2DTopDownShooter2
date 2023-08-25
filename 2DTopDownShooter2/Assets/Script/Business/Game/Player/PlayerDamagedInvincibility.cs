using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagedInvincibility : MonoBehaviour
{
    [SerializeField] private float invincibilityDuration;
    private InvincibleController invincibleController;

    private void Awake()
    {
        invincibleController = GetComponent<InvincibleController>();
    }
    public void startInvincibility()
    {
        invincibleController.StartInvincibility(invincibilityDuration);
    }
}
