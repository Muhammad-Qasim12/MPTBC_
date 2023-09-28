<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VitranNirdeshPrint.aspx.cs" Inherits="Distribution_VitranNirdeshPrint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 28px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script type="text/javascript">
         function PrintPanel() {
             var panel = document.getElementById("<%=ExportDiv.ClientID %>");

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
            }, 500);
            return false;
        }</script>
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
                        &#2357;&#2367;&#2340;&#2352;&#2339; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;
                    </td>
                    <td style="font-size: medium;" valign="top" colspan="2">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal" Width="565px">
                            <asp:ListItem Selected="True" Value="1">&#2357;&#2367;&#2340;&#2352;&#2339; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358; </asp:ListItem>
                            <asp:ListItem Value="2">&#2346;&#2369;&#2344;&#2307;  &#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2357;&#2367;&#2340;&#2352;&#2339; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358;</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>
                        &nbsp;</td>


                </tr>

                <tr>
                    <td style="font-size: medium;" valign="middle">
                        <asp:Label ID="LblAcYear" Width="144px" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;/ Year :</asp:Label>
                        <asp:DropDownList ID="DdlACYear" Width="100px" AutoPostBack="true" runat="server" CssClass="txtbox reqirerd" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td style="font-size: medium;" valign="top">
                        <asp:Label Width="144px" ID="Label7" runat="server">&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; / Printer</asp:Label>
                        <asp:DropDownList ID="DDLPrinter" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLPrinter_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td style="font-size: medium;" valign="top">
                        <asp:Label Width="144px" ID="lblDepo" runat="server">&#2310;&#2352;&#2381;&#2337;&#2352; &#2344;&#2306;&#2348;&#2352;</asp:Label>
                        <asp:DropDownList ID="ddlOrderNo" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;</td>


                </tr>

                <tr>
                    <td style="font-size: medium;" valign="middle" colspan="4">
                        <asp:Button ID="Button1" runat="server" CssClass="btn" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; " OnClick="Button1_Click" />
                    &nbsp;<a class="btn" href="#" onclick="return PrintPanel();" style="color: White;">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; / Print </a>
                    </td>


                </tr>

                <tr>
                    <td style="font-size: medium;" valign="middle" colspan="4">
                        <div id="ExportDiv" runat="server" visible="false"  >
                          <table width="100%">
                              <tr><td colspan="4" align="center" ><asp:Label ID="lblAcademicYear" runat="server" Text="Label" Font-Bold="True"></asp:Label>
                                <b>  &nbsp; &#2325;&#2375; &#2354;&#2367;&#2319; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2375; &#2337;&#2367;&#2346;&#2379;&#2357;&#2366;&#2352; &#2357;&#2367;&#2340;&#2352;&#2339; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358;</b> </td></tr>

                              <tr><td colspan="4" align="center" >&nbsp;</td></tr>

                              <tr><td>&#2357;&#2367;&#2340;&#2352;&#2339; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;</td><td>
                                  <asp:Label ID="lblKra" runat="server" Text=""></asp:Label> 
                                  </td><td>&#2357;&#2367;&#2340;&#2352;&#2339; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </td><td>
                                  <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>  
                                  </td></tr>

                              <tr><td>&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </td><td>
                                  <asp:Label ID="lblPrinterName" runat="server" CssClass="txtbox"></asp:Label>
                                  <br />
                                  <asp:Label ID="lblPaddress" runat="server" Text="Label"></asp:Label>
                                  </td><td>&#2327;&#2381;&#2352;&#2369;&#2346; </td><td>
                                  <asp:Label ID="lblGroup" runat="server" CssClass="txtbox"></asp:Label>
                                  </td></tr>

                              <tr><td class="auto-style1">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </td><td class="auto-style1" colspan="3">
                                  <asp:Label ID="lblBookName" runat="server" CssClass="txtbox"></asp:Label>
                                  </td></tr>

                              <tr><td>&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2306;&#2337;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;</td><td>
                                  <asp:Label ID="lblPerbundle" runat="server" CssClass="txtbox"></asp:Label>
                                  </td><td>&#2346;&#2381;&#2352;&#2340;&#2367; &#2327;&#2337;&#2381;&#2337;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;</td><td>
                                  <asp:Label ID="lblPerbundle0" runat="server" CssClass="txtbox"></asp:Label>
                                  </td></tr>

                              <tr><td colspan="4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; 
                                  : <asp:Label ID="lblBookType" runat="server" CssClass="txtbox"></asp:Label>
                                  </td></tr>

                             


                             

                              <tr><td colspan="4">
                                                            <asp:GridView runat="server" ID="GrdVitranNirdesh" CssClass="tab hastable" RowStyle-CssClass="none" HeaderStyle-CssClass="none" AutoGenerateColumns="False" ShowFooter="True" OnRowDataBound="GrdVitranNirdesh_RowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            
                                                                            <tr>
                                                                                <th rowspan="3" align="center">&#2325;&#2381;&#2352;&#2406;
                                                                                    
                                                                                    
                                                                                    
                                                                                </th>
                                                                                
                                                                                <th rowspan="3" align="center">&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350;
                                                                                </th>
                                                                               
                                                                                <th rowspan="3" style="width: 80Px;" align="center">&#2337;&#2367;&#2346;&#2379; &#2361;&#2375;&#2340;&#2369; &#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;
                                                                                  
                                                                                  
                                                                                </th>
                                                                                
                                                                                <th colspan="2" align="center">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2344;&#2306;&#2348;&#2352;&#2367;&#2306;&#2327; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339;
                                                                                     
                                                                                </th>
                                                                                <th colspan="3">&#2337;&#2367;&#2346;&#2379;&#2348;&#2366;&#2352; &#2348;&#2306;&#2337;&#2354;&#2379; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339;
                                                                                   
                                                                                </th>

                                                                                <th rowspan="3">&#2325;&#2369;&#2354; &#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;  
                                                                                   
                                                                                    
                                                                                </th>
                                                                                 
                                                                                 <th rowspan="3">&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; 
                                                                                   
                                                                                 
                                                                                </th>
                                                                                
                                                                            </tr>
                                                                            <tr>
                                                                                <th rowspan="2">&#2325;&#2361;&#2366;&#2305; &#2360;&#2375;
                                                                                   
                                                                                  
                                                                                </th>

                                                                                <th rowspan="2">&#2325;&#2361;&#2366;&#2305; &#2340;&#2325;
                                                                                    
                                                                                   
                                                                                </th>
                                                                                <th rowspan="2">&#2348;&#2306;&#2337;&#2354;&#2379; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;
                                                                                    
                                                                                  
                                                                                </th>
                                                                                <th colspan="2">&#2348;&#2306;&#2337;&#2354; &#2344;&#2350;&#2381;&#2348;&#2352;   
                                                                                </th>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>&#2325;&#2361;&#2366;&#2305; &#2360;&#2375;
                                                                                  
                                                                                 
                                                                                </th>
                                                                                <th>&#2325;&#2361;&#2366;&#2305; &#2340;&#2325;
                                                                                   
                                                                                   
                                                                                </th>
                                                                            </tr>
                                                                             <tr><th>1</th><th>2</th><th>3</th><th>4</th><th>5</th><th>6</th><th>7</th><th>8</th><th>9</th><th>10</th></tr> 
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <tr>
                                                                                <td align="center" ><%# Container.DataItemIndex+1 %>.</td>
                                                                                
                                                                                <td align="center" >
                                                                                    <asp:Label ID="lblDepoName_V" runat="server" Text='<%#Eval("DepoName_V")%>'></asp:Label>
                                                                                </td>
                                                                                

                                                                                <td align="center" >
                                                                                    <asp:Label ID="lblNoOfBooks" runat="server" Text='<%#Eval("NoOfBooks")%>'></asp:Label>
                                                                                </td>
                                                                                

                                                                                <td align="center" >
                                                                                    <asp:Label ID="LblBookNoFrom" runat="server" Text='<%#Eval("BookNumberFrom")%>'></asp:Label>
                                                                                </td>
                                                                                <td align="center" >
                                                                                    <asp:Label ID="LblBookNoTo" runat="server" Text='<%#Eval("BookNumberTo")%>'></asp:Label>
                                                                                </td>
                                                                                <td align="center" >
                                                                                    <asp:Label ID="lblTotalBundles" runat="server" Text='<%#Eval("TotalBundels")%>'></asp:Label>
                                                                                </td >

                                                                                <td align="center" >
                                                                                    <asp:Label ID="LblBundleNoFrom" runat="server" Text='<%#Eval("BundleNoFrom")%>'></asp:Label>
                                                                                </td>
                                                                                <td align="center" >
                                                                                    <asp:Label ID="LblBundleNOTo" runat="server" Text='<%#Eval("BundleNoTo")%>'></asp:Label>
                                                                                </td>

                                                                                <td align="center" >
                                                                                    <asp:Label ID="LblPrinter" runat="server" Text='<%#Eval("NoOfBooks")%>'></asp:Label>
                                                                                </td>
                                                                                
                                                                                 <td align="center" >
                                                                                    <asp:Label ID="Label9" runat="server" Text='<%#Eval("Remark")%>'></asp:Label>
                                                                                </td>
                                                                                

                                                                            </tr>

                                                                        </ItemTemplate>
                                                                        <FooterTemplate > <tr><th>Total</th><th></th><th><asp:Label ID="lbl1" runat="server"></asp:Label></th><th></th><th></th><th><asp:Label ID="lbl2" runat="server"></asp:Label></th><th></th><th></th><th><asp:Label ID="lbl3" runat="server"></asp:Label></th><th></th></tr> </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <PagerStyle CssClass="Gvpaging" />
                                                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                                                            </asp:GridView>
                                                        </td></tr>

                                                           
                             

                               <tr id="a" runat="server" style="display:none">
                                    <td colspan="4" align="right" style="white-space:nowrap;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; : &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;
                                  
                                  </td></tr>
                             
                              
                              <tr><td  colspan="4" align="right">
                                                            <asp:GridView runat="server" ID="GrdVitranNirdesh0" CssClass="tab hastable" RowStyle-CssClass="none" HeaderStyle-CssClass="none" AutoGenerateColumns="False" ShowFooter="True" OnRowDataBound="GrdVitranNirdesh0_RowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            
                                                                            <tr>
                                                                                <th rowspan="3" align="center">&#2325;&#2381;&#2352;&#2406;
                                                                                    
                                                                                    
                                                                                    
                                                                                </th>
                                                                                
                                                                                <th rowspan="3" align="center">&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350;
                                                                                </th>
                                                                               
                                                                                <th rowspan="3" style="width: 80Px;" align="center">&#2337;&#2367;&#2346;&#2379; &#2361;&#2375;&#2340;&#2369; &#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;
                                                                                  
                                                                                  
                                                                                </th>
                                                                                
                                                                                <th colspan="2" align="center">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2344;&#2306;&#2348;&#2352;&#2367;&#2306;&#2327; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339;
                                                                                     
                                                                                </th>
                                                                                <th colspan="3">&#2337;&#2367;&#2346;&#2379;&#2348;&#2366;&#2352; &#2348;&#2306;&#2337;&#2354;&#2379; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339;
                                                                                   
                                                                                </th>

                                                                                <th rowspan="3">&#2325;&#2369;&#2354; &#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;  
                                                                                   
                                                                                    
                                                                                </th>
                                                                                 
                                                                                 <th rowspan="3">&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; 
                                                                                   
                                                                                 
                                                                                </th>
                                                                                
                                                                            </tr>
                                                                            <tr>
                                                                                <th rowspan="2">&#2325;&#2361;&#2366;&#2305; &#2360;&#2375;
                                                                                   
                                                                                  
                                                                                </th>

                                                                                <th rowspan="2">&#2325;&#2361;&#2366;&#2305; &#2340;&#2325;
                                                                                    
                                                                                   
                                                                                </th>
                                                                                <th rowspan="2">&#2348;&#2306;&#2337;&#2354;&#2379; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;
                                                                                    
                                                                                  
                                                                                </th>
                                                                                <th colspan="2">&#2348;&#2306;&#2337;&#2354; &#2344;&#2350;&#2381;&#2348;&#2352;   
                                                                                </th>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>&#2325;&#2361;&#2366;&#2305; &#2360;&#2375;
                                                                                  
                                                                                 
                                                                                </th>
                                                                                <th>&#2325;&#2361;&#2366;&#2305; &#2340;&#2325;
                                                                                   
                                                                                   
                                                                                </th>
                                                                            </tr>
                                                                             <tr><th>1</th><th>2</th><th>3</th><th>4</th><th>5</th><th>6</th><th>7</th><th>8</th><th>9</th><th>10</th></tr> 
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <tr>
                                                                                <td align="center" ><%#Container.DataItemIndex+1 %>.</td>
                                                                                
                                                                                <td align="center" >
                                                                                    <asp:Label ID="lblDepoName_V0" runat="server" Text='<%#Eval("DepoName_V")%>'></asp:Label>
                                                                                </td>
                                                                                

                                                                                <td align="center" >
                                                                                    <asp:Label ID="lblNoOfBooks0" runat="server" Text='<%#Eval("NoOfBooks")%>'></asp:Label>
                                                                                </td>
                                                                                

                                                                                <td align="center" >
                                                                                    <asp:Label ID="LblBookNoFrom0" runat="server" Text='<%#Eval("BookNumberFrom")%>'></asp:Label>
                                                                                </td>
                                                                                <td align="center" >
                                                                                    <asp:Label ID="LblBookNoTo0" runat="server" Text='<%#Eval("BookNumberTo")%>'></asp:Label>
                                                                                </td>
                                                                                <td align="center" >
                                                                                    <asp:Label ID="lblTotalBundles0" runat="server" Text='<%#Eval("TotalBundels")%>'></asp:Label>
                                                                                </td >

                                                                                <td align="center" >
                                                                                    <asp:Label ID="LblBundleNoFrom0" runat="server" Text='<%#Eval("BundleNoFrom")%>'></asp:Label>
                                                                                </td>
                                                                                <td align="center" >
                                                                                    <asp:Label ID="LblBundleNOTo0" runat="server" Text='<%#Eval("BundleNoTo")%>'></asp:Label>
                                                                                </td>

                                                                                <td align="center" >
                                                                                    <asp:Label ID="LblPrinter0" runat="server" Text='<%#Eval("NoOfBooks")%>'></asp:Label>
                                                                                </td>
                                                                                
                                                                                 <td align="center" >
                                                                                    <asp:Label ID="Label10" runat="server" Text='<%#Eval("Remark")%>'></asp:Label>
                                                                                </td>
                                                                                

                                                                            </tr>

                                                                        </ItemTemplate>
                                                                        <FooterTemplate > <tr><th>Total</th><th></th><th><asp:Label ID="lbl4" runat="server"></asp:Label></th><th></th><th></th><th><asp:Label ID="lbl5" runat="server"></asp:Label></th><th></th><th></th><th><asp:Label ID="lbl6" runat="server"></asp:Label></th><th></th></tr> </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <PagerStyle CssClass="Gvpaging" />
                                                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                                                            </asp:GridView>
                                                        </td></tr>

                              <tr><td  colspan="4" align="right">
                               <b>  &#2351;&#2379;&#2332;&#2344;&#2366; &#2325;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; : <asp:Label ID="Label11" runat="server" Text=""></asp:Label> , &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; &#2325;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; : <asp:Label ID="Label12" runat="server" Text=""></asp:Label> &#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; :<asp:Label ID="Label13" runat="server" Text="Label"></asp:Label> 
                                   <br />  <br />
                                   &#2351;&#2379;&#2332;&#2344;&#2366; &#2325;&#2375; &#2325;&#2369;&#2354; &#2348;&#2306;&#2337;&#2354;  :    <asp:Label ID="lblBundle1" runat="server" Text=""></asp:Label> , &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; &#2325;&#2368; &#2348;&#2306;&#2337;&#2354; :<asp:Label ID="lblbundle2" runat="server" Text=""></asp:Label> &#2325;&#2369;&#2354; &#2348;&#2306;&#2337;&#2354; :<asp:Label ID="lblTotalB" runat="server" Text=""></asp:Label>

                               </b>   </td></tr>

                                <tr><td colspan="4">
                                  <asp:Label ID="lblM" runat="server"  ForeColor="#CC0000" Font-Bold="true" Visible="false"  ></asp:Label>
                                  </td></tr>

                              <tr><td  colspan="4" align="right">&nbsp;</td></tr>                              
                            

                              <tr><td  colspan="4" align="right">&#2350;&#2361;&#2366;&#2346;&#2381;&#2352;&#2348;&#2306;&#2343;&#2325; (&#2325;&#2366;&#2327;&#2332; &#2319;&#2357;&#2306; &#2357;&#2367;&#2340;&#2352;&#2339;)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td></tr>

                              <tr><td colspan="4" align="right">&#2350;.&#2346;&#2381;&#2352;. &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&nbsp; &#2344;&#2367;&#2327;&#2350; , &#2349;&#2379;&#2346;&#2366;&#2354;</td></tr>

                          </table></div> </td>


                </tr></table> </div> </div> 
</asp:Content>

