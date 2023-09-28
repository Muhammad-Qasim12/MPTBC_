<%@ Page Title="View Reel/Bundle in Challan" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="ViewPaperDetails.aspx.cs" Inherits="CenterDepot_ViewPaperDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-header ui-widget-header">
       चालान में जोड़े गये रील/बंडल देखें / View Reel/Bundle in Challan
    </div>
    <div class="portlet-content">
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table width="100%">
                    <tr>
                        <td style="text-align: left" width="30%">
                            <a class="btn" href="PaperDetilas.aspx">&#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366;
                                &#2337;&#2366;&#2354;&#2375; / New Entry </a>
                        </td>
                        <td style="text-align: right" width="35%">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;<br />Acadmic Year  </td>
                        <td style="text-align: Left" width="15%"> <asp:DropDownList ID="ddlAcYear" Width="200px" runat="server" OnInit="ddlAcYear_Init"></asp:DropDownList></td>
                       
                        <td style="text-align: right" width="15%">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;<br />
                    Printer Name
                </td >
                <td style="text-align: right" width="15%">
                    <asp:DropDownList runat="server" ID="ddlPrinter" Width="200px" 
                        CssClass="txtbox reqirerd"  >
                        <asp:ListItem Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                         <td style="text-align: right" width="15%">
                            <asp:TextBox ID="txtSearch" runat="server" MaxLength="200" Width="200px" placeholder="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2326;&#2379;&#2332;&#2375; / Search By Challan No."></asp:TextBox>
                        </td >
                        <td style="text-align: left" width="5%">
                            <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="7">
                            <asp:GridView ID="GrdLOI" runat="server" AutoGenerateColumns="false" GridLines="None"
                                CssClass="tab" Width="100%" EmptyDataText="Record Not Found." 
                                 AllowPaging="True" OnPageIndexChanging="GrdLOI_PageIndexChanging" OnRowDataBound="GrdLOI_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>.
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="OrderNo">
                                        <ItemTemplate>
                                            <%#Eval("OrderNo")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Academic Yr">
                                        <ItemTemplate>
                                       <asp:Label ID="lblPrinter_RedID_I" runat="server" Visible="false" Text='<%#Eval("PrinterID_I")%>'></asp:Label>
                                         <%#Eval("Fyear")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cover Information">
                                        <ItemTemplate>
                                            <%#Eval("CoverInformation")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Reel">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReel" runat="server" Text='<%#Eval("NoofReel")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Paper Mill">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPaperVendorTrId_I" runat="server" Visible="false" Text='<%#Eval("PaperVendorTrId_I")%>'></asp:Label>
                                             <asp:Label ID="lblPaperMstrTrId_I" runat="server" Visible="false" Text='<%#Eval("PaperMstrTrId_I")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnStatus" runat="server" Value='<%#Eval("Status")%>' />
                                            <%#Eval("PaperVendorName_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Printer Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPressName" runat="server" Text='<%#Eval("NameofPress_V")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnChallanno" runat="server" Value='<%#Eval("OrderNo")%>' />                                            
                                             <a id="hrf" runat="server" onserverclick="btnAddChallanDetailse_Click" href="#">देखें / View</a>
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                                    
                                     <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:Panel ID="pnl" runat="server">
                                            <a href="CentralDepotDispatchToPrinterNew.aspx?Ono=<%# new APIProcedure().Encrypt( Eval("OrderNo").ToString()) %>&PrinterId=<%# new APIProcedure().Encrypt(Eval("PrinterID_I").ToString())%>&acyr=<%# new APIProcedure().Encrypt( Eval("Fyear").ToString())%>">
                                                चालान बनायें / Create</a>
                                                </asp:Panel>

                                            <asp:Panel ID="pnlPrint" runat="server">
                                                 <a href='CenteralReport/ReportCentralDepotDispatchToPrinter.aspx?PrinterId=<%# new APIProcedure().Encrypt( Eval("PrinterID_I").ToString())%>&acyr=<%# new APIProcedure().Encrypt( Eval("Fyear").ToString())%>&Ono=<%# new APIProcedure().Encrypt( Eval("OrderNo").ToString())%>'>चालान प्रिंट करें</a>
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                       
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>

      <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
    </div>
    <div id="BillDiv" class="popupnew" style="display: none; width: 900px; margin-left: -12%; margin-top: -5%">
        <div align="right">
            <a href="#" onclick="document.getElementById('fadeDiv').style.display='none'; document.getElementById('BillDiv').style.display='none';">Close</a>
        </div>
        <div style="min-height: 100px; max-height: 500px; overflow: auto;">
            <table width="100%">
                <tr>
                    <th colspan="6" style="font-weight: bold;" class="portlet-header ui-widget-header">View Reel/Bundle
                    </th>
                </tr>
               
                

            </table>
            <table width="100%">                
                <tr>
                    <td colspan="3" style="text-align: center;">

                        <asp:GridView ID="GrdChallanReel" runat="server" AutoGenerateColumns="false" GridLines="None"
                            CssClass="tab" EmptyDataText="Record Not Found." ShowFooter="true" Width="100%" AllowPaging="false"
                            OnRowDataBound="GrdChallanReel_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                    <ItemTemplate>
                                       <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                             
                                <asp:TemplateField HeaderText="रोल न. <br>Role /Bundle No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRollNo" runat="server" Text='<%#Eval("RollNo")%>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        &#2325;&#2369;&#2354; / Total :
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2344;&#2375;&#2335; &#2357;&#2332;&#2344; (&#2350;&#2375;. &#2335;&#2344;)<br>Net Weight(M.T.)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNetWt" runat="server" Text='<%#Eval("NetWt")%>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotNetWt" runat="server"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2377;&#2360; &#2357;&#2332;&#2344; (&#2350;&#2375;. &#2335;&#2344;)<br>Gross Weight(M.T.)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrossWt" runat="server" Text='<%#Eval("GrossWt")%>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotGrossWt" runat="server"></asp:Label>
                                    </FooterTemplate>
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

    <script type="text/javascript">
        function OpenBill() {
            document.getElementById('fadeDiv').style.display = "block";
            document.getElementById('BillDiv').style.display = "block";

        }
    </script>
</asp:Content>
