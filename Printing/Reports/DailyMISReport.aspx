<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="DailyMISReport.aspx.cs"
    Inherits="Printing_Reports_DaillyMISReport" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="portlet-header ui-widget-header">
        मुद्रणालय की मुद्रण की दैनिक प्रगति की जानकारी / Daily Progress Report of Printer
    </div>
    <div class="portlet-content">
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table width="100%">
                    <tr>
                        <td style="text-align: left">
                            <table width="90%">
                                <tr>
                                    <td class="style1">
                                        <asp:Label ID="LblAcYear" runat="server" Width="100px">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; /<br /> Academic Year:</asp:Label>
                                    </td>
                                    <td class="style1" align="center">
                                        <asp:DropDownList ID="DdlACYear" runat="server" AutoPostBack="True" CssClass="txtbox"
                                            >
                                            <asp:ListItem>..Select Academic Year..</asp:ListItem>
                                            <asp:ListItem>2012-13</asp:ListItem>
                                            <asp:ListItem>2013-14</asp:ListItem>
                                            <asp:ListItem>2014-15</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>दिनांक से<br />
                                        From Date
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtFromDate" CssClass="txtbox reqirerd" MaxLength="10"
                                            Width="180px"></asp:TextBox>
                                        <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" TargetControlID="txtFromDate"
                                            Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>
                                    </td>
                                    <td>दिनांक तक<br />
                                        To Date
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtToDate" CssClass="txtbox reqirerd" MaxLength="10"
                                            Width="180px"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtToDate"
                                            Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                     <td></td>
                                    <td></td>
                                    <td>
                                        <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search"
                                            OnClientClick="return ValidateAllTextForm();" OnClick="btnSearch_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center; padding-top: 20px;"></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                     <td></td>
                                    <td></td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td style="text-align: center; padding-top: 20px;">

                            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                                InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
                                Width="100%" Height="657px">
                            </rsweb:ReportViewer>



                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>


