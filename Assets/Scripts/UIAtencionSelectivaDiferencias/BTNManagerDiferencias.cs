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
            Color transparentColor = new Color(1f, 1f, 1f, 0f);

            // Get the button's image component
            Image buttonImage = buttonsDifference[i].GetComponent<Image>();

            // Assign the transparent color to the button's image
            buttonImage.color = transparentColor;
            buttonsDifference[i].interactable = true;
            buttonsDifference[i].onClick.AddListener(() => ButtonClicked(buttonIndex));

        }

        GameManager.Instance.OnGamePlayingUpdated.AddListener(GamePlayingUpdated);
        GameManager.Instance.OnGameStateUpdated.AddListener(GameStateUpdated);
    }


    public void ButtonClicked(int buttonIndex)
    {
        Button button = buttonsDifference[buttonIndex];

        // Disable the button's interactivity
        button.interactable = false;

        // Create a Color with fully opaque alpha (1)
        Color opaqueColor = new Color(1f, 1f, 1f, 1f);

        // Get the button's image component
        Image buttonImage = button.GetComponent<Image>();

        // Assign the opaque color to the button's image
        buttonImage.color = opaqueColor;

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
            for (int i = 0; i < buttonsDifference.Count; i++)
            {
                int buttonIndex = i; // Capture the index in a local variable
                Color transparentColor = new Color(1f, 1f, 1f, 0f);

                // Get the button's image component
                Image buttonImage = buttonsDifference[i].GetComponent<Image>();

                // Assign the transparent color to the button's image
                buttonImage.color = transparentColor;
                buttonsDifference[i].interactable = true;
                //buttonsDifference[i].onClick.AddListener(() => ButtonClicked(buttonIndex));

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
