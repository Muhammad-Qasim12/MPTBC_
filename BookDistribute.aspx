<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BookDistribute.aspx.cs" Inherits="BookDistribute" %>

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
        #header
        {
            height: auto;
        }
        #header #sitename a.logo
        {
            font-size: 16px;
        }
        .btndash
        {
            background: #f3565d;
            padding: 20px 40px;
            font-size: 14px;
            color: #fff;
            text-align: center;
            margin-bottom: 20px;
        }
        .blubox
        {
            background: #428bca !important;
        }
        .btndash a
        {
            color: #fff;
        }
        .backbtn
        {
            background: #f4f4f4;
            border: 1px solid #ccc;
            margin: 5px 0 0;
            padding: 3px 10px;
            text-align: center;
            color: #000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <<div class="conteaner">
        <div id="header">
            <div id="top-menu">
                <span>Logged in as <a href="MobilDasbord.aspx" title="">
                    <%=Session["UserName"] %></a></span> | <a href="#" title="Logout">Logout</a>
            </div>
            <div id="sitename">
                <div class="right-bg">
                    <a href="#" class="logo float-left">M.P. Text Book Corporation</a>
                </div>
            </div>
        </div>
    </div>
    <div style="padding: 10px 20px;">
        <a href="MobilDasbord.aspx" class="backbtn"><< Back</a>
    </div>
    <div class="conteaner">
        <div class="col-lg-12 MT20">
            <h4>
                Books Distribution Of Schemes</h4>
            <hr />
            <div class="form-group">
                <label>
                    Challan No. :</label>
                <asp:DropDownList ID="ddlChallano" runat="server" class="form-control" OnSelectedIndexChanged="ddlChallano_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
                <br />
                <label>
                    Subject Name . :</label>
                <asp:DropDownList ID="ddlBookName" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlBookName_SelectedIndexChanged">
                </asp:DropDownList>
                <br />
                <label>
                    Bundle No. :</label>
                <asp:TextBox ID="txtBundlenNo" runat="server" AutoPostBack="true" OnTextChanged="Checkbarcode"
                    class="form-control" Style="width: 100%"></asp:TextBox>
            </div>
            <div class="form-group">
                अंतिम बण्डल नंबर :
                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            </div>
            <div class="form-group">
                प्रदाय की जाने वाली :<br />
                पैक बंडलो की संख्या :
                <asp:Label ID="Label3" runat="server" Text="" Style="width: 96%"></asp:Label>
                लूज पुस्तकों की संख्या :
                <asp:Label ID="Label5" runat="server" Text="" Style="width: 96%"></asp:Label></div>
            <div class="form-group">
                प्रदाय किये जा चुके पैक बंडलो की संख्या:
                <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
    <div class="clearfix">
    </div>
    <div class="clearfix"></div>
	<div id="footer">
		Copyright &copy; 2015 - C-Net Infotech Pvt. Ltd.
	</div>
    <!-- IE10 viewport hack for Surface/desktop Windows 8 bug -->
    <script src="js/ie10-viewport-bug-workaround.js"></script>
   
    </form>
    </form>
</body>
</html>
