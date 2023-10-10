using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DataBank
{
    public class EstudianteDB : SqliteHelper
    {
        private const String Tag = "Riz: LocationDb:\t";

        private const String TABLE_NAME = "Estudiantes";
        private const String KEY_ID = "id";
        private const String KEY_CEDULA = "cedula";
        private const String KEY_NIVEL_BASICA = "nivelBasica";
        private const String KEY_GENDER = "gender";
        private const String KEY_BORN = "born";

        private String[] COLUMNS = new String[] { KEY_ID, KEY_CEDULA, KEY_NIVEL_BASICA,KEY_GENDER, KEY_BORN };

        public EstudianteDB() : base()
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ( " +
                KEY_ID + " TEXT PRIMARY KEY, " +
                KEY_CEDULA + " TEXT, " +
                KEY_NIVEL_BASICA + " TEXT, " +
                KEY_GENDER + " TEXT, " +
                KEY_BORN + " TEXT )";

            dbcmd.ExecuteNonQuery();
        }

        public void addData(EstudianteEntity estudiante)
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText =
                "INSERT INTO " + TABLE_NAME
                + " ( "
                + KEY_ID + ", "
                + KEY_CEDULA + ", "
                + KEY_NIVEL_BASICA + ", "
                + KEY_GENDER + ", "
                + KEY_BORN + " ) "

                + "VALUES ( '"
                + estudiante._id + "', '"
                + estudiante._cedula + "', '"
                + estudiante._nivelBasica + "', '"
                + estudiante._gender + "', '"
                + estudiante._born + "' )";
            dbcmd.ExecuteNonQuery();
        }

        public IDataReader getDataByIdString(string id)
        {
            return base.getDataByIdString(TABLE_NAME, id);
        }


        public override IDataReader getAllData()
        {
            return base.getAllData(TABLE_NAME);
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