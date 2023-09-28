<%@ Page Title="&#2350;.&#2346;&#2381;&#2352; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; / M.P. TBC " Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrinterRptVitranNirdesh.aspx.cs" Inherits="Depo_RptVitranNirdesh" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up1">
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
            <h2>&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2360;&#2375; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2361;&#2379;&#2344;&#2375; &#2357;&#2366;&#2354;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Recieved Book From Printers Details
                     
            </h2>
        </div>
        <div class="portlet-content">
            <div class="table-responsive">
                <table width="100%">
                    <tr>
                        <td style="width: 35%; font-size: medium;" valign="top">
                            <asp:Label ID="LblAcYear" runat="server" Width="200px">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year:</asp:Label>
                            <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                            </asp:DropDownList>
                        </td>
                        <td style="font-size: medium;" valign="top">
                            <asp:Button ID="BtnShow" runat="server" CssClass="btn" OnClick="BtnShow_Click"
                                Text=" &#2357;&#2367;&#2357;&#2352;&#2339; &#2342;&#2375;&#2326;&#2375; / details" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center;" colspan="2">
                            <br />
                        </td>

                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center">

                            <rsweb:ReportViewer ID="ReportViewer1" Width="100%" runat="server" DocumentMapWidth="100%"
                                Height="450px" SizeToReportContent="True">
                            </rsweb:ReportViewer>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>

