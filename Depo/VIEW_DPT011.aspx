<%@ Page Title="म.प्र पाठ्यपुस्तक निगम / M.P. TBC " Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VIEW_DPT011.aspx.cs" Inherits="Depo_VIEW_DPT011" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>

                <span>डिपो प्रबंधक से मध्यावधि पुस्तकों की मांग / Demands Of Intermediate Books To Depot</span></h2>

        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr>
                    <td style="text-align: left">

                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="नया डाटा डाले /  New Data"   
                            onclick="btnSave_Click" Width="220px" />

                    </td>
                </tr>
                <tr>
                    <td style="text-align: left">

                                    <asp:GridView ID="grdbookdata1" runat="server" AutoGenerateColumns="False" 
                                        CssClass="tab" 
                                         AllowPaging="True" PageSize="50" 
                                        onpageindexchanging="grdbookdata0_PageIndexChanging">
                                        <Columns>
                                             <asp:TemplateField HeaderText="क्रमांक / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                                                                           
                                                                                                                                                              
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                           

                                             <asp:BoundField HeaderText="दिनांक / Date" DataFormatString="{0: dd-MM-yyyy}" DataField="DemandDate_D" />
                                             <asp:TemplateField HeaderText="आर्डर संख्या / Order No ">
                                                 <ItemTemplate>
                                                    <asp:LinkButton OnClick="lnkClick" runat="server"  CommandArgument='<%#Eval("OrderNo")%>'  Text='<%#Eval("OrderNo")%>'></asp:LinkButton>
                                                     </ItemTemplate>

                                             </asp:TemplateField> 
                                             
                                             <asp:BoundField HeaderText="मांग / Demand" DataField="DemandType_I" />
                                             <asp:BoundField HeaderText="पुस्तक प्रकार / Book Type" DataField="BookType_I" />
                                             <asp:TemplateField HeaderText="मांग / Demand">
                                                 <ItemTemplate>
                                                     <asp:Label ID="Label5" Text='<%#Eval("Demand_I")%>' runat="server"></asp:Label>
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                        </Columns>
                                                                    <PagerStyle CssClass="Gvpaging" />
                                              <EmptyDataRowStyle CssClass="GvEmptyText" />
                                    </asp:GridView>
   
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
   
                                    
   
                    </td>
                </tr>
            </table>
        </div>
        
    </div>
      <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server" >
            </div>
            <div id="Messages" style="display: none;" class="popupnew1" runat="server" >
                <asp:Button ID="Button1" runat="server" Text="Close" CssClass="btn" onclick="btnSave_Click1" />
                <asp:GridView ID="grdbookdata0" runat="server" AutoGenerateColumns="False" 
                                        CssClass="tab" 
                                        DataKeyNames="DemandDetailsID_I"
                                        >
                                        <Columns>
                                             <asp:TemplateField HeaderText="क्रमांक / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                                                                           
                                                                                                                                                              
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                           

                                             <asp:BoundField HeaderText="दिनांक / Date" DataField="DemandDate_D" />
                                             <asp:BoundField HeaderText=" आर्डर संख्या / Order No " DataField="OrderNo" />
                                             <asp:BoundField HeaderText="मांग / Demand" DataField="DemandType_I" />
                                             <asp:BoundField HeaderText="पुस्तक प्रकार / Book Type" DataField="BookType_I" />
                                            <asp:BoundField HeaderText="विषय / Subject" DataField="TitleHindi_V" />
                                            <asp:BoundField HeaderText="कक्षा / Class" DataField="Classdet_V"/>
                                            <asp:TemplateField HeaderText="आवश्यकता / Requirement">

                                                <ItemTemplate> <asp:Label ID="Label2" runat="server" Text='<%#Eval("RequesrdQt_I")%>'></asp:Label>
                                                 
                                                </ItemTemplate>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="मांग / Demand">
                                                 <ItemTemplate>
                                                     <asp:Label ID="Label3" Text='<%#Eval("Demand_I")%>' runat="server"></asp:Label>
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                        </Columns>
                                                                    <PagerStyle CssClass="Gvpaging" />
                                              <EmptyDataRowStyle CssClass="GvEmptyText" />
                                    </asp:GridView>
                </div> 
</asp:Content>

