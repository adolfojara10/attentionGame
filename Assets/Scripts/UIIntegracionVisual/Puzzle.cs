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
        MovePieces();
    }

    // Update is called once per frame
    void Update()
    {

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
}
