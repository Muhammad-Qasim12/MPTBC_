using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer.DistributionB
{
   public  class DistributionOrder: ICommon
    {
        public int QueryType { get; set; }
        public int ParameterValue { get; set; }

        DBAccess obDBAccess = new DBAccess();


        public int InsertUpdate()
        {
            throw new NotImplementedException();
        }

        public System.Data.DataSet Select()
        {
            obDBAccess.execute("USP_DIB010_DistributionOrderSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mType", QueryType);
            obDBAccess.addParam("mParameterValue", ParameterValue);
            //obDBAccess.addParam("mStringParameterValue", StringParameterValue);

            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
