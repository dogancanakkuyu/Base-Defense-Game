using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Knight : Unit
{

    [SerializeField] private Transform healtBarTransform;
    private SphereCollider sphereCollider;
    private void Awake()
    {
        enemyObjectsList = new List<GameObject>();
        attackRange = 0.5f;
        unitAnimator = GetComponent<Animator>();
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = attackRange;
        unitState = State.Idle;
        health = 150f;
        maxHealth = 150f;
        damageValue = 30f;
        
    }

    private void Update()
    {

        
        base.LookAtEnemy();
        base.CheckEnemyCount();
        base.UnitBehaviour();
    }
    private void LateUpdate()
    {
        healtBarTransform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // Enemy enters the attack range of the unit
        {
            if (!enemyObjectsList.Contains(other.gameObject))
            {
                enemyObjectsList.Add(other.gameObject);
            }    


            unitState = State.Attack;
            
        }

        if (other.CompareTag("Weapon")) // Enemy hits with its weapon to the unit
        {

            if(other.gameObject != null)
            {
                float enemyDamageValue = other.gameObject.GetComponentInParent<Skeleton>().GetDamageValue();
                TakeDamage(enemyDamageValue);
            }
            
        }
    }

    private void OnEnable()
    {
        GameEvents.onEnemyDestroyed.AddListener(RemoveEnemyFromList);

    }


    private void OnDisable()
    {
        GameEvents.onEnemyDestroyed.RemoveListener(RemoveEnemyFromList);        
    }


    public float GetDamage()
    {
        return damageValue;
    }


    public float GetHealth()
    {
        return health;
    }
    


}
