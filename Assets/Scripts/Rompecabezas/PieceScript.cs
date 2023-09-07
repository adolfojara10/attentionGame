using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PieceScript : MonoBehaviour
{

    public Vector3 rigthPosition, newPosition;
    public bool inRigthPosition, selected;
    public bool piecesMoved = false;

    // Start is called before the first frame update
    private void Awake()
    {
        rigthPosition = transform.position;
        //Debug.Log(rigthPosition + "*****************" + transform.position);
    }

    void Start()
    {
        //inRigthPosition = true;


        //transform.position = new Vector3(Random.Range(205f, 395f), Random.Range(1f, 181f), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(rigthPosition, this.gameObject.transform.position) <3f && !selected && !inRigthPosition && Puzzle.Instance.allPiecesMoved)
        {

            transform.position = rigthPosition;
            inRigthPosition = true;
            GetComponent<SortingGroup>().sortingOrder = 0;
            Puzzle.Instance.CheckPiecesPosition();
            //Debug.Log(rigthPosition + "----------------" + transform.position + "-----------------" + newPosition + this.gameObject.name);
        }
        
    }

    public void MovePositionPiecesRandom(bool move)
    {
        if (move)
        {

            //rigthPosition = transform.position;
            this.gameObject.transform.position = new Vector3(Random.Range(320f, 400f), Random.Range(100f, 175f), 0);
            //Debug.Log(rigthPosition + "----------------" + transform.position + this.gameObject.name);
            newPosition = this.gameObject.transform.position;
            inRigthPosition = false;
        }

    }
}
