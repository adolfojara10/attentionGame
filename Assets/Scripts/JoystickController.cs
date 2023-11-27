using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    //public float speed;
    public FixedJoystick fixedJoystick;


    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * fixedJoystick.Vertical + Vector3.right * fixedJoystick.Horizontal;
        //rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        // Format to one decimal place and concatenate into a string separated by a comma
        string formattedValues = (fixedJoystick.Horizontal * 200f).ToString("F1", System.Globalization.CultureInfo.InvariantCulture) + ", " +
                         (fixedJoystick.Vertical * 200f).ToString("F1", System.Globalization.CultureInfo.InvariantCulture);

        // Log or use the resulting string
        BTManager.Instance.enviarMen(formattedValues);
        //Debug.Log(formattedValues);

    }
}
