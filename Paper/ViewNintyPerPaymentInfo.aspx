<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewNintyPerPaymentInfo.aspx.cs"
    Inherits="Paper_ViewNintyPerPaymentInfo" Title="90% &#2342;&#2375;&#2351;&#2325; &#2325;&#2375; &#2349;&#2369;&#2327;&#2340;&#2366;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Information Of 90% Payment." %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-header ui-widget-header">
        <%--Dispatch to C'Depot by Paper vendor--%> 90% &#2342;&#2375;&#2351;&#2325; &#2325;&#2375; &#2349;&#2369;&#2327;&#2340;&#2366;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Information Of 90% Payment.
    </div>
    <div class="portlet-content">
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table width="100%">
                    <tr>
                        <td style="text-align: left" width="20%">
                            <a class="btn" href="NintyPerPaymentInfo.aspx">&#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375; / New Entry
                            </a>
                        </td>
                        <td style="text-align: right" width="25%">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;
                        <br />
                            Academic Year
                        </td>
                        <td style="text-align: right" width="25%">
                            <asp:Label ID="lblAcYear" runat="server" Visible="false"></asp:Label>
                            <asp:DropDownList runat="server" ID="DdlACYear" Width="262px"
                                CssClass="txtbox reqirerd">
                                <asp:ListItem Text="Select"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: right" width="25%">
                            <asp:TextBox ID="txtSearch" runat="server" MaxLength="200" Width="300px" placeholder="&#2357;&#2366;&#2313;&#2330;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2326;&#2379;&#2332;&#2375; / Search By Voucher No."></asp:TextBox>
                        </td>
                        <td style="text-align: left" width="5%">
                            <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search" OnClick="btnSearch_Click" />
                             <asp:HiddenField ID="hfApprovedFlag" runat="server" />
                             <asp:HiddenField ID="hfLoggedInDeptName" runat="server" Value="" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="5">
                            <asp:GridView ID="GrdLOI" runat="server" AutoGenerateColumns="false" GridLines="None"
                                CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="Vouchar_Tr_Id"
                                OnRowDeleting="GrdLOI_RowDeleting" AllowPaging="True" OnPageIndexChanging="GrdLOI_PageIndexChanging"
                                OnRowDataBound="GrdLOI_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br> SrNo">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>.
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="बिल नंबर<br>Bill No.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblVouchar_Tr_Id" runat="server" Visible="false" Text='<%#Eval("Vouchar_Tr_Id") %>'></asp:Label>                                           
                                            <%#Eval("VoucharNo")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="बिल दिनांक<br>Bill Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblVoucharDate" runat="server" Text='<%#Eval("VoucharDate")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2357;&#2366;&#2313;&#2330;&#2352; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; <br> Information Of Voucher">
                                        <ItemTemplate>
                                             
                                            <asp:LinkButton ID="lnkShowData" runat="server" CausesValidation="false" OnClick="lnkShowData_Click">  &#2342;&#2375;&#2326;&#2375;</asp:LinkButton>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; &#2344;&#2366;&#2350;<br> Paper Mill Name">
                                        <ItemTemplate>
                                            <%#Eval("PaperVendorName_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>L.O.I. No.">
                                        <ItemTemplate>
                                            <%#Eval("LOINo_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="&#2342;&#2352;(&#2352;&#2369;&#2346;&#2351;&#2375; / &#2350;&#2375;. &#2335;&#2344;)<br>Rates Per Metric Ton">
                                        <ItemTemplate>
                                            <%#Eval("Rate")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                   <%-- <asp:TemplateField HeaderText="&#2357;&#2366;&#2313;&#2330;&#2352; &#2325;&#2368; &#2360;&#2381;&#2340;&#2367;&#2341;&#2367;<br>Voucher Status">
                                        <ItemTemplate>
                                            <asp:Panel ID="Pnl1" runat="server" Visible='<%#Eval("Status").ToString().Equals("0")?true:false%>'>
                                                Sent For Approval
                                            </asp:Panel>
                                            <asp:Panel ID="Pnl2" runat="server" Visible='<%#Eval("Status").ToString().Equals("1")?true:false%>'>
                                                Sent For Approval
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>    --%>                                 

                                    <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;<br>Edit">
                                        <ItemTemplate>
                                            <asp:Panel ID="pnupdate" runat="server">
                                                <a href="NintyPerPaymentInfo.aspx?ID=<%# new APIProcedure().Encrypt( Eval("Vouchar_Tr_Id").ToString()) %>&vw=e">&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;</a>
                                            </asp:Panel>
                                            <asp:Panel ID="Panel1" runat="server">
                                                <a target="_blank" href="NintyPerPaymentInfo.aspx?ID=<%# new APIProcedure().Encrypt( Eval("Vouchar_Tr_Id").ToString()) %>&vw=1">&#2348;&#2367;&#2354; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2342;&#2375;&#2326;&#2375;&#2306;</a>
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="&#2357;&#2366;&#2313;&#2330;&#2352; &#2325;&#2368; &#2360;&#2381;&#2340;&#2367;&#2341;&#2367;<br>Voucher Status" Visible="false">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnBtnViewGroup" runat="server" OnClick="lnBtnViewGroup_Click"></asp:LinkButton>
                                               <asp:Label ID="ltrStatus"  runat="server" Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                          <%--           <asp:TemplateField HeaderText="Create/Edit/View Voucher">
                                    <ItemTemplate>                                                                                
                                        <asp:Panel ID="pnlCreateV" runat="server" Visible='<%# Eval("VoucherID").ToString().Equals("0")?true:false %>'>
                                        <a href="../PRI003_CreateVoucher.aspx?BillID=<%#new APIProcedure().Encrypt(Eval("Vouchar_Tr_Id").ToString())%>&vw=<%#new APIProcedure().Encrypt("Paper")%>&BillID11=<%#new APIProcedure().Encrypt(Eval("Vouchar_Tr_Id").ToString())%>">Create Voucher</a>
                                        </asp:Panel>

                                          <asp:Panel ID="pnlEditV" runat="server" Visible='<%# Eval("VoucherID").ToString().Equals("0")?false:true %>'>
                                        <a href="../PRI003_CreateVoucher.aspx?Cid=<%#new APIProcedure().Encrypt(Eval("VoucherID").ToString())%>&vw=<%#new APIProcedure().Encrypt("Paper")%>&BillID11=<%#new APIProcedure().Encrypt(Eval("Vouchar_Tr_Id").ToString())%>&b=e">Edit Voucher</a>
                                        </asp:Panel>

                                         <asp:Panel ID="pnlViewV" runat="server" Visible="false">
                                         <a href="../PRI003_CreateVoucher.aspx?Cid=<%#new APIProcedure().Encrypt(Eval("VoucherID").ToString()) %>&vw=<%#new APIProcedure().Encrypt("Paper")%>&id=<%#new APIProcedure().Encrypt("0")%>&b=bill">View Voucher</a>
                                        </asp:Panel>
                                         <asp:HiddenField ID="hdnIsChequeIssue" runat="server" Value='<%#Eval("IsChequeIssue") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>

                                      <asp:TemplateField HeaderText="">
                                    <ItemTemplate>                                                                                
                                        <asp:Panel ID="pnlCreateV" runat="server" Visible='<%# Eval("VoucherID").ToString().Equals("0")?true:false %>'>
                                        <a href="../PRI003_CreateVoucher.aspx?BillID=<%#new APIProcedure().Encrypt(Eval("Vouchar_Tr_Id").ToString())%>&vw=<%#new APIProcedure().Encrypt("Paper")%>&BillID11=<%#new APIProcedure().Encrypt(Eval("Vouchar_Tr_Id").ToString())%>">Create Voucher</a>
                                        </asp:Panel>

                                          <asp:Panel ID="pnlEditV" runat="server" Visible='<%# Eval("VoucherID").ToString().Equals("0")?false:true %>'>
                                        <a href="../PRI003_CreateVoucher.aspx?Cid=<%#new APIProcedure().Encrypt(Eval("VoucherID").ToString())%>&vw=<%#new APIProcedure().Encrypt("Paper")%>&BillID11=<%#new APIProcedure().Encrypt(Eval("Vouchar_Tr_Id").ToString())%>&b=e">Edit Voucher</a>
                                        </asp:Panel>

                                         <asp:Panel ID="pnlViewV" runat="server" Visible="false">
                                          <a href="../PRI003_CreateVoucher.aspx?Cid=<%#new APIProcedure().Encrypt(Eval("VoucherID").ToString()) %>&vw=<%#new APIProcedure().Encrypt("Paper")%>&id=<%#new APIProcedure().Encrypt("0")%>&b=bill">View Voucher</a>
                                        </asp:Panel>

                                          <asp:HiddenField ID="hdnStatus" runat="server" Value='<%#Eval("BillStatus") %>' />
                                         <asp:HiddenField ID="hdnIsChequeIssue" runat="server" Value='<%#Eval("IsChequeIssue") %>' />
                                        <asp:HiddenField ID="hdnVchrStatus" runat="server" Value='<%#Eval("VoucherStatus") %>' />
                                        <asp:HiddenField ID="hdnVoucherID" runat="server" Value='<%#Eval("VoucherID") %>' />
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
    <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
    </div>
    <div id="BillDiv" class="popupnew" style="display: none; width: 650px;">
        <div align="right">
            <a href="#" onclick="document.getElementById('fadeDiv').style.display='none'; document.getElementById('BillDiv').style.display='none';">Close</a>
        </div>
        <table>
            <tr>
                <td style="font-size: 11px;">
                    <asp:GridView ID="GrdShowVouchar" runat="server" AutoGenerateColumns="false" GridLines="None"
                        CssClass="tab" EmptyDataText="Record Not Found." Width="100%" AllowPaging="false"
                        ShowFooter="true" OnRowDataBound="GrdShowVouchar_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>.
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2348;&#2367;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; <br> Invoice No">
                                <ItemTemplate>

                                    <asp:Label ID="lblChallanNo" runat="server" Text='<%#Eval("ChallanNo")%>'></asp:Label>
                                    <asp:Label ID="lblDisTranId" runat="server" Text='<%#Eval("DisTranId")%>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2348;&#2367;&#2354; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; <br>Invoice Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblChallanDate" runat="server" Text='<%#Eval("ChallanDate")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2332;&#2368; &#2310;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; <br> GR No">
                                <ItemTemplate>
                                    <asp:Label ID="lblGRNo" runat="server" Text='<%#Eval("GRNo")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2332;&#2368; &#2310;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; <br> GR Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblGrDate" runat="server" Text='<%#Eval("GRDate")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; <br> Receive Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblReceivedDate" runat="server" Text='<%#Eval("ReceivedDate")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    &#2325;&#2369;&#2354; &#2352;&#2366;&#2358;&#2367; / Total :
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2352;&#2368;&#2354; <br> No Of Reel">
                                <ItemTemplate>
                                    <asp:Label ID="lblNoOfReel" runat="server" Text='<%#Eval("NoOfReel")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblFNoOfReel" runat="server"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2357;&#2332;&#2344; <br> Weight">
                                <ItemTemplate>
                                    <asp:Label ID="lblWeight" runat="server" Text='<%#Eval("ReceivedQty")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblFWeight" runat="server"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2352;&#2366;&#2358;&#2367; <br> Amount">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblFAmount" runat="server"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
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

