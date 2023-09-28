<%@ Page Title="&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2344;&#2367;&#2357;&#2367;&#2342;&#2366; &#2325;&#2375; &#2354;&#2367;&#2319; &#2327;&#2381;&#2352;&#2369;&#2346; &#2344;&#2367;&#2352;&#2381;&#2350;&#2366;&#2339;" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="GroupCreation.aspx.cs" Inherits="AcademicB_GroupCreation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="headlines">
            <h2>
                <span>&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2344;&#2367;&#2357;&#2367;&#2342;&#2366; &#2325;&#2375; &#2354;&#2367;&#2319; &#2327;&#2381;&#2352;&#2369;&#2346; &#2344;&#2367;&#2352;&#2381;&#2350;&#2366;&#2339;/Group Creation for Printing Tender</span></h2>
        </div>
        <div style="padding: 0 10px;">
            <asp:Panel class="form-message error" runat="server" ID="mainDiv" Style="display: none; padding-top: 10px; padding-bottom: 10px;">
                <asp:Label ID="lblmsg" class="notification" runat="server">                
                </asp:Label>
            </asp:Panel>
            <table class="tab">

                <tr>
                    <td>
                        <asp:Label ID="LblAcYear" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:HiddenField ID="hdnGrpId_I" Value="" runat="server" />
                    </td>
                </tr>


                <tr>
                    <td>&#2327;&#2381;&#2352;&#2369;&#2346; &#2344;&#2306;&#2348;&#2352;/Group No.
                    </td>
                    <td>
                        <asp:TextBox ID="txtGroupName" CssClass="txtbox reqirerd" onkeypress='javascript:tbx_fnAlphaNumericOnly(event, this);' MaxLength="7" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; /Title
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTitle" AutoPostBack="true" CssClass="txtbox reqirerd" OnSelectedIndexChanged="ddlTitle_OnSelectedIndexChanged"
                            runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>&#2313;&#2346; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; /Sub-Title
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSubTitle" AutoPostBack="true" 
                            OnSelectedIndexChanged="ddlSubTitle_OnSelectedIndexChanged" runat="server">
                        </asp:DropDownList>
                        <br />
                            <asp:Button ID="Button2" OnClick="Button2_Click" runat="server" CssClass="btn" 
                                Text="Merge All Title" Height="24px" Width="155px" />
                    </td>
                </tr>

                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:DataList ID="DlistGroup0" runat="server" RepeatColumns="8"  RepeatDirection="Horizontal" 
                                        OnSelectedIndexChanged="DlistGroup0_SelectedIndexChanged">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSubTitleName" AutoPostBack="true" runat="server" Text='<%#Eval("SubTitleHindi_V") %>' OnCheckedChanged="chkGroupName1_CheckedChanged"   />
                                            <asp:Label ID="lblSubTitle" runat="server" Text='<%#Eval("SubTitleID_I") %>' Visible="false"></asp:Label>

                                        </ItemTemplate>
                                    </asp:DataList>
                    </td>
                </tr>

                <tr><td>&#2348;&#2369;&#2325; &#2350;&#2366;&#2352;&#2381;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Bookmark Name
                                </td><td>  <asp:DataList ID="DlistGroup" runat="server" RepeatColumns="8"  RepeatDirection="Horizontal" 
                                        OnSelectedIndexChanged="DlistGroup_SelectedIndexChanged">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkGroupName" AutoPostBack="true" runat="server" Text='<%#Eval("GroupName") %>' OnCheckedChanged="chkGroupName_CheckedChanged" />
                                            <asp:Label ID="lblGroupId" runat="server" Text='<%#Eval("GroupId") %>' Visible="false"></asp:Label>

                                        </ItemTemplate>
                                    </asp:DataList>
                                </td></tr>

                <tr>
                    <td>EMD &#2352;&#2366;&#2358;&#2368; &#2352;&#2369;. / EMD Amount Rs.</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtEMDAmount_N" CssClass="txtbox reqirerd" MaxLength="8" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'></asp:TextBox>
                    </td>

                </tr>
            </table>
            <asp:Panel runat="server" ID="pnlBookDes" GroupingText=" &#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2330;&#2351;&#2344; / Select Depo" Width="1150px"
                ScrollBars="Auto">
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="grdDepo" CssClass="tab" runat="server" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="">
                                         <HeaderTemplate>
                                        <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this);" />
                                         </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelectDepo" runat="server" />
                                             <asp:HiddenField ID="hdnGrpBookmarkid" runat="server" Value='<%# Eval("Grpbookmarkid") %>'></asp:HiddenField>
                                            <asp:HiddenField ID="hdnGrpBookmarkname" runat="server" Value='<%# Eval("Grpbookmarkname") %>'></asp:HiddenField>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/S.No.">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; /Title " />
                                    <asp:BoundField DataField="SubTitleHindi_V" HeaderText="&#2313;&#2346; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; /Sub-Title" />
                                    <asp:BoundField DataField="DepoName_V" HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; /Depo" />
                                    <asp:BoundField DataField="TotalItems_I" HeaderText="&#2310;&#2348;&#2306;&#2335;&#2344;  &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;/Allotment" />
                                    <asp:BoundField DataField="DptPaperQty_N" DataFormatString="{0:F3}" HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; (&#2335;&#2344; &#2350;&#2375; )/ Printing Paper Quantity(Ton)" />
                                       <asp:BoundField DataField="DptCoverQty_N" DataFormatString="{0:F3}" HeaderText="&#2325;&#2357;&#2352; &#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; (&#2335;&#2344; &#2350;&#2375; )/ Cover Paper Quantity(Ton)" />
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDepoID" runat="server" Text='<%# Eval("DepoID_I") %>'></asp:Label>
                                            <asp:Label ID="lblTitleID" runat="server" Text='<%# Eval("TitleID_I") %>'></asp:Label>
                                            <asp:Label ID="lblSubTitleID" runat="server" Text='<%# Eval("SubTitleID_I") %>'></asp:Label>
                                            <asp:Label ID="lblDemandID" runat="server" Text='<%# Eval("DemandID_I") %>'></asp:Label>
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnAddTitle" OnClick="btnAddTitle_Click" runat="server" CssClass="btn" Visible="false"
                                OnClientClick='javascript:return ValidateAllTextForm();' Text="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2332;&#2379;&#2337;&#2375;&#2306;/Add Title" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlSelectedTitle" GroupingText=" &#2330;&#2351;&#2344;&#2367;&#2340; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325;/Selected Titles" Width="1150px"
                ScrollBars="Auto" Visible="false">
                <table>
                    <tr>
                        <td colspan="4">
                            <asp:GridView ID="grdSelectedTitle" CssClass="tab" runat="server" OnRowDeleting="grdSelectedTitle_OnRowDeleting" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/S.No.">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Title" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;/Title " />
                                    <asp:BoundField DataField="SubTitle" HeaderText="&#2313;&#2346; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; /Sub-Title " />
                                    <asp:BoundField DataField="DepoName" HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; /Depo" />
                                    <asp:BoundField DataField="TotalSupply" HeaderText="&#2310;&#2348;&#2306;&#2335;&#2344;  &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;/Allotment" />
                                    <asp:BoundField DataField="PaperQty" DataFormatString="{0:F3}" HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; (&#2335;&#2344; &#2350;&#2375; )/Printing Paper Quantity(Ton)" />
                                    <asp:BoundField DataField="PaperQty" DataFormatString="{0:F3}" HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; (&#2335;&#2344; &#2350;&#2375; )/Printing Paper Quantity(Ton)" />
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSubTitleID" runat="server" Text='<%# Eval("SubTitleID") %>'></asp:Label>
                                            <asp:Label ID="lblDepoID" runat="server" Text='<%# Eval("DepoTrno") %>'></asp:Label>
                                            <asp:Label ID="lblDemandID" runat="server" Text='<%# Eval("DemandID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnDelete" CssClass="btn" runat="server" CommandName="Delete" Text="&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375;/Delete"
                                                OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                            </asp:GridView>
                        </td>
                    </tr>
                  
                </table>
            </asp:Panel>
            <div>
                <table>
                      <tr>
                        <td>
                            <asp:Button ID="Button1" OnClick="btnSave_Click" runat="server" CssClass="btn" OnClientClick='javascript:return ValidateAllTextForm();'
                                Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306;" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        inputList[i].checked = true;
                    }
                    else {
                        inputList[i].checked = false;
                    }
                }
            }
        }
    </script>
</asp:Content>
