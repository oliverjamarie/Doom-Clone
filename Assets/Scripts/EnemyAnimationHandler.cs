using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public RuntimeAnimatorController    idleAnimation,
                                        jumpAnimation;
    Animator anim;
    AnimatorClipInfo clipInfo;


    //public Transform groundCheck;

    enum AnimationState {
        IDLE,
        JUMP,
        RUN,
        RUN_BACKWARDS,
        SPRINT,
        WALK
    };

    AnimationState state;
    bool isGrounded;
    float animTime;

    void Start(){
        anim = GetComponentInChildren<Animator>();

        anim.runtimeAnimatorController = idleAnimation;

        state = AnimationState.IDLE; 
        animTime = 0f;
    }

    void Update(){
        handleStates();

        
    }

    void handleStates() {

        if (state == AnimationState.JUMP && !isGrounded){
            return;
        }
        else if (isGrounded){
            state = AnimationState.IDLE;
            anim.runtimeAnimatorController = idleAnimation;
            return;
        }
        
        if (state == AnimationState.JUMP && animTime - Time.deltaTime <= 0){
            animTime -= Time.deltaTime;
            return;
        }
        
        EnemyMovement movement = GetComponent<EnemyMovement>();
        movement.getVelocity();

        
        if (Input.GetKeyDown(KeyCode.P) && !isGrounded){
            state = AnimationState.JUMP;
            anim.runtimeAnimatorController = jumpAnimation;
            clipInfo = anim.GetCurrentAnimatorClipInfo(0)[0];
            animTime = clipInfo.clip.length;
        }
        else
        {
            state = AnimationState.IDLE;
            anim.runtimeAnimatorController = idleAnimation;
        } 
    }

    void OnTriggerEnter(Collider coll){
        LayerMask groundMask = LayerMask.NameToLayer("Ground");

        if (coll.gameObject.layer == groundMask){
            isGrounded = true;
            print("grounded");
        }
    }

    void OnTriggerExit(Collider coll){
        LayerMask groundMask = LayerMask.NameToLayer("Ground");

        if (coll.gameObject.layer == groundMask){
            isGrounded = false;
        }
    }

}
