<%@ Page Title="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Tender Information" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VIEW003_TenderParticipent.aspx.cs" Inherits="Vehicle_VIEW003_TenderParticipent" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
      <div class="portlet-header ui-widget-header">&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Tender Information</div>
                     <div class="portlet-content">
                     <div class="table-responsive ">
                      <table width="100%">
                     <tr>
                     <td colspan="2">
                     <asp:Button runat="server" ID="btnAdd" Text="&#2332;&#2379;&#2396;&#2375; / Add" CssClass="btn" OnClick="btnAdd_Click" /> 
                     </td>
                     </tr>

                     <tr>
                     <td colspan="2">
                     <asp:Panel ID="PnlTenderPart" runat="server" GroupingText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2350;&#2375;&#2306; &#2349;&#2366;&#2327; &#2354;&#2375;&#2344;&#2375; &#2357;&#2366;&#2354;&#2375; &#2344;&#2367;&#2357;&#2367;&#2342;&#2366;&#2325;&#2352;&#2381;&#2340;&#2366;  &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Info. of Tender Participator" Width="1200px">
                       
                       
                    

                       
                         <asp:GridView runat="server" ID="grdTenderParticipent" AutoGenerateColumns="False" CssClass="tab hastable">
                     
                     <Columns>
                     <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Sr.No. ">
                     <ItemTemplate>
                     <%# Container.DataItemIndex+1 %>

                     </ItemTemplate>
                     
                    </asp:TemplateField>
                       <asp:TemplateField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;<BR>Name of Tender ">
                     <ItemTemplate>
                     <%# Eval("TenderNo_V")%>
                     </ItemTemplate>
                     </asp:TemplateField> 
                     <asp:TemplateField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2350;&#2375;&#2306; &#2349;&#2366;&#2327; &#2354;&#2375;&#2344;&#2375; &#2357;&#2366;&#2354;&#2368; &#2346;&#2366;&#2352;&#2381;&#2335;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350; / Name of The Party Participate In Tender ">
                     <ItemTemplate>
                     <%# Eval("NameofParty")%>
                     </ItemTemplate>
                     </asp:TemplateField> 
                     
                      <asp:TemplateField HeaderText="&#2346;&#2340;&#2366; / Address ">
                     <ItemTemplate>
                     <%# Eval("Address_Party")%>
                     </ItemTemplate>
                     </asp:TemplateField> 


                     <asp:TemplateField HeaderText="&#2350;&#2379;&#2348;&#2366;&#2311;&#2354; &#2344;&#2306;&#2348;&#2352; / Mobile No. ">
                     <ItemTemplate>
                     <%# Eval("Tel_MobNo")%> 
                     </ItemTemplate>
                     </asp:TemplateField> 


                   
                     


                     <asp:TemplateField HeaderText="&#2344;&#2367;&#2357;&#2367;&#2342;&#2366;&#2325;&#2352;&#2381;&#2340;&#2366; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; <br> Edit Participator Information" >
                     <ItemTemplate>
                     <a href="TenderParticipent.aspx?TDId=<%# new APIProcedure().Encrypt(Eval("TenderID_I").ToString()) %>&Cid=<%#new APIProcedure().Encrypt(Eval("TenderParID_I").ToString()) %>" >&#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; / Edit</a>
                     
                     </ItemTemplate>
                     </asp:TemplateField> 


                      <asp:TemplateField  HeaderText="&#2335;&#2375;&#2325;&#2381;&#2344;&#2367;&#2325;&#2354; &#2325;&#2306;&#2337;&#2368;&#2358;&#2344; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; <br> Edit Technical Condition " >
                     <ItemTemplate>
                     <a href="TenderChecklist.aspx?TDId=<%# new APIProcedure().Encrypt(Eval("TenderID_I").ToString()) %>&Cid=<%# new APIProcedure().Encrypt(Eval("TenderParID_I").ToString())  %>" >&#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; / Edit</a>
                     
                     </ItemTemplate>
                     </asp:TemplateField> 


                      <asp:TemplateField  HeaderText="&#2357;&#2367;&#2340;&#2381;&#2340;&#2368;&#2351; &#2321;&#2347;&#2352; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; <br> Edit Financial Year  " >
                     <ItemTemplate>
                     <a href="TenderFinancial.aspx?TDId=<%# new APIProcedure().Encrypt(Eval("TenderID_I").ToString()) %>&Cid=<%# new APIProcedure().Encrypt(Eval("TenderParID_I").ToString())  %>" >&#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; / Edit</a>
                     
                     </ItemTemplate>
                     </asp:TemplateField> 



                     </Columns>
                              <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                     </asp:GridView>

                         </asp:Panel>
                     </td> 
                     
                     </tr> 
                         
                         </table> 
                      </div> 
                     </div> 
        </div> 
</asp:Content>

