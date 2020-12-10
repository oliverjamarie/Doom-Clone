using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    NavMeshAgent agent;
    Transform goal;

    bool reachedTarget;
    CharacterController charControl;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
        reachedTarget = false;
        charControl = GetComponent<CharacterController>();
        
        GameObject search = player.transform.Find("Player Target Fd").gameObject;

        if (search != null){
            goal = search.transform;
        }
        else {
            print("no target");
        }
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
