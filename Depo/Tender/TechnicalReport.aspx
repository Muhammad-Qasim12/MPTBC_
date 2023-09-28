<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TechnicalReport.aspx.cs" Inherits="Tender_TechnicalReport" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        var rptCtrl = '<%=ReportViewer1.ClientID%>' + '_ctl09';
        var rptCtrl11 = '<%=ReportViewer1.ClientID%>';
    </script>
    <script type="text/javascript" src="../../js/jquery-1.3.2.js"></script> 
    <script type="text/javascript" src="../../js/printrdlc.js"></script>      
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div class="portlet-header ui-widget-header">
       निविदा की तकनीकी बिड का तुलनात्मक पत्रक</div>
    <div class="portlet-content">
        <div class="portlet-content">
          <div class="table-responsive">  <table width="100%" cellpadding="0" cellspacing="0">
            <tr><td>&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; </td><td>
                <asp:DropDownList ID="ddlAcYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAcYear_SelectedIndexChanged">
                </asp:DropDownList>
                </td><td>&#2344;&#2367;&#2357;&#2367;&#2342;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; </td><td>
                <asp:DropDownList ID="ddlTender" runat="server">
                </asp:DropDownList>
                &nbsp;<asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" OnClientClick="getPrintButton();" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375;&#2306;" />
                </td>
            </tr>
                <tr>
                    <td colspan="4">
                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                            InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
                            Width="100%" Height="657px" ShowPrintButton="true" ShowCredentialPrompts="True" >
                        </rsweb:ReportViewer>
                    </td>
                </tr>
            </table></div>
        </div>
        </div>


</asp:Content>

