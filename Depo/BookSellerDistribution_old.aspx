<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookSellerDistribution_old.aspx.cs" Inherits="Depo_BookSellerDistributionOLd" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
        .fancyboxclose {
    position: absolute;
    top:5px;
    right: 0;
    width: 29px;
    height: 28px;
    background: url('../images/cross_circle.png') no-repeat;
    cursor: pointer;
    z-index: 1103;
    display: none;
}
    </style>
    <div class="box">
<asp:HiddenField ID="hdnOrderid" runat="server" />
<asp:HiddenField ID="hdnMasterId1" runat="server" />
<asp:HiddenField ID="hd1" runat="server" />
        <asp:HiddenField ID="hd2" runat="server" />

        <div class="card-header">
            <h2>
                <span>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2357;&#2367;&#2325;&#2381;&#2352;&#2375;&#2340;&#2366; / Book Seller</span></h2>
        </div>
       
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px"> <div id="ExportDiv" runat="server" >
        <table width="100%">
        <tr>
                    <td style="text-align: left">
                        &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2357;&#2367;&#2325;&#2381;&#2352;&#2375;&#2340;&#2366; / Book Seller 
                    </td> <td><asp:DropDownList ID="ddlBookSllerName" runat="server" 
                            AutoPostBack="True" 
                            onselectedindexchanged="ddlBookSllerName_SelectedIndexChanged" Enabled="False"></asp:DropDownList> </td>
            <td>&#2310;&#2352;&#2381;&#2337;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Order NO </td><td><asp:DropDownList ID="DropDownList1" runat="server" 
                            AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Enabled="False" 
                           ></asp:DropDownList></td>

                </tr>
        <tr id="a" runat="server"  visible="false" >
                    <td style="text-align: left"> &#2346;&#2306;&#2332;&#2368;&#2351;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Reg.No.
                       </td> <td> <asp:Label ID="Label6" runat="server"></asp:Label>
                        
                    </td>
            <td>&#2348;&#2376;&#2306;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Bank Name</td><td>
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                    </td>

                </tr>
        <tr id="a1" runat="server" visible="false">
                    <td style="text-align: left"> <strong>&#2337;&#2368;.&#2337;&#2368;. &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / DD No</strong>
                       </td> <td><asp:Label ID="Label1" runat="server"></asp:Label>
                        
                    </td>
            <td> <strong>&#2337;&#2368;.&#2337;&#2368;. &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; /</strong>DD Date</td><td><asp:Label ID="Label5" runat="server"></asp:Label></td>

                </tr>
        <tr  id="a2" runat="server" visible="false">
                    <td style="text-align: left">
                       &#2337;&#2381;&#2352;&#2366;&#2347;&#2381;&#2335; &#2352;&#2366;&#2358;&#2368; (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375;&#2306;)/Draft Amount (in Rs)</td> <td>
                        <asp:Label ID="Label3" runat="server"></asp:Label>
                    </td>
            <td>&#2337;&#2367;&#2360;&#2381;&#2325;&#2366;&#2313;&#2306;&#2335; (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375;&#2306;) /Discount&nbsp; (in Rs)</td><td>
                    <asp:Label ID="Label4" runat="server"></asp:Label>
                    </td>

                </tr>
        <tr  id="a11" runat="server" visible="false">
                    <td style="text-align: left">
                        &#2325;&#2369;&#2354; &#2352;&#2366;&#2358;&#2368; </td> <td>
                        <asp:Label ID="Label7" runat="server"></asp:Label>
                    </td>
            <td>&#2337;&#2367;&#2360;&#2381;&#2325;&#2366;&#2313;&#2306;&#2335; &#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340; %</td><td>
                        <asp:Label ID="Label8" runat="server"></asp:Label>
                        %</td>

                </tr>
                </table>
      
            <table width="100%">
                
                <tr>
                    <td style="text-align: center">
                       
                   <asp:GridView ID="grnMain" runat="server" AutoGenerateColumns="False" 
                    CssClass="tab" DataKeyNames="BookSelleDemandTrNo_I" >
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
                                                      <asp:HiddenField ID="HdTitleHindi_V" runat="server" Value='<%#Eval("TitleHindi_V") %>' />
                                                      <asp:HiddenField ID="HdTotalDemand" runat="server" Value='<%#Eval("TotalDemand") %>' />
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                             
                                              <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; /Title" />
                       <%-- <asp:BoundField DataField="BDate_D" HeaderText="&#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/Date" />--%>
                        
                        <asp:BoundField DataField="MediunNameHindi_V" HeaderText="&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;/Medium " />
                        <asp:BoundField DataField="Classdet_V" HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366;/Class" />
                        <asp:BoundField DataField="TotalDemand" HeaderText="&#2350;&#2366;&#2306;&#2327;/Demand" />
                         <asp:TemplateField HeaderText="&#2360;&#2381;&#2335;&#2377;&#2325; &#2350;&#2375;&#2306; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStock"  runat="server" Width="106px"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                          

                        <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351;&#2367;&#2340;  &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;/No of Book Sold">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblnoofbooks"  runat="server" Width="106px"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                           <asp:BoundField DataField="NoOfBookSamanya" HeaderText="स्टॉक में उपलब्ध मात्रा " />
                           <asp:TemplateField>
                    <ItemTemplate>
                  <%--  <asp:LinkButton ID="lnkDistributeBook" runat="server" Width="141px" OnClick="lnk_DistrbutBookClick" CommandArgument='<%#Eval("User_ID_I") %>'>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2366; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2352;&#2375;</asp:LinkButton>--%>
                     <%-- <a href="#" id="bundalNo" runat="server" onclick="GetPopupBundle(this)"></a>--%>
                                             <asp:LinkButton ID="lnkDistributeBook1" runat="server" Width="141px" OnClick="lnk_DistrbutBookClick1" >&#2348;&#2306;&#2337;&#2354; &#2319;&#2357;&#2306; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;</asp:LinkButton>             
                          <asp:Panel style="display:none;" id="DivR" class="popupnew1" runat="server" ScrollBars="Both" Height="400px" Width="900px">

                                                           <asp:Panel   class="form-message error" runat="server" id="mainDiv" style="display: none;padding-top:10px;padding-bottom:10px;">
                <asp:Label  id="lblmsg" class="notification" runat="server">
                
            </asp:Label>
            </asp:Panel>
                                                               <br />
                                       <%-- <a href="#" id="fancyboxclose" class="fancyboxclose" runat="server" style="display: block;" onclick="javascript:closeMessagesDiv(this);" ></a>       --%>          
                                       
                              <br />
                              <table width="90%" border="1"><tr><td>पुस्तक का नाम :- </td><td>
                                  <asp:Label ID="Label9" runat="server" Text=""></asp:Label></td><td>कुल पुस्तक संख्या :- </td><td> <asp:Label ID="Label10" runat="server" Text=""></asp:Label></td><td>  <asp:LinkButton ID="LinkButton1"  runat="server"  OnClick="lnk_DistrbutBookClick2" CssClass="btn"  Text="Close"></asp:LinkButton></td></tr>
                                  <tr><td></td><td></td><td></td><td></td><td><br /><br />  <asp:Button runat="server"   Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306;" ID="btnSaveAll" class="btn" OnClick="btnAllSaveClick"  CommandArgument='<%#Eval("TitleID_I") %>'/></td></tr>
                              </table>
                          
                              <br />
                                                                <table class="tab" cellspacing="5" width="100%">
                                            <tr>
                                                <th>&#2354;&#2370;&#2360; &#2348;&#2306;&#2337;&#2354;/loose </th>
                                                <th>&#2348;&#2306;&#2337;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/Bundal No</th>
                                                <th>&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2306;&#2337;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;/Per Bundle Book No</th>
                                                <th>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375;/Book No from </th>
                                                <th>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2340;&#2325;/Book No To </th>
                                                <th>&#2354;&#2370;&#2332; &#2348;&#2306;&#2337;&#2354; &#2325;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2375; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2342;&#2352;&#2381;&#2332; &#2325;&#2352;&#2375;&#2306;/Select Loose Books Numbers</th>
                                            </tr>
                                            <tr>
                                                <td><asp:CheckBox ID="chkIsLoose" runat="server" AutoPostBack="true" OnCheckedChanged="chkIsLooseChange" /> </td>
                                                <td>
                                                  <asp:TextBox ID="txtBundleNo" OnTextChanged="CheckBunalFromStock" AutoPostBack="true" MaxLength="10" onkeypress='javascript:tbx_fnInteger(event, this);' Width="70"  runat="server" ></asp:TextBox>
                                                </td>
                                                <td>
                                                  <asp:TextBox ID="txtPerBundleBook"  onkeypress='javascript:tbx_fnInteger(event, this);' MaxLength="10" Width="70"  runat="server" Enabled="false"  ></asp:TextBox>
                                                </td>
                                                <td>
                                                      <asp:TextBox ID="txtFromBookNo" onkeypress='javascript:tbx_fnInteger(event, this);' MaxLength="10" Width="70"  OnTextChanged="txtFromBookNo_TextChanged" AutoPostBack="true" runat="server" Enabled="false"  ></asp:TextBox>
                                                </td>
                                                <td>
                                                     <asp:TextBox ID="txtToBookNo"  onkeypress='javascript:tbx_fnInteger(event, this);' MaxLength="10" Width="70"  runat="server" Enabled="false" ></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtb" runat="server" Visible="false" OnTextChanged="txtonChange" AutoPostBack="true" Width="30"  >

                                                    </asp:TextBox>
                                                   <asp:CheckBoxList ID="ChkLooseBundleList" runat="server" RepeatColumns="7"></asp:CheckBoxList>
                                                </td>
                                            </tr>
                                            <tr>
                                            <td colspan="2">
                                                 
                                               
                                            </td> <td></td>
                                            </tr>

                                             <tr>
                                            <td colspan="2"> <asp:CheckBoxList ID="ChkBundleList" runat="server" CssClass="tab" OnSelectedIndexChanged="chkUpdateBundle" AutoPostBack="true"  />  </td> <td></td>
                                            </tr>
                                        </table><br />
                              <asp:Button ID="Button2" runat="server" OnClick="btnButton2Click" Text="स्टॉक देखें " CssClass="btn" />
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
                        <asp:Panel ID="Panel1" runat="server" Width="200px" ScrollBars="Both" Height="50px">
                       
                         <%# Eval("bundlesS") %></asp:Panel>
                     </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="लूज बंडल ">
                    <ItemTemplate>
                        <asp:Panel ID="Panel1" runat="server" Width="200px" ScrollBars="Both" Height="50px">
                       
                         <%# Eval("bundlesSLooj") %></asp:Panel>
                     </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
                                       
                            </asp:Panel>
                    </ItemTemplate>
                    </asp:TemplateField>
                           <asp:TemplateField>
                    <ItemTemplate>
                    <asp:LinkButton ID="lnkDistributeBook" runat="server" Width="141px" OnClick="lnk_DistrbutBookClick" CommandArgument='<%#Eval("User_ID_I") %>'>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2366; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2352;&#2375;</asp:LinkButton>
                  </ItemTemplate>
                    </asp:TemplateField>  </Columns>
                </asp:GridView>
                    </td>
                </tr>
                 <tr>
                    
                    <td style="text-align: center">

                         <asp:Button ID="Button1" runat="server" Text="Print Challan" CssClass="btn" OnClick="Button1_Click" Enabled="False" />
                    </td> </tr> 
            </table></div> 
            <asp:Button ID="btnExportPDF" runat="server" CssClass="btn_gry" 
                            OnClientClick="return PrintPanel();" Text="Export to PDF & Print Challan"  />
        </div>
        
    </div>
      <asp:Panel ID="pnldiv" runat="server" style="display:none;" class="popupnew1">
             <a href="#" id="fancyboxclose" class="fancyboxclose" runat="server" style="display: block;" onclick="javascript:closeMessagesDiv1(this);" ></a> 
            <table>
            <tr>
            <td>&#2325;&#2376;&#2358; &#2350;&#2375;&#2350;&#2379; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Cash Memo No :</td> <td> <asp:TextBox ID="txtChalanNo" runat="server" MaxLength="10"></asp:TextBox> </td> <td>&#2325;&#2376;&#2358; &#2350;&#2375;&#2350;&#2379; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/ Cash Memo Date </td> <td><asp:TextBox ID="txtChalanDate" runat="server" ></asp:TextBox></td>
            </tr>
             <tr>
            <td>&#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Bilti No  :</td> <td> <asp:TextBox ID="txtGRNO" MaxLength="15" runat="server"></asp:TextBox> </td> <td>&#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/ Bilti Date </td> <td><asp:TextBox ID="txtGRNDate" runat="server" ></asp:TextBox></td>
            </tr>
            <tr>
            <td> &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2325;&#2352;&#2381;&#2340;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; /Receiver Name :</td> <td> <asp:TextBox ID="txtReceiverName" onkeypress='javascript:tbx_fnAlphaOnly(event, this);' MaxLength="50" runat="server"></asp:TextBox> </td> <td>&#2337;&#2381;&#2352;&#2366;&#2311;&#2357;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; /Driver Mobile No </td> <td><asp:TextBox ID="txtDriverMobileNo" onkeypress='javascript:tbx_fnInteger(event, this);' MaxLength="10" runat="server" ></asp:TextBox></td>
            </tr>
            <tr>
            <td>&#2335;&#2381;&#2352;&#2325; &#2344;&#2306;&#2348;&#2352; /Truck No :</td> <td> <asp:TextBox ID="txtTrucko" MaxLength="10" runat="server"></asp:TextBox> </td> <td>&#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368;/Remark :</td> <td><asp:TextBox ID="txtRemark" TextMode="MultiLine" runat="server" onkeypress='javascript:tbx_fnAlphaOnly(event, this);' MaxLength="200" ></asp:TextBox></td>
            </tr>
          
            <tr><td><asp:Button Text="Save" runat="server" OnClick="btnSave" ID="btnSaveMasterData" CssClass="btn" /> </td> </tr>
            
            
            </table>
            <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                                            TargetControlID="txtChalanDate" Format="dd/MM/yyyy">
        </cc1:CalendarExtender>
        <cc1:CalendarExtender ID="txtDate_CalendarExtender1" runat="server" 
                                            TargetControlID="txtGRNDate" Format="dd/MM/yyyy">
        </cc1:CalendarExtender>
            </asp:Panel>
           
       <div id="fadeDiv" runat="server" class="modalBackground" style="display: none">
                </div>
                <script type="text/javascript">
                    function closeMessagesDiv1(obj) {
                        //document.getElementById("ContentPlaceHolder1_pnldiv").style.display = "none";
                        document.getElementById('<%=pnldiv.ClientID %>').style.display = "none";
                        document.getElementById('<%=fadeDiv.ClientID %>').style.display = "none";
                        return false;
                    }
                
                </script>

                <script>
                    function GetPopupBundle(obj, g) {
                        // obj = "'" + obj + "'";
                        //alert(obj);
                        //  alert(document.getElementById(obj.id.replace("bundalNo" ,"DivR"))

                       
                            //  document.getElementById('"+obj+"').value = obj;
                            document.getElementById(obj.id.replace("bundalNo", "DivR")).style.display = "block";
                            document.getElementById('<%=fadeDiv.ClientID %>').style.display = "block";
                        

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
                        document.getElementById('<%=fadeDiv.ClientID %>').style.display = "none";
                        return false;
                    }
                            
                            </script>
    <script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=ExportDiv.ClientID %>");

            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }</script>            
</asp:Content>

