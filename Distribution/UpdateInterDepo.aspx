<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateInterDepo.aspx.cs" Inherits="Distribution_UpdateInterDepo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-body">
            <div class="card-header">
                <h2>अंतरडिपो डाटा अपडेट</h2>
            </div>
            <div class="row g-3">
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlSessionYear" runat="server" CssClass="form-select reqirerd">
                        </asp:DropDownList>
                        <label>शिक्षा सत्र</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlDepo" runat="server" CssClass="form-select reqirerd" OnSelectedIndexChanged="ddlDepo_SelectedIndexChanged">
                        </asp:DropDownList>
                        <label>डिपो का नाम</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlMedium" runat="server" CssClass="form-select reqirerd" AutoPostBack="True" OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged">
                        </asp:DropDownList>
                        <label>माध्यम</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlOrder" runat="server" CssClass="form-select reqirerd">
                        </asp:DropDownList>
                        <label>आर्डर नंबर</label>
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-secondary" OnClick="Button1_Click" Text="डाटा देखे" />
                </div>
                <div class="col-md-12">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" DataKeyNames="DemandChildTrNo">
                        <Columns>
                            <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                            <asp:TemplateField HeaderText="&#2357;&#2366;&#2360;&#2381;&#2340;&#2357;&#2367;&#2325;  &#2350;&#2366;&#2306;&#2327; ">
                                <ItemTemplate>
                                    <asp:TextBox runat="server" ID="txt01" Text='<%# Eval ("NetDemand") %>'></asp:TextBox>
                                </ItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; ">
                                <ItemTemplate>
                                    <asp:TextBox runat="server" ID="txt02" Text='<%# Eval ("NoOfBookTransferd") %>'></asp:TextBox>
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval ("DemandChildTrNo") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="col-md-12">
                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary" OnClick="Button2_Click" Text="&#2360;&#2375;&#2357; &#2325;&#2352;&#2375;&#2306; " />
                </div>
            </div>
        </div>
    </div>

</asp:Content>

