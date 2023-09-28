<%@ Page Title="&#2350;.&#2346;&#2381;&#2352; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; / M.P. TBC " Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VIEW_DPT008.aspx.cs" Inherits="Depo_VIEW_DPT008" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span> &#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; &#2323;&#2346;&#2344;&#2367;&#2306;&#2327; &#2360;&#2381;&#2335;&#2377;&#2325; / Others Text Product Opening Stock</span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr>
                    <td style="text-align: left">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="&#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375; / New Data"   
                            onclick="btnSave_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:GridView ID="GrdOtherStock" runat="server" AutoGenerateColumns="False" 
                            CssClass="tab" DataKeyNames="OtherStockID_I" 
                            
                            onrowdeleting="GrdOtherStock_RowDeleting" AllowPaging="True" 
                            onpageindexchanging="GrdOtherStock_PageIndexChanging" 
                            >
                            <Columns> 
                             <asp:BoundField HeaderText="&#2327;&#2379;&#2342;&#2366;&#2350; &#2325;&#2366; &#2344;&#2366;&#2350;  / Godown Name" DataField="WareHouseName_V" />
                             <asp:BoundField HeaderText="&#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350; / Other Reading material Name" DataField="SubTitleHindi" />
                                <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2306;&#2337;&#2354; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / Per Bundle No." DataField="PerBandalNo_I" /> 
                                 <asp:BoundField HeaderText="&#2325;&#2369;&#2354; &#2348;&#2306;&#2337;&#2354;&#2379; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No. Of Total Bundle" DataField="TotalBandal_I" /> 
                                 <asp:BoundField HeaderText="&#2354;&#2370;&#2332; &#2348;&#2306;&#2337;&#2354;&#2379; &#2350;&#2375;&#2306; &#2309;&#2344;&#2381;&#2351;  &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No. Loose Bundle Reading Material" DataField="TotalNo_I" /> 
                                 <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No. Total Books">
                                    <ItemTemplate>
                                     <%#Convert.ToInt32(Eval("PerBandalNo_I")) * Convert.ToInt32(Eval("TotalBandal_I")) + Convert.ToInt32(Eval("TotalNo_I"))%>
                                    </ItemTemplate></asp:TemplateField>                                 
                                <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; / Edit ">
                                    <ItemTemplate>
                                        <a href="DPT008_OtherStockDetails.aspx?ID=<%# api.Encrypt(Eval("OtherStockID_I").ToString ())%>">&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; / Edit</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:CommandField ShowDeleteButton="True" HeaderText="&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375; / Remove" />
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                                              <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        
    </div>
</asp:Content>

