using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataBank;


public class BDManager : MonoBehaviour
{

    private NivelAtencionJuegosEntity nivelAtencionJuegos;

    // Start is called before the first frame update
    void Start()
    {

        GameManager.Instance.OnGameStateUpdated.AddListener(GameStateUpdated);

    }

    public void GameStateUpdated(GameManager.GameState newState)
    {
        if (newState == GameManager.GameState.GameCompleted)
        {
            Debug.Log("BDDDDDDD");

            nivelAtencionJuegos = GameManager.Instance.nivelAtencionJuegos;

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionAuditivaLocalizarSonido)
            {

                if (nivelAtencionJuegos._atencionAuditivaLocalizarSonido == "facil")
                {
                    nivelAtencionJuegos._atencionAuditivaLocalizarSonido = "medio";
                }


                if (nivelAtencionJuegos._atencionAuditivaLocalizarSonido == "medio")
                {
                    nivelAtencionJuegos._atencionAuditivaLocalizarSonido = "dificil";
                }

            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.ConcienciaCorporal)
            {

                if (nivelAtencionJuegos._concienciaCorporal == "facil")
                {
                    nivelAtencionJuegos._concienciaCorporal = "medio";
                }


                if (nivelAtencionJuegos._concienciaCorporal == "medio")
                {
                    nivelAtencionJuegos._concienciaCorporal = "dificil";
                }
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionSelectivaLaberinto)
            {

                if (nivelAtencionJuegos._atencionSelectivaLaberinto == "facil")
                {
                    nivelAtencionJuegos._atencionSelectivaLaberinto = "medio";
                }


                if (nivelAtencionJuegos._atencionSelectivaLaberinto == "medio")
                {
                    nivelAtencionJuegos._atencionSelectivaLaberinto = "dificil";
                }
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.Yoga)
            {
                if (nivelAtencionJuegos._yoga == "facil")
                {
                    nivelAtencionJuegos._yoga = "medio";
                }


                if (nivelAtencionJuegos._yoga == "medio")
                {
                    nivelAtencionJuegos._yoga = "dificil";
                }
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionSelectivaObjetosPerdidos)
            {
                if (nivelAtencionJuegos._atencionSelectivaObjetosPerdidos == "facil")
                {
                    nivelAtencionJuegos._atencionSelectivaObjetosPerdidos = "medio";
                }


                if (nivelAtencionJuegos._atencionSelectivaObjetosPerdidos == "medio")
                {
                    nivelAtencionJuegos._atencionSelectivaObjetosPerdidos = "dificil";
                }
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionSelectivaPiezasFaltantes)
            {
                if (nivelAtencionJuegos._atencionSelectivaPiezasFaltantes == "facil")
                {
                    nivelAtencionJuegos._atencionSelectivaPiezasFaltantes = "medio";
                }


                if (nivelAtencionJuegos._atencionSelectivaPiezasFaltantes == "medio")
                {
                    nivelAtencionJuegos._atencionSelectivaPiezasFaltantes = "dificil";
                }
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionSelectivaSostenida)
            {
                if (nivelAtencionJuegos._atencionSelectivaSostenida == "facil")
                {
                    nivelAtencionJuegos._atencionSelectivaSostenida = "medio";
                }


                if (nivelAtencionJuegos._atencionSelectivaSostenida == "medio")
                {
                    nivelAtencionJuegos._atencionSelectivaSostenida = "dificil";
                }
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.IntegracionVisual)
            {
                if (nivelAtencionJuegos._integracionVisual == "facil")
                {
                    nivelAtencionJuegos._integracionVisual = "medio";
                }


                if (nivelAtencionJuegos._integracionVisual == "medio")
                {
                    nivelAtencionJuegos._integracionVisual = "dificil";
                }
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionAuditivaDiscriminarFigura)
            {
                if (nivelAtencionJuegos._atencionAuditivaDiscriminarFigura == "facil")
                {
                    nivelAtencionJuegos._atencionAuditivaDiscriminarFigura = "medio";
                }


                if (nivelAtencionJuegos._atencionAuditivaDiscriminarFigura == "medio")
                {
                    nivelAtencionJuegos._atencionAuditivaDiscriminarFigura = "dificil";
                }
            }

            GameManager.Instance.nivelAtencionJuegos = this.nivelAtencionJuegos;
            GameManager.Instance.nivelAtencionJuegosDB.Update(this.nivelAtencionJuegos);

        }
    }
}
