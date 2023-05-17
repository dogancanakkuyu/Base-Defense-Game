using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{

    //CONSTANTS
    private const string attackParameter = "isAttacking";
    private const string dieParameter = "isDying";


    protected enum State
    {
        Idle,
        Attack,
        Dead
    }

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask roadLayer;
    [SerializeField] protected Collider weaponCollider; // holds reference of weapon collider of unit
    [SerializeField] protected Image healthBarFillImage;

    protected List<GameObject> enemyObjectsList; //holds all enemies which enter unit's collider

    protected Animator unitAnimator; // Animator reference of the unit

    protected float health; // health value of a unit

    protected float maxHealth;
    protected float attackRange; //specifies attack range value
    protected float damageValue; // damaga value of a unit


    protected Vector3 targetPosition; // Enemy target's head position
    protected Vector3 destinationPosition; // Selected unit's destination position set by mouse click

    protected State unitState;
    protected GameObject enemy; // Enemy game object for unit to look at it

    protected void UnitBehaviour() //specifies unit's behaviour when it is alive
    {
        if(unitState == State.Idle)
        {
            unitAnimator.SetBool(attackParameter, false);
        }
        else if(unitState == State.Attack)
        {
            AttackEnemy();
        }
        else //Dead
        {
            weaponCollider.enabled = false;
            unitAnimator.SetTrigger(dieParameter);
        }
    }

    protected void LookAtEnemy()
    {
        enemy = GameObject.FindWithTag("Enemy");
        if (enemy != null)
        {
            Vector3 enemyPos = enemy.transform.position;
            Vector3 direction = enemyPos - transform.position;
            direction = Vector3.Normalize(direction);
            direction.y = 0;
            transform.LookAt(transform.position + direction);
        }
    }

    protected void AttackEnemy()
    {
        unitAnimator.SetBool(attackParameter, true);
        
    }
    protected void Die()
    {
        Destroy(gameObject);
    }

    protected void TakeDamage(float enemyDamageValue)
    {

        health -= enemyDamageValue;
        if(GameEvents.onUnitHealthChanged != null)
        {
            GameEvents.onUnitHealthChanged.Invoke(health, maxHealth);
        }
        if(health <= 0)
        {
            unitState = State.Dead;
        }
    }


    protected void MouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if(Physics.Raycast(ray,out RaycastHit hit, float.MaxValue, roadLayer))
        {
            transform.position = hit.point;
        }
    }

    protected void CheckEnemyCount()
    {
        if(enemyObjectsList.Count == 0)
        {
            unitState = State.Idle;
        }
    }

    protected void RemoveEnemyFromList(GameObject enemyGameObject)
    {
        if (enemyObjectsList.Contains(enemyGameObject))
        {
            int index = enemyObjectsList.IndexOf(enemyGameObject);
            enemyObjectsList.RemoveAt(index);
        }
    }

    public void HealUnit()
    {
        healthBarFillImage.fillAmount = 1;
        health = maxHealth;
    }

    protected void RotateHealthBar()
    {

    }
}
