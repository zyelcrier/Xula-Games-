using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRange = 10f;
    public float stopDistance = 2f;
    public List<Transform> wanderingPoints = new List<Transform>();
    Transform currentWanderDestination;
    float timeBetweenAttacks = 2f;
    float lastAttackTime = 0f;

    Transform target;
    NavMeshAgent thisAgent;
    bool isChasing = false;

    // Start is called before the first frame update
    void Start()
    {
        thisAgent = GetComponent<NavMeshAgent>();
        target = PlayerManager.instance.player.transform;
        currentWanderDestination = wanderingPoints[Random.Range(0, wanderingPoints.Count)];
        wanderingPoints.Remove(currentWanderDestination);
        thisAgent.SetDestination(currentWanderDestination.position);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRange)
        {
            thisAgent.SetDestination(target.position);
            isChasing = true;

            if(distance <= stopDistance)
            {
                thisAgent.ResetPath();
                FaceTarget();
                
                if(lastAttackTime == 0f)
                {
                    target.GetComponent<PlayerStat>().takeDamage(GetComponent<EnemyStat>().damage);
                    lastAttackTime = Time.time;
                }

                if(Time.time - lastAttackTime > timeBetweenAttacks)
                {
                    lastAttackTime = Time.time;
                    target.GetComponent<PlayerStat>().takeDamage(GetComponent<EnemyStat>().damage);
                }
            }
        }

        if(isChasing && distance > lookRange)
        {
            isChasing = false;
            thisAgent.SetDestination(transform.position);
        }

        if(!isChasing)
        {
            wander();
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRange);
    }

    void wander()
    {
        float distance = Vector3.Distance(currentWanderDestination.position, transform.position);

        if(thisAgent.destination != currentWanderDestination.position)
        {
            thisAgent.SetDestination(currentWanderDestination.position);
        }

        if (distance <= 3)
        {
            GetComponent<NavMeshAgent>().isStopped = true;
            thisAgent.ResetPath();
            currentWanderDestination = getNextWanderPosition();
            thisAgent.SetDestination(currentWanderDestination.position);
        }
    }

    Transform getNextWanderPosition()
    {
        Transform nextPosition;
        
        nextPosition = wanderingPoints[Random.Range(0, wanderingPoints.Count)];
        wanderingPoints.Remove(nextPosition);
        wanderingPoints.Add(currentWanderDestination);

        return nextPosition;
    }
}
