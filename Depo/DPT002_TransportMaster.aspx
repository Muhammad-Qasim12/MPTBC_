<%@ Page Title="&#2335;&#2381;&#2352;&#2366;&#2306;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335;&#2352; &#2350;&#2366;&#2360;&#2381;&#2335;&#2352; / Transport Master" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableEventValidation="false"  EnableViewStateMac ="false" CodeFile="DPT002_TransportMaster.aspx.cs" Inherits="Depo_DPT002_TransportMaster" %>
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
                 Obj.value = "";
                 Obj.focus();
                 alert("Invalid Pan No");
                 
                 return false;
             }
             if (code.test(code_chk) == false) {
                 Obj.value = "";
                 alert("Invaild PAN Card No.");
                 return false;
             }
         }
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
        control.makeTransliteratable(['ctl00_ContentPlaceHolder1_txtTransPort']);
        control.makeTransliteratable(['ctl00_ContentPlaceHolder1_txtWonerName']);
        control.makeTransliteratable(['ctl00_ContentPlaceHolder1_txtAddress']);
        control.makeTransliteratable(['ctl00_ContentPlaceHolder1_txtCity']);

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

<div class="box table-responsive">
                            <div class="card-header">
                                <h2><span>&#2335;&#2381;&#2352;&#2366;&#2306;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335;&#2352; &#2350;&#2366;&#2360;&#2381;&#2335;&#2352; / Transport Master</span></h2>
                            </div>
                               
                            <div style="padding:0 10px;">
                            <div>* &#2347;&#2368;&#2354;&#2381;&#2337; &#2349;&#2352;&#2344;&#2366; &#2310;&#2357;&#2358;&#2381;&#2351;&#2325; &#2361;&#2376; / *Field IS Required To Be Filled</div>
                            <asp:Panel   class="form-message error" runat="server" id="mainDiv" style="display: none;padding-top:10px;padding-bottom:10px;">
                <asp:Label  id="lblmsg" class="notification" runat="server">
                
            </asp:Label>
            </asp:Panel>
                            <table width="100%">
                                <tr>
                                    <td>  &#2335;&#2381;&#2352;&#2366;&#2306;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335;<span>&#2352;&nbsp; &#2325;&#2350;&#2381;&#2346;&#2344;&#2368; &#2325;&#2366;</span> &#2344;&#2366;&#2350; / Transport Company Name <span>*</span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTransPort" runat="server" CssClass="txtbox reqirerd" onkeypress="javascript:tbx_fnAlphaOnly(event, this)" MaxLength="50"></asp:TextBox>
                                         
                                        </td>
                                    <td>  &#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; <span>*</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlFyYear" runat="server" CssClass="txtbox reqirerd" onkeypress="javascript:tbx_fnAlphaNumericOnly(event, this)">
                                        </asp:DropDownList>

                                    </td>
                                </tr>
                                <tr>
                                    <td>  &#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2381;&#2352;&#2375;&#2358;&#2344; &#2344;&#2306;&#2348;&#2352; / Registration No.
                                        <span>*</span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRegNO" runat="server" CssClass="txtbox reqirerd"  MaxLength="15"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender
                                        ID="FilteredTextBoxExtender5" TargetControlID="txtRegNO" ValidChars="ASDFGHJKLZXCVBNMQWERTYUIOPasdfghjklzxcvbnmqwertyuiop/-1234567890-" runat="server">
                                    </cc1:FilteredTextBoxExtender>
                                         
                                        </td>
                                    <td>  &#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2381;&#2352;&#2375;&#2358;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Registration Date
                                        <span>*</span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRegDate" runat="server" CssClass="txtbox reqirerd" MaxLength="10"></asp:TextBox>
                                         <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtRegDate" Format="dd/MM/yyyy">
                                         </cc1:CalendarExtender>
                                          

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        ट्रांसपोर्ट मालिक &#2325;&#2366; &#2344;&#2366;&#2350; / Transport Owner&nbsp; Name <span>*</span>
                    </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtWonerName" runat="server" CssClass="txtbox reqirerd" onkeypress="javascript:tbx_fnAlphaOnly(event, this)" MaxLength="50"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td >&#2335;&#2375;&#2354;&#2368;&#2347;&#2379;&#2344; &#2344;&#2306;&#2348;&#2352; / Telephone No.</td>
                                    <td >
                                        <span style="font-size:12px;"> &#2319;&#2360;&#2335;&#2368;&#2337;&#2368; &#2325;&#2379;&#2337;  - &nbsp;&nbsp;&#2335;&#2375;&#2354;&#2368;&#2347;&#2379;&#2344; &#2344;&#2406; </span><br />
                                        <asp:TextBox ID="txtstdCode" Width="45" runat="server" 
                                            onkeypress='javascript:fnSetPhoneDigits(event, this);' MaxLength="5" ></asp:TextBox>
                       - <asp:TextBox
                            ID="txtTelPhone2" runat="server" CssClass="txtbox " Width="70"  onkeypress='javascript:fnSetPhoneDigits(event, this);'
                             
                            MaxLength="8"></asp:TextBox><cc1:FilteredTextBoxExtender
                                ID="FilteredTextBoxExtender2" TargetControlID="txtTelPhone2" ValidChars="0123456798" runat="server">
                            </cc1:FilteredTextBoxExtender></td>
                                    <td >&#2350;&#2379;&#2348;&#2366;&#2311;&#2354; &#2344;&#2306;&#2348;&#2352; / Mobile No.
                                    </td>
                                    <td >
                                        +91<asp:TextBox ID="txtMoblieNO" runat="server" CssClass="txtbox reqirerd" onkeyup='javascript:tbx_fnSignedIntegerCheck(this);'  MaxLength="10" ></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td >
                                        <span>&#2335;&#2381;&#2352;&#2366;&#2306;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335;र &#2325;&#2366; </span>&nbsp;&#2346;&#2340;&#2366; / Transporter Adderss
                                        <span>*</span>
                                    </td>
                                    <td >
                                        <asp:TextBox ID="txtAddress" runat="server" CssClass="txtbox reqirerd" MaxLength="100" onkeypress="MaxLengthCount(this,100);javascript:tbx_fnAlphaNumericOnly(event, this);"   TextMode="MultiLine"></asp:TextBox></td>
                                    <td >
                                        &#2332;&#2367;&#2354;&#2366;/ District <span>*</span>
                    </td>
                                    <td >
                                        <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="txtbox reqirerd">
                                            <asp:ListItem Value="0">&#2360;&#2375;&#2354;&#2375;&#2325;&#2381;&#2335;..</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                    <td >
                        &#2358;&#2361;&#2352;/ &#2392;&#2360;&#2381;&#2348;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; / City / Town Name
                    </td>
                    <td >
                        <asp:TextBox ID="txtCity" runat="server" CssClass="txtbox " MaxLength="30" onkeypress="javascript:tbx_fnAlphaOnly(event, this)"></asp:TextBox>
                      
                    </td>
                    <td >
                        &#2346;&#2367;&#2344; &#2325;&#2379;&#2337; / Pin Code&nbsp;
                    </td>
                    <td >
                        <asp:TextBox ID="txtPinCode" runat="server" CssClass="txtbox " MaxLength="6" onkeyup='javascript:tbx_fnSignedIntegerCheck(this);' 
                            Width="138px"></asp:TextBox>
                       
                    </td>
                                </tr>
                                <tr>
                                    <td >
                                        &#2347;&#2376;&#2325;&#2381;&#2360; &#2344;&#2306;&#2348;&#2352; / Fax No.
                                      
                                    </td>
                                    <td >
                                    <span style="font-size:12px;"> &#2319;&#2360;&#2335;&#2368;&#2337;&#2368; &#2325;&#2379;&#2337;  - &#2347;&#2376;&#2325;&#2381;&#2360; &#2344;&#2306;&#2348;&#2352;  </span><br />
                                    <asp:TextBox ID="txtFaxCode" runat="server" MaxLength="5" CssClass="txtbox " Width="45px"
                                            onkeyup='javascript:tbx_fnSignedNumericCheck(this);' ></asp:TextBox>-  
                                        <asp:TextBox ID="txtFaxNo" runat="server" MaxLength="12" CssClass="txtbox " Width="70px" 
                                            onkeyup='javascript:tbx_fnSignedNumericCheck(this);' ></asp:TextBox>
                                          
                                            </td>
                                    <td >
                                        &#2312; &#2350;&#2375;&#2354; &#2310;&#2312;.&#2337;&#2368; / Email Id</td>
                                    <td >
                                        <asp:TextBox ID="txtemailID" runat="server" CssClass="txtbox " MaxLength="50"></asp:TextBox>
                                        <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ControlToValidate="txtemailID"
                            ErrorMessage="&#2325;&#2371;&#2346;&#2351;&#2366; &#2360;&#2361;&#2368; &#2312;-&#2350;&#2375;&#2354; &#2310;&#2312;.&#2337;&#2368;. &#2342;&#2352;&#2381;&#2332; &#2325;&#2352;&#2375;&#2306;" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                        </asp:RegularExpressionValidator>
                                        </td>
                                </tr>
                                <tr>
                                    <td>
                                        &#2346;&#2376;&#2344; &#2344;&#2350;&#2381;&#2348;&#2352; / Pan NO.
                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPanNo" runat="server" CssClass="txtbox reqirerd"   onblur="fnValidatePAN(this);" MaxLength="12"></asp:TextBox></td>
                                    <td>
                                        &#2335;&#2367;&#2344; &#2344;&#2350;&#2381;&#2348;&#2352; / Tin No.
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTinNo" runat="server" CssClass="txtbox " 
                                            onkeypress="javascript:tbx_fnSignedNumericCheck(event, this)" MaxLength="12"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        &#2360;&#2352;&#2381;&#2357;&#2367;&#2360; &#2335;&#2376;&#2325;&#2381;&#2360; &#2344;&#2306;&#2348;&#2352; / Sevice Tax No. <span>*</span>
                    </td>
                                    <td>
                                        <asp:TextBox ID="txtserviceTax" runat="server" CssClass="txtbox " 
                                            MaxLength="15" onkeypress="javascript:tbx_fnAlphaNumericOnly(event, this)"></asp:TextBox></td>
                                    <td>
                                        &#2357;&#2376;&#2343;&#2381;&#2351;&#2340;&#2366; &#2325;&#2368; &#2309;&#2357;&#2343;&#2367; <span>
                                        (&#2350;&#2366;&#2361; &#2350;&#2375;&#2306;) / Validity Perioud</span></td>
                                    <td>
                                        <asp:TextBox ID="txtServiceP" runat="server" CssClass="txtbox reqirerd" MaxLength="3"></asp:TextBox>
                                       
                                      <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtServiceP" Format="dd/MM/yyyy">
                                         </cc1:CalendarExtender>
                                        </td>
                                </tr>
                                <tr>
                                    <td >&#2309;&#2350;&#2366;&#2344;&#2340; &#2325;&#2368; &#2352;&#2366;&#2358;&#2368; / Security&nbsp; Amount 
                                        <span>*</span>
                                    </td>
                                    <td >
                                        <asp:TextBox ID="txtRegAmonut" runat="server" CssClass="txtbox reqirerd" MaxLength="6" onkeyup='javascript:tbx_fnSignedNumericCheck(this);'></asp:TextBox></td>
                                    <td >&#2337;&#2368;.&#2337;&#2368;./&#2330;&#2375;&#2325; &#2344;&#2306;&#2348;&#2352; / D.D. / Cheqe No.
                                    </td>
                                    <td >
                                        <asp:TextBox ID="txtDdNo" runat="server" CssClass="txtbox reqirerd" MaxLength="15" onkeypress="javascript:tbx_fnSignedNumericCheck(event, this)"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        &#2348;&#2376;&#2306;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Bank Name&nbsp;
                    </td>
                                    <td>
                                         <asp:DropDownList ID="txtBankName" runat="server" CssClass="txtbox reqirerd">
                                            <asp:ListItem Value="0">&#2360;&#2375;&#2354;&#2375;&#2325;&#2381;&#2335;..</asp:ListItem>
                                        </asp:DropDownList>
                                       <%-- <asp:TextBox ID="txtBankName" runat="server" CssClass="txtbox reqirerd" MaxLength="40" onkeypress="javascript:tbx_fnAlphaOnly(event, this)"></asp:TextBox>--%>


                                    </td>
                                    <td>
                                        &#2337;&#2368;.&#2337;&#2368;./&#2330;&#2375;&#2325; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / D.D. / Cheqe Date <span>*</span>
                    </td>
                                    <td>
                                        <asp:TextBox ID="txtddDate" runat="server" CssClass="txtbox reqirerd" 
                                            MaxLength="15"></asp:TextBox>
                                            <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtddDate" Format="dd/MM/yyyy">
                                         </cc1:CalendarExtender>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &#2335;&#2375;&#2344; &#2344;&#2306;&#2348;&#2352; / Tan No.
                                        </td>
                                    <td>
                                        <asp:TextBox ID="txtTenNumber" runat="server" CssClass="txtbox" MaxLength="15" onkeyup='javascript:tbx_fnSignedNumericCheck(this);'></asp:TextBox>
                                    </td>
                                    <td>
                                        ई.पी.ऍफ़ नंबर /EPF NO</td>
                                    <td>
                                        <asp:TextBox ID="txtEpfNo" runat="server" CssClass="txtbox" MaxLength="15" onkeyup='javascript:tbx_fnSignedNumericCheck(this);'></asp:TextBox>
                                    </td>
                                </tr>
        <tr>
            <td colspan="4" style="text-align: center">
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save  "   
                            onclick="btnSave_Click" />
                <cc1:calendarextender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtRegDate" Format="dd/MM/yyyy">
        </cc1:calendarextender></td>
        </tr>
    </table>
                            
                            </div> </div> 
</asp:Content>

