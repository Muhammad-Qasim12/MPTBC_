<%@ Page Title="बचे हुये 2% पेमेंट की जानकारी / Information Of Remaining 2% Payment" Language="C#" MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="true" CodeFile="RemainingTwoPerPayment.aspx.cs" Inherits="Paper_RemainingTwoPerPayment" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-header ui-widget-header">
        <%--Dispatch to C'Depot by Paper vendor--%>बचे हुये 2% पेमेंट की जानकारी / Information Of Remaining 2% Payment</div>
      <div class="table-responsive">
        <table width="100%">
             <tr>
                <td >   &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; <br />
                         Acadmic Year :</td> 
                 <td colspan="3" style="height: 10px;" align="left">
                     <asp:DropDownList ID="ddlAcYear" Width="250px" runat="server" ></asp:DropDownList>

                 </td>
            </tr>
            <tr>
                <td>
                    <%--Select Vendor (--%>&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366;
                    &#2344;&#2366;&#2350;<br />Name Of Paper Mill
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlVendor" Width="250px" OnInit="ddlVendor_Init"
                        CssClass="txtbox reqirerd" AutoPostBack="True" OnSelectedIndexChanged="ddlVendor_SelectedIndexChanged">
                        <asp:ListItem Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <%--LOI No. (--%>&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br />L.O.I. No.
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlLOINo" Width="250px" CssClass="txtbox reqirerd"
                        AutoPostBack="True" OnSelectedIndexChanged="ddlLOINo_SelectedIndexChanged">
                        <asp:ListItem Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    &#2357;&#2366;&#2313;&#2330;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br />Voucher No.
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtVoucharNo" Enabled="false" onkeypress="tbx_fnUserName(event, this);"  CssClass="txtbox reqirerd" MaxLength="20"
                        Width="238px"></asp:TextBox>
                </td>
                <td>
                    &#2357;&#2366;&#2313;&#2330;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br />Voucher Date
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtVoucharDate" CssClass="txtbox reqirerd" MaxLength="10"
                        Width="238px"></asp:TextBox>
                    <cc1:CalendarExtender ID="txtChallanDate_CalendarExtender" runat="server" TargetControlID="txtVoucharDate"
                        Format="dd/MM/yyyy">
                    </cc1:CalendarExtender>
                </td>
            </tr>
                 <tr>
                <td>
                    दर (रुपये / मे. टन)<Br />Rates Per Metric Ton in Rupees
                </td>
                <td>
                  <asp:Label ID="lblRatePMT" runat="server" Font-Bold="true"></asp:Label>
                </td>
                <td>
              <%-- कुल वस्तबिक वजन <Br />Actual Weight--%>
                </td>
                <td>
               <asp:Label ID="lblActualWet" runat="server"  Font-Bold="true" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                
                <td>
                    कुल आवंटित वजन (मे. टन)<br />Total Weight(Metric Ton)
                </td>
                <td>
               <asp:Label ID="lblTotWt" runat="server"  Font-Bold="true"></asp:Label>
                </td>
                 <td>
              कुल प्रदाय वजन (मे. टन)<br />Total Paid Weight(Metric Ton)
                </td>
                <td>
                    <asp:Label ID="lblPaidWt" runat="server"  Font-Bold="true"></asp:Label>
                </td>
            </tr>
              <tr>
               
                <td>
               शेष वजन (मे. टन)<br />Remaining Weight(Metric Ton)
                </td>
                <td>
                <asp:Label ID="lblRemWt" runat="server"  Font-Bold="true"></asp:Label>
                </td>
                  <td>
           कुल थब्बा निकलने की संभाबना (मे. टन)<br />Probability Of Defect(Metric Ton)
                </td>
                <td>
                   <asp:Label ID="lblThabba" runat="server"  Font-Bold="true"></asp:Label>    
                </td>
            </tr>
            <tr>
                <td>
                 कुल प्रदाय राशि (रुपये/मे. टन)<br />Total Paid Amount(Metric Ton)
                </td>
                <td>
                    <asp:Label ID="lblTotPaidAmount" runat="server"  Font-Bold="true"></asp:Label>
                </td>
                <td>
               शेष राशि (रुपये/मे. टन)<br />Remaining Amount(Metric Ton)
                </td>
                <td>
                <asp:Label ID="lblRemAmount" runat="server"  Font-Bold="true"></asp:Label>
                </td>
            </tr>
           
            <tr>
                <td colspan="4" style="font-size:15px;font-weight:bold;">
                पेपर मिल की वाउचर की जानकारी / Voucher Information Of Paper Mill
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 10px;">
                    <asp:GridView ID="GrdWorkPlan" runat="server" AutoGenerateColumns="false" GridLines="None"
                        CssClass="tab" EmptyDataText="Record Not Found." Width="100%" AllowPaging="false"
                        ShowFooter="true" OnRowDataBound="GrdWorkPlan_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>.
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                            <asp:TemplateField HeaderText="वाउचर क्रमांक <br>Voucher No.">
                                <ItemTemplate>
                                    <asp:Label ID="lblVoucharNo" runat="server" Text='<%#Eval("VoucharNo")%>'></asp:Label>
                                   <%-- <asp:Label ID="lblVouchar_Tr_Id" runat="server" Text='<%#Eval("Vouchar_Tr_Id")%>' Visible="false"></asp:Label>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="वाउचर दिनांक<br>Voucher Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblVoucharDate" runat="server" Text='<%#Eval("VoucharDate")%>'></asp:Label>
                                </ItemTemplate>
                                 <FooterTemplate>
                                <b>कुल योग /Total :</b>
                                </FooterTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="राशि (रुपये में)<br>Amount">
                                <ItemTemplate>
                                    <asp:Label ID="lbl100Amount" runat="server" Text='<%#Eval("Amount")%>'></asp:Label>
                                </ItemTemplate>
                                 <FooterTemplate>
                               <asp:Label ID="lblF100Amount" runat="server" Font-Bold="true"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="वजन(मे. टन में) <br>Weight(Metric Ton)">
                                <ItemTemplate>
                                    <asp:Label ID="lblWeight" runat="server" Text='<%#Eval("NetWt")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                <asp:Label ID="lblFWeight" runat="server" Font-Bold="true"  Visible="false"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="प्रतिशत (%)">
                                <ItemTemplate>
                                    <asp:Label ID="lbl1001Amount" runat="server" Text='<%#Eval("Percentage")%>'></asp:Label>
                                </ItemTemplate>
                                 
                            </asp:TemplateField>
                           
                           
                        </Columns><EmptyDataRowStyle CssClass="GvEmptyText" />
                    </asp:GridView>
                </td>
            </tr>
             <tr>
                <td colspan="4" style="font-size:15px;font-weight:bold;">
                पेपर मिल की 8% वाउचर की जानकारी / 8% Voucher Information Of Paper Mill
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 10px;">
                    <asp:GridView ID="gv90PerChallan" runat="server" AutoGenerateColumns="false" GridLines="None"
                        CssClass="tab" EmptyDataText="Record Not Found." Width="100%" AllowPaging="false"
                        ShowFooter="true" OnRowDataBound="gv90PerChallan_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>.
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="चुने <Br>Select">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" OnCheckedChanged="chkSelect_CheckedChanged" AutoPostBack="true" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="वाउचर क्रमांक <br>Voucher No.">
                                <ItemTemplate>
                                    <asp:Label ID="lblVoucharNo" runat="server" Text='<%#Eval("VoucharNo")%>'></asp:Label>
                                    <asp:Label ID="lblVouchar_Tr_Id" runat="server" Text='<%#Eval("Vouchar_Tr_Id")%>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="वाउचर दिनांक<br>Voucher Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblVoucharDate" runat="server" Text='<%#Eval("VoucharDate")%>'></asp:Label>
                                </ItemTemplate>
                                 <FooterTemplate>
                                <b>कुल योग /Total :</b>
                                </FooterTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="राशि (रुपये में)<br>Amount">
                                <ItemTemplate>
                                    <asp:Label ID="lbl100Amount" runat="server" Text='<%#Eval("Amount")%>'></asp:Label>
                                </ItemTemplate>
                                 <FooterTemplate>
                               <asp:Label ID="lblF100Amount" runat="server" Font-Bold="true"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="वजन(मे. टन में) <br>Weight(Metric Ton)">
                                <ItemTemplate>
                                    <asp:Label ID="lblWeight" runat="server" Text='<%#Eval("NetWt")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                <asp:Label ID="lblFWeight" runat="server" Font-Bold="true"  ></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="प्रतिशत (%)">
                                <ItemTemplate>
                                    <asp:Label ID="lbl1001Amount" runat="server" Text='<%#Eval("Percentage")%>'></asp:Label>
                                </ItemTemplate>
                                
                            </asp:TemplateField>
                         <%--   <asp:TemplateField HeaderText="90% राशि">
                                <ItemTemplate>
                                    <asp:Label ID="lbl90Amount" runat="server" Text='<%#Eval("90Amount")%>'></asp:Label>
                                </ItemTemplate>
                                 <FooterTemplate>
                               <asp:Label ID="lblF90Amount" runat="server" Font-Bold="true"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="8% राशि">
                                <ItemTemplate>
                                    <asp:Label ID="lbl8Amount" runat="server" Text='<%#Eval("8Amount")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblF8Amount" runat="server" Font-Bold="true"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="2% राशि">
                                <ItemTemplate>
                                    <asp:Label ID="lbl2Amount" runat="server" Text='<%#Eval("2Amount")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblF2Amount" runat="server" Font-Bold="true"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>--%>
                           
                        </Columns><EmptyDataRowStyle CssClass="GvEmptyText" />
                    </asp:GridView>
                </td>
            </tr>
              <tr>
                <td>
                   वजन (मे. टन) <br />Weight(Metric Ton)
                </td>
                <td>
                     <asp:TextBox runat="server" ID="txtWeight" AutoPostBack="true" OnTextChanged="txtWeight_TextChanged" CssClass="txtbox reqirerd" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' MaxLength="12"
                        Width="238px"></asp:TextBox>
                </td>
                <td>
                    कुल राशि (रुपये में)<br />Total Amount
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtNetAmt" Enabled="false" CssClass="txtbox reqirerd" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' MaxLength="12"
                        Width="238px"></asp:TextBox>
                   
                </td>
            </tr>
         
         
         
             
             <tr>
                <td colspan="4" style="color:#1d4a57;font-weight:bold;border-bottom:1px solid #34A0C0;"">
            
      
   बैंक की जानकारी / BANK DETAILS
                   
              
                </td>
            </tr>
              <tr>
                <td style="height: 10px;">
                    बैंक का नाम <br />
Bank Name
                </td>
                             <td>
                  <asp:TextBox ID="txtBankName" runat="server"   onkeypress='javascript:tbx_fnAlphaOnly(event, this);'  CssClass="txtbox " MaxLength="100" Width="200px"></asp:TextBox>
                </td>
                                <td style="height: 10px;">
                                    चेक / डिमांड ड्राफ्ट नंबर <Br />Cheque / Demand Draft No
                    
                </td>
                                <td style="height: 10px;">
                     <asp:TextBox runat="server" ID="txtChequeNo" CssClass="txtbox " onkeypress='javascript:tbx_fnSignedNumeric(event, this);' MaxLength="12"
                        Width="238px"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td style="height: 10px;">
                    चेक / डिमांड ड्राफ्ट दिनांक <Br />Cheque / Demand Draft Date :
                </td>
                             <td>
                  <asp:TextBox ID="txtChequeDate" runat="server"    CssClass="txtbox " MaxLength="10" Width="200px"></asp:TextBox>
                                   <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtChequeDate"
                        Format="dd/MM/yyyy">
                    </cc1:CalendarExtender>
                </td>
                                <td style="height: 10px;">
                                 
                    
                </td>
                                <td style="height: 10px;">
                   
                </td>
            </tr>
            <tr>
                <td colspan="1">
                  टिप्पणी<br />Remark
                   
                </td>
                <td colspan="3">   <asp:TextBox runat="server" ID="txtRemark" CssClass="txtbox" MaxLength="200" 
                     Width="650px"   ></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4" style="height: 10px;">
                    <asp:Button runat="server" ID="btnSave" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save "
                        OnClientClick="return ValidateAllTextForm();" CssClass="btn" OnClick="btnSave_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>


