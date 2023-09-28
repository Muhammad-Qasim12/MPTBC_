<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TenderGroupCountingRpt.aspx.cs" Inherits="Printing_TenderGroupCountingRpt" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="box">
                            <div class="card-header">
                                <h2>&#2344;&#2367;&#2357;&#2367;&#2342;&#2366;<span> &#2350;&#2375; &#2349;&#2366;&#2327; &#2354;&#2375;&#2344;&#2375; &#2357;&#2366;&#2354;&#2375; &#2327;&#2381;&#2352;&#2369;&#2346; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;&nbsp; </span></h2>
                            </div>
         <table width="100%"><tr><td><span style="color: rgb(34, 34, 34); font-family: Arial, Verdan, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: bold; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(252, 253, 253); display: inline !important; float: none;">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;</span></td><td>
             <asp:DropDownList ID="DdlACYear" CssClass="txtbox" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged"></asp:DropDownList> </td><td>&#2360;&#2375;&#2354;&#2375;&#2325;&#2381;&#2335; &#2335;&#2375;&#2306;&#2337;&#2352; </td><td>
             <asp:DropDownList ID="ddlTenderID_I" CssClass="txtbox" runat="server"></asp:DropDownList></td><td>
             &nbsp;</td></tr><tr><td colspan="2">
                 <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                     <asp:ListItem Value="1">&#2319;&#2325;&#2354; &#2342;&#2352; &#2357;&#2366;&#2354;&#2375; &#2327;&#2381;&#2352;&#2369;&#2346;</asp:ListItem>
                     <asp:ListItem Value="3">&#2348;&#2367;&#2344;&#2366; &#2342;&#2352; &#2357;&#2366;&#2354;&#2375; &#2327;&#2381;&#2352;&#2369;&#2346;</asp:ListItem>
                     <asp:ListItem Value="2">&#2327;&#2381;&#2352;&#2369;&#2346;&#2357;&#2366;&#2352;  &#2350;&#2369;&#2342;&#2381;&#2352;&#2325;&#2379; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; </asp:ListItem>
                 </asp:RadioButtonList>
                 </td><td colspan="3">
             <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; " />
                 </td></tr></table>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
        interactivedeviceinfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
        Width="100%" Height="657px">
    </rsweb:ReportViewer></div> 
</asp:Content>


