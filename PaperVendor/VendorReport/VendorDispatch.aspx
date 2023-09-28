<%@ Page Title="डिलीवरी की रिपोर्ट / Report Of Delivery" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VendorDispatch.aspx.cs" Inherits="PaperVendor_VendorReport_VendorDispatch" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <script type="text/javascript">
      function PrintPanel() {
          var panel = document.getElementById("<%=Panel1.ClientID %>");
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
    <div class="portlet-header ui-widget-header">
      डिलीवरी की रिपोर्ट / Report Of Delivery
    </div>
    <div class="portlet-content">
     <div class="table-responsive">   <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    पेपर मिल का नाम <br /> Name Of Paper MIll
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlVendor" Width="250px" OnInit="ddlVendor_Init"
                        CssClass="txtbox reqirerd" AutoPostBack="True" OnSelectedIndexChanged="ddlVendor_SelectedIndexChanged">
                        <asp:ListItem Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    एल.ओ.आई. क्रमांक<br /> L.O.I. No.
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlLOINo" Width="250px"  
                        CssClass="txtbox reqirerd">
                        <asp:ListItem Text="All"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                      
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search"
                        OnClientClick="return ValidateAllTextForm();" OnClick="btnSearch_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center" id="tdPrintContent" runat="server" visible="false">
                <div  style="width:40px;color:White;">
                <table>
                <tr>
                <td>
                 <a href="#" class="btn" style="color:White;" onclick="return PrintPanel();">प्रिंट</a>
                </td>
                <td>
                 <asp:Button ID="btnExport" runat="server" Height="28px" Text="Export to Excel" CssClass="btn" OnClick="btnExport_Click" />
                </td>
                
                </tr>
                </table>             
                </div>
                    <div style="width: auto; height: auto;">
                        <center>
                            <div class="MT20">
                                <asp:Panel ID="Panel1" runat="server" Width="100%">
                                <div id="ExportDiv" runat="server">
                                    <div style="width: 900px;">
                                        <div style="padding: 10px;">
                                             <table width="100%">
                                                <tr>
                                                    <td colspan="4" style="font-size: 18px; font-weight: bold; text-align: center;">
                                                      मध्य प्रदेश पाठ्यपुस्तक निगम
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="font-size: 16px; font-weight: 200; text-align: center;">
                                                      " पेपर  मिल "
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="font-size: 18px;font-weight: bold; text-align: center;">
                                                       डिलीवरी की रिपोर्ट
                                                    </td>
                                                </tr>
                                                <tr>
                                                   <td width="25%;"><div style="float: right; padding-right: 20px;">
                                                           शैक्षणिक सत्र :<asp:Label ID="lblYear" runat="server"></asp:Label></div></td>
                                                    <td colspan="2" style="font-size: 16px; font-weight: 200; text-align: center;width:50%;">
                                                  
                                                    </td>
                                                    <td  style="font-size: 16px; font-weight: 200; text-align: center;width:25%;" >
                                                        <div style="float: right; padding-right: 20px;">
                                                           <asp:Label ID="lblDate" runat="server"></asp:Label></div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="font-size: 16px;   text-align: center;">
                                                       <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="font-size: 13px; font-weight: 200; text-align: center;">
                                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                            Width="100%" EmptyDataText="Record Not Found." AllowPaging="True" OnRowDataBound="GridView1_RowDataBound"
                                                            OnPageIndexChanging="GridView1_PageIndexChanging">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; <br>SrNo">
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex+1 %>.
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td>
                                                                                    पेपर मिल का नाम<br /> Name Of Paper Mill
                                                                                    <asp:Label ID="lblVouchar_Tr_Id" runat="server" Visible="false" Text='<%#Eval("DisTranId") %>'></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <%#Eval("PaperVendorName_V")%>
                                                                                </td>
                                                                                <td>
                                                                                    एल.ओ.आई. क्रमांक<br />L.O.I. No.
                                                                                </td>
                                                                                <td>
                                                                                    <%#Eval("LOINo_V")%>
                                                                                </td>
                                                                            </tr>
                                                                             <tr>
                                                                                <td>
                                                                                   चालान क्रमांक<br />Challan No.
                                                                                  
                                                                                </td>
                                                                                <td>
                                                                                    <%#Eval("ChallanNo")%>
                                                                                </td>
                                                                                <td>
                                                                                    चालान दिनांक<br />Challan Date
                                                                                </td>
                                                                                <td>
                                                                                    <%#Eval("ChallanDate")%>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="4" style=" text-align: center;">
                                                                                    <asp:GridView ID="GrdLabInspection" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                                                        CssClass="tab" Width="100%" EmptyDataText="Record Not Found." AllowPaging="false">
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                                                <ItemTemplate>
                                                                                                    <%# Container.DataItemIndex+1 %>.
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="पेपर का प्रकार<br>Paper Type" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                                                <ItemTemplate>
                                                                                                    <%#Eval("PaperType")%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="पेपर का आकार<br>Paper Size" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                                                <ItemTemplate>
                                                                                                    <%#Eval("CoverInformation")%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="पेपर की मात्रा(मे. टन)<br>Paper Quantity(Metric Ton)" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                                                <ItemTemplate>
                                                                                                    <%#Eval("ReqQty")%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                                  <asp:TemplateField HeaderText="बंडल/रील की संख्या <br> No Of Bundle/Reel " HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                                                <ItemTemplate>
                                                                                                    <%#Eval("SndrReel")%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="प्रदाय की मात्रा(मे. टन)<br>Supply Quantity(Metric Ton)" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                                                <ItemTemplate>
                                                                                                    <%#Eval("VdrSendQty")%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                      
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                             <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div></div>
                                </asp:Panel>
                            </div>
                        </center>
                    </div>
                </td>
            </tr>
        </table></div>
    </div>
</asp:Content>

