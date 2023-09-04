using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIChooseGameBTN : MonoBehaviour
{
    public void AtencionAuditivaLocalizarSonidoGameButtonClicked()
    {
        GameManager.Instance.AtencionAuditivaLocalizarSonidoGame();
    }

    public void ConcienciaCorporalGameButtonClicked()
    {
        GameManager.Instance.ConcienciaCorporalGame();
    }

    public void YogaGameButtonClicked()
    {
        //Debug.Log("--------------------- gameBTNMA");
        GameManager.Instance.YogaGame();
    }

    public void ObjetosPerdidosGameButtonClicked()
    {
        //Debug.Log("--------------------- gameBTNMA");
        GameManager.Instance.ObjetosPerdidosGame();
    }

    public void DiferenciasGameButtonClicked()
    {
        //Debug.Log("--------------------- gameBTNMA");
        GameManager.Instance.DiferenciasGame();
    }





    public void IntegracionVisualButtonClicked()
    {
        GameManager.Instance.IntegracionVisualGame();
    }





    public void BackButtonClicked()
    {
        GameManager.Instance.MainMenu();
    }
}
