<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SupplyReport.aspx.cs" Inherits="DistributionB_SupplyReport" %>

 <%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="box table-responsive">
        <div class="card-header">
            <h2 class="auto-style1">&#2348;&#2381;&#2354;&#2366;&#2325;&#2357;&#2366;&#2352; &#2309;&#2344;&#2381;&#2351;  &#2346;&#2366;&#2336;&#2381;&#2351;&#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; &#2325;&#2366; &#2310;&#2357;&#2335;&#2344; &#2319;&#2357;&#2306; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351;</h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr>
                    <td>&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352;/Academic Year
                        <asp:DropDownList ID="ddlFyYr" runat="server" AutoPostBack="True" CssClass="txtbox reqirerd" onselectedindexchanged="ddlFyYr_SelectedIndexChanged">
                        </asp:DropDownList>
                        &#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Letter No.
                        <asp:DropDownList ID="ddlLetterNo" runat="server" CssClass="txtbox reqirerd">
                        </asp:DropDownList>
                        <br />
                        <asp:Button ID="btnSearch" runat="server" CssClass="btn" onclick="btnSearch_Click" OnClientClick="javascript:return ValidateAllTextForm();" Text="&#2326;&#2379;&#2332;&#2375;&#2306;/ Search" />
                    </td>
                </tr>
                <tr>
                    <td>
                         <rsweb:ReportViewer Width="100%" ID="RVDistrictSupply" runat="server">
                    </rsweb:ReportViewer>  
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </asp:Content>
