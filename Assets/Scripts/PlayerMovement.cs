using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController control;

    public float speed = 12f;
    public float sprintModifyer = 1.5f;
    public float gravity = -9.81f;
    public float groundCheckRadius = 0.4f;
    public float jumpHeight = 3f;
    //public Transform groundCheck;
    //public LayerMask groundMask;

    
    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = control.isGrounded;

        bool onIncline = isOnIncline();

        if (isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical"); 

        Vector3 move = transform.right * x + transform.forward * z;
        float moveSpeed = speed;

        if (Input.GetKeyDown(KeyCode.LeftShift)){
            moveSpeed *= sprintModifyer;
        }

        control.Move(move * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        control.Move(velocity * Time.deltaTime);
    }


    bool isOnIncline(){
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);
        

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit)){
            Vector3 direction = hit.point - transform.position;

            float angle = Vector3.Angle(direction, transform.TransformDirection(Vector3.down));

            return true;
        }

        return false;
    }

    void OnTriggerEnter(Collider collision){
        print("Player: trigger");
    }

    void OnColliderEnter(Collider collision){
        print("Player Collider");
    }

    void OnTriggerStay(Collider other){
        print("Player: bruh, social distancing");
    }

    
}
