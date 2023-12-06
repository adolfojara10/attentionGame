using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTNNextLevel : MonoBehaviour
{
    public void BTNYogaUploadLevel()
    {
        GameManager.Instance.CompletedGameEsquemaCorporal();
    }
}
