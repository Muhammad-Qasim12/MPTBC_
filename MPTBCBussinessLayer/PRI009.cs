using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Data;

using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace MPTBCBussinessLayer
{
    public class PRI009 : ICommon
    {


        private string _acyear;
        private int _dtype, _intTrno_I, _LID, _intUserTrnoNo_I, _intClasstrno_I, _intdepotrno_I, _intmedtrno_I;



        public string acyear
        {
            get { return _acyear; }
            set { _acyear = value; }
        }

        public int dtype
        {
            get { return _dtype; }
            set { _dtype = value; }
        }

        public int LID
        {
            get { return _LID; }
            set { _LID = value; }
        }
       

        public int intUserTrnoNo_I
        {
            get { return _intUserTrnoNo_I; }
            set { _intUserTrnoNo_I = value; }
        }

        public int intdepotrno_I
        {
            get { return _intdepotrno_I; }
            set { _intdepotrno_I = value; }
        }


        public int intClasstrno_I
        {
            get { return _intClasstrno_I; }
            set { _intClasstrno_I = value; }
        }


        public int intmedtrno_I
        {
            get { return _intmedtrno_I; }
            set { _intmedtrno_I = value; }
        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();

            try
            {
                obDBAccess.execute("USP_PRI009_GetDemandFormDistribution", DBAccess.SQLType.IS_PROC);
                obDBAccess.addParam("dtype", dtype);
                obDBAccess.addParam("macyear", acyear);
                obDBAccess.addParam("mediumtype", intdepotrno_I);
                // _intUserTrnoNo_I for MediumMaster 
                obDBAccess.addParam("classid", intClasstrno_I);
                obDBAccess.addParam("depoid", 0);
               
            }
            catch (Exception feException)
            {
                new Exception(feException.Message);
            }
            return obDBAccess.records();
        }


        public int ShowData()
        {
            DBAccess obDBAccess = new DBAccess();
            DataSet DS = new DataSet();
            try
            {
                DS = Select();
                //intTrno_I = Convert.ToInt32(Convert.ToString(DS.Tables[0].Rows[0]["TimeLineCompID_I"]));
                //intOrderNo_I = Convert.ToInt32(Convert.ToString(DS.Tables[0].Rows[0]["OrderNo_I"]));
                //chvComponentname_V = Convert.ToString(Convert.ToString(DS.Tables[0].Rows[0]["TimeLineCompName_V"]));
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
            
            //try
            //{
            //    LID = 0;
            //    if (intTrno_I != 0)
            //    {
            //        LID = intTrno_I;
            //        obDBAccess.AuditTrailInsert("PRI_projectmanagementcomponentmaster", LID, "TimeLineCompID_I", "U", intUserTrnoNo_I);
            //    }

            //    obDBAccess.execute("USP_PRI002_projectmanagementcomponentmastersave", DBAccess.SQLType.IS_PROC);
            //    obDBAccess.addParam("mTimeLineCompID_I", intTrno_I);
            //    obDBAccess.addParam("mTimeLineCompName_V", chvComponentname_V);
            //    obDBAccess.addParam("mOrderNo_I", intOrderNo_I);                 
            //    obDBAccess.addParam("LID", MySql.Data.MySqlClient.MySqlDbType.Int32 ,  LID, DBAccess.SqlDirection.OUT );                   
            //    int result  = obDBAccess.executeMyQuery();
            //    LID= Convert.ToInt32 ( obDBAccess.getParameter(3).ToString());
            //    if (intTrno_I == 0)
            //    {
            //        obDBAccess.AuditTrailInsert("PRI_projectmanagementcomponentmaster", LID, "TimeLineCompID_I", "N", intUserTrnoNo_I);
            //    }
                
            //    return LID;
            //}

            //catch (Exception feException)
            //{
            //    throw new Exception(feException.Message);
            //}
            //finally
            //{
            //   obDBAccess.releasedCommand();

            //}
            return 0;
        }

        public int Delete(int id)
        {
            //DBAccess obDBAccess = new DBAccess();
            //try
            //{
            //    obDBAccess.execute("USP_PRI002_projectmanagementcomponentmasterDelete", DBAccess.SQLType.IS_PROC);
            //    obDBAccess.addParam("mTimeLineCompID_I", intTrno_I);
            //    int result = obDBAccess.executeMyQuery();
            //    return result;
            //   // throw new NotImplementedException();
            //}
            //catch (Exception feException)
            //{
            //    throw new Exception(feException.Message);
            //}
            //finally
            //{
            //    obDBAccess.releasedCommand();

            //}
            return 0;
        }   

      

        
  
    }
}
