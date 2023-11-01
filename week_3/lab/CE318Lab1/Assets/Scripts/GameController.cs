using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public Rigidbody playerRigidbody;
    public GameObject[] pickups;

    private int _count;
    private const int NumberOfPickups = 8;

    private LineRenderer _lineRenderer;


    // public TextMeshProUGUI scoreText;
    // public TextMeshProUGUI winText;
    public Text scoreText;
    public Text winText;
    public Text playerPosition;
    public Text playerVelocity;
    public Text closestPickupDistance;
    public Text modeText;
    
    public Vector3 previousPosition;
    public Vector3 previousVelocity;

    private GameStates _state = GameStates.Normal;
    
    // Start is called before the first frame update
    public void Start()
    {
        _count = 0;
        winText.text = "";
        previousPosition = player.transform.position;
        playerRigidbody = player.GetComponent<Rigidbody>();
        _lineRenderer = gameObject.AddComponent<LineRenderer>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetButtonDown("Switch State"))
        {
            switch (_state)
            {
                case GameStates.Normal:
                    _state = GameStates.Distance;
                    break;
                case GameStates.Distance:
                    _state = GameStates.Vision;
                    break;
                case GameStates.Vision:
                    _state = GameStates.Normal;
                    break;
                default:
                    break;
            }
        }

        if (_state == GameStates.Normal)
        {
            modeText.text =  "Mode: Normal";
            ToggleUIElements(false);
        }
        else if (_state == GameStates.Distance)
        {
            modeText.text =  "Mode: Distance";
            ToggleUIElements(true);
            playerPosition.text = player.transform.position.ToString("0.00");

            // playerVelocity.text = (Mathf.Sqrt(playerRigidbody.velocity.x * 2 +
            //                                  playerRigidbody.velocity.z * 2) *
            //                        Time.deltaTime)
            //                                 .ToString("0.00");

            // playerVelocity.text =
            //     ((player.transform.position - previousPosition) / Time.deltaTime)
            //     .ToString("0.00");
            playerVelocity.text = (Math.Sqrt(Math.Pow(playerRigidbody.velocity.x, 2)
                + Math.Pow(playerRigidbody.velocity.z, 2)) / Time.deltaTime / 100)
                .ToString("0.00");
            previousPosition = player.transform.position;
            // previousVelocity = playerRigidbody.velocity;

            CalculateClosestPickUp();
        }
        else if (_state == GameStates.Vision)
        {
            modeText.text =  "Mode: Vision";
            ChangeToVisionMode();
        }
    }

    public void IncrementScore()
    {
        _count++;
        SetCountText();
    }

    public void ChangeToVisionMode()
    {
        ToggleUIElements(false);
        _lineRenderer.enabled = true;

        List<GameObject> activePickups = new List<GameObject>();
        
        foreach (var pickup in pickups)
        {
            if (pickup.activeSelf)
            {
                activePickups.Add(pickup);
                pickup.GetComponent<Renderer>().material.color
                    = Color.white;
            }
        }

        _lineRenderer.SetPosition(0, new Vector3(
            -5f, 0.5f, -5f
        ));
        
        
        _lineRenderer.SetPosition(1, new Vector3(
            (Mathf.Sqrt(Mathf.Pow(playerRigidbody.velocity.x, 2)
                + Mathf.Pow(playerRigidbody.velocity.z, 2)) / Time.deltaTime / 100 - 5f), 0.5f, -5f
        ));

        _lineRenderer.SetWidth(0.1f, 0.1f);
    }

    private void SetCountText()
    {
        scoreText.text = "Score: " + _count;

        if (_count >= NumberOfPickups)
        {
            winText.text = "You win!";
        }
    }

    private void CalculateClosestPickUp()
    {
        List<GameObject> activePickups = new List<GameObject>();
        
        foreach (var pickup in pickups)
        {
            if (pickup.activeSelf)
            {
                activePickups.Add(pickup);
            }
        }

        GameObject closestPickup = null;
        float currentLocationDifference = 0;
        float closestPickupLocationDifference = 0;

        foreach (var pickup in activePickups)
        {
            if (closestPickup == null)
            {
                var currentXLocationDifference = Mathf.Abs(
                    player.transform.position.x -
                    pickup.transform.position.x
                );

                var currentZLocationDifference = Mathf.Abs(
                    player.transform.position.z -
                    pickup.transform.position.z
                );

                currentLocationDifference = Mathf.Sqrt(
                    Mathf.Pow(currentXLocationDifference, 2)
                    + Mathf.Pow(currentZLocationDifference, 2)
                );
                
                closestPickup = pickup;
                closestPickupLocationDifference = currentLocationDifference;
            }
            else
            {
                var previousXLocationDifference = Mathf.Abs(
                    player.transform.position.x -
                    closestPickup.transform.position.x
                );

                var previousZLocationDifference = Mathf.Abs(
                    player.transform.position.z -
                    closestPickup.transform.position.z
                );
                
                var currentXLocationDifference = Mathf.Abs(
                    player.transform.position.x -
                    pickup.transform.position.x
                );

                var currentZLocationDifference = Mathf.Abs(
                    player.transform.position.z -
                    pickup.transform.position.z
                );
                
                var previousLocationDifference = Mathf.Sqrt(
                    Mathf.Pow(previousXLocationDifference, 2)
                    + Mathf.Pow(previousZLocationDifference, 2)
                );

                currentLocationDifference = Mathf.Sqrt(
                    Mathf.Pow(currentXLocationDifference, 2)
                    + Mathf.Pow(currentZLocationDifference, 2)
                );

                if (previousLocationDifference > currentLocationDifference)
                {
                    closestPickup = pickup;
                    closestPickupLocationDifference = currentLocationDifference;
                }
            }
            
            HighlightClosestPickup(closestPickup, pickups);
            SetClosestPickupText(closestPickupLocationDifference);
        }
    }

    private void HighlightClosestPickup(GameObject closestPick, 
        GameObject[] allPickups)
    {
        foreach (var pickup in allPickups)
        {
            pickup.GetComponent<Renderer>().material.color
                = pickup.Equals(closestPick)
                    ? Color.blue
                    : Color.white;
            
            if (pickup.Equals(closestPick))
            {
                _lineRenderer.SetPosition(0, player.transform.position);
                _lineRenderer.SetPosition(1, pickup.transform.position);
                _lineRenderer.SetWidth(0.1f, 0.1f);
            }
            
            if (_state != GameStates.Distance)
            {
                // Destroy(_lineRenderer.gameObject);  
            }
        }
    }

    private void SetClosestPickupText(float distance)
    {
        closestPickupDistance.text = distance.ToString("0.00");
    }

    private void ToggleUIElements(bool visibility)
    {
        // scoreText.gameObject.SetActive(visibility);
        // winText.gameObject.SetActive(visibility);
        playerPosition.gameObject.SetActive(visibility);
        playerVelocity.gameObject.SetActive(visibility);
        closestPickupDistance.gameObject.SetActive(visibility);
        _lineRenderer.enabled = visibility;
    }
}
