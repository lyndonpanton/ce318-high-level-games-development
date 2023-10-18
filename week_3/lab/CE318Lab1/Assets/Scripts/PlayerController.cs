using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;

    private void FixedUpdate()
    {
        var horizontalAxis = Input.GetAxis("Horizontal");
        var verticalAxis = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalAxis, 0.0f, verticalAxis);
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Time.deltaTime * speed * movement);
    }
}