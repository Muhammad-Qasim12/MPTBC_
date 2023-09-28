using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer
{
   public  class Building001_RPT001AvasMaster:ICommon 
    {

       // strat   
      string 
          _Zone_V,
          _PayScale_V,
          _AvasType_V,
          _AvasNo_V,
          _WardNo_V,
          _AvasType
          ;

      int _AvasMasterTrno_I,
          _Flag,
          _GatividhiBhavanTrno_I,
          _AllotmentStatus_I,
          _AvasVistritTrno_I;

      DateTime _FromDate,
               _ToDate;

      public string Zone_V { get { return _Zone_V; } set { _Zone_V = value; } }
      public string PayScale_V { get { return _PayScale_V; } set { _PayScale_V = value; } }
      public string AvasType_V { get { return _AvasType_V; } set { _AvasType_V = value; } }

      public string AvasNo_V { get { return _AvasNo_V; } set { _AvasNo_V = value; } }
     
      public DateTime FromDate { get { return _FromDate; } set { _FromDate = value; } }
      public DateTime ToDate { get { return _ToDate; } set { _ToDate = value; } }
     

      public int AvasMasterTrno_I { get { return _AvasMasterTrno_I; } set { _AvasMasterTrno_I = value; } }
      public int Flag { get { return _Flag; } set { _Flag = value; } }
      public int GatividhiBhavanTrno_I { get { return _GatividhiBhavanTrno_I; } set { _GatividhiBhavanTrno_I = value; } }
     
      public int AllotmentStatus_I { get { return _AllotmentStatus_I; } set { _AllotmentStatus_I = value; } }
      public int AvasVistritTrno_I { get { return _AvasVistritTrno_I; } set { _AvasVistritTrno_I = value; } }

      public string WardNo_V { get { return _WardNo_V; } set { _WardNo_V = value; } }
      public string AvasType { get { return _AvasType; } set { _AvasType = value; } }
     

     public DataSet  LoadAvasReport()
      {
          DataSet ds = new DataSet();
          DBAccess obDbaccess = new DBAccess();

          try
          {
              obDbaccess.execute("USP_Building001_RPTAvasMaster", DBAccess.SQLType.IS_PROC);

              obDbaccess.addParam("mAvasMasterTrno_I", AvasMasterTrno_I);
              obDbaccess.addParam("mAvasType_V", AvasType_V);
              obDbaccess.addParam("mZone_V", Zone_V);
              obDbaccess.addParam("mPayScale_V", PayScale_V);


              ds = obDbaccess.records();
          }

          catch (Exception ex) { }
          finally { obDbaccess = null; }

          return ds;

      }



     public DataSet LoadOtherAvasReport()
     {
         DataSet ds = new DataSet();
         DBAccess obDbaccess = new DBAccess();

         try
         {
             obDbaccess.execute("USP_Building001_RPTOtherHouse", DBAccess.SQLType.IS_PROC);



             ds = obDbaccess.records();
         }

         catch (Exception ex) { }
         finally { obDbaccess = null; }

         return ds;

     }




       public DataSet FillAllFields()
       {
           DataSet ds = new DataSet();
           DBAccess obDbaccess = new DBAccess();

           try
           {
               obDbaccess.execute("USP_Building001_RPTAvas", DBAccess.SQLType.IS_PROC);
               obDbaccess.addParam("mZone_V", Zone_V);
               obDbaccess.addParam("mPayScale_V", PayScale_V);
               obDbaccess.addParam("mAvasType_V", AvasType_V);
               obDbaccess.addParam("mAvasMasterTrno_I", AvasMasterTrno_I);
               obDbaccess.addParam("Flag", Flag);


               ds = obDbaccess.records();
           }

           catch (Exception ex) { }
           finally { obDbaccess = null; }

           return ds;

       }
       

       public DataSet LoadBhugtanReport()
       {
           DataSet ds = new DataSet();
           DBAccess obDbaccess = new DBAccess();

           try
           {
               obDbaccess.execute("USP_Building001_RPTBhugtan", DBAccess.SQLType.IS_PROC);

               obDbaccess.addParam("mGatividhiBhavanTrno_I", GatividhiBhavanTrno_I);


               ds = obDbaccess.records();
           }

           catch (Exception ex) { }
           finally { obDbaccess = null; }

           return ds;
       }

       public DataSet LoadAvantanReport()
       {
           DataSet ds = new DataSet();
           DBAccess obDbaccess = new DBAccess();

           try
           {



               obDbaccess.execute("USP_Building001_RPTAvantan", DBAccess.SQLType.IS_PROC);
               obDbaccess.addParam("mAvasMasterTrno_I", AvasMasterTrno_I);
               obDbaccess.addParam("mZone_V", Zone_V);
               obDbaccess.addParam("mAvasType_V", AvasType_V);
               obDbaccess.addParam("mPayScale_V", PayScale_V);

               ds = obDbaccess.records();
           }

           catch (Exception ex) { }
           finally { obDbaccess = null; }

           return ds;
       }

        public DataSet LoadAvasNoLoad()
       {
           DataSet ds = new DataSet();
           DBAccess obDbaccess = new DBAccess();

           try
           {
               obDbaccess.execute("USP_Building001_RPTAvasNoLoad", DBAccess.SQLType.IS_PROC);

              ds = obDbaccess.records();
           }

           catch (Exception ex) { }
           finally { obDbaccess = null; }

           return ds;
       }


        public DataSet LoadAvasNoWARDZONELoad()
        {
            DataSet ds = new DataSet();
            DBAccess obDbaccess = new DBAccess();

            try
            {
                obDbaccess.execute("USP_Building001_RPTAvasWardZonewise", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mAvasType_V", AvasType_V);
                obDbaccess.addParam("mZone_V", Zone_V);
                obDbaccess.addParam("mWardNo_V", WardNo_V);
                obDbaccess.addParam("mAllotmentStatus_I", AllotmentStatus_I);
                obDbaccess.addParam("mAvasMasterTrno_I", AvasMasterTrno_I);
               
                ds = obDbaccess.records();
            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }

            return ds;
        }
       



        #region ICommon Members

        public int InsertUpdate()
        {
            throw new NotImplementedException();
        }

        public System.Data.DataSet Select()
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
