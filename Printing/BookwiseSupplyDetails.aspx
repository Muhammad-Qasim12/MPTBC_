<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookwiseSupplyDetails.aspx.cs" Inherits="Printing_BookwiseSupplyDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="box">
        <div class="card-header">
            <h2>
                <span>&#2325;&#2366;&#2352;&#2381;&#2351;&#2366;&#2342;&#2375;&#2358; &#2319;&#2357;&#2306; &#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Workorder And Agreement</span></h2>
        </div>
     <div class="box table-responsive">
            <table width="100%">
                <tr>
                    <td style="text-align: center">
                        &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;
                        <br />
                    </td>
                    <td style="text-align: center">
                        <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: center">
                        &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                    <td style="text-align: center">
                        <asp:DropDownList ID="ddlprinterName" runat="server" CssClass="txtbox">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: center">
                        &#2325;&#2325;&#2381;&#2359;&#2366;</td>
                    <td style="text-align: center">
                        <asp:DropDownList ID="ddlClassName" runat="server" CssClass="txtbox" AutoPostBack="True" OnSelectedIndexChanged="ddlClassName_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: center">
                       
                                    &#2350;&#2366;&#2343;&#2381;&#2351;&#2350; :
                                
                                   </td>
                    
                    <td style="text-align: center">
                       
                                   <asp:DropDownList ID="ddlMedium" runat="server" CssClass="txtbox reqirerd" AutoPostBack="True" OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged">
                                    </asp:DropDownList>
                                
                    </td>
                    
                </tr>
                <tr>
                     <td style="text-align: center">
                        &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;&nbsp; </td>
                    <td style="text-align: center">
                        <asp:DropDownList ID="ddlTital" runat="server" CssClass="txtbox">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: center">
                        &#2337;&#2367;&#2346;&#2379; &#2344;&#2366;&#2350;
                    </td>
                    <td style="text-align: center">
                        <asp:DropDownList ID="DDlDepot" runat="server" CssClass="txtbox">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: center">
                        &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
                        :
                        </td>
                    <td style="text-align: center">
                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="TextBox4">
                        </cc1:CalendarExtender>
                    </td>
                    <td style="text-align: center">
                        <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="&#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2342;&#2375;&#2326;&#2375;" />
                     </td>
                  
                    <td style="text-align: center">
                        &nbsp;</td>
                  
                </tr>
                <tr>
                    <td style="text-align: center" colspan="8">
                       <%-- <asp:Panel ID="Panel1" runat="server" Height="400px" ScrollBars="Both" Width="1250px">--%>
                            <asp:GridView ID="GrdGroupDetails" runat="server" AutoGenerateColumns="False" CssClass="tab" Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr.No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                            <asp:HiddenField ID="hdTitleID" runat="server" Value='<%# Eval("TItleid") %>' />
                                           <%-- <asp:HiddenField ID="hdDepoID_I" runat="server" Value='<%# Eval("DepoID_I") %>' />--%>
                                            <asp:HiddenField ID="hdPrinter_RedID_I" runat="server" Value='<%# Eval("PrinterID") %>' />
                                            <asp:HiddenField ID="hdclasstrno_i" runat="server" Value='<%# Eval("Class") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; / Printer Name"
                                DataField="NamePrinters" />
                                    <asp:BoundField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; / Textbook Title"
                                DataField="Subject" />
                                
                                    <asp:BoundField HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366; /Class" DataField="Class" />
                                    <%--<asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2369;&#2346; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Group No.">
                                        <ItemTemplate>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblGroupNO_V" runat="server" Text='<%#Eval("GroupNO_V") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>--%>
                                    <%--</asp:TemplateField>--%>
  <%--                                  <asp:BoundField HeaderText="Proff Rece.Date" DataField="" />
                                    <asp:BoundField HeaderText="Print Order Date" DataField="" />--%>
                                    <asp:TemplateField HeaderText="&#2311;&#2306;&#2342;&#2380;&#2352;">
                                        <ItemTemplate>
                                            &#2351;&#2379;&#2332;&#2344;&#2366; :
                                            <asp:TextBox ID="txtindore" runat="server" Width="50px"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender  ID="FilteredTextBoxExtender2" TargetControlID="txtindore" ValidChars="0123456798" runat="server">
                                            </cc1:FilteredTextBoxExtender>
                                            &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; :
                                            <asp:TextBox ID="txtindore1" runat="server" Width="45px"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender  ID="FilteredTextBoxExtender5" TargetControlID="txtindore1" ValidChars="0123456798" runat="server">
                                            </cc1:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2313;&#2332;&#2381;&#2332;&#2376;&#2344; ">
                                        <ItemTemplate>
                                            &#2351;&#2379;&#2332;&#2344;&#2366; :
                                            <asp:TextBox ID="txtujjain" runat="server" Width="45px"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender  ID="FilteredTextBoxExtender22" TargetControlID="txtujjain" ValidChars="0123456798" runat="server">
                                            </cc1:FilteredTextBoxExtender>
                                            &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; :
                                            <asp:TextBox ID="txtujjain1" runat="server" Width="45px"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender  ID="FilteredTextBoxExtender5111" TargetControlID="txtujjain1" ValidChars="0123456798" runat="server">
                                            </cc1:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2326;&#2306;&#2337;&#2357;&#2366; ">
                                        <ItemTemplate>
                                            &#2351;&#2379;&#2332;&#2344;&#2366; :
                                            <asp:TextBox ID="txtKhandwa" runat="server" Width="45px"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender  ID="FilteredTextBoxExtender12" TargetControlID="txtKhandwa" ValidChars="0123456798" runat="server">
                                            </cc1:FilteredTextBoxExtender>
                                            &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; :
                                            <asp:TextBox ID="txtKhandwa1" runat="server" Width="45px"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender  ID="FilteredTextBoxExtender51" TargetControlID="txtKhandwa1" ValidChars="0123456798" runat="server">
                                            </cc1:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2349;&#2379;&#2346;&#2366;&#2354;">
                                        <ItemTemplate>
                                            &#2351;&#2379;&#2332;&#2344;&#2366; :
                                            <asp:TextBox ID="txtbhopal" runat="server" Width="45px"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender  ID="FilteredTextBoxExtender1" TargetControlID="txtbhopal" ValidChars="0123456798" runat="server">
                                            </cc1:FilteredTextBoxExtender>
                                            &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; :
                                            <asp:TextBox ID="txtbhopal1" runat="server" Width="45px"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender  ID="FilteredTextBoxExtender4" TargetControlID="txtbhopal1" ValidChars="0123456798" runat="server">
                                            </cc1:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2332;&#2348;&#2354;&#2346;&#2369;&#2352;">
                                        <ItemTemplate>
                                            &#2351;&#2379;&#2332;&#2344;&#2366; :
                                            <asp:TextBox ID="txtjabapur" runat="server" Width="45px"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender  ID="FilteredTextBoxExtender3" TargetControlID="txtjabapur" ValidChars="0123456798" runat="server">
                                            </cc1:FilteredTextBoxExtender>
                                            &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; :
                                            <asp:TextBox ID="txtjabapur1" runat="server" Width="45px"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender  ID="FilteredTextBoxExtender15" TargetControlID="txtjabapur1" ValidChars="0123456798" runat="server">
                                            </cc1:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2327;&#2381;&#2357;&#2366;&#2354;&#2367;&#2351;&#2352;">
                                        <ItemTemplate>
                                            &#2351;&#2379;&#2332;&#2344;&#2366; :
                                            <asp:TextBox ID="txtGwaliore" runat="server" Width="45px"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender  ID="FilteredTextBoxExtender21" TargetControlID="txtGwaliore" ValidChars="0123456798" runat="server">
                                            </cc1:FilteredTextBoxExtender>
                                            &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; :
                                            <asp:TextBox ID="txtGwaliore1" runat="server" Width="45px"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender  ID="FilteredTextBoxExtender115" TargetControlID="txtGwaliore1" ValidChars="0123456798" runat="server">
                                            </cc1:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2360;&#2366;&#2327;&#2352; ">
                                        <ItemTemplate>
                                            &#2351;&#2379;&#2332;&#2344;&#2366; :
                                            <asp:TextBox ID="txtSagar" runat="server" Width="45px"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender  ID="FilteredTextBoxExtender23" TargetControlID="txtSagar" ValidChars="0123456798" runat="server">
                                            </cc1:FilteredTextBoxExtender>
                                            &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; :
                                            <asp:TextBox ID="txtSagar1" runat="server" Width="45px"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender  ID="FilteredTextBoxExtender512" TargetControlID="txtSagar1" ValidChars="0123456798" runat="server">
                                            </cc1:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2352;&#2368;&#2357;&#2366;">
                                        <ItemTemplate>
                                            &#2351;&#2379;&#2332;&#2344;&#2366; :
                                            <asp:TextBox ID="txtrewa" runat="server" Width="45px"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender  ID="FilteredTextBoxExtender112" TargetControlID="txtrewa" ValidChars="0123456798" runat="server">
                                            </cc1:FilteredTextBoxExtender>
                                            &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; :
                                            <asp:TextBox ID="txtrewa1" runat="server" Width="45px"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender  ID="FilteredTextBoxExtender511" TargetControlID="txtrewa1" ValidChars="0123456798" runat="server">
                                            </cc1:FilteredTextBoxExtender>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    Data Not Found
                                </EmptyDataTemplate>
                                <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                            </asp:GridView>
                        <%--</asp:Panel>--%>
                    </td>
                </tr>
                </table>
        </div>
    </div>
    <br />
                            <asp:Button ID="Button2" runat="server" CssClass="btn"  Text="&#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; " OnClick="Button2_Click" Visible="False" />
                    
      <br />
      <%--<asp:Panel ID="Panel2" runat="server" Height="300px" ScrollBars="Both" Width="1250px">--%>
          <asp:GridView ID="GridView1" runat="server" CssClass="tab" AutoGenerateColumns="False" DataKeyNames="supID" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting">
              <Columns>
                  <asp:BoundField DataField="DateRec" HeaderText="&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " />
                  <asp:BoundField DataField="NameofPress_V" HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                  <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                  <asp:BoundField DataField="ClassID" HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366; " />
                  <asp:TemplateField HeaderText="&#2311;&#2306;&#2342;&#2380;&#2352;">
                      <ItemTemplate>
                          &#2351;&#2379;&#2332;&#2344;&#2366; :
                          <asp:Label ID="Label44" runat="server" Text='<%#Eval("IndAllotmentY") %>'></asp:Label>
                          <br />
                          &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; :
                          <asp:Label ID="Label5" runat="server" Text='<%#Eval("IndAllotmentS") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="&#2313;&#2332;&#2381;&#2332;&#2376;&#2344;">
                      <ItemTemplate>
                          &#2351;&#2379;&#2332;&#2344;&#2366; :
                          <asp:Label ID="Label6" runat="server" Text='<%#Eval("UJJainAllotmentY") %>'></asp:Label>
                          <br />
                          &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; :
                          <asp:Label ID="Label7" runat="server" Text='<%#Eval("UjjainAllotmentS") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="&#2326;&#2306;&#2337;&#2357;&#2366; ">
                      <ItemTemplate>
                          &#2351;&#2379;&#2332;&#2344;&#2366; :
                          <asp:Label ID="Label12" runat="server" Text='<%#Eval("KhandAllotmentY") %>'></asp:Label>
                          <br />
                          &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; :
                          <asp:Label ID="Labe13" runat="server" Text='<%#Eval("KhandAllotmentS") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="&#2349;&#2379;&#2346;&#2366;&#2354;">
                      <ItemTemplate>
                          &#2351;&#2379;&#2332;&#2344;&#2366; :
                          <asp:Label ID="Label1" runat="server" Text='<%#Eval("BhoAllotmentY") %>'></asp:Label>
                          <br />
                          &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; :
                          <asp:Label ID="Label2" runat="server" Text='<%#Eval("BhoAllotmentS") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="&#2332;&#2348;&#2354;&#2346;&#2369;&#2352;">
                      <ItemTemplate>
                          &#2351;&#2379;&#2332;&#2344;&#2366; :
                          <asp:Label ID="Label151" runat="server" Text='<%#Eval("JablpurAllotmentY") %>'></asp:Label>
                          <br />
                          &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; :
                          <asp:Label ID="Labe162" runat="server" Text='<%#Eval("JabalpurAllotmentS") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="&#2327;&#2381;&#2357;&#2366;&#2354;&#2367;&#2351;&#2352;">
                      <ItemTemplate>
                          &#2351;&#2379;&#2332;&#2344;&#2366; :
                          <asp:Label ID="Label15" runat="server" Text='<%#Eval("GwaAllotmentY") %>'></asp:Label>
                          <br />
                          &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; :
                          <asp:Label ID="Labe16" runat="server" Text='<%#Eval("GwaAllotments") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="&#2360;&#2366;&#2327;&#2352;">
                      <ItemTemplate>
                          &#2351;&#2379;&#2332;&#2344;&#2366; :
                          <asp:Label ID="Label8" runat="server" Text='<%#Eval("SagarAllotmentY") %>'></asp:Label>
                          <br />
                          &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; :
                          <asp:Label ID="Label9" runat="server" Text='<%#Eval("SagarAllotmentS") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="&#2352;&#2368;&#2357;&#2366;">
                      <ItemTemplate>
                          &#2351;&#2379;&#2332;&#2344;&#2366; :
                          <asp:Label ID="Label10" runat="server" Text='<%#Eval("RewaAllotmentY") %>'></asp:Label>
                          <br />
                          &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; :
                          <asp:Label ID="Labe11" runat="server" Text='<%#Eval("RewaAllotmentS") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:CommandField ShowDeleteButton="True" />
              </Columns>
              <EmptyDataTemplate>
                  Data Not Found
              </EmptyDataTemplate>
          </asp:GridView>
      <%--</asp:Panel>--%>
                    
      <br />
                          
     
                    
</asp:Content>

