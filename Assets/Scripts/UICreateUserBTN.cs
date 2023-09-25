using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UI.Dates;
using TMPro;
using System;

public class UICreateUserBTN : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameField;
    [SerializeField] private TMP_InputField lastNameField;
    [SerializeField] private DatePicker datePicker;
    [SerializeField] private Button actionButton;
    [SerializeField] private Image errorIcon;

    private void Start()
    {
        // Disable the error icon initially
        errorIcon.enabled = false;

        // Attach a click event to the button
        actionButton.onClick.AddListener(OnActionButtonClick);
    }

    private void OnActionButtonClick()
    {
        // Check if the input field has text
        if (!string.IsNullOrWhiteSpace(nameField.text))
        {
            // Execute your code here when the input field is not empty
            Debug.Log("Input field has text: " + nameField.text);

            // Hide the error icon
            errorIcon.enabled = false;

            if (!string.IsNullOrWhiteSpace(lastNameField.text))
            {
                // Execute your code here when the input field is not empty
                Debug.Log("Input field has text: " + lastNameField.text);

                // Hide the error icon
                errorIcon.enabled = false;

                if (!string.IsNullOrWhiteSpace(datePicker.GetComponent<DatePicker>().SelectedDate.ToString()) && datePicker.GetComponent<DatePicker>().SelectedDate.ToString() != "Selecciona una fecha")
                {
                    // Execute your code here when the input field is not empty
                    Debug.Log("Input field has text: " + datePicker.GetComponent<DatePicker>().SelectedDate.ToString());
                    DateTime dateTime = DateTime.Parse(datePicker.GetComponent<DatePicker>().SelectedDate.ToString()); // Parse the input string into a DateTime object
                    string dateOnly = dateTime.ToShortDateString();
                    Debug.Log(dateOnly);
                    // Hide the error icon
                    errorIcon.enabled = false;

                    int ID = GameManager.Instance.estudianteDB.GetRowCount() + 1;

                    string idNombreApellido = ID.ToString() + " " + nameField.text + " " + lastNameField.text;


                    BTManager.Instance.enviarMen(idNombreApellido);
                    Debug.Log(idNombreApellido);

                    BTManager.Instance.nameNewStudent = nameField.text;
                    BTManager.Instance.nameNewStudent = lastNameField.text;
                    BTManager.Instance.bornNewStudent = dateOnly;

                    GameManager.Instance.Saving();
                    //UIError.Instance.ChangeText("Guardando usuario \n*Por favor colocar el rostro al frente del robot");



                    //BDManager.Instance.CreateStudent(nameField.text, lastNameField.text, dateOnly);
                }
                else
                {
                    // Show the error icon
                    errorIcon.enabled = true;

                    // Position the error icon relative to the input field
                    RectTransform inputFieldRect = datePicker.GetComponent<RectTransform>();
                    RectTransform errorIconRect = errorIcon.GetComponent<RectTransform>();

                    errorIconRect.anchoredPosition = new Vector2(
                        334f,
                        inputFieldRect.anchoredPosition.y + 26f// Keep the same y position
                    );
                }
            }
            else
            {
                // Show the error icon
                errorIcon.enabled = true;

                // Position the error icon relative to the input field
                RectTransform inputFieldRect = lastNameField.GetComponent<RectTransform>();
                RectTransform errorIconRect = errorIcon.GetComponent<RectTransform>();

                errorIconRect.anchoredPosition = new Vector2(
                    334f, //+ inputFieldRect.rect.width + 10f, // Adjust the x offset as needed
                    inputFieldRect.anchoredPosition.y // Keep the same y position
                );
            }
        }
        else
        {
            // Show the error icon
            errorIcon.enabled = true;

            // Position the error icon relative to the input field
            RectTransform inputFieldRect = nameField.GetComponent<RectTransform>();
            RectTransform errorIconRect = errorIcon.GetComponent<RectTransform>();

            errorIconRect.anchoredPosition = new Vector2(
                334f, //+ inputFieldRect.rect.width + 10f, // Adjust the x offset as needed
                inputFieldRect.anchoredPosition.y // Keep the same y position
            );
        }






    }


    public void BackButtonClicked()
    {
        //Debug.Log("MAIN MENUUU");
        errorIcon.enabled = false;
        nameField.text = "";
        lastNameField.text = "";


        GameManager.Instance.MainMenu();
    }
}
