using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerAtencionAuditivaManager : MonoBehaviour
{
    public GameObject[] containersLevels;




    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnGamePlayingUpdated.AddListener(GamePlayingUpdated);
        GameManager.Instance.OnGameStateUpdated.AddListener(GameStateUpdated);
    }

    // Update is called once per frame
    void Update()
    {



    }


    public void GamePlayingUpdated(GameManager.GamePlaying newGamePlaying)
    {
        //Debug.Log("jugando--------------- " + newGamePlaying);
        if (newGamePlaying == GameManager.GamePlaying.AtencionAuditivaLocalizarSonido)
        {
            //Debug.Log("nivel ---------------- : " + GameManager.Instance.nivelAtencionJuegos._atencionAuditivaLocalizarSonido);
            if (GameManager.Instance.nivelAtencionJuegos._atencionAuditivaLocalizarSonido == "facil")
            {
                StopwatchTimeBar.Instance.timeToMatch = 30f;
                containersLevels[0].SetActive(true);
            }

            if (GameManager.Instance.nivelAtencionJuegos._atencionAuditivaLocalizarSonido == "medio")
            {
                StopwatchTimeBar.Instance.timeToMatch = 30f;
                containersLevels[1].SetActive(true);
            }

            if (GameManager.Instance.nivelAtencionJuegos._atencionAuditivaLocalizarSonido == "dificil")
            {
                StopwatchTimeBar.Instance.timeToMatch = 30f;
                containersLevels[2].SetActive(true);
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
                container.SetActive(false);
            }
        }

        if (newState == GameManager.GameState.InGame && GameManager.GamePlaying.AtencionAuditivaLocalizarSonido == GameManager.Instance.gamePlaying)
        {
            GamePlayingUpdated(GameManager.Instance.gamePlaying);
        }
    }
}
