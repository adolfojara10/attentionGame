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

    public void AtencionSelectivaSostenidaGameButtonClicked()
    {
        //Debug.Log("--------------------- gameBTNMA");
        GameManager.Instance.AtencionSelectivaSostenidaGame();
    }


    public void AtencionAuditivaDiscriminarFiguraGameButtonClicked()
    {
        //Debug.Log("--------------------- gameBTNMA");
        GameManager.Instance.AtencionAuditivaDiscriminarFiguraGame();
    }


    public void RompecabezasButtonClicked()
    {
        GameManager.Instance.RompecabezasGame();
    }

    public void IntegracionVisualButtonClicked()
    {
        GameManager.Instance.StartDemoIntegracionVisual();
    }

    public void IntegracionVisualEmpezarButtonClicked()
    {
        GameManager.Instance.IntegracionVisualGame();
    }


    public void BackButtonClicked()
    {
        //Debug.Log("MAIN MENUUU");
        GameManager.Instance.MainMenu();
    }

    public void CierreVisualButtonClicked()
    {
        GameManager.Instance.ChooseGameCierreVisual();
    }

    public void EsquemaCorporalButtonClicked()
    {
        GameManager.Instance.ChooseGameEsquemaCorporal();
    }

    public void DiscriminacionAuditivaButtonClicked()
    {
        GameManager.Instance.ChooseGameDiscriminacionAuditiva();
        //Debug.Log("hhhhhhhhhhhhhh");
    }


    public void BackButtonToChooseGameClicked()
    {
        //Debug.Log("MAIN MENUUU");
        GameManager.Instance.ChooseGame();
    }




}
