<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="ViewPBGInfo.aspx.cs" Inherits="Paper_ViewPBGInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box">
        <div class="card-header">
            <h2>
                <span>&#2357;&#2375;&#2306;&#2337;&#2352; &#2346;&#2368;.&#2348;&#2368;.&#2332;&#2368;. &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;</span>
            </h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr>
                    <td style="text-align: left">
                        <table>
                            <tr>
                                <td>
                                    <a href="PBGInfo.aspx">
                                        <div class="btn" style="width: 100px;">
                                            &#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375;</div>
                                    </a>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:GridView ID="GrdPBGInfo" runat="server" AutoGenerateColumns="false" GridLines="None"
                            CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="PBGTrId_I"
                            AllowPaging="True"   OnRowDeleting="GrdPBGInfo_RowDeleting" OnPageIndexChanging="GrdPBGInfo_PageIndexChanging" OnRowDataBound="GrdPBGInfo_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2344;&#2306;.">
                                    <ItemTemplate>
                                        <%#Eval("LOINo_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2368;.&#2348;&#2368;.&#2332;&#2368;. &#2344;&#2306;.">
                                    <ItemTemplate>
                                        <%#Eval("PBGNo_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2368;.&#2348;&#2368;.&#2332;&#2368;. &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPBGDate_D" runat="server" Text='<%#Eval("PBGDate_D")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2368;.&#2348;&#2368;.&#2332;&#2368;. &#2348;&#2376;&#2306;&#2325; ">
                                    <ItemTemplate>
                                        <%#Eval("BankName")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2368;.&#2348;&#2368;.&#2332;&#2368;. &#2352;&#2366;&#2358;&#2367; (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375; )">
                                    <ItemTemplate>
                                        <%#Eval("PBGAmount")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2357;&#2376;&#2343;&#2381;&#2351;&#2340;&#2366; &#2360;&#2350;&#2351;">
                                    <ItemTemplate>
                                        <%#Eval("ValidityTime_I")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;">
                                    <ItemTemplate>
                                        <a href="PBGInfo.aspx?ID=<%#Eval("PBGTrId_I") %>&LOITrId=<%#Eval("LOITrId_I") %>">&#2337;&#2366;&#2335;&#2366;
                                            &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;</a>
                                    </ItemTemplate>
                                      
                                </asp:TemplateField>
                                <asp:CommandField ShowDeleteButton="True" HeaderText="&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375;" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
