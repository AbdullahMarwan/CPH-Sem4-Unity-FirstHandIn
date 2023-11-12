using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float forwardForce = 10f;
    [SerializeField] private float maxJumps = 2;
    private float amountOfJumps;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    // Start is called before the first frame update
    void Start()
    {
        amountOfJumps = maxJumps;
        rigidbody = GetComponent<Rigidbody>();
        // Freeze rotation on all axes
        rigidbody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rigidbody.velocity = new Vector3(horizontalInput * forwardForce, rigidbody.velocity.y, verticalInput * forwardForce);


        if (Input.GetKeyDown(KeyCode.Space) && amountOfJumps > 0)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpForce, rigidbody.velocity.z);
            amountOfJumps --;
        }

        if (IsGrounded())
        {
            amountOfJumps = maxJumps;
        }

    }

    bool IsGrounded(){
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);
    }

}