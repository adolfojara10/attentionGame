using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PieceScript : MonoBehaviour
{

    private Vector3 rigthPosition;
    public bool inRigthPosition, selected; 


    // Start is called before the first frame update
    void Start()
    {
        inRigthPosition = false;
        rigthPosition = transform.position;
        transform.position = new Vector3(Random.Range(338f, 540f),Random.Range(267f, 50f),0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(rigthPosition,transform.position) < 2f && !selected && !inRigthPosition){


            transform.position = rigthPosition;
            inRigthPosition = true;
            GetComponent<SortingGroup>().sortingOrder = 0;
        }
    }
}
