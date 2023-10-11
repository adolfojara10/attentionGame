using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DataBank
{
    public class ReporteEntity
    {
        public string _id;

        public string _game;
        public string _date;
        public string _result;
        public string _time;
        public string _buttonsFound;
        public string _tries;

        public string _idEstudiante;

        public ReporteEntity()
        {

        }

        public ReporteEntity(string id, string game, string date, string result,
        string tiempo, string botonesEncontrados, string intentos, string idEstudiante)
        {
            _id = id;
            _game = game;
            _date = date;
            _result = result;
            _time = tiempo;
            _buttonsFound = botonesEncontrados;
            _tries = intentos;
            _idEstudiante = idEstudiante;
        }


    }
}