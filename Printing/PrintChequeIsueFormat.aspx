<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrintChequeIsueFormat.aspx.cs" Inherits="PrintChequeIsueFormat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            font-weight: bold;
            text-align: center;
        }
        .auto-style2 {
            text-align: right;
        }
        </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">    
    <table class="table" width="100%">
        <tr>
                            <th style="text-align:left" class="portlet-header ui-widget-header">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2348;&#2367;&#2354; </th>
                        </tr>

        <tr>
            <td colspan="4">
                
<div runat="server" id = "ExportDiv"> <br /><br />    
    <table width="75%">
        <tr style="background-color:#EBEDEF;color:black;">
            <td  align="right" style="width:97%;vertical-align:central" colspan="4">
               Date : <asp:Label ID="lblCheqDate" runat="server" Font-Bold="true"></asp:Label><br /><br /> </td>
            
        </tr>
      
         <tr>
            <td colspan="4" style="background-color:#33DAFF;color:black;">
               Pay&nbsp;&nbsp;&nbsp;<asp:Label ID="lblPrinter" runat="server" Font-Bold="true"></asp:Label>&nbsp;&nbsp;को उनके आदेश पर OR ORDER<br /><br />
                रुपये Rupees&nbsp;&nbsp;&nbsp;<asp:Label ID="lblRupHindi" runat="server" Font-Bold="true"></asp:Label>&nbsp;&nbsp;अदा करें <span>₹</span>&nbsp;
                <asp:Label ID="lblCheqAmt" runat="server" CssClass="txtbox" Font-Bold="true"></asp:Label>
            </td>
            
        </tr>

    </table>
    </div>
            </td>
        </tr>
    </table>
    
    <div style="padding-left:10px;"><br /><br />
    <asp:Button ID="btnExport" runat="server" Text="Print"  CssClass="btn" OnClientClick="PrintPanel();" />
        </div>

     <script type = "text/javascript">
         function PrintPanel() {
             var panel = document.getElementById("<%=ExportDiv.ClientID %>");

             var printWindow = window.open('', '', 'height=400,width=800');
             printWindow.document.write('<html><head><title>Printer Voucher Bill Detail</title>');
             printWindow.document.write('</head><body >');
             printWindow.document.write(panel.innerHTML);
             printWindow.document.write('</body></html>');
             printWindow.document.close();
             setTimeout(function () {
                 printWindow.print(); 

             }, 500);
             return false;
         }</script>
</asp:Content>

