<%@ Page Title="प्रिंटर की मशीनों की  जानकारी / Machine Details" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PRI001_MachineDetails.aspx.cs" Inherits="Printing_PRI001_MachineDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  <div class="portlet-header ui-widget-header">प्रिंटर की मशीनों की  जानकारी / Machine Details </div>
                    <div class="box table-responsive">
 <div>
                    <asp:HiddenField ID="HdnPriMacDesID_I" Value="0" runat="server" />
                    </div>

      <asp:Panel runat="server" ID="pnlMachineDes" GroupingText="Machine Description  ">
       <table width="100%">
       <tr>
       <td style="height: 10px;">
       </td>
       </tr>

       <tr>
       <td colspan="2">
       <b>12. Details of Mechanical Composing equipment.</b>
       </td>
       </tr>

        <tr><td style="height: 10px;" colspan="2"></td> </tr>
       <tr>
       <td colspan="2" >
       
       <table class="tab hastable">
       <tr>
       <th></th>
       <th>
       Model Nos
       </th>
       </tr>
       <tr>
       <td>
      (a) Mono Type
      </td>
      <td>
      <asp:TextBox ID="txtComposing_Monotype_V" MaxLength="35" runat="server" CssClass="txtbox reqirerd" Width="300px" onkeypress="tbx_fnAlphaNumericOnly(event, this);" ></asp:TextBox>
      </td>
      </tr>

      <tr>
     <td>(b) Lino Type</td>
     <td>
     <asp:TextBox ID="txtComposing_Linotype_V" MaxLength="35" runat="server" CssClass="txtbox reqirerd" Width="300px" onkeypress="tbx_fnAlphaNumericOnly(event, this);" ></asp:TextBox>
      </td>
     </tr>

      <tr>
      <td> (c) Any other</td>
      <td>
      <div><asp:TextBox ID="txtOther" MaxLength="35" runat="server"  Visible="false"  onkeypress="tbx_fnAlphaNumericOnly(event, this);"  ></asp:TextBox></div>
      <div><asp:TextBox ID="txtComposAnyOthtype_V" MaxLength="35" runat="server" CssClass="txtbox reqirerd" Width="300px" onkeypress="tbx_fnAlphaNumericOnly(event, this);"  ></asp:TextBox></div>
                                                      
      </td>
      </tr>
      </table>
      
       </td>
       
        </tr>


       
       <tr><td style="height: 10px;" colspan="2"></td> </tr>
       
       <tr>
       <td colspan="2">
       <b>13. Foundry type in stock in Kg. 10pt. 12 pt. 14 pt. 18 pt. attach specimen sheets 20pt. 24pt.</b>
       </td>
       </tr>




       <tr>
       <td colspan="2">
       <asp:FileUpload runat="server" ID="FileFoundaryTyAtt_V"  />
       <asp:Label ID="lblFoundaryTyAtt_V" runat="server" Font-Bold="false" ForeColor="Green" Font-Size="Small"  ></asp:Label>
       </td>
       </tr>

       <tr>
       <td style="height: 10px;"></td>
       </tr>
       
       <tr>
       <td colspan="2"><b>14. Composing Capacity per day in. Terms of pages as 26X12 pica cms:</b></td>
       </tr>
        <tr><td style="height: 10px;" colspan="2"></td> </tr>
       <tr>
       <td colspan="2">
       
        <table class="tab hastable">
          <tr>
              <th> </th>
              <th>Language</th>
              <th>Pages</th>
          </tr>

          <tr>
              <th>(a)</th>
              
              <td>
                  <asp:TextBox ID="txtComposingCapL1_V" runat="server" MaxLength="45"  onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
              </td>

              <td>
                  <asp:TextBox ID="txtComposingCapP1_I" runat="server" MaxLength="4"  onkeypress='javascript:tbx_fnSignedInteger(event, this);' ></asp:TextBox>
               </td>
          </tr>

          <tr>
          <th>(b) </th>
          <td>
          <asp:TextBox ID="txtComposingCapL2_V" runat="server" MaxLength="45" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
          </td>
          <td>
          <asp:TextBox ID="txtComposingCapP2_I" runat="server" MaxLength="4"   onkeypress='javascript:tbx_fnSignedInteger(event, this);' ></asp:TextBox>
          </td>
          </tr>
          
          <tr>
          <th>(c)</th>
          <td>
          <asp:TextBox ID="txtComposingCapL3_V" runat="server" MaxLength="45"  onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
          </td>
          <td>
          <asp:TextBox ID="txtComposingCapP3_I" runat="server" MaxLength="4"  onkeypress='javascript:tbx_fnSignedInteger(event, this);' ></asp:TextBox>
          </td>
          </tr>
          </table>

         </td>
         </tr>
         
         <tr>
         <td style="height: 10px;">
         </td>
          </tr>

         <tr>
          <td colspan="2"> <b>15. The Languages in which textbook</b> setting work can be accepted</td>
          </tr>

          <tr>
         <td style="height: 10px;">
         </td>
          </tr>

          <tr>
          <td></td>
         <td>
         <asp:TextBox runat="server" ID="txtLanguagesTxtSetAttach_V" TextMode="MultiLine" Width="500px" onpaste="MaxLengthCount(this,150);" onkeypress="MaxLengthCount(this,150);" ></asp:TextBox>
         <%--<asp:FileUpload runat="server" ID="FileLanguagesTxtSetAttach_V"  />
         <asp:Label ID="lblLanguagesTxtSetAttach_V" runat="server" Font-Bold="false" ForeColor="Green" Font-Size="Small"  ></asp:Label>--%>
         </td>
         </tr>

         <tr>
         <td style="height: 10px;">
         </td>
         </tr>
         </table> 

         </asp:Panel> 

          <asp:Panel runat="server" ID="PnlRegInfo" GroupingText="Machine Details ">
         <table width="100%">

          <tr>
          <td colspan="2"> <b>16. Printing Machines:</b></td>
          </tr>

          <tr><td colspan="2">
          

          <table width="100%">
        
          
         
          <tr>
              <td>
                  Any other size attach separate  list if necessary web offset Machine.
              </td>
           </tr>

           <tr>
              <td>
                  <asp:FileUpload runat="server" ID="filemFoundaryTyAtt_V" />
                  <asp:Label ID="lblmFoundaryTyAtt_V" runat="server" Font-Bold="false" ForeColor="Green" Font-Size="Small"   ></asp:Label>
              </td>
          </tr>
          <tr>
              <td colspan="2" style="height: 10px;">
              </td>
          </tr>
          <tr>
              <td colspan="2">
              
                  <table class="tab">
                      <tr>
                          <th>
                              Machine
                          </th>
                          <th>
                          Machine No.
                          </th>

                          <th>
                              Make
                          </th>
                          <th>
                              Year
                          </th>
                          <th>
                              Date of Installation
                          </th>
                          <th>
                              No. of Machines
                          </th>
                          <th colspan="2">
                              Printing Capacity / Day 8 Hrs
                              (No.of Impressions)
                          </th>
                         
                      </tr>
                      <tr>
                          <td>
                              <asp:DropDownList ID="ddlMachineDescription" runat="server">
                              </asp:DropDownList>
                             <%-- <asp:Label ID="HdnPriMacID_I" runat="server" Text="0"></asp:Label>--%>
                              <asp:HiddenField ID="HdnPriMacID_I" Value="0" runat="server" />
                          </td>

                           <td>
                              <asp:TextBox ID="txtMachineNo_I" runat="server" Width="100px" MaxLength="20"></asp:TextBox>
                               <cc1:FilteredTextBoxExtender ID="FilteredtxtMachineNo_I" TargetControlID="txtMachineNo_I" FilterMode="ValidChars" ValidChars="0123456789abcdefghijklmnopqrstuvwxyz,':" runat="server">
                              </cc1:FilteredTextBoxExtender>
                          </td> 


                          <td>
                              <asp:TextBox ID="txtMake_V" runat="server" Width="100px" MaxLength="25"></asp:TextBox>

                              <cc1:FilteredTextBoxExtender ID="FilteredtxtMake_V" TargetControlID="txtMake_V" FilterMode="ValidChars" ValidChars="0123456789abcdefghijklmnopqrstuvwxyz" runat="server">
                              </cc1:FilteredTextBoxExtender>

                          </td>
                          <td>
                          <asp:DropDownList runat="server" ID="ddlYear_I" Width="80px"></asp:DropDownList>


                             <%-- <asp:TextBox ID="txtYear_I" runat="server" Width="80px" MaxLength="4" onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                              <cc1:FilteredTextBoxExtender ID="FilteredTtxtYear_I" TargetControlID="txtYear_I" FilterMode="ValidChars" ValidChars="0123456789" runat="server">
                              </cc1:FilteredTextBoxExtender>--%>
                          
                          </td>
                          <td>
                              <asp:TextBox ID="txtDateOfInstallation_D" runat="server" Width="70px" MaxLength="10"></asp:TextBox>
                              <cc1:CalendarExtender Format="dd/MM/yyyy" ID="CaltxtDateOfInstallation_D" TargetControlID="txtDateOfInstallation_D" runat="server">
                              </cc1:CalendarExtender>
                             
                          </td>
                          <td>
                              <asp:TextBox ID="txtnOOFmACHINE" runat="server" Width="50px" MaxLength="4" onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                              
                               <cc1:FilteredTextBoxExtender ID="FilteredtxtnOOFmACHINE" TargetControlID="txtnOOFmACHINE" FilterMode="ValidChars" ValidChars="0123456789" runat="server">
                              </cc1:FilteredTextBoxExtender>
                          
                         
                          </td>
                          <td>
                              <asp:TextBox ID="txtpRINcAPASITY_v" runat="server" Width="50px" MaxLength="4" onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                          
                           <cc1:FilteredTextBoxExtender ID="FilteredtxtpRINcAPASITY_v" TargetControlID="txtpRINcAPASITY_v" FilterMode="ValidChars" ValidChars="0123456789" runat="server">
                              </cc1:FilteredTextBoxExtender>
                          </td>
                          <td>
                              <asp:Button ID="btnMachineDetailsave" runat="server" Text="मशीन की जानकारी सुरक्षित करे /  Save Machine" CssClass="btn" OnClick="btnMachineDetailsave_Click" />
                          </td>
                      </tr>
                  </table>
                 
              </td>
          </tr>
         
          <tr>
              <td colspan="2">
                  
                  
                  
                  
                  <asp:GridView runat="server" ID="grdMachineDetails" DataKeyNames="PriMacID_I" OnRowDeleting="grdMachineDetails_RowDeleting" AutoGenerateColumns="false" OnRowUpdating="grdMachineDetails_RowUpdating"
                      CssClass="tab " Width="90%">
                      <Columns>
                          <asp:TemplateField HeaderText="S.No.">
                              <ItemTemplate>
                                  <%# Container.DataItemIndex+1 %>
                                  <asp:HiddenField ID="HdnPriMacID_I" runat="server" Value='<%# Eval("PriMacID_I") %>'></asp:HiddenField>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Machine">
                              <ItemTemplate>
                                  <asp:HiddenField ID="HdnmMachineID_I" Value='<%# Eval("MachineID_I") %>' runat="server" />
                                  <asp:Label ID="lblmMachineID_I" runat="server" Text='<%# Eval("MachineDescription") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>

                          <asp:TemplateField HeaderText="Machine No.">
                              <ItemTemplate>
                                  
                                  <asp:Label ID="lblMachineNo_V" runat="server" Text='<%# Eval("MachineNo_V") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>

                          <asp:TemplateField HeaderText="Make">
                              <ItemTemplate>
                                  <asp:Label ID="lblMake_V" runat="server" Text='<%# Eval("Make_V") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Year">
                              <ItemTemplate>
                                  <asp:Label ID="lblYear_I" runat="server" Text='<%# Eval("Year_I") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Date of Installation">
                              <ItemTemplate>
                                  <asp:Label ID="lblDateOfInstallation_D" runat="server" Text='<%# Eval("DateOfInstallation_D") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="No. of Machines">
                              <ItemTemplate>
                                  <asp:Label ID="lblnOOFmACHINE" runat="server" Text='<%# Eval("nOOFmACHINE") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Printing Capacity">
                              <ItemTemplate>
                                  <asp:Label ID="lblpRINcAPASITY_v" runat="server" Text='<%# Eval("pRINcAPASITY_v") %>'></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Edit">
                              <ItemTemplate>

                                   <ul id="icons" class="ui-widget ui-helper-clearfix">
									<li class="ui-state-default ui-corner-all" title="Confirm">
                                    <asp:Button runat="server" ID="BtnMachineDesEdit" CssClass="ui-icon ui-icon-check" CommandArgument="UpdateMachine" CommandName="Update" />
                                   </li>
									<li class="ui-state-default ui-corner-all" title="Delete">
                                    <asp:Button runat="server" ID="BtnMachineDelete" CssClass="ui-icon ui-icon-trash" CommandArgument="DeleteMachine" CommandName="Delete" Visible="false"  />
                                    </li>

								</ul>

                                  
                           </ItemTemplate>
                                                            </asp:TemplateField>
                           
                                <asp:CommandField ShowDeleteButton="True" />
                                                        </Columns>
                                                    </asp:GridView>










                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="height: 10px;">
                                                </td>
                                            </tr>
                                        </table>
         
        </td>
                            </tr>

          </table>
          </asp:Panel> 

                            <table>
                            <tr>
                                <td colspan="2" style="height: 10px;">
                                </td>
                            </tr>
                           
                           
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="btnMachineDesSave" runat="server" Text="सुरक्षित करे / Save" CssClass="btn" OnClientClick="return ValidateAllTextForm();" OnClick="btnMachineDesSave_Click" />
                                  <asp:Button ID="BtnBack" runat="server" Text="वापस जाये / Back" CssClass="btn"  OnClick ="BtnBack_Click" />
                                
                                
                                </td>
                            </tr>
                        </table>
</div>

       <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server" >
        </div>

         <div id="SuccessDiv"  class="popupnew" style ="display:none">
         <div align="right" ><a href="#" onclick="document.getElementById('fadeDiv').style.display='none'; document.getElementById('SuccessDiv').style.display='none';" >Close</a></div>

         <table>
         <tr>
         <td colspan="2"><b>Printer Details Saved Successfully. </b></td>
             

         <td><asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" /></td>
         <td><asp:Button ID="btnView" runat="server" Text="Go to View form" OnClick="btnView_Click" /></td>
         </tr>
         
         
         </table>



          </div> 


</asp:Content>

