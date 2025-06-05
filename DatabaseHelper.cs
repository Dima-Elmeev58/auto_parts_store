using System;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;

namespace AutoStoreParts
{
    public class DatabaseHelper
    {
        public string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AutoPartsDBB.mdb;Persist Security Info=False;";
        public OleDbConnection GetConnection()
        {
            return new OleDbConnection(connectionString);
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();
            using (OleDbConnection conn = GetConnection())
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(query, conn);
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }
        public int ExecuteParametrizedQuery(string query, params OleDbParameter[] parameters)
        {
            using (OleDbConnection conn = GetConnection())
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public object ExecuteScalar(string query, params OleDbParameter[] parameters)
        {
            using (OleDbConnection conn = GetConnection())
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteScalar();
                }
            }
        }

        public int ExecuteNonQuery(string query)
        {
            using (OleDbConnection conn = GetConnection())
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(query, conn);
                return cmd.ExecuteNonQuery();
            }
        }
        public object ExecuteScalarWithParams(string query, params OleDbParameter[] parameters)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }

        public object ExecuteScalar(string query)
        {
            using (OleDbConnection conn = GetConnection())
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(query, conn);
                return cmd.ExecuteScalar();
            }
        }
        public bool TestConnection()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка подключения: {ex.Message}");
                return false;
            }
        }
    }
}