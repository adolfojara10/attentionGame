using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Data.Sqlite;
using UnityEngine;
using System.Data;


namespace DataBank
{
    public class SqliteHelper
    {
        private const string Tag = "Riz: SqliteHelper:\t";

        private const string database_name = "my_db.db";

        public string db_connection_string;
        public IDbConnection db_connection;

        public SqliteHelper()
        {
            db_connection_string = "URI=file:" + Application.persistentDataPath + "/" + database_name;

            Debug.Log("db_connection_string" + db_connection_string);
            db_connection = new SqliteConnection(db_connection_string);
            db_connection.Open();
        }

        ~SqliteHelper()
        {
            db_connection.Close();
        }


        public void createReporteTable()
        {

            String TABLE_NAME = "Reportes";
            String KEY_ID = "id";
            String KEY_GAME = "game";
            String KEY_DATE = "date";
            String KEY_RESULT = "result";
            String KEY_TIME = "time";
            String KEY_BUTTONS_FOUND = "buttonsFound";
            String KEY_TRIES = "tries";
            String KEY_LEVEL = "level";
            String KEY_ID_ESTUDIANTE = "idEstudiante";

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

        public void addDataReporteTable(ReporteEntity reporte)
        {
            String TABLE_NAME = "Reportes";
            String KEY_ID = "id";
            String KEY_GAME = "game";
            String KEY_DATE = "date";
            String KEY_RESULT = "result";
            String KEY_TIME = "time";
            String KEY_BUTTONS_FOUND = "buttonsFound";
            String KEY_TRIES = "tries";
            String KEY_LEVEL = "level";
            String KEY_ID_ESTUDIANTE = "idEstudiante";

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


        /*


            Nivel atencion juegos


        */

        public void createNivelAtencionTable()
        {
            String TABLE_NAME = "NivelAtencionJuegos";

            String KEY_ID = "id";
            String KEY_atencionAuditivaLocalizarSonido = "atencionAuditivaLocalizarSonido";
            String KEY_concienciaCorporal = "concienciaCorporal";
            String KEY_atencionSelectivaLaberinto = "atencionSelectivaLaberinto";

            String KEY_yoga = "yoga";
            String KEY_atencionSelectivaObjetosPerdidos = "atencionSelectivaObjetosPerdidos";
            String KEY_atencionSelectivaPiezasFaltantes = "atencionSelectivaPiezasFaltantes";
            String KEY_atencionSelectivaSostenida = "atencionSelectivaSostenida";
            String KEY_integracionVisual = "integracionVisual";
            String KEY_atencionAuditivaDiscriminarFigura = "atencionAuditivaDiscriminarFigura";

            String Key_idEstudiante = "idEstudiante";

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
        

        public void addDataNivelAtencionJuegos(NivelAtencionJuegosEntity nivelJuegos)
        {
            String TABLE_NAME = "NivelAtencionJuegos";

            String KEY_ID = "id";
            String KEY_atencionAuditivaLocalizarSonido = "atencionAuditivaLocalizarSonido";
            String KEY_concienciaCorporal = "concienciaCorporal";
            String KEY_atencionSelectivaLaberinto = "atencionSelectivaLaberinto";

            String KEY_yoga = "yoga";
            String KEY_atencionSelectivaObjetosPerdidos = "atencionSelectivaObjetosPerdidos";
            String KEY_atencionSelectivaPiezasFaltantes = "atencionSelectivaPiezasFaltantes";
            String KEY_atencionSelectivaSostenida = "atencionSelectivaSostenida";
            String KEY_integracionVisual = "integracionVisual";
            String KEY_atencionAuditivaDiscriminarFigura = "atencionAuditivaDiscriminarFigura";

            String Key_idEstudiante = "idEstudiante";

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

        public NivelAtencionJuegosEntity getDataByIdEstudiante(string id)
        {
            IDataReader dataReader = this.getAllData("NivelAtencionJuegos");

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

        public void UpdateDataByIdStringNivelAtencion(string table_name, NivelAtencionJuegosEntity nivel)
        {
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "UPDATE " + table_name
                + " SET "
                + "atencionAuditivaLocalizarSonido" + " = '" + nivel._atencionAuditivaLocalizarSonido + "', "
                + "concienciaCorporal" + " = '" + nivel._concienciaCorporal + "', "
                + "atencionSelectivaLaberinto" + " = '" + nivel._atencionSelectivaLaberinto + "', "
                + "yoga" + " = '" + nivel._yoga + "', "
                + "atencionSelectivaObjetosPerdidos" + " = '" + nivel._atencionSelectivaObjetosPerdidos + "', "
                + "atencionSelectivaPiezasFaltantes" + " = '" + nivel._atencionSelectivaPiezasFaltantes + "', "
                + "atencionSelectivaSostenida" + " = '" + nivel._atencionSelectivaSostenida + "', "
                + "integracionVisual" + " = '" + nivel._integracionVisual + "', "
                + "atencionAuditivaDiscriminarFigura" + " = '" + nivel._atencionAuditivaDiscriminarFigura + "' "
                + "WHERE " + "id" + " = '" + nivel._id + "'";

            // Execute the command
            dbcmd.ExecuteNonQuery();
        }


        public void ResetFacilValuesNivelJuegos()
        {
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "UPDATE " + "NivelAtencionJuegos" + " SET " +
                "atencionAuditivaLocalizarSonido = '" + "facil" + "', " +
                "concienciaCorporal = '" + "facil" + "', " +
                "atencionSelectivaLaberinto = '" + "facil" + "', " +
                "yoga = '" + "facil" + "', " +
                "atencionSelectivaObjetosPerdidos = '" + "facil" + "', " +
                "atencionSelectivaPiezasFaltantes = '" + "facil" + "', " +
                "atencionSelectivaSostenida = '" + "facil" + "', " +
                "integracionVisual = '" + "facil" + "', " +
                "atencionAuditivaDiscriminarFigura = '" + "facil" + "' " +
                "WHERE id = " + "1";


            dbcmd.ExecuteNonQuery();

        }
        /*


            Estudiantes


        */

        public void createEstudiantesTable()
        {
            String TABLE_NAME = "Estudiantes";
            String KEY_ID = "id";
            String KEY_CEDULA = "cedula";
            String KEY_NIVEL_BASICA = "nivelBasica";
            String KEY_GENDER = "gender";
            String KEY_BORN = "born";

            IDbCommand dbcmd = getDbCommand();
            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ( " +
                KEY_ID + " TEXT PRIMARY KEY, " +
                KEY_CEDULA + " TEXT, " +
                KEY_NIVEL_BASICA + " TEXT, " +
                KEY_GENDER + " TEXT, " +
                KEY_BORN + " TEXT )";

            dbcmd.ExecuteNonQuery();

        }

        public void addDataEstudiante(EstudianteEntity estudiante)
        {
            String TABLE_NAME = "Estudiantes";
            String KEY_ID = "id";
            String KEY_CEDULA = "cedula";
            String KEY_NIVEL_BASICA = "nivelBasica";
            String KEY_GENDER = "gender";
            String KEY_BORN = "born";


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

        public IDataReader getStudentByCedula(string cedula)
        {

            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText = "SELECT * FROM Estudiantes WHERE CEDULA = '" + cedula + "'";

            try
            {
                IDataReader reader = dbcmd.ExecuteReader();

                // Check if there is a valid row before accessing data
                if (reader.Read())
                {
                    return reader; // Return the reader with the valid row
                }
                else
                {
                    Debug.LogWarning("No data found for the specified ID.");
                    reader.Close(); // Close the reader when no data is found
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("Error while retrieving data by ID: " + ex.Message);
                return null;
            }
        }


        // virtual functions
        public virtual IDataReader getDataById(int id)
        {

            Debug.Log(Tag + "This function is not implemnted");
            throw null;
        }

        public IDataReader getDataByIdString(string table_name, string id)
        {

            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText = "SELECT * FROM " + table_name + " WHERE ID = " + id;
            try
            {
                IDataReader reader = dbcmd.ExecuteReader();

                // Check if there is a valid row before accessing data
                if (reader.Read())
                {
                    return reader; // Return the reader with the valid row
                }
                else
                {
                    Debug.LogWarning("No data found for the specified ID.");
                    reader.Close(); // Close the reader when no data is found
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("Error while retrieving data by ID: " + ex.Message);
                return null;
            }
        }


        public virtual void deleteDataById(int id)
        {
            Debug.Log(Tag + "This function is not implemented");
            throw null;
        }

        public virtual void deleteDataByString(string id)
        {
            Debug.Log(Tag + "This function is not implemented");
            throw null;
        }

        public virtual IDataReader getAllData()
        {
            Debug.Log(Tag + "This function is not implemented");
            throw null;
        }

        public virtual void deleteAllData()
        {
            Debug.Log(Tag + "This function is not implemnted");
            throw null;
        }

        public virtual IDataReader getNumOfRows()
        {
            Debug.Log(Tag + "This function is not implemnted");
            throw null;
        }

        //helper functions
        public IDbCommand getDbCommand()
        {
            return db_connection.CreateCommand();
        }

        public IDataReader getAllData(string table_name)
        {
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + table_name;
            IDataReader reader = dbcmd.ExecuteReader();
            return reader;
        }

        public void deleteAllData(string table_name)
        {
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText = "DROP TABLE IF EXISTS " + table_name;
            dbcmd.ExecuteNonQuery();
        }

        public IDataReader getNumOfRows(string table_name)
        {
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText =
                "SELECT COALESCE(MAX(id)+1, 0) FROM " + table_name;
            IDataReader reader = dbcmd.ExecuteReader();
            return reader;
        }

        public int GetRowCount(string table_name)
        {
            IDbCommand dbcmd = db_connection.CreateCommand();
            dbcmd.CommandText = "SELECT COUNT(*) FROM " + table_name;

            try
            {
                int rowCount = Convert.ToInt32(dbcmd.ExecuteScalar());
                return rowCount;
            }
            catch (Exception ex)
            {
                Debug.LogError("Error while getting row count: " + ex.Message);
                Debug.Log("Error while getting row count: " + ex.Message);
                return -1; // or another suitable error value
            }
        }


        public void close()
        {
            db_connection.Close();
        }
    }
}