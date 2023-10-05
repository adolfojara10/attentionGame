using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimeBar : MonoBehaviour
{
    public RectTransform fillRect;

    public Image fillColor;

    public Gradient gradient;

    private bool shouldStart = false;
    private float delay = 3f;

    private void Start()
    {

        //GameManager.Instance.OnGamePlayingUpdated.AddListener(GamePlayingUpdated);
        //StartCoroutine(StartAfterDelay());
    }

    // Update is called once per frame
    void Update()
    {
        /*if (!shouldStart)
        {
            return; // Wait until the delay is over
        }*/

        float factor = StopwatchTimeBar.Instance.currentTimeToMatch / StopwatchTimeBar.Instance.timeToMatch;
        factor = Mathf.Clamp(factor, 0f, 1f);

        factor = 1 - factor;

        fillRect.localScale = new Vector3(factor, 1, 1);
        fillColor.color = gradient.Evaluate(factor);
    }

    /*private IEnumerator StartAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        shouldStart = true;
    }*/

    /*public void GamePlayingUpdated(GameManager.GamePlaying newPlaying)
    {

        if (GameManager.Instance.gameState == GameManager.GameState.InGame)
        {
            if (newPlaying == GameManager.GamePlaying.AtencionAuditivaDiscriminarFigura || newPlaying == GameManager.GamePlaying.AtencionAuditivaLocalizarSonido)
            {
                Debug.Log("entraaaaa ----- ");
                StartCoroutine(StartAfterDelay());
            }
        }
        else
        {
            shouldStart = false;
        }

    }*/

}
