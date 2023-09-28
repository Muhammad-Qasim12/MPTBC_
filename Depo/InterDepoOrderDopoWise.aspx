<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InterDepoOrderDopoWise.aspx.cs" Inherits="Depo_InterDepoOrderDopoWise" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function divexpandcollapse(divname) {
            var div = document.getElementById(divname);
            var img = document.getElementById('img' + divname);

            if (div.style.display == "none") {
                div.style.display = "inline";
                //img.src = "../images/d_arrow.jpg";
            } else {
                div.style.display = "none";
                //  img.src = "../images/d_arrow.jpg";
            }
        }

    </script>
    <script type="text/javascript">
        function PrintPanel(id) {
            var panel = document.getElementById(id);
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
    <script type = "text/javascript">
        function PrintPanel1() {
            var panel = document.getElementById("<%=ExportDiv.ClientID %>");

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
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span style="font-size: medium;">&#2309;&#2306;&#2340;&#2352; &#2337;&#2367;&#2346;&#2379; &#2335;&#2381;&#2352;&#2366;&#2344;&#2381;&#2360;&#2347;&#2352; &#2330;&#2366;&#2354;&#2366;&#2344; / Inter Depot Transfer Challan </span>
            </h2>
        </div>
        <div style="padding: 0 10px;">
            <table style="width: 100%">
                <tr>
                    <td>
                                    <asp:Label ID="LblAcYear" runat="server" Width="116px">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; </asp:Label>
                    </td>
                    <td>
                                    <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                                    </asp:DropDownList>

                                    &nbsp;&nbsp;
                        <asp:TextBox ID="txtFromDate" runat="server" OnTextChanged="txtfromDate_SelectedIndexChanged" AutoPostBack="true" Visible="false"></asp:TextBox>
                                        <cc1:calendarextender ID="txtFromDate_CalendarExtender" Format="dd/MM/yyyy"  runat="server" TargetControlID="txtFromDate">
                        </cc1:calendarextender>
                    </td>
                </tr>
                <tr id="a" runat="server" >
                    <td colspan="2">
                        प्राप्तक डिपो
                        <asp:DropDownList ID="ddlReqDepo" runat="server" AutoPostBack="True" OnInit="ddlReqDepo_Init"
                            OnSelectedIndexChanged="ddlReqDepo_SelectedIndexChanged">
                        </asp:DropDownList>
                    &nbsp;</td>
                </tr>

                

                <tr>
                    <td colspan="2">
                                                    <asp:Button ID="btnExportPDF" runat="server" CssClass="btn_gry" 
                                OnClientClick="return PrintPanel1();" Text="Export to PDF & Print"  />
             <asp:Button CssClass="btn" runat="server" Text="&#2337;&#2366;&#2335;&#2366; &#2319;&#2325;&#2381;&#2360;&#2375;&#2354; &#2350;&#2375;&#2306; &#2354;&#2375;&#2306; |" ID="btnExport" OnClick="btnExport_Click" />
                        <br /><br />
                        <div id="ExportDiv" runat="server" >
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; ">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                <asp:BoundField DataField="ChallanNo" HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352; " />
                                <asp:BoundField DataField="ChalanDate" HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " />
                                <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                <asp:BoundField DataField="NetDemand" HeaderText="&#2357;&#2366;&#2360;&#2381;&#2340;&#2357;&#2367;&#2325; &#2337;&#2367;&#2350;&#2366;&#2306;&#2337; " />
                                <asp:BoundField DataField="NoOfBookTransferd" HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " />
                                <asp:BoundField DataField="TransSupply" HeaderText="&#2325;&#2361;&#2366; &#2360;&#2375; " />
                                <asp:BoundField DataField="ReqSupplier" HeaderText="&#2325;&#2361;&#2366; &#2325;&#2379;  " />
                                <asp:BoundField DataField="bookType" HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; " />
                            </Columns>
                        </asp:GridView>

                        <asp:GridView ID="GrdDepoQtyMaster" runat="server" AutoGenerateColumns="false" GridLines="None"
                            Width="100%" OnRowDataBound="GrdDepoQtyMaster_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; <br> Sr. No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2375;&#2359;&#2325; &#2337;&#2367;&#2346;&#2379; <br> Sender Depot">
                                    <HeaderTemplate>


                                        <table width="100%">
                                            <tr>
                                                <td style="width: 20%">&#2346;&#2381;&#2352;&#2375;&#2359;&#2325; &#2337;&#2367;&#2346;&#2379;
                                                    <br />
                                                    Sender Depot
                                                </td>
                                                <td style="width: 20%">&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2406;
                                            <br>
                                                    Challan No.
 
                                                </td>
                                                <td style="width: 20%">&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br>
                                                    Challan Date
  
                                                </td>
                                                <td style="width: 20%">&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2325; &#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350;
                                                    <br />
                                                    Receiver Depot Name
                                                </td>
                                                <td style="width: 20%">&#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2342;&#2375;&#2326;&#2375;<br></br>
                                                    View Details
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table width="100%">
                                            <tr>
                                                <td style="width: 20%">
                                                    <%#Eval("TransSupply")%>
                                                </td>
                                                <td style="width: 20%">
                                                    <asp:Label ID="lblChallanNo" runat="server" Text='<%#Eval("ChallanNo")%>'></asp:Label>
                                                    <asp:Label ID="lblDemandingDepotID" runat="server" Text='<%#Eval("DemandingDepotID")%>' Visible="false"></asp:Label>
                                                    <asp:Label ID="lblSupplierDepoID" runat="server" Text='<%#Eval("SupplierDepoID")%>' Visible="false"></asp:Label>
                                                </td>
                                                <td style="width: 20%">
                                                    <asp:Label ID="lblChalanDate" runat="server" Text='<%#Eval("ChalanDate")%>'></asp:Label>
                                                </td>
                                                <td style="width: 20%">
                                                    <%#Eval("ReqSupplier")%>
                                                </td>
                                                <td style="width: 20%"><a id="imgdiv<%# Eval("ChallanNo") %>" href="JavaScript:divexpandcollapse('div<%# Eval("ChallanNo") %>');" style="color: red;">View Details
                                                                            
                                                </a>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td colspan="4">
                                                    <div id="div<%# Eval("ChallanNo") %>" style="display: none; position: relative; left: 15px; overflow: auto">
                                                        <br />
                                                        <a href="#" class="btn" style="color: White;" onclick="return PrintPanel('divP<%# Eval("ChallanNo") %>');">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;</a>
                                                        <br /><br />

                                                        <div id="divP<%# Eval("ChallanNo") %>">
                                                            <asp:GridView ID="GvReelDetails" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                                CssClass="tab" Width="100%" EmptyDataText="Record Not Found." OnRowDataBound="GvReelDetails_RowDataBound"
                                                                AllowPaging="false" ShowFooter="true">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex+1 %>.
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                   <%-- <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2406; <br> Challan No." HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                        <ItemTemplate>
                                                                            <%#Eval("ChallanNo")%>
                                                                        </ItemTemplate>

                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; <br>Challan Date" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                        <ItemTemplate>
                                                                            <%#Eval("ChalanDate")%>
                                                                        </ItemTemplate>

                                                                    </asp:TemplateField>--%>
                                                                     <asp:BoundField DataField="bookType" HeaderText="बुक टाइप " />
                                                                    <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; <br>Name Of Book" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                        <ItemTemplate>
                                                                            <%#Eval("TitleHindi_V")%>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            Total :
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; <br> No Of Books" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblNoOFBook" runat="server" Text='<%#Eval("NoOfBookTransferd")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblFNoOFBook" runat="server"></asp:Label>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="&#2325;&#2361;&#2366; &#2360;&#2375; <br> From" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                        <ItemTemplate>
                                                                            <%#Eval("TransSupply")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="&#2325;&#2361;&#2366; &#2325;&#2379; <br> To" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                        <ItemTemplate>
                                                                            <%#Eval("ReqSupplier")%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                            </div>
                    </td>
                </tr>

            </table>
        </div>
    </div>

</asp:Content>

