using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataBank;
using System;


public class BDManager : MonoBehaviour
{
    public static BDManager Instance;

    private NivelAtencionJuegosEntity nivelAtencionJuegos;

    string game = "";
    string result = "";
    public string tiempo = "-";
    public string botonesEncontrados = "-";
    public string intentos = "-";

    public void RestartVars()
    {
        tiempo = "-";
        botonesEncontrados = "-";
        intentos = "-";
    }

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

        GameManager.Instance.OnGameStateUpdated.AddListener(GameStateUpdated);

    }

    public void CreateStudent(string cedula, string nivelBasica, string gender, string born)
    {
        string id = (GameManager.Instance.estudianteDB.GetRowCount() + 1).ToString();
        EstudianteEntity estudiante = new EstudianteEntity(id, cedula, nivelBasica, gender, born);
        GameManager.Instance.estudianteDB.addData(estudiante);

        string idNivel = (GameManager.Instance.nivelAtencionJuegosDB.GetRowCount() + 1).ToString();

        NivelAtencionJuegosEntity nivelEntity = new NivelAtencionJuegosEntity(idNivel,
            "facil",
            "facil",
            "facil",
            "facil",
            "facil",
            "facil",
            "facil",
            "facil",
            "facil",
            id);

        GameManager.Instance.nivelAtencionJuegosDB.addData(nivelEntity);

        Debug.Log("Usuario creado con id: " + id);

    }

    public void GameStateUpdated(GameManager.GameState newState)
    {

        game = "";
        result = "";

        if (newState == GameManager.GameState.GameCompletedCierreVisual || newState == GameManager.GameState.GameCompletedEsquemaCorporal || newState == GameManager.GameState.GameCompletedDiscriminacionAuditiva)
        {
            Debug.Log("BDDDDDDD");

            result = "Mejora - Juego completado";

            nivelAtencionJuegos = GameManager.Instance.nivelAtencionJuegos;

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionAuditivaLocalizarSonido)
            {

                if (nivelAtencionJuegos._atencionAuditivaLocalizarSonido == "facil")
                {
                    nivelAtencionJuegos._atencionAuditivaLocalizarSonido = "medio";
                }
                else if (nivelAtencionJuegos._atencionAuditivaLocalizarSonido == "medio")
                {
                    nivelAtencionJuegos._atencionAuditivaLocalizarSonido = "dificil";
                }

                game = "Atencion Auditiva - Localizar Sonido";

            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.ConcienciaCorporal)
            {

                if (nivelAtencionJuegos._concienciaCorporal == "facil")
                {
                    nivelAtencionJuegos._concienciaCorporal = "medio";
                }
                else if (nivelAtencionJuegos._concienciaCorporal == "medio")
                {
                    nivelAtencionJuegos._concienciaCorporal = "dificil";
                }

                game = "Conciencia Corporal";

            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionSelectivaLaberinto)
            {

                if (nivelAtencionJuegos._atencionSelectivaLaberinto == "facil")
                {
                    nivelAtencionJuegos._atencionSelectivaLaberinto = "medio";
                }
                else if (nivelAtencionJuegos._atencionSelectivaLaberinto == "medio")
                {
                    nivelAtencionJuegos._atencionSelectivaLaberinto = "dificil";
                }

                game = "Atencion Selectiva - Laberinto";
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.Yoga)
            {
                if (nivelAtencionJuegos._yoga == "facil")
                {
                    nivelAtencionJuegos._yoga = "medio";
                }
                else if (nivelAtencionJuegos._yoga == "medio")
                {
                    nivelAtencionJuegos._yoga = "dificil";
                }

                game = "Yoga";
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionSelectivaObjetosPerdidos)
            {
                if (nivelAtencionJuegos._atencionSelectivaObjetosPerdidos == "facil")
                {
                    nivelAtencionJuegos._atencionSelectivaObjetosPerdidos = "medio";
                }
                else if (nivelAtencionJuegos._atencionSelectivaObjetosPerdidos == "medio")
                {
                    nivelAtencionJuegos._atencionSelectivaObjetosPerdidos = "dificil";
                }

                game = "Atencion Selectiva - Objetos Perdidos";
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionSelectivaPiezasFaltantes)
            {
                if (nivelAtencionJuegos._atencionSelectivaPiezasFaltantes == "facil")
                {
                    nivelAtencionJuegos._atencionSelectivaPiezasFaltantes = "medio";
                }
                else if (nivelAtencionJuegos._atencionSelectivaPiezasFaltantes == "medio")
                {
                    nivelAtencionJuegos._atencionSelectivaPiezasFaltantes = "dificil";
                }

                game = "Atencion Selectiva - Piezas Faltantes";
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionSelectivaSostenida)
            {
                if (nivelAtencionJuegos._atencionSelectivaSostenida == "facil")
                {
                    nivelAtencionJuegos._atencionSelectivaSostenida = "medio";
                }
                else if (nivelAtencionJuegos._atencionSelectivaSostenida == "medio")
                {
                    nivelAtencionJuegos._atencionSelectivaSostenida = "dificil";
                }
                game = "Atencion Selectiva y Sostenida";
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.IntegracionVisual)
            {
                if (nivelAtencionJuegos._integracionVisual == "facil")
                {
                    nivelAtencionJuegos._integracionVisual = "medio";
                }
                else if (nivelAtencionJuegos._integracionVisual == "medio")
                {
                    nivelAtencionJuegos._integracionVisual = "dificil";
                }

                game = "Integracion Visual";
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionAuditivaDiscriminarFigura)
            {
                if (nivelAtencionJuegos._atencionAuditivaDiscriminarFigura == "facil")
                {
                    nivelAtencionJuegos._atencionAuditivaDiscriminarFigura = "medio";
                }
                else if (nivelAtencionJuegos._atencionAuditivaDiscriminarFigura == "medio")
                {
                    nivelAtencionJuegos._atencionAuditivaDiscriminarFigura = "dificil";
                }

                game = "Atencion Auditiva - Discriminar Figura";
            }
            GameManager.Instance.nivelAtencionJuegos = this.nivelAtencionJuegos;
            GameManager.Instance.nivelAtencionJuegosDB.Update(this.nivelAtencionJuegos);

            CreateReport();

        }



        if (newState == GameManager.GameState.GameOverCierreVisual || newState == GameManager.GameState.GameOverDiscriminacionAuditiva || newState == GameManager.GameState.GameOverEsquemaCorporal)
        {
            result = "Juego no completado";

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionAuditivaLocalizarSonido)
            {
                game = "Atencion Auditiva - Localizar Sonido";
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.ConcienciaCorporal)
            {
                game = "Conciencia Corporal";
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionSelectivaLaberinto)
            {
                game = "Atencion Selectiva - Laberinto";
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.Yoga)
            {
                game = "Yoga";
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionSelectivaObjetosPerdidos)
            {
                game = "Atencion Selectiva - Objetos Perdidos";
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionSelectivaPiezasFaltantes)
            {
                game = "Atencion Selectiva - Piezas Faltantes";
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionSelectivaSostenida)
            {
                game = "Atencion Selectiva y Sostenida";
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.IntegracionVisual)
            {
                game = "Integracion Visual";
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionAuditivaDiscriminarFigura)
            {
                game = "Atencion Auditiva - Discriminar Figura";
            }

            CreateReport();
        }


        RestartVars();

    }


    public void CreateReport()
    {

        int rowCount = GameManager.Instance.reporteDB.GetRowCount() + 1;
        string rowCountAsString = rowCount.ToString();

        string formattedDate = DateTime.Now.ToString("dd/MM/yyyy");

        /*Debug.Log($"rowCountAsString: {rowCountAsString}");
        Debug.Log($"game: {game}");
        Debug.Log($"formattedDate: {formattedDate}");
        Debug.Log($"result: {result}");
        Debug.Log($"nivelAtencionJuegos._idEstudiante: {GameManager.Instance.nivelAtencionJuegos._idEstudiante}");
*/
        ReporteEntity rep = new ReporteEntity(rowCountAsString,
            game,
            formattedDate,
            result,
            tiempo,
            botonesEncontrados,
            intentos,
            GameManager.Instance.nivelAtencionJuegos._idEstudiante);


        GameManager.Instance.reporteDB.addData(rep);
    }
}
