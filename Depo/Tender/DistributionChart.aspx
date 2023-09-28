<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DistributionChart.aspx.cs" Inherits="Depo_Tender_DistributionChart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="box table-responsive">

        <div class="portlet-header ui-widget-header">
            &#2325;&#2366;&#2350;&#2352;&#2381;&#2358;&#2367;&#2351;&#2354; &#2348;&#2367;&#2337; &#2340;&#2369;&#2354;&#2344;&#2366;&#2340;&#2381;&#2350;&#2325; &#2346;&#2381;&#2352;&#2340;&#2381;&#2352;&#2325; </div>
        <div class="portlet-content">
            <div class="table-responsive">
                <asp:Panel ID="messDiv" runat="server">
                    <asp:Label ID="lblMess" runat="server" class="notification"></asp:Label>
                </asp:Panel>
                <asp:Button ID="btnExportPDF" runat="server" CssClass="btn_gry" 
                                OnClientClick="return PrintPanel();" Text="Export to PDF & Print"  />
                <div id="ExportDiv" runat="server">
                    <table width="100%">
                        <tr>
                            <td style="width:30%;">&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                            <td style="width:30%;">
                                <asp:DropDownList ID="ddlDepo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDepo_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="width:30%;">&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                            <td>
                                <asp:DropDownList ID="ddlTender" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTender_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:GridView ID="grdblock" runat="server" AutoGenerateColumns="False" CssClass="tab">
                                    <Columns>
                                        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2332;&#2367;&#2354;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; ">
                                            <ItemTemplate>
                                                <asp:Literal ID="ltrLeader" runat="server" OnDataBinding="ltrLeader_DataBinding"></asp:Literal>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="BlockNameHindi_V" HeaderText="&#2348;&#2381;&#2354;&#2366;&#2325; &#2350;&#2369;&#2326;&#2381;&#2351;&#2366;&#2354;&#2351; " />
                                        <asp:BoundField HeaderText="&#2346;&#2366;&#2352;&#2381;&#2335;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350; / Party Name" DataField="NameofParty" />
                                        
                                        <asp:BoundField HeaderText="&#2347;&#2369;&#2354; &#2335;&#2381;&#2352;&#2325; (9 &#2335;&#2344;) &nbsp;&#2352;&#2375;&#2335; (&#2327;&#2340; &#2357;&#2352;&#2381;&#2359; &#2325;&#2368; &#2342;&#2352;&#2375;  )"  DataField="FullTruckRate_N"/>
                                        <asp:TemplateField HeaderText=" &#2361;&#2366;&#2347; &#2335;&#2381;&#2352;&#2325; (4.5 &#2335;&#2344;) &#2352;&#2375;&#2335; (&#2327;&#2340; &#2357;&#2352;&#2381;&#2359; &#2325;&#2368; &#2342;&#2352;&#2375;  )"  >
                                            <ItemTemplate>
                                                <asp:Label ID="txtAvailableAmount" runat="server" onkeypress="javascript:tbx_fnNumeric(event, this);" Text='<%#Eval("HalfTruckRate_N") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367;&#2348;&#2306;&#2337;&#2354; &#2352;&#2375;&#2335; (&#2327;&#2340; &#2357;&#2352;&#2381;&#2359; &#2325;&#2368; &#2342;&#2352;&#2375;  )">
                                            <ItemTemplate>
                                                <asp:Label ID="txtrequestAmount" runat="server" onkeypress="javascript:tbx_fnNumeric(event, this);" Text='<%#Eval("RatePerBundle_N") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2347;&#2369;&#2354; &#2335;&#2381;&#2352;&#2325; (9 &#2335;&#2344;) ">
                                            <ItemTemplate>
                                                <asp:Label ID="txtEstimateAmount" runat="server" onkeypress="javascript:tbx_fnNumeric(event, this);" Text='<%#Eval("FullTruck") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText=" &#2361;&#2366;&#2347; &#2335;&#2381;&#2352;&#2325; (4.5 &#2335;&#2344;) &#2352;&#2375;&#2335;" DataField="HalftTruck" />
                                        <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367;&#2348;&#2306;&#2337;&#2354; &#2352;&#2375;&#2335; " DataField="PerBundle" />

                                        <asp:TemplateField HeaderText="&#2357;&#2371;&#2342;&#2381;&#2343;&#2367; &#2325;&#2366; &#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340; (9 &#2335;&#2344; )">
                                            <ItemTemplate>
                                              
                                                <%# Convert.ToInt32(Eval("FullTruck"))-Convert.ToInt32(Eval("FullTruckRate_N")== "" ? "0" :Eval("FullTruckRate_N") ) %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367;&#2348;&#2306;&#2337;&#2354; &#2352;&#2375;&#2335; ( &#2361;&#2366;&#2347; &#2335;&#2381;&#2352;&#2325; (4.5 &#2335;&#2344;) &#2352;&#2375;&#2335;)">
                                            <ItemTemplate>
                                                <%# Convert.ToInt32(Eval("HalftTruck"))-Convert.ToInt32(Eval("HalfTruckRate_N")== "" ? "0" : Eval("HalfTruckRate_N")) %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2357;&#2371;&#2342;&#2381;&#2343;&#2367; &#2325;&#2366; &#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340; (&#2346;&#2381;&#2352;&#2340;&#2367;&#2348;&#2306;&#2337;&#2354; &#2352;&#2375;&#2335;  )" >
                                            <ItemTemplate>
                                               <%# Convert.ToInt32(Eval("PerBundle"))-Convert.ToInt32(Eval("RatePerBundle_N")== "" ? "0" :Eval("RatePerBundle_N")) %>
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

