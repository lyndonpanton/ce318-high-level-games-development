using System;
using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;

    private GameController gameController;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController")
            .GetComponent<GameController>();
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
            gameController.IncrementScore();
        }
    }
}