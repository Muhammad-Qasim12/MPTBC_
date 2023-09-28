<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="RptStockOnDepot.aspx.cs" Inherits="Distrubution_RptStockOnDepot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
    <%--<asp:UpdatePanel ID="up1" runat="server">
<ContentTemplate>
<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up1">
                            <ProgressTemplate>
                                <div class="fade">
                                </div>
                                <div class="progress">
                                    <img src="../images/LoadingCircle_finalani.gif" alt="Loading..." width="110" height="110" />
                                </div>
                            </ProgressTemplate>
                            </asp:UpdateProgress>--%>
    <div class="box table-responsive">

        <div class="card-header">
            <h2>
                <span style="font-size: medium;">&#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2375; &#2350;&#2380;&#2332;&#2370;&#2342;&#2366; &#2360;&#2381;&#2335;&#2377;&#2325; &#2325;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; / Report Of Available Stock in Textbook
                </span>
            </h2>
        </div>
        <div class="portlet-content">
            <asp:Panel class="response-msg inf ui-corner-all" runat="server" ID="mainDiv" Style="display: none; padding-top: 10px; padding-bottom: 10px;">
                <asp:Label ID="lblmsg" class="notification" runat="server"
                    Text="&#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2375; &#2350;&#2380;&#2332;&#2370;&#2342;&#2366; &#2360;&#2381;&#2335;&#2377;&#2325; &#2325;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; ">
                
                </asp:Label>
            </asp:Panel>
            <table width="100%">

                <tr>

                    <td style="font-size: medium;">
                        <asp:Label ID="LblDepot" runat="server">&#2337;&#2367;&#2346;&#2379;  &#2330;&#2369;&#2344;&#2375; <br /> Choose Depot  :</asp:Label>

                    </td>
                    <td>
                        <asp:DropDownList ID="DdlDepot" runat="server" CssClass="txtbox"></asp:DropDownList>

                    </td>
                    <td style="font-size: medium;" valign="top">
                        <asp:Label ID="LblMedium" runat="server">&#2350;&#2366;&#2343;&#2381;&#2351;&#2350; <br /> Medium :</asp:Label>

                    </td>
                    <td>
                        <asp:DropDownList ID="DdlMedium" runat="server" CssClass="txtbox"></asp:DropDownList>

                    </td>
                </tr>


                <tr>

                    <td style="font-size: medium;">
                        <asp:Label ID="LblClass" runat="server">&#2325;&#2325;&#2381;&#2359;&#2366; <br /> Class :</asp:Label>

                    </td>
                    <td>
                        <asp:DropDownList ID="DdlClass" runat="server" AutoPostBack="true"
                            CssClass="txtbox" OnSelectedIndexChanged="DdlClass_SelectedIndexChanged">
                        </asp:DropDownList>

                    </td>
                    <td style="font-size: medium;" valign="top">
                        <asp:Label ID="LblTitle" runat="server">&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; <br /> Title :</asp:Label>

                    </td>
                    <td>
                        <asp:DropDownList ID="DdlTitle" runat="server" CssClass="txtbox">
                        </asp:DropDownList>

                    </td>
                </tr>


                <tr>

                    <td style="font-size: medium;">
                            <asp:Label ID="LblAcYear" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; <br /> Academic Year :</asp:Label>

                    </td>
                    <td>
                            <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox reqirerd">
                            </asp:DropDownList>


                    </td>
                    <td style="font-size: medium;" valign="top" colspan="2">
                        <asp:Button ID="Button1" runat="server" CssClass="btn" Text="Show Report"  OnClick="BtnShow_Click" />

                    </td>
                </tr>


                <tr>
                    <td colspan="4" style="text-align: center" id="tdPrintContent" runat="server" visible="false">
                        <div style="color: White; float: right;">

                            <table>
                                <tr>
                                    <td>
                                        <a href="#" class="btn" style="color: White;" onclick="return PrintPanel();">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; / Print </a>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnExport" runat="server" Height="28px" Text="&#2319;&#2325;&#2381;&#2360;&#2354; &#2350;&#2375;&#2306; &#2342;&#2375;&#2326;&#2375; / Export to Excel" CssClass="btn" OnClick="btnExport_Click" />
                                    </td>

                                </tr>
                            </table>
                        </div>
                        <div style="width: auto; height: auto;">
                            <center>
                                <div class="MT20">
                                    <asp:Panel ID="Panel1" runat="server" Width="100%">
                                        <div id="ExportDiv" runat="server">
                                            <div style="width: 100%">
                                                <div style="padding: 10px;">
                                                    <table width="100%">
                                                        <tr>
                                                            <td colspan="4" style="font-size: 18px; font-weight: bold; text-align: center;">&#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" style="font-size: 16px; font-weight: 200; text-align: center;"> " &#2357;&#2367;&#2340;&#2352;&#2339; (&#2309;) &#2358;&#2366;&#2326;&#2366; "
                                                            </td>
                                                        </tr>
                                                        
                                                        <tr>
                                                            <td style="font-size: 16px; font-weight: 200; text-align: left;">
                                                                <asp:Label ID="lblAcademicYear" runat="server"></asp:Label>
                                                            </td>
                                                            <td colspan="2" style="font-size: 18px; font-weight: bold; text-align: center; padding-right: 80px;">&#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2375; &#2350;&#2380;&#2332;&#2370;&#2342;&#2366; &#2360;&#2381;&#2335;&#2377;&#2325; &#2325;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; 
                                                            </td>
                                                            <td style="font-size: 16px; font-weight: 200; text-align: right;">
                                                                <asp:Label ID="lblDate" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" style="font-size: 16px; font-weight: 200; text-align: center;"> 
                                                                <asp:Label ID="lblPageTitle" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" style="font-size: 13px; font-weight: 200; text-align: center;">
                                                                <asp:GridView ID="GrdStock" runat="server" AutoGenerateColumns="false"
                                                                    CssClass="tab" EmptyDataText="Record Not Found." GridLines="None" 
                                                                    Width="100%" OnSelectedIndexChanged="GrdStock_SelectedIndexChanged" ShowFooter="true" OnRowDataBound="GrdStock_RowDataBound">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; <br /> Sr.No. <br /><br />1" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex+1 %>.
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; <br /> Depot Name <br /><br />2" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>
                                                                                <%#Eval("DepotName")%>
                                                                            </ItemTemplate>
                                                                            
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;<br /> Medium <br /><br />3" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>
                                                                                <%#Eval("MediunNameHindi_V")%>
                                                                            </ItemTemplate>
                                                                          
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; <br /> Title <br /><br />4" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>
                                                                                <%#Eval("Title")%>
                                                                            </ItemTemplate>
                                                                              <FooterTemplate>
                                                                                Total :
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="&#2351;&#2379;&#2332;&#2344;&#2366; &#2325;&#2368; &#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2375; <br /> Net Scheme Book <br /><br />5 " HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>
                                                                              <asp:Label ID="lblyojna" runat="server" Text='<%#Eval("yojna")%>'></asp:Label>  
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblfyojna" runat="server" ></asp:Label>  
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; &#2325;&#2368; &#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2375; <br /> Net Genral Book <br /><br />6" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>
                                                                                 <asp:Label ID="lblOpnMkt" runat="server" Text='<%#Eval("OpnMkt")%>'></asp:Label> 
                                                                            </ItemTemplate>
                                                                             <FooterTemplate>
                                                                                <asp:Label ID="lblfOpnMkt" runat="server" ></asp:Label>  
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="(&#2351;&#2379;&#2332;&#2344;&#2366; + &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;) &#2325;&#2368; &#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2375;&#2306;<br />(Scheme + Genral Net Books)  <br /><br />7" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>
                                                                               <asp:Label ID="lblTotal" runat="server" Text='<%#Eval("Total")%>'></asp:Label>    
                                                                            </ItemTemplate>
                                                                               <FooterTemplate>
                                                                                <asp:Label ID="lblfTotal" runat="server" ></asp:Label>  
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                         <asp:TemplateField HeaderText="मूल्य  <br /><br />8" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>
                                                                               <asp:Label ID="lblTotal1" runat="server" Text='<%#Eval("Rate_N")%>'></asp:Label>    
                                                                            </ItemTemplate>
                                                                               <FooterTemplate>
                                                                                <asp:Label ID="lblfTotal1" runat="server" ></asp:Label>  
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                         <asp:TemplateField HeaderText=" कुल राशि  <br /><br />8" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>
                                                                               <asp:Label ID="lblTotal2" runat="server" Text='<%#Eval("Amounta")%>'></asp:Label>    
                                                                            </ItemTemplate>
                                                                               <FooterTemplate>
                                                                                <asp:Label ID="lblfTotal2" runat="server" ></asp:Label>  
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
                                        </div>
                                    </asp:Panel>
                                </div>
                            </center>
                        </div>
                    </td>
                </tr>
                </tr>
             
            </table>
        </div>
        <div style="margin-left: 80px;">
            &nbsp;
        </div>
    </div>
    <%--
</ContentTemplate>

</asp:UpdatePanel>--%>
</asp:Content>
