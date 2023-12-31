
//=============== here 1: English,0: Hindi,2:===================//
var GlobalLanguage;
function ChangeLabel(Choice, FormId, QueryString) {

    GlobalLanguage = Choice;
    //=============== WebYojna Hindi Label Managed Code Start ===================//
    //Form ID 182, Form Name:Frm_department.aspx
    if (Choice == 0 && FormId == 182) {
        document.getElementById("LblHeader").innerHTML = "विभाग मास्टर";
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
        document.getElementById("lblDepartmentDetail").innerHTML = "विभाग विवरण";
        document.getElementById("lblDepartmentName").innerHTML = "विभाग का नाम (अंग्रेजी)";
        document.getElementById("lbldeptinhindi").innerHTML = "विभाग का नाम (हिन्दी)";
        document.getElementById("lbldeptcode").innerHTML = "विभाग कोड";
        document.getElementById("lblDesignation").innerHTML = "विभाग का मुखिया";
        document.getElementById("btnsave").value = "रक्षित करें";
        document.getElementById("btnCancel").value = "रद्द करें";
        //============Hindi Text================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblDepartmentDetail").className = "Frm_Txt_Hindi";
        document.getElementById("lblDepartmentName").className = "Frm_Txt_Hindi";
        document.getElementById("lbldeptinhindi").className = "Frm_Txt_Hindi";
        document.getElementById("lbldeptcode").className = "Frm_Txt_Hindi";
        document.getElementById("lblDesignation").className = "Frm_Txt_Hindi";
        document.getElementById("btnsave").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("ddlDesignation").className = "ddl_Hindi";

        // Grid Code Start
        var table = document.getElementById("gvDepartment");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "चुनिये";
        tr.cells[1].innerHTML = "हटाएँ ";
        tr.cells[2].innerHTML = "विभाग का नाम (अंग्रेजी)";
        tr.cells[3].innerHTML = "विभाग का नाम (हिन्दी)";
        tr.cells[4].innerHTML = "विभाग कोड";
        tr.cells[5].innerHTML = "विभाग का मुखिया";
        //============Hindi Text================//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
        tr.cells[5].className = "Frm_Txt_Hindi";
    }
    //Form ID 183, Form Name:frm_division.aspx
    if (Choice == 0 && FormId == 183) {
        document.getElementById("LblHeader").innerHTML = "शाखा मास्टर";
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
        document.getElementById("lblDivisionDetail").innerHTML = "शाखा विवरण";
        document.getElementById("lblDivisionName").innerHTML = "शाखा का नाम (अंग्रेजी)";
        document.getElementById("lblDivinhindi").innerHTML = "शाखा का नाम (हिन्दी)";
        document.getElementById("lbldivcode").innerHTML = "शाखा कोड";
        document.getElementById("lbldeptname").innerHTML = "विभाग का नाम";
        document.getElementById("btnsave").value = "रक्षित करें";
        document.getElementById("btndelete").value = "हटाऐ";
        document.getElementById("btnCancel").value = "रद्ध करे"
        //============Hindi Text================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblDivisionDetail").className = "Frm_Txt_Hindi";
        document.getElementById("lblDivisionName").className = "Frm_Txt_Hindi";
        document.getElementById("lblDivinhindi").className = "Frm_Txt_Hindi";
        document.getElementById("lbldivcode").className = "Frm_Txt_Hindi";
        document.getElementById("lbldeptname").className = "Frm_Txt_Hindi";
        document.getElementById("btnsave").className = "btn_Hindi";
        document.getElementById("btndelete").className = "btn_Hindi";
        document.getElementById("ddldeptname").className = "ddl_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";

        // Grid Code Start
        var table = document.getElementById("gvDivision");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "चुनिये";
        tr.cells[1].innerHTML = "हटाएँ ";
        tr.cells[2].innerHTML = "शाखा का नाम (अंग्रेजी)";
        tr.cells[3].innerHTML = "शाखा का नाम (हिन्दी)";
        tr.cells[4].innerHTML = "शाखा कोड";
        tr.cells[5].innerHTML = "विभाग का नाम";
       
        //============Hindi Text================//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
        tr.cells[5].className = "Frm_Txt_Hindi";
    }

    //Form ID 222, Form Name:frmLeaveManagement.aspx
    if (Choice == 0 && FormId == 222) {
        document.getElementById("LblHeader").innerHTML = "अवकाश आवेदन";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";

        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("BtnSave").value = "रक्षित करे";
        document.getElementById("BtnCancel").value = "रद्द करे";
        document.getElementById("BtnExit").value = "बाहर निकलें";
        document.getElementById("LblDtApplying").innerHTML = "आवेदन की दिनांक";
        document.getElementById("LblDepartment").innerHTML = "विभाग का नाम";
        document.getElementById("LblDivision").innerHTML = "शाखा का नाम";
        document.getElementById("LblEmployeeName").innerHTML = "कर्मचारी का नाम";
        document.getElementById("LblTypeofLeave").innerHTML = "छुट्टी का प्रकार";
        document.getElementById("LblFromDt").innerHTML = "दिनांक से";
        document.getElementById("LblTypeofLeave").innerHTML = "छुट्टी का प्रकार";
        document.getElementById("LblLeaveReason").innerHTML = "छुट्टी का कारण";
        document.getElementById("LblSanctionBy").innerHTML = "स्वीकृत द्वारा ";
        document.getElementById("LblDaysNo").innerHTML = "दिनों की संख्या ";
        document.getElementById("LblBalanceDays").innerHTML = "बचे हुऐ दिन";
        document.getElementById("lblTodate").innerHTML = "दिनांक तक ";
        document.getElementById("LblAddressLeave").innerHTML = "अवकाश काल का पता ";
        document.getElementById("lblUploadBill").innerHTML = "अपलोड अवकाश फाईल ";

        //=======Hindi Text ============//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("BtnSave").className = "btn_Hindi";
        document.getElementById("BtnCancel").className = "btn_Hindi";
        document.getElementById("BtnExit").className = "btn_Hindi";
        document.getElementById("LblDtApplying").className = "Frm_Txt_Hindi";
        document.getElementById("LblDepartment").className = "Frm_Txt_Hindi";
        document.getElementById("LblDivision").className = "Frm_Txt_Hindi";
        document.getElementById("LblEmployeeName").className = "Frm_Txt_Hindi";
        document.getElementById("LblTypeofLeave").className = "Frm_Txt_Hindi";
        document.getElementById("LblFromDt").className = "Frm_Txt_Hindi";
        document.getElementById("LblTypeofLeave").className = "Frm_Txt_Hindi";
        document.getElementById("LblLeaveReason").className = "Frm_Txt_Hindi";
        document.getElementById("LblSanctionBy").className = "Frm_Txt_Hindi";
        document.getElementById("LblDaysNo").className = "Frm_Txt_Hindi";
        document.getElementById("LblBalanceDays").className = "Frm_Txt_Hindi";
        document.getElementById("lblTodate").className = "Frm_Txt_Hindi";
        document.getElementById("LblAddressLeave").className = "Frm_Txt_Hindi";
        document.getElementById("lblUploadBill").className = "Frm_Txt_Hindi";
        

        // Grid Code Start
        var table = document.getElementById("GridView1");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "कर्मचारी का नाम";
        tr.cells[1].innerHTML = "दिनों की संख्या ";
        tr.cells[2].innerHTML = "दिनांक से";
        tr.cells[3].innerHTML = "दिनांक तक";
        tr.cells[4].innerHTML = "छुट्टी का कारण";
        tr.cells[5].innerHTML = "छुट्टी का प्रकार";
        tr.cells[6].innerHTML = "आवेदन की दिनांक";
        tr.cells[7].innerHTML = "स्वीकृत छुट्टी";
        tr.cells[8].innerHTML = "स्वीकृत द्वारा ";
        tr.cells[9].innerHTML = "स्वीकृति  दिनांक";
        tr.cells[10].innerHTML = "स्वीकृति  दिनांक";
        //=======Hindi Text ============//
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

    }


    //Form ID 227, Form Name:HRManagement/frm_Increment.aspx
    if (Choice == 0 && FormId == 227) {
        document.getElementById("LblHeader").innerHTML = "स्वत : वेतन वृद्धि और रोक";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";

        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("lblIncrementDetails").innerHTML = "वेतन वृद्धि विवरण";
        document.getElementById("lblEmployeename").innerHTML = "कर्मचारी का नाम";
        document.getElementById("ChkManualIncrement").nextSibling.innerHTML = " मैन्युयल वेतन वृद्धि";
        document.getElementById("lblGrade").innerHTML = "ग्रेड";
        document.getElementById("lblCurrentSalary").innerHTML = "वर्तमान वेतन";
        document.getElementById("lblIncrementNo").innerHTML = "वेतन वृद्धि नंबर";
        document.getElementById("lblSalaryAfterEffect").innerHTML = "वृद्धि के बाद वेतन";
        document.getElementById("lblReason").innerHTML = "कारण";
        document.getElementById("lblOrderNo").innerHTML = "आदेश नंबर";
        document.getElementById("lblArrears").innerHTML = "एरियर्स";
        document.getElementById("lblOrderDate").innerHTML = "आदेश तिथि";
        document.getElementById("lblEffectiveDate").innerHTML = "प्रभावित तिथि";
        document.getElementById("lblRemark").innerHTML = "विवरण";
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("btnCalculateSalary").value = "वेतन वृद्धि की गणना";
        document.getElementById("btnEnableCtrl").value = "सुधारें";
        //==========Hindi Text===========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblIncrementDetails").className = "Frm_Txt_Hindi";
        document.getElementById("lblEmployeename").className = "Frm_Txt_Hindi";
        document.getElementById("ChkManualIncrement").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("lblGrade").className = "Frm_Txt_Hindi";
        document.getElementById("lblCurrentSalary").className = "Frm_Txt_Hindi";
        document.getElementById("lblIncrementNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblSalaryAfterEffect").className = "Frm_Txt_Hindi";
        document.getElementById("lblReason").className = "Frm_Txt_Hindi";
        document.getElementById("lblOrderNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblArrears").className = "Frm_Txt_Hindi";
        document.getElementById("lblOrderDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblEffectiveDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemark").className = "Frm_Txt_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("btnCalculateSalary").className = "btn_Hindi";
        document.getElementById("btnEnableCtrl").className = "btn_Hindi";
    }
    //Form ID 230, Form Name:HRManagement/Master/frm_PostMaster.aspx
    if (Choice == 0 && FormId == 230) {

        document.getElementById("LblHeader").innerHTML = "पद मास्टर";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("lblPostName").innerHTML = "पद नाम";
        document.getElementById("lblHPostName").innerHTML = "पद नाम (हिन्दी)";
        document.getElementById("lblAge").innerHTML = "आयु";
        document.getElementById("lblMinAge").innerHTML = "न्युनतम ";
        document.getElementById("lblMaxAge").innerHTML = "अधिकतम ";
        document.getElementById("lblClass").innerHTML = "श्रेणी";
        document.getElementById("lblPostCode").innerHTML = "पद कोड";
        document.getElementById("lblMinimumQualification").innerHTML = "न्युनतम योग्यता";
        document.getElementById("lblExperience").innerHTML = "अनुभव";
        document.getElementById("LblTotalPost").innerHTML = "कुल पद";
        document.getElementById("lblUploadBill").innerHTML = "अपलोड आदेश";
        document.getElementById("Label1").innerHTML = "नियुक्ती का तरीका";
        document.getElementById("lblPromotion").innerHTML = "पदोन्नती";
        document.getElementById("lblDirectRecuitment").innerHTML = "सीधी भर्ती";
        document.getElementById("lblDeputation").innerHTML = "प्रतिनियुक्ति";
        document.getElementById("lblCategory").innerHTML = "तालिका ";
        document.getElementById("lblSTNo").innerHTML = "एस टी";
        document.getElementById("lblSCNo").innerHTML = "एस सी";
        document.getElementById("lblOBC").innerHTML = "ओ बी सी";
//        document.getElementById("lblPayGrade").innerHTML = "वेतन मान";
        document.getElementById("lblGeneral").innerHTML = "सामान्य";
        document.getElementById("lblDST").innerHTML = "एस टी";
        document.getElementById("lblDSC").innerHTML = "एस सी";
        document.getElementById("lblDOBC").innerHTML = "ओ बी सी";
        document.getElementById("lblDGen").innerHTML = "सामान्य";
        document.getElementById("lblDTPost").innerHTML = "नियुक्ती का तरीका";
        document.getElementById("lblDPromotion").innerHTML = "पदोन्नती";
        document.getElementById("lblDirectRecuritment").innerHTML = "सीधी भर्ती";
        document.getElementById("lblDeputaion").innerHTML = "प्रतिनियुक्ति";
        document.getElementById("lblNote").innerHTML = "नोट :-";
        document.getElementById("lblnoteDetail").innerHTML = "फाईल का प्रकार JPG,JPEG,PNG,GIF,PDF मेँ हो और इसकी साईज़ 512 KB से ज्यादा ना हो । ";

        
        document.getElementById("btnSave").value = "रक्षित करे";
        document.getElementById("btnClear").value = "रद्द करे";
        
        

        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblPostName").className = "Frm_Txt_Hindi";
        document.getElementById("lblHPostName").className = "Frm_Txt_Hindi";
        document.getElementById("lblAge").className = "Frm_Txt_Hindi";
        document.getElementById("lblMinAge").className = "Frm_Txt_Hindi";
        document.getElementById("lblMaxAge").className = "Frm_Txt_Hindi";
        document.getElementById("lblClass").className = "Frm_Txt_Hindi";

        document.getElementById("lblPostCode").className = "Frm_Txt_Hindi";
        document.getElementById("lblMinimumQualification").className = "Frm_Txt_Hindi";
        document.getElementById("lblExperience").className = "Frm_Txt_Hindi";
        document.getElementById("LblTotalPost").className = "Frm_Txt_Hindi";
//        document.getElementById("lblPayGrade").className = "Frm_Txt_Hindi";
//        document.getElementById("lblUploadBill").className = "Frm_Txt_Hindi";
        document.getElementById("Label1").className = "Frm_Txt_Hindi";
        document.getElementById("lblPromotion").className = "Frm_Txt_Hindi";
        document.getElementById("lblDirectRecuitment").className = "Frm_Txt_Hindi";
        document.getElementById("lblDeputation").className = "Frm_Txt_Hindi";
        document.getElementById("lblCategory").className = "Frm_Txt_Hindi";
        document.getElementById("lblSTNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblSCNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblOBC").className = "Frm_Txt_Hindi";
        document.getElementById("lblGeneral").className = "Frm_Txt_Hindi";
        document.getElementById("lblDST").className = "Frm_Txt_Hindi";
        document.getElementById("lblDSC").className = "Frm_Txt_Hindi";
        document.getElementById("lblDOBC").className = "Frm_Txt_Hindi";
        document.getElementById("lblDGen").className = "Frm_Txt_Hindi";
        document.getElementById("lblDTPost").className = "Frm_Txt_Hindi";
        document.getElementById("lblDPromotion").className = "Frm_Txt_Hindi";
        document.getElementById("lblDirectRecuritment").className = "Frm_Txt_Hindi";
        document.getElementById("lblUploadBill").className = "Frm_Txt_Hindi";
        document.getElementById("lblNote").className = "Frm_Txt_Hindi";
        document.getElementById("lblnoteDetail").className = "Frm_Txt_Hindi";

        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnClear").className = "btn_Hindi";

        //Grid Code Start
        var table = document.getElementById("gvPost");
        var tr = table.rows[0];
        tr.cells[1].innerHTML = "सुधारें";
        tr.cells[2].innerHTML = "हटायें";
        tr.cells[3].innerHTML = "पद नाम";
        tr.cells[4].innerHTML = "पद नाम (हिन्दी)";
        tr.cells[5].innerHTML = "न्युनतम-अधिकतम आयु";
        tr.cells[6].innerHTML = "श्रेणी";
        tr.cells[7].innerHTML = "पद कोड";
        tr.cells[8].innerHTML = "न्युनतम योग्यता";
        tr.cells[9].innerHTML = "अनुभव";
//        tr.cells[10].innerHTML = "वेतन मान";
        tr.cells[10].innerHTML = "पद देखेँ";
        tr.cells[11].innerHTML = "तालिका देखेँ";
        tr.cells[12].innerHTML = "आदेश देखेँ";
        //============Hindi Text================//
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
        tr.cells[5].className = "Frm_Txt_Hindi";
        tr.cells[6].className = "Frm_Txt_Hindi";
        tr.cells[7].className = "Frm_Txt_Hindi";
        tr.cells[8].className = "Frm_Txt_Hindi";
        tr.cells[9].className = "Frm_Txt_Hindi";
//        tr.cells[10].className = "Frm_Txt_Hindi";
        tr.cells[10].className = "Frm_Txt_Hindi";
        tr.cells[11].className = "Frm_Txt_Hindi";
        tr.cells[12].className = "Frm_Txt_Hindi";


    }
    //Form ID 231, Form Name:HRManagement/frm_Nominee.aspx
    if (Choice == 0 && FormId == 231) {
        document.getElementById("LblHeader").innerHTML = "नामांकित सदस्यों का विवरण";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
//        var RBHindi = document.getElementById("rbHindi");
//        var RB = RBHindi.parentNode.getElementsByTagName("label");
//        RB[0].innerHTML = "हिन्दी";

//        var RBenglish = document.getElementById("rbenglish");
//        var RB = RBenglish.parentNode.getElementsByTagName("label");
//        RB[0].innerHTML = "English";

        document.getElementById("btnNew").value = "नया बनायें";
        document.getElementById("btnEdit").value = "सुधारें";
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("BtnCancel").value = "रद्द करें";
        document.getElementById("btnExit").value = "बाहर निकलें";
        document.getElementById("lblEmployee").innerHTML = "कर्मचारी का नाम";
        document.getElementById("lblNominee").innerHTML = "नामांकित का नाम ";
        document.getElementById("lblNomineeAge").innerHTML = "नामांकित की उम्र ";
        document.getElementById("lblRelationWithEmp").innerHTML = "कर्मचारी से सम्बन्ध";
        document.getElementById("lblPreference").innerHTML = "प्राथमिकता";
        

        // First,Second Radio button code
        var First = document.getElementById("rbFirstPreference");
        var RB = First.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "प्रथम";
        RB[0].className = "Frm_Txt_Hindi";
        var Second = document.getElementById("rbSecondPreference");
        var RB = Second.parentNode.getElementsByTagName("label");
        RB[1].innerHTML = "द्वितीय";
        RB[1].className = "Frm_Txt_Hindi";

        //============Hindi Text================//
        document.getElementById("lblEmployee").className = "Frm_Txt_Hindi";
        document.getElementById("lblNominee").className = "Frm_Txt_Hindi";
        document.getElementById("lblNomineeAge").className = "Frm_Txt_Hindi";
        document.getElementById("lblRelationWithEmp").className = "Frm_Txt_Hindi";
        document.getElementById("lblPreference").className = "Frm_Txt_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("BtnCancel").className = "btn_Hindi";
        document.getElementById("btnExit").className = "btn_Hindi";
        //Grid Hindi

        var table = document.getElementById("gvNominee");
        if (document.getElementById("gvNominee") != null) {
            var tr = table.rows[0];
            tr.cells[0].innerHTML = "चुनिये";
            tr.cells[1].innerHTML = "हटाएँ ";
            tr.cells[2].innerHTML = "नामांकित का नाम";
            tr.cells[3].innerHTML = "नामांकित की आयु";
            tr.cells[4].innerHTML = "कर्मचारी से संबंध";
            tr.cells[5].innerHTML = "प्राथमिकता";
            //============Hindi Text================//
            tr.cells[0].className = "Frm_Txt_Hindi";
            tr.cells[1].className = "Frm_Txt_Hindi";
            tr.cells[2].className = "Frm_Txt_Hindi";
            tr.cells[3].className = "Frm_Txt_Hindi";
            tr.cells[4].className = "Frm_Txt_Hindi";
            tr.cells[5].className = "Frm_Txt_Hindi";
        }
    }
    //Form ID 232, Form Name:HRManagement/frm_Dependent.aspx
    if (Choice == 0 && FormId == 232) {
        document.getElementById("LblHeader").innerHTML = "आश्रितों का विवरण";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
//        var RBHindi = document.getElementById("rbHindi");
//        var RB = RBHindi.parentNode.getElementsByTagName("label");
//        RB[0].innerHTML = "हिन्दी";

//        var RBenglish = document.getElementById("rbenglish");
//        var RB = RBenglish.parentNode.getElementsByTagName("label");
        //        RB[0].innerHTML = "English";
        document.getElementById("btnNew").value = "नया बनायें";
        document.getElementById("btnEdit").value = "सुधारें";
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("BtnCancel").value = "रद्द करें";
        document.getElementById("btnExit").value = "बाहर निकलें";
        document.getElementById("lblEmployee").innerHTML = "कर्मचारी का नाम";
        document.getElementById("lblNameOfDependent").innerHTML = "आश्रित का नाम";
        document.getElementById("lblDependentAge").innerHTML = "आश्रित की आयु";
        document.getElementById("lblRelationWithEmp").innerHTML = "कर्मचारी से संबंध";

        //============Hindi Text================//
        document.getElementById("lblEmployee").className = "Frm_Txt_Hindi";
        document.getElementById("lblNameOfDependent").className = "Frm_Txt_Hindi";
        document.getElementById("lblDependentAge").className = "Frm_Txt_Hindi";
        document.getElementById("lblRelationWithEmp").className = "Frm_Txt_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("BtnCancel").className = "btn_Hindi";
        document.getElementById("btnExit").className = "btn_Hindi";
        //Grid Hindi
        var table = document.getElementById("gvDependent");
        if (document.getElementById("gvDependent") != null) {
            var tr = table.rows[0];
            tr.cells[0].innerHTML = "चुनिये";
            tr.cells[1].innerHTML = "हटाएँ ";
            tr.cells[2].innerHTML = "कर्मचारी का नाम";
            tr.cells[3].innerHTML = "आश्रित का नाम";
            tr.cells[4].innerHTML = "आश्रित की आयु";
            tr.cells[5].innerHTML = "कर्मचारी से संबंध";

            //============Hindi Text================//
            tr.cells[0].className = "Frm_Txt_Hindi";
            tr.cells[1].className = "Frm_Txt_Hindi";
            tr.cells[2].className = "Frm_Txt_Hindi";
            tr.cells[3].className = "Frm_Txt_Hindi";
            tr.cells[4].className = "Frm_Txt_Hindi";
            tr.cells[5].className = "Frm_Txt_Hindi";
        }
    }
    //Form ID 233, Form Name:HRManagement/frm_Achievement_Employee.aspx
    if (Choice == 0 && FormId == 233) {
        document.getElementById("LblHeader").innerHTML = "उपलब्धियाँ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("lblEmployee").innerHTML = "कर्मचारी का नाम";
        document.getElementById("lblNameOfDependent").innerHTML = "उपलब्धि का प्रकार ";
        document.getElementById("lblDependentAge").innerHTML = "विषय";
        document.getElementById("lbTypeOrMedia").innerHTML = "मीडिया का प्रकार 	";
        document.getElementById("lbNameOfMedia").innerHTML = "मीडिया का नाम";
        document.getElementById("lblRelationWithEmp").innerHTML = "संस्थान";
        document.getElementById("lblDate").innerHTML = "तिथि";
        document.getElementById("lblMonth").innerHTML = "माह";
        document.getElementById("lblYear").innerHTML = "वर्ष";
        document.getElementById("lblUploads").innerHTML = "अपलोड दस्तावेज";        
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("BtnCancel").value = "रद्द करें";
        document.getElementById("btnNew").value = "नया";
        document.getElementById("btnUpdate").value = "सुधारें";
        document.getElementById("BtnExit").value = "बाहर निकलें";
        //==========Inrease=========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblEmployee").className = "Frm_Txt_Hindi";
        document.getElementById("lblNameOfDependent").className = "Frm_Txt_Hindi";
        document.getElementById("lblDependentAge").className = "Frm_Txt_Hindi";
        document.getElementById("lbTypeOrMedia").className = "Frm_Txt_Hindi";
        document.getElementById("lbNameOfMedia").className = "Frm_Txt_Hindi";
        document.getElementById("lblRelationWithEmp").className = "Frm_Txt_Hindi";
        document.getElementById("lblDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblMonth").className = "Frm_Txt_Hindiमाह";
        document.getElementById("lblYear").className = "Frm_Txt_Hindi";
        document.getElementById("lblUploads").className = "Frm_Txt_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("BtnCancel").className = "btn_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnUpdate").className = "btn_Hindi";
        document.getElementById("BtnExit").className = "btn_Hindi";

        // Grid Code Start
        var table = document.getElementById("gvdepartment");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "चुनिये";
        tr.cells[1].innerHTML = "हटाये";
        tr.cells[2].innerHTML = "कर्मचारी का नाम";
        tr.cells[3].innerHTML = "उपलब्धि का प्रकार ";
        tr.cells[4].innerHTML = "विषय";
        tr.cells[5].innerHTML = "मीडिया का प्रकार ";
        tr.cells[6].innerHTML = "मीडिया का नाम";
        tr.cells[7].innerHTML = "संस्थान";
        tr.cells[8].innerHTML = "तिथि";
        tr.cells[9].innerHTML = "माह";
        tr.cells[10].innerHTML = "वर्ष";
        tr.cells[11].innerHTML = "दस्तावेज़";
        //=========Hindi Text=========//
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
    }
    //Form ID 234, Form Name:HRManagement/frm_Yearly_Calendar.aspx
    if (Choice == 0 && FormId == 234) {
        document.getElementById("LblHeader").innerHTML = "बार्षिक कैलेंडर";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("lblFinancialYear").innerHTML = "वर्ष";
        document.getElementById("lblDate").innerHTML = "तिथि";
        document.getElementById("lblEvent").innerHTML = "विवरण ";
        document.getElementById("lblHolidayType").innerHTML = "अवकाश का  प्रकार ";
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("BtnCancel").value = "रद्द करें";
        //==========Inrease=========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblFinancialYear").className = "Frm_Txt_Hindi";
        document.getElementById("lblDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblEvent").className = "Frm_Txt_Hindi";
        document.getElementById("lblHolidayType").className = "Frm_Txt_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("BtnCancel").className = "btn_Hindi";

        //HalfDay,Holiday Radio button code
        var HalfDay = document.getElementById("rbHalfDay");
        var RB = HalfDay.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "साप्तहिक अवकाश";
        RB[0].className = "Frm_Txt_Hindi";

        var Holiday = document.getElementById("rbHoliday");
        var RB = Holiday.parentNode.getElementsByTagName("label");
        RB[1].innerHTML = "अवकाश";
        RB[1].className = "Frm_Txt_Hindi";

        // Grid Code Start
        var table = document.getElementById("gvEventDetails");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "चुनिये";
        tr.cells[1].innerHTML = "हटाये";
        tr.cells[2].innerHTML = "तिथि";
        tr.cells[3].innerHTML = "दिन";
        tr.cells[4].innerHTML = "ईवेंट";
        tr.cells[5].innerHTML = "वित्तीय वर्ष";
        tr.cells[6].innerHTML = "साप्तहिक अवकाश";
        tr.cells[7].innerHTML = "अवकाश";
        //=========Hindi Text=========//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
        tr.cells[5].className = "Frm_Txt_Hindi";
        tr.cells[6].className = "Frm_Txt_Hindi";
        tr.cells[7].className = "Frm_Txt_Hindi";
    }
    //Form ID 235, Form Name:HRManagement/rpt_Roster_Report.aspx
    if (Choice == 0 && FormId == 235) {
        document.getElementById("LblHeader").innerHTML = "Roster Report (H)";
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
        document.getElementById("lblSR").innerHTML = "क्रमांक न.";
        document.getElementById("lblPostName").innerHTML = "पद का नाम";
        document.getElementById("lblAllPost").innerHTML = "सभी पद";
        document.getElementById("lblFilledPost").innerHTML = "Filled Post (H)";
        document.getElementById("lblVacantPost").innerHTML = "Vacant Post (H)";
        document.getElementById("lblSC").innerHTML = "एस सी";
        document.getElementById("lblST").innerHTML = "एस टी";
        document.getElementById("lblOBC").innerHTML = "ओ बी सी";
        document.getElementById("lblGen").innerHTML = "सामान्य";
        document.getElementById("lblOther").innerHTML = "अन्य";
        document.getElementById("lblTotal").innerHTML = "कुल";
        document.getElementById("lblSC1").innerHTML = "एस सी";
        document.getElementById("lblST1").innerHTML = "एस टी";
        document.getElementById("lblOBC1").innerHTML = "ओ बी सी";
        document.getElementById("lblGen1").innerHTML = "सामान्य";
        document.getElementById("lblOther1").innerHTML = "अन्य";
        document.getElementById("lblTotal1").innerHTML = "कुल";
        document.getElementById("lblSC2").innerHTML = "एस सी";
        document.getElementById("lblST2").innerHTML = "एस टी";
        document.getElementById("lblOBC2").innerHTML = "ओ बी सी";
        document.getElementById("lblGen2").innerHTML = "सामान्य";
        document.getElementById("lblOther2").innerHTML = "अन्य";
        document.getElementById("lblTotal2").innerHTML = "कुल";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";
    }
    //Form ID 236, Form Name:HRManagement/frm_Attendance_Register.aspx
    if (Choice == 0 && FormId == 236) {
        document.getElementById("LblHeader").innerHTML = "उपस्थिति रजिस्टर";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("lblMonth").innerHTML = "माह";
        document.getElementById("lblYear").innerHTML = "वर्ष";
        document.getElementById("lblEmployer").innerHTML = "कर्मचारी";
        document.getElementById("lblNote").innerHTML = "नोट :- रंगों के मिश्रण का उपयोग";
        document.getElementById("chk1").nextSibling.innerHTML = "अवकाश के लिए";
        document.getElementById("chk2").nextSibling.innerHTML = "अस्वीकृत अवकाश के लिए";
        document.getElementById("chk3").nextSibling.innerHTML = "स्वीकृत अवकाश के लिए";
        document.getElementById("BtnCancel").value = "रद्द करें";
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btnShow").value = "देखें";
        //========Increase========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblMonth").className = "Frm_Txt_Hindi";
        document.getElementById("lblYear").className = "Frm_Txt_Hindi";
        document.getElementById("lblEmployer").className = "Frm_Txt_Hindi";
        document.getElementById("lblNote").className = "Frm_Txt_Hindi";
        document.getElementById("chk1").className = "btn_Hindi";
        document.getElementById("chk2").className = "btn_Hindi";
        document.getElementById("chk3").className = "btn_Hindi";
        document.getElementById("BtnCancel").className = "btn_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";

    }
    //Form ID 237, Form Name:HRManagement/rpt_LeaveReport.aspx
    if (Choice == 0 && FormId == 237) {
        document.getElementById("LblHeader").innerHTML = "अवकाश रिपोर्ट";
         document.getElementById("lblEmployee").innerHTML = "कर्मचारी  ";
        document.getElementById("lblFromDate").innerHTML = "दिनांक से ";
        document.getElementById("lblToDate").innerHTML = "दिनांक तक";
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
        document.getElementById("btnShow").value = "देखें";
        document.getElementById("lblYear").innerHTML = "वित्तीय वर्ष";
        document.getElementById("lblEmployee").innerHTML = "कर्मचारी का नाम";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";
        //======================Font Incrase======================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("lblEmployee").className = "Frm_Txt_Hindi";
        document.getElementById("lblYear").className = "Frm_Txt_Hindi";
    }
    //Form ID 238, Form Name:HRManagement/rpt_Attendance.aspx
    if (Choice == 0 && FormId == 238) {
        document.getElementById("LblHeader").innerHTML = "उपस्थिति रिपोर्ट";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("lblMonth").innerHTML = "माह";
        document.getElementById("lblYear").innerHTML = "वर्ष";
        document.getElementById("lblEmployer").innerHTML = "कर्मचारी";
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";
        //========Increase========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblMonth").className = "Frm_Txt_Hindi";
        document.getElementById("lblYear").className = "Frm_Txt_Hindi";
        document.getElementById("lblEmployer").className = "Frm_Txt_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";

    }





    //Form ID 221, Form Name:HRManagement/frmTimeSheet.aspx
    if (Choice == 0 && FormId == 221) {
        document.getElementById("LblHeader").innerHTML = "उपस्थिति पत्रक";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("LblDate").innerHTML = "दिनांक";
        document.getElementById("BtnAttendence").value = "उपस्थिति जोडें";
        document.getElementById("BtnExit").value = "बाहर निकलें";
        document.getElementById("btnShpw").value = "देखें ";

        //==========Hindi Code============//
        document.getElementById("LblDate").className = "Frm_Txt_Hindi";
        document.getElementById("BtnAttendence").className = "btn_Hindi";
        document.getElementById("BtnExit").className = "btn_Hindi";

        var Daily = document.getElementById("rbDaily");
        var RB = Daily.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = " दैनिक उपस्थिति पत्रक";
        RB[0].className = "Frm_Txt_Hindi";

        var Monthly = document.getElementById("rbMonthly");
        var RB = Monthly.parentNode.getElementsByTagName("label");
        RB[1].innerHTML = " मासिक उपस्थिति पत्रक";
        RB[1].className = "Frm_Txt_Hindi";


        document.getElementById("lblSubHeading").innerHTML = "उपस्थिति दर्ज करें ";
        document.getElementById("LblEmployee").innerHTML = "कर्मचारी";
        document.getElementById("LblTimeSlot").innerHTML = "समय स्लाँट";
        document.getElementById("ChkBtn").nextSibling.innerHTML = "सभी कार्य के लिए प्रथम घंटे कि परियोजना लागू करें";
        document.getElementById("BtnSave").value = "रक्षित करें";
        document.getElementById("BtnClose").value = "बन्द करें";
        //==========Hindi Code============//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblSubHeading").className = "Frm_Txt_Hindi";
        document.getElementById("LblEmployee").className = "Frm_Txt_Hindi";
        document.getElementById("LblTimeSlot").className = "Frm_Txt_Hindi";
        document.getElementById("ChkBtn").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("BtnSave").className = "btn_Hindi";
        document.getElementById("BtnClose").className = "btn_Hindi";

        if (document.getElementById("rbMonthly").checked == true) {
            //Grid Code Start one
            var table = document.getElementById("GridView1");
            var tr = table.rows[0];
            tr.cells[0].innerHTML = "नाम";
            tr.cells[1].innerHTML = "तिथि";
            tr.cells[2].innerHTML = "शिफ्ट";
            tr.cells[3].innerHTML = "एक घंटें";
            tr.cells[4].innerHTML = "दो घंटें";
            tr.cells[5].innerHTML = "तीन घंटें";
            tr.cells[6].innerHTML = "चार घंटें";
            tr.cells[7].innerHTML = "पाँच घंटें";
            tr.cells[8].innerHTML = "छे घंटें";
            tr.cells[9].innerHTML = "सात घंटें";
            tr.cells[10].innerHTML = "आठ घंटें";
            tr.cells[11].innerHTML = "कुल घंटें";
            //========== Hindi Code ============//
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
        } else {
            //Grid Code Start one
            var table = document.getElementById("GridView1");
            var tr = table.rows[0];
            tr.cells[0].innerHTML = "नाम";
            tr.cells[1].innerHTML = "शिफ्ट";
            tr.cells[2].innerHTML = "एक घंटें";
            tr.cells[3].innerHTML = "दो घंटें";
            tr.cells[4].innerHTML = "तीन घंटें";
            tr.cells[5].innerHTML = "चार घंटें";
            tr.cells[6].innerHTML = "पाँच घंटें";
            tr.cells[7].innerHTML = "छे घंटें";
            tr.cells[8].innerHTML = "सात घंटें";
            tr.cells[9].innerHTML = "आठ घंटें";
            tr.cells[10].innerHTML = "कुल घंटें";
            //========== Hindi Code ============//
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
        }
    }



    //==Form ID 200, Form Name:HRManagement/Master/frm_GradeTypeMaster.aspx
    if (Choice == 0 && FormId == 200) {
        document.getElementById("LblHeader").innerHTML = "ग्रेड मास्टर";
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
        document.getElementById("btnUpdate").value = "सुधारें";
        document.getElementById("btnDelete").value = "हटायें";
        document.getElementById("BtnSave").value = "रक्षित करें";
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("BtnExit").value = "बाहर निकलें";
        document.getElementById("lblGradeName").innerHTML = "ग्रेड का नाम :"
        document.getElementById("lblGradeCode").innerHTML = "ग्रेड कोड :";
        document.getElementById("lblGradeType").innerHTML = "ग्रेड का नाम";
        document.getElementById("lblMonth").innerHTML = "माह :";
        document.getElementById("lblYear").innerHTML = "वर्ष :";
        //document.getElementById("lblLeave").innerHTML = "छुटटी काँलम"
        document.getElementById("lblPayment").innerHTML = "भुगतान काँलम";
        document.getElementById("lblIncrement").innerHTML = "वेतन वृद्धि काँलम"
        //document.getElementById("lblDeduction").innerHTML = "कटौती काँलम";
        document.getElementById("lblheadGrade").innerHTML = "ग्रेड मास्टर";
        //document.getElementById("lblDate").innerHTML = "प्रभावित तिथि";
        //============Hindi Text================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnUpdate").className = "btn_Hindi";
        document.getElementById("btnDelete").className = "btn_Hindi";
        document.getElementById("BtnSave").className = "btn_Hindi";
        document.getElementById("BtnExit").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("lblGradeName").className = "Frm_Txt_Hindi";
        document.getElementById("lblGradeCode").className = "Frm_Txt_Hindi";
        document.getElementById("lblGradeType").className = "Frm_Txt_Hindi";
        document.getElementById("lblMonth").className = "Frm_Txt_Hindi";
        document.getElementById("lblYear").className = "Frm_Txt_Hindi";
        document.getElementById("lblheadGrade").className = "Frm_Txt_Hindi";
        //document.getElementById("lblDate").className = "Frm_Txt_Hindi";
    }
    //==Form ID 201, Form Name:HRManagement/Master/frm_GradeValueMaster.aspx
    if (Choice == 0 && FormId == 201) {
        document.getElementById("LblHeader").innerHTML = "ग्रेड वैल्‍यू मास्टर";
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
        document.getElementById("BtnSave").value = "रक्षित करें";
        document.getElementById("btnCncl").value = "रद्द करें";
        document.getElementById("BtnExit").value = "बाहर निकलें";
        //document.getElementById("btnDelete").value = "हटायें";
        document.getElementById("lblGradeName").innerHTML = "ग्रेड का नाम :";
        document.getElementById("lblLeave").innerHTML = "छुटटी काँलम";
        document.getElementById("lblPayment").innerHTML = "भुगतान काँलम";
        document.getElementById("lblIncrement").innerHTML = "वेतन वृद्धि काँलम"
        document.getElementById("lblDeduction").innerHTML = "कटौती काँलम";
        document.getElementById("lblheadGrade").innerHTML = "ग्रेड वैल्‍यू मास्टर";
        document.getElementById("lblGradeValue").innerHTML = "ग्रेड का नाम";
        document.getElementById("lblDate").innerHTML = "प्रभावित तिथि ";
        //============Hindi Text================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("BtnSave").className = "btn_Hindi";
        document.getElementById("btnCncl").className = "btn_Hindi";
        document.getElementById("BtnExit").className = "btn_Hindi";
        //document.getElementById("btnDelete").className = "btn_Hindi";
        document.getElementById("lblGradeName").className = "Frm_Txt_Hindi";
        document.getElementById("lblheadGrade").className = "Frm_Txt_Hindi";
        document.getElementById("lblGradeValue").className = "Frm_Txt_Hindi";
        document.getElementById("lblDate").className = "Frm_Txt_Hindi";
    }
    //==Form ID 202, Form Name:HRManagement/Master/frm_PayBill_Header.aspx
    if (Choice == 0 && FormId == 202) {
        document.getElementById("LblHeader").innerHTML = "वेतन शीर्षक";
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
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("BtnExit").value = "बाहर निकलें";
        document.getElementById("lblHeaderDetail").innerHTML = "शीर्षक विवरण";
        document.getElementById("lblPayment").innerHTML = "भुगतान काँलम";
        document.getElementById("lblDeduction").innerHTML = "कटौती काँलम";
        document.getElementById("lblPayBillHeader").innerHTML = "वेतन शीर्षक :-";
        document.getElementById("LblHeaderName").innerHTML = "शीर्षक का नाम";
        document.getElementById("LbHlHeaderName0").innerHTML = "शीर्षक का नाम (हिन्दी )";
        //document.getElementById("lblScheme").innerHTML = "स्कीम का नाम";
        document.getElementById("lblEffectiveDate").innerHTML = "प्रभावित तिथि";
        document.getElementById("ChkName").nextSibling.innerHTML = " नाम";
        document.getElementById("ChkDepartment").nextSibling.innerHTML = " विभाग";
        document.getElementById("ChkDesignation").nextSibling.innerHTML = " पदनाम";
        document.getElementById("lblPaymentHead").innerHTML = "भुगतान काँलम";
        document.getElementById("lblDeductionHead").innerHTML = "कटौती काँलम";
        document.getElementById("lblNote").innerHTML = "नोट:- क़ॉलम  Arrear ,pension deduction ,employee provident fund   सामान्य भुगतान एवम काटौती पेज पर नही दिखाई देंगे . क्योकि यह सॉफ्टवेयर गणना के लिए आरक्षित है ।";
        //============Hindi Text================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("BtnSave").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("BtnExit").className = "btn_Hindi";
        document.getElementById("lblPayBillHeader").className = "Frm_Txt_Hindi";
        document.getElementById("LblHeaderName").className = "Frm_Txt_Hindi";
        document.getElementById("lblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("lblEffectiveDate").className = "Frm_Txt_Hindi";
        document.getElementById("ChkName").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("ChkDepartment").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("ChkDesignation").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("lblPaymentHead").className = "Frm_Txt_Hindi";
        document.getElementById("lblDeductionHead").className = "Frm_Txt_Hindi";
        document.getElementById("lblNote").className = "Frm_Txt_Hindi";

        //Grid Code Start
        var table = document.getElementById("gvHeader");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "चुने";
        tr.cells[1].innerHTML = "हटायें";
        tr.cells[2].innerHTML = "शीर्षक का नाम";
        tr.cells[3].innerHTML = "शीर्षक का नाम (हिन्दी )";
        //tr.cells[4].innerHTML = "स्कीम का नाम";
        if (tr.cells[5] == null) {
            tr.cells[4].innerHTML = "प्रभावित तिथि";

        }
        else {
            tr.cells[5].innerHTML = "प्रभावित तिथि";
            tr.cells[5].className = "Frm_Txt_Hindi";
        }
        
       
        //============Hindi Text================//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
     

        //Grid Code Start
        var table = document.getElementById("gvPayment");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "चुने";
        tr.cells[1].innerHTML = "भुगतान";
        tr.cells[2].innerHTML = "डिस्प्ले आर्डर";
        tr.cells[3].innerHTML = "डिस्प्ले काँलम का नाम";
        tr.cells[4].innerHTML = "डिस्प्ले काँलम का नाम(हिन्दी )";
        tr.cells[5].innerHTML = "लेजर का नाम";
       
        //============Hindi Text================//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
        tr.cells[5].className = "Frm_Txt_Hindi";     
//        if (table.rows.count > 6) {
//            tr.cells[6].innerHTML = "श्रेणी का नाम";
//            tr.cells[6].className = "Frm_Txt_Hindi";
//        }

        //Grid Code Start
        var table = document.getElementById("gvDeduction");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "चुने";
        tr.cells[1].innerHTML = "कटौती";
        tr.cells[2].innerHTML = "डिस्प्ले आर्डर";
        tr.cells[3].innerHTML = "डिस्प्ले काँलम का नाम";
        tr.cells[4].innerHTML = "डिस्प्ले काँलम का नाम(हिन्दी )";
        tr.cells[5].innerHTML = "लेजर का नाम";
      
        //============Hindi Text================//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
        tr.cells[5].className = "Frm_Txt_Hindi";      
//        if (table.rows.count > 6) {
//            tr.cells[6].innerHTML = "श्रेणी का नाम";
//            tr.cells[6].className = "Frm_Txt_Hindi";
//        }
    }
    //=Form ID 203, Form Name:HRManagement/Master/frm_Employee_DefaultValue.aspx
    if (Choice == 0 && FormId == 203) {
        document.getElementById("LblHeader").innerHTML = "कर्मचारी सामान्‍य वैल्‍यू";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("BtnSave").value = "रक्षित करें";
        document.getElementById("btnok").value = "रक्षित करें";
        document.getElementById("btnOkLIC").value = "रक्षित करें";
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("btnShow").value = "देखें";
        document.getElementById("lblEmployeeValue").innerHTML = "कर्मचारी सामान्‍य वैल्‍यू :";
        document.getElementById("LblEmployeeName").innerHTML = "कर्मचारी का नाम";
        document.getElementById("lblPayment").innerHTML = "भुगतान काँलम";
        document.getElementById("lblDeduction").innerHTML = "कटौती काँलम";
        document.getElementById("lblPaymentHead").innerHTML = "भुगतान शीर्ष";
        document.getElementById("lblDeductionHead").innerHTML = "कटौती शीर्ष";
        document.getElementById("lblDate").innerHTML = "वित्तीय वर्ष ";

        //*********
        document.getElementById("lblSanctionNo").innerHTML = "स्वीकृति  नं  ";
        document.getElementById("lblSanctionDate").innerHTML = "स्वीकृति तिथि  ";
        document.getElementById("lblStartMonth").innerHTML = "प्रारम्भ माह  ";
        document.getElementById("lblstartYear").innerHTML = "प्रारम्भ वर्ष ";
        document.getElementById("lblSanctionAmt").innerHTML = "स्वीकृत राशि ";
        document.getElementById("lblIntAmt").innerHTML = "व्याज राशि  ";
        document.getElementById("lblNoofinstallment").innerHTML = "किस्त नं ";
        document.getElementById("lblSrNo").innerHTML = "क्रमांक   ";
        document.getElementById("lblLicNo").innerHTML = "एल आइ सी पॉलिसी नं ";
        document.getElementById("lbllicMonth").innerHTML = "प्रारम्भ माह ";
        document.getElementById("lbllicYear").innerHTML = "प्रारम्भ वर्ष ";
        document.getElementById("lblPremium").innerHTML = "प्रीमियम  ";
        
        //============Hindi Text================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("BtnSave").className = "btn_Hindi";
        document.getElementById("btnok").className = "btn_Hindi";
        document.getElementById("btnOkLIC").className = "btn_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("lblEmployeeValue").className = "Frm_Txt_Hindi";
        document.getElementById("LblEmployeeName").className = "Frm_Txt_Hindi";
        document.getElementById("lblPaymentHead").className = "Frm_Txt_Hindi";
        document.getElementById("lblDeductionHead").className = "Frm_Txt_Hindi";
        document.getElementById("lblDate").className = "Frm_Txt_Hindi";

        document.getElementById("lblSanctionNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblSanctionDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblStartMonth").className = "Frm_Txt_Hindi";
        document.getElementById("lblstartYear").className = "Frm_Txt_Hindi";
        document.getElementById("lblSanctionAmt").className = "Frm_Txt_Hindi";
        document.getElementById("lblIntAmt").className = "Frm_Txt_Hindi";
        document.getElementById("lblNoofinstallment").className = "Frm_Txt_Hindi";
        document.getElementById("lblSrNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblLicNo").className = "Frm_Txt_Hindi";
        document.getElementById("lbllicMonth").className = "Frm_Txt_Hindi";
        document.getElementById("lbllicYear").className = "Frm_Txt_Hindi";
        document.getElementById("lblPremium").className = "Frm_Txt_Hindi";

        //Grid Code Start
        var table = document.getElementById("gvPayment");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "भुगतान  शीर्ष";
        tr.cells[1].innerHTML = "चुनें";
        tr.cells[2].innerHTML = "अप्रेल";
        tr.cells[3].innerHTML = "मई";
        tr.cells[4].innerHTML = "जून";
        tr.cells[5].innerHTML = "जुलाई";
        tr.cells[6].innerHTML = "अगस्त";
        tr.cells[7].innerHTML = "सितम्बर";
        tr.cells[8].innerHTML = "अक्टूबर";
        tr.cells[9].innerHTML = "नवम्बर";
        tr.cells[10].innerHTML = "दिसम्बर";
        tr.cells[11].innerHTML = "जनवरी";
        tr.cells[12].innerHTML = "फरवरी";
        tr.cells[13].innerHTML = "मार्च";
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

        //Grid Code Start
        var table = document.getElementById("gvDeduction");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "कटौती शीर्ष";
        tr.cells[1].innerHTML = "चुनें";
        tr.cells[2].innerHTML = "अप्रेल";
        tr.cells[3].innerHTML = "मई";
        tr.cells[4].innerHTML = "जून";
        tr.cells[5].innerHTML = "जुलाई";
        tr.cells[6].innerHTML = "अगस्त";
        tr.cells[7].innerHTML = "सितम्बर";
        tr.cells[8].innerHTML = "अक्टूबर";
        tr.cells[9].innerHTML = "नवम्बर";
        tr.cells[10].innerHTML = "दिसम्बर";
        tr.cells[11].innerHTML = "जनवरी";
        tr.cells[12].innerHTML = "फरवरी";
        tr.cells[13].innerHTML = "मार्च";
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
    }
    //=Form ID 204, Form Name:HRManagement/Master/frm_PayBill_Generate.aspx
    if (Choice == 0 && FormId == 204) {
        document.getElementById("LblHeader").innerHTML = "वेतन पत्रक जनरेट";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        var RBDeputation = document.getElementById("rbDeputation");
        var RBD = RBDeputation.parentNode.getElementsByTagName("label");
        RBD[0].innerHTML = "प्रतिनियुक्ति";

        var RBother = document.getElementById("rbOther");
        var RBO = RBother.parentNode.getElementsByTagName("label");
        RBO[0].innerHTML = "अन्य";

        document.getElementById("btnCalculateTDS").value = "टी डी एस गणना";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("BtnSave").value = "अनंतिम रक्षित";
        document.getElementById("btnFinalSave").value = "अंतिम रक्षित";
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("BtnExit").value = "बाहर निकलें";
        document.getElementById("lblPayBill").innerHTML = "वेतन पत्रक जनरेट";
        //document.getElementById("lblScheme").innerHTML = "स्कीम का नाम";
        document.getElementById("lblFromDate0").innerHTML = "माह";
        document.getElementById("lblFromDate2").innerHTML = "वर्ष";
        document.getElementById("btnShow").value = "देखें";
        //============Hindi Text================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("BtnSave").className = "btn_Hindi";
        document.getElementById("btnCalculateTDS").className = "btn_Hindi";
        document.getElementById("btnFinalSave").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("BtnExit").className = "btn_Hindi";
        document.getElementById("lblPayBill").className = "Frm_Txt_Hindi";
        document.getElementById("lblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("lblFromDate0").className = "Frm_Txt_Hindi";
        document.getElementById("lblFromDate2").className = "Frm_Txt_Hindi";

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
    //===============Form ID , Form Name:HRManagement/Master/frm_Configuration_Setting.aspx
    if (Choice == 0 && FormId == 205) {
        document.getElementById("LblHeader").innerHTML = "कॉन्फीगरेशन सेटिंग";
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
        document.getElementById("lblPayBill").innerHTML = "भुगतान देयक";
        document.getElementById("lblPayBill1").innerHTML = "भुगतान देयक";
        document.getElementById("lblEffectiveDate").innerHTML = "प्रभावित दिनांक";
        document.getElementById("lblConfiguration").innerHTML = "कॉन्फीगरेशन का प्रकार";
        if (document.getElementById('lblEpfPercent') != null) {
            document.getElementById("lblEpfPercent").innerHTML = "ई पी एफ (%)";
            document.getElementById("lblEpfPercent").className = "Frm_Txt_Hindi";
        }
        if (document.getElementById('lblMaxsal') != null) {
            document.getElementById("lblMaxsal").innerHTML = "अधिकतम वेतन ";
            document.getElementById("lblMaxsal").className = "Frm_Txt_Hindi";
        }
        document.getElementById("Label4").innerHTML = "आवश्यक ";

        var RBYes = document.getElementById("RbYes");
        var RB = RBYes.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हाँ";

        var RBNo = document.getElementById("RbNo");
        var RB = RBNo.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "नहीं";

        document.getElementById("ChkIsDefault").nextSibling.innerHTML = " सामान्य सभी शाखाओ के लिये";
        document.getElementById("Li1").innerHTML = "कर्मचारी अनिवार्य डाटा";
        document.getElementById("lblSaturDay").innerHTML = "शनिवार अवकाश ";
        document.getElementById("lblSatureDayDetail").innerHTML = "शनिवार अवकाश ";
        document.getElementById("lblWeekly").innerHTML = "साप्ताहिक अवकाश "
        document.getElementById("lblWeekly").innerHTML = "साप्ताहिक अवकाश ";
        document.getElementById("chkAllsaturday").nextSibling.innerHTML = "सभी शनिवार "
        document.getElementById("chkFSaturDay").nextSibling.innerHTML = "पह्ला शनिवार "
        document.getElementById("chkSSaturDay").nextSibling.innerHTML = "दूसरा शनिवार "
        document.getElementById("chkTSaturDay").nextSibling.innerHTML = "तीसरा  शनिवार "
        document.getElementById("chkFourSaturDay").nextSibling.innerHTML = "चौथा शनिवार "
        document.getElementById("chkFifthSaturDay").nextSibling.innerHTML = "पांचवा शनिवार "
        document.getElementById("chkAllBranchForsaturday").nextSibling.innerHTML = "सामान्य सभी शाखाओ के लिये "
        document.getElementById("lbleffectiveSaturday").innerHTML = "प्रभावित दिनांक "
        document.getElementById("lblWeeklyDetail").innerHTML = "साप्ताहिक अवकाश "
        document.getElementById("lblWeekly").innerHTML = "साप्ताहिक अवकाश "


        document.getElementById("lblWeeklyoffeffective").innerHTML = "प्रभावित दिनांक"
        document.getElementById("chkAllBranchForWeeklyOFF").nextSibling.innerHTML = "सामान्य सभी शाखाओ के लिये "
        document.getElementById("lblWeeklyS").innerHTML = "साप्ताहिक अवकाश "

        //============Hindi Text tab1================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnExit").className = "btn_Hindi";
        document.getElementById("lblPayBill1").className = "Frm_Txt_Hindi";
        document.getElementById("lblEffectiveDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblConfiguration").className = "Frm_Txt_Hindi";
        document.getElementById("Label4").className = "Frm_Txt_Hindi";
        document.getElementById("ChkIsDefault").nextSibling.className = "Frm_Txt_Hindi";

        //============Hindi Text tab2================//
        document.getElementById("lblConfigurationType").innerHTML = "कॉन्फीगरेशन का प्रकार";
        document.getElementById("lblEffective_Date").innerHTML = "प्रभावित दिनांक";
        document.getElementById("lblConfigurationValue").innerHTML = "कॉन्फीगरेशन वैल्‍यू";
        if (document.getElementById("ChkIsDefaultForTab1") != null) {
            document.getElementById("ChkIsDefaultForTab1").nextSibling.innerHTML = " सामान्य सभी शाखाओ के लिये";
            document.getElementById("ChkIsDefaultForTab1").nextSibling.className = "Frm_Txt_Hindi";
        }        
        document.getElementById("lblEmployeeMandatory").innerHTML = "कर्मचारी अनिवार्य डाटा";
        document.getElementById("lblConfigurationType").className = "Frm_Txt_Hindi";
        document.getElementById("lblEffective_Date").className = "Frm_Txt_Hindi";
        document.getElementById("lblConfigurationValue").className = "Frm_Txt_Hindi";
        
        document.getElementById("lblEmployeeMandatory").className = "Frm_Txt_Hindi";

        document.getElementById("lblNote").innerHTML = 'नोट:-6500 LIMIT FOR EPF DEDUCTION के लिए कॉन्फीगरेशन सेटिंग आवश्यक, ई पी एफ (%), अधिकतम वेतन के रूप मे दिखाई गई है ';
        document.getElementById("lblNote").className = "Frm_Txt_Hindi";
        //Grid Code Start
        var table = document.getElementById("gvPayBill");
        //alert(table);
        var tr = table.rows[0];
        tr.cells[1].innerHTML = "चुनिये";
        tr.cells[0].innerHTML = "हटायें";

        tr.cells[2].innerHTML = "कॉन्फीगरेशन का प्रकार";
        tr.cells[3].innerHTML = "प्रभावित दिनांक";
        tr.cells[4].innerHTML = "कॉन्फीगरेशन वैल्‍यू";
        //============Hindi Text================//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";

        //Grid Code Start
        var table = document.getElementById("GVMendetoryData");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "हटायें";
        tr.cells[1].innerHTML = "चुनिये";
        tr.cells[2].innerHTML = "कॉन्फीगरेशन का प्रकार";
        tr.cells[3].innerHTML = "प्रभावित दिनांक";
        tr.cells[4].innerHTML = "कॉन्फीगरेशन वैल्‍यू";
        //============Hindi Text================//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";

        //*************
        var table = document.getElementById("GVSaturDay");
        var tr = table.rows[0];
        tr.cells[1].innerHTML = "चुनिये";
        tr.cells[0].innerHTML = "हटायें";

        tr.cells[2].innerHTML = "कॉन्फीगरेशन का प्रकार";
        tr.cells[3].innerHTML = "प्रभावित दिनांक";
        tr.cells[7].innerHTML = "कॉन्फीगरेशन वैल्‍यू";
        //============Hindi Text================//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[7].className = "Frm_Txt_Hindi";

        //******
        var table = document.getElementById("GVWeekly");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "हटायें";
        tr.cells[1].innerHTML = "चुनिये";
        tr.cells[2].innerHTML = "कॉन्फीगरेशन का प्रकार";
        tr.cells[3].innerHTML = "प्रभावित दिनांक";
        tr.cells[7].innerHTML = "कॉन्फीगरेशन वैल्‍यू";
        //============Hindi Text================//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[7].className = "Frm_Txt_Hindi";

        //============Hindi Text================//
        var chkdefault = document.getElementById("chkDefault");
        var ch = chkdefault.parentNode.getElementsByTagName("label");
        ch[0].innerHTML = "सामान्य सभी शाखाओ के लिये";
        ch[0].className = "Frm_Txt_Hindi";


        var chkisagency = document.getElementById("chkisAgency");
        var ch1 = chkisagency.parentNode.getElementsByTagName("label");
        ch1[0].innerHTML = "इज एजेंसी";
        ch1[0].className = "Frm_Txt_Hindi";

        var chkiscategory = document.getElementById("chkisCategory");
        var chk1 = chkiscategory.parentNode.getElementsByTagName("label");
        chk1[0].innerHTML = "इज श्रेणी";
        chk1[0].className = "Frm_Txt_Hindi";


        //document.getElementById("btnsave_Ledger").value = "रक्षित करें";
        //document.getElementById("btnCancel_Salary").value = "रद्द करें";
        document.getElementById("lblSalaryConfig").innerHTML = "भुगतान लेज़र ";
        document.getElementById("lblSalaryPayableLedger").innerHTML = "भुगतान लेज़र कांफिगरेशन";        
        document.getElementById("lblConfigType").innerHTML = "कांफिगरेशन का प्रकार";
        document.getElementById("lblLedgerEffectiveDt").innerHTML = "प्रभावित तिथि";
        document.getElementById("lblLedgerType").innerHTML = "लेज़र का प्रकार";
        document.getElementById("lblLedger").innerHTML = "लेज़र का नाम";
        document.getElementById("lblCategory").innerHTML = "केटेगरी का नाम";
        
        //=======Hindi Text ============//
        
        //document.getElementById("btnsave_Ledger").className = "btn_Hindi";
        //document.getElementById("btnCancel_Salary").className = "btn_Hindi";        
        document.getElementById("lblSalaryPayableLedger").className = "Frm_Txt_Hindi";
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
    //===============Form ID 206, Form Name:HRManagement/rpt_PrintPaySlip.aspx
    if (Choice == 0 && FormId == 206) {
        document.getElementById("LblHeader").innerHTML = "प्रिंट वेतन पर्ची/वेतन पत्रक";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbPaySlip");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "वेतन पर्ची";
        RB[0].className = "Frm_Txt_Hindi";
        var RBenglish = document.getElementById("rbPayBill");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "वेतन पत्रक";
        RB[0].className = "Frm_Txt_Hindi";
        document.getElementById("rbPayBill").className = "Frm_Txt_Hindi";
        //document.getElementById("LblScheme").innerHTML = "स्कीम का नाम";
        document.getElementById("LblMonth").innerHTML = "माह";
        document.getElementById("LblYear").innerHTML = "वर्ष";
//        document.getElementById("LblGrossPay").innerHTML = "कुल भुगतान";
//        document.getElementById("LblGrossDeduction").innerHTML = "कुल कटौती";
        //        document.getElementById("LblNetTot").innerHTML = "कुल देय राशि";
        if (document.getElementById("BtnReprintPayBill") != null) {
            document.getElementById("BtnReprintPayBill").innerHTML = "वेतन पत्रक प्रिंट करें";
           document.getElementById("BtnReprintPayBill").className = "btn_Hindi";
        }
        if (document.getElementById("BtnGeneratePaySlip") != null) {
            document.getElementById("BtnGeneratePaySlip").innerHTML = "वेतन पर्ची प्रिंट करें";
            document.getElementById("BtnGeneratePaySlip").className = "btn_Hindi";
       }
        document.getElementById("BtnShowPayBill").value = "देखें";
        document.getElementById("BtnCancel_New").value = "रद्द करें";
        document.getElementById("lblEmployee").innerHTML = "वेतन पत्रक/ वेतन पर्ची में कर्मचारी खोजें";
//        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";
//        document.getElementById("btnSaveasExcel").className = "btn_Hindi";
        //=======================Hindi Text=====================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
       // document.getElementById("LblScheme").className = "Frm_Txt_Hindi";
        document.getElementById("LblMonth").className = "Frm_Txt_Hindi";
        document.getElementById("LblYear").className = "Frm_Txt_Hindi";
//        document.getElementById("LblGrossPay").className = "Frm_Txt_Hindi";
//        document.getElementById("LblGrossDeduction").className = "Frm_Txt_Hindi";
//        document.getElementById("LblNetTot").className = "Frm_Txt_Hindi";
        document.getElementById("BtnShowPayBill").className = "btn_Hindi";
        document.getElementById("BtnCancel_New").className = "btn_Hindi";
        document.getElementById("lblEmployee").className = "Frm_Txt_Hindi";

        //Grid Code (gvPaySlip)Start
        if (document.getElementById("LblScheme")!= null) {
            var table = document.getElementById("gvPaySlip");
            var tr = table.rows[0];
            tr.cells[0].innerHTML = "";
            tr.cells[1].innerHTML = "सं. क्र.";
            tr.cells[2].innerHTML = "चुनिये";
          //  tr.cells[3].innerHTML = "लाभ केन्द्र";
            tr.cells[3].innerHTML = "पे बिल नं.";
            tr.cells[4].innerHTML = "माह";
            tr.cells[5].innerHTML = "वर्ष";
            tr.cells[6].innerHTML = "कुल कर्मचारी";
            tr.cells[7].innerHTML = "कुल भुगतान";
            tr.cells[8].innerHTML = "कुल कटौती";
            tr.cells[9].innerHTML = "कुल देय राशि";
            //============Hindi Text================//
            tr.cells[0].className = "";
            tr.cells[1].className = "Frm_Txt_Hindi";
            tr.cells[2].className = "Frm_Txt_Hindi";
            tr.cells[3].className = "Frm_Txt_Hindi";
            tr.cells[4].className = "Frm_Txt_Hindi";
            tr.cells[5].className = "Frm_Txt_Hindi";
            tr.cells[6].className = "Frm_Txt_Hindi";
            tr.cells[7].className = "Frm_Txt_Hindi";
            tr.cells[8].className = "Frm_Txt_Hindi";
            tr.cells[9].className = "Frm_Txt_Hindi";
            //tr.cells[10].className = "Frm_Txt_Hindi";
        }
        else {
            var table = document.getElementById("gvPaySlip");
            var tr = table.rows[0];
            tr.cells[0].innerHTML = "";
            tr.cells[1].innerHTML = "सं. क्र.";
            tr.cells[2].innerHTML = "चुनिये";
            tr.cells[2].innerHTML = "चुनिये";
            tr.cells[3].innerHTML = "पे बिल नं.";
            tr.cells[4].innerHTML = "माह";
            tr.cells[5].innerHTML = "वर्ष";
            tr.cells[6].innerHTML = "कुल कर्मचारी";
            tr.cells[7].innerHTML = "कुल भुगतान";
            tr.cells[8].innerHTML = "कुल कटौती";
            tr.cells[9].innerHTML = "कुल देय राशि";
            //============Hindi Text================//
            tr.cells[0].className = "";
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

//        document.getElementById("BtnGeneratePaySlip").value = "जनरेट वेतन पर्ची ";
//        document.getElementById("BtnGeneratePaySlip").className = "btn_Hindi";
//        document.getElementById("BtnReprintPayBill").value = "रिप्रिंट वेतन पत्रक";
//        document.getElementById("BtnReprintPayBill").className = "btn_Hindi";

        // Grid Code Start
        var table = document.getElementById("gvPaySlipDetail");
        var tr = table.rows[0];
        
        document.getElementById("gvPaySlipDetail_ctl01_chkall").nextSibling.innerHTML = "सभी";
//        tr.cells[2].innerHTML = "कर्मचारी का नाम";
//        tr.cells[5].innerHTML = "न्यूनतम बैंड";
//        tr.cells[6].innerHTML = "ग्रेड पे";
//        tr.cells[7].innerHTML = "स्पेशल भत्ता/ स्पेशल पे";
//        tr.cells[8].innerHTML = "महंगाई भत्ता";
//        tr.cells[9].innerHTML = "घर किराया भत्ता (%)में";
//        tr.cells[10].innerHTML = "सी.सी.ए./ डी.ए./ डब्ल्यू.ए.";
//        tr.cells[11].innerHTML = "अन्य भत्ता";
//        tr.cells[12].innerHTML = "चिकित्सा भत्ता";
//        tr.cells[13].innerHTML = "अध्ययन शुल्क";
//        tr.cells[14].innerHTML = "परिवहन भत्ता";
//        tr.cells[15].innerHTML = "आदिवासी भत्ता";
//        tr.cells[16].innerHTML = "अवकाश वेतन ";
//        tr.cells[17].innerHTML = "धुलाई भत्ता";
//        tr.cells[18].innerHTML = "एरियर्स";
//        tr.cells[20].innerHTML = "जीआईएस/ ईआईएसएस";
//        tr.cells[21].innerHTML = "जीपीएफ";
//        tr.cells[22].innerHTML = "जीपीएफ का अग्रिम";
//        tr.cells[23].innerHTML = "घर निर्माण ऋण";
//        tr.cells[24].innerHTML = "वाहन का अग्रिम ";
//        tr.cells[25].innerHTML = "त्यौहार का अग्रिम ";
//        tr.cells[26].innerHTML = "अनाज का अग्रिम";
//        tr.cells[27].innerHTML = "वेतन का अग्रिम";
//        tr.cells[28].innerHTML = "चिकित्सा का अग्रिम";
//        tr.cells[29].innerHTML = "अग्रिम विबिध रिकवरी";
//        tr.cells[30].innerHTML = "एलआईसी";
//        tr.cells[31].innerHTML = "अन्य ऋण";
//        tr.cells[32].innerHTML = "अवकाश कटौती";
//        tr.cells[33].innerHTML = "स्त्रोत पर कर कटौती";
//        tr.cells[34].innerHTML = "कोइ अन्य कटौती";
//        tr.cells[35].innerHTML = "प्रोफेशनल कर ";
//        tr.cells[36].innerHTML = "घर किराया/ लाईसेंस शुल्क";
//        tr.cells[37].innerHTML = "पानी खर्च";
//        tr.cells[38].innerHTML = "वाहन खर्च";
//        tr.cells[39].innerHTML = "वेलफेयर फंड";
//        tr.cells[40].innerHTML = "बैंक ऋण";
//        tr.cells[41].innerHTML = "कर्मचारी भविष्य निधि";
//        tr.cells[42].innerHTML = "पेंशन कटौती";
//        tr.cells[45].innerHTML = "ईपीएफ नियोक्ता अंशदान";
        //********************
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
        tr.cells[15].className = "Frm_Txt_Hindi";
        tr.cells[16].className = "Frm_Txt_Hindi";
        tr.cells[17].className = "Frm_Txt_Hindi";
        tr.cells[18].className = "Frm_Txt_Hindi";
        tr.cells[19].className = "Frm_Txt_Hindi";
        tr.cells[20].className = "Frm_Txt_Hindi";
        tr.cells[21].className = "Frm_Txt_Hindi";
        tr.cells[22].className = "Frm_Txt_Hindi";
        tr.cells[23].className = "Frm_Txt_Hindi";
        tr.cells[24].className = "Frm_Txt_Hindi";
        tr.cells[25].className = "Frm_Txt_Hindi";
        tr.cells[26].className = "Frm_Txt_Hindi";
        tr.cells[27].className = "Frm_Txt_Hindi";
        tr.cells[28].className = "Frm_Txt_Hindi";
        tr.cells[29].className = "Frm_Txt_Hindi";
        tr.cells[30].className = "Frm_Txt_Hindi";
        tr.cells[31].className = "Frm_Txt_Hindi";
        tr.cells[32].className = "Frm_Txt_Hindi";
        tr.cells[33].className = "Frm_Txt_Hindi";
        tr.cells[34].className = "Frm_Txt_Hindi";
        tr.cells[35].className = "Frm_Txt_Hindi";
        tr.cells[36].className = "Frm_Txt_Hindi";
        tr.cells[37].className = "Frm_Txt_Hindi";
        tr.cells[38].className = "Frm_Txt_Hindi";
        tr.cells[39].className = "Frm_Txt_Hindi";
        tr.cells[40].className = "Frm_Txt_Hindi";
        tr.cells[41].className = "Frm_Txt_Hindi";
        tr.cells[42].className = "Frm_Txt_Hindi";
        tr.cells[43].className = "Frm_Txt_Hindi";
        tr.cells[44].className = "Frm_Txt_Hindi";
        tr.cells[45].className = "Frm_Txt_Hindi";
        tr.cells[46].className = "Frm_Txt_Hindi";
    }
    //=====Form ID 207, Form Name:HRManagement/rpt_ServiceBook.aspx
    if (Choice == 0 && FormId == 207) {
        document.getElementById("LblHeader").innerHTML = "कर्मचारी सेवा पुस्तिका";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("LblDate").innerHTML = "दिनांक";
        document.getElementById("LblEmp").innerHTML = "कर्मचारी चुनें";
        document.getElementById("BtnViewRecord").value = "रिकार्ड  देखें";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";
        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("LblDate").className = "Frm_Txt_Hindi";
        document.getElementById("LblEmp").className = "Frm_Txt_Hindi";
        document.getElementById("BtnViewRecord").className = "btn_Hindi";
    }
    //=====Form ID 208, Form Name:HRManagement/frmEmployee_Promotion.aspx
    if (Choice == 0 && FormId == 208) {
        document.getElementById("LblHeader").innerHTML = "कर्मचारी पदोन्नति";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("lblRemark").innerHTML = "रिमार्क ";
        document.getElementById("lblSearch").innerHTML = "खोजें";
        document.getElementById("lblEmpCode").innerHTML = "कर्मचारी कोड नबंर";
        document.getElementById("lblName").innerHTML = "कर्मचारी का नाम";
       // document.getElementById("lblScheemName").innerHTML = "स्कीम का नाम";
        document.getElementById("lblDesignation").innerHTML = "पद";
        document.getElementById("lblGrade").innerHTML = "ग्रेड";
        document.getElementById("lblOrderNo").innerHTML = "आदेश नबंर";
        document.getElementById("lbldate").innerHTML = "आदेश तिथि";
        document.getElementById("lblEffectdate").innerHTML = "प्रभावित तिथि";
        document.getElementById("btnReset").value = "रिफ्रेश करें";
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("lblselect").innerHTML = "चुनें";
        document.getElementById("lblEmployeeCode").innerHTML = "कर्मचारी कोड नबंर";
        document.getElementById("lblEmployeeName").innerHTML = "कर्मचारी का नाम";
        document.getElementById("lblExisting").innerHTML = "वर्तमान";
        document.getElementById("lblNew").innerHTML = "नवीन";
        document.getElementById("lblOrderNo1").innerHTML = "आदेश नबंर";
        document.getElementById("lblOrderDate").innerHTML = "आदेश तिथि";
        document.getElementById("lblDesignation1").innerHTML = "पद";
        document.getElementById("lblGrade1").innerHTML = "ग्रेड";
        document.getElementById("lblSalary1").innerHTML = "वेतन";
        document.getElementById("lblDesignation2").innerHTML = "पद";
        document.getElementById("lblGrade2").innerHTML = "";
        document.getElementById("lblSalary2").innerHTML = "";
        document.getElementById("btnTransfer").value = "पदोन्नति कर्मचारी";
        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblSearch").className = "Frm_Txt_Hindi";
        document.getElementById("lblEmpCode").className = "Frm_Txt_Hindi";
        document.getElementById("lblName").className = "Frm_Txt_Hindi";
        document.getElementById("lblScheemName").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemark").className = "Frm_Txt_Hindi";
        document.getElementById("lblDesignation").className = "Frm_Txt_Hindi";
        document.getElementById("lblGrade").className = "Frm_Txt_Hindi";
        document.getElementById("lblOrderNo").className = "Frm_Txt_Hindi";
        document.getElementById("lbldate").className = "Frm_Txt_Hindi";
        document.getElementById("lblEffectdate").className = "Frm_Txt_Hindi";
        document.getElementById("lblselect").className = "Frm_Txt_Hindi";
        document.getElementById("lblEmployeeCode").className = "Frm_Txt_Hindi";
        document.getElementById("lblEmployeeName").className = "Frm_Txt_Hindi";
        document.getElementById("lblExisting").className = "Frm_Txt_Hindi";
        document.getElementById("lblNew").className = "Frm_Txt_Hindi";
        document.getElementById("lblOrderNo1").className = "Frm_Txt_Hindi";
        document.getElementById("lblOrderDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblDesignation1").className = "Frm_Txt_Hindi";
        document.getElementById("lblGrade1").className = "Frm_Txt_Hindi";
        document.getElementById("lblSalary1").className = "Frm_Txt_Hindi";
        document.getElementById("lblDesignation2").className = "Frm_Txt_Hindi";
        document.getElementById("lblGrade2").className = "Frm_Txt_Hindi";
        document.getElementById("lblSalary2").className = "Frm_Txt_Hindi";
        document.getElementById("btnTransfer").className = "btn_Hindi";
        document.getElementById("btnReset").className = "btn_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";

        //Grid Code Start
        var table = document.getElementById("GvSelectedEmployee");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "कर्मचारी कोड नबंर";
        tr.cells[1].innerHTML = "कर्मचारी का नाम";
        tr.cells[2].innerHTML = "वर्तमान पद";
        tr.cells[3].innerHTML = "वर्तमान ग्रेड";
        tr.cells[4].innerHTML = "वर्तमान वेतन";
        tr.cells[5].innerHTML = "नवीन पद";
        tr.cells[6].innerHTML = "";
        tr.cells[7].innerHTML = "";
        tr.cells[8].innerHTML = "आदेश नबंर";
        tr.cells[9].innerHTML = "आदेश तिथि";
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
    //=====Form ID 209, Form Name:HRManagement/frmEmployee_Transfer.aspx
    if (Choice == 0 && FormId == 209) {
        document.getElementById("LblHeader").innerHTML = "कर्मचारी स्थानांतरण";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("lblSearch").innerHTML = "खोजें";
        document.getElementById("lblEmpCode").innerHTML = "कर्मचारी कोड नबंर";
        document.getElementById("lblName").innerHTML = "कर्मचारी का नाम";
        //document.getElementById("lblScheemName").innerHTML = "स्कीम का नाम";
        document.getElementById("lblDesignation").innerHTML = "पद";
        document.getElementById("lblGrade").innerHTML = "ग्रेड";
        document.getElementById("lblOrderNo").innerHTML = "आदेश नबंर";
        document.getElementById("lbldate").innerHTML = "आदेश तिथि";
        document.getElementById("btnReset").value = "रिफ्रेश करें";
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("lblselect").innerHTML = "चुनें";
        document.getElementById("lblEmployeeCode").innerHTML = "कर्मचारी कोड नबंर";
        document.getElementById("lblEmployeeName").innerHTML = "कर्मचारी का नाम";
        document.getElementById("lblExisting").innerHTML = "वर्तमान";
        document.getElementById("lblNew").innerHTML = "नवीन";
        document.getElementById("lblOrderNo1").innerHTML = "आदेश नबंर";
        document.getElementById("lblOrderDate").innerHTML = "आदेश तिथि";
        //document.getElementById("lblScheme1").innerHTML = "स्कीम";
        document.getElementById("lblPosting1").innerHTML = "पदस्थापना";
        document.getElementById("lblLocation1").innerHTML = "स्थान";
       // document.getElementById("lblScheme2").innerHTML = "स्कीम";
        document.getElementById("lblPosting2").innerHTML = "पदस्थापना";
        document.getElementById("lblLocation2").innerHTML = "स्थान";
        document.getElementById("btnTransfer").value = "स्थानांतरित कर्मचारी";
        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblSearch").className = "Frm_Txt_Hindi";
        document.getElementById("lblEmpCode").className = "Frm_Txt_Hindi";
        document.getElementById("lblName").className = "Frm_Txt_Hindi";
        document.getElementById("lblScheemName").className = "Frm_Txt_Hindi";
        document.getElementById("lblDesignation").className = "Frm_Txt_Hindi";
        document.getElementById("lblGrade").className = "Frm_Txt_Hindi";
        document.getElementById("lblOrderNo").className = "Frm_Txt_Hindi";
        document.getElementById("lbldate").className = "Frm_Txt_Hindi";
        document.getElementById("lblselect").className = "Frm_Txt_Hindi";
        document.getElementById("lblEmployeeCode").className = "Frm_Txt_Hindi";
        document.getElementById("lblEmployeeName").className = "Frm_Txt_Hindi";
        document.getElementById("lblExisting").className = "Frm_Txt_Hindi";
        document.getElementById("lblNew").className = "Frm_Txt_Hindi";
        document.getElementById("lblOrderNo1").className = "Frm_Txt_Hindi";
        document.getElementById("lblOrderDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblScheme1").className = "Frm_Txt_Hindi";
        document.getElementById("lblPosting1").className = "Frm_Txt_Hindi";
        document.getElementById("lblLocation1").className = "Frm_Txt_Hindi";
        document.getElementById("lblScheme2").className = "Frm_Txt_Hindi";
        document.getElementById("lblPosting2").className = "Frm_Txt_Hindi";
        document.getElementById("lblLocation2").className = "Frm_Txt_Hindi";
        document.getElementById("btnTransfer").className = "btn_Hindi";
        document.getElementById("btnReset").className = "btn_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";

        //Grid Code Start
        var table = document.getElementById("GvSelectedEmployee");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "कर्मचारी कोड नबंर";
        tr.cells[1].innerHTML = "कर्मचारी का नाम";
        tr.cells[2].innerHTML = "वर्तमान स्कीम";
        tr.cells[3].innerHTML = "वर्तमान पदस्थापना";
        tr.cells[4].innerHTML = "वर्तमान स्थान";
        //tr.cells[5].innerHTML = "नवीन स्कीम";
        tr.cells[6].innerHTML = "नवीन पदस्थापना";
        tr.cells[7].innerHTML = "नवीन स्थान";
        tr.cells[8].innerHTML = "आदेश नबंर";
        tr.cells[9].innerHTML = "आदेश तिथि";
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
    //=====Form ID 210, Form Name:HRManagement/rpt_SeniorityList.aspx
    if (Choice == 0 && FormId == 210) {
        document.getElementById("LblHeader").innerHTML = "सेवानिवृत्ति और वरिष्ठता सूची";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        // Retirement & Seniority list Radio Button
        var RBRetirement = document.getElementById("rbRetirement");
        var RB = RBRetirement.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "सेवानिवृत्ति सूची";
        RB[0].className = "Frm_Txt_Hindi";

        var RBSeniority = document.getElementById("rbSeniority");
        var RB = RBSeniority.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "वरिष्ठता सूची";
        RB[0].className = "Frm_Txt_Hindi";

        if (document.getElementById("rbRetirement").checked == true) {
            document.getElementById("lblCalculateFrom").innerHTML = "तिथि से गणना";
            document.getElementById("btnShow").value = "देखें";
            //========Hindi Text========//
            document.getElementById("lblCalculateFrom").className = "Frm_Txt_Hindi";
            document.getElementById("btnShow").className = "btn_Hindi";
        }
        document.getElementById("LblJoinDate").innerHTML = " नियुक्ति  तिथि";
        document.getElementById("LblAppointmentDate").innerHTML = "कार्यग्रहण तिथि";
        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";
        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("LblJoinDate").className = "Frm_Txt_Hindi";
        document.getElementById("LblAppointmentDate").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
    }
    //=====Form ID 211, Form Name:HRManagement/Master/frm_EmployeeDesignation.aspx
    if (Choice == 0 && FormId == 211) {
        document.getElementById("LblHeader").innerHTML = "पदनाम मास्टर";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("lblDesignationName").innerHTML = "पद नाम";
        document.getElementById("lblHDesignationName").innerHTML = "पद नाम (हिन्दी)";
        document.getElementById("lblDesignationCode").innerHTML = "पद कोड";
        document.getElementById("lblMinimumQualification").innerHTML = "न्युनतम योग्यता";
        document.getElementById("lblExperience").innerHTML = "अनुभव";
        document.getElementById("lblRetirementAge").innerHTML = "सेवानिवृत्ति की आयु";
        document.getElementById("lblAgainstPost").innerHTML = "अगेंस्ट पद ";
        document.getElementById("lblLinkOfficer").innerHTML = "लिंक अधिकारी का पद ";
        document.getElementById("lblGrade").innerHTML = "वेतन मान";
        document.getElementById("lblReportTo").innerHTML = "सूचित अधिकारी";
        document.getElementById("btnSave").value = "रक्षित करे";
        document.getElementById("btnClear").value = "रद्द करे";

        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblDesignationName").className = "Frm_Txt_Hindi";
        document.getElementById("lblHDesignationName").className = "Frm_Txt_Hindi";
        document.getElementById("lblDesignationCode").className = "Frm_Txt_Hindi";
        document.getElementById("lblMinimumQualification").className = "Frm_Txt_Hindi";
        document.getElementById("lblExperience").className = "Frm_Txt_Hindi";
        document.getElementById("lblRetirementAge").className = "Frm_Txt_Hindi";
        document.getElementById("lblReportTo").className = "Frm_Txt_Hindi";
        document.getElementById("lblAgainstPost").className = "Frm_Txt_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnClear").className = "btn_Hindi";
        document.getElementById("ddlAge").className = "ddl_Hindi";
        document.getElementById("ddlReportedTo").className = "ddl_Hindi";
        //Grid Code Start       
        var table = document.getElementById("gvDesignation");
        var tr = table.rows[0];
        tr.cells[1].innerHTML = "सुधारें";
        tr.cells[2].innerHTML = "हटायें";
        tr.cells[3].innerHTML = "पद नाम";
        tr.cells[4].innerHTML = "पद नाम (हिन्दी)";
        tr.cells[5].innerHTML = "सेवानिवृत्ति की आयु";
        tr.cells[6].innerHTML = "पद कोड";
        tr.cells[7].innerHTML = "न्युनतम योग्यता";
        tr.cells[8].innerHTML = "अनुभव";
        tr.cells[9].innerHTML = "सूचित अधिकारी";
        tr.cells[10].innerHTML = "अगेंस्ट पद ";
        tr.cells[11].innerHTML = "अगेंस्ट पद (हिन्दी)";
        tr.cells[12].innerHTML = "वेतन मान";
        tr.cells[13].innerHTML = "लिंक अधिकारी का पद ";
        tr.cells[14].innerHTML = "लिंक अधिकारी का पद (हिन्दी)";
        //============Hindi Text================//
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
    //=====Form ID 242, Form Name:HRManagement/Master/frm_EmployeeDesignation.aspx
    if (Choice == 0 && FormId == 242) {
        document.getElementById("LblHeader").innerHTML = "वसूली/जुर्माना का प्रकार ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("lblPenaltyType").innerHTML = "जुर्माना का प्रकार";
        document.getElementById("lblPenaltyDescription").innerHTML = "जुर्माना का विवरण";
        document.getElementById("btnSave").value = "रक्षित करे";
        document.getElementById("btnCancel").value = "रद्द करे";
        document.getElementById("btnNew").value = "नया";
        document.getElementById("btnEdit").value = "सुधारें";
        document.getElementById("btnExit").value = "बाहर निकलें";

        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblPenaltyType").className = "Frm_Txt_Hindi";
        document.getElementById("lblPenaltyDescription").className = "Frm_Txt_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("btnExit").className = "btn_Hindi";
        //Grid Code Start
        var table = document.getElementById("gvPenaltyType");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "सुधारें";
        tr.cells[1].innerHTML = "हटायें";
        tr.cells[2].innerHTML = "जुर्माना";
        tr.cells[3].innerHTML = "विवरण";
        //============Hindi Text================//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
    }
    //=====Form ID 243, Form Name:HRManagement//HR_Transaction/frm_Penallty.aspx
    if (Choice == 0 && FormId == 243) {
        document.getElementById("LblHeader").innerHTML = "जुर्माना";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("lblEmployee").innerHTML = "कर्मचारी का नाम";
        document.getElementById("lblGrade").innerHTML = "ग्रेड";
        document.getElementById("lblCurrentBasicSalry").innerHTML = "वर्तमान बेसिक वेतन";
        document.getElementById("lblTypeofPenalty").innerHTML = "जुर्माना का प्रकार";
        document.getElementById("lblNoofIncrement").innerHTML = "वृद्धि की संख्या";
        document.getElementById("lblPenaltyDescription").innerHTML = "जुर्माना का विवरण";
        document.getElementById("lblOrderNo").innerHTML = "आदेश क्रमांक";
        document.getElementById("lblOrderDate").innerHTML = "आदेश दिनांक";
        document.getElementById("LblFromDt").innerHTML = "दिनांक से";
        document.getElementById("lblTodate").innerHTML = "दिनांक तक";
        document.getElementById("lblRecoverableAmount").innerHTML = "वशूली राशि";

        document.getElementById("btnSave").value = "रक्षित करे";
        document.getElementById("btnCancel").value = "रद्द करे";


        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblEmployee").className = "Frm_Txt_Hindi";
        document.getElementById("lblGrade").className = "Frm_Txt_Hindi";
        document.getElementById("lblCurrentBasicSalry").className = "Frm_Txt_Hindi";
        document.getElementById("lblTypeofPenalty").className = "Frm_Txt_Hindi";
        document.getElementById("lblNoofIncrement").className = "Frm_Txt_Hindi";
        document.getElementById("lblPenaltyDescription").className = "Frm_Txt_Hindi";
        document.getElementById("lblOrderNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblOrderDate").className = "Frm_Txt_Hindi";
        document.getElementById("LblFromDt").className = "Frm_Txt_Hindi";
        document.getElementById("lblTodate").className = "Frm_Txt_Hindi";
        document.getElementById("lblRecoverableAmount").className = "Frm_Txt_Hindi";


        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";

    }
    //Form ID 244, Form Name:frm_yearly_leaves.aspx
    if (Choice == 0 && FormId == 244) {
        document.getElementById("LblHeader").innerHTML = "अवकाश मास्टर";
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
        document.getElementById("lblDepartmentDetail").innerHTML = "अवकाश का विवरण";
        document.getElementById("lblYear").innerHTML = "वर्ष ";
        document.getElementById("lblLeaveType").innerHTML = "अवकाश का प्रकार ";
        document.getElementById("lblCreaditWay").innerHTML = "अवकाश जमा करना ";
        document.getElementById("lblNoOfLeave").innerHTML = "अवकाश के दिन";
        document.getElementById("chkCommulative").nextSibling.innerHTML = "कम्युलेटिव";
        document.getElementById("btnsave").value = "रक्षित करें";
        document.getElementById("btnCancel").value = "रद्द करे ";
        document.getElementById("btndelete").value = "हटाऐ";
        //============Hindi Text================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblDepartmentDetail").className = "Frm_Txt_Hindi";
        document.getElementById("lblYear").className = "Frm_Txt_Hindi";
        document.getElementById("lblLeaveType").className = "Frm_Txt_Hindi";
        document.getElementById("lblCreaditWay").className = "Frm_Txt_Hindi";
        document.getElementById("lblNoOfLeave").className = "Frm_Txt_Hindi";
        document.getElementById("chkCommulative").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("btnsave").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("btndelete").className = "btn_Hindi";
        //document.getElementById("ddlDesignation").className = "ddl_Hindi";

        // Grid Code Start
        var table = document.getElementById("gvLeave");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "चुनिये";
        tr.cells[1].innerHTML = "हटाएँ ";
        tr.cells[2].innerHTML = "वर्ष ";
        tr.cells[3].innerHTML = "अवकाश भुगतान का प्रकार";
        tr.cells[4].innerHTML = "अवकाश का प्रकार ";
        tr.cells[5].innerHTML = "अवकाश के दिन ";
        //============Hindi Text================//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
        tr.cells[5].className = "Frm_Txt_Hindi";
    }
    //Form ID 245, Form Name:frm_credit_leave.aspx
    if (Choice == 0 && FormId == 245) {

        document.getElementById("LblHeader").innerHTML = "अवकाश भुगतान";
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

        document.getElementById("lblCreditDetails").innerHTML = "अवकाश भुगतान";
        document.getElementById("lblYear").innerHTML = "वर्ष ";
        document.getElementById("lblLeaveType").innerHTML = "अवकाश का प्रकार ";
        document.getElementById("chkAllBranch").nextSibling.innerHTML = "सभी शाखाऐ ";
        document.getElementById("btnsave").value = "रक्षित करें";
        document.getElementById("btnClear").value = "हटाऐ";
        document.getElementById("btndelete").value = "हटाऐ";
        //============Hindi Text================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblCreditDetails").className = "Frm_Txt_Hindi";
        document.getElementById("lblYear").className = "Frm_Txt_Hindi";
        document.getElementById("lblLeaveType").className = "Frm_Txt_Hindi";
        document.getElementById("chkAllBranch").nextSibling.className = "Frm_Txt_Hindi";
        document.getElementById("btnsave").className = "btn_Hindi";
        document.getElementById("btnClear").className = "btn_Hindi";
        document.getElementById("btndelete").className = "btn_Hindi";
        //document.getElementById("ddlDesignation").className = "ddl_Hindi";

        //        // Grid Code Start
        //        var table = document.getElementById("gvLeave");
        //        var tr = table.rows[0];
        //        tr.cells[0].innerHTML = "चुनिये";
        //        tr.cells[1].innerHTML = "हटाएँ ";
        //        tr.cells[2].innerHTML = "वर्ष ";
        //        tr.cells[3].innerHTML = "अवकाश भुगतान का प्रकार";
        //        tr.cells[4].innerHTML = "अवकाश का प्रकार ";
        //        tr.cells[5].innerHTML = "अवकाश के दिन ";
        //        //============Hindi Text================//
        //        tr.cells[0].className = "Frm_Txt_Hindi";
        //        tr.cells[1].className = "Frm_Txt_Hindi";
        //        tr.cells[2].className = "Frm_Txt_Hindi";
        //        tr.cells[3].className = "Frm_Txt_Hindi";
        //        tr.cells[4].className = "Frm_Txt_Hindi";
        //        tr.cells[5].className = "Frm_Txt_Hindi";
    }
    //=====Form ID 210, Form Name:HRManagement/rpt_SeniorityListNew.aspx
    if (Choice == 0 && FormId == 254) {
        document.getElementById("LblHeader").innerHTML = "वरिष्ठता सूची";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        // Branch Radio button code
        var RBHindi = document.getElementById("RbWithBranch");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "उप शाखा सहित";
        RB[0].className = "Frm_Txt_Hindi";

        var RBenglish = document.getElementById("RbWithoutBranch");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "उप शाखा रहित";
        RB[0].className = "Frm_Txt_Hindi";

        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnPrint").value = "प्रिंट करे";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";
        document.getElementById("lblDesignation").innerHTML = "पद नाम";
        document.getElementById("lblToDate").innerHTML = "दिनांक तक";
        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblDesignation").className = "Frm_Txt_Hindi";
        document.getElementById("lblToDate").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";
    }
    //=====Form ID 250, Form Name:HRManagement/Master/frm_FestivalAdvanceApplicationForm.aspx
    if (Choice == 0 && FormId == 250) {
        document.getElementById("LblHeader").innerHTML = "त्यौहार अग्रिम आवेदन पत्र ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("lblADate").innerHTML = "आवेदन दिनांक";
        document.getElementById("lblApplicantName").innerHTML = "आवेदन कर्ता का नाम";
        document.getElementById("lblDesignation").innerHTML = "पद का नाम";
        document.getElementById("lblJoiningPost").innerHTML = "पद स्थान";
        document.getElementById("lblJobType").innerHTML = "सेवा का प्रकार";
        //        document.getElementById("rbPermanent").innerHTML = "स्थायी";
        //        document.getElementById("rbTemp").innerHTML = "अस्थायी";
        var RBPermanent = document.getElementById("rbPermanent");
        var RB = RBPermanent.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "स्थायी";

        var RBTemp = document.getElementById("rbTemp");
        var RB = RBTemp.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "अस्थायी";

        document.getElementById("lblAppointmentDate").innerHTML = "नियुक्ती की दिनांक";
        document.getElementById("lblBasicSalary").innerHTML = "मूल वेतन";
        document.getElementById("lblDemandedAmount").innerHTML = "मांगी हुई अग्रिम राशि";
        document.getElementById("lblFestivalName").innerHTML = "त्यौहार का नाम ";
        document.getElementById("lblFestivalDate").innerHTML = "त्यौहार का दिनांक ";
        document.getElementById("lblApplicantAlready").innerHTML = "पूर्व अग्रिम त्यौहार की दिनांक";
        document.getElementById("lblPreviousFestival").innerHTML = "बकाया अग्रिम त्यौहार";
        document.getElementById("lblPreAmountDeduct").innerHTML = "पूर्व अग्रिम त्यौहार का पूर्ण कटौत्रा";
        //        document.getElementById("rdbYes").innerHTML = "हाँ";
        //        document.getElementById("rdbNo").innerHTML = "नहीँ";
       
        document.getElementById("lblUploadletter").innerHTML = "अपलोड जमानत नामा";
        document.getElementById("lnkdownload").innerHTML = "जमानत नामा फोरमेट प्रिंट करेँ ";
        document.getElementById("lblNote").innerHTML = "नोट :-";
        document.getElementById("lblnoteDetail").innerHTML = "फाईल का प्रकार JPG,JPEG,PNG,GIF,PDF मेँ हो और इसकी साईज़ 512 KB से ज्यादा ना हो । ";
        document.getElementById("lblForwardTo").innerHTML = "अग्रेषित कर्मचारी";
        document.getElementById("btnForward").value = "रक्षित करे";    
        document.getElementById("btnCancel").value = "रद्द करे";
        var rbYes = document.getElementById("rdbYes");
        var rb = rbYes.parentNode.getElementsByTagName("label");
        rb[0].innerHTML = "हाँ";

        var rbNo = document.getElementById("rdbNo");
        var rb = rbNo.parentNode.getElementsByTagName("label");
        rb[0].innerHTML = "नहीँ";

        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblADate").className = "Frm_Txt_Hindi";
        document.getElementById("lblApplicantName").className = "Frm_Txt_Hindi";
        document.getElementById("lblDesignation").className = "Frm_Txt_Hindi";
        document.getElementById("lblJoiningPost").className = "Frm_Txt_Hindi";
        document.getElementById("lblJobType").className = "Frm_Txt_Hindi";
        var RBPermanent = document.getElementById("rbPermanent");
        var RB = RBPermanent.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "स्थायी";

        var RBTemp = document.getElementById("rbTemp");
        var RB = RBTemp.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "अस्थायी";
        document.getElementById("lblAppointmentDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblBasicSalary").className = "Frm_Txt_Hindi";
        document.getElementById("lblDemandedAmount").className = "Frm_Txt_Hindi";
        document.getElementById("lblFestivalName").className = "Frm_Txt_Hindi";
        document.getElementById("lblFestivalDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblApplicantAlready").className = "Frm_Txt_Hindi";
        document.getElementById("lblPreviousFestival").className = "Frm_Txt_Hindi";
        document.getElementById("lblPreAmountDeduct").className = "Frm_Txt_Hindi";
        document.getElementById("rdbYes").className = "Frm_Txt_Hindi";
        document.getElementById("rdbNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblUploadletter").className = "Frm_Txt_Hindi";
        document.getElementById("lnkdownload").className = "Frm_Txt_Hindi";
        document.getElementById("lblNote").className = "Frm_Txt_Hindi";
        document.getElementById("lblnoteDetail").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwardTo").className = "Frm_Txt_Hindi";
        document.getElementById("btnForward").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        //Grid Code Start
    }

    //=====Form ID 251, Form Name:HRManagement/Master/Frm_GrainAdvanceApplicationForm.aspx
    if (Choice == 0 && FormId == 251) {
        document.getElementById("LblHeader").innerHTML = "अनाज अग्रिम आवेदन पत्र ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("lblADate").innerHTML = "आवेदन दिनांक";
        document.getElementById("lblApplicantName").innerHTML = "आवेदन कर्ता का नाम";
        document.getElementById("lblDesignation").innerHTML = "पद का नाम";
        document.getElementById("lblJoiningPost").innerHTML = "पद स्थान";
        document.getElementById("lblBasicSalary").innerHTML = "सेवा का प्रकार";
        var RBPermanent = document.getElementById("rbPermanent");
        var RB = RBPermanent.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "स्थायी";

        var RBTemp = document.getElementById("rbTemp");
        var RB = RBTemp.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "अस्थायी";
        document.getElementById("lblTotalSalary").innerHTML = "मूल वेतन";
        document.getElementById("lblDemandedAmount").innerHTML = "मांगी हुई अग्रिम राशि";
        document.getElementById("lblUploadletter").innerHTML = "अपलोड जमानत नामा";
        document.getElementById("lnkdownload").innerHTML = "जमानत नामा फोरमेट प्रिंट करेँ ";
        document.getElementById("lblNote").innerHTML = "नोट :-";
        document.getElementById("lblnoteDetail").innerHTML = "फाईल का प्रकार JPG,JPEG,PNG,GIF,PDF मेँ हो और इसकी साईज़ 512 KB से ज्यादा ना हो । ";
        document.getElementById("lblForwardTo").innerHTML = "अग्रेषित कर्मचारी";
        document.getElementById("btnForward").value = "रक्षित करे";     
        document.getElementById("btnCancel").value = "रद्द करे";

        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblADate").className = "Frm_Txt_Hindi";
        document.getElementById("lblApplicantName").className = "Frm_Txt_Hindi";
        document.getElementById("lblDesignation").className = "Frm_Txt_Hindi";
        document.getElementById("lblJoiningPost").className = "Frm_Txt_Hindi";
        document.getElementById("lblBasicSalary").className = "Frm_Txt_Hindi";
        document.getElementById("rbPermanent").className = "Frm_Txt_Hindi";
        document.getElementById("rbTemp").className = "Frm_Txt_Hindi";
        document.getElementById("lblTotalSalary").className = "Frm_Txt_Hindi";
        document.getElementById("lblDemandedAmount").className = "Frm_Txt_Hindi";
        document.getElementById("lblApplicantAlready").className = "Frm_Txt_Hindi";
        document.getElementById("lblPreviousFastival").className = "Frm_Txt_Hindi";
        document.getElementById("lblUploadletter").className = "Frm_Txt_Hindi";
        document.getElementById("lnkdownload").className = "Frm_Txt_Hindi";
        document.getElementById("lblNote").className = "Frm_Txt_Hindi";
        document.getElementById("lblnoteDetail").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwardTo").className = "Frm_Txt_Hindi";
        document.getElementById("btnForward").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        //document.getElementById("ddlReportedTo").className = "ddl_Hindi";
        //Grid Code Start
        var table = document.getElementById("gvGrainAdvance");
        var tr = table.rows[0];
        document.getElementById("gvGrainAdvance_ctl01_HSelectAll").nextSibling.innerHTML = "सभी चुनें";
        // tr.cells[0].innerHTML = "सभी चुनेँ ";
        tr.cells[1].innerHTML = "आवेदन कर्ता";
        tr.cells[2].innerHTML = "पद का नाम";
        tr.cells[3].innerHTML = "सेवा का प्रकार";
        tr.cells[4].innerHTML = "मूल वेतन ";
        tr.cells[5].innerHTML = "मांगी हुई अग्रिम राशि";
        tr.cells[6].innerHTML = "पूर्व अग्रिम अनाज की दिनांक";
        tr.cells[7].innerHTML = "बकाया अग्रिम अनाज";
        tr.cells[8].innerHTML = "आवेदन दिनांक";
        tr.cells[9].innerHTML = "जमानत नामा देखेँ";
        tr.cells[10].innerHTML = "स्थिति";

        //============Hindi Text================//
        //tr.cells[0].className = "Frm_Txt_Hindi";
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


    //=====Form ID 252, Form Name:HRManagement/Master/frm_Travelling_Advance.aspx
    if (Choice == 0 && FormId == 252) {
        document.getElementById("LblHeader").innerHTML = "यात्रा अग्रिम आवेदन पत्र ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("lblApplicationdate").innerHTML = "आवेदन दिनांक";
        document.getElementById("lblName").innerHTML = "आवेदन कर्ता का नाम";
        document.getElementById("lblDesignation").innerHTML = "पद का नाम";
        document.getElementById("lblBasicSalary").innerHTML = "मूल वेतन";
        document.getElementById("lblTravellingAllowance").innerHTML = "यात्रा भत्ता हेतु श्रेणी";
        document.getElementById("lblDailyAllowanceRate").innerHTML = " दैनिक भत्ते की दर";
        document.getElementById("lblPlaceName").innerHTML = "यात्रा स्थान";
        document.getElementById("lblReasonOfTravel").innerHTML = "यात्रा का कारण ";
        document.getElementById("lblOrderByOfficer").innerHTML = "आदेशानुसार";
        document.getElementById("lblRemainingAmount").innerHTML = "बकाया अग्रिम राशि";
        document.getElementById("lblPeriodOfTravel").innerHTML = "यात्रा की अवधि(दिन)";
        document.getElementById("lblTypeOfTransport").innerHTML = "यात्रा का प्रकार";
        document.getElementById("lblExpectedExpenditure").innerHTML = "अनुमानित खर्च ";
        document.getElementById("lblTravelCharge").innerHTML = "यात्रा खर्च";
        document.getElementById("lblLodgeCharges").innerHTML = "लाजिंग खर्च ";
        document.getElementById("lblDailyAllowance").innerHTML = "दैनिक भत्ता ";
        document.getElementById("lblTexiAutoCharges").innerHTML = "टेक्सी/आटो/रिक्शा खर्चा  ";
        document.getElementById("lblLuggageCharges").innerHTML = "सामान किराया";
        document.getElementById("lblTotalCharge").innerHTML = "कुल खर्चा";
        document.getElementById("lblForwardTo").innerHTML = "अग्रेषित कर्मचारी";
        document.getElementById("btnForward").value = "रक्षित करे";
        document.getElementById("btnCancel").value = "रद्द करे";

        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblApplicationdate").className = "Frm_Txt_Hindi";
        document.getElementById("lblName").className = "Frm_Txt_Hindi";
        document.getElementById("lblDesignation").className = "Frm_Txt_Hindi";
        document.getElementById("lblBasicSalary").className = "Frm_Txt_Hindi";
        document.getElementById("lblTravellingAllowance").className = "Frm_Txt_Hindi";
        document.getElementById("lblDailyAllowanceRate").className = "Frm_Txt_Hindi";
        document.getElementById("lblPlaceName").className = "Frm_Txt_Hindi";
        document.getElementById("lblReasonOfTravel").className = "Frm_Txt_Hindi";
        document.getElementById("lblOrderByOfficer").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemainingAmount").className = "Frm_Txt_Hindi";
        document.getElementById("lblPeriodOfTravel").className = "Frm_Txt_Hindi";
        document.getElementById("lblTypeOfTransport").className = "Frm_Txt_Hindi";
        document.getElementById("lblExpectedExpenditure").className = "Frm_Txt_Hindi";
        document.getElementById("lblTravelCharge").className = "Frm_Txt_Hindi";
        document.getElementById("lblLodgeCharges").className = "Frm_Txt_Hindi";
        document.getElementById("lblDailyAllowance").className = "Frm_Txt_Hindi";
        document.getElementById("lblTexiAutoCharges").className = "Frm_Txt_Hindi";
        document.getElementById("lblLuggageCharges").className = "Frm_Txt_Hindi";
        document.getElementById("lblTotalCharge").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwardTo").className = "Frm_Txt_Hindi";
        document.getElementById("btnForward").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        //document.getElementById("ddlReportedTo").className = "ddl_Hindi";
    }

    //=====Form ID 249, Form Name:HRManagement/Master/frm_TravelingAllowance_Recommandation.aspx
    if (Choice == 0 && FormId == 249) {
        document.getElementById("LblHeader").innerHTML = "यात्रा अग्रिम अनुशंसा ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("lblTravelAllowanceReqNo").innerHTML = "यात्रा अग्रिम निवेदन क्रमांक";
        document.getElementById("lbl_ApplicantInfo").innerHTML = "आवेदन की जानकारी";
        document.getElementById("lblName").innerHTML = "आवेदन कर्ता का नाम";
        document.getElementById("lblDesignation").innerHTML = "पद का नाम";
        document.getElementById("lblBasicSalary").innerHTML = "मूल वेतन";
        document.getElementById("lblTravellingAllowance").innerHTML = "यात्रा भत्ता हेतु श्रेणी";
        document.getElementById("lblDailyAllowanceRate").innerHTML = " दैनिक भत्ते की दर";
        document.getElementById("lblPlaceName").innerHTML = "यात्रा स्थान";
        document.getElementById("lblReasonOfTravel").innerHTML = "यात्रा का कारण ";
        document.getElementById("lblOrderByOfficer").innerHTML = "आदेशानुसार";
        document.getElementById("lblRemainingAmount").innerHTML = "बकाया अग्रिम राशि";
        document.getElementById("lblPeriodOfTravel").innerHTML = "यात्रा की अवधि";
        document.getElementById("lblTypeOfTransport").innerHTML = "यात्रा का प्रकार";
        document.getElementById("lblExpectedExpenditure").innerHTML = "अनुमानित खर्च ";
        document.getElementById("lblTravelCharge").innerHTML = "यात्रा खर्च";
        document.getElementById("lblLodgeCharges").innerHTML = "लाजिंग खर्च ";
        document.getElementById("lblDailyAllowance").innerHTML = "दैनिक भत्ता ";
        document.getElementById("lblTexiAutoCharges").innerHTML = "टेक्सी/आटो/रिक्शा खर्चा  ";
        document.getElementById("lblLuggageCharges").innerHTML = "सामान किराया";
        document.getElementById("lblTotalCharge").innerHTML = "कुल खर्चा";
        document.getElementById("lbl_ROfficer").innerHTML = "अधिकारी के द्वारा अनुशंसा";
        if (document.getElementById("lblEmployeeName") != null) {
            document.getElementById("lblEmployeeName").innerHTML = "आवेदन कर्ता का नाम";
            document.getElementById("lblPlace").innerHTML = "यात्रा स्थान";
            document.getElementById("lblRemainamount").innerHTML = "पूर्व अग्रिम यात्रा की बकाया राशि ";
            document.getElementById("lblSenctionalAmount").innerHTML = "राशि";
            document.getElementById("btns").value = "देखें";
        }
        document.getElementById("lblSenctional").innerHTML = "प्रतिक्रिया दिनांक";
        document.getElementById("lblForwarededFor").innerHTML = "प्रतिक्रिया";
        document.getElementById("lblForwardTo").innerHTML = "अग्रेषित कर्मचारी";
        document.getElementById("lblRemark").innerHTML = "विवरण";
        document.getElementById("btnForward").value = "रक्षित करे";
        document.getElementById("btnCancel").value = "रद्द करे";

        var RBcheque = document.getElementById("rbChecque");
        var RB = RBcheque.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "चैक/ डी डी";

        var RBepay = document.getElementById("rbePay");
        var RBe = RBepay.parentNode.getElementsByTagName("label");
        RBe[0].innerHTML = "ई पेमेंट";

        document.getElementById("lblPaymentMode").innerHTML = "भुगतान का प्रकार ";
        document.getElementById("lblPaymentMode").className = "Frm_Txt_Hindi";

        document.getElementById("LblSelectBank").innerHTML = "बैंक का नाम";
        document.getElementById("lblCheque").innerHTML = "चैक/ डी डी नं.";

        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblTravelAllowanceReqNo").className = "Frm_Txt_Hindi";
        document.getElementById("lbl_ApplicantInfo").className = "Frm_Txt_Hindi";
        document.getElementById("lblName").className = "Frm_Txt_Hindi";
        document.getElementById("lblDesignation").className = "Frm_Txt_Hindi";
        document.getElementById("lblBasicSalary").className = "Frm_Txt_Hindi";
        document.getElementById("lblTravellingAllowance").className = "Frm_Txt_Hindi";
        document.getElementById("lblDailyAllowanceRate").className = "Frm_Txt_Hindi";
        document.getElementById("lblPlaceName").className = "Frm_Txt_Hindi";
        document.getElementById("lblReasonOfTravel").className = "Frm_Txt_Hindi";
        document.getElementById("lblOrderByOfficer").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemainingAmount").className = "Frm_Txt_Hindi";
        document.getElementById("lblPeriodOfTravel").className = "Frm_Txt_Hindi";
        document.getElementById("lblTypeOfTransport").className = "Frm_Txt_Hindi";
        document.getElementById("lblExpectedExpenditure").className = "Frm_Txt_Hindi";
        document.getElementById("lblTravelCharge").className = "Frm_Txt_Hindi";
        document.getElementById("lblLodgeCharges").className = "Frm_Txt_Hindi";
        document.getElementById("lblDailyAllowance").className = "Frm_Txt_Hindi";
        document.getElementById("lblTexiAutoCharges").className = "Frm_Txt_Hindi";
        document.getElementById("lblLuggageCharges").className = "Frm_Txt_Hindi";
        document.getElementById("lblTotalCharge").className = "Frm_Txt_Hindi";
        document.getElementById("lbl_ROfficer").className = "Frm_Txt_Hindi";
        if (document.getElementById("lblEmployeeName") != null) {
            document.getElementById("lblEmployeeName").className = "Frm_Txt_Hindi";
            document.getElementById("lblPlace").className = "Frm_Txt_Hindi";
            document.getElementById("lblRemainamount").className = "Frm_Txt_Hindi";
            document.getElementById("lblSenctionalAmount").className = "Frm_Txt_Hindi";
            document.getElementById("btns").className = "btn_Hindi";
        }
        document.getElementById("lblSenctional").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwarededFor").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwardTo").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemark").className = "Frm_Txt_Hindi";
        document.getElementById("btnForward").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
      
    }

    //=====Form ID 275, Form Name:HRManagement/Master/frm_Grain_Advance_Recommandation.aspx
    if (Choice == 0 && FormId == 275) {
        document.getElementById("LblHeader").innerHTML = "अनाज  अग्रिम अनुशंसा ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("lblTravelAllowanceReqNo").innerHTML = "अनाज अग्रिम निवेदन क्रमांक";
        document.getElementById("lbl_ApplicantInfo").innerHTML = "आवेदन की जानकारी";
        document.getElementById("lblApplicantName").innerHTML = "आवेदन कर्ता का नाम";
        document.getElementById("lblDesignation").innerHTML = "पद का नाम";
        document.getElementById("lblJoiningPost").innerHTML = "पद स्थान";
        document.getElementById("lblBasicSalary").innerHTML = "सेवा का प्रकार";
        var RBPermanent = document.getElementById("rbPermanent");
        var RB = RBPermanent.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "स्थायी";

        var RBTemp = document.getElementById("rbTemp");
        var RB = RBTemp.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "अस्थायी";
        
        document.getElementById("lblTotalSalary").innerHTML = "मूल वेतन";
        document.getElementById("lblDemandedAmount").innerHTML = " मांगी हुई अग्रिम राशि";    
        document.getElementById("lnkViewOrder").innerHTML = "जमानत नामा देखेँ ";
        document.getElementById("lbl_ROfficer").innerHTML = "अधिकारी के द्वारा अनुशंसा";
        if (document.getElementById("lblEmployeeName") != null) {
            document.getElementById("lblEmployeeName").innerHTML = "आवेदन कर्ता का नाम";
            document.getElementById("lblRemainamount").innerHTML = "पूर्व अग्रिम अनाज की बकाया राशि ";
            document.getElementById("lblSenctionalAmount").innerHTML = "राशि";           
        }
        document.getElementById("lblSenctional").innerHTML = "प्रतिक्रिया दिनांक";
        document.getElementById("lblRemark").innerHTML = "विवरण";
        document.getElementById("lblForwarededFor").innerHTML = "प्रतिक्रिया";
        document.getElementById("lblForwardTo").innerHTML = "अग्रेषित कर्मचारी";
        document.getElementById("btnForward").value = "रक्षित करे";
        document.getElementById("btnCancel").value = "रद्द करे";

        var RBcheque = document.getElementById("rbChecque");
        var RB = RBcheque.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "चैक/ डी डी";

        var RBepay = document.getElementById("rbePay");
        var RBe = RBepay.parentNode.getElementsByTagName("label");
        RBe[0].innerHTML = "ई पेमेंट";

        document.getElementById("lblPaymentMode").innerHTML = "भुगतान का प्रकार ";
        document.getElementById("lblPaymentMode").className = "Frm_Txt_Hindi";

        document.getElementById("LblSelectBank").innerHTML = "बैंक का नाम";
        document.getElementById("lblCheque").innerHTML = "चैक/ डी डी नं.";
        document.getElementById("LblSelectBank").className = "Frm_Txt_Hindi";
        document.getElementById("lblCheque").className = "Frm_Txt_Hindi";

        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblTravelAllowanceReqNo").className = "Frm_Txt_Hindi";
        document.getElementById("lbl_ApplicantInfo").className = "Frm_Txt_Hindi";
        document.getElementById("lblApplicantName").className = "Frm_Txt_Hindi";
        document.getElementById("lblDesignation").className = "Frm_Txt_Hindi";
        document.getElementById("lblJoiningPost").className = "Frm_Txt_Hindi";
        document.getElementById("rbPermanent").className = "Frm_Txt_Hindi";
        document.getElementById("rbTemp").className = "Frm_Txt_Hindi";
        document.getElementById("lblTotalSalary").className = "Frm_Txt_Hindi";
        document.getElementById("lblDemandedAmount").className = "Frm_Txt_Hindi";  
        document.getElementById("lnkViewOrder").className = "Frm_Txt_Hindi";

        document.getElementById("lbl_ROfficer").className = "Frm_Txt_Hindi";
        if (document.getElementById("lblEmployeeName") != null) {
            document.getElementById("lblEmployeeName").className = "Frm_Txt_Hindi";
            document.getElementById("lblRemainamount").className = "Frm_Txt_Hindi";
            document.getElementById("lblSenctionalAmount").className = "Frm_Txt_Hindi";
            document.getElementById("btns").className = "btn_Hindi";
        }
        document.getElementById("lblSenctional").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemark").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwarededFor").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwardTo").className = "Frm_Txt_Hindi";
        document.getElementById("btnForward").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";


    }

    //=====Form ID 276, Form Name:HRManagement/Master/ffrm_Festival_Advance_Recommandation.aspx
    if (Choice == 0 && FormId == 276) {
        document.getElementById("LblHeader").innerHTML = "त्यौहार  अग्रिम अनुशंसा ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("lblTravelAllowanceReqNo").innerHTML = "त्यौहार अग्रिम निवेदन क्रमांक";
        document.getElementById("lbl_ApplicantInfo").innerHTML = "आवेदन की जानकारी";
        document.getElementById("lblApplicantName").innerHTML = "आवेदन कर्ता का नाम";
        document.getElementById("lblDesignation").innerHTML = "पद का नाम";
        document.getElementById("lblJoiningPost").innerHTML = "पद स्थान";
        document.getElementById("lblJobType").innerHTML = "सेवा का प्रकार";

        var RBPermanent = document.getElementById("rbPermanent");
        var RB = RBPermanent.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "स्थायी";

        var RBTemp = document.getElementById("rbTemp");
        var RB = RBTemp.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "अस्थायी";
        document.getElementById("lblAppointmentDate").innerHTML = "नियुक्ती की दिनांक";
        document.getElementById("lblBasicSalary").innerHTML = "मूल वेतन";
        document.getElementById("lblDemandedAmount").innerHTML = "मांगी हुई अग्रिम राशि";
        document.getElementById("lblFestivalName").innerHTML = "त्यौहार का नाम ";
        document.getElementById("lblFestivalDate").innerHTML = "त्यौहार का दिनांक ";
        document.getElementById("lblApplicantAlready").innerHTML = "पूर्व अग्रिम त्यौहार की दिनांक";
        document.getElementById("lblPreviousFestival").innerHTML = "बकाया अग्रिम त्यौहार";
        document.getElementById("lblPreAmountDeduct").innerHTML = "पूर्व अग्रिम त्यौहार का पूर्ण कटौत्रा";
        
        document.getElementById("lnkViewOrder").innerHTML = "जमानत नामा देखेँ ";
        document.getElementById("lbl_ROfficer").innerHTML = "अधिकारी के द्वारा अनुशंसा";
      
        document.getElementById("lblSenctional").innerHTML = "प्रतिक्रिया दिनांक";
        document.getElementById("lblRemark").innerHTML = "विवरण";
        document.getElementById("lblForwarededFor").innerHTML = "प्रतिक्रिया";
        document.getElementById("lblForwardTo").innerHTML = "अग्रेषित कर्मचारी";
        document.getElementById("btnForward").value = "रक्षित करे";
        document.getElementById("btnCancel").value = "रद्द करे";
        if (document.getElementById("lblEmployeeName") != null) {
            document.getElementById("lblEmployeeName").innerHTML = "आवेदन कर्ता का नाम";
            document.getElementById("lblRemainamount").innerHTML = "पूर्व अग्रिम त्यौहार की बकाया राशि ";
            document.getElementById("lblSenctionalAmount").innerHTML = "राशि";

        }
        var RBcheque = document.getElementById("rbChecque");
        var RB = RBcheque.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "चैक/ डी डी";

        var RBepay = document.getElementById("rbePay");
        var RBe = RBepay.parentNode.getElementsByTagName("label");
        RBe[0].innerHTML = "ई पेमेंट";
        
        document.getElementById("lblPaymentMode").innerHTML = "भुगतान का प्रकार -:";
        document.getElementById("lblPaymentMode").className = "Frm_Txt_Hindi";

        document.getElementById("LblSelectBank").innerHTML = "बैंक का नाम";
        document.getElementById("lblCheque").innerHTML = "चैक/ डी डी नं.";
        
        var rbYes = document.getElementById("rdbYes");
        var rb = rbYes.parentNode.getElementsByTagName("label");
        rb[0].innerHTML = "हाँ";

        var rbNo = document.getElementById("rdbNo");
        var rb = rbNo.parentNode.getElementsByTagName("label");
        rb[0].innerHTML = "नहीँ";

        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblTravelAllowanceReqNo").className = "Frm_Txt_Hindi";
        document.getElementById("lbl_ApplicantInfo").className = "Frm_Txt_Hindi";
        document.getElementById("lblApplicantName").className = "Frm_Txt_Hindi";
        document.getElementById("lblDesignation").className = "Frm_Txt_Hindi";
        document.getElementById("lblJobType").className = "Frm_Txt_Hindi";
        document.getElementById("rbPermanent").className = "Frm_Txt_Hindi";
        document.getElementById("rbTemp").className = "Frm_Txt_Hindi";
        document.getElementById("lblAppointmentDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblBasicSalary").className = "Frm_Txt_Hindi";
        document.getElementById("lblDemandedAmount").className = "Frm_Txt_Hindi";
        document.getElementById("lblFestivalName").className = "Frm_Txt_Hindi ";
        document.getElementById("lblFestivalDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblApplicantAlready").className = "Frm_Txt_Hindi";
        document.getElementById("lblPreviousFestival").className = "Frm_Txt_Hindi";
        document.getElementById("lblPreAmountDeduct").className = "Frm_Txt_Hindi";
        document.getElementById("lnkViewOrder").className = "Frm_Txt_Hindi";

        document.getElementById("lbl_ROfficer").className = "Frm_Txt_Hindi";
        if (document.getElementById("lblEmployeeName") != null) {
            document.getElementById("lblEmployeeName").className = "Frm_Txt_Hindi";
            document.getElementById("lblRemainamount").className = "Frm_Txt_Hindi";
            document.getElementById("lblSenctionalAmount").className = "Frm_Txt_Hindi";
            document.getElementById("btns").className = "btn_Hindi";
        }
        document.getElementById("lblSenctional").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemark").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwarededFor").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwardTo").className = "Frm_Txt_Hindi";
        document.getElementById("btnForward").className = "btn_Hindi";      
        document.getElementById("btnCancel").className = "btn_Hindi";


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
    //=====Form ID 256, Form Name:HR_Report/rpt_Combined_epf_challan.aspx
    if (Choice == 0 && FormId == 256) {
        document.getElementById("LblHeader").innerHTML = "सामुहिक ई पी एफ चालान ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        
        var RBHindi = document.getElementById("rbWithBranch");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "उप शाखा सहित";
        RB[0].className = "Frm_Txt_Hindi";

        var RBenglish = document.getElementById("rbWithoutBranch");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "उप शाखा रहित";
        RB[0].className = "Frm_Txt_Hindi";

        // Branch Radio button code
        var RBHindi = document.getElementById("rbDeputation");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "प्रतिनियुक्ति";
        RB[0].className = "Frm_Txt_Hindi";

        var RBenglish = document.getElementById("rbOther");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "अन्य";
        RB[0].className = "Frm_Txt_Hindi";


//        document.getElementById("lblState").innerHTML = "मुख्य कार्यालय";
//        document.getElementById("lblDistrict").innerHTML = "डिपो/गोदाम";
        document.getElementById("lblMonth").innerHTML = "माह";
        document.getElementById("lblYear").innerHTML = "वर्ष";
        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnPrint").value = "प्रिंट करे";       
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";


        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblState").className = "Frm_Txt_Hindi";
        document.getElementById("lblDistrict").className = "Frm_Txt_Hindi";
        document.getElementById("lblMonth").className = "Frm_Txt_Hindi";
        document.getElementById("lblYear").className = "Frm_Txt_Hindi";
       
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";
    }
    //=====Form ID 271, Form Name:HR_Report/rpt_Traveling_and_Advance_Register.aspx
    if (Choice == 0 && FormId == 271) {
        document.getElementById("LblHeader").innerHTML = "यात्रा एवँ  अग्रिम पंजी ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        // Branch Radio button code

        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("lblEmployee").innerHTML = "कर्मचारी  ";
        document.getElementById("lblFromDate").innerHTML = "दिनांक से ";
        document.getElementById("lblToDate").innerHTML = "दिनांक तक";
        document.getElementById("btnSaveAsExecel").value = "एक्सेल में रक्षित करें";


        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblEmployee").className = "Frm_Txt_Hindi";
        document.getElementById("lblFromDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblToDate").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveAsExecel").className = "btn_Hindi";
    }
    if (Choice == 0 && FormId == 272) {
        //document.getElementById("LblHeader").innerHTML = "अग्रिम ";
        document.getElementById("hlHome").innerHTML = "होमपेज";       
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        // Branch Radio button code

        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("lblEmployee").innerHTML = "कर्मचारी  ";
        document.getElementById("lblFromDate").innerHTML = "दिनांक से ";
        document.getElementById("lblToDate").innerHTML = "दिनांक तक";
        document.getElementById("btnSaveAsExecel").value = "एक्सेल में रक्षित करें";


        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblEmployee").className = "Frm_Txt_Hindi";
        document.getElementById("lblFromDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblToDate").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveAsExecel").className = "btn_Hindi";
    }

    if (Choice == 0 && FormId == 273) {
        //document.getElementById("LblHeader").innerHTML = "यात्रा एवँ  अग्रिम पंजी ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        // Branch Radio button code

        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("lblEmployee").innerHTML = "कर्मचारी  ";
        document.getElementById("lblFromDate").innerHTML = "दिनांक से ";
        document.getElementById("lblToDate").innerHTML = "दिनांक तक";
        document.getElementById("btnSaveAsExecel").value = "एक्सेल में रक्षित करें";


        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblEmployee").className = "Frm_Txt_Hindi";
        document.getElementById("lblFromDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblToDate").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveAsExecel").className = "btn_Hindi";
    }

    if (Choice == 0 && FormId == 274) {
        //document.getElementById("LblHeader").innerHTML = "यात्रा एवँ  अग्रिम पंजी ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        // Branch Radio button code

        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("lblEmployee").innerHTML = "कर्मचारी  ";
        document.getElementById("lblFromDate").innerHTML = "दिनांक से ";
        document.getElementById("lblToDate").innerHTML = "दिनांक तक";
        document.getElementById("btnSaveAsExecel").value = "एक्सेल में रक्षित करें";


        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblEmployee").className = "Frm_Txt_Hindi";
        document.getElementById("lblFromDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblToDate").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveAsExecel").className = "btn_Hindi";
    }
    if (Choice == 0 && FormId == 258) {
        document.getElementById("LblHeader").innerHTML = " सेवा पुस्तिका ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        // Branch Radio button code

        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("lblEmployee").innerHTML = "कर्मचारी  ";
        document.getElementById("lblFromDate").innerHTML = "दिनांक से ";
        document.getElementById("lblToDate").innerHTML = "दिनांक तक";
        document.getElementById("btnSaveAsExecel").value = "एक्सेल में रक्षित करें";


        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblEmployee").className = "Frm_Txt_Hindi";
        document.getElementById("lblFromDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblToDate").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveAsExecel").className = "btn_Hindi";
    }
    //=====Form ID 276, Form Name:HRManagement/Transaction/Frm_TravellingAllowance_Bill.aspx
    if (Choice == 0 && FormId == 253) {
        document.getElementById("LblHeader").innerHTML = "यात्रा बिल ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        if (document.getElementById("lblTravelAllowanceReqNo") != null) {
            document.getElementById("lblTravelAllowanceReqNo").innerHTML = "यात्रा बिल निवेदन क्रमांक";
        }
        document.getElementById("lblHeaderDetail").innerHTML = "बिल विवरण";
        document.getElementById("lblPayment").innerHTML = "कुल विवरण";
        
        document.getElementById("LblEmployee").innerHTML = "आवेदन कर्ता का नाम";
        document.getElementById("lblCategory").innerHTML = "श्रेणी";
        document.getElementById("lblPosted").innerHTML = "पद का नाम";
        document.getElementById("lblPostedField").innerHTML = "पद स्थान";
        document.getElementById("lblBasicPay").innerHTML = "ग्रेड पे ";
       // document.getElementById("lblSpecialPay").innerHTML = "विशेष भुगतान ";

        document.getElementById("lblDeparture").innerHTML = "प्रस्थान";
        document.getElementById("lblDStation").innerHTML = "स्टेशन";
        document.getElementById("lblDDate").innerHTML = "दिनांक ";
        document.getElementById("lblTime").innerHTML = "समय (घंटे मे)";
        
        document.getElementById("lblArrivalDetails").innerHTML = "आगमन";
        document.getElementById("lblArrStation").innerHTML = "स्टेशन";
        document.getElementById("lblArrDate").innerHTML = "दिनांक ";
        document.getElementById("lblArrTime").innerHTML = "समय (घंटे मे)";

        document.getElementById("lblJourneyDetails").innerHTML = "यात्रा विवरण";
        document.getElementById("lblKindOfJourney").innerHTML = "यात्रा का प्रकार";
        document.getElementById("lblClass").innerHTML = "यात्रा श्रेणी";
        document.getElementById("lblNoFares").innerHTML = "यात्रियो की संख्या";
        document.getElementById("lblAmountOfFare").innerHTML = "यात्रा का कुल किराया";
        
//         document.getElementById("lblHeadQuarter").innerHTML = "मुख्यालय भत्ता";
//        document.getElementById("lblExtent").innerHTML = "डी.ए की सीमा";
//        document.getElementById("lblHeadAmount").innerHTML = "राशि";

        document.getElementById("lblDailyAllowance").innerHTML = "दैनिक भत्ते की सामान्य दर ";
        document.getElementById("lblDurationOfHalt").innerHTML = "ठहरने का समय (घंटे मे)";
        document.getElementById("lblDailyExtent").innerHTML = "डी.ए की सीमा";
        document.getElementById("lblDailyAmount").innerHTML = "राशि";

        document.getElementById("lblHaltSpecial").innerHTML = "ठहरने का भत्ता";
        document.getElementById("lblHaltDurationS").innerHTML = "ठहरने का समय (घंटे मे)";
        document.getElementById("lblHaltDA").innerHTML = "डी.ए की सीमा";
        document.getElementById("lblHaltAmount").innerHTML = "राशि";

//        document.getElementById("lblSpecialHalt").innerHTML = "विशेष ठहरने का भत्ता";
//        document.getElementById("lblSpecialExtent").innerHTML = "डी.ए की सीमा";
//        document.getElementById("lblSpecialAmount").innerHTML = "राशि";
        document.getElementById("lblGrandTotal").innerHTML = "क़ुल राशि";
        document.getElementById("lblRemark").innerHTML = "रिमार्क";

        document.getElementById("lblFare").innerHTML = "यात्रा किराया ";
        //document.getElementById("lblHeadQuarterAllowance").innerHTML = "मुख्यालय भत्ता ";
        document.getElementById("lblJourneyAllowance").innerHTML = "दैनिक भत्ते की सामान्य दर  ";
        document.getElementById("lblHaltAllown").innerHTML = "ठहरने का भत्ता";
        document.getElementById("lblOtherCharges").innerHTML = "अन्य भत्ता";
        document.getElementById("lblConveyance").innerHTML = "परिवहन व्यय  ";
        document.getElementById("lblLodging").innerHTML = "लाजिंग किराया";
        document.getElementById("lblTotalCharges").innerHTML = "क़ुल राशि ";
        document.getElementById("lblDeduction").innerHTML = "कटौत्रा";
        
        document.getElementById("lblGrossClaim").innerHTML = "सकल मांग राशि ";
        document.getElementById("lblAmountOfAdvance").innerHTML = "अग्रिम राशि";
        document.getElementById("lblTakenVide").innerHTML = "विवरण";
        document.getElementById("lblDate").innerHTML = "दिनांक";
        document.getElementById("lblNetClaim").innerHTML = "क़ुल मांग राशि";
        document.getElementById("lblPurpose").innerHTML = "यात्रा उद्देशय"; 

        document.getElementById("lblUploadBill").innerHTML = "अपलोड बिल";
        document.getElementById("lblAction").innerHTML = "प्रतिक्रिया";
        document.getElementById("lblForwardTo").innerHTML = "अग्रेषित कर्मचारी";
        document.getElementById("lnkViewOrder").innerHTML = "बिल देखे";
        document.getElementById("btnAdd").value = "जोङे ";
        document.getElementById("btnNew").value = "नया";
        document.getElementById("btnEdit").value = "सुधारे";
        document.getElementById("btnShow").value = "देखे"; 
        document.getElementById("btnForward").value = "रक्षित करे";      
        document.getElementById("btnCancel").value = "रद्द करे";

        document.getElementById("lblSenctional").innerHTML = "प्रतिक्रिया दिनांक";
        document.getElementById("lblReqRemark").innerHTML = "रिमार्क";

        var RBCash = document.getElementById("rbCash");
        var RB = RBCash.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "रोकड़";

        var RBcheque = document.getElementById("rbChecque");
        var RB = RBcheque.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "चैक/ डी डी";

        var RBepay = document.getElementById("rbePay");
        var RBe = RBepay.parentNode.getElementsByTagName("label");
        RBe[0].innerHTML = "ई पेमेंट";

        document.getElementById("LblSelectBank").innerHTML = "बैंक का नाम";
        document.getElementById("lblCheque").innerHTML = "चैक/ डी डी नं.";

        document.getElementById("lblPaymentMode").innerHTML = "भुगतान का प्रकार -:";
        document.getElementById("lblPaymentMode").className = "Frm_Txt_Hindi";
        document.getElementById("lblNote").innerHTML = "नोट :-";
        document.getElementById("lblnoteDetail").innerHTML = "फाईल का प्रकार JPG,JPEG,PNG,GIF,PDF मेँ हो और इसकी साईज़ 512 KB से ज्यादा ना हो । ";

        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblTravelAllowanceReqNo").className = "Frm_Txt_Hindi";
        document.getElementById("LblEmployee").className = "Frm_Txt_Hindi";
        document.getElementById("lblCategory").className = "Frm_Txt_Hindi";
        document.getElementById("lblPosted").className = "Frm_Txt_Hindi";
        document.getElementById("lblPostedField").className = "Frm_Txt_Hindi";
        document.getElementById("lblBasicPay").className = "Frm_Txt_Hindi";
        document.getElementById("lblSpecialPay").className = "Frm_Txt_Hindi";

        document.getElementById("lblDeparture").className = "Frm_Txt_Hindi";
        document.getElementById("lblDStation").className = "Frm_Txt_Hindi";
        document.getElementById("lblDDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblTime").className = "Frm_Txt_Hindi";

        document.getElementById("lblArrivalDetails").className = "Frm_Txt_Hindi";
        document.getElementById("lblArrStation").className = "Frm_Txt_Hindi";
        document.getElementById("lblArrDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblArrTime").className = "Frm_Txt_Hindi";

        document.getElementById("lblJourneyDetails").className = "Frm_Txt_Hindi";
        document.getElementById("lblKindOfJourney").className = "Frm_Txt_Hindi";
        document.getElementById("lblClass").className = "Frm_Txt_Hindi";
        document.getElementById("lblNoFares").className = "Frm_Txt_Hindi";
        document.getElementById("lblAmountOfFare").className = "Frm_Txt_Hindi";

        document.getElementById("lblHeadQuarter").className = "Frm_Txt_Hindi";
        document.getElementById("lblExtent").className = "Frm_Txt_Hindi";
        document.getElementById("lblHeadAmount").className = "Frm_Txt_Hindi";

        document.getElementById("lblDailyAllowance").className = "Frm_Txt_Hindi";
        document.getElementById("lblDurationOfHalt").className = "Frm_Txt_Hindi";
        document.getElementById("lblDailyExtent").className = "Frm_Txt_Hindi";
        document.getElementById("lblDailyAmount").className = "Frm_Txt_Hindi";

        document.getElementById("lblHaltSpecial").className = "Frm_Txt_Hindi";
        document.getElementById("lblHaltDurationS").className = "Frm_Txt_Hindi";
        document.getElementById("lblHaltDA").className = "Frm_Txt_Hindi";
        document.getElementById("lblHaltAmount").className = "Frm_Txt_Hindi";

        document.getElementById("lblSpecialHalt").className = "Frm_Txt_Hindi";
        document.getElementById("lblSpecialExtent").className = "Frm_Txt_Hindi";
        document.getElementById("lblSpecialAmount").className = "Frm_Txt_Hindi";
        document.getElementById("lblGrandTotal").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemark").className = "Frm_Txt_Hindi";

        document.getElementById("lblFare").className = "Frm_Txt_Hindi";
        document.getElementById("lblHeadQuarterAllowance").className = "Frm_Txt_Hindi";
        document.getElementById("lblJourneyAllowance").className = "Frm_Txt_Hindi";
        document.getElementById("lblHaltAllown").className = "Frm_Txt_Hindi";
        document.getElementById("lblSpecialAllowan").className = "Frm_Txt_Hindi";
        document.getElementById("lblConveyance").className = "Frm_Txt_Hindi";
        document.getElementById("lblLodging").className = "Frm_Txt_Hindi";
        document.getElementById("lblTotalCharges").className = "Frm_Txt_Hindi";
        document.getElementById("lblDeduction").className = "Frm_Txt_Hindi";

        document.getElementById("lblGrossClaim").className = "Frm_Txt_Hindi";
        document.getElementById("lblAmountOfAdvance").className = "Frm_Txt_Hindi";
        document.getElementById("lblTakenVide").className = "Frm_Txt_Hindi";
        document.getElementById("lblDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblNetClaim").className = "Frm_Txt_Hindi";
        document.getElementById("lblPurpose").className = "Frm_Txt_Hindi";

        document.getElementById("lblUploadBill").className = "Frm_Txt_Hindi";
        document.getElementById("lblAction").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwardTo").className = "Frm_Txt_Hindi";
        document.getElementById("lnkViewOrder").className = "btn_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnForward").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("lblSenctional").className = "Frm_Txt_Hindi";
        document.getElementById("lblReqRemark").className = "Frm_Txt_Hindi";
        document.getElementById("lblNote").className = "Frm_Txt_Hindi";
        document.getElementById("lblnoteDetail").className = "Frm_Txt_Hindi";
    }
    if (Choice == 0 && FormId == 278) {
        document.getElementById("LblHeader").innerHTML = "सावधि जमा रजिस्टर";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

       
        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";


        var RBAll = document.getElementById("rbAll");
        var RB = RBAll.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "सभी ";

        //*****
        var RBPending = document.getElementById("rbPending");
        var RB = RBPending.parentNode.getElementsByTagName("label");
        RB[1].innerHTML = "विलम्बित  ";
        // Branch Radio button code

        document.getElementById("btnShow").value = "देखें";
        document.getElementById("lblDataOption").innerHTML = "डाटा विकल्प ";
        document.getElementById("btnPrint").value = "प्रिंट करे";

        document.getElementById("lblBankName").innerHTML = "एफ डी आर जारीकर्ता बैंक";
        document.getElementById("lblBranchName").innerHTML = "एफ डी आर जारीकर्ता शाखा";
        document.getElementById("lblFDRNo").innerHTML = "एफ डी आर नं. ";
        document.getElementById("lblFDRDate").innerHTML = "एफ डी आर दिनांक";
        document.getElementById("lblRateOfIns").innerHTML = "ब्याज की दर ";
        document.getElementById("lblinterestamount").innerHTML = "ब्याज राशि";
        document.getElementById("lblDue_Date").innerHTML = "परिपक्वता दिनांक ";
        document.getElementById("lblMaturityamount").innerHTML = "परिपक्वता राशि";
        
        
        //document.getElementById("lblEmployee").innerHTML = "कर्मचारी  ";
        //document.getElementById("lblFromDate").innerHTML = "दिनांक से ";
        // document.getElementById("lblToDate").innerHTML = "दिनांक तक";
        document.getElementById("lblFinDate").innerHTML = "वित्तीय वर्ष ";
        document.getElementById("btnSaveAsExecel").value = "एक्सेल में रक्षित करें";


        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
       // document.getElementById("lblEmployee").className = "Frm_Txt_Hindi";
        //document.getElementById("lblFromDate").className = "Frm_Txt_Hindi";
        // document.getElementById("lblToDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblFinDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblDataOption").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";

        document.getElementById("lblBankName").className = "Frm_Txt_Hindi";
        document.getElementById("lblBranchName").className = "Frm_Txt_Hindi";
        document.getElementById("lblFDRNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblFDRDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblRateOfIns").className = "Frm_Txt_Hindi";
        document.getElementById("lblinterestamount").className = "Frm_Txt_Hindi";
        document.getElementById("lblDue_Date").className = "Frm_Txt_Hindi";
        document.getElementById("lblMaturityamount").className = "Frm_Txt_Hindi";
    }
    if (Choice == 0 && FormId == 261) {
        document.getElementById("LblHeader").innerHTML = " अवकाश खाता फार्म  ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        // Branch Radio button code

        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnPrint").value = "प्रिंट करे";
        document.getElementById("lblEmployee").innerHTML = "कर्मचारी  ";
        document.getElementById("lblFromDate").innerHTML = "दिनांक से ";
        document.getElementById("lblToDate").innerHTML = "दिनांक तक";
        document.getElementById("btnSaveAsExecel").value = "एक्सेल में रक्षित करें";


        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblEmployee").className = "Frm_Txt_Hindi";
        document.getElementById("lblFromDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblToDate").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";
    }
    //****HR_Report/rpt_Bank_Gurantee_Register.aspx formid='284'
    if (Choice == 0 && FormId == 284) {
        document.getElementById("LblHeader").innerHTML = "बैंक गारंटी रजिस्टर  ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";

        
        
        
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        //document.getElementById("rbAll").value = "सभी";
        var RBenglish = document.getElementById("rbAll");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "सभी";

        var RBenglish = document.getElementById("rbPending");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "लंबित";
        //document.getElementById("rbPending").innerHTML = "लंबित";
        
        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnPrint").value = "प्रिंट करे";
        document.getElementById("lblFinDate").innerHTML = "वित्तीय वर्ष  ";
        document.getElementById("btnSaveAsExecel").value = "एक्सेल में रक्षित करें";
//========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblFinDate").className = "Frm_Txt_Hindi";

        document.getElementById("rbAll").className = "btn_Hindi";
        document.getElementById("rbPending").className = "btn_Hindi";
        
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveAsExecel").className = "btn_Hindi";
    }
    //=====Form ID 290, Form Name:HRManagement/Transaction/frm_printing_bill_payment.aspx
    if (Choice == 0 && FormId == 290) {
        document.getElementById("LblHeader").innerHTML = "प्रिंटिंग रनिंग बिल का भुगतान";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        if (document.getElementById("lblBillRefNo1") != null) {
            document.getElementById("lblBillRefNo1").innerHTML = "बिल रेफरेंस क्रमांक";
            document.getElementById("lblBillRefNo1").className = "Frm_Txt_Hindi";
        }
        document.getElementById("lblProfitCenter").innerHTML = "लाभ केन्द्र";
        document.getElementById("lblPrinterName").innerHTML = " प्रिंटर का नाम";
        document.getElementById("lblBookTitle").innerHTML = "पुस्तक का नाम";
        document.getElementById("lblBillNo").innerHTML = "बिल क्रमांक";
        document.getElementById("lblBillDate").innerHTML = "बिल दिनांक ";
        document.getElementById("lblTenderNo").innerHTML = " टेंडर क्रमांक ";
        document.getElementById("lblGroupOfNo").innerHTML = "ग्रुप क्रमांक";
        if (document.getElementById("lblorderno") != null) {
            document.getElementById("lblorderno").innerHTML = "आदेश नं ";
        }

        if (document.getElementById("lblGroupOfNo") != null) {
            document.getElementById("lblPaymentMode").innerHTML = "भुगतान का प्रकार -:";
            document.getElementById("lblPaymentMode").className = "Frm_Txt_Hindi";
        }

        document.getElementById("lbl_ApplicantInfo").innerHTML = "Printing charges & SD reimbursement";
        document.getElementById("lblTotalPrintingCharge").innerHTML = "कुल प्रिंटिंग खर्चा ";
        document.getElementById("lblDeduct").innerHTML = "Deduct wilhheld(25% of printing charges)";
        document.getElementById("lblNetPrintingCharge").innerHTML = "Net Printing Charge Payable";
        document.getElementById("lblPrintingSecurityReimbusted").innerHTML = "Printing Security reimbursed ";
        document.getElementById("lblpaperSecurity").innerHTML = "Paper Security reimbursed";
        document.getElementById("lbltotalamountpayable").innerHTML = "Total Amount Payable";

        document.getElementById("Label1").innerHTML = "कटौती";
        document.getElementById("lblWithheld").innerHTML = "Withheld 2% regarding income Tax on Rs";
        document.getElementById("lblDeductionagainstpaper").innerHTML = "Deduction against paper security";
        document.getElementById("lblDepotExpenditure").innerHTML = "Depot Expenditure on behalf of printer";
        document.getElementById("lblInterestonPaper").innerHTML = "Interest on Paper ";
        document.getElementById("lblPenaltyforDelay").innerHTML = "Penalty for delay in supply of books";
        document.getElementById("lblDeductionOfPapercost").innerHTML = "Deduction of paper cost against short size of books";
        document.getElementById("lblTotalDeduction0").innerHTML = "Total Deductions";
        document.getElementById("lblNetPayableAB").innerHTML = "Net Payable Rs.";
        document.getElementById("lblSenctional").innerHTML = "दिनांक";
        document.getElementById("lblRemark").innerHTML = "रिमार्क ";
        document.getElementById("lblForwarededFor").innerHTML = "प्रतिक्रिया";
        document.getElementById("lblForwardTo").innerHTML = "अग्रेषित कर्मचारी";
        
        document.getElementById("btnNew").value = "नया";
        document.getElementById("btnEdit").value = "सुधारे";
        document.getElementById("btnshow").value = "देखे";
        document.getElementById("btns").value = "मुद्रक पंजी देखें";
        document.getElementById("btns1").value = "देखे";
        document.getElementById("btnForward").value = "भेजे";
        document.getElementById("btnCancel").value = "रद्द करे";   

        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";

        document.getElementById("lblProfitCenter").className = "Frm_Txt_Hindi";
        document.getElementById("lblPrinterName").className = "Frm_Txt_Hindi";
        document.getElementById("lblBookTitle").className = "Frm_Txt_Hindi";
        document.getElementById("lblBillNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblBillDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblTenderNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblGroupOfNo").className = "Frm_Txt_Hindi";

        document.getElementById("lbl_ApplicantInfo").className = "Frm_Txt_Hindi";
        document.getElementById("lblTotalPrintingCharge").className = "Frm_Txt_Hindi";
        document.getElementById("lblDeduct").className = "Frm_Txt_Hindi";
        document.getElementById("lblNetPrintingCharge").className = "Frm_Txt_Hindi";
        document.getElementById("lblPrintingSecurityReimbusted").className = "Frm_Txt_Hindi";
        document.getElementById("lblpaperSecurity").className = "Frm_Txt_Hindi";
        document.getElementById("lbltotalamountpayable").className = "Frm_Txt_Hindi";

        document.getElementById("Label1").className = "Frm_Txt_Hindi";
        document.getElementById("lblWithheld").className = "Frm_Txt_Hindi";
        document.getElementById("lblDeductionagainstpaper").className = "Frm_Txt_Hindi";
        document.getElementById("lblDepotExpenditure").className = "Frm_Txt_Hindi";
        document.getElementById("lblInterestonPaper").className = "Frm_Txt_Hindi";
        document.getElementById("lblPenaltyforDelay").className = "Frm_Txt_Hindi";
        document.getElementById("lblDeductionOfPapercost").className = "Frm_Txt_Hindi";
        document.getElementById("lblTotalDeduction0").className = "Frm_Txt_Hindi";
        document.getElementById("lblNetPayableAB").className = "Frm_Txt_Hindi";
        document.getElementById("lblSenctional").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemark").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwarededFor").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwardTo").className = "Frm_Txt_Hindi";
        if (document.getElementById("lblorderno") != null) {
            document.getElementById("lblorderno").className = "Frm_Txt_Hindi";
        }


        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("btnshow").className = "btn_Hindi";
        document.getElementById("btns").className = "btn_Hindi";
        document.getElementById("btns1").className = "btn_Hindi";
        document.getElementById("btnForward").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";


        var RBHindi = document.getElementById("rbChecque");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "चेक/डीडी";
        var RBHindi = document.getElementById("rbePay");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "ई-पेमेंट/हस्तांतरण";
      

    }
    //=====Form ID 291, Form Name:Reports/HR Reports/rpt_Post_information.aspx
    if (Choice == 0 && FormId == 291) {
        //document.getElementById("LblHeader").innerHTML = " P ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        // Branch Radio button code
        document.getElementById("LblHeader").innerHTML = "पदों की जानकारी का पत्रक";
        document.getElementById("lblDate").innerHTML = "दिनांक से ";
        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnPrint").value = "प्रिंट करे";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";
        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblDate").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";       
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";
    }

    //=====Form ID 257, Form Name:Reports/HR_Reports/frm_Particulars_Immovable_Assets.aspx
    if (Choice == 0 && FormId == 257) {
        //document.getElementById("LblHeader").innerHTML = " P ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        // Branch Radio button code
        document.getElementById("LblHeader").innerHTML = "अचल सम्पत्ति विवरण";
        document.getElementById("lblyear").innerHTML = "वर्ष ";
        document.getElementById("lblEmp").innerHTML = "कर्मचारी का नाम ";
        document.getElementById("lblDesignation").innerHTML = "पद नाम ";
        document.getElementById("lblPost").innerHTML = "पद ";
        document.getElementById("lblAppointmentdate").innerHTML = "नियुक्ति दिनांक ";
        document.getElementById("lblNextInc").innerHTML = "अगले बढौत्तरी की दिनांक";
        document.getElementById("lblBasicSalary").innerHTML = "मूल वेतन ";
        document.getElementById("lblAssetDetails").innerHTML = "असेट्स का विवरण ";
        document.getElementById("btnTemp").value = "अस्थायी रक्षित करें";
        document.getElementById("btnsaveprint").value = "स्थायी रक्षित करें";
        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblyear").className = "Frm_Txt_Hindi";
        document.getElementById("lblEmp").className = "Frm_Txt_Hindi";
        document.getElementById("lblDesignation").className = "Frm_Txt_Hindi";
        document.getElementById("lblPost").className = "Frm_Txt_Hindi";
        document.getElementById("lblAppointmentdate").className = "Frm_Txt_Hindi";
        document.getElementById("lblNextInc").className = "Frm_Txt_Hindi";
        document.getElementById("lblBasicSalary").className = "Frm_Txt_Hindi";
        document.getElementById("lblAssetDetails").className = "Frm_Txt_Hindi";
        document.getElementById("btnTemp").className = "btn_Hindi";
        document.getElementById("btnsaveprint").className = "btn_Hindi";
    }

    //=====Form ID 279, Form Name:Reports/HR_Reports/rpt_Security_Deposit_inward.aspx
    if (Choice == 0 && FormId == 279) {
//        document.getElementById("LblHeader").innerHTML = "";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        // Branch Radio button code
        document.getElementById("LblHeader").innerHTML = "सुरक्षा निधि (प्राप्ति) रजिस्टर";
        document.getElementById("lblFinDate").innerHTML = "वित्तीय वर्ष";
        document.getElementById("lblAgencyType").innerHTML = "एजेंसी का प्रकार ";
        document.getElementById("lblAgency").innerHTML = "एजेंसी का नाम ";
        document.getElementById("lblDataOption").innerHTML = "डाटा विकल्प";
        document.getElementById("lblNote").innerHTML = "चेक / डीडी रिपोर्ट दिनांक तक प्राप्त नही हुआ ";
        var all = document.getElementById("rbAll");
        var rball = all.parentNode.getElementsByTagName("label");
        rball[0].innerHTML = "सभी";
        rball[0].className = "Frm_Txt_Hindi";

        var rbPen= document.getElementById("rbPending");
        var rbPending = rbPen.parentNode.getElementsByTagName("label");
        rbPending[1].innerHTML = "शेष";
        rbPending[1].className = "Frm_Txt_Hindi";
       
        document.getElementById("lblReport").innerHTML = "रिपोर्ट विकल्प ";

        var Summary = document.getElementById("rbSummary");
        var rbSummary = Summary.parentNode.getElementsByTagName("label");
        rbSummary[0].innerHTML = "संक्षिप्त";
        rbSummary[0].className = "Frm_Txt_Hindi";

        var Detail = document.getElementById("rbDetail");
        var rbDetail = Detail.parentNode.getElementsByTagName("label");
        rbDetail[1].innerHTML = "विवरण";
        rbDetail[1].className = "Frm_Txt_Hindi";

        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("btnSaveAsExecel").value = "एक्सेल में रक्षित करे";
        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblFinDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblAgencyType").className = "Frm_Txt_Hindi";
        document.getElementById("lblAgency").className = "Frm_Txt_Hindi";
        document.getElementById("lblDataOption").className = "Frm_Txt_Hindi";
        document.getElementById("lblReport").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveAsExecel").className = "btn_Hindi";
        document.getElementById("lblNote").className = "Frm_Txt_Hindi";
    }
    

    //=====Form ID 208, Form Name:HR_Transaction/frm_Departmental_Transfer.aspx
    if (Choice == 0 && FormId == 2374) {
       
        document.getElementById("LblHeader").innerHTML = "कर्मचारी स्थानंतरण ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("lblpost").innerHTML = "पद ";
        document.getElementById("btnshow").value = "दिखाये ";
        document.getElementById("btnsave").value = "रक्षित करें";
        document.getElementById("btncancel").value = "रद्द करें ";

        document.getElementById("lblSearch").innerHTML = "खोजें";
        document.getElementById("lblEmpCode").innerHTML = "कर्मचारी कोड नबंर";
        document.getElementById("lblName").innerHTML = "कर्मचारी का नाम";
        // document.getElementById("lblScheemName").innerHTML = "स्कीम का नाम";
        document.getElementById("lbldetails").innerHTML = "विवरण ";        
        document.getElementById("lblOrderNo").innerHTML = "आदेश नबंर";
        document.getElementById("lbldate").innerHTML = "आदेश तिथि";
        document.getElementById("lblEffectdate").innerHTML = "प्रभावित तिथि";        
        document.getElementById("lblselect").innerHTML = "चुनें";
        document.getElementById("lblEmployeeCode").innerHTML = "कर्मचारी कोड नबंर";
        document.getElementById("lblEmployeeName").innerHTML = "कर्मचारी का नाम";
        document.getElementById("lblExisting").innerHTML = "वर्तमान";
        document.getElementById("lblNew").innerHTML = "नवीन";
        document.getElementById("lblOrderNo").innerHTML = "आदेश नबंर";
        document.getElementById("lbldate").innerHTML = "आदेश तिथि";

        document.getElementById("lblEffectdate").innerHTML = "प्रभावित  तिथि";
        document.getElementById("lblDesignation1").innerHTML = "पद";
      document.getElementById("lblGrade1").innerHTML = "शाखा ";
        document.getElementById("lblDesignation2").innerHTML = "पद";
        document.getElementById("lblGrade2").innerHTML = "शाखा";
 document.getElementById("btnTransfer").value = "जोडे ";
         
         
        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblSearch").className = "Frm_Txt_Hindi";
        document.getElementById("lblEmpCode").className = "Frm_Txt_Hindi";
        document.getElementById("lblName").className = "Frm_Txt_Hindi";
        document.getElementById("lblpost").className = "Frm_Txt_Hindi";
        document.getElementById("lbldetails").className = "Frm_Txt_Hindi";
       
        document.getElementById("lblOrderNo").className = "Frm_Txt_Hindi";
        document.getElementById("lbldate").className = "Frm_Txt_Hindi";
        document.getElementById("lblEffectdate").className = "Frm_Txt_Hindi";
        document.getElementById("lblselect").className = "Frm_Txt_Hindi";
        document.getElementById("lblEmployeeCode").className = "Frm_Txt_Hindi";
        document.getElementById("lblEmployeeName").className = "Frm_Txt_Hindi";
        document.getElementById("lblExisting").className = "Frm_Txt_Hindi";
        document.getElementById("lblNew").className = "Frm_Txt_Hindi";
        
       
        document.getElementById("lblDesignation1").className = "Frm_Txt_Hindi";
        document.getElementById("lblGrade1").className = "Frm_Txt_Hindi";
       
        document.getElementById("lblDesignation2").className = "Frm_Txt_Hindi";
        document.getElementById("lblGrade2").className = "Frm_Txt_Hindi";

        document.getElementById("btnTransfer").className = "btn_Hindi";

        document.getElementById("btncancel").className = "btn_Hindi";

        document.getElementById("btnsave").className = "btn_Hindi";
        document.getElementById("btnshow").className = "btn_Hindi";
       
        //Grid Code Start
        var table = document.getElementById("GvSelectedEmployee");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "कर्मचारी कोड नबंर  ";
        tr.cells[1].innerHTML = "कर्मचारी का नाम";
        tr.cells[2].innerHTML = "वर्तमान पद";
        tr.cells[3].innerHTML = "वर्तमान ग्रेड";
        tr.cells[4].innerHTML = "वर्तमान वेतन";
        tr.cells[5].innerHTML = "नवीन पद";
        tr.cells[6].innerHTML = "नवीन ग्रेड";
        tr.cells[7].innerHTML = "नवीन वेतन";
        tr.cells[8].innerHTML = "आदेश नबंर";
        tr.cells[9].innerHTML = "आदेश तिथि";
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
    //Form Name:HR_Transaction/frm_Annual_Increment.aspx
    
    if (Choice == 0 && FormId == 2360) {
      
        document.getElementById("LblHeader").innerHTML = " वार्षिक वृद्धि ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        // Branch Radio button code
        document.getElementById("btnNew").value = "नया ";
        document.getElementById("btnEdit").value = "सुधारे ";
        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnForward").value = "भेजें";
        document.getElementById("btnCancel").value = "रद्द करें";
        if (document.getElementById("lblArrearRefNo1") != null) {
            document.getElementById("lblArrearRefNo1").innerHTML = "रिफरेंस नं.";
            document.getElementById("lblArrearRefNo1").className = "Frm_Txt_Hindi";
        }
        document.getElementById("lblYear").innerHTML = "वर्ष ";
        document.getElementById("lblPost").innerHTML = "पद नाम ";
//        document.getElementById("lbleffectivedate").innerHTML = "प्रभावित तिथि ";
        document.getElementById("lbl_ApplicantInfo").innerHTML = "कर्मचारी का विवरण :";
        document.getElementById("lblSenctional").innerHTML = "प्रतिक्रिया दिनांक";
        document.getElementById("lblRemark").innerHTML = "रिमार्क";
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
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnForward").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("lblYear").className = "Frm_Txt_Hindi";
        document.getElementById("lblPost").className = "Frm_Txt_Hindi";
        document.getElementById("lbl_ApplicantInfo").className = "Frm_Txt_Hindi";      
        document.getElementById("lblSenctional").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemark").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwarededFor").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwardTo").className = "Frm_Txt_Hindi";
        document.getElementById("lblPaymentMode").className = "Frm_Txt_Hindi";
        document.getElementById("LblSelectBank").className = "Frm_Txt_Hindi";
        document.getElementById("lblCheque").className = "Frm_Txt_Hindi";
        document.getElementById("lbleffectivedate").className = "Frm_Txt_Hindi";
        
    }
    //Form Name:HR_Transaction/frm_Annual_Increment.aspx
    if (Choice == 0 && FormId == 292) {
        document.getElementById("LblHeader").innerHTML = "वार्षिक वृद्धि सूची";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        // Branch Radio button code

        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("btnSaveAsExecel").value = "एक्सेल में रक्षित करें";
        document.getElementById("lblYear").innerHTML = "वर्ष";
        document.getElementById("lblReferenceNo").innerHTML = "वार्षिक वृद्धि रिफरेंस नं.";
        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnForward").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("lblYear").className = "Frm_Txt_Hindi";
        document.getElementById("lblReferenceNo").className = "Frm_Txt_Hindi";
    }

    // HR_Transaction / frm_pay_Fixation.aspx
    if (Choice == 0 && FormId == 2362) {

        document.getElementById("LblHeader").innerHTML = "वेतन निर्धारण";
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
        if (document.getElementById("lblPayFixationRefNo") != null) {
            document.getElementById("lblPayFixationRefNo").innerHTML = "वेतन निर्धारण रिफरेंस न."
            document.getElementById("lblPayFixationRefNo").className = "Frm_Txt_Hindi";

        }

        document.getElementById("lblDate").innerHTML = "दिनांक";
        document.getElementById("lblPost").innerHTML = "पद का नाम  ";
        document.getElementById("lblEmployeeName").innerHTML = "कर्मचारी  का नाम ";
        document.getElementById("lblPayBand").innerHTML = "पे-बैंड";
        document.getElementById("lblNewPayBand").innerHTML = "नया पे-बैंड";
        document.getElementById("lblOldVetanmaan").innerHTML = "पूर्व वेतन-मान ";
        document.getElementById("lblNewVetanmaan").innerHTML = "नया वेतन-मान ";
        //        document.getElementById("lblEmoluments").innerHTML = "कुल परिलब्धिया ";
        document.getElementById("lblSenctional").innerHTML = "प्रतिक्रिया दिनांक";
        document.getElementById("lblRemark").innerHTML = "रिमार्क ";
        document.getElementById("lblForwarededFor").innerHTML = "प्रतिक्रिया";
        document.getElementById("lblForwardTo").innerHTML = "अग्रेषित कर्मचारी";
        document.getElementById("lblPaymentMode").innerHTML = "भुगतान का तरीका";
        document.getElementById("lbleffectivedate").innerHTML = "प्रभावित तिथि ";
        var RBcheque = document.getElementById("rbChecque");
        var RB = RBcheque.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "चैक/ डी डी";

        var RBepay = document.getElementById("rbePay");
        var RBe = RBepay.parentNode.getElementsByTagName("label");
        RBe[0].innerHTML = "ई पेमेंट";

        document.getElementById("LblSelectBank").innerHTML = "बैंक का नाम";
        document.getElementById("lblCheque").innerHTML = "चैक/ डी डी नं.";
        document.getElementById("btnSave").value = "रक्षित करें ";
        document.getElementById("lbl_ApplicantInfo").innerHTML = "आवेदन की जानकारी";
        //        document.getElementById("btnCount").value = "रद्द करें ";
        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("lblPayFixationRefNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblPost").className = "Frm_Txt_Hindi ";
        document.getElementById("lblEmployeeName").className = "Frm_Txt_Hindi";
        document.getElementById("lblPayBand").className = "Frm_Txt_Hindi";
        document.getElementById("lblNewPayBand").className = "Frm_Txt_Hindi";
        document.getElementById("lbleffectivedate").className = "Frm_Txt_Hindi";

        document.getElementById("lblOldVetanmaan").className = "Frm_Txt_Hindi";
        document.getElementById("lblNewVetanmaan").className = "Frm_Txt_Hindi";
        //        document.getElementById("lblEmoluments").className = "Frm_Txt_Hindi";
        document.getElementById("lblSenctional").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemark").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwarededFor").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwardTo").className = "Frm_Txt_Hindi";
        document.getElementById("lblPaymentMode").className = "Frm_Txt_Hindi";
        document.getElementById("LblSelectBank").className = "Frm_Txt_Hindi";
        document.getElementById("lblCheque").className = "Frm_Txt_Hindi";
        document.getElementById("btnsave").className = "btn_Hindi";
        document.getElementById("lbl_ApplicantInfo").className = "Frm_Txt_Hindi";
    }

    //HR_Transaction / frm_Leave_Encashment.aspx
    if (Choice == 0 && FormId == 2364) {

        document.getElementById("LblHeader").innerHTML = "अवकाश नगदीकरण";
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
        if (document.getElementById("lblLeaveEncashmentRefNo") != null) {
            document.getElementById("lblLeaveEncashmentRefNo").innerHTML = "अवकाश नगदीकरण रिफरेंस न. ";
            document.getElementById("lblLeaveEncashmentRefNo").className = "Frm_Txt_Hindi";
        }
        document.getElementById("lbl_ApplicantInfo").innerHTML = "आवेदन की जानकारी";
        document.getElementById("lblBalanceEl").innerHTML = "शेष अर्जित अवकाश ";
        document.getElementById("lblEncashmentamt").innerHTML = "नगदीकरण राशि ";
        document.getElementById("lblDate").innerHTML = "दिनांक";
        document.getElementById("lblPost").innerHTML = "पद का नाम  ";
        document.getElementById("lblEmployeeName").innerHTML = "कर्मचारी का नाम ";
        document.getElementById("lblAppointmentDt").innerHTML = "नियुक्ति दिनांक";
        document.getElementById("lblPayBand").innerHTML = "पे-बैंड";
        document.getElementById("lblRetirementDate").innerHTML = "मृत्यु / सेवानिवृत्ति दिनांक ";
        document.getElementById("lblSalary").innerHTML = "मूल वेतन";
        document.getElementById("lblGradePay").innerHTML = "वेतन-मान";
        document.getElementById("lblDA").innerHTML = "डी.ए.";
        document.getElementById("lblEmoluments").innerHTML = "कुल परिलब्धियाँ  ";
       // document.getElementById("btnCount").value = "गणना";
        document.getElementById("lblSenctional").innerHTML = "प्रतिक्रिया दिनांक";
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
        //        document.getElementById("lblLeaveEncashmentRefNo")
        document.getElementById("lblDate").className = "Frm_Txt_Hindi";
        document.getElementById("lbl_ApplicantInfo").className = "Frm_Txt_Hindi";
        document.getElementById("lblBalanceEl").className = "Frm_Txt_Hindi";
        document.getElementById("lblEncashmentamt").className = "Frm_Txt_Hindi";
        document.getElementById("lblPost").className = "Frm_Txt_Hindi";
        document.getElementById("lblEmployeeName").className = "Frm_Txt_Hindi";
        document.getElementById("lblAppointmentDt").className = "Frm_Txt_Hindi";
        document.getElementById("lblPayBand").className = "Frm_Txt_Hindi";
        document.getElementById("lblRetirementDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblSalary").className = "Frm_Txt_Hindi";
        document.getElementById("lblGradePay").className = "Frm_Txt_Hindi";
        document.getElementById("lblDA").className = "Frm_Txt_Hindi";
        document.getElementById("lblEmoluments").className = "Frm_Txt_Hindi";
        //document.getElementById("btnCount").className = "btn_Hindi";
        document.getElementById("lblSenctional").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemark").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwarededFor").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwardTo").className = "Frm_Txt_Hindi";

    }
    //HR_Transaction / frm_Arrear_Fixation.aspx
    if (Choice == 0 && FormId == 2363) {

        document.getElementById("LblHeader").innerHTML = "एरियर निर्धारण";
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
        if (document.getElementById("lblArrearRefNo1") != null) {
            document.getElementById("lblArrearRefNo1").innerHTML = "एरियर निर्धारण रिफरेंस न. ";
            document.getElementById("lblArrearRefNo1").className = "Frm_Txt_Hindi";
        }

        //        document.getElementById("lblApplicationDate").innerHTML = "दिनांक";
        document.getElementById("lblPost").innerHTML = "पद का नाम  ";
        document.getElementById("lblEmployeeName").innerHTML = "कर्मचारी  का नाम ";
        document.getElementById("lbl_ApplicantInfo").innerHTML = "टाइम स्केल विवरण :";
        document.getElementById("lblMonth").innerHTML = "माह";
        document.getElementById("lblYear").innerHTML = "वर्ष ";
        document.getElementById("lblPayCurrent").innerHTML = "बेसिक";
        document.getElementById("lblGradePayCurrent").innerHTML = "ग्रेड पे";
        document.getElementById("lblDACurrent").innerHTML = "डी.ए.";
        document.getElementById("Label1").innerHTML = "ड्रान(छठवाँ पे स्केल ) विवरण :";
        document.getElementById("lblSixPay").innerHTML = "बेसिक";
        document.getElementById("lblSixGradepay").innerHTML = "ग्रेड पे";
        document.getElementById("lblSixDA").innerHTML = "डी.ए.";
        document.getElementById("btnAdd").value = "जोडें";
        document.getElementById("lblSenctional").innerHTML = "प्रतिक्रिया दिनांक";
        document.getElementById("lblRemark").innerHTML = "रिमार्क ";
        document.getElementById("lblForwarededFor").innerHTML = "प्रतिक्रिया";
        document.getElementById("lblForwardTo").innerHTML = "अग्रेषित कर्मचारी";
        document.getElementById("btnForward").value = "भेजें";
        document.getElementById("btnCancel").value = "रद्द करें";

        document.getElementById("lblPaymentMode").innerHTML = "भुगतान का तरीका";
        var RBcheque = document.getElementById("rbChecque");
        var RB = RBcheque.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "चैक/ डी डी";

        var RBepay = document.getElementById("rbePay");
        var RBe = RBepay.parentNode.getElementsByTagName("label");
        RBe[0].innerHTML = "ई पेमेंट";

        var RAdjust = document.getElementById("rbAdjustment");
        var RBA = RAdjust.parentNode.getElementsByTagName("label");
        RBA[0].innerHTML = "समायोजन द्वारा";

        document.getElementById("LblSelectBank").innerHTML = "बैंक का नाम";
        document.getElementById("lblCheque").innerHTML = "चैक/ डी डी नं.";
        //        document.getElementById("btnSave").value = "रक्षित करें ";
        //        document.getElementById("btnCount").value = "रद्द करें ";
        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("lblPost").className = "Frm_Txt_Hindi ";
        document.getElementById("lblEmployeeName").className = "Frm_Txt_Hindi";
        document.getElementById("lbl_ApplicantInfo").className = "Frm_Txt_Hindi";
        document.getElementById("lblMonth").className = "Frm_Txt_Hindi ";
        document.getElementById("lblYear").className = "Frm_Txt_Hindi";
        document.getElementById("lblPayCurrent").className = "Frm_Txt_Hindi";
        document.getElementById("lblGradePayCurrent").className = "Frm_Txt_Hindi";
        document.getElementById("lblDACurrent").className = "Frm_Txt_Hindi";
        document.getElementById("Label1").className = "Frm_Txt_Hindi";
        document.getElementById("lblSixPay").className = "Frm_Txt_Hindi";
        document.getElementById("lblSixGradepay").className = "Frm_Txt_Hindi";
        document.getElementById("lblSixDA").className = "Frm_Txt_Hindi";
        document.getElementById("btnAdd").className = "btn_Hindi";
        document.getElementById("lblSenctional").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemark").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwarededFor").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwardTo").className = "Frm_Txt_Hindi";
        document.getElementById("btnForward").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";

    }

    //Form ID 183, Form Name:frm_leave_approval.aspx
    if (Choice == 0 && FormId == 248) {
        document.getElementById("LblHeader").innerHTML = "अवकाश मंजूरी ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        // Label code//
        document.getElementById("lblLeaveRequest").innerHTML = "अवकाश आवेदन क्र.";
        document.getElementById("LblDtApplying").innerHTML = "आवेदन दिनांक";
        document.getElementById("LblEmployeeName").innerHTML = "कर्मचारी का नाम ";
        document.getElementById("LblDepartment").innerHTML = "विभाग का नाम";
        document.getElementById("LblDivision").innerHTML = "शाखा का नाम";
        document.getElementById("lbl_ApplicantInfo").innerHTML = "आवेदन का विवरण";
        document.getElementById("LblTypeofLeave").innerHTML = "अवकाश का प्रकार ";
        document.getElementById("LblFromDt").innerHTML = "दिनांक से"
        document.getElementById("lblTodate").innerHTML = "दिनांक तक";
        document.getElementById("LblDaysNo").innerHTML = "कुल दिन ";
        document.getElementById("LblBalanceDays").innerHTML = "शेष दिन ";
        document.getElementById("LblLeaveReason").innerHTML = "अवकाश का कारण ";
        document.getElementById("lnk_LeaveRecord").innerHTML = "रिकार्ड देखे";
        document.getElementById("lnkViewOrder").innerHTML = "अवकाश दस्तावेज देखे";
        document.getElementById("lbl_Sanctional").innerHTML = "स्वीकृत विवरण ";
        document.getElementById("LblDtSanction").innerHTML = "स्वीकृत दिनांक";
        document.getElementById("lblFromdateHR").innerHTML = "दिनांक से";
        document.getElementById("lblTodateHR").innerHTML = "दिनांक तक "
        document.getElementById("lblSanctionedLeave").innerHTML = "स्वीकृत अवकाश ";
        document.getElementById("lblPost").innerHTML = "पद का नाम ";
        document.getElementById("lblEmployee_Name").innerHTML = "कर्मचारी का नाम ";
        document.getElementById("lblSenctional").innerHTML = "दिनांक ";
        document.getElementById("lblRemark").innerHTML = "रिमार्क ";
        document.getElementById("lblForwarededFor").innerHTML = "प्रतिक्रिया ";
        document.getElementById("lblForwardTo").innerHTML = "अग्रेषित कर्मचारी"
        document.getElementById("BtnSave").value = "स्वीकृत करे"
        //document.getElementById("BtnReject").value = "अस्वीकृत करे"
        document.getElementById("BtnCancel").value = "रद्ध करे"
        document.getElementById("BtnExit").value = "बाहर निकलें"
        //============Hindi Text================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblDivisionDetail").className = "Frm_Txt_Hindi";
        document.getElementById("lblLeaveRequest").className = "Frm_Txt_Hindi";
        document.getElementById("LblDtApplying").className = "Frm_Txt_Hindi";
        document.getElementById("LblEmployeeName").className = "Frm_Txt_Hindi";
        document.getElementById("LblDepartment").className = "Frm_Txt_Hindi";
        document.getElementById("LblDivision").className = "Frm_Txt_Hindi";
        document.getElementById("lbl_ApplicantInfo").className = "Frm_Txt_Hindi";
        document.getElementById("LblTypeofLeave").className = "Frm_Txt_Hindi";
        document.getElementById("LblFromDt").className = "Frm_Txt_Hindi"
        document.getElementById("lblTodate").className = "Frm_Txt_Hindi";
        document.getElementById("LblDaysNo").className = "Frm_Txt_Hindi";
        document.getElementById("LblBalanceDays").className = "Frm_Txt_Hindi";
        document.getElementById("LblLeaveReason").className = "Frm_Txt_Hindi";
        document.getElementById("lnk_LeaveRecord").className = "Frm_Txt_Hindi";
        document.getElementById("lnkViewOrder").className = "Frm_Txt_Hindi";
        document.getElementById("lbl_Sanctional").className = "Frm_Txt_Hindi";
        document.getElementById("LblDtSanction").className = "Frm_Txt_Hindi";
        document.getElementById("lblFromdateHR").className = "Frm_Txt_Hindi";
        document.getElementById("lblTodateHR").className = "Frm_Txt_Hindi"
        document.getElementById("lblSanctionedLeave").className = "Frm_Txt_Hindi";
        document.getElementById("lblPost").className = "Frm_Txt_Hindi";
        document.getElementById("lblEmployee_Name").className = "Frm_Txt_Hindi";
        document.getElementById("lblSenctional").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemark").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwarededFor").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwardTo").className = "Frm_Txt_Hindi"
        document.getElementById("BtnSave").className = "btn_Hindi"
        //document.getElementById("BtnReject").className = "btn_Hindi"
        document.getElementById("BtnCancel").className = "btn_Hindi"
        document.getElementById("BtnExit").className = "btn_Hindi"
    }

    //TBC_Transaction / frm_Gratuity.aspx
    if (Choice == 0 && FormId == 2366) {

        document.getElementById("LblHeader").innerHTML = "ग्रेच्यूटी";
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
        if (document.getElementById("lblGraduatyFixRefNo") != null) {
            document.getElementById("lblGraduatyFixRefNo").innerHTML = "ग्रेच्यूटी निर्धारण रिफरेंस न. ";
            document.getElementById("lblGraduatyFixRefNo").className = "Frm_Txt_Hindi";
        }
        document.getElementById("lbl_ApplicantInfo").innerHTML = "आवेदन की जानकारी";
        document.getElementById("lblDate").innerHTML = "दस्तावेज दिनांक";
        document.getElementById("lblPost").innerHTML = "पद का नाम  ";
        document.getElementById("lblEmployeeName").innerHTML = "कर्मचारी का नाम ";
        document.getElementById("lblAppointmentDt").innerHTML = "नियुक्ति दिनांक";
        document.getElementById("lblPayBand").innerHTML = "पे-बैंड";
        document.getElementById("lblRetirementDate").innerHTML = "मृत्यु / सेवानिवृत्ति दिनांक ";
        document.getElementById("lblSalary").innerHTML = "मूल वेतन";
        document.getElementById("lblGradePay").innerHTML = "वेतन-मान";
        document.getElementById("lblDA").innerHTML = "डी.ए.";
        document.getElementById("lblEmoluments").innerHTML = "कुल परिलब्धिया ";
        document.getElementById("lblcompletedyear").innerHTML = "सेवा के 6 माही खण्डों  की संख्या ";
        document.getElementById("lblCalculateAmt").innerHTML = "ग्रेच्यूटी राशि ";
       // document.getElementById("btnCount").value = "गणना";
        document.getElementById("lblSenctional").innerHTML = "प्रतिक्रिया दिनांक";
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
        document.getElementById("btnSave").value = "रक्षित करें ";

        //        document.getElementById("btnSave").value = "रक्षित करें ";
        //        document.getElementById("btnCount").value = "रद्द करें ";
        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("lbl_ApplicantInfo").className = "Frm_Txt_Hindi";
        document.getElementById("lblDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblPost").className = "Frm_Txt_Hindi";
        document.getElementById("lblEmployeeName").className = "Frm_Txt_Hindi";
        document.getElementById("lblCalculateAmt").className = "Frm_Txt_Hindi";
        document.getElementById("lblAppointmentDt").className = "Frm_Txt_Hindi";
        document.getElementById("lblPayBand").className = "Frm_Txt_Hindi";
        document.getElementById("lblRetirementDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblSalary").className = "Frm_Txt_Hindi";
        document.getElementById("lblGradePay").className = "Frm_Txt_Hindi";
        document.getElementById("lblDA").className = "Frm_Txt_Hindi";
        document.getElementById("lblEmoluments").className = "Frm_Txt_Hindi";
        //document.getElementById("btnCount").className = "btn_Hindi";
        document.getElementById("lblSenctional").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemark").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwarededFor").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwardTo").className = "Frm_Txt_Hindi";
        document.getElementById("lblPaymentMode").className = "Frm_Txt_Hindi";
        document.getElementById("btnForward").className = "btn_Hindi";
        document.getElementById("LblSelectBank").className = "Frm_Txt_Hindi";
        document.getElementById("lblCheque").className = "Frm_Txt_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("lblcompletedyear").className = "Frm_Txt_Hindi";

    }
    if (Choice == 0 && FormId == 2379) {

        document.getElementById("LblHeader").innerHTML = "विविध अग्रिम ";
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
        document.getElementById("Btnsh").value = "बेलेंस देखें";
        document.getElementById("lblDate").innerHTML = "आवेदन दिनांक ";
        document.getElementById("lblAgencyType").innerHTML = "एजेंसी का प्रकार";
        document.getElementById("lblSupplierProvider").innerHTML = "एजेंसी का नाम";
        document.getElementById("lblPurpose").innerHTML = "अग्रिम का कारण";
        document.getElementById("lblAdvanceAmt").innerHTML = "अग्रिम राशि";
        document.getElementById("lblSenctional").innerHTML = "प्रतिक्रिया दिनांक";
        document.getElementById("lblRemark").innerHTML = "रिमार्क ";
        document.getElementById("lblForwarededFor").innerHTML = "प्रतिक्रिया";
        document.getElementById("lblForwardTo").innerHTML = "अग्रेषित कर्मचारी";
        document.getElementById("lblPaymentMode").innerHTML = "भुगतान का तरीका";
       
        var RBCash = document.getElementById("rbCash");
        var RB = RBCash.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "रोकड़";

        var RBcheque = document.getElementById("rbChecque");
        var RB = RBcheque.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "चैक/ डी डी";

        var RBepay = document.getElementById("rbePay");
        var RBe = RBepay.parentNode.getElementsByTagName("label");
        RBe[0].innerHTML = "ई पेमेंट";

        document.getElementById("LblSelectBank").innerHTML = "बैंक का नाम";
        document.getElementById("lblCheque").innerHTML = "चैक/ डी डी नं.";

        document.getElementById("lblAdvanceRefNo").innerHTML = " विविध अग्रिम रिफरेंस न.";



        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";      
        document.getElementById("Btnsh").className = "btn_Hindi";
        document.getElementById("lblDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblAgencyType").className = "Frm_Txt_Hindi";
        document.getElementById("lblSupplierProvider").className = "Frm_Txt_Hindi";
        document.getElementById("lblPurpose").className = "Frm_Txt_Hindi";
        document.getElementById("lblAdvanceAmt").className = "Frm_Txt_Hindi";          
        document.getElementById("lblSenctional").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemark").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwarededFor").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwardTo").className = "Frm_Txt_Hindi";
        document.getElementById("lblPaymentMode").className = "Frm_Txt_Hindi";
        document.getElementById("lblAdvanceRefNo").className = "Frm_Txt_Hindi";

    }
    
    //=====Form ID 2382, Form Name:HRTransaction/Frm_MedicalAdvanceApplicationForm.aspx
    if (Choice == 0 && FormId == 2382) {
        document.getElementById("LblHeader").innerHTML = "चिकित्सा अग्रिम आवेदन पत्र ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";

        document.getElementById("lblADate").innerHTML = "आवेदन दिनांक";
        document.getElementById("lblApplicantName").innerHTML = "आवेदन कर्ता का नाम";
        document.getElementById("lblDesignation").innerHTML = "पद का नाम";
        document.getElementById("lblJoiningPost").innerHTML = "पद स्थान";
        document.getElementById("lblBasicSalary").innerHTML = "सेवा का प्रकार";
        var RBPermanent = document.getElementById("rbPermanent");
        var RB = RBPermanent.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "स्थायी";

        var RBTemp = document.getElementById("rbTemp");
        var RB = RBTemp.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "अस्थायी";
        document.getElementById("lblTotalSalary").innerHTML = "मूल वेतन";
        document.getElementById("lblDemandedAmount").innerHTML = "मांगी हुई अग्रिम राशि";
        document.getElementById("lbltypeofIllness").innerHTML = "बीमारी का प्रकार";
        document.getElementById("lblForwardTo").innerHTML = "अग्रेषित कर्मचारी";
        document.getElementById("lblUploadletter").innerHTML = "अपलोड दस्तावेज फाईल";
        document.getElementById("lblNote").innerHTML = "नोट :-";
        document.getElementById("lblnoteDetail").innerHTML = "फाईल का प्रकार JPG,JPEG,PNG,GIF,PDF मेँ हो और इसकी साईज़ 512 KB से ज्यादा ना हो । ";
        document.getElementById("btnForward").value = "रक्षित करे";
        document.getElementById("btnCancel").value = "रद्द करे";

        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblADate").className = "Frm_Txt_Hindi";
        document.getElementById("lblApplicantName").className = "Frm_Txt_Hindi";
        document.getElementById("lblDesignation").className = "Frm_Txt_Hindi";
        document.getElementById("lblJoiningPost").className = "Frm_Txt_Hindi";
        document.getElementById("lblBasicSalary").className = "Frm_Txt_Hindi";
        document.getElementById("rbPermanent").className = "Frm_Txt_Hindi";
        document.getElementById("rbTemp").className = "Frm_Txt_Hindi";
        document.getElementById("lblTotalSalary").className = "Frm_Txt_Hindi";
        document.getElementById("lblDemandedAmount").className = "Frm_Txt_Hindi";
        document.getElementById("lbltypeofIllness").className = "Frm_Txt_Hindi";
        document.getElementById("lblUploadletter").className = "Frm_Txt_Hindi";
        document.getElementById("lblNote").className = "Frm_Txt_Hindi";
        document.getElementById("lblnoteDetail").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwardTo").className = "Frm_Txt_Hindi";
        document.getElementById("btnForward").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        
        
    }

    //=====Form ID 2383, Form Name:HR_Transaction/frm_Medical_Advance_Recommandation.aspx
    if (Choice == 0 && FormId == 2383) {
        document.getElementById("LblHeader").innerHTML = "चिकित्सा अग्रिम अनुशंसा";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";

        document.getElementById("lblMedicalAdvanceRequestNo").innerHTML = "चिकित्सा अग्रिम निवेदन क्रमांक";
        document.getElementById("lbl_ApplicantInfo").innerHTML = "आवेदन की जानकारी";
        document.getElementById("lblApplicantName").innerHTML = "आवेदन कर्ता का नाम";
        document.getElementById("lblDesignation").innerHTML = "पद का नाम";
        document.getElementById("lblJoiningPost").innerHTML = "पद स्थान";
        document.getElementById("lblBasicSalary").innerHTML = "सेवा का प्रकार";
        var RBPermanent = document.getElementById("rbPermanent");
        var RB = RBPermanent.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "स्थायी";

        var RBTemp = document.getElementById("rbTemp");
        var RB = RBTemp.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "अस्थायी";
        document.getElementById("lblTotalSalary").innerHTML = "मूल वेतन";
        document.getElementById("lblDemandedAmount").innerHTML = " मांगी हुई अग्रिम राशि";
        document.getElementById("lblTypeOfIllness").innerHTML = "बीमारी का प्रकार";
        document.getElementById("lnkViewOrder").innerHTML = "दस्तावेज फाईल देखेँ ";
        document.getElementById("lbl_ROfficer").innerHTML = "अधिकारी के द्वारा अनुशंसा";
        if (document.getElementById("lblEmployeeName") != null) {
            document.getElementById("lblEmployeeName").innerHTML = "आवेदन कर्ता का नाम";
            document.getElementById("lblSenctionAmount").innerHTML = "राशि";
        }
        document.getElementById("lblSenctional").innerHTML = "प्रतिक्रिया दिनांक";
        document.getElementById("lblRemark").innerHTML = "विवरण";
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
        
        document.getElementById("btnForward").value = "भेजें";
        document.getElementById("btnCancel").value = "रद्द करे";

        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblTravelAllowanceReqNo").className = "Frm_Txt_Hindi";
        document.getElementById("lbl_ApplicantInfo").className = "Frm_Txt_Hindi";
        document.getElementById("lblApplicantName").className = "Frm_Txt_Hindi";
        document.getElementById("lblDesignation").className = "Frm_Txt_Hindi";
        document.getElementById("lblJoiningPost").className = "Frm_Txt_Hindi";
        document.getElementById("rbPermanent").className = "Frm_Txt_Hindi";
        document.getElementById("rbTemp").className = "Frm_Txt_Hindi";
        document.getElementById("lblTotalSalary").className = "Frm_Txt_Hindi";
        document.getElementById("lblDemandedAmount").className = "Frm_Txt_Hindi";
        
        document.getElementById("lnkViewOrder").className = "Frm_Txt_Hindi";
        document.getElementById("lbl_ROfficer").className = "Frm_Txt_Hindi";
        if (document.getElementById("lblEmployeeName") != null) {
            document.getElementById("lblEmployeeName").className = "Frm_Txt_Hindi";
            document.getElementById("lblRemainamount").className = "Frm_Txt_Hindi";
            document.getElementById("lblSenctionalAmount").className = "Frm_Txt_Hindi";
            document.getElementById("btns").className = "btn_Hindi";
        }
        document.getElementById("lblSenctional").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemark").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwarededFor").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwardTo").className = "Frm_Txt_Hindi";
        document.getElementById("btnForward").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";


    }

    //=====Form ID 2384, Form Name:HRTransaction/frm_Paybill_Deduction_Challan.aspx
    if (Choice == 0 && FormId == 2384) {
        document.getElementById("LblHeader").innerHTML = "पे बिल कटौती चालान ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";

        document.getElementById("lblChallanType").innerHTML = "चालान का प्रकार";
        document.getElementById("lblMonth").innerHTML = "माह";
        document.getElementById("lblYear").innerHTML = "वर्ष";
        document.getElementById("lblPayBill").innerHTML = "पे बिल  नं.";
        document.getElementById("lblDateDeposit").innerHTML = "डिपोज़िट दिनांक";
        document.getElementById("lblBank").innerHTML = "बैंक का नाम";
        document.getElementById("lblCheque").innerHTML = "चैक नं.";     
        document.getElementById("btnFill").value = "भरें";   
        document.getElementById("btnGenerate").value = "बनायें एवं प्रिंट करें";
        //document.getElementById("btnCancel").value = "रद्द करे";

        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        
        document.getElementById("lblChallanType").className = "Frm_Txt_Hindi";
        document.getElementById("lblMonth").className = "Frm_Txt_Hindi";
        document.getElementById("lblYear").className = "Frm_Txt_Hindi";
        document.getElementById("lblPayBill").className = "Frm_Txt_Hindi";
        document.getElementById("lblDateDeposit").className = "Frm_Txt_Hindi";
        document.getElementById("lblBank").className = "Frm_Txt_Hindi";
        document.getElementById("lblCheque").className = "Frm_Txt_Hindi";
        document.getElementById("btnFill").className = "btn_Hindi";
        document.getElementById("btnGenerate").className = "btn_Hindi";
        //document.getElementById("btnCancel").className = "btn_Hindi";


    }
    //=====Form ID 2387, Form Name:HRTransaction/frm_Cancel_Paybill_Deduction_Challan.aspx
    if (Choice == 0 && FormId == 2387) {
        document.getElementById("LblHeader").innerHTML = "पे बिल कटौती चालान रद्द";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";

        document.getElementById("lblChallanType").innerHTML = "चालान का प्रकार";
        document.getElementById("lblMonth").innerHTML = "माह";
        document.getElementById("lblYear").innerHTML = "वर्ष";
        document.getElementById("lblChallanNo").innerHTML = "चालान  नं."
        document.getElementById("lblRemark").innerHTML = "विवरण"
        document.getElementById("btnFill").value = "भरें";
        document.getElementById("btnCancelChallan").value = "चालान रद्द करें";
        //document.getElementById("btnCancel").value = "रद्द करे";

        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";

        document.getElementById("lblChallanType").className = "Frm_Txt_Hindi";
        document.getElementById("lblMonth").className = "Frm_Txt_Hindi";
        document.getElementById("lblYear").className = "Frm_Txt_Hindi";
        document.getElementById("lblChallanNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemark").className = "Frm_Txt_Hindi";
        document.getElementById("btnFill").className = "btn_Hindi";
        document.getElementById("btnCancelChallan").className = "btn_Hindi";


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
