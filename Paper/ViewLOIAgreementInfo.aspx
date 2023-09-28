<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewLOIAgreementInfo.aspx.cs"
    Inherits="Paper_ViewLOIAgreementInfo" Title="पेपर मिल एल.ओ.आई. (अनुबंध) की जानकारी / Information Of L.O.I.(Agreement)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box">
        <div class="headlines">
            <h2>
                <span>पेपर मिल एल.ओ.आई. (अनुबंध) की जानकारी / Information Of L.O.I.(Agreement)</span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table width="100%">
                    <tr>
                        <td style="text-align: left" width="30%">
                            <a class="btn" href="VendorLOI.aspx">&#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375; / New Entry
                            </a>
                        </td>
                        <td style="text-align: right" width="30%">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;
                            <br />
                            Acadmic Year :
                        </td>
                        <td style="text-align: right">
                            <asp:DropDownList ID="ddlAcYear" runat="server" OnInit="ddlAcYear_Init"></asp:DropDownList>
                        </td>
                        <td style="text-align: right" width="35%">
                            <asp:TextBox ID="txtSearch" runat="server" MaxLength="200" Width="300px" placeholder="एल.ओ.आई. क्रमांक खोजे / Search by L.O.I. No."></asp:TextBox>
                        </td>
                        <td style="text-align: left" width="5%">
                            <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="5">
                            <asp:GridView ID="GrdLOI" runat="server" AutoGenerateColumns="false" GridLines="None"
                                CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="LOITrId_I"
                                OnRowDeleting="GrdLOI_RowDeleting" AllowPaging="True"
                                OnPageIndexChanging="GrdLOI_PageIndexChanging"
                                OnRowDataBound="GrdLOI_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br> SrNo">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>.
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="टेंडर क्र. <br> Tender No.">
                                        <ItemTemplate>
                                            <%#Eval("TenderNo_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br> L.I.O. No.">
                                        <ItemTemplate>

                                            <%#Eval("LOINo_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; <br> L.O.I. Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLOIDate" runat="server" Text='<%#Eval("LOIDate_D")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2346;&#2381;&#2352;&#2340;&#2367;<br> L.O.I. To">
                                        <ItemTemplate>
                                            <%#Eval("PaperVendorName_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="मिल को आबंटित पेपर मात्रा (मे. टन)">
                                        <ItemTemplate>
                                            <%#Eval("AllotedQuantity")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="डाउनलोड करे<br> Download L.O.I.">
                                        <ItemTemplate>

                                            <asp:Panel ID="pnldownload" runat="server" Visible='<%#Eval("LOIFile_V").ToString().Equals("#")?false:true%>'>
                                                <a href="<%#"../PaperUploadedFile/"+ Eval("LOIFile_V")%>">एल.ओ.आई. डाउनलोड करे </a>
                                            </asp:Panel>
                                            <asp:Panel ID="Panel1" runat="server" Visible='<%#Eval("LOIFile_V").ToString().Equals("#")?true:false%>'>
                                                <a href="#">एल.ओ.आई. डाउनलोड करे</a>
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;<br>Edit">
                                        <ItemTemplate>
                                            <asp:Panel ID="pnlEdit" runat="server" Visible='<%# bool.Parse(Eval("EnableStatus").ToString()) %>'>
                                                <a href="VendorLOI.aspx?TndId=<%# new APIProcedure().Encrypt(Eval("TenderTrId_I").ToString()) %>&ID=<%# new APIProcedure().Encrypt(Eval("LOITrId_I").ToString()) %>">&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; / Edit</a>
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--   <asp:CommandField ShowDeleteButton="True" HeaderText="&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375;" />--%>
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

