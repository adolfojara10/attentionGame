using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BTNManager : MonoBehaviour
{
    public static BTNManager Instance;
    public int differencesToFind;
    public int differencesFound = 0;
    public TextMeshProUGUI differencesMissing;

    public List<Button> buttonsDifference;

    private void Awake()
    {

        Instance = this;

    }


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < buttonsDifference.Count; i++)
        {
            int buttonIndex = i; // Capture the index in a local variable
            buttonsDifference[i].onClick.AddListener(() => ButtonClicked(buttonIndex));
        }

        GameManager.Instance.OnGamePlayingUpdated.AddListener(GamePlayingUpdated);
        GameManager.Instance.OnGameStateUpdated.AddListener(GameStateUpdated);
    }


    public void ButtonClicked(int buttonIndex)
    {
        buttonsDifference[buttonIndex].gameObject.SetActive(false);
        differencesFound++;
        differencesMissing.text = differencesFound.ToString();

        if (differencesFound == differencesToFind)
        {
            GameManager.Instance.CompletedGame();
        }
    }

    public void GamePlayingUpdated(GameManager.GamePlaying newGamePlaying)
    {
        if (newGamePlaying == GameManager.GamePlaying.AtencionSelectivaPiezasFaltantes)
        {
            foreach (Button button in buttonsDifference)
            {
                button.gameObject.SetActive(true);
            }
        }
        //differencesFound = 0;
    }

    public void GameStateUpdated(GameManager.GameState newState)
    {
        //Debug.Log("state--------------- " + newState);
        if (newState != GameManager.GameState.InGame)
        {
            differencesFound = 0;
            differencesMissing.text = differencesFound.ToString();
        }

        if (newState == GameManager.GameState.InGame)
        {
            GamePlayingUpdated(GameManager.Instance.gamePlaying);
        }


    }
}
