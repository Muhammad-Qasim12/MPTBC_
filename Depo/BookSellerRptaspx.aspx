<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookSellerRptaspx.aspx.cs" Inherits="Depo_BookSellerRptaspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="card-header">
            <h2>
                <span style="font-size: medium;">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;</span></h2>
        </div>
        <div id="ExportDiv" runat="server" >
     <asp:GridView ID="grnMain" runat="server" AutoGenerateColumns="False" 
                    CssClass="tab" DataKeyNames="BookSelleDemandTrNo_I" >
                    <Columns>
                       <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     <asp:HiddenField ID="BookSelleDemandTrNo_I" 
                                                         runat="server" Value='<%# Eval("BookSelleDemandTrNo_I") %>' />
                                                           <asp:HiddenField ID="HiddenField1" runat="server"  Value='<%# Eval("TitleID_i") %>' />
                                                               <asp:HiddenField ID="hdnUser_ID_I" runat="server"  Value='<%# Eval("User_ID_I") %>' />
                                                            <asp:HiddenField ID="hdnDetailsid" runat="server" />
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                             
                                             
                                              <asp:BoundField DataField="BooksellerOwnerName_V" HeaderText="Book seller" />
                                              <asp:BoundField DataField="OrderNo" HeaderText="Order No" />
                                              <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2335;&#2366;&#2311;&#2335;&#2354; " />
                        <asp:BoundField DataField="BDate_D" HeaderText="&#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" />
                        
                        <asp:BoundField DataField="MediunNameHindi_V" HeaderText="&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;" />
                        <asp:BoundField DataField="Classdet_V" HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366;" />
                        <asp:BoundField DataField="TotalDemand" HeaderText="&#2350;&#2366;&#2306;&#2327;" />
                        <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblnoofbooks"  runat="server" Text='<%# Eval("total") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                           
                           </Columns>
                </asp:GridView></div> 
                    <asp:Button ID="btnExport" runat="server" CssClass="btn_gry" 
                                OnClick="btnExport_Click" Text="Export to Excel" Visible="False" />
                            <asp:Button ID="btnExportPDF" runat="server" CssClass="btn_gry" 
                                OnClientClick="return PrintPanel();" Text="Export to PDF" Visible="False" />
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

