<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DepoStockBarcode.aspx.cs" Inherits="Depo_DepoStockBarcode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="box table-responsive">
        <div class="card-header">
            <h2>&#2349;&#2380;&#2340;&#2367;&#2325; &#2360;&#2340;&#2381;&#2351;&#2366;&#2346;&#2344; &#2325;&#2375; &#2360;&#2381;&#2335;&#2377;&#2325; &#2325;&#2366; &#2348;&#2366;&#2352;&#2325;&#2379;&#2337; </h2>
        </div>
        <div style="padding: 0 10px;">
            <table width="100%">
                <tr>
                    <td class="auto-style1">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; :</td>
                    <td>&nbsp;<asp:DropDownList ID="ddlSessionYear" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                    <td>
                        <asp:DropDownList ID="DdlDepot" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp; &#2350;&#2366;&#2343;&#2381;&#2351;&#2350; </td>
                    <td>
                        <asp:DropDownList ID="ddlMedium" runat="server" CssClass="txtbox reqirerd" 
                            >
                        </asp:DropDownList>
                    </td>
                    <td>&#2325;&#2325;&#2381;&#2359;&#2366; / Class</td>
                    <td>
                        <asp:DropDownList ID="DDLClass" runat="server" >
                            <asp:ListItem Value="0">Select..</asp:ListItem>
                            <asp:ListItem Text="1-8" Value="1-8"></asp:ListItem>
                            <asp:ListItem Text="9-12" Value="9-12"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1" colspan="4">
                        <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="&#2360;&#2381;&#2335;&#2377;&#2325; &#2342;&#2375;&#2326;&#2375; " />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1" colspan="4">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;">
                                    <ItemTemplate>
                                       <%# Container.DataItemIndex +1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                                <asp:BoundField DataField="DepoName_V" HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                <asp:BoundField DataField="BookType" HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; " />
                                <asp:BoundField DataField="BundleNoFrom" HeaderText="&#2348;&#2306;&#2337;&#2354;  &#2344;&#2306;&#2348;&#2352; &#2360;&#2375; " />
                                <asp:BoundField DataField="BundleNoTo" HeaderText="&#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; &#2340;&#2325; " />
                                <asp:BoundField DataField="TotalBunlde" HeaderText="&#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " />
                                <asp:TemplateField HeaderText="&#2348;&#2366;&#2352;&#2325;&#2379;&#2337; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2325;&#2352;&#2375;&#2306; ">
                                    <ItemTemplate>
                                    <a href="barCode_1.aspx?ACYear=<%# Eval("AcYear") %>&Bookstart=<%#Eval("Bookstart") %>&BookType=<%# Eval("BookType") %>&TxtBundleNoFrom=<%# Eval("BundleNoFrom") %>&lblBundleNoTo=<%# Eval("BundleNoTo") %>&Title=<%#Eval("TitleHindi_V") %>&Printer=<%#Eval("DepoName_V")%>&Cnt=<%#Eval("Cnt")%>&DepoName=<%#Eval("DepoName_V") %>" target="_blank" >Print</a>
                                       <%-- =' + ACYear + '&Bookstart=' + TxtBookNoFrom.textContent + '&BookType=' + DdlBookType.textContent + '&TxtBundleNoFrom=' + TxtBundleNoFrom.textContent + "&lblBundleNoTo=" + lblBundleNoTo.textContent + "&Title=" + DdlTitle.textContent + "&Printer=" + DdlPrinter.textContent + "&Cnt=" + TextBooksPerBundle.textContent)--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </div>

</asp:Content>

