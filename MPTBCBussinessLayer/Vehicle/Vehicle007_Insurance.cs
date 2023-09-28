using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer
{
    public class Vehicle007_Insurance : ICommon
    {

        string
               _InsuranceComName,
               _Email,
               _Address,
               _TelPhoneNo,
               _AjentOfficerName,
               _AjantCode,
               _AjentMobileNo,
               _AjantEmailId,
               _InsurancePolicyName,
               _PolicyNo,
               _ReceiptNo,
               _VehicleNo_V,
               _FilePolicy;

        DateTime
                 _PolicyFrom,
                 _PolicyTo;

        double

               _PremiumAmount,
               _ServiceTaxAmount,
               _NetPaybleAmount;

        int
               _VehInsuranceTrno,
               _VehicleNo_I,
               _UserTrno;

        public string InsuranceComName { get { return _InsuranceComName; } set { _InsuranceComName = value; } }
        public string Email { get { return _Email; } set { _Email = value; } }
        public string Address { get { return _Address; } set { _Address = value; } }
        public string TelPhoneNo { get { return _TelPhoneNo; } set { _TelPhoneNo = value; } }
        public string AjentOfficerName { get { return _AjentOfficerName; } set { _AjentOfficerName = value; } }
        public string AjantCode { get { return _AjantCode; } set { _AjantCode = value; } }
        public string AjentMobileNo { get { return _AjentMobileNo; } set { _AjentMobileNo = value; } }
        public string AjantEmailId { get { return _AjantEmailId; } set { _AjantEmailId = value; } }
        public string InsurancePolicyName { get { return _InsurancePolicyName; } set { _InsurancePolicyName = value; } }
        public string PolicyNo { get { return _PolicyNo; } set { _PolicyNo = value; } }
        public string ReceiptNo { get { return _ReceiptNo; } set { _ReceiptNo = value; } }
        public DateTime PolicyFrom { get { return _PolicyFrom; } set { _PolicyFrom = value; } }
        public DateTime PolicyTo { get { return _PolicyTo; } set { _PolicyTo = value; } }
        public double PremiumAmount { get { return _PremiumAmount; } set { _PremiumAmount = value; } }
        public double ServiceTaxAmount { get { return _ServiceTaxAmount; } set { _ServiceTaxAmount = value; } }
        public double NetPaybleAmount { get { return _NetPaybleAmount; } set { _NetPaybleAmount = value; } }
        public int VehicleNo_I { get { return _VehicleNo_I; } set { _VehicleNo_I = value; } }
        public string VehicleNo_V { get { return _VehicleNo_V; } set { _VehicleNo_V = value; } }
        public string FilePolicy { get { return _FilePolicy; } set { _FilePolicy = value; } }

        public int UserTrno { get { return _UserTrno; } set { _UserTrno = value; } }
        public int VehInsuranceTrno { get { return _VehInsuranceTrno; } set { _VehInsuranceTrno = value; } }



        #region ICommon Members

        public int InsertUpdate()
        {
            int i = 0;
            DBAccess obdbAccess = new DBAccess();

            try
            {
                obdbAccess.execute("USP_Vehicle007_InsuranceSaveUpdate", DBAccess.SQLType.IS_PROC);
                obdbAccess.addParam("mVehInsuranceTrno", VehInsuranceTrno);
                obdbAccess.addParam("mInsuranceComName", InsuranceComName);
                obdbAccess.addParam("mEmail", Email);
                obdbAccess.addParam("mAddress", Address);
                obdbAccess.addParam("mTelPhoneNo", TelPhoneNo);
                obdbAccess.addParam("mAjentOfficerName", AjentOfficerName);
                obdbAccess.addParam("mAjantCode", AjantCode);
                obdbAccess.addParam("mAjentMobileNo", AjentMobileNo);
                obdbAccess.addParam("mAjantEmailId", AjantEmailId);
                obdbAccess.addParam("mInsurancePolicyName", InsurancePolicyName);
                obdbAccess.addParam("mPolicyNo", PolicyNo);
                obdbAccess.addParam("mReceiptNo", ReceiptNo);
                obdbAccess.addParam("mPolicyFrom", PolicyFrom);
                obdbAccess.addParam("mPolicyTo", PolicyTo);
                obdbAccess.addParam("mPremiumAmount", PremiumAmount);
                obdbAccess.addParam("mServiceTaxAmount", ServiceTaxAmount);
                obdbAccess.addParam("mNetPaybleAmount", NetPaybleAmount);
                obdbAccess.addParam("mVehicleNo_I", VehicleNo_I);
                obdbAccess.addParam("mVehicleNo_V", VehicleNo_V);
                obdbAccess.addParam("mFilePolicy", FilePolicy);
                obdbAccess.addParam("mUserTrno", UserTrno);

               i = Convert.ToInt32(obdbAccess.executeMyScalar());
                return i;


            }

            catch (Exception ex) { }

            finally { obdbAccess = null; }
            return i;
        }


        public DataSet Select()
        {
            DataSet ds = new DataSet();
            DBAccess obdbAccess = new DBAccess();

            try
            {
                obdbAccess.execute("USP_Vehicle007_InsuranceLoad", DBAccess.SQLType.IS_PROC);
                obdbAccess.addParam("mVehInsuranceTrno", VehInsuranceTrno);

                ds = obdbAccess.records();
            }

            catch (Exception ex) { }

            finally { obdbAccess = null; }
            return ds ;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}