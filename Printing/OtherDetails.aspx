<%@ Page Title="Other Details" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OtherDetails.aspx.cs" Inherits="Printing_OtherDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-body">
            <div class="card-header">
                <h2>अन्य जानकारी</h2>
            </div>
            <div class="row g-3">
                <asp:Panel runat="server" ID="PnlOther" GroupingText="">
        
                <asp:HiddenField runat="server" ID="hdnRegOthID" Value="0" />
                    <div class="row">
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtNoofshift_V" MaxLength="4" runat="server" placeholder="" CssClass="form-control reqirerd" onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                        <label>How many shifts do you Normally run ?</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtBookPrintExperience_V" MaxLength="150" placeholder="" TextMode="MultiLine" runat="server" CssClass="form-control reqirerd" onpaste="MaxLengthCount(this,150);" onkeypress="MaxLengthCount(this,150);tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                        <label>Experience in printing of books including text books</label>
                    </div>
                </div>
                        </div>
                <div class="col-md-12">
                    <strong>No. of titles of books printed during the last 3 year with Quantity of each</strong>
                </div>
                <div class="col-md-12">
                    <table class="table table-bordered">
                        <tr>
                            <th>Corporation </th>
                            <th>Description</th>
                            <th>No. of titles</th>
                        </tr>
                        <tr>
                            <td>(a) M.P. Text Book Corporation 
                            </td>
                            <td></td>
                            <td>
                                <asp:TextBox ID="NOofTitle_MPTBCPrint_I" MaxLength="6" runat="server" Width="80px" CssClass="form-control reqirerd" onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>(b) Other Text Book Corporation  

                            </td>
                            <td>
                                <asp:TextBox ID="txtNameOfTitle_OThTBCPrint_V" MaxLength="50" runat="server" Width="280px" CssClass="form-control" onkeypress="tbx_fnAlphaNumeric(event, this);"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtNOofTitle_OThTBCPrint_I" MaxLength="6" runat="server" Width="80px" CssClass="form-control" onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>(c) Other</td>
                            <td>
                                <asp:TextBox ID="txtOtherCorpName_V" MaxLength="50" Width="280px" CssClass="form-control" runat="server" onkeypress="tbx_fnAlphaNumeric(event, this);"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="txtOtherCorpNo_I" MaxLength="6" runat="server" Width="80px" CssClass="form-control" onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                            </td>

                        </tr>
                    </table>
                </div>
                <div class="col-md-12">
                    <table class="" cellspace="5" cellpadding="5">
                        <tr>
                            <td colspan="2" style="vertical-align: middle">Warehousing facilities for stocking paper issued for printing
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtWareHouseDet_V" MaxLength="150" Width="300px" TextMode="MultiLine" runat="server" CssClass="form-control reqirerd" onpaste="MaxLengthCount(this,150);" onkeypress="MaxLengthCount(this,150);tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="vertical-align: middle">Whether premises and goods insured against fire,
                                    <br />
                                theft, burglary etc. if so, please state the name of Insurance company
                        <br />
                                with policy number and the amount covered.
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtPremises_GoodIns_V" MaxLength="150" Width="300px" TextMode="MultiLine" runat="server" CssClass="form-control reqirerd" onpaste="MaxLengthCount(this,150);" onkeypress="MaxLengthCount(this,150);tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="vertical-align: middle">Will your insurance cover our materials and works in progress in your plan ?
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtIns_CoverDetail_V" MaxLength="150" Width="300px" TextMode="MultiLine" runat="server" CssClass="form-control reqirerd" onpaste="MaxLengthCount(this,150);" onkeypress="MaxLengthCount(this,150);tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="vertical-align: middle">Name and address of your Bankers
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtNameaddbanker_v" MaxLength="200" Width="300px" TextMode="MultiLine" runat="server" CssClass="form-control reqirerd" onpaste="MaxLengthCount(this,200);" onkeypress="MaxLengthCount(this,200);tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">Are you on the list of approved contractors of controller ptg?
                            </td>
                            <td colspan="2">
                                <asp:RadioButtonList runat="server" ID="RadioApprovContractor_I" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="Yes" Value="1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:TextBox ID="txtApprovContractor_I" Visible="false" MaxLength="4" runat="server"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="vertical-align: middle">Any other information which you consider necessary to furnish 
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtAnyOthDetails_V" MaxLength="200" Width="300px" TextMode="MultiLine" runat="server" CssClass="form-control reqirerd" onpaste="MaxLengthCount(this,200);" onkeypress="MaxLengthCount(this,200);tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">Are you an income Tax Payee?
                            </td>
                            <td colspan="2">
                                <asp:RadioButtonList runat="server" ID="RadioIncometaxPay" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="Yes" Value="1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                </asp:RadioButtonList>

                                <asp:TextBox ID="txtIncometaxPay" Visible="false" MaxLength="4" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Button ID="btnOtherDetailsSave" runat="server" Text="सुरक्षित करे" CssClass="btn btn-primary" OnClick="btnOtherDetailsSave_Click" OnClientClick="return ValidateAllTextForm();" />
                                <asp:Button ID="BtnBack" runat="server" Text="वापस जाये" CssClass="btn btn-default" OnClick="BtnBack_Click" />

                            </td>
                        </tr>
                    </table>
                </div>
                    </asp:Panel>
            </div>
        </div>
    </div>

  
    <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
    </div>

    <div id="SuccessDiv" class="popupnew" style="display: none">
        <div align="right">
            <a href="#" onclick="document.getElementById('fadeDiv').style.display='none'; document.getElementById('SuccessDiv').style.display='none';">Printer Details Saved Successfully. </a>
        
             <asp:Button ID="btnNext" runat="server" CssClass="btn btn-primary" Text="Next" OnClick="btnNext_Click" />
             <asp:Button ID="btnView" runat="server" CssClass="btn btn-default"  Text="Go to View form" OnClick="btnView_Click" />

        </div>
        </div>
</asp:Content>

