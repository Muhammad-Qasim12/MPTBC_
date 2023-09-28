<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DemandfromOthers.aspx.cs" Inherits="DistributionB_DemandfromOthers"
    Title="&#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327;" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript">
        function SelectDistrinct(obj) {
            document.getElementById('<%=fadeDiv.ClientID %>').style.display = 'block';
            document.getElementById('<%=Messages.ClientID%>').style.display = 'block';

        }

        function CloseDistrictSelection() {
            document.getElementById('<%=fadeDiv.ClientID %>').style.display = 'none';
            document.getElementById('<%=Messages.ClientID%>').style.display = 'none';
        }

        function Copyall(chkid) {
            //ctl00_ContentPlaceHolder1_tblBlockwise
            var val;
            var table = document.getElementById("ctl00_ContentPlaceHolder1_tblBlockwise");
            var column_count0 = table.rows[0].cells.length;
            var column_count1 = table.rows[1].cells.length;

            //alert(chkid.checked);

            var rowcount = (table.rows.length) - 2;
            var firstval = "0"; var cnt = 0;
            //alert(rowcount);
            if (rowcount > 0) {
                //var column_count2 = table.rows[2].cells.length;
                //alert(column_count2);
                for (var index = 2; index < (table.rows.length) ; index++) {
                    //alert("indx-" + index);
                    var column_count2 = table.rows[index].cells.length;
                    for (var j = 1; j < column_count2; j++) {
                        var element;
                        var elements = table.rows[index].cells[j].getElementsByTagName('input');
                        //alert(elements.length)
                        if (elements.length > 0) {
                            element = elements[0];
                            //alert(element.id.indexOf("txtDistrict"));
                            //alert("elem-" + element);
                            //alert(element.id);
                            if (element.id.indexOf("txtDistrict") != -1) {
                                var obj = document.getElementById(element.id);
                                if (parseInt(firstval) == 0) {
                                    firstval = obj.value;
                                }
                                if (chkid.checked) {
                                    obj.value = firstval;
                                }
                                else {
                                    cnt++;
                                    if (cnt > 1) {
                                        obj.value = '';
                                    }
                                }


                            }
                        }
                    }

                }
            }
            //alert(rowcount); alert(column_count0); alert(column_count1);
        }
    </script>
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
            <div class="box table-responsive">
                <div class="card-header">
                    <h2>
                        <span>&#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368;
                            &#2325;&#2368; &#2350;&#2366;&#2306;&#2327; / Demand of Other then TextBook Items</span></h2>
                </div>
                <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
                    <asp:Panel class="form-message error" runat="server" ID="mainDiv" Style="display: none; padding-top: 10px; padding-bottom: 10px;">
                        <asp:Label ID="lblmsg" class="notification" runat="server"> </asp:Label>

                    </asp:Panel>
                    <table class="tab">
                        <tr>
                            <td colspan="6">
                                <asp:HiddenField ID="hdnDenmandID" runat="server" />
                                <asp:HiddenField ID="hdnTitleCnt" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>&#2350;&#2366;&#2306;&#2327;&#2325;&#2352;&#2381;&#2340;&#2366; &#2360;&#2306;&#2360;&#2381;&#2341;&#2366; / Demand From Department
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlDemandFrom">
                                </asp:DropDownList>
                            </td>
                            <td>&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlAcademicYr" OnSelectedIndexChanged="ddlAcademicYr_OnSelectedIndexChanged"
                                    AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                            <td>&#2357;&#2367;&#2340;&#2381;&#2340;&#2368;&#2351; &#2357;&#2352;&#2381;&#2359; / Financial Year
                            </td>
                            <td>
                                <asp:Label ID="lblFinancialYr" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>&#2350;&#2366;&#2306;&#2327;&#2325;&#2352;&#2381;&#2340;&#2366; &#2357;&#2367;&#2349;&#2366;&#2327; &#2325;&#2366; &#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Demanding Department Letter No. 
                            </td>
                            <td>
                                <asp:TextBox ID="txtLetterNo" MaxLength="30" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                            </td>
                            <td>&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Letter Date
                            </td>
                            <td>
                                <asp:TextBox ID="txtLetterDate" MaxLength="12" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender ID="calLetterDate" TargetControlID="txtLetterDate" Format="dd/MM/yyyy"
                                    runat="server" Enabled="True">
                                </cc1:CalendarExtender>

                            </td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>&#2352;&#2375;&#2398;&#2352;&#2344;&#2381;&#2360; &#2354;&#2376;&#2335;&#2352; &#2325;&#2381;&#2352;&#2306; / Reference Letter No.
                            </td>
                            <td>
                                <asp:TextBox ID="txtRefLetterNo" MaxLength="30" CssClass="txtbox"
                                    runat="server"></asp:TextBox>
                            </td>
                            <td>&#2352;&#2375;&#2398;&#2352;&#2344;&#2381;&#2360; &#2354;&#2376;&#2335;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Reference Letter Date
                            </td>
                            <td>
                                <asp:TextBox ID="txtRefLetterDate" MaxLength="12" CssClass="txtbox"
                                    runat="server"></asp:TextBox>
                                <cc1:CalendarExtender ID="calExt" TargetControlID="txtRefLetterDate" Format="dd/MM/yyyy"
                                    runat="server" Enabled="True">
                                </cc1:CalendarExtender>

                            </td>
                            <td>डिमांड टाइप </td>
                            <td>
                                <asp:DropDownList ID="DDlDemandType" runat="server" CssClass="txtbox">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>&#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2366;&#2327;&#2381;&#2352;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350; / Other then TextBook Item
                            </td>
                            <td colspan="5">
                                <asp:DropDownList runat="server" ID="ddlTitle" RepeatColumns="4" RepeatDirection="Horizontal">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6"></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButtonList ID="rdlOfficeName" AutoPostBack="True" runat="server" CssClass="reqirerd"
                                    OnSelectedIndexChanged="rdlOfficeName_OnSelectedIndexChanged">
                                    <asp:ListItem Value="1">&#2357;&#2367;&#2325;&#2366;&#2360;&#2326;&#2306;&#2337;&#2357;&#2366;&#2352; &#2350;&#2366;&#2306;&#2327;/ Blockwise Demand</asp:ListItem>
                                    <asp:ListItem Value="2">&#2332;&#2367;&#2354;&#2366;&#2357;&#2366;&#2352; &#2350;&#2366;&#2306;&#2327;/ Districtwise Demand</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <asp:Label ID="lblDist" runat="server" Visible="False" Text="&#2337;&#2367;&#2346;&#2379; &#2330;&#2369;&#2344;&#2375;&#2306; / Depo "></asp:Label>
                                <br />
                                <asp:Label ID="lblDivision" runat="server" Text="&#2360;&#2306;&#2349;&#2366;&#2327; &#2330;&#2369;&#2344;&#2375; "></asp:Label>
                                <br />
                                <asp:DropDownList ID="ddlDivision" runat="server" Visible="False">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDistrict" Visible="False" AutoPostBack="True" CssClass="txtbox reqirerd"
                                    OnSelectedIndexChanged="ddlDistrict_OnSelectedIndexChanged" runat="server">
                                </asp:DropDownList>
                                <br />
                                <asp:Label ID="Label1" runat="server" Text="District Name :" Visible="False"></asp:Label>
                                <br />
                                <asp:DropDownList ID="ddlDistrictM" runat="server" AutoPostBack="True" CssClass="txtbox reqirerd" OnSelectedIndexChanged="ddlDistrictM_SelectedIndexChanged" Visible="False">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <br />
                                <asp:CheckBox ID="ChkOtherAgency" runat="server" Visible="false"
                                    Text="&#2309;&#2344;&#2381;&#2351; &#2360;&#2306;&#2360;&#2381;&#2341;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; / Other Department Name" />
                            </td>
                            <td>
                                <asp:TextBox runat="server" MaxLength="70" CssClass="txtbox reqirerd"
                                    ID="TxtOtherAgency" Visible="False"></asp:TextBox>
                                <asp:DropDownList ID="ddlOtherORG" runat="server" AutoPostBack="True" CssClass="txtbox reqirerd" OnSelectedIndexChanged="ddlOtherORG_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:CheckBoxList ID="chkOffice" runat="server" RepeatDirection="Horizontal" Visible="False">
                                    <asp:ListItem Value="2"> &#2337;&#2368; &#2346;&#2368; &#2360;&#2368;  &#2325;&#2366;&#2352;&#2381;&#2351;&#2366;&#2354;&#2351;</asp:ListItem>
                                    <asp:ListItem Value="3"> &#2337;&#2366;&#2312;&#2335;  &#2325;&#2366;&#2352;&#2381;&#2351;&#2366;&#2354;&#2351; </asp:ListItem>
                                </asp:CheckBoxList>
                                <asp:Button ID="BtnViewAll" runat="server" CssClass="btn" Text=" &#2342;&#2375;&#2326;&#2375;&#2306; / View" OnClick="BtnViewAll_Click" />
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="font-size: medium;">
                                <div class="tabpad">
                                    <asp:DataList ID="gridDetails" runat="server" EnableViewState="true" AutoGenerateColumns="false" ShowHeader="false"
                                        OnItemDataBound="gridDetails_ItemDataBound">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnkey" runat="server" Value='<%#Eval("BlockTrno_I") %>' />
                                            <div class="tabth">
                                                <asp:Label ID="lbas" Text='<%#Eval("BlockNameHindi_V") %>' runat="server"></asp:Label>
                                            </div>
                                            <asp:GridView ID="grdTitlegrid" CssClass="tab" Style="margin: 0px;" ShowHeader="false" runat="server"
                                                AutoGenerateColumns="false" OnRowDataBound="gridDetails_RowDataBound" ShowFooter="false">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="book name">
                                                        <ItemTemplate>
                                                            <asp:Label Text='<%#Eval("Title") %>' ID="txtl" runat="server" Width="350"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                                                                       <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="tilleid" runat="server" Value='<%#Eval("SubTitleID") %>' />
                                                            <asp:TextBox ID="txtDemand" CssClass="reqirerd" onkeypress='javascript:tbx_fnInteger(event, this);' runat="server" Width="60" MaxLength="10" Text="0"></asp:TextBox>

                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <asp:Label ID="lblFooterSum" runat="server" Visible="false"></asp:Label>

                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerStyle CssClass="Gvpaging" />
                                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                                            </asp:GridView>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </div>
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>&#2354;&#2376;&#2335;&#2352; &#2325;&#2368; &#2360;&#2381;&#2325;&#2376;&#2344;
                                            &#2346;&#2381;&#2352;&#2340;&#2367;&#2354;&#2367;&#2346;&#2367; &#2309;&#2346;&#2354;&#2379;&#2337;
                                            &#2325;&#2352;&#2375;  / Upload Scan Copy of Letter   
                                 <asp:FileUpload ID="fileScanLetter" runat="server" />
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>&#2325;&#2369;&#2354; &#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2366;&#2327;&#2381;&#2352;&#2368; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; /&nbsp; Total Demand of Other then TextBook Items :
                                            <asp:Label ID="lblTotalTitles" runat="server" Text="0"></asp:Label>
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button runat="server" OnClick="btnSave_Click" ID="btnSave" OnClientClick='javascript:return ValidateAllTextForm();'
                                    Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; "
                                    CssClass="btn" />
                                <asp:HiddenField ID="mapID" runat="server" />
                                <asp:Button ID="btnFinailise" runat="server" CssClass="btn"
                                    OnClick="btnFinailise_Click"
                                    OnClientClick="javascript:return ValidateAllTextForm();" Text="&#2347;&#2366;&#2311;&#2344;&#2354; &#2325;&#2352;&#2375; " />
                                <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" CssClass="btn" Text="&#2357;&#2366;&#2346;&#2360; &#2332;&#2366;&#2319;&#2306;" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
                    </div>
                    <div id="Messages" style="display: none;" class="popupnew1" runat="server">
                        <h2>&#2332;&#2367;&#2354;&#2379;&#2306; &#2325;&#2366; &#2330;&#2351;&#2344; &#2325;&#2352;&#2375;&#2306;
                        </h2>
                        <div style="overflow: scroll; height: 500px;">
                            <asp:CheckBoxList ID="chklstDistrict" runat="server">
                            </asp:CheckBoxList>
                        </div>
                        <asp:Button runat="server" OnClick="btnCloseDistrictSelection_Click" ID="btnCloseDistrictSelection"
                            OnClientClick="CloseDistrictSelection()" Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375; "
                            CssClass="btn" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:HiddenField ID="hdnblockid" runat="server" />
</asp:Content>
