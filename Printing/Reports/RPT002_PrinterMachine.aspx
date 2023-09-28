<%@ Page Title=" &#2350;&#2358;&#2368;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; " Language="C#" 
    MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RPT002_PrinterMachine.aspx.cs" EnableEventValidation="false" Inherits="Printing_Reports_RPT002_PrinterMachine" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div class="portlet-header ui-widget-header">
&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2368; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2350;&#2358;&#2368;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Printer's Printing Machine Details
        </div>
        <div class="portlet-content">

        <table>  <tr>
                             <td width="15%" >  </td>
                              <td width="15%"  >  </td>
                            <td  width="25%" > &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; / Printer Name </td>
    
                            <td><asp:DropDownList ID="ddlPrinter" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="ddlPrinter_SelectedIndexChanged" >
                                </asp:DropDownList>
            <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search "
                        OnClick="btnSearch_Click"   OnClientClick="return ValidateAllTextForm();"/>
                            </td> 
                            
                            </tr> </table> 

                            <table width="100%">
                             
                           
                           
                            <tr>
                            <td colspan="2">
                              <div runat="server" id = "ExportDiv">


                                  <table align = "center"  width="100%" >
       <tr><td  colspan="9" class="style1"  style="text-align:center;font-weight:bold;font-family:Verdana;font-size:18px;" > 
           <strong> <center>&#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;</center></strong> 

           </td></tr>
      <tr>
          <td align = "center" colspan="9" class="style1" style="text-align:center;font-family:Verdana;font-size:16px;" >
              <center> " &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2349;&#2357;&#2344; "</center> 

          </td></tr>

                <tr>
          <td align = "center" colspan="9" class="style1"  style="text-align:center;font-family:Verdana;font-size:16px;" >
              <center>&#2309;&#2352;&#2375;&#2352;&#2366; &#2361;&#2367;&#2354;&#2381;&#2360; , &#2349;&#2379;&#2346;&#2366;&#2354; (&#2350;.&#2346;&#2381;&#2352;) 462011</center> 

          </td></tr>
          <tr>
            <td align = "center" colspan="9" class="style1" style="text-align:center;font-family:Verdana;font-size:14px;" >
                 <div style="text-align:center;line-height:1.5">
                 &#2342;&#2370;&#2352;&#2349;&#2366;&#2359; - 0755-2550727, 2551294, 2551565, &#2347;&#2376;&#2325;&#2381;&#2360; - 2551145, <br />
&#2312;-&#2350;&#2375;&#2354; - infomptbc@mp.gov.in, &#2357;&#2375;&#2348;&#2360;&#2366;&#2311;&#2335;- mptbc.nic.in</div>

              </td>

          </tr>
 <tr><td align = "center" colspan="9" class="style1" > <center style="width: 100%;font-weight:bold;">
          <asp:Label ID="Label2" runat="server" 
              Text="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2368; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2350;&#2358;&#2368;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;"></asp:Label></center>
          </td></tr>
<tr><td align = "center" colspan="9" class="style1" > <center style="width: 100%;font-weight:bold;">
          <asp:Label ID="lblPrinterName" runat="server"  Text="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; : "></asp:Label>  
          </center>
          </td></tr>
      </table>
    
    

                            <asp:GridView runat="server" ID="grdMachineDetails" AutoGenerateColumns="false" 
                      CssClass="tab hastable">
                      <Columns>
                          <asp:TemplateField HeaderText=" &#2325;&#2381;&#2352;&#2350;&#2366;&#2325; / <br> S.No.  ">
                              <ItemTemplate>
                                  <%# Container.DataItemIndex+1 %>
                                  <asp:HiddenField ID="HdnPriMacID_I" runat="server" Value='<%# Eval("PriMacID_I") %>'></asp:HiddenField>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="  &#2350;&#2358;&#2368;&#2344; &#2325;&#2366; &#2344;&#2366;&#2350; /   <br> Machine">
                              <ItemTemplate>
                                  <asp:HiddenField ID="HdnmMachineID_I" Value='<%# Eval("MachineID_I") %>' runat="server" />
                                  <asp:Label ID="lblmMachineID_I" runat="server" Text='<%# Eval("MachineDescription") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>

                          <asp:TemplateField HeaderText="Machine No." Visible ="false">
                              <ItemTemplate>
                                  
                                  <asp:Label ID="lblMachineNo_V" runat="server" Visible="false"  Text='<%# Eval("MachineNo_V") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>

                          <asp:TemplateField HeaderText="   &#2350;&#2375;&#2325; / <br> Make  ">
                              <ItemTemplate>
                                  <asp:Label ID="lblMake_V" runat="server" Text='<%# Eval("Make_V") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="  &#2357;&#2352;&#2381;&#2359; /  <br> Year ">
                              <ItemTemplate>
                                  <asp:Label ID="lblYear_I" runat="server" Text='<%# Eval("Year_I") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="  &#2311;&#2306;&#2360;&#2381;&#2335;&#2366;&#2354;&#2375;&#2358;&#2344; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / <br> Date of Installation ">
                              <ItemTemplate>
                                  <asp:Label ID="lblDateOfInstallation_D" runat="server" Text='<%# Eval("DateOfInstallation_D") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="   &#2350;&#2358;&#2368;&#2344;&#2379; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / <br> No. of Machines  ">
                              <ItemTemplate>
                                  <asp:Label ID="lblnOOFmACHINE" runat="server" Text='<%# Eval("nOOFmACHINE") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText=" &#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2325;&#2381;&#2359;&#2350;&#2340;&#2366; (&#2335;&#2344; &#2350;&#2375;&#2306; )  / <br> Printing Capacity(in Ton)  ">
                              <ItemTemplate>
                                  <asp:Label ID="lblpRINcAPASITY_v" runat="server" Text='<%# Eval("pRINcAPASITY_v") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>


                                                          
                                                        </Columns>
                                                    </asp:GridView>
                            </div>
                            </td>
                            
                            </tr>


                            <tr>
                            <td colspan="2">
                            <asp:Button ID="btnExport" runat="server" Text="Export to Excel" CssClass="btnExport_Click" OnClick="btnExport_Click1" 
                                      />
                                     
          
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

