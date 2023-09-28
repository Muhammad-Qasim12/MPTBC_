using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
    public class TextbookDemand : ICommon
    {

        private int _DemandId_I;
        private int _NoOfBooks;
        private int _DemandTypeId_I;
        private string _AcYearId_V;
        private int _TitleId_I;
        private int _UserId;
        DateTime _EntryDate;
        int _DepoId;
        int _DistrictId;
        int _blockId;
        int _IsOpenMktDemand;
        int _ClassId;
        int _SchemeID;
        private string _LetterNo;
        private DateTime _LetterDate;

        private string _BlockNameHindi_V;

        public int DemandId_I { get { return _DemandId_I; } set { _DemandId_I = value; } }
        public int NoOfBooks { get { return _NoOfBooks; } set { _NoOfBooks = value; } }
        public int DemandTypeId_I { get { return _DemandTypeId_I; } set { _DemandTypeId_I = value; } }
        public string AcYearId_V { get { return _AcYearId_V; } set { _AcYearId_V = value; } }
        public int TitleId_I { get { return _TitleId_I; } set { _TitleId_I = value; } }
        public int UserId { get { return _UserId; } set { _UserId = value; } }
        public int blockId { get { return _blockId; } set { _blockId = value; } }
        public int IsconnOpen { get; set ; } 
        public int DepoId { get { return _DepoId; } set { _DepoId = value; } }
        public int SchemeID { get { return _SchemeID; } set { _SchemeID = value; } }
        public int DistrictId { get { return _DistrictId; } set { _DistrictId = value; } }
        public int IsOpenMktDemand { get { return _IsOpenMktDemand; } set { _IsOpenMktDemand = value; } }
        public DateTime EntryDate { get { return _EntryDate; } set { _EntryDate = value; } }
        public DateTime LetterDate { get { return _LetterDate; } set { _LetterDate = value; } }
        public string LetterNo { get { return _LetterNo; } set { _LetterNo = value; } }

        DBAccess obDBAccess = null;
        public int InsertUpdate()
        {

            if (obDBAccess == null)
            {
                obDBAccess = new DBAccess();
            }
            if (IsconnOpen == 1)
            {
                obDBAccess.closeConnection();
            }
            else
            {
                obDBAccess.execute("USP_DIS018_SaveTextBookDemand", DBAccess.SQLType.IS_PROC);

                obDBAccess.addParam("mDemandId", DemandId_I);
                obDBAccess.addParam("mNoOfBooks", NoOfBooks);
                obDBAccess.addParam("mDemandTypeId", DemandTypeId_I);
                obDBAccess.addParam("mAcYearId", AcYearId_V);
                obDBAccess.addParam("mTitleId", TitleId_I);
                obDBAccess.addParam("mUserId", UserId);
                obDBAccess.addParam("mblockId", blockId);
                obDBAccess.addParam("mSchemeID", SchemeID);

                obDBAccess.addParam("mDepoId", DepoId);
                obDBAccess.addParam("mDistrictId", DistrictId);
                obDBAccess.addParam("mIsOpenMktDemand", IsOpenMktDemand);
                obDBAccess.addParam("mEntryDate", EntryDate);
                obDBAccess.addParam("mLetterNo", LetterNo);
                obDBAccess.addParam("mLetterDate", LetterDate);

                int result = obDBAccess.executeMyQuery();
                return result;
            }
            return 0;
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





