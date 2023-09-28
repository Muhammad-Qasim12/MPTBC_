using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer
{
    public class Building005_AvantanAndRikt : ICommon
    {
        int
            _BuildingAllotTrno_I,
            _AvasMasterTrno_I,
            _AvasVistritTrno_I,
            _PersonID,
            _DesignationId,
            _AllotmentStatus_I,
            _MonthlyRentRule_I,
            _isNOC_I,
            _UserTrno_I;

        string

            _AllotedPersonName_V,
            _Designation_V,
            _AllotedRemark_V,
            _MonthlyRentRule_V,
            _UnallotmentRemark_V,
            _AllotmentNo_V,
            _AvasRiktReason_V,
            _AvasRiktOtherReason_V
            ;

        DateTime

            _AllotmentDate_D,
            _AdhipatyaDate_D,


            _UnallotmentDate_D,
            _AdhipatyaSamaptiDate_D;


           

        public int BuildingAllotTrno_I { get { return _BuildingAllotTrno_I; } set { _BuildingAllotTrno_I = value; } }
        public int AvasMasterTrno_I { get { return _AvasMasterTrno_I; } set { _AvasMasterTrno_I = value; } }
        public int AvasVistritTrno_I { get { return _AvasVistritTrno_I; } set { _AvasVistritTrno_I = value; } }
        public string AllotedPersonName_V { get { return _AllotedPersonName_V; } set { _AllotedPersonName_V = value; } }
        public int PersonID { get { return _PersonID; } set { _PersonID = value; } }
        public int DesignationId { get { return _DesignationId; } set { _DesignationId = value; } }
        public string Designation_V { get { return _Designation_V; } set { _Designation_V = value; } }
        public DateTime AllotmentDate_D { get { return _AllotmentDate_D; } set { _AllotmentDate_D = value; } }
        public DateTime AdhipatyaDate_D { get { return _AdhipatyaDate_D; } set { _AdhipatyaDate_D = value; } }
        public string AllotedRemark_V { get { return _AllotedRemark_V; } set { _AllotedRemark_V = value; } }
        public DateTime UnallotmentDate_D { get { return _UnallotmentDate_D; } set { _UnallotmentDate_D = value; } }
        public DateTime AdhipatyaSamaptiDate_D { get { return _AdhipatyaSamaptiDate_D; } set { _AdhipatyaSamaptiDate_D = value; } }
        public int AllotmentStatus_I { get { return _AllotmentStatus_I; } set { _AllotmentStatus_I = value; } }
        public int MonthlyRentRule_I { get { return _MonthlyRentRule_I; } set { _MonthlyRentRule_I = value; } }
        public string MonthlyRentRule_V { get { return _MonthlyRentRule_V; } set { _MonthlyRentRule_V = value; } }
        public int isNOC_I { get { return _isNOC_I; } set { _isNOC_I = value; } }
        public string UnallotmentRemark_V { get { return _UnallotmentRemark_V; } set { _UnallotmentRemark_V = value; } }
        public string AllotmentNo_V { get { return _AllotmentNo_V; } set { _AllotmentNo_V = value; } }
        
        public int UserTrno_I { get { return _UserTrno_I; } set { _UserTrno_I = value; } }

        public string AvasRiktReason_V { get { return _AvasRiktReason_V; } set { _AvasRiktReason_V = value; } }
         public string AvasRiktOtherReason_V { get { return _AvasRiktOtherReason_V; } set { _AvasRiktOtherReason_V = value; } }

        public DataSet AllAvasListLoad()
        {

            DataSet ds = new DataSet();
            DBAccess obDbaccess = new DBAccess();

            try
            {
                obDbaccess.execute("USP_Building005_AllAvasListLoad", DBAccess.SQLType.IS_PROC);
                
                ds = obDbaccess.records();
            }


            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return ds;
        }



        public DataSet AvasListLoad()
        {

            DataSet ds = new DataSet();
            DBAccess obDbaccess = new DBAccess();

            try
            {
                obDbaccess.execute("USP_Building005_AvantanAndRiktAvasList", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mAvasMasterTrno_I", AvasMasterTrno_I);
                obDbaccess.addParam("mAllotmentStatus_I", AllotmentStatus_I);

                ds = obDbaccess.records();
            }


            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return ds;
        }


        #region ICommon Members

        public int InsertUpdate()
        {
            int i = 0;
            DBAccess obDbaccess = new DBAccess();

            try
            {
                obDbaccess.execute("USP_Building005_AvantanAndRiktSaveUpdate", DBAccess.SQLType.IS_PROC);

                obDbaccess.addParam("mBuildingAllotTrno_I", BuildingAllotTrno_I);
                obDbaccess.addParam("mAvasMasterTrno_I", AvasMasterTrno_I);
                obDbaccess.addParam("mAvasVistritTrno_I", AvasVistritTrno_I);
                obDbaccess.addParam("mAllotedPersonName_V", AllotedPersonName_V);
                obDbaccess.addParam("mPersonID", PersonID);
                obDbaccess.addParam("mDesignationId", DesignationId);
                obDbaccess.addParam("mDesignation_V", Designation_V);
                obDbaccess.addParam("mAllotmentDate_D", AllotmentDate_D);
                obDbaccess.addParam("mAdhipatyaDate_D", AdhipatyaDate_D);
                obDbaccess.addParam("mAllotedRemark_V", AllotedRemark_V);
                obDbaccess.addParam("mUnallotmentDate_D", UnallotmentDate_D);
                obDbaccess.addParam("mAdhipatyaSamaptiDate_D", AdhipatyaSamaptiDate_D);
                obDbaccess.addParam("mAllotmentStatus_I", AllotmentStatus_I);
                obDbaccess.addParam("mMonthlyRentRule_I", MonthlyRentRule_I);
                obDbaccess.addParam("mMonthlyRentRule_V", MonthlyRentRule_V);
                obDbaccess.addParam("misNOC_I", isNOC_I);
                obDbaccess.addParam("mUnallotmentRemark_V", UnallotmentRemark_V);
                obDbaccess.addParam("mUserTrno_I", UserTrno_I);
                obDbaccess.addParam("mAllotmentNo_V", AllotmentNo_V);

                obDbaccess.addParam("mAvasRiktReason_V", AvasRiktReason_V);
                obDbaccess.addParam("mAvasRiktOtherReason_V", AvasRiktOtherReason_V);


                i = obDbaccess.executeMyQuery();

            }


            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return i;
        }


        public DataSet EmployeeNameLoad() 
        {
            DataSet ds = new DataSet();
            DBAccess obDbaccess = new DBAccess();

            try
            {
                obDbaccess.execute("USP_Building005_EmployeeLoad", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mEmp_ID", PersonID );
               
                ds = obDbaccess.records();
            }


            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return ds;
        
        }

        public DataSet EmployeeDesignationLoad()
        {
            DataSet ds = new DataSet();
            DBAccess obDbaccess = new DBAccess();

            try
            {
                obDbaccess.execute("USP_Building005_EmpDesignationLoad", DBAccess.SQLType.IS_PROC);
               
                ds = obDbaccess.records();
            }


            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return ds;

        }




        public System.Data.DataSet Select()
        {
            DataSet ds = new DataSet();
            DBAccess obDbaccess = new DBAccess();

            try
            {
                obDbaccess.execute("USP_Building005_AvantanAndRiktLoad", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mBuildingAllotTrno_I", BuildingAllotTrno_I);
                obDbaccess.addParam("mAllotmentStatus_I", AllotmentStatus_I);
                ds = obDbaccess.records();
            }


            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return ds;
        }


        public DataSet GetAlDetailsOnEmpId()
        {
            DataSet ds = new DataSet();
            DBAccess obDbaccess = new DBAccess();

            try
            {
                obDbaccess.execute("USP_Building005_AllotedStatusOnID", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mPersonID", PersonID);
               
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
