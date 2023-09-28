<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TitleBindingWithPrinterMachine.aspx.cs" Inherits="TitleBindingWithPrinterMachine" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
         <div class="card-header">
                <h2>प्रिंटर मशीन से शीर्षक बाइंडिंग</h2>
            </div>
        <div class="card-body">           
            <div class="row g-3">
                <div class="col-md-12 mt-2">
                    <asp:Panel ID="messDiv" runat="server" CssClass="alert alert-success" Visible="false">
                        <asp:Label runat="server" ID="lblMess" class=""></asp:Label>
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
                        <label>शिक्षा सत्र</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlPrinter" runat="server" AutoPostBack="true" CssClass="form-select" OnSelectedIndexChanged="ddlPrinter_SelectedIndexChanged">
                        </asp:DropDownList>
                        <label>प्रिंटर</label>
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:GridView ID="GrdEval" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False" OnRowDataBound="GrdEval_RowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField runat="server" ID="Machineid" Value='<%# Int32.Parse(Eval("MachineID_I").ToString()) %>'></asp:HiddenField>

                                    <asp:HiddenField runat="server" ID="HndTitleid" Value='<%# Eval("titleid_i") %>'></asp:HiddenField>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="titleenglish_v" HeaderText="शीर्षक" />

                            <asp:TemplateField HeaderText="मशीन">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlYojna" runat="server" Width="300" CssClass="form-select reqirerd">
                                        <asp:ListItem Text="Select" Value="1"></asp:ListItem>
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

