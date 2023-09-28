<%@ Page Title="&#2350;.&#2346;&#2381;&#2352; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; / M.P. TBC" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DPT017_StockParivartan.aspx.cs" Inherits="Depo_DPT017_StockParivartan" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
<asp:HiddenField ID="HdnMasterHdnId" runat="server" />
<asp:HiddenField ID="HdnTrasactionID" runat="server" />
<asp:HiddenField ID="HdnTiltle" runat="server" />
<div class="box table-responsive">

                            <div class="card-header">
                                <h2>&nbsp;&#2326;&#2369;&#2354;&#2375; &#2348;&#2366;&#2332;&#2366;&#2352; &#2325;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2351;&#2379;&#2332;&#2344;&#2366; &#2350;&#2375;&#2306; &#2346;&#2352;&#2367;&#2357;&#2352;&#2381;&#2340;&#2344; </h2>
                            </div>
                            <div style="padding:0 10px;">
                            
                        
                            
                                <table width="100%">
                                <div id="a" runat="server" >
                                    <tr   >
                                        <td>
                                          
                                            &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Date </td>
                                        <td>
                                            <asp:TextBox ID="txtDate" runat="server" CssClass="txtbox reqirerd" 
                                                MaxLength="12"></asp:TextBox>
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate" Format="dd/MM/yyyy">
        </cc1:CalendarExtender>    
                                            </td>
                                    </tr>
                                    <tr>
                                        <td>&#2350;&#2366;&#2343;&#2381;&#2351;&#2350; / Medium
                                         </td>
                                        <td>
                                            <asp:DropDownList ID="ddlMedium" runat="server" CssClass="txtbox reqirerd">
                                            </asp:DropDownList>
                                            </td>
                                    </tr>
                                      <tr>
                                        <td>&#2325;&#2325;&#2381;&#2359;&#2366;	/ Class 
                                         </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCls" runat="server" CssClass="txtbox reqirerd" AutoPostBack="true" OnSelectedIndexChanged="ddlClsChange" Visible="False">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="DDLClass" runat="server" CssClass="txtbox">
                                                <asp:ListItem Text="1-8" Value="1-8"></asp:ListItem>
                                                <asp:ListItem Text="9-12" Value="9-12"></asp:ListItem>
                                            </asp:DropDownList>
                                            </td>
                                    </tr>
                                     <tr>
                                        <td>&#2357;&#2375;&#2351;&#2352;&#2361;&#2366;&#2313;&#2360; / &#2327;&#2379;&#2342;&#2366;&#2350; &#2325;&#2366; &#2344;&#2366;&#2350; / WareHouse / Godown Name	
                                         </td>
                                        <td>  <asp:DropDownList ID="ddlWarehouse" runat="server" CssClass="txtbox reqirerd">
                                            </asp:DropDownList>
                                            </td>
                                    </tr>
                                     <tr>
                                         <td>
                                             <span style="DISPLAY: inline-block" vs:forcedlayout="true">&#2344;&#2357;&#2368;&#2344; &#2327;&#2379;&#2342;&#2366;&#2350; / New Godown  </span> 
                                         </td>
                                         <td>
                                             <asp:DropDownList ID="ddlNewWarehous" runat="server" CssClass="txtbox reqirerd">
                                             </asp:DropDownList>
                                         </td>
                                    </tr>

                                    <tr>
                                    <td>
                                             <span style="DISPLAY: inline-block" vs:forcedlayout="true">&#2352;&#2375;&#2347;&#2352;&#2375;&#2306;&#2360; &#2354;&#2375;&#2335;&#2352; &#2344;&#2306;&#2348;&#2352;  / Reference Letter No. </span>
                                         </td>
                                     <td>  <asp:TextBox ID="txtRefrenceNo" runat="server" CssClass="txtbox reqirerd">
                                             </asp:TextBox></td>
                                    
                                    
                                    </tr>

                                     <tr>
                                        <td colspan="2">
                                            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="&#2310;&#2327;&#2375; &#2348;&#2338;&#2375; "   OnClientClick="return ValidateAllTextForm();"
                                                Width="108px" CssClass="btn"  />
                                         </td>
                                    </tr>
                                    </div>
                                    <div id="GID" runat="server" visible="false"  >
                                        <asp:Button ID="Button3" CssClass="btn" runat="server" Text="Back>>" OnClick="btnClose"/>
                                            <asp:GridView ID="grBook" runat="server" AutoGenerateColumns="False"  
                                                CssClass="tab" onrowdatabound="grBook_RowDataBound" Width="100%">
                                                <Columns>
                                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;. / S. No.">
                                                <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                                
                                                 <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("TitalID") %>' />
                                                </ItemTemplate>
                                                </asp:TemplateField>
                                               
                                                    <asp:BoundField HeaderText="&#2357;&#2367;&#2359;&#2351; / Subject " DataField="BookName" />
                                                    <asp:BoundField HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366; / Class " DataField="Classname" />
                                                     
                                                      <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2306;&#2337;&#2354;">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPerBundal" runat="server" Text='<%#Eval("PerBundle") %>'></asp:Label>
                                                            
                                                        </ItemTemplate></asp:TemplateField> 

                                                    <asp:TemplateField HeaderText="&#2335;&#2379;&#2335;&#2354; &#2348;&#2369;&#2325; / Total Book">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtNofBooks" runat="server" Width="106px"  OnTextChanged="txtNofBooks_TextChanged" AutoPostBack="true" 
                                                                Text=""></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="&#2346;&#2376;&#2325; &#2348;&#2339;&#2381;&#2337;&#2354; ">
                                                        <ItemTemplate>
                                                     
                                                           <asp:Label ID="lblPaikBulde" runat="server" Text=""></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="&#2354;&#2370;&#2332; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; ">
                                                        <ItemTemplate>
                                                           <asp:Label ID="lbllooj" runat="server" Text=""></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="&#2346;&#2376;&#2325; &#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; &#2337;&#2366;&#2354;&#2375; ">
                                                        <ItemTemplate>
                                                           
                                                           <a href="#" id="bundalNo" runat="server" onclick="GetPopupBundle(this)">Paik  Bundle</a>
                                                           <asp:Panel style="display:none;" id="DivR" class="popupnew1" runat="server" ScrollBars="Both" Width="1200px" Height="600px">
                                                           <a href="#" id="fancyboxclose" class="fancyboxclose" runat="server" style="display: block;" onclick="javascript:closeMessagesDiv(this);" ></a>                 
                                                           <asp:Panel   class="form-message error" runat="server" id="mainDiv" style="display: none;padding-top:10px;padding-bottom:10px;" >
                <asp:Label  id="lblmsg" class="notification" runat="server">
                
            </asp:Label>
            </asp:Panel>
                                                               &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; &#2325;&#2368; &#2348;&#2369;&#2325; &#2325;&#2379; &#2351;&#2379;&#2332;&#2344;&#2366; &#2350;&#2375;&#2306; &#2348;&#2342;&#2354;&#2375;/  &#2344;&#2357;&#2368;&#2344; &#2327;&#2379;&#2342;&#2366;&#2350; &#2350;&#2376; &#2348;&#2369;&#2325; &#2335;&#2381;&#2352;&#2366;&#2344;&#2381;&#2360;&#2347;&#2352; &#2325;&#2352;&#2375;
                                        
                                        <table class="tab" cellspacing="5" width="100%">
                                            <tr style="display:none;">
                                                <th>&#2354;&#2370;&#2360; &#2348;&#2306;&#2337;&#2354;</th>
                                                <th>&#2348;&#2306;&#2337;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;</th>
                                                <th>&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2306;&#2337;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;</th>
                                                <th>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375;</th>
                                                <th>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2340;&#2325;</th>
                                                <th>&#2354;&#2370;&#2332; &#2348;&#2306;&#2337;&#2354; &#2325;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2375; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2342;&#2352;&#2381;&#2332; &#2325;&#2352;&#2375;&#2306;</th>
                                            </tr>
                                            <tr  style="display:none;">
                                                <td>
                                                   
                                                    <asp:CheckBox ID="chkIsLoose" runat="server" AutoPostBack="true" OnCheckedChanged="chkIsLooseChange" /> </td>
                                                <td>
                                                  <asp:TextBox ID="txtBundleNo"  onkeypress='javascript:tbx_fnInteger(event, this);' Width="70"  runat="server" ></asp:TextBox>
                                                </td>
                                                <td>
                                                  <asp:TextBox ID="txtPerBundleBook"  onkeypress='javascript:tbx_fnInteger(event, this);' Width="70"  runat="server" ></asp:TextBox>
                                                </td>
                                                <td>
                                                      <asp:TextBox ID="txtFromBookNo" onkeypress='javascript:tbx_fnInteger(event, this);' Width="70"  OnTextChanged="txtFromBookNo_TextChanged" AutoPostBack="true" runat="server" ></asp:TextBox>
                                                </td>
                                                <td>
                                                     <asp:TextBox ID="txtToBookNo"  onkeypress='javascript:tbx_fnInteger(event, this);' Width="70"  runat="server" ></asp:TextBox>
                                                </td>
                                                <td>
                                                   <asp:CheckBoxList ID="ChkLooseBundleList" runat="server" RepeatColumns="7" ></asp:CheckBoxList>
                                                </td>
                                            </tr>
                                          

                                             <tr>
                                            <td colspan="2">
                                                <asp:CheckBox ID="CheckBox1" runat="server"  AutoPostBack="true"  Text="All" OnCheckedChanged="chkCheck"/>
                                                 <asp:CheckBoxList ID="ChkBundleList" runat="server" CssClass="tab"   />  </td> <td></td>
                                            </tr>
                                              <tr>
                                            <td colspan="2"> 
                                                <asp:Button runat="server"   Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306;" ID="btnSaveAll" class="btn" OnClick="btnAllSaveClick" CssClass='<%#Eval("TitalID") %>' CommandArgument='<%#Eval("Stock_ID_I") %>'/>  </td> <td></td>
                                            </tr>
                                        </table>
                                       
                            </asp:Panel>
                                                            
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="&#2354;&#2370;&#2332; &#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352;">
                                                        <ItemTemplate>
                                                            &#2354;&#2370;&#2332; &#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352;<br />
                                                             : <asp:TextBox runat="server" Text="" ID="txtbandle" Width="120px" ></asp:TextBox><br />

                                                            <asp:Button ID="Button4" runat="server" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; " OnClick="Button4_Click" CommandArgument='<%#Eval("TitalID") %>' Width="120px" /><br /><br />
                                                                                                            <asp:Button ID="Button6" runat="server" CssClass="btn" Text="&#2360;&#2381;&#2335;&#2377;&#2325; &#2342;&#2375;&#2326;&#2375;&#2306; " OnClick="Button6_Click" CommandArgument='<%#Eval("TitalID") %>' Width="120px" />
                                                             </ItemTemplate>
                                                    </asp:TemplateField>
                                                             </Columns>
                                                
                            <PagerStyle CssClass="Gvpaging" />
                                              <EmptyDataRowStyle CssClass="GvEmptyText" />
                                            </asp:GridView>
                                          
                                            <%--<asp:Button ID="Button2" runat="server" onclick="Button1_Click" Text="Save"   OnClientClick="return ValidateAllTextForm();"
                                                Width="108px" CssClass="btn"  />--%>
                                        </div> 
                                </table>
                            
                         <div id="Div1" class="modalBackground" style="display: none;" runat="server" >
            </div>
            <div id="Messages" style="display: none;" class="popupnew1" runat="server" >
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Width="800px" Height="400px">
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>

                      <br />
                    <asp:GridView ID="grdPrinterBundleDetails" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="StockDetailsChildID_I">
                                                 <Columns>
                                                  


                                                     <asp:TemplateField HeaderText="&amp;#2354;&amp;#2370;&amp;#2360; &amp;#2348;&amp;#2306;&amp;#2337;&amp;#2354;/loose">
                                                         <ItemTemplate>
                                                             <asp:CheckBox ID="chkIsLoose" runat="server" AutoPostBack="true" OnCheckedChanged="chkIsLooseChange1" />
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
                                                             <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("SubJectID_I") %>'  />
                                                             
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
                            <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server" >
    </div>
    
                            </div> 
                             <div id="Div2" class="modalBackground" style="display: none;" runat="server" >
    </div>
     <div id="Div3" style="display: none;" class="popupnew1" runat="server" >
                <asp:Panel ID="Panel2" runat="server" ScrollBars="Both" Width="800px" Height="400px">
                    <asp:Button ID="Button7" runat="server" Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375;&#2306; " CssClass="btn" OnClick="Button7_Click"/>
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
                <asp:TemplateField HeaderText="&#2346;&#2376;&#2325; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;  &lt;br&gt; 3">
                     <ItemTemplate>
                         <%# Eval("cnt1") %>
                     </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="&#2346;&#2376;&#2325; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2375; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; ">
                    <ItemTemplate>
                        <asp:Panel ID="Panel1" runat="server" Width="200px" ScrollBars="Both" Height="200px">
                       
                         <%# Eval("bundlesS") %></asp:Panel>
                     </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="&#2354;&#2370;&#2332; &#2348;&#2306;&#2337;&#2354;  ">
                    <ItemTemplate>
                        <asp:Panel ID="Panel1" runat="server" Width="200px" ScrollBars="Both" Height="200px">
                       
                         <%# Eval("bundlesSLooj") %></asp:Panel>
                     </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

                </asp:Panel> </div> 
                            <script>
                                function GetPopupBundle(obj, g) {
                                    //alert(1);
                                    // obj = "'" + obj + "'";
                                    //alert(obj);
                                    //  alert(document.getElementById(obj.id.replace("bundalNo" ,"DivR"))

                                    if (document.getElementById(obj.id.replace("bundalNo", "txtNofBooks")).value == "") {

                                        alert("Please enter total no of book");
                                        document.getElementById(obj.id.replace("bundalNo", "txtNofBooks")).focus();
                                        $(document.getElementById(obj.id.replace("bundalNo", "txtNofBooks"))).css('background-color', '#FFBDC1');
                                    }
                                    else {
                                        //  document.getElementById('"+obj+"').value = obj;
                                        document.getElementById(obj.id.replace("bundalNo", "DivR")).style.display = "block";
                                        document.getElementById("ContentPlaceHolder1_fadeDiv").style.display = "block";
                                    }

                                }
                                function ValidateAllTextFormNew() {
                                    if (document.getElementById(obj.id.replace("txtBundleNo", "btnSaveAll")).value == "") {
                                        document.getElementById(obj.id.replace("txtBundleNo", "btnSaveAll")).focus();
                                        return false;

                                    }
                                    //   document.getElementById(obj.id.replace("txtBundleNo", "btnSaveAll")).style.display = "block";
                                    //document.getElementById("ContentPlaceHolder1_fadeDiv").style.display = "block";
                                }
                                function closeMessagesDiv(obj) {
                                    document.getElementById(obj.id.replace("fancyboxclose", "DivR")).style.display = "none";
                                    document.getElementById('<%=fadeDiv.ClientID%>').style.display = "none";
                                    return false;
                                }
                            
                            </script></div>

</ContentTemplate>

</asp:UpdatePanel>
 
</asp:Content>

