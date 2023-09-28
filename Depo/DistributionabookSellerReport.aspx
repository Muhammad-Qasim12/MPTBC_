<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DistributionabookSellerReport.aspx.cs" Inherits="Depo_DistributionabookSellerReport" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2348;&#2367;&#2325;&#2381;&#2352;&#2375;&#2340;&#2366; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Book Seller details
            </h2>
        </div>
        <div style="padding: 0 10px;">
           
            
            <table width="100%">
                <tr>
                    <td>
                        डिपो का नाम :<asp:DropDownList ID="ddlDepoMaster" runat="server">
                        </asp:DropDownList>
                        <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Show Report" />
                    </td>
                </tr>
                <tr>
                    <td>
                       <asp:Button ID="btnExport" runat="server" CssClass="btn_gry" 
                            OnClick="btnExport_Click" Text="Export to Excel" Visible="False" />
                        <asp:Button ID="btnExportPDF" runat="server" CssClass="btn_gry" 
                            OnClientClick="return PrintPanel();" Text="Export to PDF and Print" Visible="False" /></td>
                </tr>
                <tr>
                    <td><div id="ExportDiv" runat="server" visible="false"  >
                        <center>
                                <b style="font-size: 12pt;">
                                    मध्य प्रदेश पाठ्यपुस्तक निगम, संभागीय भंडार
                                    <br /><br />
                                    डिपो -&nbsp;&nbsp;<asp:Label ID="lblDepoName" runat="server"></asp:Label>
                                    <br />
                                    <br />
                                    पुस्तक बिक्रेता के आई.डी. व पासवर्ड / Book Seller&nbsp; ID and Password
                                </b>
                                <br />
                                <br />
                                शिक्षा सत्र :&nbsp;&nbsp;<asp:Label ID="lblFYear" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;दिनांक :&nbsp;&nbsp;<asp:Label ID="lblCurrentDate" runat="server"></asp:Label>
                            </center>
                            <br /><br />
                         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                               CssClass="tab">
                               <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                                                                           
                                                                                                                                                              
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                    <asp:BoundField HeaderText="&#2332;&#2367;&#2354;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; / District Name" DataField="District_Name_Hindi_V" />
                                    <asp:BoundField HeaderText="&#2347;&#2352;&#2381;&#2350;  &#2325;&#2366; &#2344;&#2366;&#2350; / Shop Name " DataField="BooksellerName_V" />
                                    <asp:BoundField HeaderText="&#2346;&#2340;&#2366; /Address" DataField="Address_V" />
                                   <asp:TemplateField HeaderText="&#2360;&#2306;&#2348;&#2306;&#2343;&#2367;&#2340; &#2357;&#2381;&#2351;&#2325;&#2381;&#2340;&#2367;  &#2325;&#2366; &#2344;&#2366;&#2350; / Owner Name">
                                       <ItemTemplate>
                                           <a href="DistShowBookSellerDetails.aspx?ID=<%# api.Encrypt(Eval("Booksellerregistration_I").ToString()) %>&DepoID=<%=ddlDepoMaster.SelectedValue %>" target="_blank" ><%#Eval("BooksellerOwnerName_V")%></a>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:BoundField HeaderText="&#2350;&#2379;&#2348;&#2366;&#2311;&#2354; &#2344;&#2306;&#2348;&#2352; / Mobile No" 
                                        DataField="MobileNo_N" />
                                   <asp:BoundField HeaderText="&#2346;&#2306;&#2332;&#2368;&#2351;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Reg. No" 
                                        DataField="RegistrationNo_V" />
                                    <asp:BoundField DataField="LoginID_V" HeaderText="यूजर का नाम /User Name" />
                                    <asp:BoundField DataField="UserPassowrd" HeaderText="पासवर्ड /Password" />
                               </Columns>
                               <EmptyDataTemplate>
                                   Data Not Found....
                               </EmptyDataTemplate>
                             <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                           </asp:GridView></div>
                    </td>
                </tr>
                <tr>
                    <td>
                        
                    </td>
                </tr>
            </table>
          
            <tr>
                <td colspan="4">
              
                </td>
            
            </tr>
        </div>
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
          }</script>
</asp:Content>