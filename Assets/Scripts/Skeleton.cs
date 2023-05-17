using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : NPCBehavior
{


    
    private SphereCollider sphereCollider; //Checks whether rival unit in attack range


    private void Awake()
    {
        destinationPos = GameObject.FindWithTag("Tower").transform;
        enemyAnimator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        attackRange = 0.5f;
        enemyState = EnemyState.Walk;
        unitGameObject = null;
        damageValue = 10f;
        health = 50f;
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = attackRange;
        unitGameObject = null;
    }

    private void Update()
    {
        EnemyBehavior();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Unit"))
        {
            if(unitGameObject == null)
            {
                unitGameObject = other.gameObject;
            }
            agent.isStopped = true;
            enemyState = EnemyState.Attack;
        }
        if (other.CompareTag("UnitWeapon"))
        {
            float enemyDamageValue = other.gameObject.GetComponentInParent<Knight>().GetDamage();
            TakeDamageFromUnit(enemyDamageValue);
        }

        if (other.CompareTag("Tower"))
        {
            Destroy(gameObject);
            if(GameEvents.onTowerHealthChanged != null)
            {
                GameEvents.onTowerHealthChanged.Invoke(damageValue);
            }
        }
    }

    

    public float GetDamageValue()
    {
        return damageValue;
    }

    public float GetEnemyHealth()
    {
        return health;
    }
}
