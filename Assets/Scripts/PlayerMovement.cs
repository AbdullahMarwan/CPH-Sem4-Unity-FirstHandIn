using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatyMcStinky : MonoBehaviour
{
 [SerializeField] private Rigidbody rigidbody;
 [SerializeField] private float jumpForce = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            rigidbody.AddForce(Vector3.up * jumpForce);
        }
        
    }
}
