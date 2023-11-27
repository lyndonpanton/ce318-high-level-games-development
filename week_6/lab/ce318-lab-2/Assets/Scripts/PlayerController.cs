using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    // [SerializeField] private GameObject gameController;
    private GameController _gameController;
    
    [SerializeField] private Rigidbody rb;
    public float speed;
    private float _horizontal;
    private float _vertical;
    
    private bool _shooting;
    private const float FireRate = 0.5f;
    private float _fireTimer;

    public new Camera camera;
    public float minimumX;
    public float maximumX;
    public float minimumY;
    public float maximumY;

    public GameObject boltPrefab;
    public GameObject playerExplosion;
    
    [SerializeField] private AudioSource[] audioSources;

    private AudioSource _explosionAudioSource;
    private AudioSource _weaponAudioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        _gameController = GameObject.Find("GameController")
            .GetComponent<GameController>();

        _explosionAudioSource = audioSources[0];
        _weaponAudioSource = audioSources[1];
        
        speed = 5;
        camera = Camera.main;
        GetCameraBounds();
    }

    void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        _shooting = Input.GetMouseButtonDown(0);

        if (_fireTimer <= 0)
        {
            
            if (_shooting) ShootBolt();
        }
        else
        {
            _fireTimer -= Time.deltaTime;
        }


        if (_horizontal < 0)
        {
            rb.transform.Translate(
                Time.deltaTime * speed * new Vector3(-1, 0, 0),
                Space.World
            );

            transform.rotation = Quaternion.Euler(0, -15, 0);
        }
        else if (_horizontal > 0)
        {
            rb.transform.Translate(
                Time.deltaTime * speed * new Vector3(1, 0, 0),
                Space.World
            );

            transform.rotation = Quaternion.Euler(0, 15, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
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
        
        // Vector3 viewportPoint = camera.ScreenToViewportPoint(
        //         transform.position
        // );
        //
        // if (viewportPoint.x < 0)
        // {
        //     transform.position = new Vector3(
        //         camera.transform.position.x,
        //         transform.position.y,
        //         transform.position.z
        //     );
        // }
        // else if (viewportPoint.x > 1)
        // {
        //     transform.position = new Vector3(
        //         -camera.transform.position.x,
        //         transform.position.y,
        //         transform.position.z
        //     );
        // }
        //
        // if (viewportPoint.y < 0)
        // {
        //     transform.position = new Vector3(
        //         transform.position.x,
        //         transform.position.y,
        //         camera.transform.position.z
        //     );
        //     
        // }
        // else if (viewportPoint.y > 1)
        // {
        //     transform.position = new Vector3(
        //         transform.position.x,
        //         transform.position.y,
        //         -camera.transform.position.z
        //     );
        // }

        ClampPosition();
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("player <> asteroid collision");
        if (other.gameObject.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        _explosionAudioSource.Play();
        
        GameObject explosion = Instantiate(
            playerExplosion,
            transform.position,
            Quaternion.identity
        );

        Destroy(explosion, 2);
        _gameController.DisplayGameOverScreen();
    }

    void ClampPosition()
    {
        float additionalX = _horizontal * Time.deltaTime * speed;
        // float additionalY = _vertical * Time.deltaTime * speed;

        float newXPosition = Mathf.Clamp(
            transform.position.x + additionalX,
            minimumX,
            maximumX
        );

        // float newYPosition = Mathf.Clamp(
        //     transform.position.z + additionalY,
        //     minimumY,
        //     maximumY
        // );

        if (newXPosition < minimumX)
        {
            transform.position = new Vector3(
                maximumX,
                transform.position.y,
                transform.position.z
            );
        }
        else if (newXPosition > maximumX)
        {
            transform.position = new Vector3(
                minimumX,
                transform.position.y,
                transform.position.z
            );
        }

        // if (newYPosition < minimumY)
        // {
        //     transform.position = new Vector3(
        //         newXPosition,
        //         transform.position.y,
        //         maximumY
        //     );
        // }
        // else if (newYPosition > maximumY)
        // {
        //     transform.position = new Vector3(
        //         newXPosition,
        //         transform.position.y,
        //         minimumY
        //     );
        // }
    }

    void GetCameraBounds()
    {
        minimumX = camera.ViewportToWorldPoint(
            new Vector3(0, 0, 0)
        ).x;

        maximumX = minimumX * -1;
        
        minimumY = camera.ViewportToWorldPoint(
            new Vector3(0, 0, 0)
        ).y;

        maximumY = minimumY * -1;

        // Debug.Log("Minimum x coordinate: " + minimumX);
        // Debug.Log("Maximum x coordinate: " + maximumX);
        // Debug.Log("Minimum y coordinate: " + minimumY);
        // Debug.Log("Maximum y coordinate: " + maximumY);
    }

    void ShootBolt()
    {
        _weaponAudioSource.Play();
        Quaternion boltRotation = Quaternion.Euler(
            new Vector3(90, 0, 0)
        );
        GameObject bolt = Instantiate(
            boltPrefab,
            new Vector3(
                transform.position.x,
                2,
                transform.position.z
            ),
            boltRotation
        );

        // bolt.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 90));
            
        _fireTimer = FireRate;
    }
}
