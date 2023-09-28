<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RptDistributionOrder.aspx.cs"   EnableEventValidation="false"
    Inherits="Distribution_RptDistributionOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <script type="text/javascript">

       function Redirect(obj) {
           var TxtBundleNoFrom = document.getElementById(obj.id.replace("Viewbarcode", "LblBundleNoFrom"));
           var lblBundleNoTo = document.getElementById(obj.id.replace("Viewbarcode", "LblBundleNOTo"));
           var TextBooksPerBundle = document.getElementById(obj.id.replace("Viewbarcode", "LblBooksPerBundle"));
           var TxtBookNoFrom = document.getElementById(obj.id.replace("Viewbarcode", "LblBookNoFrom"));

           var DdlACYear = document.getElementById('<%= DdlACYear.ClientID %>');
            var DdlTitle = document.getElementById(obj.id.replace("Viewbarcode", "LblTitle"));
            var DdlPrinter = document.getElementById(obj.id.replace("Viewbarcode", "LblPrinter"));
            var DdlBookType = document.getElementById(obj.id.replace("Viewbarcode", "LblBookType"));


            var ACYear = DdlACYear.options[document.getElementById('<%= DdlACYear.ClientID %>').selectedIndex].text;

            window.open('barCode.aspx?ACYear=' + ACYear + '&Bookstart=' + TxtBookNoFrom.textContent + '&BookType=' + DdlBookType.textContent + '&TxtBundleNoFrom=' + TxtBundleNoFrom.textContent + "&lblBundleNoTo=" + lblBundleNoTo.textContent + "&Title=" + DdlTitle.textContent + "&Printer=" + DdlPrinter.textContent + "&Cnt=" + TextBooksPerBundle.textContent);

            return false;

        }
        function Redirect2(obj) {
            var TxtBundleNoFrom = document.getElementById(obj.id.replace("LinkButton1", "LblBundleNoFrom"));
            var lblBundleNoTo = document.getElementById(obj.id.replace("LinkButton1", "LblBundleNOTo"));
            var TextBooksPerBundle = document.getElementById(obj.id.replace("LinkButton1", "LblBooksPerBundle"));
            var TxtBookNoFrom = document.getElementById(obj.id.replace("LinkButton1", "LblBookNoFrom"));

            var DdlACYear = document.getElementById('<%= DdlACYear.ClientID %>');
            var DdlACYear12 = document.getElementById('<%= DdlDepot.ClientID %>');
            var DdlTitle = document.getElementById(obj.id.replace("LinkButton1", "LblTitle"));
            var DdlPrinter = document.getElementById(obj.id.replace("LinkButton1", "LblPrinter"));
            var DdlBookType = document.getElementById(obj.id.replace("LinkButton1", "LblBookType"));


            var ACYear = DdlACYear.options[document.getElementById('<%= DdlACYear.ClientID %>').selectedIndex].text;
            var DepoName = DdlACYear12.options[document.getElementById('<%= DdlDepot.ClientID %>').selectedIndex].text;
            window.open('barCode_1.aspx?ACYear=' + ACYear + '&Bookstart=' + TxtBookNoFrom.textContent + '&BookType=' + DdlBookType.textContent + '&TxtBundleNoFrom=' + TxtBundleNoFrom.textContent + "&lblBundleNoTo=" + lblBundleNoTo.textContent + "&Title=" + DdlTitle.textContent + "&Printer=" + DdlPrinter.textContent + "&Cnt=" + TextBooksPerBundle.textContent + "&DepoName=" + DepoName);

            return false;

        }

        function PrintPanel() {

            //grd = $("#ContentPlaceHolder1_GrdVitranNirdesh tbody tr");
            grd = document.getElementById("<%=GrdVitranNirdesh.ClientID %>").rows;

            for (i = 0; i < grd.length ; i++) {

                if (grd[i].cells.length == 15) {

                    grd[i].cells[14].style.display = 'none';
                }
                if (grd[i].cells.length == 12) {

                    grd[i].cells[11].style.display = 'none';
                }
            }
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

            //for (i = 0; i < grd.length ; i++) {

            //    if (grd[i].cells.length == 15) {

            //        grd[i].cells[14].style.display = 'block';
            //    }
            //    if (grd[i].cells.length == 12) {

            //        grd[i].cells[11].style.display = 'block';
            //    }

            //}
            document.getElementById("form1").submit();
            return false;
        }</script>
    <style>
        .none {
            display: none;
        }
        .auto-style1 {
            height: 28px;
        }
    </style>

   
    <div class="box table-responsive">

        <div class="card-header">
            <h2>
                <span style="font-size: medium;">&#2357;&#2367;&#2340;&#2352;&#2339; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358; &#2325;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335;  / Distrubition Order Report
                </span>
            </h2>
        </div>
        <div class="box">

            <table width="100%">

                <tr>
                    <td style="font-size: medium;" valign="middle">
                        <asp:Label ID="LblAcYear" Width="144px" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;/ Year :</asp:Label>
                        <asp:DropDownList ID="DdlACYear" Width="100px" AutoPostBack="true" runat="server" CssClass="txtbox reqirerd" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td style="font-size: medium;" valign="top">
                        <asp:Label Width="144px" ID="Label7" runat="server">&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; / Printer</asp:Label>
                        <asp:DropDownList ID="DDLPrinter" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td style="font-size: medium;" valign="top">
                        <asp:Label Width="144px" ID="lblDepo" runat="server">&#2337;&#2367;&#2346;&#2379; / Depot</asp:Label>
                        <asp:DropDownList ID="DdlDepot" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="Label6" runat="server">&#2327;&#2381;&#2352;&#2369;&#2346; &#2330;&#2369;&#2344;&#2375; <br /> Group  :</asp:Label>
                        <asp:DropDownList ID="DdlGroup" runat="server" CssClass="txtbox"  >
                        </asp:DropDownList>
                    </td>


                </tr>
                <tr>
                    <td style="font-size: medium;" valign="top">
                        <asp:Label ID="Label1" Width="144px" runat="server">&#2325;&#2325;&#2381;&#2359;&#2366;  / Class</asp:Label>
                        <asp:DropDownList Width="100px" ID="DdlClass" runat="server" CssClass="txtbox"
                            AutoPostBack="True" OnSelectedIndexChanged="DdlClass_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td style="font-size: medium;" valign="top">
                        <asp:Label Width="144px" ID="Label2" runat="server">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;  / Title</asp:Label>
                        <asp:DropDownList runat="server" ID="DdlTitle">
                        </asp:DropDownList>
                    </td>
                    <td style="font-size: medium;" valign="top">
                        <asp:Label ID="Label3" Width="144px" runat="server">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; / Book Type</asp:Label>
                        <asp:DropDownList runat="server" ID="ddlType">
                            <asp:ListItem Value="2">&#2351;&#2379;&#2332;&#2344;&#2366;</asp:ListItem>
                            <asp:ListItem Value="1">&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        &nbsp;</td>

                </tr>


                <tr>
                    <td style="font-size: medium;" valign="top" class="auto-style1">
                <span style="font-size: medium;">&#2357;&#2367;&#2340;&#2352;&#2339; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358;
                </span>
                    </td>
                    <td style="font-size: medium;" valign="top" class="auto-style1">
                        <asp:DropDownList ID="DropDownList1" runat="server" Width="60px">
                            <asp:ListItem Value="0">All</asp:ListItem>
                            <asp:ListItem Value="1">&#2346;&#2381;&#2352;&#2341;&#2350; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358;&#2346;&#2381;&#2352;&#2341;&#2350; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358;  </asp:ListItem>
                            <asp:ListItem Value="2">&#2342;&#2381;&#2357;&#2367;&#2340;&#2368;&#2351; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358;&#2342;&#2381;&#2357;&#2367;&#2340;&#2368;&#2351; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358;  </asp:ListItem>
                            <asp:ListItem Value="3">&#2340;&#2371;&#2340;&#2368;&#2351; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358;&#2340;&#2371;&#2340;&#2368;&#2351; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358;  </asp:ListItem>
                            <asp:ListItem Value="4">&#2309;&#2340;&#2367;&#2352;&#2367;&#2325;&#2381;&#2340; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358;&#2309;&#2340;&#2367;&#2352;&#2367;&#2325;&#2381;&#2340; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358;  </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="font-size: medium;" valign="top" class="auto-style1">
                        <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search "
                            OnClientClick="return ValidateAllTextForm();" OnClick="btnSearch_Click" />
                    </td>
                    <td align="right" class="auto-style1">
                    </td>

                </tr>


                <tr>
                    <td colspan="4" id="tdPrintContent" runat="server" visible="false">
                        <div style="color: White; float: right;">
                            <table>
                                <tr>
                                    <td>
                                        <a href="#" class="btn" style="color: White;" onclick="return PrintPanel();">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; / Print            </a></td>
                                    <td>
                                         <asp:Button ID="btnExport" runat="server" Height="28px" Text="Export to Excel" CssClass="btn" OnClick="btnExport_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="width: auto; height: auto;">
                            <center>
                                <div class="MT20">
                                    <asp:Panel ID="Panel1" runat="server" Width="100%">
                                        <div id="ExportDiv" runat="server">
                                            <div style="width: 100%; border: 1px solid #ccc; margin-top: 40px;">

                                                <table width="100%">
                                                    <tr>
                                                        <td colspan="4" style="font-size: 18px; font-weight: bold; text-align: center;">&#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" style="font-size: 16px; font-weight: 200; text-align: center;">" &#2357;&#2367;&#2340;&#2352;&#2339; (&#2309;) &#2358;&#2366;&#2326;&#2366; "
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td style="font-size: 16px; font-weight: 200; text-align: left;">
                                                            <asp:Label ID="lblAcademicYear" runat="server"></asp:Label>
                                                        </td>
                                                        <td colspan="2" style="font-size: 18px; font-weight: bold; text-align: center; padding-right: 80px;">&#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2357;&#2367;&#2340;&#2352;&#2339; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358; &#2325;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335;
                                                        </td>
                                                        <td style="font-size: 16px; font-weight: 200; text-align: right;">
                                                            <asp:Label ID="lblDate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" style="font-size: 13px; font-weight: 200; text-align: center;">
                                                            <asp:GridView runat="server" ID="GrdVitranNirdesh" CssClass="tab hastable"
                                                             FooterStyle-CssClass="block"    RowStyle-CssClass="none" HeaderStyle-CssClass="none" AutoGenerateColumns="False"
                                                                 ShowFooter="True" OnRowDataBound="GrdVitranNirdesh_RowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <tr>
                                                                                <th rowspan="3" align="center">&#2325;&#2381;&#2352;&#2406;
                                                                                    <br />
                                                                                    <br />
                                                                                    Sr. No.<br />
                                                                                    <br />
                                                                                    <div style="padding-top: 140px;">1</div>
                                                                                </th>
                                                                                <th rowspan="3" align="center">&#2310;&#2342;&#2375;&#2358; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br />
                                                                                    <br />
                                                                                    Order No.<br />
                                                                                    <br />
                                                                                    <div style="padding-top: 125px;">2</div>
                                                                                </th>
                                                                                <th rowspan="3" align="center">&#2310;&#2342;&#2375;&#2358; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; 
                                                                                    <br />
                                                                                    <br />
                                                                                    Order Date<br />
                                                                                    <br />
                                                                                    <div style="padding-top: 125px;">3</div>
                                                                                </th>
                                                                                <th rowspan="3" align="center">&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350;
                                                                                    <br />
                                                                                    <br />
                                                                                    Depot Name<br />
                                                                                    <br />
                                                                                    <div style="padding-top: 125px;">4</div>
                                                                                </th>
                                                                                <th rowspan="3" align="center">&#2327;&#2381;&#2352;&#2369;&#2346; 
                                                                                    <br />
                                                                                    <br />
                                                                                    Group<br />
                                                                                    <br />
                                                                                    <div style="padding-top: 150px;">5</div>
                                                                                </th>
                                                                                <th rowspan="3" align="center">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;
                                                                                    <br />
                                                                                    <br />
                                                                                    Book Title<br />
                                                                                    <br />
                                                                                    <div style="padding-top: 148px;">6</div>
                                                                                </th>
                                                                                <th rowspan="3" align="center">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;
                                                                                    <br />
                                                                                    <br />
                                                                                    Book Type<br />
                                                                                    <br />
                                                                                    <div style="padding-top: 125px;">7</div>
                                                                                </th>
                                                                                <th rowspan="3" style="width: 80Px;" align="center">&#2337;&#2367;&#2346;&#2379; &#2361;&#2375;&#2340;&#2369; &#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;
                                                                                    <br />
                                                                                    <br />
                                                                                    Depotwise Alloted No. Of Book<br />
                                                                                    <br />
                                                                                    <div style="padding-top: 100px;">8</div>
                                                                                </th>
                                                                                <th rowspan="3" style="width: 80Px;" align="center">&#2346;&#2381;&#2352;&#2340;&#2367; &#2327;&#2337;&#2381;&#2337;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;
                                                                                    <br />
                                                                                    <br />
                                                                                    Books per Gaddi<br />
                                                                                    <br />
                                                                                    <div style="padding-top: 125px;">9</div>
                                                                                </th>
                                                                                <th rowspan="3" style="width: 80Px;" align="center">&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2306;&#2337;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;
                                                                                    <br />
                                                                                    <br />
                                                                                    Books per Bundle<br />
                                                                                    <br />
                                                                                    <div style="padding-top: 124px;">10</div>
                                                                                </th>
                                                                                <th colspan="2" align="center">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2344;&#2306;&#2348;&#2352;&#2367;&#2306;&#2327; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339;
                                                                                    <br />
                                                                                    <br />
                                                                                    No. Details of Book
                                                                                </th>
                                                                                <th colspan="3">&#2337;&#2367;&#2346;&#2379;&#2348;&#2366;&#2352; &#2348;&#2306;&#2337;&#2354;&#2379; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339;
                                                                                    <br />
                                                                                    <br />
                                                                                    Depotwise Bundles Details 
                                                                                </th>

                                                                                <th rowspan="3">&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; 
                                                                                    <br />
                                                                                    <br />
                                                                                    Name Of Printer<br />
                                                                                    <br />
                                                                                    <div style="padding-top: 98px;">16</div>
                                                                                </th>
                                                                                 <th rowspan="3">&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; 
                                                                                    <br />
                                                                                    <br />
                                                                                    Remark<br />
                                                                                    <br />
                                                                                    <div style="padding-top: 98px;">17</div>
                                                                                </th>
                                                                                <th rowspan="3">&#2348;&#2306;&#2337;&#2354;&#2379;&#2306; &#2325;&#2375; &#2354;&#2367;&#2319; &#2348;&#2366;&#2352; &#2325;&#2379;&#2337; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2325;&#2352;&#2375; 
                                                                                    <br />
                                                                                    <br />
                                                                                    Print barcode for Bundles<br />
                                                                                    <br />
                                                                                    <div style="padding-top: 59px;">18</div>
                                                                                </th>
                                                                            </tr>
                                                                            <tr>
                                                                                <th rowspan="2">&#2325;&#2361;&#2366;&#2305; &#2360;&#2375;
                                                                                    <br />
                                                                                    From<br />
                                                                                    <br />
                                                                                    <div style="padding-top: 70px;">11</div>
                                                                                </th>

                                                                                <th rowspan="2">&#2325;&#2361;&#2366;&#2305; &#2340;&#2325;
                                                                                    <br />
                                                                                    To<br />
                                                                                    <br />
                                                                                    <div style="padding-top: 70px;">12</div>
                                                                                </th>
                                                                                <th rowspan="2">&#2348;&#2306;&#2337;&#2354;&#2379; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;
                                                                                    <br />
                                                                                    <br />
                                                                                    No. Of Bundle
                                                                                    <br />
                                                                                    <br />
                                                                                    <div style="padding-top: 30px;">13</div>
                                                                                </th>
                                                                                <th colspan="2">&#2348;&#2306;&#2337;&#2354; &#2344;&#2350;&#2381;&#2348;&#2352;  Bundle No. 
                                                                                </th>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>&#2325;&#2361;&#2366;&#2305; &#2360;&#2375;
                                                                                    <br />
                                                                                    From<br />
                                                                                    <br />
                                                                                    <div style="padding-top: 15px;">14</div>
                                                                                </th>
                                                                                <th>&#2325;&#2361;&#2366;&#2305; &#2340;&#2325;
                                                                                    <br />
                                                                                    To<br />
                                                                                    <br />
                                                                                    <div style="padding-top: 2px;">15</div>
                                                                                </th>
                                                                            </tr>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <tr>
                                                                                <td><%# Container.DataItemIndex+1 %>.</td>
                                                                                <td>
                                                                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("VitranNo")%>'></asp:Label>
                                                                                </td>
                                                                                <td>

                                                                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("VitranDate").ToString().Equals("")?"": Convert.ToDateTime(Eval("VitranDate")).ToShortDateString()%>'></asp:Label>

                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblDepoName_V" runat="server" Text='<%#Eval("DepoName_V")%>'></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="LblGroup" runat="server" Text='<%#Eval("GroupName")%>'></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="LblTitle" runat="server" Text='<%#Eval("TitleHindi_V")%>'></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="LblBookType" runat="server" Text='<%#Eval("BookType")%>'></asp:Label>
                                                                                </td>

                                                                                <td>
                                                                                    <asp:Label ID="lblNoOfBooks" runat="server" Text='<%#Eval("NoOfBooks")%>'></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="LblBooksPerGaddi" runat="server" Text='<%#Eval("BooksPerGaddi")%>'></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="LblBooksPerBundle" runat="server" Text='<%#Eval("BooksPerBundle")%>'></asp:Label>
                                                                                </td>

                                                                                <td>
                                                                                    <asp:Label ID="LblBookNoFrom" runat="server" Text='<%#Eval("BookNumberFrom")%>'></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="LblBookNoTo" runat="server" Text='<%#Eval("BookNumberTo")%>'></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblTotalBundles" runat="server" Text='<%#Eval("TotalBundels")%>'></asp:Label>
                                                                                </td>

                                                                                <td>
                                                                                    <asp:Label ID="LblBundleNoFrom" runat="server" Text='<%#Eval("BundleNoFrom")%>'></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="LblBundleNOTo" runat="server" Text='<%#Eval("BundleNoTo")%>'></asp:Label>
                                                                                </td>

                                                                                <td>
                                                                                    <asp:Label ID="LblPrinter" runat="server" Text='<%#Eval("NameofPress_V")%>'></asp:Label>
                                                                                </td>
                                                                                  <td>
                                                                                    <asp:Label ID="Label8" runat="server" Text='<%#Eval("Remark")%>'></asp:Label>
                                                                                </td>
                                                                                <td style="width: 60px">
                                                                                    <%--<asp:ImageButton Width="50px" Height="14px"  ImageUrl="../images/bar.png" ID="Viewbarcode" runat="server" OnClientClick="return Redirect(this);"/> --%>
                                                                                    <asp:LinkButton Text="प्रिंट / Print (6) " ID="Viewbarcode" runat="server" OnClientClick="return Redirect(this);"></asp:LinkButton>

                                                                                     <asp:LinkButton Text="प्रिंट / Print  (1)" ID="LinkButton1" runat="server" OnClientClick="return Redirect2(this);"></asp:LinkButton>
                                                                               
                                                                                </td>

                                                                            </tr>

                                                                        </ItemTemplate>
                                                                        <FooterTemplate >
                                                                            <tr>
                                                                                <td>Total</td>
                                                                                <td>
                                                                                </td>
                                                                                <td>

                                                                                </td>
                                                                                <td>
                                                                                                                                </td>
                                                                                <td>
                                                                                   
                                                                                </td>
                                                                                <td>
                                                                                    
                                                                                </td>
                                                                                <td>
                                                                                  
                                                                                </td>

                                                                                <td>
                                                                                    <asp:Label ID="lblNoOfBooks1" runat="server" ></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                   
                                                                                </td>
                                                                                <td>
                                                                                    
                                                                                </td>

                                                                                <td>
                                                                                   
                                                                                </td>
                                                                                <td>
                                                                                    
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblTotalBundles1" runat="server" ></asp:Label>
                                                                                </td>

                                                                                <td>
                                                                                  
                                                                                </td>
                                                                                <td>
                                                                                    
                                                                                </td>

                                                                                <td>
                                                                                    
                                                                                </td>
                                                                                  <td>
                                                                                   
                                                                                </td>
                                                                                <td style="width: 60px">
                                                                                    <%--<asp:ImageButton Width="50px" Height="14px"  ImageUrl="../images/bar.png" ID="Viewbarcode" runat="server" OnClientClick="return Redirect(this);"/> --%>
                                                                                    
                                                                                </td>

                                                                            </tr>
                                                                        </FooterTemplate>

                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <PagerStyle CssClass="Gvpaging" />
                                                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>

                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>
                            </center>
                        </div>


                    </td>
                </tr>
            </table>
        </div>
        <div style="margin-left: 80px;">
            &nbsp;
        </div>
    </div>

</asp:Content>


