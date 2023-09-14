using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using TechTweaking.Bluetooth;
using UnityEngine.UI;

using System;

public class Cangrejo : MonoBehaviour
{   
    public Text BTMessage;
    public GameObject InfoCanvas;
    public GameObject ActividadesCanvas;
    private string macSelected="00:21:06:BE:3D:0D";
//// volante
	//public Text valVolante;
	//public Text valAcelerador;
	public string horizontalAxis = "Horizontal";
	public string verticalAxis = "Vertical";
	private float inputHorizontal;
	private float inputVertical;



////


    private  BluetoothDevice device;
	public Text statusText;


    public void salir()
    {
        Application.Quit();

    }

    bool conect = false;
 
    public void conectarBT()
    {
        device = new BluetoothDevice();

        if (BluetoothAdapter.isBluetoothEnabled())
        {
            connect();
        }
        else
        {

            //BluetoothAdapter.enableBluetooth(); //you can by this force enabling Bluetooth without asking the user
            statusText.text = "Estado : Por favor active su Bluetooth";

            BluetoothAdapter.OnBluetoothStateChanged += HandleOnBluetoothStateChanged;
            BluetoothAdapter.listenToBluetoothState(); // if you want to listen to the following two events  OnBluetoothOFF or OnBluetoothON

            BluetoothAdapter.askEnableBluetooth();//Ask user to enable Bluetooth

        }


    }

	void Start ()
	{
		BluetoothAdapter.OnDeviceOFF += HandleOnDeviceOff;//This would mean a failure in connection! the reason might be that your remote device is OFF

		BluetoothAdapter.OnDeviceNotFound += HandleOnDeviceNotFound; //Because connecting using the 'Name' property is just searching, the Plugin might not find it!(only for 'Name').
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

	void Update()
	{

        if (device.IsConnected && !conect)
        {
            
            ActividadesCanvas.SetActive(true);
            InfoCanvas.SetActive(false);
            conect = true;

            if (device != null && !string.IsNullOrEmpty("x"))
            {
                device.send(System.Text.Encoding.ASCII.GetBytes("x" + (char)10));//10 is our seperator Byte (sepration between packets)
            }
        }

        if(conect)
        {
            inputHorizontal = SimpleInput.GetAxis( horizontalAxis );
            inputVertical = SimpleInput.GetAxis( verticalAxis );
            //valVolante.text= inputHorizontal*100+"";
            //valAcelerador.text=inputVertical*10+"";
            string envi="G:"+(int)inputHorizontal+"-V:"+(int)inputVertical;
            enviarMen(envi);

	    }
    }
	

    private void connect ()
	{
		statusText.text = "Estado : Tratando de conectar";
        device.MacAddress = macSelected;
        device.ReadingCoroutine = ManageConnection;
        statusText.text = "Estado : Tratando de conectar";		
		device.connect ();

	}

	void HandleOnBluetoothStateChanged (bool isBtEnabled)
	{
		if (isBtEnabled) {
			connect ();
			//We now don't need our recievers
			BluetoothAdapter.OnBluetoothStateChanged -= HandleOnBluetoothStateChanged;
			BluetoothAdapter.stopListenToBluetoothState ();
		}
	}

	void HandleOnDeviceOff (BluetoothDevice dev)
	{
		if (!string.IsNullOrEmpty (dev.Name)) {
			statusText.text = "Status : can't connect to '" + dev.Name + "', device is OFF ";
		} else if (!string.IsNullOrEmpty (dev.MacAddress)) {
			statusText.text = "Status : can't connect to '" + dev.MacAddress + "', device is OFF ";
		}
	}

	void HandleOnDeviceNotFound (BluetoothDevice dev)
	{
		if (!string.IsNullOrEmpty (dev.Name)) {
			statusText.text = "Status : Can't find a device with the name '" + dev.Name + "', device might be OFF or not paird yet ";

		} 
	}
	
	public void disconnect ()
	{
		if (device != null)
			device.close ();
	}
	
	//############### Recibe Datos  #####################
	IEnumerator  ManageConnection (BluetoothDevice device)
	{
		statusText.text = "Status : Connected & Can read";
		while (device.IsReading) {

			byte [] msg = device.read ();
			if (msg != null) {				
				string content = System.Text.ASCIIEncoding.ASCII.GetString (msg);
                string[] lines = content.Split(new char[] { '\n', '\r' });
                BTMessage.text = lines[0] + "-";
            }
			yield return null;
		}

		statusText.text = "Status : Done Reading";
	}
	
	void OnDestroy ()
	{
		BluetoothAdapter.OnDeviceOFF -= HandleOnDeviceOff;
		BluetoothAdapter.OnDeviceNotFound -= HandleOnDeviceNotFound;
		
	}


    public void enviarMen(string envi)
    {
        BTMessage.text = envi + " -";
        if (device != null && !string.IsNullOrEmpty(envi))
        {
            device.send(System.Text.Encoding.ASCII.GetBytes(envi + (char)10));//10 is our seperator Byte (sepration between packets)
        }

    }


}
