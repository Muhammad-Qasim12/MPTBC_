var GlobalLanguage;
function ChangeLabel(Choice, FormId, QueryString) {
    //Form ID 2212, Form Name:Master_Pages/frm_TDSRateMaster.aspx
    if (Choice == 0 && FormId == 2212) {
        document.getElementById("LblHeader").innerHTML = "टी डी एस रेट मास्टर";
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
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btnEdit").value = "सुधारें";
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("btnDelete").value = "हटायें";
        document.getElementById("btnExit").value = "बाहर निकलें";
        document.getElementById("lblRateName").innerHTML = "दर का नाम";
        document.getElementById("lblHindiRateName").innerHTML = "दर का नाम(हिन्दी)";
        document.getElementById("lblTypeofPayment").innerHTML = "भुगतान का प्रकार";
        document.getElementById("lblCode").innerHTML = "कोड";
        document.getElementById("lblEffectiveDate").innerHTML = "प्रभावित तिथि";
        document.getElementById("lblDuePeriod").innerHTML = "देय अवघि";
        document.getElementById("lblTaxRate").innerHTML = "कर की दर";
        document.getElementById("lblSurcharge").innerHTML = "अधिभार";
        document.getElementById("lblEducationCess").innerHTML = "शिक्षा उपकर";
        //=======Hindi Text ============//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("btnDelete").className = "btn_Hindi";
        document.getElementById("btnExit").className = "btn_Hindi";
        document.getElementById("lblRateName").className = "Frm_Txt_Hindi";
        document.getElementById("lblHindiRateName").className = "Frm_Txt_Hindi";
        document.getElementById("lblTypeofPayment").className = "Frm_Txt_Hindi";
        document.getElementById("lblCode").className = "Frm_Txt_Hindi";
        document.getElementById("lblEffectiveDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblDuePeriod").className = "Frm_Txt_Hindi";
        document.getElementById("lblTaxRate").className = "Frm_Txt_Hindi";
        document.getElementById("lblSurcharge").className = "Frm_Txt_Hindi";
        document.getElementById("lblEducationCess").className = "Frm_Txt_Hindi";

        // Grid Code Start
        var table = document.getElementById("gvGroupStatus");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "स्थिति नाम";
        //============Hindi Text================//
        tr.cells[0].className = "Frm_Txt_Hindi";

        // Grid Code Start
        var table = document.getElementById("gvTDSRateMaster");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "चुनियें";
        tr.cells[1].innerHTML = "दर का नाम";
        tr.cells[2].innerHTML = "दर का नाम(हिन्दी)";
        tr.cells[3].innerHTML = "भुगतान का प्रकार";
        tr.cells[4].innerHTML = "कोड";
        tr.cells[5].innerHTML = "प्रभावित तिथि";
        tr.cells[6].innerHTML = "देय अवघि";
        tr.cells[7].innerHTML = "दर";
        tr.cells[8].innerHTML = "अधिभार";
        tr.cells[9].innerHTML = "शिक्षा उपकर";
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
    }
    //Form ID 2222, Form Name:Finance/frm_TDS_Configuration.aspx
    if (Choice == 0 && FormId == 2222) {
        document.getElementById("LblHeader").innerHTML = "टी.डी.एस.कॉन्फीगरेशन";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("lblHeaderDetail").innerHTML = "भुगतान देयक";
        document.getElementById("lblEffectiveDate").innerHTML = "प्रभावित तिथि";
        document.getElementById("lblDeductingTax").innerHTML = "कर कटौती करने वाले व्‍यक्ति का नाम";
        document.getElementById("lblPersonDeducting").innerHTML = "कर कटौती करने वाले व्‍यक्ति का पता";
        document.getElementById("lblBranchType0").innerHTML = "शाखा का प्रकार";
        document.getElementById("lblBranchName0").innerHTML = "शाखा का नाम";
        document.getElementById("btnSaveSetting").value = "रक्षित करें";
        //======= font increase =======//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblEffectiveDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblDeductingTax").className = "Frm_Txt_Hindi";
        document.getElementById("lblPersonDeducting").className = "Frm_Txt_Hindi";
        document.getElementById("lblBranchType0").className = "Frm_Txt_Hindi";
        document.getElementById("lblBranchName0").className = "Frm_Txt_Hindi";
        document.getElementById("btnSaveSetting").className = "btn_Hindi";

        document.getElementById("LblHeader").innerHTML = "टी डी एस रेट मास्टर";
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


        document.getElementById("btnsave_Ledger").value = "रक्षित करें";
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("lblConfigType").innerHTML = "कांफिगरेशन का प्रकार";
        document.getElementById("lblLedgerEffectiveDt").innerHTML = "प्रभावित तिथि";
        document.getElementById("lblLedgerType").innerHTML = "लेज़र का प्रकार";
        document.getElementById("lblPayment").innerHTML = "टी डी एस कांफिगरेशन";
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
    //Form ID 2221, Form Name:Finance/frm_Challan_Reconciliation.aspx
    if (Choice == 0 && FormId == 2221) {
        document.getElementById("LblHeader").innerHTML = "चालान समाधान विवरण ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("btnExit").value = "बाहर निकलें";
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btnCancel").value = "रद्द करें";
       // document.getElementById("lblSchemeName").innerHTML = "स्कीम का नाम";
        document.getElementById("lblChallanNo").innerHTML = "चालान नंबर";
        document.getElementById("lblLastBSR").innerHTML = "पिछला बी.एस.आर.";
        document.getElementById("lblBSR").innerHTML = "बी.एस.आर.";
        document.getElementById("lblTaxDeposited").innerHTML = "कर जमा करने की तिथि";
        document.getElementById("lblLastTransferVoucher").innerHTML = "पिछला हस्‍तातरण वाउचर / चालान क्रमाक नं. ";
        document.getElementById("lblTransferVoucher").innerHTML = "हस्‍तातरण वाउचर / चालान क्रमाक नं. ";
        document.getElementById("lblDepositedByBookEntry").innerHTML = "टी.डी.एस. लेखा बही की प्रविष्टि के अनुसार जमा";
        document.getElementById("lblIncome").innerHTML = "आय";
        document.getElementById("lblSurcharge").innerHTML = "अतिरिक्‍त शुल्‍क";
        document.getElementById("lblEducation").innerHTML = "शिक्षा";
        document.getElementById("lblInterest").innerHTML = "ब्‍याज ";
        document.getElementById("lblPenalty").innerHTML = "जुर्माना ";
        document.getElementById("lblOther").innerHTML = "अन्‍य";
        document.getElementById("lblTotal").innerHTML = "कुल योग";
        //font increase ===//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnExit").className = "btn_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("lblSchemeName").className = "Frm_Txt_Hindi";
        document.getElementById("lblChallanNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblLastBSR").className = "Frm_Txt_Hindi";
        document.getElementById("lblBSR").className = "Frm_Txt_Hindi";
        document.getElementById("lblTaxDeposited").className = "Frm_Txt_Hindi";
        document.getElementById("lblLastTransferVoucher").className = "Frm_Txt_Hindi";
        document.getElementById("lblTransferVoucher").className = "Frm_Txt_Hindi";
        document.getElementById("lblDepositedByBookEntry").className = "Frm_Txt_Hindi";
        document.getElementById("lblIncome").className = "Frm_Txt_Hindi";
        document.getElementById("lblSurcharge").className = "Frm_Txt_Hindi";
        document.getElementById("lblEducation").className = "Frm_Txt_Hindi";
        document.getElementById("lblInterest").className = "Frm_Txt_Hindi";
        document.getElementById("lblPenalty").className = "Frm_Txt_Hindi";
        document.getElementById("lblOther").className = "Frm_Txt_Hindi";
        document.getElementById("lblTotal").className = "Frm_Txt_Hindi";

        // Yes,No Radio button code
        var RBYes = document.getElementById("rbYes");
        var Yes = RBYes.parentNode.getElementsByTagName("label");
        Yes[0].innerHTML = " हाँ";
        Yes[0].className = "Frm_Txt_Hindi";

        var RBNo = document.getElementById("rbNo");
        var No = RBNo.parentNode.getElementsByTagName("label");
        No[1].innerHTML = " नहीं";
        No[1].className = "Frm_Txt_Hindi";
    }   
  
}