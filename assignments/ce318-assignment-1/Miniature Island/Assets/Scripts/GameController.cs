using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private TextMeshProUGUI livesUI;
    [SerializeField] private TextMeshProUGUI levelUI;
    [SerializeField] private TextMeshProUGUI floorUI;
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private TextMeshProUGUI timeUI;
    [SerializeField] private RawImage experienceUI;
    [SerializeField] private TextMeshProUGUI textualExperienceUI;

    private float _timer;
    private TimeSpan _timeElapsed;
    private DateTime _initialTime;

    public static int enemyCount = 0;
    
    // Start is called before the first frame update
    private void Start()
    {
        SetFloor(10);
        _timer = 0;
        _initialTime = DateTime.Now;
    }
    
    // Update is called once per frame
    private void Update()
    {
        _timer += Time.deltaTime;
        _timeElapsed = DateTime.Now.Subtract(_initialTime);
        SetTime(_timer);
    }

    public static void ClearFloor()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SetExperience(int exp)
    {
        textualExperienceUI.text = (int.Parse(textualExperienceUI.text) + exp)
            .ToString();
    }

    public void SetLives(int lives)
    {
        livesUI.text = "Lives: " + lives;
    }

    public void SetLevel(int level)
    {
        levelUI.text = "Lv. " + level;
    }

    public void SetFloor(int floor)
    {
        floorUI.text = "B" + floor;
    }

    public void SetScore(int score)
    {
        scoreUI.text = "Score: " + score;
    }

    private void SetTime(float timer)
    {
        var minutes = _timeElapsed.Minutes.ToString("00");
        var seconds = _timeElapsed.Seconds.ToString("00");
        var milliseconds = _timeElapsed.Milliseconds.ToString("000")
            .Substring(0, 2);
        
        timeUI.text = minutes + ":" + seconds + "." + milliseconds;
    }
}
