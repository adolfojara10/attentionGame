using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameCompleted : MonoBehaviour
{


    public void PlayAgainButtonClicked()
    {
        GameManager.Instance.RestartGame();
    }


    public void MenuButtonClicked()
    {
        GameManager.Instance.ChooseGame();
    }

}
