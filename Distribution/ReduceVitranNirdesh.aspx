<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReduceVitranNirdesh.aspx.cs" Inherits="Distribution_ReduceVitranNirdesh" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">

        <ContentTemplate>
            <div class="card">
                <div class="card-body">
                    <div class="card-header">
                        <h2>शिक्षा सत्र <b>
                            <asp:Label ID="LblFyYear" runat="server"></asp:Label></b> के लिए मुद्रको को आवंटित पाठ्यपुस्तकों को कम करने का आदेश</h2>
                    </div>
                    <div class="row g-3">
                        <div class="col-md-12">
                            <asp:Panel class="alert alert-info" runat="server" ID="mainDiv" Style="display: none;">
                                <asp:Label ID="lblmsg" class="notification" runat="server">
                                </asp:Label>
                            </asp:Panel>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:DropDownList ID="DdlACYear" runat="server" CssClass="form-select">
                                </asp:DropDownList>
                                <label id="Label7" runat="server">शिक्षा सत्र </label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:DropDownList ID="DdlGroup" runat="server" CssClass="form-select" AutoPostBack="true"
                                    OnSelectedIndexChanged="DdlGroup_SelectedIndexChanged">
                                </asp:DropDownList>
                                <label id="Label10" runat="server">ग्रुप चुने</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:TextBox ID="txtOrderNo" runat="server" CssClass="form-control" placeholder="OrderNo"></asp:TextBox>
                                <label id="Label8" runat="server">आदेश क्र.</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:TextBox ID="txtOrderDate" runat="server" CssClass="form-control" placeholder="OrderDate"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalTxtOrderDate" runat="server" Format="dd/MM/yyyy" TargetControlID="txtOrderDate">
                                </cc1:CalendarExtender>
                                <label id="Label9" runat="server">आदेश दिनांक</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:DropDownList runat="server" ID="DdlBookType" CssClass="form-select">
                                    <asp:ListItem Text="योजना" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="सामान्य" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                                <label id="Label11" runat="server">पुस्तक का प्रकार</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:DropDownList ID="DdlClass" runat="server" CssClass="form-select"
                                    AutoPostBack="True" OnSelectedIndexChanged="DdlClass_SelectedIndexChanged">
                                </asp:DropDownList>
                                <label id="Label12" runat="server">कक्षा</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:DropDownList runat="server" ID="DdlTitle" CssClass="form-select"
                                    OnSelectedIndexChanged="DdlTitle_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                                <label id="Label13" runat="server">पुस्तक का नाम</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:DropDownList runat="server" ID="DdlPrinter" CssClass="form-select">
                                </asp:DropDownList>
                                <label id="Label2" runat="server">मुद्रक का नाम</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:TextBox ID="TextBooksPerBundle" CssClass="form-control" runat="server"></asp:TextBox>
                                <label id="Label4" runat="server">प्रति बंडल पुस्तक संख्या</label>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <asp:Button ID="BtnGenerate" runat="server" CssClass="btn btn-primary" OnClick="Button2_Click" OnClientClick="javascript:return ValidateAllTextForm();" Text="वितरण निर्देश देखे " />
                        </div>
                        <div class="table-responsive mt-3">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="DepoName_V" HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                    <asp:BoundField DataField="NoOfBooks" HeaderText="&#2325;&#2369;&#2354; &#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; " />
                                    <asp:BoundField DataField="TotalBundels" HeaderText="&#2325;&#2369;&#2354; &#2348;&#2306;&#2337;&#2354;" />
                                    <asp:TemplateField HeaderText="&#2325;&#2350; &#2325;&#2368; &#2332;&#2366;&#2344;&#2375;&#2357;&#2366;&#2354;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; ">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtnoofbookReduce" runat="server" Width="97px" AutoPostBack="True" OnTextChanged="txtnoofbookReduce_TextChanged"></asp:TextBox>
                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("Trno") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2325;&#2350; &#2325;&#2367;&#2351;&#2375; &#2327;&#2319; &#2348;&#2306;&#2337;&#2354; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; ">

                                        <ItemTemplate>
                                            <asp:TextBox ID="txtReduceBundle" runat="server" Width="97px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2358;&#2375;&#2359; &#2348;&#2306;&#2337;&#2354; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; ">

                                        <ItemTemplate>
                                            <asp:TextBox ID="txtReaminBundle" runat="server" Width="97px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; &#2360;&#2375; ">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtBundelNOFrom" runat="server" Width="97px" Text='<%#Eval("BundleNoFrom") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; &#2340;&#2325; ">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtBundelNOTo" runat="server" Width="97px" Text='<%#Eval("BundleNoTo") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2306;&#2348;&#2352; &#2360;&#2375; ">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtbookNoFrom" runat="server" Width="97px" Text='<%#Eval("BookNumberFrom") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2306;&#2348;&#2352; &#2340;&#2325; ">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtbookNoTO" runat="server" Width="97px" Text='<%#Eval("BookNumberTo") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div class="col-md-12">
                            <asp:Button ID="Button1" Visible="false" runat="server" Text="सम्बंधित डिपो भेजे एवं मुद्रक को प्रेषित करे" CssClass="btn btn-primary" OnClick="Button1_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

