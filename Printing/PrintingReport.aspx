<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrintingReport.aspx.cs" Inherits="Depo_PrintingReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="card-header">
       <%-- <h2>CLASS WISE DETAIL OF TOTAL PRINTING & SUPPLY FOR THE ACADEMIC YEAR 2016-17</h2>--%>
    </div>
    <br />
     <asp:Button ID="btnExportPDF" runat="server" CssClass="button btn_gry"  Visible="true" 
                            OnClientClick="return PrintPanel();" Text="Print"  />
      <asp:Button ID="btnExport" runat="server" CssClass="btn_gry"
        Text="Export to Excel" OnClick="btnExport_Click" />
    <div id="ExportDiv" runat="server" >
  
    <table style="width: 95%"  class="tabtwo" align="center" > 
       <tr>  <th colspan="14"> CLASS WISE DETAIL OF TOTAL PRINTING & SUPPLY FOR THE ACADEMIC YEAR 2016-17 <span style="float:right;">As on <%=System.DateTime.Now.ToString ("dd/MM/yyyy") %></span>   </th> </tr>
       
        
         <tr>
            <th colspan="14" align="center" >&#2346;&#2381;&#2352;&#2366;&#2341;&#2350;&#2367;&#2325; </th>

        </tr>
        <tr>

            <th rowspan="2">&#2325;&#2325;&#2381;&#2359;&#2366; </th>

            <th colspan="3" align="center">&#2351;&#2379;&#2332;&#2344;&#2366; </th>

            <th colspan="3">&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; </th>

            <th colspan="3">&#2325;&#2369;&#2354; &#2351;&#2379;&#2327;</th>

            <th colspan="2">&#2358;&#2375;&#2359;</th>

            <th>&#2325;&#2369;&#2354; &#2358;&#2375;&#2359;</th>

            <th>&nbsp;&#2358;&#2375;&#2359;
                &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;</th>

        </tr>
        <tr>

            <th>&#2310;&#2357;&#2306;&#2335;&#2344; </th>

            <th>&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; </th>

            <th>&#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340; </th>

            <th>&#2310;&#2357;&#2306;&#2335;&#2344; </th>

            <th>&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; </th>

            <th>&#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340; </th>

            <th>&#2310;&#2357;&#2306;&#2335;&#2344; </th>

            <th>&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; </th>

            <th>&#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340; </th>

            <th>&#2351;&#2379;&#2332;&#2344;&#2366; </th>

            <th>&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; </th>

            <th>&#2351;&#2379;&#2332;&#2344;&#2366; +&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; </th>

            <th>&nbsp;&#2325;&#2366;&nbsp;&#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340;</th>

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

        </tr>
        <tr>
            <% ds1 = COMM.FillDatasetByProc("call USP_Rp009_Masterreportbook ('2016-2017',1)");
               for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
               { 
               
               
                %>

            <td><%=ds1.Tables[0].Rows[i]["Class"].ToString () %></td>

            <td><%=ds1.Tables[0].Rows[i]["TOTAL_AllotYOJ"].ToString () %></td>

            <td><%=ds1.Tables[0].Rows[i]["ReceiptYoj"].ToString () %></td>

            <td><%=ds1.Tables[0].Rows[i]["allper"].ToString () %>
</td>

            <td><%=ds1.Tables[0].Rows[i]["TOTAL_Allotgen"].ToString () %></td>

            <td><%=ds1.Tables[0].Rows[i]["ReceiptGen"].ToString () %></td>

            <td><%=ds1.Tables[0].Rows[i]["recper"].ToString () %></td>

            <td><%=ds1.Tables[0].Rows[i]["TotalAllot"].ToString () %></td>

            <td><%=ds1.Tables[0].Rows[i]["TotalReceipt"].ToString () %></td>

            <td><%=ds1.Tables[0].Rows[i]["totalPer"].ToString () %></td>

            <td><%=ds1.Tables[0].Rows[i]["balanceYoj"].ToString () %></td>

            <td><%=ds1.Tables[0].Rows[i]["balancegen"].ToString () %></td>

            <td><%=ds1.Tables[0].Rows[i]["Totalbalance"].ToString () %></td>

            <td><%=ds1.Tables[0].Rows[i]["balanceper"].ToString () %></td>

        </tr><%} %>
        <tr>

            <th>&#2351;&#2379;&#2327;</th>

            <th><%=ds1.Tables[1].Rows[0]["sumTOTAL_AllotYOJ"].ToString () %></th>

            <th><%=ds1.Tables[1].Rows[0]["sumReceiptYoj"].ToString () %></th>

            <th><%=ds1.Tables[1].Rows[0]["sumallper"].ToString () %></th>

            <th><%=ds1.Tables[1].Rows[0]["sumTOTAL_Allotgen"].ToString () %></th>

            <th><%=ds1.Tables[1].Rows[0]["sumReceiptGen"].ToString () %></th>
           
            <th><%=ds1.Tables[1].Rows[0]["sumrecper"].ToString () %></th>

            <th><%=ds1.Tables[1].Rows[0]["sumTotalAllot"].ToString () %></th>

            <th><%=ds1.Tables[1].Rows[0]["sumTotalReceipt"].ToString () %></th>

            <th><%=ds1.Tables[1].Rows[0]["sumtotalPer"].ToString () %></th>

            <th><%=ds1.Tables[1].Rows[0]["sumbalanceYoj"].ToString () %></th>

            <th><%=ds1.Tables[1].Rows[0]["sumbalancegen"].ToString () %></th>

            <th><%=ds1.Tables[1].Rows[0]["sumTotalbalance"].ToString () %></th>

            <th><%=ds1.Tables[1].Rows[0]["sumbalanceper"].ToString () %></th>

        </tr>
    </table>
    <table style="width: 95%" border"2" class="tabtwo"> 
        <tr>
            <th colspan="14">&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;&#2367;&#2325; </th>

        </tr>
        <tr>

            <th rowspan="2">&#2325;&#2325;&#2381;&#2359;&#2366;    <th colspan="3">&#2351;&#2379;&#2332;&#2344;&#2366; </th>

            <th colspan="3">&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; </th>

            <th colspan="3">&#2325;&#2369;&#2354; &#2351;&#2379;&#2327;</th>

            <th colspan="2">&#2358;&#2375;&#2359;</th>

            <th>&#2325;&#2369;&#2354; &#2358;&#2375;&#2359;</th>

            <th>&nbsp;&#2358;&#2375;&#2359;
                &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;</th>

        </tr>
        <tr>

            <th>&#2310;&#2357;&#2306;&#2335;&#2344; </th>

            <th>&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; </th>

            <th>&#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340; </th>

            <th>&#2310;&#2357;&#2306;&#2335;&#2344; </th>

            <th>&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; </th>

            <th>&#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340; </th>

            <th>&#2310;&#2357;&#2306;&#2335;&#2344; </th>

            <th>&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; </th>

            <th>&#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340; </th>

            <th>&#2351;&#2379;&#2332;&#2344;&#2366; </th>

            <th>&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; </th>

            <th>&#2351;&#2379;&#2332;&#2344;&#2366; +&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; </th>

            <th>&nbsp;&#2325;&#2366;&nbsp;&#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340;</th>

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

        </tr>
        <tr>
            <% ds2 = COMM.FillDatasetByProc("call USP_Rp009_Masterreportbook ('2016-2017',2)");
               for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
               { 
               
               
                %>

            <td><%=ds2.Tables[0].Rows[i]["Class"].ToString () %></td>

            <td><%=ds2.Tables[0].Rows[i]["TOTAL_AllotYOJ"].ToString () %></td>

            <td><%=ds2.Tables[0].Rows[i]["ReceiptYoj"].ToString () %></td>

            <td><%=ds2.Tables[0].Rows[i]["allper"].ToString () %>
</td>

            <td><%=ds2.Tables[0].Rows[i]["TOTAL_Allotgen"].ToString () %></td>

            <td><%=ds2.Tables[0].Rows[i]["ReceiptGen"].ToString () %></td>

            <td><%=ds2.Tables[0].Rows[i]["recper"].ToString () %></td>

            <td><%=ds2.Tables[0].Rows[i]["TotalAllot"].ToString () %></td>

            <td><%=ds2.Tables[0].Rows[i]["TotalReceipt"].ToString () %></td>

            <td><%=ds2.Tables[0].Rows[i]["totalPer"].ToString () %></td>

            <td><%=ds2.Tables[0].Rows[i]["balanceYoj"].ToString () %></td>

            <td><%=ds2.Tables[0].Rows[i]["balancegen"].ToString () %></td>

            <td><%=ds2.Tables[0].Rows[i]["Totalbalance"].ToString () %></td>

            <td><%=ds2.Tables[0].Rows[i]["balanceper"].ToString () %></td>

        </tr><%} %>
        <tr>

            <th>&#2351;&#2379;&#2327;</th>

            <th><%=ds2.Tables[1].Rows[0]["sumTOTAL_AllotYOJ"].ToString () %></th>

            <th><%=ds2.Tables[1].Rows[0]["sumReceiptYoj"].ToString () %></th>

            <th><%=ds2.Tables[1].Rows[0]["sumallper"].ToString () %></th>

            <th><%=ds2.Tables[1].Rows[0]["sumTOTAL_Allotgen"].ToString () %></th>

            <th><%=ds2.Tables[1].Rows[0]["sumReceiptGen"].ToString () %></th>

            <th><%=ds2.Tables[1].Rows[0]["sumrecper"].ToString () %></th>

            <th><%=ds2.Tables[1].Rows[0]["sumTotalAllot"].ToString () %></th>

            <th><%=ds2.Tables[1].Rows[0]["sumTotalReceipt"].ToString () %></th>

            <th><%=ds2.Tables[1].Rows[0]["sumtotalPer"].ToString () %></th>

            <th><%=ds2.Tables[1].Rows[0]["sumbalanceYoj"].ToString () %></th>

            <th><%=ds2.Tables[1].Rows[0]["sumbalancegen"].ToString () %></th>

            <th><%=ds2.Tables[1].Rows[0]["sumTotalbalance"].ToString () %></th>

            <th><%=ds2.Tables[1].Rows[0]["sumbalanceper"].ToString () %></th>

        </tr>
    </table>
 <table style="width: 95%" border"2" class="tabtwo"> 
        <tr>
            <th colspan="14">&#2313;&#2330;&#2381;&#2330;&#2340;&#2352; &#2350;&#2366;&#2343;&#2381;&#2351;&#2350;&#2367;&#2325; </th>

        </tr>
        <tr>

            <th rowspan="2">&#2325;&#2325;&#2381;&#2359;&#2366;   
                 <th colspan="3">&#2351;&#2379;&#2332;&#2344;&#2366; </th>

            <th colspan="3">&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; </th>

            <th colspan="3">&#2325;&#2369;&#2354; &#2351;&#2379;&#2327;</th>

            <th colspan="2">&#2358;&#2375;&#2359;</th>

            <th>&#2325;&#2369;&#2354; &#2358;&#2375;&#2359;</th>

            <th>&nbsp;&#2358;&#2375;&#2359;
                &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; </th>

        </tr>
        <tr>

            <th>&#2310;&#2357;&#2306;&#2335;&#2344; </th>

            <th>&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; </th>

            <th>&#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340; </th>

            <th>&#2310;&#2357;&#2306;&#2335;&#2344; </th>

            <th>&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; </th>

            <th>&#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340; </th>

            <th>&#2310;&#2357;&#2306;&#2335;&#2344; </th>

            <th>&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; </th>

            <th>&#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340; </th>

            <th>&#2351;&#2379;&#2332;&#2344;&#2366; </th>

            <th>&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; </th>

            <th>&#2351;&#2379;&#2332;&#2344;&#2366; +&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; </th>

            <th>&#2325;&#2366;&nbsp;&#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340;</th>

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

        </tr>
        <tr>
            <% ds3 = COMM.FillDatasetByProc("call USP_Rp009_Masterreportbook ('2016-2017',3)");
               for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
               { 
               
               
                %>

            <td><%=ds3.Tables[0].Rows[i]["Class"].ToString () %></td>

            <td><%=ds3.Tables[0].Rows[i]["TOTAL_AllotYOJ"].ToString () %></td>

            <td><%=ds3.Tables[0].Rows[i]["ReceiptYoj"].ToString () %></td>

            <td><%=ds3.Tables[0].Rows[i]["allper"].ToString () %>
</td>

            <td><%=ds3.Tables[0].Rows[i]["TOTAL_Allotgen"].ToString () %></td>

            <td><%=ds3.Tables[0].Rows[i]["ReceiptGen"].ToString () %></td>

            <td><%=ds3.Tables[0].Rows[i]["recper"].ToString () %></td>

            <td><%=ds3.Tables[0].Rows[i]["TotalAllot"].ToString () %></td>

            <td><%=ds3.Tables[0].Rows[i]["TotalReceipt"].ToString () %></td>

            <td><%=ds3.Tables[0].Rows[i]["totalPer"].ToString () %></td>

            <td><%=ds3.Tables[0].Rows[i]["balanceYoj"].ToString () %></td>

            <td><%=ds3.Tables[0].Rows[i]["balancegen"].ToString () %></td>

            <td><%=ds3.Tables[0].Rows[i]["Totalbalance"].ToString () %></td>

            <td><%=ds3.Tables[0].Rows[i]["balanceper"].ToString () %></td>

        </tr><%} %>
        <tr>

            <th>&#2351;&#2379;&#2327;</th>

            <th><%=ds3.Tables[1].Rows[0]["sumTOTAL_AllotYOJ"].ToString () %></th>

            <th><%=ds3.Tables[1].Rows[0]["sumReceiptYoj"].ToString () %></th>

            <th><%=ds3.Tables[1].Rows[0]["sumallper"].ToString () %></th>

            <th><%=ds3.Tables[1].Rows[0]["sumTOTAL_Allotgen"].ToString () %></th>

            <th><%=ds3.Tables[1].Rows[0]["sumReceiptGen"].ToString () %></th>

            <th><%=ds3.Tables[1].Rows[0]["sumrecper"].ToString () %></th>

            <th><%=ds3.Tables[1].Rows[0]["sumTotalAllot"].ToString () %></th>

            <th><%=ds3.Tables[1].Rows[0]["sumTotalReceipt"].ToString () %></th>

            <th><%=ds3.Tables[1].Rows[0]["sumtotalPer"].ToString () %></th>

            <th><%=ds3.Tables[1].Rows[0]["sumbalanceYoj"].ToString () %></th>

            <th><%=ds3.Tables[1].Rows[0]["sumbalancegen"].ToString () %></th>

            <th><%=ds3.Tables[1].Rows[0]["sumTotalbalance"].ToString () %></th>

            <th><%=ds3.Tables[1].Rows[0]["sumbalanceper"].ToString () %></th>

        </tr>
        <tr>

            <th>&#2350;&#2361;&#2366;&#2351;&#2379;&#2327;</th>

             <th><%=ds3.Tables[2].Rows[0]["sumTOTAL_AllotYOJ"].ToString () %></th>

            <th><%=ds3.Tables[2].Rows[0]["sumReceiptYoj"].ToString () %></th>

            <th><%=ds3.Tables[2].Rows[0]["sumallper"].ToString () %></th>

            <th><%=ds3.Tables[2].Rows[0]["sumTOTAL_Allotgen"].ToString () %></th>

            <th><%=ds3.Tables[2].Rows[0]["sumReceiptGen"].ToString () %></th>

            <th><%=ds3.Tables[2].Rows[0]["sumrecper"].ToString () %></th>

            <th><%=ds3.Tables[2].Rows[0]["sumTotalAllot"].ToString () %></th>

            <th><%=ds3.Tables[2].Rows[0]["sumTotalReceipt"].ToString () %></th>

            <th><%=ds3.Tables[2].Rows[0]["sumtotalPer"].ToString () %></th>

            <th><%=ds3.Tables[2].Rows[0]["sumbalanceYoj"].ToString () %></th>

            <th><%=ds3.Tables[2].Rows[0]["sumbalancegen"].ToString () %></th>

            <th><%=ds3.Tables[2].Rows[0]["sumTotalbalance"].ToString () %></th>

            <th><%=ds3.Tables[2].Rows[0]["sumbalanceper"].ToString () %></th>

        </tr>
    </table>

    <table style="width: 95%" border"1" class="tabtwo"> 
        <tr>
            <th colspan="14"> </th>

        </tr>
        <tr>

            <th rowspan="2" valign="middle">&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<th rowspan="2" valign="middle">&#2357;&#2367;&#2357;&#2352;&#2339;    <th colspan="3">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; </th>

            <th colspan="3">&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367;</th>

            <th colspan="3">&#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340;</th>

            <th colspan="3"><%=System.DateTime.Now.ToString ("dd/MM/yyyy") %>&nbsp;&#2325;&#2379; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; </th>

        </tr>
        <tr>

            <th>&#2351;&#2379;&#2332;&#2344;&#2366; </th>

            <th>&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;&nbsp; </th>

            <th>&#2351;&#2379;&#2327;&nbsp; </th>

            <th>&#2351;&#2379;&#2332;&#2344;&#2366; </th>

            <th>&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;&nbsp; </th>

            <th>&#2351;&#2379;&#2327;&nbsp; </th>

            <th>&#2351;&#2379;&#2332;&#2344;&#2366; </th>

            <th>&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;&nbsp; </th>

            <th>&#2351;&#2379;&#2327;&nbsp; </th>

            <th>&#2351;&#2379;&#2332;&#2344;&#2366; </th>

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

        </tr>
        <tr>
            

            <td>1</td>

            <td>&#2325;&#2325;&#2381;&#2359;&#2366; -1 &#2360;&#2375;&nbsp; &#2325;&#2325;&#2381;&#2359;&#2366; -12 &#2327;&#2376;&#2352; &#2319;&#2344;.&#2360;&#2368;.&#2310;&#2352;.&#2335;&#2368;.</td>

            <td><%=ds3.Tables[3].Rows[0]["TOTAL_AllotYOJ"].ToString () %></td>

            <td><%=ds3.Tables[3].Rows[0]["TOTAL_Allotgen"].ToString () %></td>

            <td><%=ds3.Tables[3].Rows[0]["Totalalot"].ToString () %>
</td>

            <td><%=ds3.Tables[3].Rows[0]["ReceiptYoj"].ToString () %></td>

            <td><%=ds3.Tables[3].Rows[0]["ReceiptGen"].ToString () %></td>

            <td><%=ds3.Tables[3].Rows[0]["TotalReceipt"].ToString () %></td>

            <td><%=ds3.Tables[3].Rows[0]["peryoj"].ToString () %></td>

            <td><%=ds3.Tables[3].Rows[0]["pergen"].ToString () %></td>

            <td><%=ds3.Tables[3].Rows[0]["pertotal"].ToString () %></td>

             <td><%=ds3.Tables[5].Rows[0]["ReceiptYoj"].ToString () %></td>

            <td><%=ds3.Tables[5].Rows[0]["ReceiptGen"].ToString () %></td>

            <td><%=ds3.Tables[5].Rows[0]["TotQty"].ToString () %></td>

        </tr>
        <tr>

            <td>2</td>

            <td>&#2319;&#2344;.&#2360;&#2368;.&#2310;&#2352;.&#2335;&#2368;.&#2325;&#2325;&#2381;&#2359;&#2366; -3 &#2360;&#2375; &#2407;&#2407; &#2325;&#2375; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; </td>

            <td><%=ds3.Tables[4].Rows[0]["TOTAL_AllotYOJ"].ToString () %></td>

            <td><%=ds3.Tables[4].Rows[0]["TOTAL_Allotgen"].ToString () %></td>

            <td><%=ds3.Tables[4].Rows[0]["Totalalot"].ToString () %></td>

            <td><%=ds3.Tables[4].Rows[0]["ReceiptYoj"].ToString () %></td>

            <td><%=ds3.Tables[4].Rows[0]["ReceiptGen"].ToString () %></td>

            <td><%=ds3.Tables[4].Rows[0]["TotalReceipt"].ToString () %></td>

            <td><%=ds3.Tables[4].Rows[0]["peryoj"].ToString () %></td>

            <td><%=ds3.Tables[4].Rows[0]["pergen"].ToString () %></td>

            <td><%=ds3.Tables[4].Rows[0]["pertotal"].ToString () %></td>

            <td><%=ds3.Tables[6].Rows[0]["ReceiptYoj"].ToString () %></td>

            <td><%=ds3.Tables[6].Rows[0]["ReceiptGen"].ToString () %></td>

            <td><%=ds3.Tables[6].Rows[0]["TotQty"].ToString () %></td>

        </tr>
        <tr>

            <th>3</th>

            <th>&#2350;&#2361;&#2366;&#2351;&#2379;&#2327; </th>
            <% if (ds3.Tables[4].Rows[0]["peryoj"].ToString() == "")
               {
                   ds3.Tables[4].Rows[0]["peryoj"] = "0";
               }
                %>
            <th><%=Convert.ToDouble( ds3.Tables[4].Rows[0]["TOTAL_AllotYOJ"])+Convert.ToDouble( ds3.Tables[3].Rows[0]["TOTAL_AllotYOJ"])%></th>

            <th><%=Convert.ToDouble(ds3.Tables[4].Rows[0]["TOTAL_Allotgen"])+Convert.ToDouble(ds3.Tables[3].Rows[0]["TOTAL_Allotgen"]) %></th>

            <th><%=Convert.ToDouble(ds3.Tables[4].Rows[0]["Totalalot"])+Convert.ToDouble(ds3.Tables[3].Rows[0]["Totalalot"]) %></th>

            <th><%=Convert.ToDouble(ds3.Tables[4].Rows[0]["ReceiptYoj"])+Convert.ToDouble(ds3.Tables[3].Rows[0]["ReceiptYoj"]) %></th>

            <th><%=Convert.ToDouble(ds3.Tables[4].Rows[0]["ReceiptGen"])+Convert.ToDouble(ds3.Tables[3].Rows[0]["ReceiptGen"]) %></th>

            <th> <%=Convert.ToDouble(ds3.Tables[4].Rows[0]["TotalReceipt"])+Convert.ToDouble(ds3.Tables[3].Rows[0]["TotalReceipt"]) %></th>

           <th><%=ds3.Tables[2].Rows[0]["sumallper"].ToString () %></th>
            <%--<td><%=Convert.ToDouble(ds3.Tables[4].Rows[0]["peryoj"]) +Convert.ToDouble(ds3.Tables[3].Rows[0]["peryoj"])%></td>--%>

            <th><%=ds3.Tables[2].Rows[0]["sumrecper"].ToString ()%></th>

            <th>  <%=Math.Round(Convert.ToDouble(ds2.Tables[2].Rows[0]["sumtotalPer"]),2) %></th>

 
             <th><%=float.Parse(ds3.Tables[6].Rows[0]["ReceiptYoj"].ToString ())+ float.Parse( ds3.Tables[5].Rows[0]["ReceiptYoj"].ToString ())  %></th>

            <th><%=float.Parse(ds3.Tables[6].Rows[0]["ReceiptGen"].ToString ())+ float.Parse( ds3.Tables[5].Rows[0]["ReceiptGen"].ToString ())  %></th>

            <th><%=float.Parse(ds3.Tables[5].Rows[0]["TotQty"].ToString ()) + float.Parse(ds3.Tables[6].Rows[0]["TotQty"].ToString ()) %></th>

        </tr>
    </table>
    
        
                <div style="font-size:12px; font-weight:bold; width:95%; margin:10px auto 0;">
                  &#2325;&#2369;&#2354; - &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2366; &#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340;     ----   <%=Math.Round(Convert.ToDouble(ds2.Tables[2].Rows[0]["sumtotalPer"]),2) %>
                
                 
<br />
                  &#2325;&#2369;&#2354; - &#2358;&#2375;&#2359; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;      ----  <%=(Convert.ToDouble(ds3.Tables[4].Rows[0]["Totalalot"])+Convert.ToDouble(ds3.Tables[3].Rows[0]["Totalalot"]))-(Convert.ToDouble(ds3.Tables[4].Rows[0]["TotalReceipt"])+Convert.ToDouble(ds3.Tables[3].Rows[0]["TotalReceipt"])) %>
                </div>
              


                     </div>  
     <script type = "text/javascript">
         function PrintPanel() {
             var panel = document.getElementById("<%=ExportDiv.ClientID %>");

             var printWindow = window.open('', '', 'height=400,width=800');
            // printWindow.document.write('<html><head><title></title><style>.tab {width: 100%;  border-collapse: collapse;  border-left: 1px solid #d8d8d8; }.tab th { color: #000;border-bottom: 1px solid #d8d8d8;  border-top: 1px solid #d8d8d8;  background: #f1f1f1;  font-weight: bold; }   .tab th, .tab td {  padding: 8px 10px;  text-align: center;  font-size: 1em;    border-bottom: 1px solid #d8d8d8; border-right: 1px solid #d8d8d8;  border-left: 1px solid #d8d8d8; background: transparent; }  .tab th { color: #000;  border-bottom: 1px solid #d8d8d8;  border-top: 1px solid #d8d8d8;  background: #f1f1f1;  font-weight: bold;  } .tab th, .tab td { padding: 8px 10px; text-align: center; font-size: 1em; border-bottom: 1px solid #d8d8d8;   border-right: 1px solid #d8d8d8;   border-left: 1px solid #d8d8d8;   background: transparent; }</style>');
             printWindow.document.write('<html><head><title></title><style>.tabtwo{width: 100%;border-collapse: collapse;border-left: 1px solid #d8d8d8;margin:0 auto;}.tabtwo th, .tabtwo td{padding: 1px 1px;text-align: center;font-size: 11px;border-bottom: 1px solid #d8d8d8;border-right: 1px solid #d8d8d8;border-left: 1px solid #d8d8d8;background: transparent;}.tabtwo th{color: #000;border-bottom: 1px solid #d8d8d8;border-top: 1px solid #d8d8d8;background: #f1f1f1;font-weight: bold;}.tabtwo tr.odd{background: #f8f8f8;}.tabtwo table{border:none;border-collapse: collapse;padding: 0;}.tabtwo table td{border: none;padding: 0px;}</style>');
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

