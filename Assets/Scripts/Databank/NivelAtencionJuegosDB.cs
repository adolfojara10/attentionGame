using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DataBank
{
    public class NivelAtencionJuegosDB : SqliteHelper
    {
        private const String Tag = "Riz: LocationDb:\t";

        private const String TABLE_NAME = "NivelAtencionJuegos";

        private const String KEY_ID = "id";
        private const String KEY_atencionAuditivaLocalizarSonido = "atencionAuditivaLocalizarSonido";
        private const String KEY_concienciaCorporal = "concienciaCorporal";
        private const String KEY_atencionSelectivaLaberinto = "atencionSelectivaLaberinto";

        private const String KEY_yoga = "yoga";
        private const String KEY_atencionSelectivaObjetosPerdidos = "atencionSelectivaObjetosPerdidos";
        private const String KEY_atencionSelectivaPiezasFaltantes = "atencionSelectivaPiezasFaltantes";
        private const String KEY_atencionSelectivaSostenida = "atencionSelectivaSostenida";
        private const String KEY_integracionVisual = "integracionVisual";
        private const String KEY_atencionAuditivaDiscriminarFigura = "atencionAuditivaDiscriminarFigura";

        private const String Key_idEstudiante = "idEstudiante";


        private String[] COLUMNS = new String[] { KEY_ID, KEY_atencionAuditivaLocalizarSonido, KEY_concienciaCorporal, KEY_atencionSelectivaLaberinto,
                                KEY_yoga, KEY_atencionSelectivaObjetosPerdidos, KEY_atencionSelectivaPiezasFaltantes, KEY_atencionSelectivaSostenida, KEY_integracionVisual,
                                KEY_atencionAuditivaDiscriminarFigura, Key_idEstudiante};


        public NivelAtencionJuegosDB() : base()
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ( " +
                KEY_ID + " TEXT PRIMARY KEY, " +
                KEY_atencionAuditivaLocalizarSonido + " TEXT, " +
                KEY_concienciaCorporal + " TEXT, " +
                KEY_atencionSelectivaLaberinto + " TEXT, " +
                KEY_yoga + " TEXT, " +
                KEY_atencionSelectivaObjetosPerdidos + " TEXT, " +
                KEY_atencionSelectivaPiezasFaltantes + " TEXT, " +
                KEY_atencionSelectivaSostenida + " TEXT, " +
                KEY_integracionVisual + " TEXT, " +
                KEY_atencionAuditivaDiscriminarFigura + " TEXT, " +
                Key_idEstudiante + " TEXT )";

            dbcmd.ExecuteNonQuery();
        }

        public void addData(NivelAtencionJuegosEntity nivelJuegos)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "INSERT INTO " + TABLE_NAME
                + " ( "
                + KEY_ID + ", "
                + KEY_atencionAuditivaLocalizarSonido + ", "
                + KEY_concienciaCorporal + ", "
                + KEY_atencionSelectivaLaberinto + ", "
                + KEY_yoga + ", "
                + KEY_atencionSelectivaObjetosPerdidos + ", "
                + KEY_atencionSelectivaPiezasFaltantes + ", "
                + KEY_atencionSelectivaSostenida + ", "
                + KEY_integracionVisual + ", "
                + KEY_atencionAuditivaDiscriminarFigura + ", "
                + Key_idEstudiante + " ) "

                + "VALUES ( '"
                + nivelJuegos._id + "', '"
                + nivelJuegos._atencionAuditivaLocalizarSonido + "', '"
                + nivelJuegos._concienciaCorporal + "', '"
                + nivelJuegos._atencionSelectivaLaberinto + "', '"
                + nivelJuegos._yoga + "', '"
                + nivelJuegos._atencionSelectivaObjetosPerdidos + "', '"
                + nivelJuegos._atencionSelectivaPiezasFaltantes + "', '"
                + nivelJuegos._atencionSelectivaSostenida + "', '"
                + nivelJuegos._integracionVisual + "', '"
                + nivelJuegos._atencionAuditivaDiscriminarFigura + "', '"
                + nivelJuegos._idEstudiante + "' )";
            dbcmd.ExecuteNonQuery();
        }

        public override IDataReader getDataById(int id)
        {
            return base.getDataById(id);
        }

        public override IDataReader getAllData()
        {
            return base.getAllData(TABLE_NAME);
        }

        public NivelAtencionJuegosEntity getDataByIdEstudiante(string id)
        {
            IDataReader dataReader = this.getAllData();

            while (dataReader.Read())
            {
                // Access the data using dataReader.GetXXX methods

                string idEstudiante = dataReader.GetString(10);

                if (idEstudiante == id)
                {
                    NivelAtencionJuegosEntity nivel = new NivelAtencionJuegosEntity();
                    nivel._id = dataReader.GetString(0);
                    nivel._atencionAuditivaLocalizarSonido = dataReader.GetString(1);
                    nivel._concienciaCorporal = dataReader.GetString(2);
                    nivel._atencionSelectivaLaberinto = dataReader.GetString(3);
                    nivel._yoga = dataReader.GetString(4);
                    nivel._atencionSelectivaObjetosPerdidos = dataReader.GetString(5);
                    nivel._atencionSelectivaPiezasFaltantes = dataReader.GetString(6);
                    nivel._atencionSelectivaSostenida = dataReader.GetString(7);
                    nivel._integracionVisual = dataReader.GetString(8);
                    nivel._atencionAuditivaDiscriminarFigura = dataReader.GetString(9);
                    nivel._idEstudiante = idEstudiante;

                    return nivel;
                }

            }

            return null;
        }
    }

}
