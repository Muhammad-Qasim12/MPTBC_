<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RPT005_BillInterestOnPaper.aspx.cs" Inherits="Printing_Reports_RPT005_BillInterestOnPaper" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div class="portlet-header ui-widget-header">
      बिल इंटरेस्ट
        </div>
        <div class="portlet-content">

        <div class="table-responsive">
        
        <table width="100%">

        <tr>
        <td>प्रिंटर का नाम / Printer Name</td>
        <td>
        <asp:DropDownList runat="server" ID="ddlPrinterID_I">
        </asp:DropDownList>
        </td>

        </tr>

        <tr>
        <td colspan="2">
        <asp:Button ID="btnGetReport" runat="server" Text="रिपोर्ट देखे " CssClass="btn" OnClick="btnGetReport_Click" />
        </td>
        </tr>
          <tr>
                     <td colspan="2">
                     <asp:Button ID="btnExport" runat="server" Text="Export to Excel" CssClass="btn" OnClick="btnExport_Click" />
                     <asp:Button ID="btnExportPDF" runat="server" Text="Export to PDF" OnClientClick  = "return PrintPanel();" CssClass="btn" />
                     </td>
                     </tr> 




        <tr>
        <td colspan="2">
        <div runat="server" id="ExportDiv">
        <asp:GridView ID="GrdPaperBill" runat="server" AutoGenerateColumns="False"  CssClass="tab" DataKeyNames="PaperAltID_I" 
                            
                            
                            >
                            <Columns> 
                            
                            <asp:TemplateField HeaderText="क्रमांक">
                            <ItemTemplate>
                            <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="जॉब कोड / Job Code">
                            <ItemTemplate>
                           <asp:Label runat="server" ID="lblJobCode_V" Text='<%# Eval("JobCode_V") %>' ></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>

                           <asp:TemplateField HeaderText="प्रिंटर का नाम / Printer Name">
                            <ItemTemplate>
                           <asp:Label runat="server" ID="lblNameofPress_V" Text='<%# Eval("NameofPress_V") %>' ></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="पेपर सप्लाई दिनांक / Paper Supply date">
                            <ItemTemplate>
                           <asp:Label runat="server" ID="lblSupplydate_D" Text='<%# Eval("Supplydate_D") %>' ></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="पेपर का आकार / Paper Size">
                            <ItemTemplate>
                           <asp:Label runat="server" ID="lblPaperSize_V" Text='<%# Eval("PaperSize_V") %>' ></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>


                            
                            <asp:TemplateField HeaderText="पेपर का प्रकार / Paper Type">
                            <ItemTemplate>
                           <asp:Label runat="server" ID="lblPaperCategory_V" Text='<%# Eval("PaperCategory_V") %>' ></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>

                             
                            <asp:TemplateField HeaderText="दिये गये पेपर की मात्रा (टन मे ) / Paper Quantity">
                            <ItemTemplate>
                           <asp:Label runat="server" ID="lblPaperQty_N" Text='<%# Eval("PaperQty_N") %>' ></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
                                
                         
                            </Columns>
                        </asp:GridView>
</div> 

        </td>
        </tr>


        </table> 
        </div> 
        </div> 



         <script type = "text/javascript">
             function PrintPanel() {
                 var panel = document.getElementById("<%=ExportDiv.ClientID %>");

                 var printWindow = window.open('', '', 'height=400,width=800');
                 printWindow.document.write('<html><head><title>Area,Gender and Category wise Distribution of Student</title>');
                 printWindow.document.write('</head><body >');
                 printWindow.document.write(panel.innerHTML);
                 printWindow.document.write('</body></html>');
                 printWindow.document.close();
                 setTimeout(function () {
                     printWindow.print();
                 }, 500);
                 return false;
             }</script>
</asp:Content>

