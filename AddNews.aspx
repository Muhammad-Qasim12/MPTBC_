<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddNews.aspx.cs" Inherits="AddNews" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     
  <%-- <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up1">
                            <ProgressTemplate>
                                <div class="fade">
                                </div>
                                <div class="progress">
                                    <img src="../images/loading.gif" alt="Loading..." width="110" height="110" />
                                </div>
                            </ProgressTemplate>
                            </asp:UpdateProgress>--%>
    
     <div class="box">
                    <div class="card-header">
                     <h2> &#2335;&#2375;&#2306;&#2337;&#2352; / &#2344;&#2381;&#2351;&#2370;&#2332; &#2309;&#2346;&#2354;&#2379;&#2337; </h2>
                          
                    </div>
                     <table style="width: 100%">
                <tr>
                    <td style="font-size: medium;">
                        &#2335;&#2366;&#2311;&#2346; </td>
                    <td>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Width="160px">
                            <asp:ListItem Selected="True" Value="1">&#2335;&#2375;&#2306;&#2337;&#2352; </asp:ListItem>
                            <asp:ListItem Value="2">&#2344;&#2381;&#2351;&#2370;&#2395; </asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td style="width: 30%; font-size: medium;" valign="top">
                        &nbsp;</td>
                    <td style="font-size: medium;">
                        
                        &nbsp;</td>
                </tr>
                         <tr>
                             <td style="font-size: medium;">&#2337;&#2367;&#2335;&#2375;&#2354;&#2381;&#2360; </td>
                             <td colspan="3">
                                 <asp:TextBox ID="TextBox1" runat="server" CssClass="txtbox" Height="66px" TextMode="MultiLine" Width="481px"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td style="font-size: medium;">&#2346;&#2381;&#2352;&#2340;&#2367;&#2354;&#2367;&#2346; &#2309;&#2346;&#2354;&#2379;&#2337; &#2325;&#2352;&#2375;&#2306;</td>
                             <td colspan="3">
                                 <asp:FileUpload ID="FileUpload1" runat="server" />
                             </td>
                         </tr>
                         <tr>
                             <td style="font-size: medium;">URL</td>
                             <td colspan="3">
                                 <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td style="font-size: medium;">&#2348;&#2376;&#2343;&#2340;&#2366; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2340;&#2325; </td>
                             <td colspan="3">
                                 <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                  <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBox3" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                             </td>
                         </tr>
                <tr>
                    <td style="font-size: medium;" colspan="4">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" OnClick="btnSave_Click" OnClientClick="javascript:return ValidateAllTextForm();" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save  " />
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <asp:HiddenField ID="HiddenField3" runat="server" />
                        <asp:HiddenField ID="HiddenField2" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="font-size: medium;" colspan="4">
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="ID" OnRowDeleting="GridView2_RowDeleting" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                            <Columns>
                                 <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     <asp:HiddenField ID="HiddenField4" runat="server" Value='<%#Eval ("NTypea") %>' />
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                <asp:BoundField DataField="NType" HeaderText="&#2335;&#2366;&#2311;&#2346; " />
                                <asp:BoundField DataField="HeadIng" HeaderText="&#2337;&#2367;&#2335;&#2375;&#2354;&#2381;&#2360; " />
                                <asp:BoundField DataField="FileName" HeaderText="&#2309;&#2346;&#2354;&#2379;&#2337; &#2346;&#2381;&#2352;&#2340;&#2367;&#2354;&#2367;&#2346; " />
                                <asp:BoundField DataField="webURL" HeaderText="URL" />
                                 <asp:BoundField DataField="DateD" HeaderText="&#2348;&#2376;&#2343;&#2340;&#2366; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2340;&#2325;" />
                                <asp:CommandField HeaderText="Update" SelectText="Update" ShowSelectButton="True" />
                                <asp:CommandField ShowDeleteButton="True" DeleteText="Change Status" HeaderText="&#2361;&#2379;&#2350; &#2346;&#2375;&#2332; &#2360;&#2375; &#2361;&#2335;&#2366;&#2344;&#2375; &#2325;&#2375; &#2354;&#2367;&#2319; " />
                                 <asp:TemplateField HeaderText="Delete ">
                                     <ItemTemplate>
                                         <asp:HiddenField ID="HiddenField5" runat="server" Value='<%# Eval("ID") %>' />
                                         <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Delete" />
                                     </ItemTemplate>
                                 </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr></table> </div> 
                                

</asp:Content>

