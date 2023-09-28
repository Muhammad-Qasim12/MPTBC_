<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
    CodeFile="MediumwiseTotalPrintingSupply_NewFormat.aspx.cs" Inherits="Printing_Reports_MediumwiseTotalPrintingSupply" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="portlet-header ui-widget-header">
        शैक्षणिक सत्र में मुद्रित पुस्तकों के आवंटन  के विरुद्ध प्रदाय 
       
    </div>
    <table>
        <tr>
            <td>
                <asp:Label ID="LblAcYear" runat="server" Width="200px">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year:</asp:Label>
                <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                </asp:DropDownList>
                डिपो / Depo
                <asp:DropDownList ID="DdlDepo" runat="server" CssClass="txtbox">                   
                </asp:DropDownList>

                 &#2350;&#2366;&#2343;&#2381;&#2351;&#2350;
                <asp:DropDownList ID="DdlMedium" runat="server" CssClass="txtbox">                    
                </asp:DropDownList>

                 &nbsp;&#2325;&#2325;&#2381;&#2359;&#2366;&nbsp;/&nbsp;Class Name :<asp:DropDownList ID="DropDownList1" runat="server">
                     <asp:ListItem Value="0">सभी</asp:ListItem>
                    <asp:ListItem Value="1">1-8</asp:ListItem>
                    <asp:ListItem Value="2">9-12</asp:ListItem>
                </asp:DropDownList>

                 <asp:Button ID="BtnShow" runat="server" CssClass="btn" OnClick="BtnShow_Click" 
                 Text=" &#2357;&#2367;&#2357;&#2352;&#2339; &#2342;&#2375;&#2326;&#2375; / details"  Style="padding:3px 3px 3px 3px !Important"/></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
        interactivedeviceinfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
        Width="100%" Height="657px">
    </rsweb:ReportViewer>

</asp:Content>

