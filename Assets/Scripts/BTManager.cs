using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using TechTweaking.Bluetooth;
using UnityEngine.UI;

using System;

public class BTManager : MonoBehaviour
{
    public static BTManager Instance;

    public Text BTMessage;
    //public GameObject InfoCanvas;
    //public GameObject ActividadesCanvas;
    //private string macSelected = "F8:34:41:39:41:F7";
    private string macSelected = "00:22:03:01:8A:12";
    // volante
    //public Text valVolante;
    //public Text valAcelerador;
    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";
    private float inputHorizontal;
    private float inputVertical;

    private BluetoothDevice device;
    public Text statusText;

    public string cedulaNewStudent;
    public string nivelBasicaNewStudent;
    public string genderNewStudent;
    public string bornNewStudent;

    private void Awake()
    {
        Instance = this;
    }


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

    void Start()
    {
        //GameManager.Instance.OnGamePlayingUpdated.AddListener(GamePlayingUpdated);
        GameManager.Instance.OnGameStateUpdated.AddListener(GameStateUpdated);

        BluetoothAdapter.OnDeviceOFF += HandleOnDeviceOff;//This would mean a failure in connection! the reason might be that your remote device is OFF

        BluetoothAdapter.OnDeviceNotFound += HandleOnDeviceNotFound; //Because connecting using the 'Name' property is just searching, the Plugin might not find it!(only for 'Name').
        //Screen.sleepTimeout = SleepTimeout.NeverSleep;
        conectarBT();
        //enviarMen("x");
    }

    void Update()
    {
        /*
                if (device.IsConnected && !conect)
                {

                    //ActividadesCanvas.SetActive(true);
                    //InfoCanvas.SetActive(false);
                    conect = true;

                    if (device != null && !string.IsNullOrEmpty("x"))
                    {
                        device.send(System.Text.Encoding.ASCII.GetBytes("x" + (char)10));//10 is our seperator Byte (sepration between packets)
                    }
                }

                if (conect)
                {
                    inputHorizontal = SimpleInput.GetAxis(horizontalAxis);
                    inputVertical = SimpleInput.GetAxis(verticalAxis);
                    //valVolante.text= inputHorizontal*100+"";
                    //valAcelerador.text=inputVertical*10+"";
                    string envi = "G:" + (int)inputHorizontal + "-V:" + (int)inputVertical;
                    enviarMen(envi);

                }*/
    }

    public void GameStateUpdated(GameManager.GameState newState)
    {
        //Debug.Log(" estad audio " + newState);
        if (newState == GameManager.GameState.ChargingUser)
        {
            Debug.Log("leyendo estudiante");
            enviarMen("leer_persona");


        }
    }


    private void connect()
    {
        statusText.text = "Estado : Tratando de conectar";
        device.MacAddress = macSelected;
        device.ReadingCoroutine = ManageConnection;
        statusText.text = "----------";
        device.connect();
        //statusText.text = "aaaaaaaaaaaaa";

        //StartManageConnection();

    }

    void HandleOnBluetoothStateChanged(bool isBtEnabled)
    {
        if (isBtEnabled)
        {
            connect();
            //We now don't need our recievers
            BluetoothAdapter.OnBluetoothStateChanged -= HandleOnBluetoothStateChanged;
            BluetoothAdapter.stopListenToBluetoothState();
        }
    }

    void HandleOnDeviceOff(BluetoothDevice dev)
    {
        if (!string.IsNullOrEmpty(dev.Name))
        {
            statusText.text = "Status : can't connect to '" + dev.Name + "', device is OFF ";
        }
        else if (!string.IsNullOrEmpty(dev.MacAddress))
        {
            statusText.text = "Status : can't connect to '" + dev.MacAddress + "', device is OFF ";
        }
    }

    void HandleOnDeviceNotFound(BluetoothDevice dev)
    {
        if (!string.IsNullOrEmpty(dev.Name))
        {
            statusText.text = "Status : Can't find a device with the name '" + dev.Name + "', device might be OFF or not paird yet ";

        }
    }

    public void disconnect()
    {
        if (device != null)
        {
            device.close();

        }
    }
    public void StartManageConnection()
    {
        StartCoroutine(ManageConnection(device));
    }

    //############### Recibe Datos  #####################
    IEnumerator ManageConnection(BluetoothDevice device)
    {
        statusText.text = "Encendiendo Robot";

        while (device.IsReading)
        {

            byte[] msg = device.read();
            if (msg != null)
            {
                string content = System.Text.ASCIIEncoding.ASCII.GetString(msg);
                string[] lines = content.Split(new char[] { '\n', '\r' });
                BTMessage.text = lines[0] + "-";

                if (GameManager.Instance.gameState == GameManager.GameState.Idle)
                {
                    statusText.text = content;
                }

                if (GameManager.Instance.gameState == GameManager.GameState.ChargingUser)
                {
                    if (lines[0] != "-1")
                    {
                        GameManager.Instance.ReadStudentById(lines[0]);
                    }
                    else if (lines[0] == "-1" || lines[0].Contains("-1"))
                    {
                        //Reproducir sonido para que explique que el usuario no existe
                        //mostrar mensaje de error en la pantalla UICHARGING y poner boton de para volver al menuu
                        Debug.Log("todo bien");
                        GameManager.Instance.Error();
                        Debug.Log("bien 2");

                        UIError.Instance.ChangeText("Error: el estudiante no ha sido encontrado. Por favor inténtelo de nuevo.\nSi el error persiste, crear un nuevo usuario.");
                        UIError.Instance.SetActiveImage(0);
                        Debug.Log("bien 3");

                    }
                }

                if (GameManager.Instance.gameState == GameManager.GameState.SavingUser)
                {
                    if (lines[0] != "-1")
                    {
                        BDManager.Instance.CreateStudent(cedulaNewStudent, nivelBasicaNewStudent, genderNewStudent, bornNewStudent);

                        GameManager.Instance.Error();
                        UIError.Instance.ChangeText("Estudiante creado con éxito.");
                        UIError.Instance.SetActiveImage(1);
                    }
                    else if (lines[0] == "-1" || lines[0].Contains("-1"))
                    {
                        //Reproducir sonido para que explique que el usuario YA existe
                        //volver al menuu


                        GameManager.Instance.Error();

                        UIError.Instance.ChangeText("Error: el estudiante ya existe. Inténtelo de nuevo o regrese al menú y presione el botón Empezar.");
                        UIError.Instance.SetActiveImage(0);

                        cedulaNewStudent = nivelBasicaNewStudent = bornNewStudent = genderNewStudent = "";




                    }
                }

                if (GameManager.Instance.gameState == GameManager.GameState.InGame)
                {
                    if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.ConscienciaCorporal)
                    {
                        string[] parts = lines[0].Split("_");

                        if (parts[0] == "1")
                        {
                            BDManager.Instance.tiempo = parts[1];

                            GameManager.Instance.CompletedGameEsquemaCorporal();
                        }
                        else
                        {
                            GameManager.Instance.GameOverEsquemaCorporal();
                        }
                    }

                    if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionSelectivaObjetosPerdidos)
                    {
                        string[] parts = lines[0].Split("_");

                        if (parts[0] == "1")
                        {
                            BDManager.Instance.tiempo = parts[1];

                            GameManager.Instance.CompletedGameDiscriminacionAuditiva();
                        }
                        else
                        {
                            BDManager.Instance.tiempo = parts[1];

                            GameManager.Instance.GameOverDiscriminacionAuditiva();
                        }
                    }
                }
            }

            yield return null;

        }
        //statusText.text = "Status : Done Reading";
    }



    void OnDestroy()
    {
        BluetoothAdapter.OnDeviceOFF -= HandleOnDeviceOff;
        BluetoothAdapter.OnDeviceNotFound -= HandleOnDeviceNotFound;

    }


    public void enviarMen(string envi)
    {
        //BTMessage.text = envi + " -";
        BTMessage.text = envi;
        if (device != null && !string.IsNullOrEmpty(envi))
        {
            device.send(System.Text.Encoding.ASCII.GetBytes(envi + (char)10));//10 is our seperator Byte (sepration between packets)
        }

    }


}

