using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour
{
    [System.Serializable] public class OnTowerHealthChanged : UnityEvent<float> { }
    [System.Serializable] public class OnEnemyDestroyed : UnityEvent<GameObject> { }
    [System.Serializable] public class OnUnitHealthChanged : UnityEvent<float,float> { }
    public static OnTowerHealthChanged onTowerHealthChanged;
    public static OnEnemyDestroyed onEnemyDestroyed = new OnEnemyDestroyed();
    public static OnUnitHealthChanged onUnitHealthChanged = new OnUnitHealthChanged();
    private void Awake()
    {
        onTowerHealthChanged = new OnTowerHealthChanged();
    }
}
