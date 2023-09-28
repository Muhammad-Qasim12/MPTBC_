<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" ValidateRequest="false" EnableEventValidation="false" CodeFile="DemandRound.aspx.cs" Inherits="Distribution_DemandRound" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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

    <div class="card">
        <div class="card-body">
            <div class="card-header">
                <h2 id="lblTitleName" runat="server">बंडल के मान से डिमांड</h2>
            </div>
            <div class="row g-3">
                <div class="col-md-12">
                    <asp:Panel class="alert alert-info" runat="server" ID="mainDiv" Style="display: block;">
                        <asp:Label ID="lblmsg" class="notification" runat="server" Text="डाटा देखने की लिए कृपया सभी आप्शन सेलेक्ट करे / Please Select All Options To View Data">
                        </asp:Label>
                    </asp:Panel>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DdlACYear" runat="server" CssClass="form-select"></asp:DropDownList>
                        <label id="Label3" runat="server">शिक्षा सत्र </label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DDlDepot" runat="server" CssClass="form-select">
                        </asp:DropDownList>
                        <label id="Label1" runat="server">डिपो</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DdlScheme" runat="server" CssClass="form-select">
                        </asp:DropDownList>
                        <label id="Label2" runat="server">माध्यम</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DDLClass" runat="server" CssClass="form-select">
                            <asp:ListItem Text="Select.." Value="0"></asp:ListItem>
                            <asp:ListItem Text="1-8" Value="1-8"></asp:ListItem>
                            <asp:ListItem Text="9-12" Value="9-12"></asp:ListItem>
                        </asp:DropDownList>
                        <label id="Label4" runat="server">कक्षा</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
                        <label id="Label5" runat="server">आर्डर नंबर</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="TextBox2" runat="server" class="form-control"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                            TargetControlID="TextBox2" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <label id="Label6" runat="server">आर्डर दिनांक</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Width="300px">
                            <asp:ListItem Selected="True" Value="3">सभी</asp:ListItem>
                            <asp:ListItem Value="1">परिवर्तित</asp:ListItem>
                            <asp:ListItem Value="2">अपरिवर्तित</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                        (यदि मांग संशोधित है तो चेक बाक्स में चेक करे )
                    </div>
                </div>
                <div class="col-md-12 mt-2">
                    <asp:Button ID="Button2" runat="server" Text="डाटा देखे " CssClass="btn btn-primary" OnClick="Button2_Click" />
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-secondary" Text="Print" OnClientClick="return PrintPanel();" />
                    &nbsp;<asp:Button ID="btnExport" runat="server" CssClass="btn btn-default" OnClick="btnExport_Click" Text="Export to Excel" />
                </div>
            </div>
        </div>
    </div>
    <div class="box">
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">

                <asp:Panel ID="Panel1" runat="server">
                    <div id="ExportDiv" runat="server">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordereds" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2360;.&#2325;&#2381;&#2352;.">
                                    <ItemTemplate>

                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; ">
                                    <ItemTemplate>
                                        <%#Eval("TitleHindi_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2306;&#2337;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; ">
                                    <ItemTemplate>
                                        <%#Eval("BookNumber")%>
                                        <asp:TextBox ID="txtPerBundle" runat="server" MaxLength="3" Text='<%#Eval("BookNumber")%>' Width="40px" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged" Visible="false"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="&#2351;&#2379;&#2332;&#2344;&#2366; &#2325;&#2368; &#2344;&#2375;&#2335; &#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " DataField="SchemeDemand" />
                                <asp:BoundField HeaderText="&#2348;&#2306;&#2337;&#2354; &#2325;&#2375; &#2350;&#2366;&#2344; &#2360;&#2375; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " DataField="SchemeDemandRound" />
                                <asp:BoundField HeaderText="&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; &#2325;&#2368; &#2344;&#2375;&#2335; &#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " DataField="OpnMktDemand" />
                                <asp:BoundField HeaderText="&#2348;&#2306;&#2337;&#2354; &#2325;&#2375; &#2350;&#2366;&#2344; &#2360;&#2375; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " DataField="OpnMktDemandRound" />
                                <asp:BoundField HeaderText="&#2325;&#2369;&#2354; &#2344;&#2375;&#2335; &#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " DataField="TotalDenamd" />
                                <asp:TemplateField HeaderText="&#2348;&#2306;&#2337;&#2354; &#2325;&#2375; &#2350;&#2366;&#2344; &#2360;&#2375; &#2325;&#2369;&#2354; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;">
                                    <ItemTemplate>

                                        <asp:TextBox ID="txtPerBundle2" runat="server" Text='<%#Convert.ToInt32(Eval("SchemeDemandRound"))+Convert.ToInt32(Eval("OpnMktDemandRound"))%>' Width="70px" Enabled="false"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </asp:Panel>
                <asp:Button ID="Button3" runat="server" Text="प्रिंटिंग शाखा को भेजे" CssClass="btn btn-primary" OnClick="Button3_Click" Visible="False" />
                <div style="overflow: auto" class="rdlc">
                </div>
            </div>
        </div>
    </div>
</asp:Content>

