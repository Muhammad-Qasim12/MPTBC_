<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookNumbering.aspx.cs" Inherits="Distribution_BookNumbering" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="box table-responsive">
                <div class="card-header">
                    <h2 style="text-align: center;"><span><b>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2344;&#2306;&#2348;&#2352;&#2367;&#2306;&#2327; </b></span></h2>
                </div>
                <div class="portlet-content">
                    <asp:Panel class="response-msg success ui-corner-all" runat="server" ID="mainDiv" Style="display: none; padding-top: 10px; padding-bottom: 10px;">
                        <asp:Label ID="lblmsg" class="notification" runat="server">
                
                        </asp:Label>
                    </asp:Panel>
                    <table width="100%">


                        <tr>
                            <td style="font-size: medium;">
                                <asp:Label ID="LblAcYear" runat="server" Width="180px">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; <br /> Academic Year:</asp:Label>
                                <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox reqirerd"
                                   >
                                </asp:DropDownList></td>
                            <td style="font-size: medium;">
                                <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="&#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2342;&#2375;&#2326;&#2375;" />

                            </td>

                        </tr>


                        <tr>
                            <td style="font-size: medium;" colspan="2">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                                    <Columns>
                                        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;.">
                                             <ItemTemplate><%#Container.DataItemIndex+1 %>
                                                 <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("DepoTrno_I") %>' />

                                             </ItemTemplate> 
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; ">
                                            <ItemTemplate><%#Eval("DepoName_V") %></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2351;&#2379;&#2332;&#2344;&#2366; &#2325;&#2366; &#2344;&#2306;&#2348;&#2352;">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt1" runat="server" Text ='<%#Eval("SchemeBookN") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; &#2325;&#2366; &#2344;&#2306;&#2348;&#2352; "><ItemTemplate>
                                                <asp:TextBox ID="txt2" runat="server" Text ='<%#Eval("GenBookNumber") %>'></asp:TextBox>
                                            </ItemTemplate></asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>

                        </tr>


                        <tr>
                            <td style="font-size: medium;" colspan="2">
                                <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; " Visible="False" />

                            </td>

                        </tr></table> </div> </div> 
</asp:Content>

