using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTNBackChooseGame : MonoBehaviour
{
    public void BTNBack()
    {
        Debug.Log("--------------------- gameBTNBACKKK");
        GameManager.Instance.ChooseGame();
    }
}
