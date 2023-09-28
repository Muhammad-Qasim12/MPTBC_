<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReportPrinterwiseTitlesBookAllotement.aspx.cs" Inherits="Printing_Reports_ReportPrinterwiseTitlesBookAllotement" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-header ui-widget-header">
        शैक्षणिक सत्र के अनुसार प्रिंटर पुस्तकों की प्रिंटिंग एवं वितरण 
    </div>

    <table width="100%">
        <tr>
            <td colspan="6">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="1">पाठ्य सामग्री </asp:ListItem>
                    <asp:ListItem Value="2">अन्य पाठ्य सामग्री </asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
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
                <asp:DropDownList ID="ddlTital" runat="server" CssClass="txtbox" Width="120px"></asp:DropDownList>
            </td>
              <td>Order by
                <asp:RadioButton ID="rdoPrinter" runat="server" GroupName="rptType" Text="मुद्रक" Checked="true" />
                <asp:RadioButton ID="rdoPerc" runat="server" GroupName="rptType" Text="प्रतिशत" />
            </td>
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

