<%@ Page Title="वर्क प्लान & अनुबंध की जानकारी / Information Of Work Plan And Agreement" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ViewPaperVendorWorkPlan.aspx.cs" Inherits="Paper_ViewVendorAgreement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box">
        <div class="card-header">
            <h2>
                <span>वर्क प्लान & अनुबंध की जानकारी / Information Of Work Plan And Agreement</span>
            </h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table width="100%">
                    <tr>
                        <td style="text-align: left">
                            <table>
                                <tr>
                                    <td>
                                        <%-- <a href="WorkPlan.aspx">
                                        <div class="btn" style="width: 100px;">
                                            &#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375;</div>
                                    </a>--%>
                                    </td>
                                    <td style="text-align: right" width="30%">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;
                            <br />
                                        Acadmic Year :
                                    </td>
                                    <td style="text-align: right">
                                        <asp:DropDownList ID="ddlAcYear" runat="server" OnInit="ddlAcYear_Init"></asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSearch" Width="300px" runat="server" MaxLength="200" placeholder="पेपर का आकार खोजे / Search By Paper Size"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="खोजे / Search"
                                            OnClick="btnSearch_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            <asp:GridView ID="GrdAgreement" runat="server" AutoGenerateColumns="false" GridLines="None"
                                CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="WorkPlanTrId_I"
                                AllowPaging="True" OnRowDeleting="GrdAgreement_RowDeleting" OnPageIndexChanging="GrdAgreement_PageIndexChanging"
                                OnRowDataBound="GrdAgreement_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>.
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--  <asp:TemplateField HeaderText="पेपर मिल का नाम<br>Name Of Paper Mill">
                                    <ItemTemplate>
                                        <%#Eval("PaperVendorName_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="एल.ओ.आई. क्रमांक <br>L.O.I. No. ">
                                        <ItemTemplate>
                                            <%#Eval("LOINo_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="पेपर का प्रकार<br>Paper Type">
                                        <ItemTemplate>
                                            <%#Eval("PaperType")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="पेपर का आकार<br>Paper Size">
                                        <ItemTemplate>
                                            <%#Eval("CoverInformation")%>
                                            <asp:Label ID="lblAgreementTrId_I" Visible="false" runat="server" Text='<%#Eval("AgreementTrId_I")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText=" पेपर की मात्रा (मे. टन)<br>Paper Quantity(Metric Ton) ">
                                        <ItemTemplate>
                                            <%#Eval("PaperQuantity_N")%>
                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="&#2325;&#2366;&#2352;&#2381;&#2351;&#2366;&#2342;&#2375;&#2358; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br>Work Plan Date">
                                        <ItemTemplate>
                                            <asp:Panel ID="PnlStsDate" runat="server" Visible="false">
                                                अनुबंध नहीं हुआ
                                            </asp:Panel>
                                            <asp:Label ID="lblPBGDate_D" runat="server" Text='<%#Eval("AgreementDate_D")%>'></asp:Label>
                                            <asp:Label ID="lblPprVendorAgrSts" runat="server" Visible="false" Text='<%#Eval("PprVendorAgrSts")%>'></asp:Label>
                                            <asp:Label ID="lblLOIId_I" Visible="false" runat="server" Text='<%#Eval("wpLOIId_I")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="अनुबंध की जानकारी<br>Information Of Agreement">
                                        <ItemTemplate>
                                            <asp:Panel ID="pnlAgr" runat="server" Visible="false">
                                                <asp:LinkButton ID="lnkView" CausesValidation="false" OnClick="lnkView_Click" runat="server">&#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;
                                            &#2342;&#2375;&#2326;&#2375;</asp:LinkButton>
                                            </asp:Panel>

                                            <asp:Panel ID="Panel1StsNo" runat="server" Visible="false">
                                                &#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2344;&#2361;&#2368;&#2306; &#2361;&#2369;&#2310;
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="अनुबंध पत्र देखे">
                                        <ItemTemplate>
                                            <div id="a" runat="server" visible='<%# Eval("AgreementFile_V").ToString()=="" ? false  : true %>'>
                                         <a href='../PaperUploadedFile/<%# Eval("AgreementFile_V") %>' target="_blank"  >पत्र देखे</a></div>
                                        </ItemTemplate> </asp:TemplateField> 
                                    <asp:TemplateField HeaderText="आर्डर स्तर( हा / नहीं)<br>Order Status">
                                        <ItemTemplate>
                                            <asp:Panel ID="pnlStus" runat="server" Visible='<%#(Eval("PprVendorAgrSts").ToString().Equals("No"))?true:false%>'>
                                                <asp:CheckBox ID="chkAgrStatus" runat="server" />
                                            </asp:Panel>
                                            <asp:Panel ID="Panel3" runat="server" Visible='<%#(Eval("PprVendorAgrSts").ToString().Equals("No"))?false:true%>'>
                                                <%#Eval("PprVendorAgrSts")%>
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="आर्डर करे<br>Order Now">
                                        <ItemTemplate>
                                            <asp:Panel ID="pnlAgrCnm" runat="server" Visible='<%#(Eval("PprVendorAgrSts").ToString().Equals("No"))?true:false%>'>
                                                <asp:LinkButton ID="lnkAgrSave" CausesValidation="false" OnClick="lnkAgrSave_Click"
                                                    runat="server">आर्डर स्वीकार करे</asp:LinkButton>
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--  <asp:CommandField ShowDeleteButton="True" HeaderText="&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375;" />--%>
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
    <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
    </div>
    <div id="BillDiv" class="popupnew" style="display: none; width: 550px;">
        <div align="right">
            <a href="#" onclick="document.getElementById('fadeDiv').style.display='none'; document.getElementById('BillDiv').style.display='none';">Close</a>
        </div>
        <table class="tab">
            <tr>
                <th colspan="2">
                    <%--Agreement Details--%>&#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2325;&#2368;
                    &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Information Of Agreement
                </th>
            </tr>
            <tr>
                <th>
                    <%--LOI No. --%>(&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2344;&#2306;.) / L.O.I. No.
                </th>
                <td>
                    <%=LOINo %>
                </td>
            </tr>
            <tr>
                <th>
                    <%--LOI Date --%>(&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
                    ) / L.O.I. Date
                </th>
                <td>
                    <%=LOIDate %>
                </td>
            </tr>
            <tr>
                <th>
                    <%--LOI To. --%>(&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2346;&#2381;&#2352;&#2340;&#2367;) / L.O.I. To
                </th>
                <td>
                    <%=LOITo %>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td colspan="2" style="text-align: center;">
                    <asp:GridView ID="GrdPBGInfo" runat="server" AutoGenerateColumns="false" GridLines="None"
                        CssClass="tab" Width="100%" EmptyDataText="Record Not Found." AllowPaging="True">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>.
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="सिक्यूरिटी डिपाजिट  &#2344;&#2306;.<br>Security Deposit No.">
                                <ItemTemplate>
                                    <%#Eval("PBGNo_V")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="सिक्यूरिटी डिपाजिट  &#2352;&#2366;&#2358;&#2367; (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375; )<br>Security Deposit Amount">
                                <ItemTemplate>
                                    <%#Eval("PBGAmount")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2357;&#2376;&#2343;&#2381;&#2351;&#2340;&#2366; &#2360;&#2350;&#2351;<br>Validity Time">
                                <ItemTemplate>
                                    <%#Eval("ValidityTime_I")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <table class="tab">

            <tr>
                <th>
                    <%--Agreement No.--%>
                    (&#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2325;&#2381;&#2352;.) / Agreement No.
                </th>
                <td>
                    <%=AgreementNo%>
                </td>
            </tr>
            <tr>
                <th>
                    <%--Agreement Date--%>(&#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
                    ) / Agreement Date
                </th>
                <td>
                    <%=AgreementDate%>
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
