using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace MPTBCBussinessLayer
{
    public class TitleWiseSchemeMapping : ICommon
    {
        int _ClassTrno_I, _TitleID_I, _MappingTrno_I, _UserID_I;
        string _SchemeId_V, _Remark_V, _Classes;

        public int ClassTrno_I { get { return _ClassTrno_I; } set { _ClassTrno_I = value; } }
        public int TitleID_I { get { return _TitleID_I; } set { _TitleID_I = value; } }
        public int MappingTrno_I { get { return _MappingTrno_I; } set { _MappingTrno_I = value; } }
        public int UserID_I { get { return _UserID_I; } set { _UserID_I = value; } }

        public string SchemeId_V { get { return _SchemeId_V; } set { _SchemeId_V = value; } }
        public string Remark_V { get { return _Remark_V; } set { _Remark_V = value; } }
        public string Classes { get { return _Classes; } set { _Classes = value; } }



        public DataSet LoadClass()
        {
            DBAccess obDbAccess = new DBAccess();

            obDbAccess.execute("USP_ADM014_ClassMaster_Load", DBAccess.SQLType.IS_PROC);
            obDbAccess.addParam("id", ClassTrno_I);

            return obDbAccess.records();

        }


        public DataSet LoadTitle()
        {
            DBAccess obDbAccess = new DBAccess();

            obDbAccess.execute("USP_ADM015_TitleLoadClassWise", DBAccess.SQLType.IS_PROC);
            obDbAccess.addParam("mClassTrno_I", ClassTrno_I);

            return obDbAccess.records();

        }

        public DataSet LoadScheme()
        {
            DBAccess obDbAccess = new DBAccess();

            obDbAccess.execute("USP_ADM015_SchemeLoadClassWise", DBAccess.SQLType.IS_PROC);

            obDbAccess.addParam("mClasses",Classes);
            return obDbAccess.records();

        }


        // function to load title Class wise

        public DataSet LoadTitlesClassWise() 
        {
            DBAccess obDbAccess = new DBAccess();

            obDbAccess.execute("USP_ADM015_TitleWiseSchemeMappingClassWiseLoad", DBAccess.SQLType.IS_PROC);
            obDbAccess.addParam("mClassTrno_I", ClassTrno_I );

            return obDbAccess.records();
        
        }


        #region ICommon Members

        public int InsertUpdate()
        {

            DBAccess objDbaccess = new DBAccess();
            int i = 0;

            objDbaccess.execute("USP_ADM015_TitleWiseSchemeMappingSaveUpdate", DBAccess.SQLType.IS_PROC);

            //objDbaccess.addParam("mMappingTrno_I", MappingTrno_I);
            objDbaccess.addParam("mClassTrno_I", ClassTrno_I);
            objDbaccess.addParam("mTitleID_I", TitleID_I);
            objDbaccess.addParam("mSchemeId_V", SchemeId_V);
            objDbaccess.addParam("mUserID_I", UserID_I);

            objDbaccess.addParam("mRemark_V", Remark_V);

            i = objDbaccess.executeMyQuery();

            return i;

        }

        public DataSet Select()
        {
            DBAccess obDbAccess = new DBAccess();

            obDbAccess.execute("USP_ADM015_TitleWiseSchemeMappingLoad", DBAccess.SQLType.IS_PROC);
            obDbAccess.addParam("mTitleId_I", TitleID_I);

            return obDbAccess.records();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}