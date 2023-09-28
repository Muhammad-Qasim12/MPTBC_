using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer
{
    public class PRI_Inspection : ICommon
    {
        DateTime
            _Inspectiondate_D;

        string
            _OfficerName_V,
            _OfficerDesignation_V,
            _InspectionReport_V,
            _InspectionReportFile_V
            ;
        int
            _OfficerTrno_I,

            _DesignationTrno_I,
            _Printer_RedID_I,

            _UserTrno_I,
            _InspectionTrno_I
            ;


        public DateTime Inspectiondate_D { get { return _Inspectiondate_D; } set { _Inspectiondate_D = value; } }
        public string OfficerName_V { get { return _OfficerName_V; } set { _OfficerName_V = value; } }
        public int OfficerTrno_I { get { return _OfficerTrno_I; } set { _OfficerTrno_I = value; } }
        public string OfficerDesignation_V { get { return _OfficerDesignation_V; } set { _OfficerDesignation_V = value; } }
        public int DesignationTrno_I { get { return _DesignationTrno_I; } set { _DesignationTrno_I = value; } }
        public int Printer_RedID_I { get { return _Printer_RedID_I; } set { _Printer_RedID_I = value; } }
        public string InspectionReport_V { get { return _InspectionReport_V; } set { _InspectionReport_V = value; } }
        public string InspectionReportFile_V { get { return _InspectionReportFile_V; } set { _InspectionReportFile_V = value; } }
        public int UserTrno_I { get { return _UserTrno_I; } set { _UserTrno_I = value; } }

        public int InspectionTrno_I { get { return _InspectionTrno_I; } set { _InspectionTrno_I = value; } }



        #region ICommon Members

        public int InsertUpdate()
        {
            int i = 0;

            DBAccess obDbaccess = new DBAccess();


            try
            {

                obDbaccess.execute("USP_Printing007_InspectionSaveUpdate", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mInspectionTrno_I", InspectionTrno_I);
                obDbaccess.addParam("mInspectiondate_D", Inspectiondate_D);
                obDbaccess.addParam("mOfficerName_V", OfficerName_V);
                obDbaccess.addParam("mOfficerTrno_I", OfficerTrno_I);
                obDbaccess.addParam("mOfficerDesignation_V", OfficerDesignation_V);
                obDbaccess.addParam("mDesignationTrno_I", DesignationTrno_I);
                obDbaccess.addParam("mPrinter_RedID_I", Printer_RedID_I);
                obDbaccess.addParam("mInspectionReport_V", InspectionReport_V);
                obDbaccess.addParam("mInspectionReportFile_V", InspectionReportFile_V);
                obDbaccess.addParam("mUserTrno_I", UserTrno_I);

                i = obDbaccess.executeMyQuery();

            }

            catch (Exception ex) { }

            finally { obDbaccess = null; }
            return i;
        }

        public System.Data.DataSet Select()
        {
            DataSet ds = new DataSet();

            DBAccess obDbaccess = new DBAccess();


            try
            {
                obDbaccess.execute("USP_Printing007_InspectionLoad", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mInspectionTrno_I", InspectionTrno_I);
                ds = obDbaccess.records();
            }

            catch (Exception ex) { }

            finally { obDbaccess = null; }
            return ds;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
