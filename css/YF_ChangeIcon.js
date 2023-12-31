
//=============== here 1: English,0: Hindi,2:===================//
var GlobalLanguage;

function ChangeLabel(Choice, FormId, QueryString) {

    GlobalLanguage = Choice;
    //=============== WebYojna Hindi Label Managed Code Start ===================//

    //Form ID 90, Form Name:YF_Master/CashOpening.aspx
    if (Choice == 0 && FormId == 90) {
        document.getElementById("LblHeader").innerHTML = "प्रारंभिक रोकड शेष";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("LblBankName").innerHTML = "खाता का नाम (अंग्रेजी)";
        document.getElementById("lblBankHindi").innerHTML = "खाता का नाम (हिन्दी)";
        document.getElementById("BtnSave").value = "रक्षित करें";
        document.getElementById("btnCancel").value = "रद्द करें";
        //Hindi Font Increase
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("LblBankName").className = "Frm_Txt_Hindi";
        document.getElementById("lblBankHindi").className = "Frm_Txt_Hindi";
        document.getElementById("BtnSave").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";

        //Grid Code Start
        var table = document.getElementById("GridView1");
        var tr = table.rows[0];
        // document.getElementById("GridView1_ctl01_chkSelectAll").nextSibling.innerHTML = "स्कीम";
        // tr.cells[0].innerHTML = "स्कीमका का नाम";
        tr.cells[1].innerHTML = "क्रेडिट / डेबिट";
        tr.cells[2].innerHTML = "राशि";
        //Hindi Font Increase
        //document.getElementById("GridView1_ctl01_chkSelectAll").nextSibling.className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
    }

    //Form ID 165, Form Name:YF_Master/Agency_Opening.aspx
    if (Choice == 0 && FormId == 165) {
        document.getElementById("LblHeader").innerHTML = "एजेंसी का प्रारंभिक शेष";
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
        document.getElementById("btnClose").value = "रद्द करें";
        document.getElementById("lblAgencyType").innerHTML = "एजेंसी का प्रकार चुनें";
        document.getElementById("lblSearchAgency").innerHTML = "एजेंसी खोजें :";
        document.getElementById("lblAgencies").innerHTML = "एजेंसी";
        document.getElementById("lblLedgers").innerHTML = "लेजर्स";
        document.getElementById("btnSaveDetail").value = "रक्षित करें";
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("btnSaveCategory").value = "रक्षित करें";
    }

    //Form ID 176, Form Name:YF_Master/frm_Voucher_Configuration.aspx
    if (Choice == 0 && FormId == 176) {
        document.getElementById("LblHeader").innerHTML = "वाउचर कॉन्फीगरेशन";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("VoucherConfiguration").innerHTML = "वाउचर कॉन्फीगरेशन";
        document.getElementById("ApplicationConfiguration").innerHTML = "आवेदन स्तर कॉन्फीगरेशन";
        document.getElementById("lblVoucher").innerHTML = "वाउचर कॉन्फीगरेशन";
        document.getElementById("lblConfigType").innerHTML = "कॉन्फीगरेशन का प्रकार";
        document.getElementById("lblLedgerEffectiveDt").innerHTML = "प्रभावित तिथि";
        document.getElementById("lblLedgerType").innerHTML = "लेजर का प्रकार";
        document.getElementById("lblLedger").innerHTML = "लेजर";
        document.getElementById("lblCategory").innerHTML = "श्रेणी";
        document.getElementById("chkDefault").nextSibling.innerHTML = "सामान्य सभी शाखाओ के लिये";
        document.getElementById("chkisAgency").nextSibling.innerHTML = "इज एजेंसी ";
        document.getElementById("chkisCategory").nextSibling.innerHTML = "इज श्रेणी";
        document.getElementById("btnsave_Ledger").value = "रक्षित करें";
        document.getElementById("btnCancel").value = "रद्द करें";
        //============ Tab 2 ============//
        document.getElementById("lblApplicationConfig").innerHTML = "आवेदन स्तर कॉन्फीगरेशन";
        document.getElementById("lblConfigurationType").innerHTML = "कॉन्फीगरेशन का प्रकार";
        document.getElementById("lblEffective").innerHTML = "प्रभावित तिथि";
        document.getElementById("btnSaveOther").value = "रक्षित करें";
        document.getElementById("btnCancelOther").value = "रद्द करें";
        //============Hindi Font Increase============//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblVoucher").className = "Frm_Txt_Hindi";
        document.getElementById("lblConfigType").className = "Frm_Txt_Hindi";
        document.getElementById("lblLedgerEffectiveDt").className = "Frm_Txt_Hindi";
        document.getElementById("lblLedgerType").className = "Frm_Txt_Hindi";
        document.getElementById("lblLedger").className = "Frm_Txt_Hindi";
        document.getElementById("lblCategory").className = "Frm_Txt_Hindi";
        document.getElementById("chkDefault").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("chkisAgency").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("chkisCategory").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("btnsave_Ledger").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        //============DDL Hindi Font Increase============//
        document.getElementById("ddlConfigurationType").className = "ddl_Hindi";
        document.getElementById("ddlLedgerType").className = "ddl_Hindi";
        document.getElementById("ddlLedger").className = "ddl_Hindi";
        document.getElementById("ddlCategory").className = "ddl_Hindi";

        //============ Tab 2 ============//
        document.getElementById("lblApplicationConfig").className = "Frm_Txt_Hindi";
        document.getElementById("lblConfigurationType").className = "Frm_Txt_Hindi";
        document.getElementById("lblEffective").className = "Frm_Txt_Hindi";
        document.getElementById("btnSaveOther").className = "btn_Hindi";
        document.getElementById("btnCancelOther").className = "btn_Hindi";
        document.getElementById("ddlConfigurationOther").className = "ddl_Hindi";

        //Grid लेजर कॉन्फीगरेशन Code Start
        var table = document.getElementById("gridLedger");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "चुनिये";
        tr.cells[1].innerHTML = "हटायें";
        tr.cells[2].innerHTML = "सरल क्रमांक";
        tr.cells[3].innerHTML = "कॉन्फीगरेशन नाम";
        tr.cells[4].innerHTML = "प्रभावित तिथि";
        tr.cells[5].innerHTML = "लेजर नाम";
        tr.cells[6].innerHTML = "श्रेणी";
        //=======Hindi Text========//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
        tr.cells[5].className = "Frm_Txt_Hindi";
        tr.cells[6].className = "Frm_Txt_Hindi";

        //Grid Application Level Code Start
        var table = document.getElementById("gvOtherConfiguration");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "चुनिये";
        tr.cells[1].innerHTML = "हटायें";
        tr.cells[2].innerHTML = "सरल क्रमांक";
        tr.cells[3].innerHTML = "कॉन्फीगरेशन का प्रकार";
        tr.cells[4].innerHTML = "प्रभावित तिथि";
        //=======Hindi Text========//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";

        // Yes,No Radio button code
        var RBHindi = document.getElementById("rbYes");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " हाँ";
        RB[0].className = "Frm_Txt_Hindi";

        var RBenglish = document.getElementById("rbNo");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " नहीं";
        RB[0].className = "Frm_Txt_Hindi";
    }

    //Form ID 177, Form Name:YF_Master/frn_BranchMaster.aspx
    //Form ID 177, Form Name:Master_Pages/frn_BranchMaster.aspx
    if (Choice == 0 && FormId == 177) {
        document.getElementById("LblHeader").innerHTML = "बैंक शाखा मास्टर";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("btnNew").value = "नया";
        document.getElementById("btnEdit").value = "सुधारें";
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btnExit").value = "बाहर निकलें";
        document.getElementById("lblBnakDetails").innerHTML = "बैंक विवरण";
        document.getElementById("lblBankName").innerHTML = "बैंक का नाम";
        document.getElementById("lblBranchName").innerHTML = "शाखा का नाम";
        document.getElementById("lblBranchNameHindi").innerHTML = "शाखा का नाम (हिन्दी) ";
        document.getElementById("lblBranchAddress").innerHTML = "शाखा का पता";

        document.getElementById("lblBranchLocated").innerHTML = "शाखा स्थित है :";
        document.getElementById("lblPinCode").innerHTML = "पिन कोड";
        //document.getElementById("lblIFSCCode").innerHTML = "आई एफ एस सी कोड";       
        document.getElementById("lblIFSCCode").innerHTML = "आई एफ एस सी";
        document.getElementById("lblMICR").innerHTML = "एम आई सी आर नंबर";
        //=============Hindi Font Increase=================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnExit").className = "btn_Hindi";
        document.getElementById("lblBnakDetails").className = "Frm_Txt_Hindi";
        document.getElementById("lblBankName").className = "Frm_Txt_Hindi";
        document.getElementById("lblBranchName").className = "Frm_Txt_Hindi";
        document.getElementById("lblBranchNameHindi").className = "Frm_Txt_Hindi";
        document.getElementById("lblBranchAddress").className = "Frm_Txt_Hindi";
        document.getElementById("lblPinCode").className = "Frm_Txt_Hindi";
        document.getElementById("lblIFSCCode").className = "Frm_Txt_Hindi";
        document.getElementById("lblMICR").className = "Frm_Txt_Hindi";
        document.getElementById("lblState").className = "Frm_Txt_Hindi";
        document.getElementById("lblDistrict").className = "Frm_Txt_Hindi";
        document.getElementById("lblBlock").className = "Frm_Txt_Hindi";
        document.getElementById("lblGramPanchayat").className = "Frm_Txt_Hindi";
        document.getElementById("lblBranchLocated").className = "Frm_Txt_Hindi";
        document.getElementById("lblVillage").className = "Frm_Txt_Hindi";
        //=============DDl Hindi Font Increase=================//
        document.getElementById("ddlState").className = "ddl_Hindi";
        document.getElementById("ddlDistrict").className = "ddl_Hindi";
        document.getElementById("ddlBlock").className = "ddl_Hindi";
        document.getElementById("ddlGramPanchayat").className = "ddl_Hindi";
        document.getElementById("ddlVillage").className = "ddl_Hindi";
        document.getElementById("ddlBankName").className = "ddl_Hindi";

        //Grid Code Start
        var table = document.getElementById("gvBankBranch");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "हटायें";
        tr.cells[1].innerHTML = "चुनिये";
        tr.cells[2].innerHTML = "बैंक का नाम";
        tr.cells[3].innerHTML = "शाखा का नाम";
        tr.cells[4].innerHTML = "शाखा का नाम (हिन्दी)";
        tr.cells[5].innerHTML = "शाखा का पता";
        tr.cells[6].innerHTML = "पिन कोड";
        tr.cells[7].innerHTML = "आई एफ एस सी कोड";
        tr.cells[8].innerHTML = "एम आई सी आर नंबर";
        tr.cells[16].innerHTML = "राज्य";
        tr.cells[17].innerHTML = "जिला";
        tr.cells[18].innerHTML = "जनपद";
        if (tr.cells[19] != null)
        {
            tr.cells[19].innerHTML = "ग्राम पंचायत";
            tr.cells[19].className = "Frm_Txt_Hindi";
        }

        //        tr.cells[20].innerHTML = "गाँव";
        if (tr.cells[20] != null) { 
         tr.cells[20].innerHTML = "";
         tr.cells[20].innerHTML = "गाँव";
         tr.cells[20].className = "Frm_Txt_Hindi";
        }
        
        //========Hindi Text========//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
        tr.cells[5].className = "Frm_Txt_Hindi";
        tr.cells[6].className = "Frm_Txt_Hindi";
        tr.cells[7].className = "Frm_Txt_Hindi";
        tr.cells[8].className = "Frm_Txt_Hindi";
        tr.cells[16].className = "Frm_Txt_Hindi";
        tr.cells[17].className = "Frm_Txt_Hindi";
        tr.cells[18].className = "Frm_Txt_Hindi";
        
        //  tr.cells[20].className = "Frm_Txt_Hindi";
    }
    //Form ID 178, Form Name:YF_Master/frm_BankMaster.aspx
    if (Choice == 0 && FormId == 178) {
        document.getElementById("LblHeader").innerHTML = "बैंक मास्टर";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("btnNew").value = "नया";
        document.getElementById("btnEdit").value = "सुधारें";
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btnExit").value = "बाहर निकलें";

        document.getElementById("btnExcel").value = "एक्सेल में रक्षित करें ";

        document.getElementById("btnPrint").value = "प्रिंट करें ";
        document.getElementById("lblBankMaster").innerHTML = "बैंक मास्टर";
        document.getElementById("lblBankType").innerHTML = "बैंक का प्रकार";
        document.getElementById("lblBankName").innerHTML = "बैंक का नाम";
        document.getElementById("lblBankNameHindi").innerHTML = "बैंक का नाम (हिन्दी)";
        document.getElementById("lblAlias").innerHTML = "उपनाम";
        document.getElementById("lblAliasHindi").innerHTML = "उपनाम (हिन्दी)";
        //===========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnExit").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnExcel").className = "btn_Hindi";
        document.getElementById("lblBankMaster").className = "Frm_Txt_Hindi";
        document.getElementById("lblBankName").className = "Frm_Txt_Hindi";
        document.getElementById("lblBankNameHindi").className = "Frm_Txt_Hindi";
        document.getElementById("lblAlias").className = "Frm_Txt_Hindi";
        document.getElementById("lblAliasHindi").className = "Frm_Txt_Hindi";

        //Grid Code Start
        var table = document.getElementById("gvBank");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "हटायें";
        tr.cells[1].innerHTML = "चुनिये";
        tr.cells[2].innerHTML = "बैंक का प्रकार";
        //        tr.cells[3].innerHTML = "बैंक का प्रकार (हिन्दी)";
        tr.cells[3].innerHTML = "बैंक का नाम";
        tr.cells[4].innerHTML = "बैंक का नाम (हिन्दी)";
        tr.cells[5].innerHTML = "उपनाम";
        tr.cells[6].innerHTML = "उपनाम (हिन्दी)";
        //========Hindi Text========//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        //        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
        tr.cells[5].className = "Frm_Txt_Hindi";
        tr.cells[6].className = "Frm_Txt_Hindi";
    }
    //===============Form ID 179, Form Name:YF_Master/frm_AccountMaster.aspx
    if (Choice == 0 && FormId == 179) {
        //alert("Hindi");
        document.getElementById("LblHeader").innerHTML = "खाता मास्टर";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("btnNew").value = "नया";
        document.getElementById("btnEdit").value = "सुधारें";
        document.getElementById("BtnSave").value = "रक्षित करें";
        document.getElementById("BtnExit").value = "बाहर निकलें";
        document.getElementById("LblBankName").innerHTML = "बैंक का नाम"
        document.getElementById("lblbankacno").innerHTML = "खाता नं.";
        document.getElementById("lblBranchName").innerHTML = "शाखा का नाम";
        document.getElementById("lblAccountType").innerHTML = "खाता का प्रकार"
        document.getElementById("lblAccountM").innerHTML = "खाता मास्टर";
        //document.getElementById("lblCentralised").innerHTML = "सेंटरालाइस्ड बैंक";
        if (document.getElementById("lblCentralised")!= null) {
            document.getElementById("lblCentralised").innerHTML = "सेंट्रालाइज्ड खाता";
            document.getElementById("lblCentralised").className = "Frm_Txt_Hindi";
            var RBYes = document.getElementById("rdb_Yes");
            var RB = RBYes.parentNode.getElementsByTagName("label");
            RB[0].innerHTML = "हाँ";

            var RBNo = document.getElementById("rdb_No");
            var RB = RBNo.parentNode.getElementsByTagName("label");
            RB[0].innerHTML = "नहीं";
        }
        
        //=============Hindi Font Increase=============//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("BtnSave").className = "btn_Hindi";
        document.getElementById("BtnExit").className = "btn_Hindi";
        document.getElementById("LblBankName").className = "Frm_Txt_Hindi";
        document.getElementById("lblbankacno").className = "Frm_Txt_Hindi";
        document.getElementById("lblBranchName").className = "Frm_Txt_Hindi";
        document.getElementById("lblAccountType").className = "Frm_Txt_Hindi";
        document.getElementById("lblAccountM").className = "Frm_Txt_Hindi";
        
        //=============DDl Hindi Font Increase=============//
        document.getElementById("ddlBank").className = "ddl_Hindi";
        document.getElementById("ddlBranchName").className = "ddl_Hindi";
        document.getElementById("ddlAccountType").className = "ddl_Hindi";

        //Grid Code Start
        var table = document.getElementById("gvScheme");
        var tr = table.rows[0];
        // document.getElementById("gvScheme_ctl01_chkSelectAll").nextSibling.innerHTML = "स्कीम"; ;
        //tr.cells[0].innerHTML = "स्कीम";
        tr.cells[1].innerHTML = "क्रेडिट / डेबिट";
        tr.cells[2].innerHTML = "प्रारंभिक शेष";
        //========Hindi Text========//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";

        //Grid Code Start
        var table = document.getElementById("gvAC_Detail");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "हटायें ";
        tr.cells[1].innerHTML = "चुने";
        tr.cells[2].innerHTML = "बैंक का नाम";
        tr.cells[3].innerHTML = "शाखा का नाम";
        tr.cells[4].innerHTML = "खाता का प्रकार";
        tr.cells[5].innerHTML = "खाता नं.";
        //========Hindi Text========//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
        tr.cells[5].className = "Frm_Txt_Hindi";

        
    }

    //Form ID 196, Form Name:Master_Pages/Frm_AgencyImport.aspx
    if (Choice == 0 && FormId == 196) {
        document.getElementById("LblHeader").innerHTML = "एजेंसी आयात";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        // Lebel code//       
        document.getElementById("lblAgencyType").innerHTML = "एजेंसी का प्रकार";
        document.getElementById("lblImport").innerHTML = "फाईल आयात करें";
        document.getElementById("btncancel").value = "रद्द करें";
        document.getElementById("btnSave").value = "रक्षित करें";
        //font increase ===//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblAgencyType").className = "Frm_Txt_Hindi";
        document.getElementById("lblImport").className = "Frm_Txt_Hindi";
        document.getElementById("btncancel").className = "btn_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";

        // Agency Radio button code
        var RBHindi = document.getElementById("rbagencywise");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "एजेंसी नाम वाँइस";
        RB[0].className = "Frm_Txt_Hindi";

        var RBenglish = document.getElementById("rbUserCodewise");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "यूजर कोड वाँइस";
        RB[0].className = "Frm_Txt_Hindi";

        document.getElementById("lblLine1").innerHTML = "एक्सेल शीट में क्रमशः  : - यह काँलम होने चाहिये । ";
        //document.getElementById("lblLine2").innerHTML = "नोट : - एक्सेल की पहली पंक्ति हेडर होनी चाहिये और एक्सेल शीट 2003 फोरमेट में बनाए । ";
        document.getElementById("btnSub").value = "ओके";
    }
    //Form ID 199, Form Name:Master_Pages/frm_agencyopening_import.aspx
    if (Choice == 0 && FormId == 199) {
        document.getElementById("LblHeader").innerHTML = "एजेंसी का प्रारंभिक शेष आयात";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        // Lebel code//
        document.getElementById("lblScheme").innerHTML = "स्कीम का नाम चुनें";
        document.getElementById("lblLedger").innerHTML = "लेजर का नाम चुनें";
        document.getElementById("lblCategory").innerHTML = "श्रेणी का नाम चुनें";
        document.getElementById("lblAgencyType").innerHTML = "एजेंसी का प्रकार";
        document.getElementById("lblImport").innerHTML = "फाईल आयात करें";
        document.getElementById("btncancel").value = "रद्द करें";
        document.getElementById("btnSave").value = "रक्षित करें";
        //font increase ===//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("lblLedger").className = "Frm_Txt_Hindi";
        document.getElementById("lblCategory").className = "Frm_Txt_Hindi";
        document.getElementById("lblAgencyType").className = "Frm_Txt_Hindi";
        document.getElementById("lblImport").className = "Frm_Txt_Hindi";
        document.getElementById("btncancel").className = "btn_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";

        // Agency Radio button code
        var RBHindi = document.getElementById("rbagencywise");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "एजेंसी नाम वाँइस";
        RB[0].className = "Frm_Txt_Hindi";

        var RBenglish = document.getElementById("rbUserCodewise");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "यूजर कोड वाँइस";
        RB[0].className = "Frm_Txt_Hindi";

        document.getElementById("lblLine1").innerHTML = "एक्सेल शीट में क्रमशः  : - यह काँलम होने चाहिये । ";
        document.getElementById("Label1").innerHTML = "नोट : - एक्सेल की पहली पंक्ति हेडर होनी चाहिये और एक्सेल शीट 2003 और 2007 फोरमेट में बनाए । ";


        // Grid Code Start
        var table = document.getElementById("gvImport");
        var tr = table.rows[0];
        tr.cells[1].innerHTML = "एजेंसी का नाम";
        tr.cells[2].innerHTML = "यूजर कोड";
        tr.cells[3].innerHTML = "डेविट राशि";
        tr.cells[4].innerHTML = "क्रेडिट राशि";
        //font increase ===//
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
    }


    //Form ID 2229, Form Name:finance/rpt_Consolidated_Abstract_Register.aspx
    if (Choice == 0 && FormId == 2229) {
        document.getElementById("LblHeader").innerHTML = "कनसालिडेटेड ऎब्स्ट्रक्ट रजिस्टर";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";

        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("lblSchemeName").innerHTML = "स्कीम का नाम";
        document.getElementById("ChkAll").nextSibling.innerHTML = " सभी चुनें";
        //        document.getElementById("lblAgencyType").innerHTML = "एजेंसी का प्रकार";
        //        document.getElementById("lblAgencyName").innerHTML = "एजेंसी का नाम";
        document.getElementById("lblFinancialYear").innerHTML = "वित्तीय वर्ष";
        document.getElementById("btnShow").value = "देखे";
        document.getElementById("btnprint").value = "प्रिंट करें";
        //============ font increase ===========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblSchemeName").className = "Frm_Txt_Hindi";
        document.getElementById("ChkAll").className = "Frm_Txt_Hindi";
        //        document.getElementById("lblAgencyType").className = "Frm_Txt_Hindi";
        //        document.getElementById("lblAgencyName").className = "Frm_Txt_Hindi";
        document.getElementById("lblFinancialYear").className = "Frm_Txt_Hindi";
        document.getElementById("lblStates").className = "Frm_Txt_Hindi";
        document.getElementById("lblDistricts").className = "Frm_Txt_Hindi";
        document.getElementById("lblBklocks").className = "Frm_Txt_Hindi";
        document.getElementById("lblGramPanchayats").className = "Frm_Txt_Hindi";
        document.getElementById("lblVillages").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnprint").className = "btn_Hindi";
        var RBHindi = document.getElementById("RbWithBranch");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "उप शाखा सहित";
        RB[0].className = "Frm_Txt_Hindi";

        var RBenglish = document.getElementById("RbWithoutBranch");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "उप शाखा रहित";
        RB[0].className = "Frm_Txt_Hindi";

    }
    //Form ID 2242, Form Name:FinancialReports/rpt_group_ledger_cat_combination.aspx"
    if (Choice == 0 && FormId == 2242) {
        document.getElementById("LblHeader").innerHTML = "लेजर सूची प्रिंट ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";


        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("btnShow").value = "देखें ";
        document.getElementById("btnExcel").value = "एक्सेल में रक्षित करें ";
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnExcel").className = "btn_Hindi";


        // Grid Code Start
        if (document.getElementById('ddlScheme').value == '00000') {
            var table = document.getElementById("gvCategory");
            var tr = table.rows[0];
            if (tr.cells.length == 10) {
                tr.cells[0].innerHTML = "क्रमांक";
                tr.cells[1].innerHTML = "स्कीम";
                tr.cells[2].innerHTML = "ग्रुप";
                tr.cells[3].innerHTML = "खाता प्रकार";
                tr.cells[4].innerHTML = "खाता /लेजर हेड";
                tr.cells[5].innerHTML = "कोड";
                tr.cells[6].innerHTML = "फंक्शनरी हेड ( Major/Minor/Sub Minor/Object Head)";
                tr.cells[7].innerHTML = "एजेंसी / पार्टी ";
                tr.cells[8].innerHTML = "फंक्शनरी हेड ";
                tr.cells[9].innerHTML = "बजट माँनीटरिंग ";
                //font increase ===//
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
                tr.cells[0].innerHTML = "क्रमांक";
                tr.cells[1].innerHTML = "स्कीम";
                tr.cells[2].innerHTML = "ग्रुप";
                tr.cells[3].innerHTML = "खाता प्रकार";
                tr.cells[4].innerHTML = "खाता /लेजर हेड";
                tr.cells[5].innerHTML = "कोड";
                tr.cells[6].innerHTML = "एजेंसी / पार्टी ";
                tr.cells[7].innerHTML = "बजट माँनीटरिंग ";
                //font increase ===//
                tr.cells[0].className = "Frm_Txt_Hindi";
                tr.cells[1].className = "Frm_Txt_Hindi";
                tr.cells[2].className = "Frm_Txt_Hindi";
                tr.cells[3].className = "Frm_Txt_Hindi";
                tr.cells[4].className = "Frm_Txt_Hindi";
                tr.cells[5].className = "Frm_Txt_Hindi";
                tr.cells[6].className = "Frm_Txt_Hindi";
                tr.cells[7].className = "Frm_Txt_Hindi";
            }

        }
        else {
            var table = document.getElementById("gvCategory");
            var tr = table.rows[0];
            if (tr.cells.length == 9) {
                tr.cells[0].innerHTML = "क्रमांक";
                //tr.cells[1].innerHTML = "स्कीम";
                tr.cells[1].innerHTML = "ग्रुप";
                tr.cells[2].innerHTML = "खाता प्रकार";
                tr.cells[3].innerHTML = "खाता /लेजर हेड";
                tr.cells[4].innerHTML = "कोड";
                tr.cells[5].innerHTML = "फंक्शनरी हेड ( Major/Minor/Sub Minor/Object Head)";
                tr.cells[6].innerHTML = "एजेंसी / पार्टी ";
                tr.cells[7].innerHTML = "फंक्शनरी हेड ";
                tr.cells[8].innerHTML = "बजट माँनीटरिंग ";
                //font increase ===//
                tr.cells[0].className = "Frm_Txt_Hindi";
                tr.cells[1].className = "Frm_Txt_Hindi";
                tr.cells[2].className = "Frm_Txt_Hindi";
                tr.cells[3].className = "Frm_Txt_Hindi";
                tr.cells[4].className = "Frm_Txt_Hindi";
                tr.cells[5].className = "Frm_Txt_Hindi";
                tr.cells[6].className = "Frm_Txt_Hindi";
                tr.cells[7].className = "Frm_Txt_Hindi";
                tr.cells[8].className = "Frm_Txt_Hindi";
                //tr.cells[9].className = "Frm_Txt_Hindi";
            } else {

                tr.cells[0].innerHTML = "क्रमांक";
                //tr.cells[1].innerHTML = "स्कीम";
                tr.cells[1].innerHTML = "ग्रुप";
                tr.cells[2].innerHTML = "खाता प्रकार";
                tr.cells[3].innerHTML = "खाता /लेजर हेड";
                tr.cells[4].innerHTML = "कोड";
                tr.cells[5].innerHTML = "एजेंसी / पार्टी ";
                tr.cells[6].innerHTML = "बजट माँनीटरिंग ";
                //font increase ===//
                tr.cells[0].className = "Frm_Txt_Hindi";
                tr.cells[1].className = "Frm_Txt_Hindi";
                tr.cells[2].className = "Frm_Txt_Hindi";
                tr.cells[3].className = "Frm_Txt_Hindi";
                tr.cells[4].className = "Frm_Txt_Hindi";
                tr.cells[5].className = "Frm_Txt_Hindi";
                tr.cells[6].className = "Frm_Txt_Hindi";
            }
        }
    }
    //Form ID 175, Form Name:reports/yojnareports/rpt_LedgerType.aspx
    if (Choice == 0 && FormId == 175) {
        document.getElementById("LblHeader").innerHTML = "लेजर टाईप रिपोर्ट";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("lblFromDate").innerHTML = "दिनांक से";
        document.getElementById("lblToDate").innerHTML = "दिनांक तक ";
        document.getElementById("lblScheme").innerHTML = "स्कीम चुने";
        document.getElementById("lblSchemeOption").innerHTML = "स्कीम विकल्प :-";
        document.getElementById("lblLedger").innerHTML = "लेजर चुने";
        document.getElementById("lblLedgerType").innerHTML = "लेजर का प्रकार चुने";
        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";
        //=========Hindi Font Increase==========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblFromDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblToDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("lblSchemeOption").className = "Frm_Txt_Hindi";
        document.getElementById("lblLedger").className = "Frm_Txt_Hindi";
        document.getElementById("lblLedgerType").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";

        var FCRA = document.getElementById("rbFCRA");
        var RB = FCRA.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " एफ सी आर ए ";
        RB[0].className = "Frm_Txt_Hindi";

        var NonFCRA = document.getElementById("rbNonFCRA");
        var RB = NonFCRA.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " नाँन एफ सी आर ए";
        RB[0].className = "Frm_Txt_Hindi";

        var Both = document.getElementById("rbBoth");
        var RB = Both.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " दोनों";
        RB[0].className = "Frm_Txt_Hindi";
    }
    //Form ID 2236, Form Name:FinancialReports/CAG_Reports/rpt_Receipt_Payment_Account.aspx
    if (Choice == 0 && FormId == 2236) {
        document.getElementById("LblHeader").innerHTML = "प्राप्ति एंव भुगतान खाता";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("lblCAGFormat").innerHTML = "सी एन्ड ऐ जी फाँरमेट - I";
        document.getElementById("lblFdate").innerHTML = "दिनांक से";
        document.getElementById("lblToDate").innerHTML = "दिनांक तक";
        var Default = document.getElementById("RbWithBranch");
        var RB = Default.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " उप शाखा सहित";
        RB[0].className = "Frm_Txt_Hindi";

        var custom = document.getElementById("RbWithoutBranch");
        var RB = custom.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " उप शाखा रहित";
        RB[0].className = "Frm_Txt_Hindi";

        document.getElementById("ChkAll").nextSibling.innerHTML = " सभी चुनें";
        document.getElementById("lblSchemeName").innerHTML = "स्कीम का नाम";
        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";
        //=======Hindi Text ============//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblCAGFormat").className = "Frm_Txt_Hindi";
        document.getElementById("lblFdate").className = "Frm_Txt_Hindi";
        document.getElementById("lblToDate").className = "Frm_Txt_Hindi";
        document.getElementById("ChkAll").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("lblSchemeName").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("lblStates").className = "Frm_Txt_Hindi";
        document.getElementById("lblDistricts").className = "Frm_Txt_Hindi";
        document.getElementById("lblBklocks").className = "Frm_Txt_Hindi";
        document.getElementById("lblGramPanchayats").className = "Frm_Txt_Hindi";
        document.getElementById("lblVillages").className = "Frm_Txt_Hindi";

        // Default and Branch Radio button code


        if (document.getElementById("RbWithBranch").checked == true) {
            //            document.getElementById("btnGo").value = "देखें";
            //            document.getElementById("lblPanchayatCode").innerHTML = "पंचायत कोड";
            //            document.getElementById("lbFindBranchCode").innerHTML = "शाखा कोड देखें";
            //            // Fint Size Increase code
            //            document.getElementById("btnGo").className = "btn_Hindi";
            //            document.getElementById("lblPanchayatCode").className = "Frm_Txt_Hindi";
        }
    }
    //Form ID 2237, Form Name:FinancialReports/CAG_Reports/rpt_Statement_Payable.aspx
    if (Choice == 0 && FormId == 2237) {
        document.getElementById("LblHeader").innerHTML = "भुगतान विवरण";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("lblCAGFormat").innerHTML = "सी एन्ड ऐ जी फाँरमेट - IV";
        document.getElementById("lblFdate").innerHTML = "दिनांक से";
        document.getElementById("lblToDate").innerHTML = "दिनांक तक";
        document.getElementById("ChkAll").nextSibling.innerHTML = " सभी चुनें";
        document.getElementById("lblSchemeName").innerHTML = "स्कीम का नाम";
        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        //========================= Hindi Text ========================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblCAGFormat").className = "Frm_Txt_Hindi";
        document.getElementById("lblFdate").className = "Frm_Txt_Hindi";
        document.getElementById("lblToDate").className = "Frm_Txt_Hindi";
        document.getElementById("ChkAll").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("lblSchemeName").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("lblStates").className = "Frm_Txt_Hindi";
        document.getElementById("lblDistricts").className = "Frm_Txt_Hindi";
        document.getElementById("lblBklocks").className = "Frm_Txt_Hindi";
        document.getElementById("lblGramPanchayats").className = "Frm_Txt_Hindi";
        document.getElementById("lblVillages").className = "Frm_Txt_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";

        // Default and Branch Radio button code
        var Default = document.getElementById("RbWithBranch");
        var RB = Default.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " उप शाखा सहित";
        RB[0].className = "Frm_Txt_Hindi";

        var custom = document.getElementById("RbWithoutBranch");
        var RB = custom.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " उप शाखा रहित";
        RB[0].className = "Frm_Txt_Hindi";


        if (document.getElementById("RbWithBranch").checked == true) {
            //            document.getElementById("btnGo").value = "देखें";
            //            document.getElementById("lblPanchayatCode").innerHTML = "पंचायत कोड";
            //            document.getElementById("lbFindBranchCode").innerHTML = "शाखा कोड देखें";
            //            // Fint Size Increase code
            //            document.getElementById("btnGo").className = "btn_Hindi";
            //            document.getElementById("lblPanchayatCode").className = "Frm_Txt_Hindi";
        }
    }
    // **********************************************************************
    if (Choice == 0 && FormId == 80) {
        // document.getElementById("LblUtilization").innerHTML = "ई-रोकड़ पुस्तक";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        // Income/Expenditure Radio button code
        var Income = document.getElementById("rbIncome");
        var RB = Income.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "आय";
        RB[0].className = "Frm_Txt_Hindi";

        var Expenditure = document.getElementById("rbExpenditure");
        var RB1 = Expenditure.parentNode.getElementsByTagName("label");
        RB1[0].innerHTML = "व्यय";
        RB1[0].className = "Frm_Txt_Hindi";

        document.getElementById("LblScheme").innerHTML = "स्कीम";
        document.getElementById("lblVoucherTemplate").innerHTML = "वाउचर टेमप्लेट";
        document.getElementById("lblBank").innerHTML = "बैंक खाता";
        document.getElementById("LblDate").innerHTML = "दिनांक";
        document.getElementById("lblIncomeExpend").innerHTML = "कुल व्यय";
        document.getElementById("lblClosingBalance0").innerHTML = "अंतिम शेष";
        document.getElementById("BtnSaveMain").value = "रक्षित करें";
        document.getElementById("BtnExitMain").value = "रद्द करें";
        document.getElementById("BtnGo").value = "देखें";
        document.getElementById("btnCreAge").value = "रक्षित करें";
        document.getElementById("btnAddAgency").value = "ऐजेंसी बनाऐं";
        document.getElementById("lblAgencyType").innerHTML = "ऐजेंसी का प्रकार";
        document.getElementById("lblAgencyNameCreation").innerHTML = "ऐजेंसी का नाम";
        document.getElementById("lblNarration").innerHTML = "विवरण";
        //=============Hindi Font InCrease============//
        document.getElementById("LblUtilization").className = "Frm_Head_Hindi";
        document.getElementById("LblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("lblVoucherTemplate").className = "Frm_Txt_Hindi";
        document.getElementById("lblBank").className = "Frm_Txt_Hindi";
        document.getElementById("LblDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblIncomeExpend").className = "Frm_Txt_Hindi";
        document.getElementById("lblClosingBalance0").className = "Frm_Txt_Hindi";
        document.getElementById("BtnSaveMain").className = "btn_Hindi";
        document.getElementById("BtnExitMain").className = "btn_Hindi";
        document.getElementById("BtnGo").className = "btn_Hindi";
        document.getElementById("btnAddAgency").className = "btn_Hindi";
        document.getElementById("btnAddAgency").className = "btn_Hindi";
        document.getElementById("lblAgencyType").className = "Frm_Txt_Hindi";
        document.getElementById("lblAgencyNameCreation").className = "Frm_Txt_Hindi";
        document.getElementById("lblNarration").className = "Frm_Txt_Hindi";
        //Radio button code
        //        var RBcreditors = document.getElementById("rbcreditors");
        //        var RB = RBcreditors.parentNode.getElementsByTagName("label");
        //        RB[0].innerHTML = "लेनदारों का प्रकार";
        //        RB[0].className = "Frm_Txt_Hindi";

        //        var RBOther = document.getElementById("rbOther");
        //        var RB = RBOther.parentNode.getElementsByTagName("label");
        //        RB[0].innerHTML = "अन्य";
        //        RB[0].className = "Frm_Txt_Hindi";

        //        var RBdebtor = document.getElementById("rbdebtor");
        //        var RB = RBdebtor.parentNode.getElementsByTagName("label");
        //        RB[0].innerHTML = "देनदारों का प्रकार";
        //        RB[0].className = "Frm_Txt_Hindi";

        //        var RBboth = document.getElementById("rbboth");
        //        var RB = RBboth.parentNode.getElementsByTagName("label");
        //        RB[0].innerHTML = "दोनो";
        //        RB[0].className = "Frm_Txt_Hindi";
        document.getElementById("lblGeneralIMT").innerHTML = "वाउचर की सामान्य जानकारी";
        document.getElementById("lblOtherIMT").innerHTML = "वाउचर की अन्य जानकारी";
        document.getElementById("spanddldetails").innerHTML = "सूची";
        //document.getElementById("spanagencyname").innerHTML = "राशि प्राप्त";
        document.getElementById("lblfundtransferby").innerHTML = "द्वारा कोष स्थानातंरण";
        document.getElementById("lblmaterial").innerHTML = "सामग्री";
        document.getElementById("lblunit").innerHTML = "युनिट ";


        document.getElementById("lblCast").innerHTML = "जाति  ";
        document.getElementById("lblGender").innerHTML = "लिंग  ";
        document.getElementById("lblFarmerType").innerHTML = "केटेगरी ";

        document.getElementById("lbltrainingrefno").innerHTML = "प्रशिक्षण नंबर";
        document.getElementById("lblworkplannumber").innerHTML = "कार्ययोजना नंबर";
        document.getElementById("btnadd").value = "वाउचर जोडें";
        document.getElementById("spangrassamt").innerHTML = " कुल राशि";
        document.getElementById("lblChecqueN").innerHTML = "चेक/डीडी/यूटीआर नंबर";
        //=============Hindi Font InCrease============//
        document.getElementById("lblGeneralIMT").className = "Frm_Txt_Hindi";
        document.getElementById("lblOtherIMT").className = "Frm_Txt_Hindi";
        document.getElementById("spanddldetails").className = "Frm_Txt_Hindi";
        //document.getElementById("spanagencyname").className = "Frm_Txt_Hindi";
        document.getElementById("lblfundtransferby").className = "Frm_Txt_Hindi";
        document.getElementById("lblmaterial").className = "Frm_Txt_Hindi";
        document.getElementById("lblunit").className = "Frm_Txt_Hindi";
        document.getElementById("lblFarmerType").className = "Frm_Txt_Hindi";
        document.getElementById("lblCast").className = "Frm_Txt_Hindi";
        document.getElementById("lblGender").className = "Frm_Txt_Hindi";
        document.getElementById("lbltrainingrefno").className = "Frm_Txt_Hindi";
        document.getElementById("lblworkplannumber").className = "Frm_Txt_Hindi";
        document.getElementById("btnadd").className = "btn_Hindi";
        document.getElementById("spangrassamt").className = "Frm_Txt_Hindi";
        document.getElementById("lblChecqueN").className = "Frm_Txt_Hindi";

        document.getElementById("lblDateText").innerHTML = "टिप: दिनांक (दिन/माह/वर्ष)फारमेट में डालें,दिनांक चुनने के लिये कैलेन्डर भी है |";
        //document.getElementById("lblBudget").innerHTML = "बजट";
        document.getElementById("lblAmountinRs").innerHTML = "राशि रूपयों में  -:";
        // document.getElementById("lblComponent").innerHTML = "कम्पोनेन्ट एवं हेड";

        document.getElementById("lblFileUpload").innerHTML = "अपलोड फाइल";
        document.getElementById("lblAllowFileFormatMsg").innerHTML = "केवल (.jpg/.jpeg/.png/.gif/.pdf)"
        //        document.getElementById("lblParticulars").innerHTML = "विवरण";
        //        document.getElementById("lblCashExp").innerHTML = "रोकड़";
        //        document.getElementById("lblBankExp").innerHTML = "बैंक";
        //=============Hindi Font InCrease============//
        //document.getElementById("lblBudget").className = "Frm_Txt_Hindi";
        //        document.getElementById("lblParticulars").className = "Frm_Txt_Hindi";
        //        document.getElementById("lblCashExp").className = "Frm_Txt_Hindi";
        //        document.getElementById("lblBankExp").className = "Frm_Txt_Hindi";
        document.getElementById("lblDateText").className = "Frm_Txt_Hindi";
        document.getElementById("lblComponent").className = "Frm_Txt_Hindi";
        document.getElementById("lblAmountinRs").className = "Frm_Txt_Hindi";

        document.getElementById("lblFileUpload").className = "Frm_Txt_Hindi";
        document.getElementById("lblAllowFileFormatMsg").className = "Frm_Txt_Hindi";

        document.getElementById("lblDoYouWant").innerHTML = "क्या आप प्रिंट करना चाहते है";
        document.getElementById("btnPrint").value = "हाँ";
        document.getElementById("btnDontPring").value = "नहीं";
        //=============Hindi Font InCrease============//
        document.getElementById("lblDoYouWant").className = "Frm_Txt_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnDontPring").className = "btn_Hindi";

    }
    //Form ID 81, Form Name:eCashBook/eCashBookTemplate.aspx
    if (Choice == 0 && FormId == 81) {
        document.getElementById("LblHeader").innerHTML = "वाउचर टेमप्लेट";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("lblTemplateName").innerHTML = "टेमप्लेट का नाम";
        document.getElementById("lblHtemplate").innerHTML = "टेमप्लेट का नाम(हिन्दी)";
        document.getElementById("LblScheme").innerHTML = "स्कीम";
        document.getElementById("chkWithAgency").nextSibling.innerHTML = "ऐजेंसी के साथ";
        document.getElementById("chkShowStatus").nextSibling.innerHTML = "सभी शाखायें";
        document.getElementById("BtnGo").value = "आगे जाईये";
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("lblLedger").innerHTML = "कम्पोनेन्ट एवं हेड";
        document.getElementById("BtnSaveMain").value = "रक्षित करें";
        document.getElementById("lblNarration").innerHTML = "विवरण";
        document.getElementById("lblAgencyTypeAllBranch").innerHTML = "ऐजेंसी का प्रकार";
        //=============Hindi Font InCrease============//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblTemplateName").className = "Frm_Txt_Hindi";
        document.getElementById("lblHtemplate").className = "Frm_Txt_Hindi";
        document.getElementById("LblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("chkWithAgency").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("chkShowStatus").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("BtnGo").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("lblLedger").className = "Frm_Txt_Hindi";
        document.getElementById("BtnSaveMain").className = "btn_Hindi";
        document.getElementById("lblNarration").className = "Frm_Txt_Hindi";
        document.getElementById("lblAgencyTypeAllBranch").className = "Frm_Txt_Hindi";


        // New,Edit Radio button code
        var RBNew = document.getElementById("rbNew");
        var RB = RBNew.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "नया टेमप्लेट बनाऐं";
        RB[0].className = "Frm_Txt_Hindi";

        var RBEdit = document.getElementById("rbEdit");
        var RB = RBEdit.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "टेमप्लेट सुधारें";
        RB[0].className = "Frm_Txt_Hindi";

        document.getElementById("lblTemplateName1").innerHTML = "टेमप्लेट का नाम चुनें";
        document.getElementById("lblTemplateName1").className = "Frm_Txt_Hindi";
    }
    //Form ID 199, Form Name:Master_Pages/frm_agencyopening_import.aspx
    if (Choice == 0 && FormId == 199) {
        document.getElementById("LblHeader").innerHTML = "एजेंसी का प्रारंभिक शेष आयात";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        // Lebel code//
        document.getElementById("lblScheme").innerHTML = "स्कीम का नाम चुनें";
        document.getElementById("lblLedger").innerHTML = "लेजर का नाम चुनें";
        document.getElementById("lblCategory").innerHTML = "श्रेणी का नाम चुनें";
        document.getElementById("lblAgencyType").innerHTML = "एजेंसी का प्रकार";
        document.getElementById("lblImport").innerHTML = "फाईल आयात करें";
        document.getElementById("btncancel").value = "रद्द करें";
        document.getElementById("btnSave").value = "रक्षित करें";
        //font increase ===//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("lblLedger").className = "Frm_Txt_Hindi";
        document.getElementById("lblCategory").className = "Frm_Txt_Hindi";
        document.getElementById("lblAgencyType").className = "Frm_Txt_Hindi";
        document.getElementById("lblImport").className = "Frm_Txt_Hindi";
        document.getElementById("btncancel").className = "btn_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";

        // Agency Radio button code
        var RBHindi = document.getElementById("rbagencywise");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "एजेंसी नाम वाँइस";
        RB[0].className = "Frm_Txt_Hindi";

        var RBenglish = document.getElementById("rbUserCodewise");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "यूजर कोड वाँइस";
        RB[0].className = "Frm_Txt_Hindi";

        document.getElementById("lblLine1").innerHTML = "एक्सेल शीट में क्रमशः  : - यह काँलम होने चाहिये । ";
        document.getElementById("Label1").innerHTML = "नोट : - एक्सेल की पहली पंक्ति हेडर होनी चाहिये और एक्सेल शीट 2003 और 2007 फोरमेट में बनाए । ";


        // Grid Code Start
        var table = document.getElementById("gvImport");
        var tr = table.rows[0];
        tr.cells[1].innerHTML = "एजेंसी का नाम";
        tr.cells[2].innerHTML = "यूजर कोड";
        tr.cells[3].innerHTML = "डेविट राशि";
        tr.cells[4].innerHTML = "क्रेडिट राशि";
        //font increase ===//
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
    }
    //Form ID 193, Form Name:Master_Pages/frm_ChequeBook.aspx
    if (Choice == 0 && FormId == 193) {
        document.getElementById("LblHeader").innerHTML = "रजिस्टर चैक बुक";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        // Lebel code//
        document.getElementById("btnNew").value = "नया";
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btnView").value = "देखें";
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("btnExit").value = "बाहर निकलें";
        document.getElementById("lblBankAccount").innerHTML = "बैंक खाता";
        document.getElementById("lblChequeBookNo").innerHTML = "चैक बुक नंबर";
        document.getElementById("lblChequeNumber").innerHTML = "चैक नंबर";
        document.getElementById("lblFrom").innerHTML = "से";
        document.getElementById("lblTo").innerHTML = "तक";
        //========== Hindi Increase code =========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnView").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("btnExit").className = "btn_Hindi";
        document.getElementById("lblBankAccount").className = "Frm_Txt_Hindi";
        document.getElementById("lblChequeBookNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblChequeNumber").className = "Frm_Txt_Hindi";
        document.getElementById("lblFrom").className = "Frm_Txt_Hindi";
        document.getElementById("lblTo").className = "Frm_Txt_Hindi";
    }
    //Form ID 2210, Form Name:Finance/rpt_AgeWise_AdvanceAnalysis.aspx
    if (Choice == 0 && FormId == 2210) {
        document.getElementById("LblHeader").innerHTML = "आयु अनुसार अग्रिम की गणना";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        // AgencyWise Radio button code
        var AgencyWise = document.getElementById("rbAgencyWise");
        var RB = AgencyWise.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " एजेंसी वॉइस";
        RB[0].className = "Frm_Txt_Hindi";

        var SchemeWise = document.getElementById("rbSchemeWise");
        var RB = SchemeWise.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " स्कीम वॉइस";
        RB[0].className = "Frm_Txt_Hindi";

        document.getElementById("lblAsonDate").innerHTML = "दिनांक से";
        document.getElementById("lblDD").innerHTML = "(दिन/माह/वर्ष)";
        document.getElementById("lblStatus").innerHTML = "स्टेटस चुनिये";
        document.getElementById("lblLedger").innerHTML = "लेजर चुनिये";
        document.getElementById("lblAge").innerHTML = "आयु चुनिये";
        document.getElementById("lblAgencyType").innerHTML = "एजेंसी का प्रकार चुनिये";
        document.getElementById("lblAgencyName").innerHTML = "एजेंसी का नाम चुनिये";
        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";
        //=======Hindi Text ============//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblAsonDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblDD").className = "Frm_Txt_Hindi";
        document.getElementById("lblStatus").className = "Frm_Txt_Hindi";
        document.getElementById("lblLedger").className = "Frm_Txt_Hindi";
        document.getElementById("lblAge").className = "Frm_Txt_Hindi";
        document.getElementById("lblAgencyType").className = "Frm_Txt_Hindi";
        document.getElementById("lblAgencyName").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        // Default and Branch Radio button code
        var Default = document.getElementById("rbDefault");
        var RB = Default.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " डिफॉल्ट शाखा कोड";
        RB[0].className = "Frm_Txt_Hindi";

        var custom = document.getElementById("rbcustom");
        var RB = custom.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " कस्टम शाखा कोड";
        RB[0].className = "Frm_Txt_Hindi";

        // Detail/ Radio button code
        var Detail = document.getElementById("rbDetail");
        var RB = Detail.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " विस्तार रिपोर्ट";
        RB[0].className = "Frm_Txt_Hindi";

        var Summary = document.getElementById("rbSummary");
        var RB = Summary.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " संक्षिप्त रिपोर्ट";
        RB[0].className = "Frm_Txt_Hindi";

        // Scheme button code
        var FCRA = document.getElementById("rbFCRA");
        var RB = FCRA.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " एफ सी आर ए ";
        RB[0].className = "Frm_Txt_Hindi";

        var NonFCRA = document.getElementById("rbNonFCRA");
        var RB = NonFCRA.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " नाँन एफ सी आर ए";
        RB[0].className = "Frm_Txt_Hindi";

        var Both = document.getElementById("rbBoth");
        var RB = Both.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " दोनों";
        RB[0].className = "Frm_Txt_Hindi";

        if (document.getElementById("rbcustom").checked == true) {
            document.getElementById("btnGo").value = "देखें";
            document.getElementById("lblPanchayatCode").innerHTML = "पंचायत कोड";
            document.getElementById("lbFindBranchCode").innerHTML = "शाखा कोड देखें";
            // Hindi Size Increase code
            document.getElementById("btnGo").className = "btn_Hindi";
            document.getElementById("lblPanchayatCode").className = "Frm_Txt_Hindi";
        }
    }
    //Form ID 189, Form Name:rpt_Annexure(VIII).aspx
    if (Choice == 0 && FormId == 189) {
        document.getElementById("LblHeader").innerHTML = "परिशिष्ट (आठवीं)";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var Annexure = document.getElementById("rbenglish");
        var AR = Annexure.parentNode.getElementsByTagName("label");
        AR[0].innerHTML = "English";
        // Lebel code//
        document.getElementById("lblPreiod").innerHTML = "अवधि";
        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        // Hindi Increase code//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblPreiod").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";

        // RadioButtonList button code
        var RBHindi = document.getElementById("AnnexureRadioButtonList");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "1st तिमाही";
        RB[1].innerHTML = "2nd तिमाही";
        RB[2].innerHTML = "3rd तिमाही";
        RB[3].innerHTML = "4th तिमाही";
        RB[4].innerHTML = "पूर्ण वर्ष";
        // RadioButtonList Hindicode
        RB[0].className = "Frm_Txt_Hindi";
        RB[1].className = "Frm_Txt_Hindi";
        RB[2].className = "Frm_Txt_Hindi";
        RB[3].className = "Frm_Txt_Hindi";
        RB[4].className = "Frm_Txt_Hindi";
    }
    //Form ID 190, Form Name:rpt_Annexure(XI).aspx
    if (Choice == 0 && FormId == 190) {
        document.getElementById("LblHeader").innerHTML = "परिशिष्ट (ग्यारहवीं)";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var Annexure = document.getElementById("rbenglish");
        var AR = Annexure.parentNode.getElementsByTagName("label");
        AR[0].innerHTML = "English";

        var FCRA = document.getElementById("rbFCRA");
        var RB = FCRA.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " एफ सी आर ए ";
        RB[0].className = "Frm_Txt_Hindi";

        var NonFCRA = document.getElementById("rbNonFCRA");
        var RB = NonFCRA.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " नाँन एफ सी आर ए";
        RB[0].className = "Frm_Txt_Hindi";

        var Both = document.getElementById("rbBoth");
        var RB = Both.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " दोनों";
        RB[0].className = "Frm_Txt_Hindi";

        // Lebel code//
        document.getElementById("lblPreiod").innerHTML = "अवधि";
        document.getElementById("lblScheme").innerHTML = "स्कीम";
        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        // Hindi Increase code//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblPreiod").className = "Frm_Txt_Hindi";
        document.getElementById("lblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";

        // RadioButtonList button code
        var RBHindi = document.getElementById("AnnexureRadioButtonList");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "1st तिमाही";
        RB[1].innerHTML = "2nd तिमाही";
        RB[2].innerHTML = "3rd तिमाही";
        RB[3].innerHTML = "4th तिमाही";
        RB[4].innerHTML = "पूर्ण वर्ष";
        // RadioButtonList Hindicode
        RB[0].className = "Frm_Txt_Hindi";
        RB[1].className = "Frm_Txt_Hindi";
        RB[2].className = "Frm_Txt_Hindi";
        RB[3].className = "Frm_Txt_Hindi";
        RB[4].className = "Frm_Txt_Hindi";
    }
    //Form ID 191, Form Name:rpt_Annexure(XII).aspx
    if (Choice == 0 && FormId == 191) {
        document.getElementById("LblHeader").innerHTML = "परिशिष्ट (बारहवीं)";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var Annexure = document.getElementById("rbenglish");
        var AR = Annexure.parentNode.getElementsByTagName("label");
        AR[0].innerHTML = "English";

        var FCRA = document.getElementById("rbFCRA");
        var RB = FCRA.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " एफ सी आर ए ";
        RB[0].className = "Frm_Txt_Hindi";

        var NonFCRA = document.getElementById("rbNonFCRA");
        var RB = NonFCRA.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " नाँन एफ सी आर ए";
        RB[0].className = "Frm_Txt_Hindi";

        var Both = document.getElementById("rbBoth");
        var RB = Both.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " दोनों";
        RB[0].className = "Frm_Txt_Hindi";

        // Lebel code//
        document.getElementById("lblPreiod").innerHTML = "अवधि";
        document.getElementById("lblScheme").innerHTML = "स्कीम";
        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        // Hindi Increase code//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblPreiod").className = "Frm_Txt_Hindi";
        document.getElementById("lblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";

        // RadioButtonList button code
        var RBHindi = document.getElementById("AnnexureRadioButtonList");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "1st तिमाही";
        RB[1].innerHTML = "2nd तिमाही";
        RB[2].innerHTML = "3rd तिमाही";
        RB[3].innerHTML = "4th तिमाही";
        RB[4].innerHTML = "पूर्ण वर्ष";
        // RadioButtonList Hindicode
        RB[0].className = "Frm_Txt_Hindi";
        RB[1].className = "Frm_Txt_Hindi";
        RB[2].className = "Frm_Txt_Hindi";
        RB[3].className = "Frm_Txt_Hindi";
        RB[4].className = "Frm_Txt_Hindi";
    }
    //Form ID 185, Form Name:ManagementReports/SponsorReport.aspx
    if (Choice == 0 && FormId == 185) {
        document.getElementById("lblsponsorreport").innerHTML = "प्रायोजक रिपोर्ट";
        document.getElementById("hlkhome").innerHTML = "होमपेज";
        document.getElementById("hlklogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        // Lebel code//
        document.getElementById("lblfromdate").innerHTML = "तिथि से";
        document.getElementById("lbltodate").innerHTML = "तिथि तक";
        document.getElementById("lblselectagency").innerHTML = "एजेन्सी चुनें";
        document.getElementById("lblLedger").innerHTML = "लेजर";
        document.getElementById("btnOK").value = "दिखाएँ";
        document.getElementById("btnprint").value = "प्रिंट करें";
        //font increase ===//
        document.getElementById("lblsponsorreport").className = "Frm_Head_Hindi";
        document.getElementById("lblfromdate").className = "Frm_Txt_Hindi";
        document.getElementById("lbltodate").className = "Frm_Txt_Hindi";
        document.getElementById("lblselectagency").className = "Frm_Txt_Hindi";
        document.getElementById("lblLedger").className = "Frm_Txt_Hindi";
        document.getElementById("btnOK").className = "btn_Hindi";
        document.getElementById("btnprint").className = "btn_Hindi";
    }
    //Form ID 186, Form Name:FinancialReports/rpt_Ledger.aspx
    if (Choice == 0 && FormId == 186) {
        document.getElementById("LblHeader").innerHTML = "लेजर रिपोर्ट";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        // Lebel code//
        document.getElementById("ChkAll").nextSibling.innerHTML = " सभी चुनें";
        document.getElementById("lblLedger").innerHTML = "लेजर का नाम";
        document.getElementById("LblFromDt").innerHTML = "तिथि से";
        document.getElementById("LblToDt").innerHTML = "तिथि तक";
        document.getElementById("BtnShow").value = "रिपोर्ट देखें";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("BtnExit").value = "बाहर निकलें";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";
        //        document.getElementById("btncheckAll").value = "सभी चुनें ";
        //        document.getElementById("btnUncheckAll").value = "सभी हटाये ";
        document.getElementById("ChkMonthly").nextSibling.innerHTML = "मासिक";
        document.getElementById("ChkOtherAgency").nextSibling.innerHTML = "विवरण";
        document.getElementById("lblFromDtFormat").innerHTML = "दिन / माह / वर्ष";
        document.getElementById("LblToDtFormat").innerHTML = "दिन / माह / वर्ष";
        //font increase ===//
        document.getElementById("ChkAll").className = "btn_Hindi";
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblLedger").className = "Frm_Txt_Hindi";
        document.getElementById("LblFromDt").className = "Frm_Txt_Hindi";
        document.getElementById("LblToDt").className = "Frm_Txt_Hindi";
        document.getElementById("BtnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("BtnExit").className = "btn_Hindi";
        document.getElementById("ChkMonthly").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("ChkOtherAgency").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("lblFromDtFormat").className = "Frm_Txt_Hindi";
        document.getElementById("LblToDtFormat").className = "Frm_Txt_Hindi";

        var WithCategory = document.getElementById("rbWithCategory");
        var RB = WithCategory.parentNode.getElementsByTagName("label");
        //RB[0].innerHTML = "श्रेणी सहित";
        RB[0].innerHTML = "घटक सहित";
        RB[0].className = "Frm_Txt_Hindi";

        var rbWithoutCategory = document.getElementById("rbWithoutCategory");
        var RB = rbWithoutCategory.parentNode.getElementsByTagName("label");
        //RB[0].innerHTML = "श्रेणी रहित";
        RB[0].innerHTML = "घटक रहित";
        RB[0].className = "Frm_Txt_Hindi";
    }
    //Form ID 181, Form Name:Master_Pages/rpt_DayBook.aspx
    if (Choice == 0 && FormId == 181) {
        document.getElementById("LblHeader").innerHTML = "डे - बुक रिपोर्ट";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";


        var RBDetail = document.getElementById("rbDetail");
        var RB1 = RBDetail.parentNode.getElementsByTagName("label");
        RB1[0].innerHTML = "विवरण रिपोर्ट  ";
        var RbSummary = document.getElementById("rbSummary");
        var RB = RbSummary.parentNode.getElementsByTagName("label");
        RB[1].innerHTML = "संक्षिप्त रिपोर्ट  ";


        //        // Lebel code//
        document.getElementById("ChkAll").nextSibling.innerHTML = " सभी चुनें";
        document.getElementById("lblFdate").innerHTML = "दिनांक से";
        document.getElementById("lblTodate").innerHTML = "दिनांक तक";
        document.getElementById("lblVoucherType").innerHTML = "वाउचर का प्रकार चुनें";
        // document.getElementById("lblScheme").innerHTML = "स्कीम चुनें";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";
        //        document.getElementById("btncheckAll").value = "सभी चुनें";
        //        document.getElementById("btnUncheckAll").value = "सभी हटायें";
        document.getElementById("btnShow").value = "रिपोर्ट देखें";
        document.getElementById("btnPrint").value = "प्रिंट";
        document.getElementById("btnPrintVoucher").value = "प्रिंट वाउचर ";
        document.getElementById("btnForward").value = "भेजें  ";
        document.getElementById("btnforward_dvsubmit_pass_forward").value = "भेजें";
        document.getElementById('btnok').value = 'प्रिंट करै'

        document.getElementById("lblaction").innerHTML = "प्रतिक्रिया ";
        document.getElementById('btnForwardOk').value = 'ओके'
        document.getElementById('btnForwardCancel').value = 'रद्द करें'
        // document.getElementById('lblSaveMsg').innerHTML = 'क्या आप वाउचर रक्षित करना चाहते  है ?'
        document.getElementById('lblForwardDesignation').innerHTML = 'अग्रेषित पद'
        document.getElementById('lblForwardedEmp').innerHTML = 'अग्रेषित कर्मचारी'
        //============Hindi Font Increase============//
        document.getElementById("ChkAll").className = "btn_Hindi";
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblFdate").className = "Frm_Txt_Hindi";
        document.getElementById("ddlVoucherType").className = "ddl_Hindi";
        document.getElementById("lblVoucherType").className = "Frm_Txt_Hindi";
        document.getElementById("lblTodate").className = "Frm_Txt_Hindi";
        document.getElementById("lblScheme").className = "Frm_Txt_Hindi";
        //        document.getElementById("btncheckAll").className = "btn_Hindi";
        //        document.getElementById("btnUncheckAll").className = "btn_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnForward").className = "btn_Hindi";
        

       


        document.getElementById('btnForwardOk').className = "btn_Hindi";
        document.getElementById('btnForwardCancel').className = "btn_Hindi";
        //document.getElementById('lblSaveMsg').className = "Frm_Txt_Hindi";
        document.getElementById('lblForwardDesignation').className = "Frm_Txt_Hindi";
        document.getElementById('lblForwardedEmp').className = "Frm_Txt_Hindi";

        //Radio button code
        var FCRA = document.getElementById("rbFCRA");
        var RB = FCRA.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " एफ सी आर ए ";

        var NonFCRA = document.getElementById("rbNonFCRA");
        var RB = NonFCRA.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " नाँन एफ सी आर ए";

        var Both = document.getElementById("rbBoth");
        var RB = Both.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " दोनों";
    }
    //Form ID 173, Form Name:reports/yojnareports/rpt_paymentregister.aspx
    if (Choice == 0 && FormId == 173) {
        document.getElementById("LblHeader").innerHTML = "पार्टी / एजेंसी रजिस्टर रिपोर्ट";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("lblFromDate").innerHTML = "दिनांक से";
        document.getElementById("lblToDate").innerHTML = "दिनांक तक ";
        //document.getElementById("lblScheme").innerHTML = "स्कीम";
        document.getElementById("lblLedger").innerHTML = "लेजर";
        document.getElementById("lblAgencyType").innerHTML = "ऐजेंसी का प्रकार";
        //        document.getElementById("lblState").innerHTML = "राज्य";
        //        document.getElementById("lblDistrict").innerHTML = "जिला";
        //        document.getElementById("lblJanpadPanchayat").innerHTML = "जनपद पंचायत";
        //        document.getElementById("lblGramPanchayat").innerHTML = "ग्राम पंचायत";
        document.getElementById("lblAgencyName").innerHTML = "ऐजेंसी का नाम";
        document.getElementById("chkMonthly").nextSibling.innerHTML = " मासिक";
        //        document.getElementById("chkCategory").nextSibling.innerHTML = " श्रेणी";
        document.getElementById("chkCategory").nextSibling.innerHTML = " घटक";
        document.getElementById("chkCapital").nextSibling.innerHTML = "केपिटल";
        document.getElementById("chkRevenue").nextSibling.innerHTML = "रिवेन्यू";
        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";
        //=========Hindi Text===========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblFromDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblToDate").className = "Frm_Txt_Hindi";
        // document.getElementById("lblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("lblLedger").className = "Frm_Txt_Hindi";
        document.getElementById("lblAgencyType").className = "Frm_Txt_Hindi";
        document.getElementById("lblState").className = "Frm_Txt_Hindi";
        document.getElementById("lblDistrict").className = "Frm_Txt_Hindi";
        document.getElementById("lblJanpadPanchayat").className = "Frm_Txt_Hindi";
        document.getElementById("lblGramPanchayat").className = "Frm_Txt_Hindi";
        document.getElementById("lblAgencyName").className = "Frm_Txt_Hindi";
        document.getElementById("chkMonthly").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("chkCategory").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("chkCapital").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("chkRevenue").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";

        //Radio Button Code Start
        var schemewise = document.getElementById("rbschemewise");
        var RB = schemewise.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " स्कीम वाँइस ";
        RB[0].className = "Frm_Txt_Hindi";

        var agencywise = document.getElementById("rbagencywise");
        var RB = agencywise.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " ऐजेंसी वाँइस";
        RB[0].className = "Frm_Txt_Hindi";

        var FCRA = document.getElementById("rbFCRA");
        var RB = FCRA.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " एफ सी आर ए ";
        RB[0].className = "adverties_txt";

        var NonFCRA = document.getElementById("rbNonFCRA");
        var RB = NonFCRA.parentNode.getElementsByTagName("label");
        RB[1].innerHTML = " नाँन एफ सी आर ए";
        RB[1].className = "adverties_txt";

        var Both = document.getElementById("rbBoth");
        var RB = Both.parentNode.getElementsByTagName("label");
        RB[2].innerHTML = " दोनों";
        RB[2].className = "adverties_txt";
        if (document.getElementById("lblaction") != null) {
            document.getElementById("lblaction").className = "Frm_Txt_Hindi";
        }

    }
    //Form ID 174, Form Name:reports/yojnareports/rpt_PaymentSummary.aspx
    if (Choice == 0 && FormId == 174) {
        document.getElementById("LblHeader").innerHTML = "पार्टी / एजेंसी संक्षिप्त रिपोर्ट";
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

        document.getElementById("lblFromDate").innerHTML = "दिनांक से";
        document.getElementById("lblToDate").innerHTML = "दिनांक तक ";
        //document.getElementById("lblScheme").innerHTML = "स्कीम";
        document.getElementById("lblLedger").innerHTML = "लेजर";
        document.getElementById("lblAgencyType").innerHTML = "ऐजेंसी का प्रकार";
        //        document.getElementById("lblState").innerHTML = "राज्य";
        //        document.getElementById("lblDistrict").innerHTML = "जिला";
        //        document.getElementById("lblJanpadPanchayat").innerHTML = "जनपद पंचायत";
        //        document.getElementById("lblGramPanchayat").innerHTML = "ग्राम पंचायत";
        document.getElementById("lblAgencyName").innerHTML = "ऐजेंसी का नाम";
        document.getElementById("chkMonthly").nextSibling.innerHTML = " मासिक";
        //        document.getElementById("chkCategory").nextSibling.innerHTML = " केटेगरी";
        document.getElementById("chkCategory").nextSibling.innerHTML = " घटक";
        document.getElementById("chkCapital").nextSibling.innerHTML = " केपिटल ";
        document.getElementById("chkRevenue").nextSibling.innerHTML = "रिवेन्यू ";
        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";
        //=========Hindi Text===========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblFromDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblToDate").className = "Frm_Txt_Hindi";
        //document.getElementById("lblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("lblLedger").className = "Frm_Txt_Hindi";
        document.getElementById("lblAgencyType").className = "Frm_Txt_Hindi";
        document.getElementById("lblState").className = "Frm_Txt_Hindi";
        document.getElementById("lblDistrict").className = "Frm_Txt_Hindi";
        document.getElementById("lblJanpadPanchayat").className = "Frm_Txt_Hindi";
        document.getElementById("lblGramPanchayat").className = "Frm_Txt_Hindi";
        document.getElementById("lblAgencyName").className = "Frm_Txt_Hindi";
        document.getElementById("chkMonthly").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("chkCategory").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";

        //Radio Button Code Start
        var schemewise = document.getElementById("rbschemewise");
        var RB = schemewise.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " स्कीम वाँइस ";
        RB[0].className = "Frm_Txt_Hindi";


        var schemewise = document.getElementById("rbagencywise");
        var RB = schemewise.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "एजेंसी वाँइस ";
        RB[0].className = "Frm_Txt_Hindi";

        var FCRA = document.getElementById("rbFCRA");
        var RB = FCRA.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " एफ सी आर ए ";
        RB[0].className = "adverties_txt";

        var NonFCRA = document.getElementById("rbNonFCRA");
        var RB = NonFCRA.parentNode.getElementsByTagName("label");
        RB[1].innerHTML = " नाँन एफ सी आर ए";
        RB[1].className = "adverties_txt";

        var Both = document.getElementById("rbBoth");
        var RB = Both.parentNode.getElementsByTagName("label");
        RB[2].innerHTML = " दोनों";
        RB[2].className = "adverties_txt";
    }
    //Form ID 91, Form Name:RecieptPaymentAccount.aspx
    if (Choice == 0 && FormId == 91) {
        document.getElementById("LblHeader").innerHTML = "प्राप्ति एंव भुगतान खाता";
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
        if (document.getElementById("LblScheme") != null) {
            document.getElementById("LblScheme").innerHTML = "स्कीम चुने";
        }

        document.getElementById("lblFdate").innerHTML = "दिनांक से";
        document.getElementById("lblToDate").innerHTML = "दिनांक तक";
        document.getElementById("ChkAll").nextSibling.innerHTML = " सभी चुनें";
        //        document.getElementById("lblSchemeName").innerHTML = "स्कीम का नाम";
        document.getElementById("BtnTrialBalance").value = "रिपोर्ट देखें";
        document.getElementById("BtnExit").value = "बंद करे";
        
        //        document.getElementById("btncheckAll").value = "सभी चुनें";
        //        document.getElementById("btnUncheckAll").value = "सभी हटायें";


        document.getElementById("LblSchemeOption").innerHTML = "स्कीम विकल्प";
        //=======Hindi Text ============//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("LblReportOp").className = "Frm_Txt_Hindi";
        if (document.getElementById("LblScheme") != null) {
            document.getElementById("LblScheme").className = "Frm_Txt_Hindi";
        }

        document.getElementById("lblFdate").className = "Frm_Txt_Hindi";
        document.getElementById("lblToDate").className = "Frm_Txt_Hindi";
        document.getElementById("BtnTrialBalance").className = "btn_Hindi";
        document.getElementById("BtnExit").className = "btn_Hindi";
        //        document.getElementById("LblSchemeOption").className = "Frm_Txt_Hindi";
        if (document.getElementById("DrpScheme") != null) {
            document.getElementById("DrpScheme").className = "ddl_Hindi";
        }

        //        // Default and Branch Radio button code
        //        var Default = document.getElementById("rbDefault");
        //        var RB = Default.parentNode.getElementsByTagName("label");
        //        RB[0].innerHTML = " डिफ़ाँल्ट शाखा कोड";
        //        RB[0].className = "Frm_Txt_Hindi";

        //        var custom = document.getElementById("rbcustom");
        //        var RB = custom.parentNode.getElementsByTagName("label");
        //        RB[1].innerHTML = " कस्टम शाखा कोड";
        //        RB[1].className = "Frm_Txt_Hindi";
        //=======Report Text ============//
        var Action = document.getElementById("RBLReport");
        var rbAction = Action.parentNode.getElementsByTagName("label");
        rbAction[0].innerHTML = " ग्रुप";
        //rbAction[1].innerHTML = " श्रेणी";
        rbAction[1].innerHTML = " घटक";
        rbAction[2].innerHTML = " बजट (घटक)";
        rbAction[0].className = "Frm_Txt_Hindi";
        rbAction[1].className = "Frm_Txt_Hindi";
        rbAction[2].className = "Frm_Txt_Hindi";

        // Scheme button code
        var FCRA = document.getElementById("RBLScheme");
        var RB = FCRA.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " एफ सी आर ए";
        RB[1].innerHTML = " नाँन एफ सी आर ए";
        RB[2].innerHTML = " दोनों";
        RB[0].className = "Frm_Txt_Hindi";
        RB[1].className = "Frm_Txt_Hindi";
        RB[2].className = "Frm_Txt_Hindi";

    }
    //Form ID 92, Form Name:IncomeExpAccount.aspx
    if (Choice == 0 && FormId == 92) {
        //document.getElementById("LblHeader").innerHTML = "लाभ एवं हानि रिपोर्ट ";
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
        //        document.getElementById("LblScheme").innerHTML = "स्कीम चुनें";
        document.getElementById("ChkAll").nextSibling.innerHTML = "सभी चुने";
        document.getElementById("LblFromDt").innerHTML = "दिनांक से";
        document.getElementById("Label1").innerHTML = "(दिन/माह/वर्ष)";
        document.getElementById("LblToDt").innerHTML = "दिनांक तक";
        document.getElementById("Label2").innerHTML = "(दिन/माह/वर्ष)";
        document.getElementById("BtnTrialBalance").value = "रिपोर्ट देखें";
        document.getElementById("BtnExit").value = "बंद करे";
        // document.getElementById("btncheckAll").value = "सभी चुनें";
        // document.getElementById("btnUncheckAll").value = "सभी हटायें";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";

        document.getElementById("LblSchemeOption").innerHTML = "स्कीम विकल्प";
        //=======Hindi Text ============//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("LblReportOp").className = "Frm_Txt_Hindi";
        //        document.getElementById("LblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("ChkAll").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("LblFromDt").className = "Frm_Txt_Hindi";
        document.getElementById("Label1").className = "Frm_Txt_Hindi";
        document.getElementById("LblToDt").className = "Frm_Txt_Hindi";
        document.getElementById("Label2").className = "Frm_Txt_Hindi";
        document.getElementById("BtnTrialBalance").className = "btn_Hindi";
        document.getElementById("BtnExit").className = "btn_Hindi";
        document.getElementById("LblSchemeOption").className = "Frm_Txt_Hindi";
        if (document.getElementById("DrpScheme") != null) {
            document.getElementById("DrpScheme").className = "ddl_Hindi";
        }
        // document.getElementById("btncheckAll").className = "btn_Hindi";
        //  document.getElementById("btnUncheckAll").className = "btn_Hindi";
        // Default and Branch Radio button code
        //        var Default = document.getElementById("rbDefault");
        //        var RB = Default.parentNode.getElementsByTagName("label");
        //        RB[0].innerHTML = " डिफ़ाँल्ट शाखा कोड";
        //        RB[0].className = "Frm_Txt_Hindi";

        //        var custom = document.getElementById("rbcustom");
        //        var RB = custom.parentNode.getElementsByTagName("label");
        //        RB[0].innerHTML = " कस्टम शाखा कोड";
        //        RB[0].className = "Frm_Txt_Hindi";
        //=======Report Text ============//
        var Action = document.getElementById("RBLReport");
        var rbAction = Action.parentNode.getElementsByTagName("label");
        rbAction[0].innerHTML = " ग्रुप";
        //rbAction[1].innerHTML = " श्रेणी";
        rbAction[1].innerHTML = " घटक";
        rbAction[2].innerHTML = " बजट (घटक)";
        rbAction[0].className = "Frm_Txt_Hindi";
        rbAction[1].className = "Frm_Txt_Hindi";
        rbAction[2].className = "Frm_Txt_Hindi";

        // Scheme button code
        var FCRA = document.getElementById("RBLScheme");
        var RB = FCRA.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " एफ सी आर ए";
        RB[1].innerHTML = " नाँन एफ सी आर ए";
        RB[2].innerHTML = " दोनों";
        RB[0].className = "Frm_Txt_Hindi";
        RB[1].className = "Frm_Txt_Hindi";
        RB[2].className = "Frm_Txt_Hindi";
        //        if (document.getElementById("rbcustom").checked == true) {
        //            document.getElementById("btnGo").value = "देखें";
        //            document.getElementById("lblPanchayatCode").innerHTML = "पंचायत कोड";
        //            document.getElementById("lbFindBranchCode").innerHTML = "शाखा कोड देखें";
        //            // Fint Size Increase code
        //            document.getElementById("btnGo").className = "btn_Hindi";
        //            document.getElementById("lblPanchayatCode").className = "Frm_Txt_Hindi";
        //        }
        var Default = document.getElementById("RbWithBranch");
        var RB = Default.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " उप शाखा सहित";
        RB[0].className = "Frm_Txt_Hindi";

        var custom = document.getElementById("RbWithoutBranch");
        var RB = custom.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " उप शाखा रहित";
        RB[0].className = "Frm_Txt_Hindi";
    }
    //Form ID 93, Form Name:BalanceSheet.aspx
    if (Choice == 0 && FormId == 93) {
        document.getElementById("LblHeader").innerHTML = "बैलेंस-शीट";
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
        //        document.getElementById("LblScheme").innerHTML = "स्कीम चुनें";
        document.getElementById("ChkAll").nextSibling.innerHTML = "सभी चुने";
        document.getElementById("LblFromDt").innerHTML = "दिनांक से";
        document.getElementById("Label1").innerHTML = "(दिन/माह/वर्ष)";
        document.getElementById("BtnTrialBalance").value = "रिपोर्ट देखें";
        document.getElementById("BtnExit").value = "बंद करे";
        document.getElementById("LblSchemeOption").innerHTML = "स्कीम विकल्प";
        //document.getElementById("btncheckAll").value = "सभी चुनें";
        // document.getElementById("btnUncheckAll").value = "सभी हटायें";
        
        //=======Hindi Text ============//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("LblReportOp").className = "Frm_Txt_Hindi";
        //        document.getElementById("LblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("ChkAll").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("LblFromDt").className = "Frm_Txt_Hindi";
        document.getElementById("Label1").className = "Frm_Txt_Hindi";
        document.getElementById("BtnTrialBalance").className = "btn_Hindi";
        document.getElementById("BtnExit").className = "btn_Hindi";
        document.getElementById("LblSchemeOption").className = "Frm_Txt_Hindi";
        if (document.getElementById("DrpScheme") != null) {
            document.getElementById("DrpScheme").className = "ddl_Hindi";
        }
        //document.getElementById("btncheckAll").className = "btn_Hindi";
        // document.getElementById("btnUncheckAll").className = "btn_Hindi";
        // Default and Branch Radio button code
        //        var Default = document.getElementById("rbDefault");
        //        var RB = Default.parentNode.getElementsByTagName("label");
        //        RB[0].innerHTML = " डिफ़ाँल्ट शाखा कोड";
        //        RB[0].className = "Frm_Txt_Hindi";

        //        var custom = document.getElementById("rbcustom");
        //        var RB = custom.parentNode.getElementsByTagName("label");
        //        RB[1].innerHTML = " कस्टम शाखा कोड";
        //        RB[1].className = "Frm_Txt_Hindi";
        //=======Report Text ============//
        var Action = document.getElementById("RBLReport");
        var rbAction = Action.parentNode.getElementsByTagName("label");
        rbAction[0].innerHTML = " ग्रुप";
        //rbAction[1].innerHTML = " श्रेणी";
        rbAction[1].innerHTML = " घटक";
        rbAction[2].innerHTML = " बजट (घटक)";
        rbAction[0].className = "Frm_Txt_Hindi";
        rbAction[1].className = "Frm_Txt_Hindi";
        rbAction[2].className = "Frm_Txt_Hindi";

        // Scheme button code
        var FCRA = document.getElementById("RBLScheme");
        var RB = FCRA.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " एफ सी आर ए";
        RB[1].innerHTML = " नाँन एफ सी आर ए";
        RB[2].innerHTML = " दोनों";
        RB[0].className = "Frm_Txt_Hindi";
        RB[1].className = "Frm_Txt_Hindi";
        RB[2].className = "Frm_Txt_Hindi";
        //        if (document.getElementById("rbcustom").checked == true) {
        //            document.getElementById("btnGo").value = "देखें";
        //            document.getElementById("lblPanchayatCode").innerHTML = "पंचायत कोड";
        //            document.getElementById("lbFindBranchCode").innerHTML = "शाखा कोड देखें";
        //            // Fint Size Increase code
        //            document.getElementById("btnGo").className = "btn_Hindi";
        //            document.getElementById("lblPanchayatCode").className = "Frm_Txt_Hindi";
        //        }
        var Default = document.getElementById("RbWithBranch");
        var RB = Default.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " उप शाखा सहित";
        RB[0].className = "Frm_Txt_Hindi";

        var custom = document.getElementById("RbWithoutBranch");
        var RB = custom.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " उप शाखा रहित";
        RB[0].className = "Frm_Txt_Hindi";
    }
    //Form ID 86, Form Name:ManagementReports/StaffAdvancesReport.aspx
    if (Choice == 0 && FormId == 86) {
        document.getElementById("LblHeader").innerHTML = "कर्मचारी को अग्रिम";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("LblScheme").innerHTML = "एजेंसी कोड";
        document.getElementById("LblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("showModalPopupServerOperatorButton").value = "एजेंसी खोजें";
        document.getElementById("showModalPopupServerOperatorButton").className = "btn_Hindi";
        document.getElementById("BtnVwReport").value = "रिपोर्ट देखें";
        document.getElementById("BtnVwReport").className = "btn_Hindi";
        document.getElementById("BtnExit").value = "बंद करे";
        document.getElementById("BtnExit").className = "btn_Hindi";
        document.getElementById("LblAgencyT").innerHTML = "एजेंसी टाईप";
        document.getElementById("LblAgencyT").className = "Frm_Txt_Hindi";
        document.getElementById("Label1").innerHTML = "एजेंसी का नाम";
        document.getElementById("Label1").className = "Frm_Txt_Hindi";
        document.getElementById("btnSearch").value = "एजेंसी खोजें";
        document.getElementById("btnSearch").className = "btn_Hindi";
        document.getElementById("lblPanelHeader").innerHTML = "एजेंसी खोजें";
        document.getElementById("lblPanelHeader").className = "Frm_Txt_Hindi";

        //Grid Code Start one
        var table = document.getElementById("dgAgency");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "यूजर कोड";
        tr.cells[1].innerHTML = "एजेंसी का नाम";
        tr.cells[2].innerHTML = "चुनिये";
        //==========Hindi Code============//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
    }
    if (Choice == 0 && FormId == 109) {
        document.getElementById("Lblheader").innerHTML = "सहायता राशि रिपोर्ट –एम आई ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = " | लॉगआउट";
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
        // Location, Bank Wise Radio button code
        document.getElementById("btnSave").value = "देखें ";
        document.getElementById("btnPrint").value = "प्रिंट  ";
        document.getElementById("btnCancel").value = "रद्ध करें  ";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";
        //document.getElementById("ChkAll").innerHTML = "सभी चुनें   ";
        document.getElementById("ChkAll").nextSibling.innerHTML = "सभी चुनें   ";
        document.getElementById("lblSchemeName").innerHTML = "स्कीम का नाम   ";
        document.getElementById("lblFinancialYear").innerHTML = "वित्तीय वर्ष ";
        // document.getElementById("lblOrderBy").innerHTML = "क्रम  ";
        document.getElementById("lblOrderBy").innerHTML = "सब योग ";

        document.getElementById("LblHeader").className = "Frm_Txt_Hindi";
        document.getElementById("hlHome").className = "Frm_Head_Hindi";
        document.getElementById("hlLogoff").className = "Frm_Txt_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";
    }
    //Rpt_Annual_Action_Plan.aspx
    if (Choice == 0 && FormId == 111) {
        document.getElementById("Lblheader").innerHTML = "वार्षिक कार्य योजना ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = " | लॉगआउट";
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
        // Location, Bank Wise Radio button code
        document.getElementById("btnSave").value = "देखें ";
        // document.getElementById("btnPrint").value = "प्रिंट  ";
        document.getElementById("btCancel").value = "रद्ध करें  ";
        //document.getElementById("ChkAll").innerHTML = "सभी चुनें   ";
        document.getElementById("ChkAll").nextSibling.innerHTML = "सभी चुनें   ";
        document.getElementById("lblSchemeName").innerHTML = "स्कीम का नाम   ";
        document.getElementById("lblFinancialYear").innerHTML = "वित्तीय वर्ष ";
        document.getElementById("lblOrderBy").innerHTML = "क्रम  ";

        document.getElementById("Lblheader").className = "Frm_Head_Hindi";
        document.getElementById("hlHome").className = "Frm_Head_Hindi";
        document.getElementById("hlLogoff").className = "Frm_Txt_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        //document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btCancel").className = "btn_Hindi";
    }
    //Form ID 83, Form Name:TrialBalanceReport.aspx
    if (Choice == 0 && FormId == 83) {
        document.getElementById("LblHeader").innerHTML = "तलपट (ट्राँयल बैलेंस)";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        // document.getElementById("btnGetBranch").value = "शाखा  देखें";
        // document.getElementById("chkwithSUBBranch").nextSibling.innerHTML = " उप शाखाओ सहित";
        document.getElementById("LblReportOp").innerHTML = "रिपोर्ट प्रकार";
        //document.getElementById("lblSchemeName").innerHTML = "स्कीम का नाम";
        document.getElementById("lblFdate").innerHTML = "दिनांक से";
        document.getElementById("lblToDate").innerHTML = "दिनांक तक";
        document.getElementById("BtnTrialBalance").value = "रिपोर्ट देखें";
        document.getElementById("BtnExit").value = "बंद करे";
        
        // document.getElementById("btnGo").value = "देखें";
        // document.getElementById("lblPanchayatCode").innerHTML = "पंचायत कोड";
        // document.getElementById("lbFindBranchCode").innerHTML = "शाखा कोड देखें";
        document.getElementById("lblFunctionary0").innerHTML = "फंक्शन";
        document.getElementById("lblFunctionary").innerHTML = "फंक्शनरी चुनें";
        document.getElementById("LblSchemeOption").innerHTML = "स्कीम विकल्प";
        document.getElementById("ChkAll").nextSibling.innerHTML = "सभी चुनें";
        //=======Hindi Text ============//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        // document.getElementById("chkwithSUBBranch").nextSibling.className = "Frm_Txt_Hindi";
        // document.getElementById("btnGetBranch").className = "btn_Hindi";
        document.getElementById("LblReportOp").className = "Frm_Txt_Hindi";
        //document.getElementById("lblSchemeName").className = "Frm_Txt_Hindi";
        document.getElementById("lblFdate").className = "Frm_Txt_Hindi";
        document.getElementById("lblToDate").className = "Frm_Txt_Hindi";
        document.getElementById("BtnTrialBalance").className = "btn_Hindi";
        document.getElementById("BtnExit").className = "btn_Hindi";
        //document.getElementById("btnGo").className = "btn_Hindi";
        // document.getElementById("lblPanchayatCode").className = "Frm_Txt_Hindi";
        document.getElementById("lblFunctionary0").className = "Frm_Txt_Hindi";
        document.getElementById("lblFunctionary").className = "Frm_Txt_Hindi";
        document.getElementById("LblSchemeOption").className = "Frm_Txt_Hindi";
        // document.getElementById("lblStates").className = "Frm_Txt_Hindi";
        // document.getElementById("lblDistricts").className = "Frm_Txt_Hindi";
        // document.getElementById("lblBklocks").className = "Frm_Txt_Hindi";
        // document.getElementById("lblGramPanchayats").className = "Frm_Txt_Hindi";
        // document.getElementById("lblVillages").className = "Frm_Txt_Hindi";
        document.getElementById("ChkAll").nextSibling.className = "Frm_Txt_Hindi";
        //=======Report Text ============//
        //Add by Rakesh as per task 1707
        var Default = document.getElementById("RbWithBranch");
        var RB = Default.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " उप शाखा सहित";
        RB[0].className = "Frm_Txt_Hindi";

        var custom = document.getElementById("RbWithoutBranch");
        var RB = custom.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " उप शाखा रहित";
        RB[0].className = "Frm_Txt_Hindi";

        var Action = document.getElementById("RBLReport");
        var rbAction = Action.parentNode.getElementsByTagName("label");
        rbAction[0].innerHTML = " ग्रुप";
        rbAction[1].innerHTML = " घटक";
        rbAction[0].className = "Frm_Txt_Hindi";
        rbAction[1].className = "Frm_Txt_Hindi";
        // Branch button code
        //        var RBrbstate = document.getElementById("rbstate");
        //        var rbrbstate = RBrbstate.parentNode.getElementsByTagName("label");
        //        rbrbstate[0].innerHTML = " राज्य";
        //        rbrbstate[0].className = "Frm_Txt_Hindi";

        //        var RBrbDistrict = document.getElementById("rbDistrict");
        //        var rbrbDistrict = RBrbDistrict.parentNode.getElementsByTagName("label");
        //        rbrbDistrict[0].innerHTML = " जिला";
        //        rbrbDistrict[0].className = "Frm_Txt_Hindi";

        //        var RBrbblock = document.getElementById("rbblock");
        //        var rbrbblock = RBrbblock.parentNode.getElementsByTagName("label");
        //        rbrbblock[0].innerHTML = " जनपद";
        //        rbrbblock[0].className = "Frm_Txt_Hindi";

        //        var RBrbgrampanchyat = document.getElementById("rbgrampanchyat");
        //        var rbrbgrampanchyat = RBrbgrampanchyat.parentNode.getElementsByTagName("label");
        //        rbrbgrampanchyat[0].innerHTML = " ग्राम पचांयत";
        //        rbrbgrampanchyat[0].className = "Frm_Txt_Hindi";


        //        var RBrbVillage = document.getElementById("rbVillage");
        //        var rbrbVillage = RBrbVillage.parentNode.getElementsByTagName("label");
        //        rbrbVillage[0].innerHTML = " ग्राम";
        //        rbrbVillage[0].className = "Frm_Txt_Hindi";
        // Scheme button code
        var FCRA = document.getElementById("RBLScheme");
        var RB = FCRA.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " एफ सी आर ए";
        RB[1].innerHTML = " नाँन एफ सी आर ए";
        RB[2].innerHTML = " दोनों";
        RB[0].className = "Frm_Txt_Hindi";
        RB[1].className = "Frm_Txt_Hindi";
        RB[2].className = "Frm_Txt_Hindi";
    }
    //Form ID 84, Form Name:frmFinancialReport.aspx
    if (Choice == 0 && FormId == 84) {
        document.getElementById("LblHeader").innerHTML = "वित्तीय स्थिति पर रिपोर्ट";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("lblstates").innerHTML = "राज्य";
        document.getElementById("lbldistricts").innerHTML = "जिला";
        document.getElementById("lblblocks").innerHTML = "जनपद";
        document.getElementById("lblGramPanchayats").innerHTML = "ग्राम पंचायत";
        document.getElementById("lblvillages").innerHTML = "ग्राम";
        document.getElementById("chkwithSUBBranch").nextSibling.innerHTML = "उप शाखाओ सहित";
        document.getElementById("btnGetBranch").value = "शाखा देखें";
        document.getElementById("LblPeriod").innerHTML = "वित्तीय वर्ष";
        document.getElementById("LblSchemeOption").innerHTML = "स्कीम का प्रकार";
        document.getElementById("LblQuarter").innerHTML = "तिमाही";
        document.getElementById("Btnok").value = "रिपोर्ट देखे";
        document.getElementById("BtnExit").value = "बंद करे";        
        //==============Font Size===============//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblstates").className = "Frm_Txt_Hindi";
        document.getElementById("lbldistricts").className = "Frm_Txt_Hindi";
        document.getElementById("lblblocks").className = "Frm_Txt_Hindi";
        document.getElementById("lblGramPanchayats").className = "Frm_Txt_Hindi";
        document.getElementById("lblvillages").className = "Frm_Txt_Hindi";
        document.getElementById("chkwithSUBBranch").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("btnGetBranch").className = "btn_Hindi";
        document.getElementById("LblPeriod").className = "Frm_Txt_Hindi";
        document.getElementById("LblSchemeOption").className = "Frm_Txt_Hindi";
        document.getElementById("LblQuarter").className = "Frm_Txt_Hindi";
        document.getElementById("Btnok").className = "btn_Hindi";
        document.getElementById("BtnExit").className = "btn_Hindi";
        // Scheme button code
        var FCRA = document.getElementById("RadioButtonList1");
        var RB = FCRA.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " एफ सी आर ए";
        RB[1].innerHTML = " नाँन एफ सी आर ए";
        RB[2].innerHTML = " दोनों";
        RB[0].className = "Frm_Txt_Hindi";
        RB[1].className = "Frm_Txt_Hindi";
        RB[2].className = "Frm_Txt_Hindi";

        // Quarter button code
        var FCRA = document.getElementById("RadioButtonList2");
        var RB = FCRA.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " 1st तिमाही";
        RB[1].innerHTML = " 2nd तिमाही";
        RB[2].innerHTML = " 3rd तिमाही";
        RB[3].innerHTML = " 4th तिमाही";
        RB[4].innerHTML = " पूरा वर्ष";
        RB[0].className = "Frm_Txt_Hindi";
        RB[1].className = "Frm_Txt_Hindi";
        RB[2].className = "Frm_Txt_Hindi";
        RB[3].className = "Frm_Txt_Hindi";
        RB[4].className = "Frm_Txt_Hindi";
    }
    //Form ID 85, Form Name:CashBookReport.aspx
    if (Choice == 0 && FormId == 85) {
        document.getElementById("LblHeader").innerHTML = "कैश-बुक रिपोर्ट";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("LblSchemeOp").innerHTML = "स्कीम विकल्प";
        // document.getElementById("LblSchemeName").innerHTML = "स्कीम का नाम";
        document.getElementById("LblFromDate").innerHTML = "दिनांक से";
        document.getElementById("LblToDate").innerHTML = "दिनांक तक";
        document.getElementById("LblReportOp").innerHTML = "रिपोर्ट प्रकार";
        document.getElementById("ChkDetail").nextSibling.innerHTML = "विवरण";
        document.getElementById("btnPrintRptCry").value = "रिपोर्ट देखें";     
        document.getElementById("BtnExit").value = "बंद करे";
        if (document.getElementById("LblScheme") != null) {
            document.getElementById("LblScheme").innerHTML = "स्कीम चुनें";
            document.getElementById("ChkAll").nextSibling.innerHTML = "सभी चुने"
        }
        var Default = document.getElementById("RbWithBranch");
        var RB = Default.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " उप शाखा सहित";
        RB[0].className = "Frm_Txt_Hindi";

        var custom = document.getElementById("RbWithoutBranch");
        var RB = custom.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " उप शाखा रहित";
        RB[0].className = "Frm_Txt_Hindi";
        //=======Hindi Text ============//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("LblSchemeOp").className = "Frm_Txt_Hindi";
        //document.getElementById("LblSchemeName").className = "Frm_Txt_Hindi";
        document.getElementById("LblFromDate").className = "Frm_Txt_Hindi";
        document.getElementById("LblToDate").className = "Frm_Txt_Hindi";
        document.getElementById("LblReportOp").className = "Frm_Txt_Hindi";
        document.getElementById("btnPrintRptCry").className = "btn_Hindi";
        document.getElementById("BtnExit").className = "btn_Hindi";
        document.getElementById("ChkDetail").nextSibling.className = "Frm_Txt_Hindi";
        //document.getElementById("DlSchemeName").className = "ddl_Hindi";

        //=======Report Text ============//
        var Action = document.getElementById("RBLSchemeOp");
        var RB = Action.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " एफ सी आर ए";
        RB[1].innerHTML = " नाँन एफ सी आर ए";
        RB[2].innerHTML = " दोनों";
        RB[0].className = "Frm_Txt_Hindi";
        RB[1].className = "Frm_Txt_Hindi";
        RB[2].className = "Frm_Txt_Hindi";

        // Default and Branch Radio button code
        var Default = document.getElementById("RBLDailyMonthly");
        var RB = Default.parentNode.getElementsByTagName("label");
        RB[1].innerHTML = " रोजाना";
        RB[2].innerHTML = " मासिक";
        RB[1].className = "Frm_Txt_Hindi";
        RB[2].className = "Frm_Txt_Hindi";
    }



    //Form ID 82, Form Name:frmDepositWithdraw.aspx
    if (Choice == 0 && FormId == 82) {
        document.getElementById("LblCash").innerHTML = "रोकड जमा और निकासी";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("lblFunctionary").innerHTML = "फंक्शन";
        document.getElementById("lblFunction").innerHTML = "फंक्शनरी चुनें";
        //document.getElementById("LblScheme").innerHTML = "स्कीम";
        document.getElementById("LblDate").innerHTML = "दिनांक";

        if (document.getElementById("lblCheque") != null) {
            document.getElementById("lblCheque").innerHTML = "चेक/डीडी/यूटीआर न. ";
        }
        document.getElementById("LblAmount").innerHTML = "राशि";
        document.getElementById("BtnSave").value = "रक्षित करे";
        //document.getElementById("BtnExit").value = "बंद करे";
        document.getElementById("lblTip").innerHTML = "टिप: दिनांक दिन/माह/वर्ष फारमेट में डालें, दिनांक चुननें के लिये कलेन्डर भी है |";

        // Radio button code
        var RBHindi = document.getElementById("RadioButtonList1");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "जमा";
        RB[1].innerHTML = "निकासी";
        RB[2].innerHTML = "बैंक हस्तान्तरण";
        RB[0].className = "Frm_Txt_Hindi";
        RB[1].className = "Frm_Txt_Hindi";
        RB[2].className = "Frm_Txt_Hindi";

        //Hindi Font Increase
        document.getElementById("LblCash").className = "Frm_Head_Hindi";
        document.getElementById("lblFunctionary").className = "Frm_Txt_Hindi";
        document.getElementById("lblFunction").className = "Frm_Txt_Hindi";
        document.getElementById("LblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("LblDate").className = "Frm_Txt_Hindi";
        document.getElementById("LblSelectBank").className = "Frm_Txt_Hindi";
        if (document.getElementById("lblCheque") != null) {
            document.getElementById("lblCheque").className = "Frm_Txt_Hindi";
        }
        document.getElementById("LblAmount").className = "Frm_Txt_Hindi";
        document.getElementById("BtnSave").className = "btn_Hindi";
        if (document.getElementById("BtnExit") != null) {
            document.getElementById("BtnExit").className = "btn_Hindi";
        }
        document.getElementById("lblTip").className = "RedText";
    }
    //Form ID 2209, Form Name:frm_UnpaidBill.aspx
    if (Choice == 0 && FormId == 2209) {
        document.getElementById("LblHeader").innerHTML = "अनपेड देयक";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("lblDate").innerHTML = "तिथि";
        document.getElementById("lblschemename").innerHTML = "स्कीम का नाम";
        document.getElementById("lblAccountHead").innerHTML = "लेखा शीर्ष";
        document.getElementById("lblObjectHead").innerHTML = "उदेदश्य शीर्ष";
        //document.getElementById("lblSanctionRef").innerHTML = "स्वीकृति पत्रक रिफरेंस न.";
        document.getElementById("lblAgencyType").innerHTML = "एजेंसी का प्रकार";
        document.getElementById("lblAgency").innerHTML = "एजेंसी";
        document.getElementById("lblSanctionRef").innerHTML = "प्रोजेक्ट संदर्भ क्रमांक";
        document.getElementById("lblBillDetail").innerHTML = "देयक विवरण";
        document.getElementById("lblBillno").innerHTML = "देयक नंबर";
        document.getElementById("lblBillDate").innerHTML = "देयक तिथि";
        document.getElementById("lblBillAmount").innerHTML = "देयक राशि";
        document.getElementById("lblUploadBill").innerHTML = "अपलोड देयक";
        document.getElementById("lblProposedDeduction").innerHTML = "प्रस्तावित कटौती";
        document.getElementById("lblProposedPayment").innerHTML = "प्रस्तावित भुगतान";
        document.getElementById("lblRemark").innerHTML = "विवरण";
        document.getElementById("lblReasonforamount").innerHTML = "प्रस्तावित राशि में कटौती कारण";
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("lblFileformat").innerHTML = "केवल (.jpg/.jpeg/.png/.gif/.pdf)";

        //font increase ===//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblschemename").className = "Frm_Txt_Hindi";
        document.getElementById("lblAccountHead").className = "Frm_Txt_Hindi";
        document.getElementById("lblObjectHead").className = "Frm_Txt_Hindi";
        document.getElementById("lblAgencyType").className = "Frm_Txt_Hindi";
        document.getElementById("lblAgency").className = "Frm_Txt_Hindi";
        document.getElementById("lblSanctionRef").className = "Frm_Txt_Hindi";
        document.getElementById("lblBillDetail").className = "Frm_Txt_Hindi";
        document.getElementById("lblBillno").className = "Frm_Txt_Hindi";
        document.getElementById("lblBillDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblBillAmount").className = "Frm_Txt_Hindi";
        document.getElementById("lblUploadBill").className = "Frm_Txt_Hindi";
        document.getElementById("lblProposedDeduction").className = "Frm_Txt_Hindi";
        document.getElementById("lblProposedPayment").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemark").className = "Frm_Txt_Hindi";
        document.getElementById("lblReasonforamount").className = "Frm_Txt_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("lblFileformat").className = "Frm_Txt_Hindi";
    }
    //Form ID 2208, Form Name:Finance/frm_SanctionNote.aspx
    if (Choice == 0 && FormId == 2208) {
        document.getElementById("LblHeader").innerHTML = "स्वीकृति पत्रक";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("lblDate").innerHTML = "तिथि";
        document.getElementById("lblDepartment").innerHTML = "विभाग";
        document.getElementById("lblDivision").innerHTML = "शाखा";
        document.getElementById("lblschemename").innerHTML = "स्कीम का नाम";
        document.getElementById("lblAccountHead").innerHTML = "लेखा शीर्ष";
        document.getElementById("lblObjectHead").innerHTML = "उदेदश्य शीर्ष";
        document.getElementById("lblProjectRef").innerHTML = "परियोजना रिफरेंस न.";
        document.getElementById("lblProposedAmount").innerHTML = "प्रस्तावित राशि";
        document.getElementById("lblAvailableBudget").innerHTML = "उपलब्ध बजट";
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("btnShowBudget").value = "बजट देखें";
        document.getElementById("btnSaveForward").value = "रक्षित करें एवं भेजें";
        //font increase ===//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblDepartment").className = "Frm_Txt_Hindi";
        document.getElementById("lblDivision").className = "Frm_Txt_Hindi";
        document.getElementById("lblschemename").className = "Frm_Txt_Hindi";
        document.getElementById("lblAccountHead").className = "Frm_Txt_Hindi";
        document.getElementById("lblObjectHead").className = "Frm_Txt_Hindi";
        document.getElementById("lblProjectRef").className = "Frm_Txt_Hindi";
        document.getElementById("lblProposedAmount").className = "Frm_Txt_Hindi";
        document.getElementById("lblAvailableBudget").className = "Frm_Txt_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("btnShowBudget").className = "btn_Hindi";
        document.getElementById("btnSaveForward").className = "btn_Hindi";
    }
    if (Choice == 0 && FormId == 2203) {
        document.getElementById("LblHeader").innerHTML = "रिप्रिंट सहायता राशि वितरण";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        // Location, Bank Wise Radio button code
        var Loation = document.getElementById("rbLocationWise");
        var L = Loation.parentNode.getElementsByTagName("label");
        L[0].innerHTML = "स्थान वाँइस";
        L[0].className = "Frm_Txt_Hindi";

        var Bank = document.getElementById("rbBankWise");
        var B = Bank.parentNode.getElementsByTagName("label");
        B[0].innerHTML = "बैंक वाँइस";
        B[0].className = "Frm_Txt_Hindi";

        document.getElementById("lblGroupType").innerHTML = "ग्रुप पर रिपोर्ट";
        document.getElementById("lblPensionSubsidyNo").innerHTML = "सहायता राशि वितरण नबंर";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("lblGroupType").className = "Frm_Txt_Hindi";
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblPensionSubsidyNo").className = "Frm_Txt_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
    }
    //Form ID 88, Form Name:ManagementReports/BenificiaryReport.aspx
    if (Choice == 0 && FormId == 88) {
        document.getElementById("LblHeader").innerHTML = "हितग्राही रिपोर्ट";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("Label2").innerHTML = "स्कीम का नाम";
        document.getElementById("Label2").className = "Frm_Txt_Hindi";
        document.getElementById("lblLedger").innerHTML = "लेजर का नाम";
        document.getElementById("lblLedger").className = "Frm_Txt_Hindi";
        document.getElementById("LblScheme").innerHTML = "एजेंसी कोड";
        document.getElementById("LblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("showModalPopupServerOperatorButton").value = "एजेंसी खोजें";
        document.getElementById("showModalPopupServerOperatorButton").className = "btn_Hindi";
        document.getElementById("BtnVwReport").value = "रिपोर्ट देखें";
        document.getElementById("BtnVwReport").className = "btn_Hindi";
        document.getElementById("BtnExit").value = "बंद करे";
        document.getElementById("BtnExit").className = "btn_Hindi";
        document.getElementById("LblAgencyT").innerHTML = "एजेंसी टाईप";
        document.getElementById("LblAgencyT").className = "Frm_Txt_Hindi";
        document.getElementById("Label1").innerHTML = "एजेंसी का नाम";
        document.getElementById("Label1").className = "Frm_Txt_Hindi";
        document.getElementById("btnSearch").value = "एजेंसी खोजें";
        document.getElementById("btnSearch").className = "btn_Hindi";
        document.getElementById("chkAll").nextSibling.innerHTML = "सभी चुने";
        document.getElementById("chkAll").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("lblPanelHeader").innerHTML = "एजेंसी खोजें";
        document.getElementById("lblPanelHeader").className = "Frm_Txt_Hindi";

        //Grid Code Start one
        var table = document.getElementById("dgAgency");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "यूजर कोड";
        tr.cells[1].innerHTML = "एजेंसी का नाम";
        tr.cells[2].innerHTML = "चुनिये";
        //==========Hindi Code============//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
    }
    //Form ID 89, Form Name:ManagementReports/OtherAdvancesReport.aspx
    if (Choice == 0 && FormId == 89) {
        document.getElementById("LblHeader").innerHTML = "अन्य को अग्रिम";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("LblScheme").innerHTML = "एजेंसी कोड";
        document.getElementById("LblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("showModalPopupServerOperatorButton").value = "एजेंसी खोजें";
        document.getElementById("showModalPopupServerOperatorButton").className = "btn_Hindi";
        document.getElementById("BtnVwReport").value = "रिपोर्ट देखें";
        document.getElementById("BtnVwReport").className = "btn_Hindi";
        document.getElementById("BtnExit").value = "बंद करे";
        document.getElementById("BtnExit").className = "btn_Hindi";
        document.getElementById("LblAgencyT").innerHTML = "एजेंसी टाईप";
        document.getElementById("LblAgencyT").className = "Frm_Txt_Hindi";
        document.getElementById("Label1").innerHTML = "एजेंसी का नाम";
        document.getElementById("Label1").className = "Frm_Txt_Hindi";
        document.getElementById("btnSearch").value = "एजेंसी खोजें";
        document.getElementById("btnSearch").className = "btn_Hindi";
        document.getElementById("lblPanelHeader").innerHTML = "एजेंसी खोजें";
        document.getElementById("lblPanelHeader").className = "Frm_Txt_Hindi";

        //Grid Code Start one
        var table = document.getElementById("dgAgency");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "यूजर कोड";
        tr.cells[1].innerHTML = "एजेंसी का नाम";
        tr.cells[2].innerHTML = "चुनिये";
        //==========Hindi Code============//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
    }
    //FormId == 2220 and frm_Generate_Challan.aspx
    if (Choice == 0 && FormId == 2220) {
        document.getElementById("LblHeader").innerHTML = "जनरेट चालान ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("lblSchemeName").innerHTML = "स्कीम का नाम";
        document.getElementById("lblFromDate").innerHTML = "तिथि से";
        document.getElementById("lblTypeofPayment").innerHTML = "भुगतान का प्रकार";
        document.getElementById("lblToDate").innerHTML = "तिथि तक";
        document.getElementById("lblCompanyName").innerHTML = "कम्‍पनी का नाम";
        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnCancel_New").value = "रद्द करें";
        document.getElementById("lnkReprintChallan").innerHTML = "रिप्रिंट चालान";
        document.getElementById("btnGenerateChallan").value = "जनरेट चालान";
        //font increase ===//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblSchemeName").className = "Frm_Txt_Hindi";
        document.getElementById("lblFromDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblTypeofPayment").className = "Frm_Txt_Hindi";
        document.getElementById("lblToDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblCompanyName").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnCancel_New").className = "btn_Hindi";
        //document.getElementById("lnkReprintChallan").innerHTML = "रिप्रिंट चालान";
        document.getElementById("btnGenerateChallan").className = "btn_Hindi";



        // Reprint Div Hindi,
        document.getElementById("lblChallanNo0").innerHTML = "रिप्रिंट चालान";
        document.getElementById("lblChallanNo0").className = "Frm_Txt_Hindi";
        document.getElementById("lblChallanNo").innerHTML = "चालान नंबर";
        document.getElementById("lblChallanNo").className = "Frm_Txt_Hindi";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("btnClose").value = "बन्द करें";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnClose").className = "btn_Hindi";

        // Grid Code Start

        var table = document.getElementById("gvGenerateChallan");
        if (table != null) {
            var tr = table.rows[0];
            document.getElementById("gvGenerateChallan_ctl01_ChkSelectAll").nextSibling.innerHTML = "सभी चुने";

            tr.cells[1].innerHTML = "क्रमांक  न.";
            tr.cells[2].innerHTML = "काटे जाने वाले का कोड";
            tr.cells[3].innerHTML = "काटे जाने वाले का पेन";
            tr.cells[4].innerHTML = "नाम";
            tr.cells[5].innerHTML = "तिथि";
            tr.cells[6].innerHTML = "भुगतान राशि";
            tr.cells[7].innerHTML = "बही की प्रविष्टि के अनुसार भुगतान ";
            tr.cells[8].innerHTML = "आयकर";
            tr.cells[9].innerHTML = "अतिरिक्‍त शुल्‍क ";
            tr.cells[10].innerHTML = "शिक्षा उपकर";
            tr.cells[11].innerHTML = "कर कटौती ";
            tr.cells[12].innerHTML = "कर जमा";
            tr.cells[13].innerHTML = "भुगतान का प्रकार";
            tr.cells[14].innerHTML = "कम्‍पनी ";
            //============Hindi Text================//
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
            tr.cells[10].className = "Frm_Txt_Hindi";
            tr.cells[11].className = "Frm_Txt_Hindi";
            tr.cells[12].className = "Frm_Txt_Hindi";
            tr.cells[13].className = "Frm_Txt_Hindi";
            tr.cells[14].className = "Frm_Txt_Hindi";

        }

        // Challan Can not be Div Hindi,
        document.getElementById("lblUnStatusHeader").innerHTML = "इस डाटा का चालान जनरेट नही हो सकता  :";
        document.getElementById("lblUnStatusHeader").className = "Frm_Txt_Hindi";
        document.getElementById("btnOkDiv").value = "ओके";
        document.getElementById("btnCancelDiv").value = "रद्द करें";
        document.getElementById("btnOkDiv").className = "btn_Hindi";
        document.getElementById("btnCancelDiv").className = "btn_Hindi";
        // Grid Code Start
        var table = document.getElementById("gvUnStatusvoucher");
        if (table != null) {
            var tr = table.rows[0];
            tr.cells[0].innerHTML = "नाम";
            tr.cells[1].innerHTML = "राशि";
            tr.cells[2].innerHTML = "तिथि";
            //============Hindi Text================//
            tr.cells[0].className = "Frm_Txt_Hindi";
            tr.cells[1].className = "Frm_Txt_Hindi";
            tr.cells[2].className = "Frm_Txt_Hindi";
        }

        // Generate Challan Button Div Hindi,
        document.getElementById("lblPaymentType").innerHTML = "भुगतान का प्रकार :-";
        document.getElementById("lblPaymentDetails").innerHTML = "भुगतान का विवरण";
        document.getElementById("lblIncome").innerHTML = "आय";
        document.getElementById("lblSurcharge").innerHTML = "अतिरिक्‍त शुल्‍क";
        document.getElementById("lblEducation").innerHTML = "शिक्षा";
        document.getElementById("lblInterest").innerHTML = "ब्‍याज ";
        document.getElementById("lblPenalty").innerHTML = "जुर्माना ";
        document.getElementById("lblOther").innerHTML = "अन्‍य";
        document.getElementById("lblTotal").innerHTML = "कुल योग";
        document.getElementById("lblPaymentMode").innerHTML = "भुगतान मोड";
        document.getElementById("lblbankname").innerHTML = "बैंक का नाम";
        document.getElementById("lblChequeNo").innerHTML = "चेक/ट्राँजेक्सन नंबर";
        document.getElementById("lblTaxDepositDate").innerHTML = "कर जमा तिथि";
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btnCancel").value = "रद्द करें";
        //======= Payment Mode Radio button Text ============//
        var RBCheque = document.getElementById("rbCheque");
        var rbCheque = RBCheque.parentNode.getElementsByTagName("label");
        rbCheque[0].innerHTML = " चेक";
        rbCheque[0].className = "Frm_Txt_Hindi";

        var RBCash = document.getElementById("rbCash");
        var rbCash = RBCash.parentNode.getElementsByTagName("label");
        rbCash[1].innerHTML = " नगद";
        rbCash[1].className = "Frm_Txt_Hindi";

        var RBDebitAccount = document.getElementById("rbDebitAccount");
        var rbDebitAccount = RBDebitAccount.parentNode.getElementsByTagName("label");
        rbDebitAccount[2].innerHTML = " खाते से डेबिट ";
        rbDebitAccount[2].className = "Frm_Txt_Hindi";

        //======= Payment Type Radio button Text ============//
        var TaxPayee = document.getElementById("rbTaxPayee");
        var rbTaxPayee = TaxPayee.parentNode.getElementsByTagName("label");
        rbTaxPayee[0].innerHTML = " टी.सी.एस./टी.डी.एस. देययोग्य कर अदाकर्ता";
        rbTaxPayee[0].className = "Frm_Txt_Hindi";

        var RegularAssessment = document.getElementById("rbRegularAssessment");
        var RegularA = RegularAssessment.parentNode.getElementsByTagName("label");
        RegularA[1].innerHTML = "टी.डी.एस./टी.सी.एस. रेग्युलर आंकलन";
        RegularA[1].className = "Frm_Txt_Hindi";

        var CompanyDeductees = document.getElementById("rbCompanyDeductees");
        var cd = CompanyDeductees.parentNode.getElementsByTagName("label");
        cd[0].innerHTML = "काटी जाने वाली कम्पनी";

        var NonCompanyDeductees = document.getElementById("rbNonCompanyDeductees");
        var ncd = NonCompanyDeductees.parentNode.getElementsByTagName("label");
        if (ncd[1] != null) {
            ncd[1].innerHTML = "न काटी जाने वाली कम्पनी";
        } else {
            ncd[0].innerHTML = "न काटी जाने वाली कम्पनी";
        }

    }
    //Form ID 2202, Form Name:Finance/rpt_Subsidy_Disbursment_Reprint.aspx
    if (Choice == 0 && FormId == 2241) {
        document.getElementById("LblHeader").innerHTML = "रिप्रिंट सहायता राशि वितरण";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        // Location, Bank Wise Radio button code
        var Loation = document.getElementById("rbLocationWise");
        var L = Loation.parentNode.getElementsByTagName("label");
        L[0].innerHTML = "स्थान वाँइस";
        L[0].className = "Frm_Txt_Hindi";

        var Bank = document.getElementById("rbBankWise");
        var B = Bank.parentNode.getElementsByTagName("label");
        B[0].innerHTML = "बैंक वाँइस";
        B[0].className = "Frm_Txt_Hindi";

        document.getElementById("lblGroupType").innerHTML = "ग्रुप पर रिपोर्ट";
        document.getElementById("lblSubsidyNo").innerHTML = "सहायता राशि वितरण नबंर";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnCancel").value = "वितरण रद्द करें";
        document.getElementById("lblGroupType").className = "Frm_Txt_Hindi";
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblSubsidyNo").className = "Frm_Txt_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
    }
    //Form ID 903, Form Name:BillManagement/frmbankReconcile.aspx
    if (Choice == 0 && FormId == 903 && QueryString == 0) {
        document.getElementById("LblHeader").innerHTML = "बैंक समाधान विवरण";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        //document.getElementById("lblScheme").innerHTML = "स्कीम";
        document.getElementById("lblfromdate").innerHTML = "दिनांक से";
        document.getElementById("lbltodate").innerHTML = "दिनांक तक";

        document.getElementById("lblimportdata").innerHTML = "आयात डाटा";
        document.getElementById("lblbank").innerHTML = "बैंक";
        document.getElementById("lbltype").innerHTML = "प्रकार चुनिये :";
        document.getElementById("btnShownew").value = "देखें";
        document.getElementById("btnsave").value = "रक्षित करें";
        document.getElementById("btnnext").value = "आगे जायें";
        document.getElementById("btnNew").value = "दिनांक  बदलॆ  ";
        document.getElementById("btnCloseValImg").value = "ओके";
        document.getElementById("btnreprint").value = " रिप्रिंट  ";
        //============Hindi Text================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        //document.getElementById("lblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("lblfromdate").className = "Frm_Txt_Hindi";
        document.getElementById("lbltodate").className = "Frm_Txt_Hindi";
        document.getElementById("lblbank").className = "Frm_Txt_Hindi";
        document.getElementById("btnShownew").className = "btn_Hindi";
        document.getElementById("btnsave").className = "btn_Hindi";
        document.getElementById("lbltype").className = "Frm_Txt_Hindi";
        document.getElementById("btnnext").className = "btn_Hindi";
        document.getElementById("btnreprint").className = "btn_Hindi";
        // Hindi,English Radio button code
        var reconciled = document.getElementById("rbreconciled");
        var RB = reconciled.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "समाशोधित";
        RB[0].className = "Frm_Txt_Hindi";

        var unreconciled = document.getElementById("rbunreconciled");
        var RB = unreconciled.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "असमाशोधित";
        RB[0].className = "Frm_Txt_Hindi";

        var both = document.getElementById("rbboth");
        var RB = both.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "दोनों";
        RB[0].className = "Frm_Txt_Hindi";

        // Grid Code Start
        var table = document.getElementById("gvbankreconcile");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "वाउचर न.";
        tr.cells[1].innerHTML = "वाउचर दिनांक";
        tr.cells[2].innerHTML = "विवरण";
        tr.cells[3].innerHTML = "चेक न.";
        tr.cells[4].innerHTML = "डेविट राशि";
        tr.cells[5].innerHTML = "क्रेडिट राशि";
        tr.cells[6].innerHTML = "समाशोधन  दिनांक";
        tr.cells[7].innerHTML = "प्राप्त";
        //============Hindi Text================//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
        tr.cells[5].className = "Frm_Txt_Hindi";
        tr.cells[6].className = "Frm_Txt_Hindi";
        tr.cells[7].className = "Frm_Txt_Hindi";
    }
    //Form ID 903, Form Name:BillManagement/frmbankreconcilationstatement.aspx
    if (Choice == 0 && FormId == 903 && QueryString == 1) {
        document.getElementById("LblHeader").innerHTML = "बैंक समाधान विवरण";

        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("lblCAGFormat").innerHTML = "सी एन्ड ऐ जी फाँरमेट - III";
        document.getElementById("lblForPeriod").innerHTML = "अवधि के लिये :";
        document.getElementById("lblbankName").innerHTML = "बैंक का नाम एवं खाता नंबर";
        document.getElementById("lblBalanceAsper").innerHTML = "बैंक के अनुसार शेष (पास बुक)";
        document.getElementById("lblAmountDepositedBut").innerHTML = "राशि जमा जो बैंक द्वारा नहीं दिखाई गयी";
        document.getElementById("lblAmountDebitedBy").innerHTML = "बैंक अनुसार डेविट राशि पर कैश - बुक अनुसार क्रेडिट नहीं";
        document.getElementById("lblAmountDebitedByBank").innerHTML = "बैंक अनुसार क्रेडिट राशि पर कैश - बुक अनुसार डेविट नहीं";
        document.getElementById("lblDifference").innerHTML = "अंतर राशि";
        document.getElementById("lblChequeIssuedButNot").innerHTML = "चेक जारी मगर बैंक में प्रस्तुत नहीं";
        document.getElementById("lblbalanceaspercashbook").innerHTML = "कैश - बुक अनुसार शेष";
        document.getElementById("lblDateCheque").innerHTML = "तिथि";
        document.getElementById("lblPartcularCheque").innerHTML = "विवरण";
        document.getElementById("lblCheque1").innerHTML = "चेक नंबर";
        document.getElementById("lblAmountCheque").innerHTML = "राशि";
        document.getElementById("lblAdd2").innerHTML = "जोडें";
        document.getElementById("btnadddr").value = "जोडें";
        document.getElementById("lblDate").innerHTML = "तिथि";
        document.getElementById("lblParticular").innerHTML = "विवरण";
        document.getElementById("lblCheque").innerHTML = "चेक नंबर";
        document.getElementById("lblAmount").innerHTML = "राशि";
        document.getElementById("lblAdd").innerHTML = "जोडें";
        document.getElementById("btnAddcr").value = "जोडें";
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("lnkClose").value = "बन्द करें";
        //=======Hindi Label Increase========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblForPeriod").className = "Frm_Txt_Hindi";
        document.getElementById("lblbankName").className = "Frm_Txt_Hindi";
        document.getElementById("lblBalanceAsper").className = "Frm_Txt_Hindi";
        document.getElementById("lblAmountDepositedBut").className = "Frm_Txt_Hindi";
        document.getElementById("lblAmountDebitedBy").className = "Frm_Txt_Hindi";
        document.getElementById("lblAmountDebitedByBank").className = "Frm_Txt_Hindi";
        document.getElementById("lblDifference").className = "Frm_Txt_Hindi";
        document.getElementById("lblChequeIssuedButNot").className = "Frm_Txt_Hindi";
        document.getElementById("lblbalanceaspercashbook").className = "Frm_Txt_Hindi";
        document.getElementById("lblDateCheque").className = "Frm_Txt_Hindi";
        document.getElementById("lblPartcularCheque").className = "Frm_Txt_Hindi";
        document.getElementById("lblCheque1").className = "Frm_Txt_Hindi";
        document.getElementById("lblAmountCheque").className = "Frm_Txt_Hindi";
        document.getElementById("lblAdd2").className = "Frm_Txt_Hindi";
        document.getElementById("btnadddr").className = "btn_Hindi";
        document.getElementById("lblDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblParticular").className = "Frm_Txt_Hindi";
        document.getElementById("lblCheque").className = "Frm_Txt_Hindi";
        document.getElementById("lblAmount").className = "Frm_Txt_Hindi";
        document.getElementById("lblAdd").className = "Frm_Txt_Hindi";
        document.getElementById("btnAddcr").className = "btn_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("lnkClose").className = "btn_Hindi";

        // Grid Code Start
        var table = document.getElementById("gvchequedetailsDr");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "हटाये";
        tr.cells[1].innerHTML = "तिथि";
        tr.cells[2].innerHTML = "विवरण";
        tr.cells[3].innerHTML = "चेक न.";
        tr.cells[4].innerHTML = "राशि";
        //============Hindi Text================//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";

        // Grid Code Start
        var table = document.getElementById("gvchequedetailsCr");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "हटाये";
        tr.cells[1].innerHTML = "तिथि";
        tr.cells[2].innerHTML = "विवरण";
        tr.cells[3].innerHTML = "चेक न.";
        tr.cells[4].innerHTML = "राशि";
        //============Hindi Text================//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
    }
    //Form ID 912, Form Name:BillManagement/rpt_ChequePayment_Register.aspx
    if (Choice == 0 && FormId == 912) {
        //document.getElementById("LblHeader").innerHTML = "चेक भुगतान पंजी";
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
//        document.getElementById("hlHome").innerHTML = "होमपेज";
//        document.getElementById("hlHome").className = "Frm_Txt_Hindi";
//        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
//        document.getElementById("hlLogoff").className = "Frm_Txt_Hindi";
        
        document.getElementById("lblSelectBankName").innerHTML = "बैंक का नाम ";
        document.getElementById("lblSelectBankName").className = "Frm_Txt_Hindi";
        
        document.getElementById("lblSelectACNo").innerHTML = "खाता नंबर ";
        document.getElementById("lblSelectACNo").className = "Frm_Txt_Hindi";
        
        document.getElementById("lbldate").innerHTML = "तिथि से";
        document.getElementById("lbldate").className = "Frm_Txt_Hindi";
        
        document.getElementById("lbltodate").innerHTML = "तिथि तक";
        document.getElementById("lbltodate").className = "Frm_Txt_Hindi";

        if (document.getElementById("lblOrdeerBy") != null) {
            document.getElementById("lblOrdeerBy").innerHTML = "क्रमानुसार";
            document.getElementById("lblOrdeerBy").className = "Frm_Txt_Hindi";
                    var dt = document.getElementById("rbDate");
                    var RBdt = dt.parentNode.getElementsByTagName("label");
                    RBdt[0].innerHTML = "दिनांक";
                    RBdt[0].className = "Frm_Txt_Hindi";
                    var cheq = document.getElementById("rbChekque");
                    var RBcheq = cheq.parentNode.getElementsByTagName("label");
                    RBcheq[1].innerHTML = "चैक";
                    RBcheq[1].className = "Frm_Txt_Hindi";
                }
                document.getElementById("btnshow").value = "देखें";
                document.getElementById("btnshow").className = "btn_Hindi";
                 
                document.getElementById("btnPrint").value = "प्रिंट करें";
                document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";
        if (document.getElementById("btnCancelPrint") != null) {
            document.getElementById("btnCancelPrint").value = "चैक नं. रद्द करें / बदलें";
            document.getElementById("btnCancelPrint").className = "btn_Hindi";
        }
        if (document.getElementById("lblChequePrintHeader") != null) {
            document.getElementById("lblChequePrintHeader").innerHTML = "चैक प्रिंट पर नाम भरें";
            document.getElementById("lblChequePrintHeader").className = "Frm_Txt_Hindi";
            document.getElementById("btnPrintCheque").value = "प्रिंट चैक";
            document.getElementById("btnPrintCheque").className = "btn_Hindi";
            document.getElementById("btnPayAdvice").value = "भुगतान एडवाइस";
            document.getElementById("btnPayAdvice").className = "btn_Hindi";
        }
        if (document.getElementById("lbleneternewchequeno") != null) {
            document.getElementById("lbleneternewchequeno").innerHTML = "नया चैक नं. भरें";
            document.getElementById("lbleneternewchequeno").className = "Frm_Txt_Hindi";
            document.getElementById("btnok").value = "ओ के";
            document.getElementById("btnok").className = "btn_Hindi";
        }
        
//        document.getElementById("lblOrdeerBy").innerHTML = "क्रमानुसार";
        
//        if(document.getElementById("btnCancelPrint")!=null)
//        {
//            document.getElementById("btnCancelPrint").value = "चेक न. बदले / रद्द करें";
//            document.getElementById("btnCancelPrint").className = "btn_Hindi";
//        }
        
        
        
//        if (document.getElementById("btnok") != null)
//        {
//            document.getElementById("btnok").value = "ओके";
//            document.getElementById("btnok").className = "btn_Hindi";           
//        }
        
        
        //-----------Font size-------------//
        
        
        
//        document.getElementById("btnshow").className = "btn_Hindi";
//        document.getElementById("btnPrint").className = "btn_Hindi";        
//        document.getElementById("lblChequePrintHeader").className = "Frm_Txt_Hindi";        
//        document.getElementById("lblOrdeerBy").className = "Frm_Txt_Hindi";
//        document.getElementById("btnPrintCheque").className = "btn_Hindi";
//        document.getElementById("btnPayAdvice").className = "btn_Hindi";
//        document.getElementById("btnSaveasExcel").className = "btn_Hindi";
//        document.getElementById("btnCancelPrint").className = "btn_Hindi";
        
    }
    //Form ID 906, Form Name:BillManagement/FrmReceipt.aspx
    if (Choice == 0 && FormId == 906) {
        document.getElementById("LblHeader").innerHTML = "कराधान रसीद";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("chkcancelreceipt").nextSibling.innerHTML = "रद्द रसीद";
        document.getElementById("lblLedgerHead").innerHTML = "प्राप्ति का प्रकार";
        document.getElementById("lblReceiptdate").innerHTML = "रसीद दिनांक";
        document.getElementById("btnshowcashdetail").value = "रोकड विवरण";
        document.getElementById("lblbankname").innerHTML = "बैक का नाम";
        document.getElementById("lblbankplace").innerHTML = "बैक स्थान";
        document.getElementById("lblchqno").innerHTML = "चेक / डीडी नम्बर";
        document.getElementById("lblchqdate").innerHTML = "चेक / डीडी  दिनांक";
        document.getElementById("lblchequeamount").innerHTML = "राशि";
        document.getElementById("btnAdd").value = "जोडें";
        document.getElementById("lblProjectName").innerHTML = "परियोजना का नाम";
        document.getElementById("lblAgencyType").innerHTML = "देनदार का प्रकार ";
        document.getElementById("btnfillSponsor").value = "देनदार  भरे";
        document.getElementById("btnothertypeagency").value = "अन्य  ऐजेंसी रक्षित करें ";
        document.getElementById("lblSponsor").innerHTML = "ऐजेंन्सी";
        document.getElementById("lblRemark").innerHTML = "रिमार्क";
        document.getElementById("chkwithoutbill").nextSibling.innerHTML = "बिना देयक";
        document.getElementById("btnshowbillno").value = "भुगतान विवरण दिखाएँ";
        document.getElementById("lblAdvanceamount").innerHTML = "अग्रिम राशि";
        document.getElementById("btnsave").value = "रक्षित करें";
        document.getElementById("lblInstrument").innerHTML = "इंस्ट्रूमेंट  विवरण";
        document.getElementById("lblSponsorText").innerHTML = "ऐजेंन्सी";
        document.getElementById("lblPaymenttext").innerHTML = "भुगतान समायोजन विवरण";
        // Hindi,English Radio button code
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("chkcancelreceipt").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("lblLedgerHead").className = "Frm_Txt_Hindi";
        document.getElementById("lblReceiptdate").className = "Frm_Txt_Hindi";
        document.getElementById("btnshowcashdetail").className = "btn_Hindi";
        document.getElementById("lblbankname").className = "Frm_Txt_Hindi";
        document.getElementById("lblbankplace").className = "Frm_Txt_Hindi";
        document.getElementById("lblchqno").className = "Frm_Txt_Hindi";
        document.getElementById("lblchqdate").className = "Frm_Txt_Hindi";
        document.getElementById("lblchequeamount").className = "Frm_Txt_Hindi";
        document.getElementById("btnAdd").className = "btn_Hindi";
        document.getElementById("lblProjectName").className = "Frm_Txt_Hindi";
        document.getElementById("lblAgencyType").className = "Frm_Txt_Hindi";
        document.getElementById("btnfillSponsor").className = "btn_Hindi";
        document.getElementById("btnothertypeagency").className = "btn_Hindi";
        document.getElementById("lblSponsor").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemark").className = "Frm_Txt_Hindi";
        document.getElementById("chkwithoutbill").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("btnshowbillno").className = "btn_Hindi";
        document.getElementById("lblAdvanceamount").className = "Frm_Txt_Hindi";
        document.getElementById("btnsave").className = "btn_Hindi";
        document.getElementById("lblInstrument").className = "Frm_Txt_Hindi";
        document.getElementById("lblSponsorText").className = "Frm_Txt_Hindi";
        document.getElementById("lblPaymenttext").className = "Frm_Txt_Hindi";
        //Radio Button Code Start
        var Cash = document.getElementById("rbCash");
        var RB = Cash.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "रोकङ राशि";
        RB[0].className = "Frm_Txt_Hindi";

        var Cheque = document.getElementById("rbCheque");
        var RB = Cheque.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "चेक / डीडी";
        RB[0].className = "Frm_Txt_Hindi";

        var payment = document.getElementById("rbepayment");
        var RB = payment.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "ई-पेमेंट";
        RB[0].className = "Frm_Txt_Hindi";

        if (document.getElementById("rbCash").checked == true) {
            // Grid Code Start Cash Ammount Grid
            var table = document.getElementById("Gvcashdetails");
            var tr = table.rows[0];
            tr.cells[0].innerHTML = "रु";
            tr.cells[1].innerHTML = "स्वीकार";
            tr.cells[2].innerHTML = "सम";
            tr.cells[3].innerHTML = "वापसी";
            tr.cells[4].innerHTML = "सम";
            //============Hindi Text================//
            tr.cells[0].className = "Frm_Txt_Hindi";
            tr.cells[1].className = "Frm_Txt_Hindi";
            tr.cells[2].className = "Frm_Txt_Hindi";
            tr.cells[3].className = "Frm_Txt_Hindi";
            tr.cells[4].className = "Frm_Txt_Hindi";

            document.getElementById("btnsavecashdetail").value = "रक्षित करें";
        }
        if (document.getElementById("rbCheque").checked == true) {
            document.getElementById("lblchqno").innerHTML = "चेक / डीडी नम्बर";
            document.getElementById("lblchqdate").innerHTML = "चेक / डीडी  दिनांक";
            var table = document.getElementById("gvBank");
            var tr = table.rows[0];
            tr.cells[1].innerHTML = "हटाये";
            tr.cells[2].innerHTML = "बैक का नाम";
            tr.cells[3].innerHTML = "बैक स्थान";
            tr.cells[4].innerHTML = "चेक / डीडी नम्बर";
            tr.cells[5].innerHTML = "चेक / डीडी  दिनांक";
            tr.cells[6].innerHTML = "राशि";
            //============Hindi Text================//
            tr.cells[1].className = "Frm_Txt_Hindi";
            tr.cells[2].className = "Frm_Txt_Hindi";
            tr.cells[3].className = "Frm_Txt_Hindi";
            tr.cells[4].className = "Frm_Txt_Hindi";
            tr.cells[5].className = "Frm_Txt_Hindi";
            tr.cells[6].className = "Frm_Txt_Hindi";
        }
        else {
            document.getElementById("lblchqno").innerHTML = "ट्रांजेक्शन नम्बर";
            document.getElementById("lblchqdate").innerHTML = "ट्रांजेक्शन  दिनांक ";
            var table = document.getElementById("gvBank");
            var tr = table.rows[0];
            tr.cells[1].innerHTML = "हटाये";
            tr.cells[2].innerHTML = "बैक का नाम";
            tr.cells[3].innerHTML = "बैक स्थान";
            tr.cells[4].innerHTML = "ट्रांजेक्शन नम्बर";
            tr.cells[5].innerHTML = "ट्रांजेक्शन  दिनांक ";
            tr.cells[6].innerHTML = "राशि";
            //============Hindi Text================//
            tr.cells[1].className = "Frm_Txt_Hindi";
            tr.cells[2].className = "Frm_Txt_Hindi";
            tr.cells[3].className = "Frm_Txt_Hindi";
            tr.cells[4].className = "Frm_Txt_Hindi";
            tr.cells[5].className = "Frm_Txt_Hindi";
            tr.cells[6].className = "Frm_Txt_Hindi";
        }
    }

    //Form ID 2599, Form Name:yf_transaction/Frm_Receipt_new.aspx 
    if (Choice == 0 && FormId == 2599) {

        document.getElementById("LblHeader").innerHTML = "रसीद";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("lblreceiptno").innerHTML = "रसीद क्र.";
        document.getElementById("lblreceipttype").innerHTML = "रसीद  का प्रकार ";
        document.getElementById("lblreceiptno").innerHTML = "रसीद क्र.";
        document.getElementById("lblReceiptdate").innerHTML = "रसीद दिनांक";
        document.getElementById("lblInstrument").innerHTML = "इंस्ट्रूमेंट  विवरण";
        document.getElementById("lblbankname").innerHTML = "बैक का नाम";
        document.getElementById("lblbankbranch").innerHTML = "बैक शाखा ";
        document.getElementById("lblchqno").innerHTML = "डीडी नम्बर";
        document.getElementById("lblchqdate").innerHTML = "डीडी  दिनांक";
        document.getElementById("lblchequeamount").innerHTML = "राशि";
        document.getElementById("lblAgencyType").innerHTML = "ऐजेंन्सी का प्रकार ";
        document.getElementById("lblagency").innerHTML = "ऐजेंन्सी";
        document.getElementById("lblAdvanceamount").innerHTML = "कुल रसीद राशि";
        document.getElementById("lbldeductions").innerHTML = "कटोतियॉ ";
        document.getElementById("lbltds").innerHTML = "टी.डी.एस. ";
        document.getElementById("lbldeduction_commission").innerHTML = "कमिशन  ";
        document.getElementById("lbldeduction_other").innerHTML = "अन्य";
        document.getElementById("lblreceiptdetails").innerHTML = "रसीद विवरण ";
        document.getElementById("lblreceiptdetails_chequeno").innerHTML = "डीडी / यूटीआर  न. ";
        document.getElementById("lblreceiptdetails_amount").innerHTML = "राशि";
        document.getElementById("btnreceiptdetails_Add").value = "जोडें";
        document.getElementById("lblaction").innerHTML = "अन्य विवरण ";
        document.getElementById("lblactiontakendate").innerHTML = "प्रतिक्रिया दिनांक";
        document.getElementById("lblRemark").innerHTML = "रिमार्क ";
        document.getElementById("btnnew").value = "नया";
        document.getElementById("btnedit").value = "सुधारे";
        if (document.getElementById("lbluploaddepasitslip") != null) {
            document.getElementById("lbluploaddepasitslip").innerHTML = "अपलोड डिपोज़िट स्लिप";
            document.getElementById("lbluploaddepasitslip").className = "Frm_Txt_Hindi";
        }

        if (document.getElementById("lblNote") != null) {
            document.getElementById("lblNote").innerHTML = "नोट :-";
            document.getElementById("lblNote").className = "Frm_Txt_Hindi";
        }

        if (document.getElementById("lblnoteDetail") != null) {
            document.getElementById("lblnoteDetail").innerHTML = "फाईल का प्रकार JPG,JPEG,PNG,GIF,PDF मेँ हो और इसकी साईज़ 512 KB से ज्यादा ना हो । ";
            document.getElementById("lblnoteDetail").className = "Frm_Txt_Hindi";
        }

        document.getElementById("lblForwarededFor").innerHTML = "प्रतिक्रिया";
        document.getElementById("lblForwarededFor").className = "Frm_Txt_Hindi";
        if (document.getElementById("lblForwardTo") != null) {
            document.getElementById("lblForwardTo").innerHTML = "अग्रेषित कर्मचारी";
            document.getElementById("lblForwardTo").className = "Frm_Txt_Hindi";
        }
        if (document.getElementById("btnreprintdepositslip") != null) {
            document.getElementById("btnreprintdepositslip").value = "डिपोज़िट स्लिप पुनः प्रिंट करे";
            document.getElementById("btnreprintdepositslip").className = "btn_Hindi";
        }
        if (document.getElementById("btnreturn") != null) {
            document.getElementById("btnreturn").value = "वापस भेजे ";
            document.getElementById("btnreturn").className = "btn_Hindi";
        }
        if (document.getElementById("btnreprintreceipt") != null) {
            document.getElementById("btnreprintreceipt").value = "रसीद पुनः प्रिंट करे";
            document.getElementById("btnreprintreceipt").className = "btn_Hindi";
        }
        document.getElementById("btnsave").value = "रक्षित करें ";
        document.getElementById("btnsave").className = "btn_Hindi";
        
        document.getElementById("btnAddAgency").value = "ऐजेंसी बनाऐं";
        document.getElementById("btnAddAgency").className = "btn_Hindi";

        // Hindi,English Radio button code
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblreceiptno").className = "Frm_Txt_Hindi";
        document.getElementById("lblreceipttype").className = "Frm_Txt_Hindi";
        document.getElementById("lblreceiptno").className = "Frm_Txt_Hindi";
        document.getElementById("lblReceiptdate").className = "Frm_Txt_Hindi";
        document.getElementById("lblInstrument").className = "Frm_Txt_Hindi";
        document.getElementById("lblbankname").className = "Frm_Txt_Hindi";
        document.getElementById("lblbankbranch").className = "Frm_Txt_Hindi";
        document.getElementById("lblchqno").className = "Frm_Txt_Hindi";
        document.getElementById("lblchqdate").className = "Frm_Txt_Hindi";
        document.getElementById("lblchequeamount").className = "Frm_Txt_Hindi";
        document.getElementById("lblAgencyType").className = "Frm_Txt_Hindi";
        document.getElementById("lblagency").className = "Frm_Txt_Hindi";
        document.getElementById("lblAdvanceamount").className = "Frm_Txt_Hindi";
        document.getElementById("btnsave").className = "btn_Hindi";
        document.getElementById("lblreceiptdetails").className = "Frm_Txt_Hindi";
        document.getElementById("lblreceiptdetails_chequeno").className = "Frm_Txt_Hindi";
        document.getElementById("lblreceiptdetails_amount").className = "Frm_Txt_Hindi";
        document.getElementById("btnreceiptdetails_Add").className = "btn_Hindi";
        document.getElementById("lblaction").className = "Frm_Txt_Hindi";
        document.getElementById("lblactiontakendate").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemark").className = "Frm_Txt_Hindi";
        document.getElementById("btnnew").className = "btn_Hindi";
        document.getElementById("btnedit").className = "btn_Hindi";
        document.getElementById("btnsave").className = "btn_Hindi";
        document.getElementById("lbldeductions").className = "Frm_Txt_Hindi";
        document.getElementById("lbltds").className = "Frm_Txt_Hindi";
        document.getElementById("lbldeduction_commission").className = "Frm_Txt_Hindi";
        document.getElementById("lbldeduction_other").className = "Frm_Txt_Hindi";

        //Radio Button Code Start
        var Cash = document.getElementById("rbCash");
        var RB = Cash.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "रोकङ राशि";
        RB[0].className = "Frm_Txt_Hindi";

        var Cheque = document.getElementById("rbCheque");
        var RB = Cheque.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "डीडी";
        RB[0].className = "Frm_Txt_Hindi";

        var payment = document.getElementById("rbepayment");
        var RB = payment.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "ई-पेमेंट";
        RB[0].className = "Frm_Txt_Hindi";

        if (document.getElementById("rbCash").checked == true) {
            // Grid Code Start Cash Ammount Grid
            var table = document.getElementById("Gvcashdetails");
            var tr = table.rows[0];
            tr.cells[0].innerHTML = "रु";
            tr.cells[1].innerHTML = "स्वीकार";
            tr.cells[2].innerHTML = "सम";
            tr.cells[3].innerHTML = "वापसी";
            tr.cells[4].innerHTML = "सम";
            //============Hindi Text================//
            tr.cells[0].className = "Frm_Txt_Hindi";
            tr.cells[1].className = "Frm_Txt_Hindi";
            tr.cells[2].className = "Frm_Txt_Hindi";
            tr.cells[3].className = "Frm_Txt_Hindi";
            tr.cells[4].className = "Frm_Txt_Hindi";

            document.getElementById("btnsavecashdetail").value = "रक्षित करें";
        }
        if (document.getElementById("rbCheque").checked == true) {
            document.getElementById("lblchqno").innerHTML = "चेक / डीडी नम्बर";
            document.getElementById("lblchqdate").innerHTML = "चेक / डीडी  दिनांक";
            var table = document.getElementById("gvBank");
            var tr = table.rows[0];
            tr.cells[1].innerHTML = "हटाये";
            tr.cells[2].innerHTML = "बैक का नाम";
            tr.cells[3].innerHTML = "बैक शाखा ";
            tr.cells[4].innerHTML = "चेक / डीडी नम्बर";
            tr.cells[5].innerHTML = "चेक / डीडी  दिनांक";
            tr.cells[6].innerHTML = "राशि";
            //============Hindi Text================//
            tr.cells[1].className = "Frm_Txt_Hindi";
            tr.cells[2].className = "Frm_Txt_Hindi";
            tr.cells[3].className = "Frm_Txt_Hindi";
            tr.cells[4].className = "Frm_Txt_Hindi";
            tr.cells[5].className = "Frm_Txt_Hindi";
            tr.cells[6].className = "Frm_Txt_Hindi";
        }
        else {
            document.getElementById("lblchqno").innerHTML = "यूटीआर  न. ";
            document.getElementById("lblchqdate").innerHTML = "यूटीआर दिनांक ";
            var table = document.getElementById("gvBank");
            var tr = table.rows[0];
            tr.cells[1].innerHTML = "हटाये";
            tr.cells[2].innerHTML = "बैक का नाम";
            tr.cells[3].innerHTML = "बैक शाखा";
            tr.cells[4].innerHTML = "यूटीआर न. ";
            tr.cells[5].innerHTML = "यूटीआर दिनांक ";
            tr.cells[6].innerHTML = "राशि";
            //============Hindi Text================//
            tr.cells[1].className = "Frm_Txt_Hindi";
            tr.cells[2].className = "Frm_Txt_Hindi";
            tr.cells[3].className = "Frm_Txt_Hindi";
            tr.cells[4].className = "Frm_Txt_Hindi";
            tr.cells[5].className = "Frm_Txt_Hindi";
            tr.cells[6].className = "Frm_Txt_Hindi";
        }
    }

    if (Choice == 1 && FormId == 906) {
        if (document.getElementById("rbCheque").checked == true) {
            document.getElementById("lblchqno").innerHTML = "Cheque/DD/No";
            document.getElementById("lblchqdate").innerHTML = "Cheque/DD/Date";
            var table = document.getElementById("gvBank");
            var tr = table.rows[0];
            tr.cells[1].innerHTML = "Delete";
            tr.cells[2].innerHTML = "Bank Name";
            tr.cells[3].innerHTML = "Bank Place";
            tr.cells[4].innerHTML = "Cheque/DD/No";
            tr.cells[5].innerHTML = "Cheque/DD/Date";
            tr.cells[6].innerHTML = "Amount";
        }
        else {
            document.getElementById("lblchqno").innerHTML = "Transaction no.";
            document.getElementById("lblchqdate").innerHTML = "Transaction Date";
            var table = document.getElementById("gvBank");
            var tr = table.rows[0];
            tr.cells[1].innerHTML = "Delete";
            tr.cells[2].innerHTML = "Bank Name";
            tr.cells[3].innerHTML = "Bank Place";
            tr.cells[4].innerHTML = "Transaction no.";
            tr.cells[5].innerHTML = "Transaction Date";
            tr.cells[6].innerHTML = "Amount";
        }
    }
    if (Choice == 0 && FormId == 906) {
        // Grid Code Start Bottom Grid
        var table = document.getElementById("gvReceiptDtl");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "विवरण";
        tr.cells[1].innerHTML = "बिल नंबर";
        tr.cells[2].innerHTML = "बिल दिनांक";
        tr.cells[3].innerHTML = "वित्तीय वर्ष";
        tr.cells[4].innerHTML = "देय राशि";
        tr.cells[5].innerHTML = "प्राप्त राशि";
        tr.cells[6].innerHTML = "चेक नंबर";
        //============Hindi Text================//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
        tr.cells[5].className = "Frm_Txt_Hindi";
        tr.cells[6].className = "Frm_Txt_Hindi";
    }
    //Form ID 911, Form Name:BillManagement/frm_receipt_cancel.aspx
    if (Choice == 0 && FormId == 911) {
        document.getElementById("LblHeader").innerHTML = "रसीद रद्द करे";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("lblReceiptN").innerHTML = "रसीद नंबर";
        document.getElementById("lblagencytype").innerHTML = "ऐजेंसी का प्रकार";
        document.getElementById("lblSponsor").innerHTML = "ऐजेंसी";
        document.getElementById("lblfinyear").innerHTML = "वित्तीय वर्ष";
        document.getElementById("LblCancelDate").innerHTML = "रसीद रद्द दिनांक";
        document.getElementById("lblReceiptNos").innerHTML = "रसीद  नम्बर डाले";
        document.getElementById("btnshow").value = "रसीद नंबर भरें";
        document.getElementById("btnshowdetails").value = "रसीद देखें";
        document.getElementById("btncancelreceipt").value = "रसीद रद्द करें";
        document.getElementById("lblor").innerHTML = "अथवा";
        // Hindi Font Increase code
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblReceiptN").className = "Frm_Txt_Hindi";
        document.getElementById("lblagencytype").className = "Frm_Txt_Hindi";
        document.getElementById("lblSponsor").className = "Frm_Txt_Hindi";
        document.getElementById("lblfinyear").className = "Frm_Txt_Hindi";
        document.getElementById("LblCancelDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblReceiptNos").className = "Frm_Txt_Hindi";
        document.getElementById("btnshow").className = "btn_Hindi";
        document.getElementById("btnshowdetails").className = "btn_Hindi";
        document.getElementById("btncancelreceipt").className = "btn_Hindi";
        document.getElementById("lblor").className = "Frm_Txt_Hindi";
    }
    if (Choice == 0 && FormId == 905) {
        document.getElementById("LblHeader").innerHTML = "दैंनिक संग्रहण पंजी";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        //document.getElementById("lblScheme").innerHTML = "स्कीम";
        document.getElementById("lbldate").innerHTML = "दिनांक से";
        document.getElementById("lbltodate").innerHTML = "दिनांक तक";
        document.getElementById("btnshow").value = "देखें";
        document.getElementById("btnprint").value = "प्रिंट करें";
        document.getElementById("btnsave").value = "वाउचर रक्षित करें";
        document.getElementById("btncancelvoucher").value = "वाउचर रद्द करें";
        // Hindi Font Increase code
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("lbldate").className = "Frm_Txt_Hindi";
        document.getElementById("lbltodate").className = "Frm_Txt_Hindi";
        document.getElementById("btnshow").className = "btn_Hindi";
        document.getElementById("btnprint").className = "btn_Hindi";
        document.getElementById("btnsave").className = "btn_Hindi";
        document.getElementById("btncancelvoucher").className = "btn_Hindi";

        // Grid Code Start
        var table = document.getElementById("gvcollectionregister");
        var tr = table.rows[0];
        document.getElementById("gvcollectionregister_ctl01_chkSelectAll").nextSibling.innerHTML = "सभी चुनें"; ;
        tr.cells[1].innerHTML = "रसीद दिनांक";
        tr.cells[2].innerHTML = "रसीद न.";
        tr.cells[3].innerHTML = "भुगतानकर्ता";
        tr.cells[4].innerHTML = "रसीद का प्रकार";
        tr.cells[5].innerHTML = "बिल न.";
        tr.cells[6].innerHTML = "नगद राशि";
        tr.cells[7].innerHTML = "इंस्ट्रुमेंट न.";
        tr.cells[8].innerHTML = "बैंक नाम";
        tr.cells[9].innerHTML = "इंस्ट्रुमेंट तिथि";
        tr.cells[10].innerHTML = "राशि";
        // Hindi Font Increase code
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
        tr.cells[5].className = "Frm_Txt_Hindi";
        tr.cells[6].className = "Frm_Txt_Hindi";
        tr.cells[7].className = "Frm_Txt_Hindi";
        tr.cells[8].className = "Frm_Txt_Hindi";
        tr.cells[9].className = "Frm_Txt_Hindi";
        tr.cells[10].className = "Frm_Txt_Hindi";
    }
    //Form ID 904, Form Name:BillManagement/frmchequedeposit.aspx
    if (Choice == 0 && FormId == 904) {
        document.getElementById("LblHeader").innerHTML = "चेक जमा पर्ची";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        // document.getElementById("lblScheme").innerHTML = "स्कीम";
        document.getElementById("lblfromdate").innerHTML = "दिनांक से";
        document.getElementById("lbltodate").innerHTML = "दिनांक तक";
        document.getElementById("lbldateofdeposit").innerHTML = "जमा दिनांक";
        document.getElementById("btnshow").value = "देखें";
        document.getElementById("btnsave").value = "रक्षित करें";

        document.getElementById("btnprintdepositslip").value = "प्रिंट डिपोजिट स्लिप   ";


        //============Hindi Text Increase================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("lblfromdate").className = "Frm_Txt_Hindi";
        document.getElementById("lbltodate").className = "Frm_Txt_Hindi";
        document.getElementById("lbldateofdeposit").className = "Frm_Txt_Hindi";
        document.getElementById("btnshow").className = "btn_Hindi";
        document.getElementById("btnsave").className = "btn_Hindi";

        document.getElementById("btnprintdepositslip").className = "btn_Hindi";

        // Grid Code Start
        var table = document.getElementById("gvchequedeposit");
        var tr = table.rows[0];
        document.getElementById("gvchequedeposit_ctl01_chkSelectAll").nextSibling.innerHTML = "सभी चुने";
        tr.cells[1].innerHTML = "रसीद दिनांक";
        tr.cells[2].innerHTML = "रसीद न.";
        tr.cells[3].innerHTML = "रसीद का प्रकार";
        tr.cells[4].innerHTML = "बैंक नाम";
        tr.cells[5].innerHTML = "इंस्ट्रुमेंट न.";
        tr.cells[6].innerHTML = "तिथि";
        tr.cells[7].innerHTML = "राशि";
        tr.cells[8].innerHTML = "जमा बैंक का नाम ";
        //============Hindi Text================//
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
        tr.cells[5].className = "Frm_Txt_Hindi";
        tr.cells[6].className = "Frm_Txt_Hindi";
        tr.cells[7].className = "Frm_Txt_Hindi";
        tr.cells[8].className = "Frm_Txt_Hindi";
    }
    // Bill Master Hindi Label Managed Code Start
    //Form ID 901, Form Name:BillManagement/frm_showreport.aspx(Daily Collection) 
    if (Choice == 0 && FormId == 901) {
        document.getElementById("LblHeader").innerHTML = "दैनिक संग्रह विवरण रिपोर्ट";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        if (document.getElementById("lblSelectBankName") != null) {
            document.getElementById("lblSelectBankName").innerHTML = "बैंक का नाम ";
            document.getElementById("lblSelectBankName").className = "Frm_Txt_Hindi";
        }
        if (document.getElementById("lblSelectACNo") != null) {
            document.getElementById("lblSelectACNo").innerHTML = "खाता क्रमांक ";
            document.getElementById("lblSelectACNo").className = "Frm_Txt_Hindi";
        }
        if (document.getElementById("lblScheme") != null) {
            document.getElementById("lblScheme").innerHTML = "स्कीम";
        }
        document.getElementById("lbldate").innerHTML = "संग्रह दिनांक";
        document.getElementById("btnshow").value = "देखें";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";
        //font increase ===//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        if (document.getElementById("lblScheme") != null) {
            document.getElementById("lblScheme").className = "Frm_Txt_Hindi";
        }
        document.getElementById("lbldate").className = "Frm_Txt_Hindi";
        document.getElementById("btnshow").className = "btn_Hindi";
    }
    if (Choice == 1 && FormId == 901) {
        if (document.getElementById("rbenglish").checked == true) {
            document.getElementById("LblHeader").innerHTML = "Daily Collection Details Report";
            document.getElementById("lbldate").innerHTML = "Collection Date";
        }
    }
    //Form ID 904, Form Name:YF_Configuration/Frm_Disbursement_Ledger_Configuration.aspx
    if (Choice == 0 && FormId == 2527) {
        document.getElementById("LblHeader").innerHTML = "सहायता लेजर्स कॉन्फीगरेशन ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        if (document.getElementById("hlLogoff") != null) {
            document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        }
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("lblScheme").innerHTML = "स्कीम का नाम";
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("chkAllBranch").nextSibling.innerHTML = " सभी शाखाओ के लिये";
        var table = document.getElementById("gvWorkSelectionUnderScheme");
        var tr = table.rows[0];
        // document.getElementById("GridView1_ctl01_chkSelectAll").nextSibling.innerHTML = "स्कीम";
        tr.cells[0].innerHTML = "चुनें";
        tr.cells[2].innerHTML = "लेजर्स ";

        //=============Font Size=============//

        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("chkAllBranch").nextSibling.className = "Frm_Txt_Hindi";
        var table = document.getElementById("gvWorkSelectionUnderScheme");
        var tr = table.rows[0];
        // document.getElementById("GridView1_ctl01_chkSelectAll").nextSibling.innerHTML = "स्कीम";
        tr.cells[0].className = "Frm_Head_Hindi";
        tr.cells[2].className = "Frm_Head_Hindi";
        tr.cells[3].className = "Frm_Head_Hindi";
    }
    //Form ID 2238, Form Name:FinancialReports/CAG_Reports/rpt_Statement_Receivable.aspx
    if (Choice == 0 && FormId == 2238) {
        document.getElementById("LblHeader").innerHTML = "प्राप्ति विवरण";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("lblCAGFormat").innerHTML = "सी एन्ड ऐ जी फाँरमेट - IV";
        document.getElementById("lblFdate").innerHTML = "दिनांक से";
        document.getElementById("lblToDate").innerHTML = "दिनांक तक";
        document.getElementById("ChkAll").nextSibling.innerHTML = " सभी चुनें";
        document.getElementById("lblSchemeName").innerHTML = "स्कीम का नाम";
        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        //=======Hindi Text ============//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblCAGFormat").className = "Frm_Txt_Hindi";
        document.getElementById("lblFdate").className = "Frm_Txt_Hindi";
        document.getElementById("lblToDate").className = "Frm_Txt_Hindi";
        document.getElementById("ChkAll").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("lblSchemeName").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("lblStates").className = "Frm_Txt_Hindi";
        document.getElementById("lblDistricts").className = "Frm_Txt_Hindi";
        document.getElementById("lblBklocks").className = "Frm_Txt_Hindi";
        document.getElementById("lblGramPanchayats").className = "Frm_Txt_Hindi";
        document.getElementById("lblVillages").className = "Frm_Txt_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";

        // Default and Branch Radio button code
        var Default = document.getElementById("RbWithBranch");
        var RB = Default.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " उप शाखा सहित";
        RB[0].className = "Frm_Txt_Hindi";

        var custom = document.getElementById("RbWithoutBranch");
        var RB = custom.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " उप शाखा रहित";
        RB[0].className = "Frm_Txt_Hindi";


        if (document.getElementById("RbWithBranch").checked == true) {
            //            document.getElementById("btnGo").value = "देखें";
            //            document.getElementById("lblPanchayatCode").innerHTML = "पंचायत कोड";
            //            document.getElementById("lbFindBranchCode").innerHTML = "शाखा कोड देखें";
            //            // Fint Size Increase code
            //            document.getElementById("btnGo").className = "btn_Hindi";
            //            document.getElementById("lblPanchayatCode").className = "Frm_Txt_Hindi";
        }
    }

    //****************YF_Report/rpt_bank_branch_master.aspx******
    if (Choice == 0 && FormId == 2523) {
        document.getElementById("LblHeader").innerHTML = "बैंक शाखा मास्टर रिपोर्ट";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("lblBankName").innerHTML = "बैंक का नाम ";
        document.getElementById("btnShow").value = "रिपोर्ट देखें";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";

        //=============Hindi Font Increase=============//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblBankName").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";
        //=============RB Hindi Font Increase=============//
        var Default = document.getElementById("RbWithBranch");
        var RB = Default.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " उप शाखा सहित";
        RB[0].className = "Frm_Txt_Hindi";

        var custom = document.getElementById("RbWithoutBranch");
        var RB = custom.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " उप शाखा रहित";
        RB[0].className = "Frm_Txt_Hindi";
    }

    // YF_Report/rpt_bank_account_master.aspx
    if (Choice == 0 && FormId == 2524) {
        document.getElementById("LblHeader").innerHTML = "बैंक खाता मास्टर रिपोर्ट";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("lblBankName").innerHTML = "बैंक का नाम ";
        document.getElementById("lblBranchName").innerHTML = "शाखा का नाम ";
        //document.getElementById("lblSchemeName").innerHTML = "स्कीम का नाम ";
        document.getElementById("btnShow").value = "रिपोर्ट देखें";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";

        //=============Hindi Font Increase=============//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblBankName").className = "Frm_Txt_Hindi";
        document.getElementById("lblBranchName").className = "Frm_Txt_Hindi";
        //document.getElementById("lblSchemeName").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";
        //=============RB Hindi Font Increase=============//
        var Default = document.getElementById("RbWithBranch");
        var RB = Default.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " उप शाखा सहित";
        RB[0].className = "Frm_Txt_Hindi";

        var custom = document.getElementById("RbWithoutBranch");
        var RB = custom.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " उप शाखा रहित";
        RB[0].className = "Frm_Txt_Hindi";
    }

    //Form ID 2516, Form Name:YF_Reports/rpt_Assets_Register.aspx
    if (Choice == 0 && FormId == 2516) {
        //document.getElementById("LblHeader").innerHTML = "असेट रजिस्टर रिपोर्ट ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        if (document.getElementById("hlLogoff") != null) {
            document.getElementById("hlLogoff").innerHTML = "| लॉगआउट";
        }
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("lblFdate").innerHTML = "दिनांक तक ";
        if (document.getElementById("lblLedger") != null) {
            document.getElementById("lblLedger").innerHTML = "लेजर ";
        }
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("btnShow").value = "देखें ";
        document.getElementById("LblScheme").innerHTML = "स्कीम चुनें";
        document.getElementById("LblScheme").innerHTML = "स्कीम का नाम";
        document.getElementById("ChkAll").nextSibling.innerHTML = "सभी चुने"
        var Default = document.getElementById("RbWithBranch");
        var RB = Default.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " उप शाखा सहित";
        RB[0].className = "Frm_Txt_Hindi";

        var custom = document.getElementById("RbWithoutBranch");
        var RB = custom.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " उप शाखा रहित";
        RB[0].className = "Frm_Txt_Hindi";

        //============Hindi Text================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblFdate").className = "Frm_Txt_Hindi";
        // document.getElementById("lblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("btnshow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        if (document.getElementById("lblLedger") != null) {
            document.getElementById("lblLedger").className = "btn_Hindi";
        }
        document.getElementById("LblScheme").className = "btn_Hindi";
        document.getElementById("LblScheme").className = "btn_Hindi";
    }
    //2559 YF_Master/frm_LedgerOpening.aspx
    if (Choice == 0 && FormId == 2559) {
        document.getElementById("LblHeader").innerHTML = "लेजर का प्रारंभिक शेष";
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
        document.getElementById("btnClose").value = "रद्द करें";
        document.getElementById("lblAgencyType").innerHTML = "एजेंसी का प्रकार चुनें";
        document.getElementById("lblSearchAgency").innerHTML = "एजेंसी खोजें :";
        document.getElementById("lblAgencies").innerHTML = "एजेंसी";
        document.getElementById("lblLedgers").innerHTML = "लेजर्स";
        document.getElementById("btnSaveDetail").value = "रक्षित करें";
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("btnSaveCategory").value = "रक्षित करें";
    }
    //Form ID 1758, Form Name:YF_Configuration/frm_Report_Configuration.aspx

    if (Choice == 0 && FormId == 1758) {
        try {
            document.getElementById("LblHeader").innerHTML = "रिपोर्ट कॉन्फीगरेशन";
            document.getElementById("hlHome").innerHTML = "होमपेज";
            document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
            // Hindi,English Radio button code
            var RBHindi = document.getElementById("rbHindi");
            var RB = RBHindi.parentNode.getElementsByTagName("label");
            RB[0].innerHTML = "हिन्दी";

            var RBenglish = document.getElementById("rbenglish");
            var RB = RBenglish.parentNode.getElementsByTagName("label");
            RB[0].innerHTML = "English";

            document.getElementById("lblConfigType").innerHTML = "कॉन्फीगरेशन का प्रकार";
            document.getElementById("lblLedgerEffectiveDt").innerHTML = "प्रभावित तिथि";
            document.getElementById("btnLedgerType_Save").value = "रक्षित करें";
            document.getElementById("lblLedgerType").innerHTML = "लेजर का प्रकार";
            document.getElementById("chkDefaultSetting_LedgerType").nextSibling.innerHTML = " सामान्य सभी शाखाओ के लिये";

            //-----------Font size-------------//
            document.getElementById("lblConfigType").className = "Frm_Txt_Hindi";
            document.getElementById("lblLedgerEffectiveDt").className = "Frm_Txt_Hindi";
            document.getElementById("btnLedgerType_Save").className = "btn_Hindi";
            document.getElementById("lblLedgerType").className = "Frm_Txt_Hindi";
            document.getElementById("chkDefaultSetting_LedgerType").nextSibling.className = "Frm_Txt_Hindi";

            //-----------Grid gridLedger Code-------------//
            if (document.getElementById("gv_LedgerTypeConfig") != null) {
                var table = document.getElementById("gv_LedgerTypeConfig");
                var tr = table.rows[0];
                tr.cells[0].innerHTML = "चुनिये";
                tr.cells[1].innerHTML = "हटायें";
                tr.cells[2].innerHTML = "कॉन्फीगरेशन नाम";
                tr.cells[3].innerHTML = "प्रभावित तिथि";
                //=======Hindi Text ============//
                tr.cells[0].className = "Frm_Txt_Hindi";
                tr.cells[1].className = "Frm_Txt_Hindi";
                tr.cells[2].className = "Frm_Txt_Hindi";
                tr.cells[3].className = "Frm_Txt_Hindi";
            }
            document.getElementById("lblHeadLedgerName").innerHTML = "लेजर का नाम";
            document.getElementById("lblHeadLedgerName").className = "Frm_Txt_Hindi";
        }
        catch (e) {
            return true;
        }
    }
    //=Form ID 2560, Form Name:HRManagement/Master/frm_Pay_Bill_Voucher.aspx
    if (Choice == 0 && FormId == 2560) {
        document.getElementById("LblHeader").innerHTML = "वेतन पत्रक वाउचर";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("btnEdit").value = "सुधारें";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("BtnSave").value = "अंनतिम रक्षित";
        document.getElementById("btnFinalSave").value = "अतिंम रक्षित";
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("BtnExit").value = "बाहर निकलें";
        document.getElementById("lblPayBillNo").innerHTML = "वेतन पत्रक नंबर";
        document.getElementById("lblPayBill").innerHTML = "वेतन पत्रक जनरेट";
        document.getElementById("lblScheme").innerHTML = "स्कीम का नाम";
        document.getElementById("lblPHeader").innerHTML = "वेतन शीर्षक";
        document.getElementById("lblBillDate").innerHTML = "देयक तिथि";
        document.getElementById("lblPayBillNo").innerHTML = "देयक नंबर";
        document.getElementById("lblChequeNo").innerHTML = "चेक नबंर";
        document.getElementById("lblAgency").innerHTML = "एजेंसी ";
        document.getElementById("lbl_BankName").innerHTML = "बैंक का नाम";
        //document.getElementById("lblFromDate0").innerHTML = "माह";
        // document.getElementById("lblFromDate2").innerHTML = "वर्ष";
        document.getElementById("btnAddAgency").value = "एजेंसी जोडें";
        document.getElementById("btnShow").value = "एजेंसी देखें";
        //============Hindi Text================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("BtnSave").className = "btn_Hindi";
        document.getElementById("btnFinalSave").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("BtnExit").className = "btn_Hindi";
        document.getElementById("lblPayBillNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblPayBill").className = "Frm_Txt_Hindi";
        document.getElementById("lblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("lblPHeader").className = "Frm_Txt_Hindi";
        document.getElementById("lblBillDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblPayBillNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblChequeNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblAgency").className = "Frm_Txt_Hindi";
        document.getElementById("lbl_BankName").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnAddAgency").className = "btn_Hindi";
        //  document.getElementById("lblFromDate0").className = "Frm_Txt_Hindi";
        //  document.getElementById("lblFromDate2").className = "Frm_Txt_Hindi";

        document.getElementById("lblPrtMess").innerHTML = "क्या  आप वेतन पत्रक सभी अनचेक पंक्तियों के साथ प्रिंट करना चाहते है ?";
        document.getElementById("btnYes").value = "हॉ";
        document.getElementById("btnNo").value = "नही";
        document.getElementById("btnCncl").value = "रद्द करें";
        //============Hindi Text================//
        document.getElementById("lblPrtMess").className = "Frm_Txt_Hindi";
        document.getElementById("btnYes").className = "btn_Hindi";
        document.getElementById("btnNo").className = "btn_Hindi";
        document.getElementById("btnCncl").className = "btn_Hindi";

        document.getElementById("lblGrossPayment").innerHTML = "सकल भुगतान ";
        document.getElementById("lblGrossDeduction").innerHTML = "सकल कटौती";
        document.getElementById("lblNetTotal").innerHTML = "कुल देय राशि";
        //============Hindi Text================//
        document.getElementById("lblGrossPayment").className = "Frm_Txt_Hindi";
        document.getElementById("lblGrossDeduction").className = "Frm_Txt_Hindi";
        document.getElementById("lblNetTotal").className = "Frm_Txt_Hindi";

        document.getElementById("lblPrtMess").innerHTML = "क्या  आप वेतन पत्रक सभी अनचेक पंक्तियों के साथ प्रिंट करना चाहते है ?";
        document.getElementById("btnYes").value = "हॉ";
        document.getElementById("btnNo").value = "नही";
        document.getElementById("btnCncl").value = "रद्द करें";
        //============Hindi Text================//
        document.getElementById("lblPrtMess").className = "Frm_Txt_Hindi";
        document.getElementById("btnYes").className = "btn_Hindi";
        document.getElementById("btnNo").className = "btn_Hindi";
        document.getElementById("btnCncl").className = "btn_Hindi";
    }
    //Form ID 2561, YF_Report/Rpt_SOE_Form_1B.aspx
    if (Choice == 0 && FormId == 2561) {
        document.getElementById("LblHeader").innerHTML = "SOE Form 1-B";
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
        document.getElementById("lblTodate").innerHTML = "दिनांक तक ";
        document.getElementById("lblScheme").innerHTML = "स्कीम चुने";
        document.getElementById("btnShow").value = "रिपोर्ट देखें";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";
        //==============Hindi Font Increase==================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblFdate").className = "Frm_Txt_Hindi";
        document.getElementById("lblTodate").className = "Frm_Txt_Hindi";
        document.getElementById("lblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";
    }

    //Form ID 2561, YF_Report/Rpt_SOE_Form_1B.aspx
    if (Choice == 0 && FormId == 2562) {
        document.getElementById("LblHeader").innerHTML = "SOE Form 1-C";
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
        document.getElementById("lblTodate").innerHTML = "दिनांक तक ";
        document.getElementById("lblScheme").innerHTML = "स्कीम चुने";
        document.getElementById("btnShow").value = "रिपोर्ट देखें";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";
        //==============Hindi Font Increase==================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblFdate").className = "Frm_Txt_Hindi";
        document.getElementById("lblTodate").className = "Frm_Txt_Hindi";
        document.getElementById("lblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";
    }

    //Form ID 2563, YF_Report/Rpt_Abstract_of_summary_Sheet.aspx
    if (Choice == 0 && FormId == 2563) {
        document.getElementById("LblHeader").innerHTML = "Abstract of Summary Sheet";
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
        document.getElementById("lblTodate").innerHTML = "दिनांक तक ";
        document.getElementById("lblScheme").innerHTML = "स्कीम चुने";
        document.getElementById("btnShow").value = "रिपोर्ट देखें";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";
        //==============Hindi Font Increase==================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblFdate").className = "Frm_Txt_Hindi";
        document.getElementById("lblTodate").className = "Frm_Txt_Hindi";
        document.getElementById("lblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";
    }
    //Form ID 2564, Form Name:/frm_Cancel_Paybill_Voucher.aspx
    if (Choice == 0 && FormId == 2564) {
        document.getElementById("LblHeader").innerHTML = "वेतन पत्रक रद्द करे";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("lblfromdate").innerHTML = "दिनांक से";
        document.getElementById("lbltodate").innerHTML = "दिनांक तक";
        document.getElementById("lblScheme").innerHTML = "स्कीम चुने";
        document.getElementById("lblPaybillNo").innerHTML = "वेतन पत्रक नंबर";
        document.getElementById("btnCancelPaybillNew").value = "वेतन पत्रक नंबर रद्द करें";
        document.getElementById("btnCancelPaybill").value = "वाउचर रद्द करें";
        document.getElementById("btnDeletePaybill").value = "वेतन पत्रक नंबर हटाये ";
        // Hindi Font Increase code
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblfromdate").className = "Frm_Txt_Hindi";
        document.getElementById("lbltodate").className = "Frm_Txt_Hindi";
        document.getElementById("lblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("lblPaybillNo").className = "Frm_Txt_Hindi";
        document.getElementById("btnCancelPaybill").className = "btn_Hindi";
        document.getElementById("btnCancelPaybillNew").className = "btn_Hindi";
        document.getElementById("btnDeletePaybill").className = "btn_Hindi";
    }
    //Form ID 2571, Form Name:reports/yf_report/rpt_paybill.aspx
    if (Choice == 0 && FormId == 2571) {
        document.getElementById("LblHeader").innerHTML = "वेतन पत्रक रिपोर्ट";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("lblFromDate").innerHTML = "दिनांक से";
        document.getElementById("lblToDate").innerHTML = "दिनांक तक ";
        document.getElementById("lblScheme").innerHTML = "स्कीम चुने";
        document.getElementById("lblSchemeOption").innerHTML = "स्कीम विकल्प :-";
        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("BtnPrintExcel").value = "एक्सेल में रक्षित करें";
        //=========Hindi Font Increase==========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblFromDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblToDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("lblSchemeOption").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("BtnPrintExcel").className = "btn_Hindi";

        var FCRA = document.getElementById("rbFCRA");
        var RB = FCRA.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " एफ सी आर ए ";
        RB[0].className = "Frm_Txt_Hindi";

        var NonFCRA = document.getElementById("rbNonFCRA");
        var RB = NonFCRA.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " नाँन एफ सी आर ए";
        RB[0].className = "Frm_Txt_Hindi";

        var Both = document.getElementById("rbBoth");
        var RB = Both.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " दोनों";
        RB[0].className = "Frm_Txt_Hindi";
    }

    //Form ID 2601, Form Name:reports/yf_report/rpt_cheque_dd_eTransaction_Register.aspx
    if (Choice == 0 && FormId == 2601) {
        //  document.getElementById("LblHeader").innerHTML = "चेक / डीडी / ई-ट्रांजेक्शन रजिस्टर ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("lblFromDate").innerHTML = "दिनांक से";
        document.getElementById("lblToDate").innerHTML = "दिनांक तक ";
        document.getElementById("lblNote").innerHTML = "डीडी रिपोर्ट दिनांक तक प्राप्त नही हुआ ";
        document.getElementById("lblCancel").innerHTML = "रद्द रसीद  ";
        document.getElementById("lblReceiptType").innerHTML = "रसीद का प्रकार ";
        var RBCash = document.getElementById("rbCash");
        var RB1 = RBCash.parentNode.getElementsByTagName("label");
        RB1[0].innerHTML = " नगद";
        RB1[0].className = "Frm_Txt_Hindi";
        var RBDD = document.getElementById("rbDD");
        var RB2 = RBDD.parentNode.getElementsByTagName("label");
        RB2[0].innerHTML = " डीडी/ ई-ट्रांजेक्शन";
        RB2[0].className = "Frm_Txt_Hindi";
        //        document.getElementById("lblscheme").innerHTML = "स्कीम";
        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnCancel").value = "रद्द करें ";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("btncancelreceipt").value = "रसीद रद्द करें ";
        //=========Hindi Font Increase==========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblFromDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblNote").className = "Frm_Txt_Hindi";
        document.getElementById("lblCancel").className = "Frm_Txt_Hindi";
        document.getElementById("lblToDate").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("btncancelreceipt").className = "btn_Hindi";
        document.getElementById("lblscheme").className = "Frm_Txt_Hindi";
        document.getElementById("lblReceiptType").className = "Frm_Txt_Hindi";
        //        var FCRA = document.getElementById("rbFCRA");
        //        var RB = FCRA.parentNode.getElementsByTagName("label");
        //        RB[0].innerHTML = " एफ सी आर ए ";
        //        RB[0].className = "Frm_Txt_Hindi";

        //        var NonFCRA = document.getElementById("rbNonFCRA");
        //        var RB = NonFCRA.parentNode.getElementsByTagName("label");
        //        RB[0].innerHTML = " नाँन एफ सी आर ए";
        //        RB[0].className = "Frm_Txt_Hindi";

        //        var Both = document.getElementById("rbBoth");
        //        var RB = Both.parentNode.getElementsByTagName("label");
        //        RB[0].innerHTML = " दोनों";
        //        RB[0].className = "Frm_Txt_Hindi";
    }

    //===============Form ID 2598, Form Name:Panch_Transaction/frm_deposit_cheque.aspx

    if (Choice == 0 && FormId == 2598) {

        document.getElementById("LblHeader").innerHTML = "चेक / फंड इन ट्रांजिट जमा ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("lblScheme").innerHTML = "स्कीम ";
        document.getElementById("lblFinyear").innerHTML = "वित्तीय वर्ष ";
        document.getElementById("lblTransferFromBank").innerHTML = "चेक / फंड इन ट्रांजिट जमा करने  के लिए बैंक खाता  ";
        document.getElementById("lblFinyear").className = "Frm_Txt_Hindi";
        document.getElementById("lblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("lblTransferFromBank").className = "Frm_Txt_Hindi";


        document.getElementById("btnshow").value = "दिखाये ";
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btnCancel").value = "रद्द करें ";

        //=============Hindi Font Increase=============//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";

        document.getElementById("btnshow").className = "btn_Hindi";

        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";


        //Grid Code Start

        var table = document.getElementById("gvVoucher");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "क्र.";
        document.getElementById("gvVoucher_ctl01_chkSelectAll").nextSibling.innerHTML = "सभी चुनें"; ;
        //tr.cells[1].innerHTML = " सभी चुनें ";
        tr.cells[2].innerHTML = "तिथि  ";
        tr.cells[3].innerHTML = "वाउचर क्रमांक  ";
        tr.cells[4].innerHTML = "विवरण 	";
        tr.cells[5].innerHTML = "फंड हस्तांतरित करने वाला ";
        tr.cells[6].innerHTML = " राशि 	";
        tr.cells[7].innerHTML = "जमा तिथि ";
        // tr.cells[8].innerHTML = "खाता न.";


        //========Hindi Text========//
        //  tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
        tr.cells[5].className = "Frm_Txt_Hindi";
        tr.cells[6].className = "Frm_Txt_Hindi";
        tr.cells[7].className = "Frm_Txt_Hindi";

        //tr.cells[8].className = "Frm_Txt_Hindi";


    }

    //Frm_Work_Selection_UnderScheme.aspx
    if (Choice == 0 && FormId == 2519) {
        //document.getElementById("LblHeader").innerHTML = "योजना अंतर्गत कार्य का चुनाव ";
        document.getElementById("LblHeader").innerHTML = "योजना अंतर्गत कार्य का प्रकार और प्रकृति का चुनाव";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        if (document.getElementById("hlLogoff") != null) {
            document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        }
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("lblScheme").innerHTML = "स्कीम का नाम";
        document.getElementById("lblheadname").innerHTML = " हेड का नाम ";

        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btnCancel").value = "रद्द करें";

        var table = document.getElementById("gvWorkSelectionUnderScheme");
        var tr = table.rows[0];
        // document.getElementById("GridView1_ctl01_chkSelectAll").nextSibling.innerHTML = "स्कीम";
        tr.cells[0].innerHTML = "चुनें";
        tr.cells[2].innerHTML = "कार्य का प्रकार ";
        tr.cells[3].innerHTML = "कार्य की प्रकृति ";
        //=============Font Size=============//

        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        var table = document.getElementById("gvWorkSelectionUnderScheme");
        var tr = table.rows[0];
        // document.getElementById("GridView1_ctl01_chkSelectAll").nextSibling.innerHTML = "स्कीम";
        tr.cells[0].className = "Frm_Head_Hindi";
        tr.cells[2].className = "Frm_Head_Hindi";
        tr.cells[3].className = "Frm_Head_Hindi";
    }


    //frm_Advance_Ledger_Configuration.aspx
    if (Choice == 0 && FormId == 2613) {

        document.getElementById("LblHeader").innerHTML = "अग्रिम लेज़र कांफिगरेशन";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";


        var chkdefault = document.getElementById("chkDefault");
        var ch = chkdefault.parentNode.getElementsByTagName("label");
        ch[0].innerHTML = "सामान्य सभी शाखाओ के लिये";


        var chkisagency = document.getElementById("chkisAgency");
        var ch1 = chkisagency.parentNode.getElementsByTagName("label");
        ch1[0].innerHTML = "इज एजेंसी";


        var chkiscategory = document.getElementById("chkisCategory");
        var chk1 = chkiscategory.parentNode.getElementsByTagName("label");
        chk1[0].innerHTML = "इज श्रेणी";


        document.getElementById("btnsave_Ledger").value = "रक्षित करें";
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("lblConfigType").innerHTML = "कांफिगरेशन का प्रकार";
        document.getElementById("lblLedgerEffectiveDt").innerHTML = "प्रभावित तिथि";
        document.getElementById("lblLedgerType").innerHTML = "लेज़र का प्रकार";
        document.getElementById("lblLedger").innerHTML = "लेज़र का नाम";
        document.getElementById("lblCategory").innerHTML = "केटेगरी का नाम";
        //=======Hindi Text ============//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnsave_Ledger").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("lblConfigType").className = "Frm_Txt_Hindi";
        document.getElementById("lblLedgerEffectiveDt").className = "Frm_Txt_Hindi";
        document.getElementById("lblLedgerType").className = "Frm_Txt_Hindi";
        document.getElementById("lblLedger").className = "Frm_Txt_Hindi";
        document.getElementById("lblCategory").className = "Frm_Txt_Hindi";

        // Grid Code Start
        var table = document.getElementById("gridLedger");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "चुनियें";
        tr.cells[1].innerHTML = "हटाये";
        tr.cells[2].innerHTML = "स/क्र.";
        tr.cells[3].innerHTML = "कांफिगरेशन का नाम ";
        tr.cells[4].innerHTML = "प्रभावित तिथि";
        tr.cells[5].innerHTML = "लेज़र का नाम";
        tr.cells[6].innerHTML = "केटेगरी का नाम";

        //============Hindi Text================//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
        tr.cells[5].className = "Frm_Txt_Hindi";
        tr.cells[6].className = "Frm_Txt_Hindi";
    }

    //frm_Receipt_Configuration.aspx
    if (Choice == 0 && FormId == 2614) {

        document.getElementById("LblHeader").innerHTML = "रसीद कांफिगरेशन";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";


        var chkdefault = document.getElementById("chkDefault");
        var ch = chkdefault.parentNode.getElementsByTagName("label");
        ch[0].innerHTML = "सामान्य सभी शाखाओ के लिये";


        var chkall = document.getElementById("ChkAll");
        var cha = chkall.parentNode.getElementsByTagName("label");
        cha[0].innerHTML = "सभी चुने";

        var chkisagency = document.getElementById("chkisAgency");
        var ch1 = chkisagency.parentNode.getElementsByTagName("label");
        ch1[0].innerHTML = "इज एजेंसी";


        var chkiscategory = document.getElementById("chkisCategory");
        var chk1 = chkiscategory.parentNode.getElementsByTagName("label");
        chk1[0].innerHTML = "इज श्रेणी";


        document.getElementById("btnsave_Ledger").value = "रक्षित करें";
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("btnSaveReceipt").value = "रक्षित करें";
        document.getElementById("btnCancelReceipt").value = "रद्द करें";
        document.getElementById("ApplicationConfiguration").innerHTML = "रसीद कांफिगरेशन";
        document.getElementById("VoucherConfiguration").innerHTML = "रसीद का प्रकार ";
        document.getElementById("lblConfigType").innerHTML = "रसीद कांफिगरेशन";
        document.getElementById("lblLedgerEffectiveDt").innerHTML = "प्रभावित तिथि";
        document.getElementById("lblScheme").innerHTML = "कॉलम  चुने";
        document.getElementById("lblLedgerType").innerHTML = "लेज़र का प्रकार";
        document.getElementById("lblLedger").innerHTML = "लेज़र का नाम";
        document.getElementById("lblCategory").innerHTML = "केटेगरी का नाम";
        document.getElementById("lblReceiptName").innerHTML = "रसीद का प्रकार";
        document.getElementById("lblReceiptNameHindi").innerHTML = "रसीद का प्रकार (हिन्दी)";
        //=======Hindi Text ============//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnsave_Ledger").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("lblConfigType").className = "Frm_Txt_Hindi";
        document.getElementById("lblLedgerEffectiveDt").className = "Frm_Txt_Hindi";
        document.getElementById("lblLedgerType").className = "Frm_Txt_Hindi";
        document.getElementById("lblLedger").className = "Frm_Txt_Hindi";
        document.getElementById("lblCategory").className = "Frm_Txt_Hindi";
        document.getElementById("lblReceiptName").className = "Frm_Txt_Hindi";
        document.getElementById("lblReceiptNameHindi").className = "Frm_Txt_Hindi";
        document.getElementById("btnSaveReceipt").className = "btn_Hindi";
        document.getElementById("btnCancelReceipt").className = "btn_Hindi";

        // Grid Code Start
        var table = document.getElementById("gridLedger");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "चुनियें";
        tr.cells[1].innerHTML = "हटाये";
        tr.cells[2].innerHTML = "स/क्र.";
        tr.cells[3].innerHTML = "रसीद का नाम ";
        tr.cells[4].innerHTML = "प्रभावित तिथि";
        tr.cells[5].innerHTML = "लेज़र का प्रकार";
        tr.cells[6].innerHTML = "लेज़र का नाम";
        tr.cells[7].innerHTML = "केटेगरी का नाम";

        //============Hindi Text================//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
        tr.cells[5].className = "Frm_Txt_Hindi";
        tr.cells[6].className = "Frm_Txt_Hindi";

        // Grid Code Start
        var table = document.getElementById("gvReceipt");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "चुनियें";
        tr.cells[1].innerHTML = "हटाये";
        tr.cells[2].innerHTML = "स/क्र.";
        tr.cells[3].innerHTML = "रसीद का प्रकार ";
        tr.cells[4].innerHTML = "रसीद का प्रकार (हिन्दी)";

        //============Hindi Text================//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
    }
    //frm_fixDeposit.aspx
    if (Choice == 0 && FormId == 2617) {

        document.getElementById("LblHeader").innerHTML = "सावधि जमा";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";







        // creation,encashment Radio button code
        var RBcreation = document.getElementById("rbCreation");
        var RBC = RBcreation.parentNode.getElementsByTagName("label");
        RBC[0].innerHTML = "क्रिएशन";

        var RBencashment = document.getElementById("rbencashment");
        var RBE = RBencashment.parentNode.getElementsByTagName("label");
        RBE[1].innerHTML = "नगदीकरण";

        var RBencashment = document.getElementById("rbrenewal");
        var RBE = RBencashment.parentNode.getElementsByTagName("label");
        RBE[2].innerHTML = "नवीनीकरण";




        document.getElementById("btnnewcreation").value = "नया बनायें";
        document.getElementById("Btneditcreation").value = "सुधारें";
       // document.getElementById("lbldepositrefno").innerHTML = "डिपोजिट संदर्भ नं.";
        document.getElementById("lbldatecreation").innerHTML = "दिनांक";
        document.getElementById("lblfundtransferbank").innerHTML = "राशि हस्तांतरण बैंक";
        document.getElementById("lblfdramount").innerHTML = "एफ डी आर राशि";
        document.getElementById("lblchddutrcreation").innerHTML = "चैक/डीडी/यूटीआर नं.";
        document.getElementById("lblnameonfdr").innerHTML = "एफ डी आर पर नाम";
        document.getElementById("lblfdrissuingbankname").innerHTML = "एफ डी आर जारीकर्ता बैंक";
        document.getElementById("lblfdrissuingbranchname").innerHTML = "एफ डी आर जारीकर्ता शाखा";
        document.getElementById("lblfdrnocreation").innerHTML = "एफ डी आर नं. ";
        document.getElementById("lblfdrdatecreation").innerHTML = "एफ डी आर दिनांक";
        document.getElementById("lblrateofinterest").innerHTML = "ब्याज की दर";
        document.getElementById("lblinterestamountcreation").innerHTML = "ब्याज राशि";
        document.getElementById("lblmaturitydate").innerHTML = "परिपक्वता दिनांक";
        document.getElementById("lblmaturityamount").innerHTML = "परिपक्वता राशि";
        if (document.getElementById("lblencashmentrefno") != null) {
          //  document.getElementById("lblencashmentrefno").innerHTML = "नगदीकरण संदर्भ नं.";
            document.getElementById("lblencashmentrefno").className = "Frm_Txt_Hindi";
        }


        if (document.getElementById("lbldateencashment") != null) {
            document.getElementById("lbldateencashment").innerHTML = "दिनांक";
            document.getElementById("lbldateencashment").className = "Frm_Txt_Hindi";
        }
        if (document.getElementById("lblfundreceivedbank") != null) {
            document.getElementById("lblfundreceivedbank").innerHTML = "राशि प्राप्तकर्ता बैंक";
            document.getElementById("lblfundreceivedbank").className = "Frm_Txt_Hindi";
        }
        if (document.getElementById("lblchddutrnoencashment") != null) {
            document.getElementById("lblchddutrnoencashment").innerHTML = "चैक/डीडी/यूटीआर नं.";
            document.getElementById("lblchddutrnoencashment").className = "Frm_Txt_Hindi";
        }
        if (document.getElementById("lblfdrnoencashment") != null) {
            document.getElementById("lblfdrnoencashment").innerHTML = "एफ डी आर नं.";
            document.getElementById("lblfdrnoencashment").className = "Frm_Txt_Hindi";
        }
        if (document.getElementById("lblprincipalamount") != null) {
            document.getElementById("lblprincipalamount").innerHTML = "प्राप्त  मूल राशि";
            document.getElementById("lblprincipalamount").className = "Frm_Txt_Hindi";
        }
        if (document.getElementById("lblinterestamountencashment") != null) {
            document.getElementById("lblinterestamountencashment").innerHTML = " प्राप्त  ब्याज";
            document.getElementById("lblinterestamountencashment").className = "Frm_Txt_Hindi";
        }
        if (document.getElementById("lbltdsamount") != null) {
            document.getElementById("lbltdsamount").innerHTML = "टीडीएस कटौती ";
            document.getElementById("lbltdsamount").className = "Frm_Txt_Hindi";
        }
        if (document.getElementById("lblchnetamount") != null) {

            if (document.getElementById('rbencashment').checked == true) {
                document.getElementById("lblchnetamount").innerHTML = "चैक / कुल राशि";

            }
            if (document.getElementById('rbrenewal').checked == true) {
                document.getElementById("lblchnetamount").innerHTML = "नयी एफ डी आर राशि ";

            }



            document.getElementById("lblchnetamount").className = "Frm_Txt_Hindi";
        }

        document.getElementById("lblremarkfdr").innerHTML = "प्रतिक्रिया दिनांक";
        document.getElementById("lblRemark").innerHTML = "रिमार्क";
        document.getElementById("lblForwarededFor").innerHTML = "प्रतिक्रिया";
        document.getElementById("lblForwardTo").innerHTML = "अग्रेषित कर्मचारी";
        document.getElementById("btnsave").value = "रक्षित करें";
        document.getElementById("btncancel").value = "रद्द करें";

        //        document.getElementById("lblencashmentrefno").innerHTML = "नगदीकरण संदर्भ नं.";
        //document.getElementById("lbldateencashment").innerHTML = "दिनांक";
        //document.getElementById("lblfundreceivedbank").innerHTML = "राशि प्राप्तकर्ता बैंक";
        //document.getElementById("lblchddutrnoencashment").innerHTML = "चैक/डीडी/यूटीआर नं.";
        //document.getElementById("lblfdrnoencashment").innerHTML = "एफ डी आर नं.";
        //document.getElementById("lblprincipalamount").innerHTML = "मूल राशि";
        //document.getElementById("lblinterestamountencashment").innerHTML = "ब्याज राशि";
        //document.getElementById("lbltdsamount").innerHTML = "टीडीएस राशि";
        //document.getElementById("lblchnetamount").innerHTML = "चैक / कुल राशि";
        //        document.getElementById("lblremarkfdr").innerHTML = "दिनांक";
        //        document.getElementById("lblRemark").innerHTML = "रिमा";
        //        document.getElementById("lblForwarededFor").innerHTML = "प्रतिक्रिया";
        //        document.getElementById("lblForwardTo").innerHTML = "अग्रेषित";
        //        document.getElementById("btnsave").value = "रक्षित करें";
        //        document.getElementById("btncancel").value = "रद्द करें";
        //============Hindi Text================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnnewcreation").className = "btn_Hindi";
        document.getElementById("Btneditcreation").className = "btn_Hindi";
        document.getElementById("lbldepositrefno").className = "Frm_Txt_Hindi";
        document.getElementById("lbldatecreation").className = "Frm_Txt_Hindi";
        document.getElementById("lblfundtransferbank").className = "Frm_Txt_Hindi";
        document.getElementById("lblfdramount").className = "Frm_Txt_Hindi";
        document.getElementById("lblchddutrcreation").className = "Frm_Txt_Hindi";
        document.getElementById("lblnameonfdr").className = "Frm_Txt_Hindi";
        document.getElementById("lblfdrissuingbankname").className = "Frm_Txt_Hindi";
        document.getElementById("lblfdrissuingbranchname").className = "Frm_Txt_Hindi";
        document.getElementById("lblfdrnocreation").className = "Frm_Txt_Hindi ";
        document.getElementById("lblfdrdatecreation").className = "Frm_Txt_Hindi";
        document.getElementById("lblrateofinterest").className = "Frm_Txt_Hindi";
        document.getElementById("lblinterestamountcreation").className = "Frm_Txt_Hindi";
        document.getElementById("lblmaturitydate").className = "Frm_Txt_Hindi";
        document.getElementById("lblmaturityamount").className = "Frm_Txt_Hindi";
        document.getElementById("lblremarkfdr").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemark").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwarededFor").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwardTo").className = "Frm_Txt_Hindi";
        document.getElementById("btnsave").className = "btn_Hindi";
        document.getElementById("btncancel").className = "btn_Hindi";


        //        document.getElementById("lblencashmentrefno").className = "Frm_Txt_Hindi";
        //        document.getElementById("lbldateencashment").className = "Frm_Txt_Hindi";
        //        document.getElementById("lblfundreceivedbank").className = "Frm_Txt_Hindi";
        //        document.getElementById("lblchddutrnoencashment").className = "Frm_Txt_Hindi";
        //        document.getElementById("lblfdrnoencashment").className = "Frm_Txt_Hindi";
        //        document.getElementById("lblprincipalamount").className = "Frm_Txt_Hindi";
        //        document.getElementById("lblinterestamountencashment").className = "Frm_Txt_Hindi";
        //        document.getElementById("lbltdsamount").className = "Frm_Txt_Hindi";
        //        document.getElementById("lblchnetamount").className = "Frm_Txt_Hindi";
        //        document.getElementById("lblremarkfdr").className = "Frm_Txt_Hindi";
        //        document.getElementById("lblRemark").className = "Frm_Txt_Hindi";
        //        document.getElementById("lblForwarededFor").className = "Frm_Txt_Hindi";
        //        document.getElementById("lblForwardTo").className = "Frm_Txt_Hindi";
        //        document.getElementById("btnsave").className = "btn_Hindi";
        //        document.getElementById("btncancel").className = "btn_Hindi";


    }
    if (Choice == 0 && FormId == 293) {

        document.getElementById("LblHeader").innerHTML = "सामान्य बिल भुगतान";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("btnNew").value = "नया ";
        document.getElementById("btnEdit").value = "सुधारे ";
        document.getElementById("btnSave").value = "रक्षित करें ";
        document.getElementById("btnCancel").value = "रद्द करें ";
        document.getElementById("lblGeneralBillRefNo").innerHTML = " सामान्य बिल भुगतान रिफरेंस न.";
        document.getElementById("lblDate").innerHTML = "दिनांक ";
        document.getElementById("lblAccountHead").innerHTML = "भुगतान का प्रकार ";
        document.getElementById("lblObjectHead").innerHTML = "बजट कोड";
        document.getElementById("lblSupplierProviderType").innerHTML = "सप्लायर /सर्विस प्रदाता का प्रकार ";
        document.getElementById("lblSupplierProvider").innerHTML = " सप्लायर /सर्विस प्रदाता ";
        document.getElementById("lblDescription").innerHTML = "विवरण";
        document.getElementById("lblUploadBill").innerHTML = "अपलोड बिल";
        document.getElementById("lblAmount").innerHTML = "राशि";
        document.getElementById("lblVAT").innerHTML = "वैट";
        document.getElementById("lblServiceTax").innerHTML = "सर्विस कर";
        document.getElementById("lblGrossBillAmt").innerHTML = "ग्रौस बिल राशि";
        document.getElementById("lblApplicationLess").innerHTML = "कटौती";
        document.getElementById("lblTDS").innerHTML = "टी.डी.एस.";
        document.getElementById("lblDeduction").innerHTML = " कटौती";
        document.getElementById("lblWithHeldAmt").innerHTML = "रोकी गई राशि";
        document.getElementById("lblApprovableAmt").innerHTML = "स्वीकृति योग्य राशि";
        document.getElementById("lblGetPayInfo").innerHTML = "भुगतान पाने वाले की जानकारी";
        document.getElementById("lblSupplierEmpType").innerHTML = "कर्मचारी का प्रकार ";
        document.getElementById("lblSupplierEmpName").innerHTML = " कर्मचारी का नाम";
        document.getElementById("lblAdvanceAmt").innerHTML = "अग्रिम समायोजन की राशि";
        document.getElementById("lblPaymentAmt").innerHTML = "भुगतान राशि";
        document.getElementById("lblSenctional").innerHTML = "दिनांक";
        document.getElementById("lblRemark").innerHTML = "रिमार्क ";
        document.getElementById("lblForwarededFor").innerHTML = "प्रतिक्रिया";
        document.getElementById("lblForwardTo").innerHTML = "अग्रेषित कर्मचारी";
        document.getElementById("lblPaymentMode").innerHTML = "भुगतान का तरीका";
        var RBcheque = document.getElementById("rbChecque");
        var RB = RBcheque.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "चैक/ डी डी";

        var RBepay = document.getElementById("rbePay");
        var RBe = RBepay.parentNode.getElementsByTagName("label");
        RBe[0].innerHTML = "ई पेमेंट";

        document.getElementById("LblSelectBank").innerHTML = "बैंक का नाम";
        document.getElementById("lblCheque").innerHTML = "चैक/ डी डी नं.";



        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("lblGeneralBillRefNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblDate ").className = "Frm_Txt_Hindi";
        document.getElementById("lblAccountHead ").className = "Frm_Txt_Hindi";
        document.getElementById("lblObjectHead ").className = "Frm_Txt_Hindi";
        document.getElementById("lblSupplierProviderType ").className = "Frm_Txt_Hindi";
        document.getElementById("lblSupplierProvider").className = "Frm_Txt_Hindi";
        document.getElementById("lblDescription").className = "Frm_Txt_Hindi";
        document.getElementById("lblUploadBill").className = "Frm_Txt_Hindi";
        document.getElementById("lblAmount").className = "Frm_Txt_Hindi";
        document.getElementById("lblVAT").className = "Frm_Txt_Hindi";
        document.getElementById("lblServiceTax ").className = "Frm_Txt_Hindi";
        document.getElementById("lblGrossBillAmt ").className = "Frm_Txt_Hindi";
        document.getElementById("lblApplicationLess ").className = "Frm_Txt_Hindi";
        document.getElementById("lblTDS").className = "Frm_Txt_Hindi";
        document.getElementById("lblDeduction").className = "Frm_Txt_Hindi";
        document.getElementById("lblWithHeldAmt").className = "Frm_Txt_Hindi";
        document.getElementById("lblApprovableAmt").className = "Frm_Txt_Hindi";
        document.getElementById("lblGetPayInfo").className = "Frm_Txt_Hindi";
        document.getElementById("lblSupplierEmpType").className = "Frm_Txt_Hindi";
        document.getElementById("lblSupplierEmpName").className = "Frm_Txt_Hindi";
        document.getElementById("lblAdvanceAmt").className = "Frm_Txt_Hindi";
        document.getElementById("lblPaymentAmt").className = "Frm_Txt_Hindi";
        document.getElementById("lblSenctional").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemark").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwarededFor").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwardTo").className = "Frm_Txt_Hindi";
        document.getElementById("lblPaymentMode").className = "Frm_Txt_Hindi";

    }

    //frm_General_Bill_Payment_Configuration.aspx
    if (Choice == 0 && FormId == 2618) {

        document.getElementById("LblHeader").innerHTML = "सामान्य बिल भुगतान कांफिगरेशन";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";


        var chkdefault = document.getElementById("chkDefault");
        var ch = chkdefault.parentNode.getElementsByTagName("label");
        ch[0].innerHTML = "सामान्य सभी शाखाओ के लिये";


        var chkall = document.getElementById("ChkAll");
        var cha = chkall.parentNode.getElementsByTagName("label");
        cha[0].innerHTML = "सभी चुने";

        var chkisagency = document.getElementById("chkisAgency");
        var ch1 = chkisagency.parentNode.getElementsByTagName("label");
        ch1[0].innerHTML = "इज एजेंसी";


        var chkiscategory = document.getElementById("chkisCategory");
        var chk1 = chkiscategory.parentNode.getElementsByTagName("label");
        chk1[0].innerHTML = "इज श्रेणी";


        document.getElementById("btnsave_Ledger").value = "रक्षित करें";
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("btnSaveReceipt").value = "रक्षित करें";
        document.getElementById("btnCancelReceipt").value = "रद्द करें";
        document.getElementById("ApplicationConfiguration").innerHTML = "सामान्य बिल भुगतान कांफिगरेशन";
        document.getElementById("VoucherConfiguration").innerHTML = "सामान्य बिल भुगतान का प्रकार ";
        document.getElementById("lblConfigType").innerHTML = "सामान्य बिल भुगतान कांफिगरेशन";
        document.getElementById("lblLedgerEffectiveDt").innerHTML = "प्रभावित तिथि";
        document.getElementById("lblScheme").innerHTML = "स्कीम चुने";
        document.getElementById("lblLedgerType").innerHTML = "लेज़र का प्रकार";
        document.getElementById("lblLedger").innerHTML = "लेज़र का नाम";
        document.getElementById("lblCategory").innerHTML = "केटेगरी का नाम";
        document.getElementById("lblReceiptName").innerHTML = "सामान्य बिल भुगतान का प्रकार";
        document.getElementById("lblReceiptNameHindi").innerHTML = "सामान्य बिल भुगतान का प्रकार (हिन्दी)";
        //=======Hindi Text ============//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnsave_Ledger").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("lblConfigType").className = "Frm_Txt_Hindi";
        document.getElementById("lblLedgerEffectiveDt").className = "Frm_Txt_Hindi";
        document.getElementById("lblLedgerType").className = "Frm_Txt_Hindi";
        document.getElementById("lblLedger").className = "Frm_Txt_Hindi";
        document.getElementById("lblCategory").className = "Frm_Txt_Hindi";
        document.getElementById("lblReceiptName").className = "Frm_Txt_Hindi";
        document.getElementById("lblReceiptNameHindi").className = "Frm_Txt_Hindi";
        document.getElementById("btnSaveReceipt").className = "btn_Hindi";
        document.getElementById("btnCancelReceipt").className = "btn_Hindi";

        // Grid Code Start
        var table = document.getElementById("gridLedger");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "चुनियें";
        tr.cells[1].innerHTML = "हटाये";
        tr.cells[2].innerHTML = "स/क्र.";
        tr.cells[3].innerHTML = "सामान्य बिल भुगतान का नाम ";
        tr.cells[4].innerHTML = "प्रभावित तिथि";
        tr.cells[5].innerHTML = "लेज़र का प्रकार";
        tr.cells[6].innerHTML = "लेज़र का नाम";
        tr.cells[7].innerHTML = "केटेगरी का नाम";

        //============Hindi Text================//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
        tr.cells[5].className = "Frm_Txt_Hindi";
        tr.cells[6].className = "Frm_Txt_Hindi";

        // Grid Code Start
        var table = document.getElementById("gvGeneralBillType");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "चुनियें";
        tr.cells[1].innerHTML = "हटाये";
        tr.cells[2].innerHTML = "स/क्र.";
        tr.cells[3].innerHTML = "सामान्य बिल भुगतान का प्रकार ";
        tr.cells[4].innerHTML = "सामान्य बिल भुगतान का प्रकार (हिन्दी)";

        //============Hindi Text================//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
    }

    //Form ID 2620, Form Name:Finance/frm_TDS_Configuration.aspx
    if (Choice == 0 && FormId == 2620) {
        document.getElementById("LblHeader").innerHTML = "सावधि जमा कॉन्फीगरेशन";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("LblHeader").innerHTML = "सावधि जमा मास्टर";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";



        var chkdefault = document.getElementById("chkDefault");
        var ch = chkdefault.parentNode.getElementsByTagName("label");
        ch[0].innerHTML = "सामान्य सभी शाखाओ के लिये";


        var chkisagency = document.getElementById("chkisAgency");
        var ch1 = chkisagency.parentNode.getElementsByTagName("label");
        ch1[0].innerHTML = "इज एजेंसी";


        var chkiscategory = document.getElementById("chkisCategory");
        var chk1 = chkiscategory.parentNode.getElementsByTagName("label");
        chk1[0].innerHTML = "इज श्रेणी";


        document.getElementById("btnsave").value = "रक्षित करें";
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("lblConfigType").innerHTML = "कांफिगरेशन का प्रकार";
        document.getElementById("lblLedgerEffectiveDt").innerHTML = "प्रभावित तिथि";
        document.getElementById("lblLedgerType").innerHTML = "लेज़र का प्रकार";
        document.getElementById("lblPayment").innerHTML = "सावधि जमा कांफिगरेशन";
        document.getElementById("lblLedger").innerHTML = "लेज़र का नाम";
        document.getElementById("lblCategory").innerHTML = "केटेगरी का नाम";
        //=======Hindi Text ============//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnsave").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("lblConfigType").className = "Frm_Txt_Hindi";
        document.getElementById("lblLedgerEffectiveDt").className = "Frm_Txt_Hindi";
        document.getElementById("lblLedgerType").className = "Frm_Txt_Hindi";
        document.getElementById("lblLedger").className = "Frm_Txt_Hindi";
        document.getElementById("lblCategory").className = "Frm_Txt_Hindi";

        // Grid Code Start
        var table = document.getElementById("gridLedger");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "चुनियें";
        tr.cells[1].innerHTML = "हटाये";
        tr.cells[2].innerHTML = "स/क्र.";
        tr.cells[3].innerHTML = "कांफिगरेशन का नाम ";
        tr.cells[4].innerHTML = "प्रभावित तिथि";
        tr.cells[5].innerHTML = "लेज़र का नाम";
        tr.cells[6].innerHTML = "केटेगरी का नाम";

        //============Hindi Text================//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
        tr.cells[5].className = "Frm_Txt_Hindi";
        tr.cells[6].className = "Frm_Txt_Hindi";


    }


}

