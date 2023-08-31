using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public List<AudioClip> atencionAuditivaLocalizarSonidoSounds = new List<AudioClip>();
    public AudioSource SFXSource;

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
        GameManager.Instance.OnGamePlayingUpdated.AddListener(GamePlayingUpdated);
        GameManager.Instance.OnGameStateUpdated.AddListener(GameStateUpdated);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GamePlayingUpdated(GameManager.GamePlaying newGamePlaying)
    {
        if (newGamePlaying == GameManager.GamePlaying.AtencionAuditivaLocalizarSonido)
        {

            if (GameManager.Instance.nivelAtencionJuegos._atencionAuditivaLocalizarSonido == "facil")
            {
                SFXSource.PlayOneShot(atencionAuditivaLocalizarSonidoSounds[0]);
            }

            if (GameManager.Instance.nivelAtencionJuegos._atencionAuditivaLocalizarSonido == "medio")
            {
                SFXSource.PlayOneShot(atencionAuditivaLocalizarSonidoSounds[1]);
            }

            if (GameManager.Instance.nivelAtencionJuegos._atencionAuditivaLocalizarSonido == "dificil")
            {
                SFXSource.PlayOneShot(atencionAuditivaLocalizarSonidoSounds[2]);
            }


        }
    }

    public void GameStateUpdated(GameManager.GameState newState)
    {
        if (newState != GameManager.GameState.InGame)
        {
            if (SFXSource.isPlaying)
            {
                SFXSource.Stop();
            }
        }
    }
}
