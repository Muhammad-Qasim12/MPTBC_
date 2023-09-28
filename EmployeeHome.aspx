<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EmployeeHome.aspx.cs" Inherits="EmployeeHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function ValidateLeave() {
            var list = document.getElementById("<%=RadioButtonList1.ClientID %>"); //Client ID of the radiolist
            var inputs = list.getElementsByTagName("input");
            var selected;
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].checked) {
                    selected = inputs[i];
                    break;
                }
            }
            //if (selected) {
            //    alert(selected.value);
            //}
            var hfflag = document.getElementById("<%=hfApprovedFlag.ClientID %>");
             if (hfflag.value == '0' && selected.value == '1') {
                 var ddlForwardTo = document.getElementById("<%=ddlForwardTo.ClientID %>");
                 if (ddlForwardTo.selectedIndex == 0) {
                     alert('Please select Approved Officer');
                     //ddlAppEmpName.style.backgroundColor = "#ffbdc1";
                     ddlForwardTo.focus();
                     return false;
                 }
             }
             var txtRemark = document.getElementById("<%=txtRemark.ClientID %>");
            if (txtRemark.value == '') {
                alert('Please enter remark');
                txtRemark.focus();
                return false;
            }
            return true;
        }
        function ValidateGrain() {
            var list = document.getElementById("<%=rbGrainStatus.ClientID %>"); //Client ID of the radiolist
             var inputs = list.getElementsByTagName("input");
             var selected;
             for (var i = 0; i < inputs.length; i++) {
                 if (inputs[i].checked) {
                     selected = inputs[i];
                     break;
                 }
             }
             //if (selected) {
             //    alert(selected.value);
             //}

             var hfflag = document.getElementById("<%=hfApprovedFlag.ClientID %>");

             if (hfflag.value == '0' && selected.value == '1') {
                 var ddlGrainApprovedBy = document.getElementById("<%=ddlGrainApprovedBy.ClientID %>");
                 if (ddlGrainApprovedBy.selectedIndex == 0) {
                     alert('Please select Approved Officer');
                     //ddlAppEmpName.style.backgroundColor = "#ffbdc1";
                     ddlGrainApprovedBy.focus();
                     return false;
                 }
             }
             var txtGrainApprovedAmount = document.getElementById("<%=txtGrainApprovedAmount.ClientID %>");
             if (txtGrainApprovedAmount.value == '') {
                 alert('Please enter approved amount');
                 txtGrainApprovedAmount.focus();
                 return false;
             }
             var txtGrainRemarks = document.getElementById("<%=txtGrainRemarks.ClientID %>");
             if (txtGrainRemarks.value == '') {
                 alert('Please enter remark');
                 txtGrainRemarks.focus();
                 return false;
             }
             return true;
         }

         function ValidateTransfer() {
             var list = document.getElementById("<%=RadioButtonList2.ClientID %>"); //Client ID of the radiolist
             var inputs = list.getElementsByTagName("input");
             var selected;
             for (var i = 0; i < inputs.length; i++) {
                 if (inputs[i].checked) {
                     selected = inputs[i];
                     break;
                 }
             }
             var hfflag = document.getElementById("<%=hfApprovedFlag.ClientID %>");
             if (hfflag.value == '0' && selected.value == '1') {
                 var ddlTForwardTo = document.getElementById("<%=ddlTForwardTo.ClientID %>");
                 if (ddlTForwardTo.selectedIndex == 0) {
                     alert('Please select Approved Officer');
                     //ddlAppEmpName.style.backgroundColor = "#ffbdc1";
                     ddlTForwardTo.focus();
                     return false;
                 }
             }
             var txtTRemark = document.getElementById("<%=txtTRemark.ClientID %>");
             if (txtTRemark.value == '') {
                 alert('Please enter remark');
                 txtTRemark.focus();
                 return false;
             }
             return true;
         }

         function ValidateFestival() {
             var list = document.getElementById("<%=rbFestivalStatus.ClientID %>"); //Client ID of the radiolist
             var inputs = list.getElementsByTagName("input");
             var selected;
             for (var i = 0; i < inputs.length; i++) {
                 if (inputs[i].checked) {
                     selected = inputs[i];
                     break;
                 }
             }
             var hfflag = document.getElementById("<%=hfApprovedFlag.ClientID %>");
             if (hfflag.value == '0' && selected.value == '1') {
                 var ddlFestivalApprovedBy = document.getElementById("<%=ddlFestivalApprovedBy.ClientID %>");
                 if (ddlFestivalApprovedBy.selectedIndex == 0) {
                     alert('Please select Approved Officer');
                     //ddlAppEmpName.style.backgroundColor = "#ffbdc1";
                     ddlFestivalApprovedBy.focus();
                     return false;
                 }
             }
             var txtFestivalApprovedAmount = document.getElementById("<%=txtFestivalApprovedAmount.ClientID %>");
             if (txtFestivalApprovedAmount.value == '') {
                 alert('Please select Approved Officer');
                 txtFestivalApprovedAmount.focus();
                 return false;
             }
             var txtFestivalRemark = document.getElementById("<%=txtFestivalRemark.ClientID %>");
             if (txtFestivalRemark.value == '') {
                 alert('Please enter remark');
                 txtFestivalRemark.focus();
                 return false;
             }
             return true;
         }

         function ValidateMedical() {
             var list = document.getElementById("<%=rbMedicalStatus.ClientID %>"); //Client ID of the radiolist
             var inputs = list.getElementsByTagName("input");
             var selected;
             for (var i = 0; i < inputs.length; i++) {
                 if (inputs[i].checked) {
                     selected = inputs[i];
                     break;
                 }
             }
             var hfflag = document.getElementById("<%=hfApprovedFlag.ClientID %>");
             if (hfflag.value == '0' && selected.value == '1') {
                 var ddlMedicalApprovedBy = document.getElementById("<%=ddlMedicalApprovedBy.ClientID %>");
                 if (ddlMedicalApprovedBy.selectedIndex == 0) {
                     alert('Please select Officer');
                     //ddlAppEmpName.style.backgroundColor = "#ffbdc1";
                     ddlMedicalApprovedBy.focus();
                     return false;
                 }
             }
             var txtMedicalApprovedAmount = document.getElementById("<%=txtMedicalApprovedAmount.ClientID %>");
             if (txtMedicalApprovedAmount.value == '') {
                 alert('Please enter approved amount');
                 txtMedicalApprovedAmount.focus();
                 return false;
             }
             var txtMedicalRemark = document.getElementById("<%=txtMedicalRemark.ClientID %>");
             if (txtMedicalRemark.value == '') {
                 alert('Please enter remark');
                 txtMedicalRemark.focus();
                 return false;
             }
             return true;
         }

         function ValidatePf() {
             var list = document.getElementById("<%=rbPFStatus.ClientID %>"); //Client ID of the radiolist
             var inputs = list.getElementsByTagName("input");
             var selected;
             for (var i = 0; i < inputs.length; i++) {
                 if (inputs[i].checked) {
                     selected = inputs[i];
                     break;
                 }
             }
             var hfflag = document.getElementById("<%=hfApprovedFlag.ClientID %>");
             if (hfflag.value == '0' && selected.value == '1') {
                 var ddlPFApprovedBy = document.getElementById("<%=ddlPFApprovedBy.ClientID %>");
                 if (ddlPFApprovedBy.selectedIndex == 0) {
                     alert('Please select Approved Officer');
                     //ddlAppEmpName.style.backgroundColor = "#ffbdc1";
                     ddlPFApprovedBy.focus();
                     return false;
                 }
             }
             var txtPFApprovedAmount = document.getElementById("<%=txtPFApprovedAmount.ClientID %>");
             if (txtPFApprovedAmount.value == '') {
                 alert('Please enter approved amount');
                 txtPFApprovedAmount.focus();
                 return false;
             }
             var txtPFRemaks = document.getElementById("<%=txtPFRemaks.ClientID %>");
             if (txtPFRemaks.value == '') {
                 alert('please enter remarks');
                 txtPFRemaks.focus();
                 return false;
             }
             return true;
         }

         function ValidateTravel() {
             var list = document.getElementById("<%=rbTravelStatus.ClientID %>"); //Client ID of the radiolist
             var inputs = list.getElementsByTagName("input");
             var selected;
             for (var i = 0; i < inputs.length; i++) {
                 if (inputs[i].checked) {
                     selected = inputs[i];
                     break;
                 }
             }
             var hfflag = document.getElementById("<%=hfApprovedFlag.ClientID %>");
             if (hfflag.value == '0' && selected.value == '1') {
                 var ddlTravelApprovedBy = document.getElementById("<%=ddlTravelApprovedBy.ClientID %>");
                 if (ddlTravelApprovedBy.selectedIndex == 0) {
                     alert('Please select Approved Officer');
                     //ddlAppEmpName.style.backgroundColor = "#ffbdc1";
                     ddlTravelApprovedBy.focus();
                     return false;
                 }
             }
             var txtTravelApprovedAmount = document.getElementById("<%=txtTravelApprovedAmount.ClientID %>");
             if (txtTravelApprovedAmount.value == '') {
                 alert('Please enter approved amount');
                 txtTravelApprovedAmount.focus();
                 return false;
             }
             var txtTravelRemark = document.getElementById("<%=txtTravelRemark.ClientID %>");
             if (txtTravelRemark.value == '') {
                 alert('Please enter remark');
                 txtTravelRemark.focus();
                 return false;
             }
             return true;
         }

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
     <asp:HiddenField ID="hfPayRollPayID" runat="server" />
    <asp:Panel ID="pnlLoanStatus" runat="server" Visible="false">
        <table width="100%">
            <tr>
                <td style="padding-top: 10px; padding-bottom: 10px;"><span style="font-size: 20px; color: green;"><b>Running Loans Status</b></span></td>
            </tr>
            <tr>
                <td>
                    <div style="width: 100%; overflow: scroll;">
                        <asp:GridView ID="gvLoans" CssClass="tab" AutoGenerateColumns="false" PageSize="20"
                            AllowPaging="true" OnPageIndexChanging="gvDepartmentMaster_PageIndexChanging" DataKeyNames="ELID" runat="server">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <%--   <asp:TemplateField HeaderText="&#2310;&#2357;&#2375;&#2342;&#2325;">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblApplicant" Text='<%# Eval("EmployeeFullName")%>' Width="150px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                <asp:BoundField DataField="LoanTypeName" ReadOnly="true" HeaderText="&#2315;&#2339; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;" />
                                <asp:BoundField DataField="LoanAmount" ReadOnly="true" HeaderText="&#2315;&#2339; &#2325;&#2368; &#2352;&#2366;&#2358;&#2367;" />
                                <asp:BoundField DataField="EMIAmount" ReadOnly="true" HeaderText="&#2325;&#2367;&#2360;&#2381;&#2340; &#2325;&#2368; &#2352;&#2366;&#2358;&#2367;" />
                                <asp:BoundField DataField="NoOfInstalment" ReadOnly="true" HeaderText="&#2325;&#2367;&#2360;&#2381;&#2340; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;" />

                                <asp:TemplateField HeaderText="&#2360;&#2375;&#2325;&#2381;&#2358;&#2344; &#2321;&#2352;&#2381;&#2337;&#2352; &#2344;&#2306;&#2348;&#2352;">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblSanctionOrder" Text='<%# Eval("SanctionOrderNo")%>' Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="&#2360;&#2375;&#2325;&#2381;&#2358;&#2344; &#2321;&#2352;&#2381;&#2337;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblSanctionOrderDate" Text='<%# Eval("SanctionOrderDate", "{0:dd/MM/yyyy}")%>' Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2354;&#2379;&#2360;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblTodate" Text='<%# Eval("ClosureDate", "{0:dd/MM/yyyy}")%>' Width="100px"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="NoOfInstalmentPaid" ReadOnly="true" HeaderText="No Of Instalment Paid" />
                                <asp:BoundField DataField="CStatus" ReadOnly="true" HeaderText="&#2360;&#2381;&#2341;&#2367;&#2340;&#2367; / Status" />
                                <asp:TemplateField HeaderText="View Complete Detail">
                                    <ItemTemplate>
                                        <%--<a href="ViewInstallment.aspx?loanid=<%# new APIProcedure().Encrypt(Eval("ELID").ToString ()) %>">View Detail </a>--%>
                                        <asp:Button ID="Button6" runat="server" CssClass="btn" Text="&#2325;&#2367;&#2360;&#2381;&#2340; &#2357;&#2367;&#2357;&#2352;&#2339;" OnClick="Button6_Click" CommandArgument='<%#Eval("ELID") %>' Width="120px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>
        <div id="Div2" class="modalBackground" style="display: none;" runat="server">
        </div>
        <div id="Div3" style="display: none;" class="popupnew1" runat="server">
            <asp:Panel ID="Panel2" runat="server" ScrollBars="Horizontal" Height="400px">
                <asp:Button ID="Button7" runat="server" Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375;&#2306; " CssClass="btn" OnClick="Button7_Click" />

                <asp:GridView ID="gvLoansInstallment" CssClass="tab" AutoGenerateColumns="false" PageSize="20"
                    AllowPaging="false"
                    DataKeyNames="LoanDetailID" runat="server" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="LoanAmount" ReadOnly="true" HeaderText="&#2325;&#2367;&#2360;&#2381;&#2340; &#2325;&#2368; &#2352;&#2366;&#2358;&#2367;" />
                        <asp:TemplateField HeaderText="&#2325;&#2367;&#2360;&#2381;&#2340; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="LoanDate" Text='<%# Eval("LoanDate", "{0:dd/MM/yyyy}")%>' Width="100px"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table>
                            <tr>
                                <td style="text-align: center!important;">No Loan Available</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                </asp:GridView>
            </asp:Panel>
        </div>
    </asp:Panel>

      <div id="Div1" class="modalBackground" style="display: none;" runat="server" >
            </div>
            <div id="Div4" style="display: none;" class="popupnew1" runat="server" >
                <h2><b>Complaint Details For Action</b> </h2>
                <table width="800px" >
                    <tr><td>Applicant Name</td><td>
                        <asp:Label ID="lblApplicantName" runat="server" Text=""></asp:Label></td>
                        <td> Reason</td><td><asp:Label ID="lblReason" runat="server" Text=""></asp:Label> </td></tr>
                     <tr><td>Complaint Details </td><td>
                        <asp:Label ID="lblComplaint" runat="server" Text=""></asp:Label>

                                                    </td><td></td><td> </td></tr>
                     <tr><td>Status</td><td>

                        <asp:RadioButtonList ID="RadioButtonList3" runat="server" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Forward</asp:ListItem>
                            <asp:ListItem Value="2">Close</asp:ListItem>
                        </asp:RadioButtonList>
                         </td><td>Forward To</td><td>
                            <asp:DropDownList ID="ddlComplaintForWord" runat="server"></asp:DropDownList></td></tr>

                     <tr><td>Remark</td><td colspan="3">

                        <asp:TextBox ID="TextBox1" runat="server" Width="312px" Height="47px"></asp:TextBox> </td></tr>

                     <tr><td colspan="4">
                         <asp:Button ID="btn_Complaint01" runat="server" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306;" Width="100px" OnClick="btn_Complaint01_Click" />
&nbsp;<asp:Button ID="btn_Complaint02" runat="server" CssClass="btn" OnClick="btn_Complaint02_Click" Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375;&#2306; " Width="83px" />
                         </td></tr>

                </table>

                </div> 
    <asp:Panel ID="pnComplaintStatus" runat="server" Visible="false">
        <table width="100%">
            <tr>
                <td style="padding-top: 10px; padding-bottom: 10px;"><span style="font-size: 20px; color: green;"><b>Complaint </b></span></td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="grdComplaintStatus" runat="server" AutoGenerateColumns="False" CssClass="tab"
                         DataKeyNames="ID" AllowPaging="false" >
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                <asp:BoundField HeaderText="&#2325;&#2366;&#2352;&#2339; / Reason" DataField="Resoan" />
                                <asp:BoundField HeaderText="&#2358;&#2367;&#2325;&#2366;&#2351;&#2340; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339; / Complaint Details&nbsp;" DataField="ComplaintDetails&nbsp;" />
                           
                              <asp:BoundField HeaderText="Status" DataField="Status" />
                             <asp:BoundField HeaderText="Remark" DataField="Remark" />
                            <asp:BoundField HeaderText="Remark Date" DataField="Remarkdate" />
                             <%--<asp:CommandField SelectText="Update" ShowSelectButton="True" />--%>
                        </Columns>
                       
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>
<asp:Panel ID="pnaComplatin" runat="server" Visible="false">
        <table width="100%">
            <tr>
                <td style="padding-top: 10px; padding-bottom: 10px;"><span style="font-size: 20px; color: green;"><b>Complaint </b></span></td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GrdComplaint" runat="server" AutoGenerateColumns="False" CssClass="tab"
                         DataKeyNames="ID" AllowPaging="True" OnPageIndexChanging="GrdLeaveStatus_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                <asp:BoundField HeaderText="&#2325;&#2366;&#2352;&#2339; / Reason" DataField="Resoan" />
                                <asp:BoundField HeaderText="&#2358;&#2367;&#2325;&#2366;&#2351;&#2340; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339; / Complaint Details&nbsp;" DataField="ComplaintDetails&nbsp;" />
                           
                             <asp:TemplateField HeaderText="Remark/Close">
                                    <ItemTemplate>
                                         <asp:Label ID="lblLeaveId" runat="server" Text='<%#Bind("CompID")%>' Visible="false"></asp:Label>
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("ID") %>' />
                                        <%--<a href="ViewInstallment.aspx?loanid=<%# new APIProcedure().Encrypt(Eval("ELID").ToString ()) %>">View Detail </a>--%>
                                        <asp:Button ID="btnComp" runat="server" CssClass="btn" Text="&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; " OnClick="btnComp_Click" CommandArgument='<%#Eval("CompID") %>' Width="120px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                             <%--<asp:CommandField SelectText="Update" ShowSelectButton="True" />--%>
                        </Columns>
                       
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>


    <asp:Panel ID="pnlLeaveStatus" runat="server" Visible="false">
        <table width="100%">
            <tr>
                <td style="padding-top: 10px; padding-bottom: 10px;"><span style="font-size: 20px; color: green;"><b>Leaves Status</b></span>
                    <asp:HiddenField ID="hfDesignationId" runat="server" />
                     <asp:HiddenField ID="HiddenField8" runat="server" />
                    <asp:HiddenField ID="hfDepartmentId" runat="server" />
                     <asp:HiddenField ID="hfEmployeeId" runat="server" />
                     <asp:HiddenField ID="hfLoggedInDepartment" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GrdLeaveStatus" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="LeaveRequestID" AllowPaging="True" OnPageIndexChanging="GrdLeaveStatus_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ApplicationDate" HeaderText="&#2310;&#2357;&#2375;&#2342;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="FromDate" HeaderText="&#2325;&#2348; &#2360;&#2375;" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="ToDate" HeaderText="&#2325;&#2348; &#2340;&#2325;" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="NoofDays" HeaderText="&#2325;&#2369;&#2354; &#2342;&#2367;&#2357;&#2360;" />
                            <asp:BoundField DataField="LeaveTypeName" HeaderText="&#2310;&#2357;&#2375;&#2342;&#2344; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;" />
                            <asp:BoundField HeaderText="&#2309;&#2357;&#2325;&#2366;&#2358; &#2325;&#2366; &#2325;&#2366;&#2352;&#2339;" DataField="LeaveReason" />
                            <asp:BoundField DataField="EmployeeName" HeaderText="&#2309;&#2344;&#2369;&#2350;&#2379;&#2342;&#2344;/&#2309;&#2349;&#2367;&#2350;&#2340; &#2309;&#2343;&#2367;&#2325;&#2366;&#2352;&#2368;" />
                            <asp:BoundField DataField="STATUS" HeaderText="&#2360;&#2381;&#2341;&#2367;&#2340;&#2367;" />
                        </Columns>
                        <EmptyDataTemplate>
                            <table>
                                <tr>
                                    <td style="text-align: center!important;">No Leave Available</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlLeaveApproval" runat="server" Visible="false">
        <table width="100%">
            <tr>
                <td style="padding-top: 10px; padding-bottom: 10px;"><span style="font-size: 20px; color: green;"><b>Pending Leaves for Approval</b>
                    <asp:HiddenField ID="HiddenField2" runat="server" />
                    <asp:HiddenField ID="HiddenField3" runat="server" />
                    <asp:HiddenField ID="HiddenField4" runat="server" />
                </span></td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GrdLeaveApproval" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="LeaveRequestID" AllowPaging="True" OnPageIndexChanging="GrdLeaveApproval_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ApplicationDate" HeaderText="&#2310;&#2357;&#2375;&#2342;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="Applicant" HeaderText="&#2310;&#2357;&#2375;&#2342;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;" />
                            <asp:BoundField DataField="FromDate" HeaderText="&#2325;&#2348; &#2360;&#2375;" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="ToDate" HeaderText="&#2325;&#2348; &#2340;&#2325;" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="NoofDays" HeaderText="&#2325;&#2369;&#2354; &#2342;&#2367;&#2357;&#2360;" />
                            <asp:BoundField DataField="LeaveTypeName" HeaderText="&#2310;&#2357;&#2375;&#2342;&#2344; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;" />
                            <asp:BoundField HeaderText="&#2309;&#2357;&#2325;&#2366;&#2358; &#2325;&#2366; &#2325;&#2366;&#2352;&#2339;" DataField="LeaveReason" />
                         <%--   <asp:BoundField HeaderText="&#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368;" DataField="Remark" />--%>
                            <asp:BoundField DataField="STATUS" HeaderText="&#2360;&#2381;&#2341;&#2367;&#2340;&#2367;" />
                            <%--<asp:CommandField SelectText="Approve" ShowSelectButton="True" />--%>
                            <asp:TemplateField HeaderText="&#2342;&#2360;&#2381;&#2340;&#2366;&#2357;&#2375;&#2332;&#2364; &#2337;&#2366;&#2313;&#2344;&#2354;&#2379;&#2337;">
                                <ItemTemplate>
                                    <a href='<%#Eval("UploadImg")%>' target="_blank"><%#Eval("aa")%></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField  HeaderText="&#2325;&#2381;&#2354;&#2367;&#2325; &#2325;&#2352;&#2375;">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkApprove" OnClick="lnkApprove_Click">&#2309;&#2349;&#2367;&#2350;&#2340;</asp:LinkButton>
                                    <asp:Label ID="lblLeaveId" runat="server" Text='<%#Bind("LeaveRequestID")%>' Visible="false"></asp:Label>
                                     <asp:Label ID="lblApplicantDeptId" runat="server" Text='<%#Bind("CEDepartmentId")%>' Visible="false"></asp:Label>
                                     <asp:Label ID="lblApplicantId" runat="server" Text='<%#Bind("ApplicatinId")%>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblAssignedEmp" runat="server" Text='<%#Bind("AssignedEmp")%>' Visible="false"></asp:Label>
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("ID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkViewDetail" OnClick="lnkViewDetail_Click">View Detail</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table>
                                <tr>
                                    <td style="text-align: center!important;">No Leave Available</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <asp:HiddenField ID="hfLeaveId" runat="server" />
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlGrainAdvance" runat="server" Visible="false">
        <table width="100%">
            <tr>
                <td style="padding-top: 10px; padding-bottom: 10px;"><span style="font-size: 20px; color: green;"><b>Grain Advance Status</b></span></td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GrdGrainAdvance" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="GrainID" AllowPaging="True" OnPageIndexChanging="GrdGrainAdvance_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="EffectedDate" HeaderText="&#2310;&#2357;&#2375;&#2342;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" DataFormatString="{0:dd/MM/yyyy}" />
                            <%-- <asp:BoundField DataField="DateOfPreviouslyGrainAdvance" HeaderText="Date Of Previously Grain Advance" DataFormatString="{0:dd/MM/yyyy}" />--%>
                            <asp:BoundField DataField="AdvanceAmountRequered" HeaderText="&#2309;&#2327;&#2381;&#2352;&#2367;&#2350; &#2352;&#2366;&#2358;&#2367; &#2325;&#2366; &#2309;&#2344;&#2369;&#2352;&#2379;&#2343;" />
                            <asp:BoundField DataField="BalanceGrainAdvance" HeaderText="&#2309;&#2327;&#2381;&#2352;&#2367;&#2350; &#2358;&#2375;&#2359; &#2309;&#2344;&#2366;&#2332; &#2352;&#2366;&#2358;&#2367;" />
                            <asp:BoundField DataField="ForwardedName" HeaderText="&#2309;&#2344;&#2369;&#2350;&#2379;&#2342;&#2344;/&#2309;&#2349;&#2367;&#2350;&#2340; &#2309;&#2343;&#2367;&#2325;&#2366;&#2352;&#2368;" />
                            <asp:BoundField DataField="aAppStatus" HeaderText="&#2360;&#2381;&#2341;&#2367;&#2340;&#2367;" />
                            <%--<asp:CommandField SelectText="Update" ShowSelectButton="True" />--%>
                        </Columns>
                        <EmptyDataTemplate>
                            <table>
                                <tr>
                                    <td style="text-align: center!important;">No Grain Advance Available</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlGrainAdvApproval" runat="server" Visible="false">
        <table width="100%">
            <tr>
                <td style="padding-top: 10px; padding-bottom: 10px;"><span style="font-size: 20px; color: green;"><b>Grain Advance Approval</b></span>
                    <asp:HiddenField ID="hfGrainDetailId" runat="server" />
                    <asp:HiddenField ID="hfGrainAppId" runat="server" />
                    <asp:HiddenField ID="hfGrainApporvedId" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GrdGrainAdvApproval" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="GrainID" AllowPaging="True" OnPageIndexChanging="GrdGrainAdvApproval_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="EffectedDate" HeaderText="&#2310;&#2357;&#2375;&#2342;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="EmployeeFullName" HeaderText="&#2310;&#2357;&#2375;&#2342;&#2306;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;" />
                            <asp:BoundField DataField="Designation" HeaderText="&#2346;&#2342;" />
                            <asp:BoundField DataField="PostedAT" HeaderText="&#2346;&#2342;&#2360;&#2381;&#2341;" />
                            <%-- <asp:BoundField DataField="DateOfPreviouslyGrainAdvance" HeaderText="Date Of Previously Grain Advance" DataFormatString="{0:dd/MM/yyyy}" />--%>
                            <asp:BoundField DataField="AdvanceAmountRequered" HeaderText="&#2309;&#2327;&#2381;&#2352;&#2367;&#2350; &#2352;&#2366;&#2358;&#2367; &#2325;&#2366; &#2309;&#2344;&#2369;&#2352;&#2379;&#2343;" />
                            <asp:BoundField DataField="BalanceGrainAdvance" HeaderText="&#2309;&#2327;&#2381;&#2352;&#2367;&#2350; &#2358;&#2375;&#2359; &#2309;&#2344;&#2366;&#2332; &#2352;&#2366;&#2358;&#2367;" />
                            <asp:BoundField DataField="ApprovedAmount" HeaderText="&#2309;&#2344;&#2369;&#2350;&#2379;&#2342;&#2367;&#2340; &#2352;&#2366;&#2358;&#2367;" />
                            <asp:BoundField DataField="Remark" HeaderText="&#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368;" />
                            <asp:BoundField DataField="aAppStatus" HeaderText="&#2360;&#2381;&#2341;&#2367;&#2340;&#2367;" />
                            <%--<asp:CommandField SelectText="Update" ShowSelectButton="True" />--%>
                            <asp:TemplateField HeaderText="&#2342;&#2360;&#2381;&#2340;&#2366;&#2357;&#2375;&#2332;&#2364; &#2337;&#2366;&#2313;&#2344;&#2354;&#2379;&#2337;">
                                <ItemTemplate>
                                    <a href='<%#Eval("UploadImg")%>' target="_blank"><%#Eval("aa")%></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText="&#2325;&#2381;&#2354;&#2367;&#2325; &#2325;&#2352;&#2375;">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkGrainAdvApprove" OnClick="lnkGrainAdvApprove_Click">&#2309;&#2349;&#2367;&#2350;&#2340;</asp:LinkButton>
                                    <asp:Label ID="lblGrainID" runat="server" Text='<%#Bind("GrainID")%>' Visible="false"></asp:Label>
                                    <asp:HiddenField ID="hfGGrainDetailId" runat="server" Value='<%# Eval("ID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkViewGrainDetail" OnClick="lnklnkViewGrainDetail_Click">View Detail</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkGrainAdvCancel" OnClick="lnkGrainAdvCancel_Click">Cancle</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                        <EmptyDataTemplate>
                            <table>
                                <tr>
                                    <td style="text-align: center!important;">No Grain Advance Available</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlMedicalAdvApp" runat="server" Visible="false">
        <table width="100%">
            <tr>
                <td style="padding-top: 10px; padding-bottom: 10px;"><span style="font-size: 20px; color: green;"><b>Medical Advance Status</b></span></td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GrdMedicalAdvApp" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="MedicalID" AllowPaging="True" OnPageIndexChanging="GrdMedicalAdvApp_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ApplicationDate" HeaderText="&#2310;&#2357;&#2375;&#2342;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" DataFormatString="{0:dd/MM/yyyy}" />
                            <%--<asp:BoundField DataField="LoanTypeName" HeaderText="Loan Name" />--%>
                            <asp:BoundField DataField="AdvanceAmountRequested" HeaderText="&#2309;&#2327;&#2381;&#2352;&#2367;&#2350; &#2352;&#2366;&#2358;&#2367; &#2325;&#2366; &#2309;&#2344;&#2369;&#2352;&#2379;&#2343;" />
                            <asp:BoundField DataField="TypeofIllness" HeaderText="&#2348;&#2368;&#2350;&#2366;&#2352;&#2368; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;" />
                            <asp:BoundField DataField="ForwardedName" HeaderText="&#2309;&#2344;&#2369;&#2350;&#2379;&#2342;&#2344;/&#2309;&#2349;&#2367;&#2350;&#2340; &#2309;&#2343;&#2367;&#2325;&#2366;&#2352;&#2368;" />
                            <asp:BoundField DataField="Status" HeaderText="&#2360;&#2381;&#2341;&#2367;&#2340;&#2367;" />
                            <%--<asp:CommandField SelectText="Update" ShowSelectButton="True" />--%>
                        </Columns>
                        <EmptyDataTemplate>
                            <table>
                                <tr>
                                    <td style="text-align: center!important;">No Medical Advance Application Available</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlMedicalAdvApproval" runat="server" Visible="false">
        <table width="100%">
            <tr>
                <td style="padding-top: 10px; padding-bottom: 10px;"><span style="font-size: 20px; color: green;"><b>Medical Advance Approval</b></span>
                    <asp:HiddenField ID="hfMedicalDetailId" runat="server" />
                    <asp:HiddenField ID="hfMedicalAppId" runat="server" />
                    <asp:HiddenField ID="hfMedicalApprovedId" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GrdMedicalAdvApproval" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="MedicalID" AllowPaging="True" OnPageIndexChanging="GrdMedicalAdvApproval_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ApplicationDate" HeaderText="&#2310;&#2357;&#2375;&#2342;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="EmployeeFullName" HeaderText="&#2310;&#2357;&#2375;&#2342;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;" />
                            <asp:BoundField DataField="Designation" HeaderText="&#2346;&#2342;" />
                            <asp:BoundField DataField="PostedAT" HeaderText="&#2346;&#2342;&#2360;&#2381;&#2341;" />
                            <asp:BoundField DataField="AdvanceAmountRequested" HeaderText="&#2309;&#2327;&#2381;&#2352;&#2367;&#2350; &#2352;&#2366;&#2358;&#2367; &#2325;&#2366; &#2309;&#2344;&#2369;&#2352;&#2379;&#2343;" />
                            <asp:BoundField DataField="ApprovedAmount" HeaderText="&#2309;&#2344;&#2369;&#2350;&#2379;&#2342;&#2367;&#2340; &#2352;&#2366;&#2358;&#2367;" />
                            <asp:BoundField DataField="TypeofIllness" HeaderText="&#2348;&#2368;&#2350;&#2366;&#2352;&#2368; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;" />
                            <asp:BoundField DataField="Remark" HeaderText="&#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368;" />
                            <asp:BoundField DataField="Status" HeaderText="&#2360;&#2381;&#2341;&#2367;&#2340;&#2367;" />
                            <asp:TemplateField HeaderText="&#2342;&#2360;&#2381;&#2340;&#2366;&#2357;&#2375;&#2332;&#2364; &#2337;&#2366;&#2313;&#2344;&#2354;&#2379;&#2337;">
                                <ItemTemplate>
                                    <a href='<%#Eval("UploadImg")%>' target="_blank"><%#Eval("aa")%></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:CommandField SelectText="Update" ShowSelectButton="True" />--%>
                               <asp:TemplateField  HeaderText="&#2325;&#2381;&#2354;&#2367;&#2325; &#2325;&#2352;&#2375;">
                                <ItemTemplate>
                                    <%-- <a href="HR/MedicalAdvanceRecommendation.aspx?medicalid=<%# new APIProcedure().Encrypt(Eval("MedicalID").ToString ()) %>">Approve</a>--%>
                                    <asp:LinkButton runat="server" ID="lnkMedicalAdvApprove" OnClick="lnkMedicalAdvApprove_Click">&#2309;&#2349;&#2367;&#2350;&#2340;</asp:LinkButton>
                                    <asp:Label ID="lblMedicalID" runat="server" Text='<%#Bind("MedicalID")%>' Visible="false"></asp:Label>
                                    <asp:HiddenField ID="hfGMedicalDetailId" runat="server" Value='<%# Eval("ID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkViewMedicalDetail" OnClick="lnkViewMedicalDetail_Click">View Detail</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--   <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkMedicalAdvCancel" OnClick="lnkMedicalAdvCancel_Click">Cancle</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                        <EmptyDataTemplate>
                            <table>
                                <tr>
                                    <td style="text-align: center!important;">No Medical Advance Available</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlTravelingStatus" runat="server" Visible="false">
        <table width="100%">
            <tr>
                <td style="padding-top: 10px; padding-bottom: 10px;"><span style="font-size: 20px; color: green;"><b>Traveling Status</b></span></td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GrdTravelingStatus" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="AppID" AllowPaging="True" OnPageIndexChanging="GrdTravelingStatus_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ApplicationDate" HeaderText="&#2310;&#2357;&#2375;&#2342;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="DailyAllowanceRate" HeaderText="&#2342;&#2375;&#2344;&#2367;&#2325; &#2349;&#2340;&#2381;&#2340;&#2366; &#2342;&#2352;" />
                            <asp:BoundField DataField="Fromdate" HeaderText="&#2346;&#2381;&#2352;&#2366;&#2352;&#2350;&#2381;&#2349; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="Todate" HeaderText="&#2309;&#2306;&#2340;&#2367;&#2350; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="PeriodOfTravel" HeaderText="&#2351;&#2366;&#2340;&#2381;&#2352;&#2366; &#2325;&#2368; &#2309;&#2357;&#2343;&#2367;(&#2342;&#2367;&#2344; &#2350;&#2375;&#2306;)" />
                            <asp:BoundField DataField="PlaceForTravel" HeaderText="&#2351;&#2366;&#2340;&#2381;&#2352;&#2366; &#2325;&#2366; &#2360;&#2381;&#2341;&#2366;&#2344;" />
                            <asp:BoundField DataField="TotalCharges" HeaderText="&#2325;&#2369;&#2354; &#2352;&#2366;&#2358;&#2367;" />
                            <asp:BoundField DataField="EmployeeFullName" HeaderText="&#2309;&#2344;&#2369;&#2350;&#2379;&#2342;&#2344;/&#2309;&#2349;&#2367;&#2350;&#2340; &#2309;&#2343;&#2367;&#2325;&#2366;&#2352;&#2368;" />
                            <asp:BoundField DataField="aAppStatus" HeaderText="&#2360;&#2381;&#2341;&#2367;&#2340;&#2367;" />
                            <%--<asp:CommandField SelectText="Update" ShowSelectButton="True" />--%>
                        </Columns>
                        <EmptyDataTemplate>
                            <table>
                                <tr>
                                    <td style="text-align: center!important;">No Record Available</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlTravelingApproval" runat="server" Visible="false">
        <table width="100%">
            <tr>
                <td style="padding-top: 10px; padding-bottom: 10px;"><span style="font-size: 20px; color: green;"><b>Traveling Approval</b></span>
                    <asp:HiddenField ID="hfTravelDetailId" runat="server" />
                    <asp:HiddenField ID="hfTravelAppId" runat="server" />
                    <asp:HiddenField ID="hfTravelApprovedId" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GrdTravelingApproval" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="AppID" AllowPaging="True" OnPageIndexChanging="GrdTravelingApproval_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ApplicationDate" HeaderText="&#2310;&#2357;&#2375;&#2342;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="Applicant" HeaderText="&#2310;&#2357;&#2375;&#2342;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;" />
                           <%-- <asp:BoundField DataField="ClassName" HeaderText="&#2358;&#2381;&#2352;&#2375;&#2339;&#2368;" />
                            <asp:BoundField DataField="DailyAllowanceRate" HeaderText="&#2342;&#2375;&#2344;&#2367;&#2325; &#2349;&#2340;&#2381;&#2340;&#2366; &#2342;&#2352;" />--%>
                            <asp:BoundField DataField="Fromdate" HeaderText="&#2346;&#2381;&#2352;&#2366;&#2352;&#2306;&#2349; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="Todate" HeaderText="&#2309;&#2306;&#2340;&#2367;&#2350; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" DataFormatString="{0:dd/MM/yyyy}" />
                            <%--<asp:BoundField DataField="PeriodOfTravel" HeaderText="&#2351;&#2366;&#2340;&#2381;&#2352;&#2366; &#2325;&#2368; &#2309;&#2357;&#2343;&#2367;(&#2342;&#2367;&#2344; &#2350;&#2375;&#2306;)" />--%>
                            <asp:BoundField DataField="PlaceForTravel" HeaderText="&#2351;&#2366;&#2340;&#2381;&#2352;&#2366; &#2325;&#2366; &#2360;&#2381;&#2341;&#2366;&#2344;" />
                            <asp:BoundField DataField="TotalCharges" HeaderText="&#2325;&#2369;&#2354; &#2352;&#2366;&#2358;&#2367;" />
                            <asp:BoundField DataField="Remark" HeaderText="&#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368;" />
                            <asp:BoundField DataField="ApprovedAmount" HeaderText="&#2309;&#2344;&#2369;&#2350;&#2379;&#2342;&#2367;&#2340; &#2352;&#2366;&#2358;&#2367;" />
                            <asp:BoundField DataField="aAppStatus" HeaderText="&#2360;&#2381;&#2341;&#2367;&#2340;&#2367;" />
                            <%--<asp:BoundField DataField="EmployeeFullName" HeaderText="Forward To" />--%>
                            <%--<asp:CommandField SelectText="Update" ShowSelectButton="True" />--%>
                               <asp:TemplateField  HeaderText="&#2325;&#2381;&#2354;&#2367;&#2325; &#2325;&#2352;&#2375;">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkTravelingApprove" OnClick="lnkTravelingApprove_Click">&#2309;&#2349;&#2367;&#2350;&#2340;</asp:LinkButton>
                                    <asp:Label ID="lblAppID" runat="server" Text='<%#Bind("AppID")%>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblClassName" runat="server" Text='<%#Bind("ClassName")%>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblDailyAllowanceRate" runat="server" Text='<%#Bind("DailyAllowanceRate")%>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblPeriodOfTravel" runat="server" Text='<%#Bind("PeriodOfTravel")%>' Visible="false"></asp:Label>
                                    <asp:HiddenField ID="hfGTravelDetailId" runat="server" Value='<%# Eval("ID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                               <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkViewTravellingDetail" OnClick="lnkViewTravellingDetail_Click">View Detail</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <%--   <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkTravelingCancel" OnClick="lnkTravelingCancel_Click">Cancle</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                        <EmptyDataTemplate>
                            <table>
                                <tr>
                                    <td style="text-align: center!important;">No Record Available</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlFestivalAdvanceStatus" runat="server" Visible="false">
        <table width="100%">
            <tr>
                <td style="padding-top: 10px; padding-bottom: 10px;"><span style="font-size: 20px; color: green;"><b>Festival Advance Status</b></span></td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GrdFestivalAdvanceStatus" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="ApplicationId" AllowPaging="True" OnPageIndexChanging="GrdFestivalAdvanceStatus_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ApplicationDate" HeaderText="&#2310;&#2357;&#2375;&#2342;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" />
                            <asp:BoundField DataField="AdvanceAmountRequested" HeaderText="&#2309;&#2327;&#2381;&#2352;&#2367;&#2350; &#2352;&#2366;&#2358;&#2367; &#2325;&#2366; &#2309;&#2344;&#2369;&#2352;&#2379;&#2343;" />
                            <asp:BoundField DataField="FestivalName" HeaderText="&#2340;&#2381;&#2351;&#2380;&#2361;&#2366;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;" />
                            <asp:BoundField DataField="FestivalDate" HeaderText="&#2340;&#2381;&#2351;&#2380;&#2361;&#2366;&#2352; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" />
                            <%-- <asp:BoundField DataField="PreviouslyTakenDate" HeaderText="Date of Previously Taken Festival Advance" />--%>
                            <asp:BoundField DataField="BalanceFestivalAdvance" HeaderText="&#2358;&#2375;&#2359; &#2340;&#2381;&#2351;&#2380;&#2361;&#2366;&#2352; &#2309;&#2327;&#2381;&#2352;&#2367;&#2350; " />
                            <asp:BoundField DataField="RecommendationName" HeaderText="&#2309;&#2344;&#2369;&#2350;&#2379;&#2342;&#2344;/&#2309;&#2349;&#2367;&#2350;&#2340; &#2309;&#2343;&#2367;&#2325;&#2366;&#2352;&#2368;" />
                            <asp:BoundField DataField="ApplicationStatus" HeaderText="&#2360;&#2381;&#2341;&#2367;&#2340;&#2367;" />
                            <%--<asp:CommandField SelectText="Update" ShowSelectButton="True" />--%>
                        </Columns>
                        <EmptyDataTemplate>
                            <table>
                                <tr>
                                    <td style="text-align: center!important;">No Festival Advance Available</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlFestivalApproval" runat="server" Visible="false">
        <table width="100%">
            <tr>
                <td style="padding-top: 10px; padding-bottom: 10px;">
                    <span style="font-size: 20px; color: green;"><b>Festival Advance Approval</b></span>
                    <asp:HiddenField ID="hfFestivalDetailId" runat="server" />
                    <asp:HiddenField ID="hfFestivalAppId" runat="server" />
                    <asp:HiddenField ID="hfFestivalApprovedId" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GrdFestivalAdvanceApproval" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="ApplicationId" AllowPaging="True" OnPageIndexChanging="GrdFestivalAdvanceApproval_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ApplicationDate" HeaderText="&#2310;&#2357;&#2375;&#2342;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" />
                            <asp:BoundField DataField="EmployeeFullName" HeaderText="&#2310;&#2357;&#2375;&#2342;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;" />
                            <asp:BoundField DataField="DesignationName" HeaderText="&#2346;&#2342;&#2344;&#2366;&#2350;" />
                            <asp:BoundField DataField="LocationName" HeaderText="&#2346;&#2342;&#2360;&#2381;&#2341;" />
                            <%-- <asp:BoundField DataField="AppointmentDate" HeaderText="&#2344;&#2367;&#2351;&#2369;&#2325;&#2381;&#2340;&#2367; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;"/>--%>
                            <%--  <asp:BoundField DataField="BasicSalary" HeaderText="&#2346;&#2375; &#2348;&#2375;&#2306;&#2337;" />--%>
                            <asp:BoundField DataField="AdvanceAmountRequested" HeaderText="&#2309;&#2327;&#2381;&#2352;&#2367;&#2350; &#2352;&#2366;&#2358;&#2367; &#2325;&#2366; &#2309;&#2344;&#2369;&#2352;&#2379;&#2343;" />
                            <asp:BoundField DataField="FestivalName" HeaderText="&#2340;&#2381;&#2351;&#2380;&#2361;&#2366;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;" />
                            <asp:BoundField DataField="FestivalDate" HeaderText="&#2340;&#2381;&#2351;&#2380;&#2361;&#2366;&#2352; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" />
                            <%--  <asp:BoundField DataField="PreviouslyTakenDate" HeaderText="Date of Previously Taken Festival Advance"/>--%>
                            <asp:BoundField DataField="BalanceFestivalAdvance" HeaderText="&#2358;&#2375;&#2359; &#2340;&#2381;&#2351;&#2380;&#2361;&#2366;&#2352; &#2309;&#2327;&#2381;&#2352;&#2367;&#2350; " />
                            <asp:BoundField DataField="ApprovedAmount" HeaderText="&#2309;&#2344;&#2369;&#2350;&#2379;&#2342;&#2367;&#2340; &#2352;&#2366;&#2358;&#2367;" />
                            <asp:BoundField DataField="Remark" HeaderText="&#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368;" />
                            <asp:BoundField DataField="ApplicationStatus" HeaderText="&#2360;&#2381;&#2341;&#2367;&#2340;&#2367;" />
                            <asp:TemplateField HeaderText="&#2342;&#2360;&#2381;&#2340;&#2366;&#2357;&#2375;&#2332;&#2364; &#2337;&#2366;&#2313;&#2344;&#2354;&#2379;&#2337;">
                                <ItemTemplate>
                                    <a href='<%#Eval("UploadImg")%>' target="_blank"><%#Eval("aa")%></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:CommandField SelectText="Update" ShowSelectButton="True" />--%>
                             <asp:TemplateField  HeaderText="&#2325;&#2381;&#2354;&#2367;&#2325; &#2325;&#2352;&#2375;">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkFestivalAdvApprove" OnClick="lnkFestivalAdvApprove_Click">&#2309;&#2349;&#2367;&#2350;&#2340;</asp:LinkButton>
                                    <asp:Label ID="lblFestivalID" runat="server" Text='<%#Bind("ApplicationId")%>' Visible="false"></asp:Label>
                                    <asp:HiddenField ID="hfGFestivalDetailId" runat="server" Value='<%# Eval("ID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkViewFestivalDetail" OnClick="lnkViewFestivalDetail_Click">View Detail</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkFestivalAdvCancel" OnClick="lnkFestivalAdvCancel_Click">Cancle</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                        <EmptyDataTemplate>
                            <table>
                                <tr>
                                    <td style="text-align: center!important;">No Festival Advance Available</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlTransferApplicationStatus" runat="server" Visible="false">
        <table width="100%">
            <tr>
                <td style="padding-top: 10px; padding-bottom: 10px;">
                    <span style="font-size: 20px; color: green;"><b>Transfer Application Status</b></span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="grdTransferApplicationStatus" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="ApplicationId" AllowPaging="True" OnPageIndexChanging="grdTransferApplicationStatus_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ApplicationDate" HeaderText="&#2310;&#2357;&#2375;&#2342;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" />
                            <asp:BoundField DataField="CurrentLocationName" HeaderText="&#2357;&#2352;&#2381;&#2340;&#2350;&#2366;&#2344; &#2360;&#2381;&#2341;&#2366;&#2344; " />
                            <asp:BoundField DataField="NewLocationName" HeaderText="&#2344;&#2357;&#2368;&#2344; &#2360;&#2381;&#2341;&#2366;&#2344;" />
                            <asp:BoundField DataField="Remarks" HeaderText="&#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368;" />
                            <asp:BoundField DataField="RecommondedName" HeaderText="&#2309;&#2344;&#2369;&#2350;&#2379;&#2342;&#2344;/&#2309;&#2349;&#2367;&#2350;&#2340; &#2309;&#2343;&#2367;&#2325;&#2366;&#2352;&#2368;" />
                            <asp:BoundField DataField="aStatus" HeaderText="&#2360;&#2381;&#2341;&#2367;&#2340;&#2367;" />
                            <%--<asp:CommandField SelectText="Update" ShowSelectButton="True" />--%>
                        </Columns>
                        <EmptyDataTemplate>
                            <table>
                                <tr>
                                    <td style="text-align: center!important;">No Transfer Application Available</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlTransferApplicationApproval" runat="server" Visible="false">
        <table width="100%">
            <tr>
                <td style="padding-top: 10px; padding-bottom: 10px;"><span style="font-size: 20px; color: green;"><b>Transfer Application Approval</b></span>
                    <asp:HiddenField ID="HiddenField5" runat="server" />
                    <asp:HiddenField ID="HiddenField6" runat="server" />
                    <asp:HiddenField ID="HiddenField7" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="grdTransferApplicationApproval" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="ApplicationId" AllowPaging="True" OnPageIndexChanging="grdTransferApplicationApproval_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ApplicationDate" HeaderText="&#2310;&#2357;&#2375;&#2342;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" />
                            <asp:BoundField DataField="EmployeeFullName" HeaderText="&#2310;&#2357;&#2375;&#2342;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;" />
                            <asp:BoundField DataField="DesignationName" HeaderText="&#2346;&#2342;" />
                            <asp:BoundField DataField="CurrentLocationName" HeaderText="&#2357;&#2352;&#2381;&#2340;&#2350;&#2366;&#2344; &#2360;&#2381;&#2341;&#2366;&#2344;" />
                            <asp:BoundField DataField="NewLocationName" HeaderText="&#2344;&#2357;&#2368;&#2344; &#2360;&#2381;&#2341;&#2366;&#2344;" />
                            <asp:BoundField DataField="Remarks" HeaderText="&#2310;&#2357;&#2375;&#2342;&#2325; &#2357;&#2367;&#2357;&#2352;&#2339;" />
                            <asp:BoundField DataField="Remark" HeaderText="&#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368;" />
                            <asp:BoundField DataField="aStatus" HeaderText="&#2360;&#2381;&#2341;&#2367;&#2340;&#2367;" />
                            <%--<asp:CommandField SelectText="Update" ShowSelectButton="True" />--%>
                              <asp:TemplateField  HeaderText="&#2325;&#2381;&#2354;&#2367;&#2325; &#2325;&#2352;&#2375;">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkTransferApprove" OnClick="lnkTransferApprove_Click">&#2309;&#2349;&#2367;&#2350;&#2340;</asp:LinkButton>
                                    <asp:Label ID="lblTransferID" runat="server" Text='<%#Bind("ApplicationId")%>' Visible="false"></asp:Label>
                                    <asp:HiddenField ID="hfApprovedId" runat="server" Value='<%# Eval("ID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkViewTransferDetail" OnClick="lnkViewTransferDetail_Click">View Detail</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <table>
                                <tr>
                                    <td style="text-align: center!important;">No Transfer Application Available</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlProvidentFundStaus" runat="server" Visible="false">
        <table width="100%">
            <tr>
                <td style="padding-top: 10px; padding-bottom: 10px;"><span style="font-size: 20px; color: green;"><b>Provident Fund Status</b></span></td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="grdPFStatus" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="FundID" AllowPaging="True" OnPageIndexChanging="grdPFStatus_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ApplicationDate" HeaderText="&#2310;&#2357;&#2375;&#2342;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" DataFormatString="{0:dd/MM/yyyy}" />
                            <%--<asp:BoundField DataField="LoanTypeName" HeaderText="Loan Name" />--%>
                            <asp:BoundField DataField="AmountRequested" HeaderText="&#2309;&#2327;&#2381;&#2352;&#2367;&#2350; &#2352;&#2366;&#2358;&#2367; &#2325;&#2366; &#2309;&#2344;&#2369;&#2352;&#2379;&#2343;" />
                            <asp:BoundField DataField="Reason" HeaderText="&#2325;&#2366;&#2352;&#2339;" />
                            <asp:BoundField DataField="ForwardedName" HeaderText="&#2309;&#2344;&#2369;&#2350;&#2379;&#2342;&#2344;/&#2309;&#2349;&#2367;&#2350;&#2340; &#2309;&#2343;&#2367;&#2325;&#2366;&#2352;&#2368;" />
                            <asp:BoundField DataField="Status" HeaderText="&#2360;&#2381;&#2341;&#2367;&#2340;&#2367;" />
                            <%--<asp:CommandField SelectText="Update" ShowSelectButton="True" />--%>
                        </Columns>
                        <EmptyDataTemplate>
                            <table>
                                <tr>
                                    <td style="text-align: center!important;">No P.F. Application Available</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlProvidentFundApproval" runat="server" Visible="false">
        <table width="100%">
            <tr>
                <td style="padding-top: 10px; padding-bottom: 10px;"><span style="font-size: 20px; color: green;"><b>Provident Fund Approval</b></span>
                    <asp:HiddenField ID="hfPFDetailId" runat="server" />
                    <asp:HiddenField ID="hfPFAppId" runat="server" />
                    <asp:HiddenField ID="hfPFApprovedId" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GrdPFApproval" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="FundID" AllowPaging="True" OnPageIndexChanging="GrdPFApproval_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ApplicationDate" HeaderText="&#2310;&#2357;&#2375;&#2342;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="EmployeeFullName" HeaderText="&#2310;&#2357;&#2375;&#2342;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;" />
                            <asp:BoundField DataField="Designation" HeaderText="&#2346;&#2342;" />
                            <asp:BoundField DataField="PostedAT" HeaderText="&#2346;&#2342;&#2360;&#2381;&#2341;" />
                            <asp:BoundField DataField="AmountRequested" HeaderText="&#2309;&#2327;&#2381;&#2352;&#2367;&#2350; &#2352;&#2366;&#2358;&#2367; &#2325;&#2366; &#2309;&#2344;&#2369;&#2352;&#2379;&#2343;" />
                            <asp:BoundField DataField="ApprovedAmount" HeaderText="&#2309;&#2344;&#2369;&#2350;&#2379;&#2342;&#2367;&#2340; &#2352;&#2366;&#2358;&#2367;" />
                            <asp:BoundField DataField="Reason" HeaderText="&#2325;&#2366;&#2352;&#2339;" />
                            <asp:BoundField DataField="Remark" HeaderText="&#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368;" />
                            <asp:BoundField DataField="Status" HeaderText="&#2360;&#2381;&#2341;&#2367;&#2340;&#2367;" />
                            <%--<asp:CommandField SelectText="Update" ShowSelectButton="True" />--%>
                            <asp:TemplateField HeaderText="&#2342;&#2360;&#2381;&#2340;&#2366;&#2357;&#2375;&#2332;&#2364; &#2337;&#2366;&#2313;&#2344;&#2354;&#2379;&#2337;">
                                <ItemTemplate>
                                    <a href='<%#Eval("UploadImg")%>' target="_blank"><%#Eval("aa")%></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField  HeaderText="&#2325;&#2381;&#2354;&#2367;&#2325; &#2325;&#2352;&#2375;">
                                <ItemTemplate>
                                    <%-- <a href="HR/MedicalAdvanceRecommendation.aspx?medicalid=<%# new APIProcedure().Encrypt(Eval("MedicalID").ToString ()) %>">Approve</a>--%>
                                    <asp:LinkButton runat="server" ID="lnkPFApprove" OnClick="lnkPFApprove_Click">&#2309;&#2349;&#2367;&#2350;&#2340;</asp:LinkButton>
                                    <asp:Label ID="lblFundID" runat="server" Text='<%#Bind("FundID")%>' Visible="false"></asp:Label>
                                    <asp:HiddenField ID="hfGPFDetailId" runat="server" Value='<%# Eval("ID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkViewPFDetail" OnClick="lnkViewPFDetail_Click">View Detail</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--   <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkMedicalAdvCancel" OnClick="lnkMedicalAdvCancel_Click">Cancle</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                        <EmptyDataTemplate>
                            <table>
                                <tr>
                                    <td style="text-align: center!important;">No P.F. Available</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlPrintingVoucherBill" runat="server" Visible="false" ScrollBars="Horizontal" Width="100%">
        <table width="100%">
            <tr>
                <td style="padding-top: 10px; padding-bottom: 10px;"><span style="font-size: 20px; color: green;"><b>Pending Voucher Bill Approval</b>
                    <asp:HiddenField ID="HiddenField9" runat="server" />
                    <asp:HiddenField ID="HiddenField10" runat="server" />
                    <asp:HiddenField ID="HiddenField11" runat="server" />
                </span></td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GrdPriBillVoucherFill" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="VoucherTrno_I" 
                        AllowPaging="True" OnPageIndexChanging="GrdPriBillVoucherFill01" OnRowDataBound="GrdPriBillVoucherFill_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText="">
                                <ItemTemplate><span>Click&nbsp;
                                   <a href="PRI003_CreateVoucherNew.aspx?Cid=<%#new APIProcedure().Encrypt(Eval("VoucherTrno_I").ToString()) %>&vw=<%#new APIProcedure().Encrypt(Eval("DepartmentName_V").ToString())%>&id=<%#new APIProcedure().Encrypt(Eval("id").ToString())%>&desg=<%#new APIProcedure().Encrypt(Eval("ApprovedBy").ToString())%>&BillID11=<%#new APIProcedure().Encrypt(Eval("BillID_I").ToString())%>"><%#Eval("DeyakNo_V")%></a>
                                    for voucher process</span>
                                    </ItemTemplate>
                                    </asp:TemplateField>
                            <asp:BoundField DataField="DepartmentName_V" HeaderText="Department" />
                            <asp:BoundField DataField="ApplicationDate" HeaderText="Voucher Date" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="Mad_V" HeaderText="Head" />
                            <asp:BoundField DataField="TotalBudjut_N" HeaderText="Total Budget Provisioned" />
                            <asp:BoundField DataField="PreviousBillAmount_N" HeaderText="Expenditure Till Last Date" />
                            <asp:BoundField DataField="PartyName_V" HeaderText="Payment to be Made to" />
                            <asp:BoundField  DataField="SanctionedAmount_N" HeaderText="Sanctionable Amount (Rs.)" />
                         <asp:BoundField  DataField="SamayojanAmount_N" HeaderText="Adjustment Amount (Rs.)"  />
                             <asp:BoundField  DataField="PayAmount_N" HeaderText="Payable Amount (Rs.)"  />
                            <asp:BoundField DataField="RemarkPending" HeaderText="Remark" />
                            <asp:TemplateField  HeaderText="Party Bill No">
                                <ItemTemplate>
                                   <%-- <a href="Printing/PRI003_BillDetails.aspx?ID=<%#new APIProcedure().Encrypt(Eval("BillID_I").ToString()) %>&vw=1" target="_blank"><%#Eval("PartyBillNo_V")%></a>--%>
                                    <a id="hreflnk" runat="server" href="#"><%#Eval("PartyBillNo_V")%></a>
                                    <asp:LinkButton ID="lnkBill" runat="server" Visible="false" CommandArgument='<%#Eval("BillID_I")%>' OnClick="lnBtnViewIndent_Click" Text='<%#Eval("PartyBillNo_V")%>'></asp:LinkButton>
                                    </ItemTemplate>
                                    </asp:TemplateField>
                              <asp:BoundField  DataField="PartyBillDate_D" HeaderText="Party Bill Date." DataFormatString="{0:dd/MM/yyyy}"  />
                            <asp:BoundField DataField="STATUS" HeaderText=" Status" />                          
                           
                         
                               <asp:TemplateField  HeaderText="&#2325;&#2381;&#2354;&#2367;&#2325; &#2325;&#2352;&#2375;" Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkApprove" OnClick="lnkApprove_Click">&#2309;&#2349;&#2367;&#2350;&#2340;</asp:LinkButton>
                                    <asp:Label ID="lblLeaveId" runat="server" Text='<%#Bind("VoucherTrno_I")%>' Visible="false"></asp:Label>
                                     <asp:Label ID="lblApplicantDeptId" runat="server" Text='<%#Bind("CEDepartmentId")%>' Visible="false"></asp:Label>
                                     <asp:Label ID="lblApplicantId" runat="server" Text='<%#Bind("ApplicatinId")%>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblAssignedEmp" runat="server" Text='<%#Bind("AssignedEmp")%>' Visible="false"></asp:Label>
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("ID") %>' />
                                     <asp:HiddenField ID="hfIsFinalBill" runat="server" Value='<%# Eval("IsFinalBill") %>' />
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
                    <asp:HiddenField ID="HiddenField12" runat="server" />
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel ID="pnlBankDetailsBill" runat="server" Visible="false">
        <table width="100%">
            <tr>
                <td style="padding-top: 10px; padding-bottom: 10px;"><span style="font-size: 20px; color: green;"><b>Approved Bank Details</b>
                    <asp:HiddenField ID="HiddenField13" runat="server" />
                    <asp:HiddenField ID="HiddenField14" runat="server" />
                    <asp:HiddenField ID="HiddenField15" runat="server" />
                </span></td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GrdBankDetailsBill" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="VoucherTrno_I" AllowPaging="True" OnPageIndexChanging="GrdLeaveApproval_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField  HeaderText="Voucher No">
                                <ItemTemplate>
                                    <a href="PRI003_CreateVoucher.aspx?Cid=<%#new APIProcedure().Encrypt(Eval("VoucherTrno_I").ToString()) %>&vw=<%#new APIProcedure().Encrypt(Eval("DepartmentName_V").ToString())%>&id=<%#new APIProcedure().Encrypt(Eval("id").ToString())%>"><%#Eval("DeyakNo_V")%></a>
                                    </ItemTemplate>
                                    </asp:TemplateField>
                            <asp:BoundField DataField="DepartmentName_V" HeaderText="Department" />
                            <asp:BoundField DataField="ApplicationDate" HeaderText="Voucher Date" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="Mad_V" HeaderText="Head" />
                            <asp:BoundField DataField="TotalBudjut_N" HeaderText="Total Budget Provisioned" />
                            <asp:BoundField DataField="PreviousBillAmount_N" HeaderText="Expenditure Till Last Date" />
                            <asp:BoundField DataField="PartyName_V" HeaderText="Payment to be Made to" />
                            <asp:BoundField  DataField="SanctionedAmount_N" HeaderText="Sanctionable Amount (Rs.)" />
                         <asp:BoundField  DataField="SamayojanAmount_N" HeaderText="Adjustment Amount (Rs.)"  />
                             <asp:BoundField  DataField="PayAmount_N" HeaderText="Payable Amount (Rs.)"  />
                            <asp:BoundField DataField="RemarkPending" HeaderText="Remark" />
                            <asp:TemplateField  HeaderText="Printer Bill No">
                                <ItemTemplate>
                                    <a href="Printing/PRI003_BillDetails.aspx?ID=<%#new APIProcedure().Encrypt(Eval("BillID_I").ToString()) %>&vw=1" target="_blank"><%#Eval("PartyBillNo_V")%></a>
                                    </ItemTemplate>
                                    </asp:TemplateField>
                              <asp:BoundField  DataField="PartyBillDate_D" HeaderText="Party Bill Date." DataFormatString="{0:dd/MM/yyyy}"  />
                            <asp:BoundField DataField="STATUS" HeaderText="Status" />                          
                           
                         
                               <asp:TemplateField  HeaderText="&#2325;&#2381;&#2354;&#2367;&#2325; &#2325;&#2352;&#2375;" Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkApprove" OnClick="lnkApprove_Click">&#2309;&#2349;&#2367;&#2350;&#2340;</asp:LinkButton>
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
                </td>
            </tr>
        </table>
    </asp:Panel>

    <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
    </div>
    <div id="Messages" style="display: none;" class="popupnew1" runat="server">
        <h2><b>Pending Leaves for Approval</b> </h2>
        <table width="800px">
            <tr>
                <td>&#2310;&#2357;&#2375;&#2342;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;</td>
                <td>
                    <asp:Label ID="lblApplicant" runat="server" Text=""></asp:Label></td>
                <td>&#2310;&#2357;&#2375;&#2342;&#2344; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;</td>
                <td>
                    <asp:Label ID="lblLeaveType" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&#2325;&#2348; &#2360;&#2375;</td>
                <td>
                    <asp:Label ID="lblFrom" runat="server" Text=""></asp:Label></td>
                <td>&#2325;&#2348; &#2340;&#2325;</td>
                <td>
                    <asp:Label ID="lblTo" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &#2325;&#2366;&#2352;&#2381;&#2351;&#2325;&#2366;&#2352;&#2368; &#2325;&#2352;&#2381;&#2350;&#2330;&#2366;&#2352;&#2368;
                </td>
                <td>
                   
                    <asp:DropDownList ID="ddlAssignedEmployee" runat="server" CssClass="ddl"></asp:DropDownList>
                    <asp:Label ID="lblAssignedEmployee" runat="server" Visible="false"></asp:Label>
                    
                </td>
                <td>
                    <asp:Label ID="lblLeaveStatus" runat="server" Text="&#2360;&#2381;&#2341;&#2367;&#2340;&#2367;" Visible="false"></asp:Label>
                   </td>
                <td>
                     <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" Visible="false" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                        <asp:ListItem Value="1" Selected="True">Approve</asp:ListItem>
                        <asp:ListItem Value="2">Cancel</asp:ListItem>
                        <asp:ListItem Value="3">Query</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td> <asp:Label ID="lblFarwardTo" runat="server" Text="&#2309;&#2349;&#2367;&#2350;&#2340; &#2309;&#2343;&#2367;&#2325;&#2366;&#2352;&#2368;"></asp:Label></td>
                <td>  <asp:DropDownList ID="ddlForwardTo" runat="server" Visible="false"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>&#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368;</td>
                <td colspan="3">
                    <asp:TextBox ID="txtRemark" runat="server" Width="312px" Height="47px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td colspan="4">
                    <asp:Button ID="Button1" runat="server" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306;" Width="100px" OnClick="Button1_Click" OnClientClick="return ValidateLeave()" />
                    &nbsp;<asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375;&#2306; " Width="83px" />
                </td>
            </tr>

        </table>

    </div>

    <div id="fadeDiv1" class="modalBackground" style="display: none;" runat="server">
    </div>
    <div id="Messages1" style="display: none;" class="popupnew1" runat="server">
        <h2><b>Pending Transfer Application for Approval</b> </h2>
        <table width="800px">
            <tr>
                <td>&#2310;&#2357;&#2375;&#2342;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;</td>
                <td>
                    <asp:Label ID="lblTApplicantName" runat="server" ></asp:Label></td>
                <td>&#2346;&#2342;</td>
                <td>
                    <asp:Label ID="lblDesignationName" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>&#2357;&#2352;&#2381;&#2340;&#2350;&#2366;&#2344; &#2360;&#2381;&#2341;&#2366;&#2344;</td>
                <td>
                    <asp:Label ID="lblCurrentLocation" runat="server" Text=""></asp:Label></td>
                <td>&#2344;&#2357;&#2368;&#2344; &#2360;&#2381;&#2341;&#2366;&#2344;</td>
                <td>
                    <asp:Label ID="lblNewLocation" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTranferStatus" runat="server" Text="&#2360;&#2381;&#2341;&#2367;&#2340;&#2367;" Visible="false"></asp:Label>
                    <asp:Label ID="lblTForwardTo" runat="server" Text="&#2309;&#2349;&#2367;&#2350;&#2340; &#2309;&#2343;&#2367;&#2325;&#2366;&#2352;&#2368;" Visible="false"></asp:Label>
                </td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal" Visible="false">
                        <asp:ListItem Value="1" Selected="True">Approve</asp:ListItem>
                        <asp:ListItem Value="2">Cancel</asp:ListItem>
                    </asp:RadioButtonList>
                     <asp:DropDownList ID="ddlTForwardTo" runat="server" Visible="false"></asp:DropDownList>
                </td>
                <td>
                    </td>
                <td>
                   </td>
            </tr>
            <tr>
                <td>&#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368;</td>
                <td colspan="3">
                    <asp:TextBox ID="txtTRemark" runat="server" TextMode="MultiLine" Width="312px" Height="47px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="Button3" runat="server" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306;" Width="100px" OnClick="Button3_Click" OnClientClick="return ValidateTransfer()" />
                    &nbsp;<asp:Button ID="Button4" runat="server" CssClass="btn" OnClick="Button4_Click" Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375;&#2306; " Width="83px" />
                </td>
            </tr>

        </table>

    </div>


      <div id="fadeDiv2" class="modalBackground" style="display: none;" runat="server">
    </div>
    <div id="Messages2" style="display: none;" class="popupnew1" runat="server">
        <h2><b>Pending Grain Advance Application for Approval</b> </h2>
        <table width="800px">
            <tr>
                <td>&#2310;&#2357;&#2375;&#2342;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                <td>
                    <asp:Label ID="lblGrainApplicantName" runat="server" Text=""></asp:Label></td>
                <td>&#2346;&#2342;</td>
                <td>
                    <asp:Label ID="lblGrainDesignation" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>&#2346;&#2342;&#2360;&#2381;&#2341; </td>
                <td>
                    <asp:Label ID="lblGrainPostedAt" runat="server" Text=""></asp:Label></td>
                <td>&#2309;&#2327;&#2381;&#2352;&#2367;&#2350; &#2358;&#2375;&#2359; &#2309;&#2344;&#2366;&#2332; &#2352;&#2366;&#2358;&#2367;</td>
                <td>
                    <asp:Label ID="lblGrainAdvanceBalance" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&#2309;&#2327;&#2381;&#2352;&#2367;&#2350; &#2352;&#2366;&#2358;&#2367; &#2325;&#2366; &#2309;&#2344;&#2369;&#2352;&#2379;&#2343; &#2325;&#2367;&#2351;&#2366; </td>
                <td>
                    <asp:Label ID="lblAdvenceAmtRequest" runat="server" Text=""></asp:Label></td>
                <td>&#2309;&#2344;&#2369;&#2350;&#2379;&#2342;&#2367;&#2340; &#2352;&#2366;&#2358;&#2367;<span style="color:red">*</span></td>
                <td>
                    <asp:TextBox ID="txtGrainApprovedAmount" runat="server" Text="" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblGrainStatus" runat="server" Text="&#2360;&#2381;&#2341;&#2367;&#2340;&#2367;" Visible="false"></asp:Label>
                    <asp:Label ID="lblGrainApprovedBy" runat="server" Text="&#2309;&#2349;&#2367;&#2350;&#2340; &#2309;&#2343;&#2367;&#2325;&#2366;&#2352;&#2368;"></asp:Label>
                    <span style="color:red">*</span>
                </td>
                <td>
                      <asp:DropDownList ID="ddlGrainApprovedBy" runat="server"></asp:DropDownList>
                    <asp:RadioButtonList ID="rbGrainStatus" runat="server" RepeatDirection="Horizontal" Visible="false">
                        <asp:ListItem Value="1" Selected="True">Approve</asp:ListItem>
                        <asp:ListItem Value="2">Cancel</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>&#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368;<span style="color:red">*</span></td>
                <td colspan="3">
                    <asp:TextBox ID="txtGrainRemarks" runat="server" TextMode="MultiLine" Width="312px" Height="47px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnGrainSave" runat="server" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306;" Width="100px" OnClick="btnGrainSave_Click" OnClientClick="return ValidateGrain()" />
                    &nbsp;<asp:Button ID="btnGrainCancel" runat="server" CssClass="btn" OnClick="btnGrainCancel_Click" Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375;&#2306; " Width="83px" />
                </td>
            </tr>

        </table>

    </div>

    <div id="fadeDiv3" class="modalBackground" style="display: none;" runat="server">
    </div>
    <div id="Messages3" style="display: none;" class="popupnew1" runat="server">
        <h2><b>Pending Festival Advance Application for Approval</b> </h2>
        <table width="800px">
            <tr>
                <td>&#2310;&#2357;&#2375;&#2342;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                <td>
                    <asp:Label ID="lblFestivalApplicant" runat="server" Text=""></asp:Label></td>
                <td>&#2346;&#2342;</td>
                <td>
                    <asp:Label ID="lblFestivalDesignation" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>&#2346;&#2342;&#2360;&#2381;&#2341; </td>
                <td>
                    <asp:Label ID="lblFestivalPostedAt" runat="server" Text=""></asp:Label></td>
                <td>&#2358;&#2375;&#2359; &#2340;&#2381;&#2351;&#2380;&#2361;&#2366;&#2352; &#2309;&#2327;&#2381;&#2352;&#2367;&#2350;</td>
                <td>
                    <asp:Label ID="lblFestivalAdvanceBalance" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&#2340;&#2381;&#2351;&#2380;&#2361;&#2366;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                <td>
                    <asp:Label ID="lblFestivalName" runat="server" Text=""></asp:Label></td>
                <td>&#2340;&#2381;&#2351;&#2380;&#2361;&#2366;&#2352; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;</td>
                <td>
                    <asp:Label ID="lblFestivalDate" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&#2309;&#2327;&#2381;&#2352;&#2367;&#2350; &#2352;&#2366;&#2358;&#2367; &#2325;&#2366; &#2309;&#2344;&#2369;&#2352;&#2379;&#2343; </td>
                <td>
                    <asp:Label ID="lblFestivalRequestAmount" runat="server" Text=""></asp:Label></td>
                <td>&#2309;&#2344;&#2369;&#2350;&#2379;&#2342;&#2367;&#2340; &#2352;&#2366;&#2358;&#2367;</td>
                <td>
                    <asp:TextBox ID="txtFestivalApprovedAmount" runat="server" Text="" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblFestivalStatus" runat="server" Text="&#2360;&#2381;&#2341;&#2367;&#2340;&#2367;" Visible="false"></asp:Label>
                     <asp:Label ID="lblFestivalApprovedBy" runat="server" Text="&#2309;&#2349;&#2367;&#2350;&#2340; &#2309;&#2343;&#2367;&#2325;&#2366;&#2352;&#2368;" Visible="false"></asp:Label>
                </td>
                <td>
                    <asp:RadioButtonList ID="rbFestivalStatus" runat="server" RepeatDirection="Horizontal" Visible="false">
                        <asp:ListItem Value="1" Selected="True">Approve</asp:ListItem>
                        <asp:ListItem Value="2">Cancel</asp:ListItem>
                    </asp:RadioButtonList>
                     <asp:DropDownList ID="ddlFestivalApprovedBy" runat="server" Visible="false"></asp:DropDownList>
                </td>
                <td>
                   </td>
                <td>
                   </td>
            </tr>
            <tr>
                <td>&#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368;</td>
                <td colspan="3">
                    <asp:TextBox ID="txtFestivalRemark" runat="server" TextMode="MultiLine" Width="312px" Height="47px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnFestivalSave" runat="server" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306;" Width="100px" OnClick="btnFestivalSave_Click" OnClientClick="return ValidateFestival()" />
                    &nbsp;<asp:Button ID="btnFestivalCancel" runat="server" CssClass="btn" OnClick="btnFestivalCancel_Click" Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375;&#2306; " Width="83px" />
                </td>
            </tr>

        </table>

    </div>

    <div id="fadeDiv4" class="modalBackground" style="display: none;" runat="server">
    </div>
    <div id="Messages4" style="display: none;" class="popupnew1" runat="server">
        <h2><b>Pending Medical Advance Application for Approval</b> </h2>
        <table width="800px">
            <tr>
                <td>&#2310;&#2357;&#2375;&#2342;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                <td>
                    <asp:Label ID="lblMedicalApplicant" runat="server" Text=""></asp:Label></td>
                <td>&#2346;&#2342;</td>
                <td>
                    <asp:Label ID="lblMedicalDesignation" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>&#2346;&#2342;&#2360;&#2381;&#2341; </td>
                <td>
                    <asp:Label ID="lblMedicalPostedAt" runat="server" Text=""></asp:Label></td>
                <td>&#2348;&#2368;&#2350;&#2366;&#2352;&#2368; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; </td>
                <td>
                    <asp:Label ID="lblMedicalIllness" runat="server" Text=""></asp:Label></td>
               
            </tr>
            <tr>
                 <td>&#2310;&#2357;&#2358;&#2381;&#2351;&#2325; &#2352;&#2366;&#2358;&#2367; &#2325;&#2366; &#2309;&#2344;&#2369;&#2352;&#2379;&#2343;</td>
                <td>
                    <asp:Label ID="lblMedicalRequestAmount" runat="server" Text=""></asp:Label>
                </td>
                <td>&#2309;&#2344;&#2369;&#2350;&#2379;&#2342;&#2367;&#2340; &#2352;&#2366;&#2358;&#2367;</td>
                <td>
                    <asp:TextBox ID="txtMedicalApprovedAmount" runat="server" Text="" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMedicalStatus" runat="server" Text="&#2360;&#2381;&#2341;&#2367;&#2340;&#2367;" Visible="false"></asp:Label>
                    <asp:Label ID="lblMedicalApprovedBy" runat="server" Text="&#2309;&#2349;&#2367;&#2350;&#2340; &#2309;&#2343;&#2367;&#2325;&#2366;&#2352;&#2368;"  Visible="false"></asp:Label>
                </td>
                <td>
                    <asp:RadioButtonList ID="rbMedicalStatus" runat="server" RepeatDirection="Horizontal" Visible="false">
                        <asp:ListItem Value="1" Selected="True">Approve</asp:ListItem>
                        <asp:ListItem Value="2">Cancel</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:DropDownList ID="ddlMedicalApprovedBy" runat="server" Visible="false"></asp:DropDownList>
                </td>
                <td>
                    </td>
                <td>
                    </td>
            </tr>
            <tr>
                <td>&#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368;</td>
                <td colspan="3">
                    <asp:TextBox ID="txtMedicalRemark" runat="server" Width="312px" TextMode="MultiLine" Height="47px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnMedicalSave" runat="server" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306;" Width="100px" OnClick="btnMedicalSave_Click" OnClientClick="return ValidateMedical()" />
                    &nbsp;<asp:Button ID="btnMedicalCancel" runat="server" CssClass="btn" OnClick="btnMedicalCancel_Click" Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375;&#2306; " Width="83px" />
                </td>
            </tr>

        </table>

    </div>

    <div id="fadeDiv5" class="modalBackground" style="display: none;" runat="server">
    </div>
    <div id="Messages5" style="display: none;" class="popupnew1" runat="server">
        <h2><b>Pending Provident Fund Application for Approval</b> </h2>
        <table width="800px">
            <tr>
                <td>&#2310;&#2357;&#2375;&#2342;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                <td>
                    <asp:Label ID="lblPFApplicant" runat="server" Text=""></asp:Label></td>
                <td>&#2346;&#2342;</td>
                <td>
                    <asp:Label ID="lblPFDesignation" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>&#2346;&#2342;&#2360;&#2381;&#2341; </td>
                <td>
                    <asp:Label ID="lblPFPostedAt" runat="server" Text=""></asp:Label></td>
                <td>&#2310;&#2357;&#2358;&#2381;&#2351;&#2325; &#2352;&#2366;&#2358;&#2367; &#2325;&#2366; &#2309;&#2344;&#2369;&#2352;&#2379;&#2343;</td>
                <td>
                    <asp:Label ID="lblPFRequestedAmount" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&#2325;&#2366;&#2352;&#2339; </td>
                <td>
                    <asp:Label ID="lblPFReason" runat="server" Text=""></asp:Label></td>
                <td>&#2309;&#2344;&#2369;&#2350;&#2379;&#2342;&#2367;&#2340; &#2352;&#2366;&#2358;&#2367;</td>
                <td>
                    <asp:TextBox ID="txtPFApprovedAmount" runat="server" Text="" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPFStatus" runat="server" Text="&#2360;&#2381;&#2341;&#2367;&#2340;&#2367;" Visible="false"></asp:Label>
                    <asp:Label ID="lblPFApprovedBy" runat="server" Text="&#2309;&#2349;&#2367;&#2350;&#2340; &#2309;&#2343;&#2367;&#2325;&#2366;&#2352;&#2368;" Visible="false"></asp:Label>
                </td>
                <td>
                    <asp:RadioButtonList ID="rbPFStatus" runat="server" RepeatDirection="Horizontal" Visible="false">
                        <asp:ListItem Value="1" Selected="True">Approve</asp:ListItem>
                        <asp:ListItem Value="2">Cancel</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:DropDownList ID="ddlPFApprovedBy" runat="server" Visible="false"></asp:DropDownList>
                </td>
                <td>
                    </td>
                <td>
                    </td>
            </tr>
            <tr>
                <td>&#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368;</td>
                <td colspan="3">
                    <asp:TextBox ID="txtPFRemaks" runat="server" TextMode="MultiLine" Width="312px" Height="47px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnPFSave" runat="server" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306;" Width="100px" OnClick="btnPFSave_Click" OnClientClick="return ValidatePf()" />
                    &nbsp;<asp:Button ID="lblPFCancel" runat="server" CssClass="btn" OnClick="lblPFCancel_Click" Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375;&#2306; " Width="83px" />
                </td>
            </tr>

        </table>

    </div>

    <div id="fadeDiv6" class="modalBackground" style="display: none;" runat="server">
    </div>
    <div id="Messages6" style="display: none;" class="popupnew1" runat="server">
        <h2><b>Pending travel for Approval</b> </h2>
        <table width="800px">
            <tr>
                <td>&#2310;&#2357;&#2375;&#2342;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;</td>
                <td>
                    <asp:Label ID="lblTravelApplicantName" runat="server" Text=""></asp:Label></td>
                <td>&#2358;&#2381;&#2352;&#2375;&#2339;&#2368;</td>
                <td>
                    <asp:Label ID="lblTravelClass" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&#2346;&#2381;&#2352;&#2366;&#2352;&#2306;&#2349; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;</td>
                <td>
                    <asp:Label ID="lblTravelStatingDate" runat="server" Text=""></asp:Label></td>
                <td>&#2309;&#2306;&#2340;&#2367;&#2350; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;</td>
                <td>
                    <asp:Label ID="lblTravelEndDate" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&#2351;&#2366;&#2340;&#2381;&#2352;&#2366; &#2325;&#2368; &#2309;&#2357;&#2343;&#2367; (&#2342;&#2367;&#2344; &#2350;&#2375;&#2306;)</td>
                <td>
                    <asp:Label ID="lblTravelPeriod" runat="server" Text=""></asp:Label></td>
                <td>&#2351;&#2366;&#2340;&#2381;&#2352;&#2366; &#2325;&#2366; &#2360;&#2381;&#2341;&#2366;&#2344;</td>
                <td>
                    <asp:Label ID="lblTravelPlace" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>&#2309;&#2327;&#2381;&#2352;&#2367;&#2350; &#2352;&#2366;&#2358;&#2367; &#2325;&#2366; &#2309;&#2344;&#2369;&#2352;&#2379;&#2343;</td>
                <td>
                    <asp:Label ID="lblTravelAdvanceAmount" runat="server" Text=""></asp:Label></td>
                <td>&#2309;&#2344;&#2369;&#2350;&#2379;&#2342;&#2367;&#2340; &#2352;&#2366;&#2358;&#2367;</td>
                <td>
                    <asp:TextBox ID="txtTravelApprovedAmount" runat="server" Text="" onkeypress="return isNumberKey(event,this)"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTravelApprovedBy" runat="server" Text="&#2309;&#2349;&#2367;&#2350;&#2340; &#2309;&#2343;&#2367;&#2325;&#2366;&#2352;&#2368;" Visible="false"></asp:Label>
                    <asp:Label ID="lblTravelStatus" runat="server" Text="&#2360;&#2381;&#2341;&#2367;&#2340;&#2367;" Visible="false"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlTravelApprovedBy" runat="server" Visible="false"></asp:DropDownList>
                     <asp:RadioButtonList ID="rbTravelStatus" runat="server" RepeatDirection="Horizontal" Visible="false">
                        <asp:ListItem Value="1" Selected="True">Approve</asp:ListItem>
                        <asp:ListItem Value="2">Cancel</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    </td>
                <td>
                   
                </td>
            </tr>
            <tr>
                <td>&#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368;</td>
                <td colspan="3">
                    <asp:TextBox ID="txtTravelRemark" runat="server" Width="312px" TextMode="MultiLine" Height="47px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Button ID="btnTravelSave" runat="server" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306;" Width="100px" OnClick="btnTravelSave_Click" OnClientClick="return ValidateTravel()" />
                    &nbsp;<asp:Button ID="btnTravelCancel" runat="server" CssClass="btn" OnClick="btnTravelCancel_Click" Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375;&#2306; " Width="83px" />
                </td>
            </tr>

        </table>

    </div>

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
                    <asp:BoundField DataField="Approved Officer" HeaderText="Approved Officer" />                     
                    <asp:BoundField DataField="Remark" HeaderText="Remark" />
                    <asp:BoundField DataField="Action Date" HeaderText="Action Date" /> 
                    <asp:BoundField DataField="Status" HeaderText="Status" />                   
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </div>

     <div id="ApprovedLeave" class="modalBackground" style="display: none;" runat="server">
    </div>
    <div id="ApprovedLeave1" style="display: none;" class="popupnew1" runat="server">
        <asp:Panel ID="Panel3" runat="server" ScrollBars="Horizontal" Height="400px">
           
            <asp:Button ID="Button8" runat="server" Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375;&#2306; " CssClass="btn" OnClick="Button8_Click" />
            <br />
            <h2><b>Approved Employee Leaves</b> </h2>
            <asp:GridView ID="grdApprovedLeave" CssClass="tab" AutoGenerateColumns="false" PageSize="20"
                    AllowPaging="false"
                    DataKeyNames="LeaveRequestID" runat="server" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:BoundField DataField="ApplicationDate" ReadOnly="true" HeaderText="&#2310;&#2357;&#2375;&#2342;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" />
                        <asp:BoundField DataField="Applicant" ReadOnly="true" HeaderText="&#2310;&#2357;&#2375;&#2342;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;" />
                        <asp:BoundField DataField="LeaveTypeName" ReadOnly="true" HeaderText="&#2309;&#2357;&#2325;&#2366;&#2358; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;" />
                         <asp:BoundField DataField="FromDate" ReadOnly="true" HeaderText="&#2346;&#2381;&#2352;&#2366;&#2352;&#2306;&#2349; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" />
                         <asp:BoundField DataField="ToDate" ReadOnly="true" HeaderText="&#2309;&#2306;&#2340;&#2367;&#2350; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" />
                         <asp:BoundField DataField="NoofDays" ReadOnly="true" HeaderText="&#2325;&#2369;&#2354; &#2342;&#2367;&#2344;" />
                         <asp:BoundField DataField="LeaveReason" ReadOnly="true" HeaderText="&#2325;&#2366;&#2352;&#2339;" />
                         <asp:BoundField DataField="LeaveReason" ReadOnly="true" HeaderText="&#2325;&#2366;&#2352;&#2339;" />
                           <asp:TemplateField HeaderText="&#2342;&#2360;&#2381;&#2340;&#2366;&#2357;&#2375;&#2332;&#2364; &#2337;&#2366;&#2313;&#2344;&#2354;&#2379;&#2337;">
                                <ItemTemplate>
                                    <a href='<%#Eval("UploadImg")%>' target="_blank"><%#Eval("aa")%></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table>
                            <tr>
                                <td style="text-align: center!important;">No Loan Available</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                    <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                </asp:GridView>
        </asp:Panel>
    </div>

    <div id="fadeDiv11" runat="server" class="modalBackground" style="display: none">
    </div>
    <div id="Messages11" style="display: none; width: 80%; left: 5%" class="popupnew" runat="server">
        <table width="100%">
            <tr>
               <td>
                <asp:LinkButton ID="lnBtnBack" runat="server" OnClick="lnBtnBack_Click">&#2348;&#2306;&#2342; &#2325;&#2352;&#2375;&#2306;..</asp:LinkButton>
               </td>
            </tr>
            <tr>
                <td>
                    <div class="box">
                        <div class="card-header">
                            <h2>
                                <span>&#2346;&#2375;&#2352;&#2379;&#2354; &#2348;&#2367;&#2354; / HR Payroll Bill</span></h2>
                        </div>
                        <div class="table-responsive">
                                <center>
                            <asp:Panel ID="Panel4" runat="server">
                                <div>
                                    <table width="100%"> 
                                                                               
                                        <tr>
                                            <td colspan="4" align="center">
                    <asp:GridView runat="server" ID="GrdViewIndentDetails" AutoGenerateColumns="false"  CssClass="tab" >
                     <Columns>
                     <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;. / No." HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                     <ItemTemplate>
                     <%# Container.DataItemIndex +1 %>
                         <asp:HiddenField ID="hdnMonthID" runat="server" Value='<%# Eval("MonthID")%>' />
                     </ItemTemplate>
                     </asp:TemplateField> 

                     <asp:TemplateField HeaderText="&#2357;&#2352;&#2381;&#2359; / Year" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                     <ItemTemplate>
                     <%# Eval("Yearid")%>
                     </ItemTemplate>                     
                     </asp:TemplateField>

                          <asp:TemplateField HeaderText="&#2350;&#2366;&#2361; / Month" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                     <ItemTemplate>
                     <%# Eval("Month_v")%>
                     </ItemTemplate>                     
                     </asp:TemplateField>
                     
                      <asp:TemplateField HeaderText="&#2349;&#2369;&#2327;&#2340;&#2366;&#2344; &#2325;&#2368; &#2327;&#2312; &#2352;&#2366;&#2358;&#2368; &#2352;&#2369;. / Payment Amount" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                     <ItemTemplate>
                     <%# Eval("Netsalary")%>
                     </ItemTemplate>      
                     </asp:TemplateField>

                          <asp:TemplateField HeaderText="&#2348;&#2367;&#2354; &#2325;&#2368; &#2360;&#2381;&#2341;&#2367;&#2340;&#2367; / Bill Status" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                     <ItemTemplate>
                     <%# Eval("VchrPendingApprove")%>
                     </ItemTemplate>                     
                     </asp:TemplateField>

                     </Columns>
                         
                                <EmptyDataRowStyle CssClass="GvEmptyText" />

                     </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </asp:Panel>
                                </center>
                        </div>
                    </div>
                </td>
            </tr>
            
        </table>
    </div>
    <script type="text/javascript">
        function doPostBack_bill(hreflnk, id) {
            __doPostBack(hreflnk, 'lnBtnViewIndent_Click');
            return false;
        }
    </script>
</asp:Content>

