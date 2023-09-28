<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrinterExpiryList.aspx.cs" Inherits="Printing_PrinterList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="portlet-header ui-widget-header">
          &#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2381;&#2352;&#2375;&#2358;&#2344; &#2325;&#2350;&#2381;&#2346;&#2354;&#2368;&#2335; &#2325;&#2352;&#2344;&#2375; &#2357;&#2366;&#2354;&#2375;&nbsp; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; 
    </div>
    <div class="table-responsive">
        <table width="100%">
            <tr><td>
                No of Days
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="&#2326;&#2379;&#2332;&#2375; " />
                </td>
                </tr>
            <tr>
                <td >
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" Width="100%" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
 <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>

                                                     <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval ("Printer_RedID_I") %>' />    
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                            <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; " DataField="NameofPress_V" />
                            <asp:BoundField HeaderText="&#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2381;&#2352;&#2375;&#2358;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " DataField="RegDate_D" DataFormatString="{0:d}"  />
                            <asp:BoundField HeaderText="&#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2381;&#2352;&#2375;&#2358;&#2344; &#2346;&#2369;&#2352;&#2381;&#2339; &#2361;&#2379;&#2344;&#2375; &#2325;&#2367; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;  " DataField="Enddate" DataFormatString="{0:d}" />
                            
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr><td>
                &nbsp;</td></tr>
            </table> </div> 
</asp:Content>

