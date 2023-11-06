using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


public class UIMenuBTNS : MonoBehaviour
{
    public void ChooseGameButtonClicked()
    {
        //GameManager.Instance.ChooseGame();
        GameManager.Instance.Charging();
        UIError.Instance.ChangeText("Cargando usuario \n*Por favor colocar el rostro al frente del robot");
    }


    public void UserButtonClicked()
    {
        GameManager.Instance.CreateUser();
    }

    public void BluetoothButtonClicked()
    {
        GameManager.Instance.ConnectBluetooth();
    }

    public void InvitedButtonClicked()
    {
        GameManager.Instance.InvitedSession();
    }


    public void DownloadBD()
    {
        
    }

    public void ExitButtonClicked()
    {
        GameManager.Instance.ExitGame();
    }
}
