<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OpeningStockReport.aspx.cs" Inherits="OpeningStockReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="card-header">
        <h2>&#2323;&#2346;&#2344;&#2367;&#2306;&#2327; &#2360;&#2381;&#2335;&#2377;&#2325; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; /Opening Stock Report</h2>
    </div>
    <div style="padding: 0 10px;">
        <asp:HiddenField ID="hdnId" runat="server" />

        <table class="auto-style1">
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&#2350;&#2366;&#2343;&#2381;&#2351;&#2350; </td>
                <td>

                    <asp:DropDownList ID="ddlMedium" runat="server" CssClass="txtbox reqirerd" OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged">
                    </asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; </td>
                <td>
                    <asp:DropDownList ID="ddlTital0" runat="server" CssClass="txtbox">
                        <asp:ListItem Value="2">&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;</asp:ListItem>
                        <asp:ListItem Value="1">&#2351;&#2379;&#2332;&#2344;&#2366;</asp:ListItem>
                    </asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;                             
                </td>
                <td>
                    <asp:DropDownList ID="ddlTital" runat="server" CssClass="txtbox"></asp:DropDownList>
                </td>


            </tr>
            <tr>
                <td class="auto-style2">&#2325;&#2325;&#2381;&#2359;&#2366; / Class</td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DDLClass" runat="server" CssClass="txtbox">
                        <asp:ListItem Text="1-8" Value="1-8"></asp:ListItem>
                        <asp:ListItem Text="9-12" Value="9-12"></asp:ListItem>
                    </asp:DropDownList>
                </td>


            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="LblAcYear" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;<br /> Academic Year :</asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                    </asp:DropDownList>
                </td>


            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; " /></td>
                <td>&nbsp;</td>


            </tr>
            <tr>
                <td colspan="2">
                    <div id="ExportDiv" runat="server" >

                    <asp:GridView ID="grdPrinterBundleDetails0" runat="server" AutoGenerateColumns="False" CssClass="tab" ShowFooter="true" OnRowDataBound="grdPrinterBundleDetails0_RowDataBound">
                        <Columns>
                            <%--<asp:BoundField DataField="ClassDesc_v" HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366; /Class" />--%>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;">
                                <ItemTemplate>
                                    <asp:Label Text='<%#Eval("bookType") %>' ID="NameofPress_V0" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Title Name">
                                <ItemTemplate>
                                    <a href="abc.aspx?BookTitle='<%#Eval("TitleID_I")%>'&BookType='<%#Eval("BundleType_I")%>'&Medium='<%#Eval("Medium_I")%>'&ClassTrno='<%#Eval("ClassTrno_I")%>'&Year='<%# Eval("AcYear") %>' ">
                                        <asp:Label Text='<%#Eval("TitleHindi_V") %>' ID="TitleHindi_V0" runat="server"></asp:Label></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2306;&#2337;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; ">
                                <ItemTemplate>
                                    <asp:Label Text='<%# Eval("PerBundle") %>' ID="lblPerBundle" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; ">
                                <ItemTemplate>
                                    <asp:Label Text='<%# Eval("kulbook") %>' ID="lblkulbook" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2346;&#2376;&#2325; &#2348;&#2306;&#2337;&#2354;">
                                <ItemTemplate>
                                   <asp:Label Text='<%#Eval("Total") %>' ID="lblTotal" runat="server" ></asp:Label>
                                    
                                        
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2346;&#2376;&#2325; &#2348;&#2306;&#2337;&#2354; &#2350;&#2375;&#2306; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; ">
                                <ItemTemplate>
                                    <asp:Label Text='<%#Eval("TotalBookpaik") %>' ID="lblTotalBookpaik" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="&#2346;&#2376;&#2325; &#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; &#2360;&#2375;" DataField="BundleNo_IMin" />
                            <asp:BoundField HeaderText="&#2346;&#2376;&#2325; &#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; &#2340;&#2325;" DataField="BundleNo_Imax" />
                            <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375; / Book No. From">
                                <ItemTemplate>
                                    <asp:Label Text='<%#Eval("FromNo_I") %>' ID="lblFromNo_I" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2340;&#2325; / Book No. To">
                                <ItemTemplate>
                                    <asp:Label Text='<%#Eval("ToNo_I") %>' ID="lblToNo_I" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2354;&#2370;&#2332; &#2348;&#2339;&#2381;&#2337;&#2354;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;">
                                <ItemTemplate>
                                   <asp:Label Text='<%#Eval("Loojbandal").ToString ().Equals("0")?0:1 %>' ID="lblLoojBook" runat="server"></asp:Label>
                                </ItemTemplate>
                                 <FooterTemplate>
                                     <asp:Label   ID="lblFLoojBook" runat="server"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2354;&#2370;&#2332; &#2348;&#2339;&#2381;&#2337;&#2354; &#2350;&#2375;&#2306; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;">
                                <ItemTemplate>
                                    <asp:Label Text='<%#Eval("LoojBook") %>' ID="ToNo_I0" runat="server"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                     <asp:Label   ID="FToNo_I0" runat="server"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate></asp:TemplateField> 
                            <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                            <asp:BoundField DataField="YojanaBook" HeaderText="&#2351;&#2379;&#2332;&#2344;&#2366; " />
                            <asp:BoundField DataField="samanyBook" HeaderText="&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; " />
                                                        <asp:TemplateField HeaderText="&#2325;&#2369;&#2354;">
                                <ItemTemplate>
                                                        <%#Convert.ToInt32(Eval("YojanaBook")) + Convert.ToInt32(Eval("samanyBook"))%>
                                    </ItemTemplate> 
                                                            </asp:TemplateField> 
                        </Columns>
                    </asp:GridView>
                    </div> 

                </td>
            </tr>
            <tr>
                <td colspan="2"> 
                   
                </td>
            </tr>
            <tr>
                <td colspan="2"> <asp:Button ID="btnExportPDF" runat="server" CssClass="btn_gry" 
                                OnClientClick="return PrintPanel();" Text="Export to PDF & Print" />&nbsp;
                    <asp:Button ID="btnExport" runat="server" Height="28px" Text="Export to Excel" CssClass="btn_gry" OnClick="btnExport_Click1"  />
              
                    </td>
            </tr>
        </table><script type = "text/javascript">
                                    function PrintPanel() {
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
        <br />
        <br />

    </div>
</asp:Content>

