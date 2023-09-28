<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InterDepoDemand.aspx.cs" Inherits="Distribution_InterDepoDemand" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <div class="card">
                <div class="card-body">
                    <div class="card-header">
                        <h2>डिपो प्रबंधक से मध्यावधि पुस्तकों की मांग</h2>
                    </div>
                    <div class="row g-3">
                        <div class="col-md-12 mb-1 mt-1">
                            <asp:Panel class="alert alert-info" runat="server" ID="mainDiv" Style="display: none;">
                                <asp:Label ID="lblmsg" class="notification" runat="server">
                                </asp:Label>
                            </asp:Panel>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:DropDownList ID="DdlACYear" CssClass="form-select" runat="server">
                                </asp:DropDownList>
                                <label>शिक्षा सत्र </label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:TextBox ID="txtDate" runat="server" type="date" CssClass="form-control reqirerd" ></asp:TextBox>
                                <label id="Label1" runat="server">दिनांक</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:TextBox ID="txtOrderNo" runat="server" CssClass="form-control reqirerd" MaxLength="15"></asp:TextBox>
                                <label>आर्डर नंबर </label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:RadioButtonList ID="rdBookType" runat="server" CssClass="form-control reqirerd"
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem Value="1">सामान्य</asp:ListItem>
                                    <asp:ListItem Value="2" Selected="True">योजना</asp:ListItem>
                                </asp:RadioButtonList>
                                <label>बुक का प्रकार</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:DropDownList ID="ddlMedium" runat="server" CssClass="form-select reqirerd">
                                </asp:DropDownList>
                                <label>माध्यम</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:DropDownList ID="ddlDepo" runat="server" CssClass="form-select reqirerd" AutoPostBack="True" OnSelectedIndexChanged="ddlDepo_SelectedIndexChanged">
                                </asp:DropDownList>
                                <label>डिपो का नाम</label>
                            </div>
                        </div>
                        <div class="col-md-4" style="display: none">
                            <div class="form-floating">
                                <asp:RadioButtonList ID="rdDemandType" runat="server"
                                    CssClass="txtbox reqirerd" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="2" Selected="True">&#2350;&#2343;&#2381;&#2351;&#2366;&#2357;&#2343;&#2367; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2350;&#2377;&#2327;</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:DropDownList ID="CheckBoxList1" runat="server" multiple="multiple" class="multi-select form-control"></asp:DropDownList>
                                <label>कक्षा </label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <%--<asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged" RepeatColumns="6" RepeatDirection="Horizontal">
                                </asp:CheckBoxList>--%>
                            <div class="form-floating">
                                
                                <asp:DropDownList ID="DDLClass" runat="server" AutoPostBack="True" CssClass="form-select" OnSelectedIndexChanged="DDLClass_SelectedIndexChanged">
                                    <asp:ListItem Value="0">Select..</asp:ListItem>
                                    <asp:ListItem Text="1-8" Value="1-8"></asp:ListItem>
                                    <asp:ListItem Text="9-12" Value="9-12"></asp:ListItem>
                                </asp:DropDownList>
                                <label>कक्षा </label>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <asp:GridView ID="grdbookdata" runat="server" AutoGenerateColumns="False"
                                CssClass="table table-bordered" OnSelectedIndexChanged="grdbookdata_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                            <asp:HiddenField ID="TitalID"
                                                runat="server" Value='<%# Eval("TitalID") %>' />
                                            <asp:HiddenField ID="hdnclassID"
                                                runat="server" Value='<%# Eval("classID") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="&#2357;&#2367;&#2359;&#2351; / Subject " DataField="BookName" />
                                    <asp:BoundField HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366; / Class " DataField="Classname" />
                                    <asp:TemplateField HeaderText="&#2310;&#2357;&#2358;&#2381;&#2351;&#2325;&#2340;&#2366; / Reqierment ">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtDemand" MaxLength="6" runat="server"
                                                onkeyup='javascript:tbx_fnSignedNumericCheck(this);' CssClass="txtbox reqirerd"
                                                Text='<%# Eval("Request") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                            </asp:GridView>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                        </div>
                        <div class="col-md-12">
                            <asp:Button ID="Button1" runat="server" CssClass="btn btn-success" Text="&#2332;&#2379;&#2396;&#2375; / Add "
                                OnClick="Button1_Click"
                                OnClientClick='javascript:return ValidateAllTextForm();' />
                            <asp:HiddenField ID="HiddenField4" runat="server" />
                        </div>
                        <div class="col-md-12">
                            <asp:GridView ID="grdbookdata0" runat="server" AutoGenerateColumns="False"
                                CssClass="table table-bordered" OnSelectedIndexChanged="grdbookdata0_SelectedIndexChanged"
                                DataKeyNames="DemandDetailsID_I" OnRowDeleting="grdbookdata0_RowDeleting" OnRowDataBound="grdbookdata0_RowDataBound" ShowFooter="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325 ; / No.">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>

                                            <asp:HiddenField ID="HID" runat="server"
                                                Value='<%# Eval("DemandDetailsID_I") %>' />

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="&#2357;&#2367;&#2359;&#2351; / Subject" DataField="TitleHindi_V" />
                                    <asp:BoundField HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366; / Class" DataField="Classdet_V" />
                                    <asp:TemplateField HeaderText="&#2310;&#2357;&#2358;&#2381;&#2351;&#2325;&#2340;&#2366; / Reqierment ">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("RequesrdQt_I")%>'></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2350;&#2366;&#2306;&#2327; / Demand">
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" Text='<%#Eval("Demand_I")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <asp:CommandField ShowDeleteButton="True" />
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                            </asp:GridView>
                        </div>
                        <div class="col-md-12">
                            <asp:Button ID="Button12" runat="server" CssClass="btn btn-primary" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save  "
                                OnClick="Button12_Click"
                                Visible="False" />
                            <asp:HiddenField ID="HiddenField2" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

