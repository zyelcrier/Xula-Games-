using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    NavMeshAgent agent;
    Rigidbody rigidbody;
    bool onAir = false;
    Vector3 dest;
    float remDist = 0f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rigidbody = GetComponent<Rigidbody>();
    }

    public void MoveToPoint(Vector3 point)
    {
        dest = point;
        agent.SetDestination(point);
    }

    public void jump()
    {
        if(!onAir)
        {
            remDist = agent.remainingDistance;
            onAir = true;
            agent.enabled = false;

            rigidbody.isKinematic = false;

            if(remDist > 0.1f)
            {
                rigidbody.AddRelativeForce(new Vector3(0, 5, 5), ForceMode.Impulse);
            }

            else
            {
                rigidbody.AddRelativeForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            }
        }
            
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(onAir)
        {
            agent.enabled = true;
            onAir = false;
            rigidbody.isKinematic = true;

            if (remDist > 0.1f)
            {
                agent.SetDestination(dest);
            }
        }
    }

    public NavMeshAgent getAgent()
    {
        return agent;
    }

    public bool isOnAir()
    {
        return onAir;
    }
}
