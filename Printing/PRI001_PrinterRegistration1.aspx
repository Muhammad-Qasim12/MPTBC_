<%@ Page Title="Printer Registration" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PRI001_PrinterRegistration1.aspx.cs" Inherits="Printing_PRI001_PrinterRegistration" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">












        <div class="portlet-header ui-widget-header">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2381;&#2352;&#2375;&#2358;&#2344;</div>
        <div class="portlet-content">

        <asp:Panel runat="server" ID="pnlMain">

         <asp:HiddenField ID="hdnPrinter_RedID_I" Value="0" runat="server" />
       
        <table width="100%">
       <tr><td colspan="4" style="height: 10px;"> </td></tr>
       
       <tr>      
       <td colspan="4">
           
       <div>

       <asp:Panel runat="server" ID="PnlRegInfo" GroupingText="Printer Registration General Information">


       <table width="100%">
       <tr>
        <td>Registration No </td>
         <td>
         <asp:TextBox ID="txtRegno_I" runat="server" Width="80px" CssClass="txtbox reqirerd" MaxLength="10" onkeypress="tbx_fnAlphaNumericOnly(event, this);"  ></asp:TextBox>
         </td>
        
        <td>Registration Date</td>
        <td>
        <asp:TextBox ID="txtRegDate_D" runat="server" Width="70px" CssClass="txtbox reqirerd" MaxLength="10" ></asp:TextBox>
        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="CaltxtRegDate_D" TargetControlID="txtRegDate_D" runat="server"></cc1:CalendarExtender>
        <cc1:MaskedEditExtender ID="MasktxtRegDate_D" TargetControlID="txtRegDate_D"  Mask="99/99/9999" UserDateFormat="None"  MaskType="Date" runat="server"></cc1:MaskedEditExtender>
        </td>
         </tr>

         <tr>
        <td> Registration for Offset</td>
        <td>
        <asp:CheckBox ID="chkIsOffsetReg_I" runat="server"  />
      
        </td>

         <td> Registration for Year</td>
         <td><asp:TextBox ID="txtRegforYear_I" runat="server" Text="0" Width="80px" CssClass="txtbox reqirerd" ></asp:TextBox></td>

         </tr>

         <tr>

         <td>Grade</td>

         <td colspan="3">
         <asp:DropDownList runat="server" ID="ddlGrade_V" CssClass="txtbox reqirerd" Width="80px">
          <asp:ListItem Text="A" Value="1"></asp:ListItem>
          <asp:ListItem Text="B" Value="2"></asp:ListItem>
          <asp:ListItem Text="C" Value="3"></asp:ListItem>
          <asp:ListItem Text="D" Value="4"></asp:ListItem>
         </asp:DropDownList>
          </td>
         </tr>
         
          <tr> 


          <td>Pay Mode</td>

          <td>
          <asp:DropDownList runat="server" ID="ddlPayMode" AutoPostBack="true"  OnSelectedIndexChanged="ddlPayMode_SelectedIndexChanged" >
          <asp:ListItem Text="select" Value="0"></asp:ListItem>
          <asp:ListItem Value="Cash" Text="Cash"></asp:ListItem>
          <asp:ListItem Value="Cheque" Text="Cheque"></asp:ListItem>
          <asp:ListItem Value="DD" Text="DD"></asp:ListItem>
          </asp:DropDownList>
          </td>



          </tr>

          <tr>
          <td colspan="4">
              <asp:Panel ID="Panel1" runat="server">
                  <table class="style1">
                      <tr>
                          <td class="style3">
                              Bank Name</td>
                          <td>
                              <asp:TextBox ID="txtBankName_V" runat="server" Enabled="false" MaxLength="80" 
                                  onkeypress="tbx_fnAlphaNumeric(event, this);" Width="400px"></asp:TextBox>
                          </td>
                      </tr>
                      <tr>
                          <td class="style3">
                              Cheque /DD No.</td>
                          <td>
                              <asp:TextBox ID="txtRegDetails_V" runat="server" Enabled="false" MaxLength="40" 
                                  onkeypress="tbx_fnAlphaNumeric(event, this);" Width="240px"></asp:TextBox>
                          </td>
                      </tr>
                      <tr>
                          <td class="style3">
                              Date</td>
                          <td>
                              <asp:TextBox ID="txtDate" runat="server" Enabled="false" MaxLength="10" 
                                  Width="80px"></asp:TextBox>
                              <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                                  Format="dd/MM/yyyy" TargetControlID="txtDate">
                              </cc1:CalendarExtender>
                              <cc1:MaskedEditExtender ID="txtDate_MaskedEditExtender" runat="server" 
                                  Mask="99/99/9999" MaskType="Date" TargetControlID="txtDate" 
                                  UserDateFormat="None">
                              </cc1:MaskedEditExtender>
                          </td>
                      </tr>
                  </table>
              </asp:Panel>
              </td>

          

          </tr>

           <tr>
            <td>Registration Amount</td>
           <td>
           <asp:TextBox ID="txtRegamount_N" runat="server"  Width="80px" CssClass="txtbox reqirerd" MaxLength="5" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'></asp:TextBox>
            </td>
          
          </tr>


         


         </table>

        </asp:Panel>

       </div>

       </td>
       
       </tr>

          <tr>
              <td colspan="4" style="height: 10px;">
              </td>
          </tr>
         </table> 



         <asp:Panel runat="server" ID="pnlreg" GroupingText=" " >
         <table width="100%">

          <tr>
              <td>
                  <b>1. Name of the press :</b>
              </td>
              <td colspan="3" align="left">
                  <asp:TextBox ID="txtNameofPress_V" runat="server" MaxLength="50" Width="660px" CssClass="txtbox reqirerd" onkeypress="tbx_fnAlphaNumeric(event, this);"  ></asp:TextBox>
              </td>
          </tr>
          <tr>
              <td>
                  <b>2. Full Address:</b>
              </td>
              <td colspan="3" align="left">
                  <asp:TextBox ID="txtFullAddress_V" runat="server" MaxLength="80" Width="660px" CssClass="txtbox reqirerd" onkeypress="tbx_fnAlphaNumeric(event, this);" ></asp:TextBox>
              </td>
          </tr>
          <tr>
              <td>
                  <b>3. Head Office:</b>
              </td>
              <td colspan="3" align="left">
                  <asp:TextBox ID="txtHeadoffice_V" runat="server" MaxLength="80" Width="660px" CssClass="txtbox reqirerd" onkeypress="tbx_fnAlphaNumeric(event, this);" ></asp:TextBox>
              </td>
          </tr>
          <tr>
              <td>
                  <b>4. Branch Office Telegraphic Address:</b>
              </td>
              <td colspan="3" align="left">
                  <asp:TextBox ID="txtBOTelegraph_Add_V" runat="server" MaxLength="80" Width="660px"  CssClass="txtbox reqirerd" onkeypress="tbx_fnAlphaNumeric(event, this);" ></asp:TextBox>
              </td>
          </tr>
          <tr>
              <td>
                  <b>5. Date of establishment of the press:</b>
              </td>
              <td colspan="3" align="left">
                  <asp:TextBox ID="txtEst_Date_D" runat="server" CssClass="txtbox reqirerd" Width="70px" MaxLength="10" ></asp:TextBox>
                  <cc1:CalendarExtender Format="dd/MM/yyyy" ID="CaltxtEst_Date_D" TargetControlID="txtEst_Date_D"    runat="server"></cc1:CalendarExtender>
                 
                  <cc1:MaskedEditExtender ID="MasktxtEst_Date_D" TargetControlID="txtEst_Date_D" Mask="99/99/9999" UserDateFormat="None" CultureName="en-GB"   MaskType="Date" runat="server"></cc1:MaskedEditExtender>
             
             
              </td>
          </tr>
          <tr>
              <td>
                  <b>6. Full Name (s) of the Owner (s) Directors:</b>
              </td>
              <td colspan="3" align="left">
                  <asp:TextBox ID="txtOwnerDeail_V" runat="server" MaxLength="45" Width="660px" CssClass="txtbox reqirerd" onkeypress="tbx_fnAlphaNumericOnly(event, this);" ></asp:TextBox>
              </td>
          </tr>
          <tr>
              <td>
                  <b>7. Area Occupies:</b>
              </td>
              <td colspan="3" align="left">
                  <asp:TextBox ID="txtAreaOccupies_N" runat="server" Width="75px" MaxLength="4" CssClass="txtbox reqirerd"   onkeypress='javascript:tbx_fnSignedInteger(event, this);' ></asp:TextBox>
                  <strong>sq. mtrs</strong>
              </td>
          </tr>
          <tr>
              <td>
                  Area Type
              </td>
              <td colspan="3" align="center">
                  <asp:RadioButtonList ID="radioAreaType_I" runat="server" RepeatDirection="Horizontal" CssClass="txtbox reqirerd" Width="350px" Font-Size="Small">
                      <asp:ListItem Text="Rentee" Value="1"> </asp:ListItem>
                      <asp:ListItem Text="Owned" Value="2"></asp:ListItem>
                      <asp:ListItem Text="partially rented" Value="3"></asp:ListItem>
                  </asp:RadioButtonList>
              </td>
          </tr>
          <tr>
              <td>
                  <b>8. Factory Registration No.</b>
              </td>
              <td colspan="3" align="left">
                  <asp:TextBox ID="txtFacRegNo_V" MaxLength="30" Width="250px" runat="server" CssClass="txtbox reqirerd" onkeypress="tbx_fnAlphaNumericOnly(event, this);" ></asp:TextBox>
              </td>
          </tr>

           <tr>
              <td colspan="4" style="height: 10px;">
              </td>
          </tr>


          <tr>
                <td>
                    <b>9. <b>Is the press registration under :</b>
                </td>
                <td colspan="3" align="left">
                </td>
            </tr>
          <tr>
                <td>
                    (a) Indian Companies Act. 1913
                </td>
                <td colspan="3" align="left">
                    <asp:RadioButtonList ID="radioReginComact_I" CssClass="txtbox reqirerd" runat="server" Width="150px" Font-Size="Small"   RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="radioReginComact_I_SelectedIndexChanged">
                     <asp:ListItem Text="Yes" Value="1"> </asp:ListItem>
                        <asp:ListItem Text="No" Value="0"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
          <tr>
                <td>
                    (b) If so. please state Nos
                </td>
                <td colspan="3" align="left">
                    <asp:TextBox ID="txtRegDet_V" Enabled="false"  MaxLength="10" Width="75px" runat="server"  onkeypress="tbx_fnAlphaNumericOnly(event, this);" ></asp:TextBox>
                </td>
            </tr>
          <tr>
                <td colspan="4">
                </td>
          </tr>

           <tr>
              <td colspan="4" style="height: 10px;">
              </td>
          </tr>

          <tr>
                <td colspan="4">
                    <b>10. Number of person currently</b>
                </td>
            </tr>
             
             <tr>
              <td colspan="4" style="height: 10px;">
              </td>
          </tr>

          <tr>
                <td colspan="4">
                    <div>
                        <table class="tab hastable">
                            <tr>
                                <th> Processing in Employment (As per latest Factory returns )<br /> Except Daily </th>
                                <th>
                                    Operatives
                                </th>
                                <th>
                                    Supervisors
                                </th>
                             </tr>
               
                <tr>
                    <td>
                        <%--(a)--%> Processing Image earners-contractors
                    </td>
                    <td>
                        <asp:TextBox ID="txtNoofProc_OP_I" runat="server" Width="100px" MaxLength="4"
                            onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNoofProc_Su_I" runat="server" Width="100px" MaxLength="4"
                            onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--(b)--%>Composing
                    </td>
                    <td>
                        <asp:TextBox ID="txtNoofComp_OP_I" runat="server" Width="100px" MaxLength="4" 
                            onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNoofComp_Su_I" runat="server" Width="100px" MaxLength="4" 
                            onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                       <%-- (c)--%> Printing
                    </td>
                    <td>
                        <asp:TextBox ID="txtNoofPrint_OP_I" runat="server" Width="100px" MaxLength="4" 
                            onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNoofPrint_Su_I" runat="server" Width="100px" MaxLength="4" 
                            onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                       <%-- (d)--%> Binding
                    </td>
                    <td>
                        <asp:TextBox ID="txtNoofBind_OP_I" runat="server" Width="100px" MaxLength="4" 
                            onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNoofBind_Su_I" runat="server" Width="100px" MaxLength="4" 
                            onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--(e)--%> Misc
                    </td>
                    <td>
                        <asp:TextBox ID="txtNoofMisc_OP_I" runat="server" Width="100px" MaxLength="4" 
                            onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNoofMisc_Su_I" runat="server" Width="100px" MaxLength="4" 
                            onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                       <%-- (f)--%> Total
                    </td>
                    <td>
                        <asp:TextBox ID="txtNoofTotal_OP_I" runat="server" Width="100px" MaxLength="4" 
                            onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNoofTotal_Su_I" runat="server" Width="100px" MaxLength="4" 
                            onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                    </td>
                </tr>
               
                    </table>
                    </div>
                                </td>
                            </tr>
                           
                           <tr>
              <td colspan="4" style="height: 10px;">
              </td>
                           </tr>

          <tr>
                                <td colspan="4">
                                    <b>11. Facilities of Proof reading</b>
                                </td>
                            </tr>

                              <tr>
              <td colspan="4" style="height: 10px;">
              </td>
                           </tr>

          <tr>
                                <td>
                                    (a) No. Of Proof readers(Language wise ) :
                                </td>
                                <td colspan="3" align="left">
                                    <asp:FileUpload ID="fileProfreadpath_v"  Width="250px"  runat="server"></asp:FileUpload>
                                    <asp:Label ID="lblProfreadpath_v" Font-Bold="false" ForeColor="Green" Font-Size="Small"   runat="server"></asp:Label>
                                </td>
                            </tr>
          <tr>
                                <td>
                                    (b) No. Of copy holders
                                </td>
                                <td colspan="3" align="left">
                                    <asp:TextBox ID="txtNoofProofreader_I" runat="server" CssClass="txtbox reqirerd" Width="75px" MaxLength="4" onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                </td>
                            </tr>

                             <tr>
              <td colspan="4" style="height: 10px;">
              </td>
          </tr>

          <tr>
                                <td>
                                </td>
                                <td colspan="3">
                                    <asp:Button ID="BtnPrinterRegistration" runat="server" Text="Save" CssClass="btn" OnClick="BtnPrinterRegistration_Click" OnClientClick="return ValidateAllTextForm();" />
                                
                                    <asp:Button ID="BtnBack" runat="server" Text="Back" CssClass="btn"  OnClick ="BtnBack_Click" />
                                </td>
                            </tr>
         
          </table>
          </asp:Panel> 
        </asp:Panel>

        </div>

        <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server" >
        </div>

         <div id="SuccessDiv"  class="popupnew" style ="display:none">
         <div align="right" >
         <a href="#" onclick="document.getElementById('SuccessDiv').style.display='none'; document.getElementById('fadeDiv').style.display='none'; " >Closee</a>
         </div>

         <table>
         <tr>
         <td colspan="2"><b>Printer Details Saved Successfully. </b></td>
             

         <td><asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" /></td>
         <td><asp:Button ID="btnView" runat="server" Text="Go to View form" OnClick="btnView_Click" /></td>
         </tr>
         
         
         </table>



          </div> 
      

           <script type="text/javascript">


               function ShowHide(chk, div) {
                   var checkbox = document.getElementById(chk);
                   var dropdown = document.getElementById(div);



                   if (checkbox.checked == true) {
                       dropdown.style.display = "block";
                   }
                   else { dropdown.style.display = "none"; }


               }
   
    </script>
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 187px;
        }
        .style3
        {
            width: 313px;
        }
    </style>
</asp:Content>


