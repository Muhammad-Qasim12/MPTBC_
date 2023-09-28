<%@ Page Title="&#2350;.&#2346;&#2381;&#2352; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; / M.P. TBC " Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShowBookSellerDetails.aspx.cs" Inherits="Depo_ShowBookSellerDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:Button ID="btnExport" runat="server" CssClass="btn_gry" 
                                OnClick="btnExport_Click" Text="Export to Excel" Visible="False" />
                            <asp:Button ID="btnExportPDF" runat="server" CssClass="btn_gry" 
                                OnClientClick="return PrintPanel();" Text="Export to PDF & Print" Visible="False" />
    <asp:Button ID="Button1" runat="server" CssClass="btn_gry" 
                               Text="&#2357;&#2366;&#2346;&#2360; &#2332;&#2366;&#2351;&#2375; "  OnClick="Button1_Click" />
    <div id="ExportDiv" runat="server" >
    <div class="box table-responsive">
     <center>
                                <b style="font-size: 12pt;">
                                    &#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;, &#2360;&#2306;&#2349;&#2366;&#2327;&#2368;&#2351; &#2349;&#2306;&#2337;&#2366;&#2352;
                                    <br /><br />
                                    &#2337;&#2367;&#2346;&#2379; -&nbsp;&nbsp;<asp:Label ID="lblDepoName" runat="server"></asp:Label>
                                    <br />
                                    <br />
                                    &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2348;&#2367;&#2325;&#2381;&#2352;&#2375;&#2340;&#2366; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Book Seller Details
                                </b>
                                <br />
                                <br />
                                &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; :&nbsp;&nbsp;<asp:Label ID="lblFYear" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; :&nbsp;&nbsp;<asp:Label ID="lblCurrentDate" runat="server"></asp:Label>
                            </center>
                            <br /><br />
 <table id="tblDetails" runat="server"  class="tab" >
                                <tr>
                                    <td >
                                        &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2357;&#2367;&#2325;&#2381;&#2352;&#2375;&#2340;&#2366; &#2344;&#2366;&#2350;&nbsp; / Book Seller Name
                                    </td>
                                    <td >
                                        <asp:Literal ID="lblBookseller" runat="server"></asp:Literal>
                                    </td>
                                    <td colspan="2" >
                                    </td>
                                </tr>
                                <tr>
                                    <td>  &#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2381;&#2352;&#2375;&#2358;&#2344; &#2344;&#2306;&#2348;&#2352; / Reg. No.
                                    </td>
                                    <td>
                                        <asp:Literal ID="lblBooksellerRegNo" runat="server"></asp:Literal>
                                        </td>
                                    <td>  &#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2381;&#2352;&#2375;&#2358;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Reg. Date
                                    </td>
                                    <td>
                                        <asp:Literal ID="lblBooksellerRegDate" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &#2346;&#2376;&#2344; &#2344;&#2350;&#2381;&#2348;&#2352; / PAN No.</td>
                                    <td>
                                        <asp:Literal ID="lblBooksellerPanNo" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        &#2335;&#2367;&#2344; &#2344;&#2350;&#2381;&#2348;&#2352; / TIN No.
                                    </td>
                                    <td>
                                        <asp:Literal ID="lblBooksellerTinNO" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td >   &#2360;&#2306;&#2348;&#2306;&#2343;&#2367;&#2340;  &#2357;&#2381;&#2351;&#2325;&#2381;&#2340;&#2367; &#2325;&#2366; &#2344;&#2366;&#2350; / Related Person Name
                                    </td>
                                    <td colspan="3" >
                                        <asp:Literal ID="lblOwnerName" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&#2335;&#2375;&#2354;&#2368;&#2347;&#2379;&#2344; &#2344;&#2306;&#2348;&#2352; / Telephone No.
                                       </td>
                                    <td>
                                        <asp:Literal ID="lblTellephoneNo" runat="server"></asp:Literal>
                                     </td>
                                    <td>&#2350;&#2379;&#2348;&#2366;&#2311;&#2354; &#2344;&#2306;&#2348;&#2352; / Mobile No.
                                    </td>
                                    <td>
                                         <asp:Literal ID="lblMobile" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td >
                                        &#2346;&#2340;&#2366; / Address
                                    </td>
                                    <td >
                                        <asp:Literal ID="lblTellephoneNo0" runat="server"></asp:Literal>
                                     </td>
                                    <td >
                                        &#2332;&#2367;&#2354;&#2366; / District</td>
                                    <td >
                                        <asp:Literal ID="lblDistNAme" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td >
                                        &#2347;&#2376;&#2325;&#2381;&#2360; &#2344;&#2306;&#2348;&#2352; / FAX No.
                                      
                                    </td>
                                    <td >
                                        
                                        <asp:Literal ID="lblFaxNo" runat="server"></asp:Literal>
                                        
                                        </td>
                                    <td >
                                        &#2312;-&#2350;&#2375;&#2354; &#2310;&#2312;.&#2337;&#2368;. / Email ID</td>
                                    <td >
                                        <asp:Literal ID="lblEmailID" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&#2309;&#2350;&#2366;&#2344;&#2340; &#2325;&#2368; &#2352;&#2366;&#2358;&#2368; / Amount</td>
                                    <td >
                                        <asp:Literal ID="lblRegAmount" runat="server"></asp:Literal>
                                    &nbsp;(Rs.)</td>
                                    <td>&#2337;&#2368;.&#2337;&#2368;./&#2330;&#2375;&#2325; &#2344;&#2306;&#2348;&#2352; / DD/Cheque No.
                                    </td>
                                    <td>
                                        <asp:Literal ID="lblddDate" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&#2357;&#2376;&#2343;&#2340;&#2366; &#2325;&#2368; &#2309;&#2357;&#2343;&#2367; / Validity</td>
                                    <td >
                                        <asp:Literal ID="lblVailed" runat="server"></asp:Literal>
                                        &#2350;&#2366;&#2361; &#2350;&#2375;&#2306;
                                    </td>
                                    <td>&#2337;&#2368;.&#2337;&#2368;./&#2330;&#2375;&#2325; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / DD/Cheque Date
                                        </td>
                                    <td>
                                        <asp:Literal ID="lblDDdate1" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &#2351;&#2370;&#2332;&#2352; &#2310;&#2312;.&#2337;&#2368;. / User ID</td>
                                    <td>
                                        <asp:Literal ID="lblUserID" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        &#2346;&#2366;&#2360;&#2357;&#2352;&#2381;&#2337; / Password</td>
                                    <td>
                                        <asp:Literal ID="lblPasseword" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                               <tr>
                                <td colspan="4">
                                    &nbsp;</td>
                               </tr>
          </table></div>
    </div>
        
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

