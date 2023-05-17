using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem
{
    private int fullHealth; //maximum health val of a unit
    private int currentHealth;

    public HealthSystem(int fullHealth,int currentHealth)
    {
        this.fullHealth = fullHealth;
        this.currentHealth = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public void Heal()
    {
        currentHealth = fullHealth;
    }
}
