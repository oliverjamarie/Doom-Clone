using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController control;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float groundCheckRadius = 0.4f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public LayerMask groundMask;

    public Collider collide;

    
    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask);

        bool onIncline = isOnIncline();

        

        if (isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical"); 

        Vector3 move = transform.right * x + transform.forward * z;

        control.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        control.Move(velocity * Time.deltaTime);
    }


    bool isOnIncline(){
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.forward);

        

        if (collide.Raycast(ray, out hit, 1000f)){
            print("COLLIDED WITH SOMETHING \t Angle: \t"/*+ Vector3.Angle(hit.normal, transform.forward)*/);
        }

        return false;
    }
}
