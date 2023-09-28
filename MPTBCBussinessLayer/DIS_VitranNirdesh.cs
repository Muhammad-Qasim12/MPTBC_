using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
    public class DIS_VitranNirdesh : ICommon
    {
        string
                    _AcYear,
                    _BundleNoFrom,
                    _BundleNoTo,
                    _BookNumberFrom,
                    _BookNumberTo,
                    _Remark,_DemandType,
                    _OrderNo;

        int
            _PrinterID,
            _DepotID,
            _TitleID,
            _BookType,
            _GroupID,
            _NoOfBooks,
            _BooksPerBundle,
            _BooksPerGaddi,

            _TotalBundels;
        DateTime _OrderDate;


        public string AcYear { get { return _AcYear; } set { _AcYear = value; } }
        public string BundleNoFrom { get { return _BundleNoFrom; } set { _BundleNoFrom = value; } }
        public string BundleNoTo { get { return _BundleNoTo; } set { _BundleNoTo = value; } }
        public string BookNumberFrom { get { return _BookNumberFrom; } set { _BookNumberFrom = value; } }
        public string BookNumberTo { get { return _BookNumberTo; } set { _BookNumberTo = value; } }
        public string Remark { get { return _Remark; } set { _Remark = value; } }
        public string OrderNo { get { return _OrderNo; } set { _OrderNo = value; } }


        public int PrinterID { get { return _PrinterID; } set { _PrinterID = value; } }
        public int DepotID { get { return _DepotID; } set { _DepotID = value; } }
        public int TitleID { get { return _TitleID; } set { _TitleID = value; } }
        public int BookType { get { return _BookType; } set { _BookType = value; } }
        public int GroupID { get { return _GroupID; } set { _GroupID = value; } }
        public int NoOfBooks { get { return _NoOfBooks; } set { _NoOfBooks = value; } }
        public int BooksPerBundle { get { return _BooksPerBundle; } set { _BooksPerBundle = value; } }
        public int BooksPerGaddi { get { return _BooksPerGaddi; } set { _BooksPerGaddi = value; } }
        public int TotalBundels { get { return _TotalBundels; } set { _TotalBundels = value; } }

        public DateTime OrderDate { get { return _OrderDate; } set { _OrderDate = value; } }

        public string DemandType { get { return _DemandType; } set { _DemandType = value; } }


        public int InsertUpdate()
        {
            int i = 0;
            DBAccess obDbaccess = new DBAccess();

            try
            {
                obDbaccess.execute("USP_DIS_VitranNirdeshSaveUpdate", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mAcYear", AcYear);
                obDbaccess.addParam("mPrinterID", PrinterID);
                obDbaccess.addParam("mDepotID", DepotID);
                obDbaccess.addParam("mTitleID", TitleID);
                obDbaccess.addParam("mBookType", BookType);
                obDbaccess.addParam("mGroupID", GroupID);
                obDbaccess.addParam("mNoOfBooks", NoOfBooks);
                obDbaccess.addParam("mBooksPerBundle", BooksPerBundle);
                obDbaccess.addParam("mBooksPerGaddi", BooksPerGaddi);
                obDbaccess.addParam("mBookNumberFrom", BookNumberFrom);
                obDbaccess.addParam("mBookNumberTo", BookNumberTo);
                obDbaccess.addParam("mTotalBundels", TotalBundels);
                obDbaccess.addParam("mBundleNoFrom", BundleNoFrom);
                obDbaccess.addParam("mBundleNoTo", BundleNoTo);
                obDbaccess.addParam("mRemark", Remark);
                obDbaccess.addParam("mOrderNo", OrderNo);
                obDbaccess.addParam("mOrderDate", OrderDate);
                obDbaccess.addParam("DemandTypea", DemandType);
                i = obDbaccess.executeMyQuery();

            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return i;
        }

        public System.Data.DataSet Select()
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
