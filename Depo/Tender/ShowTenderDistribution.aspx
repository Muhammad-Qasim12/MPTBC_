<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShowTenderDistribution.aspx.cs" Inherits="Depo_Tender_ShowTenderDistribution" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="box table-responsive">
        <div class="portlet-header ui-widget-header">
            &#2346;&#2352;&#2367;&#2357;&#2361;&#2344; &#2325;&#2368; &#2342;&#2352;&#2379; &#2325;&#2366; &#2344;&#2367;&#2352;&#2381;&#2343;&#2366;&#2352;&#2339; </div>
        <div class="portlet-content">
            <div class="table-responsive">
                <asp:Panel ID="messDiv" runat="server">
                    <asp:Label ID="lblMess" runat="server" class="notification"></asp:Label>
                </asp:Panel>
                <div>
                    <table width="100%">
                        <tr>
                            <td style="width:30%;">&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                            <td style="width:30%;">
                                <asp:DropDownList ID="ddlDepo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDepo_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="width:30%;">&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                            <td>
                                <asp:DropDownList ID="ddlTender" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTender_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:HiddenField ID="HiddenField4" runat="server" />
                                <asp:HiddenField ID="HiddenField5" runat="server" />
                                <asp:GridView ID="grdblock" runat="server" AutoGenerateColumns="False" CssClass="tab">
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
                                        <asp:TemplateField HeaderText="&#2346;&#2366;&#2352;&#2381;&#2335;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350; / Party Name">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdDistrict" runat="server" Value='<%#Eval("DistinctID") %>' />
                                                <asp:HiddenField ID="HDTenderParID" runat="server" Value='<%#Eval("TenderParID_I") %>' />
                                                 <asp:HiddenField ID="HiddenField2" runat="server" Value='<%#Eval("TenderParID_I") %>' />
                                                <asp:Label ID="lblheadname" runat="server" Text='<%#Eval("NameofParty") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2347;&#2369;&#2354; &#2335;&#2381;&#2352;&#2325; (9 &#2335;&#2344;) &nbsp;&#2352;&#2375;&#2335; / Full Truck Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="txtEstimateAmount" runat="server" onkeypress="javascript:tbx_fnNumeric(event, this);" Text='<%#Eval("FullTruck") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText=" &#2361;&#2366;&#2347; &#2335;&#2381;&#2352;&#2325; (4.5 &#2335;&#2344;) &#2352;&#2375;&#2335; / Half Truck Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="txtAvailableAmount" runat="server" onkeypress="javascript:tbx_fnNumeric(event, this);" Text='<%#Eval("HalftTruck") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367;&#2348;&#2306;&#2337;&#2354; &#2352;&#2375;&#2335; / Per Bundle Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="txtrequestAmount" runat="server" onkeypress="javascript:tbx_fnNumeric(event, this);" Text='<%#Eval("PerBundle") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2342;&#2375;&#2326;&#2375;">
                                            <ItemTemplate>
                                              
                                                <asp:Button ID="Button2" runat="server" Text="View Details" OnClick="Button2_Click" Visible='<%# Eval("Status").ToString()=="1" ? false  : true %>'  CssClass="btn" />
                                              <%-- <a href="ViewDetails.aspx?DistrictID='<%#Eval("DistinctID") %>'&ParticipateID='<%#Eval("TenderParID_I")%>'">View Details</a>--%>
                                            
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle CssClass="Gvpaging" />
                                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                                </asp:GridView>
                            </td>
                        </tr>
                        </table>
                </div>
            </div>
        </div>
    </div>
           <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
            </div>
            <div id="Messages" style="display: none;" class="popupnew1" runat="server">
         
                    <table width="100%">
                        <tr>
                            <td>

                    
     <asp:GridView ID="GridView1" runat="server" 
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
                                <asp:HiddenField ID="hdnHeadId" runat="server" Value='<%#Eval("DistinctID") %>' />
                                 <asp:HiddenField ID="hdnblockTrn" runat="server" Value='<%#Eval("BlockID") %>' />
                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("TenderParID_I") %>' />
                                     <asp:HiddenField ID="HiddenField3" runat="server" Value='<%#Eval("TenderID_I") %>' />
                                <asp:Label ID="lblheadname" Text='<%#Eval("BlockNameHindi_V") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField>
                                    <asp:BoundField HeaderText="&#2347;&#2369;&#2354; &#2335;&#2381;&#2352;&#2325; (9 &#2335;&#2344;) &nbsp;&#2352;&#2375;&#2335; / Full Truck Rate" DataField="FullTruckRate_N" />
                                 <asp:TemplateField HeaderText="&#2347;&#2369;&#2354; &#2335;&#2381;&#2352;&#2325; (9 &#2335;&#2344;) &nbsp;&#2352;&#2375;&#2335; / Full Truck Rate">
                                <ItemTemplate>
                                <asp:TextBox ID="txtEstimateAmount" Text='<%#Eval("FullTruckRate_N") %>'  onkeypress='javascript:tbx_fnNumeric(event, this);' Width="100px"  runat="server"></asp:TextBox>
                                 </ItemTemplate>
                                </asp:TemplateField>
                                    <asp:BoundField HeaderText=" &#2361;&#2366;&#2347; &#2335;&#2381;&#2352;&#2325; (4.5 &#2335;&#2344;) &#2352;&#2375;&#2335; / Half Truck Rate" DataField="HalfTruckRate_N" />
                                <asp:TemplateField HeaderText=" &#2361;&#2366;&#2347; &#2335;&#2381;&#2352;&#2325; (4.5 &#2335;&#2344;) &#2352;&#2375;&#2335; / Half Truck Rate">
                                <ItemTemplate>
                                 <asp:TextBox ID="txtAvailableAmount" Text='<%#Eval("HalfTruckRate_N") %>' onkeypress='javascript:tbx_fnNumeric(event, this);' Width="100px"  runat="server"></asp:TextBox>
                                 </ItemTemplate>
                                 </asp:TemplateField>
                                    <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367;&#2348;&#2306;&#2337;&#2354; &#2352;&#2375;&#2335; / Per Bundle Rate" DataField="RatePerBundle_N" />
                                <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367;&#2348;&#2306;&#2337;&#2354; &#2352;&#2375;&#2335; / Per Bundle Rate">
                                <ItemTemplate>
                                  <asp:TextBox ID="txtrequestAmount" Text='<%#Eval("RatePerBundle_N") %>' onkeypress='javascript:tbx_fnNumeric(event, this);' Width="100px" runat="server"></asp:TextBox>
                                 </ItemTemplate>
                                 </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr><td>
                            <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; " />
                             <asp:Button ID="Button3" runat="server" CssClass="btn" OnClick="Button3_Click" Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375;&#2306; " />
                            </td></tr>
                        </table>
                </div>
           
</asp:Content>

