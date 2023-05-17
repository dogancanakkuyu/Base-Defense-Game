using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour
{
    private float towerHealth = 100f;


    private void Awake()
    {
        towerHealth = 100f;
    }


    public float GetTowerHealth()
    {
        return towerHealth;
    }
}
