using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTNContainerFacil : MonoBehaviour
{
    public void RigthBTNClicked(){
        GameManager.Instance.CompletedGame();
    }

    public void WrongBTNClicked(){
        Debug.Log("Instrumento incorrecto");
    }
}
