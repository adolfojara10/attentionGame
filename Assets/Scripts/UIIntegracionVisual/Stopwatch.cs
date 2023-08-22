using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{

    public float time = 0f;

    public TextMeshProUGUI timeLabel;


    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameState == GameManager.GameState.InGame)
        {
            IncreaseTime();
        }
    }

    private void IncreaseTime()
    {
        StartCoroutine(IncreaseTimeCoroutine());

    }

    private IEnumerator IncreaseTimeCoroutine()
    {
        time += Time.deltaTime;

        yield return new WaitForSeconds(0.02f);

        int timeEntero = (int) time;

        timeLabel.text = timeEntero.ToString();


    }


    public void GameStateUpdated(GameManager.GameState newState)
    {
        if (newState == GameManager.GameState.GameOver)
        {
            time = 0;
            //pointsLabel.text = displayedPoints.ToString();
        }
    }

}
