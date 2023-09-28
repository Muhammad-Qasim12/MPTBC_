<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookSellerDistributionaNew.aspx.cs" MaintainScrollPositionOnPostback="true"  Inherits="Depo_BookSellerDistributionaNew" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            font-weight: normal;
            color: #FF0000;
        }
    </style>
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
        <h2><span>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2357;&#2367;&#2325;&#2381;&#2352;&#2375;&#2340;&#2366; / Book Seller</span></h2>
    </div>
    <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
        <div id="ExportDiv" runat="server">
            <table width="100%">
                <tr>
                    <td style="text-align: left">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2357;&#2367;&#2325;&#2381;&#2352;&#2375;&#2340;&#2366; / Book Seller </td>
                    <td>
                        <asp:DropDownList ID="ddlBookSllerName" runat="server" AutoPostBack="True" onselectedindexchanged="ddlBookSllerName_SelectedIndexChanged" Enabled="False">
                        </asp:DropDownList>
                    </td>
                    <td>&#2310;&#2352;&#2381;&#2337;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Order NO </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"  OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Enabled="False" >
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr id="a" runat="server" visible="false">
                    <td style="text-align: left">&#2346;&#2306;&#2332;&#2368;&#2351;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Reg.No. </td>
                    <td>
                        <asp:Label ID="Label6" runat="server"></asp:Label>
                    </td>
                    <td>&#2348;&#2376;&#2306;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Bank Name</td>
                    <td>
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="a1" runat="server" visible="false">
                    <td style="text-align: left"><strong>&#2337;&#2368;.&#2337;&#2368;. &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / DD No</strong> </td>
                    <td>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </td>
                    <td><strong>&#2337;&#2368;.&#2337;&#2368;. &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; /</strong>DD Date</td>
                    <td>
                        <asp:Label ID="Label5" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="a2" runat="server" visible="false">
                    <td style="text-align: left">&#2337;&#2381;&#2352;&#2366;&#2347;&#2381;&#2335; &#2352;&#2366;&#2358;&#2368; (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375;&#2306;)/Draft Amount (in Rs)</td>
                    <td>
                        <asp:Label ID="Label3" runat="server"></asp:Label>
                    </td>
                    <td>&#2337;&#2367;&#2360;&#2381;&#2325;&#2366;&#2313;&#2306;&#2335; (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375;&#2306;) /Discount&nbsp; (in Rs)</td>
                    <td>
                        <asp:Label ID="Label4" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="a11" runat="server" visible="false">
                    <td style="text-align: left">&#2325;&#2369;&#2354; &#2352;&#2366;&#2358;&#2368; </td>
                    <td>
                        <asp:Label ID="Label7" runat="server"></asp:Label>
                    </td>
                    <td>&#2337;&#2367;&#2360;&#2381;&#2325;&#2366;&#2313;&#2306;&#2335; &#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340; %</td>
                    <td>
                        <asp:Label ID="Label8" runat="server"></asp:Label>
                        %</td>
                </tr>
            </table>
        </div>
          <table width="100%">
                
                <tr>
                    <td style="text-align: center">
                        <span class="auto-style1"><strong>&nbsp;</strong></span>
                        <asp:Button ID="Button16" runat="server" CssClass="btn" OnClick="Button16_Click" Text="&#2346;&#2376;&#2325; &#2348;&#2306;&#2337;&#2354; &#2337;&#2366;&#2354;&#2375;  " Visible="false" />
                         <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button116_Click" Text="&#2354;&#2370;&#2332; &#2319;&#2325; &#2360;&#2366;&#2341; &#2348;&#2306;&#2337;&#2354; &#2337;&#2366;&#2354;&#2375;  "   Visible="false" />
                  
                          <asp:Button ID="Button7" runat="server" CssClass="btn" OnClick="Button7_Click" Text="&#2319;&#2325; &#2360;&#2366;&#2341; &#2346;&#2376;&#2325; &#2348;&#2306;&#2337;&#2354; &#2337;&#2366;&#2354;&#2375; "    />
                  
                          </td> </tr>
                
                <tr>
                    <td style="text-align: center">
                        <asp:HiddenField ID="hdnMasterId1" runat="server" />
                        <asp:HiddenField ID="HiddenField2" runat="server" />
                        <asp:HiddenField ID="HiddenField6" runat="server" />
                        <asp:HiddenField ID="hdnDetailsid" runat="server" />
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" ShowFooter="True" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Book Name/ " />
                                <asp:BoundField DataField="DestributeBook" HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2368; &#2332;&#2366;&#2344;&#2375; &#2357;&#2366;&#2354;&#2368; &#2348;&#2369;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;/No of Distribute Books " />
                                <asp:BoundField DataField="PaikBandal" HeaderText="&#2325;&#2369;&#2354; &#2346;&#2376;&#2325; &#2348;&#2339;&#2381;&#2337;&#2354; / Total  Pack Bundle" />
                                <asp:BoundField DataField="LoojBandal" HeaderText="&#2354;&#2370;&#2332; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;/ No. Of Loose Books" />
                                <asp:BoundField DataField="BundleNo_I" HeaderText="&#2348;&#2366;&#2352;&#2325;&#2379;&#2337; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2348;&#2306;&#2337;&#2354;&#2379;  &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; /No of Bundle Received by barcode" />
                                <asp:BoundField DataField="TotalBook" HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; /Distributed Books  No" />
                               
                               
                                 <asp:TemplateField HeaderText="&#2346;&#2361;&#2354;&#2366; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2366; &#2344;&#2306;&#2348;&#2352; &#2337;&#2366;&#2354;&#2375; ">
                                    <ItemTemplate>  <asp:HiddenField ID="HiddenField3" runat="server" Value='<%#Eval("TitalID") %>' />
                                        <asp:HiddenField ID="hdType" runat="server" Value='<%#Eval("IsScheme") %>' />
                                        <asp:TextBox ID="TextBox1" runat="server"   AutoPostBack="True" CssClass="txtbox" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                                        <asp:Button ID="Button14" runat="server" CssClass="btn" OnClick="Button15_Click1" Text="&#2360;&#2381;&#2335;&#2377;&#2325; &#2342;&#2375;&#2326;&#2375; " />
                                    </ItemTemplate>
                                </asp:TemplateField>

                               <%-- <asp:TemplateField HeaderText="&#2319;&#2325;&#2381;&#2360;&#2354; &#2325;&#2368; &#2347;&#2366;&#2311;&#2354; &#2309;&#2346;&#2354;&#2379;&#2337; &#2325;&#2352;&#2375;&#2306; ">
                                    <ItemTemplate>
                                        <asp:FileUpload ID="FileUpload1" runat="server" Width="142px" />
                                        <asp:Button ID="Button10" runat="server" CssClass="btn" OnClick="Button10_Click" Text="&#2309;&#2346;&#2354;&#2379;&#2337; &#2325;&#2352;&#2375;&#2306; " Width="113px" />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                              
                                <asp:TemplateField HeaderText="&#2354;&#2370;&#2332; &#2348;&#2339;&#2381;&#2337;&#2354;/Loose Bundle">
                                    <ItemTemplate>
                                        
                                        
                               <br />
                                        <asp:Button ID="Button4" runat="server" CommandArgument='<%#Eval("TitalID") %>' CssClass="btn" OnClick="Button4_Click" Text="&#2346;&#2361;&#2354;&#2375; &#2354;&#2370;&#2332; &#2348;&#2306;&#2337;&#2354; &#2348;&#2344;&#2366;&#2351;&#2375; &#2347;&#2367;&#2352; &#2311;&#2360; &#2346;&#2352; &#2325;&#2381;&#2354;&#2367;&#2325; &#2325;&#2352;&#2375;&#2306;" Width="227px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="&#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; &#2337;&#2366;&#2354;&#2375; ">
                           <ItemTemplate> 
                                 <asp:Button ID="btn12" runat="server" CssClass="btn" OnClick="btn12_Click"  Text="&#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; &#2337;&#2366;&#2354;&#2375; "  />

                           </ItemTemplate>
                       </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;">
                                    <ItemTemplate>
                                        '<%# Eval("IsScheme").ToString()=="1" ? "&#2351;&#2379;&#2332;&#2344;&#2366;"  : "&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;" %>'
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                 <asp:TemplateField HeaderText="&#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; &#2342;&#2375;&#2326;&#2375; ">
                           <ItemTemplate>
                                 <asp:Button ID="btn121" runat="server" CssClass="btn" OnClick="btn13_Click"  Text="&#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; &#2342;&#2375;&#2326;&#2375; "  />

                           </ItemTemplate>
                       </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td> </tr><asp:HiddenField ID="hdPaikBandal" runat="server" />
                <tr>
                    <td>&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button15" runat="server" CssClass="btn" OnClick="Button15_Click" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306;" />
                    </td>
                </tr>
            <asp:HiddenField ID="HiddenField4" runat="server" />
            <asp:HiddenField ID="HiddenField5" runat="server" />
            <asp:HiddenField ID="hdLosse" runat="server" />
            <asp:HiddenField ID="hdbandal" runat="server" /> </table> 
    </div>
      <div id="Div1" class="modalBackground" style="display: none;" runat="server" >
            </div>
            <div id="Div2" style="display: none;" class="popupnew1" runat="server" >
               
                <h1></h1>
                 <asp:Panel ID="Panel2" runat="server" ScrollBars="Both" Width="800px" Height="400px">
                <asp:GridView ID="GridView2" runat="server" CssClass="tab" AutoGenerateColumns="False">
                    <Columns>
                         <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                         <asp:TemplateField HeaderText="">
                                                 <ItemTemplate>
                                                     
                                                     <asp:CheckBox ID="CheckBox1" runat="server"  Checked="true" />
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                  <asp:BoundField HeaderText="&#2348;&#2339;&#2381;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; " DataField="BundleNo_I"/>
                        
                    </Columns> 
                         </asp:GridView></asp:Panel> 
                <asp:Button ID="Button8" runat="server" CssClass="btn" OnClick="Button8_Click"  Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306;"  />
                 <asp:Button ID="Button9" runat="server" CssClass="btn" OnClick="Button9_Click"  Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375;&#2306;"  />
                 </div> 
    <div id="Div7" class="modalBackground" style="display: none;" runat="server" >
            </div>
            <div id="Div8" style="display: none;" class="popupnew1" runat="server" >
                 <asp:Panel ID="Panel5" runat="server" Width="900px" ScrollBars="Both" Height="400px">
                <asp:Button ID="B13" runat="server" CssClass="btn" OnClick="B13_Click"  Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375;&#2306; " />
              <asp:GridView ID="grd15" runat="server" AutoGenerateColumns="False" CssClass="tab">
            <Columns>
                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &lt;br&gt; 1">
                    <ItemTemplate>
                       <%# Container.DataItemIndex +1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; &lt;br&gt; 2">
                     <ItemTemplate>
                         <%# Eval("Title") %>
                     </ItemTemplate>

                </asp:TemplateField>
                <%--<asp:TemplateField HeaderText="&#2346;&#2376;&#2325; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; (&#2351;&#2379;&#2332;&#2344;&#2366;) &lt;br&gt; 3">
                     <ItemTemplate>
                         <%# Eval("cnt2") %>
                     </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="&#2346;&#2376;&#2325; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2375; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;  (&#2351;&#2379;&#2332;&#2344;&#2366;) &lt;br&gt; 4">
                    <ItemTemplate>
                        <asp:Panel ID="Panel1" runat="server" Width="200px" ScrollBars="Both" Height="100px">
                       
                         <%# Eval("bundlesSY") %></asp:Panel>
                     </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="&#2354;&#2370;&#2332; &#2348;&#2306;&#2337;&#2354; &#2325;&#2366; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; <br> 5">
                    <ItemTemplate>
                       
                       <asp:Panel ID="Panel21" runat="server" Width="100px" ScrollBars="Both" Height="100px">
                         <%# Eval("bundlesYLooj") %></asp:Panel> 
                     </ItemTemplate>
                </asp:TemplateField>--%>

                
                <asp:TemplateField HeaderText="&#2346;&#2376;&#2325; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; (&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;) &lt;br&gt; 6">
                    <ItemTemplate> <%# Eval("cnt1") %></ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="&#2354;&#2370;&#2332; &#2348;&#2306;&#2337;&#2354; &#2325;&#2366; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; <br> 7">
                    <ItemTemplate>
                        <asp:Panel ID="Panel1" runat="server" Width="100px" ScrollBars="Both" Height="100px">
                       
                         <%# Eval("bundlesSLooj") %></asp:Panel>
                     </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="&#2346;&#2376;&#2325; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2375; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; (&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; ) &lt;br&gt; 8">

                    <ItemTemplate>
                     <asp:Panel ID="Panel1" runat="server" Width="200px" ScrollBars="Both" Height="100px">
                       
                         <%# Eval("bundlesS") %></asp:Panel> 
                     </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView></asp:Panel> 
                </div> 
    <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server" >
            </div>
            <div id="Messages" style="display: none;" class="popupnew1" runat="server" >
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Width="800px" Height="400px">
                  &#2354;&#2370;&#2332; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2337;&#2366;&#2354;&#2375; !
                                   <asp:Label ID="Label9" runat="server" Text="" Font-Bold="true" ></asp:Label><br />
                 <b>  &#2335;&#2379;&#2335;&#2354; &#2354;&#2370;&#2332; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; : <asp:Label ID="Label10" runat="server" Text=""></asp:Label> 
                      <br />

                    <asp:GridView ID="grdPrinterBundleDetails" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="StockDetailsChildID_I" >
                                                 <Columns>
                                                  


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
                     </asp:Panel> 
            </div>
      <div id="Div11" class="modalBackground" style="display: none;" runat="server" >
            </div>
            <div id="Div12" style="display: none;" class="popupnew1" runat="server" >

               <table width="100%">
                    <tr><td colspan="2">&#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; &#2337;&#2366;&#2354;&#2375; &#2332;&#2376;&#2360;&#2375; 123456,1425848,124563
                        <br />
                        <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
                        </td></tr>
                    <tr><td>&#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352;


                        </td><td>
                        <asp:TextBox ID="TextBox1" runat="server" Height="162px" TextMode="MultiLine" Width="631px"></asp:TextBox>
                        </td></tr>
                    <tr><td colspan="2">
                        <asp:Button ID="btn12_1" runat="server" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; " OnClick="btn12_1_Click" />
&nbsp;<asp:Button ID="btn12_2" runat="server" CssClass="btn" Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375;&#2306; " OnClick="btn12_2_Click" />
                        </td></tr>
                </table>
                </div> 
      <div id="Div5" class="modalBackground" style="display: none;" runat="server" >
            </div>
            <div id="Div6" style="display: none;" class="popupnew1" runat="server" >
               
             
                
                 <asp:Panel ID="Panel4" runat="server" ScrollBars="Both" Width="800px" Height="400px">
                   <asp:Button ID="Button13" runat="server" CssClass="btn" OnClick="Button13_Click"  Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375;&#2306;"  />
                     <br />
                          <asp:GridView ID="GridView4" runat="server" CssClass="tab" AutoGenerateColumns="False" DataKeyNames="BundleNo_I" OnSelectedIndexChanged="GridView4_SelectedIndexChanged">
                    <Columns>
                         <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                          <asp:BoundField HeaderText="&#2348;&#2339;&#2381;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; " DataField="BundleNo_I"/>
                  
                        <asp:CommandField HeaderText="Delete Bandel" SelectText="Delete" ShowSelectButton="True" />
                        
                    </Columns> 
                         </asp:GridView>
               
                    <br />
                     <b> &#2360;&#2381;&#2335;&#2377;&#2325; &#2350;&#2375;&#2306; &#2344;&#2361;&#2368;&#2306; &#2350;&#2367;&#2354;&#2344;&#2375; &#2357;&#2366;&#2354;&#2375; &#2348;&#2306;&#2337;&#2354; : 
                         <asp:Label ID="Label12" runat="server" Text=""></asp:Label></b>
                     </asp:Panel> 
             </div> 



      <div id="Div3" class="modalBackground" style="display: none;" runat="server" >
            </div>
            <div id="Div4" style="display: none;" class="popupnew1" runat="server" >

               <table width="100%">
                    <tr><td colspan="2">&#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; &#2337;&#2366;&#2354;&#2375; &#2332;&#2376;&#2360;&#2375; 123456,1425848,124563
                        <br />
                        <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
                        </td></tr>
                    <tr><td>&#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352;


                        </td><td>
                        <asp:TextBox ID="TextBox2" runat="server" Height="162px" TextMode="MultiLine" Width="631px"></asp:TextBox>
                        </td></tr>
                    <tr><td colspan="2">
                        <asp:Button ID="Button3" runat="server" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; " OnClick="Button3_Click" />
&nbsp;<asp:Button ID="Button6" runat="server" CssClass="btn" Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375;&#2306; " OnClick="Button6_Click" />
                        </td></tr>
                </table>
                </div> 
              
</ContentTemplate>
</asp:UpdatePanel> 
</asp:Content>

