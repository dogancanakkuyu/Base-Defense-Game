using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHealthController : MonoBehaviour
{
    private Slider slider;
    [SerializeField] Tower towerObject;
    private float towerCurrentHealth, towerMaxHealth;


    private void Awake()
    {
        slider = GetComponent<Slider>();
        towerMaxHealth = towerObject.GetTowerHealth();
        towerCurrentHealth = towerObject.GetTowerHealth();
        slider.maxValue = towerMaxHealth;
        slider.value = towerMaxHealth;
    }

    private void HandleTowerHealth(float damage)
    {

        
        towerCurrentHealth -= damage;
        
        slider.value = (towerCurrentHealth / towerMaxHealth) * 100f;
    }

    private void OnEnable()
    {
        GameEvents.onTowerHealthChanged.AddListener(HandleTowerHealth);
    }

    private void OnDisable()
    {
        GameEvents.onTowerHealthChanged.RemoveListener(HandleTowerHealth);
    }
}
