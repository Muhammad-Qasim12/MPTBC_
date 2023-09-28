using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;

public class DBAccess
{
    public SqlConnection moSqlConnection;
    public SqlCommand moSqlCommand;
    public SqlDataReader moSqlDataReader;
    public SqlTransaction moSqlTransaction;
    public SqlDataAdapter moSqlDataAdapter;
    public System.Data.DataSet moDataSet;
  //  component c = new component();
    public DBAccess()
    {
        moSqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        moSqlCommand = new SqlCommand();
        moSqlCommand.Connection = moSqlConnection;
    }

    public DBAccess(string connectionString)
    {
        moSqlConnection = new SqlConnection(connectionString);
        moSqlCommand = new SqlCommand();
        moSqlCommand.Connection = moSqlConnection;
    }

    public DataSet records()
    {
        moSqlDataAdapter = new SqlDataAdapter(moSqlCommand);
        moDataSet = new System.Data.DataSet();

        
        moSqlDataAdapter.Fill(moDataSet);
        moSqlDataAdapter.Dispose();
        if (moSqlConnection.State == ConnectionState.Open)
            moSqlConnection.Close();
        return moDataSet;
    }

    public DataTable records1()
    {
        moSqlDataAdapter = new SqlDataAdapter(moSqlCommand);
        DataTable moDataSet1 = new DataTable();
        moSqlDataAdapter.Fill(moDataSet1);
        moSqlDataAdapter.Dispose();
        if (moSqlConnection.State == ConnectionState.Open)
            moSqlConnection.Close();
        return moDataSet1;
    }

    public void openConnection()
    {
        if (moSqlConnection.State == ConnectionState.Closed)
        {moSqlConnection.Open(); }
        //else { moSqlConnection.Close(); }
            
    }

    public object getParameter(String fsParameter)
    {
        return moSqlCommand.Parameters[fsParameter].Value;
    }

    public object getParameter(int fiParameterIndex)
    {
        return moSqlCommand.Parameters[fiParameterIndex].Value;
    }

    public int executeMyQuery()
    {
        try
        {
            openConnection();
            int result = moSqlCommand.ExecuteNonQuery();
            if (moSqlConnection.State == ConnectionState.Open)
                moSqlConnection.Close();
            return result;
        }
        catch (Exception ex)
        {
            rollBackTransaction();
            throw ex;
        }
    }

    public object executeMyScalar()
    {
        try
        {
            openConnection();
            object obj = moSqlCommand.ExecuteScalar();
            if (moSqlConnection.State == ConnectionState.Open)
                moSqlConnection.Close();
            return obj;
        }
        catch (Exception ex)
        {
            rollBackTransaction();
            throw ex;
        }
    }

    public DataSet returnSet()
    {
        moSqlDataAdapter = new SqlDataAdapter(moSqlCommand);
        DataSet dsSet = new DataSet();
        moSqlDataAdapter.Fill(dsSet);
        moSqlDataAdapter.Dispose();
        if (moSqlConnection.State == ConnectionState.Open)
            moSqlConnection.Close();
        return dsSet;

    }

    public DataTable returnTable()
    {
        moSqlDataAdapter = new SqlDataAdapter(moSqlCommand);
        DataTable dtTable = new DataTable();
        moSqlDataAdapter.Fill(dtTable);
        moSqlDataAdapter.Dispose();
        if (moSqlConnection.State == ConnectionState.Open)
            moSqlConnection.Close();
        return dtTable;
    }

    public void execute(String fsSQL, SQLType foSQLType)
    {
        openConnection();
        //moSqlCommand = new SqlCommand(fsSQL, moSqlConnection, moSqlTransaction);
        moSqlCommand = new SqlCommand(fsSQL, moSqlConnection);
        moSqlCommand.CommandTimeout = 300;
        if (foSQLType == SQLType.IS_PROC)
        {
            moSqlCommand.CommandType = CommandType.StoredProcedure;
        }
            
    }

    public void addParam(String fsParameterName, SqlDbType foSqlDbType, object foValue, SqlDirection foSqlDirection)
    {
        SqlParameter loSqlParameter = new SqlParameter();
        loSqlParameter.ParameterName = fsParameterName;
        loSqlParameter.SqlDbType = foSqlDbType;
        if (foSqlDirection == SqlDirection.IN)
            loSqlParameter.Direction = ParameterDirection.Input;
        else if (foSqlDirection == SqlDirection.OUT)
            loSqlParameter.Direction = ParameterDirection.Output;
        loSqlParameter.Value = foValue;
        moSqlCommand.Parameters.Add(loSqlParameter);
    }

    public void addParam(String fsParameterName, SqlDbType foSqlDbType, SqlDirection foSqlDirection)
    {
        SqlParameter loSqlParameter = new SqlParameter();
        loSqlParameter.ParameterName = fsParameterName;
        loSqlParameter.SqlDbType = foSqlDbType;
        loSqlParameter.Size = 10;

        if (foSqlDirection == SqlDirection.IN)
            loSqlParameter.Direction = ParameterDirection.Input;
        else if (foSqlDirection == SqlDirection.OUT)
            loSqlParameter.Direction = ParameterDirection.Output;

        moSqlCommand.Parameters.Add(loSqlParameter);
    }

    public void addParam(String fsParameterName, SqlDbType foSqlDbType, SqlDirection foSqlDirection, int fiLength)
    {
        SqlParameter loSqlParameter = new SqlParameter();
        loSqlParameter.ParameterName = fsParameterName;
        loSqlParameter.SqlDbType = foSqlDbType;
        loSqlParameter.Size = fiLength;
        if (foSqlDirection == SqlDirection.IN)
            loSqlParameter.Direction = ParameterDirection.Input;
        else if (foSqlDirection == SqlDirection.OUT)
        {
            loSqlParameter.Direction = ParameterDirection.Output;
            loSqlParameter.Size = fiLength;
        }
        moSqlCommand.Parameters.Add(loSqlParameter);
    }

    public void addParam(String fsParameterName, object foValue, SqlDirection foSqlDirection)
    {
        SqlParameter loSqlParameter = moSqlCommand.Parameters.AddWithValue(fsParameterName, foValue);
        if (foSqlDirection == SqlDirection.IN)
            loSqlParameter.Direction = ParameterDirection.Input;
        else if (foSqlDirection == SqlDirection.OUT)
            loSqlParameter.Direction = ParameterDirection.Output;
    }

    public void addParam(String fsParameterName, object foValue)
    {
        addParam(fsParameterName, foValue, SqlDirection.IN);
    }

    public void addParam(SqlParameter foSqlParameter)
    {
        moSqlCommand.Parameters.Add(foSqlParameter);
    }

    public void closeConnection()
    {
        if (moSqlConnection.State == ConnectionState.Open)
            moSqlConnection.Close();


     
        if (moSqlCommand != null)
        {
            moSqlCommand.Dispose();
        }
        if (moSqlConnection != null)
        {
           // SqlConnection.ClearPool(moSqlConnection);
            moSqlConnection.Dispose();
        }
    }

    public enum SQLType
    {
        IS_QUERY = 1,
        IS_PROC = 2
    }

    public enum SqlDirection
    {
        IN = 1,
        OUT = 2
    }

    public void rollBackTransaction()
    {
        try
        {
            if (moSqlTransaction != null)
                moSqlTransaction.Rollback();
        }
        catch (Exception feException)
        { }
    }

    public void releasedCommand()
    {
        if (moSqlCommand != null)
        {
            moSqlCommand.Dispose();
            moSqlCommand = null;
        }
        //closeConnection();
    }
}
