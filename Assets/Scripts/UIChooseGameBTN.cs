using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIChooseGameBTN : MonoBehaviour
{
    public void IntegracionVisualButtonClicked()
    {
        GameManager.Instance.IntegracionVisualGame();
    }





    public void BackButtonClicked()
    {
        GameManager.Instance.MainMenu();
    }
}
