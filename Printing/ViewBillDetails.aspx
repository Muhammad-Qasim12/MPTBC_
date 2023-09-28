<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewBillDetails.aspx.cs" Inherits="Printing_ViewBillDetails" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upPnale" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="upPnale">
                <ProgressTemplate>
                    <div class="fade">
                    </div>
                    <div class="progress">
                        <img src="../images/loading.gif" alt="Loading..." width="110" height="110" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="card">
                <div class="card-header">
                    <div class="row">
                        <div class="col-md-6">
                            <h2>बिल की जानकारी</h2>
                        </div>
                        <div class="col-md-6 text-right">
                            <a href="PrinterBillDetails.aspx" class="btn-add">नया डाटा डाले</a>
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <div class="row g-3">
                        <asp:HiddenField ID="hfApprovedFlag" runat="server" />
                        <asp:HiddenField ID="hfDesignationId" runat="server" />
                        <asp:HiddenField ID="hfDepartmentId" runat="server" />
                        <asp:HiddenField ID="hfLoggedInDeptName" runat="server" Value="" />
                        <asp:HiddenField ID="HDNVchrID" runat="server" Value="0" />
                        <asp:HiddenField ID="HDNBillPayTrno_I" runat="server" Value="" />
                        <asp:HiddenField ID="hdnStatus_M" runat="server" Value="0" />
                        <asp:HiddenField ID="hdnMode" runat="server" Value="" />
                        <asp:HiddenField ID="hfRevert" runat="server" Value="" />
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:TextBox ID="txtSearch" CssClass="form-control" runat="server"></asp:TextBox>
                                <label>बिल नंबर </label>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <asp:Button runat="server" ID="Button2" CssClass="btn btn-submit" Text="प्रिंटर को खोजे"  />
                            <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-submit" Text="Search"
                                OnClick="btnSearch_Click" />
                        </div>
                        <div class="col-md-12">
                            <asp:GridView ID="GrdLabMaster" runat="server" AutoGenerateColumns="False" GridLines="None"
                                    CssClass="table table-bordered" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="BillID_I"
                                    AllowPaging="True" OnPageIndexChanging="GrdLabMaster_PageIndexChanging"
                                    OnRowDataBound="GrdLabMaster_RowDataBound"
                                    OnSelectedIndexChanged="GrdLabMaster_SelectedIndexChanged" PageSize="40">
                                    <Columns>
                                        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1 %>.
                                        <asp:HiddenField ID="HidBill" runat="server" Value='<%# Eval("BillID_I") %>' />
                                                <asp:Label ID="ltrStatus" runat="server" Visible="false"></asp:Label>
                                                <asp:HiddenField ID="hdnStatus" runat="server" Value='<%#Eval("BillStatus") %>' />
                                                <asp:HiddenField ID="hdnIsChequeIssue" runat="server" Value='<%#Eval("IsChequeIssue") %>' />
                                                <asp:HiddenField ID="hdnVchrStatus" runat="server" Value='<%#Eval("VoucherStatus") %>' />
                                                <asp:HiddenField ID="hdnVoucherID" runat="server" Value='<%#Eval("VoucherID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2348;&#2367;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; ">
                                            <ItemTemplate>
                                                <%#Eval("Billno_V")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText=" &#2348;&#2367;&#2354; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; ">
                                            <ItemTemplate>

                                                <asp:Label ID="lblBilldate" runat="server" Text='<%#Eval("BillDate_D")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; ">
                                            <ItemTemplate>
                                                <%#Eval("NameofPress_V")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2348;&#2367;&#2354; &#2325;&#2368; &#2360;&#2381;&#2340;&#2367;&#2341;&#2367;">
                                            <ItemTemplate>
                                                <%#Eval("BillStatus")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2347;&#2366;&#2311;&#2344;&#2375;&#2306;&#2360; &#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368;">
                                            <ItemTemplate>
                                                <%#Eval("FinanceRemark")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;">
                                            <ItemTemplate>
                                                <asp:Panel ID="Panel1" runat="server" Visible='<%# Eval("BillStatus").ToString().Equals("In Process")?true:false %>'>
                                                    <a href="../Printing/PRI003_BillDetails.aspx?ID=<%#new APIProcedure().Encrypt(Eval("BillID_I").ToString()) %>">&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;</a>
                                                </asp:Panel>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="View Bill">
                                            <ItemTemplate>
                                                <asp:Panel ID="Panel33" runat="server">
                                                    <a href="../Printing/PRI003_BillDetails.aspx?ID=<%#new APIProcedure().Encrypt(Eval("BillID_I").ToString()) %>&vw=p">&#2342;&#2375;&#2326;&#2375;&#2306;</a>
                                                </asp:Panel>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:Panel ID="pnlCreateV" runat="server" Visible='<%# Eval("VoucherID").ToString().Equals("0")?true:false %>'>
                                                    <%--<a href="../PRI003_CreateVoucher.aspx?BillID=<%#new APIProcedure().Encrypt(Eval("BillID_I").ToString())%>&vw=<%#new APIProcedure().Encrypt("Printing")%>&BillID11=<%#new APIProcedure().Encrypt(Eval("BillID_I").ToString())%>">Create Voucher</a>&nbsp;|&nbsp;--%>
                                                    <asp:LinkButton ID="lnktitleBill" CommandName="Printing" CommandArgument='<%#Eval("BillID_I")%>' runat="server" OnClick="lnkForwardBill_Click" Text='Forward'></asp:LinkButton>
                                                </asp:Panel>

                                                <asp:Panel ID="pnlEditV" runat="server" Visible='<%# Eval("VoucherID").ToString().Equals("0")?false:true %>'>
                                                    <%--<a href="../PRI003_CreateVoucher.aspx?Cid=<%#new APIProcedure().Encrypt(Eval("VoucherID").ToString())%>&vw=<%#new APIProcedure().Encrypt("Printing")%>&BillID11=<%#new APIProcedure().Encrypt(Eval("BillID_I").ToString())%>&b=e&desg11=<%#new APIProcedure().Encrypt(Eval("ApprovedBy").ToString())%>">Edit Voucher</a>--%>
                                                    <asp:Label ID="ltrView" runat="server" Style="font-family: Calibri; color: #658f1f; font-size: 0.95em;"></asp:Label>
                                                </asp:Panel>

                                                <asp:Panel ID="pnlViewV" runat="server" Visible="false">
                                                    <a href="../PRI003_CreateVoucherNew.aspx?Cid=<%#new APIProcedure().Encrypt(Eval("VoucherID").ToString()) %>&vw=<%#new APIProcedure().Encrypt("Printing")%>&id=<%#new APIProcedure().Encrypt("0")%>&b=bill">View Voucher</a>
                                                </asp:Panel>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="" Visible="false">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnBtnViewGroup" runat="server" OnClick="lnBtnViewGroup_Click"
                                                    Text="Send To Finance"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <a href="../Printing/RunningBillRept.aspx?ID=<%#new APIProcedure().Encrypt(Eval("BillID_I").ToString()) %>" target="_blank">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2325;&#2352;&#2375;&#2306;</a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle CssClass="Gvpaging" />
                                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                                </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>

            <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
            </div>
            <div id="Messages" style="display: none;" class="popupnew1" runat="server">
                <h2><b>Forward Printing Bill</b> </h2>
                <table width="800px">

                    <tr>
                        <td>
                            <asp:Label ID="lblFarwardTo" runat="server" Text="&#2309;&#2349;&#2367;&#2350;&#2340; &#2309;&#2343;&#2367;&#2325;&#2366;&#2352;&#2368;/Forwarding Officer"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="ddlForwardTo" runat="server"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>&#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368;/Remark</td>
                        <td colspan="3">
                            <asp:TextBox ID="txtRemark" runat="server" Width="312px" Height="47px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="4">
                            <asp:Button ID="Button1" runat="server" CssClass="btn" Text="&#2310;&#2327;&#2375; &#2349;&#2375;&#2332;&#2375;&#2306;/Fowrard To" Width="169px" OnClick="btnSave_Click" OnClientClick="return ValidateLeave()" />
                            &nbsp;<asp:Button ID="Button3" runat="server" CssClass="btn" OnClick="lnBtnBack_Click" Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375;&#2306; " Width="83px" />
                        </td>
                    </tr>

                </table>

            </div>

            <asp:HiddenField ID="hfClassId" runat="server" />
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:HiddenField ID="hfEmployeeId" runat="server" />
            <asp:HiddenField ID="HiddenField2" runat="server" />
            <asp:HiddenField ID="hfUserId" runat="server" />
            <asp:HiddenField ID="hfDesignationName" runat="server" />
            <asp:HiddenField ID="hfPrinterId" runat="server" />
            <asp:HiddenField ID="hfEmpFullName" runat="server" />
            <asp:HiddenField ID="hfSaveSend" runat="server" Value="0" />
            <asp:HiddenField ID="HiddenField3" runat="server" Value="0" />
            <asp:HiddenField ID="HiddenField4" runat="server" Value="0" />
            <asp:HiddenField ID="HiddenField5" runat="server" Value="" />
            <asp:HiddenField ID="hfIsChequeIssue" runat="server" Value="0" />
            <asp:HiddenField ID="hfIsFinalBill" runat="server" Value="0" />

            <asp:Label ID="txtDepartmentName_V" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="txtLekhaSheersh_V" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="txtPayAmount_N" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="txtSanctionedAmount_N" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="txtSamayojanAmount_N" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="txtPartyBillDate_D" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="txtPartyBillNo_V" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="txtPartyName_V" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="txtPartyTrno_I" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="txtOfficerName_V" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="txtDesignationTrno_I" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="txtSamayojanAmount_N_Account" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="txtPayAmount_N_Account" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="txtPreviousBillAmount_N" runat="server" Visible="false"></asp:Label>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

