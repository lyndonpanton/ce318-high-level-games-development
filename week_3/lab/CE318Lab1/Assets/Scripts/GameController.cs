using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject player;
    
    private int count;
    private int numberOfPickups = 8;

    public GameObject[] pickups;

    // public TextMeshProUGUI scoreText;
    // public TextMeshProUGUI winText;
    public Text scoreText;
    public Text winText;
    public Text playerPosition;
    public Text playerVelocity;
    
    public Vector3 previousPosition;
    
    // Start is called before the first frame update
    public void Start()
    {
        count = 0;
        winText.text = "";
        previousPosition = player.transform.position;
    }

    // Update is called once per frame
    public void Update()
    {
        playerPosition.text = player.transform.position.ToString("0.00");
        playerVelocity.text =
            ((player.transform.position - previousPosition) / Time.deltaTime)
            .ToString("0.00");
        previousPosition = player.transform.position;
    }

    public void IncrementScore()
    {
        count++;
        SetCountText();
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
