using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer.Academic
{
    public class PrintOrder: ICommon
    {
        public int QueryType { get; set; }
        public int ParameterValue { get; set; }
        public string StringParameter { get; set; }

     
        public string LetterNo_V { get; set; }
        public string LetterDate_D { get; set; }
        public int Printer_RedID_I { get; set; }
        public int AcYearID_I { get; set; }
        public int WorkOrderID_I { get; set; }
        public int TitleID_I { get; set; }
        public int PrintOrderTrno_I { get; set; }
        public int TransID { get; set; }
        public string Remark_V { get; set; }


       

        DBAccess obDBAccess;
        #region ICommon Members

        public int InsertUpdate()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACD004_PrintOrderSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLetterNo_V", LetterNo_V);
            obDBAccess.addParam("mLetterDate_D", LetterDate_D);
            obDBAccess.addParam("mPrinter_RedID_I", Printer_RedID_I);
            obDBAccess.addParam("mAcYearID_I", AcYearID_I);
            obDBAccess.addParam("mWorkOrderID_I", WorkOrderID_I);
            obDBAccess.addParam("mTitleID_I", TitleID_I);
            obDBAccess.addParam("mRemark_V", Remark_V);
            obDBAccess.addParam("mPrintOrderTrno_I", PrintOrderTrno_I);
            obDBAccess.addParam("mTransID", TransID);
          

            object result = obDBAccess.executeMyScalar();
            return int.Parse(result.ToString());
           
        }

        public System.Data.DataSet Select()
        {

            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACD004_PrintOrderSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mQueryType", QueryType);
            obDBAccess.addParam("mStringParameter", StringParameter);
            obDBAccess.addParam("mParameterValue", ParameterValue);
          
            return obDBAccess.records();      


           
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
