using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTNContainerFacil : MonoBehaviour
{
    public void RigthBTNClicked()
    {
        BDManager.Instance.tiempo = StopwatchTimeBar.Instance.currentTimeToMatch.ToString();
        GameManager.Instance.CompletedGameDiscriminacionAuditiva();
    }

    public void WrongBTNClicked()
    {
        BDManager.Instance.tiempo = StopwatchTimeBar.Instance.currentTimeToMatch.ToString();
        GameManager.Instance.GameOverDiscriminacionAuditiva();
    }
}
