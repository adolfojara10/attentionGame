using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTNContainerFacil : MonoBehaviour
{
    public void RigthBTNClicked(){
        GameManager.Instance.CompletedGameDiscriminacionAuditiva();
    }

    public void WrongBTNClicked(){
        GameManager.Instance.GameOver();
    }
}
