using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTNBack2DObject : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("--------------------- gameBTNBACKKK");
        GameManager.Instance.ChooseGameCierreVisual();
    }
}
