using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    public Texture2D handCursor;

    void Start()
    {
        Cursor.SetCursor(handCursor, Vector2.zero, CursorMode.ForceSoftware);
    }
}
