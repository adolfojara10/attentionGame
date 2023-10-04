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

    public void BTNBackCierreVisual()
    {
        //Debug.Log("--------------------- gameBTNBACKKK");
        GameManager.Instance.ChooseGameCierreVisual();
        BTManager.Instance.enviarMen("cancelar");
    }

    public void BTNBackEsquemaCorporal()
    {
        //Debug.Log("--------------------- gameBTNBACKKK");
        GameManager.Instance.ChooseGameEsquemaCorporal();
        BTManager.Instance.enviarMen("cancelar");
    }

    public void BTNBackDiscriminacionAuditiva()
    {
        //Debug.Log("--------------------- gameBTNBACKKK");
        GameManager.Instance.ChooseGameDiscriminacionAuditiva();
        BTManager.Instance.enviarMen("cancelar");
    }

}
