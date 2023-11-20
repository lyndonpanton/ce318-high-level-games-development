using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 3f;
        
        // Debug.Log(
        //     "( "
        //     + transform.position.x
        //     + ", " + transform.position.y
        //     + ", " + transform.position.z
        //     + " )"
        // );
        //
        // Debug.Log(
        //     "( "
        //     + transform.rotation.x
        //     + ", " + transform.rotation.y
        //     + ", " + transform.rotation.z
        //     + " )"
        // );
        
        rb.AddForce(
            speed * Vector3.forward,
            ForceMode.Impulse
        );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
