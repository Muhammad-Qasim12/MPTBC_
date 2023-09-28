<%@ Page Title="&#2337;&#2367;&#2354;&#2368;&#2357;&#2352;&#2368; &#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Information Of Delivery Challan" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewDeliveryReelEntry.aspx.cs" Inherits="PaperVendor_ViewDeliveryReelEntry" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-header ui-widget-header">
        <%--Dispatch to C'Depot by Paper vendor--%>&#2337;&#2367;&#2354;&#2368;&#2357;&#2352;&#2368; &#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Information Of Delivery Challan
    </div>
    <div class="portlet-content">
        <div class="table-responsive">
            <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
                <table width="100%">
                    <tr>
                        <td style="text-align: left" width="20%">
                            <a class="btn" href="DeliveryReelEntry.aspx">&#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375; / New Entry
                            </a>
                        </td>
                        <td style="text-align: right" width="50%">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;
                            <br />
                            Acadmic Year :
                        </td>
                        <td style="text-align: left" width="10%">
                            <asp:DropDownList ID="ddlAcYear" runat="server" OnInit="ddlAcYear_Init" Width="120px"></asp:DropDownList>
                        </td>
                        <td style="text-align: right" width="25%">
                            <asp:TextBox ID="txtSearch" runat="server" MaxLength="200" Width="300px" placeholder="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2326;&#2379;&#2332;&#2375; / Search By Challan No"></asp:TextBox>
                        </td>
                        <td style="text-align: left" width="5%">
                            <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search"
                                OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="5">
                            <asp:GridView ID="GrdLOI" runat="server" AutoGenerateColumns="false" GridLines="None"
                                CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="Delivery_Id"
                                OnRowDeleting="GrdLOI_RowDeleting" AllowPaging="True" OnPageIndexChanging="GrdLOI_PageIndexChanging"
                                OnRowDataBound="GrdLOI_RowDataBound" PageSize="20">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo ">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>.
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; <br> Challan No">
                                        <ItemTemplate>
                                            <%#Eval("ChallanNo")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2348;&#2306;&#2337;&#2354;/&#2352;&#2368;&#2354;<br> Total Bundle / Reel ">
                                        <ItemTemplate>
                                            <%#Eval("RollNo")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2344;&#2375;&#2335; &#2357;&#2332;&#2344; (K.G.)<br>Net Weight(K.G.)">
                                        <ItemTemplate>
                                            <%#Eval("NetWt")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2377;&#2360; &#2357;&#2332;&#2344; (K.G.)<br>Gross Weight(K.G.)">
                                        <ItemTemplate>
                                            <%#Eval("GrossWt")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;<br>Edit">
                                        <ItemTemplate>
                                            <a href="DeliveryReelEntry.aspx?ID=<%# new APIProcedure().Encrypt(Eval("Delivery_Id").ToString()) %>&AcYear=<%=ddlAcYear.SelectedItem.Text %>">&#2337;&#2366;&#2335;&#2366;
                                                &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; / Edit</a>
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

