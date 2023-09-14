using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using TechTweaking.Bluetooth;
using UnityEngine.UI;

using System;

public class BtAra : MonoBehaviour
{   
    public Text BTMessage;
    //public Text devicNameText;

    public Dropdown mac_Dropdown;

    public Text nomtortu;

    public GameObject InfoCanvas;

    public GameObject ActividadesCanvas;

    public GameObject Ojos;

    public GameObject act;
    public GameObject mMen;

    public InputField mensj; 

    public Slider R;
    public Slider G;
    public Slider B;
    public Slider A;
    public Slider Pasos;
    public Text Pas;
    private string macSelected="98:D3:31:F7:36:2E";

////////////
    public GameObject juego;


   public void MacChanged()
    {
       string nomSelect = mac_Dropdown.options[mac_Dropdown.value].text;
       string[] macSelect =new string[6] {"98:D3:31:F5:75:D2","98:D3:32:F5:BB:40","98:D3:31:F7:36:2E","45:48:DB:33:46:41","55:11:4D:BE:E6:FF","57:29:3F:23:78:94"};
       macSelected=macSelect[mac_Dropdown.value];
       //Debug.Log(nomSelect);
       //Debug.Log(macSelected);
       nomtortu.text=nomSelect;

    }

    public void GameTor(){
        juego.SetActive(true);

    }

    public void GameTorSal(){
        juego.SetActive(false);

    }
/////////////////



    private  BluetoothDevice device;
	public Text statusText;

    public void enviarC(){
        float Red=R.value;
        float Green=G.value;
        float Blue=B.value;
        float Az=A.value;
        string O ="i "+Az+" "+Red+" "+Green+" "+Blue;

        enviarCol(O);

    }

        public void enviarMen(){
        string men = mensj.text;
        string O ="txt "+men;

        enviarCol(O);

    }

    public void salir()
    {
        Application.Quit();

    }

    bool conect = false;

    public void AOjos(){
        Ojos.SetActive(true);
        act.SetActive(false);
        mMen.SetActive(false);
    }
    public void COjos(){ Ojos.SetActive(false);  }
    public void aACti(){ 
        act.SetActive(true);
        Ojos.SetActive(false);
        mMen.SetActive(false);
          }
    public void cActi(){ act.SetActive(false); }
    public void aMen(){  
        mMen.SetActive(true); 
        Ojos.SetActive(false);
        act.SetActive(false);
        }
    public void cMen(){  mMen.SetActive(false); }


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
    }
	

    private void connect ()
	{
		statusText.text = "Estado : Tratando de conectar";
        //device.MacAddress = "98:D3:32:F5:BD:25";
        //device.MacAddress = "98:D3:31:F5:75:D2";
        //device.MacAddress = "98:D3:32:F5:BB:40";
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

    public void ValueChangeCheck()
	{
		Pas.text= Pasos.value+" ";
	}

    public void enviarActi(string envi)
    {

        float P=Pasos.value;
        string ms=envi+" "+P;
        BTMessage.text = ms + " -";
        if (device != null && !string.IsNullOrEmpty(ms))
        {
            device.send(System.Text.Encoding.ASCII.GetBytes(ms + (char)10));//10 is our seperator Byte (sepration between packets)
        }

    }
    public void enviarCol(string envi)
    {
        BTMessage.text = envi + " -";
        if (device != null && !string.IsNullOrEmpty(envi))
        {
            device.send(System.Text.Encoding.ASCII.GetBytes(envi + (char)10));//10 is our seperator Byte (sepration between packets)
        }

    }

        public void enviarSim(string envi)
    {
        if (device != null && !string.IsNullOrEmpty(envi))
        {
            device.send(System.Text.Encoding.ASCII.GetBytes(envi + (char)10));//10 is our seperator Byte (sepration between packets)
        }

    }


}
