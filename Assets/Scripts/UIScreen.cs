using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class UIScreen : MonoBehaviour
{
    public GameObject UIObject;

    public RectTransform containerRect;
    public CanvasGroup containerCanvas;
    public Image background;
    public GameManager.GameState visibleState;
    public GameManager.GamePlaying visiblePlaying;

    public float transitionTime;

    public bool isGameUI;


    // Start is called before the first frame update
    void Start()
    {
        //GameManager.Instance.OnGameStateUpdated.AddListener(GameStateUpdated);
        //GameManager.Instance.OnGamePlayingUpdated.AddListener(GameStateUpdated);
        bool initialState = GameManager.Instance.gameState == visibleState;

        UIObject.SetActive(initialState);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GameStateUpdated(GameManager.GameState newState)
    {
        if (newState == visibleState)
        {
            ShowScreen();
        }
        else
        {
            HideScreen();
        }
    }

    public void ShowScreen()
    {
        if (!isGameUI)
        {
            //enable elements
            background.enabled = true;
            containerRect.gameObject.SetActive(true);

            //bg animation
            var bgColor = background.color;
            bgColor.a = 0;
            background.color = bgColor;
            bgColor.a = 1;
            background.DOColor(bgColor, transitionTime);


            //container animation
            containerCanvas.alpha = 0;
            containerRect.anchoredPosition = new Vector2(0, 100);
            containerCanvas.DOFade(1f, transitionTime);
            containerRect.DOAnchorPos(Vector2.zero, transitionTime);
            UIObject.SetActive(true);
        }
        else
        {
            UIObject.SetActive(true);
        }



    }

    public void HideScreen()
    {

        if (!isGameUI)
        {
            //background animation
            var bgColor = background.color;
            bgColor.a = 0;
            background.DOColor(bgColor, transitionTime * 0.5f);


            //container animation
            containerCanvas.alpha = 1;
            containerRect.anchoredPosition = Vector2.zero;

            containerCanvas.DOFade(0, transitionTime * 0.5f);
            containerRect.DOAnchorPos(new Vector2(0, -100), transitionTime * 0.5f).onComplete = () =>
            {
                background.enabled = false;
                containerRect.gameObject.SetActive(false);
            };
            UIObject.SetActive(false);
        }
        else
        {
            UIObject.SetActive(false);
        }

    }
}
