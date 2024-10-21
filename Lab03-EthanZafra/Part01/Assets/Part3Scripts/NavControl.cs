using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavControl : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent agent;
    public Animator animator;
    public bool isWalking = true;

    public float animationSpeed;
    public float agentSpeed;
    public float animationSpeedtoAgentSpeed;
    // Start is called before the first frame update
    void Start()
    {
        


        agent = GetComponent<NavMeshAgent>();
        agentSpeed = agent.speed;
        animationSpeed = animationSpeedtoAgentSpeed * agentSpeed;

        animator.speed = animationSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
        {
            if (GetDistanceTo(target.transform.GetChild(0)) < GetDistanceTo(target.transform.GetChild(1)) && GetDistanceTo(target.transform.GetChild(0)) < GetDistanceTo(target.transform.GetChild(2))) 
            {
                agent.destination = target.transform.GetChild(0).position;
            }

            else if (GetDistanceTo(target.transform.GetChild(1)) < GetDistanceTo(target.transform.GetChild(0)) && GetDistanceTo(target.transform.GetChild(1)) < GetDistanceTo(target.transform.GetChild(2))) 
            {
                agent.destination = target.transform.GetChild(1).position;
            }

            else
            {
                agent.destination = target.transform.GetChild(2).position;
            }
            

        } else
        {
            agent.destination= transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Dragon")
        {
            isWalking = false;
            animator.SetTrigger("Attack");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Dragon")
        {
            isWalking = true;
            animator.SetTrigger("Walk");
        }
    }

    public float GetDistanceTo(Transform targetObject)
    {


        float distance = Vector3.Distance(transform.position, targetObject.position);
        return distance;
    }
}
