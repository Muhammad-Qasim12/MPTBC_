<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ClasswiseTotalPrintingSupply.aspx.cs" Inherits="Printing_Reports_ClasswiseTotalPrintingSupply" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="portlet-header ui-widget-header">
        &#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; &#2350;&#2375;&#2306; &#2325;&#2325;&#2381;&#2359;&#2366;&#2357;&#2366;&#2352; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2319;&#2357;&#2306; &#2357;&#2367;&#2340;&#2352;&#2339; 
       
    </div>
    <table>
        <tr>
            <td>
                <asp:Label ID="LblAcYear" runat="server" Width="200px">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year:</asp:Label>
                <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                </asp:DropDownList>
                कक्षा समूह / Class Group
                <asp:DropDownList ID="DdlClassTitle" runat="server" CssClass="txtbox">
                    <asp:ListItem  Value="All">सभी</asp:ListItem>
                    <asp:ListItem  Value="Prathamik">प्राथमिक</asp:ListItem>
                    <asp:ListItem  Value="Madhyamik">माध्यमिक</asp:ListItem>
                    <asp:ListItem  Value="UcchaMadhyamik">उच्चतर माध्यमिक</asp:ListItem>
                </asp:DropDownList>

                 <asp:Button ID="BtnShow" runat="server" CssClass="btn" OnClick="BtnShow_Click" 
                 Text=" &#2357;&#2367;&#2357;&#2352;&#2339; &#2342;&#2375;&#2326;&#2375; / details"  Style="padding:3px 3px 3px 3px !Important"/></td>
        </tr>
    </table>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
        interactivedeviceinfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
        Width="100%" Height="657px">
    </rsweb:ReportViewer>

</asp:Content>

