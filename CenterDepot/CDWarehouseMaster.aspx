<%@ Page Title="वेयरहाउस मास्टर" Language="C#" MasterPageFile="~/MasterPage.master" EnableEventValidation="false"  EnableViewStateMac ="false"  AutoEventWireup="true" CodeFile="CDWarehouseMaster.aspx.cs" Inherits="Depo_WarehouseMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" language="javascript">
     function fnValidatePAN(Obj) {
         if (Obj == null) Obj = window.event.srcElement;
         if (Obj.value != "") {
             ObjVal = Obj.value;
             var panPat = /^([a-zA-Z]{5})(\d{4})([a-zA-Z]{1})$/;
             var code = /([C,P,H,F,A,T,B,L,J,G])/;
             var code_chk = ObjVal.substring(3, 4);
             if (ObjVal.search(panPat) == -1) {
                 alert("Invalid Pan No");
                 Obj.focus();
                 return false;
             }
             if (code.test(code_chk) == false) {
                 Obj.value= "";
                 alert("Invaild PAN Card No.");
                 return false;
             }
         }
     }
     function Redirect() {
         
              windows.location.href = 'VIEW_Dpt001.aspx';
     }
</script>
 <script type="text/javascript">

     // Load the Google Transliterate API
     google.load("elements", "1", {
         packages: "transliteration"
     });

     function onLoad() {
         var options = {
             sourceLanguage:
                google.elements.transliteration.LanguageCode.ENGLISH,
             destinationLanguage:
                [google.elements.transliteration.LanguageCode.HINDI],
             //shortcutKey: 'ctrl+g',
             transliterationEnabled: true
         };

         // Create an instance on TransliterationControl with the required
         // options.
         var control =
            new google.elements.transliteration.TransliterationControl(options);

         // Enable transliteration in the textbox with id
         // 'transliterateTextarea'.
         control.makeTransliteratable(['ctl00_ContentPlaceHolder1_txtWareHouseName']);
         control.makeTransliteratable(['ctl00_ContentPlaceHolder1_txtaddress']);
         control.makeTransliteratable(['ctl00_ContentPlaceHolder1_txtCity']);
         control.makeTransliteratable(['ctl00_ContentPlaceHolder1_txtWarehouseOwnerN']);
         
         var prm = Sys.WebForms.PageRequestManager.getInstance();
         prm.add_initializeRequest(InitializeRequest);
         prm.add_endRequest(EndRequest);

         function InitializeRequest(sender, args) {
         }

         // this is called to re-init the google after update panel updates.
         function EndRequest(sender, args) {
             onLoad();
         }
     }
     google.setOnLoadCallback(onLoad);
    </script>
    <div class="box">
        <div class="card-header">
            <h2>
                <span>&#2357;&#2375;&#2351;&#2352;&#2361;&#2366;&#2313;&#2360; &#2350;&#2366;&#2360;&#2381;&#2335;&#2352;</span></h2>
        </div>
        <asp:UpdatePanel ID="up1" runat="server">
<ContentTemplate>
      <asp:Panel   class="form-message error" runat="server" id="mainDiv" style="display: none;padding-top:10px;padding-bottom:10px;">
                <asp:Label  id="lblmsg" class="notification" runat="server">
                
            </asp:Label>
            </asp:Panel>
            <div>* &#2347;&#2368;&#2354;&#2381;&#2337; &#2349;&#2352;&#2344;&#2366; &#2310;&#2357;&#2358;&#2381;&#2351;&#2325; &#2361;&#2376;</div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr> 
                    <td>
                        &nbsp;</td>
                    <td colspan="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &#2357;&#2375;&#2351;&#2352;&#2361;&#2366;&#2313;&#2360;/ &#2327;&#2379;&#2342;&#2366;&#2350;&nbsp; &#2325;&#2366; &nbsp;&#2344;&#2366;&#2350;
                        <span>*</span> </td>
                    <td>
                        <asp:TextBox ID="txtWareHouseName" runat="server" CssClass="txtbox reqirerd" onkeypress="javascript:tbx_fnAlphaNumericOnly(event, this)"  MaxLength="40"></asp:TextBox>
                    </td>
                    <td>
                        &#2357;&#2375;&#2351;&#2352;&#2361;&#2366;&#2313;&#2360;/ &#2327;&#2379;&#2342;&#2366;&#2350; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;
                        <span>*</span>
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rdwarehouse" runat="server" CssClass="txtbox reqirerd" 
                            RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">&#2360;&#2381;&#2341;&#2366;&#2312;</asp:ListItem>
                            <asp:ListItem Value="2">&#2309;&#2360;&#2381;&#2341;&#2366;&#2312;</asp:ListItem>
                            <asp:ListItem Value="3">&#2344;&#2367;&#2332;&#2368;</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        &#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;
                        <span>*</span> </td>
                    <td>
                        <asp:TextBox ID="txtRegistrationNo" runat="server" CssClass="txtbox reqirerd"      MaxLength="20"></asp:TextBox></td>
                    <td>
                        &#2310;&#2343;&#2367;&#2346;&#2340;&#2381;&#2351; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
                        <span>*</span> </td>
                    <td>
                        <asp:TextBox ID="txtRegDate" runat="server" CssClass="txtbox reqirerd"    MaxLength="10"  ></asp:TextBox>
                     <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtRegDate" Format="dd/MM/yyyy">
                     </cc1:CalendarExtender>
                        
                        <cc1:MaskedEditExtender ID="txtBookingDate0_MaskedEditExtender" runat="server"  MaskType="Date" CultureName="en-GB" TargetControlID="txtRegDate" Mask="99/99/9999">
                                   </cc1:MaskedEditExtender>
                    </td>
                </tr>
                
                 <tr>
                    <td>
                        &#2357;&#2375;&#2351;&#2352;&#2361;&#2366;&#2313;&#2360;/ &#2327;&#2379;&#2342;&#2366;&#2350; &#2350;&#2366;&#2354;&#2367;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;
                        <span>*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtWarehouseOwnerN" runat="server" CssClass="txtbox reqirerd" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'   MaxLength="40" ></asp:TextBox></td>
                    <td>
                       &#2325;&#2366;&#2352;&#2346;&#2375;&#2335; &#2319;&#2352;&#2367;&#2351;&#2366;
                        <span>*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCorpet" runat="server" CssClass="txtbox reqirerd"  onkeyup='javascript:tbx_fnSignedNumericCheck(this);'  MaxLength="10"></asp:TextBox>
                        <asp:DropDownList ID="ddlCorpetType" runat="server" CssClass="txtbox reqirerd" 
                            AutoPostBack="True" onselectedindexchanged="ddlCorpetType_SelectedIndexChanged">
                            <asp:ListItem Value="0">&#2330;&#2369;&#2344;&#2375; </asp:ListItem>
                            <asp:ListItem Value="1">&#2357;&#2352;&#2381;&#2327; &#2347;&#2368;&#2335; </asp:ListItem>
                            <asp:ListItem Value="2">&#2357;&#2352;&#2381;&#2327; &#2350;&#2368;&#2335;&#2352; </asp:ListItem>
                           
                            <asp:ListItem Value="4">&#2350;&#2376;&#2335;&#2381;&#2352;&#2367;&#2325; &#2335;&#2344;</asp:ListItem>
                        </asp:DropDownList>
                     </td>
                </tr>
                <tr>
                    <td>
                        &#2335;&#2375;&#2354;&#2368;&#2347;&#2379;&#2344; &#2344;&#2306;&#2348;&#2352;
                    </td>
                    <td ><span style="font-size:12px;"> &#2319;&#2360;&#2335;&#2368;&#2337;&#2368; &#2325;&#2379;&#2337;  - &nbsp;&nbsp;&#2335;&#2375;&#2354;&#2368;&#2347;&#2379;&#2344; &#2344;&#2406; </span><br />
                        <asp:TextBox ID="txtstdCode" Width="45" runat="server" 
                            onkeypress='javascript:fnSetPhoneDigits(event, this);' MaxLength="5" ></asp:TextBox>
                       - <asp:TextBox
                            ID="txtTelPhone2" runat="server" CssClass="txtbox " Width="70"  onkeypress='javascript:fnSetPhoneDigits(event, this);'
                             
                            MaxLength="8"></asp:TextBox><cc1:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender2" TargetControlID="txtTelPhone2" ValidChars="0123456798" runat="server">
                            </cc1:FilteredTextBoxExtender>
                            </td>
                    <td>
                        &#2350;&#2379;&#2348;&#2366;&#2311;&#2354; &#2344;&#2306;&#2348;&#2352;
                        <span>*</span>
                    </td>
                    <td>
                        +91<asp:TextBox ID="txtMoblie" runat="server" 
                            MaxLength="10" onblur='javascript:fnIsValidPhoneFormat(this);'></asp:TextBox><cc1:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender1" TargetControlID="txtMoblie" ValidChars="0123456798" runat="server">
                            </cc1:FilteredTextBoxExtender>
                    </td>
                </tr>
                <tr>
                    <td>
                        &#2357;&#2375;&#2351;&#2352;&#2361;&#2366;&#2313;&#2360;/ &#2327;&#2379;&#2342;&#2366;&#2350; &#2325;&#2366; &#2346;&#2340;&#2366;
                        <span>*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtaddress" runat="server" CssClass="txtbox reqirerd"  TextMode="MultiLine" MaxLength="100" onkeypress="MaxLengthCount(this,100);javascript:tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox></td>
                    <td>
                        &#2332;&#2367;&#2354;&#2366; <span>*</span> </td>
                    <td>
                        <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="txtbox reqirerd">
                            <asp:ListItem Value="0">&#2360;&#2375;&#2354;&#2375;&#2325;&#2381;&#2335;..</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        &#2358;&#2361;&#2352;/ &#2392;&#2360;&#2381;&#2348;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350;
                    </td>
                    <td>
                        <asp:TextBox ID="txtCity" runat="server" CssClass="txtbox " MaxLength="30" onkeypress="javascript:tbx_fnAlphaNumericOnly(event, this)"></asp:TextBox>
                       
                    </td>
                    <td>
                        &#2346;&#2367;&#2344; &#2325;&#2379;&#2337;
                    </td>
                    <td>
                        <asp:TextBox ID="txtPinCode" runat="server" CssClass="txtbox " MaxLength="6"  onkeyup='javascript:tbx_fnSignedNumericCheck(this);'
                            Width="138px"></asp:TextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td>
                        &#2347;&#2376;&#2325;&#2381;&#2360; &#2344;&#2306;&#2348;&#2352;
                    </td>
                    <td>
                        <span style="font-size:12px;">&#2319;&#2360;&#2335;&#2368;&#2337;&#2368; &#2325;&#2379;&#2337; - &#2347;&#2376;&#2325;&#2381;&#2360; &#2344;&#2306;&#2348;&#2352;  </span>
                        <br />
                        <asp:TextBox ID="txtstdCode1" runat="server" MaxLength="5" 
                            onkeypress="javascript:fnSetPhoneDigits(event, this);" Width="45"></asp:TextBox>
                        -<asp:TextBox ID="txtFaxNo" runat="server" CssClass="txtbox " 
                            onkeyup='javascript:tbx_fnSignedNumericCheck(this);' MaxLength="8" 
                            Width="70px"></asp:TextBox></td>
                    <td>
                        &#2312; &#2350;&#2375;&#2354; &#2310;&#2312;.&#2337;&#2368;.</td>
                    <td>
                        <asp:TextBox ID="txtEmailID" runat="server" CssClass="txtbox " MaxLength="30"></asp:TextBox>
                        <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailID"
                            ErrorMessage="&#2325;&#2371;&#2346;&#2351;&#2366; &#2360;&#2361;&#2368; &#2312;-&#2350;&#2375;&#2354; &#2310;&#2312;.&#2337;&#2368;. &#2342;&#2352;&#2381;&#2332; &#2325;&#2352;&#2375;&#2306;" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                        </asp:RegularExpressionValidator>
                        </td>
                </tr>
                <tr>
                    <td>
                        &#2346;&#2376;&#2344; &#2344;&#2350;&#2381;&#2348;&#2352; <span>
                        </span> </td>
                    <td>
                        <asp:TextBox ID="txtPanNo" runat="server" CssClass="txtbox"  onkeypress="javascript:tbx_fnAlphaNumericOnly(event, this)" onblur="fnValidatePAN(this);"    MaxLength="10"></asp:TextBox></td>
                    <td>
                        &#2335;&#2367;&#2344; &#2344;&#2350;&#2381;&#2348;&#2352;
                    <span></span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTinNo" runat="server" CssClass="txtbox " 
                            onkeypress="javascript:tbx_fnAlphaNumericOnly(event, this)" MaxLength="15"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        &#2360;&#2352;&#2381;&#2357;&#2367;&#2360; &#2335;&#2376;&#2325;&#2381;&#2360; &#2344;&#2306;&#2348;&#2352;</td>
                    <td>
                        <asp:TextBox ID="txtServiceTaxNo" runat="server" CssClass="txtbox " 
                            onkeypress="javascript:tbx_fnAlphaNumericOnly(event, this)" MaxLength="20" 
                            ontextchanged="txtServiceTaxNo_TextChanged"></asp:TextBox></td>
                    <td>
                        &#2357;&#2376;&#2328;&#2340;&#2366; &#2309;&#2357;&#2343;&#2367; (&#2350;&#2366;&#2361; &#2350;&#2375;&#2306; ) </td>
                    <td>
                        <asp:TextBox ID="txtServicePe" runat="server" CssClass="txtbox" 
                            onkeyup='javascript:tbx_fnSignedIntegerCheck(this);'  MaxLength="3"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        &#2309;&#2350;&#2366;&#2344;&#2340; &#2352;&#2366;&#2358;&#2368;
                        <span>*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRegAmount" runat="server" CssClass="txtbox reqirerd" onkeyup='javascript:tbx_fnSignedNumericCheck(this);'
                            MaxLength="6" ></asp:TextBox></td>
                    <td>
                        <strong>&#2337;&#2368;.&#2337;&#2368;./&#2330;&#2375;&#2325; &#2344;&#2306;&#2348;&#2352; 
                        </strong>
                    </td>
                    <td style="font-weight: bold">
                        <asp:TextBox ID="txtCheckNo" runat="server" CssClass="txtbox reqirerd" onkeyup='javascript:tbx_fnSignedIntegerCheck(this);' MaxLength="10"  ></asp:TextBox></td>
                </tr>
                <tr style="font-weight: bold">
                    <td>
                        &#2348;&#2376;&#2306;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;<span 
                            class="required"> </span> </td>
                    <td>
                        <asp:TextBox ID="txtBankName" runat="server" CssClass="txtbox reqirerd" onkeypress="javascript:tbx_fnAlphaNumericOnly(event, this)" MaxLength="30"></asp:TextBox></td>
                    <td>
                        <strong>&#2337;&#2368;.&#2337;&#2368;./&#2330;&#2375;&#2325; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;</strong></td>
                    <td>
                        <asp:TextBox ID="txtCheckDate" runat="server" CssClass="txtbox reqirerd" 
                            MaxLength="10" ></asp:TextBox>
                             <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtCheckDate" Format="dd/MM/yyyy">
                     </cc1:CalendarExtender>
                        
                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server"  MaskType="Date" CultureName="en-GB" TargetControlID="txtCheckDate" Mask="99/99/9999">
                                   </cc1:MaskedEditExtender>
                    </td>
                </tr>
                <tr style="font-weight: bold">
                    <td>
                        &#2335;&#2375;&#2344; &#2344;&#2306;&#2348;&#2352;
                    </td>
                    <td>
                        <asp:TextBox ID="txttenno" runat="server" CssClass="txtbox reqirerd" 
                            MaxLength="10" onkeyup="javascript:tbx_fnSignedIntegerCheck(this);"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr style="font-weight: bold">
                    <td>
                        &#2357;&#2375;&#2351;&#2352;&#2361;&#2366;&#2313;&#2360;/ &#2327;&#2379;&#2342;&#2366;&#2350; &#2350;&#2376;&#2346;</td>
                    <td id="PhotoUpload3">
                        <asp:FileUpload ID="FlMapFile" runat="server" /></td>
                    <td>
                        &#2357;&#2375;&#2351;&#2352;&#2361;&#2366;&#2313;&#2360;/ &#2327;&#2379;&#2342;&#2366;&#2350; &#2309;&#2327;&#2381;&#2352;&#2368;&#2350;&#2375;&#2306;&#2335;
                    </td>
                    <td id="PhotoUpload">
                        <asp:FileUpload ID="FlAgrimentFile" runat="server" /></td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center">
                  <div class="card-header"> <h2>    &#2325;&#2367;&#2352;&#2366;&#2351;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339;</h2> </div> 
                    </td>
                </tr>
                <tr>
                    <td>
                        &#2325;&#2367;&#2352;&#2366;&#2351;&#2366; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
                        <span>*</span> </td>
                    <td colspan="3">
                        <asp:DropDownList ID="txtRentDate" runat="server" CssClass="txtbox reqirerd"   MaxLength="10"></asp:DropDownList></td>
             
       
                </tr>
                <tr>
                    <td>
                        &#2325;&#2367;&#2352;&#2366;&#2351;&#2366; &#2352;&#2366;&#2358;&#2368; (&#2346;&#2381;&#2352;&#2340;&#2367; 
                        &#2351;&#2370;&#2344;&#2367;&#2335;) <span>*</span> </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtRentAmount" runat="server" CssClass="txtbox reqirerd" onkeyup='javascript:tbx_fnSignedNumericCheck(this);'
                            MaxLength="5" AutoPostBack="True" 
                            ontextchanged="txtRentAmount_TextChanged"></asp:TextBox>
                        <asp:DropDownList ID="ddlAmountType" runat="server" CssClass="txtbox reqirerd">
                            <asp:ListItem Value="0">&#2330;&#2369;&#2344;&#2375; </asp:ListItem>
                            <asp:ListItem Value="1">&#2357;&#2352;&#2381;&#2327; &#2347;&#2368;&#2335; </asp:ListItem>
                            <asp:ListItem Value="2">&#2357;&#2352;&#2381;&#2327; &#2350;&#2368;&#2335;&#2352; </asp:ListItem>
                            <asp:ListItem Value="3">&#2350;&#2368;&#2335;&#2352;</asp:ListItem>
                            <asp:ListItem Value="4">&#2350;&#2376;&#2335;&#2381;&#2352;&#2367;&#2325; &#2335;&#2344;</asp:ListItem>
                        </asp:DropDownList>
                    &nbsp;<asp:Label ID="Label1" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; "  
                            onclick="btnSave_Click" />
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <asp:HiddenField ID="mapID" runat="server" />
                        <asp:HiddenField ID="Agriment" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center">
                        
                    </td>
                </tr>
            </table>
        </div>
        <script>
            
        var Globlephoto =  document.getElementById("PhotoUpload").innerHTML;
        $('#ctl00_ContentPlaceHolder1_FlAgrimentFile').live('change', function () {

            //this.files[0].size gets the size of your file.
             if (this.files[0].size / 1024 > 500) {
                 alert("file size cannot geater then 500 kb");
                  document.getElementById("PhotoUpload").innerHTML=Globlephoto;
                
            }

          });
          var Globlephoto2 = document.getElementById("PhotoUpload3").innerHTML;
          $('#ctl00_ContentPlaceHolder1_FlMapFile').live('change', function () {

              //this.files[0].size gets the size of your file.
              if (this.files[0].size / 1024 > 500) {
                  alert("file Size cannot geater then 500 kb");
                  document.getElementById("PhotoUpload3").innerHTML = Globlephoto2;

              }

          });
        
        </script>
        </ContentTemplate> </asp:UpdatePanel> 
    </div>
</asp:Content>

