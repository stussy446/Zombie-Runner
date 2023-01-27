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
        if (TargetInRange())
        {
            navMeshAgent.SetDestination(target.position);
        }
        
    }
    
    private bool TargetInRange()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        return distanceToTarget <= chaseRange;
    }
}
