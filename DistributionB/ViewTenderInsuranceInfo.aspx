<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ViewTenderInsuranceInfo.aspx.cs" Inherits="DistributionB_ViewTenderInsuranceInfo" Title="Tender Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>बीमा टेंडर की जानकारी / Insurance Tender Information </span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table width="100%">
                    <tr>
                        <td style="text-align: left">
                            <table>
                                <tr>
                                    <td>
                                        <a class="btn" href="TenderInsuranceInfo.aspx">&#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366;
                                            &#2337;&#2366;&#2354;&#2375; </a>
                                    </td>
                                    <td style="width:170px;">
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSearch" MaxLength="200" placeholder="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; &#2326;&#2379;&#2332;&#2375;/ New Tender "
                                            runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375;"
                                            OnClick="btnSearch_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            <asp:GridView ID="GrdTenderInfo" runat="server" AutoGenerateColumns="false" GridLines="None"
                                CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="TenderTrId_I"
                                OnRowDeleting="GrdTenderInfo_RowDeleting" AllowPaging="True" OnPageIndexChanging="GrdTenderInfo_PageIndexChanging"
                                OnRowDataBound="GrdTenderInfo_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/S.No.">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>.
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2381;&#2352;./Tender No.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTenderTrId_I" Visible="false" runat="server" Text='<%#Eval("TenderTrId_I") %>'></asp:Label>
                                            <asp:LinkButton ID="lnkTenderNo_V" runat="server" Text='<%#Eval("TenderNo_V")%>'
                                                OnClick="lnkTenderNo_V_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;/ Tender Name">
                                        <ItemTemplate>
                                            <%#Eval("WorkName_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="बीमित सामग्री का विवरण/Type of Tender">
                                        <ItemTemplate>
                                            <%#Eval("TenderType_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2347;&#2368;&#2360;/Tender Fees">
                                        <ItemTemplate>
                                            <%#Eval("TenderFees_N")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2360;&#2381;&#2335;&#2377;&#2325; &#2325;&#2366; &#2309;&#2344;&#2369;&#2350;&#2366;&#2344;&#2367;&#2340; &#2350;&#2370;&#2354;&#2381;&#2351;(&#2352;&#2369;&#2346;&#2351;&#2375; &#2325;&#2352;&#2379;&#2396; &#2350;&#2375;&#2306;)  / Approx Anual stock (Rs. in Crore) ">
                                        <ItemTemplate>
                                            <%#Eval("TenderAmount")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="टेंडर जमा करने की अंतिम तिथि / Last Date of Tender Submission">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTenderSubmissionDate_D" runat="server" Text='<%#Eval("TenderSubmissionDate_D")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2337;&#2366;&#2313;&#2344;&#2354;&#2379;&#2337; &#2325;&#2352;&#2375; /Download Tender ">
                                        <ItemTemplate>
                                            <a href='<%#Eval("TenderFile_V")%>' target="_blank">&#2337;&#2366;&#2313;&#2344;&#2354;&#2379;&#2337;
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; /Edit">
                                        <ItemTemplate>
                                            <a href="TenderInsuranceInfo.aspx?ID=<%#new APIProcedure().Encrypt(Eval("TenderTrId_I").ToString()) %>">&#2337;&#2366;&#2335;&#2366;
                                                &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;</a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2335;&#2375;&#2325;&#2381;&#2344;&#2367;&#2325;&#2354; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375;&#2306; / Technical Bid Information">
                                        <ItemTemplate>
                                            <a href="DIB_013_TechnicalBid.aspx?Cid=<%#new APIProcedure().Encrypt(Eval("TenderTrId_I").ToString()) %>">&#2325;&#2381;&#2354;&#2367;&#2325;
                                                &#2325;&#2352;&#2375;&#2306;</a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2325;&#2377;&#2350;&#2352;&#2381;&#2360;&#2367;&#2309;&#2354; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375;&#2306; / Commercial Bid Information">
                                        <ItemTemplate>
                                            <a href="DIB_014_TenderEvaluation.aspx?ID=<%#new APIProcedure().Encrypt(Eval("TenderTrId_I").ToString()) %>">&#2325;&#2381;&#2354;&#2367;&#2325;
                                                &#2325;&#2352;&#2375;&#2306;</a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--  <asp:CommandField ShowDeleteButton="True" HeaderText="&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375;" />--%>
                                </Columns><PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div id="fadeDiv" runat="server" class="modalBackground" style="display: none">
        </div>
        <div id="Messages" style="display: none; width: 80%; left: 5%" class="popupnew" runat="server">
            <table width="100%">
                <div class="box">
                    <div class="card-header">
                        <h2>
                            <span>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;</span></h2>
                    </div>
                    <div class="table-responsive">
                        <table width="100%">
                            <tr>
                                <td colspan="4" style="height: 10px;">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <%--Name of Work --%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblNameOfWork" Text='<%#Eval("WorkName_V")%>'></asp:Label>
                                </td>
                                <td>
                                    <%--Tender Type--%>
                                    &#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblTenderType_V" Text='<%#Eval("TenderType_V")%>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="height: 10px;">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <%--RFP No. --%><%--&#2310;&#2352;.&#2319;&#2347;.&#2346;&#2368;.(--%>&#2335;&#2375;&#2306;&#2337;&#2352;
                                    &#2325;&#2381;&#2352;.
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblTenderNo_V" Text='<%#Eval("TenderNo_V")%>'></asp:Label>
                                </td>
                                <td>
                                    <%--Date --%><%--&#2310;&#2352;.&#2319;&#2347;.&#2346;&#2368;.(--%>&#2335;&#2375;&#2306;&#2337;&#2352;
                                    &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblTenderDate_D" Text='<%#Eval("TenderDate_D")%>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <%--RFP No. --%><%--&#2310;&#2352;.&#2319;&#2347;.&#2346;&#2368;.(--%>बीमा दिनांक(कब
                                    से)
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblInsuranceDateFrom_D" Text='<%#Eval("InsuranceDateFrom_D")%>'></asp:Label>
                                </td>
                                <td>
                                    <%--Date --%><%--&#2310;&#2352;.&#2319;&#2347;.&#2346;&#2368;.(--%>बीमा दिनांक(कब
                                    तक)
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblInsuranceDateTo_D" Text='<%#Eval("InsuranceDateTo_D")%>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <%--Details (--%>&#2357;&#2367;&#2357;&#2352;&#2339;
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblTenderDescription_V" Text='<%#Eval("TenderDescription_V")%>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="height: 10px;">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <%--EMD. (--%>
                                    &#2312; .&#2319;&#2350;.&#2337;&#2368;. &#2352;&#2366;&#2358;&#2367; (&#2352;&#2369;&#2346;&#2351;&#2375;
                                    &#2350;&#2375; )
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblEMDAmount_N" Text='<%#Eval("EMDAmount_N")%>'></asp:Label>
                                </td>
                                <td>
                                    <%--Tender Fee (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2347;&#2368;&#2360; (&#2352;&#2369;&#2346;&#2351;&#2375;
                                    &#2350;&#2375; )
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblTenderFees_N" Text='<%#Eval("TenderFees_N")%>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <%-- Anual stock--%>
                                    &#2360;&#2381;&#2335;&#2377;&#2325; &#2325;&#2366; &#2309;&#2344;&#2369;&#2350;&#2366;&#2344;&#2367;&#2340;
                                    &#2350;&#2370;&#2354;&#2381;&#2351;(&#2352;&#2369;&#2346;&#2351;&#2375; &#2325;&#2352;&#2379;&#2396;
                                    &#2350;&#2375;&#2306;)
                                </td>
                                <td colspan="3">
                                    <asp:Label runat="server" ID="lblTenderAmount" Text='<%#Eval("TenderAmount")%>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <%--Submission Date (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2332;&#2350;&#2366;
                                    &#2325;&#2352;&#2344;&#2375; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblTenderSubmissionDate_D" Text='<%#Eval("TenderSubmissionDate_D")%>'></asp:Label>
                                </td>
                                <td>
                                    &#2335;&#2375;&#2306;&#2337;&#2352; &#2332;&#2350;&#2366; &#2325;&#2352;&#2344;&#2375;
                                    &#2325;&#2366; &#2360;&#2350;&#2351;
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblTenderSubmissionTime" Text='<%#Eval("TenderSubmissionTime")%>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="1" style="height: 10px;">
                                    &#2335;&#2375;&#2325;&#2381;&#2344;&#2367;&#2325;&#2354; &#2348;&#2367;&#2337; &#2326;&#2379;&#2354;&#2344;&#2375;
                                    &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblTechDate" Text='<%#Eval("TechDate")%>'></asp:Label>
                                </td>
                                <td>
                                    &#2335;&#2375;&#2325;&#2381;&#2344;&#2367;&#2325;&#2354; &#2348;&#2367;&#2337; &#2326;&#2379;&#2354;&#2344;&#2375;
                                    &#2325;&#2366; &#2360;&#2350;&#2351;
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblTechTime" Text='<%#Eval("TechTime")%>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="1" style="height: 10px;">
                                    &#2325;&#2350;&#2352;&#2381;&#2358;&#2367;&#2351;&#2354; &#2348;&#2367;&#2337; &#2323;&#2346;&#2344;
                                    &#2325;&#2352;&#2344;&#2375; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblCommDate" Text='<%#Eval("CommDate")%>'></asp:Label>
                                </td>
                                <td>
                                    &#2325;&#2350;&#2352;&#2381;&#2358;&#2367;&#2351;&#2354; &#2348;&#2367;&#2337; &#2323;&#2346;&#2344;
                                    &#2325;&#2352;&#2344;&#2375; &#2325;&#2366; &#2360;&#2350;&#2351;
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblCommTime" Text='<%#Eval("CommTime")%>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &#2337;&#2367;&#2346;&#2379;
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblDepoIDs" Text='<%#Eval("DepoIDs")%>'></asp:Label>
                                </td>
                                <td>
                                    <%--Remark (--%>&#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368;
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblRemark_V" Text='<%#Eval("Remark_V")%>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="height: 10px;">
                                    <asp:HiddenField ID="hdnFile" runat="server" />
                                </td>
                            </tr>
                        </table>
                        <asp:LinkButton ID="lnBtnBack" runat="server" OnClick="lnBtnBack_Click">&#2346;&#2368;&#2331;&#2375; &#2332;&#2366;&#2319;&#2306;..</asp:LinkButton>
                    </div>
                </div>
            </table>
        </div>
    </div>
</asp:Content>
