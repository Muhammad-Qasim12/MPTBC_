<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GetTenderDetails.aspx.cs" Inherits="Depo_Tender_GetTenderDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
    <div class="portlet-header ui-widget-header">&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Tender Details</div>
              
    <div class="portlet-content">
    <div class="table-responsive">
    <asp:Panel ID="messDiv" runat="server" >
    <asp:Label runat="server" ID="lblMess" class="notification" ></asp:Label>
    </asp:Panel> 

   <div>
     <table width="100%">
     <tr>
     <td style="width:30%;">&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
     <td>
         <asp:DropDownList ID="ddlTenderID_I" runat="server" OnSelectedIndexChanged="ddlTenderID_I_SelectedIndexChanged" Width="400px">
         </asp:DropDownList>
&nbsp;<asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="&#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2342;&#2375;&#2326;&#2375;" />
    
     </td>
     </tr>
     <tr>
     <td colspan="2">

                    
     <asp:GridView ID="grdblock" runat="server" 
                                        AutoGenerateColumns="False"  CssClass="tab" 
                                         >
                                <Columns>
                               <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                      <asp:TemplateField HeaderText="L1 &#2330;&#2369;&#2344;&#2375; ">
                                                 <ItemTemplate>
                                                     <asp:CheckBox ID="CheckBox1" runat="server"  Checked='<%# Convert.ToBoolean(Eval("PartyID")) %>' />
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
                                <asp:Label ID="lblheadname" Text='<%#Eval("NameofParty") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="&#2347;&#2369;&#2354; &#2335;&#2381;&#2352;&#2325; (9 &#2335;&#2344;) &nbsp;&#2352;&#2375;&#2335; / Full Truck Rate">
                                <ItemTemplate>
                                <asp:Label ID="txtEstimateAmount" Text='<%#Eval("FullTruck") %>'  onkeypress='javascript:tbx_fnNumeric(event, this);'  runat="server"></asp:Label>
                                 </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" &#2361;&#2366;&#2347; &#2335;&#2381;&#2352;&#2325; (4.5 &#2335;&#2344;) &#2352;&#2375;&#2335; / Half Truck Rate">
                                <ItemTemplate>
                                 <asp:Label ID="txtAvailableAmount" Text='<%#Eval("HalftTruck") %>' onkeypress='javascript:tbx_fnNumeric(event, this);'   runat="server"></asp:Label>
                                 </ItemTemplate>
                                 </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367;&#2348;&#2306;&#2337;&#2354; &#2352;&#2375;&#2335; / Per Bundle Rate">
                                <ItemTemplate>
                                  <asp:Label ID="txtrequestAmount" Text='<%#Eval("PerBundle") %>' onkeypress='javascript:tbx_fnNumeric(event, this);' runat="server"></asp:Label>
                                 </ItemTemplate>
                                 </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                                </asp:GridView> </td>
     </tr>
     <tr>
     <td colspan="2">

                    
         <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; " Enabled="False" />
    
         </td>
     </tr></table> </div> 
</asp:Content>

