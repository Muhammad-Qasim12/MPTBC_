using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer.Admin
{
    public class SubMenuForm : ICommon
    {
        DBAccess obDBAccess = new DBAccess();
        public int QueryType { get; set; }
        public int ParameterValue { get; set; }




        public int InsertUpdate()
        {
            throw new NotImplementedException();
        }

        public System.Data.DataSet Select()
        {
            obDBAccess.execute("USP_ADM0041_SubMenuFormSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mQueryType", QueryType);
            obDBAccess.addParam("mParameterValue", ParameterValue);
            return obDBAccess.records();

        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
