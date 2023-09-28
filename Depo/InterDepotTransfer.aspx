<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="InterDepotTransfer.aspx.cs" Inherits="Distribution_dreport4" Title="&#2309;&#2306;&#2340;&#2352; &#2337;&#2367;&#2346;&#2379; &#2335;&#2381;&#2352;&#2366;&#2344;&#2381;&#2360;&#2347;&#2352;" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                //Get the Cell To find out ColumnIndex
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        //If the header checkbox is checked
                        //check all checkboxes
                        //and highlight all rows
                        //row.style.backgroundColor = "aqua";
                        inputList[i].checked = true;
                    }
                    else {
                        //If the header checkbox is checked
                        //uncheck all checkboxes
                        //and change rowcolor back to original
                        //if (row.rowIndex % 2 == 0) {
                        //    //Alternating Row Color
                        //    row.style.backgroundColor = "#C2D69B";
                        //}
                        //else {
                        //    row.style.backgroundColor = "white";
                        //}
                        inputList[i].checked = false;
                    }
                }
            }
        }
    </script>
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span style="font-size: medium;">&#2309;&#2306;&#2340;&#2352; &#2337;&#2367;&#2346;&#2379; &#2335;&#2381;&#2352;&#2366;&#2344;&#2381;&#2360;&#2347;&#2352; / InterDepot Transfer </span>
            </h2>
        </div>
        <div style="padding: 0 10px;">
            <table style="width: 100%">
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="3" >
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">&#2350;&#2343;&#2381;&#2351;&#2357;&#2352;&#2381;&#2340;&#2368; &#2350;&#2366;&#2306;&#2327; </asp:ListItem>
                            <asp:ListItem Value="2">&#2351;&#2370; &#2319;&#2306;&#2337; &#2312; &#2327;&#2381;&#2352;&#2369;&#2346; </asp:ListItem>
                            <asp:ListItem Value="3">&#2310;&#2306;&#2325;&#2354;&#2367;&#2340;  &#2337;&#2367;&#2350;&#2366;&#2306;&#2337; </asp:ListItem>
                            <asp:ListItem Value="4">&#2326;&#2369;&#2354;&#2375; &#2348;&#2366;&#2332;&#2366;&#2352; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327; </asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                            <asp:Label ID="LblAcYear" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;<br /> Academic Year :</asp:Label>
                    </td>
                    <td >
                            <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged">
                            </asp:DropDownList>


                    </td>
                    <td>
                            <asp:Label ID="LblScheme" runat="server">&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;  <br /> Medium :</asp:Label>
                    </td>
                    <td>
                            <asp:DropDownList ID="DdlScheme" runat="server" CssClass="txtbox">
                            </asp:DropDownList>

                    </td>
                </tr>
                <tr>
                    <td>&#2337;&#2367;&#2346;&#2379; &#2330;&#2369;&#2344;&#2375;
                        <br />
                        Choose Depot
                    </td>
                    <td >
                        <asp:DropDownList ID="ddlReqDepo" runat="server" AutoPostBack="True"
                            OnInit="ddlReqDepo_Init"
                            OnSelectedIndexChanged="ddlReqDepo_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &#2310;&#2352;&#2381;&#2337;&#2352; &#2344;&#2306;o<br />
                        Order No
                    </td>
                    <td>
                            <asp:DropDownList ID="ddlOrderNo" runat="server"
                            OnInit="ddlOrderNo_Init"
                            OnSelectedIndexChanged="ddlOrderNo_SelectedIndexChanged">
                        </asp:DropDownList>

                    </td>
                </tr>
                <tr id="tr1" runat="server" visible="false">
                    <td>
                <span style="font-size: medium;">&#2309;&#2306;&#2340;&#2352; &#2337;&#2367;&#2346;&#2379; &#2335;&#2381;&#2352;&#2366;&#2344;&#2381;&#2360;&#2347;&#2352;<br />
                        </span>
                        &#2310;&#2352;&#2381;&#2337;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br />
                        Order Date
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtChallanDate"   CssClass="txtbox reqirerd" MaxLength="10"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtRecivedDate_CalendarExtender" runat="server" TargetControlID="txtChallanDate"
                        Format="dd/MM/yyyy">
                    </cc1:CalendarExtender>
                    </td>
                    <td>
                <span style="font-size: medium;">&#2309;&#2306;&#2340;&#2352; &#2337;&#2367;&#2346;&#2379; &#2335;&#2381;&#2352;&#2366;&#2344;&#2381;&#2360;&#2347;&#2352;<br />
&nbsp;</span>&#2310;&#2352;&#2381;&#2337;&#2352; &#2344;&#2306;o<br />
                        Order No</td>
                    <td><asp:TextBox runat="server" ID="txtOrderNo"   CssClass="txtbox reqirerd"  ReadOnly="true"></asp:TextBox></td>
                </tr>


                <tr id="tr2" runat="server" >
                    <td colspan="4">
                        &#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340; :
                        <asp:TextBox ID="TextBox1" runat="server" Visible="False" Width="104px" Text="100"></asp:TextBox>
                    </td>
                </tr>

                <tr id="tr4" runat="server" >
                    <td colspan="4">
                        <asp:Button ID="Button3" runat="server" CssClass="btn" OnClick="Button3_Click" Text="Show Data" />
                    </td>
                </tr>
                
                <tr id="tr121" runat="server">
                    <td colspan="3">
                        &#2351;&#2342;&#2367; &#2346;&#2381;&#2352;&#2375;&#2359;&#2325; &#2337;&#2367;&#2346;&#2379; &#2360;&#2349;&#2368; &#2319;&#2325; &#2361;&#2379; &#2340;&#2379; &#2311;&#2360; &#2337;&#2381;&#2352;&#2366;&#2346;&#2337;&#2366;&#2313;&#2344; &#2325;&#2379; &#2360;&#2375;&#2354;&#2375;&#2325;&#2381;&#2335; &#2325;&#2352;&#2375;&#2306; :<asp:DropDownList ID="DropDownList1" runat="server">
                        </asp:DropDownList>
                        <asp:Button ID="Button4" runat="server" CssClass="btn" OnClick="Button4_Click" Text="&#2325;&#2381;&#2354;&#2367;&#2325; &#2325;&#2352;&#2375;&#2306; " />
                    </td>
                    <td>&nbsp;</td>
                </tr>

                <tr>
                    <td colspan="4">

                        <asp:GridView ID="GrdDepoQtyMaster" runat="server" AutoGenerateColumns="false" GridLines="None"
                            CssClass="tab" Width="100%" EmptyDataText="Record Not Found."
                            OnRowDataBound="GrdDepoQtyMaster_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Sr. No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="  &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2325; &#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350, / Depot Name">
                                    <ItemTemplate>

                                        <asp:Label ID="lblDemandTrNo" runat="server" Text='<%#Eval("DemandTrNo")%>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblNetDemand" runat="server" Text='<%#Eval("NetDemand")%>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblDemandingDepotID" runat="server" Text='<%#Eval("DemandingDepotID")%>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblReqNo" runat="server" Text='<%#Eval("ReqNo")%>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblTitleID_I" runat="server" Text='<%#Eval("TitleID_I")%>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblIsScheme" runat="server" Text='<%#Eval("IsScheme")%>' Visible="false"></asp:Label>
                                        <%#Eval("DepoName_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366; / Class ">
                                    <ItemTemplate>
                                        <%#Eval("Classdet_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2350;&#2366;&#2343;&#2381;&#2351;&#2350; / Medium">
                                    <ItemTemplate>
                                        <%#Eval("MediunNameHindi_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; / Book Type">
                                    <ItemTemplate>
                                        <%#Eval("BookType")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2357;&#2367;&#2359;&#2351; / Subject">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkBookDetails" runat="server" Width="92px" CommandArgument='<%#Eval("TitleID_I")%>' OnCommand="lnkBookDetails_Click"><%#Eval("TitleHindi_V")%></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2350;&#2366;&#2306;&#2327; / Demand">
                                    <ItemTemplate>
                                        <%#Eval("NetDemand")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2358;&#2375;&#2359; / Balance">
                                    <ItemTemplate>

                                        <asp:Label ID="lblTotRemaing" runat="server" Text='<%#Eval("TotRemaing")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2330;&#2369;&#2344;&#2375; / Choose">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="ChkHeaderSelect" runat="server" onclick="checkAll(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkSelect" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2335;&#2381;&#2352;&#2366;&#2306;&#2360;&#2347;&#2352; &#2325;&#2368; &#2332;&#2366;&#2344;&#2375;&#2357;&#2366;&#2354;&#2368; </br>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / Transferd Book No. ">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtQtySupp" onkeypress='javascript:tbx_fnInteger(event, this);' runat="server" MaxLength="10" CssClass="txtbox" Width="78px" Text='<%#Eval("TotRemaing")%>'></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="Red" ControlToValidate="txtQtySupp" Text="*" ErrorMessage="Invalid Quantity." runat="server" ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2375;&#2359;&#2325; &#2337;&#2367;&#2346;&#2379; / Sender Depot">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlDepoSupp" runat="server" CssClass="txtbox" OnInit="ddlDepoSupp_Init">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>

                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Visible="false"
                            Text="&#2335;&#2381;&#2352;&#2366;&#2306;&#2360;&#2347;&#2352; &#2325;&#2352;&#2375; / Transfer"
                            OnClick="btnSave_Click" OnClientClick="return ValidateAllTextForm();" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
    </div>
    <div id="Messages" style="display: none; height: 300px; overflow: auto;" class="popupnew" runat="server">
        <h2>&nbsp;</h2>
        <div class="msg MT10">
            <p>
                <asp:GridView ID="GrdPopUp" runat="server" AutoGenerateColumns="false" GridLines="None"
                    CssClass="tab" Width="100%" EmptyDataText="Record Not Found.">
                    <Columns>
                        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>.
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350;">
                            <ItemTemplate>
                                <%#Eval("DepotName")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;">
                            <ItemTemplate>
                                <%#Eval("Title")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; &#2361;&#2375;&#2340;&#2369; &#2360;&#2381;&#2335;&#2377;&#2325;">
                            <ItemTemplate>
                                <%#Eval("samanya")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="&#2351;&#2379;&#2332;&#2344;&#2366; &#2361;&#2375;&#2340;&#2369; &#2360;&#2381;&#2335;&#2377;&#2325;">
                            <ItemTemplate>
                                <%#Eval("yojna")%>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                </asp:GridView>
            </p>
            <asp:Button ID="Button2" runat="server" CssClass="btn" Text="Close" OnClick="Button2_Click" />
        </div>
    </div>
</asp:Content>
