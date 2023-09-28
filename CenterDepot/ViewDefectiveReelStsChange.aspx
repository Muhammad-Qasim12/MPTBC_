<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ViewDefectiveReelStsChange.aspx.cs" Inherits="ViewDefectiveReelStsChange"
    Title="&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2360;&#2375;&#2306;&#2335;&#2381;&#2352;&#2354; &#2337;&#2367;&#2346;&#2379; &#2325;&#2379; &#2337;&#2367;&#2360;&#2381;&#2346;&#2376;&#2330;
        &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Dispatch Information Of Paper Mill To Central Depot " %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-header ui-widget-header">
        &#2325;&#2335;&#2368; &#2361;&#2369;&#2312; &#2348;&#2306;&#2337;&#2354; / &#2352;&#2368;&#2354; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Information Of Defective Reel / Bundel
    </div>
    <div class="portlet-content">
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table width="100%">
                    <tr>
                        <td style="text-align: left">
                            <table>
                                <tr>
                                    <td style="text-align: right" width="60%">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;
                                        Acadmic Year  </td>
                                    <td style="text-align: Left" width="15%">
                                        <asp:DropDownList ID="ddlAcYear" Width="200px" runat="server" OnInit="ddlAcYear_Init"></asp:DropDownList></td>

                                    <td style="text-align: right" width="25%">&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; &#2344;&#2366;&#2350;/ Name Of Paper Mill
                                    </td>
                                    <td style="text-align: right" width="15%">
                                        <asp:DropDownList runat="server" ID="ddlVendor" Width="200px"
                                            CssClass="txtbox reqirerd">
                                            <asp:ListItem Text="Select"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSearch" runat="server" MaxLength="200" Width="400px" placeholder="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2326;&#2379;&#2332;&#2375; &#2324;&#2352; &#2352;&#2379;&#2354; &#2344;&#2306;&#2348;&#2352;/ Search By Challan No or Role No"></asp:TextBox>
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
                            <asp:GridView ID="GrdLOI" runat="server" AutoGenerateColumns="false" GridLines="None"
                                CssClass="tab" Width="100%" EmptyDataText="Record Not Found."
                                OnRowDeleting="GrdLOI_RowDeleting" AllowPaging="True" OnPageIndexChanging="GrdLOI_PageIndexChanging"
                                OnRowDataBound="GrdLOI_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>.
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; &#2344;&#2366;&#2350;<br>Name Of Paper Mill ">
                                        <ItemTemplate>
                                            <%#Eval("PaperVendorName_V")%>
                                            <asp:Label ID="lblid" runat="server" Text='<%#Eval("Id")%>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblPaperCategory" runat="server" Text='<%#Eval("PaperCategory")%>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; <br>Challan No.">
                                        <ItemTemplate>
                                            <%#Eval("ChallanNo")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;<br> Paper Type">
                                        <ItemTemplate>
                                            <%#Eval("PaperType")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352;<br>Paper Size">
                                        <ItemTemplate>
                                            <%#Eval("CoverInformation")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2352;&#2379;&#2354; &#2344;&#2306;&#2348;&#2352;<br> Role No.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRollNo" runat="server" Text='<%#Eval("RollNo")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2358;&#2368;&#2335; &#2346;&#2381;&#2352;&#2340;&#2367; &#2352;&#2368;&#2350;/&#2352;&#2368;&#2354; <br> Total Sheets Per Reem / Reel">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalSheets" runat="server" Text='<%#Eval("TotalSheets")%>'></asp:Label>
                                            <asp:TextBox ID="txtTotalSheets" runat="server" Text='<%#Eval("TotalSheets") %>' Visible="false" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2344;&#2375;&#2335; &#2357;&#2332;&#2344; (K.G.) <br>Net Weight(K.G.)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNetWt" runat="server" Text='<%#Eval("NetWt") %>'></asp:Label>
                                            <asp:TextBox ID="txtNetWt" runat="server" Text='<%#Eval("NetWt") %>' Visible="false" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2377;&#2360; &#2357;&#2332;&#2344; (K.G.)<br> Gross Weight(K.G.)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGrossWt" runat="server" Text='<%#Eval("GrossWt") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; <Br> Edit">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEdit" CausesValidation="false" runat="server" Text="Edit" OnClick="lnkEdit_Click"></asp:LinkButton>
                                            <asp:LinkButton ID="lnkUpdate" runat="server" Text="Update" Visible="false" OnClick="lnkUpdate_Click"></asp:LinkButton>
                                            <asp:LinkButton ID="lnkCancel" CausesValidation="false" runat="server" Text="Cancel" Visible="false" OnClick="lnkCancel_Click"></asp:LinkButton>
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
