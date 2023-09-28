<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrinterList.aspx.cs" Inherits="Printing_PrinterList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="portlet-header ui-widget-header">
          &#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2352; &#2319;&#2357;&#2306; &#2309;&#2344;&#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2352; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; 
    </div>
    <div class="table-responsive">
        <table width="100%">
            <tr>
                <td >
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" Width="100%" DataKeyNames="Printer_RedID_I" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
 <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>

                                                     <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval ("Printer_RedID_I") %>' />    
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                            <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; " DataField="NameofPress_V" />
                            <asp:TemplateField HeaderText="&#2352;&#2366;&#2332;&#2381;&#2351; &#2325;&#2366; &#2344;&#2366;&#2350; ">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlstate" runat="server"></asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" >
                                        <asp:ListItem Value="1">&#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2352; </asp:ListItem>
                                        <asp:ListItem Value="2">&#2309;&#2344; &#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2352;</asp:ListItem>
                                    </asp:RadioButtonList>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr><td>
                <asp:Button ID="Button1" runat="server" Text="Save" CssClass="btn" OnClick="Button1_Click" Width="197px" /></td></tr>
            </table> </div> 
</asp:Content>

