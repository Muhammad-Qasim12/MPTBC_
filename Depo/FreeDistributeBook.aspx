<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FreeDistributeBook.aspx.cs" Inherits="Depo_FreeDistributeBook" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">&nbsp;<div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>
                    &#2344;&#2367;: &#2358;&#2369;&#2354;&#2381;&#2325; &#2346;&#2366;&#2336;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351;
                    </span></h2>
        </div>
        <div class="table-responsive">

            <table width="100%">
                <tr><td colspan="4">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
                    </td></tr>

                <tr><td><span style="color: rgb(0, 0, 0); font-family: Arial, Verdan, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: bold; letter-spacing: normal; orphans: 2; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(241, 241, 241); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352;</span></td><td>
                    <asp:DropDownList ID="ddlSessionYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    </asp:DropDownList>
                    </td><td><span style="color: rgb(0, 0, 0); font-family: Arial, Verdan, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: bold; letter-spacing: normal; orphans: 2; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(241, 241, 241); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">RSK &#2325;&#2366; &#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2406;</span></td><td>
                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                    </asp:DropDownList>
                    </td></tr>
                <tr>
                    <td>&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </td><td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="TextBox2">
                                         </cc1:CalendarExtender>
                    </td><td>&nbsp;</td><td>
                    &nbsp;</td>
                </tr>

                <tr><td colspan="4">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="TitalID">
                        <Columns>
                            <asp:BoundField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " DataField="TitleHindi_V" />
                            <asp:BoundField HeaderText="&#2310;&#2342;&#2375;&#2358;&#2367;&#2340; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " DataField="TotalBooks_I" />
                                                       <asp:BoundField HeaderText="प्रदाय संख्या " DataField="TotalBook" />
                             <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; ">
                                <ItemTemplate>
                                 <%--   <asp:TextBox ID="txtas" runat="server" ></asp:TextBox>--%>
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("TitalID") %>' />
                                    <asp:Button ID="Button2" CssClass="btn" OnClick="Button4_Click" runat="server" Text="प्रदाय करें" />
                                    
                                      </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    </td></tr>

                <tr><td colspan="4">
                    <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Save" Width="108px" />
                    </td></tr>
                </table>
            </div></div>
         <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server" >
            </div>
            <div id="Messages" style="display: none;" class="popupnew1" runat="server" >
              शीर्षक का नाम :- <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
               प्रदाय संख्या :-   <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                      
                 <asp:GridView ID="grdPrinterBundleDetails" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="StockDetailsChildID_I">
                                                 <Columns>
                                                  

                                                     <asp:TemplateField HeaderText="प्रदाय ">
                                                         <ItemTemplate>
                                                             <asp:CheckBox ID="chkpaik" runat="server" />
                                                         </ItemTemplate>
                                                     </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="&amp;#2354;&amp;#2370;&amp;#2360; &amp;#2348;&amp;#2306;&amp;#2337;&amp;#2354;/loose">
                                                         <ItemTemplate>
                                                             <asp:CheckBox ID="chkIsLoose" runat="server" AutoPostBack="true" OnCheckedChanged="chkIsLooseChange" />
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                  


                                                 <asp:TemplateField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Title Name ">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("TitleHindi_V") %>' ID="TitleHindi_V" runat="server"  ></asp:Label>
                                              
                                                       </ItemTemplate>
                                                 </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; / Book Type">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("booktype") %>' ID="booktype" runat="server"  ></asp:Label>
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
                                                  <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / Book No.">
                                                 <ItemTemplate>
                                                  
                                                  <asp:Label Text='<%#Convert.ToInt32(Eval("TotalBook"))%>' ID="lblPer" runat="server"  ></asp:Label>
                                              
                                                     
                                                     
                                                      </ItemTemplate>
                                                 </asp:TemplateField>
                                                     <asp:TemplateField>
                                                         <ItemTemplate>
                                                            
                                                               <asp:TextBox ID="txtb" runat="server" Visible="false" OnTextChanged="txtonChange_TextChanged" AutoPostBack="true" Width="30"  ></asp:TextBox>
                                                             <br />
                                                             <asp:HiddenField ID="hdaa" runat="server" Value='<%#Eval("RemainingStock") %>' />
                                                            <%-- <asp:Label ID="Label1" runat="server" Text='<%#Eval("RemaingLoose_V") %>'></asp:Label>--%>
                                                             <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("StockDetailsChildID_I") %>'  />
                                                             
                                                             <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Width="200px" Height="100px">
                                                                    <asp:CheckBoxList ID="ChkLooseBundleList" runat="server" RepeatColumns="7" Enabled="false"  >
                                                             </asp:CheckBoxList ></asp:Panel>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                  
                                                 </Columns>
                                                  <PagerStyle CssClass="Gvpaging" />
                                                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                                                 </asp:GridView>
                     <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="But1_Click" Text="&#2337;&#2366;&#2335;&#2366; &#2360;&#2375;&#2357; &#2325;&#2352;&#2375;&#2306; "  />
                     <asp:Button ID="Button5" runat="server" CssClass="btn" OnClick="Button5_Click"  Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375;&#2306;  "  />
                     
                </div> 

</asp:Content>

