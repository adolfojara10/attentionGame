using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsGameCompletedController : MonoBehaviour
{
    public static StarsGameCompletedController Instance;

    public Image gameCompletedCierreVisual;
    public Image gameCompletedEsquemaCorporal;
    public Image gameCompletedDiscriminacionAuditiva;

    private Dictionary<string, string> levelTextureMapping = new Dictionary<string, string>
    {
        {"facil", "stars_empty"},
        {"medio", "stars1"},
        {"dificil", "stars2"},
        {"terminado", "stars3"}
    };


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
