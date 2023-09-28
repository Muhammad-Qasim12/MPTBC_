<%@ Page Title="&#2350;.&#2346;&#2381;&#2352; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; / M.P. TBC " Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VIEW_DPT009.aspx.cs" Inherits="Depo_VIEW_DPT009" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2357;&#2367;&#2325;&#2381;&#2352;&#2375;&#2340;&#2366; &#2350;&#2377;&#2327; &#2346;&#2381;&#2352;&#2340;&#2381;&#2352;&#2325; / Books Seller Demand Report</span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr>
                    <td style="text-align: left">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="&#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375; / New Data"   
                            onclick="btnSave_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                       <asp:GridView ID="grnMain" runat="server" AutoGenerateColumns="False" 
                    CssClass="tab" DataKeyNames="BookSelleDemandTrNo_I" 
                  > 
                    <Columns>
                       <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     <asp:HiddenField ID="BookSelleDemandTrNo_I" 
                                                         runat="server" Value='<%# Eval("BookSelleDemandTrNo_I") %>' />
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                        <asp:BoundField DataField="BDate_D" HeaderText="&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Date" />
                        <asp:BoundField DataField="DepoName_V" HeaderText="&#2337;&#2367;&#2346;&#2379; &#2344;&#2366;&#2350; / Depo Name" />
                          <asp:TemplateField HeaderText="&#2321;&#2352;&#2381;&#2337;&#2352; &#2344;&#2306;&#2348;&#2352; / Order No.">
                            <ItemTemplate>
                               <asp:LinkButton OnClick="lnkClick" runat="server"  CommandArgument='<%#Eval("OrderNo")%>'  Text='<%#Eval("OrderNo")%>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pay Now">
                            <ItemTemplate>
                              <a href="">  <div class="pm-button"><a href="https://www.payumoney.com/paybypayumoney/#/306C3B9B9911E7F84C1E6B5D5305247A"><img src="https://www.payumoney.com//media/images/payby_payumoney/buttons/111.png" /></a></div></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                                              <EmptyDataRowStyle CssClass="GvEmptyText" />
                </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        
    </div>
     <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server" >
            </div>
            <div id="Messages" style="display: none;" class="popupnew1" runat="server" >
                <h2>
                   <asp:Button ID="Button1" runat="server" Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375; " CssClass="btn"  onclick="Button1_Click" />
                <asp:Button ID="btnExportPDF" runat="server" CssClass="btn" 
                                OnClientClick="return PrintPanel();" Text="Export to PDF & Print" />
                </h2>
               
                    <p>
                        <asp:Panel ID="Panel1" runat="server" Width="900px" Height="500px" ScrollBars="Both" >
                             <div class="msg MT10" id="ExportDiv" runat="server" >
                             <table width="100%" class="tab">
                             <tr><th>&#2347;&#2352;&#2381;&#2350; /&#2342;&#2369;&#2325;&#2366;&#2344;  &#2325;&#2366; &#2344;&#2366;&#2350;  </th><th><%=obDataSet.Tables[0].Rows[0]["BooksellerName_V"]%> </th><th>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2357;&#2367;&#2325;&#2381;&#2352;&#2375;&#2340;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; </th><th><%=obDataSet.Tables[0].Rows[0]["BooksellerName_V"]%> </th></tr>
                             <tr><th>&#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2381;&#2352;&#2375;&#2358;&#2344; &#2344;&#2306;&#2348;&#2352;</th><th><%=obDataSet.Tables[0].Rows[0]["RegistrationNo_V"]%> </th><th>&#2350;&#2379;&#2348;&#2366;&#2311;&#2354; &#2344;&#2306;&#2348;&#2352;</th><th><%=obDataSet.Tables[0].Rows[0]["MobileNo_N"]%> </th></tr>
                             <tr><th>&#2337;&#2367;&#2346;&#2379; &#2344;&#2366;&#2350;</th><th><%=obDataSet.Tables[0].Rows[0]["DepoName"]%> </th><th>&#2321;&#2352;&#2381;&#2337;&#2352; &#2344;&#2306;&#2348;&#2352; / Order No.</th><th>
                                 <asp:Label ID="Label1" runat="server" Text=""></asp:Label></th></tr>
                             <tr><th>&#2337;&#2368; &#2337;&#2368; /&#2330;&#2375;&#2325; &#2344;&#2306;&#2348;&#2352; </th><th>
                                 <asp:Label ID="lblCheckNo" runat="server"></asp:Label>
                                 </th><th>डी डी /चेक राशि  </th><th>
                                 <asp:Label ID="lblCheckAmount" runat="server"></asp:Label>
                                 </th></tr>
                             <tr><th>&#2337;&#2368; &#2337;&#2368; /&#2330;&#2375;&#2325; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </th><th>
                                 <asp:Label ID="lblChekDate" runat="server"></asp:Label>
                                 </th><th> </th><th>
                                 
                                 </th></tr>
                                <tr>
                                    <th>पुस्तकों की कुल राशि</th>
                                    <th><asp:Label ID="lblTotalAmount" runat="server"></asp:Label></th>
                                    <th>देयक राशि </th>
                                    <th><asp:Label ID="Label2" runat="server"></asp:Label></th>
                                </tr> 
                             <tr><th>&#2348;&#2376;&#2306;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </th><th>
                                 <asp:Label ID="lblBankName" runat="server"></asp:Label>
                                 </th><th> ऑर्डर दिनांक  </th><th>
                                <asp:Label ID="lblDate" runat="server"></asp:Label></th></tr>
                         </table> 
                        <br />
                   <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                    CssClass="tab" DataKeyNames="BookSelleDemandTrNo_I"  ShowFooter="false"   >
                    <Columns>
                       <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     <asp:HiddenField ID="BookSelleDemandTrNo_I" 
                                                         runat="server" Value='<%# Eval("BookSelleDemandTrNo_I") %>' />
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                       <%-- <asp:BoundField DataField="BDate_D" HeaderText="&#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" />
                        <asp:BoundField DataField="DepoName_V" HeaderText="&#2337;&#2367;&#2346;&#2379; &#2344;&#2366;&#2350;" />--%>
                        <asp:BoundField DataField="MediunNameHindi_V" HeaderText="&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;" />
                        <asp:BoundField DataField="Classdet_V" HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366;" />
                          <asp:BoundField DataField="TitleHindi_V" HeaderText="शीर्षक का नाम " />
                        <asp:BoundField DataField="TotalDemand" HeaderText="&#2350;&#2366;&#2306;&#2327;" />
                        <asp:BoundField DataField="Rate_N" HeaderText="&#2352;&#2375;&#2335; " />
                       <asp:TemplateField HeaderText="कुल राशि ">
                                                 <ItemTemplate>
                                                      <%#Convert.ToInt32(Eval("TotalDemand")) * Convert.ToInt32(Eval("Rate_N"))%>
                                                   
                                                      </ItemTemplate>

                                             </asp:TemplateField>
                      
                        
                    </Columns>
                </asp:GridView></div>
                            </asp:Panel>
                    </p>
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

