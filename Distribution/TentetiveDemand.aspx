<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TentetiveDemand.aspx.cs"
    Inherits="Distribution_TentetiveDemand" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">

        function CheckAll(rb) {
            var gv = document.getElementById("<%= ddlClass.ClientID  %>");

            var rbs = gv.getElementsByTagName("input");

            var row = rb.parentNode.parentNode;

            for (var i = 0; i < rbs.length; i++) {
                if (rbs[i].type == "checkbox") {
                    rbs[i].checked = document.getElementById('chkSelect').checked;
                }
            }
            if (document.getElementById('chkSelect').checked == true) {
                document.getElementById('Name').innerHTML = "&#2360;&#2349;&#2368; &#2361;&#2335;&#2366;&#2351;&#2375;";
            }
            else {
                document.getElementById('Name').innerHTML = "&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375;";
            }
            // alert(document.getElementById('Name').innerHTML);
        }

    </script>
    <div class="card">
        <div class="card-body">
            <div class="card-header">
                <h2>योजना के अंतर्गत अनुमानित मांग </h2>
            </div>
            <div class="row g-3">
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control reqirerd"
                            OnInit="ddlYear_Init">
                        </asp:DropDownList>
                        <label id="Label7" runat="server">शिक्षा सत्र </label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlMedum" runat="server" CssClass="form-control reqirerd"
                            OnInit="ddlMedum_Init" >
                        </asp:DropDownList>
                        <label id="Label1" runat="server">माध्यम </label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control reqirerd"
                            OnInit="ddlDistrict_Init">
                        </asp:DropDownList>
                        <label id="Label3" runat="server">जिला </label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="">
                         <label id="Label4" runat="server">कक्षा </label>
                        <label id="Name">&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; / Select All </label>
                        <input type="checkbox" id="chkSelect" value="सभी चुने " name="सभी चुने" onclick="CheckAll(this);" />
                        <asp:CheckBoxList ID="ddlClass" OnInit="ddlClass_Init" RepeatDirection="Horizontal" RepeatColumns="8" TextAlign="Left" runat="server" CssClass="table reqirerd">
                        </asp:CheckBoxList>
                       
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:Button ID="btnSearch" runat="server" Text="खोजे "
                            CssClass="btn btn-primary" OnClick="btnSearch_Click" OnClientClick="return ValidateAllTextForm();" />
                        <asp:RadioButtonList ID="RadBtnListAgency" runat="server"
                            RepeatDirection="Horizontal" Visible="False">
                            <asp:ListItem>&#2351;&#2379;&#2332;&#2344;&#2366; / Scheme </asp:ListItem>
                            <asp:ListItem>&#2326;&#2369;&#2354;&#2375; &#2348;&#2366;&#2395;&#2366;&#2352; / Open Market </asp:ListItem>
                        </asp:RadioButtonList>
                </div>
                <div class="col-md-12">
                    <asp:DataList ID="DlHsty" runat="server" RepeatColumns="10" OnItemDataBound="DlHsty_ItemDataBound"
                                    RepeatLayout="Table" BorderWidth="1" BorderStyle="solid" BorderColor="Gray">
                                    <ItemTemplate>

                                        <table width="100%" cellpadding="0" class="tabmain" cellspacing="0">
                                            <tr style="background-color: #618509; padding: 8px; color: #fff;">

                                                <td colspan="2" style="text-align: center;" valign="top">
                                                    <%#Eval("BlockNameHindi_V")%>
                                                    <asp:Label ID="lblBlockID" runat="server" Text='<%#Eval("BlockID")%>' Visible="false"></asp:Label>

                                                    <asp:Label ID="lblDistrictID" runat="server" Text='<%#Eval("DistrictID")%>' Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr style="background-color: #f4fcdf; border-bottom: 1px solid #618509; color: #618509">
                                                <td id="tdRow" runat="server"></td>
                                                <td valign="top" align="center">

                                                    <table width="100%" style="text-align: center; padding: 5px;">
                                                        <tr>
                                                            <td width="25%" style="text-align: center;"><%#Eval("AcYear3")%></td>
                                                            <td width="25%" style="text-align: center;"><%#Eval("AcYear2")%></td>
                                                            <td width="25%" style="text-align: center;"><%#Eval("AcYear1")%></td>
                                                            <td width="25%" style="text-align: center;"><%#Eval("CurrentAcYear")%></td>
                                                        </tr>
                                                    </table>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td colspan="2" valign="top">
                                                    <asp:GridView ID="GvChild" runat="server" AutoGenerateColumns="false" CellPadding="0" CellSpacing="0" ShowHeader="false"
                                                        ShowFooter="false" OnRowDataBound="GvChild_RowDataBound" GridLines="Both">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <table width="100%" class="tab01" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <th id="tdGvRow" runat="server">
                                                                                <asp:Label ID="lblTitleHindi_V" runat="server" Text='<%#Eval("TitleHindi_V")%>'></asp:Label>
                                                                                <asp:Label ID="lblTiTleID" runat="server" Text='<%#Eval("TiTleID")%>' Visible="false"></asp:Label>
                                                                            </th>
                                                                            <td>
                                                                                <table width="300" cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td id="TdGvId" runat="server" width="50">

                                                                                            <asp:Label ID="lblDistrictID" runat="server" Text='<%#Eval("DistrictID")%>' Visible="false"></asp:Label>
                                                                                            <asp:Label ID="lblBlockID" runat="server" Text='<%#Eval("BlockID_121")%>' Visible="false"></asp:Label>
                                                                                            <asp:Label ID="lbltTiTleID" runat="server" Text='<%#Eval("tTiTleID")%>' Visible="false"></asp:Label>



                                                                                            <asp:Label ID="lblAcYear3" runat="server" Text='<%#Eval("AcYear3")%>' Visible="false"></asp:Label>
                                                                                            <asp:Label ID="lblAcYear2" runat="server" Text='<%#Eval("AcYear2")%>' Visible="false"></asp:Label>
                                                                                            <asp:Label ID="lblAcYear1" runat="server" Text='<%#Eval("AcYear1")%>' Visible="false"></asp:Label>


                                                                                            <div>

                                                                                                <asp:Label ID="lblCurrent3" runat="server"></asp:Label>
                                                                                                <%--<%#Eval("Current-3")%>--%>
                                                                                            </div>
                                                                                        </td>
                                                                                        <td width="50">
                                                                                            <asp:Label ID="lblCurrent2" runat="server"></asp:Label>
                                                                                            <%-- <%#Eval("Current-2")%>--%>
                                                                                        </td>
                                                                                        <td width="50">
                                                                                            <div>
                                                                                                <asp:Label ID="lblCurrent1" runat="server"></asp:Label>
                                                                                                <%--<%#Eval("Current-1")%>--%>
                                                                                            </div>
                                                                                        </td>
                                                                                        <td width="50">
                                                                                            <div>
                                                                                                <asp:TextBox ID="txtQty" runat="server" Width="30" Height="10px" Text='<%#Eval("Current")%>' MaxLength="10" onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox>
                                                                                            </div>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>

                                    </ItemTemplate>
                                </asp:DataList>
                </div>
                <div class="col-md-12">
                    <asp:Button ID="btnSave" runat="server" Text="सुरक्षित करे" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
