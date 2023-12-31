
//=============== here 1: English,0: Hindi,2:===================//
var GlobalLanguage;

function ChangeLabel(Choice, FormId, QueryString) {
   
    GlobalLanguage = Choice;
    //=============== WebYojna Hindi Label Managed Code Start ===================//


    //Form ID 166, Form Name:YM_Master/frm_Category_Master.aspx
    if (Choice == 0 && FormId == 166) {
        document.getElementById("LblHeader").innerHTML = "श्रेणी मास्टर";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btnNew").value = "नया";
        document.getElementById("btnEdit").value = "सुधारें";
        document.getElementById("btnExit").value = "बाहर निकलें";
        document.getElementById("lblCategory").innerHTML = "श्रेणी का नाम";
        document.getElementById("lblCategoryHindi").innerHTML = "श्रेणी का नाम (हिन्दी)";
        document.getElementById("lbldescription").innerHTML = "विवरण";
        document.getElementById("lbldescriptionhindi").innerHTML = "विवरण (हिन्दी)";
        document.getElementById("lblLevelName").innerHTML = "स्तर का नाम";
        document.getElementById("lblCodeNo").innerHTML = "कोड नंबर";
        document.getElementById("lblMainCategory").innerHTML = "मुख्य श्रेणी का नाम";
        document.getElementById("chkEnable").nextSibling.innerHTML = " अनुमति";
        document.getElementById("lblCategoryDetail").innerHTML = "श्रेणी का विवरण";

        document.getElementById("lblsearchcategory").innerHTML = "श्रेणी  खोजें ";
        document.getElementById("lblsearchcategorylevelname").innerHTML = "स्तर का नाम";
        document.getElementById("btnsearch").value = "खोजें ";
        // Hindi,Increase Font code
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("btnExit").className = "btn_Hindi";
        document.getElementById("lblCategory").className = "Frm_Txt_Hindi";
        document.getElementById("lblCategoryHindi").className = "Frm_Txt_Hindi";
        document.getElementById("lbldescription").className = "Frm_Txt_Hindi";
        document.getElementById("lbldescriptionhindi").className = "Frm_Txt_Hindi";
        
        document.getElementById("lblLevelName").className = "Frm_Txt_Hindi";
        document.getElementById("lblCodeNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblMainCategory").className = "Frm_Txt_Hindi";
        document.getElementById("chkEnable").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("lblCategoryDetail").className = "Frm_Txt_Hindi";

        document.getElementById("lblsearchcategory").className = "Frm_Txt_Hindi";
        document.getElementById("lblsearchcategorylevelname").className = "Frm_Txt_Hindi";
        document.getElementById("btnsearch").className = "btn_Hindi";
        

        // Grid Code Start
        var table = document.getElementById("gvCategory");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "हटाये";
        tr.cells[1].innerHTML = "चुनिये";
        tr.cells[2].innerHTML = "श्रेणी का नाम";
        tr.cells[3].innerHTML = "श्रेणी का नाम (हिन्दी)";
        tr.cells[4].innerHTML = "कोड नंबर";
        tr.cells[5].innerHTML = "स्तर का नाम";
        tr.cells[6].innerHTML = "मुख्य श्रेणी का नाम";

        tr.cells[10].innerHTML = "विवरण";
        tr.cells[11].innerHTML = "विवरण (हिन्दी)";
        
        // Lebel Hindi Font Increase //
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
        tr.cells[5].className = "Frm_Txt_Hindi";
        tr.cells[6].className = "Frm_Txt_Hindi";

        tr.cells[10].className = "Frm_Txt_Hindi";
        tr.cells[11].className = "Frm_Txt_Hindi";
        
    }

    //Form ID 168, Form Name:YM_Master/frm_Group_Master.aspx
    if (Choice == 0 && FormId == 168) {
        document.getElementById("LblHeader").innerHTML = "ग्रुप मास्टर";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btnNew").value = "नया";
        document.getElementById("btnEdit").value = "सुधारें";
        document.getElementById("btnExit").value = "बाहर निकलें";
        document.getElementById("lblGroup").innerHTML = "ग्रुप का नाम";
        document.getElementById("lblGroupHindi").innerHTML = "ग्रुप का नाम (हिन्दी)";
        document.getElementById("lblPrimaryGroup").innerHTML = "प्राइमरी ग्रुप का नाम";
        document.getElementById("chFixed").nextSibling.innerHTML = " स्थायी";
        //==============Hindi Font Increase==================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("btnExit").className = "btn_Hindi";
        document.getElementById("lblGroup").className = "Frm_Txt_Hindi";
        document.getElementById("lblGroupHindi").className = "Frm_Txt_Hindi";
        document.getElementById("lblPrimaryGroup").className = "Frm_Txt_Hindi";
        document.getElementById("chFixed").nextSibling.className = "Frm_Txt_Hindi";

        // Grid Code Start
        var table = document.getElementById("gvGroup");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "हटाये";
        tr.cells[1].innerHTML = "चुनिये";
        tr.cells[2].innerHTML = "ग्रुप का नाम";
        tr.cells[3].innerHTML = "ग्रुप का नाम (हिन्दी)";
        tr.cells[4].innerHTML = "प्राइमरी ग्रुप का नाम";
        //==============Hindi Font Increase==================//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
    }

    //Form ID 169, Form Name:YM_Master/Frm_LedgerMaster.aspx
    if (Choice == 0 && FormId == 169) {
        document.getElementById("LblHeader").innerHTML = "लेजर मास्टर";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btnNew").value = "नया";
        document.getElementById("btnEdit").value = "सुधारें";
        document.getElementById("btnExit").value = "बाहर निकलें";
        document.getElementById("btnCancelData").value = "रद्द करें";
        document.getElementById("btnDelete").value = "हटायें";
        document.getElementById("lblLedgerName").innerHTML = "लेजर का नाम :";
        document.getElementById("chkSpacialPurpose").nextSibling.innerHTML = " विशेष उद्देश्य ";
        document.getElementById("lblLedgerNameHindi").innerHTML = "लेजर का नाम (हिन्दी) :";
        document.getElementById("lblGroup").innerHTML = "ग्रुप का नाम :";
        document.getElementById("chkWithBudget").nextSibling.innerHTML = " बजट के साथ ";
        document.getElementById("chkAgency").nextSibling.innerHTML = " एजेंसी";
        //document.getElementById("chkCategory").nextSibling.innerHTML = " श्रेणी";
        document.getElementById("lblLedgerHead").innerHTML = "लेजर :-";
        document.getElementById("lblSearch").innerHTML = "खोजें :";
        //==============Hindi Font Increase==================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("btnExit").className = "btn_Hindi";
        document.getElementById("btnCancelData").className = "btn_Hindi";
        document.getElementById("btnDelete").className = "btn_Hindi";
        document.getElementById("lblLedgerName").className = "Frm_Txt_Hindi";
        document.getElementById("chkSpacialPurpose").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("lblLedgerNameHindi").className = "Frm_Txt_Hindi";
        document.getElementById("lblGroup").className = "Frm_Txt_Hindi";
        document.getElementById("chkWithBudget").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("chkAgency").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("chkCategory").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("lblLedgerHead").className = "Frm_Txt_Hindi";
        document.getElementById("lblSearch").className = "Frm_Txt_Hindi";

        // Grid Code Start
        var table = document.getElementById("gvScheme");
        var tr = table.rows[0];
        //tr.cells[0].innerHTML = "स्कीम";
        tr.cells[1].innerHTML = "वित्तीय ";
        tr.cells[2].innerHTML = "फिजिकल";
        //==============Hindi Font Increase==================//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";

        // Grid Code Start
        var table = document.getElementById("gvCategory");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "श्रेणी";
        tr.cells[1].innerHTML = "वित्तीय ";
        tr.cells[2].innerHTML = "फिजिकल";
        //==============Hindi Font Increase==================//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
    }

    //Form ID 167, Form Name:YM_Master/frm_Scheme_Master.aspx
    if (Choice == 0 && FormId == 167) {
        document.getElementById("LblHeader").innerHTML = "स्कीम मास्टर";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btnNew").value = "नया";
        document.getElementById("btnEdit").value = "सुधारें";
        document.getElementById("btnExit").value = "बाहर निकलें";
        document.getElementById("lblScheme").innerHTML = "स्कीम का नाम";
        document.getElementById("lblSchemeHindi").innerHTML = "स्कीम का नाम (हिन्दी)";
        document.getElementById("lblUmbrelaScheme").innerHTML = "अम्ब्रेला स्कीम";
        document.getElementById("lblAlias").innerHTML = "उपनाम";
        document.getElementById("lblAliasHindi").innerHTML = "उपनाम (हिन्दी)";
        document.getElementById("lblsponsortype").innerHTML = "प्रायोजक का प्रकार ";
        document.getElementById("lblnatureofscheme").innerHTML = "स्कीम की प्रकृति  ";
        document.getElementById("lblfinyearofscheme").innerHTML = "स्कीम का वित्तीय वर्ष   ";
        document.getElementById("lblfromyear").innerHTML = "तिथि से  ";
        document.getElementById("lbltoyear").innerHTML = "तिथि तक  ";
//        document.getElementById("lblschemecoverage").innerHTML = "स्कीम के अंतर्गत जिला और जनपद   ";
//        document.getElementById("ChkAlldistrict").nextSibling.innerHTML = "सभी जिले "
//        document.getElementById("chkallblocks").nextSibling.innerHTML = "सभी जनपद "
        // Lebel Hindi Font Increase //
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("btnExit").className = "btn_Hindi";
        document.getElementById("lblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("lblSchemeHindi").className = "Frm_Txt_Hindi";
        document.getElementById("lblUmbrelaScheme").className = "Frm_Txt_Hindi";
        document.getElementById("lblAlias").className = "Frm_Txt_Hindi";
        document.getElementById("lblAliasHindi").className = "Frm_Txt_Hindi";
        document.getElementById("lblsponsortype").className = "Frm_Txt_Hindi";
        document.getElementById("lblnatureofscheme").className = "Frm_Txt_Hindi";
        document.getElementById("lblfinyearofscheme").className = "Frm_Txt_Hindi";
        document.getElementById("lblfromyear").className = "Frm_Txt_Hindi";
        document.getElementById("lbltoyear").className = "Frm_Txt_Hindi";
//        document.getElementById("lblschemecoverage").className = "Frm_Txt_Hindi";



//        var RBPlan = document.getElementById("rbPlanWise");
//        var RB1 = RBPlan.parentNode.getElementsByTagName("label");
//        RB1[0].innerHTML = "प्लान ";

//        var RBnonPlan = document.getElementById("rbNonPlanWise");
//        var RB1 = RBnonPlan.parentNode.getElementsByTagName("label");
//        RB1[0].innerHTML = "नॉन प्लान ";

        var RBIndivisual = document.getElementById("rbindividual");
        var RB3 = RBIndivisual.parentNode.getElementsByTagName("label");
        RB3[0].innerHTML = "स्वयं ";

        var RBConvergence = document.getElementById("rbconvergence");
        var RB4 = RBConvergence.parentNode.getElementsByTagName("label");
        RB4[0].innerHTML = "कनवरजेंस";

        // Grid Code Start
        var table = document.getElementById("gvScheme");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "चुनिये";
        tr.cells[1].innerHTML = "हटाये";
        tr.cells[2].innerHTML = "स्कीम का नाम";
        tr.cells[3].innerHTML = "स्कीम का नाम (हिन्दी)";
//        tr.cells[4].innerHTML = "अम्ब्रेला स्कीम का नाम";
//        tr.cells[5].innerHTML = "अम्ब्रेला स्कीम का नाम (हिन्दी)";
        //tr.cells[4].innerHTML = "";
       // tr.cells[5].innerHTML = "";
        //tr.cells[6].innerHTML = "प्रांरभिक डी आर";
        //tr.cells[7].innerHTML = "प्रांरभिक सी आर";
        //tr.cells[8].innerHTML = "आंतरिक डी आर";
        tr.cells[13].innerHTML = "उपनाम";
        tr.cells[14].innerHTML = "उपनाम (हिन्दी)";
        tr.cells[15].innerHTML = "कनवरजेंस / स्वयं";
        // Lebel Hindi Font Increase //
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
//        tr.cells[6].className = "Frm_Txt_Hindi";
//        tr.cells[7].className = "Frm_Txt_Hindi";
//        tr.cells[8].className = "Frm_Txt_Hindi";
        tr.cells[13].className = "Frm_Txt_Hindi";
        tr.cells[14].className = "Frm_Txt_Hindi";
        tr.cells[15].className = "Frm_Txt_Hindi";
    }

    //Form ID 170, Form Name:YM_Master/Ledger_Category_Config_Master.aspx
    if (Choice == 0 && FormId == 170) {
        document.getElementById("LblHeader").innerHTML = "एसओआर कॉन्फीगरेशन";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("btnsave").value = "रक्षित करें";
        document.getElementById("lblConfigType").innerHTML = "कॉन्फीगरेशन का प्रकार";
        document.getElementById("lblEffdate").innerHTML = "प्रभावित तिथि";
        if (document.getElementById("lblLedgerType") != null) {
            document.getElementById("lblLedgerType").innerHTML = "लेजर का प्रकार";
        }
        if (document.getElementById("lblledger") != null) {
            document.getElementById("lblledger").innerHTML = "लेजर";
        }
        if (document.getElementById("lblCategory") != null) {
            document.getElementById("lblCategory").innerHTML = "श्रेणी";
        }
        document.getElementById("chkDefaultSetting").nextSibling.innerHTML = "सामान्य सभी शाखाओ के लिये";
        if (document.getElementById("chkisAgency") != null) {
            document.getElementById("chkisAgency").nextSibling.innerHTML = "इज एजेंसी ";
        }
        if (document.getElementById("chkisCategory") != null) {
            document.getElementById("chkisCategory").nextSibling.innerHTML = "इज श्रेणी";
        }
        if (document.getElementById("rbDMSYES") != null) {
            var RBYes = document.getElementById("rbDMSYES");
            var RB = RBYes.parentNode.getElementsByTagName("label");
            RB[0].innerHTML = "हाँ";
        }

        if (document.getElementById("rbDMSNO") != null) {
            var RBNo = document.getElementById("rbDMSNO");
            var RB = RBNo.parentNode.getElementsByTagName("label");
            RB[0].innerHTML = "नहीं ";
        }
        //==============Hindi Font Increase==================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnsave").className = "btn_Hindi";
        document.getElementById("lblConfigType").className = "Frm_Txt_Hindi";
        document.getElementById("lblEffdate").className = "Frm_Txt_Hindi";
        if (document.getElementById("lblLedgerType") != null) {
            document.getElementById("lblLedgerType").className = "Frm_Txt_Hindi";
        }
        if (document.getElementById("lblledger") != null) {
            document.getElementById("lblledger").className = "Frm_Txt_Hindi";
        }
        if (document.getElementById("lblCategory") != null) {
            document.getElementById("lblCategory").className = "Frm_Txt_Hindi";
        }
        if (document.getElementById("chkDefaultSetting") != null) {
            document.getElementById("chkDefaultSetting").nextSibling.className = "Frm_Txt_Hindi";
        }
        if (document.getElementById("chkisAgency") != null) {
            document.getElementById("chkisAgency").nextSibling.className = "Frm_Txt_Hindi";
        }
        if (document.getElementById("chkisCategory") != null) {
            document.getElementById("chkisCategory").nextSibling.className = "Frm_Txt_Hindi";
        }

        //Radio Button Code Start
        var LedgerCatConfig = document.getElementById("rbLedgerCatConfig");
        var RB = LedgerCatConfig.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "लेजर एवं श्रेणी कॉन्फीगरेशन";
        RB[0].className = "Frm_Txt_Hindi";

        //Radio Button Code Start
        var LimitConfig = document.getElementById("rbLimitConfig");
        var RB = LimitConfig.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "कॉन्फीगरेशन सीमा";
        RB[0].className = "Frm_Txt_Hindi";

        var LimitConfig = document.getElementById("rbDmsRequired");
        var RB = LimitConfig.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "डी एम एस कॉन्फीगरेशन";
        RB[0].className = "Frm_Txt_Hindi";

        // Grid Code Start
        if (document.getElementById("gridConfig") != null) {
            var table = document.getElementById("gridConfig");
            var tr = table.rows[0];
            tr.cells[0].innerHTML = "चुनिये";
            tr.cells[1].innerHTML = "हटायें";
            tr.cells[3].innerHTML = "कॉन्फीगरेशन का नाम";
            tr.cells[4].innerHTML = "प्रभावित तिथि";
            tr.cells[5].innerHTML = "लेजर का नाम";
            tr.cells[6].innerHTML = "श्रेणी का नाम";
            //=======Text=======//
            tr.cells[0].className = "Frm_Txt_Hindi";
            tr.cells[1].className = "Frm_Txt_Hindi";
            tr.cells[3].className = "Frm_Txt_Hindi";
            tr.cells[4].className = "Frm_Txt_Hindi";
            tr.cells[5].className = "Frm_Txt_Hindi";
            tr.cells[6].className = "Frm_Txt_Hindi";
        }
        //Dms grid code
        if (document.getElementById("GV_DMS") != null) {
            var table = document.getElementById("GV_DMS");
            var tr = table.rows[0];
            tr.cells[0].innerHTML = "चुनिये";
            tr.cells[1].innerHTML = "हटायें";
            tr.cells[3].innerHTML = "कॉन्फीगरेशन का नाम";
            tr.cells[4].innerHTML = "प्रभावित तिथि";

            //=======Text=======//
            tr.cells[0].className = "Frm_Txt_Hindi";
            tr.cells[1].className = "Frm_Txt_Hindi";
            tr.cells[3].className = "Frm_Txt_Hindi";
            tr.cells[4].className = "Frm_Txt_Hindi";
        }

    }

    //Form ID 2202, Form Name:YM_Report/rpt_AgencyListPrint.aspx
    if (Choice == 0 && FormId == 2202) {
        document.getElementById("LblHeader").innerHTML = "एजेंसी सूची प्रिंट";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        var RBHindi = document.getElementById("RbWithBranch");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "उप शाखा सहित";
        RB[0].className = "Frm_Txt_Hindi";

        var RBenglish = document.getElementById("RbWithoutBranch");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "उप शाखा रहित";
        RB[0].className = "Frm_Txt_Hindi";
        document.getElementById("lblAgencyType").innerHTML = "एजेंसी का प्रकार";
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblAgencyType").className = "Frm_Txt_Hindi";
        document.getElementById("lblStandardColumns").innerHTML = "एजेंसी का प्रकार";
        document.getElementById("ChkAll").nextSibling.innerHTML = "सभी चुनें";
        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("btnSaveAsExcel").value = "एक्सेल में रक्षित करें";
        document.getElementById("lblStandardColumns").className = "Frm_Txt_Hindi";
        document.getElementById("ChkAll").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveAsExcel").className = "btn_Hindi";
    }

    //Form ID 172, Form Name:YM_Master/frm_SorLimitConfiguration.aspx
    if (Choice == 0 && FormId == 172) {
        document.getElementById("LblHeader").innerHTML = "एसओआर लिमिट कॉन्फीगरेशन";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("lbldesignation").innerHTML = "पद";
        document.getElementById("lbltechnicallimit").innerHTML = "तकनीकी स्वीकृति की सीमा";
        document.getElementById("lbladminsenctionlimit").innerHTML = "प्रशासकीय स्वीकृति की सीमा";
        document.getElementById("lbleffectivedate").innerHTML = "प्रभावित तिथि";
        document.getElementById("btnsave").value = "रक्षित करें";
        document.getElementById("btnprint").value = "प्रिंट करें";
        //=========Hindi==========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lbldesignation").className = "Frm_Txt_Hindi";
        document.getElementById("lbltechnicallimit").className = "Frm_Txt_Hindi";
        document.getElementById("lbladminsenctionlimit").className = "Frm_Txt_Hindi";
        document.getElementById("lbleffectivedate").className = "Frm_Txt_Hindi";
        document.getElementById("btnsave").className = "btn_Hindi";
        document.getElementById("btnprint").className = "btn_Hindi";

        // Grid Code Start
        var table = document.getElementById("gvlimitConfiguration");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "चुनिये";
        tr.cells[2].innerHTML = "पद";
        tr.cells[3].innerHTML = "प्रभावित तिथि";
        tr.cells[4].innerHTML = "तकनीकी स्वीकृति की सीमा";
        tr.cells[5].innerHTML = "प्रशासकीय स्वीकृति की सीमा";
        //=========Hindi Text===========//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
        tr.cells[5].className = "Frm_Txt_Hindi";
    }

    // **********************************************************************
    //Form ID 172, Form Name:YM_Master/Frm_Scheme_Coverage.aspx
    if (Choice == 0 && FormId == 2555) {
        document.getElementById("LblHeader").innerHTML = "स्कीम कवरेज मास्टर ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("lblScheme").innerHTML = "स्कीम का नाम ";
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btnCancel").value = "रद्द  करें";
        document.getElementById("btnShow").value = "देखें ";
      
        //=========Hindi==========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
       

      
    }
      
}



