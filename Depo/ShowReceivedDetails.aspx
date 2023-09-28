<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShowReceivedDetails.aspx.cs" Inherits="Depo_ShowReceivedDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:UpdatePanel ID="up1" runat="server">
<ContentTemplate>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up1">
                            <ProgressTemplate>
                                <div class="fade">
                                </div>
                                <div class="progress">
                                    <img src="../images/loading.gif" alt="Loading..." width="110" height="110" />
                                </div>
                            </ProgressTemplate>
                            </asp:UpdateProgress>
      <div class="card-header">
            <h2>
                <span>&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;</span></h2>
        </div>
    <asp:Button ID="Button1" runat="server" CssClass="btn" Text="&#2357;&#2366;&#2346;&#2360; &#2332;&#2366;&#2351;&#2375; >>" OnClick="Button1_Click" />
     <asp:Button ID="btnSave" runat="server" Text=" &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2325;&#2352;&#2375; " CssClass="btn" OnClick="btnSave_Click" />
        
  
    <asp:Label ID="lblmsg2" runat="server" Text="&#2348;&#2366;&#2352;&#2325;&#2379;&#2337; &#2360;&#2375; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;" Font-Bold="True" ForeColor="#FF3300" ></asp:Label>
      <asp:GridView ID="GrdMismatch" runat="server" AutoGenerateColumns="false" CssClass="tab">
                                                 <Columns>
                                                     <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                    
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("TitleHindi_V") %>' ID="lblTitleHindi_V" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("booktype") %>' ID="lblbooktype" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="&#2348;&#2306;&#2337;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("BundleNo_I") %>' ID="lblBundleNo_I" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375;">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("FromNo_I") %>' ID="lblFromNo_I" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2340;&#2325;">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("ToNo_I") %>' ID="lblToNo_I" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                 </Columns>
                                                 </asp:GridView>
    <br />
    <asp:Label ID="lblmsg1" runat="server" Text="&#2330;&#2366;&#2354;&#2366;&#2344; &#2350;&#2375;&#2306; &#2309;&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2348;&#2306;&#2337;&#2354;" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
                                                 <asp:GridView ID="grdAprapt" runat="server" AutoGenerateColumns="false" CssClass="tab" >
                                                 <Columns>
                                                     <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                    
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("TitleHindi_V") %>' ID="lblTitleHindi_V" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("booktype") %>' ID="lblbooktype" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="&#2348;&#2306;&#2337;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("BundleNo_I") %>' ID="lblBundleNo_I" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375;">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("FromNo_I") %>' ID="lblFromNo_I" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2340;&#2325;">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("ToNo_I") %>' ID="lblToNo_I" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                 </Columns>
                                                 </asp:GridView>
    <br />
     <asp:Label ID="Label1" runat="server" Text="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2349;&#2375;&#2332;&#2375; &#2327;&#2351;&#2375; &#2348;&#2306;&#2337;&#2354; &#2325;&#2366; &#2348;&#2367;&#2348;&#2352;&#2339;" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
                                       <asp:GridView ID="grdPrinterBundleDetails" runat="server" AutoGenerateColumns="false" CssClass="tab">
                                                 <Columns>
                                                     <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                  
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("TitleHindi_V") %>' ID="lblTitleHindi_V" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("booktype") %>' ID="lblbooktype" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="&#2348;&#2306;&#2337;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("BundleNo_I") %>' ID="lblBundleNo_I" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375;">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("FromNo_I") %>' ID="lblFromNo_I" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2340;&#2325;">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("ToNo_I") %>' ID="lblToNo_I" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2325;&#2352;&#2375;&#2306;">
                                                          <HeaderTemplate>
                                                           <asp:CheckBox ID="CheckBox2" runat="server" Checked="true" Text="Select All" AutoPostBack="True" OnCheckedChanged="CheckBox2_CheckedChanged" />
                                                          </HeaderTemplate>
                                                 <ItemTemplate>
                                              
                                                     <asp:CheckBox ID="CheckBox1" runat="server" Checked="true" />
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                                 </Columns>
                                                 </asp:GridView>
    <br />
   <br /><br /></ContentTemplate> </asp:UpdatePanel> 
</asp:Content>


