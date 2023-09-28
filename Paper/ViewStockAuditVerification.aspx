<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ViewStockAuditVerification.aspx.cs" Inherits="Paper_ViewStockAuditVerification"
    Title="स्टॉक ऑडिट एवं सत्यापन / Stock Audit And Verification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box">
        <div class="headlines">
            <h2>
                <span>स्टॉक ऑडिट एवं सत्यापन / Stock Audit And Verification</span>
            </h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table width="100%">
                    <tr>
                        <td style="text-align: left" width="20%">
                            <a class="btn" href="StockAuditAndVerification.aspx">&#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366;
                                &#2337;&#2366;&#2354;&#2375; / New Entry</a>
                        </td>
                          <td style="text-align: right" width="30%">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;
                        <br />
                        Acadmic Year :
                    </td>
                    <td style="text-align: left" width="15%">
                        <asp:DropDownList ID="ddlAcYear" runat="server" OnInit="ddlAcYear_Init"  Width="245px"></asp:DropDownList>
                    </td>
                        <td style="text-align: right" width="25%">
                            <asp:TextBox ID="txtSearch" runat="server" MaxLength="200" Width="300px" placeholder="अधिकारी का नाम खोजे / Search By Officer Name"></asp:TextBox>
                        </td>
                        <td style="text-align: left" width="5%">
                            <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="खोजे / Search" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="5">
                            <asp:GridView ID="GrdLOI" runat="server" AutoGenerateColumns="false" GridLines="None"
                                CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="AuditTrId_I"
                                OnRowDeleting="GrdLOI_RowDeleting" AllowPaging="True" OnPageIndexChanging="GrdLOI_PageIndexChanging"
                                OnRowDataBound="GrdLOI_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>.
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="अधिकारी का नाम <br>Officer Name">
                                        <ItemTemplate>
                                            <%#Eval("Name")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="पद <br> Post">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPost" runat="server" Text='<%#Eval("Post")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="एल.ओ.आई. क्रमांक <br>L.O.I. No.">
                                        <ItemTemplate>
                                            <%#Eval("LOINo_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="सत्यापन रिपोर्ट <br>Verification Report">
                                        <ItemTemplate>
                                            <%#Eval("VerificationReport_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="डाउनलोड करे<br>Report Download">
                                        <ItemTemplate>
                                            <asp:Panel ID="pnldownload" runat="server" Visible='<%#Eval("VerifcationReportFile_V").ToString().Equals("#")?false:true%>'>
                                                <a href="<%#"../PaperUploadedFile/"+ Eval("VerifcationReportFile_V")%>"> रिपोर्ट डाउनलोड करे
                                                </a>
                                            </asp:Panel>
                                            <asp:Panel ID="Panel1" runat="server" Visible='<%#Eval("VerifcationReportFile_V").ToString().Equals("#")?true:false%>'>
                                                <a href="#">रिपोर्ट डाउनलोड करे </a>
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;<br>Edit">
                                        <ItemTemplate>
                                            <a href="StockAuditAndVerification.aspx?ID=<%# new APIProcedure().Encrypt( Eval("AuditTrId_I").ToString()) %>">&#2337;&#2366;&#2335;&#2366;
                                                &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;</a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:CommandField ShowDeleteButton="True" HeaderText="&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375;" />--%>
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
