<%@ Page Title="सेंट्रल डिपो में स्टॉक की मात्रा / Stock Quantity in Central Depot " Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="StockbetweenDate.aspx.cs" Inherits="CenterDepot_CenteralReport_StockDetailsbetweenTwoDate" %>

 
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
 
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-header ui-widget-header">
        सेंट्रल डिपो में स्टॉक की मात्रा / Stock Quantity in Central Depot 
    </div>
    <div class="portlet-content">
        <div class="table-responsive">
            <table width="100%" cellpadding="0" cellspacing="0">
             <tr>
                  <td> 
                        &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;
                        <br />
                        Academic Year
                    </td>
                    <td>
                           <asp:DropDownList ID="ddlAcYear" runat="server" CssClass="txtbox" AutoPostBack="true" Width="250px"  >
                        </asp:DropDownList>
                    </td>
                    <td>
                        पेपर का प्रकार<br /> Paper Type
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlPaperType" Width="250px" CssClass="txtbox"
                            OnInit="ddlPaperType_Init">
                            <asp:ListItem Text="All"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        दिनांक से<br />From Date
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFromDate" CssClass="txtbox reqirerd" MaxLength="10"
                            Width="238px"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" TargetControlID="txtFromDate"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                    </td>
                    <td>
                        दिनांक तक<br />To Date
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtToDate" CssClass="txtbox reqirerd" MaxLength="10"
                            Width="238px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtToDate"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search"
                            OnClientClick="return ValidateAllTextForm();" OnClick="btnSearch_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <div style="width: auto; height: auto;">
                            <center>
                                <div class="MT20">
                                    <asp:Panel ID="Panel1" runat="server" Width="100%">
                                        <div style="width: 100%;">
                                            <div style="padding: 10px;">
                                                <table width="100%">
                                                    <tr>
                                                        <td colspan="4" style="font-size: 16px; font-weight: 200; text-align: center;">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" style="font-size: 13px; font-weight: 200; text-align: center;">
                                                            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                                                                InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
                                                                Width="1000px" Height="657px">
                                                            </rsweb:ReportViewer>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>
                            </center>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
