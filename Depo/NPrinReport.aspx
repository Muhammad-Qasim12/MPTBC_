<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NPrinReport.aspx.cs" Inherits="Depo_NPrinReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div id="ExportDiv" runat="server">  
    <table class="auto-style1" border="1">
        <tr>
            <td colspan="4">
                <table align="center" width="100%">
                    <tr>
                        <td align="center"><b style="text-align: center">&#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; ,&#2360;&#2306;&#2349;&#2366;&#2327;&#2368;&#2351; &#2349;&#2306;&#2337;&#2366;&#2352;<br />
                            <br />
                            &nbsp;<asp:Label ID="lblAddress" runat="server"></asp:Label>
                            <br />
                            </b></td>
                    </tr>
                    <tr>
                        <td>&#2342;&#2370;&#2352;&#2349;&#2366;&#2359; &#2344;&#2306;&#2348;&#2352; : <b>
                            <asp:Label ID="lblphone" runat="server"></asp:Label>
                            , &#2350;&#2379;&#2348;&#2366;&#2311;&#2354; &#2344;&#2306;&#2348;&#2352; :<asp:Label ID="lblmobileNo" runat="server"></asp:Label>
                            &nbsp; &nbsp;</b>,&#2312;&#2350;&#2375;&#2354; &#2310;&#2312;&#2337;&#2368; : <b>
                            <asp:Label ID="lblemailID" runat="server"></asp:Label>
                            &nbsp;,</b>&#2357;&#2375;&#2348;&#2360;&#2366;&#2311;&#2335; : http://mptbc.nic.in</td>
                    </tr>
                    <tr>
                        <td>&nbsp;&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; :<b><asp:Label ID="lblfyYaer" runat="server"></asp:Label>
                          <%--  </b>&nbsp;&nbsp;&nbsp; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; : <b>
                            <asp:Label ID="lblDate" runat="server"></asp:Label>--%>
                            </b></td>
                    </tr>
                    <tr>
                        <td><b> &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2352;&#2360;&#2368;&#2342; </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
<%--              Response.Redirect("NPrinReport.aspx?ChallanID=" + lblChallan.Text + "&ChallanDate=" + lblChallanDate.Text + "&PrinterName=" + lblPrinterName.Text + "&BookName=" + lblBookName.Text + "&NoofBooks=" + lblBook.Text + "&noofBundle=" + lblbundel.Text + "");--%>
            <td colspan="4">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; :<%=Request.QueryString["PrinterName"].ToString () %>, &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; :<%=Request.QueryString["BookName"] %>  </td>
        </tr>
        <tr>
            <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352; </td>
            <td><%=Request.QueryString["ChallanID"] %></td>
            <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;</td>
            <td><%=System.DateTime.Now.ToString("dd/MM/yyyy")%></td>
            
        </tr>
        <tr>
            <td>&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2360;&#2375; &#2349;&#2375;&#2332;&#2375; &#2327;&#2319; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; </td>
            <td><%=Request.QueryString["noofBundle"] %></td>
            <td>&#2337;&#2367;&#2346;&#2379; &#2350;&#2375;&#2306; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;</td>
            <td><%=Request.QueryString["noofBundle"] %></td>
        </tr>
         <tr>
            <td>&#2313;&#2340;&#2352;&#2366;&#2312;</td>
            <td><%=Request.QueryString["Exp"] %>
                </td>
            <td>
               &#2335;&#2381;&#2352;&#2325; &#2344;&#2306;&#2348;&#2352;
            </td>
            <td><%=Request.QueryString["Truck"] %></td>
           
        </tr>
        <tr>
            <td> &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr align="right" >
            <td colspan="4" align="right" >
              <br /><br />
               <b>&#2337;&#2367;&#2346;&#2379; &#2350;&#2376;&#2344;&#2375;&#2332;&#2352; <br />
     <center>
               <b>
                   </td> </tr> </table> </div>
    <asp:Button ID="btnExportPDF" runat="server" CssClass="btn" 
                            OnClientClick="return PrintPanel();" Text="&#2346;&#2366;&#2357;&#2340;&#2368; &#2352;&#2360;&#2368;&#2342; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2325;&#2352;&#2375;&#2306; "  /><br /> 


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

