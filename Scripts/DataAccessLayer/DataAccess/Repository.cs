using Mono.Data.Sqlite;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Data_Access
{
    public class Repository
    {
        public string connection_string;
        public IDbConnection db_connection;

        public Repository()
        {
            connection_string = "URI=file:" + Application.dataPath + "/Database/unityaccess.db";
            db_connection = new SqliteConnection(connection_string);
            db_connection.Open();
        }

        ~Repository()
        {
            db_connection.Close();
        }

        public void DropTable(string tableName)
        {
            string sqlQuery = string.Format("Drop Table \"{0}\"", tableName);
            IDbCommand command = db_connection.CreateCommand();
            command.CommandText = sqlQuery;
            command.ExecuteNonQuery();
        }
        public void CreateTable(string sqlQuery)
        {
            IDbCommand command = db_connection.CreateCommand();
            command.CommandText = sqlQuery;
            command.ExecuteNonQuery();
        }
        public void DeleteById(string tableName, int id)
        {
            string sqlQuery = string.Format("DELETE FROM \"{0}\" WHERE PlayerId = \"{1}\"", tableName, id);
            ExecuteQuery(sqlQuery);
        }

        public void DeleteByDoubleId(string tableName, string firstIdName, string secondIdName, int firstId, int secondId)
        {
            string sqlQuery = string.Format("DELETE FROM \"{0}\" WHERE \"{1}\" = \"{2}\" AND \"{3}\" = \"{4}\"", tableName, firstIdName, firstId, secondIdName, secondId);
            ExecuteQuery(sqlQuery);
        }

        public void Insert(string query)
        {
            string sqlQuery = query;
            ExecuteQuery(sqlQuery);
        }

        public void Select(string query)
        {
            string sqlQuery = query;
            ExecuteQuery(sqlQuery);
        }

        public IDataReader GetDataById(string tableName, string idName, int id)
        {
            string sqlQuery = string.Format("SELECT \"{1}\" FROM \"{0}\" WHERE \"{1}\" = \"{2}\"", tableName, idName, id);
            return (ReturnReader(sqlQuery));
        }

        public IDataReader GetRowById(string tableName, string idName, int id)
        {
            string sqlQuery = string.Format("SELECT * FROM \"{0}\" WHERE \"{1}\"=\"{2}\";", tableName, idName, id) ;
            return (ReturnReader(sqlQuery));
        }

        public IDataReader GetDataByString(string query)
        {
            string sqlQuery = query;
            return (ReturnReader(sqlQuery));
        }

        public IDataReader GetAllData(string table)
        {
            string sqlQuery = string.Format("SELECT * FROM \"{0}\"", table);
            return(ReturnReader(sqlQuery));

        }

        public IDataReader FilterResultsById(string tableName, string filterCriteriaName, int criteriaId)
        {
            string sqlQuery = string.Format("SELECT * from \"{0}\" where \"{1}\"=\"{2}\"", tableName, filterCriteriaName, criteriaId);
            return (ReturnReader(sqlQuery));
        }

        private void ExecuteQuery(string query)
        {
            IDbCommand command = db_connection.CreateCommand();
            command.CommandText = query;
            command.ExecuteScalar();
        }

        private IDataReader ReturnReader(string sqlQuery)
        {
            IDbCommand command = db_connection.CreateCommand();
            command.CommandText = sqlQuery;
            IDataReader reader = command.ExecuteReader();
           
            return reader;
        }

        
    }
}
