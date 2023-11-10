using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Juego.UIIntegracionVisual;
using System.IO;
using UnityEngine.Events;
using DataBank;
using System.Data;

public class GameManager : MonoBehaviour
{

    //public List<Image> imagesIntegracionVisual = new List<Image>();
    private readonly object databaseLock = new object();
    public static GameManager Instance;

    public EstudianteEntity estudiante;
    public NivelAtencionJuegosEntity nivelAtencionJuegos;


    public EstudianteDB estudianteDB;
    public NivelAtencionJuegosDB nivelAtencionJuegosDB;

    public ReporteDB reporteDB;

    public SqliteHelper conexionSQL;

    public int numberOfComment;


    public enum GameState
    {
        Idle,
        ChooseGame,
        CreateUser,
        InGame,
        GameCompletedCierreVisual,
        GameOverCierreVisual,
        ChargingUser,
        SavingUser,
        Error,
        ChooseGameCierreVisual,
        ChooseGameEsquemaCorporal,
        ChooseGameDiscriminacionAuditiva,
        GameCompletedEsquemaCorporal,
        GameCompletedDiscriminacionAuditiva,
        GameOverEsquemaCorporal,
        GameOverDiscriminacionAuditiva,
        Welcome,
        DemoIntegracionVisual
    }


    public GameState gameState;

    public UnityEvent<GameState> OnGameStateUpdated;
    public UnityEvent<GamePlaying> OnGamePlayingUpdated;

    public enum GamePlaying
    {
        None,
        AtencionAuditivaLocalizarSonido,
        ConcienciaCorporal,
        AtencionSelectivaLaberinto,
        Yoga,
        AtencionSelectivaObjetosPerdidos,
        AtencionSelectivaPiezasFaltantes,
        AtencionSelectivaSostenida,
        IntegracionVisual,
        AtencionAuditivaDiscriminarFigura,
        Rompecabezas
    }


    public GamePlaying gamePlaying;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //PuzzleSelection puzzleSelectionInstance = PuzzleSelection.Instance;
        //puzzleSelectionInstance.SetPuzzlePhoto(1);

        //Debug.Log("manager");
        lock (databaseLock)
        {
            //estudianteDB = new EstudianteDB();
            //nivelAtencionJuegosDB = new NivelAtencionJuegosDB();
            //reporteDB = new ReporteDB();

            conexionSQL = new SqliteHelper();

            conexionSQL.createEstudiantesTable();
            conexionSQL.createNivelAtencionTable();
            conexionSQL.createReporteTable();


            /*conexionSQL.deleteAllData("NivelAtencionJuegos");
            conexionSQL.deleteAllData("Reportes");
            conexionSQL.deleteAllData("Estudiantes");*/

            //estudianteDB.deleteAllData();
            //nivelAtencionJuegosDB.deleteAllData();
            //reporteDB.deleteAllData();

            //conexionSQL.ResetFacilValuesNivelJuegos();

            //nivelAtencionJuegosDB.ResetValues();


            IDataReader dataReader = conexionSQL.getDataByIdString("Estudiantes", "1");
            /*IDataReader dataReader = conexionSQL.getAllData("Estudiantes");
            if (dataReader.Read())
            {
                // Iterate through the rows
                while (dataReader.Read())
                {
                    // Iterate through the columns
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        // Print the column name and value
                        string columnName = dataReader.GetName(i);
                        object columnValue = dataReader[i];

                        // You can adjust the formatting as needed
                        Debug.Log($"{columnName}: {columnValue}");
                    }

                    // Add a separator between rows
                    Debug.Log("--------------------------------------------------");
                }

            }
            else
            {
                Debug.LogWarning("No data found for the specified ID.");
                dataReader.Close(); // Close the reader when no data is found
                
            }*/


            if (dataReader == null)
            {
                Debug.Log("----------creando usuarioooooo-----------");
                string dateString = "2023-08-21";

                //estudianteDB.addData(new EstudianteEntity("1", "Invitado", "Invitado", "invitado", dateString));
                estudiante = new EstudianteEntity("1", "Invitado", "Invitado", "invitado", dateString);
                conexionSQL.addDataEstudiante(estudiante);

                NivelAtencionJuegosEntity nivelAtencionJuegos = new NivelAtencionJuegosEntity("1",
                "facil",
                "facil",
                "facil",
                "facil",
                "facil",
                "facil",
                "facil",
                "facil",
                "facil",
                "1");

                conexionSQL.addDataNivelAtencionJuegos(nivelAtencionJuegos);
            }
            else
            {
                Debug.Log("Uusuario encontrado");
                conexionSQL.ResetFacilValuesNivelJuegos();
                nivelAtencionJuegos = conexionSQL.getDataByIdEstudiante("1");
                estudiante = new EstudianteEntity(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4));

                Debug.Log(estudiante);
            }

        }
        /*dataReader = estudianteDB.getAllData();

        int fieldCount2 = dataReader.FieldCount;
        List<EstudianteEntity> myList2 = new List<EstudianteEntity>();
        while (dataReader.Read())
        {
            //string dateTimeString = reader[3];
            //Debug.Log("------------------" + reader[3]);

            EstudianteEntity entity = new EstudianteEntity(dataReader[0].ToString(),
                                    dataReader[1].ToString(),
                                    dataReader[2].ToString(),
                                    dataReader[3].ToString());

            Debug.Log("id: " + entity._id + " nombre: " + entity._name + " born: " + entity._born);
            myList2.Add(entity);
        }*/


        //nivelAtencionJuegosDB.Update();

        //Debug.Log("nivel " + nivelAtencionJuegos._idEstudiante);


        //Debug.Log("estudiante   " + estudiante._name);

    }

    private void Update()
    {
        /*if (Puzzle.Instance.allPiecesInRigthPlace)
        {
            gameState = GameState.GameCompleted;
            OnGameStateUpdated?.Invoke(gameState);
        }*/
    }

    public void AssignNumberOfComment()
    {
        // Generate a random integer between 1 and 100 (inclusive).
        numberOfComment = Random.Range(1, 101);
    }


    public void ReadStudentById(string IDRead)
    {
        Debug.Log("1");
        IDataReader dataReader = conexionSQL.getDataByIdString("Estudiantes", IDRead);
        estudiante = new EstudianteEntity(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4));
        Debug.Log("4" + estudiante);

        Debug.Log("2");
        dataReader = conexionSQL.getDataByIdString("NivelAtencionJuegos", IDRead);
        nivelAtencionJuegos = new NivelAtencionJuegosEntity(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4), dataReader.GetString(5), dataReader.GetString(6), dataReader.GetString(7), dataReader.GetString(8), dataReader.GetString(9), dataReader.GetString(10));
        Debug.Log("3" + nivelAtencionJuegos);


        this.Welcome();
    }

    public void Welcome()
    {

        gameState = GameState.Welcome;

        OnGameStateUpdated?.Invoke(gameState);
        Debug.Log("welcomeeeeeeeeee");
        TimerWelcome.Instance.StartTimer();
    }


    public void StartGame()
    {

        gameState = GameState.InGame;
        //Debug.Log("INGAME");
        OnGameStateUpdated?.Invoke(gameState);

    }

    public void RestartGame()
    {

        gameState = GameState.InGame;

        OnGamePlayingUpdated?.Invoke(this.gamePlaying);
        OnGameStateUpdated?.Invoke(gameState);

    }

    public void CompletedGameCierreVisual()
    {
        AssignNumberOfComment();
        string message = "good_" + numberOfComment.ToString();
        BTManager.Instance.enviarMen(message);
        gameState = GameState.GameCompletedCierreVisual;
        OnGamePlayingUpdated?.Invoke(this.gamePlaying);
        OnGameStateUpdated?.Invoke(gameState);


    }

    public void CompletedGameEsquemaCorporal()
    {
        AssignNumberOfComment();
        string message = "good_" + numberOfComment.ToString();
        BTManager.Instance.enviarMen(message);
        gameState = GameState.GameCompletedEsquemaCorporal;
        OnGamePlayingUpdated?.Invoke(this.gamePlaying);
        OnGameStateUpdated?.Invoke(gameState);


    }

    public void CompletedGameDiscriminacionAuditiva()
    {
        AssignNumberOfComment();
        string message = "good_" + numberOfComment.ToString();
        BTManager.Instance.enviarMen(message);
        gameState = GameState.GameCompletedDiscriminacionAuditiva;
        OnGamePlayingUpdated?.Invoke(this.gamePlaying);
        OnGameStateUpdated?.Invoke(gameState);


    }

    public void GameOverCierreVisual()
    {
        AssignNumberOfComment();
        string message = "bad_" + numberOfComment.ToString();
        BTManager.Instance.enviarMen(message);
        gameState = GameState.GameOverCierreVisual;
        OnGamePlayingUpdated?.Invoke(this.gamePlaying);
        OnGameStateUpdated?.Invoke(gameState);

        AudioManager.Instance.SFXSource.Stop();


    }

    public void GameOverDiscriminacionAuditiva()
    {
        AssignNumberOfComment();
        string message = "bad_" + numberOfComment.ToString();
        BTManager.Instance.enviarMen(message);
        gameState = GameState.GameOverDiscriminacionAuditiva;
        OnGamePlayingUpdated?.Invoke(this.gamePlaying);
        OnGameStateUpdated?.Invoke(gameState);

        AudioManager.Instance.SFXSource.Stop();


    }

    public void GameOverEsquemaCorporal()
    {
        AssignNumberOfComment();
        string message = "bad_" + numberOfComment.ToString();
        BTManager.Instance.enviarMen(message);
        gameState = GameState.GameOverEsquemaCorporal;
        OnGamePlayingUpdated?.Invoke(this.gamePlaying);
        OnGameStateUpdated?.Invoke(gameState);

        AudioManager.Instance.SFXSource.Stop();


    }

    public void ExitGame()
    {

        gameState = GameState.Idle;
        gamePlaying = GamePlaying.None;
        OnGameStateUpdated?.Invoke(gameState);

    }

    public void ChooseGame()
    {
        gameState = GameState.ChooseGame;
        gamePlaying = GamePlaying.None;
        OnGameStateUpdated?.Invoke(gameState);
    }

    public void ChooseGameCierreVisual()
    {
        gameState = GameState.ChooseGameCierreVisual;
        gamePlaying = GamePlaying.None;
        OnGameStateUpdated?.Invoke(gameState);
    }

    public void ChooseGameEsquemaCorporal()
    {
        gameState = GameState.ChooseGameEsquemaCorporal;
        gamePlaying = GamePlaying.None;
        OnGameStateUpdated?.Invoke(gameState);
    }

    public void ChooseGameDiscriminacionAuditiva()
    {
        gameState = GameState.ChooseGameDiscriminacionAuditiva;
        gamePlaying = GamePlaying.None;
        OnGameStateUpdated?.Invoke(gameState);
        //Debug.Log("iiiiii");
    }

    public void CreateUser()
    {
        gameState = GameState.CreateUser;
        gamePlaying = GamePlaying.None;
        OnGameStateUpdated?.Invoke(gameState);
    }

    public void MainMenu()
    {
        //nivelAtencionJuegosDB.ResetValues();
        nivelAtencionJuegos = null;
        gameState = GameState.Idle;
        gamePlaying = GamePlaying.None;
        BTManager.Instance.enviarMen("cancelar");
        OnGameStateUpdated?.Invoke(gameState);
    }

    public void Charging()
    {
        gameState = GameState.ChargingUser;
        gamePlaying = GamePlaying.None;
        OnGameStateUpdated?.Invoke(gameState);
    }

    public void Saving()
    {
        gameState = GameState.SavingUser;
        gamePlaying = GamePlaying.None;
        OnGameStateUpdated?.Invoke(gameState);
    }

    public void Error()
    {
        gameState = GameState.Error;
        gamePlaying = GamePlaying.None;
        OnGameStateUpdated?.Invoke(gameState);
    }

    public void ConnectBluetooth()
    {
        BTManager.Instance.conectarBT();
    }

    public void InvitedSession()
    {
        // Antes de realizar operaciones en la base de datos, adquiere el bloqueo
        lock (databaseLock)
        {
            // Realiza operaciones en la base de datos aquí
            IDataReader dataReader = conexionSQL.getDataByIdString("Estudiantes", "1");
            Debug.Log("Usuario encontrado");
            //nivelAtencionJuegosDB.ResetValues();
            nivelAtencionJuegos = conexionSQL.getDataByIdEstudiante("1");
            estudiante = new EstudianteEntity(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3), dataReader.GetString(4));

            Debug.Log(estudiante);

            this.Welcome();
        }

        // Asegúrate de liberar el bloqueo cuando hayas terminado


    }

    public void StartDemoIntegracionVisual()
    {
        gameState = GameState.DemoIntegracionVisual;
        gamePlaying = GamePlaying.None;
        OnGameStateUpdated?.Invoke(gameState);
        BTManager.Instance.enviarMen("completa_imagen");
    }

    public void AtencionAuditivaLocalizarSonidoGame()
    {
        //Debug.Log("--------------------- game manager");
        gameState = GameState.InGame;
        gamePlaying = GamePlaying.AtencionAuditivaLocalizarSonido;
        OnGamePlayingUpdated?.Invoke(gamePlaying);
        OnGameStateUpdated?.Invoke(gameState);
        BTManager.Instance.enviarMen("atencion_auditiva");
    }

    public void ConcienciaCorporalGame()
    {
        //Debug.Log("--------------------- game manager");
        gameState = GameState.InGame;
        gamePlaying = GamePlaying.ConcienciaCorporal;
        OnGamePlayingUpdated?.Invoke(gamePlaying);
        OnGameStateUpdated?.Invoke(gameState);
        BTManager.Instance.enviarMen("conciencia_corporal_" + this.nivelAtencionJuegos._concienciaCorporal);
    }

    public void YogaGame()
    {
        //Debug.Log("--------------------- game manager");
        gameState = GameState.InGame;
        gamePlaying = GamePlaying.Yoga;
        OnGamePlayingUpdated?.Invoke(gamePlaying);
        OnGameStateUpdated?.Invoke(gameState);
        BTManager.Instance.enviarMen("yoga_" + this.nivelAtencionJuegos._yoga);
    }

    public void ObjetosPerdidosGame()
    {
        //Debug.Log("--------------------- game manager");
        gameState = GameState.InGame;
        gamePlaying = GamePlaying.AtencionSelectivaObjetosPerdidos;
        OnGamePlayingUpdated?.Invoke(gamePlaying);
        OnGameStateUpdated?.Invoke(gameState);
        string messageSend = "simon_dice_" + this.nivelAtencionJuegos._atencionSelectivaObjetosPerdidos;
        Debug.Log(messageSend);
        BTManager.Instance.enviarMen(messageSend);
    }

    public void DiferenciasGame()
    {
        //Debug.Log("--------------------- game manager");
        gameState = GameState.InGame;
        gamePlaying = GamePlaying.AtencionSelectivaPiezasFaltantes;
        OnGamePlayingUpdated?.Invoke(gamePlaying);
        OnGameStateUpdated?.Invoke(gameState);
        BTManager.Instance.enviarMen("encuentra_diferencias");

    }

    public void AtencionSelectivaSostenidaGame()
    {
        //Debug.Log("--------------------- game manager");
        gameState = GameState.InGame;
        gamePlaying = GamePlaying.AtencionSelectivaSostenida;
        OnGamePlayingUpdated?.Invoke(gamePlaying);
        OnGameStateUpdated?.Invoke(gameState);
        BTManager.Instance.enviarMen("encuentra_objeto");
    }

    public void AtencionAuditivaDiscriminarFiguraGame()
    {
        //Debug.Log("--------------------- game manager");
        gameState = GameState.InGame;
        gamePlaying = GamePlaying.AtencionAuditivaDiscriminarFigura;
        OnGamePlayingUpdated?.Invoke(gamePlaying);
        OnGameStateUpdated?.Invoke(gameState);
        BTManager.Instance.enviarMen("sonidos_naturaleza");
    }


    public void RompecabezasGame()
    {
        gameState = GameState.InGame;

        gamePlaying = GamePlaying.Rompecabezas;
        OnGamePlayingUpdated?.Invoke(gamePlaying);
        OnGameStateUpdated?.Invoke(gameState);
    }

    public void IntegracionVisualGame()
    {
        gameState = GameState.InGame;

        gamePlaying = GamePlaying.IntegracionVisual;
        OnGamePlayingUpdated?.Invoke(gamePlaying);
        OnGameStateUpdated?.Invoke(gameState);
    }

}
