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

    private void Update() {
        if(Puzzle.Instance.allPiecesInRigthPlace){
            gameState = GameState.GameCompleted;
            OnGameStateUpdated?.Invoke(gameState);
        }
    }

    public void StartGame()
    {

        gameState = GameState.InGame;
        OnGameStateUpdated?.Invoke(gameState);

    }

    public void RestartGame()
    {

        gameState = GameState.InGame;
        OnGameStateUpdated?.Invoke(gameState);

    }

    public void ExitGame()
    {

        gameState = GameState.Idle;
        OnGameStateUpdated?.Invoke(gameState);

    }

}
