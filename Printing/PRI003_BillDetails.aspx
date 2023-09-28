 <%@ Page Title="Bill Details" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="PRI003_BillDetails.aspx.cs" Inherits="Printing_PRI003_BillDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
    <asp:HiddenField ID="HDNPaperTotal" runat="server" />
    <asp:HiddenField ID="HDNCoverTotal" runat="server" />
     <asp:HiddenField ID="HDNRowIndex" runat="server" />
                             <asp:HiddenField ID="HDN_Rate" runat="server" />
                             <asp:HiddenField ID="HDN_TitleName" runat="server" />
                            <asp:HiddenField ID="HDNBillDetailID_I" runat="server" />
                             <asp:HiddenField ID="HDN_PriTranID" runat="server" />

    <div class="portlet-header ui-widget-header">
        &#2348;&#2367;&#2354; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;</div>
    
    <div class="portlet-content">
        <asp:Panel runat="server" ID="pnlMain">
            <asp:Panel runat="server" ID="pnlBillDetail" GroupingText="Printer Bill Details"
                Width="1200px">
                <table width="100%">
                    <tr>
                        <td class="auto-style2">
                            Academic Year</td>
                        <td class="auto-style2">
                            <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox" 
                                onselectedindexchanged="DdlACYear_SelectedIndexChanged">
                                <asp:ListItem>..Select..</asp:ListItem>
                                <asp:ListItem>2012-13</asp:ListItem>
                                <asp:ListItem>2013-14</asp:ListItem>
                                <asp:ListItem>2014-15</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="auto-style2">
                            Add&nbsp; Challan
                            <br />
                            Received upto Date </td>
                        <td class="auto-style2">
                            <asp:TextBox ID="txtChalanrecDate" runat="server" CssClass="txtbox reqirerd" MaxLength="10" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtChalanrecDate_CalendarExtender" runat="server" Format="dd/MM/yyyy" TargetControlID="txtChalanrecDate">
                            </cc1:CalendarExtender>
                            <asp:HiddenField ID="hdngst" runat="server" Value="0" />
                              <asp:HiddenField ID="hdngst_out" runat="server" Value="0" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Name of the Printer</td>
                        <td>
                            <asp:DropDownList ID="ddlPrinter" runat="server" AutoPostBack="True" CssClass="txtbox reqirerd" OnInit="ddlPrinter_Init" OnSelectedIndexChanged="ddlPrinter_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>Bill No </td>
                        <td>
                            <asp:TextBox ID="txtBillNo" runat="server" CssClass="txtbox reqirerd" MaxLength="10" onkeypress="tbx_fnAlphaNumericOnly(event, this);" Width="166px"></asp:TextBox>
                        </td>
                        <td>Bill Date </td>
                        <td>&nbsp;<asp:TextBox ID="txtBillDate" runat="server" CssClass="txtbox reqirerd" MaxLength="10" onkeypress="tbx_fnAlphaNumericOnly(event, this);" AutoPostBack="True" OnTextChanged="txtBillDate_TextChanged"></asp:TextBox>
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
                            (1) Paper supplied size 84cm
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td>
                              <asp:LinkButton ID="lnkBill" runat="server" OnClick="lnBtnViewIndent_Click" Text='(i) Total Paper supplied(Ton)'></asp:LinkButton>
                            
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
                            <%if (ddlPrinter.SelectedValue != "" && txtChalanrecDate.Text !="") %>
                            <%{%>
                         <a href="../Printing/TentyFiveperReportforBill.aspx?ID=<%=ddlPrinter.SelectedValue%>&dtfrom=01/12/2018&dtto=<%=Convert.ToDateTime(txtChalanrecDate.Text, cult).ToString("dd/MM/yyyy")%>&myear=<%=DdlACYear.SelectedValue%> " target="_blank" class="auto-style3"> <span class="auto-style4">&#2408;&#2411;% &#2327;&#2339;&#2344;&#2366; &#2352;&#2360;&#2368;&#2342; &#2342;&#2375;&#2326;&#2375;</span></a>  
                            <%}%>
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
                                     <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                           <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="True" OnCheckedChanged="chkSelect_CheckedChanged"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>                                            
                                            <asp:LinkButton ID="lnktitleBill" runat="server" OnClick="lnktitleBill_Click" Text='<%# Eval("TitleHindi_V")%>'></asp:LinkButton>
                                            <asp:Label ID="lblBillDetID_I" runat="server" Text='<%# Eval("BillDetID_I")%>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblTitleID_I" runat="server" Text='<%# Eval("TitleID_I")%>' Visible="false"></asp:Label>
                                            <asp:HiddenField ID="hdPriTransID" runat="server" Value='<%# Eval("PriTransID")%>'></asp:HiddenField>                                           
                                            <asp:HiddenField ID="hdChalanNo" runat="server" Value='<%#Eval("ChalanNo")%>'></asp:HiddenField>
                                            <asp:HiddenField ID="hdnIsChecked" runat="server" Value='<%#Eval("IsChecked") != null?Eval("IsChecked"):0%>'></asp:HiddenField>  
                                            <asp:HiddenField ID="hdnGrpno_V" runat="server" Value='<%#Eval("Grpno_V")%>'></asp:HiddenField>                                       
                                            <asp:HiddenField ID="hdPriTransID_All" runat="server" Value='<%#Eval("PriTransID_All")%>'></asp:HiddenField>   
                                            <asp:HiddenField ID="HiddenBookType" runat="server" Value='<%#Eval("Booktype")%>'></asp:HiddenField>                                     
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalNoBook" runat="server" Text='<%# Bind("TotalNoOfBooks")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rate">
                                        <ItemTemplate>
                                             <asp:TextBox ID="lblRate_N" CssClass="txtbox" runat="server" AutoPostBack="true"  OnTextChanged="txtAmount1_TextChanged"
                                                MaxLength="8" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' Text='<%#Eval("Rate_N") %>' Width="100px"></asp:TextBox>
                                            <%--<asp:Label ID="lblRate_N" runat="server" Text='<%# Eval("Rate_N")%>'></asp:Label>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Pages">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPages_N" runat="server" Text='<%#Eval("Pages_N")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="No of Library Books ">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtLibBook" CssClass="txtbox" runat="server" AutoPostBack="true"  OnTextChanged="txtLibBook_TextChanged"
                                                MaxLength="8" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' Text='<%#Eval("LibraryBook") %>' Width="100px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Blank Pages(per Book)">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtBlankPages" CssClass="txtbox" runat="server" AutoPostBack="true"  OnTextChanged="txtBlankPages_TextChanged"
                                                MaxLength="8" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' Text='<%#Eval("BlankPages") %>' Width="100px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Payable Pages">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPayablePages" runat="server" Text='<%#Eval("Pages_N")%>' Width="100px"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Total Blank Pages">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalBlankPages_N" runat="server" Text='<%# Eval("TotBlankPage")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAmount" runat="server"  Text='<%# Eval("Amount_N")  %>' DataFormatString="{0:0.00}"  ></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Paper consumption with wastage in Tons">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtPapterConsumption" CssClass="txtbox" runat="server" MaxLength="8"
                                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' Text='<%#Eval("PaperConsum_Wastage_N") %>' Width="100px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cover Paper consumption with wastage in Sheets">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCoverPapterConsumption" CssClass="txtbox" runat="server" MaxLength="8"
                                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' Text='<%#Eval("CoverPaperConsum_Wastage_N") %>' Width="100px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Bad Printing Penalty(%)">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtBadPrintPen_grd" CssClass="txtbox" runat="server" MaxLength="8" AutoPostBack="true"
                                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' Width="100px" Text='<%#Eval("BadPrintPenPercent") %>'
                                                OnTextChanged="txtBadPrinPercent_TextChanged">
                                            </asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
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
                        <td>
                           <b> GST Amount</b>
                        </td>
                       
                    </tr>

                      <tr>
                        <td>                             
                           <asp:RadioButton ID="rdOut" runat="server" GroupName="rd" Text="Outside M.P. Printer" onclick="javascript:chkgst();" AutoPostBack="True" OnCheckedChanged="rdOut_CheckedChanged" />&nbsp;&nbsp;
                            <asp:RadioButton ID="rdIn" runat="server" GroupName="rd" Text="Within M.P. Printer" Checked="true" onclick="javascript:chkgst();" OnCheckedChanged="rdIn_CheckedChanged" AutoPostBack="True" />
                        </td>
                        <td>
                           <div id="dvOutgst" runat="server" clientidmode="Static" style="line-height:1.5em;display:none;">IGST (5%) :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lblOutgst" runat="server"></asp:Label></div>
                            <div id="dvIngst_s" runat="server" clientidmode="Static" style="line-height:1.5em;">CGST (2.5%) :&nbsp;&nbsp;&nbsp; <asp:Label ID="lblIngst_s" runat="server"></asp:Label></div>
                           <div id="dvIngst_c" runat="server" clientidmode="Static" style="line-height:1.5em;">SGST (2.5%) : &nbsp;&nbsp;&nbsp; <asp:Label ID="lblIngst_c" runat="server"></asp:Label></div>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
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
            <asp:Button ID="Button1" runat="server" Height="30px" OnClick="Button1_Click" Text="View Interest Calculation sheet" Width="227px" OnClientClick="NewWindow();" />
            <asp:Button ID="Button2" runat="server" Height="30px" OnClick="Button2_Click1" OnClientClick="NewWindow();" Text="Deduction agst short size of Books " Width="227px" />
            <asp:Button ID="Button3" runat="server" Height="30px" OnClick="Button3_Click1" OnClientClick="NewWindow();" Text="Penalty for Delay Supply of Books " Width="227px" />
            <asp:Button ID="Button4" runat="server" Height="30px" OnClick="Button4_Click1" Text="Penalty for Bad Printing/Printing Mistakes" Width="255px" />
            <asp:Button ID="Button5" runat="server" Height="30px" OnClick="Button5_Click1" Visible="false" Text="Export Interest Calculation to Excel" />
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
                                ontextchanged="txt2PerInComeTAX_TextChanged" Enabled="true">0</asp:TextBox>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;<asp:Label ID="lblTDSGST" runat="server" Text="(2-a) Withheld 1% regarding SGST TDS Rs. "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txt2PerTDSGST" runat="server" AutoPostBack="True" CssClass="txtbox reqirerd" Enabled="true" MaxLength="8" onkeypress="javascript:tbx_fnSignedNumeric(event, this);" ontextchanged="txt2PerInComeTAX_TextChanged">0</asp:TextBox>
                        </td>
                        <td colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;<asp:Label ID="lblTDSCGST" runat="server" Text="(b) Withheld 1% regarding CGST TDS&nbsp; Rs. "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txt2PerTDSCGST" runat="server" AutoPostBack="True" CssClass="txtbox reqirerd" Enabled="true" MaxLength="8" onkeypress="javascript:tbx_fnSignedNumeric(event, this);" ontextchanged="txt2PerInComeTAX_TextChanged">0</asp:TextBox>
                        </td>
                        <td colspan="2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>(3) Deduction against paper security </td>
                        <td>
                            <asp:TextBox ID="txtDeductionPaperSecurity" runat="server" AutoPostBack="True" CssClass="txtbox reqirerd" MaxLength="8" onkeypress="javascript:tbx_fnSignedNumeric(event, this);" ontextchanged="txtDeductionPaperSecurity_TextChanged">0</asp:TextBox>
                        </td>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td>
                            (4) Depot Expenditure on behalf of Printer
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
                        <td class="auto-style1">
                            (5) Interest on Paper
                             
                        </td>
                        <td class="auto-style1">
                            <asp:TextBox runat="server" ID="txtPaperInterest" CssClass="txtbox reqirerd" MaxLength="8"
                                
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' AutoPostBack="True" 
                                ontextchanged="txtPaperInterest_TextChanged">0</asp:TextBox>
                        </td>
                        <td colspan="2" class="auto-style1">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            (6) Penalty for Delay supply of Books
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
                            (7) Deduction of Paper cost of against short size of Books
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
                            (8) Bad Printing
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtBadPrinting" CssClass="txtbox reqirerd"
                                 MaxLength="8" 
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' AutoPostBack="True" 
                                ontextchanged="txtBadPrinting_TextChanged">0</asp:TextBox>
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
                            (9) Printing Mistakes
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtPrintingMistakes" CssClass="txtbox reqirerd"
                                 MaxLength="8" 
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' AutoPostBack="True" 
                                ontextchanged="txtPrintingMistakes_TextChanged">0</asp:TextBox>
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
                            (10) Lamination
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtLamination" CssClass="txtbox reqirerd"
                                 MaxLength="8" 
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' AutoPostBack="True" 
                                ontextchanged="txtLamination_TextChanged">0</asp:TextBox>
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
                            (11) Perfect Binding
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtPerfectBinding" CssClass="txtbox reqirerd"
                                 MaxLength="8" 
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' AutoPostBack="True" 
                                ontextchanged="txtPerfectBinding_TextChanged">0</asp:TextBox>
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
                            (12) Loose Bundle Pack
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtLooseBundlePack" CssClass="txtbox reqirerd"
                                 MaxLength="8" 
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' AutoPostBack="True" 
                                ontextchanged="txtLooseBundlePack_TextChanged">0</asp:TextBox>
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
                            (13) Transportation/Delievery charges
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtTransportationDelvry" CssClass="txtbox reqirerd"
                                 MaxLength="8" 
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' AutoPostBack="True" 
                                ontextchanged="txtTransportationDelvry_TextChanged">0</asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>

                     <tr>
                        <td style="vertical-align:middle;">
                            (14) Other Deduction : Description
                             <div style="margin-left:20px;text-align:left;padding-top:8px">
                                 <asp:TextBox runat="server" ID="txtOtherDedDescription" TextMode="MultiLine" CssClass="txtbox"></asp:TextBox>
                             </div>
                        </td>
                        <td>
                          <asp:TextBox runat="server" ID="txtOtherDedAmt" CssClass="txtbox reqirerd" MaxLength="8" 
                                ontextchanged="txtOtherDedAmt_TextChanged" 
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' AutoPostBack="True">0</asp:TextBox>
                        </td>
                        <td style="vertical-align:middle;">
                            
                        </td>
                        <td style="vertical-align:middle;">
                            
                        </td>                    </tr>

                 

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

                    <tr>
                        <td>
                        </td>
                        <td>
                           Amount return to Printer
                        </td>
                        <td>
                            Rs.
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtAmtReturnToPrinter" CssClass="txtbox reqirerd" MaxLength="8"
                                onkeypress='javascript:tbx_fnSignedNumeric(event, this);' OnTextChanged="txtAmtReturnToPrinter_TextChanged">0</asp:TextBox>
                        </td>
                    </tr>

                      <tr style="display:none;">
                        <td>
                           <b> GST Amount</b>
                        </td>
                        <td>
                           <b>Rs.</b> <asp:Label runat="server" ID="lblGSTAmt" Font-Bold="true">0</asp:Label>
                            <span style="font-size:13px;font-family:Calibri;margin-left:4px;">(Depot Expenditure + Net payable) x 5%</span>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
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

                     <tr>
                        <td>
                            (d) GST Rs.
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtGST" CssClass="txtbox reqirerd"
                                MaxLength="8" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' Enabled="false">0</asp:TextBox>
                        </td>
                         </tr>

                       <tr>
                           <td>(e)Amount of SD return to Printer</td>
                           <td>
                               <asp:TextBox ID="txtAmtReturnToPrinter0" runat="server" CssClass="txtbox reqirerd" MaxLength="8" onkeypress="javascript:tbx_fnSignedNumeric(event, this);">0</asp:TextBox>
                           </td>
                    </tr>

                       <tr>
                         <td>
                             (f) Total Payable Amount including GST (c + d + e) Rs.
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtTotalPayableWithGST" CssClass="txtbox reqirerd"
                                MaxLength="8" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' Enabled="false">0</asp:TextBox>
                        </td>

                    </tr>
                </table>
            </asp:Panel>
            <asp:Button runat="server" ID="btnForward" CssClass="btn" Text="Save " OnClientClick="return ValidateAllTextForm();"
                OnClick="btnForward_Click" />
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack11_Click" CssClass="btn" />
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

        <asp:Panel runat="server" ID="pnlChequeIssue" style="font-size:13px;" GroupingText="Bank Details" Width="1200px" CssClass="PanelPadding" Visible="false">
                <table>
                     <tr>
                        <td>
                            (a) Bank Name
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtBankName" CssClass="txtbox reqirerd" MaxLength="200"></asp:TextBox>
                        </td>
                    </tr>

                       <tr>
                        <td>
                            (b) Cheque/DD No.
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtChequeDDNo" CssClass="txtbox reqirerd" MaxLength="12"></asp:TextBox>
                        </td>
                    </tr>

                     <tr>
                        <td>
                            (c) Cheque Date
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtChequeDate" CssClass="txtbox reqirerd"></asp:TextBox>
                             <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtChequeDate">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            (d) Cheque Amount of the Bill Rs.
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtCheckAmount" CssClass="txtbox reqirerd" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'>
                            </asp:TextBox>
                        </td>
                    </tr>
                                    
                     <tr>
                        <td>
                            (e) Remark
                        </td>
                        <td>
                             <asp:TextBox runat="server" ID="txtCheckRemark" CssClass="txtbox" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
                        </td>
                    </tr>
                </table>
              </asp:Panel>
    </div>

                            <div id="fadeDiv" runat="server" class="modalBackground" style="display: none">
    </div>


                                                      <div id="MessagesGroup" style="display: none; width: 80%; left: 5%" class="popupnew" runat="server" >
                                                          <asp:LinkButton ID="lnBtnBack" runat="server" OnClick="lnBtnBack_Click">&#2348;&#2306;&#2342; &#2325;&#2352;&#2375; ..</asp:LinkButton>
                                                          <div style="float:right;"><asp:LinkButton ID="LinkButton7" runat="server" OnClientClick="javascript:return PrintPanel_interest();">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;..</asp:LinkButton></div>
        <table width="100%">
            <tr>
                <td colspan="4" style="text-align: center;">Interest on Paper
                     <asp:Panel ID="Panel7" runat="server" Height="400px" ScrollBars="Both" > 
                     <asp:GridView ID="GrdBillIntrast" runat="server" AutoGenerateColumns="False"  CssClass="tab" ShowFooter="true"
                                AllowPaging="false" OnRowDataBound="GrdBillIntrast_RowDataBound">
                                <Columns>

                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/<br/>Sr.No.">
                                        <ItemTemplate>
                                             <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                         <FooterTemplate>
                                            <b>Total:</b>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    
                                    <%-- <asp:TemplateField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325;/<br/>  Title">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblTitle" Text='<%# Eval("TitleHindi_V") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    
                                    <asp:TemplateField HeaderText=" &#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352;/<br/>  ChalanNumber">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblChalanNo" Text='<%# Eval("ChalanNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    

                                    <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/<br/> Book Recieved date">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblTransactionDate_N" Text='<%# Eval("BookRecieveddate") %>'></asp:Label>
                                        </ItemTemplate>
                                       
                                    </asp:TemplateField>
                                     
                                    <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; /<br/>Total No Of Books">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblTotalNoOfBooks" Text='<%# Eval("TotalNoOfBooks") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalNoOfBooks_f" runat="server" Font-Bold="true"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2342;&#2367;&#2351;&#2375; &#2327;&#2351;&#2375; &#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; (&#2335;&#2344; &#2350;&#2375; ) /<br/> Paper Quantity (in Ton)">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblPaperQty_N" Text='<%# Eval("PaperQuantity") %>'></asp:Label>
                                        </ItemTemplate>
                                         <FooterTemplate>
                                            <asp:Label ID="lblPaperQty_N_f" runat="server" Font-Bold="true"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2348;&#2381;&#2351;&#2366;&#2332; /<br/>Intrest On Paper(&#8377;)">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblIntrestOnPaper" Text='<%# Eval("BillAmount") %>'></asp:Label>
                                        </ItemTemplate>
                                         <FooterTemplate>
                                            <asp:Label ID="lblIntrestOnPaper_f" runat="server" Font-Bold="true"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="&#2348;&#2381;&#2351;&#2366;&#2332; &#2327;&#2339;&#2344;&#2366; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; /<br/>Details" >
                                        <ItemTemplate>
                                            <asp:Label runat="server" Width="300px" ID="lblDetailsAll" Text='<%# Eval("Details") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />

                            </asp:GridView>
                         </asp:Panel>
                </td>
            </tr>
        </table>
       
  

                                                      </div>

                            <div id="Div2" runat="server" class="modalBackground" style="display: none">
    </div>
                            
   <div id="Div1" style="display: none; width: 80%; left: 5%" class="popupnew" runat="server" >
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="lnBtnBack_Click">&#2348;&#2306;&#2342; &#2325;&#2352;&#2375; ..</asp:LinkButton>
       <div style="float:right;"><asp:LinkButton ID="lnkPriShortbook" runat="server" OnClientClick="javascript:return PrintPanel_agstshortbook();">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;..</asp:LinkButton></div>
      
                                 <asp:Panel ID="Panel3" runat="server" Height="400px" ScrollBars="Both" > 
        <table width="100%">
            <tr>
                <td colspan="4" style="text-align: left"> Deduction Agst Short Size of Books
                     <asp:GridView ID="GridBooksizePenalty" runat="server" AutoGenerateColumns="False"  CssClass="tab"  
                                AllowPaging="false">
                                <Columns>

                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/<br/>Sr.No. 1">
                                        <ItemTemplate>
                                             <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText=" &#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352;/<br/>  &#2344;&#2360;&#2381;&#2340;&#2367;  &#2346;&#2371;&#2359;&#2381;&#2336;  &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; <br>2">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lbl1" Text=' '></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText=" &#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352;/<br/>  &#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350;<br>3">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblChalanNo" Text='<%# Eval("depo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    

                                    <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; <br>4">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblTransactionDate_N" Text='<%# Eval("TitleHindi_V") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     
                                    <asp:TemplateField HeaderText="&#2346;&#2371;&#2359;&#2381;&#2336; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; <br> 5">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblTotalNoOfBooks" Text='<%# Eval("Pages_N") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;  <br> 6">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblPaperQty_N" Text='<%# Eval("ReceivedBook") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2344;&#2367;&#2352;&#2381;&#2343;&#2366;&#2352;&#2367;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366;  &#2310;&#2325;&#2366;&#2352; c.m.  <br> 7">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblIntrestOnPaper" Text='<%# Eval("DefaultArea") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2354;&#2350;&#2381;&#2348;&#2366;&#2312;  <br> 8 " >
                                        <ItemTemplate>
                                            <asp:Label runat="server" Width="200px" ID="lblDetailsAll" Text='<%# Eval("RecLength") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2330;&#2380;&#2396;&#2366;&#2312;  <br> 9" >
                                        <ItemTemplate>
                                            <asp:Label runat="server" Width="200px" ID="lblDetailsAll" Text='<%# Eval("RecWidth") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="&#2325;&#2381;&#2359;&#2375;&#2340;&#2381;&#2352;&#2347;&#2354;  <br> 10" >
                                        <ItemTemplate>
                                            <asp:Label runat="server" Width="200px" ID="lblDetailsAll" Text='<%# Eval("bookArea") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="&#2309;&#2306;&#2340;&#2352;  <br> 11" >
                                        <ItemTemplate>
                                            <asp:Label runat="server" Width="200px" ID="lblDetailsAll" Text='<%# Eval("C7_C10") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2346;&#2375;&#2346;&#2352; &#2325;&#2306;&#2332;&#2350;&#2381;&#2358;&#2344;  <br> 12" >
                                        <ItemTemplate>
                                            <asp:Label runat="server" Width="200px" ID="lblDetailsAll" Text='<%# Eval("totPaperCon") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2309;&#2306;&#2340;&#2352; &#2325;&#2366; &#2346;&#2375;&#2346;&#2352; &#2325;&#2306;&#2332;&#2350;&#2381;&#2358;&#2344;  <br> 13" >
                                        <ItemTemplate>
                                            <asp:Label runat="server" Width="200px" ID="lblDetailsAll" Text='<%# Eval("conQty") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="&#2352;&#2366;&#2358;&#2367;  <br> 14" >
                                        <ItemTemplate>
                                            <asp:Label runat="server" Width="200px" ID="lblDetailsAll" Text='<%# Eval("Amount") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />

                            </asp:GridView>
                </td>
            </tr>
        </table> 
                                     </asp:Panel>
        </div>

        <div id="Div3" style="display: none; width: 80%; left: 5%" class="popupnew" runat="server" >
                                 <asp:Panel ID="Panel4" runat="server"  Height="400px" ScrollBars="Both" > 
                                      <asp:LinkButton ID="LinkButton2" runat="server" OnClick="lnBtnBack_Click">&#2348;&#2306;&#2342; &#2325;&#2352;&#2375; ..</asp:LinkButton>
                                     <div style="float:right;"><asp:LinkButton ID="lnkPrint22" runat="server" OnClientClick="javascript:return PrintPanel_delay();">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;..</asp:LinkButton></div>
        <table width="100%">
            <tr>
                <td colspan="4" style="text-align: center"><b> Penalty for Delay supply of Books</b>
                    <div id="ExportDiv2">
                     <asp:GridView ID="GrdDelayPen" runat="server" AutoGenerateColumns="False"  CssClass="tab" OnRowDataBound="GrdDelayPen_RowDataBound"  
                                AllowPaging="false" ShowFooter="true">
                                <Columns>

                                    <asp:TemplateField HeaderText="Sr.No. <br/ 1">
                                        <ItemTemplate>
                                             <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <b>Total:</b>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Name of Book <br>2">
                                        <ItemTemplate>            
                                            <asp:Label runat="server" ID="lbl1" Text='<%# Eval("TitleHindi_V") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                      <asp:TemplateField HeaderText="Tender Days <br>3">
                                        <ItemTemplate>            
                                            <asp:Label runat="server" ID="lblTenderDays" Text='<%# Eval("TenderDays") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText=" Print Order Date  <br>4" >
                                        <ItemTemplate  > <%# Eval("PrintDate") %>     </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Vitran Date   <br>5" >
                                        <ItemTemplate  > <%# Eval("VitDate") %>     </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText=" Due Date 50%-100% <br>6" >
                                        <ItemTemplate  > <%# Eval("DateFifty") %>     '-'    <%# Eval("Datehun") %>   </ItemTemplate>
                                    </asp:TemplateField>
                                    

                                    <asp:TemplateField HeaderText=" Reason <br>7">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblTransactionDate_N" Text=' '></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                     
                                    <asp:TemplateField HeaderText="Received Qty(Books) <br> 8">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblTotalNoOfBooks" Text='<%# Eval("BookReceived") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotBook_f" runat="server" Font-Bold="true"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Received Date  <br>  9">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblPaperQty_N" Text='<%# Eval("RecDate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" Delay Days <br> 10">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblIntrestOnPaper" Text='<%# Eval("DelayDay") %>'></asp:Label>
                                        </ItemTemplate>
                                         <FooterTemplate>
                                            <asp:Label ID="lblIntrestOnPaper_f" runat="server" Font-Bold="true"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText=" Total % of Penalty <br> 11" >
                                        <ItemTemplate>
                                            <asp:Label runat="server" Width="200px" ID="lblDetailsAll" Text=' '></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="100% Printing Charges <br> 12" >
                                        <ItemTemplate>
                                            <asp:Label runat="server" Width="200px" ID="lblDetailsAll_hunamt" Text='<%# Eval("HunAmount") %>'></asp:Label>
                                        </ItemTemplate>
                                         <FooterTemplate>
                                            <asp:Label ID="lblTotHunAmount_f" runat="server" Font-Bold="true"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Amount of Penalty <br> 13" >
                                        <ItemTemplate>
                                            <asp:Label runat="server" Width="200px" ID="lblDetailsAll_penamt" Text='<%# Eval("PenaltyAmount") %>'></asp:Label>
                                        </ItemTemplate>
                                           <FooterTemplate>
                                            <asp:Label ID="lblDetailsAll_penamt_f" runat="server" Font-Bold="true"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                     
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />

                            </asp:GridView>
                        </div>
                </td>
            </tr>
        </table>

       
 
                                     </asp:Panel>
                                                      </div>

 <div id="fadeDiv11" runat="server" class="modalBackground" style="display: none">
    </div>
    <div id="Messages11" style="display:none; width: 80%;left:5%;" class="popupnew" runat="server">
        <table width="100%">
            <tr>
               <td>
                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="lnBtnBack11_Click">&#2348;&#2306;&#2342; &#2325;&#2352;&#2375;&#2306;..</asp:LinkButton>
                   <div style="float:right;"><asp:LinkButton ID="lnkPrint11" runat="server" OnClientClick="javascript:return PrintPanel();">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;..</asp:LinkButton></div>
               </td>
               
            </tr>

            <tr>
                <td>
                    <div class="box" >
                        <div class="card-header">
                            <h2>
                                <span>Paper Issue Quantity Detail</span></h2>
                        </div>
                        <div class="table-responsive">
                                <center>
                            <asp:Panel ID="Panel5" runat="server" Height="400px" ScrollBars="Vertical">
                                <div id="ExportDiv1">
                                    <table width="100%">                                        
                                        <tr>
                                            <td colspan="4" align="center">
                                                <asp:Repeater ID="GrdViewIndentDetails" runat="server" OnItemDataBound="GrdViewIndentDetails_ItemDataBound">
                                                    <HeaderTemplate>
                                                        <table class="tab" border="1" style="border-collapse:collapse;">
                                                            <thead>
                                                                <tr>
                                                                    <th style="background-color:lightgrey;border-color:black;border-width:1px;border-style:solid;font-size:1em;"></th>
                                                                    <th style="background-color:lightgrey;border-color:black;border-width:1px;border-style:solid;font-size:1em;"></th>
                                                                     <th colspan="2" style="text-align:center;vertical-align:middle;background-color:lightgrey;border-color:black;border-width:1px;border-style:solid;font-size:1em;">
                                                                      Paper Qty(Ton)
                                                                    </th>
                                                                    <th colspan="2" style="text-align:center;vertical-align:middle;background-color:lightgrey;border-color:black;border-width:1px;border-style:solid;font-size:1em;">
                                                                        Cover Paper Qty(Sheet)
                                                                    </th>
                                                                </tr>
                                                                <tr>                                                                   
                                                                    <th style="background-color:lightgrey;border-color:black;border-width:1px;border-style:solid;font-size:1em;">&#2325;&#2381;&#2352;. / No.</th>
                                                                    <th rowspan="2" style="background-color:lightgrey;border-color:black;border-width:1px;border-style:solid;font-size:1em;">Challan Date</th>
                                                                    <th style="background-color:lightgrey;border-color:black;border-width:1px;border-style:solid;font-size:1em;">70 GSM</th>
                                                                    <th style="background-color:lightgrey;border-color:black;border-width:1px;border-style:solid;font-size:1em;">80 GSM</th>
                                                                    <th style="background-color:lightgrey;border-color:black;border-width:1px;border-style:solid;font-size:1em;">230 GSM</th>
                                                                    <th style="background-color:lightgrey;border-color:black;border-width:1px;border-style:solid;font-size:1em;">250 GSM</th>
                                                                    
                                                                </tr>
                                                            </thead>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tbody>
                                                            <tr>
                                                                <td style="border-color:black;border-width:1px;border-style:solid;font-size:1em;"><%# Container.ItemIndex +1 %></td>
                                                                <td style="border-color:black;border-width:1px;border-style:solid;font-size:1em;"><%#String.Format("{0:dd-MM-yyyy}",Eval("ChallanDate"))%></td>
                                                                <td style="border-color:black;border-width:1px;border-style:solid;font-size:1em;"><asp:Label ID="lblGSM70" runat="server" Text='<%#Eval("GSM70")%>'></asp:Label></td>
                                                                  <td style="border-color:black;border-width:1px;border-style:solid;font-size:1em;"><asp:Label ID="lblGSM80" runat="server" Text='<%#Eval("GSM80")%>'></asp:Label></td>
                                                                  <td style="border-color:black;border-width:1px;border-style:solid;font-size:1em;"><asp:Label ID="lblGSM230" runat="server" Text='<%#Eval("GSM230")%>'></asp:Label></td>
                                                                  <td style="border-color:black;border-width:1px;border-style:solid;font-size:1em;"><asp:Label ID="lblGSM250" runat="server" Text='<%#Eval("GSM250")%>'></asp:Label></td>
                                                            </tr>
                                                        </tbody>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <tr>
                                                            <td colspan="2" style="border-color:black;border-width:1px;border-style:solid;font-size:1em;font-weight:bold;">
                                                                  <div style="padding:0 0 5px 0">Total</div>
                                                            </td>
                                                            <td style="border-color:black;border-width:1px;border-style:solid;font-size:1em;font-weight:bold;">
                                                                 <div style="padding:0 0 5px 0;font-weight:bold;"><asp:Label ID="lbl70GSMPaperTotal" runat="server" /></div>
                                                            </td>
                                                               <td style="border-color:black;border-width:1px;border-style:solid;font-size:1em;font-weight:bold;">
                                                                 <div style="padding:0 0 5px 0;font-weight:bold;"><asp:Label ID="lbl80GSMPaperTotal" runat="server" /></div>
                                                            </td>
                                                            <td style="border-color:black;border-width:1px;border-style:solid;font-size:1em;font-weight:bold;">
                                                                 <div style="padding:0 0 5px 0;font-weight:bold;"><asp:Label ID="lbl230GSMCoverPaperTotal" runat="server" /></div>
                                                            </td>
                                                            <td style="border-color:black;border-width:1px;border-style:solid;font-size:1em;font-weight:bold;">
                                                                 <div style="padding:0 0 5px 0;font-weight:bold;"><asp:Label ID="lbl250GSMCoverPaperTotal" runat="server" /></div>
                                                            </td>
                                                        </tr>
                                                        </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>
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

     <div id="fadeDiv22" runat="server" class="modalBackground" style="display: none">
    </div>
    <div id="Messages22" style="display:none; width: 80%;left:5%;" class="popupnew" runat="server">
        <table width="100%">
            <tr>
               <td>
                <asp:LinkButton ID="LinkButton4" runat="server" OnClick="lnBtnBack22_Click">&#2348;&#2306;&#2342; &#2325;&#2352;&#2375;&#2306;..</asp:LinkButton>
               </td>
            </tr>

            <tr>
                <td>
                    <div class="box">
                        <div class="card-header">
                            <h2>
                                <span>Title wise Challan Details</span></h2>
                        </div>
                        <div class="table-responsive">
                                <center>
                            <asp:Panel ID="Panel6" runat="server" Height="400px" ScrollBars="Vertical">
                                
                                    <table width="100%">                                        
                                        <tr>
                                            <td colspan="4" align="center">
                    <asp:GridView ID="GrdChallantitlewiseChallans" runat="server" AutoGenerateColumns="False" 
                               CssClass="tab">
                               <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No." HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>.&nbsp;<asp:CheckBox ID="chkSelect" runat="server" Checked='<%#Convert.ToBoolean(Eval("IsChecked").ToString()=="1"?"True":"False")%>' />
                                                                                                           
                                                                                                                                                              
                                                 </ItemTemplate>
                                             </asp:TemplateField>                                    
                                                                    
                                 
                                    <asp:BoundField DataField="DepoName_V" HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; " HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black" />
                                 
                                    <asp:BoundField DataField="ChallanNo_V" 
                                        HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Chalan No."  
                                        HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black"/>

                                    <asp:BoundField DataField="ChallanDate" HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Chalan Date" 
                                        HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black"/>

                                    <%--<asp:BoundField DataField="BookType" HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; " HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black" />--%>

                                   <%--<asp:BoundField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Title Name" 
                                        DataField="TitleHindi_V" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" 
                                       FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  
                                       ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  
                                       HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black" />--%>


                                    <asp:TemplateField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Title Name"  HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" 
                                       FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  
                                       ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  
                                       HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                        <ItemTemplate>
                                            <%# Eval("TitleHindi_V")%>
                                        </ItemTemplate>                                       
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Quantity"  HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" 
                                       FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  
                                       ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  
                                       HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalNoBook" runat="server" Text='<%# Eval("NoOfBooks")%>'></asp:Label>
                                             <asp:HiddenField ID="hdPriTransID" runat="server" Value='<%#Eval("PriTransID")%>'></asp:HiddenField>
                                            <asp:HiddenField ID="hdLibraryBook" runat="server" Value='<%#Eval("LibraryBook")%>'></asp:HiddenField>
                                            <asp:HiddenField ID="hdBlankPages" runat="server" Value='<%#Eval("BlankPages")%>'></asp:HiddenField>
                                        </ItemTemplate>                                        
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Amount"  HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" 
                                       FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  
                                       ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  
                                       HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount_N")%>'></asp:Label>                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Paper consumption with wastage in Tons"  HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" 
                                       FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  
                                       ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  
                                       HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPapterConsumption" runat="server" Text='<%#Eval("PaperConsum_Wastage_N")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Cover Paper consumption with wastage in Sheets"  HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" 
                                       FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  
                                       ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  
                                       HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCoverPapterConsumption" runat="server" Text='<%#Eval("CoverPaperConsum_Wastage_N")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                               </Columns>
                                                           <PagerStyle CssClass="Gvpaging" />
                                              <EmptyDataRowStyle CssClass="GvEmptyText" />
                               <EmptyDataTemplate>
                                   Data Not Found............
                               </EmptyDataTemplate>
                           </asp:GridView>
                                            </td>
                                        </tr>

                                         <tr>
               <td colspan="4">
                <asp:Button ID="btnAddBill" runat="server" Text="Add in Bill" OnClick="btnAddBill_Click" CssClass="btn" />   
                  <%-- &nbsp;&nbsp;
                    <span>Total Quantity:</span><b><asp:Label ID="lblTotalQty" runat="server"></asp:Label></b> --%>                                  
               </td> 
                 <td>
                   
                </td>              
            </tr>

                                    </table>
                                
                            </asp:Panel>
                                </center>
                        </div>
                    </div>
                </td>
            </tr>
            
        </table>
    </div>

    
    <div id="dvPenltyBadPrtg" runat="server" class="modalBackground" style="display: none">
    </div>


                                                      <div id="dvPenPopup" style="display: none; width: 80%; left: 5%" class="popupnew" runat="server" >
                                                          <asp:LinkButton ID="LinkButton5" runat="server" OnClick="lnBtnBack_Click">&#2348;&#2306;&#2342; &#2325;&#2352;&#2375; ..</asp:LinkButton>
                                                          <div style="float:right;"><asp:LinkButton ID="LinkButton6" runat="server" OnClientClick="javascript:return PrintPanel_bad();">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;..</asp:LinkButton></div>
        <table width="100%">
            <tr>
                <td colspan="4" style="text-align: center;">Penalty for Bad Printing
                     <asp:Panel ID="Panel8" runat="server" Height="400px" ScrollBars="Both" > 
                     <asp:GridView ID="GrdPenltyBadPrtg" runat="server" AutoGenerateColumns="False" 
                            CssClass="tab" DataKeyNames="PenaltyID_I">
                            <Columns> 
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                  <ItemTemplate>
                                   <%# Container.DataItemIndex+1 %>
                                  </ItemTemplate>
                                </asp:TemplateField>   
                                 <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352;" DataField="NameofPress_V" />
                                <asp:BoundField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325;" DataField="TitleHindi_V" />
                                <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2330;&#2366;&#2352;&#2381;&#2332;(100%) / Printing Charge (100%)" DataField="PrintingChr100per_N" />
                             
                                <asp:BoundField HeaderText="&#2326;&#2352;&#2366;&#2348; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2325;&#2368; &#2346;&#2375;&#2344;&#2366;&#2354;&#2381;&#2335;&#2368; (% &#2350;&#2375;&#2306;) / Penalty for bad printing (in %)" DataField="Substandardbadprintingper_N" />
                                <asp:BoundField HeaderText="&#2326;&#2352;&#2366;&#2348; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2325;&#2368; &#2346;&#2375;&#2344;&#2366;&#2354;&#2381;&#2335;&#2368; (&#2352;&#2369;. &#2350;&#2375;&#2306;) / Penalty for bad printing (in Rs.)" DataField="BadPrintingAmount_N" />

                                <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2327;&#2354;&#2340;&#2367;&#2351;&#2379;&#2306; &#2350;&#2375;&#2306; &#2346;&#2375;&#2344;&#2366;&#2354;&#2381;&#2335;&#2368; (% &#2350;&#2375;&#2306;) / Penalty for Printing Mistakes (in %)" DataField="PrintMistakPer_N" />
                                <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2327;&#2354;&#2340;&#2367;&#2351;&#2379;&#2306; &#2350;&#2375;&#2306; &#2346;&#2375;&#2344;&#2366;&#2354;&#2381;&#2335;&#2368; (&#2352;&#2369;. &#2350;&#2375;&#2306;) / Penalty for Printing Mistakes (in Rs.)" DataField="MistakeAmount_N" />                                
                               
                                 <asp:BoundField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2325;&#2348; &#2340;&#2325; / Upto Challan Date" DataField="UptoChallandate_D"  DataFormatString="{0:dd/MM/yyyy}" />                                
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                         </asp:Panel>
                </td>
            </tr>
        </table>
       
  

                                                      </div>

 </ContentTemplate>
        <%-- <Triggers>
            <asp:PostBackTrigger ControlID="Button5" />
        </Triggers>--%>
</asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            height: 40px;
        }
        .auto-style2 {
            height: 42px;
        }
        .auto-style3 {
            color: #0000FF;
        }
        .auto-style4 {
            font-size: medium;
        }
    </style>

    <script type="text/javascript">
        var acy = '<%=DdlACYear.SelectedItem.Text%>';
        function NewWindow() {
            document.forms[0].target = "_blank";
        }

        function chkgst() {
            var txtgst = document.getElementById('<%=txtGST.ClientID%>');
            var hdngst = document.getElementById('<%=hdngst.ClientID%>');
            var hdngst_out = document.getElementById('<%=hdngst_out.ClientID%>');
            
            if (document.getElementById('<%=rdOut.ClientID%>').checked) {
                document.getElementById('dvOutgst').style.display = 'block';
                document.getElementById('dvIngst_c').style.display = 'none';
                document.getElementById('dvIngst_s').style.display = 'none';
                txtgst.value = hdngst_out.value;
            }
            else if (document.getElementById('<%=rdIn.ClientID%>').checked) {
                document.getElementById('dvOutgst').style.display = 'none';
                document.getElementById('dvIngst_c').style.display = 'block';
                document.getElementById('dvIngst_s').style.display = 'block';
                txtgst.value = hdngst.value;
            }
        }

        function PrintPanel() {
            var panel = document.getElementById("ExportDiv1");
            var det1 = '<div align="center" style="line-height:1.5em;"><strong>&#2350;&#2343;&#2381;&#2351;&#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;, &#2349;&#2379;&#2346;&#2366;&#2354; </strong> </div>  <div align="center" style="line-height:1.5em;"><strong>&#2360;&#2340;&#2381;&#2352; - '+acy+'</strong></div>';
            var det = '<div> <h2><span>Paper Issue Quantity Detail</span></h2></div>';
            var det3 =  '<div align="right" style="line-height:1.5em;">&#2350;.&#2346;&#2381;&#2352;.&#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;  &#2349;&#2379;&#2346;&#2366;&#2354; </div>';

            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('</head>'+det1+det+'<body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('<br><br>'+det3+'</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }

        function PrintPanel_delay() {
            var panel = document.getElementById("ExportDiv2");
            var det1 = '<div align="center" style="line-height:1.5em;"><strong>&#2350;&#2343;&#2381;&#2351;&#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;, &#2349;&#2379;&#2346;&#2366;&#2354; </strong> </div>  <div align="center" style="line-height:1.5em;"><strong>&#2360;&#2340;&#2381;&#2352; - ' + acy + '</strong></div>';
            var det = '<div> <h2><span>Penalty for Delay supply of Books</span></h2></div>';
            var det3 = '<div align="right" style="line-height:1.5em;">&#2350;.&#2346;&#2381;&#2352;.&#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;  &#2349;&#2379;&#2346;&#2366;&#2354; </div>';

            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('</head>' + det1 + det + '<body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('<br><br>' + det3 + '</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }

        function PrintPanel_bad() {
            var panel = document.getElementById("<%=Panel8.ClientID%>");
            var det1 = '<div align="center" style="line-height:1.5em;"><strong>&#2350;&#2343;&#2381;&#2351;&#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;, &#2349;&#2379;&#2346;&#2366;&#2354; </strong> </div>  <div align="center" style="line-height:1.5em;"><strong>&#2360;&#2340;&#2381;&#2352; - ' + acy + '</strong></div>';
            var det = '<div> <h2><span>Penalty for Bad Printing</span></h2></div>';
            var det3 = '<div align="right" style="line-height:1.5em;">&#2350;.&#2346;&#2381;&#2352;.&#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;  &#2349;&#2379;&#2346;&#2366;&#2354; </div>';

            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('</head>' + det1 + det + '<body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('<br><br>' + det3 + '</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }

        function PrintPanel_interest() {
            var panel = document.getElementById("<%=Panel7.ClientID%>");
            var det1 = '<div align="center" style="line-height:1.5em;"><strong>&#2350;&#2343;&#2381;&#2351;&#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;, &#2349;&#2379;&#2346;&#2366;&#2354; </strong> </div>  <div align="center" style="line-height:1.5em;"><strong>&#2360;&#2340;&#2381;&#2352; - ' + acy + '</strong></div>';
             var det = '<div> <h2><span>Interest on Paper</span></h2></div>';
             var det3 = '<div align="right" style="line-height:1.5em;">&#2350;.&#2346;&#2381;&#2352;.&#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;  &#2349;&#2379;&#2346;&#2366;&#2354; </div>';

             var printWindow = window.open('', '', 'height=400,width=800');
             printWindow.document.write('<html><head><title></title>');
             printWindow.document.write('</head>' + det1 + det + '<body >');
             printWindow.document.write(panel.innerHTML);
             printWindow.document.write('<br><br>' + det3 + '</body></html>');
             printWindow.document.close();
             setTimeout(function () {
                 printWindow.print();
             }, 500);
             return false;
        }

        function PrintPanel_agstshortbook() {
            var panel = document.getElementById("<%=Panel3.ClientID%>");
            var det1 = '<div align="center" style="line-height:1.5em;"><strong>&#2350;&#2343;&#2381;&#2351;&#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;, &#2349;&#2379;&#2346;&#2366;&#2354; </strong> </div>  <div align="center" style="line-height:1.5em;"><strong>&#2360;&#2340;&#2381;&#2352; - ' + acy + '</strong></div>';
             var det = '<div> <h2><span>Deduction Agst Short Size of Books</span></h2></div>';
             var det3 = '<div align="right" style="line-height:1.5em;">&#2350;.&#2346;&#2381;&#2352;.&#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;  &#2349;&#2379;&#2346;&#2366;&#2354; </div>';

             var printWindow = window.open('', '', 'height=400,width=800');
             printWindow.document.write('<html><head><title></title>');
             printWindow.document.write('</head>' + det1 + det + '<body >');
             printWindow.document.write(panel.innerHTML);
             printWindow.document.write('<br><br>' + det3 + '</body></html>');
             printWindow.document.close();
             setTimeout(function () {
                 printWindow.print();
             }, 500);
             return false;
         }
    </script>

    
          
                 
</asp:Content>

