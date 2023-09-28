using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer.AcademicB
{
    public class DemandCreation : ICommon
    {
        public int QueryType { get; set; }
        public int ParameterValue { get; set; }
        public int ParameterValue2 { get; set; }


        public int DemandID_I { get; set; }
        public int SubTitleID_I { get; set; }
        public int TotalQty_I { get; set; }
        public int TotalPages_I { get; set; }
        public double Qty_PriPaper { get; set; }
        public double Qty_CoverPaper { get; set; }
        public int DemandDetailsID_I { get; set; }

        public int DisDemandID_I { get; set; }
        public int TotalItems_I { get; set; }
        public int DepoID_I { get; set; }

        public int DemandSpecificationID_I { get; set; }
        public string ItemSize_V { get; set; }
        public string Binding_V { get; set; }
        public int PrintingPaperTypeID_I { get; set; }
        public int PrintingPaperGSM_I { get; set; }
        public int CoverPaperTypeID_I { get; set; }
        public int CoverPaperGSM_I { get; set; }
        public string TextColor_V { get; set; }
        public string CoverColor1n4_V { get; set; }
        public string DemandGenrationDate_D { get; set; }
        public string CoverColor2n3_V { get; set; }
        public int TransID { get; set; }


        DBAccess obDBAccess = new DBAccess();
        #region ICommon Members

        public int InsertUpdate()
        {
            obDBAccess.execute("USP_ACB006_DemandCreationSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDemandID_I", DemandID_I);
            obDBAccess.addParam("mSubTitleID_I", SubTitleID_I);
            obDBAccess.addParam("mTotalQty_I", TotalQty_I);
            obDBAccess.addParam("mTotalPages_I", TotalPages_I);
            obDBAccess.addParam("mQty_PriPaper", Qty_PriPaper);
            obDBAccess.addParam("mQty_CoverPaper", Qty_CoverPaper);
            obDBAccess.addParam("mDemandGenrationDate_D", DemandGenrationDate_D);
            obDBAccess.addParam("mDemandDetailsID_I", DemandDetailsID_I);
            obDBAccess.addParam("mDisDemandID_I", DisDemandID_I);
            obDBAccess.addParam("mTotalItems_I", TotalItems_I);

            obDBAccess.addParam("mDepoID_I", DepoID_I);
            obDBAccess.addParam("mDemandSpecificationID_I", DemandSpecificationID_I);
            obDBAccess.addParam("mItemSize_V", ItemSize_V);
            obDBAccess.addParam("mBinding_V", Binding_V);
            obDBAccess.addParam("mPrintingPaperTypeID_I", PrintingPaperTypeID_I);

            obDBAccess.addParam("mPrintingPaperGSM_I", PrintingPaperGSM_I);
            obDBAccess.addParam("mCoverPaperTypeID_I", CoverPaperTypeID_I);
            obDBAccess.addParam("mCoverPaperGSM_I", CoverPaperGSM_I);
            obDBAccess.addParam("mTextColor_V", TextColor_V);
            obDBAccess.addParam("mCoverColor1n4_V", CoverColor1n4_V);
            obDBAccess.addParam("mCoverColor2n3_V", CoverColor2n3_V);
            obDBAccess.addParam("mTransID", TransID);

            object result = obDBAccess.executeMyScalar();
            return int.Parse(result.ToString());
        }

        public System.Data.DataSet Select()
        {
            obDBAccess.execute("USP_ACB006_DemandCreationSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mQueryType", QueryType);
            obDBAccess.addParam("mParameterValue", ParameterValue);
            obDBAccess.addParam("mParameterValue2", ParameterValue2);
            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
