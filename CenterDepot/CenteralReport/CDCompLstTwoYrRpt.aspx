<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CDCompLstTwoYrRpt.aspx.cs" Inherits="Paper_CompressionLastTwoYearReport"
    Title="&#2346;&#2375;&#2346;&#2352; &#2360;&#2381;&#2335;&#2377;&#2325; &#2325;&#2366; &#2346;&#2367;&#2331;&#2354;&#2375; &#2357;&#2352;&#2381;&#2359; &#2325;&#2368; &#2340;&#2369;&#2354;&#2344;&#2366; / Last Year Compression Of Paper Stock" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <div class="portlet-header ui-widget-header">
        &#2346;&#2375;&#2346;&#2352; &#2360;&#2381;&#2335;&#2377;&#2325; &#2325;&#2366; &#2346;&#2367;&#2331;&#2354;&#2375; &#2357;&#2352;&#2381;&#2359; &#2325;&#2368; &#2340;&#2369;&#2354;&#2344;&#2366; / Last Year Compression Of Paper Stock<asp:Label ID="lblLastYear" runat="server"></asp:Label>
    </div>
    <div class="portlet-content">
        <div class="portlet-content">
            <div class="table-responsive">
                <table width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="3">&#2332;&#2368;&#2319;&#2360;&#2319;&#2350;/GSM
                    <asp:DropDownList runat="server" ID="ddlGSM" Width="120px" CssClass="txtbox">
                    </asp:DropDownList>&nbsp;
           <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search"
               OnClick="btnSearch_Click" OnClientClick="return ValidateAllTextForm();" />
                        </td>
                    </tr>

                    <tr>
                        <td colspan="3">
                            <center>
                                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                                    InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
                                    Width="100%" Height="657px">
                                </rsweb:ReportViewer>
                            </center>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
