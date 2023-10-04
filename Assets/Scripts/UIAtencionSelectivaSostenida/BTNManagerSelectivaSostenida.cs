using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BTNManagerSelectivaSostenida : MonoBehaviour
{
    public int objectsToFind;
    public int objectsFound = 0;

    public List<Button> buttonsDifference;

    public List<Image> images;

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
        images[buttonIndex].gameObject.SetActive(false);
        objectsFound++;

        if (objectsFound == objectsToFind)
        {
            GameManager.Instance.CompletedGameCierreVisual();
        }
    }

    public void GamePlayingUpdated(GameManager.GamePlaying newGamePlaying)
    {
        if (newGamePlaying == GameManager.GamePlaying.AtencionSelectivaSostenida)
        {
            foreach (Button button in buttonsDifference)
            {
                button.gameObject.SetActive(true);
            }

            foreach (Image img in images)
            {
                img.gameObject.SetActive(true);
            }
        }
    }

    public void GameStateUpdated(GameManager.GameState newState)
    {
        //Debug.Log("state--------------- " + newState);
        if (newState != GameManager.GameState.InGame)
        {
            objectsFound = 0;
        }

        if (newState == GameManager.GameState.InGame)
        {
            GamePlayingUpdated(GameManager.Instance.gamePlaying);
        }


    }

}
