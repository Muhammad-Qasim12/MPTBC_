<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TenderParticipent.aspx.cs" Inherits="Depo_Tender_TenderParticipent" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
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
                    Obj.value = "";
                    alert("Invaild PAN Card No.");
                    return false;
                }
            }
        }
    </script>




    <%--<asp:UpdatePanel runat="server" ID="UpdatePnl">
<ContentTemplate>--%>

    <%--<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePnl">
                            <ProgressTemplate>
                                <div class="fade">
                                </div>
                                <div class="progress">
                                    <img src="../images/loading.gif" alt="Loading..." width="110" height="110" />
                                </div>
                            </ProgressTemplate>
                            </asp:UpdateProgress>--%>
    <div class="box table-responsive">
        <div class="portlet-header ui-widget-header">&#2335;&#2375;&#2306;&#2337;&#2352; &#2350;&#2375;&#2306; &#2349;&#2366;&#2327; &#2354;&#2375;&#2344;&#2375; &#2357;&#2366;&#2354;&#2368; &#2346;&#2366;&#2352;&#2381;&#2335;&#2367;&#2351;&#2379;&#2306; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Information Of Participating Patries In Tender </div>
        <div class="portlet-content">
            <div class="table-responsive ">

                <asp:Panel ID="messDiv" runat="server">
                    <asp:Label runat="server" ID="lblMess" class="notification"></asp:Label>
                </asp:Panel>


             
                    <table width="100%">
                        <tr>
                            <td style="width: 380px;">&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; / Tender Name</td>
                            <td colspan="3">
                                <asp:DropDownList ID="ddlTenderID_I" runat="server" Width="400px">
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>

                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>


                    </table>
                    <table width="100%" cellpadding="1px">
                        <tr>
                            <td colspan="4"></td>
                        </tr>

                        <tr>
                            <td style="width: 380px;">टेंडर/ &#2325;&#2344;&#2381;&#2360;&#2352;&#2381;&#2344; &#2325;&#2366; &#2344;&#2366;&#2350; / Name of the Tender/Concern</td>
                            <td colspan="3">
                                <asp:TextBox ID="txtNameofParty" MaxLength="150" CssClass="txtbox reqirerd" runat="server" Width="300px"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender runat="server" ID="FilterName" InvalidChars="~`<=>?|+:;\!@#$^&0123456789_*" FilterMode="InvalidChars" TargetControlID="txtNameofParty"></cc1:FilteredTextBoxExtender>
                            </td>
                        </tr>

                        <tr>
                            <td style="vertical-align: middle;">&#2346;&#2340;&#2366; (&#2335;&#2375;&#2354;. & &#2350;&#2379;&#2348;&#2366;&#2311;&#2354; &#2344;&#2306;&#2348;&#2352;) / Address (with Tel. & Mob. No.)</td>
                            <td colspan="3">
                                <asp:TextBox ID="txtAddress_Party" runat="server" TextMode="MultiLine" Width="300px" CssClass="txtbox reqirerd" onkeypress="MaxLengthCount(this,250);" onpaste="MaxLengthCount(this,250);"></asp:TextBox>

                                <cc1:FilteredTextBoxExtender runat="server" ID="FiltertxtAddress_Party" InvalidChars="~`<=>?|+:;!@#$^&\_*" FilterMode="InvalidChars" TargetControlID="txtAddress_Party"></cc1:FilteredTextBoxExtender>

                            </td>
                        </tr>

                        <tr>
                            <td style="vertical-align: middle;">&#2349;&#2379;&#2346;&#2366;&#2354; &#2325;&#2375; &#2321;&#2347;&#2367;&#2360;/ &#2327;&#2375;&#2352;&#2366;&#2332; &#2325;&#2366; &#2346;&#2340;&#2366; &#2319;&#2357;&#2306; &#2335;&#2375;&#2354;. &#2344;&#2306;&#2348;&#2352; / Address and Tel. number of Garage/office at Bhopal</td>

                            <td colspan="3">
                                <asp:TextBox ID="txtAddress_Garage" runat="server" TextMode="MultiLine" Width="300px" CssClass="txtbox reqirerd" onkeypress="MaxLengthCount(this,250);" onpaste="MaxLengthCount(this,250);"></asp:TextBox>

                                <cc1:FilteredTextBoxExtender runat="server" ID="FiltertxtAddress_Garage" InvalidChars="~`<=>?|+:;!@#$^&\_*" FilterMode="InvalidChars" TargetControlID="txtAddress_Garage"></cc1:FilteredTextBoxExtender>

                            </td>
                        </tr>

                        <tr>
                            <td>&#2325;&#2344;&#2381;&#2360;&#2352;&#2381;&#2344; &#2325;&#2368; &#2346;&#2381;&#2352;&#2325;&#2371;&#2340;&#2367; / Nature of the concern</td>

                            <td>
                                <asp:DropDownList ID="txtNature_Concern" runat="server" CssClass="txtbox reqirerd">
                                    <asp:ListItem Text="Sole Proprietor" Value="Sole Proprietor"></asp:ListItem>
                                    <asp:ListItem Text="Partnership firm" Value="Partnership firm"></asp:ListItem>
                                    <asp:ListItem Text="Company" Value="Company"></asp:ListItem>
                                    <asp:ListItem Text="Government Department" Value="Government Department"></asp:ListItem>
                                    <asp:ListItem Text="Public Sector Organization" Value="Public Sector Organization"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td colspan="2">(i.e., Sole Proprietor or Partnership firm or a company or a government department or a public sector organization.)
                            </td>
                        </tr>

                        <tr>
                            <td>टेंडर &#2325;&#2368; &#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2381;&#2352;&#2375;&#2358;&#2344; &#2344;&#2306;&#2348;&#2352; / Registration No. of Tender</td>

                            <td>
                                <asp:TextBox ID="txtRegistrationNo" runat="server" CssClass="txtbox reqirerd" MaxLength="10"></asp:TextBox>

                                <cc1:FilteredTextBoxExtender runat="server" ID="FilteretxtRegistrationNo" InvalidChars="~`<=>?|+:;!@#$^&_*" FilterMode="InvalidChars" TargetControlID="txtRegistrationNo"></cc1:FilteredTextBoxExtender>


                            </td>
                        </tr>

                        <tr>
                            <td>&#2309;&#2346;&#2354;&#2379;&#2337; &#2325;&#2352;&#2375; &#2360;&#2340;&#2381;&#2351;&#2366;&#2346;&#2367;&#2340; &#2347;&#2379;&#2335;&#2379;&#2325;&#2377;&#2346;&#2368; &#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2381;&#2352;&#2375;&#2358;&#2344; &#2325;&#2368; / Upload attested photocopy of registration</td>
                            <td colspan="3">
                                <asp:FileUpload ID="FileRegistration" runat="server" />
                                <asp:Label ID="LblFileRegistration" runat="server" ForeColor="SkyBlue" Font-Size="Small"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td>&#2348;&#2366;&#2340;&#2330;&#2368;&#2340; &#2361;&#2375;&#2340;&#2369; &#2344;&#2306;&#2348;&#2352;. / Contact No.</td>

                            <td>
                                <asp:TextBox ID="txtTel_MobNo" runat="server" onkeypress='javascript:fnSetPhoneDigits(event, this);' MaxLength="13"></asp:TextBox>
                            </td>

                            <td>&#2335;&#2375;&#2354;&#2368;&#2347;&#2379;&#2344;/ &#2350;&#2379;&#2348;&#2366;&#2311;&#2354; &#2344;&#2306;&#2348;&#2352; / Telephone / Mobile No. Office</td>
                            <td>
                                <asp:TextBox ID="txtTel_MobNo_Office" runat="server" onkeypress='javascript:fnSetPhoneDigits(event, this);' MaxLength="13"></asp:TextBox>
                            </td>
                        </tr>


                        <tr>
                            <td>टेंडर /&#2325;&#2344;&#2381;&#2360;&#2352;&#2381;&#2344; &#2325;&#2366; PAN &#2344;&#2306;&#2348;&#2352;/ PAN No. of Tender/Concern</td>

                            <td>
                                <asp:TextBox ID="txtPANNo" runat="server" CssClass="txtbox reqirerd" onblur="fnValidatePAN(this);"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>अपलोड करे PAN काड का सत्यापित फोटोकॉपी / Upload attested photocopy of PAN</td>
                            <td colspan="3">
                                <asp:FileUpload ID="FilePANNo" runat="server" />
                                <asp:Label ID="lblFilePANNo" runat="server" ForeColor="SkyBlue" Font-Size="Small"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td>&#2337;&#2367;&#2350;&#2366;&#2306;&#2337; &#2337;&#2381;&#2352;&#2366;&#2347;&#2381;&#2335; &#2344;&#2306;&#2348;&#2352; / Demad draft No.</td>

                            <td>
                                <asp:TextBox ID="txtDD_Details" runat="server" MaxLength="20" CssClass="txtbox reqirerd"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender runat="server" ID="FiltertxtDD_Details" InvalidChars="~`<=>?|+:;!@#$^&" FilterMode="InvalidChars" TargetControlID="txtDD_Details"></cc1:FilteredTextBoxExtender>


                            </td>

                            <td>&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Date </td>
                            <td>
                                <asp:TextBox ID="txtDDDate" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                                <cc1:CalendarExtender Format="dd/MM/yyyy" ID="CaltxtDDDate" TargetControlID="txtDDDate" runat="server"></cc1:CalendarExtender>
                                <cc1:MaskedEditExtender ID="MasktxtDDDate" TargetControlID="txtDDDate" Mask="99/99/9999" UserDateFormat="None" MaskType="Date" runat="server"></cc1:MaskedEditExtender>


                            </td>
                        </tr>

                        <tr>
                            <td>&#2348;&#2376;&#2306;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Bank Name</td>
                            <td>
                                <asp:TextBox ID="txtBankDetails" runat="server" CssClass="txtbox reqirerd" MaxLength="80"></asp:TextBox>

                                <cc1:FilteredTextBoxExtender runat="server" ID="FiltetxtBankDetails" InvalidChars="~`<=>?|+:;!@#$^&_*" FilterMode="InvalidChars" TargetControlID="txtBankDetails"></cc1:FilteredTextBoxExtender>

                            </td>

                            <td>EMD (Earnest Money Deposit)  in Rs.</td>
                            <td>
                                <asp:TextBox ID="txtEMD_Amt" runat="server" MaxLength="6" CssClass="txtbox reqirerd" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'></asp:TextBox>


                            </td>
                        </tr>

                        <tr>
                            <td>&#2319;&#2344;. &#2310;&#2311;. &#2335;&#2368;. &#2324;&#2352; &#2311;&#2360;&#2325;&#2375; &#2320;&#2344;&#2368;&#2325;&#2381;&#2360;&#2330;&#2352; &#2325;&#2375; &#2361;&#2352; &#2346;&#2375;&#2332; &#2346;&#2375; &#2361;&#2360;&#2381;&#2340;&#2366;&#2325;&#2381;&#2359;&#2352; &#2324;&#2352; &#2360;&#2381;&#2335;&#2366;&#2350;&#2381;&#2346;&#2337; &#2361;&#2376; &#2325;&#2368; &#2344;&#2361;&#2368;&#2306; / Whether each page of NIT and its Annexure have been signed and stamped.</td>
                            <td colspan="3">
                                <asp:RadioButtonList ID="radioNITSign_I" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="radioNITSign_I_SelectedIndexChanged">
                                    <asp:ListItem Text="&#2361;&#2366;&#2305; / Yes" Value="1" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="&#2344;&#2361;&#2368;&#2306; / No" Value="0"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>

                        <tr>
                            <td>टेंडर की अन्य कोई महत्वपूर्ण जानकारी / Any other Information Important Hint The Opinion Of The Tender.</td>
                            <td colspan="3">
                                <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Width="300px"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="4">
                                <asp:Button ID="btnTendererSave" runat="server" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; / Save" OnClick="btnTendererSave_Click" OnClientClick="return ValidateAllTextForm();" />
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                <asp:HiddenField ID="HiddenField2" runat="server" />
                            </td>
                        </tr>

                    </table>
               

            </div>
        </div>
</asp:Content>

