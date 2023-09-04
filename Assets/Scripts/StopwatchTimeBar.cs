using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopwatchTimeBar : MonoBehaviour
{
    public static StopwatchTimeBar Instance;

    public float currentTimeToMatch = 0f;

    public float timeToMatch = 15f;


    public bool IsPlaying = false;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnGamePlayingUpdated.AddListener(GamePlayingUpdated);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlaying)
        {
            currentTimeToMatch += Time.deltaTime;

            if (currentTimeToMatch > timeToMatch)
            {
                IsPlaying = false;
                GameManager.Instance.GameOver();
            }
        }
    }

    public void GamePlayingUpdated(GameManager.GamePlaying newGamePlaying)
    {
        if ((newGamePlaying == GameManager.GamePlaying.AtencionAuditivaLocalizarSonido && GameManager.Instance.gameState == GameManager.GameState.InGame) || (newGamePlaying == GameManager.GamePlaying.AtencionSelectivaPiezasFaltantes && GameManager.Instance.gameState == GameManager.GameState.InGame))
        {
            //setear dependiendo del nivel del niño
            //timeToMatch = 15f;
            IsPlaying = true;
        }
        else
        {
            currentTimeToMatch = 0f;
            IsPlaying = false;
        }
    }
}
