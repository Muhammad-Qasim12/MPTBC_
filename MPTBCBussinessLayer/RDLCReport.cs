using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
    public class RDLCReport
    {
        public System.Data.DataTable DataShow(string mAcYear, int mDemandTypeId)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIS_RPT_Demand", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mAcYear", mAcYear);
            obDBAccess.addParam("mDemandTypeId", mDemandTypeId);
            
            return obDBAccess.records1();
        }
    }

}
