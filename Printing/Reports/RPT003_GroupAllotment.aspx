<%@ Page Title="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2375; &#2327;&#2381;&#2352;&#2369;&#2346; &#2310;&#2357;&#2306;&#2335;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RPT003_GroupAllotment.aspx.cs" EnableEventValidation="false"  Inherits="Printing_Reports_RPT003_GroupAllotment" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div class="portlet-header ui-widget-header">
      &#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2375; &#2327;&#2381;&#2352;&#2369;&#2346; &#2310;&#2357;&#2306;&#2335;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; 
        </div>
        <div class="portlet-content">

        <table width="100%">

        <tr>

        <td>
        &#2358;&#2375;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352;
        </td>
        
        <td>
        <asp:DropDownList ID="ddlAcYearId" runat="server" AutoPostBack="true"  OnSelectedIndexChanged ="ddlPrinter_SelectedIndexChanged" >
        
        </asp:DropDownList>


        </td>
            <td>टेंडर नंबर</td>
            <td>
                 <asp:DropDownList ID="ddlTenderID_I" CssClass="txtbox" runat="server"></asp:DropDownList>
            </td>
        <td>
        &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;
        </td>
        
        <td>
        <asp:DropDownList ID="ddlPrinter" runat="server"  >
        
        </asp:DropDownList>
            <a href="RPT003_GroupAllotment.aspx"></a>
            <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375;"
                        OnClick="btnSearch_Click"   OnClientClick="return ValidateAllTextForm();"/>
        </td>
        </tr>
            

        <tr>
        <td colspan="6">
        <div runat="server" id = "ExportDiv">

             <table align = "center"  width="100%" >
       <tr><td   colspan="2"  style="text-align:center;font-weight:bold;font-family:Verdana;font-size:18px;" > 
          &#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;

           </td></tr>
      <tr>
          <td align = "center"  colspan="2"  style="text-align:center;font-family:Verdana;font-size:16px;" >
              <center> " &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2349;&#2357;&#2344; "</center> 

          </td></tr>

                <tr>
          <td align = "center" colspan="2"   style="text-align:center;font-family:Verdana;font-size:16px;" >
              <center>&#2309;&#2352;&#2375;&#2352;&#2366; &#2361;&#2367;&#2354;&#2381;&#2360; , &#2349;&#2379;&#2346;&#2366;&#2354; (&#2350;.&#2346;&#2381;&#2352;) 462011</center> 

          </td></tr>
          <tr>
            <td align = "center"  colspan="2""  style="text-align:center;font-family:Verdana;font-size:14px;" >
                 <div style="text-align:center;line-height:1.5">
                 &#2342;&#2370;&#2352;&#2349;&#2366;&#2359; - 0755-2550727, 2551294, 2551565, &#2347;&#2376;&#2325;&#2381;&#2360; - 2551145, <br />
&#2312;-&#2350;&#2375;&#2354; - infomptbc@mp.gov.in, &#2357;&#2375;&#2348;&#2360;&#2366;&#2311;&#2335;- mptbc.nic.in</div>

              </td>

          </tr>
              <tr><td align = "center" colspan="2"  style="width: 100%;font-weight:bold;" > 
     <div style="text-align:center;">

            टेंडर में प्रिंटर को ग्रुप आवंटन की जानकारी
         </div>
                  </td>
                  </tr>
 <tr><td align = "center" colspan="2"  style="width: 100%;font-weight:bold;" > 
     <div style="text-align:center;">
          <asp:Label ID="lblTitle" runat="server" ></asp:Label></div>
          </td></tr>
                 <tr><td align = "center" colspan="2"  style="width: 100%;font-weight:bold;" >

      
        <asp:GridView ID="GrdGroupDetails" runat="server" AutoGenerateColumns="False" CssClass="tab">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                    <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("GrpID_I") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                              <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352;/&#2346;&#2381;&#2352;&#2375;&#2360;  &#2325;&#2366; &#2344;&#2366;&#2350;">
                    <ItemTemplate>
                    <%# Eval("NameofPress_V")%>
                    </ItemTemplate> 
                    </asp:TemplateField> 
                          
                            
                            <asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2369;&#2346; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                <ItemTemplate>
                                <asp:Label ID="lblGroupNO_V" runat="server" Text='<%#Eval("GroupNO_V") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; ">
                                <ItemTemplate>
                                <asp:Label ID="lblTitleHindi_V" runat="server" Text='<%#Eval("TitleHindi_V") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="पृष्ट संख्या">
                                <ItemTemplate>
                                <asp:Label ID="lblNoofpages" runat="server" Text='<%#Eval("Noofpages") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="आवंटित संख्या">
                                <ItemTemplate>
                                <asp:Label ID="lblTotNoOfBooks" runat="server" Text='<%#Eval("TotNoOfBooks") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; (&#2335;&#2344; &#2350;&#2375;)" Visible="False">
                                <ItemTemplate>
                                <asp:Label ID="lblQty_PriPaper" runat="server" Text='<%#Eval("Qty_PriPaper") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                              <asp:TemplateField HeaderText="दर प्रति एक हज़ार फॉर्म (रूपये)" Visible="True">
                                <ItemTemplate>
                                <asp:Label ID="lblQty_PriPaper11" runat="server" Text='<%#Eval("Rates") %>'></asp:Label>
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
        <td colspan="4">
          <asp:Button ID="btnExport" runat="server" Text="Export to Excel" CssClass="btn_gry" OnClick="btnExport_Click" />

           <asp:Button ID="btnExportPDF" runat="server" Text="Export to PDF" 
                OnClientClick  = "return PrintPanel();" CssClass="btn_gry" 
                onclick="btnExportPDF_Click" />    
                     
        </td>
        </tr>
        </table>

        </div> 

         <script type = "text/javascript">
             function PrintPanel() {
                 var panel = document.getElementById("<%=ExportDiv.ClientID %>");

                 var printWindow = window.open('', '', 'height=400,width=800');
                 printWindow.document.write('<html><head><title>Printer Tender Allotement</title>');
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
            width: 1016px;
        }
    </style>
</asp:Content>


