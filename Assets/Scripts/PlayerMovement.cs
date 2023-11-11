using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float forwardForce = 10f;
    [SerializeField] private float damping = 0.5f;
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
        if (Input.GetKeyDown(KeyCode.Space) && amountOfJumps > 0)
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            amountOfJumps --;
        }

        if (IsGrounded())
        {
            amountOfJumps = maxJumps;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        rigidbody.AddForce(moveDirection * forwardForce);

        // Apply damping to reduce velocity when no input is given
        Vector3 dampingForce = -rigidbody.velocity * damping;
        rigidbody.AddForce(dampingForce);
    }


    bool IsGrounded(){
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);
    }

}