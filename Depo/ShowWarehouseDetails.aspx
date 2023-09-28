<%@ Page Title="&#2350;.&#2346;&#2381;&#2352; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; / M.P. TBC " Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShowWarehouseDetails.aspx.cs" Inherits="Depo_ShowWarehouseDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
         <asp:Button ID="btnExport" runat="server" CssClass="btn_gry" 
                                OnClick="btnExport_Click" Text="Export to Excel" Visible="False" />
                            <asp:Button ID="btnExportPDF" runat="server" CssClass="btn_gry" 
                                OnClientClick="return PrintPanel();" Text="Print"  />
         <asp:Button ID="Button1" runat="server" CssClass="btn_gry" Text="&#2357;&#2366;&#2346;&#2360; &#2332;&#2366;&#2351;&#2375; " OnClick="Button1_Click"  />
<div id="ExportDiv" runat="server">  

<table id="tblDetails" runat="server"  class="tab" >
                                <tr>
                                    <td colspan="4" >
                                         <center>
                                <b style="font-size: 12pt;">
                                    &#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;, &#2360;&#2306;&#2349;&#2366;&#2327;&#2368;&#2351; &#2349;&#2306;&#2337;&#2366;&#2352;
                                    <br /><br />
                                    &#2337;&#2367;&#2346;&#2379; -&nbsp;&nbsp;<asp:Label ID="lblDepoName" runat="server"></asp:Label>
                                    <br />
                                    <br />
                                    &#2327;&#2379;&#2342;&#2366;&#2350; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Godown Details
                                </b>
                                <br />
                                <br />
                                &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; :&nbsp;&nbsp;<asp:Label ID="lblFYear" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; :&nbsp;&nbsp;<asp:Label ID="lblCurrentDate" runat="server"></asp:Label>
                            </center>
                            <br /><br />

                                    </td>
                                </tr>
                                <tr>
                                    <td>  &#2357;&#2375;&#2351;&#2352;&#2361;&#2366;&#2313;&#2360;/ &#2327;&#2379;&#2342;&#2366;&#2350;&nbsp; &#2325;&#2366; &nbsp;&#2344;&#2366;&#2350;&nbsp; / WareHouse / Godown Name
                                    </td>
                                    <td>
                                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                        </td>
                                    <td>  &#2357;&#2375;&#2351;&#2352;&#2361;&#2366;&#2313;&#2360;/ &#2327;&#2379;&#2342;&#2366;&#2350; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; / WareHouse/ Godown Date</td>
                                    <td>
                                        <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td>  &#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Regs. No</td>
                                    <td>
                                        <asp:Literal ID="Literal3" runat="server"></asp:Literal>
                                        </td>
                                    <td>  &#2310;&#2343;&#2367;&#2346;&#2340;&#2381;&#2351; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Regs. Date</td>
                                    <td>
                                        <asp:Literal ID="Literal4" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                        &#2357;&#2375;&#2351;&#2352;&#2361;&#2366;&#2313;&#2360;/ &#2327;&#2379;&#2342;&#2366;&#2350; &#2350;&#2366;&#2354;&#2367;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / WareHouse / Godown Owner Name</td>
                                    <td>
                                        <asp:Literal ID="Literal5" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                       &#2325;&#2366;&#2352;&#2346;&#2375;&#2335; &#2319;&#2352;&#2367;&#2351;&#2366; / Corporate Area
                                    </td>
                                    <td>
                                        <asp:Literal ID="Literal6" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                        &#2357;&#2375;&#2351;&#2352;&#2361;&#2366;&#2313;&#2360;/ &#2327;&#2379;&#2342;&#2366;&#2350; &#2325;&#2366; &#2346;&#2340;&#2366; / WareHouse/ Godown Address</td>
                                    <td colspan="3">
                                        &nbsp;<asp:Literal ID="Literal8" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&#2335;&#2375;&#2354;&#2368;&#2347;&#2379;&#2344; &#2344;&#2306;&#2348;&#2352; / Telephone No.
                                       </td>
                                    <td>
                                        <asp:Literal ID="Literal9" runat="server"></asp:Literal>
                                     </td>
                                    <td>&#2350;&#2379;&#2348;&#2366;&#2311;&#2354; &#2344;&#2306;&#2348;&#2352; / Mobile no.
                                    </td>
                                    <td>
                                         <asp:Literal ID="Literal10" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td >
                        &#2358;&#2361;&#2352;/ &#2392;&#2360;&#2381;&#2348;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; / City / Town Name
                                    </td>
                                    <td >
                                        <asp:Literal ID="Literal13" runat="server"></asp:Literal>
                                    </td>
                                    <td >
                        &#2346;&#2367;&#2344; &#2325;&#2379;&#2337; / Pin Code</td>
                                    <td >
                                        <asp:Literal ID="Literal14" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td >
                                        &#2347;&#2376;&#2325;&#2381;&#2360; &#2344;&#2306;&#2348;&#2352; / FAX No.
                                      
                                    </td>
                                    <td >
                                        
                                        <asp:Literal ID="Literal15" runat="server"></asp:Literal>
                                        
                                        </td>
                                    <td >
                                        &#2312;-&#2350;&#2375;&#2354; &#2310;&#2312;.&#2337;&#2368; / Email ID.</td>
                                    <td >
                                        <asp:Literal ID="Literal16" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&#2309;&#2350;&#2366;&#2344;&#2340; &#2325;&#2368; &#2352;&#2366;&#2358;&#2368; / Amount</td>
                                    <td >
                                        <asp:Literal ID="Literal17" runat="server"></asp:Literal>  (Rs.)
                                    </td>
                                    <td>&#2337;&#2368;.&#2337;&#2368;./&#2330;&#2375;&#2325; &#2344;&#2306;&#2348;&#2352; 
                                    </td>
                                    <td>
                                        <asp:Literal ID="Literal18" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&#2357;&#2376;&#2343;&#2340;&#2366; &#2325;&#2368; &#2309;&#2357;&#2343;&#2367; / DD/Cheque No.</td>
                                    <td >
                                        <asp:Literal ID="Literal19" runat="server"></asp:Literal>
                                    </td>
                                    <td>&#2337;&#2368;.&#2337;&#2368;./&#2330;&#2375;&#2325; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / DD/Cheque Date
                                        </td>
                                    <td>
                                        <asp:Literal ID="Literal20" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                        &#2348;&#2376;&#2306;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Bank Name</td>
                                    <td>
                                        <asp:Literal ID="Literal21" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                        &#2335;&#2375;&#2344; &#2344;&#2306;&#2348;&#2352; / TAN No.</td>
                                    <td>
                                        <asp:Literal ID="Literal22" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                        &#2325;&#2367;&#2352;&#2366;&#2351;&#2366; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Rental Date</td>
                                    <td>
                                        <asp:Literal ID="Literal23" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                        &#2325;&#2367;&#2352;&#2366;&#2351;&#2366; &#2352;&#2366;&#2358;&#2368; (&#2346;&#2381;&#2352;&#2340;&#2367; 
                        &#2351;&#2370;&#2344;&#2367;&#2335;) / Rental Amount (INR)</td>
                                    <td>
                                        <asp:Literal ID="Literal24" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &#2325;&#2369;&#2354; &#2325;&#2367;&#2352;&#2366;&#2351;&#2366; /Total rent Amount</td>
                                    <td>
                                        <asp:Literal ID="Literal25" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                               <tr>
                                <td colspan="4">
                                    &nbsp;</td>
                               </tr>
          </table>
          </div>
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

