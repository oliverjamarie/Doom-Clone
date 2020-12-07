using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform goal;
    NavMeshAgent agent;

    bool reachedTarget;
    CharacterController charControl;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
        reachedTarget = false;
        charControl = GetComponent<CharacterController>();
    }

    void Update(){
        if (!reachedTarget){
            agent.destination = goal.position;
        }
        
    }

    void OnTriggerEnter(Collider collision){
        print("Reached Target");

        reachedTarget = true;
    }

    void OnTriggerExit(Collider collision){
        reachedTarget = false;
        print("Navigating");
    }


    public Vector3 getVelocity (){
        return agent.velocity;
    }
}
