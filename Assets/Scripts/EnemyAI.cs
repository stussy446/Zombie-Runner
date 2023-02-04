using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    [Header("Chase Configurations")]
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;
    
    [SerializeField] float turnSpeed = 5f;

    
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    Animator animator;

    // animation hash codes
    int idleHash = Animator.StringToHash("Idle");
    int moveHash = Animator.StringToHash("Move");
    int attackHash = Animator.StringToHash("Attack");

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        CalculateDistanceToTarget();

        if (TargetInRange())
        {
            EngageTarget();
        }
        else
        {
            Wait();
        }
    }

    private void CalculateDistanceToTarget()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
    }

    private void EngageTarget()
    {
        FaceTarget();

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
        animator.SetBool(attackHash, true);
    }

    private void ChaseTarget()
    {
        animator.SetTrigger(moveHash);
        animator.SetBool(attackHash, false);
        navMeshAgent.SetDestination(target.position);
    }

    private void Wait()
    {
        animator.SetTrigger(idleHash);
    }

    private bool TargetInRange()
    {
        return distanceToTarget <= chaseRange;
    }

    private bool TargetInAttackRange()
    {
        return distanceToTarget <= navMeshAgent.stoppingDistance;
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
