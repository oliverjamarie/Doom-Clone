using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class EnemyMovement : MonoBehaviour
{
    public GameObject playerObject;
    public float speed = 8f;
    public float totalDelay = 1f;
    float delayRemain = 0f; 

    PlayerInfo player;
    NavMeshAgent agent;
    Transform goal;

    bool reachedTarget, isWaiting;
    CharacterController charControl;

    // Constant == continuously get best path to player
    // Breadcrumb == navigate to player's last known position
    public enum FollowType {
        BREADCRUMB,
        CONSTANT
    };
    public FollowType followType; 

    // what target does the enemy follow (forward, left, right ... of the player)
    public enum TargetType
    {
        FD,
        BK,
        LFT,
        RGHT,
        CURR
    };
    public TargetType targetType;

    // Start is called before the first frame update
    void Start()
    {
        
        isWaiting = false;
        reachedTarget = false;
        charControl = GetComponent<CharacterController>();
        
        player = playerObject.GetComponent<PlayerInfo>();

        agent = GetComponentInChildren<NavMeshAgent>();

        if (agent == null){
            print("NavMesh Agent not found");
            enabled = false;
        }else
        {
            print("NavMesh Agent found");
        }

        agent.speed = speed;
        setTarget();
        agent.destination = goal.position;
    }

    void Update(){
        if (updateTarget()){
            setTarget();
            agent.destination = goal.position;
        }
    }

    public void setPlayer(int instanceID){
        Object [] allObjects = Object.FindObjectsOfType<GameObject>();

        foreach (GameObject go in allObjects)
        {
            if (go.GetInstanceID() == instanceID){
                playerObject = go;
                break;
            }
        }

        player = playerObject.GetComponent<PlayerInfo>();
    }


    void setTarget(){

         if ( targetType == TargetType.FD){
            goal = player.getTargetFd();
        }
        else if (targetType == TargetType.BK){
            goal = player.getTargetBk();
        }
        else if (targetType == TargetType.LFT){
            goal = player.getTargetL();
        }
        else if (targetType == TargetType.RGHT){
            goal = player.getTargetR();
        }
        else
        {
            goal = player.getTargetCurr();
        } 

        goal.position += Random.insideUnitSphere;

        /* Vector3 offset = new Vector3(0f,0f,0f);

        if ( targetType == TargetType.FD){
            offset += playerObject.transform.forward;
        }
        else if (targetType == TargetType.BK){
            offset += -1* (playerObject.transform.forward);
        }
        else if (targetType == TargetType.LFT){
            offset += -1 * (playerObject.transform.right);
        }
        else if (targetType == TargetType.RGHT){
            offset += playerObject.transform.right;
        }


        offset.x = Random.value / 2;
        offset.y = Random.value / 2;
        offset.z = Random.value / 2;

        goal.position = playerObject.transform.position;

        goal.position += offset; */

    }

    
    bool updateTarget(){
        bool update = false;

        // We can use Time.deltaTime becuse the function is called on Update()

        if (isWaiting ){
            if (delayRemain > 0){
                delayRemain -= Time.deltaTime;
                return false;
            }
            else {
                isWaiting = false;
                return true;
            }
        } 

        if (reachedTarget){
            update =  true;
        } 
        else if (agent.remainingDistance < 0.02){
            update =  true;
        } 
        else if (followType == FollowType.CONSTANT){
            update =  true;
        } 
        
        if (update){
            delayRemain = totalDelay;
            isWaiting = true;

            //returns false bc we want to wait
            return false;
        } 
        else {
            return false;
        }
    }

    void OnTriggerEnter(Collider collision){
        reachedTarget = true;
    }

    void OnTriggerExit(Collider collision){
        reachedTarget = false;

        setTarget();
        agent.destination = goal.position;

    }


    public Vector3 getVelocity (){
        return agent.velocity;
    }
}
