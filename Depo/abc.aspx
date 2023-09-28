<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="abc.aspx.cs" Inherits="Depo_abc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="card-header">
                                <h2>&#2323;&#2346;&#2344;&#2367;&#2306;&#2327; &#2360;&#2381;&#2335;&#2377;&#2325; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; /Opening Stock Report</h2>
                            </div>

                            <div style="padding:0 10px;">
                                <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="वापस जाये " />

                                <asp:GridView ID="grdPrinterBundleDetails" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="BundleNo_I" OnRowDeleting="grdPrinterBundleDetails_RowDeleting" >
                                                 <Columns>
                                                     <asp:BoundField DataField="ClassDesc_v" HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366; /Class" />


                                                 <asp:TemplateField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Title Name">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("TitleHindi_V") %>' ID="TitleHindi_V" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; ">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("bookType") %>' ID="NameofPress_V" runat="server"  ></asp:Label>
                                                
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="&#2348;&#2306;&#2337;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Bundle No.">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("BundleNo_I") %>' ID="BundleNo_I" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375; / Book No. From">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("FromNo_I") %>' ID="FromNo_I" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2340;&#2325; / Book No. To">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("ToNo_I") %>' ID="ToNo_I" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="प्रति बण्डल  पुस्तक संख्या">
                                                 <ItemTemplate>
                                                  <%#Convert.ToInt32(Eval("ToNo_I"))-( Convert.ToInt32(Eval("FromNo_I")))+1%>
                                                
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="लूज बुक नंबर">
                                                 <ItemTemplate>
                                               <asp:Panel Width="200px" ScrollBars="Both" runat="server"  >
                                                     <%#Eval("RemaingLoose_V")%></asp:Panel> 
                                                
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="">
                                                          <HeaderTemplate>
                                                              <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox2_CheckedChanged" />
                                                          </HeaderTemplate>
                                                 <ItemTemplate>
                                                     <asp:CheckBox ID="CheckBox1" runat="server" />
                                                
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                    
                                                    
                                                 </Columns>
                                                 </asp:GridView>

                                                                <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" Text="डाटा डिलीट करें " />

                                

                                </div> 
</asp:Content>

