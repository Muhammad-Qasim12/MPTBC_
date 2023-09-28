using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer
{
    public class Vehicle003_Tender : ICommon
    {

        int
            _TenderParID_I,
            _TenderID_I,
            _NITSign_I,
            _UserTrno_I,

            _Chklstid,
            _NoofVehicle,
            _NoofDriver,
            _Staxregistration,


            _RateDay_Mon_Year,
            _MinimumKM,
            _Veh_FinId,
            _TenderEvaluationTrno_I,
            _L1Status
            ;


        string

            _NameofParty,
            _Address_Party,
            _Address_Garage,
            _Nature_Concern,
            _RegistrationNo,
            _Tel_MobNo,
            _Tel_MobNo_Office,
            _PANNo,
            _DD_Details,
            _BankDetails,
            _Remarks,
            _FilePANNo,
            _FileRegistration,

            _TenderNo_V,
            _VehicleType,
            _VehName,

            _registration_V,
            _drivingLicense,
            _Certificate

            ;

        double _EMD_Amt,

               _TenderDocFee_N,

               _RateKM_AC,
                _RateKM_NonAc,
                _RateaboveKM_AC,
                _RateaboveKM_NonAC,
                _RateNightHalt
                ;


        DateTime _DDDate,

                _TenderDate_D,
                _NITDate_D,

                _TenderSubmissionDate_D,
                _TechBidopeningDate_D,
                _CommecialBidOpeningdate_D
                ;





        public string VehicleType { get { return _VehicleType; } set { _VehicleType = value; } }
        public string VehName { get { return _VehName; } set { _VehName = value; } }
        public double RateKM_AC { get { return _RateKM_AC; } set { _RateKM_AC = value; } }
        public double RateKM_NonAc { get { return _RateKM_NonAc; } set { _RateKM_NonAc = value; } }
        public double RateaboveKM_AC { get { return _RateaboveKM_AC; } set { _RateaboveKM_AC = value; } }
        public double RateaboveKM_NonAC { get { return _RateaboveKM_NonAC; } set { _RateaboveKM_NonAC = value; } }
        public double RateNightHalt { get { return _RateNightHalt; } set { _RateNightHalt = value; } }
        public int RateDay_Mon_Year { get { return _RateDay_Mon_Year; } set { _RateDay_Mon_Year = value; } }
        public int MinimumKM { get { return _MinimumKM; } set { _MinimumKM = value; } }

        public int Veh_FinId { get { return _Veh_FinId; } set { _Veh_FinId = value; } }


        public string TenderNo_V { get { return _TenderNo_V; } set { _TenderNo_V = value; } }
        public DateTime TenderDate_D { get { return _TenderDate_D; } set { _TenderDate_D = value; } }
        public DateTime NITDate_D { get { return _NITDate_D; } set { _NITDate_D = value; } }
        public double TenderDocFee_N { get { return _TenderDocFee_N; } set { _TenderDocFee_N = value; } }
        public DateTime TenderSubmissionDate_D { get { return _TenderSubmissionDate_D; } set { _TenderSubmissionDate_D = value; } }
        public DateTime TechBidopeningDate_D { get { return _TechBidopeningDate_D; } set { _TechBidopeningDate_D = value; } }
        public DateTime CommecialBidOpeningdate_D { get { return _CommecialBidOpeningdate_D; } set { _CommecialBidOpeningdate_D = value; } }


        public int TenderParID_I { get { return _TenderParID_I; } set { _TenderParID_I = value; } }
        public int TenderID_I { get { return _TenderID_I; } set { _TenderID_I = value; } }
        public string NameofParty { get { return _NameofParty; } set { _NameofParty = value; } }
        public string Address_Party { get { return _Address_Party; } set { _Address_Party = value; } }
        public string Address_Garage { get { return _Address_Garage; } set { _Address_Garage = value; } }
        public string Nature_Concern { get { return _Nature_Concern; } set { _Nature_Concern = value; } }
        public string RegistrationNo { get { return _RegistrationNo; } set { _RegistrationNo = value; } }
        public string Tel_MobNo { get { return _Tel_MobNo; } set { _Tel_MobNo = value; } }
        public string Tel_MobNo_Office { get { return _Tel_MobNo_Office; } set { _Tel_MobNo_Office = value; } }
        public string PANNo { get { return _PANNo; } set { _PANNo = value; } }
        public double EMD_Amt { get { return _EMD_Amt; } set { _EMD_Amt = value; } }
        public string DD_Details { get { return _DD_Details; } set { _DD_Details = value; } }
        public string BankDetails { get { return _BankDetails; } set { _BankDetails = value; } }
        public DateTime DDDate { get { return _DDDate; } set { _DDDate = value; } }
        public int NITSign_I { get { return _NITSign_I; } set { _NITSign_I = value; } }
        public string Remarks { get { return _Remarks; } set { _Remarks = value; } }
        public int UserTrno_I { get { return _UserTrno_I; } set { _UserTrno_I = value; } }

        public string FilePANNo { get { return _FilePANNo; } set { _FilePANNo = value; } }
        public string FileRegistration { get { return _FileRegistration; } set { _FileRegistration = value; } }


        public string registration_V { get { return _registration_V; } set { _registration_V = value; } }
        public string drivingLicense { get { return _drivingLicense; } set { _drivingLicense = value; } }
        public string Certificate { get { return _Certificate; } set { _Certificate = value; } }



        public int Chklstid { get { return _Chklstid; } set { _Chklstid = value; } }
        public int NoofVehicle { get { return _NoofVehicle; } set { _NoofVehicle = value; } }
        public int NoofDriver { get { return _NoofDriver; } set { _NoofDriver = value; } }
        public int Staxregistration { get { return _Staxregistration; } set { _Staxregistration = value; } }


        public int TenderEvaluationTrno_I { get { return _TenderEvaluationTrno_I; } set { _TenderEvaluationTrno_I = value; } }
        public int L1Status { get { return _L1Status; } set { _L1Status = value; } }



        public int TenderSaveUpdate()
        {
            int i = 0;
            DBAccess obDbaccess = new DBAccess();
            try
            {
                obDbaccess.execute("USP_Vehicle003_TenderDetailsSaveUpdate", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mTenderId_I", TenderID_I);
                obDbaccess.addParam("mTenderNo_V", TenderNo_V);
                obDbaccess.addParam("mTenderDate_D", TenderDate_D);
                obDbaccess.addParam("mNITDate_D", NITDate_D);
                obDbaccess.addParam("mTenderDocFee_N", TenderDocFee_N);
                obDbaccess.addParam("mTenderSubmissionDate_D", TenderSubmissionDate_D);
                obDbaccess.addParam("mTechBidopeningDate_D", TechBidopeningDate_D);
                obDbaccess.addParam("mCommecialBidOpeningdate_D", CommecialBidOpeningdate_D);
                obDbaccess.addParam("mUserID_I", UserTrno_I);
                i = Convert.ToInt32(obDbaccess.executeMyScalar());
            }
            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return i;
        }


        public DataSet LoadTender()
        {
            DataSet ds = new DataSet();

            DBAccess obDbaccess = new DBAccess();

            try
            {
                obDbaccess.execute("USP_Vehicle003_TenderDetailsLoad", DBAccess.SQLType.IS_PROC);

                obDbaccess.addParam("mTenderId_I", TenderID_I);
                ds = obDbaccess.records();

            }

            catch (Exception ex) { }

            finally { obDbaccess = null; }

            return ds;
        }




        public int TenderFinancialSaveUpdate()
        {
            int i = 0;

            DBAccess obDbaccess = new DBAccess();

            try
            {
                obDbaccess.execute("USP_Vehicle003_TenderFinancialSaveUpdate", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mVeh_FinId", Veh_FinId);
                obDbaccess.addParam("mVehicleType", VehicleType);
                obDbaccess.addParam("mVehName", VehName);
                obDbaccess.addParam("mRateKM_AC", RateKM_AC);
                obDbaccess.addParam("mRateKM_NonAc", RateKM_NonAc);
                obDbaccess.addParam("mRateaboveKM_AC", RateaboveKM_AC);
                obDbaccess.addParam("mRateaboveKM_NonAC", RateaboveKM_NonAC);
                obDbaccess.addParam("mRateNightHalt", RateNightHalt);
                obDbaccess.addParam("mRateDay_Mon_Year", RateDay_Mon_Year);
                obDbaccess.addParam("mMinimumKM", MinimumKM);
                obDbaccess.addParam("mUserTrno_I", UserTrno_I);
                obDbaccess.addParam("mTenderParID_I", TenderParID_I);
                i = obDbaccess.executeMyQuery();

            }

            catch (Exception ex) { }

            finally { obDbaccess = null; }

            return i;
        }


        public DataSet LoadTenderFinancial()
        {
            DataSet ds = new DataSet();

            DBAccess obDbaccess = new DBAccess();

            try
            {
                obDbaccess.execute("USP_Vehicle003_TenderFinancialLoad", DBAccess.SQLType.IS_PROC);

                obDbaccess.addParam("mTenderParID_I", TenderParID_I);
                obDbaccess.addParam("mMinimumKM", MinimumKM);

                ds = obDbaccess.records();

            }

            catch (Exception ex) { }

            finally { obDbaccess = null; }

            return ds;
        }






        public int ChkListSaveUpdate()
        {
            int i = 0;

            DBAccess obDbaccess = new DBAccess();

            try
            {
                obDbaccess.execute("USP_Vehicle003_TenderCheckLiastSaveUpdate", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mChklstid", Chklstid);
                obDbaccess.addParam("mNoofVehicle", NoofVehicle);
                obDbaccess.addParam("mNoofDriver", NoofDriver);
                obDbaccess.addParam("mStaxregistration", Staxregistration);

                obDbaccess.addParam("mregistration_V", registration_V);
                obDbaccess.addParam("mdrivingLicense", drivingLicense);
                obDbaccess.addParam("mCertificate", Certificate);
                obDbaccess.addParam("mTenderParID_I", TenderParID_I);


                i = obDbaccess.executeMyQuery();

            }

            catch (Exception ex) { }

            finally { obDbaccess = null; }

            return i;
        }


        public DataSet LoadTenderChkList()
        {
            DataSet ds = new DataSet();

            DBAccess obDbaccess = new DBAccess();

            try
            {
                obDbaccess.execute("USP_Vehicle003_TenderCheckListLoad", DBAccess.SQLType.IS_PROC);

                obDbaccess.addParam("mTenderParID_I", TenderParID_I);
                ds = obDbaccess.records();

            }

            catch (Exception ex) { }

            finally { obDbaccess = null; }

            return ds;
        }





        public DataSet LoadTenderParticipent()
        {
            DataSet ds = new DataSet();

            DBAccess obDbaccess = new DBAccess();

            try
            {
                obDbaccess.execute("USP_Vehicle003_TenderParticipentLoad", DBAccess.SQLType.IS_PROC);

                obDbaccess.addParam("mTenderParID_I", TenderParID_I);
                ds = obDbaccess.records();

            }

            catch (Exception ex) { }

            finally { obDbaccess = null; }

            return ds;
        }


        public int SaveTenderParticipent()
        {
            int i = 0;

            DBAccess obDbaccess = new DBAccess();

            try
            {
                obDbaccess.execute("USP_Vehicle003_TenderParticipentSaveUpdate", DBAccess.SQLType.IS_PROC);

                obDbaccess.addParam("mTenderParID_I", TenderParID_I);
                obDbaccess.addParam("mTenderID_I", TenderID_I);
                obDbaccess.addParam("mNameofParty", NameofParty);
                obDbaccess.addParam("mAddress_Party", Address_Party);
                obDbaccess.addParam("mAddress_Garage", Address_Garage);
                obDbaccess.addParam("mNature_Concern", Nature_Concern);
                obDbaccess.addParam("mRegistrationNo", RegistrationNo);
                obDbaccess.addParam("mTel_MobNo", Tel_MobNo);
                obDbaccess.addParam("mTel_MobNo_Office", Tel_MobNo_Office);
                obDbaccess.addParam("mPANNo", PANNo);
                obDbaccess.addParam("mEMD_Amt", EMD_Amt);
                obDbaccess.addParam("mDD_Details", DD_Details);
                obDbaccess.addParam("mBankDetails", BankDetails);
                obDbaccess.addParam("mDDDate", DDDate);
                obDbaccess.addParam("mNITSign_I", NITSign_I);
                obDbaccess.addParam("mRemarks", Remarks);
                obDbaccess.addParam("mUserTrno_I", UserTrno_I);

                obDbaccess.addParam("mFilePANNo", FilePANNo);
                obDbaccess.addParam("mFileRegistration", FileRegistration);

                i = obDbaccess.executeMyQuery();

            }

            catch (Exception ex) { }

            finally { obDbaccess = null; }

            return i;
        }


        public int TenderEvaluationSaveUpdate()
        {
            int i = 0;

            DBAccess obDbaccess = new DBAccess();

            try
            {
                obDbaccess.execute("USP_Vehicle004_TenderEvaluationSaveUpdate", DBAccess.SQLType.IS_PROC);

                obDbaccess.addParam("mTenderEvaluationTrno_I", TenderEvaluationTrno_I);
                obDbaccess.addParam("mTenderTrno_I", TenderID_I);
                obDbaccess.addParam("mRemark_V", Remarks);
                obDbaccess.addParam("mL1Status", L1Status);
                obDbaccess.addParam("mUserTrno_I", UserTrno_I);
                obDbaccess.addParam("mTenderParID_I", TenderParID_I);


                i = obDbaccess.executeMyQuery();

            }

            catch (Exception ex) { }

            finally { obDbaccess = null; }

            return i;
        }


        public DataSet LoadTenderEvaluation()
        {
            DataSet ds = new DataSet();

            DBAccess obDbaccess = new DBAccess();

            try
            {
                obDbaccess.execute("USP_Vehicle004_TenderEvaluationLoad", DBAccess.SQLType.IS_PROC);

                obDbaccess.addParam("mTenderEvaluationTrno_I", TenderEvaluationTrno_I);
                ds = obDbaccess.records();

            }

            catch (Exception ex) { }

            finally { obDbaccess = null; }

            return ds;
        }



        public DataSet LoadTenderEvaluationDetails()
        {
            DataSet ds = new DataSet();

            DBAccess obDbaccess = new DBAccess();

            try
            {
                obDbaccess.execute("USP_Vehicle004_TenderEvaluationDetailsLoad", DBAccess.SQLType.IS_PROC);

                obDbaccess.addParam("mTenderId_I", TenderID_I);
                ds = obDbaccess.records();

            }

            catch (Exception ex) { }

            finally { obDbaccess = null; }

            return ds;
        }



        //
        string _DisplayStatus, _CheckListConditionHindi, _CheckListCondition;
        int _TenderCheckListTrno;



        public string DisplayStatus { get { return _DisplayStatus; } set { _DisplayStatus = value; } }
        public string CheckListConditionHindi { get { return _CheckListConditionHindi; } set { _CheckListConditionHindi = value; } }
        public string CheckListCondition { get { return _CheckListCondition; } set { _CheckListCondition = value; } }
        public int TenderCheckListTrno { get { return _TenderCheckListTrno; } set { _TenderCheckListTrno = value; } }

        public DataSet LoadTenderChecklistCondition()
        {
            DataSet ds = new DataSet();
            DBAccess obDbaccess = new DBAccess();
            try
            {
                obDbaccess.execute("USP_Vehicle003_TenderChecklistConditionLoad", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("MTenderCheckListTrno", TenderCheckListTrno);
                ds = obDbaccess.records();
            }
            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return ds;
        }


        public int TenderChecklistConditionSaveUpdate()
        {
            int i = 0;

            DBAccess obDbaccess = new DBAccess();

            try
            {
                obDbaccess.execute("USP_Vehicle003_TenderChecklistSaveUpdate", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("MTenderCheckListTrno", TenderCheckListTrno);
                obDbaccess.addParam("MCheckListCondition", CheckListCondition);

                obDbaccess.addParam("MCheckListConditionHindi", CheckListConditionHindi);
                obDbaccess.addParam("MDisplayStatus", DisplayStatus);

                obDbaccess.addParam("MUserTrno_I", UserTrno_I);
                i = obDbaccess.executeMyQuery();

            }

            catch (Exception ex) { }

            finally { obDbaccess = null; }

            return i;
        }


        public DataSet CheckListConditionLoadTenderWise()
        {
            DataSet ds = new DataSet();

            DBAccess obDbaccess = new DBAccess();

            try
            {
                obDbaccess.execute("Vehicle003_CheckListConditionLoadForTender", DBAccess.SQLType.IS_PROC);

                obDbaccess.addParam("mTenderTrno_I", TenderID_I);
                ds = obDbaccess.records();

            }

            catch (Exception ex) { }

            finally { obDbaccess = null; }

            return ds;

        }


        #region ICommon Members

        public int InsertUpdate()
        {
            throw new NotImplementedException();
        }

        public System.Data.DataSet Select()
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
