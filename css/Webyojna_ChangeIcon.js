var GlobalLanguage;
function ChangeLabel(Choice, FormId, QueryString) {

    GlobalLanguage = Choice;
    if (Choice == 0 && FormId == 220) {
        document.getElementById("LblHeader").innerHTML = "यूजर प्रबंधन";
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
        document.getElementById("btnUser").value = "यूजर";
        document.getElementById("btnUser").className = "User_btn_Hindi";
        document.getElementById("btnLedger").value = "लेजर रोल";
        document.getElementById("btnLedger").className = "Ledger_btn_Hindi";
        document.getElementById("btnScheme").value = "स्कीम रोल";
        document.getElementById("btnScheme").className = "Scheme_btn_Hindi";
        document.getElementById("btnCategory").value = "श्रेणी रोल";
        document.getElementById("btnCategory").className = "Category_btn_Hindi";
        document.getElementById("btnAgency").value = "एजेंसी रोल";
        document.getElementById("btnAgency").className = "Agency_btn_Hindi";
        document.getElementById("btnFormRight").value = "फॉम राईट्स";
        document.getElementById("btnFormRight").className = "FormRight_btn_Hindi";
        document.getElementById("btnAgencyTypeGroupRole").className = "AgencyType_btn_Hindi";
        document.getElementById("btnAgencyTypeGroupRole").value = "एजेंसी प्रकार रोल";
    }
    //Form ID 215, Form Name:UserManagement/LedgerRole.aspx
    if (Choice == 0 && FormId == 215) {
        document.getElementById("LblHeader").innerHTML = "लेजर रोल";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        // New,Edit Radio button code
        var RBHindi = document.getElementById("RbNew");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " नया";
        RB[0].className = "Frm_Txt_Hindi";

        var RBenglish = document.getElementById("rbedit");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[1].innerHTML = " सुधारें";
        RB[1].className = "Frm_Txt_Hindi";

        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("lblLedger").innerHTML = "लेजर रोल भरें";
        document.getElementById("chkAll").nextSibling.innerHTML = "सभी चुनें";
        document.getElementById("lblLedgerType").innerHTML = " लेजर रोल चुनें";
        document.getElementById("hlUsermanagement").innerHTML = "यूजर प्रबंधन";
        //============Hindi Text================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("lblLedger").className = "Frm_Txt_Hindi";
        document.getElementById("chkAll").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("lblLedgerType").className = "Frm_Txt_Hindi";
        document.getElementById("ddlledgerrole").className = "ddl_Hindi";

        //Grid Code Start
        var table = document.getElementById("gvLedger");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "चुनिये";
        tr.cells[1].innerHTML = "लेजर का नाम";
        //============Hindi Text================//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
    }
    //Form ID 2572, Form Name:UserManagement/frm_AgencyTypeGroupRole.aspx
    if (Choice == 0 && FormId == 2572) {
        document.getElementById("LblHeader").innerHTML = "एजेंसी प्रकार रोल";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        // New,Edit Radio button code
        var RBHindi = document.getElementById("RbNew");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " नया";
        RB[0].className = "Frm_Txt_Hindi";

        var RBenglish = document.getElementById("rbedit");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[1].innerHTML = " सुधारें";
        RB[1].className = "Frm_Txt_Hindi";

        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("lblLedger").innerHTML = "एजेंसी प्रकार रोल भरें";
        document.getElementById("chkAll").nextSibling.innerHTML = "सभी चुनें";
        document.getElementById("lblLedgerType").innerHTML = " एजेंसी प्रकार रोल चुनें";
        document.getElementById("hlUsermanagement").innerHTML = "यूजर प्रबंधन";
        //============Hindi Text================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("lblLedger").className = "Frm_Txt_Hindi";
        document.getElementById("chkAll").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("lblLedgerType").className = "Frm_Txt_Hindi";
        document.getElementById("ddlledgerrole").className = "ddl_Hindi";

        //Grid Code Start
        var table = document.getElementById("gvLedger");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "चुनिये";
        tr.cells[1].innerHTML = "एजेंसी प्रकार का नाम";
        //============Hindi Text================//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
    }
    //Form ID 217, Form Name:UserManagement/Scheme.aspx
    if (Choice == 0 && FormId == 217) {
        document.getElementById("LblHeader").innerHTML = "स्कीम रोल";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        // New,Edit Radio button code
        var RBHindi = document.getElementById("rbnew");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " नया";
        RB[0].className = "Frm_Txt_Hindi";

        var RBenglish = document.getElementById("rbEdit");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[1].innerHTML = " सुधारें";
        RB[1].className = "Frm_Txt_Hindi";

        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("lblScheme").innerHTML = "स्कीम रोल भरें";
        document.getElementById("chkAll").nextSibling.innerHTML = "सभी चुनें";
        document.getElementById("lblSchemeType").innerHTML = "स्कीम रोल चुनें";
        document.getElementById("lblType").innerHTML = "प्रकार";
        document.getElementById("hlUsermanagement").innerHTML = "यूजर प्रबंधन";
        //============Hindi Text================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("lblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("chkAll").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("lblSchemeType").className = "Frm_Txt_Hindi";
        document.getElementById("ddlSchemeType").className = "ddl_Hindi";
        document.getElementById("lblType").className = "Frm_Txt_Hindi";
        document.getElementById("chkList").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("ddlType").className = "ddl_Hindi";
    }
    //Form ID 219, Form Name:UserManagement/CategoryRole.aspx
    if (Choice == 0 && FormId == 219) {
        document.getElementById("LblHeader").innerHTML = "श्रेणी रोल";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        // New,Edit Radio button code
        var RBHindi = document.getElementById("rbnew");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " नया";
        RB[0].className = "Frm_Txt_Hindi";

        var RBenglish = document.getElementById("rbedit");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[1].innerHTML = " सुधारें";
        RB[1].className = "Frm_Txt_Hindi";

        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("lbCategory").innerHTML = "श्रेणी रोल भरें";
        document.getElementById("chkAll").nextSibling.innerHTML = "सभी चुनें";
        document.getElementById("lblCategoryType").innerHTML = "श्रेणी रोल चुनें";
        document.getElementById("hlUsermanagement0").innerHTML = "यूजर प्रबंधन";
        //============Hindi Text================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("lbCategory").className = "Frm_Txt_Hindi";
        document.getElementById("chkAll").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("lblCategoryType").className = "Frm_Txt_Hindi";
        document.getElementById("ddlCategory").className = "ddl_Hindi";

        //Grid Code Start
        var table = document.getElementById("gvCategory");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "चुनिये";
        tr.cells[1].innerHTML = "श्रेणी का नाम";
        //============Hindi Text================//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
    }
    //Form ID 216, Form Name:UserManagement/AgencyRole.aspx
    if (Choice == 0 && FormId == 216) {
        document.getElementById("LblHeader").innerHTML = "एजेंसी रोल";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        // New,Edit Radio button code
        var RBHindi = document.getElementById("optNew");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " नया";
        RB[0].className = "Frm_Txt_Hindi";

        var RBenglish = document.getElementById("optEdit");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[1].innerHTML = " सुधारें";
        RB[1].className = "Frm_Txt_Hindi";

        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("hlUsermanagement0").innerHTML = "यूजर प्रबंधन";
        document.getElementById("lblAgency").innerHTML = "एजेंसी रोल का नाम";
        document.getElementById("lblAgencyType").innerHTML = "एजेंसी का प्रकार";
        document.getElementById("lblState").innerHTML = "राज्य";
        document.getElementById("lblDistrict").innerHTML = "जिला";
        document.getElementById("lblBlock").innerHTML = "जनपद";
        document.getElementById("lblGram").innerHTML = "ग्राम पचांयत";
        document.getElementById("lblAgencyRole").innerHTML = "एजेंसी रोल";
        document.getElementById("chkALL").nextSibling.innerHTML = "सभी चुनें";
        document.getElementById("lblAgencyName").innerHTML = "एजेंसी का नाम";
        //============Hindi Text================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("chkALL").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("lblAgency").className = "Frm_Txt_Hindi";
        document.getElementById("lblAgencyType").className = "Frm_Txt_Hindi";
        document.getElementById("lblState").className = "Frm_Txt_Hindi";
        document.getElementById("lblDistrict").className = "Frm_Txt_Hindi";
        document.getElementById("lblBlock").className = "Frm_Txt_Hindi";
        document.getElementById("lblGram").className = "Frm_Txt_Hindi";
        document.getElementById("lblAgencyRole").className = "Frm_Txt_Hindi";
        document.getElementById("ddlAgencyType").className = "ddl_Hindi";
        document.getElementById("lblState").className = "Frm_Txt_Hindi";
        document.getElementById("lblDistrict").className = "Frm_Txt_Hindi";
        document.getElementById("lblBlock").className = "Frm_Txt_Hindi";
        document.getElementById("lblGram").className = "Frm_Txt_Hindi";
        document.getElementById("lblAgencyName").className = "Frm_Txt_Hindi";

    }
    //Form ID 226, Form Name:UserManagement/FormRights.aspx
    if (Choice == 0 && FormId == 226) {
        document.getElementById("LblHeader").innerHTML = "फॉम राईट्स";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";

        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("hlUsermanagement").innerHTML = "यूजर प्रबंधन";
        document.getElementById("btnSave").value = "रक्षित करे";
        document.getElementById("btnClear").value = "खाली करें";
        document.getElementById("lblAgency").innerHTML = "रोल भरें";
        document.getElementById("lblAgency0").innerHTML = "रोल चुनें";
        document.getElementById("lblAgency").innerHTML = "रोल भरें";
        document.getElementById("lblInsertRights").innerHTML = "I = जोडें";
        document.getElementById("lblUpdateRight").innerHTML = "U = सुधारें";
        document.getElementById("lblDeleteRights").innerHTML = "D = हटायें";
        document.getElementById("lblViewRights").innerHTML = "V = देखें";
        //========= Hindi Text Increase code =========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnClear").className = "btn_Hindi";
        document.getElementById("lblAgency").className = "Frm_Txt_Hindi";
        document.getElementById("lblAgency0").className = "Frm_Txt_Hindi";
        document.getElementById("lblAgency").className = "Frm_Txt_Hindi";
        document.getElementById("lblInsertRights").className = "Frm_Txt_Hindi";
        document.getElementById("lblUpdateRight").className = "Frm_Txt_Hindi";
        document.getElementById("lblDeleteRights").className = "Frm_Txt_Hindi";
        document.getElementById("lblViewRights").className = "Frm_Txt_Hindi";

        // New,Edit Radio button code
        var RBNew = document.getElementById("rbNew");
        var RB = RBNew.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "नया";
        RB[0].className = "Frm_Txt_Hindi";

        var RBEdit = document.getElementById("rbEdit");
        var RB = RBEdit.parentNode.getElementsByTagName("label");
        RB[1].innerHTML = "सुधारे";
        RB[1].className = "Frm_Txt_Hindi";

        // Grid Code Start
        var table = document.getElementById("gvRights");
        var tr = table.rows[0];
        tr.cells[1].innerHTML = "फॉम का नाम";
        tr.cells[1].className = "Frm_Txt_Hindi";
    }
    //Form ID 218, Form Name:UserManagement/User.aspx
    if (Choice == 0 && FormId == 218) {
        document.getElementById("LblHeader").innerHTML = "यूजर";
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
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("lnkUser").innerHTML = "यूजर";
        //document.getElementById("lnkChangePassword").innerHTML = "पासवर्ड";
        document.getElementById("lnkRole").innerHTML = "रोल";
        document.getElementById("lnkHR").innerHTML = "एच आर राईटस";
        document.getElementById("lnkFinancial").innerHTML = "वित्तिय राईटस";
        document.getElementById("lnkAudit").innerHTML = "आडिट राईटस";
        document.getElementById("hlUsermanagement").innerHTML = "यूजर प्रबंधन";
        
        //===========Hindi Size============//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";

        // New,Edit Radio button code
        var RBHindi = document.getElementById("RbNew");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " नया";
        RB[0].className = "Frm_Txt_Hindi";

        var RBenglish = document.getElementById("rbEdit");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " सुधारें";
        RB[0].className = "Frm_Txt_Hindi";

        //===========User Tab============//
        document.getElementById("lblUser").innerHTML = "यूजर का नाम";
        document.getElementById("lblPassword").innerHTML = "पासवर्ड";
        document.getElementById("lblRePassword").innerHTML = "पुनः पासवर्ड";
        document.getElementById("lblimage").innerHTML = "इमेज वेल्यू";
        document.getElementById("lblenterimage").innerHTML = "सही इमेज वेल्यू भरें";

        document.getElementById("lblUser").className = "Frm_Txt_Hindi";
        document.getElementById("lblPassword").className = "Frm_Txt_Hindi";
        document.getElementById("lblRePassword").className = "Frm_Txt_Hindi";
        document.getElementById("lblimage").className = "Frm_Txt_Hindi";
        document.getElementById("lblenterimage").className = "Frm_Txt_Hindi";
        //===========Password Tab============//
        document.getElementById("lblUserName").innerHTML = "यूजर नाम चुनें";
        document.getElementById("lblOldPassword").innerHTML = "पुराना पासवर्ड";
        document.getElementById("lblNewPassword").innerHTML = "नया पासवर्ड";
        document.getElementById("btnOK").value = "ओ के";
        document.getElementById("lblpwdImageValue").innerHTML = "इमेज वेल्यू";
        document.getElementById("lblpwdImageValueEnter").innerHTML = "सही इमेज वेल्यू भरें";
        document.getElementById("lblUserName").className = "Frm_Txt_Hindi";
        document.getElementById("lblOldPassword").className = "Frm_Txt_Hindi";
        document.getElementById("lblNewPassword").className = "Frm_Txt_Hindi";
        document.getElementById("btnOK").className = "btn_Hindi";
        document.getElementById("lblpwdImageValue").className = "Frm_Txt_Hindi";
        document.getElementById("lblpwdImageValueEnter").className = "Frm_Txt_Hindi";
        // Yes, No Radio button code
        var RB_Yes = document.getElementById("optChange");
        var RB = RB_Yes.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "पासवर्ड बदलें";
        RB[0].className = "Frm_Txt_Hindi";

        var RB_No = document.getElementById("optReset");
        var RB = RB_No.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "पासवर्ड रीसेट करें";
        RB[0].className = "Frm_Txt_Hindi";
        //===========Roll Tab============//
        document.getElementById("lblScheme").innerHTML = "स्कीम रोल";
        document.getElementById("lblLedger").innerHTML = "लेजर रोल";
        document.getElementById("lblAgency").innerHTML = "एजेंसी रोल";
        document.getElementById("lblForm").innerHTML = "फोर्म रोल";
        document.getElementById("lblAgencyTypeRole").innerHTML = "एजेंसी प्रकार रोल ";
        document.getElementById("lblCategory").innerHTML = "श्रेणी का नाम";
        document.getElementById("lblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("lblLedger").className = "Frm_Txt_Hindi";
        document.getElementById("lblAgency").className = "Frm_Txt_Hindi";
        document.getElementById("lblForm").className = "Frm_Txt_Hindi";
        document.getElementById("lblCategory").className = "Frm_Txt_Hindi";
        document.getElementById("lblAgencyTypeRole").className = "Frm_Txt_Hindi";
        //===========HR Tab============//
        document.getElementById("lblAgencyType").innerHTML = "एजेंसी का प्रकार चुनें";
        document.getElementById("lblAgencyName").innerHTML = "एजेंसी का नाम चुनें";
        document.getElementById("lblHrRight").innerHTML = "एच आर राईटस";
        document.getElementById("lblAgencyType").className = "Frm_Txt_Hindi";
        document.getElementById("lblAgencyName").className = "Frm_Txt_Hindi";
        document.getElementById("lblHrRight").className = "Frm_Txt_Hindi";
        // Yes, No Radio button code
        var RB_Yes = document.getElementById("optHrRight_Yes");
        var RB = RB_Yes.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हाँ";
        RB[0].className = "Frm_Txt_Hindi";

        var RB_No = document.getElementById("optHrRight_No");
        var RB = RB_No.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "नहीं";
        RB[0].className = "Frm_Txt_Hindi";
        //===========Financial Tab============//
        document.getElementById("lblFinancialLimit").innerHTML = "वित्तिय प्रतिबंध";
        document.getElementById("lblFinancial").innerHTML = "वित्तिय सीमा";
        document.getElementById("lblSanctionBudget").innerHTML = "बजट राईटस";
        document.getElementById("lblFinancialLimit").className = "Frm_Txt_Hindi";
        document.getElementById("lblFinancial").className = "Frm_Txt_Hindi";
        document.getElementById("lblSanctionBudget").className = "Frm_Txt_Hindi";
        // Yes, No Radio button code
        var RB_Yes = document.getElementById("optLimitYes");
        var RB = RB_Yes.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हाँ";
        RB[0].className = "Frm_Txt_Hindi";

        var RB_No = document.getElementById("optLimitNo");
        var RB = RB_No.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "नहीं";
        RB[0].className = "Frm_Txt_Hindi";

        var RB_Yes = document.getElementById("optSanctionBudget_Yes");
        var RB = RB_Yes.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हाँ";
        RB[0].className = "Frm_Txt_Hindi";

        var RB_No = document.getElementById("optSanctionBudget_No");
        var RB = RB_No.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "नहीं";
        RB[0].className = "Frm_Txt_Hindi";
        //===========Audit Tab============//
        document.getElementById("lblExternalAudit").innerHTML = "बाहरी आडिट";
        document.getElementById("lblInternalAudit").innerHTML = "आंतरिक आडिट";
        document.getElementById("lblExternalAudit").className = "Frm_Txt_Hindi";
        document.getElementById("lblInternalAudit").className = "Frm_Txt_Hindi";
        // Yes, No Radio button code
        var RB_Yes = document.getElementById("optExternalAudit_Yes");
        var RB = RB_Yes.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हाँ";
        RB[0].className = "Frm_Txt_Hindi";

        var RB_No = document.getElementById("optExternalAudit_No");
        var RB = RB_No.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "नहीं";
        RB[0].className = "Frm_Txt_Hindi";

        var RB_Yes = document.getElementById("optInternalAudit_yes");
        var RB = RB_Yes.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हाँ";
        RB[0].className = "Frm_Txt_Hindi";

        var RB_No = document.getElementById("optInternalAudit_No");
        var RB = RB_No.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "नहीं";
        RB[0].className = "Frm_Txt_Hindi";
        //Grid Code Start
        var table = document.getElementById("gvUser");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "चुनिये";
        tr.cells[2].innerHTML = "यूजर का नाम";
        tr.cells[3].innerHTML = "स्कीम रोल";
        tr.cells[4].innerHTML = "लेजर रोल";
        tr.cells[5].innerHTML = "एजेंसी रोल";
        tr.cells[6].innerHTML = "फोर्म रोल";
        tr.cells[7].innerHTML = "श्रेणी रोल";
        tr.cells[8].innerHTML = "एजेंसी प्रकार रोल ";
        tr.cells[9].innerHTML = "मंजूरी राशि";
        //============Hindi Text================//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
        tr.cells[5].className = "Frm_Txt_Hindi";
        tr.cells[6].className = "Frm_Txt_Hindi";
        tr.cells[7].className = "Frm_Txt_Hindi";
        tr.cells[8].className = "Frm_Txt_Hindi";
        tr.cells[9].className = "Frm_Txt_Hindi";

    }
    //Form ID 223, Form Name:frmChangePassWord.aspx
    if (Choice == 0 && FormId == 223) {
        document.getElementById("LblHeader").innerHTML = "पासवर्ड बदलें/रीसेट करें";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";

        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        //Radio button code
        var ChangePwd = document.getElementById("rbchangepassword");
        var RB = ChangePwd.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "पासवर्ड बदलें";
        RB[0].className = "Frm_Txt_Hindi";

        var ResetPwd = document.getElementById("rbresetpassword");
        var RB = ResetPwd.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "पासवर्ड रीसेट करें";
        RB[0].className = "Frm_Txt_Hindi";

        document.getElementById("lblUsername").innerHTML = "यूजर नेम";
        document.getElementById("lblOldPassword").innerHTML = "पुराना पासवर्ड";
        document.getElementById("lblNewPassword").innerHTML = "नया पासवर्ड";
        document.getElementById("lblpwdImageValue").innerHTML = "इमेज वेल्यू";
        document.getElementById("lblpwdImageValueEnter").innerHTML = "सही इमेज वेल्यू भरें";
        document.getElementById("btnsubmit").value = "सबमिट";
        document.getElementById("btncancel").value = "रद्द करे";
        //==========Hindi Text===========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblUsername").className = "Frm_Txt_Hindi";
        document.getElementById("lblOldPassword").className = "Frm_Txt_Hindi";
        document.getElementById("lblNewPassword").className = "Frm_Txt_Hindi";
        document.getElementById("lblpwdImageValue").className = "Frm_Txt_Hindi";
        document.getElementById("lblpwdImageValueEnter").className = "Frm_Txt_Hindi";
        document.getElementById("btnsubmit").className = "btn_Hindi";
        document.getElementById("btncancel").className = "btn_Hindi";
    }
    //Form ID 459, Form Name:unitmaster.aspx
    if (Choice == 0 && FormId == 459) {
        document.getElementById("LblHeader").innerHTML = "युनिट मास्टर";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("lblUnitName").innerHTML = "युनिट नाम";
        document.getElementById("lblHUnitName").innerHTML = "युनिट नाम (हिन्दी)";
        document.getElementById("lblMeasurementType").innerHTML = "माप का प्रकार";
        document.getElementById("lblMeasurementSubUnitName").innerHTML = "माप का उप युनिट नाम";
        document.getElementById("lblMeasurementUnitName").innerHTML = "माप का युनिट नाम";
        document.getElementById("lblMeasurementSubUnitRange").innerHTML = "माप का उप युनिट की सीमा";
        document.getElementById("lblHMeasurementSubUnitName").innerHTML = "माप का उप युनिट नाम (हिन्दी)";
        document.getElementById("lblHMeasurementUnitName").innerHTML = "माप का युनिट नाम (हिन्दी)";
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btnCancel").value = "रद्द करें";
        //======Hindi Text=======//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblUnitName").className = "Frm_Txt_Hindi";
        document.getElementById("lblHUnitName").className = "Frm_Txt_Hindi";
        document.getElementById("lblMeasurementType").className = "Frm_Txt_Hindi";
        document.getElementById("lblMeasurementSubUnitName").className = "Frm_Txt_Hindi";
        document.getElementById("lblMeasurementUnitName").className = "Frm_Txt_Hindi";
        document.getElementById("lblMeasurementSubUnitRange").className = "Frm_Txt_Hindi";
        document.getElementById("lblHMeasurementSubUnitName").className = "Frm_Txt_Hindi";
        document.getElementById("lblHMeasurementUnitName").className = "Frm_Txt_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";

        var table = document.getElementById("gvUnit");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "चुनिये";
        tr.cells[1].innerHTML = "युनिट नाम";
        tr.cells[2].innerHTML = "युनिट नाम (हिन्दी)";
        tr.cells[3].innerHTML = "माप का प्रकार";
        tr.cells[4].innerHTML = "माप का युनिट नाम";
        tr.cells[5].innerHTML = "माप का युनिट नाम (हिन्दी)";
        tr.cells[6].innerHTML = "माप का उप युनिट नाम";
        tr.cells[7].innerHTML = "माप का उप युनिट नाम (हिन्दी)";
        tr.cells[8].innerHTML = "माप का उप युनिट की सीमा";
        //======Hindi Text=======//
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
        //========Hindi Text=======//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblSchemeName").className = "Frm_Txt_Hindi";
        document.getElementById("lblClosingDate").className = "Frm_Txt_Hindi";
        document.getElementById("headBookClosing").className = "Frm_Txt_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnExit").className = "btn_Hindi";

        // Hindi,English Radio button code
        var Freeze = document.getElementById("rbFreeze");
        var RB = Freeze.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "स्थाई";
        RB[0].className = "Frm_Txt_Hindi";

        var UnFreeze = document.getElementById("rbUnFreeze");
        var RB = UnFreeze.parentNode.getElementsByTagName("label");
        RB[1].innerHTML = "अस्थाई";
        RB[1].className = "Frm_Txt_Hindi";
    }
    //Form ID 964, Form Name:HRManagement/Frm_EmployeeMaster.aspx
    if (Choice == 0 && (FormId == 212 || FormId == 725 || FormId == 164 || FormId == 2204 || FormId == 854)) {
        //alert(FormId);
        if (FormId == 212) {      //EmployeeMaster case
            document.getElementById("lblAgencyType").innerHTML = "एजेंसी का प्रकार ";
            if (document.getElementById("lblname") != null) {
                document.getElementById("lblname").innerHTML = "कर्मचारी का नाम ";
            }
            if (document.getElementById("lblsearch") != null) {
                document.getElementById("lblsearch").innerHTML = "कर्मचारी का नाम खोजें ";
            }
            if (document.getElementById("lblUploadImg") != null) {
                document.getElementById("lblUploadImg").innerHTML = "इमेज अपलोड  ";
            }
            if (document.getElementById("lblUploadDoc") != null) {
                document.getElementById("lblUploadDoc").innerHTML = "दस्तावेज अपलोड";
            }
            if (document.getElementById("lnkDoc") != null) {
                document.getElementById("lnkDoc").innerHTML = "दस्तावेज देखे ";
            }
            if (document.getElementById("lblNote") != null) {
                document.getElementById("lblNote").innerHTML = "अपलोड इमेज JPG,JPEG,PNG,GIF फर्मेट मे तथा दस्तावेज JPG,JPEG,PNG,GIF,PDF  फर्मेट मे होना चहिए तथा अपलोड की साईज 512 kb से अधिक नही हो सकती ";
            }
            document.getElementById("btnAdd").value = "नया जोड़ें ";
            document.getElementById("btnsubmit").value = "सबमिट ";
            document.getElementById("Button2").value = "रीसेट ";
            document.getElementById("Button3").value = "रद्द";
            if (document.getElementById("btnCalculate") != null) {
                document.getElementById("btnCalculate").value = "वेतन की गणना ";
            }
            document.getElementById("hlHome").innerHTML = "होमपेज";
            document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        }
        if (FormId == 164) {      //Agency Master case
            document.getElementById("lblAgencyType").innerHTML = "एजेंसी का प्रकार ";
            if (document.getElementById("lblname") != null) {
                document.getElementById("lblname").innerHTML = "एजेंसी का नाम ";
            }
            if (document.getElementById("lblsearch") != null) {
                document.getElementById("lblsearch").innerHTML = "एजेंसी का नाम खोजें";
            }
            document.getElementById("btnAdd").value = "नया जोड़ें ";
            document.getElementById("btnsubmit").value = "सबमिट ";
            document.getElementById("Button2").value = "रीसेट ";
            document.getElementById("Button3").value = "रद्द";
            if (document.getElementById("btnCalculate") != null) {
                document.getElementById("btnCalculate").value = "वेतन की गणना ";
            }
            document.getElementById("hlHome").innerHTML = "होमपेज";
            document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        }
        if (FormId == 2204) {      //Branch Master case
            document.getElementById("lblAgencyType").innerHTML = "एजेंसी का प्रकार ";
            if (document.getElementById("lblname") != null) {
                document.getElementById("lblname").innerHTML = "शाखा का नाम ";
            }
            if (document.getElementById("lblsearch") != null) {
                document.getElementById("lblsearch").innerHTML = "शाखा का नाम खोजें";
            }
            document.getElementById("btnAdd").value = "नया जोड़ें ";
            document.getElementById("btnsubmit").value = "सबमिट ";
            document.getElementById("Button2").value = "रीसेट ";
            document.getElementById("Button3").value = "रद्द";
            if (document.getElementById("btnCalculate") != null) {
                document.getElementById("btnCalculate").value = "वेतन की गणना ";
            }
            document.getElementById("hlHome").innerHTML = "होमपेज";
            document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        }
        if (FormId == 854) {      //TaxPayer Master case
            document.getElementById("lblAgencyType").innerHTML = "एजेंसी का प्रकार ";
            if (document.getElementById("lblname") != null) {
                document.getElementById("lblname").innerHTML = "कर भुगतानकर्ता  का नाम ";
            }
            if (document.getElementById("lblsearch") != null) {
                document.getElementById("lblsearch").innerHTML = "कर भुगतानकर्ता  का नाम खोजें";
            }
            document.getElementById("btnAdd").value = "नया जोड़ें ";
            document.getElementById("btnsubmit").value = "सबमिट ";
            document.getElementById("Button2").value = "रीसेट ";
            document.getElementById("Button3").value = "रद्द";
            if (document.getElementById("btnCalculate") != null) {
                document.getElementById("btnCalculate").value = "वेतन की गणना ";
            }
            document.getElementById("hlHome").innerHTML = "होमपेज";
            document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        }
        if (FormId == 725) {      //ADV Agency Master case
            document.getElementById("lblAgencyType").innerHTML = "एजेंसी का प्रकार ";
            if (document.getElementById("lblname") != null) {
                document.getElementById("lblname").innerHTML = "एजेंसी का नाम ";
            }
            if (document.getElementById("lblsearch") != null) {
                document.getElementById("lblsearch").innerHTML = "एजेंसी का नाम खोजें";
            }
            document.getElementById("btnAdd").value = "नया जोड़ें ";
            document.getElementById("btnsubmit").value = "सबमिट ";
            document.getElementById("Button2").value = "रीसेट ";
            document.getElementById("Button3").value = "रद्द";
            if (document.getElementById("btnCalculate") != null) {
                document.getElementById("btnCalculate").value = "वेतन की गणना ";
            }
            document.getElementById("hlHome").innerHTML = "होमपेज";
            document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        }

        var table = document.getElementById("tblStaff");
        if (table != null) {
            var tr = table.rows[0];
            tr.cells[0].innerHTML = "क्रियाएँ ";
            tr.cells[1].innerHTML = "कर्मचारी का नाम ";
            tr.cells[2].innerHTML = "यूजर कोड़";
            tr.cells[3].innerHTML = "पिता का नाम ";
            tr.cells[4].innerHTML = "जन्म तिथि ";
            tr.cells[5].innerHTML = "लिंग ";
            tr.cells[6].innerHTML = "धर्म  ";
            tr.cells[7].innerHTML = "जाति  ";
            tr.cells[8].innerHTML = "योग्यता  ";
            tr.cells[9].innerHTML = "राष्टीयता ";
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

            tr = table.rows[1];
            tr.cells[0].childNodes[0].value = "सुधारें ";
            tr.cells[1].childNodes[0].value = "हटाएँ";
            tr.cells[0].className = "Frm_Txt_Hindi";
            tr.cells[1].className = "Frm_Txt_Hindi";
        }
        var table1 = document.getElementById("tblAgency");
        if (table1 != null) {
            var tr = table1.rows[0];
            tr.cells[0].innerHTML = "क्रियाएँ ";
            tr = table1.rows[1];
            tr.cells[0].childNodes[0].value = "सुधारें ";
            tr.cells[1].childNodes[0].value = "हटाएँ";

        }
        // document.getElementById("reptList_ctl01_linkbtnDelete").innerHTML = "हटाएँ";

    }
//Frm_Upload.aspx
    if (Choice == 0 && FormId == 2531) {
        document.getElementById("LblHeader").innerHTML = "डाटा अपलोड ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
//        var RBHindi = document.getElementById("rbHindi");
//        var RB = RBHindi.parentNode.getElementsByTagName("label");
//        RB[0].innerHTML = "हिन्दी";

//        var RBenglish = document.getElementById("rbenglish");
//        var RB = RBenglish.parentNode.getElementsByTagName("label");
//        RB[0].innerHTML = "English";
        // Lebel code//
        document.getElementById("lblSelectFile").innerHTML = "फाईल चुनें ";
        document.getElementById("lblDocTitle").innerHTML = "फाईल नाम ";
        document.getElementById("btnUpload").value = "अपलोड";
        document.getElementById("btnCancel").value = "रद्द ";
        //========Hindi Text=======//
        document.getElementById("lblSelectFile").className = "Frm_Txt_Hindi";
        document.getElementById("lblDocTitle").className = "Frm_Txt_Hindi";
        
        document.getElementById("btnUpload").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";

        // Hindi,English Radio button code

    }
    //Frm_Upload.aspx
    if (Choice == 0 && FormId == 2532) {
        document.getElementById("LblHeader").innerHTML = "डाटा डाऊनलोड  ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
       
        // Hindi,English Radio button code

    }


    //Form ID: 2506 Form Name : PanchParmeshwar/Master/frm_DistrictMaster.aspx    
    if (Choice == 0 && FormId == 2506) {
        document.getElementById("lblAgencyType").innerHTML = "एजेंसी का प्रकार ";
        if (document.getElementById("lblname") != null) {
            document.getElementById("lblname").innerHTML = "शाखा का नाम ";
        }
        if (document.getElementById("lblsearch") != null) {
            document.getElementById("lblsearch").innerHTML = "शाखा का नाम खोजें";
        }
        document.getElementById("btnAdd").value = "नया जोड़ें ";
        document.getElementById("btnsubmit").value = "सबमिट करें";
        document.getElementById("Button2").value = "रीसेट करें";
        document.getElementById("Button3").value = "रद्द करें";
        if (document.getElementById("btnCalculate") != null) {
            document.getElementById("btnCalculate").value = "वेतन की गणना ";
        }
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";

        var table = document.getElementById("tblStaff");
        if (table != null) {
            var tr = table.rows[0];
            tr.cells[0].innerHTML = "क्रियाएँ ";
            tr.cells[1].innerHTML = "कर्मचारी का नाम ";
            tr.cells[2].innerHTML = "यूजर कोड़";
            tr.cells[3].innerHTML = "पिता का नाम ";
            tr.cells[4].innerHTML = "जन्म तिथि ";
            tr.cells[5].innerHTML = "लिंग ";
            tr.cells[6].innerHTML = "धर्म  ";
            tr.cells[7].innerHTML = "जाति  ";
            tr.cells[8].innerHTML = "योग्यता  ";
            tr.cells[9].innerHTML = "राष्टीयता ";
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

            tr = table.rows[1];
            tr.cells[0].childNodes[0].value = "सुधारें ";
            tr.cells[1].childNodes[0].value = "हटाएँ";
            tr.cells[0].className = "Frm_Txt_Hindi";
            tr.cells[1].className = "Frm_Txt_Hindi";
        }
        var table1 = document.getElementById("tblAgency");
        if (table1 != null) {
            var tr = table1.rows[0];
            tr.cells[0].innerHTML = "क्रियाएँ ";
            tr = table1.rows[1];
            tr.cells[0].childNodes[0].value = "सुधारें ";
            tr.cells[1].childNodes[0].value = "हटाएँ";
        }
    }


    //Form ID: 2507 Form Name : PanchParmeshwar/Master/frm_BlockMaster.aspx    
    if (Choice == 0 && FormId == 2507) {
        document.getElementById("lblAgencyType").innerHTML = "एजेंसी का प्रकार ";
        if (document.getElementById("lblname") != null) {
            document.getElementById("lblname").innerHTML = "शाखा का नाम ";
        }
        if (document.getElementById("lblsearch") != null) {
            document.getElementById("lblsearch").innerHTML = "शाखा का नाम खोजें";
        }
        document.getElementById("btnAdd").value = "नया जोड़ें ";
        document.getElementById("btnsubmit").value = "सबमिट करें";
        document.getElementById("Button2").value = "रीसेट करें";
        document.getElementById("Button3").value = "रद्द करें";
        if (document.getElementById("btnCalculate") != null) {
            document.getElementById("btnCalculate").value = "वेतन की गणना ";
        }
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";

        var table = document.getElementById("tblStaff");
        if (table != null) {
            var tr = table.rows[0];
            tr.cells[0].innerHTML = "क्रियाएँ ";
            tr.cells[1].innerHTML = "कर्मचारी का नाम ";
            tr.cells[2].innerHTML = "यूजर कोड़";
            tr.cells[3].innerHTML = "पिता का नाम ";
            tr.cells[4].innerHTML = "जन्म तिथि ";
            tr.cells[5].innerHTML = "लिंग ";
            tr.cells[6].innerHTML = "धर्म  ";
            tr.cells[7].innerHTML = "जाति  ";
            tr.cells[8].innerHTML = "योग्यता  ";
            tr.cells[9].innerHTML = "राष्टीयता ";
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

            tr = table.rows[1];
            tr.cells[0].childNodes[0].value = "सुधारें ";
            tr.cells[1].childNodes[0].value = "हटाएँ";
            tr.cells[0].className = "Frm_Txt_Hindi";
            tr.cells[1].className = "Frm_Txt_Hindi";
        }
        var table1 = document.getElementById("tblAgency");
        if (table1 != null) {
            var tr = table1.rows[0];
            tr.cells[0].innerHTML = "क्रियाएँ ";
            tr = table1.rows[1];
            tr.cells[0].childNodes[0].value = "सुधारें ";
            tr.cells[1].childNodes[0].value = "हटाएँ";
        }
    }
    //Form ID: 2508 Form Name : PanchParmeshwar/Master/frm_GramPanchayat_Master.aspx    
    if (Choice == 0 && FormId == 2508) {
        document.getElementById("lblAgencyType").innerHTML = "एजेंसी का प्रकार ";
        if (document.getElementById("lblname") != null) {
            document.getElementById("lblname").innerHTML = "शाखा का नाम ";
        }
        if (document.getElementById("lblsearch") != null) {
            document.getElementById("lblsearch").innerHTML = "शाखा का नाम खोजें";
        }
        document.getElementById("btnAdd").value = "नया जोड़ें ";
        document.getElementById("btnsubmit").value = "सबमिट करें";
        document.getElementById("Button2").value = "रीसेट करें";
        document.getElementById("Button3").value = "रद्द करें";
        if (document.getElementById("btnCalculate") != null) {
            document.getElementById("btnCalculate").value = "वेतन की गणना ";
        }
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";

        var table = document.getElementById("tblStaff");
        if (table != null) {
            var tr = table.rows[0];
            tr.cells[0].innerHTML = "क्रियाएँ ";
            tr.cells[1].innerHTML = "कर्मचारी का नाम ";
            tr.cells[2].innerHTML = "यूजर कोड़";
            tr.cells[3].innerHTML = "पिता का नाम ";
            tr.cells[4].innerHTML = "जन्म तिथि ";
            tr.cells[5].innerHTML = "लिंग ";
            tr.cells[6].innerHTML = "धर्म  ";
            tr.cells[7].innerHTML = "जाति  ";
            tr.cells[8].innerHTML = "योग्यता  ";
            tr.cells[9].innerHTML = "राष्टीयता ";
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

            tr = table.rows[1];
            tr.cells[0].childNodes[0].value = "सुधारें ";
            tr.cells[1].childNodes[0].value = "हटाएँ";
            tr.cells[0].className = "Frm_Txt_Hindi";
            tr.cells[1].className = "Frm_Txt_Hindi";
        }
        var table1 = document.getElementById("tblAgency");
        if (table1 != null) {
            var tr = table1.rows[0];
            tr.cells[0].innerHTML = "क्रियाएँ ";
            tr = table1.rows[1];
            tr.cells[0].childNodes[0].value = "सुधारें ";
            tr.cells[1].childNodes[0].value = "हटाएँ";
        }
    }
    

}