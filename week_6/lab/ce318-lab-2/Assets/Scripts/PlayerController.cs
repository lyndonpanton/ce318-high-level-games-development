using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    public float speed;
    private float _horizontal;
    private float _vertical;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
    }

    void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        if (_horizontal < 0)
        {
            rb.transform.Translate(
                Time.deltaTime * speed * new Vector3(-1, 0, 0)
            );
        }
        else if (_horizontal > 0)
        {
            rb.transform.Translate(
                Time.deltaTime * speed * new Vector3(1, 0, 0)
            );
        }

        if (_vertical < 0)
        {
            rb.transform.Translate(
                Time.deltaTime * speed * new Vector3(0, 0, -1)
            );

        }
        else if (_vertical > 0)
        {
            rb.transform.Translate(
                Time.deltaTime * speed * new Vector3(0, 0, 1)
            );
        }
    }
}
