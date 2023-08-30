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
        if (newGamePlaying == GameManager.GamePlaying.AtencionAuditivaLocalizarSonido)
        {
            containersLevels[0].SetActive(true);
        }
    }


    public void GameStateUpdated(GameManager.GameState newState)
    {
        if (newState != GameManager.GameState.InGame)
        {
            foreach (var container in containersLevels)
            {
                container.SetActive(false);
            }
        }
    }
}
