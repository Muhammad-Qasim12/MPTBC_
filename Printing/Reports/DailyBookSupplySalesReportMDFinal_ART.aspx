<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DailyBookSupplySalesReportMDFinal_ART.aspx.cs" Inherits="Printing_Reports_DailyBookSupplySalesReportMDFinal_ART" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <script type="text/javascript">
         var rptCtrl = '<%=ReportViewer1.ClientID%>' + '_ctl09';
         var rptCtrl11 = '<%=ReportViewer1.ClientID%>';
    </script>
    <script type="text/javascript" src="../../js/jquery-1.3.2.js"></script> 
    <script type="text/javascript" src="../../js/printrdlc.js"></script>
    <div class="portlet-header ui-widget-header">
        Daily Books Supply (FTB) & Sale Report (ART) 
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
                    <asp:ListItem Value="3">1-12</asp:ListItem>
                </asp:DropDownList>
            </td>

             <td colspan="2">
                <asp:Label ID="Label1" runat="server" Width="85px">&#2337;&#2367;&#2346;&#2379; / Depo</asp:Label>
                <asp:DropDownList ID="DdlDepo" runat="server" CssClass="txtbox">                   
                </asp:DropDownList>
            </td>

            <%--<td>&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;/Medium
                <asp:DropDownList ID="ddlMedium" AutoPostBack="false" CssClass="txtbox" runat="server">
                    <asp:ListItem Value="0" Text="Select.."></asp:ListItem>
                </asp:DropDownList>
            </td>--%>
        </tr>
        <tr>
            <td colspan="2">
                <asp:RadioButtonList ID="rd001" runat="server" RepeatDirection="Horizontal" >
                 <asp:ListItem Value="0">&#2360;&#2349;&#2368; </asp:ListItem>
                 <asp:ListItem Value="1">&#2319;&#2344;&#2360;&#2368;&#2312;&#2310;&#2352;&#2335;&#2368;  </asp:ListItem>
                 <asp:ListItem Value="2">&#2327;&#2376;&#2352; &#2319;&#2344;&#2360;&#2368;&#2312;&#2310;&#2352;&#2335;&#2368;  </asp:ListItem>
                 </asp:RadioButtonList>
            </td>

             <td>
                  <asp:RadioButton ID="rdDistrict" runat="server" Text="&#2332;&#2367;&#2354;&#2366; / District" GroupName="rd" Checked="true" />
                <asp:RadioButton ID="rdBlock" runat="server" Text="&#2348;&#2381;&#2354;&#2377;&#2325; / Block" GroupName="rd" /></td>

            <td>
                <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search " OnClick="btnSearch_Click" /></td>
        </tr>
    </table>

    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
        interactivedeviceinfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
        Width="100%" Height="657px">
    </rsweb:ReportViewer>

</asp:Content>

