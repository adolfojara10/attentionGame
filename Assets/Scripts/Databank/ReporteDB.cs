using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DataBank
{
    public class ReporteDB : SqliteHelper
    {
        private const String Tag = "Riz: LocationDb:\t";

        private const String TABLE_NAME = "Reportes";
        private const String KEY_ID = "id";
        private const String KEY_GAME = "game";
        private const String KEY_DATE = "date";
        private const String KEY_RESULT = "result";
        private const String KEY_TIME = "time";
        private const String KEY_BUTTONS_FOUND = "buttonsFound";
        private const String KEY_TRIES = "tries";
        private const String KEY_LEVEL = "level";


        private const String KEY_ID_ESTUDIANTE = "idEstudiante";

        private String[] COLUMNS = new String[] { KEY_ID, KEY_GAME, KEY_DATE, KEY_RESULT, KEY_TIME, KEY_BUTTONS_FOUND, KEY_TRIES, KEY_LEVEL, KEY_ID_ESTUDIANTE };

        public ReporteDB() : base()
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ( " +
                KEY_ID + " TEXT PRIMARY KEY, " +
                KEY_GAME + " TEXT, " +
                KEY_DATE + " TEXT, " +
                KEY_RESULT + " TEXT, " +
                KEY_TIME + " TEXT, " +
                KEY_BUTTONS_FOUND + " TEXT, " +
                KEY_TRIES + " TEXT, " +
                KEY_LEVEL + " TEXT, " +
                KEY_ID_ESTUDIANTE + " TEXT )";

            dbcmd.ExecuteNonQuery();
        }

        public void addData(ReporteEntity reporte)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "INSERT INTO " + TABLE_NAME
                + " ( "
                + KEY_ID + ", "
                + KEY_GAME + ", "
                + KEY_DATE + ", "
                + KEY_RESULT + ", "
                + KEY_TIME + ", "
                + KEY_BUTTONS_FOUND + ", "
                + KEY_TRIES + ", "
                + KEY_LEVEL + ", "
                + KEY_ID_ESTUDIANTE + " ) "

                + "VALUES ( '"
                + reporte._id + "', '"
                + reporte._game + "', '"
                + reporte._date + "', '"
                + reporte._result + "', '"
                + reporte._time + "', '"
                + reporte._buttonsFound + "', '"
                + reporte._tries + "', '"
                + reporte._level + "', '"
                + reporte._idEstudiante + "' )";
            dbcmd.ExecuteNonQuery();
        }

        public override IDataReader getAllData()
        {
            return base.getAllData(TABLE_NAME);
        }


        public List<ReporteEntity> getDataByIdEstudiante(string id)
        {
            IDataReader dataReader = this.getAllData();
            List<ReporteEntity> list = new List<ReporteEntity>();

            while (dataReader.Read())
            {
                // Access the data using dataReader.GetXXX methods

                string idEstudiante = dataReader.GetString(8);

                if (idEstudiante == id)
                {
                    ReporteEntity rep = new ReporteEntity();
                    rep._id = dataReader.GetString(0);
                    rep._game = dataReader.GetString(1);
                    rep._date = dataReader.GetString(2);
                    rep._result = dataReader.GetString(3);
                    rep._time = dataReader.GetString(4);
                    rep._buttonsFound = dataReader.GetString(5);
                    rep._tries = dataReader.GetString(6);
                    rep._level = dataReader.GetString(7);
                    rep._idEstudiante = dataReader.GetString(8);
                    list.Add(rep);
                }

            }

            return list;
        }

        public int GetRowCount()
        {
            return base.GetRowCount(TABLE_NAME);
        }

        public override void deleteAllData()
        {
            base.deleteAllData(TABLE_NAME);
        }

    }
}