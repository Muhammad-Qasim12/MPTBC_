var GlobalLanguage;
function ChangeLabel(Choice, FormId, QueryString) {
    if (Choice == 0 && FormId == 2352) {
        document.getElementById("LblHeader").innerHTML = "प्रिंटर एफ.डी.आर .";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        //    // Branch Radio button code
        //    var RBHindi = document.getElementById("RbWithBranch");
        //    var RB = RBHindi.parentNode.getElementsByTagName("label");
        //    RB[0].innerHTML = "उप शाखा सहित";
        //    RB[0].className = "Frm_Txt_Hindi";

        //    var RBenglish = document.getElementById("RbWithoutBranch");
        //    var RB = RBenglish.parentNode.getElementsByTagName("label");
        //    RB[0].innerHTML = "उप शाखा रहित";
        //    RB[0].className = "Frm_Txt_Hindi";

        document.getElementById("btnShow").value = "देखें";
        document.getElementById("btnPrint").value = "प्रिंट करे";
        document.getElementById("lblPrinter").innerHTML = "प्रिंटर";
        document.getElementById("lblFromDate").innerHTML = "दिनांक से";
        document.getElementById("lblToDate").innerHTML = "दिनांक तक";
        document.getElementById("btnSaveAsExecel").value = "एक्सेल में रक्षित करें";

        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblPrinter").className = "Frm_Txt_Hindi";
        document.getElementById("lblFromDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblToDate").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveAsExecel").className = "btn_Hindi";
    }
    //Form ID 2606, Form Name:frm_UnloadingExpenses.aspx;
    if (Choice == 0 && FormId == 2606) {
        document.getElementById("lblheader").innerHTML = "अनलोडिंग व्यय";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        //    // Branch Radio button code
        //    var RBHindi = document.getElementById("RbWithBranch");
        //    var RB = RBHindi.parentNode.getElementsByTagName("label");
        //    RB[0].innerHTML = "उप शाखा सहित";
        //    RB[0].className = "Frm_Txt_Hindi";

        //    var RBenglish = document.getElementById("RbWithoutBranch");
        //    var RB = RBenglish.parentNode.getElementsByTagName("label");
        //    RB[0].innerHTML = "उप शाखा रहित";
        //    RB[0].className = "Frm_Txt_Hindi";
        document.getElementById("lblheader").innerHTML = "अनलोडिंग व्यय ";
        document.getElementById("btnNew").value = "नया बनायें";
        document.getElementById("btnEdit").value = "सुधारें";
        document.getElementById("btnSave").value = "रक्षित करें";
        document.getElementById("btnPrepare").value = "तैयार करें";
        document.getElementById("lblPrinterName").innerHTML = "प्रिंटर नाम";
        document.getElementById("lblGRNDate").innerHTML = "जीआरएन दिनांक";
        document.getElementById("lblGRNNo").innerHTML = "जीआरएन  नं.";
        document.getElementById("lblUnloading").innerHTML = "दर(रु.)";
        document.getElementById("lblNoOfBundles").innerHTML = "बंडलों की संख्या";
        document.getElementById("lblAmount").innerHTML = "राशि(रु.) ";
        document.getElementById("lblGroupNo").innerHTML = "ग्रुप नं.";
        document.getElementById("lblTenderNo").innerHTML = "टेंडर नं.";
        document.getElementById("lblPaymentDetail").innerHTML = "भुगतान विवरण";
        document.getElementById("lblReferenceNo").innerHTML = "रिफरेंस नं.";
        //========Hindi Text========//
        document.getElementById("lblheader").className = "Frm_Head_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnPrepare").className = "btn_Hindi";
        document.getElementById("lblPrinterName").className = "Frm_Txt_Hindi";
        document.getElementById("lblGRNDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblGRNNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblUnloading").className = "Frm_Txt_Hindi";
        document.getElementById("lblNoOfBundles").className = "Frm_Txt_Hindi";
        document.getElementById("lblAmount").className = "Frm_Txt_Hindi";
        document.getElementById("lblGroupNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblTenderNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblPaymentDetail").className = "Frm_Txt_Hindi";
        document.getElementById("lblReferenceNo").className = "Frm_Txt_Hindi";


    }

    //rpt_Misc_Advance_Recovery_schedule Formid=2358
    if (Choice == 0 && FormId == 2358) {

        document.getElementById("LblHeader").innerHTML = "विविध अग्रिम कटौती अनुसूची";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbDeputation");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "प्रतिनियुक्ति";
        RB[0].className = "Frm_Txt_Hindi";
        
        var RBenglish = document.getElementById("rbOther");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "अन्य";
        RB[0].className = "Frm_Txt_Hindi";
        
        document.getElementById("lblMonth").innerHTML = "माह";
        document.getElementById("lblYear").innerHTML = "वर्ष";
        document.getElementById("btnFillPay").value = "पे बिल नं भरें";
        document.getElementById("lblPaybillNo").innerHTML = "पे बिल  नं.";
        document.getElementById("btnShow").value = "देखें ";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";

        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblMonth").className = "Frm_Txt_Hindi";
        document.getElementById("lblYear").className = "Frm_Txt_Hindi";
        document.getElementById("btnFillPay").className = "btn_Hindi";
        document.getElementById("lblPaybillNo").className = "Frm_Txt_Hindi";

        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";

    }


    
    //
    if (Choice == 0 && FormId == 2354) {

        document.getElementById("LblHeader").innerHTML = "व्यवसायिक कर सूची ";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbDeputation");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "प्रतिनियुक्ति";
        RB[0].className = "Frm_Txt_Hindi";

        var RBenglish = document.getElementById("rbOther");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "अन्य";
        RB[0].className = "Frm_Txt_Hindi";


        document.getElementById("lblMonth").innerHTML = "माह";
        document.getElementById("lblYear").innerHTML = "वर्ष";
        document.getElementById("btnFillPay").value = "पे बिल नं भरें";
        document.getElementById("lblPaybillNo").innerHTML = "पे बिल  नं.";
        document.getElementById("btnShow").value = "देखें ";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";

        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblMonth").className = "Frm_Txt_Hindi";
        document.getElementById("lblYear").className = "Frm_Txt_Hindi";
        document.getElementById("btnFillPay").className = "btn_Hindi";
        document.getElementById("lblPaybillNo").className = "Frm_Txt_Hindi";

        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";



    }
    if (Choice == 0 && FormId == 2355) {

        document.getElementById("LblHeader").innerHTML = "आयकर सूची";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        var RBHindi = document.getElementById("rbDeputation");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "प्रतिनियुक्ति";
        RB[0].className = "Frm_Txt_Hindi";

        var RBenglish = document.getElementById("rbOther");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "अन्य";
        RB[0].className = "Frm_Txt_Hindi";


        document.getElementById("lblMonth").innerHTML = "माह";
        document.getElementById("lblYear").innerHTML = "वर्ष";
        document.getElementById("btnFillPay").value = "पे बिल नं भरें";
        document.getElementById("lblPaybillNo").innerHTML = "पे बिल  नं.";
        document.getElementById("btnShow").value = "देखें ";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";

        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblMonth").className = "Frm_Txt_Hindi";
        document.getElementById("lblYear").className = "Frm_Txt_Hindi";
        document.getElementById("btnFillPay").className = "btn_Hindi";
        document.getElementById("lblPaybillNo").className = "Frm_Txt_Hindi";

        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";



    }
    if (Choice == 0 && FormId == 2356) {

        document.getElementById("LblHeader").innerHTML = "जी पी एफ अनुसूची";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbDeputation");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "प्रतिनियुक्ति";
        RB[0].className = "Frm_Txt_Hindi";

        var RBenglish = document.getElementById("rbOther");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "अन्य";
        RB[0].className = "Frm_Txt_Hindi";


        document.getElementById("lblMonth").innerHTML = "माह";
        document.getElementById("lblYear").innerHTML = "वर्ष";
        document.getElementById("btnFillPay").value = "पे बिल नं भरें";
        document.getElementById("lblPaybillNo").innerHTML = "पे बिल  नं.";
        document.getElementById("btnShow").value = "देखें ";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";

        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblMonth").className = "Frm_Txt_Hindi";
        document.getElementById("lblYear").className = "Frm_Txt_Hindi";
        document.getElementById("btnFillPay").className = "btn_Hindi";
        document.getElementById("lblPaybillNo").className = "Frm_Txt_Hindi";

        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";



    }
    if (Choice == 0 && FormId == 2357) {

        document.getElementById("LblHeader").innerHTML = "मिश्रित ई पी एफ सूची";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbDeputation");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "प्रतिनियुक्ति";
        RB[0].className = "Frm_Txt_Hindi";

        var RBenglish = document.getElementById("rbOther");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "अन्य";
        RB[0].className = "Frm_Txt_Hindi";

        document.getElementById("lblMonth").innerHTML = "माह";
        document.getElementById("lblYear").innerHTML = "वर्ष";
        document.getElementById("btnFillPay").value = "पे बिल नं भरें";
        document.getElementById("lblPaybillNo").innerHTML = "पे बिल  नं.";
        document.getElementById("btnShow").value = "देखें ";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";

        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblMonth").className = "Frm_Txt_Hindi";
        document.getElementById("lblYear").className = "Frm_Txt_Hindi";
        document.getElementById("btnFillPay").className = "btn_Hindi";
        document.getElementById("lblPaybillNo").className = "Frm_Txt_Hindi";
        
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";

    }
    if (Choice == 0 && FormId == 2353) {

        document.getElementById("LblHeader").innerHTML = "जी आई एस/एफ बी एफ कटौती अनुसूची";
        //        document.getElementById("hlHome").innerHTML = "होमपेज";
        //        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";

        var RBHindi = document.getElementById("rbDeputation");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "प्रतिनियुक्ति";
        RB[0].className = "Frm_Txt_Hindi";

        var RBenglish = document.getElementById("rbOther");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "अन्य";
        RB[0].className = "Frm_Txt_Hindi";

        document.getElementById("lblPaybillNo").innerHTML = "पे बिल नं.";
        document.getElementById("lblMonth").innerHTML = "माह";
        document.getElementById("lblYear").innerHTML = "वर्ष";
        document.getElementById("btnFillPay").value = "पे बिल नं भरें";
        document.getElementById("btnShow").value = "देखें ";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";



        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblPaybillNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblMonth").className = "Frm_Txt_Hindi";
        document.getElementById("lblYear").className = "Frm_Txt_Hindi";
        document.getElementById("btnFillPay").className = "btn_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";



    }

    if (Choice == 0 && FormId == 2377) {

        document.getElementById("LblHeader").innerHTML = "मकान किराया कटौती अनुसूची";
        //        document.getElementById("hlHome").innerHTML = "होमपेज";
        //        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";

        var RBHindi = document.getElementById("rbDeputation");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "प्रतिनियुक्ति";
        RB[0].className = "Frm_Txt_Hindi";

        var RBenglish = document.getElementById("rbOther");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "अन्य";
        RB[0].className = "Frm_Txt_Hindi";

        document.getElementById("lblPaybillNo").innerHTML = "पे बिल नं.";
        document.getElementById("lblMonth").innerHTML = "माह";
        document.getElementById("lblYear").innerHTML = "वर्ष";
        document.getElementById("btnFillPay").value = "पे बिल नं भरें";
        document.getElementById("btnShow").value = "देखें ";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";



        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblPaybillNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblMonth").className = "Frm_Txt_Hindi";
        document.getElementById("lblYear").className = "Frm_Txt_Hindi";
        document.getElementById("btnFillPay").className = "btn_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";



    }

    if (Choice == 0 && FormId == 2375) {

        document.getElementById("LblHeader").innerHTML = "अनाज अग्रिम कटौती अनुसूची";
        //        document.getElementById("hlHome").innerHTML = "होमपेज";
        //        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";

        var RBHindi = document.getElementById("rbDeputation");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "प्रतिनियुक्ति";
        RB[0].className = "Frm_Txt_Hindi";

        var RBenglish = document.getElementById("rbOther");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "अन्य";
        RB[0].className = "Frm_Txt_Hindi";

        document.getElementById("lblPaybillNo").innerHTML = "पे बिल नं.";
        document.getElementById("lblMonth").innerHTML = "माह";
        document.getElementById("lblYear").innerHTML = "वर्ष";
        document.getElementById("btnFillPay").value = "पे बिल नं भरें";
        document.getElementById("btnShow").value = "देखें ";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";



        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblPaybillNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblMonth").className = "Frm_Txt_Hindi";
        document.getElementById("lblYear").className = "Frm_Txt_Hindi";
        document.getElementById("btnFillPay").className = "btn_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";



    }

    if (Choice == 0 && FormId == 2376) {

        document.getElementById("LblHeader").innerHTML = "त्यौहार अग्रिम कटौती अनुसूची";
        //        document.getElementById("hlHome").innerHTML = "होमपेज";
        //        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";

        var RBHindi = document.getElementById("rbDeputation");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "प्रतिनियुक्ति";
        RB[0].className = "Frm_Txt_Hindi";

        var RBenglish = document.getElementById("rbOther");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "अन्य";
        RB[0].className = "Frm_Txt_Hindi";

        document.getElementById("lblPaybillNo").innerHTML = "पे बिल नं.";
        document.getElementById("lblMonth").innerHTML = "माह";
        document.getElementById("lblYear").innerHTML = "वर्ष";
        document.getElementById("btnFillPay").value = "पे बिल नं भरें";
        document.getElementById("btnShow").value = "देखें ";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";



        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblPaybillNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblMonth").className = "Frm_Txt_Hindi";
        document.getElementById("lblYear").className = "Frm_Txt_Hindi";
        document.getElementById("btnFillPay").className = "btn_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";



    }

    if (Choice == 0 && FormId == 2378) {

        document.getElementById("LblHeader").innerHTML = "बीमा कटौती की सूची";
        //        document.getElementById("hlHome").innerHTML = "होमपेज";
        //        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";

        var RBHindi = document.getElementById("rbDeputation");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "प्रतिनियुक्ति";
        RB[0].className = "Frm_Txt_Hindi";

        var RBenglish = document.getElementById("rbOther");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "अन्य";
        RB[0].className = "Frm_Txt_Hindi";

        document.getElementById("lblPaybillNo").innerHTML = "पे बिल नं.";
        document.getElementById("lblMonth").innerHTML = "माह";
        document.getElementById("lblYear").innerHTML = "वर्ष";
        document.getElementById("btnFillPay").value = "पे बिल नं भरें";
        document.getElementById("btnShow").value = "देखें ";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";



        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblPaybillNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblMonth").className = "Frm_Txt_Hindi";
        document.getElementById("lblYear").className = "Frm_Txt_Hindi";
        document.getElementById("btnFillPay").className = "btn_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";



    }

    if (Choice == 0 && FormId == 2380) {

        document.getElementById("LblHeader").innerHTML = "जी पी एफ चालान";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbDeputation");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "प्रतिनियुक्ति";
        RB[0].className = "Frm_Txt_Hindi";

        var RBenglish = document.getElementById("rbOther");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "अन्य";
        RB[0].className = "Frm_Txt_Hindi";


        document.getElementById("lblMonth").innerHTML = "पे बिल माह";
        document.getElementById("lblYear").innerHTML = "पे बिल वर्ष";
        document.getElementById("btnFillPay").value = "पे बिल नं भरें";
        document.getElementById("lblChallanNo").innerHTML = "पे बिल नं.";
        document.getElementById("btnShow").value = "देखें ";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";

        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblMonth").className = "Frm_Txt_Hindi";
        document.getElementById("lblYear").className = "Frm_Txt_Hindi";
        document.getElementById("btnFillPay").className = "btn_Hindi";
        document.getElementById("lblChallanNo").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";


    }


    
    //rpt_GIS_Challan Formid=2381
    if (Choice == 0 && FormId == 2381) {

        document.getElementById("LblHeader").innerHTML = "जी आई एस चालान";
//        document.getElementById("hlHome").innerHTML = "होमपेज";
//        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbDeputation");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "प्रतिनियुक्ति";
        RB[0].className = "Frm_Txt_Hindi";
        
        var RBenglish = document.getElementById("rbOther");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "अन्य";
        RB[0].className = "Frm_Txt_Hindi";

        
        document.getElementById("lblMonth").innerHTML = "पे बिल माह";
        document.getElementById("lblYear").innerHTML = "पे बिल वर्ष";
        document.getElementById("btnFillPay").value = "पे बिल नं भरें";
        document.getElementById("lblChallanNo").innerHTML = "पे बिल नं.";
        document.getElementById("btnShow").value = "देखें ";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";

        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblMonth").className = "Frm_Txt_Hindi";
        document.getElementById("lblYear").className = "Frm_Txt_Hindi";
        document.getElementById("btnFillPay").className = "btn_Hindi";
        document.getElementById("lblChallanNo").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";
        


    }
    //Firm id is = 2375 for the page rpt_grain_advance_recovery_schedule.aspx
//    if (Choice == 0 && FormId == 2375) {

//        document.getElementById("LblHeader").innerHTML = "अनाज अग्रिम कटौती अनुसूची";
//        document.getElementById("hlHome").innerHTML = "होमपेज";
//        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
//        // Hindi,English Radio button code
//        var RBHindi = document.getElementById("rbDeputation");
//        var RB = RBHindi.parentNode.getElementsByTagName("label");
//        RB[0].innerHTML = "प्रतिनियुक्ति";

//        var RBenglish = document.getElementById("rbOther");
//        var RB = RBenglish.parentNode.getElementsByTagName("label");
//        RB[0].innerHTML = "अन्य";



//        document.getElementById("btnShow").value = "देखें ";
//        document.getElementById("btnPrint").value = "प्रिंट करें";
//        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";

//        document.getElementById("lblMonth").innerHTML = "माह";
//        document.getElementById("lblYear").innerHTML = "वर्ष";

//        //========Hindi Text========//
//        document.getElementById("lblheader").className = "Frm_Head_Hindi";
//        document.getElementById("btnShow").className = "btn_Hindi";
//        document.getElementById("btnPrint").className = "btn_Hindi";
//        document.getElementById("btnSaveasExcel").className = "btn_Hindi";
//        document.getElementById("lblMonth").className = "Frm_Txt_Hindi";
//        document.getElementById("lblYear").className = "Frm_Txt_Hindi";


//    }


//    if (Choice == 0 && FormId == 2356) {

//        document.getElementById("LblHeader").innerHTML = "GPF SCHEDULE";
//        document.getElementById("hlHome").innerHTML = "होमपेज";
//        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
//        // Hindi,English Radio button code
//        var RBHindi = document.getElementById("rbDeputation");
//        var RB = RBHindi.parentNode.getElementsByTagName("label");
//        RB[0].innerHTML = "प्रतिनियुक्ति";

//        var RBenglish = document.getElementById("rbOther");
//        var RB = RBenglish.parentNode.getElementsByTagName("label");
//        RB[0].innerHTML = "अन्य";



//        document.getElementById("btnShow").value = "देखें ";
//        document.getElementById("btnPrint").value = "प्रिंट करें";
//        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";

//        document.getElementById("lblPaybillNo").innerHTML = "पे बिल  नं.";
//        document.getElementById("lblMonth").innerHTML = "माह";
//        document.getElementById("lblYear").innerHTML = "वर्ष";

//        //========Hindi Text========//
//        document.getElementById("lblheader").className = "Frm_Head_Hindi";
//        document.getElementById("btnShow").className = "btn_Hindi";
//        document.getElementById("btnPrint").className = "btn_Hindi";
//        document.getElementById("btnSaveasExcel").className = "btn_Hindi";
//        document.getElementById("lblPaybillNo").className = "Frm_Txt_Hindi";
//        document.getElementById("lblMonth").className = "Frm_Txt_Hindi";
//        document.getElementById("lblYear").className = "Frm_Txt_Hindi";


//    }
    // TBC_Transaction / frm_Cr_FOR_IV.aspx
    if (Choice == 0 && FormId == 2371) {

        document.getElementById("lblheader").innerHTML = "चतुर्थ श्रेणी के लिये सी.आर.फार्म (गोपनीय प्रतिवेदन)";
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

        if (document.getElementById("lblReferenceNo") != null) {
            document.getElementById("lblReferenceNo").innerHTML = "रिफरेंस न. ";
            document.getElementById("lblReferenceNo").className = "Frm_Txt_Hindi";
        }
        
        document.getElementById("lbldate").innerHTML = "दिनांक ";
        document.getElementById("lblempname").innerHTML = "1. कर्मचारी का नाम  ";
        document.getElementById("lbldesignation").innerHTML = "2. पद स्थाई /अस्थाई ";
        document.getElementById("lbldateofappointmentel").innerHTML = "3. नियुक्ति की दिनांक";
        document.getElementById("lblpayment").innerHTML = "4. वेतन ";
        document.getElementById("lblworkplace").innerHTML = "5. कार्य स्थान ";

        document.getElementById("lblduration").innerHTML = "6. अवधि जिसके लिये मत अंकित किया जा रहा है ";
        document.getElementById("lblconductbehaviour").innerHTML = "7. आचरण,व्यवहार तथा आज्ञाकारिता  ";
        document.getElementById("lblpunctuality").innerHTML = "8.समय की पाबन्दी ";
        document.getElementById("lblphysicalability").innerHTML = "9 .शारीरिक क्षमता ";
        document.getElementById("lblunderstanding").innerHTML = "10.सौंपे गये कार्य को करने की समझ और योग्यता  ";
        document.getElementById("lblgeneralremark").innerHTML = "11. स्थानांतरण दण्ड आदि के सम्बन्ध मे सामन्य मत ";

        document.getElementById("lblremarkdate").innerHTML = "प्रतिक्रिया दिनांक";
        document.getElementById("lblRemark").innerHTML = "रिमार्क ";
        document.getElementById("lblForwarededFor").innerHTML = "प्रतिक्रिया";
        document.getElementById("lblForwardTo").innerHTML = "अग्रेषित कर्मचारी";

        document.getElementById("btnsave").value = "रक्षित करें ";
        document.getElementById("btncancel").value = "रद्द करें ";
        //========Hindi Text========//
        document.getElementById("lblheader").className = "Frm_Head_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";

        document.getElementById("btnsave").className = "btn_Hindi";
        document.getElementById("btncancel").className = "btn_Hindi";



       
        document.getElementById("lbldate").className = "Frm_Txt_Hindi";
        document.getElementById("lblempname").className = "Frm_Txt_Hindi";

        document.getElementById("lbldesignation").className = "Frm_Txt_Hindi";
        document.getElementById("lbldateofappointmentel").className = "Frm_Txt_Hindi";
        document.getElementById("lblpayment").className = "Frm_Txt_Hindi";

        document.getElementById("lblworkplace").className = "Frm_Txt_Hindi";
        document.getElementById("lblduration").className = "Frm_Txt_Hindi";
        document.getElementById("lblconductbehaviour").className = "Frm_Txt_Hindi";


        document.getElementById("lblpunctuality").className = "Frm_Txt_Hindi";
        document.getElementById("lblphysicalability").className = "Frm_Txt_Hindi";
        document.getElementById("lblunderstanding").className = "Frm_Txt_Hindi";


        document.getElementById("lblgeneralremark").className = "Frm_Txt_Hindi";
        document.getElementById("lblremarkdate").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemark").className = "Frm_Txt_Hindi";


        document.getElementById("lblForwarededFor").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwardTo").className = "Frm_Txt_Hindi";
    }

    // TBC_Transaction / frm_pay_Fixation.aspx
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
       
        document.getElementById("lblOldVetanmaan").innerHTML = "पूर्व वेतन-मान ";
        document.getElementById("lblNewVetanmaan").innerHTML = "नया वेतन-मान ";
//        document.getElementById("lblEmoluments").innerHTML = "कुल परिलब्धिया ";
        document.getElementById("lblSenctional").innerHTML = "दिनांक";
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
    // TBC_Transaction / frm_Dispatch_Register.aspx
    if (Choice == 0 && FormId == 2368) {

        document.getElementById("LblHeader").innerHTML = "डिस्पेच रजिस्टर एंट्री";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("btNnew").value = "नया बनायें";
        document.getElementById("BtnEdit").value = "सुधारे ";
        if (document.getElementById("lblDispatchRefno")!= null) {
            document.getElementById("lblDispatchRefno").innerHTML = " डिस्पेच रिफरेंस नं.";
            document.getElementById("lblDispatchRefno").className = "Frm_Txt_Hindi";
        }
        
        document.getElementById("lblDate").innerHTML = "दिनांक ";
        document.getElementById("lblName").innerHTML = "नाम";
        document.getElementById("lblAddress").innerHTML = "पता";
        document.getElementById("lblPlace").innerHTML = "स्थान";
        document.getElementById("lblSubject").innerHTML = "विषय";
        document.getElementById("lblFileHeadNo").innerHTML = "फाइल का नाम/ नं.";
        document.getElementById("lblStampReceived").innerHTML = "प्राप्त स्टाम्प";
        document.getElementById("lblStampAffixed").innerHTML = "संलग्न स्टाम्प";
        document.getElementById("lblStampBalance").innerHTML = "बचे हुये स्टाम्प";
        document.getElementById("lblRemark").innerHTML = "रिमार्क";
        document.getElementById("btnsave").value = "रक्षित करें ";

        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btNnew").className = "btn_Hindi";
        document.getElementById("BtnEdit").className = "btn_Hindi";
        document.getElementById("lblDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblName").className = "Frm_Txt_Hindi";
        document.getElementById("lblAddress").className = "Frm_Txt_Hindi";
        document.getElementById("lblPlace").className = "Frm_Txt_Hindi";
        document.getElementById("lblSubject").className = "Frm_Txt_Hindi";
        document.getElementById("lblFileHeadNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblStampReceived").className = "Frm_Txt_Hindi";
        document.getElementById("lblStampAffixed").className = "Frm_Txt_Hindi";
        document.getElementById("lblStampBalance").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemark").className = "Frm_Txt_Hindi";
        document.getElementById("btnsave").className = "btn_Hindi";

    }
    // TBC_Transaction / frm_Letter_Receipt_Register.aspx
    if (Choice == 0 && FormId == 2367) {

        document.getElementById("LblHeader").innerHTML = "पत्र प्राप्ति पंजी";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";

        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";

        document.getElementById("btnnew").value = "नया बनायें";
        document.getElementById("Btnedit").value = "सुधारे ";

        if (document.getElementById("lblLetterRefno") != null)
        {
            document.getElementById("lblLetterRefno").innerHTML = " पत्र प्राप्ति रिफरेंस न.";
            document.getElementById("lblLetterRefno").className = "Frm_Txt_Hindi";
        }
        
        document.getElementById("lblReceivingDate").innerHTML = " प्राप्ति दिनांक ";
        document.getElementById("lblRefNo").innerHTML = "पत्र रिफरेंस नं.";
        document.getElementById("lblLetterDate").innerHTML = "दिनांक";
        document.getElementById("lblWhomReceived").innerHTML = "जिससे प्राप्त किया";
        document.getElementById("lblSubject").innerHTML = "विषय";
        document.getElementById("lblFileHeadNo").innerHTML = "फाइल का नाम/ नं.";
        document.getElementById("lblDisposal").innerHTML = "आदेश";
        document.getElementById("btnsave").value = "रक्षित करें ";

        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnnew").className = "btn_Hindi";
        document.getElementById("Btnedit").className = "btn_Hindi";
                
        document.getElementById("lblReceivingDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblRefNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblLetterDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblWhomReceived").className = "Frm_Txt_Hindi";
        document.getElementById("lblSubject").className = "Frm_Txt_Hindi";
        document.getElementById("lblFileHeadNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblDisposal").className = "Frm_Txt_Hindi";
        document.getElementById("btnsave").className = "btn_Hindi";

    }
    //TBC_Transaction / frm_Leave_Encashment.aspx
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
        document.getElementById("btnCount").value = "गणना";
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
        //        document.getElementById("lblLeaveEncashmentRefNo")
        document.getElementById("lblDate").className = "Frm_Txt_Hindi";
        document.getElementById("lbl_ApplicantInfo").className = "Frm_Txt_Hindi";
        document.getElementById("lblPost").className = "Frm_Txt_Hindi";
        document.getElementById("lblEmployeeName").className = "Frm_Txt_Hindi";
        document.getElementById("lblAppointmentDt").className = "Frm_Txt_Hindi";
        document.getElementById("lblPayBand").className = "Frm_Txt_Hindi";
        document.getElementById("lblRetirementDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblSalary").className = "Frm_Txt_Hindi";
        document.getElementById("lblGradePay").className = "Frm_Txt_Hindi";
        document.getElementById("lblDA").className = "Frm_Txt_Hindi";
        document.getElementById("lblEmoluments").className = "Frm_Txt_Hindi";
        document.getElementById("btnCount").className = "btn_Hindi";
        document.getElementById("lblSenctional").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemark").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwarededFor").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwardTo").className = "Frm_Txt_Hindi";
         
    }
    //TBC_Transaction / frm_Arrear_Fixation.aspx
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
        document.getElementById("lblSenctional").innerHTML = "दिनांक";
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
        document.getElementById("lblDate").innerHTML = "दिनांक";
        document.getElementById("lblPost").innerHTML = "पद का नाम  ";
        document.getElementById("lblEmployeeName").innerHTML = "कर्मचारी का नाम ";
        document.getElementById("lblAppointmentDt").innerHTML = "नियुक्ति दिनांक";
        document.getElementById("lblPayBand").innerHTML = "पे-बैंड";
        document.getElementById("lblRetirementDate").innerHTML = "मृत्यु / सेवानिवृत्ति दिनांक ";
        document.getElementById("lblSalary").innerHTML = "मूल वेतन";
        document.getElementById("lblGradePay").innerHTML = "वेतन-मान";
        document.getElementById("lblDA").innerHTML = "डी.ए.";
        document.getElementById("lblEmoluments").innerHTML = "कुल परिलब्धिया ";
        document.getElementById("btnCount").value = "गणना";
        document.getElementById("lblSenctional").innerHTML = "दिनांक";
        document.getElementById("lblRemark").innerHTML = "रिमार्क ";
        document.getElementById("lblForwarededFor").innerHTML = "प्रतिक्रिया";
        document.getElementById("lblForwardTo").innerHTML = "अग्रेषित कर्मचारी";
        document.getElementById("lblPaymentMode").innerHTML = "भुगतान का तरीका";
        document.getElementById("lblcompletedyear").innerHTML = "सेवा के वर्ष ";
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
        document.getElementById("lblAppointmentDt").className = "Frm_Txt_Hindi";
        document.getElementById("lblPayBand").className = "Frm_Txt_Hindi";
        document.getElementById("lblRetirementDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblSalary").className = "Frm_Txt_Hindi";
        document.getElementById("lblGradePay").className = "Frm_Txt_Hindi";
        document.getElementById("lblDA").className = "Frm_Txt_Hindi";
        document.getElementById("lblEmoluments").className = "Frm_Txt_Hindi";
        document.getElementById("btnCount").className = "btn_Hindi";
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
    //TBC_Transaction / frm_Cr_FOR_I.aspx
    if (Choice == 0 && FormId == 2369) {

        document.getElementById("lblheader").innerHTML = "प्रथम एवं द्वितीय श्रेणी के लिये सी.आर. फॉर्म (गोपनीय प्रतिवेदन)";
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
        if (document.getElementById("lblReferenceNo") != null) {
            document.getElementById("lblReferenceNo").innerHTML = "रिफरेंस न.";
            document.getElementById("lblReferenceNo").className = "Frm_Txt_Hindi";
        }
        document.getElementById("lbldate").innerHTML = "दिनांक";
        document.getElementById("lblyear").innerHTML = "अवधि के लिये";   
        document.getElementById("lblempname").innerHTML = "कर्मचारी का नाम ";
        document.getElementById("lblpost").innerHTML = "पद का नाम  ";
        document.getElementById("lbltypeofemployement").innerHTML = "एम्प्लॉयमेंट का प्रकार";
        document.getElementById("lblpostinglocation").innerHTML = "पोस्टिंग स्थान";
        document.getElementById("lblremarkdate").innerHTML = "प्रतिक्रिया दिनांक";
        document.getElementById("lblRemark").innerHTML = "रिमार्क ";
        document.getElementById("lblForwarededFor").innerHTML = "प्रतिक्रिया";
        document.getElementById("lblForwardTo").innerHTML = "अग्रेषित कर्मचारी";
        document.getElementById("btnsave").value = "रक्षित करें ";
        document.getElementById("btncancel").value = "रद्द करें ";
        //        document.getElementById("btnSave").value = "रक्षित करें ";
        //        document.getElementById("btnCount").value = "रद्द करें ";
        //========Hindi Text========//
        document.getElementById("lblheader").className = "Frm_Head_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("lbldate").className = "Frm_Txt_Hindi";
        document.getElementById("lblyear").className = "Frm_Txt_Hindi";
        document.getElementById("lblempname").className = "Frm_Txt_Hindi";
        document.getElementById("lblpost").className = "Frm_Txt_Hindi";
        document.getElementById("lbltypeofemployement").className = "Frm_Txt_Hindi";
        document.getElementById("lblpostinglocation").className = "Frm_Txt_Hindi";
        document.getElementById("lblremarkdate").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemark").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwarededFor").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwardTo").className = "Frm_Txt_Hindi";
        document.getElementById("btnsave").className = "btn_Hindi";
        document.getElementById("btncancel").className = "btn_Hindi";
        
        //Grid Code

        var table = document.getElementById("GvTargetAchieve");
        var tr = table.rows[0];
        tr.cells[0].innerHTML = "चुनिये";
        tr.cells[1].innerHTML = "हटाएँ ";
        tr.cells[2].innerHTML = "लक्ष्य";
        tr.cells[3].innerHTML = "उपलब्धि";
        
        //============Hindi Text================//
        tr.cells[0].className = "Frm_Txt_Hindi";
        tr.cells[1].className = "Frm_Txt_Hindi";
        tr.cells[2].className = "Frm_Txt_Hindi";
        tr.cells[3].className = "Frm_Txt_Hindi";
        
    }

    // TBC_Transaction/frm_Cr_FOR_III.aspx
    if (Choice == 0 && FormId == 2370) {

        document.getElementById("lblheader").innerHTML = "तृतीय श्रेणी के लिये सी.आर.फार्म (गोपनीय प्रतिवेदन)";
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

        if (document.getElementById("lblReferenceNo") != null) {
            document.getElementById("lblReferenceNo").innerHTML = "रिफरेंस न. ";
            document.getElementById("lblReferenceNo").className = "Frm_Txt_Hindi";
        }
        
        document.getElementById("lblyear").innerHTML = "वर्ष";
        document.getElementById("lbldate").innerHTML = "दिनांक ";
        document.getElementById("lblempname").innerHTML = "1. कर्मचारी का नाम  ";
        document.getElementById("lbldesignation").innerHTML = "2. धारित पद मूल /स्थापन्न अस्थाई ";
        document.getElementById("lbldateofappointmentel").innerHTML = "3. नियुक्ति की दिनांक";
        document.getElementById("lblsalary").innerHTML = "4. वेतन ";
        document.getElementById("lblbehaviour").innerHTML = "5.व्यक्तित्व और  व्यवहार ";
        document.getElementById("lblphysicalability").innerHTML = "6.शारीरिक क्षमता ";
        document.getElementById("lblinteligence").innerHTML = "7.बुद्धिमत्ता और पहलशक्ति ";
        document.getElementById("lblability").innerHTML = "8.प्रारुप और टीप लिखने की क्षमता ";
        document.getElementById("lblCasetesting").innerHTML = "9. प्रकरण के परीक्षण कि क्षमता  ";
        document.getElementById("lblreadiness").innerHTML = "10. कार्य के निपटाने की तत्परता  ";

        document.getElementById("lblconductcharacter").innerHTML = "11. आचरण / चरित्र ";
        document.getElementById("lblreasonforpersonal").innerHTML = "12. ऋणग्रस्ततः यह बताया जाना चाहिये कि ऋण के सम्बन्ध मे निजी तौर पर कहाँ तक उत्तरदायी है   ";
        document.getElementById("lblpunishment").innerHTML = "13 . प्रतिवेदनाधीन अवधि मे दण्ड,निन्दा,विशेष  कर्मचारी  की पिछली रिपोर्ट के बाद प्रतिकूल  टिप्पणी  की जाने कि दिनांक  ";
        document.getElementById("lblpromotion").innerHTML = "14 . पदोन्नति दक्षतारोध पार करने की उपयुक्तता  टिप्पणी ";
//        document.getElementById("lblplace").innerHTML = "स्थान ";



        document.getElementById("lblremarkdate").innerHTML = "प्रतिक्रिया दिनांक";
        document.getElementById("lblRemark").innerHTML = "रिमार्क ";
        document.getElementById("lblForwarededFor").innerHTML = "प्रतिक्रिया";
        document.getElementById("lblForwardTo").innerHTML = "अग्रेषित कर्मचारी";

        document.getElementById("btnsave").value = "रक्षित करें ";
        document.getElementById("btncancel").value = "रद्द करें ";
        //========Hindi Text========//
        document.getElementById("lblheader").className = "Frm_Head_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";

        document.getElementById("btnsave").className = "btn_Hindi";
        document.getElementById("btncancel").className = "btn_Hindi";



//        document.getElementById("lblReferenceNo").className = "Frm_Txt_Hindi";
        document.getElementById("lbldate").className = "Frm_Txt_Hindi";
        document.getElementById("lblempname").className = "Frm_Txt_Hindi";

        document.getElementById("lblyear").className = "Frm_Txt_Hindi";
        document.getElementById("lbldesignation").className = "Frm_Txt_Hindi";
        document.getElementById("lbldateofappointmentel").className = "Frm_Txt_Hindi";
        document.getElementById("lblsalary").className = "Frm_Txt_Hindi";
        document.getElementById("lblbehaviour").className = "Frm_Txt_Hindi";
        document.getElementById("lblphysicalability").className = "Frm_Txt_Hindi";

        document.getElementById("lblinteligence").className = "Frm_Txt_Hindi";
        document.getElementById("lblability").className = "Frm_Txt_Hindi";
        document.getElementById("lblCasetesting").className = "Frm_Txt_Hindi";
        document.getElementById("lblreadiness").className = "Frm_Txt_Hindi";
        document.getElementById("lblconductcharacter").className = "Frm_Txt_Hindi";
        document.getElementById("lblreasonforpersonal").className = "Frm_Txt_Hindi";
        document.getElementById("lblpunishment").className = "Frm_Txt_Hindi";
        document.getElementById("lblpromotion").className = "Frm_Txt_Hindi";

        document.getElementById("lblremarkdate").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemark").className = "Frm_Txt_Hindi";
//        document.getElementById("lblplace").className = "Frm_Txt_Hindi";

        document.getElementById("lblForwarededFor").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwardTo").className = "Frm_Txt_Hindi";
    }

    //TBC_Transaction / frm_Cr_FOR_I.aspx
    if (Choice == 0 && FormId == 2372) {

        document.getElementById("LblHeader").innerHTML = "कर्मचारियों का प्रशिक्षण";
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
            document.getElementById("lblArrearRefNo1").innerHTML = "रिफरेंस न.";
            document.getElementById("lblArrearRefNo1").className = "Frm_Txt_Hindi";
        }
        document.getElementById("lblsubject").innerHTML = "प्रशिक्षण का विषय";
        document.getElementById("lblPeriod").innerHTML = "प्रशिक्षण अवधि";
        document.getElementById("lblTo").innerHTML = "से";
        document.getElementById("lblPlace").innerHTML = "प्रशिक्षण का स्थान";
        document.getElementById("lblTrainingName").innerHTML = "प्रशिक्षक का नाम";
        document.getElementById("lblPost").innerHTML = "पद का नाम ";
        document.getElementById("lblEmployeeName").innerHTML = "कर्मचारी का नाम ";
        document.getElementById("btnAdd").value = "जोडें";
        document.getElementById("btnForward").value = "रक्षित करें ";
        document.getElementById("btnCancel").value = "रद्द करें ";
        //        document.getElementById("btnSave").value = "रक्षित करें ";
        //        document.getElementById("btnCount").value = "रद्द करें ";
        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("lbldate").className = "Frm_Txt_Hindi";
        document.getElementById("lblyear").className = "Frm_Txt_Hindi";
        document.getElementById("lblempname").className = "Frm_Txt_Hindi";
        document.getElementById("lblpost").className = "Frm_Txt_Hindi";
        document.getElementById("lbltypeofemployement").className = "Frm_Txt_Hindi";
        document.getElementById("lblpostinglocation").className = "Frm_Txt_Hindi";
        document.getElementById("lblremarkdate").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemark").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwarededFor").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwardTo").className = "Frm_Txt_Hindi";
        document.getElementById("btnsave").className = "btn_Hindi";
        document.getElementById("btncancel").className = "btn_Hindi";

    }
    //TBC_Transaction / frm_Grant_Amount.aspx
    if (Choice == 0 && FormId == 2373) {

        document.getElementById("LblHeader").innerHTML = "अनुदान राशि";
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
        if (document.getElementById("lblGrantAmountRefNo") != null) {
            document.getElementById("lblGrantAmountRefNo").innerHTML = "अनुदान राशि रिफरेंस न. ";
            document.getElementById("lblGrantAmountRefNo").className = "Frm_Txt_Hindi";
        }
        document.getElementById("lbl_ApplicantInfo").innerHTML = "आवेदन की जानकारी";
        document.getElementById("lblDate").innerHTML = "दिनांक";
        document.getElementById("lblPost").innerHTML = "पद का नाम  ";
        document.getElementById("lblEmployeeName").innerHTML = "कर्मचारी का नाम ";  
        document.getElementById("lblPayBand").innerHTML = "पे-बैंड";
        document.getElementById("lblRetirementDate").innerHTML = "मृत्यु / सेवानिवृत्ति दिनांक ";
        document.getElementById("lblSalary").innerHTML = "मूल वेतन";
        document.getElementById("lblGradePay").innerHTML = "वेतन-मान";     
        document.getElementById("lblEmoluments").innerHTML = "कुल परिलब्धिया ";
        document.getElementById("btnCount").value = " गणना";
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

        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("lbl_ApplicantInfo").className = "Frm_Txt_Hindi";
        document.getElementById("lblDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblPost").className = "Frm_Txt_Hindi";
        document.getElementById("lblEmployeeName").className = "Frm_Txt_Hindi";
        //document.getElementById("lblAppointmentDt").className = "Frm_Txt_Hindi";
        document.getElementById("lblPayBand").className = "Frm_Txt_Hindi";
        document.getElementById("lblRetirementDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblSalary").className = "Frm_Txt_Hindi";
        document.getElementById("lblGradePay").className = "Frm_Txt_Hindi";
        document.getElementById("lblDA").className = "Frm_Txt_Hindi";
        document.getElementById("lblEmoluments").className = "Frm_Txt_Hindi";
        document.getElementById("btnCount").className = "btn_Hindi";
        document.getElementById("lblSenctional").className = "Frm_Txt_Hindi";
        document.getElementById("lblRemark").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwarededFor").className = "Frm_Txt_Hindi";
        document.getElementById("lblForwardTo").className = "Frm_Txt_Hindi";
        document.getElementById("LblSelectBank").className = "Frm_Txt_Hindi";
        document.getElementById("lblCheque").className = "Frm_Txt_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";


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

        var RBContractPay = document.getElementById("Rdb_ContractPay");
        var RBC = RBContractPay.parentNode.getElementsByTagName("label");
        RBC[0].innerHTML = "कोन्ट्रेकटर  भुगतान";

        var RBProfessionalPay = document.getElementById("Rdb_Professional");
        var RBP = RBProfessionalPay.parentNode.getElementsByTagName("label");
        RBP[0].innerHTML = "प्रोफेशनल भुगतान";

        var RBRentPay = document.getElementById("Rdb_Rent");
        var RBR = RBRentPay.parentNode.getElementsByTagName("label");
        RBR[0].innerHTML = "किराया भुगतान";

        document.getElementById("btnNew").value = "नया ";
        document.getElementById("btnEdit").value = "सुधारे ";
        document.getElementById("btnSave").value = "रक्षित करें ";
        document.getElementById("btnCancel").value = "रद्द करें ";
        document.getElementById("btnShowBudget").value = "बजट देखें";
        document.getElementById("Btnsh").value = "देखें";
        document.getElementById("btnCalTAX").value = "टी डी एस गणना ";
        document.getElementById("lblDate").innerHTML = "दस्तावेज दिनांक ";
        document.getElementById("lblAccountHead").innerHTML = "भुगतान मद";
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
        document.getElementById("lblSupplierEmpType").innerHTML = "भुगतान पाने वाले का प्रकार ";
        document.getElementById("lblSupplierEmpName").innerHTML = " भुगतान पाने वाले का नाम";
        document.getElementById("lblAdvanceAmt").innerHTML = "अग्रिम समायोजन की राशि";
        document.getElementById("lblPaymentAmt").innerHTML = "भुगतान राशि";
        document.getElementById("lblSenctional").innerHTML = "प्रतिक्रिया दिनांक";
        document.getElementById("lblRemark").innerHTML = "रिमार्क ";
        document.getElementById("lblForwarededFor").innerHTML = "प्रतिक्रिया";
        document.getElementById("lblForwardTo").innerHTML = "अग्रेषित कर्मचारी"; 
        document.getElementById("lblPaymentMode").innerHTML = "भुगतान का तरीका";
        document.getElementById("lbl_ApplicantInfo").innerHTML = "भुगतान की जानकारी ";

        document.getElementById("btnAddAgency").value = "ऐजेंसी बनाऐं";
        document.getElementById("btnAddAgency").className = "btn_Hindi";

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

        document.getElementById("lblGeneralBillRefNo").innerHTML = " सामान्य बिल भुगतान रिफरेंस न.";
        document.getElementById("lnkViewOrder").innerHTML = "अपलोड बिल देखेँ ";
        
       



        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("btnNew").className = "btn_Hindi";
        document.getElementById("btnEdit").className = "btn_Hindi";
        document.getElementById("btnSave").className = "btn_Hindi";
        document.getElementById("btnCalTAX").className = "btn_Hindi";
        document.getElementById("btnCancel").className = "btn_Hindi";  
        document.getElementById("btnShowBudget").className = "btn_Hindi";
        document.getElementById("Btnsh").className = "btn_Hindi"; 
        document.getElementById("lblDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblAccountHead").className = "Frm_Txt_Hindi";
        document.getElementById("lblObjectHead").className = "Frm_Txt_Hindi";
        document.getElementById("lblSupplierProviderType").className = "Frm_Txt_Hindi";
        document.getElementById("lblSupplierProvider").className = "Frm_Txt_Hindi";
        document.getElementById("lblDescription").className = "Frm_Txt_Hindi";
        document.getElementById("lblUploadBill").className = "Frm_Txt_Hindi";
        document.getElementById("lblAmount").className = "Frm_Txt_Hindi";
        document.getElementById("lblVAT").className = "Frm_Txt_Hindi";
        document.getElementById("lblServiceTax").className = "Frm_Txt_Hindi";
        document.getElementById("lblGrossBillAmt").className = "Frm_Txt_Hindi";
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
        document.getElementById("lblGeneralBillRefNo").className = "Frm_Txt_Hindi";
        document.getElementById("lbl_ApplicantInfo").className = "Frm_Txt_Hindi";

    }
    if (Choice == 0 && FormId == 2610) {
        document.getElementById("LblHeader").innerHTML = "डैश बोर्ड";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbHindi");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "हिन्दी";
        
        var RBenglish = document.getElementById("rbenglish");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "English";


        var RBPending = document.getElementById("Rdb_Pending");
        var RB = RBPending.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "पेंडिग";

        var RBAll = document.getElementById("Rdb_AllDoc");
        var RB = RBAll.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "सभी";

        document.getElementById("btnShow").value = "देखें";
        document.getElementById("lblFromDate").innerHTML = "दिनांक से";
        document.getElementById("lblToDate").innerHTML = "दिनांक तक";
        document.getElementById("lblPageSelection").innerHTML = "आवेदन का प्रकार";           

        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblFromDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblToDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblPageSelection").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";

    }
    //Firm id is = 2386 for the page rpt_Medical_Advance_recovery_Schedule.aspx
    if (Choice == 0 && FormId == 2386) {

        document.getElementById("LblHeader").innerHTML = "चिकित्सा अग्रिम कटौती अनुसूची";
        document.getElementById("hlHome").innerHTML = "होमपेज";
        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        var RBHindi = document.getElementById("rbDeputation");
        var RB = RBHindi.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "प्रतिनियुक्ति";

        var RBenglish = document.getElementById("rbOther");
        var RB = RBenglish.parentNode.getElementsByTagName("label");
        RB[0].innerHTML = "अन्य";



        document.getElementById("btnShow").value = "देखें ";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";
        document.getElementById("lblMonth").innerHTML = "माह";
        document.getElementById("lblYear").innerHTML = "वर्ष";
        document.getElementById("btnFillPay").value = "पे बिल नं भरें";
        document.getElementById("lblPaybillNo").innerHTML = "पे बिल  नं.";

        //========Hindi Text========//
        document.getElementById("lblheader").className = "Frm_Head_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";
        document.getElementById("lblMonth").className = "Frm_Txt_Hindi";
        document.getElementById("lblYear").className = "Frm_Txt_Hindi";
        document.getElementById("btnFillPay").className = "btn_Hindi";
        document.getElementById("lblPaybillNo").className = "Frm_Txt_Hindi";
    }
    //Firm id is = 2389 for the page rpt_Dispatch_Register.aspx
    if (Choice == 0 && FormId == 2389) {
        
        document.getElementById("LblHeader").innerHTML = "डिस्पेच रजिस्टर";
        //        document.getElementById("hlHome").innerHTML = "होमपेज";
        //        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code
        //var RBHindi = document.getElementById("rbDeputation");
        //var RB = RBHindi.parentNode.getElementsByTagName("label");
        //RB[0].innerHTML = "प्रतिनियुक्ति";
        //RB[0].className = "Frm_Txt_Hindi";

        //var RBenglish = document.getElementById("rbOther");
        //var RB = RBenglish.parentNode.getElementsByTagName("label");
        //RB[0].innerHTML = "अन्य";
        //RB[0].className = "Frm_Txt_Hindi";


        document.getElementById("lblReferenceNo").innerHTML = "डिस्पेच रिफरेंस नं.";
        document.getElementById("lblFromDate").innerHTML = "प्रारंभ दिनांक";
        document.getElementById("lblToDate").innerHTML = "अंतिम दिनांक";
        document.getElementById("btnShow").value = "देखें ";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";

        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblReferenceNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblFromDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblToDate").className = "Frm_Txt_Hindi";
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";



    }
    
    //Firm id is = 2390 for the page rpt_letter_receipt.aspx
    if (Choice == 0 && FormId == 2390) {

        document.getElementById("LblHeader").innerHTML = "पत्र प्राप्ति रजिस्टर";
        //        document.getElementById("hlHome").innerHTML = "होमपेज";
        //        document.getElementById("hlLogoff").innerHTML = "लॉगआउट";
        // Hindi,English Radio button code

        document.getElementById("lblReferenceNo").innerHTML = "पत्र प्राप्ति रिफरेंस नं.";
        document.getElementById("lblFromDate").innerHTML = "प्रारंभ दिनांक";
        
        document.getElementById("lblToDate").innerHTML = "अंतिम दिनांक";
        document.getElementById("btnShow").value = "देखें ";
        document.getElementById("btnPrint").value = "प्रिंट करें";
        document.getElementById("btnSaveasExcel").value = "एक्सेल में रक्षित करें";

        //========Hindi Text========//
        document.getElementById("LblHeader").className = "Frm_Head_Hindi";
        document.getElementById("lblReferenceNo").className = "Frm_Txt_Hindi";
        document.getElementById("lblFromDate").className = "Frm_Txt_Hindi";
        document.getElementById("lblToDate").className = "Frm_Txt_Hindi";
        
        document.getElementById("btnShow").className = "btn_Hindi";
        document.getElementById("btnPrint").className = "btn_Hindi";
        document.getElementById("btnSaveasExcel").className = "btn_Hindi";



    }
}