using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        CalculateDistanceToTarget();

        if (TargetInRange())
        {
            EngageTarget();
        }
    }

    private void CalculateDistanceToTarget()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
    }

    private void EngageTarget()
    {
        if (TargetInAttackRange())
        {
            AttackTarget();
        }
        else
        {
            ChaseTarget();
        }
    }

    private void AttackTarget()
    {
        Debug.Log("ATTACK");
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }

    private bool TargetInRange()
    {
        return distanceToTarget <= chaseRange;
    }

    private bool TargetInAttackRange()
    {
        return distanceToTarget <= navMeshAgent.stoppingDistance;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
