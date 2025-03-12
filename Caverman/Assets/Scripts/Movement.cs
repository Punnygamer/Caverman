using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    
    private Rigidbody rb;
    private Transform tf;
    private Vector3 moveInput;

    private float up = 1;
    public float jump = 5f;

    private bool grounded=false;
    private bool climbable = false;

    public Isgrounded groundmask;
    public isclimb climbmask;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
    }

    void Update()
    {

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        grounded = groundmask.getGrounded();
        climbable = climbmask.getClimbable();

        //On the ground
        //
        Vector3 moveDirection = (tf.right * moveX + tf.forward * moveZ).normalized;
        if (grounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            }
            if (Input.GetKey(KeyCode.Space) && climbable)
            {
                moveInput = new Vector3(moveDirection.x, up, moveDirection.z);
                rb.linearVelocity = new Vector3(moveInput.x * speed, moveInput.y * speed, moveInput.z * speed);
            }
            else 
            {
                moveInput = new Vector3(moveDirection.x, 0, moveDirection.z);
                rb.linearVelocity = new Vector3(moveInput.x * speed, rb.linearVelocity.y, moveInput.z * speed);
            }
        }
        //Off ground
        //
        else
        {
            if (Input.GetKey(KeyCode.Space) && climbable) 
            {
                moveInput = new Vector3(moveDirection.x, up, moveDirection.z);
                rb.linearVelocity= new Vector3(moveInput.x * speed/2, moveInput.y * speed/2, moveInput.z * speed/2);
            }
            else
            {
                moveInput = new Vector3(moveDirection.x, up, moveDirection.z);
                rb.linearVelocity = new Vector3(moveInput.x * speed/2, rb.linearVelocity.y, moveInput.z * speed/2);
            }
        }
        //    
    }
        
}

   


