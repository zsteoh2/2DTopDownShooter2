using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{


    [SerializeField] private Image healthBarForegroundImage;

   public void updateHealthBar(PlayerHealth playerHealth)
    {
        healthBarForegroundImage.fillAmount = playerHealth.remainingHealthPercentage;
    }
}
