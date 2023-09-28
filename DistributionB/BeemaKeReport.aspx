<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BeemaKeReport.aspx.cs" Inherits="DistributionB_BeemaKeReport" %>

 <%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
     

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                &#2348;&#2368;&#2350;&#2366; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; </h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr>
                    <td style="text-align: left" colspan="4">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left">
                        &#2350;&#2366;&#2361;
                    </td>
                    <td style="text-align: left">
                        <asp:DropDownList ID="ddlMonth" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: left">
                        &#2360;&#2340;&#2381;&#2352;
                    </td>
                    <td style="text-align: left">
                        <asp:DropDownList ID="ddlYear" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center" colspan="4">

                    <asp:Button runat="server" ID="btnSearch" Text="&#2326;&#2379;&#2332;&#2375;&#2306;/ Search"
                                    OnClientClick='javascript:return ValidateAllTextForm();' 
                        CssClass="btn" onclick="btnSearch_Click" />

                    </td>
                </tr>
                <tr>
                    <td style="text-align: left" colspan="4">
                        <rsweb:ReportViewer ID="RVDistrictSupply" runat="server" Width="100%">
                        </rsweb:ReportViewer>
                    </td>
                </tr></table> </div> </div> 
</asp:Content>

