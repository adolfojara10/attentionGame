using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data;
using DataBank;

public class BTNFindCedula : MonoBehaviour
{
    [SerializeField] private TMP_InputField cedula;

    public void FindStudentByCedula()
    {
        if (!string.IsNullOrWhiteSpace(cedula.text))
        {
            // Execute your code here when the input field is not empty
            Debug.Log("Input field has text: " + cedula.text);

            IDataReader dataReader = GameManager.Instance.conexionSQL.getStudentByCedula(cedula.text);

            if (dataReader != null)
            {
                EstudianteEntity estudiante = new EstudianteEntity(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4));
                Debug.Log("4" + estudiante);

                dataReader = GameManager.Instance.conexionSQL.getDataByIdString("NivelAtencionJuegos", estudiante._id);
                NivelAtencionJuegosEntity nivelAtencionJuegos = new NivelAtencionJuegosEntity(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4), dataReader.GetString(5), dataReader.GetString(6), dataReader.GetString(7), dataReader.GetString(8), dataReader.GetString(9), dataReader.GetString(10));

                GameManager.Instance.ReadStudentById(estudiante._id);

                BTManager.Instance.enviarMen("saludar");

            }
            else
            {
                GameManager.Instance.Error();
                Debug.Log("bien 2");

                UIError.Instance.ChangeText("Error: el estudiante no ha sido encontrado. Por favor inténtelo de nuevo.\nSi el error persiste, crear un nuevo usuario.");
                UIError.Instance.SetActiveImage(0);
                BTManager.Instance.enviarMen("cancelar");
            }

        }
    }
}
