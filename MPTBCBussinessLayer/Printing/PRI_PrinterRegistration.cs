using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace MPTBCBussinessLayer
{
    public class PRI_PrinterRegistration : ICommon
    {


        //comm

        private int _RegChkLSTID_I,
                    _Printer_RedID_I,
                    _RegAmount_I,
                    _PressActCert_I,
                    _IncometaxClearance_I,
                    _LastThreeYrsPrinting_I,
                    _MacPurchaseBillcopy_I,
                    _Insurance_I,
                    _Other_I,
                    _ProcessCamera_I,
                    _PlateMat_I,
                    _SingleColOffset_I,
                    _BindingFacility_I,

                    _AreaType_I,
                    _ReginComact_I,
                    _NoofProc_OP_I,
                    _NoofComp_OP_I,
                    _NoofPrint_OP_I,
                    _NoofBind_OP_I,
                    _NoofMisc_OP_I,
                    _NoofTotal_OP_I,
                    _NoofProc_Su_I,
                    _NoofComp_Su_I,
                    _NoofPrint_Su_I,
                    _NoofBind_Su_I,
                    _NoofMisc_Su_I,
                    _NoofTotal_Su_I,
                    _NoofProofreader_I,
                    _Isactive_I,
                    _IsOffsetReg_I,
                    _RegforYear_I,

                    _MachineID_I,

                    _Year_I,
                    _nOOFmACHINE,

                    _PriMacID_I,

                    _ComposingCapP1_I,
                    _ComposingCapP2_I,

                    _ComposingCapP3_I,
                    _Mac_FoldingNos_I,
                    _Mac_StichgNos_I,

                    _Mac_CutNos_I,

                    _Mac_othNos_I,

                    _Book1BindCapNo_I,

                    _Book2BindCapNo_I,

                    _BookBindCapNo_I,
                    _PriBindID_I,

                    _RegOthID,
                    _NOofTitle_TBCPrint_I,
                    _NOofTitle_OThTBCPrint_I,
                    _NOofTitle_OThPrint_I,
                    _ApprovContractor_I,
                    _IncometaxPay,
                    _UserID_I,
                    _NOofTitle_MPTBCPrint_I,
                    _Last3YearQuantity_I,
                    _PriMacDesID_I,
                    _OtherCorpNo_I,
                    _RoleTrno_I
                    ;



        private string _Regno_I,
                        _OtherDet_V,
                        _Grade_V,
                        _NameofPress_V,
                        _FullAddress_V,
                        _Headoffice_V,
                        _BOTelegraph_Add_V,
                        _FacRegNo_V,
                        _RegDet_V,
                        _Profreadpath_v,
                        _RegDetails_V,
                        _OwnerDeail_V,
                        _Make_V,
                        _FoundaryTyAtt_V,
                        _pRINcAPASITY_v,
                        _Composing_Monotype_V,
                        _Composing_Linotype_V,
                        _ComposAnyOthtype_V,

                        _ComposingCapL1_V,
                        _ComposingCapL2_V,
                        _ComposingCapL3_V,
                        _LanguagesTxtSetAttach_V,
                        _Mac_FoldingMake_V,
                        _Mac_FoldingSize_V,
                            _Mac_FoldingOwned_V,
                        _Mac_StichgMake_V,
                        _Mac_StichgSize_V,
                            _Mac_StichgOwned_V,
                        _Mac_CutMake_V,
                        _Mac_CutSize_V,
                            _Mac_CutOwned_V,
                        _Mac_othMake_V,
                        _Mac_othSize_V,
                        _Mac_othOwned_V,
                        _Bookname_V,
                            _Bookname1_V,
                            _OffsetCameraSize_V,
                        _OffsetCameraMake_V,
                        _OffsetWhirlarSize_V,
                        _OffsetWhirlarMake_V,
                        _OffsetOthSize_V,
                        _OffsetOthMake_V,
                        _OffsetConCabSize_V,
                        _OffsetConCabMake_V,
                        _Bookname2_V,
                        _Noofshift_V,
                        _BookPrintExperience_V,
                        _WareHouseDet_V,
                        _Premises_GoodIns_V,
                        _Ins_CoverDetail_V,
                        _Nameaddbanker_v,
                        _AnyOthDetails_V,
                        _NameofPressHindi_V,
                     //     _NameOfTitle_OThTBCPrint_V,
                          _OtherCorpName_V,
                          _PayMode_V,
                          _BankName_V,
                          _MachineNo_V, 
                          _OffsetConCabSize_V1,
                        _OffsetConCabMake_V1,

                        _Password_V,
                        _UserType_V ;


        private DateTime _Est_Date_D,
                         _RegDate_D,
                         _DateOfInstallation_D,
                         _TransDate_d,
                         _RegistrationDate
                   ;

        private double _AreaOccupies_N,
                       _Regamount_N;


        public int RegChkLSTID_I { get { return _RegChkLSTID_I; } set { _RegChkLSTID_I = value; } }

        public int Printer_RedID_I { get { return _Printer_RedID_I; } set { _Printer_RedID_I = value; } }

        public int PriMacDesID_I { get { return _PriMacDesID_I; } set { _PriMacDesID_I = value; } }

        public int RegAmount_I { get { return _RegAmount_I; } set { _RegAmount_I = value; } }
        public int PressActCert_I { get { return _PressActCert_I; } set { _PressActCert_I = value; } }
        public int IncometaxClearance_I { get { return _IncometaxClearance_I; } set { _IncometaxClearance_I = value; } }
        public int LastThreeYrsPrinting_I { get { return _LastThreeYrsPrinting_I; } set { _LastThreeYrsPrinting_I = value; } }
        public int MacPurchaseBillcopy_I { get { return _MacPurchaseBillcopy_I; } set { _MacPurchaseBillcopy_I = value; } }
        public int Insurance_I { get { return _Insurance_I; } set { _Insurance_I = value; } }
        public int Other_I { get { return _Other_I; } set { _Other_I = value; } }
        public string OtherDet_V { get { return _OtherDet_V; } set { _OtherDet_V = value; } }
        public int ProcessCamera_I { get { return _ProcessCamera_I; } set { _ProcessCamera_I = value; } }
        public int PlateMat_I { get { return _PlateMat_I; } set { _PlateMat_I = value; } }
        public int SingleColOffset_I { get { return _SingleColOffset_I; } set { _SingleColOffset_I = value; } }
        public int BindingFacility_I { get { return _BindingFacility_I; } set { _BindingFacility_I = value; } }

        public int AreaType_I { get { return _AreaType_I; } set { _AreaType_I = value; } }
        public int ReginComact_I { get { return _ReginComact_I; } set { _ReginComact_I = value; } }
        public int NoofProc_OP_I { get { return _NoofProc_OP_I; } set { _NoofProc_OP_I = value; } }
        public int NoofComp_OP_I { get { return _NoofComp_OP_I; } set { _NoofComp_OP_I = value; } }
        public int NoofPrint_OP_I { get { return _NoofPrint_OP_I; } set { _NoofPrint_OP_I = value; } }
        public int NoofBind_OP_I { get { return _NoofBind_OP_I; } set { _NoofBind_OP_I = value; } }
        public int NoofMisc_OP_I { get { return _NoofMisc_OP_I; } set { _NoofMisc_OP_I = value; } }
        public int NoofTotal_OP_I { get { return _NoofTotal_OP_I; } set { _NoofTotal_OP_I = value; } }
        public int NoofProc_Su_I { get { return _NoofProc_Su_I; } set { _NoofProc_Su_I = value; } }
        public int NoofComp_Su_I { get { return _NoofComp_Su_I; } set { _NoofComp_Su_I = value; } }
        public int NoofPrint_Su_I { get { return _NoofPrint_Su_I; } set { _NoofPrint_Su_I = value; } }
        public int NoofBind_Su_I { get { return _NoofBind_Su_I; } set { _NoofBind_Su_I = value; } }
        public int NoofMisc_Su_I { get { return _NoofMisc_Su_I; } set { _NoofMisc_Su_I = value; } }
        public int NoofTotal_Su_I { get { return _NoofTotal_Su_I; } set { _NoofTotal_Su_I = value; } }
        public int NoofProofreader_I { get { return _NoofProofreader_I; } set { _NoofProofreader_I = value; } }
        public int Isactive_I { get { return _Isactive_I; } set { _Isactive_I = value; } }
        public int IsOffsetReg_I { get { return _IsOffsetReg_I; } set { _IsOffsetReg_I = value; } }
        public int RegforYear_I { get { return _RegforYear_I; } set { _RegforYear_I = value; } }

        public int PriMacID_I { get { return _PriMacID_I; } set { _PriMacID_I = value; } }
        public int MachineID_I { get { return _MachineID_I; } set { _MachineID_I = value; } }

        public int Year_I { get { return _Year_I; } set { _Year_I = value; } }
        public int nOOFmACHINE { get { return _nOOFmACHINE; } set { _nOOFmACHINE = value; } }
        public int ComposingCapP1_I { get { return _ComposingCapP1_I; } set { _ComposingCapP1_I = value; } }

        public int ComposingCapP2_I { get { return _ComposingCapP2_I; } set { _ComposingCapP2_I = value; } }
        public int ComposingCapP3_I { get { return _ComposingCapP3_I; } set { _ComposingCapP3_I = value; } }

        public int RegOthID { get { return _RegOthID; } set { _RegOthID = value; } }

        public int NOofTitle_TBCPrint_I { get { return _NOofTitle_TBCPrint_I; } set { _NOofTitle_TBCPrint_I = value; } }
        public int NOofTitle_OThTBCPrint_I { get { return _NOofTitle_OThTBCPrint_I; } set { _NOofTitle_OThTBCPrint_I = value; } }
        public int NOofTitle_OThPrint_I { get { return _NOofTitle_OThPrint_I; } set { _NOofTitle_OThPrint_I = value; } }

        public int ApprovContractor_I { get { return _ApprovContractor_I; } set { _ApprovContractor_I = value; } }

        public int IncometaxPay { get { return _IncometaxPay; } set { _IncometaxPay = value; } }
        public int UserID_I { get { return _UserID_I; } set { _UserID_I = value; } }
        public int NOofTitle_MPTBCPrint_I { get { return _NOofTitle_MPTBCPrint_I; } set { _NOofTitle_MPTBCPrint_I = value; } }
        public int Last3YearQuantity_I { get { return _Last3YearQuantity_I; } set { _Last3YearQuantity_I = value; } }



        public int OtherCorpNo_I { get { return _OtherCorpNo_I; } set { _OtherCorpNo_I = value; } }



        public string Regno_I { get { return _Regno_I; } set { _Regno_I = value; } }
        public string Grade_V { get { return _Grade_V; } set { _Grade_V = value; } }
        public string NameofPress_V { get { return _NameofPress_V; } set { _NameofPress_V = value; } }
        public string NameofPressHindi_V { get { return _NameofPressHindi_V; } set { _NameofPressHindi_V = value; } }
        public string FullAddress_V { get { return _FullAddress_V; } set { _FullAddress_V = value; } }
        public string Headoffice_V { get { return _Headoffice_V; } set { _Headoffice_V = value; } }
        public string BOTelegraph_Add_V { get { return _BOTelegraph_Add_V; } set { _BOTelegraph_Add_V = value; } }
        public string FacRegNo_V { get { return _FacRegNo_V; } set { _FacRegNo_V = value; } }
        public string RegDet_V { get { return _RegDet_V; } set { _RegDet_V = value; } }
        public string Profreadpath_v { get { return _Profreadpath_v; } set { _Profreadpath_v = value; } }
        public string RegDetails_V { get { return _RegDetails_V; } set { _RegDetails_V = value; } }
        public string OwnerDeail_V { get { return _OwnerDeail_V; } set { _OwnerDeail_V = value; } }
        public string Make_V { get { return _Make_V; } set { _Make_V = value; } }

        public string FoundaryTyAtt_V { get { return _FoundaryTyAtt_V; } set { _FoundaryTyAtt_V = value; } }
        public string pRINcAPASITY_v { get { return _pRINcAPASITY_v; } set { _pRINcAPASITY_v = value; } }

        public string Composing_Monotype_V { get { return _Composing_Monotype_V; } set { _Composing_Monotype_V = value; } }
        public string Composing_Linotype_V { get { return _Composing_Linotype_V; } set { _Composing_Linotype_V = value; } }
        public string ComposAnyOthtype_V { get { return _ComposAnyOthtype_V; } set { _ComposAnyOthtype_V = value; } }
        public string ComposingCapL1_V { get { return _ComposingCapL1_V; } set { _ComposingCapL1_V = value; } }
        public string ComposingCapL2_V { get { return _ComposingCapL2_V; } set { _ComposingCapL2_V = value; } }
        public string ComposingCapL3_V { get { return _ComposingCapL3_V; } set { _ComposingCapL3_V = value; } }

        public string LanguagesTxtSetAttach_V { get { return _LanguagesTxtSetAttach_V; } set { _LanguagesTxtSetAttach_V = value; } }

        public string NameOfTitle_OThTBCPrint_V { get { return _LanguagesTxtSetAttach_V; } set { _LanguagesTxtSetAttach_V = value; } }
        public string OtherCorpName_V { get { return _OtherCorpName_V; } set { _OtherCorpName_V = value; } }
        public string PayMode_V { get { return _PayMode_V; } set { _PayMode_V = value; } }
        public string BankName_V { get { return _BankName_V; } set { _BankName_V = value; } }
        public string MachineNo_V { get { return _MachineNo_V; } set { _MachineNo_V = value; } }

        public DateTime Est_Date_D { get { return _Est_Date_D; } set { _Est_Date_D = value; } }
        public DateTime RegDate_D { get { return _RegDate_D; } set { _RegDate_D = value; } }
        public DateTime DateOfInstallation_D { get { return _DateOfInstallation_D; } set { _DateOfInstallation_D = value; } }
        public DateTime TransDate_d { get { return _TransDate_d; } set { _TransDate_d = value; } }
        public DateTime RegistrationDate { get { return _RegistrationDate; } set { _RegistrationDate = value; } }

        public double AreaOccupies_N { get { return _AreaOccupies_N; } set { _AreaOccupies_N = value; } }
        public double Regamount_N { get { return _Regamount_N; } set { _Regamount_N = value; } }



        public int PriBindID_I { get { return _PriBindID_I; } set { _PriBindID_I = value; } }
        public int Mac_FoldingNos_I { get { return _Mac_FoldingNos_I; } set { _Mac_FoldingNos_I = value; } }
        public int Mac_StichgNos_I { get { return _Mac_StichgNos_I; } set { _Mac_StichgNos_I = value; } }
        public int Mac_CutNos_I { get { return _Mac_CutNos_I; } set { _Mac_CutNos_I = value; } }
        public int Mac_othNos_I { get { return _Mac_othNos_I; } set { _Mac_othNos_I = value; } }
        public int Book1BindCapNo_I { get { return _Book1BindCapNo_I; } set { _Book1BindCapNo_I = value; } }
        public int Book2BindCapNo_I { get { return _Book2BindCapNo_I; } set { _Book2BindCapNo_I = value; } }
        public int BookBindCapNo_I { get { return _BookBindCapNo_I; } set { _BookBindCapNo_I = value; } }

        public string Mac_FoldingMake_V { get { return _Mac_FoldingMake_V; } set { _Mac_FoldingMake_V = value; } }
        public string Mac_FoldingSize_V { get { return _Mac_FoldingSize_V; } set { _Mac_FoldingSize_V = value; } }

        public string Mac_FoldingOwned_V { get { return _Mac_FoldingOwned_V; } set { _Mac_FoldingOwned_V = value; } }
        public string Mac_StichgMake_V { get { return _Mac_StichgMake_V; } set { _Mac_StichgMake_V = value; } }
        public string Mac_StichgSize_V { get { return _Mac_StichgSize_V; } set { _Mac_StichgSize_V = value; } }

        public string Mac_StichgOwned_V { get { return _Mac_StichgOwned_V; } set { _Mac_StichgOwned_V = value; } }
        public string Mac_CutMake_V { get { return _Mac_CutMake_V; } set { _Mac_CutMake_V = value; } }
        public string Mac_CutSize_V { get { return _Mac_CutSize_V; } set { _Mac_CutSize_V = value; } }

        public string Mac_CutOwned_V { get { return _Mac_CutOwned_V; } set { _Mac_CutOwned_V = value; } }
        public string Mac_othMake_V { get { return _Mac_othMake_V; } set { _Mac_othMake_V = value; } }
        public string Mac_othSize_V { get { return _Mac_othSize_V; } set { _Mac_othSize_V = value; } }

        public string Mac_othOwned_V { get { return _Mac_othOwned_V; } set { _Mac_othOwned_V = value; } }
        public string Bookname_V { get { return _Bookname_V; } set { _Bookname_V = value; } }

        public string Bookname1_V { get { return _Bookname1_V; } set { _Bookname1_V = value; } }

        public string Bookname2_V { get { return _Bookname2_V; } set { _Bookname2_V = value; } }

        public string OffsetCameraSize_V { get { return _OffsetCameraSize_V; } set { _OffsetCameraSize_V = value; } }
        public string OffsetCameraMake_V { get { return _OffsetCameraMake_V; } set { _OffsetCameraMake_V = value; } }
        public string OffsetWhirlarSize_V { get { return _OffsetWhirlarSize_V; } set { _OffsetWhirlarSize_V = value; } }
        public string OffsetWhirlarMake_V { get { return _OffsetWhirlarMake_V; } set { _OffsetWhirlarMake_V = value; } }
        public string OffsetOthSize_V { get { return _OffsetOthSize_V; } set { _OffsetOthSize_V = value; } }
        public string OffsetOthMake_V { get { return _OffsetOthMake_V; } set { _OffsetOthMake_V = value; } }
        public string OffsetConCabSize_V { get { return _OffsetConCabSize_V; } set { _OffsetConCabSize_V = value; } }
        public string OffsetConCabMake_V { get { return _OffsetConCabMake_V; } set { _OffsetConCabMake_V = value; } }

        public string OffsetConCabSize_V1 { get { return _OffsetConCabSize_V1; } set { _OffsetConCabSize_V1 = value; } }
        public string OffsetConCabMake_V1 { get { return _OffsetConCabMake_V1; } set { _OffsetConCabMake_V1 = value; } }



        public string Noofshift_V { get { return _Noofshift_V; } set { _Noofshift_V = value; } }
        public string BookPrintExperience_V { get { return _BookPrintExperience_V; } set { _BookPrintExperience_V = value; } }
        public string WareHouseDet_V { get { return _WareHouseDet_V; } set { _WareHouseDet_V = value; } }
        public string Premises_GoodIns_V { get { return _Premises_GoodIns_V; } set { _Premises_GoodIns_V = value; } }
        public string Ins_CoverDetail_V { get { return _Ins_CoverDetail_V; } set { _Ins_CoverDetail_V = value; } }
        public string Nameaddbanker_v { get { return _Nameaddbanker_v; } set { _Nameaddbanker_v = value; } }
        public string AnyOthDetails_V { get { return _AnyOthDetails_V; } set { _AnyOthDetails_V = value; } }




        public string Password_V { get { return _Password_V; } set { _Password_V = value; } }
        public int RoleTrno_I { get { return _RoleTrno_I; } set { _RoleTrno_I = value; } }
        public string UserType_V { get { return _UserType_V; } set { _UserType_V = value; } }

        public DataSet MachineDesLoad()
        {
            DataSet ds = new DataSet();
            DBAccess obj = new DBAccess();

            obj.execute("USP_PRI001_MachineMasterLoad", DBAccess.SQLType.IS_PROC);
            obj.addParam("ID", MachineID_I);
            ds = obj.records();

            return ds;
        }

        // function for printer details(tab 1) save 
        public int PrinterRegistrationsaveUpdate()
        {
            int i = 0;
            DBAccess obj = new DBAccess();
            obj.execute("USP_PRI004_PrinterRegistrationsave", DBAccess.SQLType.IS_PROC);

            obj.addParam("mPrinter_RedID_I", Printer_RedID_I);
            obj.addParam("mRegno_I", Regno_I);
            obj.addParam("mGrade_V", Grade_V);
            obj.addParam("mNameofPress_V", NameofPress_V);
            obj.addParam("mFullAddress_V", FullAddress_V);
            obj.addParam("mHeadoffice_V", Headoffice_V);
            obj.addParam("mBOTelegraph_Add_V", BOTelegraph_Add_V);
            obj.addParam("mEst_Date_D", Est_Date_D);
            obj.addParam("mAreaOccupies_N", AreaOccupies_N);
            obj.addParam("mAreaType_I", AreaType_I);
            obj.addParam("mFacRegNo_V", FacRegNo_V);
            obj.addParam("mReginComact_I", ReginComact_I);
            obj.addParam("mRegDet_V", RegDet_V);
            obj.addParam("mNoofProc_OP_I", NoofProc_OP_I);
            obj.addParam("mNoofComp_OP_I", NoofComp_OP_I);
            obj.addParam("mNoofPrint_OP_I", NoofPrint_OP_I);
            obj.addParam("mNoofBind_OP_I", NoofBind_OP_I);
            obj.addParam("mNoofMisc_OP_I", NoofMisc_OP_I);
            obj.addParam("mNoofTotal_OP_I", NoofTotal_OP_I);
            obj.addParam("mNoofProc_Su_I", NoofProc_Su_I);
            obj.addParam("mNoofComp_Su_I", NoofComp_Su_I);
            obj.addParam("mNoofPrint_Su_I", NoofPrint_Su_I);
            obj.addParam("mNoofBind_Su_I", NoofBind_Su_I);
            obj.addParam("mNoofMisc_Su_I", NoofMisc_Su_I);
            obj.addParam("mNoofTotal_Su_I", NoofTotal_Su_I);
            obj.addParam("mNoofProofreader_I", NoofProofreader_I);
            obj.addParam("mProfreadpath_v", Profreadpath_v);
            obj.addParam("mIsactive_I", Isactive_I);
            obj.addParam("mIsOffsetReg_I", IsOffsetReg_I);

            obj.addParam("mRegDate_D", RegDate_D);
            obj.addParam("mRegforYear_I", RegforYear_I);
            obj.addParam("mRegamount_N", Regamount_N);
            obj.addParam("mRegDetails_V", RegDetails_V);
            obj.addParam("mOwnerDeail_V", OwnerDeail_V);
            obj.addParam("mPayMode_V", PayMode_V);
            obj.addParam("mBankName_V", BankName_V);
            obj.addParam("mRegistrationDate", RegistrationDate);
            obj.addParam("mNameofPressHindi_V", NameofPressHindi_V); 
            i = Convert.ToInt32(obj.executeMyScalar()); 
            return i; 
        }



        // function for load View Form Detail

        public DataSet PrinterRegistrationDetailLoad()
        {
            DataSet ds = new DataSet();
            DBAccess obj = new DBAccess();

            obj.execute("USP_PRI001_PrinterDetailsLoad", DBAccess.SQLType.IS_PROC);



            ds = obj.records();

            return ds;

        }


        public DataSet PrinterRegistrationSearchDetailLoad()
        {
            DataSet ds = new DataSet();
            DBAccess obj = new DBAccess();

            obj.execute("USP_PRI001_PrinterDetailsSearchLoad", DBAccess.SQLType.IS_PROC);
            obj.addParam("mPrineterName", NameofPress_V);


            ds = obj.records();

            return ds;

        }

        // function for printer details(tab 1) Load 

        public DataSet PrinterRegistrationLoad()
        {
            DataSet ds = new DataSet();
            DBAccess obj = new DBAccess();

            obj.execute("USP_PRI004_PrinterRegistrationload", DBAccess.SQLType.IS_PROC);

            obj.addParam("mPrinter_RedID_I", Printer_RedID_I);

            ds = obj.records();

            return ds;

        }
        // function for Machine details Load 

        public DataTable MachineLoad(int id)
        {
            DataTable Dt = new DataTable();
            DBAccess obj = new DBAccess();
            obj.execute("USP_PRI004_printermachineDetailsRpt", DBAccess.SQLType.IS_PROC);
            obj.addParam("mPrinter_RedID_I", Printer_RedID_I);
            obj.addParam("mtype", id);
            Dt= obj.records1();
            return Dt;
        }

        // function for Machine details(tab 2) save 

        public int PrinterMachineDetailsSaveUpdate()
        {
            DBAccess obj = new DBAccess();
            obj.execute("USP_PRI004_printermachinedetailsave", DBAccess.SQLType.IS_PROC);


            obj.addParam("mPriMacID_I", PriMacDesID_I);
            obj.addParam("mPrinter_RedID_I", Printer_RedID_I);
            obj.addParam("mComposing_Monotype_V", Composing_Monotype_V);
            obj.addParam("mComposing_Linotype_V", Composing_Linotype_V);
            obj.addParam("mComposAnyOthtype_V", ComposAnyOthtype_V);
            obj.addParam("mFoundaryTyAtt_V", FoundaryTyAtt_V);
            obj.addParam("mComposingCapL1_V", ComposingCapL1_V);
            obj.addParam("mComposingCapP1_I", ComposingCapP1_I);
            obj.addParam("mComposingCapL2_V", ComposingCapL2_V);
            obj.addParam("mComposingCapP2_I", ComposingCapP2_I);
            obj.addParam("mComposingCapL3_V", ComposingCapL3_V);
            obj.addParam("mComposingCapP3_I", ComposingCapP3_I);
            obj.addParam("mLanguagesTxtSetAttach_V", LanguagesTxtSetAttach_V);

            int i = Convert.ToInt32(obj.executeMyScalar());


            return i;

        }



        // function for machine list(tab 2) save 
        public int PrinterMachineListSaveUpdate()
        {
            DBAccess obj = new DBAccess();
            obj.execute("USP_PRI004_printermachineListSave", DBAccess.SQLType.IS_PROC);

            obj.addParam("mPriMacID_I", PriMacID_I);
            obj.addParam("mMachineID_I", MachineID_I);
            obj.addParam("mPrinter_RedID_I", Printer_RedID_I);
            obj.addParam("mMake_V", Make_V);
            obj.addParam("mYear_I", Year_I);
            obj.addParam("mFoundaryTyAtt_V", FoundaryTyAtt_V);
            obj.addParam("mnOOFmACHINE", nOOFmACHINE);
            obj.addParam("mpRINcAPASITY_v", pRINcAPASITY_v);
            obj.addParam("mDateOfInstallation_D", DateOfInstallation_D);
            obj.addParam("mMachineNo_V", MachineNo_V);

            int i = obj.executeMyQuery();

            return i;

        }




        // function to save checklist 


        public int PrinterRegistrationChkSaveUpdate()
        {

            DBAccess obDBAccess = new DBAccess();

            obDBAccess.execute("USP_PRI004_PrinterRegChkLstSave", DBAccess.SQLType.IS_PROC);

            obDBAccess.addParam("mRegChkLSTID_I", RegChkLSTID_I);
            obDBAccess.addParam("mPrinter_RedID_I", Printer_RedID_I);
            obDBAccess.addParam("mRegAmount_I", RegAmount_I);
            obDBAccess.addParam("mPressActCert_I", PressActCert_I);
            obDBAccess.addParam("mIncometaxClearance_I", IncometaxClearance_I);
            obDBAccess.addParam("mLastThreeYrsPrinting_I", LastThreeYrsPrinting_I);
            obDBAccess.addParam("mMacPurchaseBillcopy_I", MacPurchaseBillcopy_I);
            obDBAccess.addParam("mInsurance_I", Insurance_I);
            obDBAccess.addParam("mOther_I", Other_I);
            obDBAccess.addParam("mOtherDet_V", OtherDet_V);
            obDBAccess.addParam("mProcessCamera_I", ProcessCamera_I);
            obDBAccess.addParam("mPlateMat_I", PlateMat_I);
            obDBAccess.addParam("mSingleColOffset_I", SingleColOffset_I);
            obDBAccess.addParam("mBindingFacility_I", BindingFacility_I);


            int result = Convert.ToInt32(obDBAccess.executeMyScalar());
            return result;

        }

        // function to load checklist 
        public DataSet PrinterRegistrationChkLoad()
        {
            DataSet ds = new DataSet();
            DBAccess obj = new DBAccess();

            obj.execute("USP_PRI004_PrinterRegChkLstLoad", DBAccess.SQLType.IS_PROC);
            //obj.addParam("mRegChkLSTID_I", RegChkLSTID_I);
            obj.addParam("mPrinter_RedID_I", Printer_RedID_I);
            ds = obj.records();

            return ds;


        }


        //  // function for machine Description (tab 2) load

        public DataSet PrinterMachineDescriptionLoad()
        {
            DataSet ds = new DataSet();
            DBAccess obj = new DBAccess();

            obj.execute("USP_PRI004_printermachinedetailLoad", DBAccess.SQLType.IS_PROC);
            obj.addParam("mPriMacID_I", PriMacID_I);
            obj.addParam("mPrinter_RedID_I", Printer_RedID_I);

            ds = obj.records();

            return ds;


        }




        //  // function for machine list (tab 2) load

        public DataSet PrinterMachineListLoad()
        {
            DataSet ds = new DataSet();
            DBAccess obj = new DBAccess();

            obj.execute("USP_PRI004_printermachineListLoad", DBAccess.SQLType.IS_PROC);
            obj.addParam("mPriMacID_I", PriMacID_I);
            obj.addParam("mPrinter_RedID_I", Printer_RedID_I);

            ds = obj.records();

            return ds;


        }


        //  // function for Binding details (tab 3) save
        public int BindingDetailsSaveUpdate()
        {
            DBAccess obj = new DBAccess();
            int i = 0;

            obj.execute("USP_PPR001_PrinterBindSave", DBAccess.SQLType.IS_PROC);
            obj.addParam("mPriBindID_I", PriBindID_I);
            obj.addParam("mPrinter_RedID_I", Printer_RedID_I);
            obj.addParam("mMac_FoldingMake_V", Mac_FoldingMake_V);
            obj.addParam("mMac_FoldingSize_V", Mac_FoldingSize_V);
            obj.addParam("mMac_FoldingNos_I", Mac_FoldingNos_I);
            obj.addParam("mMac_FoldingOwned_V", Mac_FoldingOwned_V);
            obj.addParam("mMac_StichgMake_V", Mac_StichgMake_V);
            obj.addParam("mMac_StichgSize_V", Mac_StichgSize_V);
            obj.addParam("mMac_StichgNos_I", Mac_StichgNos_I);
            obj.addParam("mMac_StichgOwned_V", Mac_StichgOwned_V);
            obj.addParam("mMac_CutMake_V", Mac_CutMake_V);
            obj.addParam("mMac_CutSize_V", Mac_CutSize_V);
            obj.addParam("mMac_CutNos_I", Mac_CutNos_I);
            obj.addParam("mMac_CutOwned_V", Mac_CutOwned_V);
            obj.addParam("mMac_othMake_V", Mac_othMake_V);
            obj.addParam("mMac_othSize_V", Mac_othSize_V);
            obj.addParam("mMac_othNos_I", Mac_othNos_I);
            obj.addParam("mMac_othOwned_V", Mac_othOwned_V);
            obj.addParam("mBookname_V", Bookname_V);
            obj.addParam("mBook1BindCapNo_I", Book1BindCapNo_I);
            obj.addParam("mBookname1_V", Bookname1_V);
            obj.addParam("mBook2BindCapNo_I", Book2BindCapNo_I);
            obj.addParam("mBookname2_V", Bookname2_V);
            obj.addParam("mBookBindCapNo_I", BookBindCapNo_I);
            obj.addParam("mOffsetCameraSize_V", OffsetCameraSize_V);
            obj.addParam("mOffsetCameraMake_V", OffsetCameraMake_V);
            obj.addParam("mOffsetWhirlarSize_V", OffsetWhirlarSize_V);
            obj.addParam("mOffsetWhirlarMake_V", OffsetWhirlarMake_V);
            obj.addParam("mOffsetOthSize_V", OffsetOthSize_V);
            obj.addParam("mOffsetOthMake_V", OffsetOthMake_V);
            obj.addParam("mOffsetConCabSize_V", OffsetConCabSize_V);
            obj.addParam("mOffsetConCabMake_V", OffsetConCabMake_V);

            obj.addParam("mOffsetConCabSize_V1", OffsetConCabSize_V1);
            obj.addParam("mOffsetConCabMake_V1", OffsetConCabMake_V1);


            i = Convert.ToInt32(obj.executeMyScalar());

            return i;


        }


        // function to load binding details tab 3

        public DataSet BindingDetailsLoad()
        {
            DataSet ds = new DataSet();
            DBAccess obj = new DBAccess();

            obj.execute("USP_PPR001_PrinterBindLoad", DBAccess.SQLType.IS_PROC);
            obj.addParam("mPriBindID_I", PriBindID_I);
            obj.addParam("mPrinter_RedID_I", Printer_RedID_I);

            ds = obj.records();

            return ds;


        }

        public int OtherDetailsSave()
        {

            DBAccess obj = new DBAccess();
            int i = 0;
            obj.execute("USP_PRI004_PrinterregOtherdetsave", DBAccess.SQLType.IS_PROC);
            obj.addParam("mRegOthID", RegOthID);
            obj.addParam("mNoofshift_V", Noofshift_V);
            obj.addParam("mBookPrintExperience_V", BookPrintExperience_V);
            obj.addParam("mNOofTitle_TBCPrint_I", NOofTitle_TBCPrint_I);
            obj.addParam("mNOofTitle_OThTBCPrint_I", NOofTitle_OThTBCPrint_I);
            obj.addParam("mNOofTitle_OThPrint_I", NOofTitle_OThPrint_I);
            obj.addParam("mWareHouseDet_V", WareHouseDet_V);
            obj.addParam("mPremises_GoodIns_V", Premises_GoodIns_V);
            obj.addParam("mIns_CoverDetail_V", Ins_CoverDetail_V);
            obj.addParam("mNameaddbanker_v", Nameaddbanker_v);
            obj.addParam("mApprovContractor_I", ApprovContractor_I);
            obj.addParam("mAnyOthDetails_V", AnyOthDetails_V);
            obj.addParam("mIncometaxPay", IncometaxPay);
            obj.addParam("mUserID_I", UserID_I);
            obj.addParam("mNOofTitle_MPTBCPrint_I", NOofTitle_MPTBCPrint_I);
            obj.addParam("mLast3YearQuantity_I", Last3YearQuantity_I);
            obj.addParam("mPrinter_RedID_I", Printer_RedID_I);

            obj.addParam("mNameOfTitle_OThTBCPrint_V", NameOfTitle_OThTBCPrint_V);

            obj.addParam("mOtherCorpName_V", OtherCorpName_V);
            obj.addParam("mOtherCorpNo_I", OtherCorpNo_I);



            i = Convert.ToInt32(obj.executeMyScalar());

            return i;

        }



        public DataSet OtherDetailsLoad()
        {
            DataSet ds = new DataSet();
            DBAccess obj = new DBAccess();

            obj.execute("USP_PRI004_PrinterregOtherdetload", DBAccess.SQLType.IS_PROC);
            obj.addParam("mRegOthID", RegOthID);
            obj.addParam("mPrinter_RedID_I", Printer_RedID_I);

            ds = obj.records();

            return ds;

        }


        public DataSet LoadUserID()
        {
            DataSet ds = new DataSet();
            DBAccess obj = new DBAccess();

            obj.execute("USP_PRI001_GetPrinterUserIDDetail", DBAccess.SQLType.IS_PROC);

            obj.addParam("mPrinter_RedID_I", Printer_RedID_I);

            ds = obj.records();

            return ds;

        }

        public int SaveUserID()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM007_UserMasterSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mUserID_I", UserID_I);
            obDBAccess.addParam("mUserName_V", Regno_I);
            obDBAccess.addParam("mPassword_V", Password_V);
            obDBAccess.addParam("mRoleTrno_I", RoleTrno_I);
            obDBAccess.addParam("mUserType_V", UserType_V);
            obDBAccess.addParam("mTranID", UserID_I);

            int result = Convert.ToInt32(obDBAccess.executeMyScalar());
            return result;
        }

        public int SaveUserIDFromPrinter()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM007_UserMasterSavePrinter", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mUserID_I", UserID_I);
            obDBAccess.addParam("mUserName_V", Regno_I);
            obDBAccess.addParam("mPassword_V", Password_V);
            obDBAccess.addParam("mRoleTrno_I", RoleTrno_I);
            obDBAccess.addParam("mUserType_V", UserType_V);
            obDBAccess.addParam("mTranID", UserID_I);
            obDBAccess.addParam("mOfficerName_V", NameofPress_V);
            int result = Convert.ToInt32(obDBAccess.executeMyScalar());
            return result;
        }

        public int UpdateUserID()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PRI001_UserIDUpdate", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mUserID_I", UserID_I);
            obDBAccess.addParam("mPrinter_RedID_I", Printer_RedID_I);


            int result = obDBAccess.executeMyQuery();
            return result;
        }

        //printer detail on user transaction 
        public DataSet GetPrinterDetails() 
        {
            DataSet ds = new DataSet();
            DBAccess obj = new DBAccess();

            obj.execute("USP_PRI001_GetPrinterDetailsByUserID", DBAccess.SQLType.IS_PROC);

            obj.addParam("mUserID_I", UserID_I);

            ds = obj.records();
            return ds;
        }

        //printer detail on user transaction 
        public DataSet GetChallanDetailFromDepo()
        {
            DataSet ds = new DataSet();
            DBAccess obj = new DBAccess();

            obj.execute("USP_PRI004_printerChallanDepo", DBAccess.SQLType.IS_PROC);
            obj.addParam("mStockReceivedTPerID_I", 0);
             obj.addParam("mPrinter_Id", Printer_RedID_I);
             obj.addParam("mStatus", 0);
             obj.addParam("mtype", 0);
            ds = obj.records();
            return ds;
        } //printer detail on user transaction 


        public DataSet GetTenderwisegroupallotDetail()
        {
            DataSet ds = new DataSet();
            DBAccess obj = new DBAccess();

            obj.execute("USP_RPRI008_printendergroupallotdetail", DBAccess.SQLType.IS_PROC);
            //Regno_I used for finyear
            obj.addParam("mFinYear", Regno_I);
            obj.addParam("mPrinter_Id", Printer_RedID_I);
            ds = obj.records();
            return ds;
        } //printer detail on user transaction 

        public int GetChallanDetailFromDepoStatusChange(int Printer_Id)
        {
         
            DBAccess obj = new DBAccess();

            obj.execute("USP_PRI004_printerChallanDepo", DBAccess.SQLType.IS_PROC);
            obj.addParam("mStockReceivedTPerID_I", 0);
            obj.addParam("mPrinter_Id", Printer_Id);
            obj.addParam("mStatus", 0);
            obj.addParam("mtype", 1);
            int result = obj.executeMyQuery();
            return result;
        }


        public int GetVitranNirdesh(int Printer_Id)
        {

            DBAccess obj = new DBAccess();

            obj.execute("USP_PRI004_printerChallanDepo", DBAccess.SQLType.IS_PROC);
            obj.addParam("mStockReceivedTPerID_I", 0);
            obj.addParam("mPrinter_Id", Printer_Id);
            obj.addParam("mStatus", 0);
            obj.addParam("mtype", 1);
            int result = obj.executeMyQuery();
            return result;
        }

        public int InsertUpdate()
        {
            int i = 0;

            i = PrinterRegistrationsaveUpdate();

            return i;
        }

        public DataSet Select()
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }


        // End
    }
}

