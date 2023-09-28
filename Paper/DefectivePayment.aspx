<%@ Page Title=" &#2341;&#2348;&#2381;&#2348;&#2375; &#2360;&#2375; &#2360;&#2306;&#2348;&#2306;&#2343;&#2367;&#2340; &#2342;&#2375;&#2351;&#2325; &#2325;&#2375; &#2349;&#2369;&#2327;&#2340;&#2366;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Information Of Defective Payment" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
    CodeFile="DefectivePayment.aspx.cs" Inherits="Paper_DefectivePayment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-header ui-widget-header">
        <%--Dispatch to C'Depot by Paper vendor--%> &#2341;&#2348;&#2381;&#2348;&#2375; &#2360;&#2375; &#2360;&#2306;&#2348;&#2306;&#2343;&#2367;&#2340; &#2342;&#2375;&#2351;&#2325; &#2325;&#2375; &#2349;&#2369;&#2327;&#2340;&#2366;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Information Of Defective Payment</div>
      <div class="table-responsive">
        <table width="100%">
           <tr>
                <td >   &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; <br />
Acadmic Year :</td>
                <td colspan="3" style="height: 10px;" align="left"><asp:DropDownList ID="ddlAcYear" Width="250px" runat="server" OnInit="ddlAcYear_Init"></asp:DropDownList></td>
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
                    &#2342;&#2352; (&#2352;&#2369;&#2346;&#2351;&#2375; / &#2350;&#2375;. &#2335;&#2344;)<Br />Rates Per Metric Ton in Rupees
                </td>
                <td>
                  <asp:Label ID="lblRatePMT" runat="server" Font-Bold="true"></asp:Label>
                </td>
                <td>
              <%-- &#2325;&#2369;&#2354; &#2357;&#2360;&#2381;&#2340;&#2348;&#2367;&#2325; &#2357;&#2332;&#2344; <Br />Actual Weight--%>
                </td>
                <td>
               <asp:Label ID="lblActualWet" runat="server"  Font-Bold="true" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                
                <td>
                    &#2325;&#2369;&#2354; &#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2357;&#2332;&#2344; (&#2350;&#2375;. &#2335;&#2344;)<br />Total Weight(Metric Ton)
                </td>
                <td>
               <asp:Label ID="lblTotWt" runat="server"  Font-Bold="true"></asp:Label>
                </td>
                 <td>
              &#2325;&#2369;&#2354; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2357;&#2332;&#2344; (&#2350;&#2375;. &#2335;&#2344;)<br />Total Paid Weight(Metric Ton)
                </td>
                <td>
                    <asp:Label ID="lblPaidWt" runat="server"  Font-Bold="true"></asp:Label>
                </td>
            </tr>
              <tr>
               
                <td>
               &#2358;&#2375;&#2359; &#2357;&#2332;&#2344; (&#2350;&#2375;. &#2335;&#2344;)<br />Remaining Weight(Metric Ton)
                </td>
                <td>
                <asp:Label ID="lblRemWt" runat="server"  Font-Bold="true"></asp:Label>
                </td>
                  <td>
           &#2325;&#2369;&#2354; &#2341;&#2348;&#2381;&#2348;&#2366; &#2344;&#2367;&#2325;&#2354;&#2344;&#2375; &#2325;&#2368; &#2360;&#2306;&#2349;&#2366;&#2348;&#2344;&#2366; (&#2350;&#2375;. &#2335;&#2344;)<br />Probability Of Defect(Metric Ton)
                </td>
                <td>
                   <asp:Label ID="lblThabba" runat="server"  Font-Bold="true"></asp:Label>    
                </td>
            </tr>
            <tr>
                <td>
                 &#2325;&#2369;&#2354; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2352;&#2366;&#2358;&#2367; (&#2352;&#2369;&#2346;&#2351;&#2375;/&#2350;&#2375;. &#2335;&#2344;)<br />Total Paid Amount(Metric Ton)
                </td>
                <td>
                    <asp:Label ID="lblTotPaidAmount" runat="server"  Font-Bold="true"></asp:Label>
                </td>
                <td>
               &#2358;&#2375;&#2359; &#2352;&#2366;&#2358;&#2367; (&#2352;&#2369;&#2346;&#2351;&#2375;/&#2350;&#2375;. &#2335;&#2344;)<br />Remaining Amount(Metric Ton)
                </td>
                <td>
                <asp:Label ID="lblRemAmount" runat="server"  Font-Bold="true"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="font-size:15px;font-weight:bold;">
                &#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2368; &#2357;&#2366;&#2313;&#2330;&#2352; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Voucher Information Of Paper Mill
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
                           
                            <asp:TemplateField HeaderText="&#2357;&#2366;&#2313;&#2330;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; <br>Voucher No.">
                                <ItemTemplate>
                                    <asp:Label ID="lblVoucharNo" runat="server" Text='<%#Eval("VoucharNo")%>'></asp:Label>
                                   <%-- <asp:Label ID="lblVouchar_Tr_Id" runat="server" Text='<%#Eval("Vouchar_Tr_Id")%>' Visible="false"></asp:Label>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2357;&#2366;&#2313;&#2330;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br>Voucher Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblVoucharDate" runat="server" Text='<%#Eval("VoucharDate")%>'></asp:Label>
                                </ItemTemplate>
                                 <FooterTemplate>
                                <b>&#2325;&#2369;&#2354; &#2351;&#2379;&#2327; /Total :</b>
                                </FooterTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="&#2352;&#2366;&#2358;&#2367; (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375;&#2306;)<br>Amount">
                                <ItemTemplate>
                                    <asp:Label ID="lbl100Amount" runat="server" Text='<%#Eval("Amount")%>'></asp:Label>
                                </ItemTemplate>
                                 <FooterTemplate>
                               <asp:Label ID="lblF100Amount" runat="server" Font-Bold="true"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2357;&#2332;&#2344;(&#2350;&#2375;. &#2335;&#2344; &#2350;&#2375;&#2306;) <br>Weight(Metric Ton)">
                                <ItemTemplate>
                                    <asp:Label ID="lblWeight" runat="server" Text='<%#Eval("NetWt")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                <asp:Label ID="lblFWeight" runat="server" Font-Bold="true" Visible="false"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340; (%)">
                                <ItemTemplate>
                                    <asp:Label ID="lbl1001Amount" runat="server" Text='<%#Eval("Percentage")%>'></asp:Label>
                                </ItemTemplate>
                                
                            </asp:TemplateField>
                           <%-- <asp:TemplateField HeaderText="100% &#2352;&#2366;&#2358;&#2367;">
                                <ItemTemplate>
                                    <asp:Label ID="lbl100Amount" runat="server" Text='<%#Eval("100Amount")%>'></asp:Label>
                                </ItemTemplate>
                                 <FooterTemplate>
                               <asp:Label ID="lblF100Amount" runat="server" Font-Bold="true"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="90% &#2352;&#2366;&#2358;&#2367;">
                                <ItemTemplate>
                                    <asp:Label ID="lbl90Amount" runat="server" Text='<%#Eval("90Amount")%>'></asp:Label>
                                </ItemTemplate>
                                 <FooterTemplate>
                               <asp:Label ID="lblF90Amount" runat="server" Font-Bold="true"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="8% &#2352;&#2366;&#2358;&#2367;">
                                <ItemTemplate>
                                    <asp:Label ID="lbl8Amount" runat="server" Text='<%#Eval("8Amount")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblF8Amount" runat="server" Font-Bold="true"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="2% &#2352;&#2366;&#2358;&#2367;">
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
                 &#2341;&#2366;&#2348;&#2381;&#2348;&#2366; &#2357;&#2332;&#2344; (&#2350;&#2375;. &#2335;&#2344;) <br />Defective Weight(Metric Ton)
                </td>
                <td>
                     <asp:TextBox runat="server" ID="txtTotalThabba" AutoPostBack="true" OnTextChanged="txtTotalThabba_TextChanged" CssClass="txtbox reqirerd" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' MaxLength="12"
                        Width="238px"></asp:TextBox>
                </td>
                <td>
                 
                </td>
                <td>
                    
                   
                </td>
            </tr>
              <tr>
                <td>
                  &#2357;&#2332;&#2344; (&#2350;&#2375;. &#2335;&#2344;) <br /> Weight(Metric Ton)
                </td>
                <td>
                     <asp:TextBox runat="server" ID="txtWeight"  Enabled="false"  CssClass="txtbox reqirerd" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' MaxLength="12"
                        Width="238px"></asp:TextBox>
                </td>
                <td>
                    &#2325;&#2369;&#2354; &#2352;&#2366;&#2358;&#2367; (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375;&#2306;)<br />Total Amount
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtNetAmt" Enabled="false" CssClass="txtbox reqirerd" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' MaxLength="12"
                        Width="238px"></asp:TextBox>
                   
                </td>
            </tr>
          
               <tr id="trBankdetails1" runat="server">
                <td colspan="4" style="color:#1d4a57;font-weight:bold;border-bottom:1px solid #34A0C0;">      
   &#2348;&#2376;&#2306;&#2325; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / BANK DETAILS
                </td>
            </tr>

              <tr id="trBankdetails2" runat="server">
                <td style="height: 10px;">
                    &#2348;&#2376;&#2306;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; <br />
Bank Name
                </td>
                             <td>
                  <asp:TextBox ID="txtBankName" runat="server"   onkeypress='javascript:tbx_fnAlphaOnly(event, this);'  CssClass="txtbox reqirerd" MaxLength="100" Width="200px"></asp:TextBox>
                </td>
                                <td style="height: 10px;">
                                    &#2330;&#2375;&#2325; / &#2337;&#2367;&#2350;&#2366;&#2306;&#2337; &#2337;&#2381;&#2352;&#2366;&#2347;&#2381;&#2335; &#2344;&#2306;&#2348;&#2352; <Br />Cheque / Demand Draft No
                    
                </td>
                                <td style="height: 10px;">
                     <asp:TextBox runat="server" ID="txtChequeNo" CssClass="txtbox reqirerd" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' MaxLength="12"
                        Width="238px"></asp:TextBox>
                </td>
            </tr>
             <tr id="trBankdetails3" runat="server">
                <td style="height: 10px;">
                    &#2330;&#2375;&#2325; / &#2337;&#2367;&#2350;&#2366;&#2306;&#2337; &#2337;&#2381;&#2352;&#2366;&#2347;&#2381;&#2335; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; <Br />Cheque / Demand Draft Date :
                </td>
                             <td>
                  <asp:TextBox ID="txtChequeDate" runat="server"    CssClass="txtbox reqirerd" MaxLength="10" Width="200px"></asp:TextBox>
                                   <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtChequeDate"
                        Format="dd/MM/yyyy">
                    </cc1:CalendarExtender>
                </td>
                                 <td>&#2330;&#2375;&#2325;/&#2337;&#2367;&#2350;&#2366;&#2306;&#2337; &#2337;&#2381;&#2352;&#2366;&#2347;&#2381;&#2335; &#2352;&#2366;&#2358;&#2367; (&#2352;&#2369;.&#2350;&#2375;&#2306;) / Cheque/Demand Draft  Amount (Rs.) </td>
                            <td>
                                <asp:Label runat="server" ID="txtChequeAmt" Enabled="false"></asp:Label></td>
            </tr>
         
            <tr id="trBankdetails4" runat="server">
                <td colspan="1">
                  &#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368;<br />Remark
                   
                </td>
                <td colspan="3">   <asp:TextBox runat="server" ID="txtRemark" CssClass="txtbox reqirerd" MaxLength="200" 
                     Width="650px"   ></asp:TextBox></td>
            </tr>
             
             <tr>
                <td colspan="5" style="height: 10px;">
                    <asp:Button runat="server" ID="btnSave" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save "
                        OnClientClick="return ValidateAllTextForm();" CssClass="btn" OnClick="btnSave_Click" />

                    <asp:Button runat="server" ID="btnSaveBankDetails" Text="Issue Cheque/&#2330;&#2375;&#2325; &#2332;&#2366;&#2352;&#2368; &#2325;&#2352;&#2375;&#2306;"
                        OnClientClick="return ValidateAllTextForm();" Visible="false" CssClass="btn" OnClick="btnSaveBankDetails_Click" />

                    <asp:HiddenField ID="hdnID" runat="server" />
                </td>
            </tr>
        </table>
             
        
    </div>
</asp:Content>




