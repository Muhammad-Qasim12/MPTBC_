<%@ Page  Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DPT09_BookSelleDemandformat.aspx.cs" Inherits="Depo_DPT09_BookSelleDemandformat" MaintainScrollPositionOnPostback="true" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 40px;
        }
        .auto-style2 {
            color: #FF0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--<asp:UpdatePanel ID="up1" runat="server">
<ContentTemplate>--%>
<%--  <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up1">
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
                             
                                <h2>&nbsp; <span>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2357;&#2367;&#2325;&#2381;&#2352;&#2375;&#2340;&#2366; &#2350;&#2377;&#2327; &#2346;&#2381;&#2352;&#2340;&#2381;&#2352;&#2325; / Book Seller Demand Form</span></h2>
                            </div>
                            <div style="padding:0 10px;">
                               
                            <table width="100%">
                                 <tr>
                                    <td  colspan="2">
                                        <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="Red"></asp:Label>
                                        <a href="bookSellerDemand.xlsx" target="_blank" >एक्सल फाइल डाउनलोड करें </a>
                                       </td>
                                    
                                 
                                   
                                </tr>
                                <tr>
                                    <td style="height: 32px">
                                        &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2357;&#2367;&#2325;&#2381;&#2352;&#2375;&#2340;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; /Bookseller Name</td>
                                    <td style="height: 32px">
                                        <asp:DropDownList ID="ddlBookSeller" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBookSeller_SelectedIndexChanged">
                                        </asp:DropDownList>
                                 
                                    </td>
                                </tr>
                                 <tr>
                                     <td style="height: 32px">&#2310;&#2352;&#2381;&#2337;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Order Date&nbsp; <span>*</span></td>
                                     <td style="height: 32px">
                                         <asp:TextBox ID="txtDate" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                                         <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDate">
                                         </cc1:CalendarExtender>
                                     </td>
                                 </tr>
                                <tr>
                                    <td style="height: 32px">
                                        &#2321;&#2352;&#2381;&#2337;&#2352; &#2344;&#2306;&#2348;&#2352; / Order No.</td>
                                    <td style="height: 32px">
                                        <asp:TextBox ID="TextBox1" runat="server" Enabled="False" MaxLength="40" CssClass="txtbox reqirerd"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 32px">
                                        &#2337;&#2367;&#2346;&#2379; <span>/ Depot *</span></td>
                                    <td style="height: 32px">
                                        <asp:DropDownList ID="ddlDepo" runat="server" CssClass="txtbox reqirerd">
                                            <asp:ListItem>Select..</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td style="height: 32px">
                                        &#2350;&#2366;&#2343;&#2381;&#2351;&#2350; / Medium&nbsp; <span>*</span></td>
                                    <td style="height: 32px">
                                        <asp:DropDownList ID="ddlMedium" runat="server" >
                                            <asp:ListItem>Select..</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr><tr>
                                 <td>&#2325;&#2325;&#2381;&#2359;&#2366; / Class <span>*</span>	
                                         </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCls" runat="server"  
                                                AutoPostBack="True" onselectedindexchanged="ddlCls_SelectedIndexChanged">
                                                <asp:ListItem Value="0">Select..</asp:ListItem>
                                                  <asp:ListItem Value="3">All</asp:ListItem>
                                                <asp:ListItem Value="1">1-8</asp:ListItem>
                                                <asp:ListItem Value="2">9-12</asp:ListItem>
                                            </asp:DropDownList>
                                            </td>
                                    </tr>
                                <tr>
                                 <td>UTR /DD No</td>
                                        <td>
                                        <asp:TextBox ID="txtDdno" runat="server" MaxLength="20" CssClass="txtbox "></asp:TextBox>
                                    </td>
                                    </tr>
                                <tr>
                                 <td>UTR /DD Date</td>
                                        <td>
                                        <asp:TextBox ID="txtChekDate" runat="server" MaxLength="10" CssClass="txtbox "></asp:TextBox>
                                         <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtChekDate" Format="dd/MM/yyyy">
                                         </cc1:CalendarExtender>
                                       
                                    </td>
                                    </tr>
                                <tr>
                                 <td>&#2348;&#2376;&#2306;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;	
                                         /Bank Name</td>
                                        <td>
                                       <%-- <asp:TextBox ID="txtBank" runat="server" MaxLength="40"  
                                                onkeypress="javascript:tbx_fnAlphaNumericOnly(event, this)" CssClass="txtbox "></asp:TextBox>--%>
                                            <asp:DropDownList ID="DDLBank" runat="server"  
                                                AutoPostBack="false"  >
                                                <asp:ListItem Value="0">Select..</asp:ListItem>
                                            </asp:DropDownList>
                                    </td>
                                    </tr>
                                <tr>
                                 <td class="auto-style1"> UTR /DD Amount</td>
                                        <td class="auto-style1">
                                        <asp:TextBox ID="txtAmount" runat="server" MaxLength="12"  
                                                onkeypress="javascript:tbx_fnAlphaNumericOnly(event, this)" CssClass="txtbox "></asp:TextBox>
                                    </td>
                                    </tr>
                                 <tr>
                                 <td>&#2346;&#2367;&#2331;&#2354;&#2366; &#2348;&#2325;&#2366;&#2351;&#2366;  </td>
                                        <td>
                                            <asp:Label ID="Label11" runat="server" Text=""></asp:Label>
                                      
                                    </td>
                                    </tr>
                                 <tr>
                                     <td>Upload Excel</td>
                                     <td>
                                         <asp:FileUpload ID="FileUpload1" runat="server" />
                                         <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" CssClass="btn" Text="Upload Excel" />
                                     </td>
                                 </tr>
                                <tr>
                                    <td colspan="2"><span class="auto-style2">&#2344;&#2379;&#2335; :-&nbsp; &#2360;&#2350;&#2381;&#2350;&#2366;&#2344;&#2368;&#2351; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2357;&#2367;&#2325;&#2381;&#2352;&#2375;&#2340;&#2366; , &#2310;&#2346;&#2325;&#2379; &#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2357;&#2352;&#2381;&#2340;&#2350;&#2366;&#2344; &#2360;&#2381;&#2335;&#2377;&#2325; &#2342;&#2367;&#2326; &#2352;&#2361;&#2366; &#2361;&#2376; &#2332;&#2348; &#2310;&#2346; &#2337;&#2367;&#2346;&#2379; &#2350;&#2375;&#2306; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2354;&#2375;&#2344;&#2375; &#2346;&#2361;&#2369;&#2330;&#2375;&#2327;&#2375; &#2340;&#2348; &#2360;&#2381;&#2335;&#2377;&#2325; &#2350;&#2375;&#2306; &#2310;&#2306;&#2358;&#2367;&#2325;
                                        <br />
                                        <br />
                                        &#2346;&#2352;&#2367;&#2357;&#2352;&#2381;&#2340;&#2344; &#2360;&#2306;&#2349;&#2357; &#2361;&#2376; ! &#2337;&#2367;&#2346;&#2379; &#2350;&#2375;&#2306; &#2313;&#2346;&#2354;&#2348;&#2381;&#2343; &#2360;&#2381;&#2335;&#2377;&#2325; &#2325;&#2375; &#2310;&#2343;&#2366;&#2352; &#2346;&#2352; &#2361;&#2368; &#2310;&#2346;&#2325;&#2379; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2375; &#2342;&#2368; &#2332;&#2366;&#2319;&#2327;&#2368; !</span><br /> </td>
                                </tr>
                                <tr>
                                    
                                 <td  colspan="2" width="100%">
                                     <asp:GridView ID="GrdBookDemand" runat="server" AutoGenerateColumns="False" 
                                         class="tab" onselectedindexchanged="GrdBookDemand_SelectedIndexChanged">
                                         <Columns>
                                              <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/S.No">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                             <asp:BoundField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325;/ Title " DataField="TitleHindi_V" />
                                              <asp:BoundField DataField="BookNumber" HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2339;&#2381;&#2337;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " />
                                              <asp:TemplateField HeaderText="&#2350;&#2370;&#2354;&#2381;&#2351;/Rate">
                                                  <ItemTemplate>
                                                      <asp:Label ID="Label3" runat="server" Text='<%# Eval("Rate_N") %>'></asp:Label>
                                                  </ItemTemplate>
                                              </asp:TemplateField>
                                              <asp:BoundField DataField="NoOfBookSamanya" HeaderText="&#2360;&#2381;&#2335;&#2377;&#2325; &#2350;&#2375;&#2306; &#2313;&#2346;&#2354;&#2348;&#2381;&#2343; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " />
                                             <asp:TemplateField HeaderText="&#2350;&#2366;&#2306;&#2327; /Demand">
                                                 <ItemTemplate>
                                                     <asp:TextBox ID="txtdemand" runat="server" CssClass="txtbox "  
                                                         onkeyup='javascript:tbx_fnSignedNumericCheck(this);' MaxLength="6"
                                                         Text='<%# Eval("TotalDemand") %>' AutoPostBack="True" 
                                                         ontextchanged="txtdemand_TextChanged" ></asp:TextBox><asp:HiddenField ID="hTitlID" 
                                                         runat="server" Value='<%# Eval("TitleID_I") %>'  />
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                              <asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2366;&#2360; &#2309;&#2350;&#2366;&#2313;&#2306;&#2335;/Gross Amount (in Rs.)">
                                                  <ItemTemplate>
                                                      <asp:Label ID="Label1" runat="server"></asp:Label>
                                                  </ItemTemplate>
                                              </asp:TemplateField>
                                              <asp:TemplateField HeaderText="&#2344;&#2375;&#2335; &#2309;&#2350;&#2366;&#2313;&#2306;&#2335;/Net Amount (in Rs.)">
                                                  <ItemTemplate>
                                                      <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                                  </ItemTemplate>
                                              </asp:TemplateField>
                                         </Columns>
                                     </asp:GridView>
                                    
                                         </td>
                                    </tr>
                               
                                <tr  style="display:none" runat="server" id="a" >
                               
            <td colspan="2">
                &#2327;&#2381;&#2352;&#2366;&#2360; &#2309;&#2350;&#2366;&#2313;&#2306;&#2335;/Gross Amount (in Rs.) : <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
&nbsp;&nbsp; &#2344;&#2375;&#2335; &#2309;&#2350;&#2366;&#2313;&#2306;&#2335; /Net Amount (in Rs.): &nbsp;&nbsp;<asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                                &nbsp;&#2352;&#2369;&#2346;&#2351;&#2375;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - (<asp:Label ID="Label10" runat="server" Visible="False"></asp:Label>
                &nbsp;) </td>
        </tr>
                                                               
        </tr>
                                <tr>
                               
            <td colspan="2">
                <asp:Button ID="btn_add" runat="server" CssClass="btn" onclick="btn_add_Click"  Text="Add" />
                <asp:HiddenField ID="HiddenField1" runat="server" />
                                    </td>
                                    <tr>
                                        <td colspan="2">
                                            <asp:GridView ID="grnMain" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="BookSelleDemandTrNo_I" onselectedindexchanged="grnMain_SelectedIndexChanged">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/S.No.">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                            <asp:HiddenField ID="BookSelleDemandTrNo_I" runat="server" Value='<%# Eval("BookSelleDemandTrNo_I") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="BDate_D" HeaderText="&#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/Date" />
                                                    <asp:BoundField DataField="DepoName_V" HeaderText="&#2337;&#2367;&#2346;&#2379; /Depot" />
                                                    <asp:BoundField DataField="MediunNameHindi_V" HeaderText="&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;/Medium" />
                                                    <asp:BoundField DataField="Classdet_V" HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366;/Class" />
                                                    <asp:BoundField DataField="TotalDemand" HeaderText="&#2350;&#2366;&#2306;&#2327;/Demand" />
                                                    <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325;/Title" />
                                                    <asp:CommandField ShowSelectButton="True" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr id="qq" runat="server" style="display:none ">
                                        <td colspan="2">&#2327;&#2381;&#2352;&#2366;&#2360; &#2309;&#2350;&#2366;&#2313;&#2306;&#2335;/Gross Amount (in Rs.) :
                                            <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                                            &nbsp;&nbsp; &#2344;&#2375;&#2335; &#2309;&#2350;&#2366;&#2313;&#2306;&#2335;/Net Amount(in Rs.) : &nbsp;&nbsp;<asp:Label ID="Label7" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Button ID="btn_add0" runat="server" CssClass="btn" onclick="btn_add0_Click" Text="&#2321;&#2352;&#2381;&#2337;&#2352; &#2349;&#2375;&#2332;&#2375; " Visible="False" OnClientClick="return ValidateAllTextForm();" />
                                        </td>
                                    </tr>
        </tr>
    </table>
                            
                            </div> </div> 
                             <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server" >
            </div>
            <div id="Messages" style="display: none;" class="popupnew" runat="server" >
                <h2>
                  
                </h2>
                <div class="msg MT10">
                    <p>
                   &#2310;&#2346; &#2325;&#2366; &#2321;&#2352;&#2381;&#2337;&#2352; &#2344;&#2306;&#2348;&#2352; (  <asp:Label ID="Label9" runat="server" Text=""></asp:Label>) &#2360;&#2350;&#2381;&#2348;&#2306;&#2343;&#2367;&#2340; &#2337;&#2367;&#2346;&#2379; &#2325;&#2379; &#2349;&#2375;&#2332;&#2375; &#2332;&#2366; &#2330;&#2369;&#2325;&#2366; &#2361;&#2376; &#2325;&#2371;&#2346;&#2351;&#2366; (<asp:Label ID="Label8" runat="server" Text=""></asp:Label>) &#2325;&#2368; &#2337;&#2368;.&#2337;&#2368;. &#2337;&#2367;&#2346;&#2379; &#2350;&#2375;&#2306; &#2346;&#2381;&#2352;&#2360;&#2381;&#2340;&#2369;&#2340; &#2325;&#2352;&#2375; |

                    </p>
                </div>
                <asp:Button ID="Button1" runat="server" Text="&#2310;&#2327;&#2375; &#2348;&#2338;&#2375; " CssClass="btn"  onclick="Button1_Click" />
            </div>
    <div id="Div1" class="modalBackground" style="display: none;" runat="server" >
            </div>
            <div id="Div2" style="display: none;" class="popupnew" runat="server" >
                <h2>
                   <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label><br />
                     <asp:Button ID="Button2" runat="server" Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375;&#2306; " CssClass="btn"  onclick="Button11_Click" />
                </h2>
                <div class="msg MT10"></div> </div> 
   <%-- </ContentTemplate>

    </asp:UpdatePanel> --%>
</asp:Content>

