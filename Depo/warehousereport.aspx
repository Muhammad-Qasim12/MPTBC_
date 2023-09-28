<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="warehousereport.aspx.cs" Inherits="Depo_warehousereport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span> &#2357;&#2375;&#2351;&#2352;&#2361;&#2366;&#2313;&#2360; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;  </span>
            </h2>
        </div>
        <div style="padding: 0 10px;">
             <asp:Button ID="btnExport" runat="server" CssClass="btn_gry" 
                            Text="Export to Excel" OnClick="btnExport_Click1"  />
                <div id="ExportDiv" runat="server" >
                    <asp:GridView ID="GrdWarehouse" runat="server" AutoGenerateColumns="False" 
                            CssClass="tab" 
                            
                            >
                            <Columns> 
                                     <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                  <asp:BoundField HeaderText="Depo Name" DataField="DepoName_V" />
                                     <asp:BoundField HeaderText="Warehopuse Type" DataField="warehousetype" />
                                     <asp:BoundField DataField="WareHouseOwnerName_V" HeaderText="Warehouse Owner Name " />
                             <asp:BoundField HeaderText=" Warehouse/ Godown Name" DataField="WareHouseName_V" />
                                <asp:BoundField HeaderText=" Warehouse/ Godown Address" 
                                    DataField="WareHouseAddress_V" />
                                <asp:BoundField HeaderText=" Agreement No." DataField="RegistrationNo_V" />
                                <asp:BoundField HeaderText=" Possession Date" DataField="RegistrationDate_D" />
                                     <asp:BoundField HeaderText="Agreement  Period (in month) " DataField="ServicePeriod_V" />
                                <asp:BoundField HeaderText=" Mobile No." DataField="MobileNo_N" />
                                
                                     <asp:BoundField HeaderText="Corpet Area " DataField="CarpateArea_V" />
                                 
                                  <asp:TemplateField HeaderText="Rent Amount">

                                    <ItemTemplate>
                                     <%# Convert.ToInt32(Eval("Amounta"))%>
                                    </ItemTemplate></asp:TemplateField> 
                            
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                                              <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView></div> 
            </div> 
        </div> 
</asp:Content>

