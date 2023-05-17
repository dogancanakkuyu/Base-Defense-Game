using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPCBehavior : MonoBehaviour
{

    protected enum EnemyState
    {
        Walk,
        Attack,
        Die
    }

    private const string walkParameter = "isWalking";
    private const string attackParameter = "isAttacking";
    private const string dieParameter = "isDying";


    protected Animator enemyAnimator; //Animator component of enemies
    protected NavMeshAgent agent; //Nav mesh agent of enemies
    protected float attackRange; //Attack range of enemy
    protected EnemyState enemyState; //State of enemy
    protected GameObject unitGameObject; //Reference of rival unit game object

    protected float damageValue; //Damage value of enemy
    protected float health; //Health value of enemy
    protected Transform destinationPos; //Destination position of agents possibly a castle
    [SerializeField] protected GameObject coinPopUp;


    protected void EnemyBehavior()
    {
        if(unitGameObject == null)
        {
            enemyState = EnemyState.Walk;
            if (agent.isStopped) // Means skeleton detected a unit but that unit is dead
            {
                agent.isStopped = false;
                enemyAnimator.SetBool(attackParameter, false);
            }
        }

        if(enemyState == EnemyState.Walk)
        {
            WalkToDestination(destinationPos.position);
        }
        else if(enemyState == EnemyState.Attack)
        {
            Attack();
        }
        else if(enemyState == EnemyState.Die)
        {
            enemyAnimator.SetTrigger(dieParameter);
            if(GameEvents.onEnemyDestroyed != null)
            {
                GameEvents.onEnemyDestroyed.Invoke(gameObject);
            }
        }
    }

    protected void WalkToDestination(Vector3 attackPoint) //Agent walks to destined point
    {
        agent.SetDestination(attackPoint);
        enemyAnimator.SetBool(walkParameter, true);
    }

    protected void Attack()
    {
        enemyAnimator.SetBool(attackParameter, true);
    }

    protected void TakeDamageFromUnit(float unitDamageVal)
    {
        health -= unitDamageVal;
        if(health <= 0)
        {
            enemyState = EnemyState.Die;
        }
    }

    protected void Die()
    {
        Instantiate(coinPopUp, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

    protected GameObject DetectAttackableObject(string attackableObjectTag) //After entering sight range, detecting for nearest attackable game object 
    {
        GameObject[] attackableObjects = GameObject.FindGameObjectsWithTag(attackableObjectTag);
        GameObject attackableObject = null;
        float closestDistance = Mathf.Infinity;
        foreach(GameObject ao in attackableObjects)
        {
            float distance = Vector3.Distance(this.transform.position, ao.transform.position);
            if(distance < closestDistance)
            {
                closestDistance = distance;
                attackableObject = ao;
            }
        }

        if(attackableObject != null)
        {
            return attackableObject;
        }

        return null;
    }


}
