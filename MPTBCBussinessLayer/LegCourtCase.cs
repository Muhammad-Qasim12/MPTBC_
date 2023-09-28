using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
  public   class LegCourtCase :ICommon 

    {
        
private int _CourtCaseTrNo_I;
private string  _AppealCaseNo_V;
private DateTime _RegistrationDate_D;
private string _NameofApplicant_V;
private string _ApplicantMobileNumber_N;
private string  _NonApplicantName_V;
private string _NonApliMobileNumber_N;
private int _Department_I;
private int _TypeofCourt_I;
private string _OIC_V;
private string _AdocateName_V;
private string _AdocateMobileNumber_N;
private int  _CaseStatus_I;
private string _Remark_V;
private int _UserID_I;
private DateTime _TrDate_D;
private decimal _AdvocateFee;
private DateTime _LastHearingDate_D;
private DateTime _NextHearingDate_D;
private int _LStatusTrNo;
private string _Status_V;
private string _OICDEG;
private string _CourtName;
private string _AddressOFNonApplicatn;

public string OICDEG { get { return _OICDEG; } set { _OICDEG = value; } }
public string CourtName { get { return _CourtName; } set { _CourtName = value; } }


public DateTime LastHearingDate_D { get { return _LastHearingDate_D; } set { _LastHearingDate_D = value; } }
public DateTime NextHearingDate_D { get { return _NextHearingDate_D; } set { _NextHearingDate_D = value; } }
public int LStatusTrNo { get { return _LStatusTrNo; } set { _LStatusTrNo = value; } }
public string  Status_V { get { return _Status_V; } set { _Status_V = value; } }

public decimal  AdvocateFee { get { return _AdvocateFee; } set { _AdvocateFee = value; } }
public int CourtCaseTrNo_I { get { return _CourtCaseTrNo_I; } set { _CourtCaseTrNo_I = value; } }
public string AppealCaseNo_V { get { return _AppealCaseNo_V; } set { _AppealCaseNo_V = value; } }
public DateTime RegistrationDate_D { get { return _RegistrationDate_D; } set { _RegistrationDate_D = value; } }
public string  NameofApplicant_V { get { return _NameofApplicant_V; } set { _NameofApplicant_V = value; } }
public string ApplicantMobileNumber_N { get { return _ApplicantMobileNumber_N; } set { _ApplicantMobileNumber_N = value; } }
public int Department_I { get { return _Department_I; } set { _Department_I = value; } }
public string  NonApplicantName_V { get { return _NonApplicantName_V; } set { _NonApplicantName_V = value; } }
public string NonApliMobileNumber_N { get { return _NonApliMobileNumber_N; } set { _NonApliMobileNumber_N = value; } }
public int TypeofCourt_I { get { return _TypeofCourt_I; } set { _TypeofCourt_I = value; } }
public string  OIC_V { get { return _OIC_V; } set { _OIC_V = value; } }
public string AdocateName_V { get { return _AdocateName_V; } set { _AdocateName_V = value; } }
public string AdocateMobileNumber_N { get { return _AdocateMobileNumber_N; } set { _AdocateMobileNumber_N = value; } }
public int CaseStatus_I { get { return _CaseStatus_I; } set { _CaseStatus_I = value; } }
public string  Remark_V { get { return _Remark_V; } set { _Remark_V = value; } }
public int UserID_I { get { return _UserID_I; } set { _UserID_I = value; } }
public DateTime TrDate_D { get { return _TrDate_D; } set { _TrDate_D = value; } }
public string AddressOFNonApplicatn { get { return _AddressOFNonApplicatn; } set { _AddressOFNonApplicatn = value; } }

        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_LEG001_CourtCaseMaster_Save", DBAccess.SQLType.IS_PROC);

            obDBAccess.addParam("LCourtCaseTrNo_I", CourtCaseTrNo_I);
            obDBAccess.addParam("AppealCaseNo_V", AppealCaseNo_V);
            obDBAccess.addParam("RegistrationDate_D", RegistrationDate_D);
            obDBAccess.addParam("NameofApplicant_V", NameofApplicant_V);
            obDBAccess.addParam("ApplicantMobileNumber_N", ApplicantMobileNumber_N);
            obDBAccess.addParam("Department_I", Department_I);
            obDBAccess.addParam("NonApplicantName_V", NonApplicantName_V);
            obDBAccess.addParam("NonApliMobileNumber_N", NonApliMobileNumber_N);
            obDBAccess.addParam("TypeofCourt_I", TypeofCourt_I);
            obDBAccess.addParam("OIC_V", OIC_V);
            obDBAccess.addParam("AdocateName_V", AdocateName_V);
            obDBAccess.addParam("AdocateMobileNumber_N", AdocateMobileNumber_N);
            obDBAccess.addParam("CaseStatus_I", CaseStatus_I);
            obDBAccess.addParam("Remark_V", Remark_V);
            obDBAccess.addParam("UserID_I", UserID_I);
            obDBAccess.addParam("TrDate_D", TrDate_D);
            obDBAccess.addParam("AdvocateFee",AdvocateFee);
            obDBAccess.addParam("OICDEG", OICDEG);
            obDBAccess.addParam("CourtName", CourtName);
            obDBAccess.addParam("AddressOFNonApplicatn", AddressOFNonApplicatn);
            //,
            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public int SaveStatusInsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_LEG002_SaveCourtStatus_save", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("LStatusTrNo", LStatusTrNo);
            obDBAccess.addParam("CourtCaseTrNo_I", CourtCaseTrNo_I);
            obDBAccess.addParam("LastHearingDate_D", LastHearingDate_D);
            obDBAccess.addParam("NextHearingDate_D", NextHearingDate_D );
            obDBAccess.addParam("Status_V",Status_V);
            obDBAccess.addParam("Remark_V", Remark_V);
            obDBAccess.addParam("UserTrNo_I", UserID_I);
            obDBAccess.addParam("TrDate_D", TrDate_D);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_LEG001_CourtCase_Load", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("id", CourtCaseTrNo_I);
            return obDBAccess.records();
        }
       public System.Data.DataSet getCaseDetails()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_Leg002_GetCourtcaseDetails", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("id", CourtCaseTrNo_I);
            obDBAccess.addParam("dptID", Department_I);
           
            return obDBAccess.records();
        }
      
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

      
    }
}
