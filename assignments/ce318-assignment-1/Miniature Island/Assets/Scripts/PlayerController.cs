using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Search;
using UnityEngine;
// using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector3 _movementInput;
    private bool _fireInput;
    
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float movementSpeed;

    [SerializeField] private float rotationSpeed;

    [SerializeField] private GameObject bulletPrefab;

    private const float MaxInvulnerableTime = 1.5f;
    
    // Initialising to default values is redundant (0f, false)
    private float _currentInvulnerableTime;
    private bool _isInvulnerable;
    
    private int _lives;
    private int _level;
    private int _experience;

    public GameObject gameController;
    private GameController _gameControllerScript;

    private int _maxAmmo = 6;
    private int _currentAmo;
    private float _reloadRate = 1.5f;
    private float _fireRate = 0.5f;
    private bool _isReloading;
    
    
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        movementSpeed = 5;
        rotationSpeed = 360;
        
        _lives = 3;
        _level = 1;
        _experience = 0;

        _gameControllerScript = gameController
            .GetComponent<GameController>();
        _gameControllerScript.SetLives(_lives);
        _gameControllerScript.SetLevel(_level);
        _gameControllerScript.SetFloor(10);
        _gameControllerScript.SetScore(1);
    }
    
    // FixedUpdate is called at 50 fps and is good for physics
    private void FixedUpdate()
    {
        Move();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_lives <= 0)
        {
            Destroy(gameObject);
        }

        if (_isInvulnerable)
        {
            _currentInvulnerableTime += Time.deltaTime;
            
            if (_currentInvulnerableTime >= MaxInvulnerableTime)
            {
                _isInvulnerable = false;
                _currentInvulnerableTime = 0;
            }
        }
        
        GatherInput();
        Look();
    }

    private void OnCollisionStay(Collision other)
    {
        if (!_isInvulnerable && other.gameObject.CompareTag("Enemy"))
        {
            _gameControllerScript.SetLives(--_lives);
            _isInvulnerable = true;
        }
    }

    private void OnDestroy()
    {
        // Destroy(GameObject.FindObjectOfType<Camera>().gameObject);
    }

    // private IEnumerator HandleFireRate()
    // {
    //     float nextTimeC
    // }


    private void GatherInput()
    {
        _movementInput = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            0,
            Input.GetAxisRaw("Vertical")
        );
    }

    private void Look()
    {
        if (_movementInput != Vector3.zero)
        {
            // var relative =
            //     (transform.position + _movementInput.ToIsometric())
            //     - transform.position;
            //
            // var rotation = Quaternion.LookRotation(
            //     relative,
            //     Vector3.up
            // );
            //
            // transform.rotation = Quaternion.RotateTowards(
            //     transform.rotation,
            //     rotation,
            //     rotationSpeed * Time.deltaTime
            // );
            
            var relative =
                (transform.position + _movementInput.ToIsometric())
                - transform.position;
            
            var rotation = Quaternion.LookRotation(
                relative,
                Vector3.up
            );
            
            transform.rotation = rotation;
        }
    }

    private void Move()
    {
        rb.MovePosition(
            transform.position + transform.forward *
            (_movementInput.magnitude * movementSpeed * Time.deltaTime)
        );
        
        // rb.AddForce(
        //     transform.forward * (_movementInput.magnitude * movementSpeed * Time.deltaTime),
        //     ForceMode.Impulse
        // );
    }
    
    // public void OnFire(InputAction.CallbackContext context)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public void OnMove(InputAction.CallbackContext context)
    // {
    //     throw new NotImplementedException();
    // }
}
