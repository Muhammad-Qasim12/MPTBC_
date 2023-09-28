<%@ Page Title=" योजना वार शीर्षक / Schemewise Title" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
    CodeFile="ViewSchemeWiseTitle.aspx.cs" Inherits="Academic_ViewSchemeWiseTitle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="table-responsive">
     <div class="headlines">
 <h2><span> योजना वार शीर्षक / Schemewise Title </span></h2>
</div>
       
            <table width="100%">
        <tr>
        <td colspan="2">
          <asp:Button runat="server" ID="btnAdd" Text="नया डाटा डाले / New Entry" CssClass="btn" onclick="btnAdd_Click" />
        </td>
        </tr>


        <tr>
        <td>कक्षा का नाम / Class Name </td>
        <td>
        <asp:DropDownList runat="server" ID="ddlClass" AutoPostBack="true" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged"></asp:DropDownList>
        </td>
        </tr>


        <tr>
        <td colspan="2" >
        <asp:GridView runat="server" ID="grdTitleWiseSchemeMapping" AutoGenerateColumns="false" 
             AllowPaging="True"  CssClass="tab" PageSize="20" OnPageIndexChanging="grdTitleWiseSchemeMapping_PageIndexChanging" >
        <Columns>
        <asp:TemplateField HeaderText="क्रमांक <br> SrNo">
        <ItemTemplate>
        <%# Container.DataItemIndex+1 %>
        </ItemTemplate>
        
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; <br> Title">
        
        <ItemTemplate>
        <%# Eval("TitleHindi_V")%>
        
        </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; <br> Class Name">
        
        <ItemTemplate>
        <%# Eval("Classdet_V")%>
        
        </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="&#2351;&#2379;&#2332;&#2344;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; <br> Scheme Name">
        
        <ItemTemplate>
        <%# Eval("Schemes")%>
        
        </ItemTemplate>
        </asp:TemplateField>

         <asp:TemplateField HeaderText="&#2357;&#2367;&#2357;&#2352;&#2339; <br> Description">
        
        <ItemTemplate>
        <%# Eval("Remark_V")%>
        
        </ItemTemplate>
        </asp:TemplateField>


         <asp:TemplateField HeaderText="डाटा में सुधार करे <br> Edit">
        
        <ItemTemplate>
        <a href="SchemeWiseTitle.aspx?Cid=<%#new APIProcedure().Encrypt(Eval("TitleID_I").ToString().Trim().TrimStart())%>">डाटा में सुधार करे / Edit</a>
              
        </ItemTemplate>
        </asp:TemplateField>


        </Columns>
          <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
        </asp:GridView>
        
        
        </td>
        </tr>

        </table>

        </div>
</asp:Content>

