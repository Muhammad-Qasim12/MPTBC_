<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RptVitranNirdeshnumber.aspx.cs" Inherits="Distribution_RptVitranNirdeshnumber" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="box table-responsive">

                <div class="card-header">
                    <h2>
                        &#2357;&#2367;&#2340;&#2352;&#2339; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358; &#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352;
                    </h2>
                </div>
                <div class="portlet-content">
                    <div class="table-responsive">
                        <asp:Panel class="response-msg inf ui-corner-all" runat="server" ID="mainDiv" Style="display: block; padding-top: 10px; padding-bottom: 10px;">
                        </asp:Panel>
                        <table width="100%">

                            <tr>
                                <td style="width: 30%; font-size: medium;" valign="top">
                                    <asp:Label ID="LblAcYear" runat="server" Width="180px">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; <br /> Academic Year:</asp:Label>
                                    <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox" AutoPostBack="True" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 40%; font-size: medium;" valign="top">
                                    &#2310;&#2352;&#2381;&#2337;&#2352; &#2344;&#2306;&#2348;&#2352;
                                </td>
                                <td style="font-size: medium;">
                                    <asp:DropDownList ID="ddlOrderNo" runat="server" CssClass="txtbox">
                                    </asp:DropDownList>
                                </td>
                            </tr>

                            <tr>

                                <td colspan="3" style="text-align: center">
                                    <asp:Panel ID="Panel1" runat="server" Width="100%" Height="100%">
                                        </asp:Panel>
                                    <br />

                                    &nbsp;<asp:Button ID="Button3" runat="server" CssClass="btn" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; "  OnClick="Button3_Click"  />

                                </td>

                            </tr>

                            <tr>

                                <td colspan="3" style="text-align: center">
                                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" runat="server"
                        DocumentMapWidth="100%" Height="" SizeToReportContent="True">
                                    </rsweb:ReportViewer>

                                </td>

                            </tr>
                        </table>
                    </div>
                </div>
                <div style="margin-left: 80px;">
                    &nbsp;
                    </div>
            </div>
</asp:Content>

