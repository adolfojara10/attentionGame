using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Juego.UIIntegracionVisual
{
    public class PuzzleSelection : MonoBehaviour
    {
        [SerializeField]
        public List<Sprite> images = new List<Sprite>();

        //public Dictionary<int,List<Sprite>> images;// = new Dictionary<int, List<Sprite>>();

        public static PuzzleSelection Instance;

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

        private void Start()
        {

            //ReadImages();
            //Debug.Log("numero de imagenes " + images.Count);
            // SetPuzzlePhoto();
        }



        public void SetPuzzlePhoto(int levelPuzzle)
        {
            //aqui editar con el levelPuzzle
            Sprite randomSprite = images[1];

            for (int i = 0; i < 36; i++)
            {
                GameObject.Find("Piece (" + i + ")").transform.Find("Puzzle").GetComponent<SpriteRenderer>().sprite = randomSprite;

            }
        }


    }

}