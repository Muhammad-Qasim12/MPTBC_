<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReportPrinterwiseTitlesWiseMasterRpt_New.aspx.cs" Inherits="ReportPrinterwiseTitlesWiseMasterRpt" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <script type="text/javascript">
         var rptCtrl = '<%=ReportViewer1.ClientID%>' + '_ctl09';
         var rptCtrl11 = '<%=ReportViewer1.ClientID%>';
    </script>
    <script type="text/javascript" src="../../js/jquery-1.3.2.js"></script> 
    <script type="text/javascript" src="../../js/printrdlc.js"></script> 
    <div class="portlet-header ui-widget-header">
        प्रिंटर पुस्तकों की प्रिंटिंग एवं वितरण 
    </div>

    <table width="100%">
        <tr>
            <td>
                <asp:Label ID="LblAcYear" runat="server">प्रिंटर का नाम / Name of Printer</asp:Label>
                <asp:DropDownList ID="ddlPrinterName" runat="server" CssClass="txtbox" Width="100px">
                </asp:DropDownList>
            </td>
            <td>शीर्षक/ Title
                <asp:DropDownList ID="ddlTital" runat="server" CssClass="txtbox" Width="100px"></asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="LblClass" runat="server" Width="85px">&#2325;&#2325;&#2381;&#2359;&#2366;  / Class</asp:Label>
                <asp:DropDownList ID="DdlClass" runat="server" CssClass="txtbox" TabIndex="4" Width="60px">
                    <asp:ListItem Value="0">All</asp:ListItem>
                    <asp:ListItem Value="1">1 To 8</asp:ListItem>
                    <asp:ListItem Value="2">9 To 12  </asp:ListItem>
                    <asp:ListItem Value="3">1 To 12</asp:ListItem>
                    <asp:ListItem Value="4">NCERT</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="ddlBookType" runat="server" CssClass="txtbox reqirerd" Width="120px" Visible="false"  >
                    <asp:ListItem Value="0">All</asp:ListItem>
                    <asp:ListItem Value="1">योजना</asp:ListItem>
                    <asp:ListItem Value="2">सामान्य</asp:ListItem>
                </asp:DropDownList>
            </td>

            <%--  <td>
                <asp:RadioButton ID="rdoRptSummary" runat="server" GroupName="rptType" Text="Summery" Checked="true" />
                <asp:RadioButton ID="rdoRptDetail" runat="server" GroupName="rptType" Text="Detail" />
            </td>--%>
            <td>
                <asp:CheckBox ID="chkOrderByDate" runat="server" Text="Order By 100% Date" onclick="clearAllRadios()" />                
            </td>
              <td>
                <asp:RadioButton ID="rdoAll" runat="server" GroupName="rptAll"  Text="All" />
                <asp:RadioButton ID="rdoL100" runat="server" GroupName="rptAll" Text="Less Than 100%" />
                  <asp:RadioButton ID="rdoH100" runat="server" GroupName="rptAll" Text="Equal To 100%" />
            </td>
            <td>
                <asp:CheckBox ID="chkPrintAll" runat="server" Text="सिंगल पेज में सारे रिकॉर्ड देखें" />
            </td>
            <td>                
                <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search " OnClick="btnSearch_Click" />
            </td>
            
        </tr>
    </table>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
        interactivedeviceinfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
        Width="100%" Height="657px" >
    </rsweb:ReportViewer>

<script type="text/javascript">
    function clearAllRadios() {
        var radList = document.getElementsByName('ctl00$ContentPlaceHolder1$rptAll');
        for (var i = 0; i < radList.length; i++) {
            if (radList[i].checked) radList[i].checked = false;
        }
    }
</script>
</asp:Content>

