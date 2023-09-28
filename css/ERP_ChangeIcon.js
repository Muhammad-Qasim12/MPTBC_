var GlobalLanguage;
function ChangeLabel(Choice, FormId, QueryString) 
{

    GlobalLanguage = Choice;
    //Form ID 171, Form Name:Master_Pages/frm_LedgerType.aspx
    if (Choice == 0 && FormId == 171) {
        document.getElementById("LblHeader").innerHTML = "लेजर का प्रकार";
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
        document.getElementById("btnDelete").value = "हटायें";
        document.getElementById("lblLedgerType").innerHTML = "लेजर का प्रकार  :";
        document.getElementById("lblLedgerTypeHindi").innerHTML = "लेजर का प्रकार (हिन्दी) :";
        //        document.getElementById("btnSelectAll").value = "सभी चुनें";
        //        document.getElementById("btnUncheckAll").value = "सभी हटायें";
        document.getElementById("lblGradeType").innerHTML = "लेजर का प्रकार";
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("ChkSelectAll").nextSibling.innerHTML = "सभी चुनें/हटायें";
        //==============Hindi Font Increase==================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("btnExit").className = "btn_Hindi";
        document.getElementById("btnDelete").className = "btn_Hindi";
        document.getElementById("lblLedgerType").className = "Frm_Txt_Hindi";
        document.getElementById("lblLedgerTypeHindi").className = "Frm_Txt_Hindi";
        //        document.getElementById("btnSelectAll").className = "btn_Hindi";
        //        document.getElementById("btnUncheckAll").className = "btn_Hindi";
        document.getElementById("lblGradeType").className = "Frm_Txt_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("ChkSelectAll").nextSibling.className = "Frm_Txt_Hindi";
        // Grid Code Start
        var table = document.getElementById("gvLedgerTypeColumn");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "लेजर  प्रकार के काँलम का नाम";
        //tr.cells[1].innerHTML = "ग्रुप नबंर";
        tr.cells[1].innerHTML = "डिस्प्ले आर्डर";
        tr.cells[2].innerHTML = "लंबाई ";
        tr.cells[3].innerHTML = "डिस्प्ले काँलम का नाम";
        tr.cells[4].innerHTML = "डिस्प्ले काँलम का नाम (हिन्दी)";
        tr.cells[5].innerHTML = "इनपुट डाटा का प्रकार ";
        //font increase ===//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
        tr.cells[5].className = "Frm_Txt_Hindi";
        var table = document.getElementById("gvLedgerType");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "हटाये";
        tr.cells[1].innerHTML = "चुने";
        tr.cells[2].innerHTML = "लेजर का प्रकार";
        tr.cells[3].innerHTML = "लेजर का प्रकार (हिन्दी)";
    }

    //Form ID 2200, Form Name:Master_Pages/frm_AgencyType.aspx
    if (Choice == 0 && FormId == 2200) {
        document.getElementById("LblHeader").innerHTML = "एजेंसी का प्रकार";
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
        document.getElementById("btnEdit").value = "सुधारें";
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("btnDelete").value = "हटायें";
        document.getElementById("btnExit").value = "बाहर निकलें";
        document.getElementById("lblAgencyType").innerHTML = "एजेंसी प्रकार का नाम";
        document.getElementById("lblAgencyTypeHindi").innerHTML = "एजेंसी प्रकार का नाम (हिन्दी) ";
        document.getElementById("ChkFixed").nextSibling.innerHTML = "फिक्स";
        document.getElementById("ChkSelectAll").nextSibling.innerHTML = "सभी चुनें/हटायें";
        //document.getElementById("ChSelectAll").nextSibling.innerHTML = " सभी चुनें";
        document.getElementById("lblAgencyname").innerHTML = "एजेंसी प्रकार का नाम :-";
        //document.getElementById("PersonalInformationTab").innerHTML = "व्यक्तिगत जानकारी";
        //document.getElementById("ContactInformationTab").innerHTML = "संपर्क जानकारी";
        //document.getElementById("IDsInformationTab").innerHTML = "आईडी जानकारी";
        //document.getElementById("BankingInformationTab").innerHTML = "बैंकिंग जानकारी";
        //document.getElementById("ProfessionalInformationTab").innerHTML = "व्यावसायिक जानकारी";
        //document.getElementById("MemberInformationTab").innerHTML = "सदस्य जानकारी";
        //document.getElementById("SHGTab").innerHTML = "स्वय: सहायता समूह";
        //font increase ===//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("btnDelete").className = "btn_Hindi";
        document.getElementById("btnExit").className = "btn_Hindi";
        document.getElementById("lblAgencyType").className = "Frm_Txt_Hindi";
        document.getElementById("lblAgencyTypeHindi").className = "Frm_Txt_Hindi";
        document.getElementById("ChkFixed").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("ChkSelectAll").nextSibling.className = "Frm_Txt_Hindi";
        //document.getElementById("ChSelectAll").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("lblAgencyname").className = "Frm_Txt_Hindi";

        var table = document.getElementById("gvAgencyTypeColumn");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "एजेंसी प्रकार के काँलम का नाम";
        tr.cells[1].innerHTML = "ग्रुप नबंर";
        tr.cells[2].innerHTML = "डिस्प्ले आर्डर";
        tr.cells[3].innerHTML = "लंबाई ";
        tr.cells[4].innerHTML = "डिस्प्ले काँलम का नाम";
        tr.cells[5].innerHTML = "डिस्प्ले काँलम का नाम (हिन्दी)";
        //font increase ===//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
        tr.cells[5].className = "Frm_Txt_Hindi";
    }
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
        document.getElementById("lblPinCode").innerHTML = "पिन कोड";
        document.getElementById("lblIFSCCode").innerHTML = "आई एफ एस सी कोड";
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
        tr.cells[19].innerHTML = "ग्राम पंचायत";
        tr.cells[20].innerHTML = "गाँव";
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
        tr.cells[19].className = "Frm_Txt_Hindi";
        tr.cells[20].className = "Frm_Txt_Hindi";
    }
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
        document.getElementById("lblPinCode").innerHTML = "पिन कोड";
        document.getElementById("lblIFSCCode").innerHTML = "आई एफ एस सी कोड";
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
        tr.cells[19].innerHTML = "ग्राम पंचायत";
        tr.cells[20].innerHTML = "गाँव";
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
        tr.cells[19].className = "Frm_Txt_Hindi";
        tr.cells[20].className = "Frm_Txt_Hindi";
    }
    //Form ID 184, Form Name:Master_Pages/frm_SchemeBookClosing.aspx
    if (Choice == 0 && FormId == 184) {
        document.getElementById("LblHeader").innerHTML = "पुस्तक समापन";
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
        document.getElementById("lblSchemeName").innerHTML = "स्कीम का नाम";
        document.getElementById("lblClosingDate").innerHTML = "समापन तिथि";
        document.getElementById("headBookClosing").innerHTML = "पुस्तक समापन";
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btnExit").value = "बाहर निकलें";
        document.getElementById("btnPrint").value = "प्रिंट करें";

       

        //********New Tab Hindi
        document.getElementById("lblTabBookClosing").innerHTML = "पुस्तक समापन";
        document.getElementById("lblTAbOpeningClosing").innerHTML = " प्रारंभिक शेष समापन";
        document.getElementById("lblScheme_Opening").innerHTML = "स्कीम का नाम";
        document.getElementById("lblOpeningHeader").innerHTML = "प्रारंभिक शेष समापन";


        document.getElementById("btnSave_Opening").value = "रक्षित करें";
        document.getElementById("btnExit_Opening").value = "बाहर निकलें";
        document.getElementById("btnPrint_Opening").value = "प्रिंट करें";
        var Freeze = document.getElementById("rbfreeze_Opeing");
        var RB = Freeze.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "स्थाई";
        RB[0].className = "Frm_Txt_Hindi";

        var UnFreeze = document.getElementById("rbfreeze_closing");
        var RB = UnFreeze.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "अस्थाई";
        RB[0].className = "Frm_Txt_Hindi";


        document.getElementById("lblTabBookClosing").className = "Frm_Txt_Hindi";
        document.getElementById("lblOpeningHeader").className = "Frm_Txt_Hindi";
        document.getElementById("lblTAbOpeningClosing").className = "Frm_Txt_Hindi";
        document.getElementById("lblScheme_Opening").className = "Frm_Txt_Hindi";
        document.getElementById("btnSave_Opening").className = "btn_Hindi";
        document.getElementById("btnExit_Opening").className = "btn_Hindi";
        document.getElementById("btnPrint_Opening").className = "btn_Hindi";
        
        //*************
        
        //========Hindi Text=======//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblSchemeName").className = "Frm_Txt_Hindi";
        document.getElementById("lblClosingDate").className = "Frm_Txt_Hindi";
        document.getElementById("headBookClosing").className = "Frm_Txt_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnExit").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        // Hindi,English Radio button code
        var Freeze = document.getElementById("rbFreeze");
        var RB = Freeze.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "स्थाई";
        RB[0].className = "Frm_Txt_Hindi";

        var UnFreeze = document.getElementById("rbUnFreeze");
        var RB = UnFreeze.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "अस्थाई";
        RB[0].className = "Frm_Txt_Hindi";

        var Individual = document.getElementById("rbIndividual");
        var RB = Individual.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "स्वयं";
        RB[0].className = "Frm_Txt_Hindi";

        var Convergence = document.getElementById("rbConvergence");
        var RB = Convergence.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "कनवरजेंस";
        RB[0].className = "Frm_Txt_Hindi";
        if (document.getElementById("chkAllBranchClose") != null) {
            document.getElementById("chkAllBranchClose").nextSibling.innerHTML = "सभी शाखा बंद";
        }
        document.getElementById("chkAllBranch_Opening").nextSibling.innerHTML = "सभी शाखा बंद";
//        if (document.getElementById("chkAllBranch_Opening") != null) {
//        {
//         document.getElementById("chkAllBranch_Opening").nextSibling.innerHTML = "सभी शाखा बंद";
//        }
        
       
    }
    //Form ID 2223, Form Name:UploadMerge/frm_DataExportUtility.aspx
    if (Choice == 0 && FormId == 2223) {
        document.getElementById("LblHeader").innerHTML = "डाटा एक्सपोर्ट यूटिलीटी";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        // document.getElementById("lblwarningmsg").innerHTML = "नोट : आगे बढने के पूर्व यह सुनिश्चित कर ले की नेटवर्क सर्वर के 'D' ड्राइव में upload Folder स्थित है ।";
        document.getElementById("lblDataType").innerHTML = "डाटा का प्रकार";
        document.getElementById("chkFullData").nextSibling.innerHTML = " पूरा डाटा";
        document.getElementById("chkWithAllBranches").nextSibling.innerHTML = " सभी शाखा सहित";
        document.getElementById("lblBranchType").innerHTML = "शाखा का प्रकार";
        document.getElementById("lblBranchName").innerHTML = "शाखा का नाम";
        document.getElementById("chkPeroidic").nextSibling.innerHTML = " अवधि";
        document.getElementById("chkWithOpening").nextSibling.innerHTML = " प्रारंभिक शेष सहित";
        document.getElementById("lblFromDate").innerHTML = "तिथि से";
        document.getElementById("btnOk").value = "ओके";
        //============ font increase ===========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblDataType").className = "Frm_Txt_Hindi";
        document.getElementById("chkFullData").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("chkWithAllBranches").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("lblBranchType").className = "Frm_Txt_Hindi";
        document.getElementById("lblBranchName").className = "Frm_Txt_Hindi";
        document.getElementById("chkPeroidic").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("chkWithOpening").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("lblFromDate").className = "Frm_Txt_Hindi";
        document.getElementById("btnOk").className = "btn_Hindi";
    }
    //Form ID 2223, Form Name:UploadMerge/frm_DataExportUtility.aspx
    if (Choice == 0 && FormId == 2223) {
        document.getElementById("LblHeader").innerHTML = "डाटा एक्सपोर्ट यूटिलीटी";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        // document.getElementById("lblwarningmsg").innerHTML = "नोट : आगे बढने के पूर्व यह सुनिश्चित कर ले की नेटवर्क सर्वर के 'D' ड्राइव में upload Folder स्थित है ।";
        document.getElementById("lblDataType").innerHTML = "डाटा का प्रकार";
        document.getElementById("chkFullData").nextSibling.innerHTML = " पूरा डाटा";
        document.getElementById("chkWithAllBranches").nextSibling.innerHTML = " सभी शाखा सहित";
        document.getElementById("lblBranchType").innerHTML = "शाखा का प्रकार";
        document.getElementById("lblBranchName").innerHTML = "शाखा का नाम";
        document.getElementById("chkPeroidic").nextSibling.innerHTML = " अवधि";
        document.getElementById("chkWithOpening").nextSibling.innerHTML = " प्रारंभिक शेष सहित";
        document.getElementById("lblFromDate").innerHTML = "तिथि से";
        document.getElementById("btnOk").value = "ओके";
        //============ font increase ===========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblDataType").className = "Frm_Txt_Hindi";
        document.getElementById("chkFullData").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("chkWithAllBranches").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("lblBranchType").className = "Frm_Txt_Hindi";
        document.getElementById("lblBranchName").className = "Frm_Txt_Hindi";
        document.getElementById("chkPeroidic").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("chkWithOpening").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("lblFromDate").className = "Frm_Txt_Hindi";
        document.getElementById("btnOk").className = "btn_Hindi";
    }
    //Form ID 2224, Form Name:UploadMerge/frm_DataImportUtility.aspx
    if (Choice == 0 && FormId == 2224) {
        document.getElementById("LblHeader").innerHTML = "डाटा इम्पोर्ट यूटिलीटी";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        // document.getElementById("lblwarningmsg").innerHTML = "नोट : आगे बढने के पूर्व यह सुनिश्चित कर ले की आपके सिस्टम के 'D' ड्राइव में MergeData Folder स्थित है ।";
        // document.getElementById("lblwarningmsg").innerHTML = "नोट : आगे बढने के पूर्व यह सुनिश्चित कर ले की नेटवर्क सर्वर के 'D' ड्राइव में MergeData Folder स्थित है ।";

        document.getElementById("lblDataType").innerHTML = "डाटा का प्रकार";
        document.getElementById("lblSelectFolder").innerHTML = "फोल्डर चुनें";
        document.getElementById("btnOk").value = "ओके";
        //============ font increase ===========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblDataType").className = "Frm_Txt_Hindi";
        document.getElementById("lblSelectFolder").className = "Frm_Txt_Hindi";
        document.getElementById("btnOk").className = "btn_Hindi";
    }
    //Form ID 2225, Form Name:Master_Pages/frm_ImportBankData.aspx
    if (Choice == 0 && FormId == 2225) {
        document.getElementById("LblHeader").innerHTML = "आयात बैंक डाटा";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("lblScheme").innerHTML = "स्कीम का नाम चुनें ";
        document.getElementById("lblAccountType").innerHTML = "खाता का प्रकार";
        document.getElementById("lblUpload").innerHTML = "अपलोड फाईल";
        document.getElementById("btnOk").value = "अपलोड करें";
        document.getElementById("lblExcelHeader").innerHTML = "एक्सेल शीट फोरमेट : - फाइल में यह काँलम होने चाहिये । ";
        document.getElementById("lblExcelBottom").innerHTML = "नोट : - एक्सेल की पहली पंक्ति हेडर होनी चाहिये और एक्सेल शीट 2003 फोरमेट में बनाए । ";
        document.getElementById("btnCloseExcelDiv").value = "ओके";
        document.getElementById("lbl_note").innerHTML = "नोट :";
        document.getElementById("lblCorrectFormat").innerHTML = "1. एक्सेल शीट मे सही यूजर कोड भरे (अगर 00001 है तो 00001 भरे 1 नही )";
        document.getElementById("lbl_IFSCNote").innerHTML = "2. यदि बैंक के प्रकार – रीज़नल बैंक, को – आपरेटिव बैंक में एक से ज्यादा IFSC कोड पाये जाते है तो बैंक खाता किसी भी एक बैंक शाखा से कान्फ़िगर हो जाएगा । ";
        //============ font increase ===========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("lblAccountType").className = "Frm_Txt_Hindi";
        document.getElementById("lblUpload").className = "Frm_Txt_Hindi";
        document.getElementById("btnOk").className = "btn_Hindi";
        document.getElementById("lblCorrectFormat").className = "Frm_Txt_Hindi";
        document.getElementById("lbl_IFSCNote").className = "Frm_Txt_Hindi";
        document.getElementById("lbl_note").className = "Frm_Txt_Hindi";
    }
    //Form ID 2239, Form Name:Master_Pages/frm_Alert_Message.aspx
    if (Choice == 0 && FormId == 2239) {
        document.getElementById("LblHeader").innerHTML = "अलर्ट संदेश";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("lblLedgerType").innerHTML = "लेजर का प्रकार";
        document.getElementById("lblLedgerColumns").innerHTML = "लेजर के प्रकार के लिये काँलम्स :-";
        document.getElementById("lblExpiryDate").innerHTML = "समाप्ति तिथि";
        document.getElementById("lblReference").innerHTML = "रिफरेंस न.";
        document.getElementById("lblAlertMessage").innerHTML = "अलर्ट संदेश (पिरिफिक्स)";
        document.getElementById("lblAlertStartDays").innerHTML = "अलर्ट पहले के दिवस";
        document.getElementById("lblAlertEndDays").innerHTML = "अलर्ट बाद के दिवस";
        document.getElementById("lblDepartmentName").innerHTML = "विभाग का नाम";
        document.getElementById("lblDivisionName").innerHTML = "शाखा का नाम";
        document.getElementById("lblEmployeeName").innerHTML = "कर्मचारी का नाम";
        document.getElementById("lblDisplayPageName").innerHTML = "डिस्पले पेज नेम";
        document.getElementById("btnNew").value = "नया";
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btnEdit").value = "सुधारें";
        document.getElementById("btnAdd").value = "जोडें";
        //=======Hindi Text ============//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblLedgerType").className = "Frm_Txt_Hindi";
        document.getElementById("lblLedgerColumns").className = "Frm_Txt_Hindi";
        document.getElementById("lblExpiryDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblReference").className = "Frm_Txt_Hindi";
        document.getElementById("lblAlertMessage").className = "Frm_Txt_Hindi";
        document.getElementById("lblAlertStartDays").className = "Frm_Txt_Hindi";
        document.getElementById("lblAlertEndDays").className = "Frm_Txt_Hindi";
        document.getElementById("lblDepartmentName").className = "Frm_Txt_Hindi";
        document.getElementById("lblDivisionName").className = "Frm_Txt_Hindi";
        document.getElementById("lblEmployeeName").className = "Frm_Txt_Hindi";
        document.getElementById("lblDisplayPageName").className = "Frm_Txt_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("btnAdd").className = "btn_Hindi";

        var table1 = document.getElementById("gvEmpDeptDivDtl");
        if (table1 != null) {
            var tr = table1.rows[0];
            tr.cells[0].innerHTML = "चुनिये";
            tr.cells[1].innerHTML = "हटायें";
            tr.cells[2].innerHTML = "कर्मचारी का नाम";
            tr.cells[3].innerHTML = "विभाग का नाम";
            tr.cells[4].innerHTML = "शाखा का नाम";
            // ===========Increase===========//
            tr.cells[0].className = "Frm_Txt_Hindi";
            tr.cells[1].className = "Frm_Txt_Hindi";
            tr.cells[2].className = "Frm_Txt_Hindi";
            tr.cells[3].className = "Frm_Txt_Hindi";
            tr.cells[4].className = "Frm_Txt_Hindi";
        }
        var table1 = document.getElementById("gvAlertMain");
        if (table1 != null) {
            var tr = table1.rows[0];
            tr.cells[0].innerHTML = "चुनिये";
            tr.cells[1].innerHTML = "हटायें";
            tr.cells[2].innerHTML = "लेजर का प्रकार";
            tr.cells[3].innerHTML = "समाप्ति तिथि";
            tr.cells[4].innerHTML = "रिफरेंस न.";
            tr.cells[5].innerHTML = "अलर्ट संदेश";
            tr.cells[6].innerHTML = "डिस्पले पेज नेम";
            tr.cells[7].innerHTML = "पहले के दिवस";
            tr.cells[8].innerHTML = "बाद के दिवस";
            // ===========Increase===========//
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
        document.getElementById("lblSchemeOption").innerHTML = "स्कीम विकल्प :-";
        document.getElementById("lblLedger").innerHTML = "लेजर चुने";
        document.getElementById("lblLedgerType").innerHTML = "लेजर का प्रकार चुने";
        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        //=========Hindi Font Increase==========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblFromDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblToDate").className = "Frm_Txt_Hindi";
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
}
