using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;

/// <summary>
/// Summary description for DBClass
/// </summary>
public class DBClass
{
    private int _DemandId_I;
    private int _NoOfBooks;
    private int _DemandTypeId_I;
    private string _AcYearId_V;
    private int _TitleId_I;
    private int _UserId;
    string _EntryDate;
    int _DepoId;
    int _DistrictId;
    int _blockId;
    int _IsOpenMktDemand;
    int _SchemeID;
    private string _LetterNo;
    private string _LetterDate;


    public int DemandId_I { get { return _DemandId_I; } set { _DemandId_I = value; } }
    public int NoOfBooks { get { return _NoOfBooks; } set { _NoOfBooks = value; } }
    public int DemandTypeId_I { get { return _DemandTypeId_I; } set { _DemandTypeId_I = value; } }
    public string AcYearId_V { get { return _AcYearId_V; } set { _AcYearId_V = value; } }
    public int TitleId_I { get { return _TitleId_I; } set { _TitleId_I = value; } }
    public int UserId { get { return _UserId; } set { _UserId = value; } }
    public int blockId { get { return _blockId; } set { _blockId = value; } }
    public int IsconnOpen { get; set; }
    public int DepoId { get { return _DepoId; } set { _DepoId = value; } }
    public int SchemeID { get { return _SchemeID; } set { _SchemeID = value; } }
    public int DistrictId { get { return _DistrictId; } set { _DistrictId = value; } }
    public int IsOpenMktDemand { get { return _IsOpenMktDemand; } set { _IsOpenMktDemand = value; } }
    public string EntryDate { get { return _EntryDate; } set { _EntryDate = value; } }
    public string LetterDate { get { return _LetterDate; } set { _LetterDate = value; } }
    public string LetterNo { get { return _LetterNo; } set { _LetterNo = value; } }

    public MySqlConnection moSqlConnection;
    public MySqlCommand moSqlCommand;
    public MySqlDataReader moSqlDataReader;
    public MySqlTransaction moSqlTransaction;
    public MySqlDataAdapter moSqlDataAdapter;
    public DataSet moDataSet;
    public DBClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void execute(String fsSQL, SQLType foSQLType)
    {
        //moSqlCommand = new SqlCommand(fsSQL, moSqlConnection, moSqlTransaction);
        moSqlCommand = new MySqlCommand(fsSQL, moSqlConnection);
        moSqlCommand.CommandTimeout = 240;
        if (foSQLType == SQLType.IS_PROC)
            moSqlCommand.CommandType = CommandType.StoredProcedure;
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
    public void addParam(String fsParameterName, MySqlDbType foSqlDbType, object foValue, SqlDirection foSqlDirection)
    {
        MySqlParameter loSqlParameter = new MySqlParameter();
        loSqlParameter.ParameterName = fsParameterName;
        loSqlParameter.MySqlDbType = foSqlDbType;
        if (foSqlDirection == SqlDirection.IN)
            loSqlParameter.Direction = ParameterDirection.Input;
        else if (foSqlDirection == SqlDirection.OUT)
            loSqlParameter.Direction = ParameterDirection.Output;
        loSqlParameter.Value = foValue;
        moSqlCommand.Parameters.Add(loSqlParameter);
    }

    public void addParam(String fsParameterName, MySqlDbType foSqlDbType, SqlDirection foSqlDirection)
    {
        MySqlParameter loSqlParameter = new MySqlParameter();
        loSqlParameter.ParameterName = fsParameterName;
        loSqlParameter.MySqlDbType = foSqlDbType;
        loSqlParameter.Size = 10;

        if (foSqlDirection == SqlDirection.IN)
            loSqlParameter.Direction = ParameterDirection.Input;
        else if (foSqlDirection == SqlDirection.OUT)
            loSqlParameter.Direction = ParameterDirection.Output;

        moSqlCommand.Parameters.Add(loSqlParameter);
    }

    public void addParam(String fsParameterName, MySqlDbType foSqlDbType, SqlDirection foSqlDirection, int fiLength)
    {
        MySqlParameter loSqlParameter = new MySqlParameter();
        loSqlParameter.ParameterName = fsParameterName;
        loSqlParameter.MySqlDbType = foSqlDbType;
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
        MySqlParameter loSqlParameter = moSqlCommand.Parameters.AddWithValue(fsParameterName, foValue);
        if (foSqlDirection == SqlDirection.IN)
            loSqlParameter.Direction = ParameterDirection.Input;
        else if (foSqlDirection == SqlDirection.OUT)
            loSqlParameter.Direction = ParameterDirection.Output;
    }

    public void addParam(String fsParameterName, object foValue)
    {
        addParam(fsParameterName, foValue, SqlDirection.IN);
    }

    public void addParam(MySqlParameter foSqlParameter)
    {
        moSqlCommand.Parameters.Add(foSqlParameter);
    }
    public int InsertUpdate()
    {
        execute("USP_DIS018_SaveTextBookDemand", SQLType.IS_PROC);
        addParam("mDemandId", DemandId_I);
        addParam("mNoOfBooks", NoOfBooks);
        addParam("mDemandTypeId", DemandTypeId_I);
        addParam("mAcYearId", AcYearId_V);
        addParam("mTitleId", TitleId_I);
        addParam("mUserId", UserId);
        addParam("mblockId", blockId);
        addParam("mSchemeID", SchemeID);
        addParam("mDepoId", DepoId);
        addParam("mDistrictId", DistrictId);
        addParam("mIsOpenMktDemand", IsOpenMktDemand);
        addParam("mEntryDate", EntryDate);
        addParam("mLetterNo", LetterNo);
        addParam("mLetterDate", LetterDate);
        int result = executeMyQuery();
        return result;
    }
    public void ConnectionOpen()
    {
        moSqlCommand = new MySqlCommand();
        moSqlConnection = new MySqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        moSqlCommand.Connection = moSqlConnection;
        if (moSqlConnection.State == ConnectionState.Closed)
        {
            moSqlConnection.Open();
        }
    }
    public void ConnectionClose()
    {
        if (moSqlConnection.State == ConnectionState.Open)
        {
            moSqlConnection.Close();
            moSqlConnection.Dispose();
            MySqlConnection.ClearPool(moSqlConnection);
        }
    }
    public int executeMyQuery()
    {
        try
        {
            int result = moSqlCommand.ExecuteNonQuery();
            return result;
        }
        catch (Exception ex)
        {
            rollBackTransaction();
            throw ex;
        }
    }
    public void rollBackTransaction()
    {
        try
        {
            if (moSqlTransaction != null)
                moSqlTransaction.Rollback();
        }
        catch { }
    }
}