<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
    CodeFile="ReportGsmWiseStockPositionByDate.aspx.cs" Inherits="ReportGsmWiseStockDtlByDate" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-header ui-widget-header">
        शैक्षणिक सत्र के अनुसार सेंट्रल डिपो मे स्टॉक इन्शुरेंस की स्थिति 
    </div>

    <table width="100%">
        <tr>
            <td>
                <asp:Label ID="LblAcYear" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year</asp:Label>
                <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox" Width="120px">
                    <asp:ListItem>..Select..</asp:ListItem>
                    <asp:ListItem>2012-13</asp:ListItem>
                    <asp:ListItem>2013-14</asp:ListItem>
                    <asp:ListItem>2014-15</asp:ListItem>
                </asp:DropDownList>
            </td>
           
           
            <td>&#2332;&#2368;&#2319;&#2360;&#2319;&#2350;/GSM
                    <asp:DropDownList runat="server" ID="ddlPrinter" Width="120px" CssClass="txtbox"  >
                    </asp:DropDownList>&nbsp;<span style="color: #FF0000; vertical-align:top;">*</span>
                </td>

             <%--<td>पेपर मिल/Paper Mill
                    <asp:DropDownList runat="server" ID="ddlVendorName" Width="120px" CssClass="txtbox"  >
                    </asp:DropDownList>
                </td>--%>
           
             <td style="text-align: left;">Date</td>
                    <td style="text-align: left;">
                         <asp:TextBox ID="txtFromDate" runat="server" MaxLength="11" CssClass="txtbox reqirerd"></asp:TextBox>
                         <cc1:calendarextender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtFromDate"
                              Enabled="True" >
                         </cc1:calendarextender>
                         <cc1:filteredtextboxextender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtFromDate"
                           ValidChars="0123456789/-"></cc1:filteredtextboxextender>
                    </td>
                   <%-- <td style="text-align: left;">To Date&nbsp;</td>
                    <td style="text-align: left;">
                        <asp:TextBox ID="txtToDate" runat="server" MaxLength="11" CssClass="txtbox reqirerd"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" TargetControlID="txtToDate"
                              Enabled="True" >
                         </cc1:CalendarExtender>
                         <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtToDate"
                           ValidChars="0123456789/-"> </cc1:FilteredTextBoxExtender>
                    </td>--%>


            <td>
                <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search " OnClick="btnSearch_Click" />
            </td>
        </tr>
    </table>

    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
        interactivedeviceinfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
        Width="100%" Height="657px">
    </rsweb:ReportViewer>

</asp:Content>

