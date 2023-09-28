<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DPT015_Bookreceived.aspx.cs" Inherits="Depo_DPT015_Bookreceived" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
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
    <script type = "text/javascript">
        function Check_Click(objRef) {
            //Get the Row based on checkbox
            var row = objRef.parentNode.parentNode;
            if (objRef.checked) {
                objRef.checked = true;
                //If checked change color to Aqua
                row.style.backgroundColor = "aqua";
            }
            else {
                //If not checked change back to original color
                if (row.rowIndex % 2 == 0) {
                    //Alternating Row Color
                    row.style.backgroundColor = "#C2D69B";
                }
                else {
                    row.style.backgroundColor = "white";
                }
            }

            //Get the reference of GridView
            var GridView = row.parentNode;

            //Get all input elements in Gridview
            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {
                //The First element is the Header Checkbox
                var headerCheckBox = inputList[0];

                //Based on all or none checkboxes
                //are checked check/uncheck Header Checkbox
                var checked = true;
                if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                    if (!inputList[i].checked) {
                        checked = false;
                        break;
                    }
                }
            }
            //  headerCheckBox.checked = checked;

        }
</script>
 <div class="box table-responsive">

    <asp:HiddenField ID="hdnTitleID" runat="server" />
     <asp:HiddenField ID="hdnMasterID" runat="server" />
     <asp:HiddenField ID="HdnTrasactionID" runat="server" />
                            <div class="card-header">
                                <h2><span>&#2309;&#2306;&#2340;&#2352; &#2337;&#2367;&#2346;&#2379; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; / Inter Depo Distribution  </span></h2>
                            </div>
                            <div style="padding:0 10px;">
                                <asp:Panel   class="form-message sucess" runat="server" id="mainDiv" style="display: none;padding-top:10px;padding-bottom:10px;">
                <asp:Label  id="lblmsg" class="notification" runat="server">
                
            </asp:Label>
            </asp:Panel>
                          <table width="100%">
                                        <tr><td>&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352;</td> <td>
                                            <asp:DropDownList ID="ddlFyYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFyYear_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            </td><td>
                                                &nbsp;</td> </tr>
                                        <tr>
                                            <td>&#2360;&#2375;&#2354;&#2375;&#2325;&#2381;&#2335; &#2310;&#2352;&#2381;&#2337;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Select Order No. </td>
                                            <td>
                                                <asp:DropDownList ID="ddlOrderNo" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnSearch" runat="server" CssClass="btn" OnClick="SerarchDepoOrdere" Text="&#2310;&#2342;&#2375;&#2358; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2342;&#2375;&#2326;&#2375; " />
                                            </td>
                                        </tr>
                                        </table>
                            <table width="100%" border=".5">
                                <tr>
                                    <td style="text-align: center">

                                       
                                        <asp:GridView ID="grdDepoTransfer" runat="server" AutoGenerateColumns="False" 
                                            CssClass="tab" DataKeyNames="DemandChildTrno" ShowFooter="True"  OnRowDataBound="grdPrinterBundleDetails0_RowDataBound"
                                            >
                                            <Columns>
                                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                     <asp:HiddenField ID="HiddenField1" runat="server"  Value='<%# Eval("TitleID_i") %>' />
                                                     <asp:HiddenField ID="booktype" runat="server"  Value='<%# Eval("btype") %>'/>
                                                      <asp:HiddenField ID="SDepoTrno_I" runat="server"  Value='<%# Eval("SDepoTrno_I") %>'/>
                                                           <asp:HiddenField ID="Medium_I" runat="server" 
                                                         Value='<%# Eval("Medium_I") %>' />
                                                     <asp:CheckBox ID="CheckBox1" runat="server"  onclick="Check_Click(this)"   />
                                                     <asp:HiddenField ID="ClassTrno_I" runat="server" 
                                                         Value='<%# Eval("ClassTrno_I") %>' />
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                               
                                            <%--    <asp:BoundField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; / &#2309;&#2306;&#2340;&#2352;&#2381;&#2337;&#2367;&#2346;&#2379; &#2344;&#2366;&#2350; " DataField="NameofPress_V" />--%>
                                                <asp:BoundField HeaderText="&#2350;&#2369;&#2326;&#2381;&#2351;&#2366;&#2354;&#2351; &#2310;&#2342;&#2375;&#2358; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/ Head Office Permission No." DataField="reqno" />
                                                <asp:BoundField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Book Name" DataField="TitleHindi_V" />
                                                <asp:BoundField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; (&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;/ &#2351;&#2379;&#2332;&#2344;&#2366;) / Book Type (Genral / Scheme )" DataField="BookType"/>
                                                
                                               <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; / Depot Name" DataField="SDepoName_V" />
                                                <asp:BoundField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / Books No." DataField="NoOfBookTransferd" />
                                                 <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2368; &#2332;&#2366; &#2330;&#2369;&#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366;" DataField="Supply" />
                                                <asp:BoundField HeaderText="&#2360;&#2381;&#2335;&#2377;&#2325; &#2350;&#2375;&#2306; &#2313;&#2346;&#2354;&#2348;&#2381;&#2343; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " DataField="NoOfBook" />
                                                <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2368; &#2332;&#2366;&#2344;&#2375;&#2357;&#2366;&#2354;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; ">
                                                 <ItemTemplate>

                                                     <asp:TextBox ID="TextBox1" runat="server" CssClass="txxbox" Width="100px" onkeypress='javascript:tbx_fnNumeric(event, this);' Text='<%#Eval("NoOfBookTransferd") %>' ></asp:TextBox>
                                                 </ItemTemplate> </asp:TemplateField> 
                                            </Columns>
                                                                        <PagerStyle CssClass="Gvpaging" />
                                              <EmptyDataRowStyle CssClass="GvEmptyText" />
                                        </asp:GridView>
                                        <br />
                                         <asp:Button ID="btn2" runat="server" CssClass="btn" OnClick="btn2_Click" Text="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2375; &#2354;&#2367;&#2319; &#2330;&#2366;&#2354;&#2366;&#2344; &#2348;&#2344;&#2366;&#2351;&#2375; " Visible="false"   />
                                        <asp:Button ID="Button6" runat="server" CssClass="btn" OnClick="Button6_Click" Text="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2375; &#2354;&#2367;&#2319; &#2330;&#2366;&#2354;&#2366;&#2344; &#2348;&#2344;&#2366;&#2351;&#2375; " Visible="false" />
                                    </td>
                                </tr>
                             
                              
                              
                              
                               
                              
    </table>
                              <table width="100%" style="display:none" id="divDepo" runat="server" >
                                

                                  <tr>
                                    <td style="height: 24px" colspan="4" >
                                        <asp:Label ID="lblDepoOrderdate" runat="server" Text="Label" Visible="false" ></asp:Label>
                                     
                                      </td>
                                </tr>
                               
                              

                                </tr>

                                <tr>
                                    <td>
                                        &#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352; / challan No.</td>
                                    <td > 
                                        <asp:TextBox ID="lblDepoChalan" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                                    </td>
                                    <td >
                                       &#2330;&#2366;&#2354;&#2366;&#2344;  &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / challan Date</td>
                                    <td >
                                        <asp:TextBox ID="lblDepochalanDate" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                                         <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                                            TargetControlID="lblDepochalanDate" Format="dd/MM/yyyy">
        </cc1:CalendarExtender>
                                    </td>
                                </tr>
                                 <tr id="a1" runat="server" visible="false" >
                                    <td>
                                        &#2313;&#2340;&#2352;&#2366;&#2312; / Unloading </td>
                                    <td>
                                        <asp:TextBox ID="txtdepolOading" runat="server" CssClass="txtbox reqirerd" MaxLength="5"  onkeyup='javascript:tbx_fnSignedNumericCheck(this);' Text="0"></asp:TextBox></td>
                                    <td>
                                        &#2330;&#2338;&#2366;&#2312; / Uploading</td>
                                    <td>
                                        <asp:TextBox ID="txtDepoUnloading" runat="server" CssClass="txtbox reqirerd" MaxLength="5"  onkeyup='javascript:tbx_fnSignedNumericCheck(this);' Text="0"></asp:TextBox></td>
                                </tr>
                                <tr id="a2" runat="server" visible="false" >
                                    <td>
                                        &#2346;&#2352;&#2367;&#2357;&#2361;&#2344; / Transport</td>
                                    <td>
                                        <asp:TextBox ID="txtDepoTransport" runat="server" CssClass="txtbox reqirerd" MaxLength="5"  onkeyup='javascript:tbx_fnSignedNumericCheck(this);' Text="0"></asp:TextBox></td>
                                    <td>
                                        &#2309;&#2344;&#2381;&#2351; / Others</td>
                                    <td>
                                        <asp:TextBox ID="txtDepoother" runat="server" CssClass="txtbox reqirerd" MaxLength="5"  onkeyup='javascript:tbx_fnSignedNumericCheck(this);' Text="0"></asp:TextBox></td>
                                </tr>
                                  <tr>
                                    <td>
                                        &#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2344;&#2306;&#2348;&#2352;  </td>
                                    <td>
                                        <asp:TextBox ID="txtDepoGrno" runat="server" CssClass="txtbox reqirerd" MaxLength="20"></asp:TextBox></td>
                                    <td>
                                        &#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;  </td>
                                    <td>
                                        <asp:TextBox ID="txtDepoGrnoDate" runat="server" CssClass="txtbox reqirerd" MaxLength="12"></asp:TextBox>
                                         <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                                            TargetControlID="txtDepoGrnoDate" Format="dd/MM/yyyy">
        </cc1:CalendarExtender>
                                        </td>
                                </tr>
                                 
                                <tr >
                                    <td>
                                        &#2335;&#2381;&#2352;&#2325; &#2344;&#2306;&#2348;&#2352; / Truck No.</td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtDepoTruck" runat="server" CssClass="txtbox reqirerd" MaxLength="15"></asp:TextBox>
                                        <asp:HiddenField ID="HiddenField5" runat="server" />
                                    </td>
                                </tr>
                                <tr >
                                    <td style="height: 26px">
                                        &#2346;&#2381;&#2352;&#2342;&#2366;&#2351;&#2325;&#2352;&#2381;&#2340;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; / Distributors Name</td>
                                    <td colspan="3" style="height: 26px">
                                        <asp:DropDownList ID="ddldepoEmployee" runat="server" CssClass="txtbox reqirerd">
                                            <asp:ListItem>Select..</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                       
                                     </td>
                                    <td>
                                          
                                            &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                  <tr>
            <td colspan="4">
                <asp:Button ID="Button5" CssClass="btn" runat="server" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save  " OnClick="Button1_Click" OnClientClick="return ValidateAllTextForm();" />
               
                <asp:HiddenField ID="HiddenField2" runat="server" />
                <asp:HiddenField ID="HiddenField3" runat="server" />
                <asp:HiddenField ID="HiddenField4" runat="server" />
            </td>
        </tr>
                                </table>
                            </div> 
   
                              <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
            </div>
            <div id="Messages" style="display: none;" class="popupnew" runat="server">
                <h2>
                    &#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2379; &#2346;&#2340;&#2381;&#2352; &#2349;&#2375;&#2332;&#2344;&#2366;
                </h2>
                <div class="msg MT10">
                <table class="tab" width="100%">
                    <tr>
                        <td>
                            &#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;</td>
                        <td colspan="2">
                            <asp:TextBox ID="txtLetterno" runat="server" CssClass="txtbox" Height="18px" Width="149px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            &#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2325;</td>
                        <td colspan="2">
                            <asp:TextBox ID="txtLdate" runat="server" CssClass="txtbox" Height="18px" Width="149px"></asp:TextBox></td>
                    </tr>
                    <tr>
                <td>
                    &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;
                </td><td colspan="2">
                    <asp:RadioButtonList ID="rdType" runat="server" RepeatDirection="Horizontal"
                        Width="114px">
                        <asp:ListItem>&#2325;&#2350;</asp:ListItem>
                        <asp:ListItem>&#2337;&#2367;&#2347;&#2375;&#2325;&#2381;&#2335;</asp:ListItem>
                        <asp:ListItem>&#2309;&#2344;&#2381;&#2351;</asp:ListItem>
                    </asp:RadioButtonList>
                </td> 
                    </tr>
                    <tr>
                        <td>
                            &#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325;</td>
                        <td colspan="2">
                            <asp:TextBox ID="txtRemark" runat="server" CssClass="txtbox" Height="55px" TextMode="MultiLine"
                                Width="267px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Button ID="Button2" CssClass="btn" runat="server" Text="&#2346;&#2340;&#2381;&#2352; &#2342;&#2375;&#2326;&#2375;&#2306;"  />
                            
                              <asp:Button ID="Button3" CssClass="btn" runat="server" Text="close"  />
                            
                            </td>
                            
                    </tr>
                </table>
                </div>
              
              
            </div>
            <script>
                function GetPopupBundle(obj, g) {

                    // obj = "'" + obj + "'";
                    //alert(obj);
                    //  alert(document.getElementById(obj.id.replace("bundalNo" ,"DivR"))


                    //  document.getElementById('"+obj+"').value = obj;
                    document.getElementById(obj.id.replace("bundalNo", "DivR")).style.display = "block";
                    document.getElementById('<%= fadeDiv.ClientID %>').style.display = "block";
                    //document.getElementById("ContentPlaceHolder1_fadeDiv").style.display = "block";


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

                            </script>
<div id="orderDetails" class="popupnew1" runat="Server" style="display:none;" >

              <h2> &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2348;&#2369;&#2325; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; </h2>
              <asp:GridView ID="grdOrderDetails" runat="server" CssClass="tab" AutoGenerateColumns="false">
              <Columns>
               <asp:TemplateField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;" >
              <ItemTemplate>
              <asp:Label ID="lblt" runat="server" Text='<%#Eval("Title") %>' ></asp:Label>
              </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;" >
              <ItemTemplate>
              <asp:Label ID="lblt" runat="server" Text='<%#Eval("NO Of Books") %>' ></asp:Label>
              </ItemTemplate>
              </asp:TemplateField>
             <asp:TemplateField HeaderText=" &#2348;&#2306;&#2337;&#2354;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;" >
              <ItemTemplate>
              <asp:Label ID="lblt1" runat="server" Text='<%#Eval("BundleCount") %>' ></asp:Label>
              
              </ItemTemplate>
              </asp:TemplateField>
              <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2354;&#2370;&#2332; &#2348;&#2306;&#2337;&#2354;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;" >
               <ItemTemplate>
              <asp:Label ID="lblt11" runat="server" Text='<%#Eval("LooseBundleCount") %>' ></asp:Label>
              </ItemTemplate>
              </asp:TemplateField>
             
               
              </Columns>
                      <PagerStyle CssClass="Gvpaging" />
                                              <EmptyDataRowStyle CssClass="GvEmptyText" />
              </asp:GridView>
              <asp:Button Text="&#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2348;&#2306;&#2342; &#2325;&#2352;&#2375;" CssClass="btn" runat="server" ID="btnContinue" OnClick="ContinueClick"  />
              </div>
</ContentTemplate>
</asp:UpdatePanel> 
  
</asp:Content>

