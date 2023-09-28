<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrinReg.aspx.cs" Inherits="Depo_PrinReg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=Panel1.ClientID %>");
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

    <style type="text/css">
        .auto-style2 {
            width: 55px;
            height: 48px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <a href="#" class="btn" style="color:White;" onclick="return PrintPanel();">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; / Print</a>
    <br /><br />
     <asp:Panel ID="Panel1" runat="server" Width="100%">
         <%
             dt = comm.FillDatasetByProc("call USP_BookSellerRenewPrint("+Request.QueryString["ID"]+")");
             
              %>
    <table width="100%" cellpadding="8" cellspacing="8" style="border-style: double">
        <tr><td colspan="3">
            <center>
         <b>  &#2350;0&#2346;&#2381;&#2352;0 &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;</b> 
                <br />
                <img class="auto-style2" src="../images/logo.png" />
                <br />
              <b>  &nbsp;&#2309;&#2352;&#2375;&#2352;&#2366; &#2361;&#2367;&#2354;&#2381;&#2360;,&#2349;&#2379;&#2346;&#2366;&#2354;-11</b>
                <br />
            <br />
          <b>  &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2357;&#2367;&#2325;&#2381;&#2352;&#2375;&#2340;&#2366;&nbsp; &#2325;&#2375; &#2354;&#2367;&#2351;&#2375; &#2346;&#2306;&#2332;&#2368;&#2351;&#2344;/&#2344;&#2357;&#2368;&#2344;&#2368;&#2325;&#2352;&#2339; </b></center> </td></tr>
        <tr><td colspan="3"> <center>
           <b> (&#2337;&#2367;&#2346;&#2379; <%=dt.Tables[0].Rows[0]["DepoName_V"].ToString () %> &#2325;&#2375; &#2354;&#2367;&#2351;&#2375; &#2348;&#2376;&#2343;)</b></center></td></tr>
        <tr><td colspan="3">
          </td></tr>
        <tr><td>&nbsp;</td><td><b>&#2346;&#2381;&#2352;&#2350;&#2366;&#2339; &#2346;&#2340;&#2381;&#2352; &#2357;&#2352;&#2381;&#2359; 2022-2023</b> </td><td>&nbsp;</td></tr>
        <tr><td>&#2346;&#2306;&#2332;&#2368;&#2351;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;&nbsp;&nbsp; <%=dt.Tables[0].Rows[0]["RegistrationNo_V"].ToString () %>  </td><td>&nbsp;</td><td>
            &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;. <%=dt.Tables[0].Rows[0]["RegistrationDate_D"].ToString () %> </td></tr>
        <tr>
            <td align="justify" colspan="3" style="border-spacing: 5px; font-size: 16px;" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &#2346;&#2381;&#2352;&#2350;&#2366;&#2339;&#2367;&#2340; &#2325;&#2367;&#2351;&#2366; &#2332;&#2366;&#2340;&#2366; &#2361;&#2376; &#2325;&#2367;
                 &#2350;&#2375;&#2360;&#2352;&#2381;&#2360; &nbsp;&nbsp; <%=dt.Tables[0].Rows[0]["BooksellerName_V"].ToString () %> &#2346;&#2381;&#2352;&#2379;&#2346;&#2381;&#2352;&#2366;&#2311;&#2335;&#2352;/&#2346;&#2366;&#2352;&#2381;&#2335;&#2344;&#2352;
                 &#2342;&#2369;&#2325;&#2366;&#2344; &#2358;&#2381;&#2352;&#2368;;&nbsp;&nbsp <%=dt.Tables[0].Rows[0]["BooksellerOwnerName_V"].ToString () %>  &#2350;&#2369;&#2325;&#2366;&#2350;&nbsp;&nbsp; <%=dt.Tables[0].Rows[0]["Address_V"].ToString () %>  &#2346;&#2379;&#2360;&#2381;&#2335;....................................
                .....................&#2332;&#2367;&#2354;&#2366;&nbsp;<%=dt.Tables[0].Rows[0]["District_Name_Hindi_V"].ToString () %>&#2325;&#2366; &#2346;&#2306;&#2332;&#2368;&#2351;&#2344;/&#2344;&#2357;&#2368;&#2344;&#2368;&#2325;&#2352;&#2339; &#2357;&#2352;&#2381;&#2327;&nbsp;&nbsp;<%=dt.Tables[0].Rows[0]["Category"].ToString () %>&nbsp;&#2350;&#2375;&#2306; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;&nbsp;&nbsp;<%=dt.Tables[0].Rows[0]["Fromdate"].ToString () %>. &#2360;&#2375; <%=dt.Tables[0].Rows[0]["RegistrationDate_DN"].ToString () %> &#2340;&#2325; 5 &#2357;&#2352;&#2381;&#2359; &#2325;&#2375; &#2354;&#2367;&#2351;&#2375; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; &#2325;&#2375; &#2309;&#2343;&#2367;&#2325;&#2371;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2357;&#2367;&#2325;&#2381;&#2352;&#2375;&#2340;&#2366; &#2325;&#2375; &#2352;&#2370;&#2346; &#2350;&#2375;&#2306; &#2346;&#2306;&#2332;&#2368;&#2351;&#2344; &#2325;&#2368; &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; &#2358;&#2352;&#2381;&#2340;&#2379; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2325;&#2367;&#2351;&#2366; &#2332;&#2366;&#2340;&#2366; &#2361;&#2376;&#2306;&#2404; </td></tr>
        <tr> <td>
            &nbsp;</td><td colspan="2" align="center">
            &nbsp;</td></tr>
        <tr>
            <td>
                <table border="1" width="100%">
                    <tr>
                        <td align="center" colspan="2">&nbsp;&#2358;&#2369;&#2354;&#2381;&#2325; &#2357;&#2367;&#2357;&#2352;&#2339;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;&#2352;&#2366;&#2358;&#2367;</td>
                        <td><%=dt.Tables[0].Rows[0]["RegistrationAmount_N"].ToString () %> </td>
                    </tr>
                    <tr>
                        <td>&#2357;&#2367;&#2354;&#2350;&#2381;&#2357; &#2358;&#2369;&#2354;&#2381;&#2325;</td>
                        <td><%=dt.Tables[0].Rows[0]["BilamShukl"].ToString () %></td>
                    </tr>
                    <tr>
                        <td>&#2352;&#2360;&#2368;&#2342; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;</td>
                        <td><%=dt.Tables[0].Rows[0]["RegDDNo_V"].ToString () %></td>
                    </tr>
                    <tr>
                        <td>&#2352;&#2360;&#2368;&#2342; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;</td>
                        <td><%=dt.Tables[0].Rows[0]["RegistrationDate_D"].ToString () %></td>
                    </tr>
                </table>
            </td>
            <td align="center" colspan="2">
                <br />
                <br />
                &#2325;&#2371;&#2340;&#2375; &#2346;&#2381;&#2352;&#2348;&#2344;&#2381;&#2343; &#2360;&#2306;&#2330;&#2366;&#2354;&#2325;<br /> &nbsp;&#2350;0&#2346;&#2381;&#2352;0 &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; ,&#2349;&#2379;&#2346;&#2366;&#2354; </td>
        </tr>
        <tr><td colspan="3" align="center">&nbsp;</td></tr>
        <tr>
            <td align="center" colspan="3">&#2337;&#2367;&#2346;&#2379; &#2346;&#2381;&#2352;&#2348;&#2306;&#2343;&#2325;<br /> &nbsp;&#2350;0&#2346;&#2381;&#2352;0 &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;
                <br />
                &#2337;&#2367;&#2346;&#2379; <%=dt.Tables[0].Rows[0]["DepoName_V"].ToString () %>

            </td>
        </tr> <tr>
            <td align="left" colspan="3">&#2351;&#2370;&#2332;&#2352;&#2310;&#2312;&#2337;&#2368;&nbsp; : <%=dt.Tables[0].Rows[0]["LoginID_V"].ToString () %> &#2346;&#2366;&#2360;&#2357;&#2352;&#2381;&#2337; :<%=dt.Tables[0].Rows[0]["LoginID_V"].ToString () %>&#2357;&#2375;&#2348;&#2360;&#2366;&#2311;&#2335; : https://mptbc.mp.gov.in/</td>
        </tr>
        <tr>
            <td align="left" colspan="3">&#2325;&#2371;&#2346;&#2351;&#2366; &#2309;&#2346;&#2344;&#2366; &#2346;&#2366;&#2360;&#2357;&#2352;&#2381;&#2337; &#2357;&#2375;&#2348;&#2360;&#2366;&#2311;&#2335; &#2346;&#2352; &#2354;&#2377;&#2327; &#2311;&#2344; &#2325;&#2352; &#2348;&#2342;&#2354; &#2354;&#2375; !</td>
        </tr>
    </table></asp:Panel>
</asp:Content>
