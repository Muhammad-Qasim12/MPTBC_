<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PrinterRegistration.aspx.cs" Inherits="Printing_PrinterRegistration"
    Title="PrinterRegistration" %>

<%@ OutputCache Duration="30" VaryByParam="true" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
      <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>Printer Registration</span></h2>
        </div>
        <div style="padding: 0 10px;">
           
           
            <div>
                <asp:HiddenField ID="hdnPrinter_RedID_I" Value="0" runat="server" />
            </div>


            <cc1:TabContainer ID="TabPrinter" runat="server" ActiveTabIndex="0">
               
                <cc1:TabPanel ID="TabPnlPrinterDetails" HeaderText="Printer Details" runat="server">
                    <ContentTemplate>
                        <table width="100%">
                            <tr>
                                <td colspan="4" style="height: 10px;">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Registration No
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRegno_I" runat="server" CssClass="txtbox reqirerd" MaxLength="10"></asp:TextBox>
                                </td>
                                <td>
                                    Registration Date
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRegDate_D" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                                    <cc1:CalendarExtender Format="dd/MM/yyyy" ID="CaltxtRegDate_D" TargetControlID="txtRegDate_D"
                                        runat="server" Enabled="True">
                                    </cc1:CalendarExtender>
                                    <cc1:MaskedEditExtender ID="MasktxtRegDate_D" TargetControlID="txtRegDate_D" Mask="99/99/9999"
                                        MaskType="Date" runat="server" CultureAMPMPlaceholder="" 
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                                        CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True">
                                    </cc1:MaskedEditExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Registration for Offset
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkIsOffsetReg_I" runat="server" onchange="ShowHide('ContentPlaceHolder1_TabPrinter_TabPnlPrinterDetails_chkIsOffsetReg_I','DivIsOffReg');" />
                                    <div id="DivIsOffReg" style="display: none;">
                                        Registration for Year
                                        <asp:TextBox ID="txtRegforYear_I" runat="server" Text="0" Width="25px"></asp:TextBox>
                                    </div>
                                </td>
                                <td>
                                    Grad
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlGrade_V" CssClass="txtbox reqirerd" Width="180px">
                                        <asp:ListItem Text="A" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="B" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="C" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="D" Value="4"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Registration Amount
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRegamount_N" runat="server" CssClass="txtbox reqirerd" MaxLength="4"
                                        onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                </td>
                                <td>
                                    Bank Name/DD No./Date</td>
                                <td>
                                    <asp:TextBox ID="txtRegDetails_V" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="height: 10px;">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>1. Name of the press :</b>
                                </td>
                                <td colspan="3" align="left">
                                    <asp:TextBox ID="txtNameofPress_V" runat="server" MaxLength="80" Width="250px" CssClass="txtbox reqirerd"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>2. Full Address:</b>
                                </td>
                                <td colspan="3" align="left">
                                    <asp:TextBox ID="txtFullAddress_V" runat="server" MaxLength="200" Width="250px" CssClass="txtbox reqirerd"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>3. Head Office:</b>
                                </td>
                                <td colspan="3" align="left">
                                    <asp:TextBox ID="txtHeadoffice_V" runat="server" MaxLength="200" Width="250px" CssClass="txtbox reqirerd"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>4. Branch Office Telegraphic Address:</b>
                                </td>
                                <td colspan="3" align="left">
                                    <asp:TextBox ID="txtBOTelegraph_Add_V" runat="server" MaxLength="200" Width="250px"
                                        CssClass="txtbox reqirerd"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>5. Date of establishment of the press:</b>
                                </td>
                                <td colspan="3" align="left">
                                    <asp:TextBox ID="txtEst_Date_D" runat="server" CssClass="txtbox reqirerd" Width="250px"></asp:TextBox>
                                    <cc1:CalendarExtender Format="dd/MM/yyyy" ID="CaltxtEst_Date_D" TargetControlID="txtEst_Date_D"
                                        runat="server" Enabled="True">
                                    </cc1:CalendarExtender>
                                    <cc1:MaskedEditExtender ID="MasktxtEst_Date_D" TargetControlID="txtEst_Date_D" Mask="99/99/9999"
                                        MaskType="Date" runat="server" CultureAMPMPlaceholder="" 
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                                        CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True">
                                    </cc1:MaskedEditExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>6. Full Name (s) of the Owner (s) Directors:</b>
                                </td>
                                <td colspan="3" align="left">
                                    <asp:TextBox ID="txtOwnerDeail_V" runat="server" MaxLength="45" Width="250px" CssClass="txtbox reqirerd"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>7. Area Occupies:</b>
                                </td>
                                <td colspan="3" align="left">
                                    <asp:TextBox ID="txtAreaOccupies_N" runat="server" Width="250px" MaxLength="4" CssClass="txtbox reqirerd"
                                        onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                    <strong>sq. mtrs</strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Area Type
                                </td>
                                <td colspan="3" align="center">
                                    <asp:RadioButtonList ID="radioAreaType_I" runat="server" RepeatDirection="Horizontal"
                                        CssClass="txtbox reqirerd">
                                        <asp:ListItem Text="Rentee" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Owned" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="partially rented" Value="3"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>8. Factory Registration No.</b>
                                </td>
                                <td colspan="3" align="left">
                                    <asp:TextBox ID="txtFacRegNo_V" MaxLength="30" Width="250px" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>9. <b>Is the press registration under :</b>
                                </td>
                                <td colspan="3" align="left">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    (a) Indian Companies Act. 1913
                                </td>
                                <td colspan="3" align="left">
                                    <asp:RadioButtonList ID="radioReginComact_I" CssClass="txtbox reqirerd" runat="server"
                                        RepeatDirection="Horizontal">
                                        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    (b) If so. please state Nos
                                </td>
                                <td colspan="3" align="left">
                                    <asp:TextBox ID="txtRegDet_V" MaxLength="80" Width="250px" runat="server" CssClass="txtbox reqirerd"
                                        onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <b>10. Number of person currently</b>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <div>
                                        <table class="tab">
                                            <tr>
                                                <th>
                                                    Processing in Employment
                                                    <br />
                                                    (As per latest Factory returns ) Except Daily
                                                </th>
                                                <th>
                                                    Operatives
                                                </th>
                                                <th>
                                                    Supervisors
                                                </th>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    (a) Processing Image earners-contractors
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNoofProc_OP_I" runat="server" Width="100px" MaxLength="4" CssClass="txtbox reqirerd"
                                                        onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNoofProc_Su_I" runat="server" Width="100px" MaxLength="4" CssClass="txtbox reqirerd"
                                                        onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    (b)Composing
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNoofComp_OP_I" runat="server" Width="100px" MaxLength="4" CssClass="txtbox reqirerd"
                                                        onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNoofComp_Su_I" runat="server" Width="100px" MaxLength="4" CssClass="txtbox reqirerd"
                                                        onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    (c) Printing
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNoofPrint_OP_I" runat="server" Width="100px" MaxLength="4" CssClass="txtbox reqirerd"
                                                        onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNoofPrint_Su_I" runat="server" Width="100px" MaxLength="4" CssClass="txtbox reqirerd"
                                                        onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    (d) Binding
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNoofBind_OP_I" runat="server" Width="100px" MaxLength="4" CssClass="txtbox reqirerd"
                                                        onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNoofBind_Su_I" runat="server" Width="100px" MaxLength="4" CssClass="txtbox reqirerd"
                                                        onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    (e) Misc
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNoofMisc_OP_I" runat="server" Width="100px" MaxLength="4" CssClass="txtbox reqirerd"
                                                        onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNoofMisc_Su_I" runat="server" Width="100px" MaxLength="4" CssClass="txtbox reqirerd"
                                                        onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    (f) Total
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNoofTotal_OP_I" runat="server" Width="100px" MaxLength="4" CssClass="txtbox reqirerd"
                                                        onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNoofTotal_Su_I" runat="server" Width="100px" MaxLength="4" CssClass="txtbox reqirerd"
                                                        onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <b>11. Facilities of Proof reading</b>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    (a) No. Of Proof readers(Language wise ) :
                                </td>
                                <td colspan="3" align="left">
                                    <asp:FileUpload ID="fileProfreadpath_v" CssClass="txtbox reqirerd" Width="250px"
                                        runat="server"></asp:FileUpload>
                                    <asp:Label ID="lblProfreadpath_v" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    (b) No. Of copy holders
                                </td>
                                <td colspan="3" align="left">
                                    <asp:TextBox ID="txtNoofProofreader_I" runat="server" CssClass="txtbox reqirerd"
                                        Width="250px" MaxLength="4" onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="3">
                                    <asp:Button ID="BtnPrinterRegistration" runat="server" Text="Save" CssClass="btn"
                                        OnClick="BtnPrinterRegistration_Click" OnClientClick="return ValidateAllTextForm();" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </cc1:TabPanel>
               
               
               
                <cc1:TabPanel ID="TabPnlMachineDetails" HeaderText="Machine Details" runat="server">
                    <ContentTemplate>
                    <div>
                    <asp:HiddenField ID="HdnPriMacDesID_I" Value="0" runat="server" />
                    </div>

                        <table width="100%">
                            <tr>
                                <td style="height: 10px;">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>12. Details of Mechanical Composing equipment.</b>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table class="tab">
                                        <tr>
                                            <th>
                                            </th>
                                            <th>
                                                Model Nos
                                            </th>
                                        </tr>
                                        <tr>
                                            <td>
                                                (a) Mono Type
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtComposing_Monotype_V" MaxLength="4" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                (b) Lino Type
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtComposing_Linotype_V" MaxLength="4" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                (b) Any other
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtComposAnyOthtype_V" MaxLength="4" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 10px;">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <b>13. Foundry type in stock in Kg. 10pt. 12 pt. 14 pt. 18 pt. attach specimen sheets
                                        20pt. 24pt.</b>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:FileUpload runat="server" ID="FileFoundaryTyAtt_V" />
                                    <asp:Label ID="lblFoundaryTyAtt_V" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 10px;">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <b>14. Composing Capacity per day in. Terms of pages as 26X12 pica cms:</b>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table class="tab">
                                        <tr>
                                            <th>
                                            </th>
                                            <th>
                                                Language
                                            </th>
                                            <th>
                                                Pages
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>
                                                (a)
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtComposingCapL1_V" runat="server" MaxLength="45"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtComposingCapP1_I" runat="server" MaxLength="4"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                (b)
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtComposingCapL2_V" runat="server" MaxLength="45"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtComposingCapP2_I" runat="server" MaxLength="4"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                (c)
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtComposingCapL3_V" runat="server" MaxLength="45"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtComposingCapP3_I" runat="server" MaxLength="4"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 10px;">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>15. The Languages in which textbook</b> setting work can be accepted
                                </td>
                                <td>
                                    <asp:FileUpload runat="server" ID="FileLanguagesTxtSetAttach_V" />
                                    <asp:Label ID="lblLanguagesTxtSetAttach_V" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 10px;">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <b>16. Printing Machines:</b>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 10px;">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <div style="border-bottom: dimgray thin solid; border-left: dimgray thin solid; border-top: dimgray thin solid;
                                        border-right: dimgray thin solid;">
                                        <div>
                                        </div>
                                        <table width="100%">
                                            <tr>
                                                <td colspan="2" style="height: 10px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Machine Description
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="height: 10px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Any other size attach separate<br />
                                                    list if necessary web offset Machine.
                                                </td>
                                                <td>
                                                    <asp:FileUpload runat="server" ID="filemFoundaryTyAtt_V" />
                                                    <asp:Label ID="lblmFoundaryTyAtt_V" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="height: 10px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table class="tab">
                                                        <tr>
                                                            <th>
                                                                Machine
                                                            </th>
                                                            <th>
                                                                Make
                                                            </th>
                                                            <th>
                                                                Year
                                                            </th>
                                                            <th>
                                                                Date of Installation
                                                            </th>
                                                            <th>
                                                                No. of Machines
                                                            </th>
                                                            <th>
                                                                Printing Capacity / Day 8 Hrs<br></br>
                                                                (No.of Impressions)
                                                            </th>
                                                            <th>
                                                            </th>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddlMachineDescription" runat="server">
                                                                </asp:DropDownList>
                                                               <%-- <asp:Label ID="HdnPriMacID_I" runat="server" Text="0"></asp:Label>--%>
                                                                <asp:HiddenField ID="HdnPriMacID_I" Value="0" runat="server" />
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtMake_V" runat="server" Width="80px" MaxLength="4"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtYear_I" runat="server" Width="80px" MaxLength="4"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtDateOfInstallation_D" runat="server" Width="80px" MaxLength="10"></asp:TextBox>
                                                                <cc1:CalendarExtender Format="dd/MM/yyyy" ID="CaltxtDateOfInstallation_D" TargetControlID="txtDateOfInstallation_D"
                                                                    runat="server">
                                                                </cc1:CalendarExtender>
                                                                <cc1:MaskedEditExtender ID="MasktxtDateOfInstallation_D" TargetControlID="txtDateOfInstallation_D"
                                                                    Mask="99/99/9999" MaskType="Date" runat="server">
                                                                </cc1:MaskedEditExtender>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtnOOFmACHINE" runat="server" Width="80px" MaxLength="4"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtpRINcAPASITY_v" runat="server" Width="80px" MaxLength="4"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnMachineDetailsave" runat="server" Text="Save" CssClass="btn" OnClick="btnMachineDetailsave_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="height: 10px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:GridView runat="server" ID="grdMachineDetails" AutoGenerateColumns="false" OnRowUpdating="grdMachineDetails_RowUpdating"
                                                        CssClass="tab">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No.">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex+1 %>
                                                                    <asp:HiddenField ID="HdnPriMacID_I" runat="server" Value='<%# Eval("PriMacID_I") %>'></asp:HiddenField>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Machine">
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="HdnmMachineID_I" Value='<%# Eval("MachineID_I") %>' runat="server" />
                                                                    <asp:Label ID="lblmMachineID_I" runat="server" Text='<%# Eval("MachineDescription") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Make">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMake_V" runat="server" Text='<%# Eval("Make_V") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Year">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblYear_I" runat="server" Text='<%# Eval("Year_I") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Date of Installation">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDateOfInstallation_D" runat="server" Text='<%# Eval("DateOfInstallation_D") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="No. of Machines">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblnOOFmACHINE" runat="server" Text='<%# Eval("nOOFmACHINE") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Printing Capacity">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblpRINcAPASITY_v" runat="server" Text='<%# Eval("pRINcAPASITY_v") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Edit">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton runat="server" ID="imgMachineDesEdit" CommandName="Update" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="height: 10px;">
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="height: 10px;">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="btnMachineDesSave" runat="server" Text="Save" CssClass="btn" OnClick="btnMachineDesSave_Click" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </cc1:TabPanel>
               
               
               
                <cc1:TabPanel ID="TabPnlBindingDetails" HeaderText="Binding Details" runat="server">
               
               
                    <ContentTemplate>
                        <div>
                            <asp:HiddenField runat="server" ID="hdnPriBindID_I" Value="0" />
                        </div>
                        <table>
                            <tr>
                                <td colspan="2">
                                    <b>18. Details Binding</b>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table class="tab">
                                        <tr>
                                            <th>
                                                Machinery installation
                                            </th>
                                            <th>
                                                Make
                                            </th>
                                            <th>
                                                Size
                                            </th>
                                            <th>
                                                Nos
                                            </th>
                                            <th>
                                                Owned
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>
                                                1. Folding m/cs 16pp/32
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtMac_FoldingMake_V" MaxLength="15" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMac_FoldingSize_V"  MaxLength="15" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMac_FoldingNos_I"  MaxLength="4" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMac_FoldingOwned_V"  MaxLength="4" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                2. Stitching m/cs( Power operated)
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtMac_StichgMake_V" MaxLength="15" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMac_StichgSize_V" MaxLength="15" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMac_StichgNos_I" MaxLength="4" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMac_StichgOwned_V" MaxLength="4" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                3. cutting m/cs( Hand clamp/ Self clamp automatic)
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtMac_CutMake_V" MaxLength="15" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMac_CutSize_V" MaxLength="15" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMac_CutNos_I" MaxLength="4" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMac_CutOwned_V" MaxLength="4" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                4. Other
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtMac_othMake_V" MaxLength="15" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMac_othSize_V" MaxLength="15" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMac_othNos_I" MaxLength="4" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtMac_othOwned_V" MaxLength="4" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <b>19. State binding capacity(s) upto ?</b>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table class="tab">
                                        <tr>
                                            <th colspan="3">
                                                Nos of Books per day in terms of Books
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>
                                                (a)
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtBookname_V" MaxLength="10" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBookBindCapNo_I"  MaxLength="4" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                (b)
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtBookname1_V"  MaxLength="10" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBook1BindCapNo_I"  MaxLength="4" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                (c)
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtBookname2_V"  MaxLength="10" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtBook2BindCapNo_I"  MaxLength="4" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <b>20. Particulars of offset</b>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table class="tab">
                                        <tr>
                                            <th>
                                                Processing equipment
                                            </th>
                                            <th>
                                                Size
                                            </th>
                                            <th>
                                                Make
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>
                                                a. Camera
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtOffsetCameraSize_V"  MaxLength="10" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtOffsetCameraMake_V"  MaxLength="10" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                b. Whiralar
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtOffsetWhirlarSize_V"  MaxLength="10" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtOffsetWhirlarMake_V"  MaxLength="10" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                c. any other equipment
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtOffsetOthSize_V"  MaxLength="10" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtOffsetOthMake_V"  MaxLength="10" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                d. Contact Cabinet
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtOffsetConCabSize_V"  MaxLength="10" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtOffsetConCabMake_V"  MaxLength="10" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="BtnBindingSave" runat="server" Text="Save" CssClass="btn" OnClick="BtnBindingSave_Click" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </cc1:TabPanel>
              
              
              
                <cc1:TabPanel ID="TabPnlOtherDetails" HeaderText="Other Details" runat="server">
                    <ContentTemplate>
                        <div>
                            <asp:HiddenField runat="server" ID="hdnRegOthID" Value="0" />
                        </div>
                        <table>
                            <tr>
                                <td>
                                    <b>21. How many shifts do you Normally run ?</b>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNoofshift_V"  MaxLength="4" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>22. Experience in printing of books including text books</b>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBookPrintExperience_V"  MaxLength="4" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>23. No. of titles of books printed during the</b>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNOofTitle_TBCPrint_I"  MaxLength="4" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <b>last 3 year with Quantity of each</b>
                                </td>
                                <td>
                                    <asp:TextBox ID="Last3YearQuantity_I"  MaxLength="4" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <table class="tab">
                                        <tr>
                                            <th>
                                                (a) M.P. Text Book Corpn
                                            </th>
                                            <td>
                                                <asp:TextBox ID="NOofTitle_MPTBCPrint_I"  MaxLength="4" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                (b) Other Text Book Corpns
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtNOofTitle_OThTBCPrint_I"  MaxLength="4" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>
                                                (c) Other
                                            </th>
                                            <td>
                                                <asp:TextBox ID="txtNOofTitle_OThPrint_I"  MaxLength="4" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <b>24. Warehousing facilities for stocking paper issued for printing</b>
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtWareHouseDet_V"  MaxLength="10" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <b>25. Whether premises and goods insured</b>
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtPremises_GoodIns_V" runat="server"></asp:TextBox>
                                    against fire, theft, burglary etc. if so, please state the name of Insurance company
                                    with policy number and the amount covered.
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <b>26. Will your insurance cover our materials and works in progress in your plan ?</b>
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtIns_CoverDetail_V"  MaxLength="4" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <b>27. Name and address of your Bankers</b>
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtNameaddbanker_v"  MaxLength="20" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <b>28. Are you on the list of approved</b>
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtApprovContractor_I"  MaxLength="25" runat="server"></asp:TextBox>
                                    contractors of controller ptg?
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <b>29 Any other information which you consider necessary to furnish (separate sheet
                                        may be attached)</b>
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtAnyOthDetails_V" MaxLength="45" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <b>30. Are you an income Tax Payee?</b>
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtIncometaxPay" MaxLength="4" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:Button ID="btnOtherDetailsSave" runat="server" Text="Save" CssClass="btn" OnClick="btnOtherDetailsSave_Click" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </cc1:TabPanel>
               
               
                <cc1:TabPanel ID="TabPnlChecklist" HeaderText="Checklist Details" runat="server">
                    <ContentTemplate>


                        <asp:Panel ID="pnlChk" runat="server">
                            <div>
                                <asp:HiddenField runat="server" ID="HdnRegChkLSTID_I" Value="0" />
                            </div>
                            <table>
                                <tr>
                                    <td style="color: darkgreen; font-size: medium;">
                                        <asp:CheckBox ID="chkRegAmount" runat="server" />
                                        <b>&#2346;&#2306;&#2332;&#2367;&#2351;&#2344; &#2358;&#2369;&#2354;&#2381;&#2325; &#2352;&#2369;&#2346;&#2351;&#2375;
                                            250/- &#2325;&#2381;&#2352;&#2377;&#2360;&#2381;&#2337; &#2348;&#2376;&#2306;&#2325;
                                            &#2337;&#2381;&#2352;&#2366;&#2347;&#2381;&#2335; (&#2309;&#2361;&#2360;&#2381;&#2340;&#2366;&#2325;&#2381;&#2359;&#2352;&#2367;&#2340;)
                                            &#2346;&#2381;&#2352;&#2348;&#2306;&#2343; &#2360;&#2306;&#2330;&#2366;&#2354;&#2325;
                                            ,&#2350;.&#2346;&#2381;&#2352;. &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;
                                            &#2344;&#2367;&#2327;&#2350; , &#2349;&#2379;&#2346;&#2366;&#2354; &#2344;&#2366;&#2350;
                                            &#2360;&#2375; |</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: darkgreen; font-size: medium;">
                                        <asp:CheckBox ID="chkPressActCert" runat="server" />
                                        <b>&#2346;&#2381;&#2352;&#2375;&#2360; &#2319;&#2325;&#2381;&#2335; &#2325;&#2375; &#2309;&#2306;&#2340;&#2352;&#2381;&#2327;&#2340;
                                            &#2332;&#2367;&#2354;&#2366; &#2342;&#2306;&#2337;&#2366;&#2343;&#2367;&#2325;&#2366;&#2352;&#2368;
                                            (...................) &#2325;&#2375; &#2360;&#2350;&#2325;&#2381;&#2359; &#2342;&#2367;&#2319;
                                            &#2327;&#2319; &#2328;&#2379;&#2359;&#2339;&#2366; &#2346;&#2340;&#2381;&#2352;
                                            &#2325;&#2368; &#2313;&#2344;&#2325;&#2375; &#2346;&#2381;&#2352;&#2350;&#2366;&#2339;&#2368;&#2325;&#2352;&#2339;
                                            &#2360;&#2361;&#2367;&#2340; &#2360;&#2340;&#2381;&#2351; &#2346;&#2381;&#2352;&#2340;&#2367;&#2354;&#2367;&#2346;&#2367;
                                            |</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: darkgreen; font-size: medium;">
                                        <asp:CheckBox ID="chkIncomeTaxClearance" runat="server" />
                                        <b>&#2311;&#2344;&#2325;&#2350; &#2335;&#2376;&#2325;&#2381;&#2360; &#2325;&#2381;&#2354;&#2368;&#2351;&#2352;&#2375;&#2306;&#2360;
                                            &#2325;&#2375; &#2309;&#2346;&#2335;&#2370;&#2337;&#2375;&#2335; &#2360;&#2352;&#2381;&#2335;&#2367;&#2347;&#2367;&#2325;&#2375;&#2335;
                                            &#2325;&#2368; &#2346;&#2381;&#2352;&#2340;&#2367;&#2354;&#2367;&#2346;&#2367; |</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: darkgreen; font-size: medium;">
                                        <asp:CheckBox ID="chkLastThreeYrsPrinting" runat="server" />
                                        <b>&#2350;&#2369;&#2342;&#2381;&#2352;&#2339;&#2366;&#2354;&#2351; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366;
                                            &#2346;&#2367;&#2331;&#2354;&#2375; &#2340;&#2368;&#2344;&#2379; &#2357;&#2352;&#2381;&#2359;&#2379;&#2306;
                                            &#2350;&#2375; &#2350;&#2369;&#2342;&#2381;&#2352;&#2367;&#2340; &#2325;&#2368;
                                            &#2327;&#2312; &#2325;&#2350; &#2360;&#2375; &#2325;&#2350; 5 &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2375;
                                            |</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: darkgreen; font-size: medium;">
                                        <asp:CheckBox ID="chkMacPurcBillCopy" runat="server" />
                                        <b>&#2350;&#2358;&#2368;&#2344;&#2379;&#2306; &#2325;&#2375; &#2348;&#2367;&#2354;&#2379;&#2306;
                                            &#2325;&#2368; &#2331;&#2366;&#2351;&#2366; &#2346;&#2381;&#2352;&#2340;&#2367;&#2351;&#2366;
                                            |</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: darkgreen; font-size: medium;">
                                        <asp:CheckBox ID="chkInsurance" runat="server" />
                                        <b>&#2350;&#2369;&#2342;&#2381;&#2352;&#2339;&#2366;&#2354;&#2351; &#2325;&#2375; &#2348;&#2368;&#2350;&#2366;
                                            &#2360;&#2350;&#2381;&#2348;&#2344;&#2381;&#2343;&#2368; &#2342;&#2360;&#2381;&#2340;&#2366;&#2357;&#2375;&#2332;
                                            &#2325;&#2368; &#2331;&#2366;&#2351;&#2366; &#2346;&#2381;&#2352;&#2340;&#2367;
                                            |</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: darkgreen; font-size: medium;">
                                        <asp:CheckBox ID="chkOther" runat="server" onchange="ShowHide('ContentPlaceHolder1_TabPrinter_TabPnlChecklist_chkOther','Divtxt');" />
                                        <b>&#2309;&#2344;&#2381;&#2351;</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="Divtxt" style="display: none;">
                                            <asp:TextBox ID="txtOtherDet" runat="server" CssClass="txtbox" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                        </asp:Panel>
                        <asp:Panel ID="pnlChkWithOffset" runat="server">
                            <table>
                                <tr>
                                    <td style="color: darkgreen; font-size: medium;">
                                        <asp:CheckBox ID="chkProcessCamera" runat="server" />
                                        <b>&#2346;&#2381;&#2352;&#2379;&#2360;&#2375;&#2360; &#2325;&#2376;&#2350;&#2352;&#2366;
                                            24"X24"-1 (&#2319;&#2325;) </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: darkgreen; font-size: medium;">
                                        <asp:CheckBox ID="chkPlateMat" runat="server" />
                                        <b>&#2346;&#2381;&#2354;&#2375;&#2335; &#2348;&#2344;&#2366;&#2344;&#2375; &#2325;&#2375;
                                            &#2360;&#2350;&#2360;&#2381;&#2340; &#2360;&#2366;&#2343;&#2344;</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: darkgreen; font-size: medium;">
                                        <asp:CheckBox ID="chkSingleCallOffset" runat="server" />
                                        <b>&#2360;&#2367;&#2306;&#2327;&#2354; &#2325;&#2354;&#2352; &#2310;&#2347;&#2360;&#2375;&#2335;
                                            &#2350;&#2358;&#2368;&#2344;, &#2360;&#2366;&#2311;&#2395; 18" X 24" &#2351;&#2366;
                                            &#2313;&#2360;&#2360;&#2375; &#2348;&#2396;&#2366; -1-(&#2319;&#2325;)</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="color: darkgreen; font-size: medium;">
                                        <asp:CheckBox ID="chkBindingFacility" runat="server" />
                                        <b>&#2348;&#2368;&#2344;&#2381;&#2337;&#2367;&#2306;&#2327; &#2325;&#2366; &#2313;&#2346;&#2351;&#2369;&#2325;&#2381;&#2340;
                                            &#2357;&#2381;&#2351;&#2357;&#2360;&#2381;&#2341;&#2366;</b>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <tr>
                            <td>
                                <asp:Button ID="btnSave" runat="server" CssClass="btn" OnClick="btnSave_Click" Text="&#2360;&#2375;&#2357; &#2325;&#2352;&#2375; " />
                            </td>
                        </tr>
                        </table>
                    </ContentTemplate>
                </cc1:TabPanel>

            </cc1:TabContainer>


        </div>
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
