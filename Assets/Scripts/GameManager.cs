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

    public static GameManager Instance;

    public EstudianteEntity estudiante;
    public NivelAtencionJuegosEntity nivelAtencionJuegos;


    private EstudianteDB estudianteDB;
    private NivelAtencionJuegosDB nivelAtencionJuegosDB;


    public enum GameState
    {
        Idle,
        ChooseGame,
        InGame,
        GameCompleted,
        GameOver
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
        AtencionAuditivaDiscriminarFigura
    }


    public GamePlaying gamePlaying;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //PuzzleSelection puzzleSelectionInstance = PuzzleSelection.Instance;
        //puzzleSelectionInstance.SetPuzzlePhoto(1);

        //Debug.Log("manager");

        estudianteDB = new EstudianteDB();
        nivelAtencionJuegosDB = new NivelAtencionJuegosDB();

        IDataReader dataReader = estudianteDB.getDataByIdString("2");
        if (dataReader == null)
        {
            string dateString = "2023-08-21";
            estudianteDB.addData(new EstudianteEntity("2", "Sebastian", "Gavilanes", dateString));
            estudiante = new EstudianteEntity("2", "Sebastian", "Gavilanes", dateString);
            
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
            "2");

            nivelAtencionJuegosDB.addData(nivelAtencionJuegos);
        }
        else
        {
            nivelAtencionJuegos = nivelAtencionJuegosDB.getDataByIdEstudiante("2");
            estudiante = new EstudianteEntity(dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3));
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

    public void CompletedGame()
    {

        gameState = GameState.GameCompleted;
        OnGamePlayingUpdated?.Invoke(this.gamePlaying);
        OnGameStateUpdated?.Invoke(gameState);


    }

    public void GameOver()
    {

        gameState = GameState.GameOver;
        OnGamePlayingUpdated?.Invoke(this.gamePlaying);
        OnGameStateUpdated?.Invoke(gameState);


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

    public void MainMenu()
    {
        gameState = GameState.Idle;
        gamePlaying = GamePlaying.None;
        OnGameStateUpdated?.Invoke(gameState);
    }


    public void AtencionAuditivaLocalizarSonidoGame()
    {
        Debug.Log("--------------------- game manager");
        gameState = GameState.InGame;
        gamePlaying = GamePlaying.AtencionAuditivaLocalizarSonido;
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
