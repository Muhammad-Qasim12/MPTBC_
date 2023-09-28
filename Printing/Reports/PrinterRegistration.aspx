<%@ Page Title="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352;/&#2346;&#2381;&#2352;&#2375;&#2360; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
    CodeFile="PrinterRegistration.aspx.cs" Inherits="Printing_Reports_PrinterRegistration" EnableEventValidation="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div class="portlet-header ui-widget-header">
      &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352;/&#2346;&#2381;&#2352;&#2375;&#2360; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Printer Details
        </div>
        <div class="portlet-content">
          
        <table width="100%">
        <tr>

        <td>
        
      <div runat="server" id = "ExportDiv">
     
      <table align = "center"  width="100%" >
       <tr>
           <td colspan="4" style="font-size: 18px; font-weight: bold; text-align: center;">
                                                           मध्य प्रदेश पाठ्यपुस्तक निगम
           </td>
       </tr>
       <tr>
           <td colspan="4" style="font-size: 12px; font-weight: 200; text-align: center;">
                                                          " पुस्तक भवन "
           </td>
       </tr>
       <tr>
           <td colspan="4" style="font-size: 12px; font-weight: 200; text-align: center;">
                                                        अरेरा हिल्स , भोपाल (म.प्र) 462011

           </td>
       </tr>                                            
       <tr>
           <td colspan="4" style="font-size: 12px; font-weight: 200; text-align: center;">
                                                        दूरभाष - 0755-2550727, 2551294, 2551565, फैक्स - 2551145,<br /> 
                                                            ई-मेल - infomptbc@mp.gov.in, वेबसाइट- mptbc.nic.in
                                             
           </td>
       </tr>
        <tr>
           <td  style="font-size: 13px; font-weight: 200; text-align: left;">
                                                      शिक्षा सत्र :<asp:Label ID="lblAcYearRpt" runat="server"></asp:Label></td>
            <td colspan="2" style="font-weight:bold;">
प्रिंटर/प्रेस की जानकारी 
            </td>
            <td  style="font-size: 13px; font-weight: 200; text-align: right;">
दिनांक :<asp:Label ID="lblDate" runat="server"></asp:Label>
            </td>
       </tr>
       <tr><td colspan="4" style="font-size: 13px; font-weight: 200; text-align: center;">           <asp:Label ID="lblDepoName" runat="server" Font-Bold="true"></asp:Label>
           </td>
       </tr>

   <tr>
       <td colspan="4">


        <asp:GridView runat="server" ID="grdPrinterRegistration" CssClass="tab hastable" 
              AutoGenerateColumns="False"  >
                    <Columns>
                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/SNo.">
                    <ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352;/&#2346;&#2381;&#2352;&#2375;&#2360; &#2325;&#2366; &#2344;&#2366;&#2350; / Printer Name">
                    <ItemTemplate>
                    <%# Eval("NameofPress_V")%>
                    </ItemTemplate> 
                    </asp:TemplateField> 
                    
                      <asp:TemplateField HeaderText="&#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2381;&#2352;&#2375;&#2358;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Registration No. ">
                    <ItemTemplate>
                    <%# Eval("FacRegNo_V")%>
                    </ItemTemplate> 
                    </asp:TemplateField> 

                      <asp:TemplateField HeaderText="&#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2381;&#2352;&#2375;&#2358;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Registration Date ">
                    <ItemTemplate>
                    <%# Eval("RegDate_D")%>
                    </ItemTemplate> 
                    </asp:TemplateField> 


                     <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352;/&#2346;&#2381;&#2352;&#2375;&#2360; &#2325;&#2366; &#2346;&#2340;&#2366; / Printer Address">
                    <ItemTemplate>
                    <%# Eval("FullAddress_V")%>
                    </ItemTemplate> 
                    </asp:TemplateField> 
                    
                      <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352;/&#2346;&#2381;&#2352;&#2375;&#2360; &#2325;&#2366; &#2350;&#2369;&#2326;&#2381;&#2351;&#2366;&#2354;&#2351; / Printer Head Office ">
                    <ItemTemplate>
                    <%# Eval("Headoffice_V")%>
                    </ItemTemplate> 
                    </asp:TemplateField> 


                      <asp:TemplateField HeaderText="&#2360;&#2381;&#2341;&#2366;&#2346;&#2344;&#2366; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Establish Date ">
                    <ItemTemplate>
                    <%# Eval("Est_Date_D")%>
                    </ItemTemplate> 
                    </asp:TemplateField> 


                    

                      <asp:TemplateField HeaderText="&#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2381;&#2352;&#2375;&#2358;&#2344; &#2325;&#2368; &#2352;&#2366;&#2358;&#2368; &#2352;&#2369;. / Registration Amount (Rs.)">
                    <ItemTemplate>
                    <%# Eval("Regamount_N")%>
                    </ItemTemplate> 
                    </asp:TemplateField> 



                    

                    
                    </Columns>

 </asp:GridView>
           
       </td>
   </tr>
   </table>
  </div>
        </td>
        </tr>

        <tr>
        <td>
          <asp:Button ID="btnExport" runat="server" Text="Export to Excel" CssClass="btn_gry" OnClick="btnExport_Click" />
        </td>
        </tr>
        
        </table>

        

      </div> 
        <script type = "text/javascript">
            function PrintPanel() {
                var panel = document.getElementById("<%=ExportDiv.ClientID %>");
                var printWindow = window.open('', '', 'height=400,width=800');
                printWindow.document.write('<html><head><title>Printer Registration</title>');
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

<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style1
        {
            width: 1013px;
        }
    </style>
</asp:Content>


