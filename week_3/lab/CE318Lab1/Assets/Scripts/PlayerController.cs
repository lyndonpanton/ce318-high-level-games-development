using System;
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    private int count;

    private void Start()
    {
        count = 0;
    }

    private void FixedUpdate()
    {
        var horizontalAxis = Input.GetAxis("Horizontal");
        var verticalAxis = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalAxis, 0.0f, verticalAxis);
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Time.deltaTime * speed * movement);
    }

    private void OnTriggerEnter(Collider other)
    {
        // if (other.gameObject.tag == "PickUp")
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
        }
    }
}