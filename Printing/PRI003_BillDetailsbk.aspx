<%@ Page Title="Bill Details" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="PRI003_BillDetailsbk.aspx.cs" Inherits="Printing_PRI003_BillDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="upPnale" runat="server">
                        <ContentTemplate>
    
    <div class="portlet-header ui-widget-header">
        &#2348;&#2367;&#2354; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;</div>
    
    <div class="portlet-content">
        <asp:Panel runat="server" ID="pnlMain">
            <asp:Panel runat="server" ID="pnlBillDetail" GroupingText="Printer Bill Details"
                Width="1200px">
                <table width="100%">
                    <tr>
                        <td>
                            Academic Year</td>
                        <td>
                            <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox" 
                                onselectedindexchanged="DdlACYear_SelectedIndexChanged">
                                <asp:ListItem>..Select..</asp:ListItem>
                                <asp:ListItem>2012-13</asp:ListItem>
                                <asp:ListItem>2013-14</asp:ListItem>
                                <asp:ListItem>2014-15</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            Name of the Printer</td>
                        <td>
                            <asp:DropDownList ID="ddlPrinter" runat="server" AutoPostBack="True" 
                                CssClass="txtbox reqirerd" OnInit="ddlPrinter_Init" 
                                OnSelectedIndexChanged="ddlPrinter_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Bill No
                        </td>
                        <td>
                            <asp:TextBox ID="txtBillNo" runat="server" CssClass="txtbox reqirerd" MaxLength="10"
                                onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                        </td>
                        <td>
                            Bill Date
                        </td>
                        <td>
                            &nbsp;<asp:TextBox ID="txtBillDate" runat="server" CssClass="txtbox reqirerd" 
                                MaxLength="10" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td colspan="3" align="left">
                            <asp:Label runat="server" ID="lblBookNAme" Visible="False"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel runat="server" ID="Panel1" GroupingText="Bill Description " style="font-size:13px;" Width="1200px">
                <table width="100%">
                    <tr>
                        <td colspan="4">
                            (A) Payable Amount
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 10px;">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            (1) Paper supplied</td>
                    </tr>
                    <tr>
                        <td colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            (i) Total Paper supplied
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtTotalPaperSupply" CssClass="txtbox reqirerd" MaxLength="8"
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);'>0</asp:TextBox>
                        </td>
                        <td>
                            Total Cover Paper supplied
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtTotalCoverPaperSupply" CssClass="txtbox reqirerd"
                                MaxLength="8" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'>0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            (ii) Paper Security deposited by the printer Rs.
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtPaperSecurityDeposit" CssClass="txtbox reqirerd"
                                MaxLength="8" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'>0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            (iii) Paper Security reimbursed to the printer Rs.
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtPaperSecurityReimbursed" CssClass="txtbox reqirerd"
                                MaxLength="8" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' >0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            (iv) Balance paper Security for reimbursement Rs.
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtBalancePaperSecurityReimbursed" CssClass="txtbox reqirerd"
                                MaxLength="8" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'>0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 10px;">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            (2) Printing charges, Paper & Cover paper consumptions
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 10px;">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                        
                        
                            <asp:GridView runat="server" ID="GrdPaperCoverAndPrintingChares" AutoGenerateColumns="False"
                                CssClass="tab hastable" OnRowDataBound="GrdPaperCoverAndPrintingChares_RowDataBound"
                                EmptyDataText="Record Not Found.">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex +1 %></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <%# Eval("TitleHindi_V")%>
                                            <asp:Label ID="lblBillDetID_I" runat="server" Text='<%# Eval("BillDetID_I")%>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblTitleID_I" runat="server" Text='<%# Eval("TitleID_I")%>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalNoBook" runat="server" Text='<%# Eval("TotalNoOfBooks")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRate_N" runat="server" Text='<%# Eval("Rate_N")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Pages">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPages_N" runat="server" Text='<%# Eval("Pages_N")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Blank Pages(per Book)">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtBlankPages" CssClass="txtbox" runat="server" AutoPostBack="true"  OnTextChanged="txtBlankPages_TextChanged"
                                                MaxLength="8" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' Text='<%#Eval("BlankPages") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total Blank Pages">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalBlankPages_N" runat="server" Text='<%# Eval("TotBlankPage")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAmount" runat="server"  Text='<%# Eval("Amount_N")%>'   ></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Paper consumption with wastage in Tons">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtPapterConsumption" CssClass="txtbox" runat="server" MaxLength="8"
                                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' Text='<%#Eval("PaperConsum_Wastage_N") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cover Paper consumption with wastage in Sheets">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCoverPapterConsumption" CssClass="txtbox" runat="server" MaxLength="8"
                                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' Text='<%#Eval("CoverPaperConsum_Wastage_N") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                            </asp:GridView>
                      
                        
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Total 100% Printing Charges Rs.
                        </td>
                        <td colspan="3">
                            <asp:TextBox runat="server" ID="txtPrintingCharge" CssClass="txtbox reqirerd" MaxLength="8"
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);'>0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            25% Printing Charges to be withheld Rs.
                        </td>
                        <td colspan="3">
                            <asp:TextBox runat="server" ID="txtPrintingCharge25Per" CssClass="txtbox reqirerd"
                              MaxLength="8" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'>0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            75% Printing Charges Payable Rs.
                        </td>
                        <td colspan="3">
                            <asp:TextBox runat="server" ID="txtPrintingCharge75Per" CssClass="txtbox reqirerd"
                                MaxLength="8" 
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' AutoPostBack="True" 
                                ontextchanged="txtPrintingCharge75Per_TextChanged">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 10px;">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtReimburseAmount" runat="server" CssClass="txtbox reqirerd" MaxLength="8"
                                
                                onkeypress="javascript:tbx_fnSignedNumeric(event, this);" AutoPostBack="True" 
                                ontextchanged="txtReimburseAmount_TextChanged" Visible="False">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="txtPaperSecurityFor" runat="server" CssClass="txtbox reqirerd" MaxLength="8"
                                 onkeypress="javascript:tbx_fnSignedNumeric(event, this);"
                                Visible="False">0</asp:TextBox>
                            <asp:TextBox ID="txtReemPaperRs" runat="server" CssClass="txtbox reqirerd" MaxLength="8"
                                 onkeypress="javascript:tbx_fnSignedNumeric(event, this);"
                                Visible="False">0</asp:TextBox>
                            <asp:TextBox ID="txtTonsPerReem" runat="server" CssClass="txtbox reqirerd" MaxLength="8"
                                 onkeypress="javascript:tbx_fnSignedNumeric(event, this);"
                                Visible="False">0</asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtPayBlePrintingCharg" CssClass="txtbox reqirerd"
                                 MaxLength="8" 
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' AutoPostBack="True" 
                                ontextchanged="txtPayBlePrintingCharg_TextChanged" Visible="False">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        </td>
                        <td>
                            <b>(A) Total Printing Charges Payable Rs.</b>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtTotalPaybleAmount" CssClass="txtbox reqirerd"
                                 MaxLength="8" 
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' Enabled="False">0</asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel runat="server" ID="Panel2" GroupingText="DEDUCTIONS" style="font-size:13px;" Width="1200px">
                <table width="100%">
                    <tr>
                        <td colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            (1) Withheld 2% regarding income Tax on Rs.
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txt2PerInComeTAX" CssClass="txtbox reqirerd" MaxLength="8"
                                
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' AutoPostBack="True" 
                                ontextchanged="txt2PerInComeTAX_TextChanged">0</asp:TextBox>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            (2) Deduction against paper security
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtDeductionPaperSecurity" CssClass="txtbox reqirerd"
                                 MaxLength="8" 
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' AutoPostBack="True" 
                                ontextchanged="txtDeductionPaperSecurity_TextChanged">0</asp:TextBox>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            (3) Depot Expenditure on behalf of Printer
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtDepotExpenditure" CssClass="txtbox reqirerd" MaxLength="8"
                                
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' AutoPostBack="True" 
                                ontextchanged="txtDepotExpenditure_TextChanged">0</asp:TextBox>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            (4) Interest on Paper
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtPaperInterest" CssClass="txtbox reqirerd" MaxLength="8"
                                
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' AutoPostBack="True" 
                                ontextchanged="txtPaperInterest_TextChanged">0</asp:TextBox>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            (5) Penalty for Delay supply of Books
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtDelaySupplyPenalty" CssClass="txtbox reqirerd"
                             MaxLength="8" 
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' AutoPostBack="True" 
                                ontextchanged="txtDelaySupplyPenalty_TextChanged">0</asp:TextBox>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            (6) Deduction of Paper cost of against short size of Books
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtShortSizeBookDeduction" CssClass="txtbox reqirerd"
                                 MaxLength="8" 
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' AutoPostBack="True" 
                                ontextchanged="txtShortSizeBookDeduction_TextChanged">0</asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtBFPay" runat="server" CssClass="txtbox reqirerd" MaxLength="8"
                                onkeypress="javascript:tbx_fnSignedNumeric(event, this);"
                                Visible="False">0</asp:TextBox>
                            <asp:TextBox runat="server" ID="txtRs2" CssClass="txtbox reqirerd" MaxLength="8"
                               onkeypress='javascript:tbx_fnSignedNumeric(event, this);'
                                Visible="False">0</asp:TextBox>
                            <asp:TextBox runat="server" ID="txtRs3" CssClass="txtbox reqirerd" MaxLength="8"
                               onkeypress='javascript:tbx_fnSignedNumeric(event, this);'
                                Visible="False">0</asp:TextBox>
                        </td>
                        <td>
                            (B) Total deduction
                        </td>
                        <td>
                            Rs.
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtTotalDeduction" CssClass="txtbox reqirerd" MaxLength="8"
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' Enabled="false" 
                                AutoPostBack="True" ontextchanged="txtTotalDeduction_TextChanged">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            (C) Net payable A-B
                        </td>
                        <td>
                            Rs.
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtNetPayable" CssClass="txtbox reqirerd" MaxLength="8"
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' Enabled="false">0</asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlPrintingSection" style="font-size:13px;" GroupingText="Printing Section"
                Width="1200px">
                <table>
                    <tr>
                        <td>
                            (a) Amount of the Bill Rs.
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtBillAmount" CssClass="txtbox reqirerd" MaxLength="8"
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' Enabled="false">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            (b) Amount of the Deduction Rs.
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtBillAmountofDeduction" CssClass="txtbox reqirerd"
                                MaxLength="8" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'  Enabled="false">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            (c) Net payable Rs.
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtBillNetPayablePrinting" CssClass="txtbox reqirerd"
                                MaxLength="8" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' Enabled="false">0</asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Button runat="server" ID="btnForward" CssClass="btn" Text="Save " OnClientClick="return ValidateAllTextForm();"
                OnClick="btnForward_Click" />
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlFinance" GroupingText="Finance Section" Visible="false"
            Width="1200px">
            <asp:Label ID="lblFinanceMsg" runat="server"
                ForeColor="Green" Font-Bold="True"></asp:Label>
            <br />
            <br />
            <asp:Button runat="server" ID="btnSendToFinance" CssClass="btn" Text="Forward to Finance section"
                Width="250px" OnClick="btnSendToFinance_Click" Visible="false" />
        </asp:Panel>
        <cc1:CalendarExtender ID="CetxtDate" runat="server" TargetControlID="txtBillDate"
            Format="dd/MM/yyyy">
        </cc1:CalendarExtender>
    </div>
     
        </ContentTemplate>
                        </asp:UpdatePanel>
</asp:Content>
