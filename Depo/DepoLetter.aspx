<%@ Page Title="&#2357;&#2375;&#2351;&#2352;&#2361;&#2366;&#2313;&#2360; / &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2348;&#2367;&#2325;&#2381;&#2352;&#2375;&#2340;&#2366; &#2352;&#2375;&#2344;&#2369;&#2309;&#2354; &#2347;&#2377;&#2352;&#2381;&#2350; / Warehouse / Books Seller Renewal Form
    " Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DepoLetter.aspx.cs" Inherits="Depo_DepoLetter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       <script type="text/javascript">
           function PrintPanel() {
               var panel = document.getElementById("<%=Panel1.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }</script>
       <style type="text/css">
           .auto-style1 {
               height: 42px;
           }
       </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="box table-responsive">
        <div class="card-header">
            <h2><span>&#2357;&#2375;&#2351;&#2352;&#2361;&#2366;&#2313;&#2360; / &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2348;&#2367;&#2325;&#2381;&#2352;&#2375;&#2340;&#2366; &#2352;&#2375;&#2344;&#2369;&#2309;&#2354; &#2347;&#2377;&#2352;&#2381;&#2350;  / Warehouse / Books Seller Renewal Form</span></h2>
        </div>
    </div><br /><br />
     <a href="#" class="btn" style="color:White;" onclick="return PrintPanel();">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; / Print</a>
    <br /><br />
     <asp:Panel ID="Panel1" runat="server" Width="100%"> 
    <table width="100%">
        <tr><td>&#2346;&#2381;&#2352;&#2340;&#2367; ,<br /> <br />
            &#2350;&#2361;&#2366;&#2346;&#2381;&#2352;&#2348;&#2306;&#2343;&#2325;
            <br />
            <br />
            &#2350;. &#2346;&#2381;&#2352;. &#2346;&#2366;&#2336;&#2381;&#2351; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;
            <br />
            </td> </tr>
        <tr><td>&#2357;&#2367;&#2359;&#2351; :- &#2327;&#2379;&#2342;&#2366;&#2350; &#2325;&#2368; &#2309;&#2343;&#2367;&#2346;&#2340;&#2381;&#2351; &#2309;&#2357;&#2343;&#2367; &#2348;&#2397;&#2344;&#2375; &#2348;&#2366;&#2357;&#2340; </td> </tr>
        <tr><td>&#2350;&#2361;&#2379;&#2342;&#2351; </td> </tr>
        <tr><td class="auto-style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &#2313;&#2346;&#2352;&#2379;&#2325;&#2381;&#2340; &#2357;&#2367;&#2359;&#2351;&#2366;&#2344;&#2381;&#2340;&#2352;&#2381;&#2327;&#2340;
            <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label>
&nbsp; &#2325;&#2366; &#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<asp:Label ID="Label3" runat="server" Font-Bold="True"></asp:Label>&nbsp; &#2325;&#2379; &#2360;&#2350;&#2366;&#2346;&#2381;&#2340; &#2361;&#2379; &#2327;&#2351;&#2366; &#2361;&#2376; ! &#2337;&#2367;&#2346;&#2379; &#2325;&#2379; &#2327;&#2379;&#2342;&#2366;&#2350; &#2325;&#2368; &#2310;&#2357;&#2358;&#2381;&#2325;&#2340;&#2366; &#2361;&#2376; &#2325;&#2371;&#2346;&#2351;&#2366; &#2309;&#2344;&#2369;&#2348;&#2306;&#2343; 3 &#2357;&#2352;&#2381;&#2359; &#2325;&#2375; &#2354;&#2367;&#2319; &#2348;&#2397;&#2344;&#2375; &#2325;&#2368; &#2309;&#2344;&#2369;&#2350;&#2340;&#2367; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2352;&#2344;&#2375; &#2325;&#2366; &#2325;&#2359;&#2381;&#2335; &#2325;&#2352;&#2375;
            <br />
            </td> </tr>
        <tr><td>&nbsp;</td> </tr>
        <tr><td class="auto-style1">&#2337;&#2367;&#2346;&#2379; &#2346;&#2381;&#2352;&#2348;&#2306;&#2343;&#2325; 
            <asp:Label ID="Label2" runat="server" Font-Bold="True"></asp:Label>
            <br />
            <br />
            &#2350;. &#2346;&#2381;&#2352;. &#2346;&#2366;&#2336;&#2381;&#2351; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; </td> </tr>
    </table></asp:Panel> 
</asp:Content>

