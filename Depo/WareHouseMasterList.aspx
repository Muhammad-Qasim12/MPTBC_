<%@ Page Title="WareHouse List" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="WareHouseMasterList.aspx.cs" Inherits="Depo_WareHouseMasterList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
            <div class="row">
                <div class="col-md-6">
                    <h2>Ware House List</h2>
                </div>
                <div class="col-md-6 text-right">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn-add" Text="Add New WareHouse" onclick="btnSave_Click" />
                </div>
            </div>
        </div>
        <div class="card-body">
            <div class="row g-3">
                <div class="col-md-12">
                    <asp:GridView ID="GrdWarehouse" runat="server" AutoGenerateColumns="False"
                            CssClass="table table-bordered table-hover" DataKeyNames="WareHouseID_I"
                            onrowdeleting="GrdWarehouse_RowDeleting" AllowPaging="True"
                            onpageindexchanging="GrdWarehouse_PageIndexChanging"
                            onrowcommand="GrdWarehouse_RowCommand">
                            <columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <itemtemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Ware House Type" DataField="warehousetype" />
                                <asp:BoundField HeaderText="Ware House Name" DataField="WareHouseName_V" />
                                <asp:BoundField HeaderText="Address" DataField="WareHouseAddress_V" />
                                <asp:BoundField HeaderText="Agreement No." DataField="RegistrationNo_V" />
                                <asp:BoundField HeaderText="Possession Date " DataField="RegistrationDate_D" />
                                <asp:BoundField HeaderText="Agreement Period (in month)" DataField="ServicePeriod_V" />
                                <asp:BoundField HeaderText="Mobile No." DataField="MobileNo_N" />

                                <asp:BoundField HeaderText="Carpet Area" DataField="CarpateArea_V" />

                                <asp:TemplateField HeaderText="Rent Amount">

                                    <itemtemplate>
                                        <%#Convert.ToInt32(Eval("RentAmount_N")) * Convert.ToInt32(Eval("CarpateArea_V"))%>
                                    </itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Core ID" DataField="AccHrID" />
                                <asp:TemplateField HeaderText="View">
                                    <itemtemplate>
                                        <a href='<%#Eval("Agreement_V") %>' target="_blank">View Agreement</a>
                                    </itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Warehouse map">
                                    <itemtemplate>
                                        <a href='<%#Eval("WareHouseMap_V") %>' target="_blank">View Warehouse Map</a>
                                    </itemtemplate>
                                </asp:TemplateField>
                               <asp:TemplateField HeaderText="Edit/Update">
                                    <itemtemplate>
                                        <a href="#" ID="ImgbtnDelete" runat="server" CommandArgument='<%# Eval("WareHouseID_I") %>'
                                            CommandName="eDelete" class="btn btn-sm btn-danger" OnClick="return confirm('Are you sure you want to delete this record?');"><i class="bi bi-trash"></i></a>
                                    
                                        <a href="WarehouseMaster.aspx?ID=<%# api.Encrypt(Eval("WareHouseID_I").ToString ()) %>" class="btn btn-sm btn-primary" ><i class="bi bi-pencil"></i></a>
                                    </itemtemplate>
                                   <ItemStyle HorizontalAlign="Center" Width="100px" />
                                </asp:TemplateField>

                            </columns>
                            <pagerstyle cssclass="Gvpaging" />
                            <emptydatarowstyle cssclass="GvEmptyText" />
                        </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

