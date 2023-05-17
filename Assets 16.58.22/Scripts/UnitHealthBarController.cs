using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitHealthBarController : MonoBehaviour
{
    private Image healthBarFillImage;

    private void Awake()
    {
        healthBarFillImage = GetComponent<Image>();
    }

    public void ControlHealthBar(float currentHealth,float maxHealth)
    {
        healthBarFillImage.fillAmount = currentHealth / maxHealth;
    }

    private void OnEnable()
    {
        GameEvents.onUnitHealthChanged.AddListener(ControlHealthBar);
    }

    private void OnDisable()
    {
        GameEvents.onUnitHealthChanged.RemoveListener(ControlHealthBar);
    }
}
