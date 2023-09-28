<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ViewPprVndrDispatchDetails.aspx.cs" Inherits="Paper_DispatchDetails"
    Title="&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2360;&#2375;&#2306;&#2335;&#2381;&#2352;&#2354; &#2337;&#2367;&#2346;&#2379; &#2325;&#2379; &#2337;&#2367;&#2360;&#2381;&#2346;&#2376;&#2330;
        &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Dispatch Information Of Paper Mill To Central Depot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-header ui-widget-header">
        <%--Dispatch to C'Depot by Paper vendor--%>&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2360;&#2375;&#2306;&#2335;&#2381;&#2352;&#2354; &#2337;&#2367;&#2346;&#2379; &#2325;&#2379; &#2337;&#2367;&#2360;&#2381;&#2346;&#2376;&#2330;
        &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Dispatch Information Of Paper Mill To Central Depot
    </div>
    <div class="portlet-content">
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table width="100%">
                    <tr>
                        <td style="text-align: left" width="20%">
                            <a class="btn" href="DispatchDetails.aspx">&#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375; / New Entry
                            </a>
                        </td>
                        <td style="text-align: right" width="20%">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;
                            <br />
                            Acadmic Year :
                        </td>
                        <td style="text-align: left" width="10%">
                            <asp:DropDownList ID="ddlAcYear" runat="server" OnInit="ddlAcYear_Init" Width="120px"></asp:DropDownList>
                        </td>
                        <td style="text-align: right" width="20%">
                            <asp:TextBox ID="txtSearch" Width="300px" runat="server" MaxLength="200" placeholder="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2326;&#2379;&#2332;&#2375; / Search By Challan No."></asp:TextBox>
                        </td>
                        <td style="text-align: left" width="5%">
                            <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search"
                                OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="5">
                            <asp:GridView ID="GrdLOI" runat="server" AutoGenerateColumns="false" GridLines="None"
                                CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="DisTranId"
                                OnRowDeleting="GrdLOI_RowDeleting" AllowPaging="True" OnPageIndexChanging="GrdLOI_PageIndexChanging"
                                OnRowDataBound="GrdLOI_RowDataBound" OnSelectedIndexChanged="GrdLOI_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>.
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--   <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; &#2344;&#2366;&#2350;<br>Name Of Paper Mill ">
                                    <ItemTemplate>
                                        
                                        <%#Eval("PaperVendorName_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; <br> Challan No.">
                                        <ItemTemplate>
                                            <%#Eval("ChallanNo")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br> Challan Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblChallanDate" runat="server" Text='<%#Eval("ChallanDate")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352;<br>Paper Size ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDisTranId" runat="server" Visible="false" Text='<%#Eval("DisTranId")%>'></asp:Label>
                                            <asp:Label ID="lblPaperVendorTrId_I" runat="server" Visible="false" Text='<%#Eval("PaperVendorTrId_I")%>'></asp:Label>
                                            <asp:Label ID="lblPaperMstrTrId_I" runat="server" Visible="false" Text='<%#Eval("PaperMstrTrId_I")%>'></asp:Label>
                                            <asp:Label ID="lblLOITrId_I" runat="server" Visible="false" Text='<%#Eval("LOITrId_I")%>'></asp:Label>
                                            <%#Eval("CoverInformation")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2350;&#2366;&#2340;&#2381;&#2352;&#2366; (&#2350;&#2375;. &#2335;&#2344;)<br>Quantity(Metric Ton) ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPaperQty" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; <br>Supply Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSupplyDate_D" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; (&#2350;&#2375;. &#2335;&#2344;)<br>Supply Quantity(Metric Ton)">
                                        <ItemTemplate>
                                            <%#Eval("VdrSendQty")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2368; &#2309;&#2357;&#2343;&#2367; <br>Duration Of Supply">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSupplyTillDate_D" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="&#2337;&#2367;&#2360;&#2381;&#2346;&#2376;&#2330; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; <br> Dispatch Information">
                                        <ItemTemplate>
                                            <asp:Panel ID="pnupdate221" runat="server" Visible='<%#(Eval("UpdateStatus").ToString().Equals("Send to central depot"))?true:false%>'>
                                                <asp:LinkButton ID="lnkChangeSts" runat="server" CausesValidation="false" OnClick="lnkChangeSts_Click" Text='<%#Eval("UpdateStatus") %>'></asp:LinkButton>
                                            </asp:Panel>
                                            <asp:Panel ID="Panel1" runat="server" Visible='<%#(Eval("UpdateStatus").ToString().Equals("Send to central depot"))?false:true%>'>
                                                <%#Eval("UpdateStatus") %>
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2357;&#2366;&#2360;&#2381;&#2340;&#2357;&#2367;&#2325; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; (&#2350;&#2375;. &#2335;&#2344;) <br>Actual Quantity(Metric Ton)">
                                        <ItemTemplate>
                                            <%#Eval("ReceivedQty")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br>Received Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReceivedDate" runat="server" Text='<%#Eval("ReceivedDate")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;<br>Edit">
                                        <ItemTemplate>
                                            <a href="DispatchDetails.aspx?ID=<%# new APIProcedure().Encrypt( Eval("DisTranId").ToString()) %>">&#2337;&#2366;&#2335;&#2366;
                                                &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; / Edit</a>
                                            <asp:Panel ID="pnupdate" runat="server" Visible='<%#(Eval("UpdateStatus").ToString().Equals("Send to central depot")||Eval("UpdateStatus").ToString().Equals("In Process"))?true:false%>'>
                                                <a href="DispatchDetails.aspx?ID=<%# new APIProcedure().Encrypt( Eval("DisTranId").ToString()) %>">&#2337;&#2366;&#2335;&#2366;
                                                &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; / Edit</a>
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;<br>Edit">
                                        <ItemTemplate>
                                            <asp:Panel ID="pnupdate1" runat="server" Visible='<%#(Eval("UpdateStatus").ToString().Equals("In Process"))?true:false%>'>
                                                <a href="DeliveryReelEntry.aspx?ChallanNo=<%# new APIProcedure().Encrypt( Eval("ChallanNo").ToString()) %>&&AcYear=<%=ddlAcYear.SelectedItem.Text %>">&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2332;&#2379;&#2396;&#2375; / Add</a>
                                            </asp:Panel>
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
</asp:Content>
