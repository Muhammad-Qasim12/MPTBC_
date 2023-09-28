<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OrdersUpload.aspx.cs" 
    Inherits="Admin_OrdersUpload" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box">
                    <div class="headlines">
                     <h2> &#2346;&#2370;&#2352;&#2381;&#2357; &#2310;&#2342;&#2375;&#2358; / &#2344;&#2357;&#2368;&#2344; &#2310;&#2342;&#2375;&#2358; /&#2360;&#2370;&#2330;&#2344;&#2366; </h2>
                          
                    </div>
                     <table style="width: 100%">
                         <tr>
                             <td style="font-size: medium;"><b>
                          <asp:Label ID="Label2" runat="server" Text="&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352;" CssClass="table"></asp:Label></b> </td>
                             <td>
                          <asp:DropDownList ID="DdlACYear" runat="server">
                          </asp:DropDownList>
                             </td>
                         </tr>
                         <tr>
                             <td style="font-size: medium;">&#2310;&#2352;&#2381;&#2337;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </td>
                             <td>
                                 <asp:TextBox ID="TextBox2" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>.
                                   <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBox2" Format="dd/MM/yyyy">
                     </cc1:CalendarExtender>
                             </td>
                         </tr>
                         <tr>
                             <td style="font-size: medium;">&#2357;&#2367;&#2359;&#2351; </td>
                             <td>
                                 <asp:TextBox ID="TextBox1" runat="server" CssClass="txtbox txtbox" Height="66px" TextMode="MultiLine" Width="481px"></asp:TextBox>
                             
                             </td>
                         </tr>
                         <tr>
                             <td style="font-size: medium;">&#2310;&#2342;&#2375;&#2358; &#2309;&#2346;&#2354;&#2379;&#2337; &#2325;&#2352;&#2375;&#2306; -1</td>
                             <td>
                                 <asp:FileUpload ID="FileUpload1" runat="server" />
                                 <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" Text="Add" />
                             </td>
                         </tr>
                         <tr>
                             <td style="font-size: medium;" colspan="2">
                                 <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CssClass="tab">
                                     <Columns>
                                         <asp:BoundField DataField="DocumentName" HeaderText="Document Name" />
                                     </Columns>
                                 </asp:GridView>
                             </td>
                         </tr>
                <tr>
                    <td style="font-size: medium;" colspan="2">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" OnClick="btnSave_Click"  OnClientClick="javascript:return ValidateAllTextForm();" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save  " />
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    &nbsp;</td>
                </tr>
                <tr>
                    <td style="font-size: medium;" colspan="2">
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="ID" OnRowDeleting="GridView2_RowDeleting" >
                            <Columns>
                                 <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                <asp:BoundField HeaderText="&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; " DataField="ACyear" />
                                 <asp:BoundField DataField="DocuemntDetails" HeaderText="&#2357;&#2367;&#2359;&#2351;" />
                                <asp:BoundField DataField="OrderDate" HeaderText="&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " />
                                <asp:BoundField DataField="UserName_V" HeaderText="&#2337;&#2367;&#2346;&#2366;&#2352;&#2381;&#2335;&#2350;&#2375;&#2306;&#2335; &#2325;&#2366; &#2344;&#2366;&#2350;  " />
                                                                  <asp:BoundField DataField="DocumentName" HeaderText="&#2309;&#2346;&#2354;&#2379;&#2337; &#2337;&#2377;&#2325;&#2381;&#2351;&#2370;&#2350;&#2375;&#2306;&#2335; " />
                                
                                <asp:CommandField ShowDeleteButton="True" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr></table> </div> 
</asp:Content>

