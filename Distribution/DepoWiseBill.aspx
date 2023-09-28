<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DepoWiseBill.aspx.cs" Inherits="Depo_DepoWiseBill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
                <div class="card-header">
                    <h2>
                        <span style="font-size: medium;">&#2348;&#2367;&#2354; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Information Of Bill
                        </span>
                    </h2>
                </div>
                <div class="portlet-content">
                    <div class="table-responsive">
                        <table width="100%">
                            <tr>
                                <td style="width: 25%; font-size: medium;" valign="top">
                                    <asp:Label ID="LblAcYear" runat="server" >&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; <br />Academic Year :</asp:Label>
                                    <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 25%; font-size: medium;" valign="top">
                                    <asp:Label ID="LblClass" runat="server" >&#2325;&#2325;&#2381;&#2359;&#2366; <br />Class :</asp:Label>
                                    <asp:DropDownList ID="DdlClass" runat="server" CssClass="txtbox" 
                                        AutoPostBack="true">
                                        <asp:ListItem Value="1,2,3,4,5">1-5</asp:ListItem>
                                        <asp:ListItem Value="6,7,8">6-8</asp:ListItem>
                                        <asp:ListItem Value="9,10,11,12">9-12</asp:ListItem>
                                        <asp:ListItem Value="1,2,3,4,5,6,7,8">1-8</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                 <td style="width: 25%; font-size: medium;" valign="top">
                                    <asp:Label ID="Label1" runat="server" >&#2337;&#2367;&#2350;&#2366;&#2306;&#2337; &#2335;&#2366;&#2311;&#2346; <br />Demand Type:</asp:Label>
                                    <asp:DropDownList ID="DDlDemandType" runat="server" CssClass="txtbox">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25%; font-size: medium;" valign="top">
                                    <asp:DropDownList ID="ddlBillDetails" runat="server" Width="300px">
                                        <asp:ListItem Value="100">&#2348;&#2367;&#2354; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339; &#2342;&#2375;&#2326;&#2375; / Show Bill&#2348;&#2367;&#2354; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339; &#2342;&#2375;&#2326;&#2375; / Show Bill</asp:ListItem>
                                        <asp:ListItem Value="80">80 % &#2325;&#2366; &#2348;&#2367;&#2354; &#2342;&#2375;&#2326;&#2375; / Show 80% Bill80 % &#2325;&#2366; &#2348;&#2367;&#2354; &#2342;&#2375;&#2326;&#2375; / Show 80% Bill</asp:ListItem>
                                        <asp:ListItem Value="20">20 % &#2325;&#2366; &#2348;&#2367;&#2354; &#2342;&#2375;&#2326;&#2375; / Show 20% Bill20 % &#2325;&#2366; &#2348;&#2367;&#2354; &#2342;&#2375;&#2326;&#2375; / Show 20% Bill</asp:ListItem>
                                        <asp:ListItem Value="15">
15 % &#2325;&#2366; &#2348;&#2367;&#2354; &#2342;&#2375;&#2326;&#2375; / Show 15% Bill15
                                            15 % &#2325;&#2366; &#2348;&#2367;&#2354; &#2342;&#2375;&#2326;&#2375; / Show 15% Bill
                                        </asp:ListItem>
                                        <asp:ListItem Value="85">85 % &#2325;&#2366; &#2348;&#2367;&#2354; &#2342;&#2375;&#2326;&#2375; / Show 85% Bill85 % &#2325;&#2366; &#2348;&#2367;&#2354; &#2342;&#2375;&#2326;&#2375; / Show 85% Bill</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 25%; font-size: medium;" valign="top">
                                    &nbsp;</td>
                                 <td style="width: 25%; font-size: medium;" valign="top">
                                     &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="font-size: medium;" valign="top" colspan="3">
                                    <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Show Data" />
                                    <asp:Button ID="btnExport" runat="server" CssClass="btn" Height="28px" OnClick="btnExport_Click" Text="Export to Excel" />
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: medium;" valign="top" colspan="3">
                                     <div id="ExportDiv" runat="server">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True">
                                        <Columns>
                                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                            <asp:BoundField DataField="DepoName_V" HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350;" />
                                            <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2310;&#2357;&#2306;&#2335;&#2367;&#2340;  &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; ">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl1" runat="server" Text='<%#Eval("Total_Allotment")%>'></asp:Label>
                                                  
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;  &#2325;&#2368; &#2352;&#2366;&#2358;&#2367; ">
                                                 <ItemTemplate>
                                                     <asp:Label ID="lbl2" runat="server" Text='<%#Eval("Total_Amount")%>'></asp:Label>
                                                   </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; ">
                                                 <ItemTemplate>
                                                      <asp:Label ID="lbl3" runat="server" Text='<%#Eval("Praday")%>'></asp:Label>
                                                
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                         
                                             <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2368; &#2352;&#2366;&#2358;&#2367; ">
                                                 <ItemTemplate>
                                                       <asp:Label ID="lbl4" runat="server" Text='<%# (Eval("Amount"))%>'></asp:Label>
                                                
                                                
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="&#2358;&#2375;&#2359; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; ">
                                                 <ItemTemplate>
                                                       <asp:Label ID="lbl5" runat="server" Text='<%#Convert.ToDouble(Eval("Total_Allotment")) - Convert.ToDouble(Eval("Praday"))%>'></asp:Label>
                                                
                                                
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="&#2358;&#2375;&#2359; &#2352;&#2366;&#2358;&#2367; ">
                                                 <ItemTemplate>
                                                            <asp:Label ID="lbl6" runat="server" Text='<%#Convert.ToDouble(Eval("Total_Amount")) - Convert.ToDouble(Eval("Amount"))%>'></asp:Label>
                                                
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView></div>
                                </td>
                            </tr></table> </div> </div> </div> 
</asp:Content>

