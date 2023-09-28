<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrinterReceivedChallanDetails.aspx.cs" Inherits="Depo_PrinterReceivedChallanDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            text-align: left;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            text-decoration: underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


     <div class="box table-responsive">
        <div class="card-header">
            <h2>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2352;&#2360;&#2368;&#2342; </h2>
        </div>
        <div style="padding: 0 10px;">
            <table width="100%">
                <tr>
                    <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2366; &#2344;&#2306;&#2348;&#2352; </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="txtbox">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="&#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2342;&#2375;&#2326;&#2375;" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                </table> 
    <div id="ExportDiv" runat="server" visible="false" >
        <table border="1" class="auto-style1" width="100%">
            <tr>
                <td colspan="4">
                    <table align="center" width="100%">
                        <tr>
                            <td align="center" class="auto-style2"><b style="text-align: center">&#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; ,&#2360;&#2306;&#2349;&#2366;&#2327;&#2368;&#2351; &#2349;&#2306;&#2337;&#2366;&#2352;                                &nbsp;<asp:Label ID="lblAddress" runat="server"></asp:Label>
                                <br />
                                </b></td>
                        </tr>
                        <tr>
                            <td>&#2342;&#2370;&#2352;&#2349;&#2366;&#2359; &#2344;&#2306;&#2348;&#2352; : <b>
                                <asp:Label ID="lblphone" runat="server"></asp:Label>
                                , &#2350;&#2379;&#2348;&#2366;&#2311;&#2354; &#2344;&#2306;&#2348;&#2352; :<asp:Label ID="lblmobileNo" runat="server"></asp:Label>
                                &nbsp; &nbsp;</b>,&#2312;&#2350;&#2375;&#2354; &#2310;&#2312;&#2337;&#2368; : <b>
                                <asp:Label ID="lblemailID" runat="server"></asp:Label>
                                &nbsp;,</b>&#2357;&#2375;&#2348;&#2360;&#2366;&#2311;&#2335; : http://mptbc.mp.gov.in</td>
                        </tr>
                        <tr>
                            <td>&nbsp;&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; :<b><asp:Label ID="lblfyYaer" runat="server"></asp:Label>
                               <%-- </b>&nbsp;&nbsp;&nbsp; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; : <b>--%>
                                <asp:Label ID="lblDate" runat="server" Visible="false" ></asp:Label>
                                </b></td>
                        </tr>
                        <tr>
                            <td align="center" class="auto-style3"  >&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2352;&#2360;&#2368;&#2342; </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="4">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; :<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    , &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; :
                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352; </td>
                <td>
                    <asp:Label ID="lblChallan" runat="server"></asp:Label>
                </td>
                <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;</td>
                <td>
                    <asp:Label ID="lblChallanDate" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2360;&#2375; &#2349;&#2375;&#2332;&#2375; &#2327;&#2319; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; </td>
                <td>
                    <asp:Label ID="lblPrinterSendData" runat="server"></asp:Label>
                </td>
                <td>&#2337;&#2367;&#2346;&#2379; &#2350;&#2375;&#2306; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;</td>
                <td>
                    <asp:Label ID="lblReceivedbandal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&#2337;&#2367;&#2346;&#2379; &#2350;&#2375;&#2306; &#2309;&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;</td>
                <td>
                    <asp:Label ID="lblReceivedbandal0" runat="server"></asp:Label>
                </td>
                <td>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; 
                <td>
                    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                </td>
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
                <td>&#2335;&#2381;&#2352;&#2325; &#2344;&#2306;&#2348;&#2352;</td>
                <td>
                    <asp:Label ID="lbltrukno" runat="server"></asp:Label>
                </td>
                <td> कुल व्यय </td>
                <td>
                    <asp:Label ID="lblTotalBook" runat="server"></asp:Label>
                </td>
            </tr>
            <tr align="right">
                <td align="right" colspan="4">
                    <br />
                    <br />
                    <b>डिपो प्रबंधक </b>
                     <br />
                    म.प्र.पाठ्य पुस्तक निगम 
                    <br /> <%=Session["UserName"]%>
                </td>
            </tr>
            <tr  >
                <td  colspan="4">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" Widt="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                            <asp:BoundField DataField="BundleNo_I" HeaderText="बंडल नंबर " />
                            <asp:BoundField DataField="FromNo_I" HeaderText="पुस्तक नंबर से " />
                            <asp:BoundField DataField="ToNo_I" HeaderText="पुस्तक नंबर तक " />
                            <asp:BoundField DataField="Dist" HeaderText="स्थिति " />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
            </div> 
    <br />
    <br />
   <center> <asp:Button ID="btnExportPDF" runat="server" CssClass="btn" OnClientClick="return PrintPanel();" Text="&#2337;&#2369;&#2346;&#2381;&#2354;&#2368;&#2325;&#2375;&#2335; &#2346;&#2366;&#2357;&#2340;&#2368; &#2352;&#2360;&#2368;&#2342; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2325;&#2352;&#2375;&#2306;" /></center>
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

