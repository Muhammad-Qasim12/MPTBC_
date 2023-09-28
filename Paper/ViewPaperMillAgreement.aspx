<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ViewPaperMillAgreement.aspx.cs" Inherits="Paper_ViewPaperMillAgreement" Title="पेपर मिल अनुबंध एवं वर्क प्लान / Paper Mill Agreement and Work Plan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box">
        <div class="headlines">
            <h2>
                <span>&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2309;&#2344;&#2369;&#2348;&#2306;&#2343;
                    &#2319;&#2357;&#2306; &#2357;&#2352;&#2381;&#2325; &#2346;&#2381;&#2354;&#2366;&#2344; / Paper Mill Agreement and Work Plan
                </span>
                <span style="float:right;color:red;">अनुबंध हेतु संबंधित मिल को कार्यदेश स्वीकार करने हेतु निर्देशित करे |
                </span>
            </h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table width="100%">
                    <tr>
                        <td style="text-align: left" width="30%">
                            <a class="btn" href="WorkPlan.aspx">&#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366;
                                &#2337;&#2366;&#2354;&#2375; / New Entry</a>
                        </td>
                         <td style="text-align: right" width="30%">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;
                            <br />
                            Acadmic Year :
                        </td>
                        <td style="text-align: right">
                            <asp:DropDownList ID="ddlAcYear" runat="server" OnInit="ddlAcYear_Init"></asp:DropDownList>
                        </td>
                        <td style="text-align: right" width="25%">
                            <asp:TextBox ID="txtSearch" runat="server" MaxLength="200" Width="300px" placeholder="पेपर मिल का नाम खोजे / Search By Paper Mill Name"></asp:TextBox>
                        </td>
                        <td style="text-align: left" width="5%">
                            <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="खोजे / Search" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="5">
                            <asp:GridView ID="GrdAgreement" runat="server" AutoGenerateColumns="false" GridLines="None"
                                CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="WorkPlanTrId_I"
                                AllowPaging="True" OnRowDeleting="GrdAgreement_RowDeleting" OnPageIndexChanging="GrdAgreement_PageIndexChanging"
                                OnRowDataBound="GrdAgreement_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br> SrNo">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>.
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; &#2344;&#2366;&#2350;<br>Name Of Paper Mill">
                                        <ItemTemplate>
                                            <%#Eval("PaperVendorName_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                       <asp:TemplateField HeaderText="एल.ओ.आई. क्रमांक <br>L.O.I. No. ">
                                        <ItemTemplate>
                                            <%#Eval("LOINo_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;<br>Paper Type">
                                        <ItemTemplate>
                                            <%#Eval("PaperType")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352;<br>Paper Size">
                                        <ItemTemplate>
                                            <%#Eval("CoverInformation")%>
                                            <asp:Label ID="lblAgreementTrId_I" runat="server" Text='<%#Eval("AgreementTrId_I")%>'
                                                Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="पेपर की मात्रा (मे. टन)<br>
Paper Quantity(Metric Ton)">
                                        <ItemTemplate>
                                            <%#Eval("PaperQuantity_N")%>
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2325;&#2366;&#2352;&#2381;&#2351;&#2366;&#2342;&#2375;&#2358; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br>Agreement Date">
                                        <ItemTemplate>
                                            <asp:Panel ID="PnlStsDate" runat="server" Visible="false">
                                                अनुबंध नहीं हुआ
                                            </asp:Panel>
                                            <asp:Label ID="lblPBGDate_D" runat="server" Text='<%#Eval("AgreementDate_D")%>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblPprVendorAgrSts" runat="server" Text='<%#Eval("PprVendorAgrSts")%>'
                                                Visible="false"></asp:Label>
                                             <asp:LinkButton ID="lnkView11" CausesValidation="false" OnClick="lnkViewOrder_Click" Text='<%#Eval("AgreementDate_D")%>' runat="server"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;<br>Information Of Agreement">
                                        <ItemTemplate>
                                            <asp:Panel ID="pnlAgr" runat="server" Visible="false">
                                                <asp:LinkButton ID="lnkView" CausesValidation="false" OnClick="lnkView_Click" runat="server">&#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;
                                            &#2342;&#2375;&#2326;&#2375;</asp:LinkButton>
                                            </asp:Panel>
                                            <asp:Panel ID="Panel1StsYes" runat="server" Visible="false">
                                                <a href="VendorAgreement.aspx?LOI=<%# new APIProcedure().Encrypt(Eval("wpLOIId_I").ToString()) %>">&#2309;&#2344;&#2369;&#2348;&#2306;&#2343;
                                                    &#2325;&#2352;&#2375; </a>
                                            </asp:Panel>
                                            <asp:Panel ID="Panel1StsNo" runat="server" Visible="false">
                                                &#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2344;&#2361;&#2368;&#2306; &#2361;&#2369;&#2310;
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="अनुबंध डाउनलोड करे<br>Download Agreement">
                                        <ItemTemplate>
                                            <asp:Panel ID="pnlAgrDwnd" runat="server" Visible="false">
                                                <a href='<%# Eval("AgreementFile_V") %>'>अनुबंध डाउनलोड करे</a>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlAgrDwndNo" runat="server" Visible="false">
                                                &#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2344;&#2361;&#2368;&#2306; &#2361;&#2369;&#2310;
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="अनुबंध में सुधार करे <br>Agreement Edit">
                                        <ItemTemplate>
                                            <asp:Panel ID="pnlAgrUpdate" runat="server" Visible="false">
                                                <a href="VendorAgreement.aspx?ID=<%# new APIProcedure().Encrypt(Eval("AgreementTrId_I").ToString()) %>&LOITrId=<%# new APIProcedure().Encrypt(Eval("LOITrId_I").ToString()) %>">
                                                    अनुबंध में सुधार करे </a>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlAgrUpdateNo" runat="server" Visible="false">
                                                &#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2344;&#2361;&#2368;&#2306; &#2361;&#2369;&#2310;
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2319;&#2327;&#2381;&#2352;&#2368;&#2350;&#2375;&#2306;&#2335; &#2360;&#2381;&#2340;&#2352;<br>Agreement Status">
                                        <ItemTemplate>
                                            <%#Eval("PprVendorAgrSts")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;<br>Edit">
                                        <ItemTemplate>
                                            <asp:Panel ID="pnlAgrUpdt" runat="server" Visible="false">
                                                <a href="WorkPlan.aspx?ID=<%# new APIProcedure().Encrypt(Eval("WorkPlanTrId_I").ToString()) %>&PVID=<%#  new APIProcedure().Encrypt(Eval("PaperVendorTrId_I").ToString()) %>">
                                                    &#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352;
                                                    &#2325;&#2352;&#2375;</a>
                                            </asp:Panel>
                                            <asp:HiddenField ID="hdnLOIId" runat="server" Value='<%#Eval("wpLOIId_I")%>' />
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
            <a href="#" onclick="document.getElementById('fadeDiv').style.display='none'; document.getElementById('BillDiv').style.display='none';">
                Close</a></div>
        <table class="tab">
            <tr>
                <th colspan="2">
                    <%--Agreement Details--%>&#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2325;&#2368;
                    &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Information Of Agreement 
                </th>
            </tr>
            <tr>
                <th>
                    <%--LOI No. --%>(&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2344;&#2306;./L.O.I. No.)
                </th>
                <td>
                    <%=LOINo %>
                </td>
            </tr>
            <tr>
                <th>
                    <%--LOI Date --%>(&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/L.O.I. Date)
                </th>
                <td>
                    <%=LOIDate %>
                </td>
            </tr>
            <tr>
                <th>
                    <%--LOI To. --%>(&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2346;&#2381;&#2352;&#2340;&#2367;/L.O.I. To)
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
                    (&#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2325;&#2381;&#2352;./Agreement No.)
                </th>
                <td>
                    <%=AgreementNo%>
                </td>
            </tr>
            <tr>
                <th>
                    <%--Agreement Date--%>(&#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/Agreement Date)
                </th>
                <td>
                    <%=AgreementDate%>
                </td>
            </tr>
        </table>
    </div>

    <div id="fadeDiv11" class="modalBackground" style="display: none;" runat="server">
    </div>
    <div id="BillDiv11" class="popupnew" style="display: none;width:80%;left:5%;">
        <div align="right">
            <a href="#" onclick="closepp()">
                Close</a></div>
      
         <div class="headlines">
                            <h2>
                                <span> पेपर मिल अनुबंध एवं वर्क प्लान / Paper Mill Agreement and Work Plan</span></h2>
                        </div>
        <div class="table-responsive">
        <table>
           
            <tr>
                <td colspan="5" style="text-align: center;">
                    <asp:Panel ID="panl" runat="server" ScrollBars="Vertical" Height="400px">
                    <asp:GridView ID="GrdWorkPlan" runat="server" AutoGenerateColumns="false" GridLines="None"
                            DataKeyNames="WorkPlanTrId_I" CssClass="tab" EmptyDataText="Record Not Found."
                            Width="100%" AllowPaging="false" OnRowDataBound="GrdWorkPlan_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;<br>Paper Type">
                                    <ItemTemplate>
                                        <%#Eval("PaperType")%>
                                        <asp:Label ID="lblPaperType_I" runat="server" Text='<%#Eval("PaperType_I")%>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblWorkPlanTrId_I" runat="server" Text='<%#Eval("WorkPlanTrId_I")%>'
                                            Visible="false"></asp:Label>
                                        <asp:Label ID="lblPaperMstrTrId_I" runat="server" Text='<%#Eval("PaperMstrTrId_I")%>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352;<br>Paper Size ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCoverInformation" runat="server" Text='<%#Eval("CoverInformation")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; (&#2350;&#2375;. &#2335;&#2344;)<br>Paper Quantity(Metric Ton)">
                                    <ItemTemplate>

                                        <asp:Label ID="lblPaperQuantity_N" runat="server" Text='<%#Eval("PaperQuantity_N")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2352;&#2366;&#2358;&#2367;(&#2352;&#2369;&#2346;&#2351;&#2375; / &#2350;&#2375;. &#2335;&#2344;)<br>Total Amount(Metric Ton in Rupees)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotAmt" runat="server" Text='<%#Eval("TotAmount")%>'></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" &#2310;&#2342;&#2375;&#2358; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; <b> Order NO.">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItmOrderNo" runat="server" Text='<%#Eval("OrderNo")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2310;&#2342;&#2375;&#2358; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br>Order Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSupplyDate_D" runat="server" Text='<%#Eval("SupplyDate_D")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2366;&#2352;&#2306;&#2349;&#2367;&#2325; &#2340;&#2367;&#2341;&#2367; <br>Start Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStartDate" runat="server" Text='<%#Eval("StartDate")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="&#2309;&#2306;&#2340;&#2367;&#2350; &#2340;&#2367;&#2341;&#2367; <br>Last Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEndDate_D" runat="server" Text='<%#Eval("SupplyTillDate_D")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                        </asp:Panel>
                </td>
            </tr>
        </table>
          </div>
    </div>
    <script type="text/javascript">
        function OpenBill() {
            document.getElementById('fadeDiv').style.display = "block";
            document.getElementById('BillDiv').style.display = "block";
        }

        function OpenBill11() {
            document.getElementById('<%=fadeDiv11.ClientID%>').style.display = "block";
            document.getElementById('BillDiv11').style.display = "block";
        }

        function closepp() {
            document.getElementById('<%=fadeDiv11.ClientID%>').style.display = 'none';
            document.getElementById('BillDiv11').style.display = 'none';
        }
        
    </script>
</asp:Content>
