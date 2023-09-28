<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="GSRViewChallanDetails.aspx.cs" Inherits="GSRViewChallanDetails"
    Title="&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2360;&#2375;&#2306;&#2335;&#2381;&#2352;&#2354; &#2337;&#2367;&#2346;&#2379; &#2325;&#2379; &#2337;&#2367;&#2360;&#2381;&#2346;&#2376;&#2330;
        &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Dispatch Information Of Paper Mill To Central Depot " %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-header ui-widget-header">
    GSR प्राप्ति 
    </div>
    <div class="portlet-content">
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table width="100%">
                    <tr>
                        <td style="text-align: left">
                            <table>
                                <tr>
                                    <td width="23%">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; /Acadmic Year : <asp:DropDownList ID="ddlAcYear" runat="server" Width="100px" OnInit="ddlAcYear_Init"></asp:DropDownList></td>
                                     <td>
                    पेपर मिल का नाम/
                    Name Of Paper Mill
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlVendor" Width="160px" 
                        CssClass="txtbox reqirerd" >                       
                    </asp:DropDownList>
                            </td>
                                    <td style="text-align: right" width="5%">Date</td>
                        <td style="text-align: left" width="5%">
                             <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                                        <cc1:calendarextender ID="txtFromDate_CalendarExtender" Format="dd/MM/yyyy"  runat="server" TargetControlID="txtFromDate">
                        </cc1:calendarextender>
                        </td>
                                    <td>
                                        <asp:TextBox ID="txtSearch" runat="server" MaxLength="200" Width="200px" placeholder="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2326;&#2379;&#2332;&#2375; / Search By Challan No"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search"
                                            OnClick="btnSearch_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                             <div id="ExportDiv" runat="server">
                            <asp:GridView ID="GrdLOI" runat="server" AutoGenerateColumns="false" GridLines="None"
                                CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="DisTranId"
                                OnRowDeleting="GrdLOI_RowDeleting" AllowPaging="True" OnPageIndexChanging="GrdLOI_PageIndexChanging"
                                OnRowDataBound="GrdLOI_RowDataBound" OnRowCreated="GrdLOI_RowCreated">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>.
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="प्राप्ती दिनांक<br>Received Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReceivedDate" runat="server" Text='<%#Eval("ReceivedDate")%>'></asp:Label>                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>   

                                     <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; &#2344;&#2366;&#2350;<br>Name Of Paper Mill ">
                                        <ItemTemplate>
                                            <%#Eval("PaperVendorName_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                                                                                      

                                    <asp:TemplateField HeaderText="इनवॉइस क्रमांक<br>Challan No.">
                                        <ItemTemplate>
                                            <%#Eval("ChallanNo")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="इनवॉइस दिनांक<br>Challan Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblChallanDate" runat="server" Text='<%#Eval("ChallanDate")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="पेपर का प्रकार एवं साइज़<br>Paper Size">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPaperVendorTrId_I" runat="server" Visible="false" Text='<%#Eval("PaperVendorTrId_I")%>'></asp:Label>
                                            <asp:Label ID="lblPaperMstrTrId_I" runat="server" Visible="false" Text='<%#Eval("PaperMstrTrId_I")%>'></asp:Label>
                                            <asp:Label ID="lblLOITrId_I" runat="server" Visible="false" Text='<%#Eval("LOITrId_I")%>'></asp:Label>
                                            <%#Eval("CoverInformation")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField Visible="true" HeaderText="इनवॉइस की मात्रा<br>Quantity(Metric Ton)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPaperQty" Visible="false" runat="server"></asp:Label>
                                            <%#Eval("ReceivedQty")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <%-- <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br>Supply Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSupplyDate_D" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <%--<asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; (&#2350;&#2375;&#2306;. &#2335;&#2344;)<br>Supply Quantity(Metric Ton)">
                                        <ItemTemplate>
                                            <%#Eval("VdrSendQty")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <%--<asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2368; &#2309;&#2357;&#2343;&#2367; <br>Duration Of Supply Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSupplyTillDate_D" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>

                                     <%--<asp:TemplateField Visible="true" HeaderText="&#2352;&#2368;&#2354;/&#2348;&#2306;&#2337;&#2354;/&#2358;&#2368;&#2335;<br>&#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;" >
                                        <ItemTemplate>                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>

                                    <asp:TemplateField Visible="true" HeaderText="रील संख्या <br/> Reel">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReel"  runat="server" ></asp:Label> 
                                            <asp:Label ID="lblPaperCategory1" runat="server" Visible="false"
                                                 Text='<%#Eval("PaperCategory")%>' ></asp:Label>
                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField Visible="true" HeaderText="बंडल संख्या <br/> Bandal">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBandal"  runat="server" ></asp:Label>
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                     <asp:TemplateField Visible="true" HeaderText="शीट संख्या <br/> Sheet">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSheet"  runat="server" > </asp:Label>
                                            <asp:Label ID="lblPaperCategory2" runat="server" Visible="false" 
                                                Text='<%#Eval("PaperCategory")%>' ></asp:Label>
                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="&#2337;&#2375;&#2346;&#2379; &#2325;&#2368; &#2357;&#2366;&#2360;&#2381;&#2340;&#2357;&#2367;&#2325; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; (&#2350;&#2375;&#2306;. &#2335;&#2344;)<br>Actual Quantity Of Depo (Metric Ton)">
                                        <ItemTemplate>
                                            <%#Eval("ReceivedQty")%>
                                            <asp:Label ID="lblReceivedQty_in_sheet" Visible="false" runat="server" Text='<%#Eval("ReceivedQty_in_sheet")%>'></asp:Label>
                                            <asp:Label ID="lblNoOfReels" runat="server" Visible="false" Text='<%#Eval("NoOfReels")%>' ></asp:Label>
                                            <asp:Label ID="lblPaperCategory" runat="server" Visible="false" Text='<%#Eval("PaperCategory")%>' ></asp:Label>
                                               <asp:Label ID="lblSendQty" Visible="false" runat="server" Text='<%#Eval("VdrSendQty")%>'></asp:Label>
                                            <asp:Label ID="lblDisTranId" runat="server" Text='<%#Eval("DisTranId")%>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblTruckNo" Visible="false" runat="server" ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField Visible="true" HeaderText="GR नंबर">
                                        <ItemTemplate>
                                            <%#Eval("GRNo")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    <asp:TemplateField Visible="true" HeaderText="GR दिनांक">
                                        <ItemTemplate>
                                            <%#Eval("GRDate")%>
                                        </ItemTemplate>
                                        </asp:TemplateField>

                                                                       
                                   <%-- <asp:TemplateField Visible="true" HeaderText="&#2335;&#2381;&#2352;&#2325; &#2344;&#2306;. <br/> TruckNo">
                                        <ItemTemplate>                                            
                                            <%#Eval("TruckNo")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>

                                      <asp:TemplateField Visible="true" HeaderText="&#2327;&#2379;&#2342;&#2366;&#2350;- &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; <br/> WareHouse-No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblWareHouseName_V"  runat="server" ></asp:Label>
                                            <%#Eval("WareHouseName_V")%> - <%#Eval("RegistrationNo_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField Visible="true" HeaderText="प्राप्तकर्ता का नाम">
                                        <ItemTemplate>                                            
                                            <%#Eval("Praptkarta_naam")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                            </asp:GridView>
                                 </div>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="btnExport" runat="server" Height="28px" Text="Export to Excel" Visible="false" CssClass="btn" OnClick="btnExport_Click" />
            </div>
        </div>
    </div>
</asp:Content>
