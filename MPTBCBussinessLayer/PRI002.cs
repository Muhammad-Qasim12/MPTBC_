using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web; 
 
namespace MPTBCBussinessLayer
{
    public class PRI002 : ICommon
    {
        private string _chvComponentname_V, _chvRemark_V, _strQry;
        private int _intOrderNo_I, _intTrno_I, _LID, _intUserTrnoNo_I;



        public string chvComponentname_V
        {
            get { return _chvComponentname_V; }
            set { _chvComponentname_V = value; }
        }

        public int intTrno_I
        {
            get { return _intTrno_I; }
            set { _intTrno_I = value; }
        }

        public int LID
        {
            get { return _LID; }
            set { _LID = value; }
        }
        public int intOrderNo_I
        {
            get { return _intOrderNo_I; }
            set { _intOrderNo_I = value; }
        }

        public int intUserTrnoNo_I
        {
            get { return _intUserTrnoNo_I; }
            set { _intUserTrnoNo_I = value; }
        }
        public String  strQry
        {
            get { return _strQry; }
            set { _strQry = value; }
        }

       

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();

            try
            {
                obDBAccess.execute("USP_PRI002_projectmanagementcomponentmasterload", DBAccess.SQLType.IS_PROC);
                obDBAccess.addParam("mTimeLineCompID_I", intTrno_I);
               
            }
            catch (Exception feException)
            {
                new Exception(feException.Message);
            }
            return obDBAccess.records();
        }

        public System.Data.DataSet SelectSql()
        {
            DBAccess obDBAccess = new DBAccess();

            try
            {
                obDBAccess.execute("USP_PRI_DBmaster", DBAccess.SQLType.IS_PROC);
                obDBAccess.addParam("qry", strQry);

            }
            catch (Exception feException)
            {
                new Exception(feException.Message);
            }
            return obDBAccess.records();
        }

        public int InsertSql()
        {
            DBAccess obDBAccess = new DBAccess();

            try
            {


                
                    obDBAccess.execute("USP_PRI_DBmaster", DBAccess.SQLType.IS_PROC);
                    obDBAccess.addParam("qry", strQry);
                    int result = obDBAccess.executeMyQuery();
                    return result;
            }

            catch (Exception feException)
            {
                throw new Exception(feException.Message);
            }
            finally
            {
                obDBAccess.releasedCommand();

            }
           
        }
        public int ShowData()
        {
            DBAccess obDBAccess = new DBAccess();
            DataSet DS = new DataSet();
            try
            {
                DS = Select();
                intTrno_I = Convert.ToInt32(Convert.ToString(DS.Tables[0].Rows[0]["TimeLineCompID_I"]));
                intOrderNo_I = Convert.ToInt32(Convert.ToString(DS.Tables[0].Rows[0]["OrderNo_I"]));
                chvComponentname_V = Convert.ToString(Convert.ToString(DS.Tables[0].Rows[0]["TimeLineCompName_V"]));
            }
            catch (Exception feException)
            {
                new Exception(feException.Message);
            }
            return 0;
        }
        

        
        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            
            try
            {
                LID = 0;
                if (intTrno_I != 0)
                {
                    LID = intTrno_I;
                    //obDBAccess.AuditTrailInsert("PRI_projectmanagementcomponentmaster", LID, "TimeLineCompID_I", "U", intUserTrnoNo_I);
                }

                obDBAccess.execute("USP_PRI002_projectmanagementcomponentmastersave", DBAccess.SQLType.IS_PROC);
                obDBAccess.addParam("mTimeLineCompID_I", intTrno_I);
                obDBAccess.addParam("mTimeLineCompName_V", chvComponentname_V);
                obDBAccess.addParam("mOrderNo_I", intOrderNo_I);                 
                obDBAccess.addParam("LID", SqlDbType.Int ,  LID, DBAccess.SqlDirection.OUT );                   
                int result  = obDBAccess.executeMyQuery();
                LID= Convert.ToInt32 ( obDBAccess.getParameter(3).ToString());
                if (intTrno_I == 0)
                {
                    //obDBAccess.AuditTrailInsert("PRI_projectmanagementcomponentmaster", LID, "TimeLineCompID_I", "N", intUserTrnoNo_I);
                }
                
                return LID;
            }

            catch (Exception feException)
            {
                throw new Exception(feException.Message);
            }
            finally
            {
               obDBAccess.releasedCommand();

            }

        }

        public int CheckDuplicate(string strTableName, string strField, string strValue, double dblOfficeTrno, string strPrimaryKeyField, double tblTrno)
        { DBAccess obDBAccess = new DBAccess();
            try
            {
               
                 
                DataSet loDataset = new DataSet();
                obDBAccess.execute("USP_CheckDuplicate", DBAccess.SQLType.IS_PROC);
                obDBAccess.addParam("nvchrTableName",  strTableName);
                obDBAccess.addParam("nvchrFieldName", strField);
                obDBAccess.addParam("nvchrValue",  strValue);
                obDBAccess.addParam("nvchrPrimaryKeyField", strPrimaryKeyField);
                int intSuccess = obDBAccess.executeMyQuery();
                return intSuccess;
            }

            catch (Exception feException)
            {
                
                throw new Exception(feException.Message);
            }
            finally
            {
               obDBAccess.releasedCommand();

            }

        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            try
            {
                obDBAccess.execute("USP_PRI002_projectmanagementcomponentmasterDelete", DBAccess.SQLType.IS_PROC);
                obDBAccess.addParam("mTimeLineCompID_I", intTrno_I);
                int result = obDBAccess.executeMyQuery();
                return result;
               // throw new NotImplementedException();
            }
            catch (Exception feException)
            {
                throw new Exception(feException.Message);
            }
            finally
            {
                obDBAccess.releasedCommand();

            }

        }   

      

        
    }
}
