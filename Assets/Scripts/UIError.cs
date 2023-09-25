using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIError : MonoBehaviour
{
    public TextMeshProUGUI title;

    public static UIError Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeText(string newText)
    {
        title.text = newText;
    }

    public void BackButtonClicked()
    {

        GameManager.Instance.MainMenu();
    }
}
