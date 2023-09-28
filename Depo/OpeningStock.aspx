<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" enableEventValidation="false"  CodeFile="OpeningStock.aspx.cs" Inherits="Depo_OpeningStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
        <div class="card-header" id="a" runat="server" visible="false">
            <h2>&#2337;&#2367;&#2346;&#2379; &#2323;&#2346;&#2344;&#2367;&#2306;&#2327; &#2360;&#2381;&#2335;&#2377;&#2325; </h2>
        </div>

        <table width="100%">
            <tr>
                <td><span style="color: rgb(34, 34, 34); font-family: Arial, Verdan, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: bold; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(252, 253, 253); display: inline !important; float: none;">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;</span></td>
                <td>
                    <asp:DropDownList ID="DdlACYear" CssClass="txtbox" runat="server" AutoPostBack="True" ></asp:DropDownList>
                </td>
                <td>&#2337;&#2367;&#2346;&#2379; &#2344;&#2366;&#2350; </td>
                <td>
                    <asp:DropDownList ID="DDlDepot" runat="server" CssClass="txtbox">
                    </asp:DropDownList>
                </td>


                <td>
                    &#2325;&#2325;&#2381;&#2359;&#2366;
                </td>


                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="txtbox" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem Value="0">Select...</asp:ListItem>
                        <asp:ListItem Value="1">1-8</asp:ListItem>
                        <asp:ListItem Value="2">9-12</asp:ListItem>
                    </asp:DropDownList>
                </td>


                <td>&#2350;&#2366;&#2343;&#2381;&#2351;&#2350; </td>


                <td>
                    <asp:DropDownList ID="ddlMedium" runat="server" CssClass="txtbox" AutoPostBack="True" OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>


            </tr>
            <tr>
                <td colspan="8">
                      <div id="ExportDiv" runat="server">
                          <table width="100%" id="aa" runat="server" visible="false" >
                              <tr><td align="center" > शिक्षा सत्र :<%=DdlACYear.SelectedItem.Text %> हेतु डिपो प्रवन्धको से प्राप्त (भौतिक सत्यापन के आधार पर ) योजना एवं सामान्य पुस्तकों के स्टॉक का विवरण  </td></tr>
                              <tr><td> डिपो का नाम : <%=DDlDepot.SelectedItem.Text %> , माध्यम :  <%=ddlMedium.SelectedItem.Text %>, कक्षा :  <%=DropDownList1.SelectedItem.Text %> </td></tr>
                          </table>
                    <asp:GridView ID="GridView1" Width="100%" runat="server" AutoGenerateColumns="False" CssClass="tab" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;.">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " DataField="TitleHindi_V" />
                            <asp:TemplateField HeaderText="&#2351;&#2379;&#2332;&#2344;&#2366; ">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtYojna" runat="server" CssClass="txtbox" Width="100px" Text='<%# Eval("YojanaBook") %>' Enabled='<%# Eval("status").ToString()=="1" ? false  : true %>' onkeypress='javascript:tbx_fnNumeric(event, this);'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; ">
                                <ItemTemplate>
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("TitleID_I")%>' />
                                    <asp:TextBox ID="txtSamany" runat="server" CssClass="txtbox" Width="100px" Text='<%# Eval("samanyBook") %>' Enabled='<%# Eval("status").ToString()=="1" ? false  : true %>' onkeypress='javascript:tbx_fnNumeric(event, this);'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                          <asp:GridView ID="GridView2" Width="100%" runat="server" AutoGenerateColumns="False" CssClass="tab" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;.">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " DataField="TitleHindi_V" />
                            <asp:TemplateField HeaderText="&#2351;&#2379;&#2332;&#2344;&#2366; ">
                                <ItemTemplate>
                                    <%#Eval("YojanaBook") %>
                                    <%--<asp:TextBox ID="txtYojna" runat="server" CssClass="txtbox" Width="100px" Text='<%# Eval("YojanaBook") %>' Enabled='<%# Eval("status").ToString()=="1" ? false  : true %>' onkeypress='javascript:tbx_fnNumeric(event, this);'></asp:TextBox>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; ">
                                <ItemTemplate>
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("TitleID_I")%>' />
                                    <%#Eval("samanyBook") %>
                                    <%--<asp:TextBox ID="txtSamany" runat="server" CssClass="txtbox" Width="100px" Text='<%# Eval("samanyBook") %>' Enabled='<%# Eval("status").ToString()=="1" ? false  : true %>' onkeypress='javascript:tbx_fnNumeric(event, this);'></asp:TextBox>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                      </div>
                </td>


            </tr>
            <tr>
                <td colspan="8">
                    <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="&#2337;&#2366;&#2335;&#2366; &#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; " />
                &nbsp;<asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" Text="&#2337;&#2366;&#2335;&#2366; &#2325;&#2366; &#2309;&#2344;&#2369;&#2350;&#2379;&#2342;&#2344; &#2325;&#2352;&#2375;&#2306; " />
                &nbsp;<asp:Button ID="btnExport" runat="server" Height="28px" Text="Export to Excel" CssClass="btn" OnClick="btnExport_Click" />
              
                    &nbsp;  <a href="#" class="btn" style="color: White;" onclick="return PrintPanel();">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;</a>
                      </td>


            </tr>
        </table>
    </div>
</asp:Content>

