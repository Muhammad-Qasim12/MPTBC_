<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookSellerDistribution.aspx.cs" Inherits="Depo_BookSellerDistribution" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box">
<asp:HiddenField ID="hdnOrderid" runat="server" />
<asp:HiddenField ID="hdnMasterId1" runat="server" />
        <asp:HiddenField ID="HiddenField3" runat="server" />
        <asp:HiddenField ID="HiddenField2" runat="server" />
        <div class="card-header">
            <h2>
                <span>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2357;&#2367;&#2325;&#2381;&#2352;&#2375;&#2340;&#2366; / Book Seller</span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
        <table width="100%">
             <tr>
                    <td colspan="4">    <asp:Label ID="Label9" runat="server" ></asp:Label></td> </tr> 
        <tr>
                    <td style="text-align: left">
                        &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2357;&#2367;&#2325;&#2381;&#2352;&#2375;&#2340;&#2366; / Book Seller 
                    </td> <td><asp:DropDownList ID="ddlBookSllerName" runat="server" 
                            AutoPostBack="True" 
                            onselectedindexchanged="ddlBookSllerName_SelectedIndexChanged"></asp:DropDownList> </td>
            <td>&#2310;&#2352;&#2381;&#2337;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Order NO </td><td><asp:DropDownList ID="DropDownList1" runat="server" 
                            AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" 
                           ></asp:DropDownList></td>

                </tr>
        <tr id="a" runat="server"  visible="false" >
                    <td style="text-align: left"> &#2346;&#2306;&#2332;&#2368;&#2351;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Reg.No.
                       </td> <td> <asp:Label ID="Label6" runat="server"></asp:Label>
                        
                    </td>
            <td>&#2348;&#2376;&#2306;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Bank Name</td><td>
                    <asp:TextBox ID="Label2" runat="server" CssClass="txtbox" Width="150px"></asp:TextBox>
                    </td>

                </tr>
        <tr id="a1" runat="server" visible="false">
                    <td style="text-align: left"> <strong>&#2337;&#2368;.&#2337;&#2368;. &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / DD No</strong>
                       </td> <td>
                        <asp:TextBox ID="Label1" runat="server" CssClass="txtbox" Width="150px"></asp:TextBox>
                        
                    </td>
            <td> <strong>&#2337;&#2368;.&#2337;&#2368;. &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; /</strong>DD Date</td><td>
                    <asp:TextBox ID="Label5" runat="server" CssClass="txtbox" Width="150px"></asp:TextBox>
                   <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                                            TargetControlID="Label5" Format="dd/MM/yyyy">
        </cc1:CalendarExtender>
                
                                                                                                                         </td>
              
                        
                </tr>
        <tr  id="a2" runat="server" visible="false">
                    <td style="text-align: left">
                       &#2337;&#2381;&#2352;&#2366;&#2347;&#2381;&#2335; &#2352;&#2366;&#2358;&#2368; (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375;&#2306;)/Draft Amount (in Rs)</td> <td>
                        <asp:TextBox ID="Label3" runat="server" CssClass="txtbox" Width="150px"></asp:TextBox>
                    </td>
            <td>&#2337;&#2367;&#2360;&#2381;&#2325;&#2366;&#2313;&#2306;&#2335; (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375;&#2306;) /Discount&nbsp; (in Rs)</td><td>
                    <asp:Label ID="Label4" runat="server" ></asp:Label>
                    </td>

                </tr>
      
        <tr  id="a11" runat="server" >
                    <td style="text-align: left">
                        &#2325;&#2369;&#2354; &#2352;&#2366;&#2358;&#2368; / Net Amount</td> <td>
                        <asp:Label ID="Label10" runat="server" ></asp:Label>
                    </td>
            <td>&nbsp;</td><td>
                    &nbsp;</td>

                </tr>
      
                </table>
      
            <table width="100%">
                
                <tr>
                    <td style="text-align: center">
                       
                   <asp:GridView ID="grnMain" runat="server" AutoGenerateColumns="False" 
                    CssClass="tab" DataKeyNames="BookSelleDemandTrNo_I" OnRowDeleting="grnMain_RowDeleting" OnSelectedIndexChanged="grnMain_SelectedIndexChanged" >
                    <Columns>
                       <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/S.No">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     <asp:HiddenField ID="BookSelleDemandTrNo_I" 
                                                         runat="server" Value='<%# Eval("BookSelleDemandTrNo_I") %>' />
                                                           <asp:HiddenField ID="HiddenField1" runat="server"  Value='<%# Eval("TitleID_i") %>' />
                                                               <asp:HiddenField ID="hdnUser_ID_I" runat="server"  Value='<%# Eval("User_ID_I") %>' />
                                                            <asp:HiddenField ID="hdnDetailsid" runat="server" />
                                                            <asp:HiddenField ID="hdnOrderid" runat="server" Value='<%#Eval("OrderNo") %>' />
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                             
                      
                                              <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; /Title" />
                       <%-- <asp:BoundField DataField="BDate_D" HeaderText="&#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/Date" />--%>
                        
                       <%-- <asp:BoundField DataField="MediunNameHindi_V" HeaderText="&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;/Medium " />--%>
                        <asp:BoundField DataField="Rate_N" HeaderText="&#2350;&#2370;&#2354;&#2381;&#2351;/Rate" />
                        <asp:BoundField DataField="TotalDemand" HeaderText="&#2350;&#2366;&#2306;&#2327;/Demand" />
                         <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2352;&#2366;&#2358;&#2367; ">
                                                 <ItemTemplate>
                                                                    <%#Convert.ToInt32(Eval("TotalDemand"))*Convert.ToInt32(Eval("Rate_N"))%>
                                                 </ItemTemplate>

                         </asp:TemplateField> 
                         <asp:BoundField DataField="NoOfBookSamanya" HeaderText="&#2360;&#2381;&#2335;&#2377;&#2325; &#2350;&#2375;&#2306; &#2313;&#2346;&#2354;&#2357;&#2381;&#2343; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; " />
                        <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375;  ">
                                                 <ItemTemplate>
                          <asp:Button ID="deleteButton" runat="server" CommandArgument='<%# Eval("BookSelleDemandTrNo_I") %>' Text="&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375;" OnClick="btDelete" CssClass="btn"
OnClientClick="return confirm('Are you sure you want to delete this user?');" />
                                                     </ItemTemplate> </asp:TemplateField> 

                          <asp:TemplateField HeaderText="&#2350;&#2366;&#2306;&#2327; &#2350;&#2375;&#2306; &#2360;&#2306;&#2358;&#2379;&#2343;&#2344; &#2325;&#2352;&#2375;&#2306; ">
                                                 <ItemTemplate>
                                                     <asp:Button ID="Button7" runat="server" CssClass="btn " Text="&#2360;&#2306;&#2358;&#2379;&#2343;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; " CommandArgument='<%# Eval("BookSelleDemandTrNo_I") %>' OnClick="btnChange" />
                                                     </ItemTemplate>

                          </asp:TemplateField> 
                        <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2332;&#2379;&#2396;&#2375; ">
                                                 <ItemTemplate>
                                                     <asp:Button ID="Button8" runat="server" CssClass="btn " Text="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2332;&#2379;&#2396;&#2375; " CommandArgument='<%# Eval("BookSelleDemandTrNo_I") %>' OnClick="btnChange1" />
                                                     </ItemTemplate>

                          </asp:TemplateField>
                             </Columns>
                </asp:GridView>
                    </td>
                </tr>
                 <tr>
                    
                    <td style="text-align: center">

                       

                         <asp:Button ID="Button1" runat="server" Text="&#2309;&#2344;&#2369;&#2350;&#2379;&#2342;&#2344; &#2325;&#2352;&#2375;&#2306; " CssClass="btn" OnClick="Button1_Click" Visible="false"  />
                          &nbsp;
                         <asp:Button ID="Button2" runat="server" Text="&#2310;&#2352;&#2381;&#2337;&#2352; &#2352;&#2342;&#2381;&#2342; &#2325;&#2352;&#2375;&#2306; " CssClass="btn" Visible="false" OnClick="Button2_Click"  />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:Button ID="Button11" runat="server" Text="&#2330;&#2366;&#2354;&#2366;&#2344; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2325;&#2352;&#2375;&#2306; " CssClass="btn" Visible="False" OnClick="Button11_Click"  />
                    </td> </tr> 
            </table>
        </div>
          <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server" >
            </div>
            <div id="Messages" style="display: none;" class="popupnew1" runat="server" >
               
        <table width="100%">  <tr  id="a3" runat="server" >
                    <td style="text-align: left">
                        <asp:Label ID="Label7" runat="server" Text="&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; &#2310;&#2352;&#2381;&#2337;&#2352; &#2352;&#2342;&#2381;&#2342; &#2325;&#2352;&#2344;&#2375; &#2325;&#2366; "></asp:Label>
                    </td> <td colspan="3">
                        <asp:TextBox ID="Label8" runat="server"  Height="45px" TextMode="MultiLine" Width="435px"></asp:TextBox>
                    </td>

                </tr><tr runat="server"  ><td colspan="2"> <asp:Button ID="Button3" runat="server" Text="&#2360;&#2375;&#2357; &#2325;&#2352;&#2375; " CssClass="btn"   /> <asp:Button ID="Button4" runat="server" Text="&#2348;&#2344;&#2381;&#2342; &#2325;&#2352;&#2375;&#2306; " CssClass="btn"  OnClick="Button4_Click"  /></td> </tr> </table></div> 
    </div>
    <div id="Div1" class="modalBackground" style="display: none;" runat="server" >
            </div>
            <div id="Div2" style="display: none;" class="popupnew1" runat="server" >
               <table>
            <tr>
            <td>&#2325;&#2376;&#2358; &#2350;&#2375;&#2350;&#2379; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Cash Memo No :</td> <td> <asp:TextBox ID="txtChalanNo" runat="server" MaxLength="10"></asp:TextBox> </td> <td>&#2325;&#2376;&#2358; &#2350;&#2375;&#2350;&#2379; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/ Cash Memo Date </td> <td><asp:TextBox ID="txtChalanDate" runat="server" ></asp:TextBox></td>
            </tr>
             <tr>
            <td>&#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Bilti No  :</td> <td> <asp:TextBox ID="txtGRNO" MaxLength="15" runat="server"></asp:TextBox> </td> <td>&#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/ Bilti Date </td> <td><asp:TextBox ID="txtGRNDate" runat="server" ></asp:TextBox></td>
            </tr>
            <tr>
            <td> &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2325;&#2352;&#2381;&#2340;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; /Receiver Name :</td> <td> <asp:TextBox ID="txtReceiverName" onkeypress='javascript:tbx_fnAlphaOnly(event, this);' MaxLength="50" runat="server"></asp:TextBox> </td> <td>&#2337;&#2381;&#2352;&#2366;&#2311;&#2357;&#2352; &#2325;&#2366; &#2350;&#2379;&#2348;&#2366;&#2312;&#2354; &#2344;&#2306;&#2348;&#2352; /Driver Mobile No </td> <td><asp:TextBox ID="txtDriverMobileNo" onkeypress='javascript:tbx_fnInteger(event, this);' MaxLength="10" runat="server" ></asp:TextBox></td>
            </tr>
            <tr>
            <td>&#2335;&#2381;&#2352;&#2325; &#2344;&#2306;&#2348;&#2352; /Truck No :</td> <td> <asp:TextBox ID="txtTrucko" MaxLength="10" runat="server"></asp:TextBox> </td> <td>&#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368;/Remark :</td> <td><asp:TextBox ID="txtRemark" TextMode="MultiLine" runat="server" onkeypress='javascript:tbx_fnAlphaOnly(event, this);' MaxLength="200" ></asp:TextBox></td>
            </tr>
          
            <tr><td><asp:Button Text="Save" runat="server" OnClick="btnSave" ID="btnSaveMasterData" CssClass="btn" />   &nbsp;<asp:Button ID="Button6" runat="server" Text="&#2348;&#2344;&#2381;&#2342; &#2325;&#2352;&#2375;&#2306; " CssClass="btn"  OnClick="Button5_Click"  />  </td> </tr>
            
            
            </table>
            <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                                            TargetControlID="txtChalanDate" Format="dd/MM/yyyy">
        </cc1:CalendarExtender>
        <cc1:CalendarExtender ID="txtDate_CalendarExtender1" runat="server" 
                                            TargetControlID="txtGRNDate" Format="dd/MM/yyyy">
        </cc1:CalendarExtender>
        </div>

     <div id="Div3" class="modalBackground" style="display: none;" runat="server" >
            </div>
    <div id="Div4"  style="display: none;" class="popupnew1" runat="server">
        <table width="100%" >
            <tr><td>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </td><td><asp:Label ID="lblbookName" runat="server" Text=""></asp:Label> </td><td>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; </td><td><asp:Label ID="lblNo" runat="server" Text=""></asp:Label></td></tr>
            <tr><td> &#2344;&#2357;&#2368;&#2344; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;  </td> <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> </td><td>
                    <asp:Button ID="Button5" runat="server" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; " OnClick="btnSave1" /></td><td><asp:Button ID="Button8" runat="server" CssClass="btn" Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375;&#2306;  " OnClick="btnClose"  /></td></tr>
        </table>
            </div>
     <div id="Div5" class="modalBackground" style="display: none;" runat="server" >
            </div>
    <div id="Div6"  style="display: none;" class="popupnew1" runat="server">
        <table width="100%" >
            <tr><td>&#2350;&#2366;&#2343;&#2381;&#2351;&#2350; &#2325;&#2366; &#2344;&#2366;&#2350;  </td><td> <asp:DropDownList ID="ddlMedium" runat="server" CssClass="txtbox" ></asp:DropDownList></td><td>  </td><td><asp:DropDownList ID="ddlClass" runat="server" CssClass="txtbox" OnSelectedIndexChanged="ddlMediumChange" AutoPostBack="true" ></asp:DropDownList> </td></tr>
            <tr><td> &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; : <asp:DropDownList ID="ddlTitle" runat="server" CssClass="txtbox"></asp:DropDownList> 
                    </td>
                <td> &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;  </td> <td>

                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox> </td><td> <asp:Button ID="Button9" runat="server" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; " OnClick="btnSave2" /><asp:Button ID="Button10" runat="server" CssClass="btn" Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375;&#2306;  " OnClick="btnClose1"  /></td></tr>
        </table>
            </div>
</asp:Content>

