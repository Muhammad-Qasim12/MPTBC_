<%@ Page Title="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; 25 % &#2327;&#2339;&#2344;&#2366; &#2352;&#2360;&#2368;&#2342; / Book's 25% Calculation Recipt" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DPT012_25PercentageReport.aspx.cs" Inherits="Depo_DPT012_25PercentageReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
                    <div class="card-header">
                        
                        <h2>
                            <span>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; 25 % &#2327;&#2339;&#2344;&#2366; &#2352;&#2360;&#2368;&#2342; / Book's 25% Calculated Receipt </h2></span>
                    </div>
                    <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
                        <table width="100%">
                            <tr >
                                <td id="Td6"  runat="server" colspan="4">
                                     <asp:Label ID="LblAcYear" runat="server" Width="180px">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; <br /> Academic Year:</asp:Label>
                            <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox" AutoPostBack="True" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged">
                            </asp:DropDownList>
                                    &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352;/ &#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; :&nbsp;
                                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="txtbox" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>  </tr> 
                            <tr  runat="server" >
                                <td id="Td1" runat="server" colspan="4">
                                    <asp:Panel ID="Panel1" runat="server" Height="400px" ScrollBars="Both" Width="1200px">
                                        <asp:GridView ID="GrdMain" runat="server" AutoGenerateColumns="False" 
                                        CssClass="tab" DataKeyNames="StockReceiveEntryID_I" 
                                        onselectedindexchanged="GrdMain_SelectedIndexChanged" OnPageIndexChanging="GrdMain_PageIndexChanging" PageSize="20">
                                            <Columns>
                                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Sr.No.">
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325;/&#2337;&#2367;&#2346;&#2379;  &#2325;&#2366; &#2344;&#2366;&#2350; / Printer Name" DataField="NameofPress_V" />
                                                <asp:BoundField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Chalan No." DataField="ChallanNo_V" />
                                                <asp:BoundField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Chalan Date" DataField="ChallanDate_D" />
                                                <asp:CommandField SelectText="&#2327;&#2339;&#2344;&#2366; &#2352;&#2360;&#2368;&#2342; &#2332;&#2366;&#2352;&#2368; &#2325;&#2352;&#2375; " ShowSelectButton="True" />
                                            </Columns>
                                            <PagerStyle CssClass="Gvpaging" />
                                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <div id="a" runat="server" visible="false" > 
                            <tr>
                                <td >
                                    <span>&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2319;&#2357;&#2306; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </span></td>
                                <td >
                                    <span>
                                    <asp:Label ID="lblChalan" runat="server" CssClass="txtbox" Text=""></asp:Label>
                                    <asp:Label ID="lblChalandate" runat="server" CssClass="txtbox"></asp:Label>
    </span>
                                </td>
                                <td colspan="2" >
                            <span>
                                    <asp:Label ID="lblOrderDate" runat="server" CssClass="txtbox" Visible="False"></asp:Label>
    </span>
                                </td>
                            </tr>
                            <tr >
                                <td  runat="server">
                                   &#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2344;&#2306;&#2348;&#2352;</td>
                                <td  runat="server">
                                    <asp:Label ID="lblGrNo" runat="server" CssClass="txtbox" Text="Label"></asp:Label>
                                    <span>
                                    <asp:Label ID="lblorderNo" runat="server" CssClass="txtbox" Visible="False"></asp:Label>
    </span>
                                </td>
                                <td  runat="server">
                                   &#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </td>
                                <td >
                                    <asp:Label ID="lblbGrDate" runat="server" CssClass="txtbox" Text="Label"></asp:Label></td>
                            </tr>
                        
                         
                        
                           
                        
                            <tr >
                                <td  runat="server">
                                    &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </td>
                                <td  runat="server" colspan="3">
                       
                                    <asp:TextBox ID="txtReceieveddate" runat="server" MaxLength="14"  
                                        CssClass="txtbox reqirerd" Enabled="false" ></asp:TextBox>
    <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtReceieveddate" Format="dd/MM/yyyy">
        </cc1:CalendarExtender>
       
                                    </td>
                            </tr>
                              
                            <tr >
                                <td  runat="server">
                                    &#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2379; &#2349;&#2375;&#2332;&#2375; &#2327;&#2351;&#2375; &#2346;&#2340;&#2381;&#2352; &#2325;&#2366; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; </td>
                                <td  runat="server">
                            <span>
                                    <asp:TextBox ID="txtLetterNo" runat="server" MaxLength="11"   
                                        CssClass="txtbox " ></asp:TextBox>
    </span>
                                </td>
                                <td  runat="server">
                          &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </td>
                                <td >
                            
                                    <asp:TextBox ID="txtLetterDate" runat="server" MaxLength="10"  
                                        CssClass="txtbox " ></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtLetterDate" Format="dd/MM/yyyy">
        </cc1:CalendarExtender>
           
                    </td>
                            </tr>
                        <tr >
                                <td id="Td2"  runat="server" colspan="4">
                                    <asp:GridView ID="grdBookDetails" runat="server" AutoGenerateColumns="False" 
                                        CssClass="tab">
                                        <Columns>
                                            
                                             <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </br> 1 ">
                                                <ItemTemplate>
                                                 <%#Eval("TitleHindi_V")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; &lt;/br&gt; 2">
                                                 <ItemTemplate>
                                                     <%#Eval("bookType")%>
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="&#2310;&#2346;&#2325;&#2375; &#2330;&#2366;&#2354;&#2366;&#2344; &#2346;&#2340;&#2381;&#2352; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2349;&#2375;&#2332;&#2375;  &#2327;&#2351;&#2375; &#2325;&#2369;&#2354; &#2348;&#2339;&#2381;&#2337;&#2354; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; &lt;/br&gt; 3">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" runat="server" Text=' <%#Eval("PacketsSendAsPerChallan")%>'></asp:Label>
                                                
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            
                                            <asp:TemplateField HeaderText="&#2327;&#2339;&#2344;&#2366; &#2350;&#2375;&#2306; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2348;&#2339;&#2381;&#2337;&#2354; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; &lt;/br&gt; 4">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtReceivedBandla" runat="server" CssClass="txtbox reqirerd" MaxLength="6"  Width="72px"  onkeyup='javascript:tbx_fnSignedNumericCheck(this);' Text='<%#Eval("BundleNo_I")%>' Enabled="false" ></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; &#2325;&#2368; &#2349;&#2375;&#2332;&#2368; &#2327;&#2312; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; &lt;/br&gt; 5">
                                                <ItemTemplate>
                                                 <%#Eval("TotalNoofBook_IS")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2351;&#2379;&#2332;&#2344;&#2366; &#2325;&#2368; &#2349;&#2375;&#2332;&#2368; &#2327;&#2312; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; &lt;/br&gt; 6">
                                                <ItemTemplate>
                                                 <%#Eval("TotalNoofBook_IY")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="&#2327;&#2339;&#2344;&#2366; &#2350;&#2375;&#2306; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;  &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368;  &#2360;&#2306; .&lt;/br&gt; 7">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtGenranlBook" Text='<%#Eval("TotalNoofBook_IS")%>' runat="server" CssClass="txtbox reqirerd" MaxLength="6"  Width="72px"     onblur="CalculateTotalA(this)" Enabled='<%# Eval("isopenmarket").ToString()=="1" ? false  : true %>'></asp:TextBox>
                                               <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtGenranlBook" ValidChars="0123456789"></cc1:FilteredTextBoxExtender>
                                                      </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="&#2327;&#2339;&#2344;&#2366; &#2350;&#2375;&#2306; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;  &#2351;&#2379;&#2332;&#2344;&#2366; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368;  &#2360;&#2306; .&lt;/br&gt; 8">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtSechemBook" Text='<%#Eval("TotalNoofBook_IY")%>' runat="server" CssClass="txtbox reqirerd" MaxLength="6"  Width="72px"  onblur="CalculateTotal(this)"
                                                         Enabled='<%# Eval("isopenmarket").ToString()=="2" ? false  : true %>' ></asp:TextBox>
                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtSechemBook" ValidChars="0123456789"></cc1:FilteredTextBoxExtender>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="&#2327;&#2339;&#2344;&#2366; &#2325;&#2375; &#2310;&#2343;&#2366;&#2352; &#2346;&#2352; &#2325;&#2350; &#2346;&#2366;&#2312; &#2327;&#2351;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; &lt;/br&gt; 9">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtMissingbook" runat="server" CssClass="txtbox reqirerd" MaxLength="6" 
                                                         Width="72px" Text="0"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2357;&#2366;&#2360;&#2381;&#2340;&#2357;&#2367;&#2325; &#2310;&#2325;&#2366;&#2352; &lt;/br&gt; 10">
                                                <ItemTemplate>
                                                 <%#Eval("Size_V")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                             <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352; (&#2354;&#2350;&#2381;&#2348;&#2366;&#2312; X&#2330;&#2380;&#2337;&#2366;&#2312;.) &lt;/br&gt; 11">
                                                <ItemTemplate>
                                                <asp:HiddenField ID="TotalNoofBook_I" runat="server" Value='<%#Eval("TotalNoOfBooks") %>' />
                                                <asp:HiddenField ID="HiddenField3"  runat="server" 
                                                        Value='<%# Eval("TitleID_I") %>' />
                                                    <asp:TextBox ID="txtLambai" runat="server" CssClass="txtbox reqirerd" 
                                                        Width="40px"  MaxLength="6" 
                                                        onkeyup='javascript:tbx_fnSignedNumericCheck(this);' Height="20px">20</asp:TextBox>
                                                    X <asp:TextBox ID="txtch" runat="server" CssClass="txtbox reqirerd" 
                                                        Width="44px" MaxLength="6" Text="27"  
                                                        onkeyup='javascript:tbx_fnSignedNumericCheck(this);'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr >
                                <td  runat="server">
                                    &#2344;&#2350;&#2370;&#2344;&#2375; &#2325;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366;&nbsp;
                                    &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;</td>
                                <td  runat="server">
                                    <asp:TextBox ID="txtNo" runat="server" MaxLength="11"  CssClass="txtbox reqirerd" >0</asp:TextBox>
                                </td>
                                <td  runat="server">
                                    &#2332;&#2366;&#2306;&#2330; &#2325;&#2367;&#2351;&#2375; &#2327;&#2351;&#2375; &#2348;&#2306;&#2337;&#2354;&#2379; &#2325;&#2366; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;</td>
                                <td >
                                    <asp:TextBox ID="txtBandC" runat="server" MaxLength="11"  
                                        CssClass="txtbox reqirerd" onkeyup='javascript:tbx_fnSignedNumericCheck(this);'>0</asp:TextBox>
                                </td>
                            </tr>
                              <tr >
                                <td id="Td3"  runat="server">
                                    &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2346;&#2381;&#2352;&#2357;&#2367;&#2359;&#2381;&#2335;&#2367; &#2337;&#2367;&#2346;&#2379; &#2325;&#2375; &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; &#2360;&#2381;&#2335;&#2377;&#2325; &#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2352; &#2325;&#2366; &#2360;&#2352;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;
                                </td>
                                <td id="Td4"  runat="server">
                                    <asp:TextBox ID="txtRegNo" runat="server" CssClass="txtbox reqirerd" MaxLength="20" onkeyup='javascript:tbx_fnSignedNumericCheck(this);'></asp:TextBox>
                                </td>
                                <td id="Td5" runat="server">
                                    &#2342;&#2367;&#2344;&#2366;&#2325; </td>
                                <td >
                                    <asp:TextBox ID="txtDdate" runat="server" CssClass="txtbox reqirerd" MaxLength="10"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDdate" Format="dd/MM/yyyy">
        </cc1:CalendarExtender> 
                                </td>
                            </tr>
                            <tr >
                                <td  runat="server">
                                    &#2348;&#2306;&#2337;&#2354;&#2379; &#2350;&#2375;&#2306; &#2340;&#2381;&#2352;&#2369;&#2335;&#2367;&#2346;&#2370;&#2352;&#2381;&#2339; &#2319;&#2357;&#2306; &#2326;&#2352;&#2366;&#2348; &#2346;&#2366;&#2312; &#2327;&#2351;&#2368; &#2360;&#2381;&#2341;&#2367;&#2340;&#2367; &#2325;&#2375; &#2360;&#2350;&#2381;&#2348;&#2344;&#2381;&#2343; &#2350;&#2375;&#2306;
                                    </td>
                                <td  runat="server" colspan="3">
                                   
                                    <asp:DropDownList ID="ddlType" runat="server" CssClass="txtbox reqirerd" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                        
                                        <asp:ListItem>&#2344;&#2367;&#2352;&#2306;&#2325;</asp:ListItem>
                                        <asp:ListItem>&#2348;&#2306;&#2337;&#2354; &#2350;&#2375;&#2306; &#2325;&#2369;&#2331; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2375;&#2306; &#2325;&#2381;&#2359;&#2340;&#2367;&#2327;&#2381;&#2352;&#2360;&#2381;&#2340;</asp:ListItem>
                                        <asp:ListItem>&#2348;&#2306;&#2337;&#2354; &#2325;&#2368; &#2346;&#2376;&#2325;&#2367;&#2306;&#2327; &#2340;&#2381;&#2352;&#2369;&#2335;&#2368;&#2346;&#2370;&#2352;&#2381;&#2339;</asp:ListItem>
                                    </asp:DropDownList>
                                    </td>
                            </tr>
                        
                            <tr id="ar1" runat="server"  visible="false" >
                                <td  runat="server">
                                    &#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2375; &#2346;&#2381;&#2352;&#2340;&#2367;&#2344;&#2367;&#2343;&#2367; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                                <td  runat="server">
                                    <asp:TextBox ID="txtContactperson" runat="server" CssClass="txtbox " MaxLength="30" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'></asp:TextBox>
                                </td>
                                <td  runat="server">
                                    &#2337;&#2367;&#2346;&#2379; &#2350;&#2375;&#2306; &#2313;&#2346;&#2360;&#2381;&#2341;&#2367;&#2340; &#2361;&#2379;&#2344;&#2375; &#2325;&#2366; &#2342;&#2367;&#2344;&#2366;&#2325; </td>
                                <td >
                                    <asp:TextBox ID="txtPdate" runat="server" CssClass="txtbox " MaxLength="12"></asp:TextBox>
                                   
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtPdate" Format="dd/MM/yyyy">
        </cc1:CalendarExtender>
                                </td>
                            </tr>
                         <tr  id="ar2" runat="server"  visible="false" >
                                <td   runat="server">
                                    &#2337;&#2367;&#2346;&#2379; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2326;&#2379;&#2354;&#2375; &#2327;&#2351;&#2375; &#2348;&#2306;&#2337;&#2354;&#2379; &#2325;&#2368; &#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2375; 
                                    <br />
                                    &#2346;&#2381;&#2352;&#2340;&#2367;&#2344;&#2367;&#2343;&#2367; &#2325;&#2375; &#2360;&#2350;&#2325;&#2381;&#2359; &#2325;&#2368; &#2327;&#2312; &#2327;&#2339;&#2344;&#2366; &#2350;&#2375;&#2306; &#2346;&#2366;&#2312; &#2327;&#2351;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; </td>
                                <td   runat="server" colspan="3">
                                    <asp:TextBox ID="txtbookNo" runat="server" CssClass="txtbox " MaxLength="12" onkeyup='javascript:tbx_fnSignedNumericCheck(this);'></asp:TextBox>
                                </td>
                            </tr>
                         <tr  id="ar3" runat="server"  visible="false"  >
                                <td   runat="server">
                                    &#2351;&#2342;&#2367; &#2346;&#2381;&#2352;&#2340;&#2367;&#2344;&#2367;&#2343;&#2367; &#2325;&#2375; 
                                    &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2313;&#2360; &#2354;&#2366;&#2335; &#2325;&#2375; &#2342;&#2369;&#2360;&#2352;&#2375; &#2408;&#2411;% &#2348;&#2339;&#2381;&#2337;&#2354; &#2326;&#2369;&#2354;&#2357;&#2366; &#2325;&#2352; &#2325;&#2368; &#2327;&#2312; 
                                    <br />
                                    &#2327;&#2339;&#2344;&#2366; &#2350;&#2375;&#2306; &#2346;&#2366;&#2312; &#2327;&#2351;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; &#2325;&#2366; &#2348;&#2339;&#2381;&#2337;&#2354;&#2357;&#2366;&#2352; &#2357;&#2367;&#2357;&#2352;&#2339; </td>
                                <td   runat="server" colspan="3">
                                    <asp:TextBox ID="txtbandlNo" runat="server" CssClass="txtbox " MaxLength="12" onkeyup='javascript:tbx_fnSignedNumericCheck(this);'></asp:TextBox>
                                </td>
                            </tr>
                        
                           
                        
                           <tr>
                                <td  runat="server">
                                    &#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; </td>
                                <td  runat="server" colspan="3">
                                    
                                    <asp:TextBox ID="txtRemark" runat="server" CssClass="txtbox" Height="51px" MaxLength="150"
                                        TextMode="MultiLine" Width="334px"></asp:TextBox>
                                    
                                </td>
                            </tr>
                        
                           <tr>
                                <td  runat="server" colspan="4">
                                    
                                    <asp:Button ID="btnSave" runat="server" CssClass="btn" OnClientClick="return ValidateAllTextForm();" 
                                        Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save " onclick="btnSave_Click" />
                            <span>
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                    <asp:HiddenField ID="HiddenField2" runat="server" />
    </span>
                                    </td>
                            </tr>
                        </div>
                        </table>
                    </div>
                </div>
  
    <script>
        function CalculateTotalA(obj) {

            var SechemBook = document.getElementById(obj.id.replace("txtGenranlBook", "txtSechemBook"));
            var Missingbook = document.getElementById(obj.id.replace("txtGenranlBook", "txtMissingbook"));
            var TotalNoofBook_I = document.getElementById(obj.id.replace("txtGenranlBook", "TotalNoofBook_I"));
           
            
            if (obj.value != "") {
                if (SechemBook.value == "") {
                    SechemBook.value = 0;
                }

                Missingbook.value = parseInt(TotalNoofBook_I.value) - (parseInt(obj.value) + parseInt(SechemBook.value));
            }

            
        }
        function CalculateTotal(obj) {

            var SechemBook =      document.getElementById(obj.id.replace("txtSechemBook", "txtGenranlBook"));
            var Missingbook =     document.getElementById(obj.id.replace("txtSechemBook", "txtMissingbook"));
            var TotalNoofBook_I = document.getElementById(obj.id.replace("txtSechemBook", "TotalNoofBook_I"));
           
            if (obj.value != "") {
                if (SechemBook.value == "") {
                    SechemBook.value = 0;
                }

                Missingbook.value = parseInt(TotalNoofBook_I.value) - (parseInt(obj.value) + parseInt(SechemBook.value));
            }


        }
    </script>
</asp:Content>

