<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewPRI008FinalBillDetails.aspx.cs" Inherits="Printing_ViewPRI008FinalBillDetails" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box">
        <div class="card-header">
            <h2>
                <span>&#2348;&#2367;&#2354; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;</span></h2>
        </div>
      <div class="box table-responsive">
            <table width="100%">
                <tr>
                    <td style="text-align: left">
                        <table>
                            <tr>
                                <td>
                                    <a href="PRI008_FinalBillDetails.aspx">
                                        <div class="btn">
                                            &#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375;</div>
                                    </a>
                                     <asp:HiddenField ID="hfApprovedFlag" runat="server" />    
     <asp:HiddenField ID="hfDesignationId" runat="server" />
                                     <asp:HiddenField ID="hfDepartmentId" runat="server" />
                                     <asp:HiddenField ID="hfLoggedInDeptName" runat="server" Value="" />
                                    <asp:HiddenField ID="HDNVchrID" runat="server" Value="0" />
                                     <asp:HiddenField ID="HDNBillPayTrno_I" runat="server" Value="" />
                                     <asp:HiddenField ID="hdnStatus_M" runat="server" Value="0" />
                                    <asp:HiddenField ID="hdnMode" runat="server" Value="" />
                                    <asp:HiddenField ID="hfRevert" runat="server" Value="" />
                                </td>
                                <td>
                     <asp:Button runat="server" ID="Button2" CssClass="btn" 
                             Text="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2379; &#2326;&#2379;&#2332;&#2375; / Search Printer " 
                             Width="198px" />
                     </td>
                                <td>
                                    <asp:TextBox ID="txtSearch"  runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="Search" 
                                        onclick="btnSearch_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:GridView ID="GrdLabMaster" runat="server" AutoGenerateColumns="False" GridLines="None"
                            CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="BillID_I"
                            AllowPaging="True" OnPageIndexChanging="GrdLabMaster_PageIndexChanging" 
                            onrowdatabound="GrdLabMaster_RowDataBound" 
                            onselectedindexchanged="GrdLabMaster_SelectedIndexChanged">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                        <asp:HiddenField ID="HidBill" runat="server" Value='<%# Eval("BillID_I") %>' />
                                        <asp:Label ID="ltrStatus"  runat="server" Visible="false"></asp:Label>
                                        <asp:HiddenField ID="hdnStatus" runat="server" Value='<%#Eval("BillStatus") %>' />
                                         <asp:HiddenField ID="hdnIsChequeIssue" runat="server" Value='<%#Eval("IsChequeIssue") %>' />
                                        <asp:HiddenField ID="hdnVchrStatus" runat="server" Value='<%#Eval("VoucherStatus") %>' />
                                        <asp:HiddenField ID="hdnVoucherID" runat="server" Value='<%#Eval("VoucherID") %>' />
                                        
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

                                <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;">
                                    <ItemTemplate>
                                        <asp:Panel ID="Panel1" runat="server" Visible='<%# Eval("BillStatus").ToString().Equals("In Process")?true:false %>'>
                                        <%--<a href="../Printing/PRI003_BillDetails.aspx?ID=<%#new APIProcedure().Encrypt(Eval("BillID_I").ToString()) %>" target="_blank">&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;</a>--%>
                                            <a href="../Printing/PRI008_FinalBillDetails.aspx?ID=<%#new APIProcedure().Encrypt(Eval("BillID_I").ToString()) %>">&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;</a>
                                        </asp:Panel>
                                     </ItemTemplate>
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="View Bill">
                                    <ItemTemplate>                                        
                                        <asp:Panel ID="Panel33" runat="server">
                                        <%--<a href="../Printing/PRI003_BillDetails.aspx?ID=<%#new APIProcedure().Encrypt(Eval("BillID_I").ToString()) %>&vw=1" target="_blank">&#2342;&#2375;&#2326;&#2375;&#2306;</a>--%>
                                            <a href="../Printing/PRI008_FinalBillDetails.aspx?ID=<%#new APIProcedure().Encrypt(Eval("BillID_I").ToString()) %>&vw=<%#new APIProcedure().Encrypt("1") %>">&#2342;&#2375;&#2326;&#2375;&#2306;</a>
                                       </asp:Panel>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Voucher Information">
                                    <ItemTemplate>                                                                                
                                        <asp:Panel ID="pnlCreateV" runat="server" Visible='<%# Eval("VoucherID").ToString().Equals("0")?true:false %>'>
                                        <%--<a href="../PRI003_CreateVoucher.aspx?BillID=<%#new APIProcedure().Encrypt(Eval("BillID_I").ToString())%>&vw=<%#new APIProcedure().Encrypt("Printing")%>&BillID11=<%#new APIProcedure().Encrypt(Eval("BillID_I").ToString())%>&fin=<%#new APIProcedure().Encrypt(Eval("IsFinalBill").ToString())%>">Create Voucher</a>--%>
                                            <asp:LinkButton ID="lnktitleBill" CommandName="Printing" CommandArgument='<%#Eval("BillID_I")%>' runat="server" OnClick="lnkForwardBill_Click" Text='Forward'></asp:LinkButton>
                                        </asp:Panel>

                                          <asp:Panel ID="pnlEditV" runat="server" Visible='<%# Eval("VoucherID").ToString().Equals("0")?false:true %>'>
                                        <%--<a href="../PRI003_CreateVoucher.aspx?Cid=<%#new APIProcedure().Encrypt(Eval("VoucherID").ToString())%>&vw=<%#new APIProcedure().Encrypt("Printing")%>&BillID11=<%#new APIProcedure().Encrypt(Eval("BillID_I").ToString())%>&b=e&desg11=<%#new APIProcedure().Encrypt(Eval("ApprovedBy").ToString())%>&fin=<%#new APIProcedure().Encrypt(Eval("IsFinalBill").ToString())%>">Edit Voucher</a>--%>
                                              <asp:Label ID="ltrView" runat="server" style="font-family:Calibri;color:#658f1f;font-size:0.95em;" Text='<%#Eval("PartyBillNo_V")%>'></asp:Label>
                                              <asp:Literal ID="ltrText" runat="server">:&nbsp;प्रिंटिंग बिल को आगे भेजा गया</asp:Literal>
                                        </asp:Panel>

                                         <asp:Panel ID="pnlViewV" runat="server" Visible="false">
                                              <a href="../PRI003_CreateVoucherNew.aspx?Cid=<%#new APIProcedure().Encrypt(Eval("VoucherID").ToString()) %>&vw=<%#new APIProcedure().Encrypt("Printing")%>&id=<%#new APIProcedure().Encrypt("0")%>&b=bill&fin=<%#new APIProcedure().Encrypt(Eval("IsFinalBill").ToString())%>">View Voucher</a>
                                        </asp:Panel>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="" Visible="false">
                                    <ItemTemplate>
                                       
                                        <asp:LinkButton ID="lnBtnViewGroup" runat="server" OnClick="lnBtnViewGroup_Click"
                                            Text="Send To Finance"></asp:LinkButton>                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                             <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </div>

     <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
    </div>
    <div id="Messages" style="display: none;" class="popupnew1" runat="server">
        <h2><b>Forward Printing Bill</b> </h2>
        <table width="800px">  
          
            <tr>
                <td> <asp:Label ID="lblFarwardTo" runat="server" Text="अभिमत अधिकारी/Forwarding Officer"></asp:Label></td>
                <td>  <asp:DropDownList ID="ddlForwardTo" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>&#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368;/Remark</td>
                <td colspan="3">
                    <asp:TextBox ID="txtRemark" runat="server" Width="312px" Height="47px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td colspan="4">
                    <asp:Button ID="Button1" runat="server" CssClass="btn" Text="आगे भेजें/Fowrard To" Width="169px" OnClick="btnSave_Click" OnClientClick="return ValidateLeave()" />
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
</asp:Content>

