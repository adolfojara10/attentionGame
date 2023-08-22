using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Juego.UIIntegracionVisual;
using System.IO;

public class ImageLoader : MonoBehaviour {

    public List<Image> imagesIntegracionVisual = new List<Image>();

    // Start is called before the first frame update
    void Start() {
        PuzzleSelection puzzleSelectionInstance = PuzzleSelection.Instance;
        puzzleSelectionInstance.SetPuzzlePhoto(1);
    }

}
