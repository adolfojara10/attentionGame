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

        private const string database_name = "my_db";

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
                return -1; // or another suitable error value
            }
        }


        public void close()
        {
            db_connection.Close();
        }
    }
}