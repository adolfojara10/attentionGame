using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBank
{
    public class NivelAtencionJuegosEntity
    {
        public string _id;

        public string _atencionAuditivaLocalizarSonido;

        public string _concienciaCorporal;

        public string _atencionSelectivaLaberinto;

        public string _yoga;

        public string _atencionSelectivaObjetosPerdidos;

        public string _atencionSelectivaPiezasFaltantes;

        public string _atencionSelectivaSostenida;

        public string _integracionVisual;

        public string _atencionAuditivaDiscriminarFigura;

        public string _idEstudiante;

        public NivelAtencionJuegosEntity()
        {

        }

        public NivelAtencionJuegosEntity(string id, string atencionAuditivaLocalizarSonido, string concienciaCorporal, string atencionSelectivaLaberinto, string yoga,
            string atencionSelectivaObjetosPerdidos, string atencionSelectivaPiezasFaltantes, string atencionSelectivaSostenida, string integracionVisual, string atencionAuditivaDiscriminarFigura,
            string idEstudiante)
        {
            _id = id;

            _atencionAuditivaLocalizarSonido = atencionAuditivaLocalizarSonido;

            _concienciaCorporal = concienciaCorporal;

            _atencionSelectivaLaberinto = atencionSelectivaLaberinto;

            _yoga = yoga;

            _atencionSelectivaObjetosPerdidos = atencionSelectivaObjetosPerdidos;

            _atencionSelectivaPiezasFaltantes = atencionSelectivaPiezasFaltantes;

            _atencionSelectivaSostenida = atencionSelectivaSostenida;

            _integracionVisual = integracionVisual;

            _atencionAuditivaDiscriminarFigura = atencionAuditivaDiscriminarFigura;

            _idEstudiante = idEstudiante;
        }


    }

}