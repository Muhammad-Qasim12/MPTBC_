<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="OpeningStock.aspx.cs" Inherits="Depo_OpeningStock" %>

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
        }

    </script>
    <div class="card">
        <div class="card-body">
            <div class="card-header">
                <h2>डिपो ओपनिंग स्टॉक</h2>
            </div>
            <div class="row g-3">
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DdlACYear" CssClass="form-select" runat="server" AutoPostBack="True"></asp:DropDownList>
                        <label id="Label7" runat="server">शिक्षा सत्र </label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DDlDepot" runat="server" CssClass="form-select">
                    </asp:DropDownList>
                        <label id="Label1" runat="server">डिपो नाम</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="form-select" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem Value="0">Select...</asp:ListItem>
                        <asp:ListItem Value="1">1-8</asp:ListItem>
                        <asp:ListItem Value="2">9-12</asp:ListItem>
                    </asp:DropDownList>
                        <label id="Label2" runat="server">कक्षा</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlMedium" runat="server" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged">
                    </asp:DropDownList>
                        <label id="Label3" runat="server">माध्यम</label>
                    </div>
                </div>
                <div class="col-md-12">
                    <div id="ExportDiv" runat="server">
                        <table width="100%" id="aa" runat="server" visible="false">
                            <tr>
                                <td align="center">शिक्षा सत्र :<%=DdlACYear.SelectedItem.Text %> हेतु डिपो प्रवन्धको से प्राप्त (भौतिक सत्यापन के आधार पर ) योजना एवं सामान्य पुस्तकों के स्टॉक का विवरण  </td>
                            </tr>
                            <tr>
                                <td>डिपो का नाम : <%=DDlDepot.SelectedItem.Text %> , माध्यम :  <%=ddlMedium.SelectedItem.Text %>, कक्षा :  <%=DropDownList1.SelectedItem.Text %> </td>
                            </tr>
                        </table>
                        <asp:GridView ID="GridView1" Width="100%" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True">
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
                </div>
                <div>
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" OnClick="Button1_Click" Text="डाटा सुरक्षित करें " />
                    &nbsp;<asp:Button ID="Button2" runat="server" CssClass="btn btn-secondary" OnClick="Button2_Click" Text="डाटा का अनुमोदन करें" />
                    &nbsp;<asp:Button ID="btnExport" runat="server" Text="Export to Excel" CssClass="btn btn-defaul" OnClick="btnExport_Click" />
                    </div>
            </div>
        </div>
    </div>
</asp:Content>

