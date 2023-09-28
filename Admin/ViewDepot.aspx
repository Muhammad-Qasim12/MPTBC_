<%@ Page Title="Depot Profile Details" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ViewDepot.aspx.cs" Inherits="Admin_ViewDepot" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
            <div class="row">
                <div class="col-md-6">
                    <h2>Depot Profile Details</h2>
                </div>
                <div class="col-md-6 text-right">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn-add" Text="Add New Data" OnClick="btnSave_Click" />
                </div>
            </div>
        </div>
        <div class="card-body">
            <div class="row g-3">
                <div class="col-md-12">
                    <asp:GridView ID="GrdDepot" runat="server" AutoGenerateColumns="False"
                            CssClass="table table-bordered" DataKeyNames="DepoTrno_I" PageSize="30"
                            OnRowDeleting="GrdDepot_RowDeleting" AllowPaging="True"
                            OnPageIndexChanging="GrdDepot_PageIndexChanging">
                            <Columns>
                                <asp:BoundField HeaderText="Depot Name" DataField="DepoName_V" />
                                <asp:BoundField HeaderText="Telephone No." DataField="TeleNo_V" />
                                <asp:BoundField HeaderText="Mobile No." DataField="MobNo_V" />
                                <asp:BoundField HeaderText="Depot Address" DataField="DepoAddress_V" />
                                <asp:BoundField HeaderText="District" DataField="District_name_Hindi_v" />
                                <asp:BoundField HeaderText="फैक्स नंबर" DataField="FaxNo_V" Visible="false" />
                                <asp:BoundField HeaderText="Email Id" DataField="Emailid_V" />
                                <asp:BoundField HeaderText="Depot Manager Name" DataField="DepoManager_Name_V" />
                                <asp:TemplateField HeaderText="Satellite Depot">
                                    <ItemTemplate>
                                        <asp:CheckBox Enabled="false" ID="gvchkStateliteDepo"
                                            Checked='<%# Convert.ToBoolean(Eval("IsSatellite_I")) %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Main Depot Name" DataField="ParentDepo" />
                                <asp:TemplateField HeaderText="Edit/Update">
                                    <ItemTemplate>
                                        <a href="DepotMaster.aspx?ID=<%#Eval("DepoTrno_I") %>" CssClass="btn btn-sm btn-primary"><i class="bi bi-pencil"></i></a>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="btnDelete" Visible="false" CssClass="btn" runat="server" CommandName="Delete" Text="Delete"
                                            OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" />
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
</asp:Content>

