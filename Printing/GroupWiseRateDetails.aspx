<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GroupWiseRateDetails.aspx.cs" Inherits="Printing_GroupWiseRateDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
            <h2>टेंडर के ग्रुप में लाटरी नंबर का आवंटन</h2>
        </div>
        <div class="card-body">

            <div class="row g-3">
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DdlACYear" CssClass="form-control reqirerd" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged"></asp:DropDownList>
                        <label>शिक्षा सत्र</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlTenderID_I" CssClass="form-control reqirerd" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTenderID_I_SelectedIndexChanged"></asp:DropDownList>
                        <label>सेलेक्ट टेंडर</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlGroup" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged">
                        </asp:DropDownList>
                        <label>सेलेक्ट ग्रुप</label>
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
                        <Columns>
                            <asp:BoundField DataField="groupno_v" HeaderText="Name of the Books &amp; Class" />
                            <asp:BoundField DataField="Noofpages" HeaderText="Approx No of Pages " />
                            <asp:TemplateField HeaderText="Rate 2013-14">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="txtbox" Width="89px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Rate 2014-15">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" CssClass="txtbox" Width="89px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Rate 2015-16">
                                <ItemTemplate>
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("GRPID_I")%>' />
                                    <asp:TextBox ID="TextBox3" runat="server" CssClass="txtbox" Width="89px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Rate 2016-17">
                                <ItemTemplate>

                                    <asp:TextBox ID="TextBox4" runat="server" CssClass="txtbox" Width="89px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="col-md-12">
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-submit" OnClick="Button1_Click" OnClientClick='javascript:return ValidateAllTextForm();' Text="सुरक्षित करें" />
                </div>
                <div class="col-md-12">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" AllowPaging="True" OnPageIndexChanging="GridView2_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="groupno_v" HeaderText="Name of the Books &amp; Class" />
                            <asp:BoundField DataField="Noofpages" HeaderText="Approx No of Pages " />
                            <asp:BoundField DataField="GroupNO" HeaderText="GroupNO " />

                            <asp:TemplateField HeaderText="Rate 2013-14">
                                <ItemTemplate>

                                    <%#Eval("fy1314rate") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Rate 2014-15">
                                <ItemTemplate>

                                    <%#Eval("fy1415rate") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Rate 2015-16">
                                <ItemTemplate>

                                    <%#Eval("fy1516rate") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Rate 2016-17">
                                <ItemTemplate>

                                    <%#Eval("fy1617rate") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


