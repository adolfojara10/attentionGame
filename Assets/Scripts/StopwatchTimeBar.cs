using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopwatchTimeBar : MonoBehaviour
{
    public static StopwatchTimeBar Instance;

    public float currentTimeToMatch = 0f;

    public float timeToMatch = 18f;


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
        GameManager.Instance.OnGameStateUpdated.AddListener(GameStateUpdated);
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

                if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionSelectivaPiezasFaltantes || GameManager.Instance.gamePlaying == GameManager.GamePlaying.IntegracionVisual || GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionSelectivaSostenida)
                {
                    if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionSelectivaPiezasFaltantes)
                    {
                        BDManager.Instance.botonesEncontrados = BTNManager.Instance.differencesFound.ToString();
                        BDManager.Instance.tiempo = (timeToMatch - 3).ToString();
                    }

                    if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionSelectivaSostenida)
                    {
                        BDManager.Instance.botonesEncontrados = BTNManagerSelectivaSostenida.Instance.objectsFound.ToString();
                        BDManager.Instance.tiempo = (timeToMatch - 3).ToString();
                    }

                    GameManager.Instance.GameOverCierreVisual();
                }
                else if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.ConcienciaCorporal || GameManager.Instance.gamePlaying == GameManager.GamePlaying.Yoga)
                {
                    GameManager.Instance.GameOverEsquemaCorporal();
                }
                else if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionAuditivaDiscriminarFigura || GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionAuditivaLocalizarSonido || GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionSelectivaObjetosPerdidos)
                {
                    if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionAuditivaDiscriminarFigura)
                    {
                        BDManager.Instance.botonesEncontrados = BTNManagerDiscriminandoFiguras.Instance.soundsFound.ToString();
                        BDManager.Instance.tiempo = (timeToMatch - 3).ToString();
                    }

                    if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionAuditivaLocalizarSonido)
                    {
                        BDManager.Instance.tiempo = (timeToMatch - 3).ToString();
                    }
                    
                    GameManager.Instance.GameOverDiscriminacionAuditiva();
                }
            }
        }
    }

    public void GamePlayingUpdated(GameManager.GamePlaying newGamePlaying)
    {
        if ((newGamePlaying == GameManager.GamePlaying.AtencionAuditivaLocalizarSonido && GameManager.Instance.gameState == GameManager.GameState.InGame)
            || (newGamePlaying == GameManager.GamePlaying.AtencionSelectivaPiezasFaltantes && GameManager.Instance.gameState == GameManager.GameState.InGame)
            || (newGamePlaying == GameManager.GamePlaying.AtencionSelectivaSostenida && GameManager.Instance.gameState == GameManager.GameState.InGame)
            || (newGamePlaying == GameManager.GamePlaying.AtencionAuditivaDiscriminarFigura && GameManager.Instance.gameState == GameManager.GameState.InGame))
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


    public void GameStateUpdated(GameManager.GameState newState)
    {
        //Debug.Log(" estad audio " + newState);
        if (newState != GameManager.GameState.InGame)
        {
            currentTimeToMatch = 0f;
            IsPlaying = false;
        }
    }
}
