<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BillSummaryReport.aspx.cs" Inherits="Distribution_BillSummaryReport" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
                <div class="card-header">
                    <h2>
                        <span style="font-size: medium;">&#2348;&#2367;&#2354; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Information Of Bill
                        </span>
                    </h2>
                </div>
                <div class="portlet-content">
                    <div class="table-responsive">
                        <table width="100%">
                            <tr>
                                <td style="width: 25%; font-size: medium;" valign="top">
                                    <asp:Label ID="LblAcYear" runat="server" >&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; <br />Academic Year :</asp:Label>
                                    <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 25%; font-size: medium;" valign="top">
                                    <asp:Label ID="LblClass" runat="server" >&#2325;&#2325;&#2381;&#2359;&#2366; <br />Class :</asp:Label>
                                    <asp:DropDownList ID="DdlClass" runat="server" CssClass="txtbox" OnSelectedIndexChanged="DdlClass_SelectedIndexChanged"
                                        AutoPostBack="true">
                                        <asp:ListItem Value="1,2,3,4,5">1-5</asp:ListItem>
                                        <asp:ListItem Value="6,7,8">6-8</asp:ListItem>
                                        <asp:ListItem Value="9,10,11,12">9-12</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 25%; font-size: medium;" valign="top">
                                    <asp:Label ID="LblScheme" runat="server" >&#2350;&#2366;&#2343;&#2381;&#2351;&#2350; <br />Scheme :</asp:Label>
                                    <asp:DropDownList ID="DdlScheme" runat="server" CssClass="txtbox">
                                    </asp:DropDownList>
                                </td>
                                 <td style="width: 25%; font-size: medium;" valign="top">
                                    <asp:Label ID="Label1" runat="server" >&#2337;&#2367;&#2350;&#2366;&#2306;&#2337; &#2335;&#2366;&#2311;&#2346; <br />Demand Type:</asp:Label>
                                    <asp:DropDownList ID="DDlDemandType" runat="server" CssClass="txtbox">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: medium;" valign="top" colspan="4">
                                    <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Show Report" />
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: medium;" valign="top" colspan="4">
                                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" documentmapwidth="100%" height="" sizetoreportcontent="True" width="100%">
                                    </rsweb:ReportViewer>
                                </td>
                            </tr></table> </div> </div> 
</asp:Content>

