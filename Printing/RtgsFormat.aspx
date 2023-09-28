<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RtgsFormat.aspx.cs" Inherits="Printing_PrinterChallanRpt" %>

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
    <div runat="server" id = "ExportDiv">  
   
    <table width="100%">
        <tr>
            <td colspan="6" align="center" class="auto-style1" >
                &nbsp;</td>
        </tr>
         
        <tr>
            <td colspan="6" align="center" class="auto-style1" >
                <strong>&#2350;.&#2346;&#2381;&#2352;. &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;<br />
                &nbsp;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2349;&#2357;&#2344;
                <br />
                &#2309;&#2352;&#2375;&#2352;&#2366; &#2361;&#2367;&#2354;&#2381;&#2360;, &#2332;&#2375;&#2354; &#2352;&#2379;&#2337; , &#2349;&#2379;&#2346;&#2366;&#2354; -&nbsp; 462011</strong></td>
        </tr>
         
        <tr>
            <td colspan="6">&nbsp;</td>
        </tr>
         
        <tr>
            <td colspan="6">&#2342;&#2370;&#2352;&#2349;&#2366;&#2359; - 0755-2550727,2551565&nbsp; &#2347;&#2376;&#2325;&#2381;&#2360; -&nbsp; 2551145&nbsp; &#2312;&#2350;&#2375;&#2354; = <a href="mailto:tbcho@yahoo.com">tbcho@yahoo.com</a>&nbsp; &#2357;&#2375;&#2348;&#2360;&#2366;&#2311;&#2335; - mptbc.mp.gov.in</td>
        </tr>
         
        <tr>
            <td colspan="4">&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; :-&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; / &#2346;&#2366;&#2346;&#2369;&#2344;&#2367;/ &#2357;&#2367;&#2340;&#2381;&#2340;&#2381;&#2340;/ 2017</td>
            <td>&nbsp;</td>
            <td>&#2349;&#2379;&#2346;&#2366;&#2354; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; :-</td>
        </tr>
         
        <tr>
            <td colspan="4">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
         
        <tr>
            <td colspan="6">&#2346;&#2381;&#2352;&#2340;&#2367;,<br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &#2358;&#2366;&#2326;&#2366; &#2346;&#2381;&#2352;&#2348;&#2306;&#2343;&#2325;
        <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &#2360;&#2381;&#2335;&#2375;&#2335; &#2348;&#2376;&#2306;&#2325; &#2321;&#2398; &#2311;&#2339;&#2381;&#2337;&#2367;&#2351;&#2366;
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &#2357;&#2367;&#2306;&#2343;&#2381;&#2351;&#2366;&#2330;&#2354;
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &#2349;&#2379;&#2346;&#2366;&#2354;
                <br />
               &nbsp;&nbsp; &nbsp;&nbsp;  
        <br />
            </td>
        </tr>
         
        <tr  >
            <td colspan="6"  ><b>&#2357;&#2367;&#2359;&#2351; :- R.T.G.S. &#2360;&#2375; &#2352;&#2366;&#2358;&#2367; &#2360;&#2381;&#2341;&#2366;&#2344;&#2381;&#2340;&#2352;&#2367;&#2340; &#2325;&#2352;&#2344;&#2375; &#2348;&#2366;&#2357;&#2340; 
                <br />
                </b>
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="6">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &#2346;&#2381;&#2352;&#2348;&#2306;&#2343;&#2325; &#2360;&#2306;&#2330;&#2366;&#2354;&#2325; ,&nbsp;&#2350;.&#2346;&#2381;&#2352;. &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; &#2349;&#2379;&#2346;&#2366;&#2354; &#2325;&#2375; &#2326;&#2366;&#2340;&#2375; &#2360;&#2375; &#2330;&#2375;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; <%=ds1.Tables[0].Rows[0]["mchqno"].ToString()%> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;&nbsp; <%=ds1.Tables[0].Rows[0]["mchqdate"].ToString()%> &nbsp;&nbsp; &#2352;&#2366;&#2358;&#2367;&nbsp;  &#2352;&#2370;&#2346;&#2351;&#2375;  <%=ds1.Tables[0].Rows[0]["mPayAmount_N"].ToString()%> 
                <br />
                <br />
                &#2360;&#2306;&#2354;&#2306;&#2327; &#2325;&#2352; &#2309;&#2344;&#2369;&#2352;&#2379;&#2343; &#2361;&#2376; &#2325;&#2367; &#2325;&#2371;&#2346;&#2351;&#2366; &#2344;&#2367;&#2350;&#2381;&#2344;&#2366;&#2344;&#2369;&#2360;&#2366;&#2352; &#2352;&#2366;&#2358;&#2367;  &#2360;&#2350;&#2381;&#2348;&#2344;&#2381;&#2343;&#2367;&#2340; &#2360;&#2306;&#2360;&#2381;&#2341;&#2366; &#2325;&#2375; &#2326;&#2366;&#2340;&#2375; &#2350;&#2375;&#2306; R.T.G.S. &#2325;&#2375; &#2350;&#2366;&#2343;&#2381;&#2351;&#2350; &#2360;&#2375; &#2360;&#2381;&#2341;&#2366;&#2344;&#2381;&#2340;&#2352;&#2367;&#2340; &#2325;&#2367;&#2351;&#2375; &#2332;&#2366;&#2344;&#2375; &#2325;&#2366; &#2325;&#2359;&#2381;&#2335; &#2325;&#2352;&#2375; :-<br />
                <br />
            </td>
        </tr>
        <tr>
            <td>SNO.</td>
            <td class="auto-style1">NAME OF PRINTERS / PARTY </td>
            <td class="auto-style1">BANK A/C NO</td>
            <td class="auto-style1">NAME OF BANK</td>
            <td class="auto-style1">BANK&nbsp; I.F.S.C. CODE</td>
            <td class="auto-style1">AMOUNT(Rs)</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
        </tr>

        <tr>
            <td class="auto-style1">&nbsp;1</td>
            <td class="auto-style1"><%=ds1.Tables[0].Rows[0]["mPrintername"].ToString()%></td>
            <td class="auto-style1"><%=ds1.Tables[0].Rows[0]["BankAcno"].ToString()%></td>
            <td class="auto-style1"><%=ds1.Tables[0].Rows[0]["BankName"].ToString()%></td>
            <td class="auto-style1"><%=ds1.Tables[0].Rows[0]["BankIFSCCode"].ToString()%></td>
            <td class="auto-style1"><%=ds1.Tables[0].Rows[0]["mPayAmount_N"].ToString()%></td>
        </tr>


         


        <tr>
            <td colspan="6">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="6">
                <br />
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="6" class="auto-style2">
                <br />
                <br />
                <strong>&#2313;&#2346; &#2350;&#2361;&#2366;&#2346;&#2381;&#2352;&#2348;&#2306;&#2343;&#2325; (&#2357;&#2367;&#2340;&#2381;&#2340;&#2381;&#2340; )<br />
                &#2350;.&#2346;&#2381;&#2352;. &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;
                <br />
                &#2349;&#2379;&#2346;&#2366;&#2354;</strong><br />
            </td>
        </tr> 
    </table>
    </div> 
    
     <div style="padding-left:20px;padding-bottom:20px;"><asp:Button ID="btnExport" runat="server" Text="Print"  
        CssClass="btn" OnClientClick="PrintPanel();" />

    

     <script type = "text/javascript">
         function PrintPanel() {
             var panel = document.getElementById("<%=ExportDiv.ClientID %>");

             var printWindow = window.open('', '', 'height=400,width=800');
             printWindow.document.write('<html><head><title>Printer Challan Detail</title>');
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

