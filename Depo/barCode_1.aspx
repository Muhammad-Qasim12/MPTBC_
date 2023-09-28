<%@ Page Language="C#" AutoEventWireup="true" CodeFile="barCode_1.aspx.cs" MasterPageFile="~/MasterPage.master" Inherits="Distrubution_barCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        @font-face {
            font-family: "Free3of9Regular";
            src: url("BarCodeFont/FREE3OF9.eot?") format("eot"),url("BarCodeFont/FREE3OF9.woff") format("woff"), url("BarCodeFont/FREE3OF9.ttf") format("truetype"), url("BarCodeFont/FREE3OF9.svg#Free3of9") format("svg");
            font-weight: normal;
            font-style: normal;
        }

        .BarCode {
            font-family: Free3of9Regular; font-size: 210px; padding: 0 0 0 0; line-height: 170px;
        }

        @media print {
            .page-break {
                display: block;
                page-break-before: always;
                padding-top: 40px;
                height: 377px;
                margin: 50px auto;
                text-align: center;
                font: normal 12px arial;
                line-height: 16px;
            }
        }

        .floatleft {
            float: left;
            width: 50%;
            text-align: center;
            margin-top: 120px;
        }

        .page-break ul {
            margin: 0;
            padding: 0;
        }

            .page-break ul li {
                float: left;
                width: 50%;
                text-align: center;
                list-style: none;
                height: 300px;
            }

        .cleardiv {
            clear: both;
            margin-top: 120px;
        }
    </style>
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=OuterDiv.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('<style> @font-face {src: url("BarCodeFont/FREE3OF9.eot?") format("eot"),url("BarCodeFont/FREE3OF9.woff") format("woff"), url("BarCodeFont/FREE3OF9.ttf") format("truetype"), url("BarCodeFont/FREE3OF9.svg#Free3of9") format("svg");font-family: Free3of9Regular;font-weight: normal;font-style: normal;}');
            printWindow.document.write('.BarCode { font-family: Free3of9Regular; font-size: 90px; padding: 10px; line-height: 80px; }</style>');
            printWindow.document.write('</head><body >');
            printWindow.document.write('<link href="style.css" rel="stylesheet" type="text/css" />');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 100);
            return false;
        }</script>

    <asp:Button ID="Button1" runat="server" Text="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2325;&#2352;&#2375; / Print  " CssClass="btn" OnClientClick="return PrintPanel();" />
    <div class="box table-responsive">
        <div style="width: 310px; margin: 0 auto; padding: 5px; line-height: 20px;">
            <div style="float: left; width: 50px;">
                <img src="../images/logo.png" />
            </div>
            <div style="float: left; width: 250px; text-align: center">
                <h2>&#2350;.&#2346;&#2381;&#2352; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;</h2>

                <span style="font-size: 12px;">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2349;&#2357;&#2344;, &#2309;&#2352;&#2375;&#2352;&#2366; &#2361;&#2367;&#2354;&#2381;&#2360; , &#2349;&#2379;&#2346;&#2366;&#2354; (&#2350;.&#2346;&#2381;&#2352;) 462011</span>
            </div>
            <div style="clear: both"></div>
        </div>

        <div class="card-header">
            <h2 style="text-align: center;"><span><b>
                <asp:Label ID="LblTitle" runat="server"></asp:Label>
            </b></span></h2>
        </div>
        <div class="portlet-content" style="text-align: center">

            <asp:Panel runat="server" ID="mainDiv" Style="display: block; padding-top: 10px; padding-bottom: 10px;">


                <%--
                <asp:Label  id="LblTitle" class="notification" runat="server">
                
            </asp:Label>--%>
            </asp:Panel>

            <div style="width: 100%; padding: 0 20px;" id="OuterDiv" runat="server">
                <asp:PlaceHolder ID="plBarCode" runat="server">
                    <%=InnerHtmlTag %>
                    <%-- <ul id="Ul" runat="server">

  </ul>--%>
                </asp:PlaceHolder>
            </div>
        </div>
    </div>
</asp:Content>
