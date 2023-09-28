//================== All Header Icon Code Start ===================//
var GlobalLanguage;
function ChangeClass(Domain, Choice) {
    burstCache();
    history.go(1);
    GlobalLanguage = Choice;
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
function burstCache() {
    if (!navigator.onLine) {
        document.body.innerHTML = 'Loading...';
        window.location = 'ErrorPage.html';
    }
}
//================== All Header Icon Code End ===================//


//================== All Banner Code Start ===================//
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
//================== All Banner Code End ===================//



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
//=============== All WaterMark Function End ===============//


//=====Branch,function functionary, Category ,scheme Show and Hide Code Start ========//
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
            alert("From date must be less than to date.");
        } else {
            alert("प्रांरभ दिनांक, अतिंम दिनांक से छोटी होना चाहिये ।");
        }
        document.getElementById(FromDate).value = "";
        return false;
    }
    else {
        return true;
    }
}
//Function For Special Characters are Not Allowed in text box. For it pass text box object
function SpecialCharNotAllow(that, e) {
    try {
        var LedgerNameObj = document.getElementById(that.id);
        var LedgerName = document.getElementById(that.id).value;

        var i;
       // var car = e.charCode;
        var key = e.keyCode
        //if (key == 8 || (key >= 48 && key < 58) || (key >= 65 && key <= 90) || (key == 110 || key == 190 || key == 9 || key == 8 || key == 46 || key == 13) || (key >= 37 && key <= 40) || key == 46) {
        if (key == "106") {
            LedgerNameVal = LedgerName.substring(0, LedgerNameVal.length - 1);
            return false;
        }


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
            if (e.shiftKey || key == 222) {
                if (key == 16 || (key >= 49 && key <= 58) || key == 188 || key == 190 || key == 219 || key == 221 || key == 192 || key == 222) {
                    LedgerNameObj.value = '';
                    for (i = 0; i <= (LedgerName.length - 1); i++) {
                        var LedgerNameVal = '';

                        LedgerNameVal = LedgerName.substring(i, i + 1);

                        // if ((LedgerNameVal == '~') || (LedgerNameVal == '!') || (LedgerNameVal == '@') || (LedgerNameVal == '#') || (LedgerNameVal == '$') || (LedgerNameVal == '%') || (LedgerNameVal == '^') || (LedgerNameVal == '&') || (LedgerNameVal == '*') || (LedgerNameVal == '(') || (LedgerNameVal == ')') || (LedgerNameVal == '{') || (LedgerNameVal == '}') || (LedgerNameVal == '|') || (LedgerNameVal == '<') || (LedgerNameVal == '>') || (LedgerNameVal == '?')) {

                        if ((LedgerNameVal == '~') || (LedgerNameVal == '!') || (LedgerNameVal == '@') || (LedgerNameVal == '#') || (LedgerNameVal == '$') || (LedgerNameVal == '%') || (LedgerNameVal == '^') || (LedgerNameVal == '&') || (LedgerNameVal == '*') || (LedgerNameVal == '{') || (LedgerNameVal == '}') || (LedgerNameVal == '|') || (LedgerNameVal == '<') || (LedgerNameVal == '>') || (LedgerNameVal == '?') || (LedgerNameVal == "'")) {
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

        if (String.fromCharCode(eve.charCode) == ".") {
            if (document.getElementById(txtObj.id).value == "") {
                document.getElementById(txtObj.id).value = "";
                return false;
            }

        }
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
//function CheckBookCloseFinancialYearDateFormate(HF_FromDate, HF_ToDate, txtDate, ddlScheme, HF_BranchId, HF_IsBookClosed, HF_Language) {
//    try {

//        if (checkDateFormat(document.getElementById(txtDate))) {
//        } else {

//            return false;
//        }
//        var SelectedDate = document.getElementById(txtDate).value.split("/");

//        var SelectedDateStr = SelectedDate[1] + "/" + SelectedDate[0] + "/" + SelectedDate[2];
//        DateNow = new Date(SelectedDateStr);

//        if (CheckIsBookClosed(DateNow, txtDate, ddlScheme, HF_BranchId, HF_IsBookClosed, HF_Language)) {


//            var FromDateStr = document.getElementById(HF_FromDate).value;
//            var ToDateStr = document.getElementById(HF_ToDate).value;

//            var FromDateArray = FromDateStr.split("/");
//            var ToDateArray = ToDateStr.split("/");
//            var FromDateString = FromDateArray[1] + "/" + FromDateArray[0] + "/" + FromDateArray[2];
//            var ToDateString = ToDateArray[1] + "/" + ToDateArray[0] + "/" + ToDateArray[2];

//            var FromDate = new Date(FromDateString);
//            var ToDate = new Date(ToDateString);

//            if (FromDate <= DateNow && DateNow <= ToDate) {

//            }
//            else {
//                document.getElementById(txtDate).value = '';
//                if (document.getElementById(HF_Language).value == 1) {
//                    alert('Date should be between financial year.' + ' ' + '(' + FromDateArray[0] + "/" + FromDateArray[1] + "/" + FromDateArray[2].substring(0, 4) + ' ' + 'to' + ' ' + ToDateArray[0] + "/" + ToDateArray[1] + "/" + ToDateArray[2].substring(0, 4) + ')');

//                } else {
//                    alert('चुनी गई तिथि वित्तीय वर्ष के बीच की होना चाहिये ।' + ' ' + '(' + FromDateArray[0] + "/" + FromDateArray[1] + "/" + FromDateArray[2].substring(0, 4) + ' ' + 'to' + ' ' + ToDateArray[0] + "/" + ToDateArray[1] + "/" + ToDateArray[2].substring(0, 4) + ')');

//                }

//            }

//        }
//    }
//    catch (e) {
//        alert(e);
//    }

//}
//function CheckIsBookClosed(DateNow, txtDate, ddlScheme, HF_BranchId, HF_IsBookClosed, HF_Language) {

//    if (DateNow != '') {

//        var ddlScheme = document.getElementById(ddlScheme);

//        var scheme = ddlScheme.options[ddlScheme.selectedIndex].value.toLowerCase();
//        if (ddlScheme.selectedIndex <= 0) {

//            if (document.getElementById(HF_Language).value == 1) {
//                alert('Please select scheme.');

//            } else {
//                alert('कृपया  स्कीम चुनें ।');
//            }
//            document.getElementById(txtDate).value = '';

//            return false;
//        }
//        else {
//            var rowArray = new Array();
//            if (document.getElementById(HF_IsBookClosed).value != '') {
//                rowArray = document.getElementById(HF_IsBookClosed).value.split('~');
//                for (var i = 0; i < rowArray.length; i++) {
//                    var itemArray = new Array();
//                    itemArray = rowArray[i].split('*');
//                    var BranchId = document.getElementById(HF_BranchId).value;

//                    if (scheme == itemArray[0].toLowerCase() && BranchId.toLowerCase() == itemArray[1].toLowerCase()) {

//                        var ClosedDateArray = itemArray[2].split("/");
//                        var CloseDateString = ClosedDateArray[1] + "/" + ClosedDateArray[0] + "/" + ClosedDateArray[2];
//                        var CloseDate = new Date(CloseDateString);
//                        if (DateNow > CloseDate) {
//                            return true;
//                        }
//                        else {
//                            if (document.getElementById(HF_Language).value == 1) {
//                                alert('Book is already closed on' + ' ' + ClosedDateArray[0] + "/" + ClosedDateArray[1] + "/" + ClosedDateArray[2].substring(0, 4) + '' + ' ' + ' for selected scheme.');

//                            } else {
//                                alert('चुनी हुई स्कीम के लिये बुक ' + ' ' + ClosedDateArray[0] + "/" + ClosedDateArray[1] + "/" + ClosedDateArray[2].substring(0, 4) + '' + ' ' + ' को बन्द हो चुकी है ।');

//                            }
//                            document.getElementById(txtDate).value = '';
//                            return false;
//                        }
//                    }
//                }

//            }
//            else {
//                return true;
//            }
//        }
//    }
//    else {
//        return true;
//    }
//}
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
                        alert("दिनांक सही नही है ।");
                    } else {
                        alert("Invalid date.");
                    }

                }
            }
            else {
                that.value = "";
                if (GlobalLanguage == 0) {
                    alert("दिनांक सही नही है ।");
                } else {
                    alert("Invalid date.");
                }

            }
        }
        else {
            that.value = "";
            if (GlobalLanguage == 0) {
                alert("दिनांक सही नही है ।");
            } else {
                alert("Invalid date.");
            }
        }
    }
    else {
        if (entry != "") {
            that.value = "";
            if (GlobalLanguage == 0) {
                alert("दिनांक का फोर्मेट सही नही है, (दिन/माह/वर्ष) फोर्मेट मे भरे ।");
            } else {
                alert("Incorrect date format. Enter as (dd/MM/yyyy).");
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


function TextBoxAlfaNumericLengthValidation(that, txtLength) {
    if (that.value != '') {
        that.value = document.getElementById(that.id).value.replace(/[^a-zA-Z0-9\-]/gi, '');
        if (that.value.length > txtLength) {
            that.value = that.value.substring(0, parseInt(txtLength));
            if (GlobalLanguage == 0) {
                alert("आप  " + txtLength + " अक्षर से ज्यादा नहीं डाल सकते ।");
            }
            else {
                alert("Can not enter more then " + txtLength + " character.");
            }
        }
    }
}
function TextBoxAlfaNumericLengthValidationAllowComma(that, txtLength) {
    if (that.value != '') {
        that.value = document.getElementById(that.id).value.replace(/[^a-zA-Z0-9,\-_]/gi, '');
        if (that.value.length > txtLength) {
            that.value = that.value.substring(0, parseInt(txtLength));
            if (GlobalLanguage == 0) {
                alert("आप  " + txtLength + " अक्षर से ज्यादा नहीं डाल सकते ।");
            }
            else {
                alert("Can not enter more then " + txtLength + " character.");
            }
        }
    }
}




//Added function as per task 1443

function UploadControlValidationForLenthAndFileFormat(maxLengthFileName, validFileFormaString, uploadControlId) {
    //ex---------------
    //maxLengthFileName=50;
    //validFileFormaString=JPG*JPEG*PDF*DOCX
    //uploadControlId=upSaveBill
    //ex---------------
    var msg = '';
    if (document.getElementById(uploadControlId).value != '') {
        var size = document.getElementById(uploadControlId);

        var fileName = document.getElementById(uploadControlId).value;
        var lengthFileName = parseInt(document.getElementById(uploadControlId).value.length)



        var fileExtacntionArray = new Array();
        fileExtacntionArray = fileName.split('.');

        if (fileExtacntionArray.length == 2) {

            var fileExtacntion = fileExtacntionArray[fileExtacntionArray.length - 1];


            if (lengthFileName >= parseInt(maxLengthFileName) + parseInt(1)) {
                if (GlobalLanguage == 0) {
                    msg += '- फाइल का नाम ' + maxLengthFileName + ' अक्षर से कम होनी चाहिये ।\n';

                } else {
                    msg += '- File name should be less than ' + maxLengthFileName + ' characters. \n';
                }
            }
            for (i = 0; i <= (fileName.length - 1); i++) {
                var charFileName = '';

                charFileName = fileName.substring(i, i + 1);

                if ((charFileName == '~') || (charFileName == '!') || (charFileName == '@') || (charFileName == '#') || (charFileName == '$') || (charFileName == '%') || (charFileName == '&') || (charFileName == '*') || (charFileName == '{') || (charFileName == '}') || (charFileName == '|') || (charFileName == '<') || (charFileName == '>') || (charFileName == '?')) {
                    if (GlobalLanguage == 0) {
                        msg += '- फाइल के नाम मे विशेष अक्षर मान्य नही है ।\n';

                    } else {
                        msg += '- Special character not allowed in file name. \n';
                    }
                    break;
                }

            }
            var isFileFormatCorrect = false;
            var strValidFormates = '';

            if (validFileFormaString != "") {

                var fileFormatArray = new Array();
                fileFormatArray = validFileFormaString.split('*');

                for (var j = 0; j < fileFormatArray.length; j++) {
                    if (fileFormatArray[j].toUpperCase() == fileExtacntion.toUpperCase()) {
                        isFileFormatCorrect = true;
                    }

                    if (j == fileFormatArray.length - 1) {
                        strValidFormates += '.' + fileFormatArray[j].toLowerCase();

                    }
                    else {
                        strValidFormates += '.' + fileFormatArray[j].toLowerCase() + '/';

                    }
                }

                if (isFileFormatCorrect == false) {

                    if (GlobalLanguage == 0) {
                        msg += '- फाइल फारमेट सही नही है (केवल ' + strValidFormates + ')\n';
                    }
                    else {
                        msg += '- File format is not correct (only ' + strValidFormates + ').\n';
                    }
                }

            }

        }
        else {
            if (GlobalLanguage == 0) {
                msg += '- फाईल का नाम सही नही है ।';
            }
            else {
                msg += '- File name is incorrect';
            }
        }
        if (msg != '') {
            document.getElementById(uploadControlId).value = "";
            alert(msg);
            return false;
        }
        else {
            return true;
        }

    }
    //    else {
    //        if (GlobalLanguage == 0) {
    //            alert('कृपया फाइल चुने ।');

    //        } else {
    //            alert('Please select file.');
    //        }
    //    }
}