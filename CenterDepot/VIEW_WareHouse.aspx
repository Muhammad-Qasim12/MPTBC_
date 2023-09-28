<%@ Page Title="वेयरहाउस मास्टर" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VIEW_WareHouse.aspx.cs" Inherits="Depo_View001_WarehouseMaster" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="box">
        <div class="card-header">
            <h2>
                <span>&#2357;&#2375;&#2351;&#2352;&#2361;&#2366;&#2313;&#2360; &#2350;&#2366;&#2360;&#2381;&#2335;&#2352;</span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr>
                    <td style="text-align: left">
                        <a class="btn" href="CDWarehouseMaster.aspx">                                   
                                            &#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375;
                                                                                </a>                           
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:GridView ID="GrdWarehouse" runat="server" AutoGenerateColumns="False" 
                            CssClass="tab" DataKeyNames="WareHouseID_I" 
                            
                            onrowdeleting="GrdWarehouse_RowDeleting" AllowPaging="True" 
                            onpageindexchanging="GrdWarehouse_PageIndexChanging" 
                            onrowcommand="GrdWarehouse_RowCommand">
                            <Columns> 
                             <asp:BoundField HeaderText="&#2357;&#2375;&#2351;&#2352;&#2361;&#2366;&#2313;&#2360;/ &#2327;&#2379;&#2342;&#2366;&#2350; &#2325;&#2366; &#2344;&#2366;&#2350;" DataField="WareHouseName_V" />
                                <asp:BoundField HeaderText="&#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;" DataField="RegistrationNo_V" />
                                <asp:BoundField HeaderText="&#2310;&#2343;&#2367;&#2346;&#2340;&#2381;&#2351; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " DataField="RegistrationDate_D" />
                                <asp:BoundField HeaderText="&#2357;&#2375;&#2351;&#2352;&#2361;&#2366;&#2313;&#2360;/ &#2327;&#2379;&#2342;&#2366;&#2350; &#2325;&#2366; &#2346;&#2340;&#2366; " 
                                    DataField="WareHouseAddress_V" />
                                <asp:BoundField HeaderText="&#2346;&#2376;&#2344; &#2344;&#2350;&#2381;&#2348;&#2352;" DataField="PanNo_V" />
                                <asp:BoundField HeaderText="&#2312; &#2350;&#2375;&#2354; &#2310;&#2312;.&#2337;&#2368;." DataField="EmailID_V" />
                                <asp:BoundField HeaderText="&#2350;&#2379;&#2348;&#2366;&#2311;&#2354; &#2344;&#2306;&#2348;&#2352;" DataField="MobileNo_N" />
                                
                                <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;">
                                    <ItemTemplate>
                                        <a href="CDWarehouseMaster.aspx?ID=<%#Eval("WareHouseID_I") %>">&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                              <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="ImgbtnDelete" runat="server" CommandArgument='<%# Eval("WareHouseID_I") %>'
                                                    CommandName="eDelete" OnClientClick="return confirm('Are you sure to delete ?');" ></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        
    </div>
</asp:Content>

