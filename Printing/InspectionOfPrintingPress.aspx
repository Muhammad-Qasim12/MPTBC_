<%@ Page Title="मुद्रणालय स्तर पर निरिक्षण की जानकारी" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InspectionOfPrintingPress.aspx.cs" Inherits="Printing_InspectionOfPrintingPress" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
            <h2>मुद्रणालय स्तर पर निरिक्षण की जानकारी</h2>
        </div>
        <div class="card-body">
            <div class="row g-3">
                <div class="col-md-12">
                    <asp:Panel ID="messDiv" runat="server">
                        <asp:Label runat="server" ID="lblMess" class="notification"></asp:Label>
                    </asp:Panel>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox runat="server" ID="txtInspectiondate_D" TextMode="Date" CssClass="form-control reqirerd"></asp:TextBox>
                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="CaltxtInspectiondate_D" TargetControlID="txtInspectiondate_D" runat="server"></cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="MasktxtInspectiondate_D" TargetControlID="txtInspectiondate_D" Mask="99/99/9999" UserDateFormat="None" MaskType="Date" runat="server"></cc1:MaskedEditExtender>
                        <label>निरिक्षण दिनांक</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList runat="server" ID="ddlPrinter_RedID_I" CssClass="form-select reqirerd">
                        </asp:DropDownList>
                        <label>मुद्रणालय का नाम</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox runat="server" ID="txtOfficerName_V" placeholder="" CssClass="form-control reqirerd"></asp:TextBox>
                        <label>अधिकारी का नाम</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox runat="server" ID="txtOfficerDesignation_V" placeholder="" CssClass="form-control reqirerd"></asp:TextBox>
                        <label>पद</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox runat="server" ID="txtInspectionReport_V" placeholder="" CssClass="form-control reqirerd"></asp:TextBox>
                        <label>निरिक्षण रिपोर्ट </label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="">
                        <label>रिपोर्ट अपलोड करे </label>
                        <asp:FileUpload runat="server" ID="fileInspectionReportFile_V" CssClass="file-input reqirerd" />
                        <asp:Label runat="server" ID="lblInspectionReportFile_V"></asp:Label>                        
                    </div>
                </div>
                
                <div class="col-md-12">
                    <div class="form-floating">
                        <asp:Button runat="server" ID="btnSave" CssClass="btn btn-submit" Text="सुरक्षित करे" OnClick="btnSave_Click" />
                        <asp:Button runat="server" ID="btnback" CssClass="btn btn-default" Text="वापस जाये" OnClick="btnback_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

