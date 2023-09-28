<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DailyBookSupplySalesReport.aspx.cs" Inherits="Printing_Reports_DailyBookSupplySalesReport" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="portlet-header ui-widget-header">
        Daily Books Supply (FTB) & Sale Report 
    </div>
    <table width="100%">
        <tr>
            <td>
                <asp:Label ID="LblAcYear" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year</asp:Label>
                <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                    <asp:ListItem>..Select..</asp:ListItem>
                    <asp:ListItem>2012-13</asp:ListItem>
                    <asp:ListItem>2013-14</asp:ListItem>
                    <asp:ListItem>2014-15</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="LblClass" runat="server" Width="85px">&#2325;&#2325;&#2381;&#2359;&#2366;  / Class</asp:Label>
                <asp:DropDownList ID="DdlClass" runat="server" CssClass="txtbox" TabIndex="4">
                    <asp:ListItem Value="0">All</asp:ListItem>
                    <asp:ListItem Value="1">1-8</asp:ListItem>
                    <asp:ListItem Value="2">9-12</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search " OnClick="btnSearch_Click" />
            </td>
            <%--<td>माध्यम/Medium
                <asp:DropDownList ID="ddlMedium" AutoPostBack="false" CssClass="txtbox" runat="server">
                    <asp:ListItem Value="0" Text="Select.."></asp:ListItem>
                </asp:DropDownList>
            </td>--%>
        </tr>
    </table>



    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
        interactivedeviceinfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
        Width="100%" Height="657px">
    </rsweb:ReportViewer>

</asp:Content>

