<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RptInterdepo.aspx.cs" Inherits="Depo_RptInterdepo" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span style="height: 1px">&#2360;&#2381;&#2335;&#2377;&#2325; &#2346;&#2379;&#2332;&#2368;&#2358;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Stock Position Details</span>
            </h2>
        </div>
        <div style="padding: 0 10px;">
            <table width="100%">
                <tr>
                    <td>&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;  
                    </td>
                    <td>

                    <asp:DropDownList ID="ddlMedium" runat="server" CssClass="txtbox ">
                    </asp:DropDownList>

                    </td>
                    <td>
                        <asp:Button ID="Button3" runat="server" CssClass="btn" OnClick="Button3_Click"
                            OnClientClick="return ValidateAllTextForm();" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375;&#2306; / Report" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
            <rsweb:reportviewer id="ReportViewer1" width="100%" runat="server" documentmapwidth="100%" height="" sizetoreportcontent="True">
                            </rsweb:reportviewer>
                    </td>
                </tr>
            </table>
        </div>
        <div style="overflow: auto" class="rdlc">
        </div>

        
    </div>
    
</asp:Content>

