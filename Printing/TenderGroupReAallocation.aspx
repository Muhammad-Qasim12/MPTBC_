<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TenderGroupReAallocation.aspx.cs" Inherits="TenderGroupReAallocation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
            <h2>टेंडर ग्रुप पुनः आवंटन</h2>
        </div>
        <div class="card-body">
            <div class="row g-3">
                <div class="col-md-12">
                    <asp:Panel ID="messDiv" runat="server">
                        <asp:Label runat="server" ID="lblMess" class="notification"></asp:Label>
                    </asp:Panel>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DdlACYear" runat="server" CssClass="form-select">
                            <asp:ListItem>..Select..</asp:ListItem>
                            <asp:ListItem>2012-13</asp:ListItem>
                            <asp:ListItem>2013-14</asp:ListItem>
                            <asp:ListItem>2014-15</asp:ListItem>
                        </asp:DropDownList>
                        <label>शैक्षणिक सत्र</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlPrinter" runat="server" AutoPostBack="true" CssClass="form-select" OnSelectedIndexChanged="ddlPrinter_SelectedIndexChanged">
                        </asp:DropDownList>
                        <label>From Printer</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlTital" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddlTital_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem>--Select--</asp:ListItem>
                        </asp:DropDownList>
                        <label>शीर्षक/ Title</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlToPrinter" runat="server" CssClass="form-select reqirerd" AutoPostBack="True" OnSelectedIndexChanged="ddlToPrinter_SelectedIndexChanged"></asp:DropDownList>
                        <label>To Printer</label>
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:GridView ID="GrdEval" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" OnRowDataBound="GrdEval_RowDataBound" PageSize="20">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this);" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chk" Checked='<%# Eval("allotdate").ToString()=="" ? false  : true %>' />
                                    <asp:HiddenField runat="server" ID="tenreallotid_i" Value='<%# Int32.Parse(Eval("tenreallotid_i").ToString()) %>'></asp:HiddenField>

                                    <asp:HiddenField runat="server" ID="HdnDepoID" Value='<%# Eval("depoid_i") %>'></asp:HiddenField>
                                    <asp:HiddenField runat="server" ID="HndTitleid" Value='<%# Eval("titleid_i") %>'></asp:HiddenField>
                                    <asp:HiddenField runat="server" ID="HndTenderid" Value='<%# Eval("tenderid_i") %>'></asp:HiddenField>
                                    <asp:HiddenField runat="server" ID="HndGrpid_i" Value='<%# Eval("grpid_i") %>'></asp:HiddenField>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="tenderno_v" HeaderText="Tender No" />
                            <asp:BoundField DataField="deponame_v" HeaderText="Depo" />
                            <%--<asp:BoundField DataField="qty" HeaderText="Qty." />--%>

                            <asp:TemplateField HeaderText="No of Books">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtQty" runat="server" Text='<%# Eval("qty") %>' CssClass="txtbox reqirerd"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Rate" ItemStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtRate" Text='<%# Eval("ratequoated_n") %>' runat="server" Width="100px" CssClass="txtbox reqirerd" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDate" runat="server" Text='<%# Eval("allotdate") %>' MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Yojna/Samanya">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlYojna" runat="server" CssClass="txtbox reqirerd">
                                        <asp:ListItem Text="Yojna" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Samanya" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle CssClass="Gvpaging" />
                        <EmptyDataRowStyle CssClass="GvEmptyText" />
                    </asp:GridView>
                </div>
                <div class="col-md-12">
                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-submit" Text="सुरक्षित करे"
                            OnClick="btnSave_Click" Visible="false" />
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        inputList[i].checked = true;
                    }
                    else {
                        inputList[i].checked = false;
                    }
                }
            }
        }
    </script>
</asp:Content>

