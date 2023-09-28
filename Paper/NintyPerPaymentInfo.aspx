<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="NintyPerPaymentInfo.aspx.cs" Inherits="Paper_NintyPerPaymentInfo" Title="90% &#2342;&#2375;&#2351;&#2325; &#2325;&#2375; &#2349;&#2369;&#2327;&#2340;&#2366;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Information Of 90% Payment." %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-header ui-widget-header">
        90% &#2342;&#2375;&#2351;&#2325; &#2325;&#2375; &#2349;&#2369;&#2327;&#2340;&#2366;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Information Of 90% Payment.</div>
      <div class="table-responsive">
        <table width="100%">
                        <tr>
                <td >   &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; <br />
Acadmic Year :</td> <td colspan="3" style="height: 10px;" align="left"><asp:DropDownList ID="ddlAcYear" Width="250px" runat="server" OnInit="ddlAcYear_Init"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    <%--Select Vendor (--%>&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366;
                    &#2344;&#2366;&#2350;<br />Paper Mill Name
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlVendor" Width="250px" OnInit="ddlVendor_Init"
                        CssClass="txtbox reqirerd" AutoPostBack="True" OnSelectedIndexChanged="ddlVendor_SelectedIndexChanged">
                        <asp:ListItem Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                  &#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br /> L.O.I. Name
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
                    <%--Select Vendor (--%>&#2346;&#2375;&#2346;&#2352; &#2325;&#2366;
                    &#2344;&#2366;&#2350;<br />Paper Type </td>
                <td>
                            <asp:DropDownList ID="ddlGSM" runat="server" AutoPostBack="True" CssClass="txtbox reqirerd" OnSelectedIndexChanged="ddlGSM_SelectedIndexChanged" Height="16px" Width="219px">
                            </asp:DropDownList>


                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &#2348;&#2367;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br />Bill No.
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtVoucharNo" onkeypress="tbx_fnUserName(event, this);"  CssClass="txtbox reqirerd" MaxLength="20"
                        Width="238px"></asp:TextBox>
                </td>
                <td>
                   &#2348;&#2367;&#2354; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br />Bill Date
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
                    &#2342;&#2352;(&#2352;&#2369;&#2346;&#2351;&#2375; / &#2350;&#2375;. &#2335;&#2344;)<br />Rates Per Metric Ton
                </td>
                <td>
                    <asp:Label ID="lblRatePMT" runat="server"></asp:Label>
                </td>
                <td>
                </td>
                <td>
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
                            <asp:TemplateField HeaderText="&#2330;&#2369;&#2344;&#2375; <Br>Select">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" OnCheckedChanged="chkSelect_CheckedChanged" AutoPostBack="true" />
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<Br>Receive Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblReceivedDate" runat="server" Text='<%#Eval("ReceivedDate")%>'></asp:Label>
                                </ItemTemplate>
                                
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="&#2311;&#2344;&#2357;&#2366;&#2312;&#2360; &#2344;&#2306;&#2348;&#2352; <Br>Invoice No">
                                <ItemTemplate>
                                    <asp:Label ID="lblChallanNo" runat="server" Text='<%#Eval("ChallanNo")%>'></asp:Label>
                                    <asp:Label ID="lblDisTranId" runat="server" Text='<%#Eval("DisTranId")%>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2311;&#2344;&#2357;&#2366;&#2312;&#2360; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<Br>Invoice Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblChallanDate" runat="server" Text='<%#Eval("ChallanDate")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2332;&#2368; &#2310;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; <Br> GR No">
                                <ItemTemplate>
                                    <asp:Label ID="lblGRNo" runat="server" Text='<%#Eval("GRNo")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2332;&#2368; &#2310;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<Br>GR Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblGrDate" runat="server" Text='<%#Eval("GRDate")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                  <b>  &#2325;&#2369;&#2354; &#2351;&#2379;&#2327; / Total :</b>
                                </FooterTemplate>
                            </asp:TemplateField>
                           
                            <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2352;&#2368;&#2354; <Br>No Of Reel">
                                <ItemTemplate>
                                    <asp:Label ID="lblNoOfReel" runat="server" Text='<%#Eval("NoOfReel")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblFNoOfReel" runat="server" Font-Bold="true"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2357;&#2332;&#2344; <Br>Weight">
                                <ItemTemplate>
                                    <asp:Label ID="lblWeight" runat="server" Text='<%#Eval("ReceivedQty")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblFWeight" runat="server" Font-Bold="true"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2352;&#2366;&#2358;&#2367; <Br>Amount">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblFAmount" runat="server" Font-Bold="true"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="&#2393;&#2352;&#2366;&#2348; &#2352;&#2368;&#2354;<Br> Defective Reel">
                                <ItemTemplate>
                                    <asp:Label ID="lblDefReel" runat="server" Text='<%#Eval("DefReel")%>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblFDefReel" runat="server" Font-Bold="true"  Visible="false"> </asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <EmptyDataRowStyle CssClass="GvEmptyText" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" colspan="2">
                    <Table> <TR><TD>Paper Total Value</TD><TD>
                        <asp:Label ID="lblAmountM" runat="server" Text=""></asp:Label></TD></TR>
                         <TR><TD>Paper Cost</TD><TD>
                        <asp:Label ID="lblCost" runat="server" Text=""></asp:Label></TD></TR>
                         <TR><TD>12% IGST</TD><TD>
                        <asp:Label ID="lblIGST" runat="server" Text=""></asp:Label></TD></TR>
                         <TR><TD>2% IGST TDS</TD><TD>
                        <asp:Label ID="lblIGSTTDS" runat="server" Text=""></asp:Label></TD></TR>
                    </Table> </td>
                                 <td style="height: 10px;"> 
                    
                                     &nbsp;</td>
                             <td style="height: 10px;"> 
                    
                                 &nbsp;</td>
            </tr>
            <tr>
                <td style="height: 10px;">
                   &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2325;&#2366;&#2327;&#2395; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366;<Br>Total Weight :
                </td>
                                <td style="height: 10px;">
                               <asp:TextBox runat="server" ID="txtTotWeight" Enabled="false" CssClass="txtbox reqirerd" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' MaxLength="12"
                        Width="238px"></asp:TextBox>
                    
                </td>
                                 <td style="height: 10px;"> 
                    
                </td>
                             <td style="height: 10px;"> 
                    
                </td>
            </tr>
            <tr>
                <td style="height: 10px;">
                  &#2341;&#2348;&#2381;&#2348;&#2375; &#2325;&#2375; &#2350;&#2342; &#2350;&#2375;&#2306; &#2352;&#2379;&#2325;&#2368; &#2327;&#2351;&#2368; &#2325;&#2366;&#2327;&#2395; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366;<Br> Thabba (Weight):
                </td>
                                <td style="height: 10px;">
                       <asp:TextBox runat="server" ID="txtThabba" CssClass="txtbox reqirerd" 
                                        onkeypress='javascript:tbx_fnSignedNumeric(event, this);' MaxLength="12"
                        Width="238px" AutoPostBack="True" ontextchanged="txtThabba_TextChanged"></asp:TextBox>
                </td>
                                <td style="height: 10px;"> 
                    
                </td>
                             <td style="height: 10px;">
                    
                </td>
            </tr>
            <tr>
                <td style="height: 10px;">
                    &#2358;&#2369;&#2342;&#2381;&#2343; &#2349;&#2369;&#2327;&#2340;&#2366;&#2344; &#2351;&#2379;&#2327;&#2381;&#2351; &#2325;&#2366;&#2327;&#2395; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366;<Br> Net Weight :
                </td>
                                <td style="height: 10px;">
                       <asp:TextBox runat="server" ID="txtNetWt" CssClass="txtbox reqirerd" Enabled="false" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' MaxLength="12"
                        Width="238px"></asp:TextBox>
                </td>
                                <td style="height: 10px;">
                    
                </td>
                                <td style="height: 10px;">  
                    
                </td>
            </tr>
            <tr>
                <td style="height: 10px;">
                    100% &#2349;&#2369;&#2327;&#2340;&#2366;&#2344; &#2325;&#2368; &#2325;&#2369;&#2354; &#2352;&#2366;&#2358;&#2367;<Br>Net Amount Of 100% Payment :
                </td>
                                <td style="height: 10px;">
                       <asp:TextBox runat="server" ID="txtPay100" CssClass="txtbox reqirerd" Enabled="false" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' MaxLength="12"
                        Width="238px"></asp:TextBox>
                </td>
                                <td style="height: 10px;">
                  
                </td>
                                <td style="height: 10px;">
                    
                </td>
            </tr>
            <tr>
                <td style="height: 10px;">
                    10% &#2352;&#2366;&#2358;&#2367; &#2352;&#2379;&#2325;&#2368; &#2327;&#2312;<Br>
                     10% Amount With Held :
                </td>
                                <td style="height: 10px;">
                       <asp:TextBox runat="server" ID="txtPay10" CssClass="txtbox reqirerd" Enabled="false" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' MaxLength="12"
                        Width="238px"></asp:TextBox>
                </td>
                                <td style="height: 10px;">
                    
                </td>
                                <td style="height: 10px;">
                    
                </td>
            </tr>
                <tr>
                <td style="height: 10px;">
                    90% &#2352;&#2366;&#2358;&#2367; &#2349;&#2369;&#2327;&#2340;&#2366;&#2344; &#2351;&#2379;&#2327;&#2381;&#2351;<Br>
                     90% Amount To Be Paid :
                </td>
                                <td style="height: 10px;">
                       <asp:TextBox runat="server" ID="txtPay90" CssClass="txtbox reqirerd" Enabled="false" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' MaxLength="12"
                        Width="238px"></asp:TextBox>
                </td>
                                <td style="height: 10px;">
                    
                </td>
                                <td style="height: 10px;">
                    
                </td>
            </tr>
                <tr>
                <td style="height: 10px;">
                    2% IGST TDS :
                </td>
                                <td style="height: 10px;">
                       <asp:TextBox runat="server" ID="txtTDSGST" CssClass="txtbox reqirerd" Enabled="false" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' MaxLength="12"
                        Width="238px"></asp:TextBox>
                </td>
                                <td style="height: 10px;">
                    
                                    &nbsp;</td>
                                <td style="height: 10px;">
                    
                                    &nbsp;</td>
            </tr>
                <tr>
                <td style="height: 10px;">
                    &nbsp;Net Payable Amount(Rs) :</td>
                                <td style="height: 10px;">
                       <asp:TextBox runat="server" ID="txtNetPay" CssClass="txtbox reqirerd" Enabled="false" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' MaxLength="12"
                        Width="238px"></asp:TextBox>
                </td>
                                <td style="height: 10px;">
                    
                                    &nbsp;</td>
                                <td style="height: 10px;">
                    
                                    &nbsp;</td>
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
                  <asp:TextBox ID="txtBankName" runat="server"   onkeypress='javascript:tbx_fnAlphaOnly(event, this);'  CssClass="txtbox " MaxLength="100" Width="200px"></asp:TextBox>
                </td>
                                <td style="height: 10px;">
                                    &#2330;&#2375;&#2325; / &#2337;&#2367;&#2350;&#2366;&#2306;&#2337; &#2337;&#2381;&#2352;&#2366;&#2347;&#2381;&#2335; &#2344;&#2306;&#2348;&#2352; <Br />Cheque / Demand Draft No
                    
                </td>
                                <td style="height: 10px;">
                     <asp:TextBox runat="server" ID="txtChequeNo" CssClass="txtbox " onkeypress='javascript:tbx_fnSignedNumeric(event, this);' MaxLength="12"
                        Width="238px"></asp:TextBox>
                </td>
            </tr>
             <tr id="trBankdetails3" runat="server">
                <td style="height: 10px;">
                    &#2330;&#2375;&#2325; / &#2337;&#2367;&#2350;&#2366;&#2306;&#2337; &#2337;&#2381;&#2352;&#2366;&#2347;&#2381;&#2335; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; <Br />Cheque / Demand Draft Date :
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
                <td colspan="4" style="height: 10px;">
                    <asp:Button runat="server" ID="btnSave" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save"
                        OnClientClick="return ValidateAllTextForm();" CssClass="btn" OnClick="btnSave_Click" />
                    <asp:Button  runat="server" ID="btnBack"  OnClick="btnBack_Click" CssClass="btn" Text="&#2357;&#2366;&#2346;&#2360; &#2332;&#2366;&#2351;&#2375; / Back" />
                    <asp:HiddenField ID="HDNRedirect" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            height: 10px;
        }
    </style>
</asp:Content>

