<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MobiLogin.aspx.cs" Inherits="MobiLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="../../favicon.ico">

    <title>M.P. Text Book Corporation</title>

    <!-- Bootstrap core CSS -->
    <link href="css/bootstrap.min2.css" rel="stylesheet">

    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <link href="css/ie10-viewport-bug-workaround.css" rel="stylesheet">

    <!-- Custom styles for this template -->
    <!--<link href="css/signin.css" rel="stylesheet">-->

    <!-- Just for debugging purposes. Don't actually copy these 2 lines! -->
    <!--[if lt IE 9]><script src="../../assets/js/ie8-responsive-file-warning.js"></script><![endif]-->
    <script src="js/ie-emulation-modes-warning.js"></script>

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
    <style type="text/css">
		#header{ height:auto;}
		#header #sitename a.logo{ font-size:16px;}
	</style>
</head>
<body>
    <form id="form1" runat="server">

        <div class="conteaner">
        <div id="header">
            <div id="sitename">
                <div class="right-bg">
                    <a href="#" class="logo float-left">M.P. Text Book Corporation</a>			
                </div>
            </div>
        </div>	
    </div>
    <div class="container">
    	<div class="MT20">
        	<h4>Login</h4>
            <hr />
            <div class="form-group">
                <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>

            </div> 
			<div class="form-group">
                <label>Depot Name</label>
                <asp:DropDownList ID="ddlDepotID" class="form-control"  placeholder="Select Depot Name" runat="server" ></asp:DropDownList><br />
            
                <label>Password</label>
               <asp:TextBox ID="txtpwd" runat="server" placeholder="Password" class="form-control" TextMode="Password"></asp:TextBox><br />
            
                   <asp:Button ID="Button1" runat="server" Text="Login" class="btn btn-lg btn-primary btn-block" OnClick="Button1_Click"  />
             </div>
             <p>&nbsp;</p>
        </div>
    </div>

	<div class="clearfix"></div>
	<div id="footer">
		Copyright &copy; 2015 - C-Net Infotech Pvt. Ltd.
	</div>
    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <script src="js/ie10-viewport-bug-workaround.js"></script>
   
    </form>
</body>
</html>
