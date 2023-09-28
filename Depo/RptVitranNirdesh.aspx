<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RptVitranNirdesh.aspx.cs" Inherits="Depo_RptVitranNirdesh" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
           <%-- <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up1">
                <ProgressTemplate>
                    <div class="fade">
                    </div>
                    <div class="progress">
                        <img src="../images/loading.gif" alt="Loading..." width="110" height="110" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>--%>
            <div class="box">
                <div class="card-header">
                    <h2>
                        <span style="font-size: medium;">&#2357;&#2367;&#2340;&#2352;&#2339; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358; 
                        </span>
                    </h2>
                </div>
                <div class="portlet-content">
                    <div class="table-responsive">
                        <table width="100%">
                            <tr>
                                <td style="width: 25%; font-size: medium;" valign="top">
                                    <asp:Label ID="LblAcYear" runat="server" Width="100px">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; :</asp:Label>
                                </td>
                                <td style="width: 25%; font-size: medium;" valign="top">
                                    <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 25%; font-size: medium;" valign="top">&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;</td>
                                <td style="width: 25%; font-size: medium;" valign="top">
                                    <asp:DropDownList ID="ddlMedium" runat="server" CssClass="txtbox reqirerd" Width="120px">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 25%; font-size: medium;" valign="top">&#2325;&#2325;&#2381;&#2359;&#2366; </td>
                                <td style="width: 25%; font-size: medium;" valign="top">
                                    <asp:DropDownList ID="DDLClass" runat="server">
                                        <asp:ListItem Value="1-8">1-8</asp:ListItem>
                                        <asp:ListItem Value="9-12">9-12</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 25%; font-size: medium;" valign="top">&nbsp;</td>
                                <td style="font-size: medium;" valign="top">
                                    <asp:Button ID="BtnShow" runat="server" CssClass="btn" OnClick="BtnShow_Click" 
                                        Text=" &#2357;&#2367;&#2357;&#2352;&#2339; &#2342;&#2375;&#2326;&#2375;" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="8" style="text-align: center">
                                   
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

