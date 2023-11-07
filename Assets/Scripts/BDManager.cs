using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataBank;
using System;
using UnityEngine.Events;

public class BDManager : MonoBehaviour
{

    private readonly object databaseLock = new object();
    public static BDManager Instance;

    private NivelAtencionJuegosEntity nivelAtencionJuegos;

    string game = "";
    string result = "";
    public string tiempo = "-";
    public string botonesEncontrados = "-";
    public string intentos = "-";
    public string level = "-";



    public void RestartVars()
    {
        tiempo = "-";
        botonesEncontrados = "-";
        intentos = "-";
        level = "-";
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
        string id = (GameManager.Instance.conexionSQL.GetRowCount("Estudiantes") + 1).ToString();
        EstudianteEntity estudiante = new EstudianteEntity(id, cedula, nivelBasica, gender, born);
        GameManager.Instance.conexionSQL.addDataEstudiante(estudiante);

        string idNivel = (GameManager.Instance.conexionSQL.GetRowCount("NivelAtencionJuegos") + 1).ToString();

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

        GameManager.Instance.conexionSQL.addDataNivelAtencionJuegos(nivelEntity);

        Debug.Log("Usuario creado con id: " + id);

    }

    public void GameStateUpdated(GameManager.GameState newState)
    {

        game = "";
        result = "";
        level = "";

        if (newState == GameManager.GameState.GameCompletedCierreVisual || newState == GameManager.GameState.GameCompletedEsquemaCorporal || newState == GameManager.GameState.GameCompletedDiscriminacionAuditiva)
        {
            Debug.Log("BDDDDDDD");

            result = "Mejora - Juego completado";

            nivelAtencionJuegos = GameManager.Instance.nivelAtencionJuegos;

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionAuditivaLocalizarSonido)
            {

                if (nivelAtencionJuegos._atencionAuditivaLocalizarSonido == "facil")
                {
                    level = "facil";
                    nivelAtencionJuegos._atencionAuditivaLocalizarSonido = "medio";
                }
                else if (nivelAtencionJuegos._atencionAuditivaLocalizarSonido == "medio")
                {
                    level = "medio";
                    nivelAtencionJuegos._atencionAuditivaLocalizarSonido = "dificil";
                }
                else if (nivelAtencionJuegos._atencionAuditivaLocalizarSonido == "dificil")
                {
                    level = "dificil";
                    //nivelAtencionJuegos._atencionAuditivaLocalizarSonido = "dificil";
                }

                game = "Atencion Auditiva - Localizar Sonido";

            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.ConcienciaCorporal)
            {

                if (nivelAtencionJuegos._concienciaCorporal == "facil")
                {
                    level = "facil";
                    nivelAtencionJuegos._concienciaCorporal = "medio";
                }
                else if (nivelAtencionJuegos._concienciaCorporal == "medio")
                {
                    level = "medio";
                    nivelAtencionJuegos._concienciaCorporal = "dificil";
                }
                else if (nivelAtencionJuegos._concienciaCorporal == "dificil")
                {
                    level = "dificil";
                    //nivelAtencionJuegos._atencionAuditivaLocalizarSonido = "dificil";
                }

                game = "Conciencia Corporal";

            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionSelectivaLaberinto)
            {

                if (nivelAtencionJuegos._atencionSelectivaLaberinto == "facil")
                {
                    level = "facil";
                    nivelAtencionJuegos._atencionSelectivaLaberinto = "medio";
                }
                else if (nivelAtencionJuegos._atencionSelectivaLaberinto == "medio")
                {
                    level = "medio";
                    nivelAtencionJuegos._atencionSelectivaLaberinto = "dificil";
                }
                else if (nivelAtencionJuegos._atencionSelectivaLaberinto == "dificil")
                {
                    level = "dificil";
                    //nivelAtencionJuegos._atencionAuditivaLocalizarSonido = "dificil";
                }

                game = "Atencion Selectiva - Laberinto";
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.Yoga)
            {
                if (nivelAtencionJuegos._yoga == "facil")
                {
                    level = "facil";
                    nivelAtencionJuegos._yoga = "medio";
                }
                else if (nivelAtencionJuegos._yoga == "medio")
                {
                    level = "medio";
                    nivelAtencionJuegos._yoga = "dificil";
                }
                else if (nivelAtencionJuegos._yoga == "dificil")
                {
                    level = "dificil";
                    //nivelAtencionJuegos._atencionAuditivaLocalizarSonido = "dificil";
                }

                game = "Yoga";
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionSelectivaObjetosPerdidos)
            {
                if (nivelAtencionJuegos._atencionSelectivaObjetosPerdidos == "facil")
                {
                    level = "facil";
                    nivelAtencionJuegos._atencionSelectivaObjetosPerdidos = "medio";
                }
                else if (nivelAtencionJuegos._atencionSelectivaObjetosPerdidos == "medio")
                {
                    level = "medio";
                    nivelAtencionJuegos._atencionSelectivaObjetosPerdidos = "dificil";
                }
                else if (nivelAtencionJuegos._atencionSelectivaObjetosPerdidos == "dificil")
                {
                    level = "dificil";
                    //nivelAtencionJuegos._atencionAuditivaLocalizarSonido = "dificil";
                }

                game = "Atencion Selectiva - Objetos Perdidos";
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionSelectivaPiezasFaltantes)
            {
                if (nivelAtencionJuegos._atencionSelectivaPiezasFaltantes == "facil")
                {
                    level = "facil";
                    nivelAtencionJuegos._atencionSelectivaPiezasFaltantes = "medio";
                }
                else if (nivelAtencionJuegos._atencionSelectivaPiezasFaltantes == "medio")
                {
                    level = "medio";
                    nivelAtencionJuegos._atencionSelectivaPiezasFaltantes = "dificil";
                }
                else if (nivelAtencionJuegos._atencionSelectivaPiezasFaltantes == "dificil")
                {
                    level = "dificil";
                    //nivelAtencionJuegos._atencionAuditivaLocalizarSonido = "dificil";
                }

                game = "Atencion Selectiva - Piezas Faltantes";
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionSelectivaSostenida)
            {
                if (nivelAtencionJuegos._atencionSelectivaSostenida == "facil")
                {
                    level = "facil";
                    nivelAtencionJuegos._atencionSelectivaSostenida = "medio";
                }
                else if (nivelAtencionJuegos._atencionSelectivaSostenida == "medio")
                {
                    level = "medio";
                    nivelAtencionJuegos._atencionSelectivaSostenida = "dificil";
                }
                else if (nivelAtencionJuegos._atencionSelectivaSostenida == "dificil")
                {
                    level = "dificil";
                    //nivelAtencionJuegos._atencionAuditivaLocalizarSonido = "dificil";
                }

                game = "Atencion Selectiva y Sostenida";
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.IntegracionVisual)
            {
                if (nivelAtencionJuegos._integracionVisual == "facil")
                {
                    level = "facil";
                    nivelAtencionJuegos._integracionVisual = "medio";
                }
                else if (nivelAtencionJuegos._integracionVisual == "medio")
                {
                    level = "medio";
                    nivelAtencionJuegos._integracionVisual = "dificil";
                }
                else if (nivelAtencionJuegos._integracionVisual == "dificil")
                {
                    level = "dificil";
                    //nivelAtencionJuegos._atencionAuditivaLocalizarSonido = "dificil";
                }

                game = "Integracion Visual";
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionAuditivaDiscriminarFigura)
            {
                if (nivelAtencionJuegos._atencionAuditivaDiscriminarFigura == "facil")
                {
                    level = "facil";
                    nivelAtencionJuegos._atencionAuditivaDiscriminarFigura = "medio";
                }
                else if (nivelAtencionJuegos._atencionAuditivaDiscriminarFigura == "medio")
                {
                    level = "medio";
                    nivelAtencionJuegos._atencionAuditivaDiscriminarFigura = "dificil";
                }
                else if (nivelAtencionJuegos._atencionAuditivaDiscriminarFigura == "dificil")
                {
                    level = "dificil";
                    //nivelAtencionJuegos._atencionAuditivaLocalizarSonido = "dificil";
                }

                game = "Atencion Auditiva - Discriminar Figura";
            }
            GameManager.Instance.nivelAtencionJuegos = this.nivelAtencionJuegos;
            GameManager.Instance.conexionSQL.UpdateDataByIdStringNivelAtencion("NivelAtencionJuegos", this.nivelAtencionJuegos);

            CreateReport();

        }



        if (newState == GameManager.GameState.GameOverCierreVisual || newState == GameManager.GameState.GameOverDiscriminacionAuditiva || newState == GameManager.GameState.GameOverEsquemaCorporal)
        {
            result = "Juego no completado";
            nivelAtencionJuegos = GameManager.Instance.nivelAtencionJuegos;

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionAuditivaLocalizarSonido)
            {
                if (nivelAtencionJuegos._atencionAuditivaLocalizarSonido == "facil")
                {
                    level = "facil";
                }
                else if (nivelAtencionJuegos._atencionAuditivaLocalizarSonido == "medio")
                {
                    level = "medio";
                }
                else if (nivelAtencionJuegos._atencionAuditivaLocalizarSonido == "dificil")
                {
                    level = "dificil";
                }

                game = "Atencion Auditiva - Localizar Sonido";
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.ConcienciaCorporal)
            {
                if (nivelAtencionJuegos._concienciaCorporal == "facil")
                {
                    level = "facil";
                }
                else if (nivelAtencionJuegos._concienciaCorporal == "medio")
                {
                    level = "medio";
                }
                else if (nivelAtencionJuegos._concienciaCorporal == "dificil")
                {
                    level = "dificil";
                }
                game = "Conciencia Corporal";
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionSelectivaLaberinto)
            {
                if (nivelAtencionJuegos._atencionSelectivaLaberinto == "facil")
                {
                    level = "facil";
                }
                else if (nivelAtencionJuegos._atencionSelectivaLaberinto == "medio")
                {
                    level = "medio";
                }
                else if (nivelAtencionJuegos._atencionSelectivaLaberinto == "dificil")
                {
                    level = "dificil";
                }
                game = "Atencion Selectiva - Laberinto";
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.Yoga)
            {
                if (nivelAtencionJuegos._yoga == "facil")
                {
                    level = "facil";
                }
                else if (nivelAtencionJuegos._yoga == "medio")
                {
                    level = "medio";
                }
                else if (nivelAtencionJuegos._yoga == "dificil")
                {
                    level = "dificil";
                }
                game = "Yoga";
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionSelectivaObjetosPerdidos)
            {
                if (nivelAtencionJuegos._atencionSelectivaObjetosPerdidos == "facil")
                {
                    level = "facil";
                }
                else if (nivelAtencionJuegos._atencionSelectivaObjetosPerdidos == "medio")
                {
                    level = "medio";
                }
                else if (nivelAtencionJuegos._atencionSelectivaObjetosPerdidos == "dificil")
                {
                    level = "dificil";
                }
                game = "Atencion Selectiva - Objetos Perdidos";
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionSelectivaPiezasFaltantes)
            {
                level = nivelAtencionJuegos._atencionSelectivaPiezasFaltantes;
                game = "Atencion Selectiva - Piezas Faltantes";
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionSelectivaSostenida)
            {
                level = nivelAtencionJuegos._atencionSelectivaSostenida;
                game = "Atencion Selectiva y Sostenida";
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.IntegracionVisual)
            {
                level = nivelAtencionJuegos._integracionVisual;
                game = "Integracion Visual";
            }

            if (GameManager.Instance.gamePlaying == GameManager.GamePlaying.AtencionAuditivaDiscriminarFigura)
            {
                level = nivelAtencionJuegos._atencionAuditivaDiscriminarFigura;
                game = "Atencion Auditiva - Discriminar Figura";
            }

            CreateReport();
        }


        RestartVars();

    }


    public void CreateReport()
    {
        lock (databaseLock)
        {
            int rowCount = GameManager.Instance.conexionSQL.GetRowCount("Reportes") + 1;
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
                level,
                GameManager.Instance.nivelAtencionJuegos._idEstudiante);


            GameManager.Instance.conexionSQL.addDataReporteTable(rep);

        }
    }

}
