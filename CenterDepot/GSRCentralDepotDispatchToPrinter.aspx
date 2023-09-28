<%@ Page Title="&#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;/&#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; &#2361;&#2375;&#2340;&#2369; &#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Paper Demand Of Textbook/Other Than Textbook" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="GSRCentralDepotDispatchToPrinter.aspx.cs" Inherits="GSRCentralDepotDispatchToPrinter" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-header ui-widget-header">
        &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2352; (GSR)
    </div>
    <div class="portlet-content">
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table width="100%">
                    <tr>

                        <td style="text-align: right" width="15%">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;<br />
                            Acadmic Year  </td>
                        <td style="text-align: Left" width="15%">
                            <asp:DropDownList ID="ddlAcYear" Width="200px" runat="server" OnInit="ddlAcYear_Init"></asp:DropDownList></td>

                        <td style="text-align: right" width="15%">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;<br />
                            Printer Name
                        </td>
                        <td style="text-align: right" width="15%">
                            <asp:DropDownList runat="server" ID="ddlPrinter" Width="200px"
                                CssClass="txtbox reqirerd">
                                <asp:ListItem Text="Select"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: right" width="15%">Date</td>
                        <td style="text-align: left" width="20%">
                            <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" TargetControlID="txtFromDate"
                                Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                        </td>
                        <td style="text-align: right" width="15%">
                            <asp:TextBox ID="txtSearch" runat="server" MaxLength="200" Width="200px" placeholder="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2326;&#2379;&#2332;&#2375; / Search By Challan No."></asp:TextBox>
                        </td>
                        <td style="text-align: left" width="5%">
                            <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="8">
                            <div id="ExportDiv" runat="server">
                                <asp:GridView ID="GrdLOI" runat="server" AutoGenerateColumns="false" GridLines="None"
                                    CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="PrinterDisTranId"
                                    OnRowDeleting="GrdLOI_RowDeleting" AllowPaging="false"
                                    OnRowDataBound="GrdLOI_RowDataBound" OnRowCreated="GrdLOI_RowCreated">
                                    <Columns>
                                        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                            <ItemTemplate>
                                                <%--<%# Container.DataItemIndex+1 %>.--%>
                                                <asp:Literal ID="ltrSNo" runat="server"></asp:Literal>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--  <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; <br>Supply Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblChallanDate" runat="server" Text='<%#Eval("ChallanDate")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; <br>Supply Date">
                                            <ItemTemplate>
                                                <asp:Literal ID="ltrLeader" runat="server" Text='<%#Eval("ChallanDate")%>' OnDataBinding="ltrLeader_DataBinding"></asp:Literal>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; <br>Challan No.">
                                            <ItemTemplate>
                                                <asp:Literal ID="ltrChallanNo" runat="server" Text='<%#Eval("ChallanNo")%>' OnDataBinding="ltrChallanNo_DataBinding"></asp:Literal>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;<br>Printer Name">
                                            <ItemTemplate>
                                                <asp:Literal ID="ltrDemandFrom" runat="server" Text='<%#Eval("NameofPress_V")%>' OnDataBinding="ltrDemandFrom_DataBinding"></asp:Literal>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField Visible="false" HeaderText=" &#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; <br>">
                                            <ItemTemplate>
                                                <%#Eval("DemandFrom")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; &#2357; &#2360;&#2366;&#2311;&#2395; <br>Paper Type and Size">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPaperMstrTrId_I" runat="server" Visible="false" Text='<%#Eval("PaperMstrTrId_I")%>'></asp:Label>
                                                <%#Eval("CoverInformation")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; &#2344;&#2366;&#2350;<br>Name Of Paper Mill ">
                                            <ItemTemplate>
                                                <%#Eval("PaperVendorName_V")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField Visible="false" HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2348;&#2306;&#2335;&#2344;<br>Demand Of Paper(M.T.)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPaperQty" runat="server" Text='<%#Eval("ReqQty")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; <br>Supply Date" Visible="false">
                                            <ItemTemplate>
                                                <%#Eval("Transaction_D")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false" HeaderText="&#2352;&#2368;&#2354;/&#2348;&#2306;&#2337;&#2354;/&#2358;&#2368;&#2335;<br>&#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;">
                                            <ItemTemplate>
                                                <%#Eval("NoOfReels")%>  <%#Eval("PaperCategory")%>
                                                <asp:Label ID="lblNoOfReels" runat="server" Visible="false" Text='<%#Eval("NoOfReels")%>'></asp:Label>
                                                <asp:Label ID="lblPaperCategory" runat="server" Visible="false" Text='<%#Eval("PaperCategory")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false" HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; (&#2350;&#2375;. &#2335;&#2344;)<br>Supply Quantity(M.T.)">
                                            <ItemTemplate>
                                                <%#Eval("SendQty")%>
                                                <asp:Label ID="lblSendQty" runat="server" Visible="false" Text='<%#Eval("SendQty")%>'></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="true" HeaderText="रील संख्या <br/> Reel">
                                            <ItemTemplate>
                                                <asp:Label ID="lblReel" runat="server"></asp:Label>
                                                <asp:Label ID="lblPaperCategory1" runat="server" Visible="false" Text='<%#Eval("PaperCategory")%>'>

                                                </asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="true" HeaderText="बंडल संख्या <br/> Bandal">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBandal" runat="server"></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="true" HeaderText="शीट संख्या <br/> Sheet">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSheet" runat="server"> </asp:Label><asp:Label ID="lblPaperCategory2" runat="server" Visible="false" Text='<%#Eval("PaperCategory")%>'></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; (&#2350;&#2375;. &#2335;&#2344;)<br>Supply Quantity(M.T.)">
                                            <ItemTemplate>
                                                <%#Eval("SendQty")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="true" HeaderText="&#2335;&#2381;&#2352;&#2325; &#2344;&#2306;. <br/> TruckNo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTruckNo" runat="server"></asp:Label>
                                                <%#Eval("TruckNo")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="true" HeaderText="&#2327;&#2379;&#2342;&#2366;&#2350;- &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; <br/> WareHouse-No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblWareHouseName_V" runat="server"></asp:Label>
                                                <%#Eval("WareHouseName_V")%> - <%#Eval("RegistrationNo_V")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false" HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;<br>Edit">
                                            <ItemTemplate>
                                                <a href="CentralDepotDispatchToPrinterNew.aspx?ID=<%# new APIProcedure().Encrypt( Eval("PrinterDisTranId").ToString()) %>&PrinterId=<%# new APIProcedure().Encrypt( Eval("Printer_RedID_I").ToString()) %>">&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; / Edit</a>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField Visible="true" HeaderText="प्राप्तकर्ता का नाम">
                                            <ItemTemplate>
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
                <asp:Button ID="btnExport" runat="server" Height="28px" Text="Export to Excel" CssClass="btn" OnClick="btnExport_Click" />
            </div>
        </div>
    </div>
</asp:Content>
