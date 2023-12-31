function ChangeClass(Domain) {
    if (Domain == 'SSA') {
        document.getElementById('ICON').className = 'IconSSA';
    }
    if (Domain == 'YojnaPanchayat') {
        document.getElementById('ICON').className = 'IconYojnaPanchayat';
    }
    if (Domain == 'Cedmap') {
        document.getElementById('ICON').className = 'IconCedmap';
    }
    if (Domain == 'Jansampark') {
        document.getElementById('ICON').className = 'IconJansampark';
    }
    if (Domain == 'YojnaSagar') {
        document.getElementById('ICON').className = 'IconYojnaSagar';
    }
    if (Domain == 'ULB') {
        document.getElementById('ICON').className = 'IconULB';
    }
    if (Domain == 'ADV') {
        document.getElementById('ICON').className = 'IconADV';
    }
    if (Domain == 'SOR') {
        document.getElementById('ICON').className = 'IconSOR';
    }
    if (Domain == 'Cicc') {
        document.getElementById('ICON').className = 'IconCicc';
    }
    if (Domain == 'eCashBook') {
        document.getElementById('ICON').className = 'IconeCashBook';
    }
    if (Domain == 'Training') {
        document.getElementById('ICON').className = 'Icon_T_erp';
    }
    if (Domain == 'Prathamsoftware') {
        document.getElementById('ICON').className = 'IconPS';
    }

    //=============== Screen Width Code Start ===============//

    var table = document.getElementById('MainTable');
    if (table != 'undefined' && table != null) {
        if (screen.width >= 1280) {
            table.className = 'TableWidth_1280';
        } else if (screen.width >= 1024) {
            table.className = 'TableWidth_1024';
        } else if (screen.width >= 800) {
            table.className = 'TableWidth_800';
        }
    }
}


function ChangeLogoClass(Domain) {
    if (Domain == 'SSA') {
        document.getElementById('PSbanner').style.display = 'block';
    }
    if (Domain == 'YojnaPanchayat') {
        document.getElementById('PSbanner').style.display = 'block';
    }
    if (Domain == 'Cedmap') {
        document.getElementById('PSbanner').style.display = 'block';
    }
    if (Domain == 'Jansampark') {
        document.getElementById('PSbanner').style.display = 'block';
    }
    if (Domain == 'ULB') {
        document.getElementById('ULBbanner').style.display = 'block';
    }
    if (Domain == 'SOR') {
        document.getElementById('sorbanner').style.display = 'block';
    }
    if (Domain == 'Training') {
        document.getElementById('Trainingbanner').style.display = 'block';
    }
    if (Domain == 'YojnaSagar') {
        document.getElementById('Sagarbanner').style.display = 'block';
    }
    if (Domain == 'Prathamsoftware') {
        document.getElementById('PSbanner').style.display = 'block';
    }
    if (Domain == 'ADV') {
        document.getElementById('ADVbanner').style.display = 'block';
    }
    //=============== Screen Width Code Start ===============//
    var table = document.getElementById('MainTable');
    if (table != 'undefined' && table != null) {
        if (screen.width >= 1280) {
            table.className = 'TableWidth_1280';
        } else if (screen.width >= 1024) {
            table.className = 'TableWidth_1024';

        } else if (screen.width >= 800) {
            table.className = 'TableWidth_800';
        }
    }
}

//=============== All WaterMark Function Start ===============//
function ChangeWaterClass(Domain) {

    if (Domain == 'SSA') {
        document.getElementById('WATERMARK').className = 'ssawatermark_img';
    }
    if (Domain == 'Cedmap') {
        document.getElementById('WATERMARK').className = 'erpwatermark_img';
    }
    if (Domain == 'YojnaPanchayat') {
        document.getElementById('WATERMARK').className = 'erpwatermark_img';
    }
    if (Domain == 'Jansampark') {
        document.getElementById('WATERMARK').className = 'erpwatermark_img';
    }
    if (Domain == 'ULB') {
        document.getElementById('WATERMARK').className = 'ulbwatermark_img';
    }
    if (Domain == 'SOR') {
        document.getElementById('WATERMARK').className = 'sorwatermark_img';
    }
    if (Domain == 'Training') {
        document.getElementById('WATERMARK').className = 'erpwatermark_img';
    }
    if (Domain == 'YojnaSagar') {
        document.getElementById('WATERMARK').className = 'sagarwatermark_img';
    }
    if (Domain == 'Prathamsoftware') {
        document.getElementById('WATERMARK').className = 'PSwatermark_img';
    }
    if (Domain == 'ADV') {
        document.getElementById('WATERMARK').className = 'ADVwatermark_img';
    }
}
//=============== here 1: English,0: Hindi,2:===================//
var GlobalLanguage;
function ChangeLabel(Choice, FormId, QueryString) {

    GlobalLanguage = Choice;

    //Form ID 955, Form Name:Budget/frmBudgetAllotConfiguration.aspx change on 09.08.2012 implement try/catch by prince
    //    if (Choice == 0 && FormId == 955) {
    if (Choice == 0 && FormId == 2530) {
        try {
            document.getElementById("LblHeader").innerHTML = "बजट कॉन्फीगरेशन";
            document.getElementById("hlHome").innerHTML = "होमपेज";
            document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
            // Hindi,English Radio button code
            var RBHindi = document.getElementById("rbHindi");
            var RB = RBHindi.parentNode.getElementsByTagName("label");
            RB[0].innerHTML = "हिन्दी";

            var RBenglish = document.getElementById("rbenglish");
            var RB = RBenglish.parentNode.getElementsByTagName("label");
            RB[0].innerHTML = "English";
            document.getElementById("LblScheme").innerHTML = "स्कीम का नाम";
            document.getElementById("lblABranchtype").innerHTML = "शाखा का प्रकार ";
            document.getElementById("LblBranch").innerHTML = "शाखा का नाम";
            document.getElementById("lblBank").innerHTML = "बैंक का नाम";
            document.getElementById("lblgroupby").innerHTML = "ग्रुप आधार";
            document.getElementById("btnAdd").value = "रक्षित करें";
            document.getElementById("btnprint").value = "प्रिन्ट करें";
            document.getElementById("lblbanklegerConfg").innerHTML = "बैंक लेजर कॉन्फीगरेशन";
            //-----------Font size-------------//
            document.getElementById("LblHeader").className = "Frm_Head_Hindi";
            document.getElementById("LblScheme").className = "Frm_Txt_Hindi";
            document.getElementById("ddlScheme").className = "ddl_Hindi";
            document.getElementById("lblABranchtype").className = "Frm_Txt_Hindi";
            document.getElementById("ddlAgencytype").className = "ddl_Hindi";
            document.getElementById("LblBranch").className = "Frm_Txt_Hindi";
            document.getElementById("DdlAgency").className = "ddl_Hindi";
            document.getElementById("lblBank").className = "Frm_Txt_Hindi";
            document.getElementById("DdlBank").className = "ddl_Hindi";
            document.getElementById("lblgroupby").className = "Frm_Txt_Hindi";
            document.getElementById("btnAdd").className = "btn_Hindi";
            document.getElementById("btnprint").className = "btn_Hindi";
            document.getElementById("lblbanklegerConfg").className = "Frm_Txt_Hindi";

            //Radio Button Code Start
            var schemewise = document.getElementById("rbschemewise");
            var RB = schemewise.parentNode.getElementsByTagName("label");
            RB[0].innerHTML = " स्कीम वाँइस ";
            RB[0].className = "Frm_Txt_Hindi";

            var agencywise = document.getElementById("rbagencywise");
            var RB = agencywise.parentNode.getElementsByTagName("label");
            RB[0].innerHTML = " एजेंसी वाँइस";
            RB[0].className = "Frm_Txt_Hindi";

            //Grid FundDetailCode Start
            if (document.getElementById("gvFundDetail") != null) {
                var table = document.getElementById("gvFundDetail");
                var tr = table.rows[0];
                tr.cells[0].innerHTML = "चुनिये";
                tr.cells[1].innerHTML = "हटायें";
                tr.cells[2].innerHTML = "सरल क्रमांक";
                tr.cells[3].innerHTML = "स्कीम नाम";
                tr.cells[4].innerHTML = "शाखा का नाम";
                tr.cells[5].innerHTML = "बैंक का नाम";
                tr.cells[6].innerHTML = "खाता क्रमांक";
                tr.cells[7].innerHTML = "आईएफएससी कोड";
                //=======Hindi Text ============//
                tr.cells[0].className = "Frm_Txt_Hindi";
                tr.cells[1].className = "Frm_Txt_Hindi";
                tr.cells[2].className = "Frm_Txt_Hindi";
                tr.cells[3].className = "Frm_Txt_Hindi";
                tr.cells[4].className = "Frm_Txt_Hindi";
                tr.cells[5].className = "Frm_Txt_Hindi";
                tr.cells[6].className = "Frm_Txt_Hindi";
                tr.cells[7].className = "Frm_Txt_Hindi";
            }

            //Cheque in Transit
            document.getElementById("lblChequeinTransit").innerHTML = "चेक इन ट्रांज़िट  कॉन्फीगरेशन";
            document.getElementById("lblConfigType_Transit").innerHTML = "कॉन्फीगरेशन का प्रकार";
            document.getElementById("lblEffectiveDate_Transit").innerHTML = "प्रभावित तिथि";
            document.getElementById("btnSave_Transit").value = "रक्षित करें";
            document.getElementById("chkDefaultSetting_Transit").nextSibling.innerHTML = " सामान्य सभी शाखाओ के लिये";

            //-----------Font size-------------//
            document.getElementById("lblChequeinTransit").className = "Frm_Txt_Hindi";
            document.getElementById("lblConfigType_Transit").className = "Frm_Txt_Hindi";
            document.getElementById("lblEffectiveDate_Transit").className = "Frm_Txt_Hindi";
            document.getElementById("btnSave_Transit").className = "btn_Hindi";
            document.getElementById("chkDefaultSetting_Transit").nextSibling.className = "Frm_Txt_Hindi";

            var RByes = document.getElementById("rbTransit_Yes");
            var RB1 = RByes.parentNode.getElementsByTagName("label");
            RB1[0].innerHTML = "हाँ ";

            var RBNo = document.getElementById("rbTransit_No");
            var RB2 = RBNo.parentNode.getElementsByTagName("label");
            RB2[1].innerHTML = "नहीं ";
            //-----------Grid gridLedger Code-------------//
            if (document.getElementById("GV_ChequeIN_Transit") != null) {
                var table = document.getElementById("GV_ChequeIN_Transit");
                var tr = table.rows[0];
                tr.cells[0].innerHTML = "चुनिये";
                tr.cells[1].innerHTML = "हटायें";
                tr.cells[2].innerHTML = "सरल क्रमांक";
                tr.cells[3].innerHTML = "कॉन्फीगरेशन नाम";
                tr.cells[4].innerHTML = "प्रभावित तिथि";
                //=======Hindi Text ============//
                tr.cells[0].className = "Frm_Txt_Hindi";
                tr.cells[1].className = "Frm_Txt_Hindi";
                tr.cells[2].className = "Frm_Txt_Hindi";
                tr.cells[3].className = "Frm_Txt_Hindi";
                tr.cells[4].className = "Frm_Txt_Hindi";
            }

            //Ledger Type Config Tab
            document.getElementById("lblLedgertypeConfig").innerHTML = "लेजर का प्रकार कॉन्फीगरेशन";
            document.getElementById("lblLedgerType_configTYpe").innerHTML = "कॉन्फीगरेशन का प्रकार";
            document.getElementById("lblLedgerType_EffectveDate").innerHTML = "प्रभावित तिथि";
            document.getElementById("btnLedgerType_Save").value = "रक्षित करें";
            document.getElementById("lblHeadLedgerType").innerHTML = "लेजर का प्रकार";
            document.getElementById("chkDefaultSetting_LedgerType").nextSibling.innerHTML = " सामान्य सभी शाखाओ के लिये";

            //-----------Font size-------------//
            document.getElementById("lblLedgertypeConfig").className = "Frm_Txt_Hindi";
            document.getElementById("lblLedgerType_configTYpe").className = "Frm_Txt_Hindi";
            document.getElementById("lblLedgerType_EffectveDate").className = "Frm_Txt_Hindi";
            document.getElementById("btnLedgerType_Save").className = "btn_Hindi";
            document.getElementById("lblHeadLedgerType").className = "Frm_Txt_Hindi";
            document.getElementById("chkDefaultSetting_LedgerType").nextSibling.className = "Frm_Txt_Hindi";

            //-----------Grid gridLedger Code-------------//
            if (document.getElementById("gv_LedgerTypeConfig") != null) {
                var table = document.getElementById("gv_LedgerTypeConfig");
                var tr = table.rows[0];
                tr.cells[0].innerHTML = "चुनिये";
                tr.cells[1].innerHTML = "हटायें";
                tr.cells[2].innerHTML = "सरल क्रमांक";
                tr.cells[3].innerHTML = "कॉन्फीगरेशन नाम";
                tr.cells[4].innerHTML = "प्रभावित तिथि";
                //=======Hindi Text ============//
                tr.cells[0].className = "Frm_Txt_Hindi";
                tr.cells[1].className = "Frm_Txt_Hindi";
                tr.cells[2].className = "Frm_Txt_Hindi";
                tr.cells[3].className = "Frm_Txt_Hindi";
                tr.cells[4].className = "Frm_Txt_Hindi";
            }

            // Ledger Configuration Tab Code start
            document.getElementById("lblLedgerConfig").innerHTML = "लेजर कॉन्फीगरेशन";
            document.getElementById("lblConfigType").innerHTML = "कॉन्फीगरेशन का प्रकार";
            document.getElementById("lblLedgerEffectiveDt").innerHTML = "प्रभावित तिथि";
            document.getElementById("lblLedgerType").innerHTML = "लेजर का प्रकार";
            document.getElementById("lblLedger").innerHTML = "लेजर";
            document.getElementById("lblCategory").innerHTML = "श्रेणी";
            document.getElementById("btnsave_Ledger").value = "रक्षित करें";
            document.getElementById("chkDefault").nextSibling.innerHTML = " सामान्य सभी शाखाओ के लिये";
            document.getElementById("chkisAgency").nextSibling.innerHTML = "इज एजेंसी ";
            document.getElementById("chkisCategory").nextSibling.innerHTML = "इज श्रेणी";
            //-----------Font size-------------//
            document.getElementById("lblLedgerConfig").className = "Frm_Txt_Hindi";
            document.getElementById("lblConfigType").className = "Frm_Txt_Hindi";
            document.getElementById("ddlConfigurationType").className = "ddl_Hindi";
            document.getElementById("lblLedgerEffectiveDt").className = "Frm_Txt_Hindi";
            document.getElementById("lblLedgerType").className = "Frm_Txt_Hindi";
            document.getElementById("ddlLedgerType").className = "ddl_Hindi";
            document.getElementById("lblLedger").className = "Frm_Txt_Hindi";
            document.getElementById("ddlLedger").className = "ddl_Hindi";
            document.getElementById("lblCategory").className = "Frm_Txt_Hindi";
            document.getElementById("ddlCategory").className = "ddl_Hindi";
            document.getElementById("btnsave_Ledger").className = "btn_Hindi";
            document.getElementById("chkDefault").nextSibling.className = "Frm_Txt_Hindi";
            document.getElementById("chkisAgency").nextSibling.className = "Frm_Txt_Hindi";
            document.getElementById("chkisCategory").nextSibling.className = "Frm_Txt_Hindi";
            //-----------Grid gridLedger Code-------------//
            if (document.getElementById("gridLedger") != null) {
                var table = document.getElementById("gridLedger");
                var tr = table.rows[0];
                tr.cells[0].innerHTML = "चुनिये";
                tr.cells[1].innerHTML = "हटायें";
                tr.cells[2].innerHTML = "सरल क्रमांक";
                tr.cells[3].innerHTML = "कॉन्फीगरेशन नाम";
                tr.cells[4].innerHTML = "प्रभावित तिथि";
                tr.cells[5].innerHTML = "लेजर का  नाम";
                tr.cells[6].innerHTML = "श्रेणी का  नाम";
                //=======Hindi Text ============//
                tr.cells[0].className = "Frm_Txt_Hindi";
                tr.cells[1].className = "Frm_Txt_Hindi";
                tr.cells[2].className = "Frm_Txt_Hindi";
                tr.cells[3].className = "Frm_Txt_Hindi";
                tr.cells[4].className = "Frm_Txt_Hindi";
                tr.cells[5].className = "Frm_Txt_Hindi";
                tr.cells[6].className = "Frm_Txt_Hindi";

            }

        }
        catch (e) {
            return true;
        }
    }

    //Form ID 953, Form Name:Budget/frm_BudgetSummary.aspx
    if (Choice == 0 && FormId == 953) {
        document.getElementById("LblHeader").innerHTML = "बजट अनुमान";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("lblFinancialYear").innerHTML = "वित्तीय वर्ष";
        document.getElementById("lblBranch").innerHTML = "शाखा  का नाम";
        document.getElementById("lblSchemeName").innerHTML = "स्कीम का नाम";
        document.getElementById("lbFindBranchCode").innerHTML = "शाखा बदले";
        document.getElementById("lblFunctionary").innerHTML = "फंक्शन का नाम चुने";
        document.getElementById("lblFunction").innerHTML = "फंक्शनरी का  नाम चुने";
        document.getElementById("lblMajorHead").innerHTML = "शीर्ष";
        document.getElementById("btnshow").value = "देखें";

        //-----------Font size-------------//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblFinancialYear").className = "Frm_Txt_Hindi";
        document.getElementById("lblBranch").className = "Frm_Txt_Hindi";
        document.getElementById("lblSchemeName").className = "Frm_Txt_Hindi";
        document.getElementById("ddlScheme").className = "ddl_Hindi";
        document.getElementById("lblFunctionary").className = "Frm_Txt_Hindi";
        document.getElementById("lblFunction").className = "Frm_Txt_Hindi";
        document.getElementById("lblMajorHead").className = "Frm_Txt_Hindi";
        document.getElementById("lblStates").className = "Frm_Txt_Hindi";
        document.getElementById("lblDistricts").className = "Frm_Txt_Hindi";
        document.getElementById("lblBklocks").className = "Frm_Txt_Hindi";
        document.getElementById("lblGramPanchayats").className = "Frm_Txt_Hindi";
        document.getElementById("lblVillages").className = "Frm_Txt_Hindi";
        document.getElementById("btnshow").className = "btn_Hindi";

        //Radio Button Code Start
        var Repo_opt1 = document.getElementById("rdl_Repo_opt1");
        var RB = Repo_opt1.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " बजट सारांश";
        RB[0].className = "Frm_Txt_Hindi";

        var Repo_opt2 = document.getElementById("rdl_Repo_opt2");
        var RB = Repo_opt2.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " संक्षिप्त मेंजर लेखा शीर्ष वार बजट";
        RB[0].className = "Frm_Txt_Hindi";

        //Radio Button Code Start
        var Repo_opt3 = document.getElementById("rdl_Repo_opt3");
        var RB = Repo_opt3.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " लघु शीर्ष वार बजट";
        RB[0].className = "Frm_Txt_Hindi";

        var Repo_opt4 = document.getElementById("rdl_Repo_opt4");
        var RB = Repo_opt4.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " विभाग वार बजट विवरण";
        RB[0].className = "Frm_Txt_Hindi";

        // Branch Radio button code
        var RBHindi = document.getElementById("RbWithBranch");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "उप शाखा सहित";
        RB[0].className = "Frm_Txt_Hindi";

        var RBenglish = document.getElementById("RbWithoutBranch");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "उप शाखा रहित";
        RB[0].className = "Frm_Txt_Hindi";

    }
    //Form ID 954, Form Name:Budget/frmBudgetAllotmentSummary.aspx
    if (Choice == 0 && FormId == 954) {
        document.getElementById("LblHeader").innerHTML = "बजट आवंटन सारांश";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        //        document.getElementById("lblagencytype").innerHTML = "ऐजेंसी का प्रकार ";
        //        document.getElementById("lblagency").innerHTML = "ऐजेंसी का नाम";
       // document.getElementById("lblscheme").innerHTML = "स्कीम का नाम";
        document.getElementById("lblfromdate").innerHTML = "दिनांक से";
        document.getElementById("lbltodate").innerHTML = "दिनांक तक ";
        document.getElementById("btnshow").value = "देखें";
        document.getElementById("btnPrint").value = "प्रिन्ट";

        //-----------Font size-------------//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        //        document.getElementById("lblagencytype").className = "Frm_Txt_Hindi";
        //        document.getElementById("lblagency").className = "Frm_Txt_Hindi";
        document.getElementById("lblscheme").className = "Frm_Txt_Hindi";
        document.getElementById("lblfromdate").className = "Frm_Txt_Hindi";
        document.getElementById("lbltodate").className = "Frm_Txt_Hindi";
        document.getElementById("btnshow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";

        document.getElementById("lblStates").className = "Frm_Txt_Hindi";
        document.getElementById("lblDistricts").className = "Frm_Txt_Hindi";
        document.getElementById("lblBklocks").className = "Frm_Txt_Hindi";
        document.getElementById("lblGramPanchayats").className = "Frm_Txt_Hindi";
        document.getElementById("lblVillages").className = "Frm_Txt_Hindi";

        //Radio Button Code Start
        var withledger = document.getElementById("rbwithledger");
        var RB = withledger.parentNode.getElementsByTagName("label");
     // RB[0].innerHTML = " उद्देश्य शीर्ष सहित";
        RB[0].className = "Frm_Txt_Hindi";

        var withoutledger = document.getElementById("rbwithoutledger");
        var RB = withoutledger.parentNode.getElementsByTagName("label");
      //  RB[0].innerHTML = " उद्देश्य शीर्ष रहित";
        RB[0].className = "Frm_Txt_Hindi";
        var RBHindi = document.getElementById("RbWithBranch");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "उप शाखा सहित";
        RB[0].className = "Frm_Txt_Hindi";

        var RBenglish = document.getElementById("RbWithoutBranch");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "उप शाखा रहित";
        RB[0].className = "Frm_Txt_Hindi";

        if (document.getElementById("rbwithledger").checked == true) {
            var table = document.getElementById("gvbudgetallotmentrpt");
            var tr = table.rows[0];
//            tr.cells[0].innerHTML = "क्रमांक";
//            tr.cells[1].innerHTML = "नाम";
//            tr.cells[2].innerHTML = "कोड";
//            tr.cells[3].innerHTML = "चेक नंबर";
//            tr.cells[4].innerHTML = "उद्देश्य शीर्ष";
//            tr.cells[5].innerHTML = "मुख्य शीर्ष";
//            tr.cells[6].innerHTML = "राशि";
            //-----------Font size-------------//
            tr.cells[0].className = "Frm_Txt_Hindi";
            tr.cells[1].className = "Frm_Txt_Hindi";
            tr.cells[2].className = "Frm_Txt_Hindi";
            tr.cells[3].className = "Frm_Txt_Hindi";
            tr.cells[4].className = "Frm_Txt_Hindi";
            tr.cells[5].className = "Frm_Txt_Hindi";
            tr.cells[6].className = "Frm_Txt_Hindi";
        }
        else {
//            var table = document.getElementById("gvbudgetallotmentrpt");
//            var tr = table.rows[0];
//            tr.cells[0].innerHTML = "क्रमांक";
//            tr.cells[1].innerHTML = "नाम";
//            tr.cells[2].innerHTML = "कोड";
//            tr.cells[3].innerHTML = "राशि";
            //-----------Font size-------------//
            tr.cells[0].className = "Frm_Txt_Hindi";
            tr.cells[1].className = "Frm_Txt_Hindi";
            tr.cells[2].className = "Frm_Txt_Hindi";
            tr.cells[3].className = "Frm_Txt_Hindi";
        }
    }
    //Form ID 960, Form Name:Budget/rpt_AllotmentSummary.aspx
    if (Choice == 0 && FormId == 960) {
        document.getElementById("LblHeader").innerHTML = "आवंटन एवं व्यय रिपोर्ट";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnPrint").value = "प्रिंट करें";
       // document.getElementById("lblSchemeName").innerHTML = "स्कीम का नाम";
        document.getElementById("lblFromDate").innerHTML = "तिथि से";
        document.getElementById("lblToDate").innerHTML = "तिथि तक";

        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbSummary");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " संक्षिप्त रिपोर्ट";
        RB[0].className = "Frm_Txt_Hindi";

        var RBenglish = document.getElementById("rbDetail");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " विस्तार रिपोर्ट";
        RB[0].className = "Frm_Txt_Hindi";
        //=======Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("lblSchemeName").className = "Frm_Txt_Hindi";
        document.getElementById("lblFromDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblToDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblStates").className = "Frm_Txt_Hindi";
        document.getElementById("lblDistricts").className = "Frm_Txt_Hindi";
        document.getElementById("lblBklocks").className = "Frm_Txt_Hindi";
        document.getElementById("lblGramPanchayats").className = "Frm_Txt_Hindi";
        document.getElementById("lblVillages").className = "Frm_Txt_Hindi";

        var RBHindi = document.getElementById("RbWithBranch");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "उप शाखा सहित";
        RB[0].className = "Frm_Txt_Hindi";

        var RBenglish = document.getElementById("RbWithoutBranch");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "उप शाखा रहित";
        RB[0].className = "Frm_Txt_Hindi";

    }
    //Form ID 961, Form Name:BudgetExpenditureReport.aspx
    if (Choice == 0 && FormId == 961) {
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("LblReportOp").innerHTML = "रिपोर्ट प्रकार";
        document.getElementById("LblScheme").innerHTML = "स्कीम का नाम";
        document.getElementById("LblToDt").innerHTML = "दिनांक तक";
        document.getElementById("Label2").innerHTML = "(दिन/माह/वर्ष)";
        document.getElementById("LblFromDt").innerHTML = "दिनांक से";
        document.getElementById("Label1").innerHTML = "(दिन/माह/वर्ष)";
        document.getElementById("LblFunction").innerHTML = "फंक्शन का नाम";
        document.getElementById("LblFunctionary").innerHTML = "फंक्शनरी का नाम";
        document.getElementById("BtnTrialBalance").value = "रिपोर्ट देखें";
        document.getElementById("BtnExit").value = "बंद करे";

        //=======Hindi Text ============//
        document.getElementById("LblReportOp").className = "Frm_Txt_Hindi";
        document.getElementById("LblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("LblToDt").className = "Frm_Txt_Hindi";
        document.getElementById("Label2").className = "Frm_Txt_Hindi";
        document.getElementById("LblFromDt").className = "Frm_Txt_Hindi";
        document.getElementById("Label1").className = "Frm_Txt_Hindi";
        document.getElementById("LblFunction").className = "Frm_Txt_Hindi";
        document.getElementById("LblFunctionary").className = "Frm_Txt_Hindi";
        document.getElementById("BtnTrialBalance").className = "btn_Hindi";
        document.getElementById("BtnExit").className = "btn_Hindi";

        var Action = document.getElementById("RBLReport");
        var rbAction = Action.parentNode.getElementsByTagName("label");
        rbAction[0].innerHTML = " प्लान";
        rbAction[1].innerHTML = " नाँन प्लान";
        rbAction[2].innerHTML = " दोनो";
        rbAction[0].className = "Frm_Txt_Hindi";
        rbAction[1].className = "Frm_Txt_Hindi";
        rbAction[2].className = "Frm_Txt_Hindi";

        //var Default = document.getElementById("rbDefault");
        //var rbDefault = Default.parentNode.getElementsByTagName("label");
        //rbDefault[0].innerHTML = " डिफ़ाँल्ट शाखा कोड";

        //var custom = document.getElementById("rbcustom");
        //var rbcustom = custom.parentNode.getElementsByTagName("label");
        //rbcustom[0].innerHTML = " कस्टम शाखा कोड";
    }
    //Form ID 961, Form Name:BudgetExpenditureReport.aspx
    if (Choice == 0 && FormId == 962) {
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("LblReportOp").innerHTML = "रिपोर्ट प्रकार";
        document.getElementById("LblScheme").innerHTML = "स्कीम का नाम";
        document.getElementById("LblToDt").innerHTML = "दिनांक तक";
        document.getElementById("Label2").innerHTML = "(दिन/माह/वर्ष)";
        document.getElementById("LblFromDt").innerHTML = "दिनांक से";
        document.getElementById("Label1").innerHTML = "(दिन/माह/वर्ष)";
        document.getElementById("LblFunction").innerHTML = "फंक्शन का नाम";
        document.getElementById("LblFunctionary").innerHTML = "फंक्शनरी का नाम";
        document.getElementById("BtnTrialBalance").value = "रिपोर्ट देखें";
        document.getElementById("BtnExit").value = "बंद करे";

        //=======Hindi Text ============//
        document.getElementById("LblReportOp").className = "Frm_Txt_Hindi";
        document.getElementById("LblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("LblToDt").className = "Frm_Txt_Hindi";
        document.getElementById("Label2").className = "Frm_Txt_Hindi";
        document.getElementById("LblFromDt").className = "Frm_Txt_Hindi";
        document.getElementById("Label1").className = "Frm_Txt_Hindi";
        document.getElementById("LblFunction").className = "Frm_Txt_Hindi";
        document.getElementById("LblFunctionary").className = "Frm_Txt_Hindi";
        document.getElementById("BtnTrialBalance").className = "btn_Hindi";
        document.getElementById("BtnExit").className = "btn_Hindi";

        //=======Radio button Text ============//
        var Action = document.getElementById("RBLReport");
        var rbAction = Action.parentNode.getElementsByTagName("label");
        rbAction[0].innerHTML = " प्लान";
        rbAction[1].innerHTML = " नाँन प्लान";
        rbAction[2].innerHTML = " दोनो";
        rbAction[0].className = "Frm_Txt_Hindi";
        rbAction[1].className = "Frm_Txt_Hindi";
        rbAction[2].className = "Frm_Txt_Hindi";

        //var Default = document.getElementById("rbDefault");
        //var rbDefault = Default.parentNode.getElementsByTagName("label");
        //rbDefault[0].innerHTML = " डिफ़ाँल्ट शाखा कोड";

        //var custom = document.getElementById("rbcustom");
        //var rbcustom = custom.parentNode.getElementsByTagName("label");
        //rbcustom[0].innerHTML = " कस्टम शाखा कोड";
    }
    //Form ID 963, Form Name:Reportview.aspx
    if (Choice == 0 && FormId == 963) {
        document.getElementById("LblHeader").innerHTML = "यूटिलाइजेशन प्रमाणपत्र";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        var Default = document.getElementById("RbWithBranch");
        var RB = Default.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " उप शाखा सहित";
        RB[0].className = "Frm_Txt_Hindi";

        var custom = document.getElementById("RbWithoutBranch");
        var RB = custom.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " उप शाखा रहित";
        RB[0].className = "Frm_Txt_Hindi";
        document.getElementById("LblScheme").innerHTML = "स्कीम का नाम";
        document.getElementById("ChkAll").nextSibling.innerHTML = "सभी चुने"
        document.getElementById("LblFromDt").innerHTML = "दिनांक से";
        document.getElementById("LblToDt").innerHTML = "दिनांक तक";
        document.getElementById("BtnReport").value = "रिपोर्ट देखें";
        document.getElementById("BtnExit").value = "बंद करे";
        //=======Hindi Text ============//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("LblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("ChkAll").className = "Frm_Txt_Hindi";
        document.getElementById("LblFromDt").className = "Frm_Txt_Hindi";
        document.getElementById("LblToDt").className = "Frm_Txt_Hindi";
        document.getElementById("BtnReport").className = "btn_Hindi";
        document.getElementById("BtnExit").className = "btn_Hindi";
        // Default and Branch Radio button code
        var Default = document.getElementById("rbDefault");
        var RB = Default.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "डिफ़ाँल्ट शाखा कोड";
        RB[0].className = "Frm_Txt_Hindi";

        var custom = document.getElementById("rbcustom");
        var RB = custom.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "कस्टम शाखा कोड";
        RB[0].className = "Frm_Txt_Hindi";

      

        if (document.getElementById("rbcustom").checked == true) {
            document.getElementById("btnGo").value = "देखें";
            document.getElementById("lblPanchayatCode").innerHTML = "पंचायत कोड";
            document.getElementById("lbFindBranchCode").innerHTML = "शाखा कोड देखें";
            // Fint Size Increase code
            document.getElementById("btnGo").className = "btn_Hindi";
            document.getElementById("lblPanchayatCode").className = "Frm_Txt_Hindi";
        }
    }
    //Form ID 964, Form Name:FinancialReports/BdgExpReport.aspx
    if (Choice == 0 && FormId == 964) {
        document.getElementById("LblHeader").innerHTML = "बजट आवंटन एवं व्यय रिपोर्ट";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("lblDate").innerHTML = "दिनांक";
        document.getElementById("btnShow").value = "रिपोर्ट देखें";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("lblNonPlan").innerHTML = "नाँन प्लान";
        document.getElementById("lblPlan").innerHTML = "प्लान";
        document.getElementById("LblFunction").innerHTML = "फंक्शन";
        document.getElementById("LblFunctionary").innerHTML = "फंक्शनरी";
        //=======Hindi Text ============//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblDate").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("lblNonPlan").className = "Frm_Txt_Hindi";
        document.getElementById("lblPlan").className = "Frm_Txt_Hindi";
        document.getElementById("LblFunction").className = "Frm_Txt_Hindi";
        document.getElementById("LblFunctionary").className = "Frm_Txt_Hindi";

        //Grid Code Start one
        var table = document.getElementById("gvState");
        var tr = table.rows[0];
        tr.cells[2].innerHTML = "शाखा";
        tr.cells[3].innerHTML = "बजट";
        tr.cells[4].innerHTML = "व्यय";
        tr.cells[5].innerHTML = "%";
        tr.cells[6].innerHTML = "बजट";
        tr.cells[7].innerHTML = "व्यय";
        tr.cells[8].innerHTML = "%";
        //==========Hindi Code============//
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
        tr.cells[5].className = "Frm_Txt_Hindi";
        tr.cells[6].className = "Frm_Txt_Hindi";
        tr.cells[7].className = "Frm_Txt_Hindi";
        tr.cells[8].className = "Frm_Txt_Hindi";
    }
    //Form ID 966, Form Name:BudgetAllotment.aspx
    if (Choice == 0 && FormId == 966) {
        document.getElementById("LblHeader").innerHTML = "बजट आवंटन रिपोर्ट";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        //        document.getElementById("lblstates").innerHTML = "राज्य";
        //        document.getElementById("lbldistricts").innerHTML = "जिला";
        //        document.getElementById("lblblocks").innerHTML = "जनपद";
        //        document.getElementById("lblGramPanchayats").innerHTML = "ग्राम पंचायत";
        //        document.getElementById("lblvillages").innerHTML = "ग्राम";
        //        document.getElementById("btnGetBranch").value = "शाखा  देखें";
        //        document.getElementById("chkwithSUBBranch").nextSibling.innerHTML = " उप शाखाओ सहित";
        document.getElementById("LblReportOp").innerHTML = "रिपोर्ट प्रकार";
        document.getElementById("LblScheme").innerHTML = "स्कीम का नाम";
        document.getElementById("LblFromDt").innerHTML = "दिनांक से";
        document.getElementById("Label1").innerHTML = "(दिन/माह/वर्ष)";
        document.getElementById("LblToDt").innerHTML = "दिनांक तक";
        document.getElementById("Label2").innerHTML = "(दिन/माह/वर्ष)";
        document.getElementById("BtnTrialBalance").value = "रिपोर्ट देखें";
        document.getElementById("BtnExit").value = "बंद करे";
        //=======Hindi Text ============//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        //        document.getElementById("lblstates").className = "Frm_Txt_Hindi";
        //        document.getElementById("lbldistricts").className = "Frm_Txt_Hindi";
        //        document.getElementById("lblblocks").className = "Frm_Txt_Hindi";
        //        document.getElementById("lblGramPanchayats").className = "Frm_Txt_Hindi";
        //        document.getElementById("lblvillages").className = "Frm_Txt_Hindi";
        //        document.getElementById("chkwithSUBBranch").nextSibling.className = "Frm_Txt_Hindi";
        //        document.getElementById("btnGetBranch").className = "btn_Hindi";
        document.getElementById("LblReportOp").className = "Frm_Txt_Hindi";
        document.getElementById("LblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("DrpScheme").className = "ddl_Hindi";
        document.getElementById("LblFromDt").className = "Frm_Txt_Hindi";
        document.getElementById("Label1").className = "Frm_Txt_Hindi";
        document.getElementById("LblToDt").className = "Frm_Txt_Hindi";
        document.getElementById("Label2").className = "Frm_Txt_Hindi";
        document.getElementById("BtnTrialBalance").className = "btn_Hindi";
        document.getElementById("BtnExit").className = "btn_Hindi";

        var Action = document.getElementById("RBLReport");
        var rbAction = Action.parentNode.getElementsByTagName("label");
        rbAction[0].innerHTML = " प्लान";
        rbAction[1].innerHTML = " नाँन प्लान";
        rbAction[2].innerHTML = " दोनो";
        rbAction[0].className = "Frm_Txt_Hindi";
        rbAction[1].className = "Frm_Txt_Hindi";
        rbAction[2].className = "Frm_Txt_Hindi";
    }
    //Form ID 967, Form Name:Budget/rpt_FundAllotment.aspx
    if (Choice == 0 && FormId == 967) {
        document.getElementById("LblHeader").innerHTML = "फंड आवंटन रिपोर्ट";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("lblFdate").innerHTML = "दिनांक से";
        document.getElementById("lblToDate").innerHTML = "दिनांक तक";
        document.getElementById("lblSchemeName").innerHTML = "स्कीम का नाम";
        document.getElementById("ChkAll").nextSibling.innerHTML = " सभी चुनें";
        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnPrint").value = "प्रिंट करे";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";
        //=======Hindi Text ============//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblStates").className = "Frm_Txt_Hindi";
        document.getElementById("lblDistricts").className = "Frm_Txt_Hindi";
        document.getElementById("lblBklocks").className = "Frm_Txt_Hindi";
        document.getElementById("lblGramPanchayats").className = "Frm_Txt_Hindi";
        document.getElementById("lblVillages").className = "Frm_Txt_Hindi";
        document.getElementById("lblFdate").className = "Frm_Txt_Hindi";
        document.getElementById("lblToDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblSchemeName").className = "Frm_Txt_Hindi";
        document.getElementById("ChkAll").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";
        // Branch Radio button code
        var RBHindi = document.getElementById("RbWithBranch");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "उप शाखा सहित";
        RB[0].className = "Frm_Txt_Hindi";

        var RBenglish = document.getElementById("RbWithoutBranch");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "उप शाखा रहित";
        RB[0].className = "Frm_Txt_Hindi";

        // Agency, Category Radio button code
        //        var RBHindi = document.getElementById("rbagency");
        //        var RB = RBHindi.parentNode.getElementsByTagName("label");
        //        RB[0].innerHTML = "एजेंसी";
        //        RB[0].className = "Frm_Txt_Hindi";

        //        var RBenglish = document.getElementById("rbcategory");
        //        var RB = RBenglish.parentNode.getElementsByTagName("label");
        //        RB[0].innerHTML = "श्रेणी";
        //        RB[0].className = "Frm_Txt_Hindi";
        //if (document.getElementById("RbWithBranch").checked == true) {

        // document.getElementById("btnGo").value = "देखें";
        //document.getElementById("lblPanchayatCode").innerHTML = "पंचायत कोड";
        // document.getElementById("lbFindBranchCode").innerHTML = "शाखा कोड देखें";
        // Fint Size Increase code
        //document.getElementById("btnGo").className = "btn_Hindi";
        // document.getElementById("lblPanchayatCode").className = "Frm_Txt_Hindi";
        // }
    }

    //Form ID 1338, Form Name:Budget_Report/rpt_rkvy.aspx
    if (Choice == 0 && FormId == 1338) {

        document.getElementById("LblHeader").innerHTML = "बजट व्यय रिपोर्ट";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("lblFdate").innerHTML = "दिनांक से";
        document.getElementById("lblToDate").innerHTML = "दिनांक तक";


        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnPrint").value = "प्रिंट करे";

        //=======Hindi Text ============//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblStates").className = "Frm_Txt_Hindi";
        document.getElementById("lblDistricts").className = "Frm_Txt_Hindi";
        document.getElementById("lblBklocks").className = "Frm_Txt_Hindi";
        document.getElementById("lblGramPanchayats").className = "Frm_Txt_Hindi";
        document.getElementById("lblVillages").className = "Frm_Txt_Hindi";
        document.getElementById("lblFdate").className = "Frm_Txt_Hindi";
        document.getElementById("lblToDate").className = "Frm_Txt_Hindi";

        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";

        // Branch Radio button code
        var RBHindi = document.getElementById("RbWithBranch");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "उप शाखा सहित";
        RB[0].className = "Frm_Txt_Hindi";

        var RBenglish = document.getElementById("RbWithoutBranch");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "उप शाखा रहित";
        RB[0].className = "Frm_Txt_Hindi";

    }


    //Form ID 950, Form Name:Budget/frmBudgetAllotmentList.aspx
    if (Choice == 0 && FormId == 950) {
       // try {
            document.getElementById("LblHeader").innerHTML = "बजट आवंटन सूची";
            // Hindi,English Radio button code
            var RBHindi = document.getElementById("rbHindi");
            var RB = RBHindi.parentNode.getElementsByTagName("label");
            RB[0].innerHTML = "हिन्दी";

            var RBenglish = document.getElementById("rbenglish");
            var RB = RBenglish.parentNode.getElementsByTagName("label");
            RB[0].innerHTML = "English";
            document.getElementById("LblHeader").className = "Frm_Head_Hindi";
            document.getElementById("hlHome").innerHTML = "होमपेज";
            document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
            // document.getElementById("lblSchemeName").innerHTML = "स्कीम";
            document.getElementById("lblSchemeName").className = "Frm_Txt_Hindi";
            document.getElementById("ddlSchemeName").className = "ddl_Hindi";
            document.getElementById("lbldtallotment").innerHTML = "तिथि से";
            document.getElementById("lbldtallotment").className = "Frm_Txt_Hindi";
            document.getElementById("lbltodate").innerHTML = "तिथि तक";
            document.getElementById("lbltodate").className = "Frm_Txt_Hindi";
            document.getElementById("lbldtformat").innerHTML = "(दिन/माह/वर्ष)";
            document.getElementById("lbldtformat").className = "Frm_Txt_Hindi";
            document.getElementById("lblfromdateformat").innerHTML = "(दिन/माह/वर्ष)";
            document.getElementById("lblfromdateformat").className = "Frm_Txt_Hindi";
            document.getElementById("btnShowList").value = "सूची देखें";
            document.getElementById("btnShowList").className = "btn_Hindi";
            document.getElementById("btnprint").value = "प्रिन्ट करें";
            document.getElementById("btnprint").className = "btn_Hindi";
            document.getElementById("BtnExcel").value = "एक्सेल में भेजें";
            document.getElementById("BtnExcel").className = "btn_Hindi";
            document.getElementById("lblReferencesno").innerHTML = "रिफ्रेंस नम्बर";
            document.getElementById("lblReferencesno").className = "Frm_Txt_Hindi";
            document.getElementById("ddlreferencesno").className = "ddl_Hindi";
            document.getElementById("btnCancel").value = "बजट आवंटन रद्द करें";
            document.getElementById("btnCancel").className = "btn_Hindi";

            document.getElementById("btnfillrefnos").value = "रिफ्रेंस नम्बर भरे ";
            document.getElementById("btnfillrefnos").className = "btn_Hindi";


            //Radio Button Code Start
            var jobwise = document.getElementById("rbjobwise");
            var RB = jobwise.parentNode.getElementsByTagName("label");
            RB[0].innerHTML = "जॉब सहित";
            RB[0].className = "Frm_Txt_Hindi";

            var withoutjob = document.getElementById("rbwithoutjob");
            var RB = withoutjob.parentNode.getElementsByTagName("label");
            RB[1].innerHTML = "जॉब रहित";
            RB[1].className = "Frm_Txt_Hindi";
            if (document.getElementById("rbjobwise").checked == true) {
                var table = document.getElementById("GrdBudget");
                var tr = table.rows[0];
                tr.cells[0].innerHTML = "क्रमांक <br /> (1)";
                tr.cells[1].innerHTML = "नाम <br /> (2)";
                tr.cells[2].innerHTML = "आवंटन दिनांक <br /> (3)";
                tr.cells[3].innerHTML = "जॉब नंबर<br /> (4)";
                tr.cells[4].innerHTML = "बैक खाता <br /> (5)";
                tr.cells[5].innerHTML = "बैक का पता <br /> (6)";
                tr.cells[6].innerHTML = "खाता क्र. <br /> (7)";
                tr.cells[7].innerHTML = "आई एफ एस सी कोड <br /> (8)";
                tr.cells[8].innerHTML = "चेक नंबर <br /> (9)";
                tr.cells[9].innerHTML = "राशि <br /> (10)";
                //-----------Font size-------------//
                tr.cells[0].className = "Frm_Txt_Hindi";
                tr.cells[1].className = "Frm_Txt_Hindi";
                tr.cells[2].className = "Frm_Txt_Hindi";
                tr.cells[3].className = "Frm_Txt_Hindi";
                tr.cells[4].className = "Frm_Txt_Hindi";
                tr.cells[5].className = "Frm_Txt_Hindi";
                tr.cells[6].className = "Frm_Txt_Hindi";
                tr.cells[7].className = "Frm_Txt_Hindi";
                tr.cells[8].className = "Frm_Txt_Hindi";
                tr.cells[9].className = "Frm_Txt_Hindi";
            }
            else {
                var table = document.getElementById("GrdBudget");
                var tr = table.rows[0];
                tr.cells[0].innerHTML = "क्रमांक <br /> (1)";
                tr.cells[1].innerHTML = "नाम <br /> (2)";
                tr.cells[2].innerHTML = "आवंटन दिनांक <br /> (3)";
                tr.cells[3].innerHTML = "बैक खाता <br /> (4)";
                tr.cells[4].innerHTML = "बैक का पता <br /> (5)";
                tr.cells[5].innerHTML = "खाता क्र. <br /> (6)";
                tr.cells[6].innerHTML = "आई एफ एस सी कोड <br /> (7)";
                tr.cells[7].innerHTML = "चेक नंबर <br /> (8)";
                tr.cells[8].innerHTML = "राशि <br /> (9)";
                //-----------Font size-------------//
                tr.cells[0].className = "Frm_Txt_Hindi";
                tr.cells[1].className = "Frm_Txt_Hindi";
                tr.cells[2].className = "Frm_Txt_Hindi";
                tr.cells[3].className = "Frm_Txt_Hindi";
                tr.cells[4].className = "Frm_Txt_Hindi";
                tr.cells[5].className = "Frm_Txt_Hindi";
                tr.cells[6].className = "Frm_Txt_Hindi";
                tr.cells[7].className = "Frm_Txt_Hindi";
                tr.cells[8].className = "Frm_Txt_Hindi";
            }

       // }
//        catch (e) {
//            alert(e);
//        }
    }
    //Form ID 1339, Form Name:Budget_master/frm_yrwise_cat_scheme_combination.aspx

    if (Choice == 0 && FormId == 1339) {
        document.getElementById("LblHeader").innerHTML = "वर्ष वार स्कीम तथा केटेगरी कॉम्बिनेशन";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";
        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("lblFinancialYear").innerHTML = "वित्तीय बर्ष";
        document.getElementById("lblSchemeName").innerHTML = "स्कीम का नाम";
        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnSave").value = "रक्षित करें";
        //===========Hindi Font Increase==========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblFinancialYear").className = "Frm_Txt_Hindi";
        document.getElementById("lblSchemeName").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("lblCreateBudget").innerHTML = "वर्ष वार स्कीम तथा केटेगरी कॉम्बिनेशन";
        document.getElementById("lblCreateBudget").className = "BlackText";
        // Grid Code Start Bottom Grid
        if (document.getElementById("GrdBudget") != null) {
            var table = document.getElementById("GrdBudget");
            var tr = table.rows[0];
            tr.cells[0].innerHTML = "श्रेणी / लेज़र";
            document.getElementById("GrdBudget_ctl01_HSelectAll").nextSibling.innerHTML = "सभी चुनें"; ;
            //-----------Font size-------------//
            tr.cells[0].className = "show_btn_bg_Hindi";

        }

    }
}

function PageWidth() {
    var table = document.getElementById('DashBoardBanner');
    if (table != 'undefined' && table != null) {
        if (screen.width >= 1280) {
            table.className = 'innerbanner1';
        } else if (screen.width >= 1024) {
            table.className = 'innerbanner';
        }
    }
}

function DesignShowHide(Designvisible) {
    //=============== Designvisible value 1 Code Start ===============//
    if (Designvisible == 1) {
        document.getElementById('A').style.display = 'none';
        document.getElementById('B').style.display = 'none';
        document.getElementById('C').style.display = 'none';
        document.getElementById('D').style.display = 'block';
    }
    //=============== Designvisible value 2 Code Start ===============//
    if (Designvisible == 2) {
        document.getElementById('A').style.display = 'none';
        document.getElementById('B').style.display = 'none';
        document.getElementById('C').style.display = 'block';
        document.getElementById('D').style.display = 'block';
    }
    //=============== Designvisible value 3 Code Start ===============//
    if (Designvisible == 3) {
        document.getElementById('A').style.display = 'none';
        document.getElementById('B').style.display = 'none';
        document.getElementById('C').style.display = 'none';
        document.getElementById('D').style.display = 'none';
    }
    //=============== Designvisible value 4 Code Start ===============//
    if (Designvisible == 4) {
        document.getElementById('A').style.display = 'none';
        document.getElementById('B').style.display = 'block';
        document.getElementById('C').style.display = 'none';
        document.getElementById('D').style.display = 'block';
    }
}
//Function For check date that to date not less than from date 
//Pass Parameter FromDate as first parameter To date as second parameter
function CheckFromDateToDate(FromDate, ToDate) {
    var sessionLanguage;
    var str1 = document.getElementById(FromDate).value; //Fromdate
    var str2 = document.getElementById(ToDate).value;  //todate
    //sessionLanguage = '<%=Session("Version")%>';

    var sptdate1 = str1.replace("-", "/").replace("-", "/").split("/");
    var sptdate2 = str2.replace("-", "/").replace("-", "/").split("/");
    var datestring1 = sptdate1[1] + "/" + sptdate1[0] + "/" + sptdate1[2];
    var datestring2 = sptdate2[1] + "/" + sptdate2[0] + "/" + sptdate2[2];
    // alert(GlobalLanguage);
    var date1 = new Date(datestring1)
    var date2 = new Date(datestring2);
    if (date2 < date1) {
        if (GlobalLanguage == 1) {
            alert("From Date Must Be Less Than To Date");
        } else {
            alert("प्रांरभ दिनांक, अतिंम दिनांक से छोटी होना चाहिये |");
        }
        document.getElementById(FromDate).value = "";
        return false;
    }
    else {
        return true;
    }
}
//Function For Special Characters are Not Allowed in text box. For it pass text box object
// function SpecialCharNotAllow(that, CondType) {
function SpecialCharNotAllow(that, e) {
    try {
        var LedgerNameObj = document.getElementById(that.id);
        var LedgerName = document.getElementById(that.id).value;

        var i;
        // var car = e.charCode;
        var key = e.keyCode
        //if (key == 8 || (key >= 48 && key < 58) || (key >= 65 && key <= 90) || (key == 110 || key == 190 || key == 9 || key == 8 || key == 46 || key == 13) || (key >= 37 && key <= 40) || key == 46) {



        if (e.type == 'change') {
            LedgerNameObj.value = '';
            for (i = 0; i <= (LedgerName.length - 1); i++) {
                var LedgerNameVal = '';

                LedgerNameVal = LedgerName.substring(i, i + 1);

                // if ((LedgerNameVal == '~') || (LedgerNameVal == '!') || (LedgerNameVal == '@') || (LedgerNameVal == '#') || (LedgerNameVal == '$') || (LedgerNameVal == '%') || (LedgerNameVal == '^') || (LedgerNameVal == '&') || (LedgerNameVal == '*') || (LedgerNameVal == '(') || (LedgerNameVal == ')') || (LedgerNameVal == '{') || (LedgerNameVal == '}') || (LedgerNameVal == '|') || (LedgerNameVal == '<') || (LedgerNameVal == '>') || (LedgerNameVal == '?')) {

                if ((LedgerNameVal == '~') || (LedgerNameVal == '!') || (LedgerNameVal == '@') || (LedgerNameVal == '#') || (LedgerNameVal == '$') || (LedgerNameVal == '%') || (LedgerNameVal == '^') || (LedgerNameVal == '&') || (LedgerNameVal == '*') || (LedgerNameVal == '{') || (LedgerNameVal == '}') || (LedgerNameVal == '|') || (LedgerNameVal == '<') || (LedgerNameVal == '>') || (LedgerNameVal == '?')) {
                }
                else {
                    LedgerNameObj.value = LedgerNameObj.value + LedgerNameVal;
                }
            }
        }
        else {
            if (e.shiftKey) {
                if (key == 16 || (key >= 49 && key <= 58) || key == 188 || key == 190 || key == 219 || key == 221 || key == 192) {
                    LedgerNameObj.value = '';
                    for (i = 0; i <= (LedgerName.length - 1); i++) {
                        var LedgerNameVal = '';

                        LedgerNameVal = LedgerName.substring(i, i + 1);

                        // if ((LedgerNameVal == '~') || (LedgerNameVal == '!') || (LedgerNameVal == '@') || (LedgerNameVal == '#') || (LedgerNameVal == '$') || (LedgerNameVal == '%') || (LedgerNameVal == '^') || (LedgerNameVal == '&') || (LedgerNameVal == '*') || (LedgerNameVal == '(') || (LedgerNameVal == ')') || (LedgerNameVal == '{') || (LedgerNameVal == '}') || (LedgerNameVal == '|') || (LedgerNameVal == '<') || (LedgerNameVal == '>') || (LedgerNameVal == '?')) {

                        if ((LedgerNameVal == '~') || (LedgerNameVal == '!') || (LedgerNameVal == '@') || (LedgerNameVal == '#') || (LedgerNameVal == '$') || (LedgerNameVal == '%') || (LedgerNameVal == '^') || (LedgerNameVal == '&') || (LedgerNameVal == '*') || (LedgerNameVal == '{') || (LedgerNameVal == '}') || (LedgerNameVal == '|') || (LedgerNameVal == '<') || (LedgerNameVal == '>') || (LedgerNameVal == '?')) {
                        }
                        else {
                            LedgerNameObj.value = LedgerNameObj.value + LedgerNameVal;
                        }
                    }
                }
            }
        }

    }
    catch (e) {

    }

}
// Funct for validate text box max length is 14 digits & with 2 decimal disgits
function ValidateTextLength(eve, DeciamAfterDigit, txtObj) {
    try {
        var txtval = document.getElementById(txtObj.id).value.split(".");
        if (txtval.length > 1) {
            if (document.getElementById(txtObj.id).value.length > txtval[0].length + 2) {
                if (eve.keyCode != 8 && eve.keyCode != 46 && eve.keyCode != 9) {
                    return false;
                }
            }
        }
        if (String.fromCharCode(eve.charCode) == ".") {
            var txtval = document.getElementById(txtObj.id).value.split(".");
            if (txtval.length > 1) {
                if (eve.keyCode != 8 && eve.keyCode != 46 && eve.keyCode != 9) {
                    return false;
                }
            }
        }
        if (document.getElementById(txtObj.id).value.length == DeciamAfterDigit && String.fromCharCode(eve.charCode) != ".") {
            var txtval = document.getElementById(txtObj.id).value.split(".");
            if (txtval.length <= 1) {
                if (eve.keyCode != 8 && eve.keyCode != 46 && eve.keyCode != 9) {
                    return false;
                }
            }
        }
        if (document.getElementById(txtObj.id).value.length >= 17) {
            if (eve.keyCode != 8 && eve.keyCode != 46 && eve.keyCode != 9) {
                return false;
            }
        }
    }
    catch (e) {
        // alert(e);
    }
}



//------------------Cheque No dropdown and text box managing generally--------------

function FillAllTheChecqueNOs(SchemeId, ddlBankId, ddlChequeId, HF_AllTheCheque, HF_UsedChecque) {

    var RowArray = new Array();
    RowArray = document.getElementById(HF_AllTheCheque).value.split('~');

    var ddlLedger = document.getElementById(ddlBankId);

    var ddlBankLedgerId = ddlLedger.options[ddlLedger.selectedIndex].value.toLowerCase();
    document.getElementById(ddlChequeId).innerHTML = '';
    var ddlChecque = document.getElementById(ddlChequeId).id;
    choice = document.createElement('option');
    choice.value = "00000";

    if (GlobalLanguage == 1) {
        choice.appendChild(document.createTextNode('Select'));
    } else {
        choice.appendChild(document.createTextNode('चुनिये'));
    }
    document.getElementById(ddlChecque).appendChild(choice);


    for (var rowCount = 0; rowCount <= RowArray.length - 2; rowCount++) {

        var itemArray = new Array();
        itemArray = RowArray[rowCount].split('*');
        if ((ddlBankLedgerId == itemArray[1].toLowerCase()) && SchemeId.toLowerCase() == itemArray[0].toLowerCase()) {
            choice = document.createElement('option');
            choice.value = itemArray[2];
            choice.appendChild(document.createTextNode(itemArray[2]));
            document.getElementById(ddlChecque).appendChild(choice);
        }
    }
    AddUsedChequNoInDropDown(SchemeId, ddlBankId, ddlChequeId, HF_UsedChecque);
}
function AddUsedChequNoInDropDown(SchemeId, ddlBank, ddlCheque, HF_UsedChecque) {

    var str = document.getElementById(HF_UsedChecque).value;
    if (str != '') {
        ddlBankLedger = document.getElementById(ddlBank);
        var rowArray = str.split('~');
        for (var k = 0; k < rowArray.length - 1; k++) {
            var itemArray = rowArray[k].split('*');
            ddlChecqueNos = document.getElementById(ddlCheque);
            if (ddlBankLedger.options[ddlBankLedger.selectedIndex].value.toLowerCase() == itemArray[1].toLowerCase() && SchemeId.toLowerCase() == itemArray[0].toLowerCase()) {
                var IsExist = true;
                for (var j = 1; j <= ddlChecqueNos.length - 1; j++) {
                    if (ddlChecqueNos.options[j].value.toLowerCase() == itemArray[2].toLowerCase()) {
                        IsExist = false;
                        break
                    }
                }
                if (IsExist == true) {
                    var ddlChecque = document.getElementById(ddlCheque).id;
                    choice = document.createElement('option');
                    choice.value = itemArray[2];
                    choice.appendChild(document.createTextNode(itemArray[2]));
                    document.getElementById(ddlCheque).appendChild(choice);
                }
            }
        }
    }
}

function AddChequeInUsedCheque(SchemeId, bankLedgerId, chequeno, HF_UsedChecque, HF_EditedCheque) {

    document.getElementById(HF_UsedChecque).value += SchemeId + '*' + bankLedgerId + '*' + chequeno + '~';
    RemoveUsedCheque(SchemeId, bankLedgerId, chequeno, HF_UsedChecque, HF_EditedCheque);
}
function EditChecqueNo(ChecqueNO, ddlCheque) {
    ddl = document.getElementById(ddlCheque);
    for (var i = 1; i <= ddl.length - 1; i++) {
        if (ddl.options[i].value.toLowerCase() == ChecqueNO.toLowerCase()) {
            document.getElementById(ddlCheque).selectedIndex = i;
            break
        }
    }

}
function RemoveUsedCheque(SchemeId, bankLedgerId, chequeno, HF_UsedChecque, HF_EditedCheque) {
    if (document.getElementById(HF_EditedCheque).value != '') {
        var strEditedCeque = document.getElementById(HF_EditedCheque).value;
        var EditedItemArray = strEditedCeque.split('*');

        if (EditedItemArray[1].toLowerCase() == bankLedgerId.toLowerCase() && EditedItemArray[2].toLowerCase() == chequeno.toLowerCase() && SchemeId.toLowerCase() == EditedItemArray[0].toLowerCase()) {
            return true;
        }
        else {
            var strUsedChecque = document.getElementById(HF_UsedChecque).value;
            var rowArray = strUsedChecque.split('~');
            var chequeFound = false;
            document.getElementById(HF_UsedChecque).value = '';
            var count = 0;
            for (var k = 0; k < rowArray.length - 1; k++) {
                var itemArray = rowArray[k].split('*');
                if (EditedItemArray[1].toLowerCase() == itemArray[1].toLowerCase() && EditedItemArray[2].toLowerCase() == itemArray[2].toLowerCase() && EditedItemArray[0].toLowerCase() == itemArray[0].toLowerCase()) {

                    if (count == 0) {

                    }
                    else {
                        document.getElementById(HF_UsedChecque).value += rowArray[k] + '~';
                    }
                    count = count + 1;
                }
                else {
                    document.getElementById(HF_UsedChecque).value += rowArray[k] + '~';
                }

            }
        }
    }
}
function CheckIsChecqueNoUsed(SchemeId, ddlBank, ddlCheque, txtChequeNo, HF_UsedChecque) {

    var str = document.getElementById(HF_UsedChecque).value;
    var rowArray = str.split('~');
    for (var k = 0; k < rowArray.length - 1; k++) {
        var itemArray = rowArray[k].split('*');
        for (j = 0; j < itemArray.length; j++) {
            var ddlChequeNo = document.getElementById(ddlCheque);
            var ddlBankLedger = document.getElementById(ddlBank);
            if (ddlChequeNo.selectedIndex > 0) {
                var chequeno = ddlChequeNo.options[ddlChequeNo.selectedIndex].value;
            }
            else {
                var chequeno = document.getElementById(txtChequeNo).value;
            }
            if (ddlBankLedger.options[ddlBankLedger.selectedIndex].value.toLowerCase() == itemArray[1].toLowerCase() && SchemeId.toLowerCase() == itemArray[0].toLowerCase()) {
                if (itemArray[2] == chequeno) {
                    var confrmMsg;
                    if (GlobalLanguage == 1) {
                        confrmMsg = confirm('Checque no is already in used, do you continue to same cheque no ?');
                    } else {
                        confrmMsg = confirm('चेक नम्बर पहले से उपयोग मे है, क्या आप उपयोग करना चाहते है ?');
                    }

                    if (confrmMsg == true) {
                        return true;
                    }
                    else {
                        document.getElementById(ddlCheque).selectedIndex = 0;
                        document.getElementById(txtChequeNo).value = '';
                        return false;
                    }
                }
            }
        }
    }
}

function GetEditedChequeNo(SchemeId, BankLedgerId, ChequeNo, HF_EditedCheque) {
    document.getElementById('HF_EditedCheque').value = SchemeId + '*' + BankLedgerId + '*' + ChequeNo;

}
function DeleteUsedCheque(SchemeId, bankLedgerId, chequeno, HF_UsedChecque) {

    var strUsedChecque = document.getElementById(HF_UsedChecque).value;
    var rowArray = strUsedChecque.split('~');
    var chequeFound = false;
    document.getElementById(HF_UsedChecque).value = '';
    var count = 0;
    for (var k = 0; k < rowArray.length - 1; k++) {
        var itemArray = rowArray[k].split('*');
        if (bankLedgerId.toLowerCase() == itemArray[1].toLowerCase() && chequeno == itemArray[2].toLowerCase() && SchemeId.toLowerCase() == itemArray[0].toLowerCase()) {

            if (rowArray.length == 2) {
                return;
            }

            if (count == 0) {

            }
            else {
                document.getElementById(HF_UsedChecque).value += rowArray[k] + '~';
            }
            count = count + 1;
        }
        else {
            document.getElementById(HF_UsedChecque).value += rowArray[k] + '~';
        }

    }
}
//-----------------------------------End-----------------------------------------------
// This Check Book functionality is used not used on (Finance/frm_InterScheme_Transfer.aspx & Finance/frm_ExpensesAllocation_Voucher.aspx) pages but Check Book functionality is used different type
function CheckBookCloseFinancialYearDateFormate(HF_FromDate, HF_ToDate, txtDate, ddlScheme, HF_BranchId, HF_IsBookClosed, HF_Language) {
    try {

        if (checkDateFormat(document.getElementById(txtDate))) {
        } else {

            return false;
        }




        var SelectedDate = document.getElementById(txtDate).value.replace("-", "/").replace("-", "/").split("/");

        var SelectedDateStr = SelectedDate[1] + "/" + SelectedDate[0] + "/" + SelectedDate[2];
        DateNow = new Date(SelectedDateStr);

        if (CheckIsBookClosed(DateNow, txtDate, ddlScheme, HF_BranchId, HF_IsBookClosed, HF_Language)) {


            var FromDateStr = document.getElementById(HF_FromDate).value;
            var ToDateStr = document.getElementById(HF_ToDate).value;

            var FromDateArray = FromDateStr.replace("-", "/").replace("-", "/").split("/");
            var ToDateArray = ToDateStr.replace("-", "/").replace("-", "/").split("/");
            var FromDateString = FromDateArray[1] + "/" + FromDateArray[0] + "/" + FromDateArray[2];
            var ToDateString = ToDateArray[1] + "/" + ToDateArray[0] + "/" + ToDateArray[2];

            var FromDate = new Date(FromDateString);
            var ToDate = new Date(ToDateString);


            if (FromDate <= DateNow && DateNow <= ToDate) {

            }
            else {
                document.getElementById(txtDate).value = '';
                if (document.getElementById(HF_Language).value == 1) {
                    alert('Date should be between Financial year' + ' ' + '(' + FromDateArray[0] + "/" + FromDateArray[1] + "/" + FromDateArray[2].substring(0, 4) + ' ' + 'to' + ' ' + ToDateArray[0] + "/" + ToDateArray[1] + "/" + ToDateArray[2].substring(0, 4) + ')');


                } else {
                    alert('चुनी गई तिथि वित्तीय वर्ष के बीच की होना चाहिये ।' + ' ' + '(' + FromDateArray[0] + "/" + FromDateArray[1] + "/" + FromDateArray[2].substring(0, 4) + ' ' + 'to' + ' ' + ToDateArray[0] + "/" + ToDateArray[1] + "/" + ToDateArray[2].substring(0, 4) + ')');

                }

            }

        }
    }
    catch (e) {
        alert(e);
    }

}
function CheckIsBookClosed(DateNow, txtDate, ddlScheme, HF_BranchId, HF_IsBookClosed, HF_Language) {

    if (DateNow != '') {


        var ddlScheme = document.getElementById(ddlScheme);

        var scheme = ddlScheme.options[ddlScheme.selectedIndex].value.toLowerCase();
        if (ddlScheme.selectedIndex <= 0) {

            if (document.getElementById(HF_Language).value == 1) {
                alert('Please Select Scheme');

            } else {
                alert('कृपया  स्कीम चुनें ');
            }
            document.getElementById(txtDate).value = '';

            return false;
        }
        else {
            var rowArray = new Array();
            if (document.getElementById(HF_IsBookClosed).value != '') {
                rowArray = document.getElementById(HF_IsBookClosed).value.split('~');
                for (var i = 0; i < rowArray.length; i++) {
                    var itemArray = new Array();
                    itemArray = rowArray[i].split('*');
                    var BranchId = document.getElementById(HF_BranchId).value;

                    if (scheme == itemArray[0].toLowerCase() && BranchId.toLowerCase() == itemArray[1].toLowerCase()) {

                        var ClosedDateArray = itemArray[2].replace("-", "/").replace("-", "/").split("/");
                        var CloseDateString = ClosedDateArray[1] + "/" + ClosedDateArray[0] + "/" + ClosedDateArray[2];
                        var CloseDate = new Date(CloseDateString);
                        if (DateNow > CloseDate) {
                            return true;
                        }
                        else {
                            if (document.getElementById(HF_Language).value == 1) {
                                alert('Book is already Closed on' + ' ' + ClosedDateArray[0] + "/" + ClosedDateArray[1] + "/" + ClosedDateArray[2].substring(0, 4) + '' + ' ' + ' for Selected Scheme');

                            } else {
                                alert('चुनी हुई स्कीम के लिये बुक ' + ' ' + ClosedDateArray[0] + "/" + ClosedDateArray[1] + "/" + ClosedDateArray[2].substring(0, 4) + '' + ' ' + ' को बन्द हो चुकी है ।');

                            }
                            document.getElementById(txtDate).value = '';
                            return false;
                        }
                    }
                }

            }
            else {
                return true;
            }
        }
    }
    else {
        return true;
    }
}
function checkDateFormat(that) {

    var mo, day, yr;
    var entry = that.value;
    var re = /\b\d{1,2}[\/-]\d{1,2}[\/-]\d{4}\b/;
    if (re.test(entry)) {
        var delimChar = (entry.indexOf("/") != -1) ? "/" : "-";
        var delim1 = entry.indexOf(delimChar);
        var delim2 = entry.lastIndexOf(delimChar);

        day = parseInt(entry.substring(0, delim1), 10);
        mo = parseInt(entry.substring(delim1 + 1, delim2), 10);
        yr = parseInt(entry.substring(delim2 + 1), 10);
        var testDate = new Date(yr, mo - 1, day);

        if (testDate.getDate() == day) {
            if (testDate.getMonth() + 1 == mo) {
                if (testDate.getFullYear() == yr) {
                    return true;
                } else {
                    that.value = "";
                    if (GlobalLanguage == 0) {
                        alert("दिनांक सही नही है |");
                    } else {
                        alert("Invalid Date.");
                    }

                }
            }
            else {
                that.value = "";
                if (GlobalLanguage == 0) {
                    alert("दिनांक सही नही है |");
                } else {
                    alert("Invalid Date.");
                }

            }
        }
        else {
            that.value = "";
            if (GlobalLanguage == 0) {
                alert("दिनांक सही नही है |");
            } else {
                alert("Invalid Date.");
            }
        }
    }
    else {
        if (entry != "") {
            that.value = "";
            if (GlobalLanguage == 0) {
                alert("दिनांक का फोर्मेट सही नही है, (दिन/माह/वर्ष) फोर्मेट मे भरे |");
            } else {
                alert("Incorrect date format. Enter as dd/MM/yyyy.");
            }

        }
    }
    return false;

}

function TitleCase(objField) {

    var objValues = objField.value.split(" ");
    var outText = "";
    for (var i = 0; i < objValues.length; i++) {
        outText = outText + objValues[i].substr(0, 1).toUpperCase() + objValues[i].substr(1).toLowerCase() + ((i < objValues.length - 1) ? " " : "");
    }
    objField.value = outText;
    //return ;
}

function ValidationForMaXLength(that, Length) {
    if (that.value.length > Length) {
        that.value = that.value.substring(0, parseInt(Length));
        if (GlobalLanguage == 0) {
            alert("आप  " + Length + " अक्षर से ज्यादा नहीं डाल सकते ।");
        }
        else {
            alert("Can not enter more then " + Length + " character.");
        }
    }

}