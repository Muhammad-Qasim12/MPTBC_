<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ncrtBook.aspx.cs" Inherits="Distribution_ncrtBook" %>


<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box">
        <div class="card-header">
            <h2>
                <span>
                    <asp:Label ID="lblTitleName" runat="server">&#2319;&#2344;. &#2360;&#2368; .&#2310;&#2352; .&#2335;&#2368; . &#2325;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; </asp:Label>
                </span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="LblAcYear" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;</asp:Label>
                            <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                            </asp:DropDownList>


                        </td>

                        <td>
                            <asp:DropDownList ID="DropDownList1" runat="server">
                                <asp:ListItem Value="0">All</asp:ListItem>
                                <asp:ListItem Value="1">1-8</asp:ListItem>
                                <asp:ListItem Value="2">9-12</asp:ListItem>
                            </asp:DropDownList>


                        </td>

                        <td>
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Width="300px">
                                <asp:ListItem Selected="True" Value="3">सभी</asp:ListItem>
                                <asp:ListItem Value="1">परिवर्तित </asp:ListItem>
                                <asp:ListItem Value="2">अपरिवर्तित </asp:ListItem>
                            </asp:RadioButtonList>


                        </td>

                        <td style="font-size: medium;" valign="top">
                            <asp:Button ID="Button1" runat="server" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; / See Report" CssClass="btn" OnClick="Button1_Click" />
                        </td>


                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp;</td>


                    </tr></table>

                 <div style="overflow: auto" class="rdlc">
                    <rsweb:ReportViewer ID="ReportViewer1" Width="100%" runat="server"
                        DocumentMapWidth="100%" Height="" SizeToReportContent="True">
                    </rsweb:ReportViewer>
                </div>
            </div> </div> </div> 
</asp:Content>

