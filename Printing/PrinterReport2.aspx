<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrinterReport2.aspx.cs" Inherits="Printing_PrinterReport2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
   <div class="card-header">
        <h2>CLASS WISE DETAIL OF TOTAL PRINTING & SUPPLY FOR THE ACADEMIC YEAR 2016-17</h2>
    </div>
    <div id="ExportDiv" runat="server" >
    <table style="width: 100%" border"2" class="tab"> 
        <tr>

            <th rowspan="2">Sr.No</th>

            <th rowspan="2">Printer Name </th>

            <th>Total</th>

            <th>Allot</th>

            <th colspan="2">Books Total </th>

            <th>%</th>

        </tr>
        <tr>

            <th>Title</th>

            <th>&nbsp;</th>

            <th>Received</th>

            <th>Balance</th>

            <th>&nbsp;</th>

        </tr>
        <tr>

            <th>1</th>

            <th>2</th>

            <th>3</th>

            <th>4</th>

            <th>5</th>

            <th>6</th>

            <th>7</th>

        </tr>
        <tr>
            <% ds1 = COMM.FillDatasetByProc("call usp_rp009_masterreport(0,0,12,0);");
               for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
               { 
               
               
                %>

            <td><%=i+1%></td>

            <td><%=ds1.Tables[0].Rows[i]["NamePrinters"].ToString () %></td>

            <td><%=ds1.Tables[0].Rows[i]["tottitle"].ToString () %></td>

            <td><%=ds1.Tables[0].Rows[i]["TOTAL_Allot"].ToString () %></td>

            <td><%=ds1.Tables[0].Rows[i]["TOTAL_rec"].ToString () %></td>

            <td><%=ds1.Tables[0].Rows[i]["BALANCE"].ToString () %></td>

            <td><%=ds1.Tables[0].Rows[i]["BalCap"].ToString () %></td>

        </tr><%} %>
       
    </table></div>
     <asp:Button ID="btnExportPDF" runat="server" CssClass="btn_gry" 
                            OnClientClick="return PrintPanel();" Text="Print"  />
      <script type = "text/javascript">
          function PrintPanel() {
              var panel = document.getElementById("<%=ExportDiv.ClientID %>");

              var printWindow = window.open('', '', 'height=400,width=800');
              printWindow.document.write('<html><head><title></title>');
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

