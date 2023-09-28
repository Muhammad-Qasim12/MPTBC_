<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgetPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password</title>

    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />

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
        function OnLogout() {
            var backlen = history.length;
            history.go(-backlen);
            window.location.replace("Default.aspx");
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: right;"><a href="Login.aspx"><i class="fa fa-home" style="font-size: 26px; color: #fff; padding-right: 20px;" title="Home"></i></a></div>
        <div class="login_wrapper">
            <div class="login">
                <p>

                    <img src="images/tbc-logo.png" alt="" />
                </p>
                <h2>M.P. Text Book Corporation</h2>
            </div>

            <div class="loginbox">
                
                <div style="float: left; padding-left: 5px;">
                    <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>

                </div>
                <div style="padding-top:30px;">
                    <div class="selectDiv" style="padding-top: 5px;">
                        <h3 style="font-size:18px;">Forgot Password</h3>
                    </div>
                    <div class="PT10">
                        <asp:TextBox ID="txtUserName" MaxLength="30" CssClass="txtbox" placeholder="Username" AutoComplete="Off" AutoCompleteType="Disabled" runat="server"></asp:TextBox>

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
                    <div class="PT10 align-right" style="padding-top: 10px; padding-right: 5px;">
                       
                    </div>
                    <div class="PT15">
                        <asp:Button ID="btnlogin" runat="server" class="com-btn" Text="Submit" OnClick="btnLogin_Click"></asp:Button>

                    </div>
                </div>
            </div>
            <div class="copytxt">
                Copyright  2015. Design & Developed By <a href="#">Vayamtech</a> & <a href="#">C-Net Infotech Pvt. Ltd.</a>
            </div>
        </div>
        
       
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None"
            ControlToValidate="txtUserName" ForeColor="Red" ErrorMessage="Please enter username."></asp:RequiredFieldValidator>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="None"
            ControlToValidate="txtImg" ForeColor="Red" ErrorMessage="Please enter captcha code."></asp:RequiredFieldValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ForeColor="Red" />


        <div class="clearfix"></div>
    </form>
</body>
</html>
