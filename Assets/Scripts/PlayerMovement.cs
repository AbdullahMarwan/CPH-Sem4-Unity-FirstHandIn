using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatyMcStinky : MonoBehaviour
{
 [SerializeField] private Rigidbody rigidbody;
 [SerializeField] private float jumpForce = 10f;
 [SerializeField] private float forwardForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            rigidbody.AddForce(Vector3.up * jumpForce);
            
        }

        if (Input.GetKeyDown(KeyCode.D)) 
        {
            rigidbody.AddForce(Vector3.right * forwardForce);
        }

        if (Input.GetKeyDown(KeyCode.A)) 
        {
            rigidbody.AddForce(Vector3.left * forwardForce);
        }

        if (Input.GetKeyDown(KeyCode.W)) 
        {
            rigidbody.AddForce(Vector3.forward * forwardForce);
        }

        if (Input.GetKeyDown(KeyCode.S)) 
        {
            rigidbody.AddForce(Vector3.back * forwardForce);
        }

    
        
    }
}
