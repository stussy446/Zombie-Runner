using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    [Header("Chase Configurations")]
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;

    Transform target;
    NavMeshAgent navMeshAgent;
    Animator animator;
    float distanceToTarget = Mathf.Infinity;
    bool damageTaken = false;

    // animation hash codes
    int idleHash = Animator.StringToHash("Idle");
    int moveHash = Animator.StringToHash("Move");
    int attackHash = Animator.StringToHash("Attack");

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        target = FindObjectOfType<PlayerHealth>().transform;
    }

    private void Update()
    {
        CalculateDistanceToTarget();

        if (TargetInRange() || damageTaken)
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

    public void OnDamageTaken()
    {
        damageTaken = true;
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
