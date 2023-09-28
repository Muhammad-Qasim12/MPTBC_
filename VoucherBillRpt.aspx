<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VoucherBillRpt.aspx.cs" Inherits="VoucherBillRpt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function isNumberKey(evt, obj) {

             var charCode = (evt.which) ? evt.which : event.keyCode
             var value = obj.value;
             var dotcontains = value.indexOf(".") != -1;
             if (dotcontains)
                 if (charCode == 46) return false;
             if (charCode == 46) return true;
             if (charCode > 31 && (charCode < 48 || charCode > 57))
                 return false;
             return true;
         }
    </script>
    <asp:HiddenField ID="hfApprovedFlag" runat="server" />    
     <asp:HiddenField ID="hfDesignationId" runat="server" />
                     <asp:HiddenField ID="HiddenField8" runat="server" />
                    <asp:HiddenField ID="hfDepartmentId" runat="server" />
                     <asp:HiddenField ID="hfEmployeeId" runat="server" />
     <asp:HiddenField ID="hfLoggedInDepartment" runat="server" />
    

    <asp:Panel ID="pnlBankDetailsBill" runat="server" Visible="false">
        <table width="100%">
            <tr>
                <td style="padding-top: 10px; padding-bottom: 10px;"><span style="font-size: 20px; color: green;">
                    <asp:HiddenField ID="HiddenField13" runat="server" />
                    <asp:HiddenField ID="HiddenField14" runat="server" />
                    <asp:HiddenField ID="HiddenField15" runat="server" />
                     
                </span></td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GrdBankDetailsBill" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="VoucherTrno_I" 
                        AllowPaging="True" OnPageIndexChanging="GrdLeaveApproval_PageIndexChanging" PageSize="50" Visible="false">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                <ItemTemplate>
                                     <asp:Literal ID="ltrSNo" runat="server"></asp:Literal>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText="Voucher No">
                                <ItemTemplate>
                                    <a href="PRI003_CreateVoucher.aspx?Cid=<%#new APIProcedure().Encrypt(Eval("VoucherTrno_I").ToString()) %>&vw=<%#new APIProcedure().Encrypt(Eval("DepartmentName_V").ToString())%>&id=<%#new APIProcedure().Encrypt(Eval("id").ToString())%>&b=rpt">
                                        
                                        <asp:Literal ID="ltrDeyakNo_V" runat="server"  OnDataBinding="ltrLeader_DataBinding"></asp:Literal>
                                    </a>
                                    </ItemTemplate>
                                    </asp:TemplateField>                            
                            <%--<asp:BoundField DataField="ApplicationDate" HeaderText="Voucher Date" DataFormatString="{0:dd/MM/yyyy}" />--%>                                                     
                                              
                            <asp:TemplateField>
                                <ItemTemplate>
                                     <asp:Literal ID="ltrBRDate" runat="server" Text=''></asp:Literal>
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                            <asp:TemplateField  HeaderText="Printer Bill No">
                                <ItemTemplate>
                                    <a href="Printing/PRI003_BillDetails.aspx?ID=<%#new APIProcedure().Encrypt(Eval("BillID_I").ToString()) %>&vw=1" target="_blank">
                                        <asp:Literal ID="ltrPartyBillNo_V" runat="server"></asp:Literal>
                                    </a>
                                    </ItemTemplate>
                                    </asp:TemplateField>
                             <%-- <asp:BoundField  DataField="PartyBillDate_D" HeaderText="Party Bill Date." DataFormatString="{0:dd/MM/yyyy}"  />--%>
                           <%--  <asp:BoundField DataField="PartyName_V" HeaderText="Payment to be Made to" />--%>                            
                             <asp:BoundField DataField="Forwarded To" HeaderText="Forwarded/Revert To" />
                             <asp:BoundField DataField="Remark" HeaderText="Remark" />
                            <%--<asp:BoundField DataField="Status" HeaderText="Status" />  --%>
                             <asp:BoundField DataField="Action Date" HeaderText="Action Date" /> 
                         
                               <asp:TemplateField  HeaderText="&#2325;&#2381;&#2354;&#2367;&#2325; &#2325;&#2352;&#2375;" Visible="false">
                                <ItemTemplate>                                    
                                    <asp:Label ID="lblLeaveId" runat="server" Text='<%#Bind("VoucherTrno_I")%>' Visible="false"></asp:Label>
                                     <asp:Label ID="lblApplicantDeptId" runat="server" Text='<%#Bind("CEDepartmentId")%>' Visible="false"></asp:Label>
                                     <asp:Label ID="lblApplicantId" runat="server" Text='<%#Bind("ApplicatinId")%>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblAssignedEmp" runat="server" Text='<%#Bind("AssignedEmp")%>' Visible="false"></asp:Label>
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("ID") %>' />
                                     
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkViewDetail" OnClick="lnkViewDetail_VoucherBill_Click">View Detail</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table>
                                <tr>
                                    <td style="text-align: center!important;">No Voucher Available</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <asp:HiddenField ID="HiddenField16" runat="server" />

                    <asp:GridView ID="GrdLast" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="VoucherTrno_I" 
                        AllowPaging="True" OnPageIndexChanging="GrdLast_PageIndexChanging" PageSize="50" OnRowDataBound="GridLab_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                <ItemTemplate>
                                   <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText="Voucher No">
                                <ItemTemplate>
                                    <a href="PRI003_CreateVoucher.aspx?Cid=<%#new APIProcedure().Encrypt(Eval("VoucherTrno_I").ToString()) %>&vw=<%#new APIProcedure().Encrypt(Eval("DepartmentName_V").ToString())%>&id=<%#new APIProcedure().Encrypt(Eval("id").ToString())%>&b=rpt">
                                        <%# Eval("DeyakNo_V") %></a>
                                    </ItemTemplate>
                                    </asp:TemplateField> 
                             <asp:BoundField DataField="DepartmentName_V" HeaderText="Department" />                           
                            <asp:BoundField DataField="ApplicationDate" HeaderText="Voucher Date" DataFormatString="{0:dd/MM/yyyy}" /> 
                           
                            <asp:TemplateField  HeaderText="Party Bill No">
                                <ItemTemplate>
                                    <%--<a href="Printing/PRI003_BillDetails.aspx?ID=<%#new APIProcedure().Encrypt(Eval("BillID_I").ToString()) %>&vw=1" target="_blank">                                        
                                         <%# Eval("PartyBillNo_V") %>
                                    </a>--%>
                                    <a id="hreflnk" runat="server" href="#"><%#Eval("PartyBillNo_V")%></a>
                                    </ItemTemplate>
                                    </asp:TemplateField>
                                                      
                             <asp:BoundField DataField="Forwarded To" HeaderText="Designation" />                            
                           <%--<asp:BoundField DataField="Status" HeaderText="Status" /> --%>
                            <%-- <asp:BoundField DataField="Action Date" HeaderText="Action Date" /> --%>

                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblBillPendingApprove" runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                         
                               <asp:TemplateField  HeaderText="&#2325;&#2381;&#2354;&#2367;&#2325; &#2325;&#2352;&#2375;" Visible="false">
                                <ItemTemplate>                                    
                                    <asp:Label ID="lblLeaveId" runat="server" Text='<%#Bind("VoucherTrno_I")%>' Visible="false"></asp:Label>
                                     <asp:Label ID="lblApplicantDeptId" runat="server" Text='<%#Bind("CEDepartmentId")%>' Visible="false"></asp:Label>
                                     <asp:Label ID="lblApplicantId" runat="server" Text='<%#Bind("ApplicatinId")%>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblAssignedEmp" runat="server" Text='<%#Bind("AssignedEmp")%>' Visible="false"></asp:Label>
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("ID") %>' />
                                     <asp:HiddenField ID="hdnIsChequeIssue" runat="server" Value='<%# Eval("IsChequeIssue") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkViewDetail" OnClick="lnkViewDetail_VoucherBill_Click">View Detail</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table>
                                <tr>
                                    <td style="text-align: center!important;">No Voucher Available</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>

   
    <div id="ViewForwardDetail" class="modalBackground" style="display: none;" runat="server">
    </div>
    <div id="ViewForwardDetail1" style="display: none;" class="popupnew1" runat="server">
        <asp:Panel ID="Panel1" runat="server" ScrollBars="Horizontal" Height="400px">
           <span style="float:right"><asp:Button ID="Button5" runat="server" Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375;&#2306; " CssClass="btn" OnClick="Button5_Click" /></span> 
             <br />
            <br />
             <span style="text-align:center"><h3><b><asp:Label ID="lblHeading" runat="server"></asp:Label></b> </h3></span>
            <asp:GridView ID="GrdViewForwardDetail" CssClass="tab" AutoGenerateColumns="false" PageSize="20"
                AllowPaging="false" runat="server" Width="100%" OnRowDataBound="GrdViewForwardDetail_RowDataBound">
                <PagerStyle CssClass="Gvpaging" />
                <EmptyDataRowStyle CssClass="GvEmptyText" />
                <Columns>
                  <asp:BoundField DataField="Department" HeaderText="Department" />
                    <asp:BoundField DataField="Designation" HeaderText="Designation" />

                   <%-- <asp:BoundField DataField="Approved Officer" HeaderText="Approved Officer" />--%> 
                    <asp:TemplateField HeaderText="Approved Officer">
                        <ItemTemplate>                            
                             <asp:Label ID="lblApprovedOfficer" runat="server" Text='<%#Eval("Approved Officer") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                                        
                    <%--<asp:BoundField DataField="Remark" HeaderText="Remark" />--%>
                     <asp:TemplateField HeaderText="Remark">
                        <ItemTemplate>                            
                             <asp:Label ID="lblRemark" runat="server" Text='<%#Eval("Remark") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                   <%-- <asp:BoundField DataField="Action Date" HeaderText="Action Date" /> --%>
                     <asp:TemplateField HeaderText="Action Date">
                        <ItemTemplate>                            
                             <asp:Label ID="lblActionDate" runat="server" Text='<%#Eval("Action Date") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <%--<asp:BoundField DataField="Status" HeaderText="Status" /> --%>
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnIsChequeIssue" runat="server" Value='<%# Eval("IsChequeIssue") %>' />
                             <asp:HiddenField ID="hdnID" runat="server" Value='<%# Eval("ID") %>' />
                            <asp:HiddenField ID="hdnLastID" runat="server" Value='<%# Eval("LastID") %>' />
                             <asp:Label ID="lblBillPendingApprove" runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
            </asp:GridView>
        </asp:Panel>
    </div>

   
</asp:Content>

