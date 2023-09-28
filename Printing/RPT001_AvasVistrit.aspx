<%@ Page Title="आवास की जानकारी " Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RPT001_AvasVistrit.aspx.cs" Inherits="Building_Reports_RPT001_AvasVistrit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <div class="portlet-header ui-widget-header">आवास की जानकारी </div>
                     <div class="portlet-content">
                     <div class="table-responsive ">
                     <table width="100%">

                      <tr>

                       <td>जोन (नगर निगम )</td>
                      <td> 
                     <asp:DropDownList ID="ddlZone_V"   runat="server">
                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                    <asp:ListItem Text="ZONE-1" Value="ZONE-1"></asp:ListItem>
                    <asp:ListItem Text="ZONE-2" Value="ZONE-2"></asp:ListItem>
                    <asp:ListItem Text="ZONE-3" Value="ZONE-3"></asp:ListItem>
                    <asp:ListItem Text="ZONE-4" Value="ZONE-4"></asp:ListItem>
                    <asp:ListItem Text="ZONE-5" Value="ZONE-5"></asp:ListItem>
                    <asp:ListItem Text="ZONE-6" Value="ZONE-6"></asp:ListItem>
                    <asp:ListItem Text="ZONE-7" Value="ZONE-7"></asp:ListItem>
                    <asp:ListItem Text="ZONE-8" Value="ZONE-8"></asp:ListItem>
                    <asp:ListItem Text="ZONE-9" Value="ZONE-9"></asp:ListItem>
                    <asp:ListItem Text="ZONE-10" Value="ZONE-10"></asp:ListItem>
                    <asp:ListItem Text="ZONE-11" Value="ZONE-11"></asp:ListItem>
                    <asp:ListItem Text="ZONE-12" Value="ZONE-12"></asp:ListItem>
                    <asp:ListItem Text="ZONE-13" Value="ZONE-13"></asp:ListItem>
                    <asp:ListItem Text="ZONE-14" Value="ZONE-14"></asp:ListItem>
                    <asp:ListItem Text="ZONE-15" Value="ZONE-15"></asp:ListItem>
                    <asp:ListItem Text="ZONE-16" Value="ZONE-16"></asp:ListItem>
                    <asp:ListItem Text="ZONE-17" Value="ZONE-17"></asp:ListItem>
                    <asp:ListItem Text="ZONE-18" Value="ZONE-18"></asp:ListItem>
                    <asp:ListItem Text="ZONE-19" Value="ZONE-19"></asp:ListItem>
                    <asp:ListItem Text="ZONE-20" Value="ZONE-20"></asp:ListItem>
                    <asp:ListItem Text="ZONE-21" Value="ZONE-21"></asp:ListItem>
                    <asp:ListItem Text="ZONE-22" Value="ZONE-22"></asp:ListItem>
                    <asp:ListItem Text="ZONE-23" Value="ZONE-23"></asp:ListItem>
                    <asp:ListItem Text="ZONE-24" Value="ZONE-24"></asp:ListItem>
                    <asp:ListItem Text="ZONE-25" Value="ZONE-25"></asp:ListItem>
           
                    </asp:DropDownList>
                    
                    </td>



                     <td>आवास का प्रकार </td>
                     <td> 
                     <asp:DropDownList ID="ddlAvasType" runat="server" CssClass="txtbox">
                                   
                    </asp:DropDownList></td>
                                    
                  
                     </tr>
                     
                     
                     <tr>
                   
                         <td>टाइप </td>
                     <td>
                     <asp:DropDownList ID="ddlType" runat="server" CssClass="txtbox">
                     <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                     <asp:ListItem Text="E"></asp:ListItem>
                     <asp:ListItem Text="G"></asp:ListItem>
                     <asp:ListItem Text="H"></asp:ListItem>
                     <asp:ListItem Text="I"></asp:ListItem>
                     </asp:DropDownList></td>
                                   
                      <td>वेतनमान  </td>
                      <td> 
                       <asp:DropDownList ID="ddlPayScale_V"  runat="server">
         <asp:ListItem Text="Select" Value="0"></asp:ListItem>
         <asp:ListItem Text="15600+6600 ग्रेड पे या अधिक" Value="15600+6600 ग्रेड पे या अधिक" ></asp:ListItem>
         <asp:ListItem Text="15600+5400 ग्रेड पे या अधिक" Value="15600+5400 ग्रेड पे या अधिक" ></asp:ListItem>
         <asp:ListItem Text="5200+2800 ग्रेड पे या अधिक" Value="5200+2800 ग्रेड पे या अधिक" ></asp:ListItem>
         <asp:ListItem Text="5200+1900 ग्रेड पे या अधिक" Value="5200+1900 ग्रेड पे या अधिक" ></asp:ListItem>
         <asp:ListItem Text="चतुर्थ श्रेणी" Value="चतुर्थ श्रेणी" ></asp:ListItem>
        
         </asp:DropDownList></td>               
                                    
                     </tr>
                     
                     <tr>
                     <td>जिला</td>
                     <td>
                      <asp:DropDownList ID="DDLDistrictTrno_I"  runat="server"></asp:DropDownList> 
                     </td>
                     </tr>

                     <tr>
                     <td colspan="4">
                     <asp:Button runat="server" ID="btngetReport" CssClass="btn" Text="Get Report" OnClick="btngetReport_Click" />
                     </td>
                     </tr>
                    
                     <tr><td colspan="4"></td> </tr> 
                     


                     <tr>

                     <td colspan="4">
                     <div runat="server" id="ExportDiv">
                     <asp:GridView runat="server" ID="grdAvasVistrit" AutoGenerateColumns="false" CssClass="tab hastable">
                     
                     <Columns>
                     <asp:TemplateField HeaderText="क्रमांक ">
                     <ItemTemplate>
                     <%# Container.DataItemIndex+1 %>
                     </ItemTemplate>
                     
                    </asp:TemplateField>
                     
                     <asp:TemplateField HeaderText="आवास का नाम ">
                     <ItemTemplate>
                     <%# Eval("AvasName")%>
                     </ItemTemplate>
                     </asp:TemplateField> 
                     
                      <asp:TemplateField HeaderText="टाइप ">
                     <ItemTemplate>
                     <%# Eval("AvasType_V")%>
                     </ItemTemplate>
                     </asp:TemplateField> 


                     <asp:TemplateField HeaderText="क्षेत्रफल ">
                     <ItemTemplate>
                     <%# Eval("Area")%> 
                     </ItemTemplate>
                     </asp:TemplateField> 


                     <asp:TemplateField HeaderText="आवास क्रमांक  ">
                     <ItemTemplate>
                     <%# Eval("AvasNo_V")%>
                     </ItemTemplate>
                     </asp:TemplateField> 

                     <asp:TemplateField HeaderText="जोन (नगर निगम ) ">
                     <ItemTemplate>
                     <%# Eval("Zone_V")%>
                     </ItemTemplate>
                     </asp:TemplateField> 


                      <asp:TemplateField HeaderText="वार्ड  (नगर निगम ) ">
                     <ItemTemplate>
                     <%# Eval("WardNo_V")%>
                     </ItemTemplate>
                     </asp:TemplateField> 

                      <asp:TemplateField HeaderText="वेतनमान ">
                     <ItemTemplate>
                     <%# Eval("PayScale_V")%>
                     </ItemTemplate>
                     </asp:TemplateField> 

                       <asp:TemplateField HeaderText="45 ''ए'' के अधीन मासिक किराया">
                     <ItemTemplate>
                     <%# Eval("Rent45A_N")%>
                     </ItemTemplate>
                     </asp:TemplateField> 

                     <asp:TemplateField HeaderText="45 ''बी'' के अधीन मासिक किराया">
                     <ItemTemplate>
                     <%# Eval("Rent45B_N")%>
                     </ItemTemplate>
                     </asp:TemplateField> 

                      <asp:TemplateField HeaderText="अनाधिकृत अधिपत्य होने पर दांडिक मासिक किराया">
                     <ItemTemplate>
                     <%# Eval("IllegalRent_N")%>
                     </ItemTemplate>
                     </asp:TemplateField> 

                     
                     <asp:TemplateField HeaderText="आवास की स्थिति ">
                     <ItemTemplate>
                     <%# Eval("AllotmentStatus_I")%>
                     </ItemTemplate>
                     </asp:TemplateField> 


                     

                     </Columns>
                      <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />

                     </asp:GridView>
                     </div>
                     </td>

                     </tr> 

                      <tr>
                     <td colspan="4">
                         <asp:Button ID="btnExport" runat="server" Text="Export to Excel" CssClass="btn_gry" OnClick="btnExport_Click" />

                         <asp:Button ID="btnExportPDF" runat="server" Text="Export to PDF" OnClientClick  = "return PrintPanel();" CssClass="btn_gry" />
                     </td>
                     </tr> 

                     </table> 
                     </div> </div> 

                     

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

