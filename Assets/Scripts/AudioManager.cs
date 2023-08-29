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

            //hacer dependiendo del nivel
            SFXSource.PlayOneShot(atencionAuditivaLocalizarSonidoSounds[0]);

        }
    }

    public void PlaySound(GameManager.GamePlaying newGamePlaying)
    {
        StartCoroutine(PlaySoundCoroutine(newGamePlaying));
    }


    IEnumerator PlaySoundCoroutine(GameManager.GamePlaying newGamePlaying)
    {
        yield return new WaitForSeconds(0.5f);
        if (newGamePlaying == GameManager.GamePlaying.AtencionAuditivaLocalizarSonido && GameManager.Instance.gameState == GameManager.GameState.InGame)
        {

            //hacer dependiendo del nivel
            SFXSource.PlayOneShot(atencionAuditivaLocalizarSonidoSounds[0]);

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
