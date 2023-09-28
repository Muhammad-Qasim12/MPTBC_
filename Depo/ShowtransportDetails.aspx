<%@ Page Title="&#2350;.&#2346;&#2381;&#2352; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; / M.P. TBC " Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShowtransportDetails.aspx.cs" Inherits="Depo_ShowtransportDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
                            <div class="card-header">
                                <h2><span>&#2335;&#2381;&#2352;&#2366;&#2306;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335;&#2352; 
                                    &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Transporter Details</span></h2>
                            </div>
                               
                            <div style="padding:0 10px;">
                            <div></div>
                                 <table width="100%" id="ra" runat="server" visible="false" >
                                <tr><td>शैक्षणिक सत्र </td> <td>
                                    <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                                    </asp:DropDownList>
                                    </td> <td>&#2335;&#2381;&#2352;&#2366;&#2344;&#2381;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335; &#2344;&#2366;&#2350; / Transport Name</td> <td>
                                        <asp:DropDownList ID="ddlTrnasportName" runat="server" CssClass="txtbox reqirerd" onkeypress="javascript:tbx_fnAlphaNumericOnly(event, this)">
                                        </asp:DropDownList>
                                    </td><td>
                <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; "   OnClientClick="return ValidateAllTextForm();"
                            onclick="btnSave_Click" /></td></tr> </table> 
                            <asp:Panel   class="form-message error" runat="server" id="mainDiv" style="display: none;padding-top:10px;padding-bottom:10px;">
                <asp:Label  id="lblmsg" class="notification" runat="server">
                
            </asp:Label>
            </asp:Panel>
                                 <asp:Button ID="btnExport" runat="server" CssClass="btn_gry" 
                                OnClick="btnExport_Click" Text="Export to Excel" Visible="False" />
                            <asp:Button ID="btnExportPDF" runat="server" CssClass="btn_gry" 
                                OnClientClick="return PrintPanel();" Text="Export to PDF & Print" Visible="False" />
            <div id="ExportDiv" runat="server" >
                            <table width="100%" id="asa" runat="server" visible="false" >
                                <tr>
                                    <td colspan="4" align="center" >  &#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; ,&#2360;&#2306;&#2349;&#2366;&#2327;&#2368;&#2351; &#2349;&#2306;&#2337;&#2366;&#2352;<br />
        <br />
&nbsp;<asp:Label ID="lblAddress" runat="server"></asp:Label>
                                        <br />
        <br />
       
                                        &#2335;&#2381;&#2352;&#2366;&#2306;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335;&#2352; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Transport Details 
                                         <br />  <br /> </td>
                                </tr>
                                <tr>
                                    <td>  &#2335;&#2381;&#2352;&#2366;&#2306;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335;<span> &#2325;&#2350;&#2381;&#2346;&#2344;&#2368; &#2325;&#2366;</span> &#2344;&#2366;&#2350; / Transporter Company Name
                                        </td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" ></asp:Label>
                                    </td>
                                    <td>  &#2335;&#2381;&#2352;&#2366;&#2306;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; / Transporter Name
                                        </td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" ></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>  &#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2381;&#2352;&#2375;&#2358;&#2344; &#2344;&#2306;&#2348;&#2352; / Reg. No.
                                        </td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" ></asp:Label>
                                    </td>
                                    <td>  &#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2381;&#2352;&#2375;&#2358;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Reg. Date
                                        </td>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" ></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td >&#2335;&#2375;&#2354;&#2368;&#2347;&#2379;&#2344; &#2344;&#2306;&#2348;&#2352; / Telephone No.</td>
                                    <td >
                                        <asp:Label ID="Label5" runat="server" ></asp:Label>
                                    </td>
                                    <td >&#2350;&#2379;&#2348;&#2366;&#2311;&#2354; &#2344;&#2306;&#2348;&#2352; / Mobile No.
                                       
                                    </td>
                                    <td >
                                        <asp:Label ID="Label6" runat="server" ></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td >
                                        <span>&#2335;&#2381;&#2352;&#2366;&#2344;&#2381;&#2360;&#2346;&#2379;&#2335;&#2352; &#2325;&#2366; </span>&nbsp;&#2346;&#2340;&#2366; / Transporter Address
                                        </td>
                                    <td colspan="3" >
                                        <asp:Label ID="Label8" runat="server" ></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                    <td >
                        &#2358;&#2361;&#2352;/ &#2392;&#2360;&#2381;&#2348;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; / City/Town Name
                    </td>
                    <td >
                        <asp:Label ID="Label9" runat="server" ></asp:Label>
                                    </td>
                    <td >
                        &#2346;&#2367;&#2344; &#2325;&#2379;&#2337; / Pin Code
                    </td>
                    <td >
                        <asp:Label ID="Label10" runat="server" ></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td >
                                        &#2347;&#2376;&#2325;&#2381;&#2360; &#2344;&#2306;&#2348;&#2352; / FAX No.
                                      
                                    </td>
                                    <td >
                                        <asp:Label ID="Label11" runat="server" ></asp:Label>
                                    </td>
                                    <td >
                                        &#2312; &#2350;&#2375;&#2354; &#2310;&#2312;.&#2337;&#2368; / Email ID.</td>
                                    <td >
                                        <asp:Label ID="Label12" runat="server" ></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &#2346;&#2376;&#2344; &#2344;&#2350;&#2381;&#2348;&#2352; / PAN No.
                    </td>
                                    <td>
                                        <asp:Label ID="Label13" runat="server" ></asp:Label>
                                    </td>
                                    <td>
                                        &#2335;&#2367;&#2344; &#2344;&#2350;&#2381;&#2348;&#2352; / TIN No.
                                       
                                    </td>
                                    <td>
                                        <asp:Label ID="Label14" runat="server" ></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &#2360;&#2352;&#2381;&#2357;&#2367;&#2360; &#2335;&#2376;&#2325;&#2381;&#2360; &#2344;&#2306;&#2348;&#2352; / Service TAX No.
                    </td>
                                    <td>
                                        <asp:Label ID="Label15" runat="server" ></asp:Label>
                                    </td>
                                    <td>
                                        &#2357;&#2376;&#2343;&#2381;&#2351;&#2340;&#2366; &#2325;&#2368; &#2309;&#2357;&#2343;&#2367; <span>&nbsp;(&#2350;&#2366;&#2361; &#2350;&#2375;&#2306;) </span>/ Validity Time(Month)<span>
                                        </span></td>
                                    <td>
                                        <asp:Label ID="Label16" runat="server" ></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td >&#2309;&#2350;&#2366;&#2344;&#2340; &#2325;&#2368; &#2352;&#2366;&#2358;&#2368; / Amount 
                                        </td>
                                    <td >
                                        <asp:Label ID="Label17" runat="server" ></asp:Label>
                                    </td>
                                    <td >&#2337;&#2368;.&#2337;&#2368;./&#2330;&#2375;&#2325; &#2344;&#2306;&#2348;&#2352; / DD/Cheque No.
                                       
                                    </td>
                                    <td >
                                        <asp:Label ID="Label18" runat="server" ></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &#2348;&#2376;&#2306;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Bank Name
                    </td>
                                    <td>
                                        <asp:Label ID="Label19" runat="server" ></asp:Label>
                                    </td>
                                    <td>
                                        &#2337;&#2368;.&#2337;&#2368;./&#2330;&#2375;&#2325; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / DD/Cheque Date</td>
                                    <td>
                                        <asp:Label ID="Label20" runat="server" ></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &#2335;&#2375;&#2344; &#2344;&#2306;&#2348;&#2352; / TAN No.
                                        </td>
                                    <td>
                                        <asp:Label ID="Label21" runat="server" ></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        &#2352;&#2375;&#2335; &#2354;&#2367;&#2360;&#2381;&#2335; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Rate List Details
                                        </td>
                                </tr>
        <tr>
            <td colspan="4" style="text-align: center">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    CssClass="tab" >
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="&#2348;&#2381;&#2354;&#2366;&#2325; / &#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; / Block / Depo Name" />
                        <asp:BoundField DataField="FyYear" HeaderText="&#2357;&#2367;&#2340;&#2381;&#2340;&#2368;&#2351; &#2357;&#2352;&#2381;&#2359; &#2325;&#2366; &#2344;&#2366;&#2350; / Financial Year Name" />
                        <asp:BoundField DataField="FullTruckRate_N" HeaderText="&#2347;&#2369;&#2354; &#2335;&#2381;&#2352;&#2325; &#2352;&#2375;&#2335;(9 &#2335;&#2344;) /Full Track Rate " />
                        <asp:BoundField DataField="HalfTruckRate_N" HeaderText="&#2361;&#2366;&#2347; &#2335;&#2381;&#2352;&#2325; &#2352;&#2375;&#2335;(4.5 &#2335;&#2344;) / Half Track Rate" />
                        <asp:BoundField DataField="RatePerBundle_N" HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367;&#2348;&#2306;&#2337;&#2354; &#2352;&#2375;&#2335; / Per Bundle" />
                    </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                                              <EmptyDataRowStyle CssClass="GvEmptyText" />
                </asp:GridView>

            </td>
        </tr>
    </table></div>
                            
                            </div> </div>
                           
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

