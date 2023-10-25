using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public Rigidbody playerRigidbody;
    public GameObject[] pickups;

    private int _count;
    private const int NumberOfPickups = 8;


    // public TextMeshProUGUI scoreText;
    // public TextMeshProUGUI winText;
    public Text scoreText;
    public Text winText;
    public Text playerPosition;
    public Text playerVelocity;
    public Text closestPickupDistance;
    
    public Vector3 previousPosition;
    
    // Start is called before the first frame update
    public void Start()
    {
        _count = 0;
        winText.text = "";
        previousPosition = player.transform.position;
        playerRigidbody = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void Update()
    {
        playerPosition.text = player.transform.position.ToString("0.00");

        // playerVelocity.text = (Mathf.Sqrt(playerRigidbody.velocity.x * 2 +
        //                                  playerRigidbody.velocity.z * 2) *
        //                        Time.deltaTime)
        //                                 .ToString("0.00");

        // playerVelocity.text =
        //     Mathf.Sqrt(player.transform.position - previousPosition) / Time.deltaTime;
        playerVelocity.text =
            ((player.transform.position - previousPosition) / Time.deltaTime)
            .ToString("0.00");
        previousPosition = player.transform.position;
        CalculateClosestPick();
    }

    public void IncrementScore()
    {
        _count++;
        SetCountText();
    }

    private void SetCountText()
    {
        scoreText.text = "Score: " + _count;

        if (_count >= NumberOfPickups)
        {
            winText.text = "You win!";
        }
    }

    private void CalculateClosestPick()
    {
        List<GameObject> activePickups = new List<GameObject>();
        var i = 0;
        
        foreach (var pickup in pickups)
        {
            if (pickup.activeSelf)
            {
                activePickups.Add(pickup);
                i++;
            }
        }

        GameObject closestPickup = null;
        float currentLocationDifference = 0;

        foreach (var pickup in activePickups)
        {
            if (closestPickup == null)
            {
                closestPickup = pickup;
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
                }
            }
            
            HighlightClosestPickup(closestPickup, pickups);
            SetClosestPickupText(currentLocationDifference);
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
            // if (pickup.Equals(closestPick))
            // {
            //     pickup.GetComponent<Renderer>().material.color = Color.blue;
            // }
            // else
            // {
            //     pickup.GetComponent<Renderer>().material.color = Color.white;
            // }
        }
    }

    private void SetClosestPickupText(float distance)
    {
        closestPickupDistance.text = distance.ToString("0.00");
    }
}
