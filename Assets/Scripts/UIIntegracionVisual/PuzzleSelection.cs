using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Juego.UIIntegracionVisual
{
    public class PuzzleSelection : MonoBehaviour
    {

        public List<Image> images;

        private List<Button> buttons = new List<Button>();

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
            ReadImages();
            Debug.Log("numero de imagenes " + images.Count);
           // SetPuzzlePhoto();
        }

        private void ReadImages()
        {
            images = new List<Image>();

            Image[] foundImages = transform.GetComponentsInChildren<Image>();

            // Exclude the parent Image itself from the list
            foreach (Image image in foundImages)
            {
                if (image.transform != transform)
                {
                    images.Add(image);
                }
            }


        }


        /*public void SetPuzzlePhoto()
        {
            //GameObject[] Pieces;

            //Image photo = images[1];

            for (int i = 0; i < 36; i++)
            {
                GameObject.Find("Piece (" + i + ")").transform.Find("Puzzle").GetComponent<SpriteRenderer>().sprite = photo.sprite;

            }
        }*/

/*
        public void SetPuzzlePhoto()
        {
            // Load all images from a specific path
            string imagePath = "Path/To/Your/Images"; // Replace with the actual path
            string[] imageFiles = Directory.GetFiles(imagePath, "*.png", SearchOption.AllDirectories)
            .Concat(Directory.GetFiles(imagePath, "*.jpg", SearchOption.AllDirectories))
            .ToArray();

            // Choose one image from the loaded images
            int chosenIndex = Random.Range(0, imageFiles.Length);
            string chosenImagePath = imageFiles[chosenIndex];

            // Load the chosen image as a sprite
            Texture2D chosenTexture = LoadTextureFromFile(chosenImagePath);
            if (chosenTexture != null)
            {
                Sprite chosenSprite = Sprite.Create(chosenTexture, new Rect(0, 0, chosenTexture.width, chosenTexture.height), Vector2.zero);

                // Set the chosen sprite to all puzzle pieces
                for (int i = 0; i < 36; i++)
                {
                    GameObject.Find("Piece (" + i + ")").transform.Find("Puzzle").GetComponent<SpriteRenderer>().sprite = chosenSprite;
                }
            }
        }



        private Texture2D LoadTextureFromFile(string filePath)
        {
            byte[] fileData = File.ReadAllBytes(filePath);
            Texture2D texture = new Texture2D(2, 2);
            if (texture.LoadImage(fileData))
            {
                return texture;
            }
            return null;
        }

*/

    }

}