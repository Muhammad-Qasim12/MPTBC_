<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Loginold.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml" lang="en" xml:lang="en">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>M.P. Text Book Corporation</title>
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="css/login.css" rel="stylesheet" media="all" />
    <script type="text/javascript" src="js/jquery-1.3.2.js"></script>
    <script type="text/javascript" src="js/jquery-ui-1.7.2.js"></script>
    <script type="text/javascript" src="js/custom.js"></script>
    <script type="text/javascript" src="js/aes.js"></script>

    <!--[if IE 6]>
	<link href="css/ie6.css" rel="stylesheet" media="all" />
	
	<script src="js/pngfix.js"></script>
	<script>
	  /* EXAMPLE */
	  DD_belatedPNG.fix('.logo, .other ul#dashboard-buttons li a');

	</script>
	<![endif]-->
    <!--[if IE 7]>
	<link href="css/ie7.css" rel="stylesheet" media="all" />
	<![endif]-->


    <script type="text/javascript">
        function CoreShow() {
            document.getElementById("DivDate").style.display = "Block";
        }
        function BuisnessShow() {
            document.getElementById("DivDate").style.display = "None";
        }
        function OnLogout() {
            var backlen = history.length;
            history.go(-backlen);
            window.location.replace("Default.aspx");
        }
    </script>
    <style type="text/css">
        .info {
            color: #8a6d3b;
            background-color: #FDF7D9;
            border-color: #8a6d3b;
            padding: 5px 15px 15px;
            border: 1px solid rgb(175, 138, 54);
            border-radius: 4px;
            width: 300px;
            position: absolute;
            top: 176px;
            left: 30px;
            line-height: 22px;
            text-align:justify;
            
        }

            .info h4 {
                text-align: center;
                text-decoration: underline;
                color: #804A0F;
                font-size: 14px;
            }

            .info ul {
                margin: 0;
                padding: 0;
            }

            .info b {
                color: #0C9002;
                font-size: 15px;
            }

            .info li {
                list-style: none;
                background: url(../images/correct.gif) no-repeat 0 5px;
                padding: 2px 22px;
                
            }
        @media (max-width: 1024px) {
            .info {
                display:none;
            }
        }
    </style>
</head>
<body > <%--onload="onload();"--%>
    <form id="frmLogin" runat="server" autocomplete="off">
        <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
        <script type="text/javascript">
            //function PwdChange() {
            //    var PwdM = document.getElementById('txtPswd').value;
            //    $.ajax({
            //        type: "POST",
            //        url: "Login.aspx/GetDate",
            //        data: '{sData:"' + PwdM + '"}',
            //        contentType: "application/json;charset=utf-8",
            //        dataType: "json",
            //        success: OnSuccess,
            //        failure: function (response) {
            //            alert(response.d);
            //        }
            //    });
            //};

            //function OnSuccess(response) {
            //    document.getElementById('txtPswd').value = response.d;
            //};

            function SubmitsEncry() {

                debugger;

                var txtpassword = document.getElementById("<%=txtPswd.ClientID %>").value.trim();
                CryptoJS.lib.WordArray.random(128 / 8);

                var key = CryptoJS.enc.Utf8.parse('<%=Session["KeyVal"]%>');
                var iv = CryptoJS.enc.Utf8.parse('<%=Session["KeyID"]%>');
                if (txtpassword != "") {
                    var encryptedpassword = CryptoJS.AES.encrypt(CryptoJS.enc.Utf8.parse(txtpassword), key,
                    {
                        keySize: 128 / 8,
                        iv: iv,
                        mode: CryptoJS.mode.CBC,
                        padding: CryptoJS.pad.Pkcs7
                    });
                    document.getElementById("<%=txtPswd.ClientID %>").value = encryptedpassword;
                }
            }
            function OnFocusBs() {
                document.getElementById('<%=rbBusiness.ClientID%>').focus();
            }
            function OnFocusCr() {
                document.getElementById('<%=rbcore.ClientID%>').focus();
            }
            function onload() {
                document.getElementById('<%=txtPswd.ClientID%>').value = "";
            }
            function OncheckUId() {
                if (document.getElementById('<%=txtUserName.ClientID%>').value == "") {
                    alert("Please Enter UserName");
                    document.getElementById('<%=txtUserName.ClientID%>').focus();
                    document.getElementById('<%=rbBusiness.ClientID%>').checked = "checked";
                    return false;
                }
                else {
                    return true;
                };
            }
        </script>

        <div class="info">
            <h4>Important Notice</h4>
            <ul>
                <li>&#2309;&#2327;&#2352; &#2310;&#2346; &#2360;&#2361;&#2368; &#2338;&#2306;&#2327; &#2360;&#2375; Logout &#2348;&#2335;&#2344; &#2325;&#2366; &#2313;&#2346;&#2351;&#2379;&#2327; &#2324;&#2352; &#2348;&#2381;&#2352;&#2366;&#2313;&#2395;&#2352; &#2348;&#2306;&#2342; &#2344;&#2361;&#2368;&#2306; &#2325;&#2352;&#2340;&#2375; &#2361;&#2376;, &#2340;&#2379; &#2310;&#2346;&#2325;&#2366; &#2326;&#2366;&#2340;&#2366; &#2309;&#2360;&#2381;&#2341;&#2366;&#2312; &#2352;&#2370;&#2346; &#2360;&#2375; &#2348;&#2306;&#2342; &#2325;&#2352; &#2342;&#2367;&#2351;&#2366; &#2332;&#2366;&#2319;&#2327;&#2366; |</li>
                <li>&#2325;&#2371;&#2346;&#2351;&#2366; &#2309;&#2346;&#2344;&#2366; &#2346;&#2366;&#2360;&#2357;&#2352;&#2381;&#2337; &#2360;&#2350;&#2351; &#2360;&#2350;&#2351; &#2346;&#2352; &#2348;&#2342;&#2354;&#2340;&#2375; &#2352;&#2361;&#2375; |</li>
                <li>&#2325;&#2371;&#2346;&#2351;&#2366; &#2309;&#2346;&#2344;&#2366; &#2354;&#2377;&#2327; &#2311;&#2344; &#2324;&#2352; &#2346;&#2366;&#2360;&#2357;&#2352;&#2381;&#2337; &#2325;&#2367;&#2360;&#2368; &#2309;&#2344;&#2381;&#2351; &#2325;&#2379; &#2348;&#2367;&#2354;&#2325;&#2369;&#2354; &#2344; &#2348;&#2340;&#2366;&#2351;&#2375; |</li>
                <li>&#2325;&#2371;&#2346;&#2351;&#2366; &#2343;&#2381;&#2351;&#2366;&#2344; &#2342;&#2375; &#2325;&#2368; &#2346;&#2379;&#2352;&#2381;&#2335;&#2354; &#2350;&#2376;&#2306; &#2325;&#2366;&#2350; &#2325;&#2352;&#2344;&#2375; &#2325;&#2375; &#2348;&#2366;&#2342; &#2346;&#2375;&#2332; &#2325;&#2375; &#2314;&#2346;&#2352; &#2342;&#2367;&#2351;&#2366; &#2327;&#2351;&#2366; Logout &#2348;&#2335;&#2344; &#2346;&#2352; &#2325;&#2381;&#2354;&#2367;&#2325; &#2325;&#2352; &#2325;&#2375; &#2309;&#2346;&#2344;&#2375; &#2325;&#2366;&#2352;&#2381;&#2351; &#2325;&#2379; &#2360;&#2350;&#2366;&#2346;&#2381;&#2340; &#2325;&#2352;&#2375; |</li>

            </ul>
        </div>
        <div style="text-align: right;">
            <a href="Login.aspx"><i class="fa fa-home" style="font-size: 26px; color: #fff; padding-right: 20px;" title="Home"></i></a>
        </div>

        <div class="login_wrapper">

            <div class="login">
                <p>

                    <img src="images/tbc-logo.png" alt="" />
                </p>
                <h2>M.P. Text Book Corporation</h2>
            </div>

            <div class="loginbox">
                <h3>User Login</h3>
                <div style="float: left; padding-left: 5px;">
                    <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>

                </div>
                <div style="padding-top: 50px;">
                    <div class="selectDiv">

                        <asp:DropDownList ID="ddllogintype" CssClass="minimal" runat="server">
                             <asp:ListItem Text="Departmental User" Value="Departmental User"></asp:ListItem>
                            <asp:ListItem Text="Management" Value="Management"></asp:ListItem>
                            <asp:ListItem Text="System Admin" Value="System Admin"></asp:ListItem>
                           
                            <asp:ListItem Text="External User" Value="External User"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="PT10">
                        <asp:TextBox ID="txtUserName" MaxLength="30" CssClass="txtbox" placeholder="Username"  OnTextChanged="txtUserName_TextChanged" AutoComplete="Off" AutoCompleteType="Disabled" runat="server"></asp:TextBox>

                    </div>
                    <div class="PT10" style="text-align: left;">
                        <asp:RadioButton ID="rbBusiness" runat="server" Text="Business Module" Checked="true" AutoPostBack="true" OnCheckedChanged="rbBusiness_CheckedChanged" onchange="OncheckUId();" GroupName="d" Visible="false"  />
                        <asp:RadioButton ID="rbcore" runat="server" Text="Core Module" AutoPostBack="true" OnCheckedChanged="rbcore_CheckedChanged" GroupName="d" onchange="return OncheckUId();" Visible="false"/>

                    </div>
                    <div class="PT10" id="DivDate" style="display: none; font-family: Arial;">
                        <table cellpadding="0" width="99%" cellspacing="0">
                            <tr>
                                <td valign="middle" align="left">From Date
                                </td>
                                <td valign="middle" align="left">
                                    <asp:TextBox ID="txtFDate" CssClass="txtbox" runat="server" Style="width: 100px;"></asp:TextBox>
                                </td>
                                <td valign="middle" align="left">To Date &nbsp;
                                </td>
                                <td valign="middle" align="right">
                                    <asp:TextBox ID="txtToDate" CssClass="txtbox" runat="server" Style="width: 100px;"></asp:TextBox>
                                </td>
                            </tr>

                        </table>
                    </div>
                    <div class="PT10">
                        <input type="password" style="display: none;" />
                        <asp:TextBox ID="txtPswd" MaxLength="200" CssClass="txtbox" AutoComplete="Off"
                            placeholder="Password" AutoCompleteType="Disabled" runat="server"></asp:TextBox> <%-- onblur="SubmitsEncry();"--%>

                    </div>


                    <div class="PT10">
                        <table cellpadding="0" width="99%" cellspacing="0">
                            <tr width="30%">
                                <td valign="top" align="left">

                                    <asp:Image ID="imgCaptcha" runat="server" Height="36" />
                                </td>
                                <td width="">&nbsp;</td>
                                <td width="69%">
                                    <asp:TextBox ID="txtImg" MaxLength="20" AutoComplete="Off" Width="100%" placeholder="Captcha Code" CssClass="txtbox" runat="server"></asp:TextBox>


                                </td>
                            </tr>

                        </table>
                    </div>
                    <div class="PT10 align-right" style="padding-top: 1px; padding-right: 5px;">
                        <a href="ForgotPassword.aspx" class="FP">Forgot Password?</a>
                    </div>
                    <div class="PT15">
                        <asp:Button ID="btnlogin" runat="server" class="com-btn" Text="Login" OnClick="btnLogin_Click"></asp:Button>

                    </div>
                </div>
            </div>
            <div class="PT15">
<a href="TBCPROGCAB.CAB" target="_blank" >
               बारकोड नवीन संस्करण</a>
                    </div> 
            <div class="copytxt">
                Copyright  2015. Design & Developed By <a href="#">Vayamtech</a> & <a href="#">C-Net Infotech Pvt. Ltd.</a>
            </div>
        </div>
        <cc1:CalendarExtender ID="ceFDate" runat="server" PopupButtonID="txtFDate" TargetControlID="txtFDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>

        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtToDate"
            Format="dd/MM/yyyy">
        </cc1:CalendarExtender>
        <asp:RequiredFieldValidator ID="rfvtxtUserName" runat="server"
            ControlToValidate="txtUserName" ForeColor="Red" ErrorMessage="Please enter Username." Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvtxtPswd" runat="server"
            ControlToValidate="txtPswd" ForeColor="Red" ErrorMessage="Please enter password." Display="None"></asp:RequiredFieldValidator>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None"
            ControlToValidate="txtImg" ForeColor="Red" ErrorMessage="Please enter captcha code."></asp:RequiredFieldValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ForeColor="Red" />


        <div class="clearfix"></div>
    </form>
</body>
</html>
