using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltController : MonoBehaviour
{
    // [SerializeField] private GameObject gameController;
    private GameController _gameController;
    
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        _gameController = GameObject.Find("GameController")
            .GetComponent<GameController>();
        speed = 3f;
        
        rb.AddForce(
            speed * Vector3.forward,
            ForceMode.Impulse
        );
    }

    private void OnCollisionEnter(Collision other)
    {
        // if (other.gameObject.CompareTag("Asteroid"))
        // {
        //     Debug.Log("Bolt <> Asteroid Collision!");
        //     
        //     Destroy(other.gameObject);
        //     Destroy(gameObject);
        // }
    }
}
