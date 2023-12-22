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
        string databaseName = "my_db";
        string sourcePath = "/storage/emulated/0/Android/data/com.DefaultCompany.AttentionGame/files/" + databaseName;
        string destinationPath = Path.Combine(Application.persistentDataPath, "Documentos", databaseName);

        if (!File.Exists(destinationPath))
        {
            // Create the "Documentos" folder if it doesn't exist
            Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));

            // Copy the file from the source to the destination
            File.Copy(sourcePath, destinationPath);
            Debug.Log("Database file copied to 'Documentos' folder: " + destinationPath);
        }
        else
        {
            Debug.Log("Database file already exists in the 'Documentos' folder.");
        }
    }

    public void JugarRobot()
    {
        GameManager.Instance.JugarRobot();
    }

    public void TestSerial()
    {
        //BTManager.Instance.enviarMen("test_serial");
        BTManager.Instance.enviarMen("test_serial_2");
    }


    public void ExitButtonClicked()
    {
        GameManager.Instance.ExitGame();
    }

    public void ResetButtonClicked()
    {
        BTManager.Instance.enviarMen("reset");
    }

    public void CloseApp()
    {
        GameManager.Instance.CloseApp();
    }
}
