<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RunningBillRept.aspx.cs" Inherits="RunningBillRept" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:Button ID="btnExport" runat="server" CssClass="btn" 
                            Text="Export to Excel" Visible="false"  />&nbsp;
                        <asp:Button ID="btnExportPDF" runat="server" CssClass="btn" 
                            OnClientClick="return PrintPanel();" Text=" Print"  />
                        
    
    <div>
        <div class="card-header">
            <h2>
                प्रिंटिंग रनिंग बिल
            </h2>
        </div>

         <div id="ExportDiv" runat="server" >

         <table width="100%">
             <tr ><td colspan="4"><div align="center" style="line-height:1.5em;"><strong>मध्यप्रदेश पाठ्य पुस्तक निगम, भोपाल </strong> </div> 
                  <div align="center" style="line-height:1.5em;"><strong>सत्र - <%=DdlACYear%>            
                  </strong>
              </div>
              </td> </tr>

            

             <tr><td colspan="4"><strong>&#2346;&#2381;&#2352;&#2340;&#2367;
             <br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%=NameofPress_V%>
              <br />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <%=FullAddress_V%>
              

                              </strong></td> </tr>

         </table>

         
            <%--<div style="width:100%;font-weight:bold;line-height:1.5em;">Printer Bill Details--%>
                <table width="99%">
                    <tr><td colspan="5" style="font-weight:bold;font-size:0.9em;">Printer Bill Details</td></tr>
                    <tr>
                        
                        <td>Bill No: </td>
                        <td>
                            <%=txtBillNo%>
                        </td>
                        <td>Bill Date: </td>
                        <td><%=txtBillDate%>
                        </td>

                        <td>Bill Upto Date: </td>
                        <td><%=txtuptodate%>
                        </td>
                    </tr>
                   
                </table>
           <%-- </div>--%>

      
                <table width="99%">
                    <tr><td colspan="4" style="font-weight:bold;font-size:0.9em;">Bill Description</td></tr>
                    <tr>
                        <td colspan="4">
                            (A) Payable Amount:
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
                              <asp:Literal ID="lnkBill" runat="server" Text='(i) Total Paper supplied(Ton):'></asp:Literal>
                            
                        </td>
                        <td>
                            <%=txtTotalPaperSupply%>
                        </td>
                        <td>
                            Total Cover Paper supplied:
                        </td>
                        <td>
                            <%=txtTotalCoverPaperSupply%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            (ii) Paper Security deposited by the printer Rs.:
                        </td>
                        <td>
                            <%=txtPaperSecurityDeposit%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            (iii) Paper Security reimbursed to the printer Rs.:
                        </td>
                        <td>
                           <%=txtPaperSecurityReimbursed%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            (iv) Balance paper Security for reimbursement Rs.:
                        </td>
                        <td>
                            <%=txtBalancePaperSecurityReimbursed%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 10px;">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4"> 
                           
                            (2) Printing charges, Paper & Cover paper consumptions:
                        </td>
                    </tr>
                  
                    <tr>
                        <td colspan="4">
                        <!--GrdPaperCoverAndPrintingChares-->
                            <asp:GridView runat="server" ID="GrdPaperCoverAndPrintingChares" AutoGenerateColumns="False"
                                CssClass="tab" EmptyDataText="Record Not Found." Width="99%" OnRowDataBound="GrdCover_RowDataBound" ShowFooter="true">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex +1 %></ItemTemplate>
                                        <FooterTemplate><b>Total:</b></FooterTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>                                            
                                            <%# Eval("TitleHindi_V")%>
                                           </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity">
                                        <ItemTemplate>                                            
                                            <%# Eval("TotalNoOfBooks")%>
                                        </ItemTemplate>
                                          <FooterTemplate>
                                            <asp:Label ID="TotalNoOfBooks_f" runat="server" Font-Bold="true"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rate">
                                        <ItemTemplate>
                                       <%# Eval("Rate_N")%>
                                        </ItemTemplate>
                                          <FooterTemplate>
                                            <asp:Label ID="Rate_f" runat="server" Font-Bold="true"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Pages">
                                        <ItemTemplate>
                                          <%# Eval("Pages_N")%>
                                        </ItemTemplate>
                                           <FooterTemplate>
                                            <asp:Label ID="Pages_N_f" runat="server" Font-Bold="true"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="No of Library Books ">
                                        <ItemTemplate>
                                           <%# Eval("LibraryBook")%>
                                        </ItemTemplate>
                                            <FooterTemplate>
                                            <asp:Label ID="LibraryBook_f" runat="server" Font-Bold="true"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Blank Pages(per Book)">
                                        <ItemTemplate>
                                         <%# Eval("BlankPages")%>
                                        </ItemTemplate>
                                         <FooterTemplate>
                                            <asp:Label ID="BlankPages_f" runat="server" Font-Bold="true"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Payable Pages">
                                        <ItemTemplate>
                                             <%--<%# Eval("Pages_N")%> | --%><%#fnGetval(Eval("BlankPages").ToString(),Eval("Pages_N").ToString())%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Total Blank Pages">
                                        <ItemTemplate>
                                           <%# Eval("TotBlankPage")%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="TotBlankPage_f" runat="server" Font-Bold="true"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Amount">
                                        <ItemTemplate>                                            
                                            <%#Eval("Amount_N")%>
                                        </ItemTemplate>
                                         <FooterTemplate>
                                            <asp:Label ID="Amount_N_f" runat="server" Font-Bold="true"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Paper consumption with wastage in Tons">
                                        <ItemTemplate>
                                           <%#Eval("PaperConsum_Wastage_N")%>
                                        </ItemTemplate>
                                          <FooterTemplate>
                                            <asp:Label ID="PaperConsum_Wastage_N_f" runat="server" Font-Bold="true"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cover Paper consumption with wastage in Sheets">
                                        <ItemTemplate>
                                           <%#Eval("CoverPaperConsum_Wastage_N")%>
                                        </ItemTemplate>
                                         <FooterTemplate>
                                            <asp:Label ID="CoverPaperConsum_Wastage_N_f" runat="server" Font-Bold="true"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Bad Ptg Penalty(%)">
                                        <ItemTemplate>
                                           <%#Eval("BadPrintPenPercent")%>
                                        </ItemTemplate>
                                         <FooterTemplate>
                                            <asp:Label ID="BadPrintPenPercent_f" runat="server" Font-Bold="true"></asp:Label>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Total 100% Printing Charges Rs.:
                        </td>
                        <td colspan="3">
                             <%=txtPrintingCharge%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            25% Printing Charges to be withheld Rs.:
                        </td>
                        <td colspan="3">
                             <%=txtPrintingCharge25Per%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            75% Printing Charges Payable Rs.:
                        </td>
                        <td colspan="3">
                           <%=txtPrintingCharge75Per%>
                        </td>
                    </tr>

                     <tr>
                        <td>
                           GST Amount:
                        </td>
                       
                    </tr>

                      <tr>
                        <td>                             
                          <asp:Literal ID="rdOut" runat="server" Text="Outside M.P. Printer"  />&nbsp;&nbsp;
                            <asp:Literal ID="rdIn" runat="server" Text="Within M.P. Printer" />
                            <asp:HiddenField ID="hdngst" runat="server" />
                        </td>
                        <td>
                          <div id="dvOutgst"  style="line-height:1.5em;white-space:nowrap;" runat="server">IGST (5%) :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Literal ID="lblOutgst" runat="server"></asp:Literal></div>
                            <div id="dvIngst_s"  style="line-height:1.5em;white-space:nowrap;" runat="server">CGST (2.5%) :&nbsp;&nbsp;&nbsp; <asp:Literal ID="lblIngst_s" runat="server"></asp:Literal></div>
                           <div id="dvIngst_c"   style="line-height:1.5em;white-space:nowrap;" runat="server">SGST (2.5%) : &nbsp;&nbsp;&nbsp; <asp:Literal ID="lblIngst_c" runat="server"></asp:Literal></div>
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
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                             <%=txtReimburseAmount%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="txtPaperSecurityFor" runat="server"     Visible="False">0</asp:Label>
                            <asp:Label ID="txtReemPaperRs" runat="server"
                                Visible="False">0</asp:Label>
                            <asp:Label ID="txtTonsPerReem" runat="server" Visible="False">0</asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Label runat="server" ID="txtPayBlePrintingCharg"  Visible="False">0</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        </td>
                        <td>
                            <b>(A) Total Printing Charges Payable Rs.:</b>
                        </td>
                        <td>
                            <%=txtTotalPaybleAmount%>
                        </td>
                    </tr>
                </table>
      
            <div style="page-break-before:always;">
           
                <table width="
                        </td>
                        <td>
                            <%=txtTotalPaybleAmount%>
                        </td>
                    </tr>
                </table>
      
            <div style="page-break-before:always;">
           
                <table width="99%" style ="font:12px;">
                     <tr><td colspan="4" style="font-weight:bold;font-size:0.9em;">DEDUCTIONS</td></tr>
                    <tr>
                        <td colspan="4">
                        </td>
                    </tr>

                    <tr>
                      
               {
                        <td>
                            (1) Withheld 2% regarding income Tax on Rs.:
                        </td>
                        <td>
                            <%=txt2PerInComeTAX%>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div id="Div1"  style="line-height:1.5em;white-space:nowrap;" runat="server">2 Withheld 2% regarding IGST TDS&nbsp; Rs.:  </div>
                            <div id="Div2"  style="line-height:1.5em;white-space:nowrap;" runat="server">(2 -a) Withheld 1% regarding SGST TDS Rs. : </div>
                           
                            
                        </td>
                        <td>
                            <div id="Div9" style="line-height:1.5em;white-space:nowrap;" runat="server">
                             <asp:Literal ID="Literalcgst" runat="server"></asp:Literal> </div>
                             <div id="Div4"  style="line-height:1.5em;white-space:nowrap;" runat="server"><asp:Literal ID="Literaligst" runat="server"></asp:Literal></div>
                             </td>
                        <td colspan="2">
                            </td>
                    </tr>
                    <tr>
                        <td>
                          <div id="Div3"   style="line-height:1.5em;white-space:nowrap;" runat="server">2 -b) Withheld 1% regarding CGST TDS&nbsp; Rs.:&nbsp;&nbsp;&nbsp;</div> 
                        </td>
                        <td> <div id="Div5" style="line-height:1.5em;white-space:nowrap;" runat="server"> <asp:Literal ID="Literalsgst" runat="server"></asp:Literal></div> 
                            </td>
                        <td colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            (3) Deduction against paper security:
                        </td>
                        <td>
                            <%=txtDeductionPaperSecurity%>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            (4) Depot Expenditure on behalf of Printer:
                        </td>
                        <td>
                             <%=txtDepotExpenditure%>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            (5) Interest on Paper:
                             
                        </td>
                        <td class="auto-style1">
                             <%=txtPaperInterest%>
                        </td>
                        <td colspan="2" class="auto-style1">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            (6) Penalty for Delay supply of Books:
                        </td>
                        <td>
                            <%=txtDelaySupplyPenalty%>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>

                  

                    <tr>
                        <td>
                            (7) Deduction of Paper cost of against short size of Books:
                        </td>
                        <td>
                             <%=txtShortSizeBookDeduction%>
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
                            (8) Bad Printing:
                        </td>
                        <td>
                            <%=txtBadPrinting%>
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
                            (9) Printing Mistakes:
                        </td>
                        <td>
                           <%=txtPrintingMistakes%>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>

                     <tr><td colspan="4">&nbsp;</td></tr>

                     <tr>
                        <td>
                            (10) Lamination:
                        </td>
                        <td>
                             <%=txtLamination%>
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
                            (11) Perfect Binding:
                        </td>
                        <td>
                             <%=txtPerfectBinding%>
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
                            (12) Loose Bundle Pack:
                        </td>
                        <td>
                            <%=txtLooseBundlePack%>
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
                            (13) Transportation/Delievery charges:
                        </td>
                        <td>
                             <%=txtTransportationDelvry%>
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
                            (14) Other Deduction :   Description
                             <div style="margin-left:20px;text-align:left;padding-top:8px">
                                  <%=txtOtherDedDescription%>
                             </div>
                        </td>
                        <td>
                           <%=txtOtherDedAmt%>
                        </td>
                        <td style="vertical-align:middle;">
                            
                        </td>
                        <td style="vertical-align:middle;">
                            
                        </td>                    </tr>

                 

                    <tr>
                        <td>&nbsp;
                            
                        </td>
                        <td>
                            (B) Total deduction:
                        </td>
                        <td>
                            Rs.
                        </td>
                        <td>
                         <%=txtTotalDeduction%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            (C) Net payable A-B:
                        </td>
                        <td>
                            Rs.
                        </td>
                        <td>
                            <%=txtNetPayable%>
                        </td>
                    </tr>

                    <tr>
                        <td>
                        </td>
                        <td>
                           Amount return to Printer:
                        </td>
                        <td>
                            Rs.
                        </td>
                        <td>
                             <%=txtAmtReturnToPrinter%>
                        </td>
                    </tr>

       Amount of SD return to Printer:
                        </td>
                        <td>
                            Rs.
                                     <tr><td colspan="2" style="font-weight:bold;font-size:0.9em;">Printing Section       <tr>
                        <td>
                            (b) Amount of the Deduction Rs.:
                        </td>
                        <td>
                          <%=txtBillAmountofDeduction%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            (c) Net payable Rs.:
                        </td>
                        <td>
                                <%=txtBillNetPayablePrinting%>
                        </td>
                        </tr>

                     <tr>
                        <td>
                            (d) GST Rs.:
                        </td>
                        <td>
                               <%=txtGST%>
                        </td>
                         </tr>

                     <tr>
                        <td>
                            (e)Amount of SD return to Printer</td>
                        <td>
                               <%=txtAmtReturnToPrinter%></td>
                         </tr>

                       <tr>
                         <td>
                            (f) Total Payable Amount including GST (c + d + e) Rs.:
                        </td>
                        <td>
                              <%=txtTotalPayableWithGST%>
                        </td>

                    </tr>
                </table>
           
      
             <table width="100%" style ="font:12px;padding-top:10px;">

                  <tr><td colspan="4"><br /><br /><div align="left" style="line-height:1.5em;">Seals Signature of the Printer</div><br /><br /><br /></td></tr>

                 <tr><td><div align="left" style="line-height:1.5em;">Dealing Clerk</div></td>
                   <td colspan="3"> <div align="left" style="line-height:1.5em;white-space:nowrap">DGM Printing</div>
                     </td></tr>

                
                  <tr><td colspan="4"><br /><div align="center" style="line-height:1.5em;"> <hr />Finacnce Section</div><br /></td></tr>

                 <tr><td><div align="left" style="line-height:1.5em;">Details of the bill have been checked, An amount of Rs...........</div><br />
                     (Rs..............................................................................................................................................................)
                     </td></tr>

                
                    <tr><td> <br /><br /><br /><br /><div align="left" style="line-height:1.5em;">Accountant&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;A.A.O.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Sr.Manager(Finance)</div>
                    
                        </td></tr>

             <tr >
                 <td colspan="4">
                    <%-- <div align="left" style="line-height:1.5em;">महाप्रबन्थक मुद्रण, म.प्र.पाठ्यपुस्तक निगम प.क्र. .........../दिनांक. </div> 
                  <div align="left" style="line-height:1.5em;">प्रतिलिपि:-  प्रबन्ध संचालक,म.प्र.पाठ्यपुस्तक निगम,अरेरा हिल्स,जेल रोड,भोपाल की ओर सूचनार्थ एवं आवश्यक कार्यवाही हेतु प्रेषित.</div>              --%>
               <%-- <div align="right" style="line-height:1.5em;">म.प्र.पाठ्यपुस्तक निगम  भोपाल </div>  --%>           
              
              </td> </tr>

                
             
         </table>
                </div>

              </div>
       <asp:Label ID="txtBFPay" runat="server" Visible="False">0</asp:Label>
                            <asp:Label runat="server" ID="txtRs2" Visible="False">0</asp:Label>
                            <asp:Label runat="server" ID="txtRs3" Visible="False">0</asp:Label>
        </div> 
              <script type = "text/javascript">
                  function PrintPanel() {
                      var panel = document.getElementById("<%=ExportDiv.ClientID %>");

                      var printWindow = window.open('', '', 'height=400,width=800');
                      printWindow.document.write('<html><head><title></title>');
                      printWindow.document.write('</head><body >');
                      printWindow.document.write(panel.innerHTML);
                      printWindow.document.write('</body></html>');
                      printWindow.document.close();
                      setTimeout(function () {
                          printWindow.print();
                      }, 500);
                      return false;
                  }
        </script>           
</asp:Content>

