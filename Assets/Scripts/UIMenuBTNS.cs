using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuBTNS : MonoBehaviour
{
    public void ChooseGameButtonClicked()
    {
        GameManager.Instance.ChooseGame();
    }


    public void ExitButtonClicked()
    {
        GameManager.Instance.ExitGame();
    }
}
