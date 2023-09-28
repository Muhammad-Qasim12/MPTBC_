using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer
{
  public class MDDashboard 
    {
     
        public int InsertUpdate()
        {
            throw new NotImplementedException();
        }


       

        public System.Data.DataTable Select(int ID)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("MD_Daskbord", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("id", ID);
            return obDBAccess.records1();
        
        }
        public System.Data.DataTable Demand(string ID)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("MD_Daskbord", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("id", ID);
            return obDBAccess.records1();

        }
        public System.Data.DataTable VitranNirdesh(string sessionYear, int DepotID)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("DTP_GetDistributionOrder", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("sessionYear", sessionYear);
            obDBAccess.addParam("DepotID", DepotID);
            return obDBAccess.records1();

        }
        public System.Data.DataTable OpenMarketDemand(string sessionYear, int DepotID)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USPRptOpenMarketDemand", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("sessionID", sessionYear);
            obDBAccess.addParam("DepoID", DepotID);
            return obDBAccess.records1();

        }
        public System.Data.DataTable DayBook(DateTime day, string DUserID)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_GetdayReprot", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("dated", day);
            obDBAccess.addParam("DUserID", DUserID);
            return obDBAccess.records1();

        }
      
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
