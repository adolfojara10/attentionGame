using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BTNDemo : MonoBehaviour
{

    public int differencesToFind;
    public int differencesFound = 0;


    public List<Button> buttonsDifference;

    Color transparentColor = new Color(1f, 1f, 1f, 0f);



    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < buttonsDifference.Count; i++)
        {
            int buttonIndex = i; // Capture the index in a local variable
            Color transparentColor = new Color(1f, 1f, 1f, 0f);

            // Get the button's image component
            Image buttonImage = buttonsDifference[i].GetComponent<Image>();

            // Assign the transparent color to the button's image
            buttonImage.color = transparentColor;
            buttonsDifference[i].interactable = true;
            buttonsDifference[i].onClick.AddListener(() => ButtonClicked(buttonIndex));

        }

        
    }


    public void ButtonClicked(int buttonIndex)
    {
        Button button = buttonsDifference[buttonIndex];

        // Disable the button's interactivity
        button.interactable = false;

        // Create a Color with fully opaque alpha (1)
        Color opaqueColor = new Color(1f, 1f, 1f, 1f);

        // Get the button's image component
        Image buttonImage = button.GetComponent<Image>();

        // Assign the opaque color to the button's image
        buttonImage.color = opaqueColor;

        differencesFound++;
        
    }

}
