<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DistrictReport.aspx.cs" Inherits="DistributionB_DIB_Reports_DistrictReport" %>

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
                    </asp:DropDownList> </td>
                <td>
                    &#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Letter No.
                    <asp:DropDownList ID="ddlLetterNo" CssClass="txtbox reqirerd" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLetterNo_SelectedIndexChanged">
                    </asp:DropDownList>
                    <br />
                    </td>
                </tr>
                <tr>
                    <td>
                    &#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; :  <asp:DropDownList ID="DDlDepot" CssClass="txtbox reqirerd" runat="server" >
                    </asp:DropDownList>
                        </td>
                    <td>
                                &#2337;&#2367;&#2350;&#2366;&#2306;&#2337; &#2360;&#2375;&#2354;&#2375;&#2325;&#2381;&#2335; &#2325;&#2352;&#2375;<asp:DropDownList ID="ddldemand" CssClass="txtbox reqirerd" runat="server"  >
                            </asp:DropDownList>
                        </td>
                    </tr>
                <tr><td>
                    <asp:Button runat="server" ID="btnSearch" Text="&#2326;&#2379;&#2332;&#2375;&#2306;/ Search"
                                    OnClientClick='javascript:return ValidateAllTextForm();' 
                        CssClass="btn" onclick="btnSearch_Click" />

                </td>
                    <td></td>
            </tr>
            <tr>
                <td colspan="2" >
                    <rsweb:ReportViewer Width="100%" ID="RVDistrictSupply" runat="server">
                    </rsweb:ReportViewer>   
                </td>
            </tr>

            </table>
        </div>
    </div>
</asp:Content>

