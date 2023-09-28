<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="BillVoucher.aspx.cs" Inherits="Printing_BillVoucher" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-header ui-widget-header">
        <p>
            &#2348;&#2367;&#2354; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;</p>
    </div>
   <div class="box table-responsive">
     <asp:UpdatePanel ID="upPnale" runat="server">
                        <ContentTemplate>
    
        <asp:Panel runat="server" ID="pnlMain">
            <asp:Panel runat="server" ID="pnlBillDetail" GroupingText="Printer Bill Details">
                <table width="100%">
                    <tr>
                        <td colspan="5">
                            &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;
                            <asp:DropDownList ID="ddlPrinter" runat="server" AutoPostBack="True"  Width="300px"
                                CssClass="txtbox reqirerd" OnInit="ddlPrinter_Init" 
                                OnSelectedIndexChanged="ddlPrinter_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;
                            <asp:Label ID="lblBookName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            (1) Balance of Printing Charges
                        </td>
                        <td>
                            Rs.</td>
                        <td align="left" colspan="3">
                            &nbsp;
                            <asp:TextBox ID="txtBalPrintingCharges" runat="server" 
                                CssClass="txtbox reqirerd" MaxLength="8" 
                                onkeypress="javascript:tbx_fnSignedNumeric(event, this);" 
                                AutoPostBack="True" ontextchanged="txtBalPrintingCharges_TextChanged">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            (2) Balance of Printing Security
                        </td>
                        <td>
                            Rs.</td>
                        <td align="left" colspan="3">
                            &nbsp;
                            <asp:TextBox ID="txtBalPrintingSec" runat="server" CssClass="txtbox reqirerd" 
                                MaxLength="8" onkeypress="javascript:tbx_fnSignedNumeric(event, this);" 
                                AutoPostBack="True" ontextchanged="txtBalPrintingSec_TextChanged">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            (3) Balance of Printing Security
                        </td>
                        <td>
                            Rs.</td>
                        <td align="left" colspan="3">
                            &nbsp;
                            <asp:TextBox ID="txtBalPrintingSec1" runat="server" CssClass="txtbox reqirerd" 
                                MaxLength="8" onkeypress="javascript:tbx_fnSignedNumeric(event, this);" 
                                AutoPostBack="True" ontextchanged="txtBalPrintingSec1_TextChanged">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            (4)...............................................
                        </td>
                        <td>
                            Rs.</td>
                        <td align="left" colspan="3">
                            &nbsp;
                            <asp:TextBox ID="txtBalPrintingSec2" runat="server" CssClass="txtbox reqirerd" 
                                MaxLength="8" onkeypress="javascript:tbx_fnSignedNumeric(event, this);" 
                                AutoPostBack="True" ontextchanged="txtBalPrintingSec2_TextChanged">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            (5)...............................................
                        </td>
                        <td>
                            Rs.</td>
                        <td align="left" colspan="3">
                            &nbsp;
                            <asp:TextBox ID="txtBalPrintingSec3" runat="server" CssClass="txtbox reqirerd" 
                                MaxLength="8" onkeypress="javascript:tbx_fnSignedNumeric(event, this);" 
                                AutoPostBack="True" ontextchanged="txtBalPrintingSec3_TextChanged">0</asp:TextBox>
                        </td>
                    </tr>
                       <tr>
                        <td>
                           <div style="float:right">Total (A) </div>
                        </td>
                        <td>
                            Rs.</td>
                        <td align="left" colspan="3">
                            &nbsp;
                            <asp:TextBox ID="txtTotalA" runat="server" CssClass="txtbox reqirerd" 
                                MaxLength="8" onkeypress="javascript:tbx_fnSignedNumeric(event, this);" 
                                AutoPostBack="True" ontextchanged="txtTotalA_TextChanged">0</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;</td>
                        <td align="left" colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel runat="server" ID="Panel2" GroupingText="DEDUCTIONS">
                <table width="100%">
                    <tr>
                        <td colspan="5">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            (1) Penalty for substandard bad Printing
                        </td>
                        <td>
                            Rs.</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtPntySubPnting" CssClass="txtbox reqirerd" MaxLength="8"
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' 
                                AutoPostBack="True" ontextchanged="txtPntySubPnting_TextChanged">0</asp:TextBox>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            (2) Penalty for mistakes
                        </td>
                        <td>
                            Rs.</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtPntyMistacks" CssClass="txtbox reqirerd"
                                MaxLength="8" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' 
                                AutoPostBack="True" ontextchanged="txtPntyMistacks_TextChanged">0</asp:TextBox>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            (3) Penalty for delay submission of Proof
                        </td>
                        <td>
                            Rs.</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtPntyDlySubPof" CssClass="txtbox reqirerd" MaxLength="8"
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' 
                                AutoPostBack="True" ontextchanged="txtPntyDlySubPof_TextChanged">0</asp:TextBox>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            (4) Penalty for delay supply of books
                        </td>
                        <td>
                            Rs.</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtPntyDlySuplyBook" CssClass="txtbox reqirerd" MaxLength="8"
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' 
                                AutoPostBack="True" ontextchanged="txtPntyDlySuplyBook_TextChanged">0</asp:TextBox>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            (5) Depot Expenditure on behalf of Printer
                        </td>
                        <td>
                            Rs.</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtDepotExpenditure" CssClass="txtbox reqirerd"
                                MaxLength="8" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' 
                                AutoPostBack="True" ontextchanged="txtDepotExpenditure_TextChanged">0</asp:TextBox>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            (6) Cost of not Salable books
                        </td>
                        <td>
                            Rs.</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtCostSalableBook" CssClass="txtbox reqirerd"
                                MaxLength="8" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' 
                                AutoPostBack="True" ontextchanged="txtCostSalableBook_TextChanged">0</asp:TextBox>
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
                            (7) Deductions against balance paper with printer
                        </td>
                        <td>
                            Rs.</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtDeduAgainstBal" CssClass="txtbox reqirerd" MaxLength="8"
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' 
                                AutoPostBack="True" ontextchanged="txtDeduAgainstBal_TextChanged">0</asp:TextBox>
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
                            (8) 2% Income Tax On Rs
                        </td>
                        <td>
                            Rs.</td>
                        <td>
                            <asp:TextBox runat="server" ID="txt2IncomeTax" CssClass="txtbox reqirerd" MaxLength="8"
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' 
                                AutoPostBack="True" ontextchanged="txt2IncomeTax_TextChanged">0</asp:TextBox>
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
                            (9) Transportation Charges on behalf of printer
                        </td>
                        <td>
                            Rs.</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtTransportationCharges" 
                                CssClass="txtbox reqirerd" MaxLength="8"
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' 
                                AutoPostBack="True" ontextchanged="txtTransportationCharges_TextChanged">0</asp:TextBox>
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
                            (10) Interest on paper cost security
                        </td>
                        <td>
                            Rs.</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtInterestPprCstSec" 
                                CssClass="txtbox reqirerd" MaxLength="8"
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' 
                                AutoPostBack="True" ontextchanged="txtInterestPprCstSec_TextChanged">0</asp:TextBox>
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
                            (11) Other dedution if any
                        </td>
                        <td>
                            Rs.</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtOtherDedu" CssClass="txtbox reqirerd" MaxLength="8"
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' 
                                AutoPostBack="True" ontextchanged="txtOtherDedu_TextChanged">0</asp:TextBox>
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
                            (12) 2% witheld Regarding 100% Printing Charges
                        </td>
                        <td>
                            Rs.</td>
                        <td>
                            <asp:TextBox runat="server" ID="txt2WitheldReg" CssClass="txtbox reqirerd" MaxLength="8"
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' 
                                AutoPostBack="True" ontextchanged="txt2WitheldReg_TextChanged">0</asp:TextBox>
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
                           <div style="float:right">  Total (B)</div>
                        </td>
                        <td>
                            Rs.</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtTotalB" CssClass="txtbox reqirerd" MaxLength="8"
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' 
                                AutoPostBack="True" Enabled="False" EnableTheming="True" 
                                ontextchanged="txtTotalB_TextChanged">0</asp:TextBox>
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
                         <b>   Net Payable(A-B)</b>
                        </td>
                        <td>
                            Rs.</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtNetPay" CssClass="txtbox reqirerd" MaxLength="8"
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' Enabled="False">0</asp:TextBox>
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
                            <br />
                            Sr. MANAGER(PTG)
                            <br />
                            <br />
                            FINANCE
                        </td>
                        <td>
                            &nbsp;</td>
                        <td colspan="2">
                            Sr. MANAGER
                        </td>
                        <td>
                           
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            Passed for payment of 
                            Rs.....................................................................(Rupees 
                            .......................................................................)
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5" align="right" >
                          <div style="float:right;padding-right:200px;">MANAGING DIRECTOR</div>  
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Button runat="server" ID="btnForward" CssClass="btn" Text="Save " OnClientClick="return ValidateAllTextForm();"
                OnClick="btnForward_Click" />
        </asp:Panel>
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
