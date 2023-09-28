<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TenderFinancial.aspx.cs" Inherits="Depo_Tender_TenderFinancial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <div class="portlet-header ui-widget-header">टेक्निकल कंडीशन&nbsp; / Technical Condition </div>
        <div class="portlet-content">
            <div class="table-responsive ">
                     
                
                <table width="100%"><tr><td>

                    
     <asp:GridView ID="grdblock" runat="server" 
                                        AutoGenerateColumns="False"  CssClass="tab" 
                                         >
                                <Columns>
                               <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2332;&#2367;&#2354;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; ">
                                        <ItemTemplate>
                                            <asp:Literal ID="ltrLeader" runat="server" OnDataBinding="ltrLeader_DataBinding"></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2348;&#2381;&#2354;&#2366;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Block Name">
                                <ItemTemplate>
                                <asp:HiddenField ID="hdnHeadId" runat="server" Value='<%#Eval("DistrictTrno_I") %>' />
                                 <asp:HiddenField ID="hdnblockTrn" runat="server" Value='<%#Eval("BlockTrno_I") %>' />
                                
                                <asp:Label ID="lblheadname" Text='<%#Eval("BlockNameHindi_V") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="&#2347;&#2369;&#2354; &#2335;&#2381;&#2352;&#2325; (9 &#2335;&#2344;) &nbsp;&#2352;&#2375;&#2335; / Full Truck Rate">
                                <ItemTemplate>
                                <asp:TextBox ID="txtEstimateAmount" Text='<%#Eval("FullTruckRate_N") %>'  onkeypress='javascript:tbx_fnNumeric(event, this);'  runat="server"></asp:TextBox>
                                 </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" &#2361;&#2366;&#2347; &#2335;&#2381;&#2352;&#2325; (4.5 &#2335;&#2344;) &#2352;&#2375;&#2335; / Half Truck Rate">
                                <ItemTemplate>
                                 <asp:TextBox ID="txtAvailableAmount" Text='<%#Eval("HalfTruckRate_N") %>' onkeypress='javascript:tbx_fnNumeric(event, this);'   runat="server"></asp:TextBox>
                                 </ItemTemplate>
                                 </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367;&#2348;&#2306;&#2337;&#2354; &#2352;&#2375;&#2335; / Per Bundle Rate">
                                <ItemTemplate>
                                  <asp:TextBox ID="txtrequestAmount" Text='<%#Eval("RatePerBundle_N") %>' onkeypress='javascript:tbx_fnNumeric(event, this);' runat="server"></asp:TextBox>
                                 </ItemTemplate>
                                 </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                                </asp:GridView></td></tr><tr><td>
                                  <asp:GridView ID="GrdTranportRate" runat="server" 
                                        AutoGenerateColumns="False"  CssClass="tab" 
                                         >
                                <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; / Depot Name">
                                <ItemTemplate>
                               
                                 <asp:HiddenField ID="hdnDepoTrn" runat="server" Value='<%#Eval("DepoTrno_I") %>' />

                                <asp:Label ID="lblheadname0" Text='<%#Eval("DepoName_V") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="&#2347;&#2369;&#2354; &#2335;&#2381;&#2352;&#2325; (9 &#2335;&#2344;) &nbsp;&#2352;&#2375;&#2335;  (&#2352;&#2370;&#2346;&#2351;&#2375; &#2350;&#2376;) / Full Truck Rate">
                                <ItemTemplate>
                                <asp:TextBox ID="txtEstimateAmount0" Text='<%#Eval("FullTruckRate_N") %>' MaxLength="6"  onkeypress='javascript:tbx_fnNumeric(event, this);'  runat="server"></asp:TextBox>
                                 </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" &#2361;&#2366;&#2347; &#2335;&#2381;&#2352;&#2325; (4.5&#2335;&#2344;) &#2352;&#2375;&#2335; (&#2352;&#2370;&#2346;&#2351;&#2375; &#2350;&#2376;) / Half Truck Rate">
                                <ItemTemplate>
                                 <asp:TextBox ID="txtAvailableAmount0" Text='<%#Eval("HalfTruckRate_N") %>' MaxLength="6" onkeypress='javascript:tbx_fnNumeric(event, this);'   runat="server"></asp:TextBox>
                                 </ItemTemplate>
                                 </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367;&#2348;&#2306;&#2337;&#2354; &#2352;&#2375;&#2335; (&#2352;&#2370;&#2346;&#2351;&#2375; &#2350;&#2376;) / Per Bundle Rate">
                                <ItemTemplate>
                                  <asp:TextBox ID="txtrequestAmount0" Text='<%#Eval("RatePerBundle_N") %>' MaxLength="6" onkeypress='javascript:tbx_fnNumeric(event, this);' runat="server"></asp:TextBox>
                                 </ItemTemplate>
                                 </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                                </asp:GridView>
                                  </td></tr><tr><td>
                   <asp:Button ID="btnSaveCheckList" runat="server" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save" CssClass="btn" OnClick="btnSaveCheckList_Click" />

                    
                        </td></tr></table>

                    
                        <br />

                    
            </div> </div> </div> 
</asp:Content>

