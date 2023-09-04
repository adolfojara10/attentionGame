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

        public string _idEstudiante;

        public ReporteEntity()
        {

        }

        public ReporteEntity(string id, string game, string date, 
        string result, string idEstudiante)
        {
            _id = id;
            _game = game;
            _date = date;
            _result = result;
            _idEstudiante = idEstudiante;
        }


    }
}