<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PrinterDptchForBook.aspx.cs" Inherits="Paper_PublishAndCoverPaperAllotmentAndSupplyReport"
    Title=" पाठ्यपुस्तकों के लिये मुद्राको को कागज की आबंटित मात्रा" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-header ui-widget-header">
    पाठ्यपुस्तकों के लिये मुद्राको को कागज की आबंटित मात्रा</div>
    <div class="portlet-content">
        <div class="portlet-content">
          <div class="table-responsive">  <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        शैक्षणिक सत्र 
                    </td>
                    <td>
                      <asp:DropDownList runat="server" ID="ddlYear" Width="250px" CssClass="txtbox reqirerd" OnInit="ddlYear_Init">
                        <asp:ListItem Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                    </td>
                    <td><asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375;"
                        OnClick="btnSearch_Click"   OnClientClick="return ValidateAllTextForm();"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                            InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
                            Width="100%" Height="657px">
                        </rsweb:ReportViewer>
                    </td>
                </tr>
            </table></div>
        </div>
        </div>
</asp:Content>
