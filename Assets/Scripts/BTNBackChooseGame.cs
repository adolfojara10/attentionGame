using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTNBackChooseGame : MonoBehaviour
{
    public void BTNBack()
    {
        Debug.Log("--------------------- gameBTNBACKKK");
        GameManager.Instance.ChooseGame();
        BTManager.Instance.enviarMen("cancelar");
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
