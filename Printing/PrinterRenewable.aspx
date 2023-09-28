<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrinterRenewable.aspx.cs" Inherits="Printing_PrinterRenewable" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
                <h2>रिन्यूअल की जानकारी</h2>
            </div>
        <div class="card-body">
            
            <div class="row g-3">
                <div class="col-md-12">
                    <div id="messageDiv" runat="server" class="form-message" style="display: none;">
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtRenewaldate" runat="server" Type="date" CssClass="form-control reqirerd"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtBookingDate0_CalendarExtender" runat="server" TargetControlID="txtRenewaldate"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="txtBookingDate0_MaskedEditExtender" runat="server" MaskType="Date" CultureName="en-GB" TargetControlID="txtRenewaldate" Mask="99/99/9999">
                        </cc1:MaskedEditExtender>
                        <label>रिन्यूअल दिनांक</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtRenewAmount" runat="server" placeholder="" CssClass="form-control reqirerd" onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                        <label>रिन्यूअल राशि (रुपये मे )</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtAmtDetail" runat="server" placeholder="" CssClass="form-control reqirerd" TextMode="MultiLine"></asp:TextBox>
                        <label>रिन्यूअल जानकारी</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtRenFrom" Type="date" runat="server" CssClass="form-control reqirerd"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtRenFrom"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" MaskType="Date" CultureName="en-GB" TargetControlID="txtRenFrom" Mask="99/99/9999">
                        </cc1:MaskedEditExtender>
                        <label>रिन्यूअल दिनांक से</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtRenTo_D" Type="date" runat="server" CssClass="form-control reqirerd"
                            OnTextChanged="txtRenTo_D_TextChanged"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtRenTo_D"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" MaskType="Date" CultureName="en-GB" TargetControlID="txtRenTo_D" Mask="99/99/9999">
                        </cc1:MaskedEditExtender>
                        <label>रिन्यूअल दिनांक तक</label>
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-submit" Text="सुरक्षित करे" OnClientClick='javascript:return ValidateAllTextForm();'
                        OnClick="btnSave_Click" />
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:Button ID="btnback" runat="server" CssClass="btn btn-default" OnClick="btnBack_Click"
                        Text="वापस जाये" />
                    <asp:HiddenField ID="HiddenField2" runat="server" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>

