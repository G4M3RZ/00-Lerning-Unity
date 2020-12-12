using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

#region Using SQL
using Mono.Data.Sqlite;
using System.Data;
using System;
#endregion

public class Send_Info_SQL : MonoBehaviour
{
    public void InsertInfoSQL()
    {
        string conn = "URI=file:" + Application.dataPath + "/Plugins/Web Information.db";
        IDbConnection dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();

        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = "INSERT " + "INTO Info " + "(Id, User, Password) VALUES (" + "'2', 'pablo', 'holaxd'" + ")";
        dbcmd.ExecuteNonQuery();

        #region Close SQL
        dbcmd.Dispose();
        dbcmd = null;

        dbconn.Close();
        dbconn = null;
        #endregion
    }
    public void SerchIdDataFromSQL(TMP_InputField serchInfo)
    {
        if(serchInfo.text != "")
        {
            string conn = "URI=file:" + Application.dataPath + "/Plugins/Web Information.db";
            IDbConnection dbconn = (IDbConnection)new SqliteConnection(conn);
            dbconn.Open();

            IDbCommand dbcmd = dbconn.CreateCommand();
            dbcmd.CommandText = "SELECT * " + "FROM Info " + "WHERE Id = " + serchInfo.text; // buscar segun parametro
            IDataReader reader = dbcmd.ExecuteReader();

            #region Show Data
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string user = reader.GetString(1);
                string password = reader.GetString(2);

                Debug.Log("ID: " + id + " User: " + user + " password: " + password);
            }
            #endregion

            #region Close SQL
            reader.Close();
            reader = null;

            dbcmd.Dispose();
            dbcmd = null;

            dbconn.Close();
            dbconn = null;
            #endregion
        }
    }
    public void UpdateInfoSQL()
    {
        string conn = "URI=file:" + Application.dataPath + "/Plugins/Web Information.db";
        IDbConnection dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();

        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = "UPDATE " ; //no me acuerdo que mas xd
        dbcmd.ExecuteNonQuery();

        #region Close SQL
        dbcmd.Dispose();
        dbcmd = null;

        dbconn.Close();
        dbconn = null;
        #endregion
    }
    public void DeletInfoSQL(TMP_InputField serchInfo)
    {
        string conn = "URI=file:" + Application.dataPath + "/Plugins/Web Information.db";
        IDbConnection dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();

        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = "DELETE " + "FROM Info " + "WHERE Id = " + serchInfo.text;
        dbcmd.ExecuteNonQuery();

        #region Close SQL
        dbcmd.Dispose();
        dbcmd = null;

        dbconn.Close();
        dbconn = null;
        #endregion
    }
}