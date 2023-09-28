<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="ViewVendorAgreement.aspx.cs" Inherits="Paper_ViewVendorAgreement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box">
        <div class="card-header">
            <h2>
                <span>&#2357;&#2375;&#2306;&#2337;&#2352; &#2309;&#2344;&#2369;&#2348;&#2306;&#2343; (&#2319;&#2327;&#2381;&#2352;&#2368;&#2350;&#2375;&#2306;&#2335; )
                </span>
            </h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr>
                    <td style="text-align: left">
                        <table>
                            <tr>
                                <td>
                                    <a href="VendorAgreement.aspx">
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
                        <asp:GridView ID="GrdAgreement" runat="server" AutoGenerateColumns="false" GridLines="None"
                            CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="AgreementTrId_I"
                            AllowPaging="True" OnRowDeleting="GrdAgreement_RowDeleting" OnPageIndexChanging="GrdAgreement_PageIndexChanging"
                            OnRowDataBound="GrdAgreement_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                    <ItemTemplate>
                                        <%#Eval("LOINo_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2325;&#2366;&#2352;&#2381;&#2351;&#2366;&#2342;&#2375;&#2358; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                    <ItemTemplate>
                                   <%#Eval("AgreementNo_V")%>
                                     <asp:Label ID="lblAgreementTrId_I"  runat="server" Text='<%#Eval("AgreementTrId_I")%>' Visible="false" ></asp:Label>  
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2325;&#2366;&#2352;&#2381;&#2351;&#2366;&#2342;&#2375;&#2358; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPBGDate_D" runat="server" Text='<%#Eval("AgreementDate_D")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkView" CausesValidation="false" OnClick="lnkView_Click" runat="server">&#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;
                                            &#2342;&#2375;&#2326;&#2375;</asp:LinkButton>

                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;">
                                    <ItemTemplate>
                                        <a href="VendorAgreement.aspx?ID=<%#Eval("AgreementTrId_I") %>&LOITrId=<%#Eval("LOITrId_I") %>">
                                            &#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352;
                                            &#2325;&#2352;&#2375;</a>
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
    <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
    </div>
    <div id="BillDiv" class="popupnew" style="display: none">
        <div align="right">
            <a href="#" onclick="document.getElementById('fadeDiv').style.display='none'; document.getElementById('BillDiv').style.display='none';">
                Close</a></div>
        <table class="tab">
            <tr>
                <th colspan="2">
                    <%--Agreement Details--%>&#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2325;&#2368;
                    &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;
                </th>
            </tr>
            <tr>
                <th>
                    <%--LOI No. --%>(&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2344;&#2306;.)
                </th>
                <td>
                <%=LOINo %>
                </td>
            </tr>
            <tr>
                <th>
                    <%--LOI Date --%>(&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
                    )
                </th>
                <td> <%=LOIDate %>
                </td>
            </tr>
            <tr>
                <th>
                    <%--LOI To. --%>(&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2346;&#2381;&#2352;&#2340;&#2367;)
                </th>
                <td><%=LOITo %>
                </td>
            </tr>
            <tr>
                <th>
                    <%--PBG No.--%>
                    (&#2346;&#2368;.&#2348;&#2368;.&#2332;&#2368;. &#2325;&#2381;&#2352;.)
                </th>
                <td><%=PBGNo %>
                </td>
            </tr>
            <tr>
                <th>
                    <%--PBG Amount--%>
                    (&#2346;&#2368;.&#2348;&#2368;.&#2332;&#2368;. &#2352;&#2366;&#2358;&#2367;)
                </th>
                <td><%=PBGAMT %>
                </td>
            </tr>
            <tr>
                <th>
                    <%--Validity --%>(&#2346;&#2368;.&#2348;&#2368;.&#2332;&#2368;. &#2357;&#2376;&#2343;&#2381;&#2351;&#2340;&#2366;
                    )
                </th>
                <td><%=Validity%>
                </td>
            </tr>
            <tr>
                <th>
                    <%--Agreement No.--%>
                    (&#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2325;&#2381;&#2352;.)
                </th>
                <td><%=AgreementNo%>
                </td>
            </tr>
            <tr>
                <th>
                    <%--Agreement Date--%>(&#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
                    )
                </th>
                <td><%=AgreementDate%>
                </td>
            </tr>
        </table>
    </div>
    <script type="text/javascript">
        function OpenBill() {
            document.getElementById('fadeDiv').style.display = "block";
            document.getElementById('BillDiv').style.display = "block";

        }


    
    </script>
</asp:Content>
