using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    //public float speed;
    public FixedJoystick fixedJoystick;

    public bool is_zero_send;
    private int frameCounter = 0;

    private void Start()
    {
        is_zero_send = true;
        // Set the fixed time step to 1/30th of a second (30 frames per second)
        Time.fixedDeltaTime = 1f / 60f;
    }


    public void FixedUpdate()
    {
        //float verticalValue = fixedJoystick.Vertical;
        //float horizontalValue = fixedJoystick.Horizontal;

        float horizontalValue = fixedJoystick.Vertical;
        float verticalValue = fixedJoystick.Horizontal;

        if (Mathf.Abs(verticalValue) != 0 || Mathf.Abs(horizontalValue) != 0)
        {
            // Convert float values to integers
            int roundedHorizontal = Mathf.RoundToInt(horizontalValue * -200f);
            int roundedVertical = Mathf.RoundToInt(verticalValue * 200f);

            // Create the formatted string
            string formattedValues = "jugar_robot_" + "v " + roundedHorizontal + " " + roundedVertical;

            // Log or use the resulting string
            BTManager.Instance.enviarMen(formattedValues);

            if (frameCounter == 620)
            {
                BTManager.Instance.enviarMen(formattedValues);
                frameCounter = 0;
            }
            else
            {
                frameCounter++;
            }

            is_zero_send = false;
            //Debug.Log(formattedValues);
        }
        else if (Mathf.Abs(verticalValue) == 0 && Mathf.Abs(horizontalValue) == 0 && !is_zero_send)
        {
            // Convert float values to integers
            int roundedHorizontal = 0;
            int roundedVertical = 0;

            // Create the formatted string
            string formattedValues = "jugar_robot_" + "v " + roundedHorizontal + " " + roundedVertical;

            // Log or use the resulting string
            BTManager.Instance.enviarMen(formattedValues);
            is_zero_send = true;
            //frameCounter = 0;
        }

    }
}
