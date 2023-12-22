using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContainerDiferenciasManager : MonoBehaviour
{
    public GameObject[] containersLevels;

    public TextMeshProUGUI title;

    //public TextMeshProUGUI differencesMissing;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnGamePlayingUpdated.AddListener(GamePlayingUpdated);
        GameManager.Instance.OnGameStateUpdated.AddListener(GameStateUpdated);
    }


    public void GamePlayingUpdated(GameManager.GamePlaying newGamePlaying)
    {
        //Debug.Log("jugando--------------- " + newGamePlaying);
        if (newGamePlaying == GameManager.GamePlaying.AtencionSelectivaPiezasFaltantes)
        {
            
            //differencesMissing.text = "Diferencias encontradas: 0";
            //Debug.Log("nivel ---------------- : " + GameManager.Instance.nivelAtencionJuegos._atencionSelectivaPiezasFaltantes);
            if (GameManager.Instance.nivelAtencionJuegos._atencionSelectivaPiezasFaltantes == "facil")
            {
                Debug.Log("---------------------facil");
                containersLevels[0].SetActive(true);
                title.text = "Encuentra las 5 diferencias";
                StopwatchTimeBar.Instance.timeToMatch = 45f;

            }

            if (GameManager.Instance.nivelAtencionJuegos._atencionSelectivaPiezasFaltantes == "medio")
            {
                Debug.Log("---------------------medio");
                //StopwatchTimeBar.Instance.timeToMatch = 30f;
                containersLevels[1].SetActive(true);
                title.text = "Encuentra las 7 diferencias";
                StopwatchTimeBar.Instance.timeToMatch = 60f;
            }

            if (GameManager.Instance.nivelAtencionJuegos._atencionSelectivaPiezasFaltantes == "dificil")
            {
                Debug.Log("---------------------dificil");
                //StopwatchTimeBar.Instance.timeToMatch = 30f;
                containersLevels[2].SetActive(true);
                title.text = "Encuentra las 10 diferencias";
                StopwatchTimeBar.Instance.timeToMatch = 90f;
            }
        }
    }

    public void GameStateUpdated(GameManager.GameState newState)
    {
        //Debug.Log("state--------------- " + newState);
        if (newState != GameManager.GameState.InGame)
        {
            StopwatchTimeBar.Instance.currentTimeToMatch = 0f;
            foreach (var container in containersLevels)
            {

                if (container != null && !ReferenceEquals(container, null))
                {
                    container.SetActive(false);
                }
            }
        }

        if (newState == GameManager.GameState.InGame && GameManager.GamePlaying.AtencionSelectivaPiezasFaltantes == GameManager.Instance.gamePlaying)
        {
            GamePlayingUpdated(GameManager.Instance.gamePlaying);
        }

    }
}
