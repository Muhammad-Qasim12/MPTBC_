<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrintDemand.aspx.cs" Inherits="Distribution_PrintDemand" %>


<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style type="text/css">
       #ctl00_ContentPlaceHolder1_ddlPrinterName label {
  /**display: block;*/
  padding-left: 23px;
  text-indent: -15px;
  float: left;
}

.chkChoice input 
{ 
    width: 13px;
  height: 13px;
  padding: 0;
  margin:0;
  vertical-align: bottom;
  position: relative;
  top: -1px;
  *overflow: hidden;
  float: left;
}

.chkChoice td 
{ 
    padding-left: 10px; 
}

.PnlDesign
{
            border: solid 1px #000000;
            height: 150px;
            width: 330px;
            overflow-y:scroll;
            background-color: #EAEAEA;
            font-size: 15px;
            font-family: Arial;
}
    </style>
     <script type="text/javascript">
         var rptCtrl = '<%=ReportViewer1.ClientID%>' + '_ctl09';
         var rptCtrl11 = '<%=ReportViewer1.ClientID%>';
    </script>
    <script type="text/javascript" src="../../js/jquery-1.3.2.js"></script> 
    <script type="text/javascript" src="../../js/printrdlc.js"></script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div style="overflow: auto" class="rdlc">
                    <rsweb:ReportViewer ID="ReportViewer1" Width="100%" runat="server"
                        DocumentMapWidth="100%" Height="" SizeToReportContent="True">
                    </rsweb:ReportViewer>
                </div>
</asp:Content>

