using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{

    public List<GameObject> panels = new List<GameObject>();

    private UIScreen UIActive;
    private UIScreen UILastOne;



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
                UILastOne = UIActive;
            }

            uiScript.UIObject.SetActive(initialState);
        }
    }


    public void GameStateUpdated(GameManager.GameState newState)
    {
        //Debug.Log("game state " + newState);
        foreach (var ui in panels)
        {
            var uiScript = ui.GetComponent<UIScreen>();
            //if (newState != GameManager.GameState.InGame && newState != GameManager.GameState.GameCompleted)
            if (newState != GameManager.GameState.InGame)
            {
                bool actualState = GameManager.Instance.gameState == uiScript.visibleState;
                //Debug.Log(uiScript.visibleState);
                if (actualState)
                {
                    UIActive.HideScreen();

                    /*if (UIActive.visiblePlaying == GameManager.GamePlaying.AtencionSelectivaPiezasFaltantes || UIActive.visiblePlaying == GameManager.GamePlaying.IntegracionVisual || UIActive.visiblePlaying == GameManager.GamePlaying.AtencionSelectivaSostenida){
                        GameManager.Instance.ChooseGameCierreVisual();
                    }*/


                    uiScript.ShowScreen();

                    //Debug.Log("si entraaaa 1" + uiScript.visibleState);

                    UILastOne = UIActive;

                    UIActive = uiScript;
                }
            }


        }
    }


    public void GamePlayingUpdated(GameManager.GamePlaying newPlaying)
    {
        //Debug.Log("new playing " + newPlaying);
        foreach (var ui in panels)
        {
            var uiScript = ui.GetComponent<UIScreen>();
            if (newPlaying != GameManager.GamePlaying.None)
            {
                bool actualPlaying = GameManager.Instance.gamePlaying == uiScript.visiblePlaying;
                bool actualState = GameManager.Instance.gameState == uiScript.visibleState;
                //Debug.Log(GameManager.Instance.gameState + "  " + GameManager.Instance.gamePlaying + "  " + uiScript.visiblePlaying + "   " + actualPlaying + "  " + actualState);

                if (actualPlaying && actualState)
                {
                    //Debug.Log("sirvioooo");
                    UIActive.HideScreen();
                    //UIActive.UIObject.SetActive(false);
                    //uiScript.UIObject.SetActive(false);
                    uiScript.ShowScreen();

                    UILastOne = UIActive;

                    //Debug.Log("si entraaaa 2");
                    UIActive = uiScript;
                }
            }

        }
    }


}
