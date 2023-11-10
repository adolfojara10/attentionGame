using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerWelcome : MonoBehaviour
{

    private float timerDuration = 2.4f; // Change this to the desired number of seconds
    private float elapsedTime = 0.0f;
    private bool isTimerRunning = false;

    public GameObject panel;
    public static TimerWelcome Instance;

    private void Awake()
    {
        Instance = this;
        //GameManager.Instance.OnGameStateUpdated.AddListener(GameStateUpdated);
    }

    private void Start()
    {
        GameManager.Instance.OnGameStateUpdated.AddListener(GameStateUpdated);
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= timerDuration)
            {
                StopTimer();
            }
        }
    }


    public void StartTimer()
    {
        elapsedTime = 0.0f;
        isTimerRunning = true;
        Debug.Log("Timer started!");
    }

    public void StopTimer()
    {
        isTimerRunning = false;
        elapsedTime = 0.0f;
        Debug.Log("Timer stopped after " + timerDuration + " seconds.");
        GameManager.Instance.ChooseGame();
    }

    public void GameStateUpdated(GameManager.GameState newState)
    {
        //Debug.Log("state--------------- " + newState);
        if (newState == GameManager.GameState.Welcome)
        {
            StartTimer();
        }

    }
}

