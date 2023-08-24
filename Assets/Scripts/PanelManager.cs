using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{

    public List<GameObject> panels = new List<GameObject>();

    private UIScreen UIActive;



    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnGameStateUpdated.AddListener(GameStateUpdated);
        GameManager.Instance.OnGamePlayingUpdated.AddListener(GamePlayingUpdated);
        EnablePanelMenu();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnablePanelMenu()
    {
        foreach (var ui in panels)
        {
            var uiScript = ui.GetComponent<UIScreen>();
            bool initialState = GameManager.Instance.gameState == uiScript.visibleState;

            if (initialState)
            {
                UIActive = uiScript;
            }

            uiScript.background.enabled = initialState;
            uiScript.containerRect.gameObject.SetActive(initialState);
        }
    }


    public void GameStateUpdated(GameManager.GameState newState)
    {
        foreach (var ui in panels)
        {
            var uiScript = ui.GetComponent<UIScreen>();
            if (newState != GameManager.GameState.InGame && newState != GameManager.GameState.GameCompleted)
            {
                bool actualState = GameManager.Instance.gameState == uiScript.visibleState;
                if (actualState)
                {
                    UIActive.HideScreen();
                    uiScript.ShowScreen();
                    UIActive = uiScript;
                }
            }

        }
    }


    public void GamePlayingUpdated(GameManager.GamePlaying gamePlaying)
    {

    }


}
