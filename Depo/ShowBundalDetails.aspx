<%@ Page Title="&#2350;.&#2346;&#2381;&#2352; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; / M.P. TBC " Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShowBundalDetails.aspx.cs" Inherits="Depo_ShowtransportDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
                            <div class="card-header">
                                <h2>&#2337;&#2367;&#2346;&#2379;<span> &#2350;&#2375;&#2306; &#2330;&#2366;&#2354;&#2366;&#2344; 
                                    &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; </span>&nbsp;</h2>
                            </div>
                               
                            <div style="padding:0 10px;">
                            <div></div>
                                 <table width="100%" id="ra" runat="server" visible="true" >
                                <tr><td>&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2344;&#2366;&#2350; / Printer&nbsp; Name</td> <td>
                                        <asp:DropDownList ID="ddlTrnasportName" runat="server" CssClass="txtbox reqirerd" onkeypress="javascript:tbx_fnAlphaNumericOnly(event, this)">
                                        </asp:DropDownList>
                                    </td><td>
              
                               </td></tr> </table> 
                            <asp:Panel   class="form-message error" runat="server" id="mainDiv" style="display: none;padding-top:10px;padding-bottom:10px;">
                <asp:Label  id="lblmsg" class="notification" runat="server">
                
            </asp:Label>
            </asp:Panel>
                                 <asp:Button ID="btnExport" runat="server" CssClass="btn_gry" 
                                OnClick="btnExport_Click" Text="Export to Excel" Visible="False" />
                            <asp:Button ID="btnExportPDF" runat="server" CssClass="btn_gry" 
                                OnClientClick="return PrintPanel();" Text="Export to PDF & Print" Visible="False" />
            <div id="ExportDiv" runat="server" >
                            <table width="100%" id="asa" runat="server" visible="true" >
                                <tr>
                                    <td align="center" >  &#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; ,&#2360;&#2306;&#2349;&#2366;&#2327;&#2368;&#2351; &#2349;&#2306;&#2337;&#2366;&#2352;<br />
        <br />
&nbsp;<asp:Label ID="lblAddress" runat="server"></asp:Label>
                                        <br />
        <br />
       
                                        &#2337;&#2367;&#2346;&#2379; &#2350;&#2375;&#2306; &#2348;&#2306;&#2337;&#2354; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; 
                                         <br />  <br /> </td>
                                </tr>
                                
        <tr>
            <td style="text-align: center">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    CssClass="tab" >
                    <Columns>
                        <asp:BoundField DataField="PrinterName" HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;  / Printer Name" />
                        <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2379;  / Challan No" />
                        <asp:BoundField DataField="TotalBundal" HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2348;&#2306;&#2337;&#2354; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;  / Total Bundal in Challan" />
                        <asp:BoundField DataField="UploadedBundal" HeaderText="&#2348;&#2306;&#2337;&#2354; &#2309;&#2346;&#2354;&#2379;&#2337;  / Bundal Upload " />
                        <asp:BoundField DataField="withinChallanbundal" HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2375; &#2348;&#2306;&#2337;&#2354;  / Bundal Within Challan" />
                        <asp:BoundField DataField="Outchallanbundal" HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2375; &#2348;&#2361;&#2366;&#2352; &#2325;&#2375; &#2348;&#2306;&#2337;&#2354;  / Bundal Outside Challan" />
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

