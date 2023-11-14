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
        speed = 500f;
        
        rb.AddForce(
            Time.deltaTime * speed * Vector3.forward,
            ForceMode.Impulse
        );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
