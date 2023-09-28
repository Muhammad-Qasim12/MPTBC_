using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer.Academic
{
    public class PrinterProof : ICommon
    {
        public int QueryType { get; set; }
        public int ParameterValue { get; set; }
        public int ParameterValue2 { get; set; }
        public string StringParameter { get; set; }
        private int _Printer_RedID_I;

        public int PrinterProofVerificationTrno_I { get; set; }
        public int Printer_RedID_I { get { return _Printer_RedID_I; } set { _Printer_RedID_I = value; } }
        public int WorkOrderID_I { get; set; }
        public int TitleID_I { get; set; }
        public string CDProofLetterNo_V { get; set; }
        public string CDProofLetterDate_D { get; set; }
        public string CDProofRetLetterNo_V { get; set; }
        public string CDProofRetLetterDate_D { get; set; }
        public string DepSendProofLetterNo_V { get; set; }
        public string DepSendProofLetterDate_D { get; set; }
        public string ProofAcceptLetterNo_V { get; set; }
        public string ProofAcceptLetterDate_D { get; set; }

        public string PrintOrderLetterNo_V { get; set; }
        public string PrintOrderLetterDate_D { get; set; }
        public string RetProofLetterNo_V { get; set; }
        public string RetProofLetterDate_D { get; set; }

     
        public int PrinterProofVerificationOtherDetailsTrno_I { get; set; }
        public int StatusTrno_I { get; set; }
        public string   Remark_V { get; set; }
        public string OtherDetailLetterNo_V { get; set; }
        public string OtherDetailLetterDate_D { get; set; } 

        public int TransID { get; set; }

        DBAccess obDBAccess;

        #region ICommon Members

        public int InsertUpdate()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACD005_PrinterProofSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPrinterProofVerificationTrno_I", PrinterProofVerificationTrno_I);
            obDBAccess.addParam("mWorkOrderID_I", WorkOrderID_I);
            obDBAccess.addParam("mTitleID_I", TitleID_I);
            obDBAccess.addParam("mCDProofLetterNo_V", CDProofLetterNo_V);
            obDBAccess.addParam("mCDProofLetterDate_D", CDProofLetterDate_D);
            obDBAccess.addParam("mCDProofRetLetterNo_V", CDProofRetLetterNo_V);
            obDBAccess.addParam("mCDProofRetLetterDate_D", CDProofRetLetterDate_D);
            obDBAccess.addParam("mDepSendProofLetterNo_V", DepSendProofLetterNo_V);
            obDBAccess.addParam("mDepSendProofLetterDate_D", DepSendProofLetterDate_D);
            obDBAccess.addParam("mProofAcceptLetterNo_V", ProofAcceptLetterNo_V);
            obDBAccess.addParam("mProofAcceptLetterDate_D", ProofAcceptLetterDate_D);

            obDBAccess.addParam("mPrintOrderLetterNo_V", PrintOrderLetterNo_V);
            obDBAccess.addParam("mPrintOrderLetterDate_D", PrintOrderLetterDate_D);
            obDBAccess.addParam("mRetProofLetterNo_V", RetProofLetterNo_V);
            obDBAccess.addParam("mRetProofLetterDate_D", RetProofLetterDate_D);

            obDBAccess.addParam("mPrinterProofVerificationOtherDetailsTrno_I", PrinterProofVerificationOtherDetailsTrno_I);
            obDBAccess.addParam("mStatusTrno_I", StatusTrno_I);
            obDBAccess.addParam("mOtherDetailLetterNo_V", OtherDetailLetterNo_V);
            obDBAccess.addParam("mOtherDetailLetterDate_D", OtherDetailLetterDate_D);
            obDBAccess.addParam("mRemark_V", Remark_V);



            obDBAccess.addParam("mTransID", TransID);


            object result = obDBAccess.executeMyScalar();
            if (result != null)
            {
                return int.Parse(result.ToString());
            }
            else if (result == null && TransID == -1)
                return -1;
            else
                return 0;
        }

        public System.Data.DataSet Select()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACD005_PrinterProofSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mQueryType", QueryType);
            obDBAccess.addParam("mStringParameter", StringParameter);
            obDBAccess.addParam("mParameterValue", ParameterValue);
            obDBAccess.addParam("mParameterValue2", ParameterValue2);
            return obDBAccess.records();
        }

        public System.Data.DataSet FillRPT()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACD005_PrinterProofLoadRPT", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mQueryType", QueryType);
            obDBAccess.addParam("mPrinter_RedID_I", Printer_RedID_I);
            obDBAccess.addParam("mWorkOrderID_I", WorkOrderID_I);
            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
