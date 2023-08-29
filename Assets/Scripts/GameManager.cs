using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Juego.UIIntegracionVisual;
using System.IO;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    //public List<Image> imagesIntegracionVisual = new List<Image>();

    public static GameManager Instance;

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
        PuzzleSelection puzzleSelectionInstance = PuzzleSelection.Instance;
        puzzleSelectionInstance.SetPuzzlePhoto(1);
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
        Debug.Log("INGAME");
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
        gameState = GameState.InGame;
        gamePlaying = GamePlaying.AtencionAuditivaLocalizarSonido;
        OnGamePlayingUpdated?.Invoke(gamePlaying);
    }


    public void IntegracionVisualGame()
    {
        gameState = GameState.InGame;
        
        gamePlaying = GamePlaying.IntegracionVisual;
        OnGamePlayingUpdated?.Invoke(gamePlaying);
        OnGameStateUpdated?.Invoke(gameState);
    }

}
