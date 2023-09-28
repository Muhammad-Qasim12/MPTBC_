<%@ Page Title="Printer Registration" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Printer_Registration.aspx.cs" Inherits="Printing_Printer_Registration" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            control.makeTransliteratable(['ContentPlaceHolder1_txtNameOfPressHindi']);
            //control.makeTransliteratable(['ctl00_ContentPlaceHolder1_txtaddress']);
            //control.makeTransliteratable(['ctl00_ContentPlaceHolder1_txtCity']);
            //control.makeTransliteratable(['ctl00_ContentPlaceHolder1_txtWarehouseOwnerN']);

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
    <div class="card">
        <div class="card-header">
            <h2>Printer Registration Detail</h2>
        </div>
        <div class="card-body">
            <asp:Panel runat="server" ID="pnlMain">
                <asp:HiddenField ID="hdnPrinter_RedID_I" Value="0" runat="server" />
                <asp:Panel runat="server" ID="PnlRegInfo" GroupingText="">
                    <div class="row g-3">
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:TextBox ID="txtRegno_I" runat="server" CssClass="form-control reqirerd disabled" ReadOnly="true" Text="PRT0012" placeholder="Printer Registration Detail" MaxLength="10" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                                <label>Printer Registration Detail</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:TextBox ID="txtRegDate_D" runat="server" type="date" placeholder="Registration Date" CssClass="form-control reqirerd" MaxLength="10"></asp:TextBox>
                                <cc1:CalendarExtender Format="dd/MM/yyyy" ID="CaltxtRegDate_D" TargetControlID="txtRegDate_D" runat="server"></cc1:CalendarExtender>
                                <label>Registration Date</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:DropDownList runat="server" ID="DropDownList1" CssClass="form-select reqirerd">
                                    <asp:ListItem Text="Select" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                                <label>Registration for Machine with full details</label>
                            </div>
                        </div>
                        <%--<div class="col-md-4">
                            <div class="form-floating">
                                <asp:CheckBox ID="chkIsOffsetReg_I" placeholder="Registration Date" CssClass="form-control" runat="server" />
                                <label>Registration for Offset</label>
                            </div>
                        </div>--%>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:TextBox ID="txtRegforYear_I" runat="server" placeholder="Registration Year" Text="" MaxLength="4" CssClass="form-control reqirerd" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'></asp:TextBox>
                                <label>Registration of Years</label>
                            </div>
                        </div>
                        <%--<div class="col-md-4">
                            <div class="form-floating">
                                <asp:DropDownList runat="server" ID="ddlGrade_V" CssClass="form-select reqirerd">
                                    <asp:ListItem Text="A" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="B" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="C" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="D" Value="4"></asp:ListItem>
                                </asp:DropDownList>
                                <label>Grade</label>
                            </div>
                        </div>--%>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:DropDownList runat="server" ID="ddlPayMode" AutoPostBack="true" CssClass="form-select reqirerd" OnSelectedIndexChanged="ddlPayMode_SelectedIndexChanged">
                                    <asp:ListItem Text="select" Value="0"></asp:ListItem>
                                    <asp:ListItem Value="Cash" Text="Cash"></asp:ListItem>
                                    <asp:ListItem Value="Cheque" Text="Cheque"></asp:ListItem>
                                    <asp:ListItem Value="DD" Text="DD"></asp:ListItem>
                                </asp:DropDownList>
                                <label>Pay Mode</label>
                            </div>
                        </div>
                        <asp:Panel ID="Panel1" runat="server">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-floating">
                                        <asp:TextBox ID="txtBankName_V" runat="server" placeholder="Bank Name" Enabled="false" CssClass="form-control" MaxLength="80"
                                            onkeypress="tbx_fnAlphaNumeric(event, this);"></asp:TextBox>
                                        <label>Bank Name</label>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-floating">
                                        <asp:TextBox ID="txtRegDetails_V" runat="server" Enabled="false" MaxLength="40" CssClass="form-control"
                                            onkeypress="tbx_fnAlphaNumeric(event, this);"></asp:TextBox>
                                        <label>Cheque /DD No.</label>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-floating">
                                        <asp:TextBox ID="txtDate" runat="server" Enabled="false" MaxLength="10" Type="date" CssClass="form-control"></asp:TextBox>
                                        <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server"
                                            Format="dd/MM/yyyy" TargetControlID="txtDate">
                                        </cc1:CalendarExtender>
                                        <label>Date</label>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:TextBox ID="txtRegamount_N" runat="server" placeholder="" CssClass="form-control reqirerd" MaxLength="5" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'></asp:TextBox>
                                <label>Registration Amount</label>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel runat="server" ID="pnlreg" GroupingText=" ">
                    <div class="row g-3">
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:TextBox ID="txtNameofPress_V" placeholder="" runat="server" MaxLength="50" CssClass="form-control reqirerd" onkeypress="tbx_fnAlphaNumeric(event, this);"></asp:TextBox>
                                <label>Name of the press</label>
                            </div>
                        </div>
                        <%--<div class="col-md-4">
                            <div class="form-floating">
                                <asp:TextBox ID="txtNameOfPressHindi" placeholder="" runat="server" MaxLength="50" CssClass="form-control reqirerd" onkeypress="tbx_fnAlphaNumeric(event, this);"></asp:TextBox>
                                <label>प्रेस का नाम (हिंदी में)</label>
                            </div>
                        </div>--%>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:TextBox ID="txtFullAddress_V" placeholder="" runat="server" MaxLength="80" CssClass="form-control reqirerd" onkeypress="tbx_fnAlphaNumeric(event, this);"></asp:TextBox>
                                <label>Address</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:TextBox ID="txtHeadoffice_V" placeholder="" runat="server" MaxLength="80" CssClass="form-control reqirerd" onkeypress="tbx_fnAlphaNumeric(event, this);"></asp:TextBox>
                                <label>Head Office</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:TextBox ID="txtBOTelegraph_Add_V" placeholder="" runat="server" MaxLength="80" CssClass="form-control reqirerd" onkeypress="tbx_fnAlphaNumeric(event, this);"></asp:TextBox>
                                <label>Branch Office Telegraphic Address</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:TextBox ID="txtEst_Date_D" placeholder="" runat="server" CssClass="form-control reqirerd" MaxLength="10"></asp:TextBox>
                                <cc1:CalendarExtender Format="dd/MM/yyyy" ID="CaltxtEst_Date_D" TargetControlID="txtEst_Date_D" runat="server"></cc1:CalendarExtender>
                                <label>Date of establishment of the press</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:TextBox ID="txtOwnerDeail_V" placeholder="" runat="server" MaxLength="45" CssClass="form-control reqirerd" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                                <label>Full Name (s) of the Owner (s) Directors</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:TextBox ID="txtAreaOccupies_N" placeholder="" runat="server" MaxLength="4" CssClass="form-control reqirerd" onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                <label>Area Occupies (sq. mtrs)</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:RadioButtonList ID="radioAreaType_I" runat="server" RepeatDirection="Horizontal" CssClass="form-control reqirerd">
                                    <asp:ListItem Text="Rented" Value="1"> </asp:ListItem>
                                    <asp:ListItem Text="Owned" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Partially Owned" Value="3"></asp:ListItem>
                                </asp:RadioButtonList>
                                <label>Area Type</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:TextBox ID="txtFacRegNo_V" placeholder="" MaxLength="30" runat="server" CssClass="form-control reqirerd" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                                <label>Factory Registration No.</label>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <strong>If the press registered under</strong>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:RadioButtonList ID="radioReginComact_I" CssClass="form-control reqirerd" runat="server" Font-Size="Small" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="radioReginComact_I_SelectedIndexChanged">
                                    <asp:ListItem Text="Yes" Value="1"> </asp:ListItem>
                                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                </asp:RadioButtonList>
                                <label>Indian Company Act 1973</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:TextBox ID="txtRegDet_V" placeholder="" Enabled="false" CssClass="form-control" MaxLength="10" runat="server" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                                <label>If so State No</label>
                            </div>
                        </div>
                        <dtv class="col-md-12">
                            <strong>Number of person currently</strong>
                        </dtv>
                        <div class="col-md-12">
                            <table class="table table-bordered table-striped table-hover">
                                <tr>
                                    <th>Processing in Employment (As per latest Factory returns )<br />
                                        Except Daily </th>
                                    <th>Operatives
                                    </th>
                                    <th>Supervisors
                                    </th>
                                </tr>

                                <tr>
                                    <td>
                                        <%--(a)--%> Processing Image earners-contractors
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNoofProc_OP_I" runat="server" Width="100px" MaxLength="4"
                                            onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNoofProc_Su_I" runat="server" Width="100px" MaxLength="4"
                                            onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <%--(b)--%>Composing
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNoofComp_OP_I" runat="server" Width="100px" MaxLength="4"
                                            onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNoofComp_Su_I" runat="server" Width="100px" MaxLength="4"
                                            onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <%-- (c)--%> Printing
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNoofPrint_OP_I" runat="server" Width="100px" MaxLength="4"
                                            onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNoofPrint_Su_I" runat="server" Width="100px" MaxLength="4"
                                            onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <%-- (d)--%> Binding
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNoofBind_OP_I" runat="server" Width="100px" MaxLength="4"
                                            onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNoofBind_Su_I" runat="server" Width="100px" MaxLength="4"
                                            onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <%--(e)--%> Misc
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNoofMisc_OP_I" runat="server" Width="100px" MaxLength="4"
                                            onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNoofMisc_Su_I" runat="server" Width="100px" MaxLength="4"
                                            onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <%-- (f)--%> Total
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNoofTotal_OP_I" runat="server" Width="100px" MaxLength="4"
                                            onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNoofTotal_Su_I" runat="server" Width="100px" MaxLength="4"
                                            onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                    </td>
                                </tr>

                            </table>
                        </div>
                        <div class="col-md-12">
                            <strong>Facilities of Proof reading</strong>
                        </div>

                        <div class="col-md-4">
                            <div class="">
                                <label for="file-input">No. Of Proof readers(Language wise ) (2 MB)</label>
                                <asp:FileUpload ID="fileProfreadpath_v" runat="server" CssClass="file-input"></asp:FileUpload> 
                                <asp:Label ID="lblProfreadpath_v" Font-Bold="false" ForeColor="Green" Font-Size="Small" runat="server"></asp:Label>    
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:TextBox ID="txtNoofProofreader_I" placeholder="" runat="server" CssClass="form-control reqirerd" MaxLength="4" onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                <label>No. Of copy holders</label>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <asp:Button ID="BtnPrinterRegistration" runat="server" Text="सुरक्षित करे" CssClass="btn btn-submit" OnClick="BtnPrinterRegistration_Click" OnClientClick="return ValidateAllTextForm();" />

                            <asp:Button ID="BtnBack" runat="server" Text="वापस जाये" CssClass="btn btn-default" OnClick="BtnBack_Click" />
                        </div>
                    </div>
                </asp:Panel>
            </asp:Panel>
        </div>
    </div>

    <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
    </div>

    <div id="SuccessDiv" class="popupnew" style="display: none">
        <div align="right">
            <a href="#" onclick="document.getElementById('SuccessDiv').style.display='none'; document.getElementById('fadeDiv').style.display='none'; ">Closee</a>
        </div>

        <table>
            <tr>
                <td colspan="2"><b>Printer Details Saved Successfully. </b></td>

                <td>
                    <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" /></td>
                <td>
                    <asp:Button ID="btnView" runat="server" Text="Go to View form" OnClick="btnView_Click" /></td>
            </tr>
        </table>
    </div>

    <script type="text/javascript">
        function ShowHide(chk, div) {
            var checkbox = document.getElementById(chk);
            var dropdown = document.getElementById(div);
            if (checkbox.checked == true) {
                dropdown.style.display = "block";
            }
            else { dropdown.style.display = "none"; }
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
</asp:Content>


