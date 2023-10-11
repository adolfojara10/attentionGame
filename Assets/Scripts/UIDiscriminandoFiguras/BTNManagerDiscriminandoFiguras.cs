using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BTNManagerDiscriminandoFiguras : MonoBehaviour
{
    public static BTNManagerDiscriminandoFiguras Instance;
    public int soundsToFind;
    public int soundsFound = 0;

    public TextMeshProUGUI soundsMissing;

    public List<Button> buttonsSounds;

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
        /*for (int i = 0; i < buttonsSounds.Count; i++)
        {
            int buttonIndex = i; // Capture the index in a local variable
            buttonsSounds[i].onClick.AddListener(() => ButtonClicked(buttonIndex));
        }*/

        GameManager.Instance.OnGamePlayingUpdated.AddListener(GamePlayingUpdated);
        GameManager.Instance.OnGameStateUpdated.AddListener(GameStateUpdated);
    }


    public void ButtonClicked(int buttonIndex)
    {
        buttonsSounds[buttonIndex].gameObject.SetActive(false);
        soundsFound++;
        soundsMissing.text = soundsFound.ToString();

        if (soundsFound == soundsToFind)
        {
            BDManager.Instance.tiempo = StopwatchTimeBar.Instance.currentTimeToMatch.ToString();
            BDManager.Instance.botonesEncontrados = soundsFound.ToString();
            GameManager.Instance.CompletedGameDiscriminacionAuditiva();
        }
    }

    public void GamePlayingUpdated(GameManager.GamePlaying newGamePlaying)
    {
        if (newGamePlaying == GameManager.GamePlaying.AtencionAuditivaDiscriminarFigura)
        {
            foreach (Button button in buttonsSounds)
            {
                button.gameObject.SetActive(true);
            }
        }
    }

    public void GameStateUpdated(GameManager.GameState newState)
    {
        //Debug.Log("state--------------- " + newState);
        if (newState != GameManager.GameState.InGame)
        {
            soundsFound = 0;
        }

        if (newState == GameManager.GameState.InGame)
        {
            GamePlayingUpdated(GameManager.Instance.gamePlaying);
        }


    }
}
