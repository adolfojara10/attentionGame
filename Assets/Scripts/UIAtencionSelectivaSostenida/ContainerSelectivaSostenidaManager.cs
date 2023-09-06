using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerSelectivaSostenidaManager : MonoBehaviour
{
    public GameObject[] containersLevels;


    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnGamePlayingUpdated.AddListener(GamePlayingUpdated);
        GameManager.Instance.OnGameStateUpdated.AddListener(GameStateUpdated);
    }


    public void GamePlayingUpdated(GameManager.GamePlaying newGamePlaying)
    {
        //Debug.Log("jugando--------------- " + newGamePlaying);
        if (newGamePlaying == GameManager.GamePlaying.AtencionSelectivaSostenida)
        {
            
            //Debug.Log("nivel ---------------- : " + GameManager.Instance.nivelAtencionJuegos._atencionAuditivaLocalizarSonido);
            if (GameManager.Instance.nivelAtencionJuegos._atencionSelectivaSostenida == "facil")
            {
                containersLevels[0].SetActive(true);
                StopwatchTimeBar.Instance.timeToMatch = 30f;
            }

            if (GameManager.Instance.nivelAtencionJuegos._atencionSelectivaSostenida == "medio")
            {
                
                containersLevels[1].SetActive(true);
                StopwatchTimeBar.Instance.timeToMatch = 45f;
            }

            if (GameManager.Instance.nivelAtencionJuegos._atencionSelectivaSostenida == "dificil")
            {
                
                containersLevels[2].SetActive(true);
                StopwatchTimeBar.Instance.timeToMatch = 60f;

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

    }
}
