<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TotalVitranNirdesh.aspx.cs" Inherits="Depo_TotalVitranNirdesh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
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
     <div class="box table-responsive">

        <div class="card-header">
            <h2>
                <span style="font-size: medium;">&#2350;&#2369;&#2342;&#2381;&#2352;&#2367;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;                </span>
            </h2>
        </div>
        <div class="box">
               <table width="100%">

                <tr><td>
                    <asp:Label ID="LblAcYear" runat="server" Width="144px">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;/ Year :</asp:Label>
                    </td><td>
                        <asp:DropDownList ID="DdlACYear" runat="server"  CssClass="txtbox reqirerd">
                        </asp:DropDownList>
                    </td><td>&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;</td><td>
                    <asp:DropDownList ID="ddlMedium" runat="server">
                    </asp:DropDownList>
                    </td><td>&#2325;&#2325;&#2381;&#2359;&#2366; </td>
                    <td>
                        <asp:DropDownList ID="DropDownList2" runat="server">
                            <asp:ListItem Value="1,2,3,4,5,6,7,8">1-8</asp:ListItem>
                            <asp:ListItem Value="9,10,11,12">9-12</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    </tr> 

                <tr><td>
                    डिपो का नाम
                    </td><td>
                            <asp:DropDownList ID="DDlDepot" runat="server" CssClass="txtbox"
                               >
                            </asp:DropDownList>
                    </td><td>&nbsp;</td><td>
                    &nbsp;</td><td>&nbsp;</td>
                    <td>
                        &nbsp;</td>
                    </tr> 

                <tr><td colspan="6">
                    <asp:Button ID="Button1" runat="server" CssClass="btn" Text="Show Report" OnClick="Button1_Click" />
                    &nbsp;<a class="btn" href="#" onclick="return PrintPanel();" style="color: White;">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;</a>

                                                  <asp:Button CssClass="btn" runat="server" Text="डाटा एक्सेल में लें |" ID="btnExport" OnClick="btnExport_Click" />
                    </td>

        
                      </tr> 

                <tr><td colspan="6">  <div id="ExportDiv" runat="server">
                    <center>&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; <%=DdlACYear.SelectedValue %> &#2325;&#2375; &#2354;&#2367;&#2319; &#2350;&#2369;&#2342;&#2381;&#2352;&#2367;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; 
                        <br />
                    </center>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True">
                        <Columns>
                          <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;.">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                            <asp:BoundField DataField="Yojna" HeaderText="&#2351;&#2379;&#2332;&#2344;&#2366; " />
                            <asp:BoundField DataField="Samay" HeaderText="&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; " />
                            <asp:BoundField DataField="Toal" HeaderText="&#2325;&#2369;&#2354; " />
                        </Columns>
                    </asp:GridView></div> 
                    </td>
                    </tr> 
                   </table> 
            </div> </div> 
</asp:Content>

