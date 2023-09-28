<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateSchemeChallan.aspx.cs" Inherits="Depo_UpdateSchemeChallan" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type = "text/javascript">
        function Check_Click(objRef) {
            //Get the Row based on checkbox
            var row = objRef.parentNode.parentNode;
            if (objRef.checked) {
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
                    //alert(i);
                    if (!inputList[i].checked) {
                        checked = false;
                        break;
                    }
                }
            }
           // headerCheckBox.checked = checked;

        }
</script>
    
     <asp:HiddenField ID="hdnDistrictID" runat="server" />
<asp:HiddenField ID="hdnOrderID" runat="server" />
  <asp:HiddenField ID="hdnblockname"  runat="server"  />
               
            
                <div class="box">
                    <div class="card-header">
                     <h2> &#2351;&#2379;&#2332;&#2344;&#2366; &#2325;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2366; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; / Books Distribution Of Scheme</h2>
                          
                    </div>
                     <table style="width: 100%">
                <tr>
                    <td style="font-size: medium;">
                        &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; /Distribution Type </td>
                    <td>
                        <asp:DropDownList ID="ddltype" runat="server" >
                            <asp:ListItem Text="&#2351;&#2379;&#2332;&#2344;&#2366;" Value="0"> </asp:ListItem>
                            <asp:ListItem Text="&#2309;&#2340;&#2367;&#2352;&#2367;&#2325;&#2381;&#2340; &#2350;&#2366;&#2306;&#2327;" Value="1"> </asp:ListItem>
                            <asp:ListItem Text="&#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; " Value="2"> </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width: 30%; font-size: medium;" valign="top">
                        &nbsp;</td>
                    <td style="font-size: medium;">
                        
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="font-size: medium;">
                        &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;
                        / Financial Year</td>
                    <td>
                        <asp:DropDownList ID="ddlSessionYear" runat="server" CssClass="txtbox reqirerd">
                            
                        </asp:DropDownList>
                    </td>
                    <td style="width: 30%; font-size: medium;" valign="top">
                     <asp:Label ID="LblDistrict" runat="server" Width="263px">&#2332;&#2367;&#2354;&#2366;/ District Name :</asp:Label>
                    
                    </td>
                    <td style="font-size: medium;">
                        
                        <asp:DropDownList ID="DdlDistrict" runat="server"  CssClass="txtbox reqirerd" 
                            AutoPostBack="True" onselectedindexchanged="DdlDistrict_SelectedIndexChanged">
                           
                        </asp:DropDownList>
                    
                    </td>
                </tr>
                <tr>
                        <td>
                            &#2348;&#2381;&#2354;&#2366;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;&nbsp; 
                            /Bolck Name</td>
                        <td>
                            <asp:DropDownList ID="ddlBlock" runat="server"  CssClass="txtbox reqirerd">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &#2350;&#2366;&#2343;&#2381;&#2351;&#2350; </td>
                        <td>
                        
                        <asp:DropDownList ID="ddlMedium" runat="server"  CssClass="txtbox reqirerd">
                           
                        </asp:DropDownList>
                    
                        </td>
                    </tr>
                   
                    
               
                <tr>
                        <td>
                            &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2325;&#2352;&#2381;&#2340;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350;/Receiver Name</td>
                        <td>
                <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                   
                    <asp:ListItem Value="0">Select..</asp:ListItem>
                     <asp:ListItem Value="1">&#2348;&#2368; &#2310;&#2352; &#2360;&#2368; </asp:ListItem>
<asp:ListItem Value="2">&#2348;&#2368; &#2312; &#2323; </asp:ListItem>
                    <asp:ListItem Value="3">&#2337;&#2368; &#2312; &#2323; </asp:ListItem>
                    <asp:ListItem Value="4">&#2337;&#2368; &#2346;&#2368; &#2360;&#2368; </asp:ListItem>
                    <asp:ListItem Value="5">&#2309;&#2344;&#2381;&#2351; </asp:ListItem>
                </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                   
                    
               
               
                   
                    
               
                <tr>
                        <td>
                            &#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352; 
                        </td>
                        <td>
                            <asp:TextBox ID="txtChalanNo" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                        </td>
                        <td>
                
                            &#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; /Challan Date  
                
                        </td>
                        <td>
                            <asp:TextBox ID="txtChalanDate" runat="server"  CssClass="txtbox reqirerd" ></asp:TextBox>
            
            <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                                            TargetControlID="txtChalanDate" Format="dd/MM/yyyy">
        </cc1:CalendarExtender>
                        </td>
                    </tr>
                   
                    
               
               
                   
                    
               
                     <tr><td> 
                
                            &#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2344;&#2306;&#2348;&#2352;/Bilti No&nbsp; 
                
                </td><td>
                            <asp:TextBox ID="txtGRNO" runat="server" MaxLength="10"  CssClass="txtbox reqirerd"></asp:TextBox>  
                        </td> <td>
                            &#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;&nbsp;/Bilti Date</td><td><asp:TextBox ID="txtGRNDate" runat="server"  CssClass="txtbox reqirerd" ></asp:TextBox>
        <cc1:CalendarExtender ID="txtDate_CalendarExtender1" runat="server" 
                                            TargetControlID="txtGRNDate" Format="dd/MM/yyyy">
        </cc1:CalendarExtender>
           
           
                </td></tr>
            
            
               
            <tr><td> 
                
                            &#2337;&#2381;&#2352;&#2366;&#2312;&#2357;&#2352; &#2325;&#2366; &#2350;&#2379;&#2348;&#2366;&#2311;&#2354; &#2344;&#2306;&#2348;&#2352; /Driver Mobile No&nbsp; &nbsp;&nbsp;</td><td>
                            <asp:TextBox ID="txtDriverMobileNo" MaxLength="10" runat="server"  CssClass="txtbox reqirerd" ></asp:TextBox>
             
                        </td> <td>
                            &#2335;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2306;&#2348;&#2352;&nbsp;/ Truck No</td><td> <asp:TextBox ID="txtTrucko" runat="server" MaxLength="10"  CssClass="txtbox reqirerd"></asp:TextBox> </td></tr>
            
            
               
            <tr><td> 
                
                            &#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325;/ Remark&nbsp;&nbsp;&nbsp;</td><td colspan="3">
                            <asp:TextBox ID="txtRemark" onkeypress='javascript:tbx_fnAlphaOnly(event, this);' TextMode="MultiLine" runat="server" MaxLength="200" ></asp:TextBox>
                        </td> </tr>
             <tr>
                        <td colspan="4">
                            <asp:Button Text="&#2337;&#2366;&#2335;&#2366; &#2342;&#2375;&#2326;&#2375;" runat="server"  ID="btnSaveMasterData"  CssClass="btn" OnClick="btnSaveMasterData_Click" Visible="False"/> 
                        </td>
                    </tr>
                        <td colspan="4">
    <asp:GridView ID="grBook" runat="server" AutoGenerateColumns="False"
        CssClass="tab" OnRowDataBound="grBook_RowDataBound">
        <Columns>

            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;. / No.">
                <ItemTemplate>
                    <%#Container.DataItemIndex+1%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&#2330;&#2369;&#2344;&#2375; / Choose">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Eval("PradayBookChalan").ToString()=="0" ? false  : true %>' onclick = "Check_Click(this)"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="&#2357;&#2367;&#2359;&#2351; / Subject" DataField="Title_V" />


            <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2306;&#2337;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No. Of Books Per Bundle">
                <ItemTemplate>
                    <asp:TextBox ID="txtPerbundlebook" Text='<%# Eval("perbundlebook") %>' OnTextChanged="calculate" AutoPostBack="True" runat="server" Width="50px" Enabled="False"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&#2310;&#2348;&#2306;&#2335;&#2344; / Alloted">
                <ItemTemplate>
                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("TitleId") %>' />
                    <asp:TextBox ID="txtNofBooks" Text='<%#Eval("NoofBooks") %>' runat="server" Width="106px" Enabled="False"></asp:TextBox>
                    <asp:HiddenField ID="hdnDetailsid" runat="server"></asp:HiddenField>
                    <asp:HiddenField ID="hdnOrderNoI" Value='<%#Eval("OrderNO") %>' runat="server"></asp:HiddenField>

                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2368; &#2332;&#2366; &#2330;&#2369;&#2325;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;">
                <ItemTemplate>
                    <asp:Label ID="lblAbook" runat="server" Text='<%# Eval("PradayBook") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; / Distribution">
                <ItemTemplate>

                    <asp:TextBox ID="lblnoofbooks" Text='<%#(Eval("PradayBookChalan")) %>' runat="server" Width="106px" AutoPostBack="True" OnTextChanged="calculate"></asp:TextBox>

                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="&#2346;&#2376;&#2325; &#2348;&#2306;&#2337;&#2354; / Pack Bundle">
                <ItemTemplate>
                    <asp:TextBox ID="txtPackbundle" runat="server" Width="106px" Text='<%#(Convert.ToInt32(Eval("PradayBookChalan"))) / Convert.ToInt32(Eval("perbundlebook"))%>'></asp:TextBox>
                </ItemTemplate>


            </asp:TemplateField>
            <asp:TemplateField HeaderText="&#2354;&#2370;&#2360; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No. Of Loose Books">
                <ItemTemplate>
                    <asp:TextBox ID="txtloose" runat="server" Width="106px"  Text='<%#(Convert.ToInt32(Eval("PradayBookChalan"))) % Convert.ToInt32(Eval("perbundlebook"))%>'></asp:TextBox>
                </ItemTemplate>

            </asp:TemplateField>


        </Columns>
        <PagerStyle CssClass="Gvpaging" />
        <EmptyDataRowStyle CssClass="GvEmptyText" />
    </asp:GridView>
                        </td>
                    </tr>
                   
                    
               
           
            
               
            <tr><td> 
                
                            <asp:Button Text="&#2360;&#2381;&#2325;&#2368;&#2350;&#2357;&#2366;&#2352;  &#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2375;&#2326;&#2375; " runat="server"  ID="btnSchemeWise"  CssClass="btn" OnClick="btnSchemeWise_Click" Visible="False" Enabled="False"/> 
                
                </td><td>
                            <asp:Button Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; " runat="server"  ID="btnPrint"  CssClass="btn" OnClick="btnPrint_Click" OnClientClick="return ValidateAllTextForm();"/> 
                        </td> <td>
                            &nbsp;</td><td></td></tr>
            
            
         </table></div>
            
           
       <div id="fadeDiv" runat="server" class="modalBackground" style="display: none">
                </div>
                <script type="text/javascript">
                    function closeMessagesDiv(obj) {
                        // document.getElementById("ContentPlaceHolder1_pnldiv").style.display = "none";
                      <%-- // document.getElementById('<%=pnldiv.ClientID %>').style.display = "none";
                       // document.getElementById('<%=fadeDiv.ClientID %>').style.display = "none";--%>
                        return false;
                    }

                </script>
</asp:Content>

