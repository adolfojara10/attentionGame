using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{

    public List<PieceScript> pieces;

    [SerializeField]
    List<PieceScript> movedPieces = new List<PieceScript>();

    public int piecesToMove;

    public bool allPiecesMoved = false;
    public bool allPiecesInRigthPlace = false;

    public static Puzzle Instance;

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
        GameManager.Instance.OnGameStateUpdated.AddListener(GameStateUpdated);
        MovePieces();
    }

    // Update is called once per frame
    void Update()
    {
        allPiecesInRigthPlace = CheckPiecesPosition();
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameStateUpdated.RemoveListener(GameStateUpdated);
    }

    public void GameStateUpdated(GameManager.GameState state)
    {
        if (state == GameManager.GameState.GameOver)
        {
            movedPieces.Clear();
            allPiecesMoved = false;
            allPiecesInRigthPlace = false;
            //StartCoroutine(DisplayPointsCoroutine());
        }

        if (state == GameManager.GameState.GameCompleted)
        {
            movedPieces.Clear();
            allPiecesMoved = false;
            allPiecesInRigthPlace = false;
            //StartCoroutine(DisplayPointsCoroutine());
        }

        if (state == GameManager.GameState.InGame)
        {
            movedPieces.Clear();
            allPiecesMoved = false;
            allPiecesInRigthPlace = false;
            //PuzzleSelection.Instance.SetPuzzlePhoto(1);
            MovePieces();
            
        }
    }



    public void MovePieces()
    {
        int i = 0;
        while (i < piecesToMove)
        {
            var piece = pieces[Random.Range(0, pieces.Count)];
            if (!movedPieces.Contains(piece))
            {
                //piece.rigthPosition = piece.transform.position;
                piece.MovePositionPiecesRandom(true);
                //piece.inRigthPosition = false;
                i++;
                movedPieces.Add(piece);
            }

        }

        foreach (var item in movedPieces)
        {
            item.inRigthPosition = false;
            Debug.Log(item.inRigthPosition);
        }

        allPiecesMoved = true;
    }


    public bool CheckPiecesPosition()
    {
        foreach (var item in movedPieces)
        {
            if (!item.inRigthPosition)
            {
                return false;
            }
        }

        return true;
    }
}
