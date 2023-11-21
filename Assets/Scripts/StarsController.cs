using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsController : MonoBehaviour
{
    public static StarsController Instance;

    public Image levelImageDiferencias;
    public Image levelImageCompletaImagen;
    public Image levelImageEncuentraObjeto;
    public Image levelImageSonidosAmbientales;
    public Image levelImageInstrucciones;
    public Image levelImageYoga;
    public Image levelImageEsquemaCorporal;

    public List<Texture2D> levelTextures = new List<Texture2D>();

    private Dictionary<string, string> levelTextureMapping = new Dictionary<string, string>
    {
        {"facil", "stars_empty"},
        {"medio", "stars1"},
        {"dificil", "stars2"},
        {"terminado", "stars3"}
    };

    public string currentLevelDiferencias = "medio";
    public string currentLevelCompletaImagen = "facil";
    public string currentLevelEncuentraObjeto = "facil";
    public string currentLevelSonidosAmbientales = "facil";
    public string currentLevelInstrucciones = "facil";
    public string currentLevelYoga = "facil";
    public string currentLevelEsquemaCorporal = "facil";

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {

    }

    public void UpdateAllImages()
    {
        UpdateLevelImageDiferencias();
        UpdateLevelImageCompletaImagen();
        UpdateLevelImageEncuentraObjeto();
        UpdateLevelImageSonidosAmbientales();
        UpdateLevelImageInstrucciones();
        UpdateLevelImageYoga();
        UpdateLevelImageEsquemaCorporal();
    }

    void UpdateLevelImageDiferencias()
    {
        UpdateLevelImage(levelImageDiferencias, currentLevelDiferencias);
    }

    void UpdateLevelImageCompletaImagen()
    {
        UpdateLevelImage(levelImageCompletaImagen, currentLevelCompletaImagen);
    }

    void UpdateLevelImageEncuentraObjeto()
    {
        UpdateLevelImage(levelImageEncuentraObjeto, currentLevelEncuentraObjeto);
    }

    void UpdateLevelImageSonidosAmbientales()
    {
        UpdateLevelImage(levelImageSonidosAmbientales, currentLevelSonidosAmbientales);
    }

    void UpdateLevelImageInstrucciones()
    {
        UpdateLevelImage(levelImageInstrucciones, currentLevelInstrucciones);
    }

    void UpdateLevelImageYoga()
    {
        UpdateLevelImage(levelImageYoga, currentLevelYoga);
    }

    void UpdateLevelImageEsquemaCorporal()
    {
        UpdateLevelImage(levelImageEsquemaCorporal, currentLevelEsquemaCorporal);
    }

    void UpdateLevelImage(Image levelImage, string currentLevel)
    {
        if (levelTextureMapping.ContainsKey(currentLevel))
        {
            string textureName = levelTextureMapping[currentLevel];
            Texture2D texture = levelTextures.Find(tex => tex.name == textureName);

            if (texture != null)
            {
                levelImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                //Debug.Log("imageneeeeeeeeeeeeeeeeeeeeeee" + "     " + textureName + "      " + texture.name + "     " + currentLevelDiferencias);
            }
            else
            {
                Debug.LogWarning("Texture not found for level: " + currentLevel);
            }
        }
        else
        {
            Debug.LogWarning("Invalid level: " + currentLevel);
        }
    }

    // Call this method whenever you want to update the level
    public void SetCurrentLevelDiferencias(string newLevel)
    {
        currentLevelDiferencias = newLevel.ToLower();
        UpdateLevelImageDiferencias();
    }

    // Add similar SetCurrentLevel methods for other aspects
}
