﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OtherThenTextbookPrinterChallanRpt.aspx.cs" Inherits="Printing_OtherThenTextbookPrinterChallanRpt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div runat="server" id = "ExportDiv">  
   
    <table width="100%">
        <tr>
            <td colspan="4" align="center" >
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              &#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; : -  <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="14pt"></asp:Label>
            </td>
        </tr>
         
        <tr>
            <td colspan="4">&#2346;&#2381;&#2352;&#2340;&#2367;,<br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &#2337;&#2367;&#2346;&#2379; &#2346;&#2381;&#2352;&#2348;&#2306;&#2343;&#2325;
        <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &#2350;.&#2346;&#2381;&#2352;. &#2346;&#2366;&#2336;&#2381;&#2351; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;
                &#2349;&#2306;&#2337;&#2366;&#2352;
        <br />
               &nbsp;&nbsp; &nbsp;&nbsp;  <%=ds1.Tables[0].Rows[0]["DepoName_V"].ToString()%>
        <br />
            </td>
        </tr>
         
        <tr align="center">
            <td colspan="4" align="center" ><b>&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; (&#2351;&#2379;&#2332;&#2344;&#2366; /&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;)</b> </td>
        </tr>
        <tr>
            <td>&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; </td>
            <td><%=ds1.Tables[0].Rows[0]["acyear"].ToString()%></td>
            <td>&#2357;&#2367;&#2340;&#2381;&#2340;&#2368;&#2351; &#2357;&#2352;&#2381;&#2359; </td>
            <td><%=ds1.Tables[0].Rows[0]["acyear"].ToString()%></td>
        </tr>
        <tr>
            <td>&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2310;&#2342;&#2375;&#2358; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;</td>
            <td></td>
            <td>&#2357;&#2367;&#2340;&#2352;&#2339; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;</td>
            <td><%=ds1.Tables[0].Rows[0]["vitranno"].ToString()%></td>
        </tr>
        <tr>
            <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; </td>
            <td><%=ds1.Tables[0].Rows[0]["ChallanNO"].ToString()%></td>
            <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </td>
            <td><%=ds1.Tables[0].Rows[0]["ChalanDate"].ToString()%></td>
        </tr>
        <tr>
            <td>शीर्षक</td>
            <td><%=ds1.Tables[0].Rows[0]["TitleHindi_V"].ToString()%></td>
            <td>कक्षा</td>
            <td><%=ds1.Tables[0].Rows[0]["SubTitleHindi_V"].ToString()%> </td>
        </tr>
        <tr>
            <td>&#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2344;&#2306;&#2348;&#2352; </td>
            <td><%=ds1.Tables[0].Rows[0]["billtiNo"].ToString()%></td>
            <td>&#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </td>
            <td><%=Convert.ToDateTime(ds1.Tables[0].Rows[0]["Billtidate"]).ToString("dd/MM/yyyy")%></td>
        </tr>

         <tr>
            <td>&#2335;&#2381;&#2352;&#2325; &#2344;&#2306;&#2348;&#2352;   </td>
            <td><%=ds1.Tables[0].Rows[0]["TruckNo"].ToString()%></td>
            <td>&#2337;&#2381;&#2352;&#2366;&#2311;&#2357;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;  </td>
            <td><%=ds1.Tables[0].Rows[0]["DriverName"].ToString()%></td>
        </tr>


         


        <tr>
            <td colspan="4">
                <table cellpadding="9" class="tab" border="1">
                    <tr>
                        <th>&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;</th>
                        <th>कक्षा</th>
                        <th>डिपो</th>
                        
                        <th>प्रति बंडल संख्या  </th>
                        <th>प्रदाय बंडल संख्या  </th>
                        <th>कुल प्रदाय संख्या</th>
                        
                    </tr>
                    <tr>                        <td >1</td>
                        <td><%=ds1.Tables[0].Rows[0]["Title"].ToString()%></td>
                         <td><%=ds1.Tables[0].Rows[0]["DepoName_V"].ToString()%></td>
                       
                        <td><%=ds1.Tables[0].Rows[0]["BookNumber"].ToString()%></td>
                        <td><%=ds1.Tables[0].Rows[0]["TotalBundle"].ToString()%></td>
                        <td><%=ds1.Tables[0].Rows[0]["PrdadayBooks"].ToString()%></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339; &#2309;&#2327;&#2354;&#2375; &#2346;&#2371;&#2359;&#2381;&#2336; &#2346;&#2352; &#2361;&#2376; !</td>
        </tr>
        <tr>
            <td colspan="4">&#2346;&#2381;&#2352;&#2340;&#2367;&#2354;&#2367;&#2346; : - &#2357;&#2352;&#2367;&#2359;&#2381;&#2336; &#2346;&#2381;&#2352;&#2348;&#2306;&#2343;&#2325; &#2357;&#2367;&#2340;&#2352;&#2339; &#2350;.&#2346;&#2381;&#2352;. &#2346;&#2366;&#2336;&#2381;&#2351; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; ,
             <%=ds1.Tables[0].Rows[0]["DepoName_V"].ToString()%>  &nbsp;  &#2325;&#2368; &#2323;&#2352; &#2360;&#2370;&#2330;&#2344;&#2366;&#2352;&#2381;&#2341; !</td>
        </tr>
        <tr>
            <td colspan="4">
                <br />
                <br />
                &#2361;&#2360;&#2381;&#2340;&#2366;&#2325;&#2381;&#2359;&#2352; &#2319;&#2357;&#2306; &#2360;&#2368;&#2354; &#2350;&#2369;&#2342;&#2381;&#2352;&#2325; 
                <br />
            </td>
        </tr>
       <%-- <tr>
            <td colspan="4">&#2344;&#2379;&#2335; : - 1.&nbsp; &#2326;&#2369;&#2354;&#2375; &#2348;&#2366;&#2332;&#2366;&#2352; &#2350;&#2375;&#2306; &#2357;&#2367;&#2325;&#2381;&#2352;&#2351; &#2361;&#2375;&#2340;&#2369; &#2350;&#2369;&#2342;&#2381;&#2352;&#2367;&#2340; &#2361;&#2379;&#2344;&#2375; &#2357;&#2366;&#2354;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2375; &#2337;&#2367;&#2360;&#2381;&#2346;&#2376;&#2330; &#2330;&#2366;&#2354;&#2366;&#2344; &#2350;&#2375;&#2306; &#2349;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &#2325;&#2375; &#2360;&#2368;&#2352;&#2367;&#2351;&#2354; &#2344;&#2306;&#2348;&#2352; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358;&#2344;&#2369;&#2360;&#2366;&#2352; &#2309;&#2306;&#2325;&#2367;&#2340; &#2325;&#2367;&#2351;&#2366; &#2332;&#2366;&#2357;&#2375; !</td>
        </tr>--%>
        <tr>
            <td colspan="4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        </tr>
        <tr>
            <td colspan="4">
                <br />
                &#2350;&#2369;&#2342;&#2381;&#2352;&#2339;&#2366;&#2354;&#2351; &#2325;&#2366; &#2344;&#2366;&#2350; &#2319;&#2357;&#2306; &#2361;&#2360;&#2381;&#2340;&#2366;&#2325;&#2381;&#2359;&#2352;
                <br />
            </td>
        </tr>
        <tr align="center">
            <td colspan="4" align="center" >
                &nbsp;</td>
        </tr>
        <tr align="center">
            <td colspan="4" align="center" >
                &nbsp;</td>
        </tr>
        <tr align="center">
            <td colspan="4" align="center" >
                &nbsp;</td>
        </tr>
        <tr align="center">
            <td colspan="4" align="center" >
                &nbsp;</td>
        </tr>
        <tr align="center">
            <td colspan="4" align="center" >
                &nbsp;</td>
        </tr>
        <tr align="center" style="display:none;">
            <td colspan="4" align="center" >
             <b>  &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339;</b> 
            </td>
        </tr>
        <tr style="display:none;">
            <td colspan="4">
                <asp:GridView ID="GrdMismatch" runat="server" AutoGenerateColumns="False" CssClass="tab">
                    <Columns>
                        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                            <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                    
                                                 </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="&#2348;&#2306;&#2337;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                            <ItemTemplate>
                                <asp:Label ID="lblBundleNo_I" runat="server" Text='<%#Eval("BundleNo_I") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375;">
                            <ItemTemplate>
                                <asp:Label ID="lblFromNo_I" runat="server" Text='<%#Eval("FromNo_I") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2340;&#2325;">
                            <ItemTemplate>
                                <asp:Label ID="lblToNo_I" runat="server" Text='<%#Eval("ToNo_I") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
       <%-- <tr>
            <td colspan="4">
                &#2361;&#2360;&#2381;&#2340;&#2366;&#2325;&#2381;&#2359;&#2352; &#2319;&#2357;&#2306; &#2360;&#2368;&#2354; &#2350;&#2369;&#2342;&#2381;&#2352;&#2325;<br />
                <br />
            </td>
        </tr>--%>
       <%-- <tr>
            <td colspan="4">
                &#2346;&#2381;&#2352;&#2340;&#2367;&#2354;&#2367;&#2346; :&nbsp; &#2346;&#2381;&#2352;&#2340;&#2367;&#2354;&#2367;&#2346; : - &#2357;&#2352;&#2367;&#2359;&#2381;&#2336; &#2346;&#2381;&#2352;&#2348;&#2306;&#2343;&#2325; &#2357;&#2367;&#2340;&#2352;&#2339; &#2350;.&#2346;&#2381;&#2352;. &#2346;&#2366;&#2336;&#2381;&#2351; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; ,&#2349;&#2379;&#2346;&#2366;&#2354; &#2325;&#2368; &#2323;&#2352; &#2360;&#2370;&#2330;&#2344;&#2366;&#2352;&#2381;&#2341; !</td>
        </tr>
        <tr>
            <td colspan="4">
                <br />
                <br />
                &#2361;&#2360;&#2381;&#2340;&#2366;&#2325;&#2381;&#2359;&#2352; &#2319;&#2357;&#2306; &#2360;&#2368;&#2354; &#2350;&#2369;&#2342;&#2381;&#2352;&#2325;</td>
        </tr> --%>
    </table></div>  <asp:Button ID="btnExport" runat="server" Text="Print"  
        CssClass="btn_gry" OnClientClick="PrintPanel();" />
     <script type = "text/javascript">
         function PrintPanel() {
             var panel = document.getElementById("<%=ExportDiv.ClientID %>");

             var printWindow = window.open('', '', 'height=400,width=800');
             printWindow.document.write('<html><head><title>Printer Challan Detail</title>');
             printWindow.document.write('</head><body >');
             printWindow.document.write(panel.innerHTML);
             printWindow.document.write('</body></html>');
             printWindow.document.close();
             setTimeout(function () {
                 printWindow.print(); 

             }, 500);
             return false;
         }</script>
</asp:Content>

