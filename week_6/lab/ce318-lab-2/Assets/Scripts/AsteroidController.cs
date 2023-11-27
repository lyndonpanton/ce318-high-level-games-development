using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Random = UnityEngine.Random;

public class AsteroidController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    // [SerializeField] private GameObject gameController;
    private GameController _gameController;

    private const float MinMovementSpeed = 20;
    private const float MaxMovementSpeed = 30;
    [SerializeField] private float movementSpeed;

    private const float MinRotationSpeed = 5;
    private const float MaxRotationSpeed = 35;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float xRotation;
    [SerializeField] private float yRotation;
    [SerializeField] private float zRotation;

    [SerializeField] private Rigidbody rb;

    [SerializeField] private GameObject asteroidExplosion;
    
    // Start is called before the first frame update
    void Start()
    {
        _gameController = GameObject.Find("GameController")
            .GetComponent<GameController>();
        // _audioSource.Play(0);
        movementSpeed = Random.Range(MinMovementSpeed, MaxMovementSpeed);
        
        rotationSpeed = 3;
        xRotation = Random.Range(MinRotationSpeed, MaxRotationSpeed);
        yRotation = Random.Range(MinRotationSpeed, MaxRotationSpeed);
        zRotation = Random.Range(MinRotationSpeed, MaxRotationSpeed);

        if (Random.Range(0, 2) == 0)
        {
            xRotation *= -1;
        }
        
        if (Random.Range(0, 2) == 0)
        {
            yRotation *= -1;
        }
        
        if (Random.Range(0, 2) == 0)
        {
            zRotation *= -1;
        }
        
        rb.AddForce(
            (target.transform.position - transform.position)
            * movementSpeed * Time.deltaTime,
            ForceMode.Impulse
        );
    }

    // Update is called once per frame
    void Update()
    {
        rb.transform.Rotate(
            Time.deltaTime * rotationSpeed * new Vector3(
                xRotation, 
                yRotation, 
                zRotation
            )
        );
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bolt"))
        {
            _gameController.IncrementScore(100);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("beep");
        }
    }

    private void OnDestroy()
    {
        GameObject explosion = Instantiate(
            asteroidExplosion,
            transform.position,
            Quaternion.identity
        );

        Destroy(explosion, 2);
    }
}
