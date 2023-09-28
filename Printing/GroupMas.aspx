<%@ Page Title="Bookmark for Group" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GroupMas.aspx.cs" Inherits="Distrubution_GroupMas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="card">
        <div class="card-header">
            <h2>Bookmark for Group </h2>
        </div>
        <div class="card-body">

            <div class="row g-3">
                <div class="col-md-12">
                    <asp:Panel class="alert alert-danger" runat="server" ID="mainDiv" Style="display: none;">
                        <asp:Label ID="lblmsg" class="notification" runat="server"></asp:Label>
                    </asp:Panel>
                    <asp:HiddenField ID="HdnGroupId" runat="server" Value="0" />
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DdlACYear" runat="server" AppendDataBoundItems="True"
                            AutoPostBack="True" CssClass="form-select"
                            OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                        </asp:DropDownList>
                        <label>Academic Year</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtGroupName" runat="server" CssClass="form-control reqirerd"
                            MaxLength="10"></asp:TextBox>
                        <label>Bookmark</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:ListBox ID="chkDepots" runat="server" SelectionMode="multiple" class="multi-select form-control">
                            <asp:ListItem>Select</asp:ListItem>
                        </asp:ListBox>
                        <label>Depot Name</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" CssClass="form-control reqirerd"></asp:TextBox>
                        <label>Bookmark Details</label>
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:Button runat="server" ID="btnSaveGroup" Text="Save" CssClass="btn btn-submit" OnClientClick="return validateform();" OnClick="btnSaveGroup_Click" />
                </div>
                <div class="col-md-12">
                    <div class="table-responsive">
                        <asp:GridView runat="server" ID="grdGroup" AutoGenerateColumns="false" OnRowUpdating="grdGroup_RowUpdating"
                            CssClass="table table-bordered table-hover" DataKeyNames="GroupId" OnRowDeleting="grdGroup_RowDeleting">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1  %>
                                        <asp:HiddenField runat="server" ID="HdnGroupId" Value='<%# Eval("GroupId") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Academic Year">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblGroupName1" Text='<%# Eval("ACYear") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bookmark">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblGroupName" Text='<%# Eval("GroupName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Depot Name">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblDepotIds" Text='<%# Eval("DepoNames") %>'></asp:Label>
                                        <asp:HiddenField runat="server" ID="HdnDepotIds" Value='<%# Eval("DepotIds") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bookmark Details ">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblDescription" Text='<%# Eval("Description") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit/Delete">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="LinkEdit" CommandName="Update" CssClass="btn btn-sm btn-primary"><i class="bi bi-pencil"></i></asp:LinkButton>
                                        <asp:LinkButton ID="Delete" runat="server" CausesValidation="False" CommandName="Delete" class="btn btn-sm btn-danger" Text='<i class="bi bi-trash"></i>' OnClientClick="return confirm('The item will be deleted. Are you sure want to continue?');"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <script type="text/javascript">
        function validateform() {
            var msg = "";
            if (document.getElementById('<%=DdlACYear.ClientID%>').selectedIndex == 0) {
                msg = msg + "शिक्षा सत्र चुनें  \n";
            }
            if (document.getElementById('<%=txtGroupName.ClientID%>').value.trim() == "") {
                msg += "बुक मार्क भरें \n";
            }
            <%--if (document.getElementById('<%=chkDepots.ClientID%>').length > 0 ) {
                msg = msg + "डिपो का नाम चुनें\n";
            }--%>
            if (msg != "") {
                alert(msg);
                return false;
            }
            else {

                if (confirm("Do you want to Save Details ?")) {
                    return true;
                }
                else {
                    return false;
                }
            }

        }

    </script>
</asp:Content>


