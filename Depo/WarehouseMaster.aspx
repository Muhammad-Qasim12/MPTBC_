<%@ Page Title="WareHouse Master" Language="C#" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" EnableViewStateMac="false"
    AutoEventWireup="true" CodeFile="WarehouseMaster.aspx.cs" Inherits="Depo_WarehouseMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
            <h2>WareHouse Master</h2>
        </div>
        <div class="card-body">

            <div class="row g-3">
                <div class="col-md-12">
                    <asp:Panel class="alert alert-danger" runat="server" ID="mainDiv" Style="display: none; padding-top: 10px; padding-bottom: 10px;">
                        <asp:Label ID="lblmsg" class="notification" runat="server">                
                        </asp:Label>
                    </asp:Panel>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtWareHouseName" runat="server" CssClass="form-control reqirerd" placeholder="" onkeypress="javascript:tbx_fnAlphaOnly(event, this)" MaxLength="40"></asp:TextBox>
                        <label>Ware House / Godown Name<span class="red">*</span></label>
                    </div>
                </div>
                <div class="col-md-5">
                    <div class="form-floating">
                        <asp:RadioButtonList ID="rdwarehouse" runat="server" CssClass="form-control reqirerd"
                            RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Permanent</asp:ListItem>
                            <asp:ListItem Value="2">Temporary</asp:ListItem>
                            <asp:ListItem Value="3">Corporate Warehouse </asp:ListItem>
                        </asp:RadioButtonList>
                        <label>Ware House/ Godown Type <span class="red">*</span></label>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="form-floating">
                        <asp:TextBox ID="txtRegistrationNo" runat="server" CssClass="form-control reqirerd" placeholder="" MaxLength="20"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender
                            ID="FilteredTextBoxExtender5" TargetControlID="txtRegistrationNo" ValidChars="ADSFGHGJKLZXCVBNMQWERTYUIOPasdfghjklzxcvbnmqwertyuiop/-1234567890-" runat="server">
                        </cc1:FilteredTextBoxExtender>
                        <label>Agreement No. <span class="red">*</span></label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtRegDate" runat="server" TextMode="Date" CssClass="form-control reqirerd" MaxLength="10"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtRegDate" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <label>Possession Date <span class="red">*</span></label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtWarehouseOwnerN" runat="server" CssClass="form-control reqirerd" placeholder="" onkeypress='javascript:tbx_fnAlphaOnly(event, this);' MaxLength="40"></asp:TextBox>
                        <label>Ware House / Godown Owner Name <span class="red">*</span></label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtCorpet" runat="server" CssClass="form-control reqirerd FL" Width="50%" onkeyup='javascript:tbx_fnSignedNumericCheck(this);' MaxLength="10"></asp:TextBox>
                        <asp:DropDownList ID="ddlCorpetType" runat="server" CssClass="form-select reqirerd FR" Width="45%"
                            AutoPostBack="True" OnSelectedIndexChanged="ddlCorpetType_SelectedIndexChanged">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                            <asp:ListItem Value="1">Square feet </asp:ListItem>
                            <asp:ListItem Value="2">Square meter </asp:ListItem>
                            <asp:ListItem Value="4">Metric ton</asp:ListItem>
                        </asp:DropDownList>
                        <label>Carpet Area <span class="red">*</span></label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox
                            ID="txtTelPhone2" runat="server" CssClass="form-control" placeholder="PhoneNo" onkeypress='javascript:fnSetPhoneDigits(event, this);'
                            MaxLength="8"></asp:TextBox><cc1:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender2" TargetControlID="txtTelPhone2" ValidChars="0123456798" runat="server">
                            </cc1:FilteredTextBoxExtender>
                        <label>Telephone No. </label>
                    </div>
                </div>
                <%--<div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtstdCode" CssClass="form-control FL" placeholder="STD" Width="30%" runat="server"
                            onkeypress='javascript:fnSetPhoneDigits(event, this);' MaxLength="5"></asp:TextBox>
                        <asp:TextBox
                            ID="txtTelPhone2" runat="server" CssClass="form-control FR" placeholder="PhoneNo" Width="65%" onkeypress='javascript:fnSetPhoneDigits(event, this);'
                            MaxLength="8"></asp:TextBox><cc1:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender2" TargetControlID="txtTelPhone2" ValidChars="0123456798" runat="server">
                            </cc1:FilteredTextBoxExtender>
                        <label>STD &nbsp;&nbsp;&nbsp; - &nbsp;&nbsp;&nbsp; Telephone No </label>
                    </div>
                </div>--%>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtMoblie" CssClass="form-control" placeholder="" runat="server"
                            MaxLength="10" onblur='javascript:fnIsValidPhoneFormat(this);'></asp:TextBox><cc1:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender1" TargetControlID="txtMoblie" ValidChars="0123456798" runat="server">
                            </cc1:FilteredTextBoxExtender>
                        <label>Mobile No. <span class="red">*</span></label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtaddress" runat="server" placeholder="" CssClass="form-control reqirerd" TextMode="MultiLine" MaxLength="100" onkeypress="MaxLengthCount(this,100);javascript:tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                        <label>Address <span class="red">*</span></label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-select reqirerd">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                        </asp:DropDownList>
                        <label>District  <span class="red">*</span></label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtCity" runat="server" CssClass="form-control " placeholder="" MaxLength="30" onkeypress="javascript:tbx_fnAlphaOnly(event, this)"></asp:TextBox>
                        <label>City  <span class="red">*</span></label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtPinCode" runat="server" CssClass="form-control " placeholder="" MaxLength="6" onkeyup='javascript:tbx_fnSignedNumericCheck(this);'></asp:TextBox>
                        <label>Pin Code  <span class="red">*</span></label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtEmailID" runat="server" CssClass="form-control " placeholder="" MaxLength="30"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailID"
                            ErrorMessage="कृपया सही ई-मेल आई.डी. दर्ज करें" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                        </asp:RegularExpressionValidator>
                        <label>EMail ID</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                       <%-- <asp:TextBox ID="txtstdCode1" runat="server" MaxLength="5"
                            onkeypress="javascript:fnSetPhoneDigits(event, this);" CssClass="form-control FL" placeholder="STD" Width="30%"></asp:TextBox>--%>
                        <asp:TextBox ID="txtFaxNo" runat="server" CssClass="form-control" placeholder="PhoneNo"
                            onkeyup='javascript:tbx_fnSignedNumericCheck(this);' MaxLength="8"></asp:TextBox>
                        <label>Fax No</label>
                    </div>
                </div>
                
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtPanNo" runat="server" CssClass="form-control" placeholder="" onblur="fnValidatePAN(this);" MaxLength="10"></asp:TextBox>
                        <label>Pan No  <span class="red">*</span></label>
                    </div>
                </div>
                <%--<div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtTinNo" runat="server" CssClass="form-control " placeholder=""
                            onkeypress="javascript:tbx_fnSignedIntegerCheck(event, this)" MaxLength="15"></asp:TextBox>
                        <label>टिन नम्बर   <span class="red">*</span></label>
                    </div>
                </div>--%>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtServiceTaxNo" runat="server" CssClass="form-control " placeholder=""
                            onkeypress="javascript:tbx_fnSignedIntegerCheck(event, this)" MaxLength="20"></asp:TextBox>
                        <label>GST No. <span class="red">*</span></label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtServicePe" runat="server" CssClass="form-control" placeholder=""
                            onkeyup='javascript:tbx_fnSignedIntegerCheck(this);' MaxLength="3"></asp:TextBox>
                        <label>Agreement Period (in month)</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtRegAmount" runat="server" CssClass="form-control reqirerd" placeholder="" onkeyup='javascript:tbx_fnSignedNumericCheck(this);'
                            MaxLength="6"></asp:TextBox>
                        <label>Rent Payment Details </label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtCheckNo" runat="server" CssClass="form-control reqirerd" placeholder="" onkeyup='javascript:tbx_fnSignedIntegerCheck(this);' MaxLength="10"></asp:TextBox>
                        <label>D.D./ Cheque No.</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="txtBankName" runat="server" CssClass="form-select reqirerd">
                            <asp:ListItem>Select</asp:ListItem>
                        </asp:DropDownList>
                        <label>Bank Name</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtCheckDate" runat="server" TextMode="Date" CssClass="form-control reqirerd"
                            MaxLength="10"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtCheckDate" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <label>D.D./ Cheque Date</label>
                    </div>
                </div>
                <%--<div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txttenno" runat="server" CssClass="form-control reqirerd" placeholder=""
                            MaxLength="10" onkeyup="javascript:tbx_fnSignedIntegerCheck(this);"></asp:TextBox>
                        <label>टेन नंबर</label>
                    </div>
                </div>--%>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtEPFNO" runat="server" CssClass="form-control " placeholder="" MaxLength="10"></asp:TextBox>
                        <label>EPF No.</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="">
                        <label>Ware House / Godown MAP </label>
                        <div id="PhotoUpload3">
                            <asp:FileUpload ID="FlMapFile" runat="server" />
                        </div>

                    </div>
                </div>
                <div class="col-md-4">
                    <div class="">
                        <label>Ware House / GodownAgreement</label>
                        <div id="PhotoUpload">
                            <asp:FileUpload ID="FlAgrimentFile" runat="server" />
                        </div>

                    </div>
                </div>
                <div class="col-md-12">
                    <h5><strong>Rent Details</strong></h5>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="txtRentDate" runat="server" CssClass="form-select reqirerd" MaxLength="10"></asp:DropDownList>
                        <label>Rent Date <span class="red">*</span></label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtRentAmount" runat="server" CssClass="form-control reqirerd FL" Width="50%" onkeyup='javascript:tbx_fnSignedNumericCheck(this);'
                            MaxLength="5" AutoPostBack="True"
                            OnTextChanged="txtRentAmount_TextChanged"></asp:TextBox>
                        <asp:DropDownList ID="ddlAmountType" runat="server" CssClass="form-select reqirerd FR" Width="45%">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                            <asp:ListItem Value="1">square Feet</asp:ListItem>
                            <asp:ListItem Value="2">Square Meter</asp:ListItem>
                            <asp:ListItem Value="3">Meter</asp:ListItem>
                            <asp:ListItem Value="4">Metric ton</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;<asp:Label ID="Label1" runat="server"></asp:Label>
                        <label>Rent Amount <span class="red">*</span></label>
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-submit" Text="Save" OnClientClick="return validateform();" OnClick="btnSave_Click" />
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:HiddenField ID="mapID" runat="server" />
                    <asp:HiddenField ID="Agriment" runat="server" />
                </div>
            </div>

        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="head">
    <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <script type="text/javascript" language="javascript">
        function fnValidatePAN(Obj) {
            if (Obj == null) Obj = window.event.srcElement;
            if (Obj.value != "") {
                ObjVal = Obj.value;
                var panPat = /^([a-zA-Z]{5})(\d{4})([a-zA-Z]{1})$/;
                var code = /([C,P,H,F,A,T,B,L,J,G])/;
                var code_chk = ObjVal.substring(3, 4);
                if (ObjVal.search(panPat) == -1) {
                    Obj.value = "";
                    Obj.focus();
                    alert("Invalid Pan No");

                    return false;
                }
                if (code.test(code_chk) == false) {
                    Obj.value = "";
                    alert("Invaild PAN Card No.");
                    return false;
                }
            }
        }
        function Redirect() {

            windows.location.href = 'WareHouseMasterList.aspx';
        }
    </script>


    <script type="text/javascript">

        // Load the Google Transliterate API
        google.load("elements", "1", {
            packages: "transliteration"
        });

        function onLoad() {
            var options = {
                sourceLanguage:
                    google.elements.transliteration.LanguageCode.ENGLISH,
                destinationLanguage:
                    [google.elements.transliteration.LanguageCode.HINDI],
                //shortcutKey: 'ctrl+g',
                transliterationEnabled: true
            };

            // Create an instance on TransliterationControl with the required
            // options.
            var control =
                new google.elements.transliteration.TransliterationControl(options);

            // Enable transliteration in the textbox with id
            // 'transliterateTextarea'.
            control.makeTransliteratable(['ctl00_ContentPlaceHolder1_txtWareHouseName']);
            control.makeTransliteratable(['ctl00_ContentPlaceHolder1_txtaddress']);
            control.makeTransliteratable(['ctl00_ContentPlaceHolder1_txtCity']);
            control.makeTransliteratable(['ctl00_ContentPlaceHolder1_txtWarehouseOwnerN']);

            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_initializeRequest(InitializeRequest);
            prm.add_endRequest(EndRequest);

            function InitializeRequest(sender, args) {
            }

            // this is called to re-init the google after update panel updates.
            function EndRequest(sender, args) {
                onLoad();
            }
        }
        google.setOnLoadCallback(onLoad);
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            /* Attach a change event to the file upload control
             to restrict the file type and file size on file selection. */
            $("#ContentPlaceHolder1_FlMapFile").change(function () {

                // Get the file upload control file extension
                var ext = $(this).val().split('.').pop().toLowerCase();

                // Create array with the files extensions to upload
                var fileListToUpload = new Array('pdf', 'txt', 'doc', 'docx', 'xls', 'xlsx');

                //Check the file extension is in the array.               
                var isValidFile = $.inArray(ext, fileListToUpload);

                // isValidFile gets the value -1 if the file extension is not in the list.  
                if (isValidFile == -1) {
                    ShowMessage('Please select a valid file of type pdf/txt/doc/docx/xls/xlsx.', 'error');
                    $(this).replaceWith($(this).val('').clone(true));
                }
                else {
                    // Restrict the file size to 10 MB.
                    if ($(this).get(0).files[0].size > (1024 * 1024 * 10)) {
                        ShowMessage('File size should not exceed 10MB.', 'error');
                        $(this).replaceWith($(this).val('').clone(true));
                    }
                    else {
                        ShowMessage('Thank you for selecting a valid file.', 'success');
                    }
                }
            });
            $("#ContentPlaceHolder1_FlAgrimentFile").change(function () {

                // Get the file upload control file extension
                var ext = $(this).val().split('.').pop().toLowerCase();

                // Create array with the files extensions to upload
                var fileListToUpload = new Array('pdf', 'txt', 'doc', 'docx', 'xls', 'xlsx');

                //Check the file extension is in the array.               
                var isValidFile = $.inArray(ext, fileListToUpload);

                // isValidFile gets the value -1 if the file extension is not in the list.  
                if (isValidFile == -1) {
                    ShowMessage('Please select a valid file of type pdf/txt/doc/docx/xls/xlsx.', 'error');
                    $(this).replaceWith($(this).val('').clone(true));
                }
                else {
                    // Restrict the file size to 10 MB.
                    if ($(this).get(0).files[0].size > (1024 * 1024 * 10)) {
                        ShowMessage('File size should not exceed 10MB.', 'error');
                        $(this).replaceWith($(this).val('').clone(true));
                    }
                    else {
                        ShowMessage('Thank you for selecting a valid file.', 'success');
                    }
                }
            });
            // Dynamic function to show the messages on the page
            function ShowMessage(message, type) {

                if (type == 'success') {
                    $("#fileStatus").removeClass('error');
                    $("#fileStatus").addClass('success');
                }
                else if (type == 'error') {
                    $("#fileStatus").removeClass('success');
                    $("#fileStatus").addClass('error');
                }
                $("#fileStatus").text(message);
            }

        });

    </script>
    <script>

        var Globlephoto = document.getElementById("PhotoUpload").innerHTML;
        $('#ctl00_ContentPlaceHolder1_FlAgrimentFile').live('change', function () {

            //this.files[0].size gets the size of your file.
            if (this.files[0].size / 1024 > 500) {
                alert("file size cannot geater then 500 kb");
                document.getElementById("PhotoUpload").innerHTML = Globlephoto;

            }

        });
        var Globlephoto2 = document.getElementById("PhotoUpload3").innerHTML;
        $('#ctl00_ContentPlaceHolder1_FlMapFile').live('change', function () {

            //this.files[0].size gets the size of your file.
            if (this.files[0].size / 1024 > 500) {
                alert("file Size cannot geater then 500 kb");
                document.getElementById("PhotoUpload3").innerHTML = Globlephoto2;

            }

        });

    </script>
    <script type="text/javascript">
        function validateform() {
            var msg = "";
            if (document.getElementById('<%=txtWareHouseName.ClientID%>').value.trim() == "") {
                msg += "वेयरहाउस का नाम भरें \n";
            }
            if (document.getElementById('<%=txtRegistrationNo.ClientID%>').value.trim() == "") {
                msg += "अनुबंध क्रमांक भरें \n";
            }
            if (document.getElementById('<%=ddlDistrict.ClientID%>').selectedIndex == 0) {
                msg = msg + "जिला चुनें  \n";
            }
            if (document.getElementById('<%=txtWarehouseOwnerN.ClientID%>').value.trim() == "") {
                msg += "वेयरहाउस/ गोदाम मालिक का नाम भरें \n";
            }
            if (msg != "") {
                alert(msg);
                return false;
            }
            else {

                if (confirm("Do you want to Save Details ?")) {
                    return true;
                }
                else {
                    return false;
                }
            }

        }

    </script>
</asp:Content>


