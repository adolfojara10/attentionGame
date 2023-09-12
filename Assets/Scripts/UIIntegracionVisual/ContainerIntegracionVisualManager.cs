using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerIntegracionVisualManager : MonoBehaviour
{
    public GameObject[] containersLevels;

    //public TextMeshProUGUI title;


    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnGamePlayingUpdated.AddListener(GamePlayingUpdated);
        GameManager.Instance.OnGameStateUpdated.AddListener(GameStateUpdated);
    }


    public void GamePlayingUpdated(GameManager.GamePlaying newGamePlaying)
    {

        if (newGamePlaying == GameManager.GamePlaying.IntegracionVisual)
        {
            //StopwatchTimeBar.Instance.timeToMatch = 15f;
            //containersLevels[0].SetActive(true);

            //Debug.Log("nivel ---------------- : " + GameManager.Instance.nivelAtencionJuegos._atencionAuditivaDiscriminarFigura);
            //Debug.Log("containers ---------------- : " + containersLevels.Length);
            if (GameManager.Instance.nivelAtencionJuegos._integracionVisual == "facil")
            {

                containersLevels[0].SetActive(true);
                //title.text = "Encuentra los 2 sonidos";

            }

            if (GameManager.Instance.nivelAtencionJuegos._integracionVisual == "medio")
            {
                //StopwatchTimeBar.Instance.timeToMatch = 30f;
                containersLevels[1].SetActive(true);
                //title.text = "Encuentra los 5 sonidos";
            }

            if (GameManager.Instance.nivelAtencionJuegos._integracionVisual == "dificil")
            {
                //StopwatchTimeBar.Instance.timeToMatch = 30f;
                containersLevels[2].SetActive(true);
                //title.text = "Encuentra los 7 sonidos";
            }
        }
    }

    public void GameStateUpdated(GameManager.GameState newState)
    {
        //Debug.Log("state--------------- " + newState);
        if (newState != GameManager.GameState.InGame)
        {
            //StopwatchTimeBar.Instance.currentTimeToMatch = 0f;
            foreach (var container in containersLevels)
            {
                container.SetActive(false);
            }
        }

    }
}
