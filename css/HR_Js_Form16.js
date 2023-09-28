function ChangesOnResidence() {
 if (document.getElementById('rbOwnHouse').checked == true) {
  document.getElementById('txtPropertyDetailsAddress').disabled = false;
  document.getElementById('txtDateofOccupancy').value = '';
  document.getElementById('txtDateofOccupancy').disabled = true;
  document.getElementById('txtRentPaidMonthly').value = '';
  document.getElementById('txtRentPaidMonthly').disabled = true;
  document.getElementById('Chk_ResidenseAtPlace').disabled = true;
  document.getElementById('Chk_ResidenseAtPlace').checked = false;
 }
 else {
  document.getElementById('txtPropertyDetailsAddress').value = '';
  document.getElementById('txtPropertyDetailsAddress').disabled = true;
document.getElementById('txtDateofOccupancy').disabled = false;
  document.getElementById('txtRentPaidMonthly').disabled = false;
  document.getElementById('Chk_ResidenseAtPlace').disabled = false;
 }
}
function SaveValidation() {
 try {
  var LanguageType = document.getElementById('HFChoice').value;
  var EmployeeName = document.getElementById('ddlEmployeeName');
  var Msg = '';
  if (EmployeeName.selectedIndex == 0 || EmployeeName.selectedIndex == -1) {
if (LanguageType == '0') {
 Msg += ' - Select employee name.\n';
}
else {
 Msg += ' - Select employee name.\n';
}
  }
  if (Msg != '') {
alert(Msg);
return false;
  }
  var confirmMsg = '';
  if (LanguageType == '0') {
confirmMsg = confirm("Do you want to save ?");
  }
  else {
confirmMsg = confirm("Do you want to save ?");
  }
  if (confirmMsg == false) {
return false;
  }
 }
 catch (e) {
 }
}
function DeleteValidation() {
 try {
  var LanguageType = document.getElementById('HFChoice').value;
  var EmployeeName = document.getElementById('ddlEmployeeName');
  var Msg = '';
  if (EmployeeName.selectedIndex == 0 || EmployeeName.selectedIndex == -1) {
if (LanguageType == '0') {
 Msg += ' - Select employee name.\n';
}
else {
 Msg += ' - Select employee name.\n';
}
  }
  if (Msg != '') {
alert(Msg);
return false;
  }
  var confirmMsg;
  if (document.getElementById('HFChoice').value == '0') {
confirmMsg = confirm("Do you realy want to delete this record ?");
  }
  else {
confirmMsg = confirm("Do you realy want to delete this record ?");
  }
  if (confirmMsg == false) {
return false;
  }
 }
 catch (e) {
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
  alert("Invalid Date.");
  } else {
alert("Invalid Date.");
  }
 }
}
else {
 that.value = "";
 if (GlobalLanguage == 0) {
  alert("Invalid Date.");
 } else {
  alert("Invalid Date.");
 }
}
  }
  else {
that.value = "";
if (GlobalLanguage == 0) {
alert("Invalid Date.");
} else {
 alert("Invalid Date.");
}
  }
 }
 else {
  if (entry != "") {
that.value = "";
if (GlobalLanguage == 0) {
alert("Incorrect date format. Enter as dd/MM/yyyy.");
} else {
 alert("Incorrect date format. Enter as dd/MM/yyyy.");
}
  }
 }
 return false;
}
function CheckSameDataExists(str, SelectedId) {
 var LanguageType = document.getElementById('HFChoice').value;
 var rowArray = new Array();
 rowArray = str.split('~');
 for (var i = 0; i < rowArray.length - 1; i++) {
  var itemArray = new Array();
  itemArray = rowArray[i].split('*');
  if (itemArray[0].toUpperCase() == SelectedId.toUpperCase()) {
if (LanguageType == '0') {
 alert('Record already added, you can not add again.');
}
else {
 alert('Record already added, you can not add again.');
}
return false;
  }
 }
 return true;
}
function RemoveSelectedRecord(that) {
 try {
  var confrmMsg;
  if (document.getElementById('HFChoice').value == '0') {
confrmMsg = confirm('Are you sure,you want to delete this record ?');
  }
  else {
confrmMsg = confirm('Are you sure,you want to delete this record ?');
  }
  if (confrmMsg == false) {
return false;
  }
  var Index = (that.parentNode.parentNode.rowIndex) - 1;
  var HFName = '';
  if (that.id == 'Delete_Investment') {
HFName = 'HF_InvestmentData';
  }
  if (that.id == 'Delete_OtherIncome') {
HFName = 'HF_OtherIncomeData';
  }
  if (that.id == 'Delete_Deduction') {
HFName = 'HF_DeductionData';
  }
  if (document.getElementById(HFName).value != '') {
rowArray = document.getElementById(HFName).value.split('~');
document.getElementById(HFName).value = '';
for (var i = 0; i < rowArray.length - 1; i++) {
 if (i == Index) {
 }
 else {
  document.getElementById(HFName).value += rowArray[i] + '~';
 }
}
if (that.id == 'Delete_Investment') {
 CreateInvestmentTbl();
 document.getElementById('HF_EditRowNo').value = '';
}
if (that.id == 'Delete_OtherIncome') {
 CreateOtherIncomeTbl();
}
if (that.id == 'Delete_Deduction') {
 CreateDeductionTbl();
}
document.getElementById('HF_IsEdit').value = '';
document.getElementById('HF_RowIndexOnEdit').value = '';
  }
 }
 catch (e) {
 }
}
function FillSelectedRecordToEdit(that) {
 try {
  var Index = (that.parentNode.parentNode.rowIndex) - 1;
  document.getElementById('HF_IsEdit').value = '';
  document.getElementById('HF_RowIndexOnEdit').value = '';
  var HFName = '';
  if (that.id == 'Select_Investment') {
HFName = 'HF_InvestmentData';
document.getElementById('HF_RowIndexOnEdit').value = Index;
  }
  if (that.id == 'Select_OtherIncome') {
HFName = 'HF_OtherIncomeData';
  }
  if (that.id == 'Select_Deduction') {
HFName = 'HF_DeductionData';
  }
  var str = '';
  if (document.getElementById(HFName).value != '') {
rowArray = document.getElementById(HFName).value.split('~');
for (var i = 0; i < rowArray.length - 1; i++) {
 if (i == Index) {
  str = rowArray[i];
 }
}
var itemArray = new Array();
itemArray = str.split('*');
if (str != '') {
 if (that.id == 'Select_Investment') {
  document.getElementById('txtDetail').value = itemArray[2];
  document.getElementById('txtAmount').value = itemArray[3];
  document.getElementById('HF_EditRowNo').value = itemArray[4];
  ShowSelectedDDL(itemArray[0], 'ddlSection');
 }
 if (that.id == 'Select_OtherIncome') {
  document.getElementById('txtAnyOtherAmount').value = itemArray[2];
  ShowSelectedDDL(itemArray[0], 'ddlType');
 }
 if (that.id == 'Select_Deduction') {
  document.getElementById('txtDeductionAmount').value = itemArray[2];
  ShowSelectedDDL(itemArray[0], 'ddlDeduction');
 }
 document.getElementById('HF_IsEdit').value = itemArray[0];
}
  }
 }
 catch (e) {
 }
}
function ShowSelectedDDL(DDLVal, DDLId) {
 ddl = document.getElementById(DDLId);
 for (var i = 1; i <= ddl.length - 1; i++) {
  if (ddl.options[i].value.toUpperCase() == DDLVal.toUpperCase()) {
document.getElementById(DDLId).selectedIndex = i;
break;
  }
 }
}
function UpdateExistData(str, HFName) {
 var rowArray = new Array();
 rowArray = document.getElementById(HFName).value.split('~');
 var SelectedId = document.getElementById('HF_IsEdit').value;
 document.getElementById(HFName).value = '';
 for (var i = 0; i < rowArray.length - 1; i++) {
  var itemArray = new Array();
  itemArray = rowArray[i].split('*');
  if (itemArray[0].toUpperCase() == SelectedId.toUpperCase()) {
if (HFName == 'HF_InvestmentData') {
 if (i == document.getElementById('HF_RowIndexOnEdit').value) {
  document.getElementById(HFName).value += str + '~';
 }
 else {
  document.getElementById(HFName).value += rowArray[i] + '~';
 }
}
else {
 document.getElementById(HFName).value += str + '~';
}
  }
  else {
document.getElementById(HFName).value += rowArray[i] + '~';
  }
 }
}
function AddInvestmentDataInHF() {
 try {
  var Msg = '';
  var LanguageType = document.getElementById('HFChoice').value;
  var Section = document.getElementById('ddlSection');
  var Detail = document.getElementById('txtDetail').value;
  var Amount = document.getElementById('txtAmount').value;
  if (Section.selectedIndex == 0 || Section.selectedIndex == -1) {
if (LanguageType == '0') {
 Msg += ' - Select section |\n';
}
else {
 Msg += ' - Select section.\n';
}
  }
  if (Detail == "") {
if (LanguageType == '0') {
 Msg += ' - Enter detail.\n';
}
else {
 Msg += ' - Enter detail.\n';
}
  }
  if (Amount == "") {
if (LanguageType == '0') {
 Msg += ' - Enter amount.\n';
}
else {
 Msg += ' - Enter amount.\n';
}
  }
  if (Msg != '') {
alert(Msg);
return false;
  }
  if (document.getElementById('HF_IsEdit').value == '') {
var rowno;
if (document.getElementById('HF_MaxRowNo').value == '') {
 rowno = 0;
}
else {
 rowno = ((document.getElementById('HF_MaxRowNo').value) * 1) + 1;
}
document.getElementById('HF_MaxRowNo').value = rowno;
document.getElementById('HF_InvestmentData').value += Section.value + '*' + Section.options[Section.selectedIndex].text + '*' + Detail + '*' + Amount + '*' + rowno + '~';
  }
  else {
var str = Section.value + '*' + Section.options[Section.selectedIndex].text + '*' + Detail + '*' + Amount + '*' + document.getElementById('HF_EditRowNo').value;
UpdateExistData(str, 'HF_InvestmentData');
  }
  CreateInvestmentTbl();
  document.getElementById('ddlSection').selectedIndex = 0;
  document.getElementById('txtDetail').value = '';
  document.getElementById('txtAmount').value = '';
  document.getElementById('HF_IsEdit').value = '';
  document.getElementById('HF_RowIndexOnEdit').value = '';
  document.getElementById('HF_EditRowNo').value = '';
 }
 catch (e) {
 }
}
function CreateInvestmentTbl() {
 try {
  if (document.getElementById('HF_InvestmentData').value == '') {
document.getElementById('DvInvestment').innerHTML = '';
return false;
  }
  var LanguageType = document.getElementById('HFChoice').value;
  document.getElementById('DvInvestment').innerHTML = '';
  var newTbl = document.createElement('table');
  newTbl.id = 'tblInvestment';
  document.getElementById('DvInvestment').appendChild(newTbl);
  var table = document.getElementById('tblInvestment');
  table.border = "1";
  table.width = '100%';
  var newRow = table.insertRow(0);
  newRow.className = 'GridHead';
  newCell = newRow.insertCell(0);
  newCell.align = 'center';
  var newlbl = document.createElement('span');
  newlbl.className = 'span';
  if (LanguageType == '0') {
newlbl.innerHTML = 'Select';
  }
  else {
newlbl.innerHTML = 'Select';
  }
  newlbl.size = '5';
  newCell.appendChild(newlbl);
  newCell = newRow.insertCell(1);
  newCell.align = 'center';
  var newlbl = document.createElement('span');
  newlbl.className = 'span';
  if (LanguageType == '0') {
  newlbl.innerHTML = 'Delete';
  }
  else {
newlbl.innerHTML = 'Delete';
  }
  newlbl.size = '5';
  newCell.appendChild(newlbl);
  newCell = newRow.insertCell(2);
  newCell.align = 'center';
  var newlbl = document.createElement('span');
  newlbl.className = 'span';
  if (LanguageType == '0') {
newlbl.innerHTML = 'Section';
  }
  else {
newlbl.innerHTML = 'Section';
  }
  newlbl.size = '5';
  newCell.appendChild(newlbl);
  newCell = newRow.insertCell(3);
  newCell.align = 'center';
  var newlbl = document.createElement('span');
  newlbl.className = 'span';
  if (LanguageType == '0') {
  newlbl.innerHTML = 'Detail';
  }
  else {
newlbl.innerHTML = 'Detail';
  }
  newCell.appendChild(newlbl);
  newCell = newRow.insertCell(4);
  newCell.align = 'center';
  var newlbl = document.createElement('span');
  newlbl.className = 'span';
  if (LanguageType == '0') {
newlbl.innerHTML = 'Amount';
  }
  else {
newlbl.innerHTML = 'Amount';
  }
  newCell.appendChild(newlbl);
  AddRowsInInvestmentTbl(table);
 }
 catch (e) {
 }
}
function AddRowsInInvestmentTbl(table) {
 var LanguageType = document.getElementById('HFChoice').value;
 var rowArray = new Array(); 
 if (document.getElementById('HF_InvestmentData').value != '') {
  rowArray = document.getElementById('HF_InvestmentData').value.split('~');
  for (var i = 0; i < rowArray.length - 1; i++) {
var itemArray = new Array();
itemArray = rowArray[i].split('*');
var newRow = table.insertRow(table.rows.length);
newRow.className = 'altrow';
newCell = newRow.insertCell(0);
newCell.align = 'center';
var newBtn = document.createElement('input');
newBtn.type = 'button';
newBtn.className = 'btn';
newBtn.id = 'Select_Investment';
if (LanguageType == '0') {
 newBtn.value = 'Select';
}
else {
 newBtn.value = 'Select';
}
newBtn.setAttribute("onclick", "javascript:FillSelectedRecordToEdit(this)");
newCell.appendChild(newBtn);
newCell = newRow.insertCell(1);
newCell.align = 'center';
var newBtn = document.createElement('input');
newBtn.type = 'button';
newBtn.className = 'btn';
newBtn.id = 'Delete_Investment';
if (LanguageType == '0') {
 newBtn.value = 'Delete';
}
else {
 newBtn.value = 'Delete';
}
newBtn.setAttribute("onclick", "javascript:RemoveSelectedRecord(this)");
newCell.appendChild(newBtn);
newCell = newRow.insertCell(2);
newCell.align = 'center';
var newlbl = document.createElement('span');
newlbl.className = 'span';
newlbl.innerHTML = itemArray[1];
newCell.appendChild(newlbl);
newCell = newRow.insertCell(3);
newCell.align = 'center';
var newlbl = document.createElement('span');
newlbl.className = 'span';
newlbl.innerHTML = itemArray[2];
newCell.appendChild(newlbl);
newCell = newRow.insertCell(4);
newCell.align = 'right';
var newlbl = document.createElement('span');
newlbl.className = 'span';
newlbl.innerHTML = itemArray[3];
newCell.appendChild(newlbl);
if (i >= 3) {
 document.getElementById('DvInvestment').style.height = '130px';
}
else {
 document.getElementById('DvInvestment').style.height = 'auto';
}
  }
 }
}
function AddOtherIncomeDataInHF() {
 try {
  var Msg = '';
  var LanguageType = document.getElementById('HFChoice').value;
  var Type = document.getElementById('ddlType');
  var Amount = document.getElementById('txtAnyOtherAmount').value;
  if (Type.selectedIndex == 0 || Type.selectedIndex == -1) {
if (LanguageType == '0') {
 Msg += ' - Select Type |\n';
}
else {
 Msg += ' - Select Type.\n';
}
  }
  if (Amount == "") {
if (LanguageType == '0') {
 Msg += ' - Enter amount.\n';
}
else {
 Msg += ' - Enter amount.\n';
}
  }
  if (Msg != '') {
alert(Msg);
return false;
  }
  if (document.getElementById('HF_OtherIncomeData').value != '' && document.getElementById('HF_IsEdit').value == '') {
if (CheckSameDataExists(document.getElementById('HF_OtherIncomeData').value, Type.value) == false) {
 return false;
}
  }
  if (document.getElementById('HF_IsEdit').value == '') {
document.getElementById('HF_OtherIncomeData').value += Type.value + '*' + Type.options[Type.selectedIndex].text + '*' + Amount + '~';
  }
  else {
var str = Type.value + '*' + Type.options[Type.selectedIndex].text + '*' + Amount;
UpdateExistData(str, 'HF_OtherIncomeData');
  }
  CreateOtherIncomeTbl();
  document.getElementById('ddlType').selectedIndex = 0;
  document.getElementById('txtAnyOtherAmount').value = '';
  document.getElementById('HF_IsEdit').value = '';
 }
 catch (e) {
 }
}
function CreateOtherIncomeTbl() {
 try {
  if (document.getElementById('HF_OtherIncomeData').value == '') {
document.getElementById('DvOtherIncome').innerHTML = '';
return false;
  }
  var LanguageType = document.getElementById('HFChoice').value;
  document.getElementById('DvOtherIncome').innerHTML = '';
  var newTbl = document.createElement('table');
  newTbl.id = 'tblOtherIncome';
  document.getElementById('DvOtherIncome').appendChild(newTbl);
  var table = document.getElementById('tblOtherIncome');
  table.border = "1";
  table.width = '100%';
  var newRow = table.insertRow(0);
  newRow.className = 'GridHead';
  newCell = newRow.insertCell(0);
  newCell.align = 'center';
  var newlbl = document.createElement('span');
  newlbl.className = 'span';
  if (LanguageType == '0') {
  newlbl.innerHTML = 'Select';
  }
  else {
newlbl.innerHTML = 'Select';
  }
  newlbl.size = '5';
  newCell.appendChild(newlbl);
  newCell = newRow.insertCell(1);
  newCell.align = 'center';
  var newlbl = document.createElement('span');
  newlbl.className = 'span';
  if (LanguageType == '0') {
newlbl.innerHTML = 'Delete';
  }
  else {
newlbl.innerHTML = 'Delete';
  }
  newlbl.size = '5';
  newCell.appendChild(newlbl);
  newCell = newRow.insertCell(2);
  newCell.align = 'center';
  var newlbl = document.createElement('span');
  newlbl.className = 'span';
  if (LanguageType == '0') {
newlbl.innerHTML = 'Type';
  }
  else {
newlbl.innerHTML = 'Type';
  }
  newlbl.size = '5';
  newCell.appendChild(newlbl);
  newCell = newRow.insertCell(3);
  newCell.align = 'center';
  var newlbl = document.createElement('span');
  newlbl.className = 'span';
  if (LanguageType == '0') {
newlbl.innerHTML = 'Amount';
  }
  else {
newlbl.innerHTML = 'Amount';
  }
  newCell.appendChild(newlbl);
  AddRowsInOtherIncomeTbl(table);
 }
 catch (e) {
 }
}
function AddRowsInOtherIncomeTbl(table) {
 var LanguageType = document.getElementById('HFChoice').value;
 var rowArray = new Array(); 
 if (document.getElementById('HF_OtherIncomeData').value != '') {
  rowArray = document.getElementById('HF_OtherIncomeData').value.split('~');
  for (var i = 0; i < rowArray.length - 1; i++) {
var itemArray = new Array();
itemArray = rowArray[i].split('*');
var newRow = table.insertRow(table.rows.length);
newRow.className = 'altrow';
newCell = newRow.insertCell(0);
newCell.align = 'center';
var newBtn = document.createElement('input');
newBtn.type = 'button';
newBtn.className = 'btn';
newBtn.id = 'Select_OtherIncome';
if (LanguageType == '0') {
 newBtn.value = 'Select';
}
else {
 newBtn.value = 'Select';
}
newBtn.setAttribute("onclick", "javascript:FillSelectedRecordToEdit(this)");
newCell.appendChild(newBtn);
newCell = newRow.insertCell(1);
newCell.align = 'center';
var newBtn = document.createElement('input');
newBtn.type = 'button';
newBtn.className = 'btn';
newBtn.id = 'Delete_OtherIncome';
if (LanguageType == '0') {
 newBtn.value = 'Delete';
}
else {
 newBtn.value = 'Delete';
}
newBtn.setAttribute("onclick", "javascript:RemoveSelectedRecord(this)");
newCell.appendChild(newBtn);
newCell = newRow.insertCell(2);
newCell.align = 'center';
var newlbl = document.createElement('span');
newlbl.className = 'span';
newlbl.innerHTML = itemArray[1];
newCell.appendChild(newlbl);
newCell = newRow.insertCell(3);
newCell.align = 'right';
var newlbl = document.createElement('span');
newlbl.className = 'span';
newlbl.innerHTML = itemArray[2];
newCell.appendChild(newlbl);
if (i >= 3) {
 document.getElementById('DvOtherIncome').style.height = '130px';
}
else {
 document.getElementById('DvOtherIncome').style.height = 'auto';
}
  }
 }
}
function AddDeductionDataInHF() {
 try {
  var Msg = '';
  var LanguageType = document.getElementById('HFChoice').value;
  var Deduction = document.getElementById('ddlDeduction');
  var Amount = document.getElementById('txtDeductionAmount').value;
  if (Deduction.selectedIndex == 0 || Deduction.selectedIndex == -1) {
if (LanguageType == '0') {
 Msg += ' - Select Deduction |\n';
}
else {
 Msg += ' - Select Deduction.\n';
}
  }
  if (Amount == "") {
if (LanguageType == '0') {
 Msg += ' - Enter amount.\n';
}
else {
 Msg += ' - Enter amount.\n';
}
  }
  if (Msg != '') {
alert(Msg);
return false;
  }
  if (document.getElementById('HF_DeductionData').value != '' && document.getElementById('HF_IsEdit').value == '') {
if (CheckSameDataExists(document.getElementById('HF_DeductionData').value, Deduction.value) == false) {
 return false;
}
  }
  if (document.getElementById('HF_IsEdit').value == '') {
document.getElementById('HF_DeductionData').value += Deduction.value + '*' + Deduction.options[Deduction.selectedIndex].text + '*' + Amount + '~';
  }
  else {
var str = Deduction.value + '*' + Deduction.options[Deduction.selectedIndex].text + '*' + Amount;
UpdateExistData(str, 'HF_DeductionData');
  }
  CreateDeductionTbl();
  document.getElementById('ddlDeduction').selectedIndex = 0;
  document.getElementById('txtDeductionAmount').value = '';
  document.getElementById('HF_IsEdit').value = '';
 }
 catch (e) {
 }
}
function CreateDeductionTbl() {
 try {
  if (document.getElementById('HF_DeductionData').value == '') {
document.getElementById('DvDeduction').innerHTML = '';
return false;
  }
  var LanguageType = document.getElementById('HFChoice').value;
  document.getElementById('DvDeduction').innerHTML = '';
  var newTbl = document.createElement('table');
  newTbl.id = 'tblDeduction';
  document.getElementById('DvDeduction').appendChild(newTbl);
  var table = document.getElementById('tblDeduction');
  table.border = "1";
  table.width = '100%';
  var newRow = table.insertRow(0);
  newRow.className = 'GridHead';
  newCell = newRow.insertCell(0);
  newCell.align = 'center';
  var newlbl = document.createElement('span');
  newlbl.className = 'span';
  if (LanguageType == '0') {
  newlbl.innerHTML = 'Select';
  }
  else {
newlbl.innerHTML = 'Select';
  }
  newlbl.size = '5';
  newCell.appendChild(newlbl);
  newCell = newRow.insertCell(1);
  newCell.align = 'center';
  var newlbl = document.createElement('span');
  newlbl.className = 'span';
  if (LanguageType == '0') {
newlbl.innerHTML = 'Delete';
  }
  else {
newlbl.innerHTML = 'Delete';
  }
  newlbl.size = '5';
  newCell.appendChild(newlbl);
  newCell = newRow.insertCell(2);
  newCell.align = 'center';
  var newlbl = document.createElement('span');
  newlbl.className = 'span';
  if (LanguageType == '0') {
newlbl.innerHTML = 'Deduction';
  }
  else {
newlbl.innerHTML = 'Deduction';
  }
  newlbl.size = '5';
  newCell.appendChild(newlbl);
  newCell = newRow.insertCell(3);
  newCell.align = 'center';
  var newlbl = document.createElement('span');
  newlbl.className = 'span';
  if (LanguageType == '0') {
newlbl.innerHTML = 'Amount';
  }
  else {
newlbl.innerHTML = 'Amount';
  }
  newCell.appendChild(newlbl);
  AddRowsInDeductionTbl(table);
 }
 catch (e) {
 }
}
function AddRowsInDeductionTbl(table) {
 var LanguageType = document.getElementById('HFChoice').value;
 var rowArray = new Array(); 
 if (document.getElementById('HF_DeductionData').value != '') {
  rowArray = document.getElementById('HF_DeductionData').value.split('~');
  for (var i = 0; i < rowArray.length - 1; i++) {
var itemArray = new Array();
itemArray = rowArray[i].split('*');
var newRow = table.insertRow(table.rows.length);
newRow.className = 'altrow';
newCell = newRow.insertCell(0);
newCell.align = 'center';
var newBtn = document.createElement('input');
newBtn.type = 'button';
newBtn.className = 'btn';
newBtn.id = 'Select_Deduction';
if (LanguageType == '0') {
 newBtn.value = 'Select';
}
else {
 newBtn.value = 'Select';
}
newBtn.setAttribute("onclick", "javascript:FillSelectedRecordToEdit(this)");
newCell.appendChild(newBtn);
newCell = newRow.insertCell(1);
newCell.align = 'center';
var newBtn = document.createElement('input');
newBtn.type = 'button';
newBtn.className = 'btn';
newBtn.id = 'Delete_Deduction';
if (LanguageType == '0') {
 newBtn.value = 'Delete';
}
else {
 newBtn.value = 'Delete';
}
newBtn.setAttribute("onclick", "javascript:RemoveSelectedRecord(this)");
newCell.appendChild(newBtn);
newCell = newRow.insertCell(2);
newCell.align = 'center';
var newlbl = document.createElement('span');
newlbl.className = 'span';
newlbl.innerHTML = itemArray[1];
newCell.appendChild(newlbl);
newCell = newRow.insertCell(3);
newCell.align = 'right';
var newlbl = document.createElement('span');
newlbl.className = 'span';
newlbl.innerHTML = itemArray[2];
newCell.appendChild(newlbl);
if (i >= 3) {
 document.getElementById('DvDeduction').style.height = '130px';
}
else {
 document.getElementById('DvDeduction').style.height = 'auto';
}
  }
 }
}
function ShowFillData() {
 try {
  ChangesOnResidence();
  CreateInvestmentTbl();
  CreateOtherIncomeTbl();
  CreateDeductionTbl();
 }
 catch (e) {
 }
}