using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public new Camera camera;
    
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI playAgainText;

    private int _currentScore = 0;
    private int _currentLives = 3;

    private float leftBoundary;
    private float rightBoundary;
    private float topBoundary;
    private float bottomBoundary;

    private const int WaveCount = 5;
    private const float SpawnWait = 5f; 
    
    private AudioSource _audioSource;

    private bool _gameOver;
    
    /* Game Loop */
    
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play(0);
        
        var lowerLeft = camera.ScreenToWorldPoint(
            new Vector3(0, 0, 0)
        );
        
        var upperRight = camera.ScreenToWorldPoint(
            new Vector3(
                Screen.width,
                Screen.height,
                0
            )
        );

        topBoundary = upperRight.y - 5f;
        rightBoundary = upperRight.x - 5f;
        bottomBoundary = lowerLeft.y + 5f;
        leftBoundary = lowerLeft.x + 5f;

        Debug.Log("Top Boundary (y): " + topBoundary);
        Debug.Log("Right Boundary (x): " + rightBoundary);
        Debug.Log("Bottom Boundary (y): " + bottomBoundary);
        Debug.Log("Left Boundary (x): " + leftBoundary);
        
        livesText.text = "Lives: " + _currentLives;
        timeText.text = "00:00";
        scoreText.text = "Score: " + _currentScore;

        StartCoroutine(SpawnWaves());
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameOver)
        {
            var restarting = Input.GetKeyDown(KeyCode.S);

            if (restarting)
            {
                SceneManager.LoadScene(
                    SceneManager.GetActiveScene().buildIndex
                );
            }
        }
    }
    
    /* Events & Triggers */
    
    
    /* Spawning */
    private void SpawnAsteroid()
    {
        float xLocation = Random.Range(leftBoundary, rightBoundary);
        float yLocation = 2f;
        float zLocation = Random.Range(bottomBoundary, bottomBoundary + 2f);
        
        Vector3 asteroidLocation = new Vector3(
                xLocation,
                yLocation,
                zLocation
        );
        
        GameObject asteroid = Instantiate(
            asteroidPrefab,
            asteroidLocation,
            Quaternion.identity
        );
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            for (var i = 0; i < WaveCount; i++)
                SpawnAsteroid();

            yield return new WaitForSeconds(SpawnWait);
        }
    }
    
    
    /* Game Logic */
    
    /* UI */
    public void DecrementLives(int decrement)
    {
        _currentLives -= decrement;
        livesText.text = "Lives: " + _currentLives;
    }
    
    public void IncrementLives(int increment)
    {
        _currentLives += increment;
        livesText.text = "Lives: " + _currentLives;
        
    }
    
    public void IncrementScore(int score)
    {
        _currentScore += score;
        scoreText.text = "Score: " + _currentScore;
    }

    public void UpdateTime(int time)
    {
        
    }

    public void DisplayGameOverScreen()
    {
        _gameOver = true;
        gameOverText.gameObject.SetActive(true);
        playAgainText.gameObject.SetActive(true);
    }
}
