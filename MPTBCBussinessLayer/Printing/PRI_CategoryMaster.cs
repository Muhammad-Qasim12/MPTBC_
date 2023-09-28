using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer
{
   public class PRI_CategoryMaster :ICommon
   {
       private Int32 _CatID_I, _ClassTrno_I;
       private string _CategoryNo_V;
       private string _ColorSchText_V;
       private string _ColorSchCoverPaper_V;
       private string _PrintingPaperInformation_V;
       private string _CoverPaperinformation_V;
       private string _Bindingdetail_V;

       public Int32 CatID_I { get { return _CatID_I; } set { _CatID_I = value; } }
       public int ClassTrno_I { get { return _ClassTrno_I; } set { _ClassTrno_I = value; } }


       public string CategoryNo_V { get { return _CategoryNo_V; } set { _CategoryNo_V = value; } }
       public string ColorSchText_V { get { return _ColorSchText_V; } set { _ColorSchText_V = value; } }
       public string ColorSchCoverPaper_V { get { return _ColorSchCoverPaper_V; } set { _ColorSchCoverPaper_V = value; } }
       public string PrintingPaperInformation_V { get { return _PrintingPaperInformation_V; } set { _PrintingPaperInformation_V = value; } }
       public string CoverPaperinformation_V { get { return _CoverPaperinformation_V; } set { _CoverPaperinformation_V = value; } }
       public string Bindingdetail_V { get { return _Bindingdetail_V; } set { _Bindingdetail_V = value; } }


       public int InsertUpdate()
       {
           DBAccess obDBAccess = new DBAccess();
           obDBAccess.execute("USP_PRI009_CategoryMasterSave", DBAccess.SQLType.IS_PROC);
           obDBAccess.addParam("mCatID_I", CatID_I);
           obDBAccess.addParam("mCategoryNo_V", CategoryNo_V);
           obDBAccess.addParam("mColorSchText_V", ColorSchText_V);
           obDBAccess.addParam("mColorSchCoverPaper_V", ColorSchCoverPaper_V);
           obDBAccess.addParam("mPrintingPaperInformation_V", PrintingPaperInformation_V);
           obDBAccess.addParam("mCoverPaperinformation_V", CoverPaperinformation_V);
           obDBAccess.addParam("mBindingdetail_V", Bindingdetail_V);
           obDBAccess.addParam("mClassTrno_I", ClassTrno_I );


           int result = obDBAccess.executeMyQuery();
           return result;

       }

       public System.Data.DataSet Select()
       {
           DBAccess obDBAccess = new DBAccess();
           obDBAccess.execute("USP_PRI009_CategoryMasterLoad", DBAccess.SQLType.IS_PROC);
           obDBAccess.addParam("mCatID_I", CatID_I);
           return obDBAccess.records();
           throw new NotImplementedException();
       }

       public int Delete(int id)
       {
           DBAccess obDBAccess = new DBAccess();
           obDBAccess.execute("USP_PRI009_CategoryMasterDelete", DBAccess.SQLType.IS_PROC);
           obDBAccess.addParam("mCatID_I", id);

           int result = obDBAccess.executeMyQuery();
           return result;
           throw new NotImplementedException();
       }

       public DataSet Fillddl(int PaperType_ID)
       {
           DBAccess obDBAccess = new DBAccess();
           obDBAccess.execute("USP_PRI009_Fillddl", DBAccess.SQLType.IS_PROC);
           obDBAccess.addParam("mPaperType_ID", PaperType_ID);
           return obDBAccess.records();
       }

       // function to load Class
       public DataSet FillClass()
       {
           DBAccess obDBAccess = new DBAccess();
           obDBAccess.execute("USP_ADM014_ClassMaster_Load", DBAccess.SQLType.IS_PROC);
           obDBAccess.addParam("id", ClassTrno_I);
           return obDBAccess.records();
       }

   }
}
