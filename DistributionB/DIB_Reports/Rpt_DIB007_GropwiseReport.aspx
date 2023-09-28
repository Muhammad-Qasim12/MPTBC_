<%@ Page Title="&#2327;&#2381;&#2352;&#2369;&#2346;&#2357;&#2366;&#2352; &#2350;&#2366;&#2306;&#2327; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339;"
    Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Rpt_DIB007_GropwiseReport.aspx.cs"
    Inherits="DistributionB_DIB_Reports_Rpt_DIB007_GropwiseReport" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
 

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>&#2327;&#2381;&#2352;&#2369;&#2346;&#2357;&#2366;&#2352; &#2350;&#2366;&#2306;&#2327;
                    &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339;/ Groupwise demand Distribution</span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table>
                    <tr>
                        <td>&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;/Academic Year </td>
                        <td>

                            <asp:DropDownList ID="ddlAcYear" runat="server" AutoPostBack="True"
                                CssClass="txtbox reqirerd" OnSelectedIndexChanged="ddlAcYear_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;/Title</td>
                        <td>

                            <asp:DropDownList ID="ddlTitle" CssClass="txtbox reqirerd" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTitle_SelectedIndexChanged">
                            </asp:DropDownList>
                            <td>
                                डिमांड सेलेक्ट करे <asp:DropDownList ID="ddldemand" CssClass="txtbox reqirerd" runat="server" OnSelectedIndexChanged="ddldemand_SelectedIndexChanged">
                            </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="रिपोर्ट देखें/Report"
                                    OnClientClick='javascript:return ValidateAllTextForm();' OnClick="btnSearch_Click" /></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td>&nbsp;</td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="6">
                            <rsweb:ReportViewer Width="100%" ID="RVGroupwiseSupply" runat="server">
                            </rsweb:ReportViewer>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
