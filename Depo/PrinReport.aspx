<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrinReport.aspx.cs" Inherits="Depo_PrinReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
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
                        <td><b> पुस्तक प्राप्ति रसीद </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; :<asp:Label ID="Label1" runat="server" Text=""></asp:Label>, &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; : <asp:Label ID="Label2" runat="server" Text=""></asp:Label>  </td>
        </tr>
        <tr>
            <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352; </td>
            <td><%=Request.QueryString["challanNo"] %></td>
            <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;</td>
            <td><%=System.DateTime.Now.ToString("dd/MM/yyyy")%></td>
            
        </tr>
        <tr>
            <td>&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2360;&#2375; &#2349;&#2375;&#2332;&#2375; &#2327;&#2319; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; </td>
            <td><%=ds.Tables[0].Rows[0]["Toatl"].ToString() %></td>
            <td>&#2337;&#2367;&#2346;&#2379; &#2350;&#2375;&#2306; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;</td>
            <td><%=ds.Tables[0].Rows[0]["Received"].ToString() %></td>
        </tr>
        <tr>
            <td>&#2337;&#2367;&#2346;&#2379; &#2350;&#2375;&#2306; &#2309;&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;</td>
            <td><%=ds.Tables[0].Rows[0]["Remain"].ToString() %></td>
            <td>पुस्तक का प्रकार </td>
            <td> <asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
        </tr>
         <tr>
            <td>&#2313;&#2340;&#2352;&#2366;&#2312;</td>
            <td>
                <asp:Label ID="lblunloding" runat="server"></asp:Label>
            </td>
            <td>&#2330;&#2338;&#2366;&#2312;</td>
            <td>
                <asp:Label ID="lblloding" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&#2346;&#2352;&#2367;&#2357;&#2361;&#2344;</td>
            <td>
                <asp:Label ID="lblltranpo" runat="server"></asp:Label>
            </td>
            <td>&#2309;&#2344;&#2381;&#2351;</td>
            <td>
                <asp:Label ID="lbllother" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td> &#2335;&#2381;&#2352;&#2325; &#2344;&#2306;&#2348;&#2352;</td>
            <td>
                <asp:Label ID="lbltrukno" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr align="right" >
            <td colspan="4" align="right" >
              <br /><br />
               <b>&#2337;&#2367;&#2346;&#2379; &#2350;&#2376;&#2344;&#2375;&#2332;&#2352; <%=Session["UserName"]%></b> 
               
            </td>
        </tr>
    </table></div> <br /><br />
     <center><asp:Button ID="btnExportPDF" runat="server" CssClass="btn" 
                            OnClientClick="return PrintPanel();" Text="पावती रसीद प्रिंट करें "  />
   <%-- <asp:Button ID="Button1" runat="server" CssClass="btn" 
                            Text="" OnClick="btn1"  />
         <asp:Button ID="Button2" runat="server" CssClass="btn" 
                            Text=""  OnClick="btn2" />--%>
      अथवा    <a href="GSRReport.aspx" class="btn" target="_blank" >जी.एस.आर. रिपोर्ट देखे</a> अथवा 
          <a href="DPT012_25PercentageReport.aspx" class="btn" target="_blank" >25 % गणना रसीद बनाये </a>
     </center> 
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

