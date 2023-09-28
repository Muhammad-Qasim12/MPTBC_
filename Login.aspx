<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta content="width=device-width, initial-scale=1.0" name="viewport">
    <title>M.P. Text Book Corporation</title>
    <link rel="stylesheet" href="assets/css/loginNew.css?v0.1">
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/css/bootstrap-icons.css" rel="stylesheet" />

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
</head>
<body>
    <form id="frmLogin" runat="server" autocomplete="off">
        <div class="d-md-flex half">
            <div class="bg" style="background-image: url('assets/img/login-bg.png');">
                <div class="login_ftr">
                    <%--<p class=" mb-1">
                                <a href="#" class="btn btn-warning"><i class="fa fa-arrow-left"></i>
                                    &nbsp; Back to Home Page</a>
                            </p>--%>
                    <p class="text-uppercase "><strong>Contact Details</strong></p>
                    <p>
                        M.P. Text Book Corporation.
                                <br>
                        Arera Hills Bhopal, 462011<br>
                        Phone No : (0755) 2559979 ; (0755) 2559971 | Email : <a href="#" class="txt_wht">info@mptbc.com</a>
                    </p>
                </div>
            </div>
            <div class="contents">
                <div class="container">
                    <div class="row align-items-center justify-content-center">
                        <div class="gradient-border" id="box">
                            <div class="form-block mx-auto">
                                <div class="text-center mb-5">
                                    <div class="flip-container">
                                        <div class="flipper">
                                            <div class="front">
                                                <img src="assets/img/logo_icon.png" width="100">
                                            </div>
                                            <div class="back">
                                                <img src="assets/img/logo_icon.png" width="100">
                                            </div>
                                        </div>
                                    </div>
                                    <h3>M.P. Text Book Corporation</h3>
                                </div>
                                <div action="#" method="post">
                                    <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                                    <div class="form-group first mb-3">
                                        <label for="username">Username</label>
                                        <asp:TextBox ID="txtUserName" MaxLength="30" CssClass="form-control" data-msg-required="Please enter UserName" placeholder="User Name" AutoCompleteType="Disabled" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group last mb-3">
                                        <label for="password">Password</label>
                                        <asp:TextBox ID="txtPswd" MaxLength="200" CssClass="form-control" AutoComplete="Off"
                                            placeholder="*************" AutoCompleteType="Disabled" data-validate="required" data-msg-required="Please enter password" runat="server"></asp:TextBox>

                                        <span toggle="#txtPswd" class="fa fa-eye field-icon toggle-password"></span>
                                        <span class="focus-input100"></span>
                                    </div>

                                    <div class="form-group last mb-3">
                                        <div class="row">
                                            <div class="col-md-4">
                                                <asp:Image ID="imgCaptcha" runat="server" Width="100" Height="56" />
                                                <a href="javascript:void(0);" onclick="reloadImage()" class="ref"><i class="fa fa-refresh text-muted"></i></a>
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtImg" MaxLength="20" AutoComplete="Off" data-validate="required" data-msg-required="Please enter captcha" placeholder="Enter Captcha Here" CssClass="form-control pl-2" runat="server"></asp:TextBox>
                                            </div>
                                        </div>


                                    </div>
                                    <div class="mb-5">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <label class="control control--checkbox mb-3 mb-sm-0">
                                                    <span class="caption">Remember me</span>
                                                    <input type="checkbox" checked="checked" />
                                                    <div class="control__indicator"></div>
                                                </label>
                                            </div>
                                            <div class="col-md-6 text-right">
                                                <a href="#" class="forgot-pass">Forgot Password</a>
                                            </div>
                                        </div>


                                    </div>
                                    <div class="gradient-border" id="box">
                                    <asp:Button ID="btnlogin" runat="server" class="btn btn-block btn-primary" Text="Login" OnClick="btnLogin_Click"></asp:Button>
                                        </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <script type="text/javascript" src="assets/js/jquery.min.js"></script>
        <script type="text/javascript" src="assets/js/bootstrap.bundle.min.js"></script>
        <script>
            $(".toggle-password").click(function () {

                $(this).toggleClass("fa-eye fa-eye-slash");
                var input = $($(this).attr("toggle"));
                if (input.attr("type") == "password") {
                    input.attr("type", "text");
                } else {
                    input.attr("type", "password");
                }
            });
        </script>
        <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
        <script type="text/javascript">
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



        <div class="login_wrapper">

            <div class="loginbox">
                <div style="padding-top: 50px;">
                    <div class="PT10" style="text-align: left;">
                        <asp:RadioButton ID="rbBusiness" runat="server" Text="Business Module" Checked="true" AutoPostBack="true" OnCheckedChanged="rbBusiness_CheckedChanged" onchange="OncheckUId();" GroupName="d" Visible="false" />
                        <asp:RadioButton ID="rbcore" runat="server" Text="Core Module" AutoPostBack="true" OnCheckedChanged="rbcore_CheckedChanged" GroupName="d" onchange="return OncheckUId();" Visible="false" />

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

                </div>
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

    </form>
</body>
</html>
