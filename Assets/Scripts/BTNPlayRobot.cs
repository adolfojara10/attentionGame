using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTNPlayRobot : MonoBehaviour
{
    public void Parado()
    {
        BTManager.Instance.enviarMen("jugar_robot_p");
    }

    public void Sentado()
    {
        BTManager.Instance.enviarMen("jugar_robot_s");
    }

    public void Inicio()
    {
        BTManager.Instance.enviarMen("jugar_robot_i");
    }

    public void Acostado()
    {
        BTManager.Instance.enviarMen("jugar_robot_a");
    }

    public void Reset()
    {
        BTManager.Instance.enviarMen("jugar_robot_r");
    }

    public void CabezaIzquierda()
    {
        BTManager.Instance.enviarMen("jugar_robot_1");
    }

    public void CabezaDerecha()
    {
        BTManager.Instance.enviarMen("jugar_robot_2");
    }

    public void CabezaCentro()
    {
        BTManager.Instance.enviarMen("jugar_robot_3");
    }

    public void CabezaArriba()
    {
        BTManager.Instance.enviarMen("jugar_robot_4");
    }

    public void CabezaAbajo()
    {
        BTManager.Instance.enviarMen("jugar_robot_5");
    }

    public void Uno()
    {
        BTManager.Instance.enviarMen("jugar_robot_1");
    }

    public void Dos()
    {
        BTManager.Instance.enviarMen("jugar_robot_2");
    }

    public void Tres()
    {
        BTManager.Instance.enviarMen("jugar_robot_3");
    }

    public void Cuatro()
    {
        BTManager.Instance.enviarMen("jugar_robot_4");
    }
}
