<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Rpt_DIB006_DepowiseSupplyDepo.aspx.cs" Inherits="Depo_Rpt_DIB006_DepowiseSupplyDepo" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

     

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                &nbsp;<span>&#2332;&#2367;&#2354;&#2366;&#2357;&#2366;&#2352; &#2350;&#2366;&#2306;&#2327; &#2325;&#2366; &#2357;&#2367;&#2340;&#2352;&#2339;</span>
                / Districtwise Supply Information</h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
            <tr>
                <td>
                   &#2357;&#2367;&#2340;&#2381;&#2340;&#2368;&#2351; &#2357;&#2352;&#2381;&#2359; / Financial Year <asp:DropDownList ID="ddlFyYr" CssClass="txtbox reqirerd" runat="server" 
                        AutoPostBack="True" onselectedindexchanged="ddlFyYr_SelectedIndexChanged">
                    </asp:DropDownList>
                    &#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Letter No.
                    <asp:DropDownList ID="ddlLetterNo" CssClass="txtbox reqirerd" runat="server">
                    </asp:DropDownList>
                    <br />
                 

                    <asp:Button runat="server" ID="btnSearch" Text="&#2326;&#2379;&#2332;&#2375;&#2306;/ Search"
                                    OnClientClick='javascript:return ValidateAllTextForm();' 
                        CssClass="btn" onclick="btnSearch_Click" />

                </td>
            </tr>
            <tr>
                <td>
                   <%-- <rsweb:ReportViewer Width="100%" ID="RVDistrictSupply" runat="server">
                    </rsweb:ReportViewer>  --%> 
                    <rsweb:ReportViewer ID="RVDistrictSupply" Width="100%" runat="server"></rsweb:ReportViewer>


                </td>
            </tr>

            </table>
        </div>
    </div>
</asp:Content>

