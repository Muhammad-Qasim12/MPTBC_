//=============== here 1: English,0: Hindi =================//
var GlobalLanguage;
function ChangeLabel(Choice, FormId, QueryString) {
    GlobalLanguage = Choice;
    //=============== MMS Hindi Label Managed Code Start ================//

    //Form ID 2100, Form Name:MaterialManagement/Master/frm_ItemGroup_Master.aspx
    if (Choice == 0 && FormId == 2100) {
        document.getElementById("LblHeader").innerHTML = "आइटम ग्रुप मास्टर";
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
        document.getElementById("lblItemGroupName").innerHTML = "आइटम ग्रुप का नाम";
        document.getElementById("lblItemGroupHindi").innerHTML = "आइटम ग्रुप का नाम (हिन्दी) ";
        document.getElementById("lblCode").innerHTML = "कोड नंबर";
        document.getElementById("lblStandardColumn").innerHTML = "आइटम ग्रुप काँलम्स";
        document.getElementById("ChkAll").nextSibling.innerHTML = " सभी चुनें";
        //==========Increase Font========================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("lblItemGroupName").className = "Frm_Txt_Hindi";
        document.getElementById("lblItemGroupHindi").className = "Frm_Txt_Hindi";
        document.getElementById("lblCode").className = "Frm_Txt_Hindi";
        document.getElementById("lblStandardColumn").className = "Frm_Txt_Hindi";
        document.getElementById("ChkAll").nextSibling.className = "Frm_Txt_Hindi";

        // Grid Code Start
        var table = document.getElementById("gvItemGroupMaster");
        var tr = table.rows[0];
        tr.cells[2].innerHTML = "चुनिये";
        tr.cells[3].innerHTML = "हटायें";
        tr.cells[4].innerHTML = "क्रमांक नंबर";
        tr.cells[5].innerHTML = "आइटम ग्रुप का नाम";
        tr.cells[6].innerHTML = "आइटम ग्रुप का नाम (हिन्दी)";
        tr.cells[7].innerHTML = "कोड नंबर";
        tr.cells[8].innerHTML = "युनिट का नाम";
        tr.cells[9].innerHTML = "आइटम ग्रुप का नाम";
        //==========Increase Font========================//
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
        tr.cells[5].className = "Frm_Txt_Hindi";
        tr.cells[6].className = "Frm_Txt_Hindi";
        tr.cells[7].className = "Frm_Txt_Hindi";
        tr.cells[8].className = "Frm_Txt_Hindi";
        tr.cells[9].className = "Frm_Txt_Hindi";
    }
    //Form ID 2101, Form Name:MaterialManagement/Master/frm_Item_Master.aspx
    if (Choice == 0 && FormId == 2101) {
        document.getElementById("LblHeader").innerHTML = "आइटम मास्टर";
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
        document.getElementById("lblItemName").innerHTML = "आइटम का नाम";
        document.getElementById("lblItemNameHindi").innerHTML = "आइटम का नाम (हिन्दी) ";
        document.getElementById("lblCode").innerHTML = "कोड नंबर";
        document.getElementById("lblUnitName").innerHTML = "युनिट का नाम";
        document.getElementById("lblItemGroupName").innerHTML = "आइटम ग्रुप का नाम";
        //==========Increase Font========================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("lblItemName").className = "Frm_Txt_Hindi";
        document.getElementById("lblItemNameHindi").className = "Frm_Txt_Hindi";
        document.getElementById("lblCode").className = "Frm_Txt_Hindi";
        document.getElementById("lblUnitName").className = "Frm_Txt_Hindi";
        document.getElementById("lblItemGroupName").className = "Frm_Txt_Hindi";

        // Grid Code Start
        var table = document.getElementById("gvItemMaster");
        var tr = table.rows[0];
        tr.cells[3].innerHTML = "चुनिये";
        tr.cells[4].innerHTML = "हटायें";
        tr.cells[5].innerHTML = "क्रमांक नंबर";
        tr.cells[6].innerHTML = "आइटम का नाम";
        tr.cells[7].innerHTML = "आइटम का नाम (हिन्दी)";
        tr.cells[8].innerHTML = "कोड नंबर";
        tr.cells[9].innerHTML = "युनिट का नाम";
        tr.cells[10].innerHTML = "आइटम ग्रुप का नाम";
        //==========Increase Font========================//
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
        tr.cells[5].className = "Frm_Txt_Hindi";
        tr.cells[6].className = "Frm_Txt_Hindi";
        tr.cells[7].className = "Frm_Txt_Hindi";
        tr.cells[8].className = "Frm_Txt_Hindi";
        tr.cells[9].className = "Frm_Txt_Hindi";
        tr.cells[10].className = "Frm_Txt_Hindi";
    }

    //Form ID 2102, Form Name:MaterialManagement/Master/frm_Supplier_Master.aspx
    if (Choice == 0 && FormId == 2102) {
        document.getElementById("LblHeader").innerHTML = "Supplier MASTER(H)";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        //document.getElementById("btnNew").value = "नया";
       // document.getElementById("btnEdit").value = "सुधारें";
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btncancel").value = "रद्द करें";
        document.getElementById("btnAdd").value = "जोड़ें";
        document.getElementById("lblSupplierType").innerHTML = "Supplier Type(H)";
        document.getElementById("lblSupplier").innerHTML = "Supplier(H) ";
        document.getElementById("lblItemGroupName").innerHTML = "आइटम ग्रुप का नाम";
        document.getElementById("lblItemName").innerHTML = "आइटम का नाम";
        //==========Increase Font========================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        //document.getElementById("btnNew").className = "btn_Hindi";
        //document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btncancel").className = "btn_Hindi";
        document.getElementById("btnAdd").className = "btn_Hindi";
        document.getElementById("lblSupplierType").className = "Frm_Txt_Hindi";
        document.getElementById("lblSupplier").className = "Frm_Txt_Hindi";
        document.getElementById("lblItemGroupName").className = "Frm_Txt_Hindi";
        document.getElementById("lblItemName").className = "Frm_Txt_Hindi";

        // Grid Code Start
        var table = document.getElementById("gvSupplierMaster");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "चुनिये";
        tr.cells[1].innerHTML = "हटायें";
        tr.cells[2].innerHTML = "क्रमांक नंबर";
        tr.cells[3].innerHTML = "आइटम ग्रुप का नाम";
        tr.cells[4].innerHTML = "आइटम का नाम";
        //==========Increase Font========================//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        tr.cells[4].className = "Frm_Txt_Hindi";
    }

    //Form ID 2103, Form Name:MaterialManagement/Master/frm_SupplierRate_Master.aspx
    if (Choice == 0 && FormId == 2103) {
        document.getElementById("LblHeader").innerHTML = "Supplier Rate MASTER(H)";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        //document.getElementById("btnNew").value = "नया";
        //document.getElementById("btnEdit").value = "सुधारें";
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btncancel").value = "रद्द करें";
        document.getElementById("lblSupplierType").innerHTML = "Supplier Type(H)";
        document.getElementById("lblSupplier").innerHTML = "Supplier(H) ";
        document.getElementById("lblEffectiveDate").innerHTML = "प्रभावित तिथि";
        document.getElementById("lblValidity").innerHTML = "Validity (In Months)(H)";
        document.getElementById("Label1").innerHTML = "(दिन / माह / बर्ष )";
        //==========Increase Font========================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        //document.getElementById("btnNew").className = "btn_Hindi";
        //document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btncancel").className = "btn_Hindi";
        document.getElementById("lblSupplierType").className = "Frm_Txt_Hindi";
        document.getElementById("lblSupplier").className = "Frm_Txt_Hindi";
        document.getElementById("lblEffectiveDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblValidity").className = "Frm_Txt_Hindi";

        // Grid Code Start
        var table = document.getElementById("gvSupplierRateMaster");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "हटायें";
        tr.cells[1].innerHTML = "क्रमांक नंबर";
        tr.cells[2].innerHTML = "आइटम ग्रुप का नाम";
        tr.cells[3].innerHTML = "आइटम का नाम ";
        tr.cells[4].innerHTML = "Contracted Qty(H)";
        tr.cells[5].innerHTML = "दर";
        tr.cells[6].innerHTML = "Min Order Qty (H)";
        tr.cells[7].innerHTML = "Order Time (in Days)(H)";
        tr.cells[8].innerHTML = "Special Terms(H)";
        //==========Increase Font========================//
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
    //Form ID 2104, Form Name:MaterialManagement/Transaction/frm_Purchase_Order.aspx
    if (Choice == 0 && FormId == 2104) {
        document.getElementById("LblHeader").innerHTML = "क्रय आदेश";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        if (document.getElementById("hlback") != null) {
            document.getElementById("hlback").innerHTML = "पीछे जायें";
        }
        
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("lblSelectPurchaseOrderNo").innerHTML = "क्रय आदेश न. चुनिये";
        //document.getElementById("lblPurchaseOrder").innerHTML = "क्रय आदेश न.";
        document.getElementById("btnprepare").value = "prepare (H)";
        document.getElementById("btnverify").value = "Verify (H)";
        document.getElementById("btnpass").value = "pass (H)";
        document.getElementById("lblPurchaseOrderDate").innerHTML = "क्रय आदेश तिथि";
        document.getElementById("lblSupplier").innerHTML = "Supplier (H)";
        document.getElementById("lblShippingTerms").innerHTML = "Shipping Terms (H)";
        document.getElementById("lblShippingMethod").innerHTML = "Shipping Method (H)";
        document.getElementById("lblDeliveryDate").innerHTML = "Delivery Date (H)";
        document.getElementById("Label1").innerHTML = "(दिन / माह / बर्ष)";
        document.getElementById("Label3").innerHTML = "(दिन / माह / बर्ष)";
        document.getElementById("lblPlaceOfDeliver").innerHTML = "Place Of Deliver (H)";
        document.getElementById("lblAddress").innerHTML = "पता";
        document.getElementById("lblPinCode").innerHTML = "पिन कोड न.";
        document.getElementById("lblPhoneNo").innerHTML = "फोन न.";
        document.getElementById("lblEmailAddress").innerHTML = "ई - मेल पता";
        document.getElementById("lblPaymentMode").innerHTML = "भुगतान का प्रकार";
        document.getElementById("lblItemGroupName").innerHTML = "आइटम ग्रुप का नाम";
        document.getElementById("lblItemName").innerHTML = "आइटम का नाम";
        document.getElementById("lblCode").innerHTML = "कोड न.";
        document.getElementById("lblQty").innerHTML = "मात्रा";
        document.getElementById("lblUnitName").innerHTML = "युनिट का नाम";
        document.getElementById("lblPacking").innerHTML = "Packing (H)";
        document.getElementById("lblRate").innerHTML = "दर";
        document.getElementById("lblExciseService").innerHTML = "Excise Duty/Service Tax (H)";
        document.getElementById("lblVat").innerHTML = "Vat (H)";
        document.getElementById("lblDiscount").innerHTML = "Discount (H)";
        document.getElementById("lblFreight").innerHTML = "Freight (H)";
        document.getElementById("btnAdd").value = "जोडें";
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btnverifypass").value = "रक्षित करें एवं भेजें";
        document.getElementById("lblForwardDesignation").innerHTML = "अग्रेषित पद"
        document.getElementById("lblForwardedEmp").innerHTML = "अग्रेषित कर्मचारी"
        document.getElementById("btnForwardOk").value = "ओके"
        document.getElementById("btnForwardCancel").value = "रद्द करें"

        // Payment Mode Radio button code
        var RBcash = document.getElementById("rbcash");
        var RB = RBcash.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "नगद";
        RB[0].className = "Frm_Txt_Hindi";

        var RBCredit = document.getElementById("rbCredit");
        var RB = RBCredit.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "क्रेडिट";
        RB[0].className = "Frm_Txt_Hindi";

        var RBLC = document.getElementById("rbLC");
        var RB = RBLC.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "एल सी";
        RB[0].className = "Frm_Txt_Hindi";

        if (document.getElementById("lblLCRefNo") != null) {
            document.getElementById("lblLCRefNo").innerHTML = "एल सी रिफरेंस न.";
        }            
            
        // Grid Code Start
        var table = document.getElementById("gvPurchase_Order");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "चुनिये";
        tr.cells[1].innerHTML = "हटायें";
        tr.cells[2].innerHTML = "क्रमांक नंबर";
        tr.cells[3].innerHTML = "आइटम का नाम";
        tr.cells[4].innerHTML = "मात्रा";
        tr.cells[5].innerHTML = "युनिट का नाम";
        tr.cells[6].innerHTML = "दर";
        tr.cells[7].innerHTML = "ED/ST %(H)";
        tr.cells[8].innerHTML = "राशि";
        tr.cells[9].innerHTML = "Vat %(H)";
        tr.cells[10].innerHTML = "राशि";
        tr.cells[11].innerHTML = "Discount %(H)";
        tr.cells[12].innerHTML = "राशि";
        tr.cells[13].innerHTML = "राशि";
    }
    //Form ID 2105, Form Name:MaterialManagement/Transaction/frm_GRN.aspx
    if (Choice == 0 && FormId == 2105) {
        document.getElementById("LblHeader").innerHTML = "जी आर एन";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        if (document.getElementById("hlback") != null) {
            document.getElementById("hlback").innerHTML = "पीछे जायें |";
        }  
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("lblSelectGRNNo").innerHTML = "जी आर एन न. चुनिये";
        //document.getElementById("lblGRN").innerHTML = "जी आर एन न.";
        document.getElementById("btnprepare").value = "prepare (H)";
        document.getElementById("btnverify").value = "Verify (H)";
        document.getElementById("btnpass").value = "pass (H)";
        document.getElementById("lblDate").innerHTML = "तिथि";
        document.getElementById("lblPurchaseOrder").innerHTML = "Against Purchase Order (H)";
        document.getElementById("btnFill").value = "Fill (H)";
        document.getElementById("lblSupplierType").innerHTML = "Supplier Type (H)";
        document.getElementById("lblSupplier").innerHTML = "Supplier (H)";
        document.getElementById("lblTransporter").innerHTML = "Transporter (H)";
        document.getElementById("lblBillNo").innerHTML = "Bilty No. (H)";
        document.getElementById("lblChallanNo").innerHTML = "Challan No.(H)";
        document.getElementById("lblInvoiceCash").innerHTML = "Invoice/Cash Memo no. (H)";
        document.getElementById("lblInvoiceCashMemoDate").innerHTML = "तिथि";
        document.getElementById("lblAgainstForm").innerHTML = "Against Form (H)";
        document.getElementById("CHC").nextSibling.innerHTML = "'सी'";
        document.getElementById("CHF").nextSibling.innerHTML = "'एफ'";
        document.getElementById("CH49").nextSibling.innerHTML = "'49'";
        document.getElementById("lblInter_State_Sale").innerHTML = "Inter State Sale (H)";
        document.getElementById("lblPaymentMode").innerHTML = "भुगतान का प्रकार";
        document.getElementById("lblItemGroupName").innerHTML = "आइटम ग्रुप का नाम";
        document.getElementById("lblItemName").innerHTML = "आइटम का नाम";
        document.getElementById("lblCode").innerHTML = "कोड न.";
        document.getElementById("lblQty").innerHTML = "मात्रा";
        document.getElementById("lblUnitName").innerHTML = "युनिट का नाम";
        document.getElementById("lblPacking").innerHTML = "Packing (H)";
        document.getElementById("lblRate").innerHTML = "दर";
        document.getElementById("lblExciseService").innerHTML = "Excise Duty/Service Tax (H)";
        document.getElementById("Label1").innerHTML = "(दिन / माह / बर्ष )";
        document.getElementById("Label3").innerHTML = "(दिन / माह / बर्ष )";
        document.getElementById("lblVat").innerHTML = "Vat (H)";
        document.getElementById("lblDiscount").innerHTML = "Discount (H)";
        document.getElementById("lblFreight").innerHTML = "Freight (H)";
        document.getElementById("btnAdd").value = "जोडें";
        document.getElementById("btnDetails").value = "विवरण";
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btnverifypass").value = "रक्षित करें एवं भेजें";
        document.getElementById("lblForwardDesignation").innerHTML = "अग्रेषित पद"
        document.getElementById("lblForwardedEmp").innerHTML = "अग्रेषित कर्मचारी"
        document.getElementById("btnForwardOk").value = "ओके"
        document.getElementById("btnForwardCancel").value = "रद्द करें"

        // Payment Mode Radio button code
        var RBcash = document.getElementById("rbcash");
        var RB = RBcash.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "नगद";
        RB[0].className = "Frm_Txt_Hindi";

        var RBCredit = document.getElementById("rbCredit");
        var RB = RBCredit.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "क्रेडिट";
        RB[0].className = "Frm_Txt_Hindi";

        var RBLC = document.getElementById("rbLC");
        var RB = RBLC.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "एल सी";
        RB[0].className = "Frm_Txt_Hindi";

        if (document.getElementById("lblLCRefNo") != null) {
            document.getElementById("lblLCRefNo").innerHTML = "एल सी रिफरेंस न.";
        }

        if (document.getElementById("btnSaveColumnValue") != null) {
            document.getElementById("btnSaveColumnValue").value = "ओके";
        }

        if (document.getElementById("btnCancel") != null) {
            document.getElementById("btnCancel").value = "रद्द करें";
        }  

        // Grid Code Start
        var table = document.getElementById("gvGRN");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "चुनिये";
        tr.cells[1].innerHTML = "हटायें";
        tr.cells[2].innerHTML = "क्रमांक नंबर";
        tr.cells[3].innerHTML = "आइटम का नाम";
        tr.cells[4].innerHTML = "मात्रा";
        tr.cells[5].innerHTML = "युनिट का नाम";
        tr.cells[6].innerHTML = "दर";
        tr.cells[7].innerHTML = "ED/ST %(H)";
        tr.cells[8].innerHTML = "राशि";
        tr.cells[9].innerHTML = "Vat %(H)";
        tr.cells[10].innerHTML = "राशि";
        tr.cells[11].innerHTML = "Discount %(H)";
        tr.cells[12].innerHTML = "राशि";
        tr.cells[13].innerHTML = "राशि";
    }
    //Form ID 2106, Form Name:MaterialManagement/Transaction/frm_Material_Requisition_Slip.aspx
    if (Choice == 0 && FormId == 2106) {
        document.getElementById("LblHeader").innerHTML = "Material Requisition Slip (H)";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        if (document.getElementById("hlback") != null) {
            document.getElementById("hlback").innerHTML = "पीछे जायें |";
        }
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("btnprepare").value = "prepare (H)";
        document.getElementById("btnverify").value = "Verify (H)";
        document.getElementById("btnpass").value = "pass (H)";
        document.getElementById("lblSelectGRNNo").innerHTML = "जी आर एन न. चुनें";
        document.getElementById("lblDate").innerHTML = "तिथि";
        document.getElementById("lblSchemeName").innerHTML = "स्कीम का नाम";
        document.getElementById("lblProjecRefNo").innerHTML = "परियोजना रिफरेंस न.";
        document.getElementById("lblDepartmentName").innerHTML = "विभाग का नाम";
        document.getElementById("lblDivisionName").innerHTML = "शाखा का नाम";
        document.getElementById("lblItemGroupName").innerHTML = "आइटम ग्रुप का नाम";
        document.getElementById("lblItemName").innerHTML = "आइटम का नाम";
        document.getElementById("lblDeliveryDate").innerHTML = "Delivery Date (H)";
        document.getElementById("lblQtyRequired").innerHTML = "जरूरी मात्रा";
        document.getElementById("lblRemark").innerHTML = "विवरण";
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btnverifypass").value = "रक्षित करें एवं भेजें";
        document.getElementById("lblForwardDesignation").innerHTML = "अग्रेषित पद"
        document.getElementById("lblForwardedEmp").innerHTML = "अग्रेषित कर्मचारी"
        document.getElementById("btnForwardOk").value = "ओके"
        document.getElementById("btnForwardCancel").value = "रद्द करें"
        //====================font Increase=================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnprepare").className = "btn_Hindi";
        document.getElementById("btnverify").className = "btn_Hindi";
        document.getElementById("btnpass").className = "btn_Hindi";
        document.getElementById("lblSelectGRNNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblSchemeName").className = "Frm_Txt_Hindi";
        document.getElementById("lblProjecRefNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblDepartmentName").className = "Frm_Txt_Hindi";
        document.getElementById("lblDivisionName").className = "Frm_Txt_Hindi";
        document.getElementById("lblItemGroupName").className = "Frm_Txt_Hindi";
        document.getElementById("lblItemName").className = "Frm_Txt_Hindi";
        document.getElementById("lblDeliveryDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblQtyRequired").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemark").className = "Frm_Txt_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnverifypass").className = "btn_Hindi";
        document.getElementById("lblForwardDesignation").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwardedEmp").className = "Frm_Txt_Hindi";
        document.getElementById("btnForwardOk").className = "btn_Hindi";
        document.getElementById("btnForwardCancel").className = "btn_Hindi";
    }
    //Form ID 2107, Form Name:MaterialManagement/Transaction/frm_Stock_Issue.aspx
    if (Choice == 0 && FormId == 2107) {
        document.getElementById("LblHeader").innerHTML = "Stock Issue(H)";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        if (document.getElementById("hlback") != null) {
            document.getElementById("hlback").innerHTML = "पीछे जायें";
        }
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
        if (document.getElementById("btnSave") != null) {
            document.getElementById("btnSave").value = "रक्षित करें";
        }
        if (document.getElementById("btnissue") != null) {
            document.getElementById("btnissue").value = "Issue (H)";
        }
        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnAdd").value = "जोडें";
        document.getElementById("lblRequisitionNo").innerHTML = "Requisition No.(H) ";
        document.getElementById("lblDate").innerHTML = "तिथि";
        document.getElementById("lblDepartmentName").innerHTML = "विभाग का नाम";
        document.getElementById("lblDivisionName").innerHTML = "शाखा का नाम";
        document.getElementById("Label1").innerHTML = "Requisition Detail -:(H) ";
        document.getElementById("Requisition").innerHTML = "Requisition No (H)";
        document.getElementById("lblItemNameGroup").innerHTML = "आइटम ग्रुप का नाम";
        document.getElementById("lblItemName").innerHTML = "आइटम का नाम";
        document.getElementById("lblQty").innerHTML = "Qty(H)";
        document.getElementById("lblIssuedQty").innerHTML = "Issued Qty(H) ";
        document.getElementById("lblRemark").innerHTML = "विवरण";
        if (document.getElementById("lblSelectGRNNo") != null) {
            document.getElementById("lblSelectGRNNo").innerHTML = "Select stock No.(H)";
        }
        //==========Increase Font========================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";
        if (document.getElementById("btnSave") != null) {
            document.getElementById("btnSave").className = "btn_Hindi";
        }
        if (document.getElementById("btnissue") != null) {
            document.getElementById("btnissue").className = "btn_Hindi";
        }
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnAdd").className = "btn_Hindi";
        document.getElementById("lblRequisitionNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblDepartmentName").className = "Frm_Txt_Hindi";
        document.getElementById("lblDivisionName").className = "Frm_Txt_Hindi";
        document.getElementById("Label1").className = "Frm_Head_Hindi";
        document.getElementById("Requisition").className = "Frm_Txt_Hindi";
        document.getElementById("lblItemNameGroup").className = "Frm_Txt_Hindi";
        document.getElementById("lblItemName").className = "Frm_Txt_Hindi";
        document.getElementById("lblQty").className = "Frm_Txt_Hindi";
        document.getElementById("lblIssuedQty").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemark").className = "Frm_Txt_Hindi";
        if (document.getElementById("lblSelectGRNNo") != null) {
            document.getElementById("lblSelectGRNNo").className = "Frm_Txt_Hindi";
        }
        // Grid Code Start
        var table = document.getElementById("gvStockIssue");
        var tr = table.rows[0];
        tr.cells[1].innerHTML = "चुनिये";
        tr.cells[2].innerHTML = "हटायें";
        tr.cells[3].innerHTML = "क्रमांक नंबर";
        tr.cells[4].innerHTML = "आइटम ग्रुप का नाम";
        tr.cells[5].innerHTML = "आइटम का नाम ";
        tr.cells[6].innerHTML = "Requisition No.(H)";
        tr.cells[7].innerHTML = "स्कीम का नाम";
        tr.cells[8].innerHTML = "परियोजना का नाम";
        tr.cells[9].innerHTML = "मात्रा";
        tr.cells[10].innerHTML = "Issued Qty(H)";
        tr.cells[11].innerHTML = "विवरण";
        //==========Increase Font========================//
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
    //Form ID 2108, Form Name:MaterialManagement/Transaction/frm_Material_Requisition_DashBoard.aspx
    if (Choice == 0 && FormId == 2108) {
        document.getElementById("LblHeader").innerHTML = "Material Requisition Dash Board(H)";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("lblSR").innerHTML = "क्रमांक न.";
        document.getElementById("lblRequisitionDate").innerHTML = "Requisition Date (H)";
        document.getElementById("lblRequisitionNo").innerHTML = "Requisition No. (H)";
        document.getElementById("lblRequisitionFrom").innerHTML = "Requisition From(H)";
        document.getElementById("lblItemDescription").innerHTML = "आइटम का विवरण";
        document.getElementById("lblStatus").innerHTML = "Status (H)";
        document.getElementById("lblAction").innerHTML = "Action Tag (H)";
        document.getElementById("Remark").innerHTML = "विवरण";
        document.getElementById("lblForward").innerHTML = "भेजें";
        document.getElementById("lblDepartment").innerHTML = "विभाग";
        document.getElementById("lblDivision").innerHTML = "शाखा";
        document.getElementById("lblEmployee").innerHTML = "कर्मचारी";
        document.getElementById("lblItemCode").innerHTML = "आइटम कोड";
        document.getElementById("lblItemName").innerHTML = "आइटम का नाम";
        document.getElementById("lblQTY").innerHTML = "मात्रा";
        document.getElementById("lblDeliveryDate").innerHTML = "Delivery Date(H)";
        document.getElementById("lblAvailability").innerHTML = "Availability (H)";
        document.getElementById("lblMRS").innerHTML = "एम आर एस";
        document.getElementById("lblIssue").innerHTML = "Issue (H)";
        document.getElementById("lblPO").innerHTML = "क्रय आदेश";
        document.getElementById("lblRespond").innerHTML = "Respond (H)";
        document.getElementById("lblForwardDesignation").innerHTML = "अग्रेषित पद"
        document.getElementById("lblForwardedEmp").innerHTML = "अग्रेषित कर्मचारी"
        document.getElementById("btnForwardOk").value = "ओके"
        document.getElementById("btnForwardCancel").value = "रद्द करें"
        //========================Increase Font=======================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblSR").className = "Frm_Txt_Hindi";
        document.getElementById("lblRequisitionDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblRequisitionNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblRequisitionFrom").className = "Frm_Txt_Hindi";
        document.getElementById("lblItemDescription").className = "Frm_Txt_Hindi";
        document.getElementById("lblStatus").className = "Frm_Txt_Hindi";
        document.getElementById("lblAction").className = "Frm_Txt_Hindi";
        document.getElementById("Remark").className = "Frm_Txt_Hindi";
        document.getElementById("lblForward").className = "Frm_Txt_Hindi";
        document.getElementById("lblDepartment").className = "Frm_Txt_Hindi";
        document.getElementById("lblDivision").className = "Frm_Txt_Hindi";
        document.getElementById("lblEmployee").className = "Frm_Txt_Hindi";
        document.getElementById("lblItemCode").className = "Frm_Txt_Hindi";
        document.getElementById("lblItemName").className = "Frm_Txt_Hindi";
        document.getElementById("lblQTY").className = "Frm_Txt_Hindi";
        document.getElementById("lblDeliveryDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblAvailability").className = "Frm_Txt_Hindi";
        document.getElementById("lblMRS").className = "Frm_Txt_Hindi";
        document.getElementById("lblIssue").className = "Frm_Txt_Hindi";
        document.getElementById("lblPO").className = "Frm_Txt_Hindi";
        document.getElementById("lblRespond").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwardDesignation").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwardedEmp").className = "Frm_Txt_Hindi";
        document.getElementById("btnForwardOk").className = "btn_Hindi";
        document.getElementById("btnForwardCancel").className = "btn_Hindi";
    }
    //Form ID 2109, Form Name:MaterialManagement/Transaction/PurchaseOrder_Dash.aspx
    if (Choice == 0 && FormId == 2109) {
        document.getElementById("LblHeader").innerHTML = "Purchase Order Dash Board (H)";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("lblSR").innerHTML = "क्रमांक न.";
        document.getElementById("lblPODate").innerHTML = "क्रय आदेश तिथि";
        document.getElementById("lblPONo").innerHTML = "क्रय आदेश न.";
        document.getElementById("lblPOFrom").innerHTML = "Purchase Order From(H)";
        document.getElementById("lblRemark").innerHTML = "विवरण";
        document.getElementById("lblAction").innerHTML = "Action Tag";
        document.getElementById("Remark").innerHTML = "विवरण";
        document.getElementById("lblForward").innerHTML = "भेजें";
        document.getElementById("lblDepartment").innerHTML = "विभाग";
        document.getElementById("lblDivision").innerHTML = "शाखा";
        document.getElementById("lblEmployee").innerHTML = "कर्मचारी";
        document.getElementById("lblSupplier").innerHTML = "Supplier (H)";
        document.getElementById("lblAction").innerHTML = "Action Tag (H)";
        document.getElementById("lblPO").innerHTML = "क्रय आदेश";
        document.getElementById("lblForwardDesignation").innerHTML = "अग्रेषित पद"
        document.getElementById("lblForwardedEmp").innerHTML = "अग्रेषित कर्मचारी"
        document.getElementById("btnForwardOk").value = "ओके"
        document.getElementById("btnForwardCancel").value = "रद्द करें"
        //===========Increase Font Size ==================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblSR").className = "Frm_Txt_Hindi";
        document.getElementById("lblPODate").className = "Frm_Txt_Hindi";
        document.getElementById("lblPONo").className = "Frm_Txt_Hindi";
        document.getElementById("lblPOFrom").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemark").className = "Frm_Txt_Hindi";
        document.getElementById("lblAction").className = "Frm_Txt_Hindi";
        document.getElementById("Remark").className = "Frm_Txt_Hindi";
        document.getElementById("lblForward").className = "Frm_Txt_Hindi";
        document.getElementById("lblDepartment").className = "Frm_Txt_Hindi";
        document.getElementById("lblDivision").className = "Frm_Txt_Hindi";
        document.getElementById("lblEmployee").className = "Frm_Txt_Hindi";
        document.getElementById("lblSupplier").className = "Frm_Txt_Hindi";
        document.getElementById("lblAction").className = "Frm_Txt_Hindi";
        document.getElementById("lblPO").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwardDesignation").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwardedEmp").className = "Frm_Txt_Hindi";
        document.getElementById("btnForwardOk").className = "btn_Hindi";
        document.getElementById("btnForwardCancel").className = "btn_Hindi";
    }
    //Form ID 2110, Form Name:MaterialManagement/Transaction/frm_PurchaseAndGRN_DashBoard.aspx
    if (Choice == 0 && FormId == 2110) {
        document.getElementById("LblHeader").innerHTML = "GRN Dash Board (H)";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        document.getElementById("lblSR").innerHTML = "क्रमांक न.";
        document.getElementById("lblGRNDate").innerHTML = "जी आर एन तिथि";
        document.getElementById("lblGRNNo").innerHTML = "जी आर एन न.";
        document.getElementById("lblGRNFrom").innerHTML = "GRN From (H)";
        document.getElementById("lblRemark").innerHTML = "विवरण";
        document.getElementById("lblAction").innerHTML = "Action Tag";
        document.getElementById("Remark").innerHTML = "विवरण";
        document.getElementById("lblForward").innerHTML = "भेजें";
        document.getElementById("lblDepartment").innerHTML = "विभाग";
        document.getElementById("lblDivision").innerHTML = "शाखा";
        document.getElementById("lblEmployee").innerHTML = "कर्मचारी";
        document.getElementById("lblSupplier").innerHTML = "Supplier (H)";
        document.getElementById("lblAction").innerHTML = "Action Tag (H)";
        document.getElementById("lblGRN").innerHTML = "जी आर एन";
        document.getElementById("lblForwardDesignation").innerHTML = "अग्रेषित पद"
        document.getElementById("lblForwardedEmp").innerHTML = "अग्रेषित कर्मचारी"
        document.getElementById("btnForwardOk").value = "ओके"
        document.getElementById("btnForwardCancel").value = "रद्द करें"
        //==================== Increase Font ======================//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblSR").className = "Frm_Txt_Hindi";
        document.getElementById("lblGRNDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblGRNNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblGRNFrom").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemark").className = "Frm_Txt_Hindi";
        document.getElementById("lblAction").className = "Frm_Txt_Hindi";
        document.getElementById("Remark").className = "Frm_Txt_Hindi";
        document.getElementById("lblForward").className = "Frm_Txt_Hindi";
        document.getElementById("lblDepartment").className = "Frm_Txt_Hindi";
        document.getElementById("lblDivision").className = "Frm_Txt_Hindi";
        document.getElementById("lblEmployee").className = "Frm_Txt_Hindi";
        document.getElementById("lblSupplier").className = "Frm_Txt_Hindi";
        document.getElementById("lblAction").className = "Frm_Txt_Hindi";
        document.getElementById("lblGRN").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwardDesignation").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwardedEmp").className = "Frm_Txt_Hindi";
        document.getElementById("btnForwardOk").className = "btn_Hindi";
        document.getElementById("btnForwardCancel").className = "btn_Hindi";
    }
    //Form ID 2119, Form Name:MaterialManagement/rpt_StockRegister.aspx
    if (Choice == 0 && FormId == 2119) {
        document.getElementById("LblHeader").innerHTML = "Stock Register (H)";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("lblFromDate").innerHTML = "तिथि से";
        document.getElementById("lblToDate").innerHTML = "तिथि तक";
        document.getElementById("lblItemGroupName").innerHTML = "आइटम ग्रुप का नाम";
        document.getElementById("lblItemName").innerHTML = "आइटम का नाम";
        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        //=========Increase Hindi==============//
        document.getElementById("lblFromDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblToDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblItemGroupName").className = "Frm_Txt_Hindi";
        document.getElementById("lblItemName").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
    }

    //Form ID 2120, Form Name:MaterialManagement/rpt_StockList.aspx
    if (Choice == 0 && FormId == 2120) {
        document.getElementById("LblHeader").innerHTML = "Stock List (H)";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("lblFromDate").innerHTML = "तिथि से";
        document.getElementById("lblToDate").innerHTML = "तिथि तक";
        document.getElementById("lblItemGroupName").innerHTML = "आइटम ग्रुप का नाम";
        document.getElementById("lblItemName").innerHTML = "आइटम का नाम";
        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        //=========Increase Hindi==============//
        document.getElementById("lblFromDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblToDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblItemGroupName").className = "Frm_Txt_Hindi";
        document.getElementById("lblItemName").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
    }

    //Form ID 2111, Form Name:MaterialManagement/Transaction/frm_LCOpening.aspx
    if (Choice == 0 && FormId == 2111) {
        document.getElementById("LblHeader").innerHTML = "LC Opening Form(H)";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";
        //document.getElementById("btnAdd").value = "रिकार्ड जोडें";
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btnNew").value = "नया";
        document.getElementById("btnEdit").value = "सुधारें";        
        document.getElementById("btnCancel").value = "रद्द करें";
        document.getElementById("lblLCRefNo").innerHTML = "एल सी न.";
        document.getElementById("lblDate").innerHTML = "तिथि";
        document.getElementById("lblBanificiaryName").innerHTML = "हितग्राही का नाम";
        document.getElementById("lblAddress").innerHTML = "पता";
        document.getElementById("lblLCAmount").innerHTML = "एल सी राशि";
        document.getElementById("lblCurrency").innerHTML = "Currency (H)";
        document.getElementById("lblExchangeRate").innerHTML = "Exchange Rate (H)";
        document.getElementById("lblAdvisingBank").innerHTML = "Advising Bank Name & Address (H)";
        document.getElementById("lblBenificiaryBankName").innerHTML = "Benificiary  Bank Name & Address (H)";
        document.getElementById("lblShippingPeriod").innerHTML = "Shipping Period (H)";
        document.getElementById("lblFromDate").innerHTML = "तिथि से";
        document.getElementById("lblToDate").innerHTML = "तिथि तक";
        document.getElementById("lblFOB").innerHTML = "FOB/C.F.R/CIF(H)";
        document.getElementById("Label1").innerHTML = "Partial Shipment Permitted (H)";
        document.getElementById("lblTransshipment").innerHTML = "Transshipment Permitted (H)";
        document.getElementById("lblDocuments").innerHTML = "दस्तावेज";

        document.getElementById("lblSignedCommercial").innerHTML = "Signed Commercial Invoice (H)";
        document.getElementById("lblImportLicenseNo").innerHTML = "Import License No. (H)";
        document.getElementById("lblBillsofLading").innerHTML = "Bills of Lading (H)";
        document.getElementById("lblMarineInsurancePolicy").innerHTML = "Marine Insurance Policy (H)";
        document.getElementById("lblTestCertificate").innerHTML = "Test Certificate/Inspection Certificate (H)";
        
        document.getElementById("SignedCommercialCopiesNo").innerHTML = "काँपी की संख्या";
        document.getElementById("ImportLicenseCopiesNo").innerHTML = "काँपी की संख्या";
        document.getElementById("lblBillsofLadingCopiesNo").innerHTML = "काँपी की संख्या";
        document.getElementById("lblMarineInsurancePolicyCopiesNo").innerHTML = "काँपी की संख्या";
        document.getElementById("lblTestCertificateCopiesNo").innerHTML = "काँपी की संख्या";
        document.getElementById("lblLastDateofBills").innerHTML = "Last Date of Bills of Lading (H)";
        document.getElementById("lblLastDateofNegotiation").innerHTML = "Last Date of Negotiation of Bills of Exchange (H)";
        //=======================Increase Font========================//



        // Yes,No Radio button code
        var RBYes = document.getElementById("rbPortialYes");
        var RB = RBYes.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हाँ";

        var RBNo = document.getElementById("rbPortialNo");
        var RB = RBNo.parentNode.getElementsByTagName("label");
        RB[1].innerHTML = "नहीं";

        // Yes,No Radio button code
        var TransshipmentYes = document.getElementById("rbTransshipmentYes");
        var RB = TransshipmentYes.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हाँ";

        var TransshipmentNo = document.getElementById("rbTransshipmentNo");
        var RB = TransshipmentNo.parentNode.getElementsByTagName("label");
        RB[1].innerHTML = "नहीं";
    }

    //Form ID 2112, Form Name:MaterialManagement/Transaction/frm_Amc_Register.aspx
    if (Choice == 0 && FormId == 2112) {
        document.getElementById("LblHeader").innerHTML = "AMC Register (H)";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("lblSR").innerHTML = "क्रमांक न.";
        document.getElementById("lblServiceprovider").innerHTML = "Service provider (H)";
        document.getElementById("lblContractNo").innerHTML = "Contact No. (H)";
        document.getElementById("lblNatureservice").innerHTML = "Nature of service (H)";
        document.getElementById("lblPeriod").innerHTML = "अवधि";
        document.getElementById("lblContactDetails").innerHTML = "Contact Details (H)";
        document.getElementById("lblRequestservice").innerHTML = "Request for service (H)";
        document.getElementById("lblFrom").innerHTML = "से";
        document.getElementById("lblTo").innerHTML = "तक";
    }
    //Form ID 2124, Form Name:MaterialManagement/PrintCertificates_Declaration.aspx
    if (Choice == 0 && FormId == 2124) {
        document.getElementById("LblHeader").innerHTML = "Print Certificates / Declaration (H)";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("lblTypeof").innerHTML = "Type of (H)";
        document.getElementById("lblNo").innerHTML = "नंबर";
        document.getElementById("lblDate").innerHTML = "तिथि";
        document.getElementById("lblSupplierType").innerHTML = "Supplier Type (H)";
        document.getElementById("lblSupplierName").innerHTML = "Supplier Name(H)";
        document.getElementById("lblItemGroup").innerHTML = "आइटम ग्रुप का नाम";
        document.getElementById("lblItemName").innerHTML = "आइटम का नाम";
        document.getElementById("lblQty").innerHTML = "मात्रा";
        document.getElementById("lblRate").innerHTML = "दर";
        document.getElementById("lblValue").innerHTML = "वेल्यु";
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        //=========Increase Hindi==============//

    }

    //Form ID 2125, Form Name:MaterialManagement/rpt_Availability_GoodMaterial.aspx
    if (Choice == 0 && FormId == 2125) {
        document.getElementById("LblHeader").innerHTML = "Availability of Goods Material (H)";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("lblCode").innerHTML = "कोड न.";
        document.getElementById("lblItemGroup").innerHTML = "आइटम ग्रुप का नाम";
        document.getElementById("lblItemName").innerHTML = "आइटम का नाम";
        document.getElementById("btnShow").value = "देखें";
        document.getElementById("lblBalanceQty").innerHTML = "शेष मात्रा";
        //=========Increase Hindi==============//
        document.getElementById("lblCode").className = "Frm_Txt_Hindi";
        document.getElementById("lblItemGroup").className = "Frm_Txt_Hindi";
        document.getElementById("lblItemName").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("lblBalanceQty").className = "Frm_Txt_Hindi";
    }
}





