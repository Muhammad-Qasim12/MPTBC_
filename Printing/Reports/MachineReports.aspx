<%@ Page Title=" प्रिंटर का नाम / Name of the Printer " Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MachineReports.aspx.cs" Inherits="Printing_Reports_MachineReports" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="portlet-header ui-widget-header">
     मशीन की जानकारी /  Machine Detail </div>
    <div class="portlet-content">
        <div class="portlet-content">
         <div class="table-responsive">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="30%">
                     प्रिंटर का नाम / Name of the Printer
                    </td>
                    <td width="15%">
                      <asp:DropDownList runat="server" ID="ddlPrinter"  CssClass="txtbox reqirerd" OnInit="ddlPrinter_Init">
                        <asp:ListItem Text="All"></asp:ListItem>
                    </asp:DropDownList>
                    </td>
                    <td width="15%"><asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375;"
                        OnClick="btnSearch_Click"   OnClientClick="return ValidateAllTextForm();"/>
                    </td>
                    <td width="15%"></td>
                    <td width="10%"></td>
                    <td width="10%"></td>
                    <td width="10%"></td>
                </tr>
                <tr>
                    <td colspan="7">
                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                            InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
                            Width="100%" Height="1000px">
                        </rsweb:ReportViewer>
                    </td>
                </tr>
            </table></div>
        </div>
</asp:Content>


