<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrinterwiseDailyMIS.aspx.cs" Inherits="Printing_Reports_PrinterwiseDailyMIS" %>

  
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-header ui-widget-header">
        मुद्रणालय की मुद्रण की दैनिक प्रगति की जानकारी / Daily Progress Report of Printer
    </div>
    <div class="portlet-content">
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table>
                    <tr>
                        <td>प्रिंटर चुनिए / Select Printer  
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddlPrinterName" Width="250px" CssClass="txtbox"
                                AutoPostBack="True">
                                <asp:ListItem Text="Select Printer"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ForeColor="Red" SetFocusOnError="true" ID="rqddlVendorFill"
                                runat="server" ErrorMessage="Please Select Printer Name." ControlToValidate="ddlPrinterName"
                                ValidationGroup="Save" InitialValue="Select">*</asp:RequiredFieldValidator>
                        </td>
                        <td>दिनांक से / From Date </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtFromDate" CssClass="txtbox reqirerd" MaxLength="10"
                                Width="238px"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" TargetControlID="txtFromDate"
                                Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                        </td>
                        <td>दिनांक तक / To Date </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtToDate" CssClass="txtbox reqirerd" MaxLength="10"
                                Width="238px"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtToDate"
                                Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                        </td>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search"
                                OnClientClick="return ValidateAllTextForm();" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                </table>
                <hr />
                <div>
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                        InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
                        Width="100%" Height="657px">
                    </rsweb:ReportViewer>
                </div>

            </div>
        </div>
    </div>
</asp:Content>

