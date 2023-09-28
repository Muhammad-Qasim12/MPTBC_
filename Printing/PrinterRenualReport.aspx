<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrinterRenualReport.aspx.cs" Inherits="Printing_PrinterRenualReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div class="portlet-header ui-widget-header">
           &nbsp;मुद्रक के रजिस्ट्रेशन नवीनीकरण की रिपोर्ट 
        </div>
        <div class="portlet-content">
  
        <table width="100%">

        <tr>

        <td>
             <asp:Button ID="btnPrint" runat="server" Text="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2325;&#2352;&#2375;&#2306;" Width="150" CssClass="btn" OnClientClick="return PrintPanel()" />
              
             <div id="ExportDiv" runat="server" clientidmode="Static">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                <Columns>
                    <asp:BoundField DataField="NameofPress_V" HeaderText="मुद्रक का नाम " />
                    <asp:BoundField DataField="FullAddress_V" HeaderText="पता" />
                    <asp:BoundField DataField="Statename_eng_V" HeaderText="राज्य" />
                    <asp:BoundField DataField="Mobileno" HeaderText="कांटेक्ट पर्सन एवं मोबाइल नो." />
                    <asp:BoundField DataField="Renewaldate_D" HeaderText="नवीनीकरण दिनांक " />
                    <asp:BoundField DataField="Amount_I" HeaderText="नवीनीकरण राशि " />
                    <asp:BoundField DataField="AmtDetail_V" HeaderText="रसीद क्र." />
                    <asp:BoundField DataField="RenFrom_D" HeaderText="दिनांक से " />
                    <asp:BoundField DataField="RenTo_D" HeaderText="दिनांक तक " />
                </Columns>
            </asp:GridView></div> 
         </td> 

            </tr> </table> </div> 
    <script type="text/javascript">
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
         }</script>
</asp:Content>

