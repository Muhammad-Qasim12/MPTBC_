<%@ Page Title="&#2326;&#2369;&#2354;&#2375; &#2348;&#2366;&#2395;&#2366;&#2352; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327; / Open Market Demand" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RptOpenmarketDemand.aspx.cs" Inherits="Depo_RptOpenmarketDemand" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
          <%--  <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                AssociatedUpdatePanelID="up1">
                <ProgressTemplate>
                    <div class="fade">
                    </div>
                    <div class="progress">
                        <img src="../images/loading.gif" alt="Loading..." width="110" height="110" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>--%>
           <div class="box table-responsive">
                <div class="card-header">
                    <h2>
                        <span style="font-size: medium;">&#2326;&#2369;&#2354;&#2375; &#2348;&#2366;&#2395;&#2366;&#2352; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327; / Open Market Demand </span>
                    </h2>
                </div>
                <div class="portlet-content">
                   <div class="box table-responsive">
                        <table width="100%">
                            <tr>
                                <td style="width: 25%; font-size: medium;" valign="top">
                                    <asp:Label ID="LblAcYear0" runat="server" Width="202px">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year:</asp:Label>
                                </td>
                                <td style="width: 25%; font-size: medium;" valign="top">
                                    <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 25%; font-size: medium;" valign="top">&#2350;&#2366;&#2343;&#2381;&#2351;&#2350; </td>
                                <td style="width: 25%; font-size: medium;" valign="top">
                                    <asp:DropDownList ID="ddlMedium" runat="server" CssClass="txtbox reqirerd">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 25%; font-size: medium;" valign="top">&#2325;&#2325;&#2381;&#2359;&#2366; / Class</td>
                                <td style="width: 25%; font-size: medium;" valign="top">
                                    <asp:DropDownList ID="DDLClass" runat="server" CssClass="txtbox">
                                    </asp:DropDownList>
                                </td>
                                <td style="font-size: medium;" valign="top">
                                    &nbsp;</td>
                            </tr>
                           
                            <tr>
                                <td colspan="7" style="font-size: medium;" valign="top">
                                    <asp:Button ID="BtnShow" runat="server" CssClass="btn" OnClick="BtnShow_Click" Text=" &#2357;&#2367;&#2357;&#2352;&#2339; &#2342;&#2375;&#2326;&#2375; / Details" />
                                </td>
                            </tr>
                           
                            <tr>
                                <td colspan="7" style="text-align: center">
                                      <rsweb:ReportViewer ID="ReportViewer1" runat="server" documentmapwidth="100%" height="" sizetoreportcontent="True" width="100%">
                                      </rsweb:ReportViewer>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

