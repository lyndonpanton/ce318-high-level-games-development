using System;
using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    private int count;
    private int numberOfPickups = 8;
    // public TextMeshProUGUI scoreText;
    // public TextMeshProUGUI winText;
    public Text scoreText;
    public Text winText;

    private void Start()
    {
        count = 0;
        winText.text = "";
        
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
            SetCountText();
        }
    }

    private void SetCountText()
    {
        scoreText.text = "Score: " + count.ToString();

        if (count >= numberOfPickups)
        {
            winText.text = "You win!";
        }
    }
}