<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrinterReport3.aspx.cs" Inherits="Printing_PrinterReport3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div id="ExportDiv" runat="server" >
     <div class="card-header">
        <h2>&#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2360;&#2350;&#2381;&#2348;&#2344;&#2381;&#2343;&#2368; &#2360;&#2306;&#2325;&#2381;&#2359;&#2367;&#2346;&#2381;&#2340; &#2360;&#2381;&#2341;&#2367;&#2340;&#2367; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &#2360;&#2381;&#2341;&#2367;&#2340;&#2367; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;:  <%=System.DateTime.Now.ToString ("dd/MM/yyyy") %>   </h2>
        
    </div>

    <table style="width: 98%" border"2" class="tab"> 
        <tr>

            <th rowspan="2">&#2360; &#2325;&#2381;&#2352;</th>

            <th rowspan="2">&#2325;&#2325;&#2381;&#2359;&#2366;</th>

            <th colspan="3">&#2350;&#2369;&#2342;&#2381;&#2352;&#2367;&#2340; &#2325;&#2368; &#2332;&#2366; &#2352;&#2361;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; </th>

            <th colspan="3">&#2360;&#2381;&#2325;&#2344;&#2381;&#2343; &#2350;&#2375;&#2306; &#2313;&#2346;&#2354;&#2357;&#2381;&#2343; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; </th>

            <th colspan="3">&#2325;&#2369;&#2354; &#2310;&#2357;&#2358;&#2381;&#2351;&#2325; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; </th>

            <th colspan="3">&#2325;&#2369;&#2354; &#2313;&#2346;&#2354;&#2357;&#2381;&#2343; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;
                <br />
                (&#2360;&#2381;&#2325;&#2344;&#2381;&#2343; + &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367;)</th>

            <th colspan="3">&#2358;&#2375;&#2359; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; </th>

        </tr>
        <tr>

            <th>&#2351;&#2379;&#2332;&#2344;&#2366;</th>

            <th>&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; </th>

            <th>&#2351;&#2379;&#2327; </th>

            <th>&#2351;&#2379;&#2332;&#2344;&#2366;</th>

            <th>&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; </th>

            <th>&#2351;&#2379;&#2327; </th>

            <th>&#2351;&#2379;&#2332;&#2344;&#2366;</th>

            <th>&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; </th>

            <th>&#2351;&#2379;&#2327; </th>

            <th>&#2351;&#2379;&#2332;&#2344;&#2366;</th>

            <th>&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; </th>

            <th>&#2351;&#2379;&#2327; </th>

            <th>&#2351;&#2379;&#2332;&#2344;&#2366;</th>

            <th>&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; </th>

            <th>&#2351;&#2379;&#2327; </th>

        </tr>
        <tr>

            <th>1</th>

            <th>2</th>

            <th>3</th>

            <th>4</th>

            <th>5</th>

            <th>6</th>

            <th>7</th>

            <th>8</th>

            <th>9</th>

            <th>10</th>

            <th>11</th>

            <th>12</th>

            <th>13</th>

            <th>14</th>

            <th>15</th>

            <th>16</th>

            <th>17</th>

        </tr>
        <tr>
            <%  COMM.FillDatasetByProc("call usp_rp009_masterreport(0,0,13,0);");
                
                ds1 = COMM.FillDatasetByProc("SELECT * FROM printingsummarydub where class in ('1-5','6-8','9-12')");
               for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
               {
                  
               
                   
                %>

            <td><%if(i==4)
                      
                  { %> <%} 
                         else { %><%=i+1%><%} %></td>

            <td><%=ds1.Tables[0].Rows[i]["class"].ToString () %></td>

            <td align="left" ><%=ds1.Tables[0].Rows[i]["allotyoj"].ToString () %></td>

            <td align="left" ><%=ds1.Tables[0].Rows[i]["allotgen"].ToString () %></td>

            <td align="left" ><%=ds1.Tables[0].Rows[i]["total1"].ToString () %></td>

            <td><%=ds1.Tables[0].Rows[i]["stockyoj"].ToString () %></td>

            <td><%=ds1.Tables[0].Rows[i]["stockgen"].ToString () %></td>

            <td><%=ds1.Tables[0].Rows[i]["total2"].ToString () %></td>

            <td><%=ds1.Tables[0].Rows[i]["requiryoj"].ToString () %></td>

            <td><%=ds1.Tables[0].Rows[i]["requirgen"].ToString () %></td>

            <td><%=ds1.Tables[0].Rows[i]["totalreq"].ToString () %></td>

            <td><%=ds1.Tables[0].Rows[i]["totavailyoj"].ToString () %></td>

            <td><%=ds1.Tables[0].Rows[i]["totavailgen"].ToString () %></td>

            <td><%=ds1.Tables[0].Rows[i]["totavailable"].ToString () %></td>

            <td><%=ds1.Tables[0].Rows[i]["BalYoj"].ToString () %></td>

            <td><%=ds1.Tables[0].Rows[i]["BalGen"].ToString () %></td>

            <td><%=ds1.Tables[0].Rows[i]["TotBalance"].ToString () %></td>

        </tr>
       
        
       
        <tr>

            <td>&nbsp;</td>

            <td>&nbsp;</td>

            <td align="left" >&nbsp;</td>

            <td align="left" >&nbsp;</td>

            <td align="left" >&nbsp;</td>

            <td>&nbsp;</td>

            <td>&nbsp;</td>

            <td>&nbsp;</td>

            <td>&nbsp;</td>

            <td>&nbsp;</td>

            <td>&nbsp;</td>

            <td>&nbsp;</td>

            <td>&nbsp;</td>

            <td>&nbsp;</td>

            <td>&nbsp;</td>

            <td>&nbsp;</td>

            <td>&nbsp;</td>

        </tr><%} %>
       
        
       
        <tr>
            <%ds2 = COMM.FillDatasetByProc("SELECT * FROM printingsummarydub where class in ('Total')");
              %>
            <td colspan="2">&#2325;&#2369;&#2354; </td>

              <td align="left" ><%=ds2.Tables[0].Rows[0]["allotyoj"].ToString () %></td>

            <td align="left" ><%=ds2.Tables[0].Rows[0]["allotgen"].ToString () %></td>

            <td align="left" ><%=ds2.Tables[0].Rows[0]["total1"].ToString () %></td>

            <td><%=ds2.Tables[0].Rows[0]["stockyoj"].ToString () %></td>

            <td><%=ds2.Tables[0].Rows[0]["stockgen"].ToString () %></td>

            <td><%=ds2.Tables[0].Rows[0]["total2"].ToString () %></td>

            <td><%=ds2.Tables[0].Rows[0]["requiryoj"].ToString () %></td>

            <td><%=ds2.Tables[0].Rows[0]["requirgen"].ToString () %></td>

            <td><%=ds2.Tables[0].Rows[0]["totalreq"].ToString () %></td>

            <td><%=ds2.Tables[0].Rows[0]["totavailyoj"].ToString () %></td>

            <td><%=ds2.Tables[0].Rows[0]["totavailgen"].ToString () %></td>

            <td><%=ds2.Tables[0].Rows[0]["totavailable"].ToString () %></td>

            <td><%=ds2.Tables[0].Rows[0]["BalYoj"].ToString () %></td>

            <td><%=ds2.Tables[0].Rows[0]["BalGen"].ToString () %></td>

            <td><%=ds2.Tables[0].Rows[0]["TotBalance"].ToString () %></td>

        </tr>
       
         <tr>

            <td colspan="2">&#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340; </td>

            <td align="left" >&nbsp;</td>

            <td align="left" >&nbsp;</td>

            <td align="left" >&nbsp;</td>

            <td>&nbsp;</td>

            <td>&nbsp;</td>

            <td>&nbsp;</td>

            <td>&nbsp;</td>

            <td>&nbsp;</td>

            <td>&nbsp;</td>

            <td>&nbsp;</td>

            <td>&nbsp;</td>

            <td> <%=Convert.ToString(Math.Round( (Convert.ToDecimal( ds2.Tables[0].Rows[0]["totavailable"])/ Convert.ToDecimal( ds2.Tables[0].Rows[0]["totalreq"]))*100,2))  %> %

            </td>

            <td>&nbsp;</td>

            <td>&nbsp;</td>

            <td><%=Convert.ToString(Math.Round( (Convert.ToDecimal( ds2.Tables[0].Rows[0]["TotBalance"])/ Convert.ToDecimal( ds2.Tables[0].Rows[0]["totalreq"]))*100,2))  %> %</td>

        </tr>
       
    </table></div>
     <asp:Button ID="btnExportPDF" runat="server" CssClass="btn_gry" 
                            OnClientClick="return PrintPanel();" Text="Print"  />
    . <asp:Button ID="btnExport" runat="server" CssClass="btn_gry"
        Text="Export to Excel" OnClick="btnExport_Click" />
    <script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=ExportDiv.ClientID %>");

            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title><style>.tab {width: 100%;  border-collapse: collapse;  border-left: 1px solid #d8d8d8; }.tab th { color: #000;border-bottom: 1px solid #d8d8d8;  border-top: 1px solid #d8d8d8;  background: #f1f1f1;  font-weight: bold; }   .tab th, .tab td {  padding: 8px 10px;  text-align: center;  font-size: 1em;    border-bottom: 1px solid #d8d8d8; border-right: 1px solid #d8d8d8;  border-left: 1px solid #d8d8d8; background: transparent; }  .tab th { color: #000;  border-bottom: 1px solid #d8d8d8;  border-top: 1px solid #d8d8d8;  background: #f1f1f1;  font-weight: bold;  } .tab th, .tab td { padding: 8px 10px; text-align: center; font-size: 1em; border-bottom: 1px solid #d8d8d8;   border-right: 1px solid #d8d8d8;   border-left: 1px solid #d8d8d8;   background: transparent; }</style>');
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

