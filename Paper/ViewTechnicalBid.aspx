<%@ Page Title="&#2335;&#2375;&#2325;&#2381;&#2344;&#2367;&#2325;&#2354; &#2348;&#2367;&#2337; &#2325;&#2366; &#2340;&#2369;&#2354;&#2344;&#2366;&#2340;&#2381;&#2350;&#2325; &#2346;&#2340;&#2381;&#2352;&#2325; / Comparative Form Of Technical Bid" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
    CodeFile="ViewTechnicalBid.aspx.cs" Inherits="Paper_ViewTechnicalBid" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box">
        <div class="headlines">
            <h2>
                <span>&#2335;&#2375;&#2325;&#2381;&#2344;&#2367;&#2325;&#2354; &#2348;&#2367;&#2337; &#2325;&#2366; &#2340;&#2369;&#2354;&#2344;&#2366;&#2340;&#2381;&#2350;&#2325; &#2346;&#2340;&#2381;&#2352;&#2325; / Comparative Form Of Technical Bid</span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table width="100%">
                    <tr>
                        <td style="text-align: left" width="30%">
                            <a class="btn" href="TechnicalBid.aspx">&#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375; / New Entry
                            </a>
                        </td>
                        <td style="text-align: right" width="30%">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;
                            <br />
                            Acadmic Year :
                        </td>
                        <td style="text-align: right">
                            <asp:DropDownList ID="ddlAcYear" runat="server" OnInit="ddlAcYear_Init"></asp:DropDownList>
                        </td>
                        <td style="text-align: right" width="75%">
                            <asp:TextBox ID="txtSearch" runat="server" MaxLength="200" Width="300px" placeholder="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2381;&#2352;. &#2325;&#2366; &#2344;&#2366;&#2350; &#2326;&#2379;&#2332;&#2375; / Search By Tender No."></asp:TextBox>
                        </td>
                        <td style="text-align: left" width="5%">
                            <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search"
                                OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="5">
                            <asp:GridView ID="GrdLabMaster" runat="server" AutoGenerateColumns="false" GridLines="None"
                                CssClass="tab" Width="100%" EmptyDataText="Record Not Found."
                                AllowPaging="True" OnPageIndexChanging="GrdLabMaster_PageIndexChanging" OnRowDataBound="GrdLabMaster_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br> SrNo">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>.
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2381;&#2352;.<br> Tender No.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTenderId" runat="server" Text='<%#Eval("TenderTrId_I")%>' Visible="false"></asp:Label>
                                            <%#Eval("TenderNo_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;<br> Tender Name">
                                        <ItemTemplate>
                                            <%#Eval("WorkName_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; &#2344;&#2366;&#2350;<br> Name Of Paper Mill">
                                        <ItemTemplate>
                                            <asp:GridView ID="grdPaperMill" runat="server" GridLines="None" AutoGenerateColumns="false" ShowFooter="false" ShowHeader="false">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <div style="padding: 5px 0px 5px 0px;"><%#Eval("PaperVendorName_V")%></div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="कुल वांछित पेपर मात्रा <br>Total Required Paper Quantity">
                                        <ItemTemplate>
                                            <%#Eval("RqcQuantity")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;<br> Edit">
                                        <ItemTemplate>
                                            <asp:Panel ID="pnlEdit" runat="server" Visible='<%# bool.Parse(Eval("EnableStatus").ToString()) %>'>
                                                <a href="TechnicalBid.aspx?TndId=<%# new APIProcedure().Encrypt( Eval("TenderTrId_I").ToString()) %>">&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; / Edit</a>
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

