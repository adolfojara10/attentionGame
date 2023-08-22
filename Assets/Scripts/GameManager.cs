using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Juego.UIIntegracionVisual;
using System.IO;

public class GameManager : MonoBehaviour
{

    //public List<Image> imagesIntegracionVisual = new List<Image>();

    public static GameManager Instance;

    public enum GameState
    {
        Idle,
        ChooseGame,
        InGame,
        GameOver
    }


    public GameState gameState;

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

}
