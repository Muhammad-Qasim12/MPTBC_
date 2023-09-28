<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MobiBookReceived.aspx.cs"
    Inherits="MobiBookReceived" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head  >
   
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
    <script src="js/CommonCtrl.js" type="text/javascript"></script>
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
    <style type="text/css">
        #header {
            height: auto;
        }

            #header #sitename a.logo {
                font-size: 16px;
            }

        .btndash {
            background: #f3565d;
            padding: 20px 40px;
            font-size: 14px;
            color: #fff;
            text-align: center;
            margin-bottom: 20px;
        }

        .blubox {
            background: #428bca !important;
        }

        .btndash a {
            color: #fff;
        }

        .backbtn {
            background: #f4f4f4;
            border: 1px solid #ccc;
            margin: 5px 0 0;
            padding: 3px 10px;
            text-align: center;
            color: #000;
        }
    </style>
    
    <script src="js/jquery-1.8.3.min.js"></script>
    <script>
        function setFocus() {
            document.getElementById("textbox").focus();
        }
        BindDdl();
        var i = 1;



        function OnChangeKey() {
            AddChalan();
        }

        $("#btnSave").hide();
        function AddChalan() {


            if (i < 11) {

                document.getElementById("textbox").readOnly = false;
                i = i + 1;
                document.getElementById("textbox").focus();
                $("#textbox").focus();
                document.getElementById("textbox").value = document.getElementById("textbox").value + ",";
                document.getElementById("btnSave").style.display = "Block";
                document.getElementById("textbox").focus();

            }
            else {
                //alert("Please Save Data First.");
                document.getElementById("pFocus").value = "Please Save Data First.";
                document.getElementById("pFocus").focus();
                document.getElementById("textbox").readOnly = true;
                $("#pFocus").focus();
            };
        }
        function Save() {

            $.ajax({
                type: "POST",
                url: "MobiBookReceived.aspx?Flag=SaveData&BandalNO=" + $("#textbox").text() + "&ChallanNO=" + $("#ddlChallanNo").val(),
                data: '{}',
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                }
            });

        }
        function OnSuccess(response) {
            alert(response);
            $.each(response, function (i, Val) {
                if (Val.Msg == "Ok") {
                    window.location.reload();
                }
            });
        };

        function BindDdl() {

            $.ajax({
                type: "POST",
                url: "MobiBookReceived.aspx?Flag=Loadddl",
                data: '{}',
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (rsp) {
                    $("#ddlChallanNo").empty();
                    $.each(rsp, function (i, state) {
                        $("#ddlChallanNo").append('<option value="' + state.ChallanTrno_I + '">' + state.ChalanNo + '</option>');
                    });
                },
                failure: function (response) {
                    alert(response.d);
                }
            });

        };


        function checkEnter(event) {
            var keynum;
            var keychar;
            var enttest;

            if (window.event) {
                keynum = event.keyCode;

            }
            else {
                if (event.which) {
                    keynum = event.which;
                }
            }

            keychar = String.fromCharCode(keynum);

            enttest = "r";

            if (13 == keynum) {

                event.srcElement.blur();
                document.getElementById("textbox").focus();
                return false;

            }

        }

    </script>
</head>
<body onload="setFocus()">
    <form id="form1" runat="server">
     <div class="conteaner">
        <div id="header">
            <div id="top-menu">
                <span>Logged in as <a href="#" title=""> </a></span>
                | <a href="MobiLogin.aspx" title="Logout">Logout</a>
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
                Printer / Depot Recieved Books
            </h4>
            <hr />
            <div class="portlet-content">
                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                </div>
                <div class="form-group">
                    <label>
                        Challan No.
                    </label>
                   <%-- <select ID="ddlChallanNo"  class="form-control">
                    </select>--%>
                    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                    <br />
                    <label>
                        Bandal No :
                    </label>
                    <textarea id="textbox"  type="text" style="width: 100% ; height:150px;" class="form-control" runat="server"   onkeypress="checkEnter(event);" onchange="OnChangeKey();"></textarea>
                   
                    <br />  <label id="ChallanDetails"></label>
                    <input id="pFocus" style="border:none;color:Red ;" readonly="readonly" ></input>

                    <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click"  />
                </div>

                <div class="form-group">
                    <%--<input id="btnSave"  type="button" style="display:none;" value="Save" onclick="Save()" />--%>
                    
                   
                </div>
                <p>
                 
                </p>
            </div>
        </div>
        <div class="clearfix">
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
