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
        private const String KEY_NAME = "name";
        private const String KEY_LASTNAME = "lastname";
        private const String KEY_BORN = "born";

        private String[] COLUMNS = new String[] { KEY_ID, KEY_NAME, KEY_LASTNAME, KEY_BORN };

        public EstudianteDB() : base()
        {
            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ( " +
                KEY_ID + " TEXT PRIMARY KEY, " +
                KEY_NAME + " TEXT, " +
                KEY_LASTNAME + " TEXT, " +
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
                + KEY_NAME + ", "
                + KEY_LASTNAME + ", "
                + KEY_BORN + " ) "

                + "VALUES ( '"
                + estudiante._id + "', '"
                + estudiante._name + "', '"
                + estudiante._lastName + "', '"
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