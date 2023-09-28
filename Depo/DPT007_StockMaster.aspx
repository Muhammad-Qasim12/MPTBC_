<%@ Page Title="&nbsp;&#2360;&#2381;&#2335;&#2377;&#2325; &#2350;&#2366;&#2360;&#2381;&#2335;&#2352; / Stock Master" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DPT007_StockMaster.aspx.cs" Inherits="Depo_DPT007_StockMaster" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
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
    &nbsp;<div class="box">
                            <div class="card-header">
                                <h2><span>&nbsp;&#2360;&#2381;&#2335;&#2377;&#2325; &#2350;&#2366;&#2360;&#2381;&#2335;&#2352; / Stock Master</span></h2>
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
                                            <asp:DropDownList ID="ddlCls" runat="server" CssClass="txtbox reqirerd">
                                            </asp:DropDownList>
                                            </td>
                                    </tr>
                                     <tr>
                                        <td>&#2357;&#2375;&#2351;&#2352;&#2361;&#2366;&#2313;&#2360; / &#2327;&#2379;&#2342;&#2366;&#2350; &#2325;&#2366; &#2344;&#2366;&#2350; / Ware House / Godown Name 	
                                         </td>
                                        <td>  <asp:DropDownList ID="ddlWarehouse" runat="server" CssClass="txtbox reqirerd">
                                            </asp:DropDownList>
                                            </td>
                                    </tr>
                                     <tr>
                                        <td>&#2348;&#2369;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;&nbsp; / Book Type 	
                                         </td>
                                        <td>  <asp:DropDownList ID="ddlType" runat="server" 
    CssClass="txtbox ">
    <asp:ListItem Value="1">&#2351;&#2379;&#2332;&#2344;&#2366; </asp:ListItem>
    <asp:ListItem Value="2">&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; </asp:ListItem>
</asp:DropDownList>
                                            </td>
                                    </tr>
                                     <tr>
                                        <td>&#2348;&#2369;&#2325; &#2325;&#2368; &#2360;&#2381;&#2341;&#2367;&#2340;&#2367; / Book Status </td>
                                        <td>  
                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                                                onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
                                                RepeatDirection="Horizontal" Width="303px">
                                                <asp:ListItem Selected="True" Value="1">&#2348;&#2367;&#2325;&#2381;&#2352;&#2368; &#2351;&#2379;&#2327;&#2381;&#2351;	</asp:ListItem>
                                                <asp:ListItem Value="2">&#2348;&#2367;&#2325;&#2381;&#2352;&#2368; &#2309;&#2351;&#2379;&#2327;&#2381;&#2351;</asp:ListItem>
                                            </asp:RadioButtonList>
                                         </td>
                                    </tr>
                                     <tr>
                                        <td>&nbsp;</td>
                                        <td>  <asp:DropDownList ID="ddlBookType" runat="server" 
                                                CssClass="txtbox reqirerd" Visible="False">
                                            <asp:ListItem Value="0">Select..</asp:ListItem>
                                            <asp:ListItem Value="1">&#2309;&#2346;&#2381;&#2352;&#2330;&#2354;&#2367;&#2340;</asp:ListItem>
                                            <asp:ListItem Value="2">&#2309;&#2344;&#2369;&#2346;&#2351;&#2379;&#2327;&#2368;</asp:ListItem>
                                            <asp:ListItem Value="3">&#2309;&#2346;&#2354;&#2375;&#2326;&#2367;&#2325;</asp:ListItem>
                                            </asp:DropDownList>
                                         </td>
                                    </tr>
                                     <tr>
                                        <td colspan="2">
                                            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="&#2310;&#2327;&#2375; &#2348;&#2338;&#2375; / Next "   OnClientClick="return ValidateAllTextForm();"
                                                Width="159px" CssClass="btn" Height="25px"  />
                                         </td>
                                    </tr>
                                    </div>
                                    <div id="GID" runat="server" visible="false"  >
                                     
                                            <asp:GridView ID="grBook" runat="server" AutoGenerateColumns="False"  
                                                CssClass="tab">
                                                <Columns>
                                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;. / S.No.">
                                                <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                                </asp:TemplateField>
                                               
                                                    <asp:BoundField HeaderText="&#2357;&#2367;&#2359;&#2351; / Subject " DataField="BookName" />
                                                    <asp:BoundField HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366; / Class " DataField="Classname" />
                                                    <asp:TemplateField HeaderText="&#2335;&#2379;&#2335;&#2354; &#2348;&#2369;&#2325; / Total Book ">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtNofBooks" runat="server" Width="106px" 
                                                                Text="" MaxLength="10" onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="&#2348;&#2306;&#2337;&#2354; &#2319;&#2357;&#2306; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Bundle And Book No. ">
                                                         
                                                        <ItemTemplate>
                                                           <asp:Button runat="server" Text=" Add Bundle And Book No." OnClick="aa" />
                                                          <%-- <a href="#" id="bundalNo" runat="server" onclick="GetPopupBundle(this)"  >&#2348;&#2306;&#2337;&#2354; &#2319;&#2357;&#2306; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; /  Bundle And Book No.</a>--%>
                                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("TitalID") %>' />
                                                            <asp:Panel style="display:none;" id="DivR" class="popupnew1" runat="server">
                                                           <a href="#" id="fancyboxclose" class="fancyboxclose" runat="server" style="display: block;" onclick="javascript:closeMessagesDiv(this);" ></a>                 
                                                           <asp:Panel   class="form-message error" runat="server" id="mainDiv" style="display: none;padding-top:10px;padding-bottom:10px;">
                <asp:Label  id="lblmsg" class="notification" runat="server">
                
            </asp:Label>
            </asp:Panel>
            <table class="tab" width="100%">
          
            
            </table>
                                         <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Width="900px" Height="300px">
                                            
                                        <table class="tab" cellspacing="5" width="100%">
                                           <tr>
                                          <td colspan="7" align="center" > <b> &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2348;&#2369;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; :<asp:Label ID="lbl1" runat="server" Text="Label"></asp:Label></b></td>
                                           </tr>

                                            <tr>
                                                <th>&#2332;&#2375;&#2344;&#2352;&#2375;&#2335; &#2348;&#2306;&#2337;&#2354;</th>
                                                <th> &#2354;&#2370;&#2360; &#2348;&#2306;&#2337;&#2354;</th>
                                                <th><asp:Label  Text="&#2348;&#2306;&#2337;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;" ID="lblbun" runat="server"></asp:Label> </th>
                                                <th>&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2306;&#2337;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;</th>
                                                <th>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375;</th>
                                                <th>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2340;&#2325;</th>
                                                <th>&#2354;&#2370;&#2332; &#2348;&#2306;&#2337;&#2354; &#2325;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2375; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2342;&#2352;&#2381;&#2332; &#2325;&#2352;&#2375;&#2306;</th>
                                            </tr>
                                            
                                           
                                            <tr>
                                             <td><asp:CheckBox ID="chkgbundle" runat="server"  /> </td>
                                                <td><asp:CheckBox ID="chkIsLoose" runat="server" AutoPostBack="true" OnCheckedChanged="chkIsLooseChange" /> </td>
                                                <td>
                                                  <asp:TextBox ID="txtBundleNo" MaxLength="8"  onkeypress='javascript:tbx_fnInteger(event, this);' Width="70"  runat="server" ></asp:TextBox>
                                                </td>
                                                <td>
                                                  <asp:TextBox ID="txtPerBundleBook" MaxLength="4" onkeypress='javascript:tbx_fnInteger(event, this);' Width="70"  runat="server" ></asp:TextBox>
                                                </td>
                                                <td>
                                                      <asp:TextBox ID="txtFromBookNo" MaxLength="8" onkeypress='javascript:tbx_fnInteger(event, this);' Width="70"  OnTextChanged="txtFromBookNo_TextChanged" AutoPostBack="true" runat="server" ></asp:TextBox>
                                                </td>
                                                <td>
                                                     <asp:TextBox ID="txtToBookNo" MaxLength="8" onkeypress='javascript:tbx_fnInteger(event, this);' Width="70"  runat="server" ></asp:TextBox>
                                                </td>
                                                <td>
                                                   <asp:TextBox ID="txtb" runat="server" Visible="false" OnTextChanged="txtonChange_TextChanged" AutoPostBack="true" Width="30"  ></asp:TextBox>
                                                   <asp:CheckBoxList ID="ChkLooseBundleList" runat="server" RepeatColumns="7" ></asp:CheckBoxList>
                                                </td>
                                            </tr>


                                            <tr>
                                            
                                            
                                            </tr>
                                            <tr>
                                            <td colspan="2"> <asp:Button runat="server"   Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306;" ID="btnSaveAll" class="btn" OnClick="btnAllSaveClick" CssClass='<%#Eval("TitalID") %>' CommandArgument='<%#Eval("Stock_ID_I") %>'/>  </td> <td></td>
                                            </tr>

                                             <tr>
                                            <td colspan="2"> <asp:CheckBoxList ID="ChkBundleList" runat="server" CssClass="tab" OnSelectedIndexChanged="chkUpdateBundle"   />  </td> <td></td>
                                            </tr>
                                        </table></asp:Panel>
                                       
                            </asp:Panel>
                                                            
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
                            
                        
                            <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server" >
    </div>
    
                            </div> 
                            
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
                                      //  document.getElementById(obj.id.replace("lbl1", "txtNofBooks")).value = document.getElementById(obj.id.replace("bundalNo", "txtNofBooks")).value;
                                        
                                        document.getElementById(obj.id.replace("bundalNo", "DivR")).style.display = "block";
                                        document.getElementById('<%= fadeDiv.ClientID %>').style.display = "block";
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
                                    document.getElementById('<%= fadeDiv.ClientID %>').style.display = "none";
                                    return false;
                                }
                            
                            </script></div>
</ContentTemplate>

</asp:UpdatePanel>
 
                            
</asp:Content>

