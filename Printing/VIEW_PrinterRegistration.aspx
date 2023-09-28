<%@ Page Title="VIEW Printer Registration" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VIEW_PrinterRegistration.aspx.cs" Inherits="Printing_VIEW_PrinterRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="box table-responsive">
 <div class="card-header">
 <h2><span>Printer Registration</span></h2>
</div>
<div class="box table-responsive">

<table width="100%">
<tr>
<td><asp:Button runat="server" ID="btnAdd" CssClass="btn" Text="Add Printer" OnClick="btnAdd_Click" />
</td>
<td><asp:Button runat="server" ID="Button1" CssClass="btn" Text="Add Printer" OnClick="btnAdd_Click" />
</td>
<td><asp:Button runat="server" ID="Button2" CssClass="btn" Text="Add Printer" OnClick="btnAdd_Click" />
</td>
<td><asp:Button runat="server" ID="Button3" CssClass="btn" Text="Add Printer" OnClick="btnAdd_Click" />
<asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375;"
                        OnClientClick="return ValidateAllTextForm();"/>
                            
</td>
</tr>
                        
<tr>
<td colspan ="4" >
     <asp:Panel runat="server" ID="pnlreg" GroupingText="Printer Registration " Width="1200px" ScrollBars="Both"  >

    <asp:GridView runat="server" PageSize="10" ID="grdPrinterRegistration" CssClass="tab" AutoGenerateColumns="false" AllowPaging="True" OnPageIndexChanging="grdPrinterRegistration_PageIndexChanging">
    <Columns>
    <asp:TemplateField HeaderText="S.No">
    <ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Name of Press">
    <ItemTemplate>
    <%# Eval("NameofPress_V")%>
    </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Address">
    <ItemTemplate>
    <%# Eval("FullAddress_V")%>
    </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Head Office">
    <ItemTemplate>
    <%# Eval("Headoffice_V")%>
    </ItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Registration Date">
    <ItemTemplate>
    <%# Eval("RegDate_D")%>
    </ItemTemplate>
    </asp:TemplateField>




    <asp:TemplateField HeaderText="Edit">
    <ItemTemplate>
   
    <a href="PrinterRegistration.aspx?Cid=<%#new APIProcedure().Encrypt(Eval("Printer_RedID_I").ToString()) %>">Edit</a>
    </ItemTemplate>
    </asp:TemplateField>


    </Columns>
     <PagerStyle CssClass="Gvpaging" />
    </asp:GridView>

     </asp:Panel>


</td>

</tr>
</table>






</div> </div> 
</asp:Content>

