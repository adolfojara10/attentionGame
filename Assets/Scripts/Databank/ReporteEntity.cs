using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DataBank
{
    public class ReporteEntity
    {
        public string _id;

        public string _juego;
        public string _fecha;
        public string _resultado;

        public string _idEstudiante;

        public ReporteEntity()
        {

        }

        public ReporteEntity(string id, string juego, string fecha, string resultado, string idEstudiante)
        {
            _id = id;
            _juego = juego;
            _fecha = fecha;
            _resultado = resultado;
            _idEstudiante = idEstudiante;
        }


    }
}