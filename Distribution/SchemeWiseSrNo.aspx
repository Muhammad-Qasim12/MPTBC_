<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SchemeWiseSrNo.aspx.cs" Inherits="Distribution_SchemeWiseSrNo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-body">
            <div class="card-header">
                <h2>योजना के अनुसार पुस्तक का नंबर</h2>
            </div>
            <div class="row g-3">
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlAcYear" runat="server" CssClass="form-select">
                        </asp:DropDownList>
                        <label for="floatingName">शिक्षा सत्र</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DdlScheme" runat="server" AutoPostBack="True" CssClass="form-select" OnSelectedIndexChanged="DdlScheme_SelectedIndexChanged">
                        </asp:DropDownList>
                        <label for="floatingName">योजना का नाम</label>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
                            <Columns>
                                <asp:TemplateField HeaderText="क्र.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="पुस्तक का नाम">
                                    <ItemTemplate>
                                        <%# Eval("TitleHindi_V") %>
                                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("TitleID_I") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="क्रमांक">
                                    <ItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("SrNo") %>'></asp:TextBox>

                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div>
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" OnClick="Button1_Click" Text="सुरक्षित करे" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

