using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image healthForegroundImage;
    public void UpdateHealthBar(HealthController healthcontroller){
        healthForegroundImage.fillAmount = healthcontroller.RemainingHealthPercentage;
    }
}
