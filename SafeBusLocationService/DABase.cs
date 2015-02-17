using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace SafeBusLocationService
{
    class DABase
    {
        private SqlConnection daSqlConnection;
        public DABase()
        {
            daSqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SafebusConn"].ConnectionString);
        }
        /*SELECT BLOCK*/
        public DataTable ExecuteSelect(string _query, SqlParameter[] _sqlParameter)
        {
            return ExecuteSelectQuery(_query, _sqlParameter);
        }
        public DataTable ExecuteSelect(string _query)
        {
            return ExecuteSelectQuery(_query);
        }
        public DataSet ExecuteSelect(string _query, Hashtable _hashparameters)
        {
            return ExecuteQuery(_query, _hashparameters);
        }


        /*COUNT BLOCK*/
        public int GetCount(string _query)
        {
            try
            {
                int iResult = 0;
                DataTable dtResult = (DataTable)ExecuteSelectQuery(_query);
                if (dtResult.Rows.Count > 0)
                {
                    Int32.TryParse(dtResult.Rows[0][0].ToString(), out iResult);
                }
                return iResult;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        public int GetCount(string _query, SqlParameter[] _sqlParameter)
        {
            try
            {
                int iResult = 0;
                DataTable dtResult = (DataTable)ExecuteSelectQuery(_query, _sqlParameter);
                if (dtResult.Rows.Count > 0)
                {
                    Int32.TryParse(dtResult.Rows[0][0].ToString(), out iResult);
                }
                return iResult;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        /*INSERT BLOCK*/
        public bool ExecuteInsert(String _query)
        {
            return this.ExecuteNonSelectQuery(_query);
        }
        public bool ExecuteInsert(String _query, out int _affectedrows)
        {
            return this.ExecuteNonSelectQuery(_query, out _affectedrows);
        }
        public bool ExecuteInsert(String _query, SqlParameter[] _sqlParameter)
        {
            return this.ExecuteNonSelectQuery(_query, _sqlParameter);
        }
        public bool ExecuteInsert(String _query, SqlParameter[] _sqlParameter, out int _affectedrows)
        {
            return this.ExecuteNonSelectQuery(_query, _sqlParameter, out  _affectedrows);
        }
        /*UPDATE BLOCK*/
        public bool ExecuteUpdate(String _query)
        {
            return this.ExecuteNonSelectQuery(_query);
        }
        public bool ExecuteUpdate(String _query, out int _affectedrows)
        {
            return this.ExecuteNonSelectQuery(_query, out _affectedrows);
        }
        public bool ExecuteUpdate(String _query, SqlParameter[] _sqlParameter)
        {
            return this.ExecuteNonSelectQuery(_query, _sqlParameter);
        }
        public bool ExecuteUpdate(String _query, SqlParameter[] _sqlParameter, out int _affectedrows)
        {
            return this.ExecuteNonSelectQuery(_query, _sqlParameter, out _affectedrows);
        }
        public int ExecuteUpdate(string _query, Hashtable _hashparameters)
        {
            return this.ExecuteNonQuery(_query, _hashparameters);
        }

        /*DELETE BLOCK*/
        public bool ExecuteDelete(String _query)
        {
            return this.ExecuteNonSelectQuery(_query);
        }
        public bool ExecuteDelete(String _query, out int _affectedrows)
        {
            return this.ExecuteNonSelectQuery(_query, out _affectedrows);
        }
        public bool ExecuteDelete(String _query, SqlParameter[] _sqlParameter)
        {
            return this.ExecuteNonSelectQuery(_query, _sqlParameter);
        }
        public bool ExecuteDelete(String _query, SqlParameter[] _sqlParameter, out int _affectedrows)
        {
            return this.ExecuteNonSelectQuery(_query, _sqlParameter, out _affectedrows);
        }
        public int ExecuteDelete(string _query, Hashtable _hashparameters)
        {
            return this.ExecuteNonQuery(_query, _hashparameters);
        }

        /*PRIVATE FUNCTION BLOCK*/
        private void OpenDataBaseConnection()
        {
            try
            {
                if (daSqlConnection.State == ConnectionState.Closed || daSqlConnection.State == ConnectionState.Broken)
                {
                    daSqlConnection.Open();
                }
            }
            catch (SqlException SqlEx)
            {
                throw SqlEx;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
            }
        }
        private void CloseDataBaseConnection()
        {
            try
            {
                if (daSqlConnection.State != ConnectionState.Closed)
                {
                    daSqlConnection.Close();
                }
            }
            catch (SqlException SqlEx)
            {
                throw SqlEx;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
            }
        }
        private bool ExecuteNonSelectQuery(String _query)
        {
            SqlCommand daSqlCommand = new SqlCommand();
            try
            {
                OpenDataBaseConnection();
                daSqlCommand.Connection = this.daSqlConnection;
                daSqlCommand.CommandText = _query;
                return (daSqlCommand.ExecuteNonQuery() > 0) ? true : false;
            }
            catch (SqlException SqlEx)
            {
                throw SqlEx;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                daSqlCommand.Dispose();
                CloseDataBaseConnection();
            }
        }
        private bool ExecuteNonSelectQuery(String _query, SqlParameter[] _sqlParameter)
        {
            SqlDataAdapter daSqlDataAdapter = new SqlDataAdapter();
            SqlCommand daSqlCommand = new SqlCommand();
            try
            {
                OpenDataBaseConnection();
                daSqlCommand.Connection = this.daSqlConnection;
                daSqlCommand.CommandText = _query;
                daSqlCommand.CommandType = CommandType.StoredProcedure;
                daSqlCommand.Parameters.AddRange(_sqlParameter);
                daSqlDataAdapter.UpdateCommand = daSqlCommand;
                return (daSqlCommand.ExecuteNonQuery() > 0) ? true : false;
            }
            catch (SqlException SqlEx)
            {
                throw SqlEx;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                daSqlCommand.Dispose();
                daSqlDataAdapter.Dispose();
                CloseDataBaseConnection();
            }
        }
        private bool ExecuteNonSelectQuery(String _query, out int _affectedrows)
        {
            SqlCommand daSqlCommand = new SqlCommand();
            try
            {
                OpenDataBaseConnection();
                daSqlCommand.Connection = this.daSqlConnection;
                daSqlCommand.CommandText = _query;
                _affectedrows = daSqlCommand.ExecuteNonQuery();
                return (_affectedrows > 0) ? true : false;
            }
            catch (SqlException SqlEx)
            {
                throw SqlEx;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                daSqlCommand.Dispose();
                CloseDataBaseConnection();
            }
        }
        private bool ExecuteNonSelectQuery(String _query, SqlParameter[] _sqlParameter, out int _affectedrows)
        {
            SqlDataAdapter daSqlDataAdapter = new SqlDataAdapter();
            SqlCommand daSqlCommand = new SqlCommand();
            try
            {
                OpenDataBaseConnection();
                daSqlCommand.Connection = this.daSqlConnection;
                daSqlCommand.CommandText = _query;
                daSqlCommand.Parameters.AddRange(_sqlParameter);
                daSqlDataAdapter.UpdateCommand = daSqlCommand;
                _affectedrows = daSqlCommand.ExecuteNonQuery();
                return (_affectedrows > 0) ? true : false;
            }
            catch (SqlException SqlEx)
            {
                throw SqlEx;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                daSqlCommand.Dispose();
                daSqlDataAdapter.Dispose();
                CloseDataBaseConnection();
            }
        }
        private DataTable ExecuteSelectQuery(string _query)
        {
            SqlDataAdapter daSqlDataAdapter = new SqlDataAdapter();
            SqlCommand daSqlCommand = new SqlCommand();
            try
            {
                OpenDataBaseConnection();
                daSqlCommand.Connection = this.daSqlConnection;
                daSqlCommand.CommandText = _query;
                daSqlDataAdapter.SelectCommand = daSqlCommand;
                DataTable dataTableResult = new DataTable();
                daSqlDataAdapter.Fill(dataTableResult);
                return dataTableResult;
            }
            catch (SqlException SqlEx)
            {
                throw SqlEx;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                daSqlCommand.Dispose();
                daSqlDataAdapter.Dispose();
                CloseDataBaseConnection();
            }
        }
        private DataTable ExecuteSelectQuery(string _query, SqlParameter[] _sqlParameter)
        {
            SqlDataAdapter daSqlDataAdapter = new SqlDataAdapter();
            SqlCommand daSqlCommand = new SqlCommand();
            try
            {
                DataTable dataTableResult = new DataTable();
                OpenDataBaseConnection();
                daSqlCommand.Connection = this.daSqlConnection;
                daSqlCommand.CommandType = CommandType.StoredProcedure;
                daSqlCommand.CommandText = _query;
                daSqlCommand.Parameters.AddRange(_sqlParameter);
                daSqlCommand.ExecuteNonQuery();
                daSqlDataAdapter.SelectCommand = daSqlCommand;
                daSqlDataAdapter.Fill(dataTableResult);
                return dataTableResult;
            }
            catch (SqlException SqlEx)
            {
                throw SqlEx;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                daSqlCommand.Dispose();
                daSqlDataAdapter.Dispose();
                CloseDataBaseConnection();
            }
        }
        private int ExecuteNonQuery(string _query, Hashtable _hashparameters)
        {
            SqlCommand daSqlCommand = new SqlCommand();
            try
            {
                OpenDataBaseConnection();
                daSqlCommand.Connection = this.daSqlConnection;
                daSqlCommand.CommandText = _query;
                daSqlCommand.CommandType = CommandType.StoredProcedure;
                foreach (DictionaryEntry daDictionaryEntry in _hashparameters)
                {
                    SqlParameter saSqlParameter = new SqlParameter(daDictionaryEntry.Key.ToString(), daDictionaryEntry.Value);
                    daSqlCommand.Parameters.Add(saSqlParameter);
                }
                return daSqlCommand.ExecuteNonQuery();
            }
            catch (SqlException SqlEx)
            {
                throw SqlEx;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                daSqlCommand.Dispose();
                CloseDataBaseConnection();
            }
        }
        private DataSet ExecuteQuery(string _query, Hashtable _hashparameters)
        {
            SqlCommand daSqlCommand = new SqlCommand();
            SqlDataAdapter daSqlDataAdapter = new SqlDataAdapter();
            try
            {
                OpenDataBaseConnection();
                daSqlCommand.Connection = this.daSqlConnection;
                daSqlCommand.CommandText = _query;
                daSqlCommand.CommandType = CommandType.StoredProcedure;
                foreach (DictionaryEntry daDictionaryEntry in _hashparameters)
                {
                    SqlParameter param = new SqlParameter(daDictionaryEntry.Key.ToString(), daDictionaryEntry.Value);
                    daSqlCommand.Parameters.Add(param);
                }
                DataSet dataTableResult = new DataSet();
                daSqlDataAdapter = new SqlDataAdapter(daSqlCommand);
                daSqlDataAdapter.Fill(dataTableResult);
                return dataTableResult;
            }
            catch (SqlException SqlEx)
            {
                throw SqlEx;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                daSqlCommand.Dispose();
                daSqlDataAdapter.Dispose();
                CloseDataBaseConnection();
            }
        }
    }
}