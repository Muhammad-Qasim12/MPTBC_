<%@ Page Language="VB" AutoEventWireup="false" Inherits="WebYojna.PrintHTMLREPORT" Codebehind="PrintHTMLREPORT.aspx.vb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
 <head id="Head1" runat="server">
<link href="~/css/webyojna.css" rel="stylesheet" type="text/css" />
<script src="css/ChangeIcon.js" type="text/javascript"></script>
<title></title>
<script type ="text/javascript" language ="javascript" >
function Print (){window.print();}
</script>
<style type="text/css">
#bgDiv
{
position: absolute;
height: 600px;
top: 0px;
bottom: 0px;
left: 0px;
right: 0px;
overflow: hidden;
padding: 0;
margin: 0;
background-color: Transparent;
z-index: 500;
}
#Progress
{
position: absolute;
background-color: Transparent;
z-index: 600;
}
.blanckSpan
{ 
	color:transparent ;
		
}
</style>
<script src="css/HelperScript.js" type="text/javascript"></script>
  <script type="text/javascript">
  function burstCache() {
  if (!navigator.onLine) {
  document.body.innerHTML = 'Loading...';
  window.location = 'ErrorPage.html';
  }
  }
</script>
</head>
<body onload ="burstCache(),Print();"> 
<form id="form1" runat="server" style="font-family: 'Arial Unicode MS'">
 <center>
 <%=PrintSTR%>
 </center>
</form>
</body>
</html>

