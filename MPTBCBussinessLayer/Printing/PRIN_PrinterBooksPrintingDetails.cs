using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer
{
   public  class PRIN_PrinterBooksPrintingDetails : ICommon
    {
        int     _PrinterBookDetailTrno_I,
                _TitleTrno_I,
                _ClassTrno_I,
                _GroupTrno_I,
                _TitleTotalFormQty_I,
                _CompQuantity,
                _PenQuantity,
                _PrintingCover,
                _Gathering,
                _Stiching,
                _Finishing,
                _Numbering,
                _PrinterRegId;

        string  _CompFormFrom,
                _CompFormTo,

                _PenFrmFrom,
                _PenFrmTo;

        DateTime _Transdate_D;


        public int PrinterBookDetailTrno_I { get { return _PrinterBookDetailTrno_I; } set { _PrinterBookDetailTrno_I = value; } }
        public int TitleTrno_I { get { return _TitleTrno_I; } set { _TitleTrno_I = value; } }
        public int ClassTrno_I { get { return _ClassTrno_I; } set { _ClassTrno_I = value; } }
        public int GroupTrno_I { get { return _GroupTrno_I; } set { _GroupTrno_I = value; } }
        public int TitleTotalFormQty_I { get { return _TitleTotalFormQty_I; } set { _TitleTotalFormQty_I = value; } }
        public string CompFormFrom { get { return _CompFormFrom; } set { _CompFormFrom = value; } }
        public string CompFormTo { get { return _CompFormTo; } set { _CompFormTo = value; } }
        public int CompQuantity { get { return _CompQuantity; } set { _CompQuantity = value; } }
        public string PenFrmFrom { get { return _PenFrmFrom; } set { _PenFrmFrom = value; } }
        public string PenFrmTo { get { return _PenFrmTo; } set { _PenFrmTo = value; } }
        public int PenQuantity { get { return _PenQuantity; } set { _PenQuantity = value; } }
        public int PrintingCover { get { return _PrintingCover; } set { _PrintingCover = value; } }
        public int Gathering { get { return _Gathering; } set { _Gathering = value; } }
        public int Stiching { get { return _Stiching; } set { _Stiching = value; } }
        public int Finishing { get { return _Finishing; } set { _Finishing = value; } }
        public int Numbering { get { return _Numbering; } set { _Numbering = value; } }
        public int PrinterRegId { get { return _PrinterRegId; } set { _PrinterRegId = value; } }

        public DateTime  Transdate_D { get { return _Transdate_D; } set { _Transdate_D = value; } }


       



        #region ICommon Members

        public int InsertUpdate()
        {
            DBAccess obDbAccess = new DBAccess();
            int i = 0;


            obDbAccess.execute("USP_PRI012_PrinterBooksPrintingDetailsSaveUpdate", DBAccess.SQLType.IS_PROC);
            obDbAccess.addParam("mPrinterBookDetailTrno_I", PrinterBookDetailTrno_I);
            obDbAccess.addParam("mTitleTrno_I", TitleTrno_I);
            obDbAccess.addParam("mClassTrno_I", ClassTrno_I);
            obDbAccess.addParam("mGroupTrno_I", GroupTrno_I);
            obDbAccess.addParam("mTitleTotalFormQty_I", TitleTotalFormQty_I);
            obDbAccess.addParam("mCompFormFrom", CompFormFrom);
            obDbAccess.addParam("mCompFormTo", CompFormTo);
            obDbAccess.addParam("mCompQuantity", CompQuantity);
            obDbAccess.addParam("mPenFrmFrom", PenFrmFrom);
            obDbAccess.addParam("mPenFrmTo", PenFrmTo);
            obDbAccess.addParam("mPenQuantity", PenQuantity);
            obDbAccess.addParam("mPrintingCover", PrintingCover);
            obDbAccess.addParam("mGathering", Gathering);
            obDbAccess.addParam("mStiching", Stiching);
            obDbAccess.addParam("mFinishing", Finishing);
            obDbAccess.addParam("mNumbering", Numbering);
            obDbAccess.addParam("mPrinterRegId", PrinterRegId);
            obDbAccess.addParam("mTransdate_D", Transdate_D);

            i = obDbAccess.executeMyQuery();

            return i;

        }

        public System.Data.DataSet Select()
        {
            DBAccess obDbAccess = new DBAccess();
            DataSet ds = new DataSet();


            obDbAccess.execute("USP_PRI012_PrinterBooksPrintingDetailsLoad", DBAccess.SQLType.IS_PROC);
            obDbAccess.addParam("mPrinterRegId",PrinterRegId);
            obDbAccess.addParam("mTransdate_D", Transdate_D);
            ds = obDbAccess.records();

            return ds;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
