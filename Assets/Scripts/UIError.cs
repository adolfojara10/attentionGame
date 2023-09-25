using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIError : MonoBehaviour
{
    public TextMeshProUGUI title;

    public static UIError Instance;

    public List<Image> images = new List<Image>();

    private void Awake()
    {

        Instance = this;

    }

    public void ChangeText(string newText)
    {
        title.text = newText;
    }

    public void SetActiveImage(int indexToActivate)
    {
        // Deactivate all images
        foreach (Image image in images)
        {
            image.gameObject.SetActive(false);
        }

        // Check if the index is within the valid range
        if (indexToActivate >= 0 && indexToActivate < images.Count)
        {
            // Activate the image at the specified index
            images[indexToActivate].gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Index out of range: " + indexToActivate);
        }
    }

    public void BackButtonClicked()
    {

        GameManager.Instance.MainMenu();
    }
}
