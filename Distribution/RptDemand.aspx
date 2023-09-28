<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RptDemand.aspx.cs" Inherits="Distrubution_RptDemand" MasterPageFile="~/MasterPage.master" %>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>
 
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box">
        <div class="card-header">
            <h2>
                <span>
                    <asp:Label ID="lblTitleName" runat="server"></asp:Label>
                </span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table width="100%">

                    <tr>
                        <td style="font-size: medium;" valign="top">
                            <asp:Label ID="LblAcYear" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; <br /> Academic Year :</asp:Label>
                            <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox reqirerd">
                            </asp:DropDownList>
                        </td>

                        <td style="font-size: medium;">
                            <asp:Label ID="LblDepot" runat="server">&#2337;&#2367;&#2346;&#2379;  &#2330;&#2369;&#2344;&#2375; <br /> Depot  :</asp:Label>
                            <asp:DropDownList ID="DdlDepot" runat="server" CssClass="txtbox reqirerd"></asp:DropDownList>
                        </td>
                        <td style="font-size: medium;" valign="top">
                            <asp:Label ID="LblMedium" runat="server">&#2350;&#2366;&#2343;&#2381;&#2351;&#2350; <br /> Medium :</asp:Label>
                            <asp:DropDownList ID="DdlMedium" runat="server"></asp:DropDownList>
                        </td>
                    </tr>

                    <tr>



                        <td style="font-size: medium;" valign="top">
                            <asp:Label ID="LblClasses" runat="server">&#2325;&#2325;&#2381;&#2359;&#2366; <br /> Class :</asp:Label>
                            <asp:DropDownList ID="DdlClasses" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search "
                                OnClientClick="return ValidateAllTextForm();" OnClick="btnSearch_Click" />
                        </td>
                    </tr>


                </table>


                <div style="overflow: auto" class="rdlc">
                    <rsweb:ReportViewer ID="ReportViewer1" Width="100%" runat="server"
                        DocumentMapWidth="100%" Height="" SizeToReportContent="True">
                    </rsweb:ReportViewer>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
