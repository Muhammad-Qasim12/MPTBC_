<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LunListGroupDetails.aspx.cs" Inherits="Printing_LunListGroupDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2342;&#2352;&#2381;&#2332; &#2325;&#2352;&#2375;&#2306;/ Tender Details</span>
            </h2>
        </div>
        <div id="messageDiv" runat="server" class="form-message" style="display: none;">
            </div>
        <div style="padding: 0 10px;">
            <table width="100%">
                <tr>
                    <td>
                       &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year <span class="required">*</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlAcdmicYr_V" runat="server" CssClass="txtbox reqirerd" 
                            onselectedindexchanged="ddlAcdmicYr_V_SelectedIndexChanged" 
                            AutoPostBack="True">
                          <asp:ListItem value="2014-2015">2014-2015</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;&nbsp; / Tender Name <span class="required">*</span>
                    </td>
                    <td>
                    <asp:DropDownList ID="ddlTenderName" runat="server" CssClass="txtbox reqirerd">
                   
                    </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; " />
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                            <Columns>
                                <asp:TemplateField HeaderText="Sr.No">
                                    <ItemTemplate>
                                         <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Printer Name" >
                                    <ItemTemplate>
                                       <asp:Literal ID="lblPrinter" runat="server" Text="" OnDataBinding="lblPrinter_DataBinding"></asp:Literal> 
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Group No">
                                    <ItemTemplate>
                                        <%#Eval("GroupNO") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Group Qty">
                                    <ItemTemplate>
                                        <%#Eval("GroupQty") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Printer Capacity (1.5)">
                                    <ItemTemplate>
                                         <asp:Literal ID="lblPrinterCapacity" runat="server" Text="" OnDataBinding="lblPrinterCapacity_DataBinding" ></asp:Literal> 
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr></table> </div> </div> 
</asp:Content>

