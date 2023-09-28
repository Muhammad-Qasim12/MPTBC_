<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReportTitlewiseBookAllotement.aspx.cs" Inherits="Printing_Reports_ReportTitlewiseBookAllotement" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="portlet-header ui-widget-header">
        &#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2357;&#2366;&#2352; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2319;&#2357;&#2306; &#2357;&#2367;&#2340;&#2352;&#2339; 
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
            <td>
                <asp:Label ID="LblClass" runat="server" Width="85px">&#2325;&#2325;&#2381;&#2359;&#2366;  / Class</asp:Label>
                <asp:DropDownList ID="DdlClass" runat="server" CssClass="txtbox" TabIndex="4" Width="80px">
                    <asp:ListItem>All</asp:ListItem>
                    <asp:ListItem>&#2325;&#2325;&#2381;&#2359;&#2366; &#2407; </asp:ListItem>
                    <asp:ListItem>&#2325;&#2325;&#2381;&#2359;&#2366; &#2408;  </asp:ListItem>
                    <asp:ListItem>&#2325;&#2325;&#2381;&#2359;&#2366; &#2409; </asp:ListItem>
                    <asp:ListItem>&#2325;&#2325;&#2381;&#2359;&#2366; &#2410;  </asp:ListItem>
                </asp:DropDownList>
            </td>
             <td>माध्यम/Medium
                <asp:DropDownList ID="ddlMedium" runat="server" CssClass="txtbox reqirerd" Width="120px">
                </asp:DropDownList>
            </td>
             <td>शीर्षक/ Title
                <asp:DropDownList ID="ddlTital" runat="server" CssClass="txtbox" Width="150px"></asp:DropDownList>
            </td>
            <td>
                <asp:RadioButton ID="rdoRptSummary" runat="server" GroupName="rptType" Text="Summary" Checked="true" />
                <asp:RadioButton ID="rdoRptDetail" runat="server" GroupName="rptType" Text="Detail" />
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

