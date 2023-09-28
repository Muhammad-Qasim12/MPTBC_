<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="schemeWiseChallan.aspx.cs" Inherits="Depo_schemeWiseChallan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                
                <div class="box">
                    <div class="card-header">
                     <h2> &#2351;&#2379;&#2332;&#2344;&#2366; &#2325;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2366; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; / Books Distribution Of Scheme</h2>
                          
                    </div>
    <asp:GridView ID="grdview" runat="server" AutoGenerateColumns="False" CssClass="tab" OnRowDataBound="grdDailyTask_RowDataBound">


<Columns>
<asp:TemplateField HeaderText="स्कीम का नाम एवं चालान नंबर ">
<ItemTemplate>
 <span style="font: bold 12px arial; color: #017C3C; padding: 20px 10px;">
       <asp:HiddenField runat="server" ID="HID" Value='<%#Eval("SchemeId") %>' ></asp:HiddenField>
 <asp:Label ID="lbltype" Text='<%#Eval("SchemeName_Hindi")%>' runat="server" style="font-weight:bolder;" ></asp:Label> चालान नंबर :<%#Eval("ChallanNO") %>/ <%#Container.DataItemIndex+1 %></span> 
<br />
<asp:GridView ID="grdview1" runat="server" AutoGenerateColumns="False" Width="100%"  >
    <Columns>
         <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
        <asp:BoundField HeaderText="पुस्तक का नाम " DataField="ABookName" />
        <asp:BoundField HeaderText="आवंटन " DataField="TotalAvntan" />
        <asp:BoundField HeaderText="प्रदाय " DataField="Praday" />
          <asp:TemplateField HeaderText="शेष">
                                                 <ItemTemplate>
                                               
                                                       <%#Convert.ToInt32(Eval("TotalAvntan")) - Convert.ToInt32(Eval("Praday"))%>
                                                 </ItemTemplate>
                                             </asp:TemplateField>
        
         <asp:BoundField HeaderText="प्रति बण्डल" DataField="PerBandul1" />
        <asp:BoundField HeaderText="पैक बण्डल " DataField="Paikbandal" />
         <asp:BoundField HeaderText="लूज बण्डल " DataField="Loojbandal" />
    </Columns>
</asp:GridView> 
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView>

</asp:Content>

