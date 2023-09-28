<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PRI001_Group_ReAllocation.aspx.cs" Inherits="PRI001_Group_ReAllocation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="portlet-header ui-widget-header">
        &#2335;&#2375;&#2306;&#2337;&#2352; &#2327;&#2381;&#2352;&#2369;&#2346; &#2346;&#2369;&#2344;&#2307; &#2310;&#2357;&#2306;&#2335;&#2344;/Tender Group Re-allocation
    </div>
    <div class="portlet-content">
        <div class="table-responsive">
            <asp:Panel ID="messDiv" runat="server">
                <asp:Label runat="server" ID="lblMess" class="notification"></asp:Label>
            </asp:Panel>
            <table width="100%">
                <tr>
                    <td>
                        <asp:Label ID="LblAcYear" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year</asp:Label>
                    </td>
                    <td>
                        From Printer</td>
                    <td>&#2358;&#2368;&#2352;&#2381;&#2359;&#2325;/ Title</td>
                    <td>
                         To Printer</td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                            <asp:ListItem>..Select..</asp:ListItem>
                            <asp:ListItem>2012-13</asp:ListItem>
                            <asp:ListItem>2013-14</asp:ListItem>
                            <asp:ListItem>2014-15</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPrinter" runat="server" Width="300px" AutoPostBack="true" CssClass="txtbox" OnSelectedIndexChanged="ddlPrinter_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;<asp:DropDownList ID="ddlTital" runat="server" CssClass="txtbox" Width="300px" OnSelectedIndexChanged="ddlTital_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem>--Select--</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                         <asp:DropDownList ID="ddlToPrinter" runat="server" Width="350px" CssClass="txtbox reqirerd" AutoPostBack="True" OnSelectedIndexChanged="ddlToPrinter_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td>
                        <asp:GridView ID="GrdEval" runat="server" CssClass="tab hastable" AutoGenerateColumns="false" OnRowDataBound="GrdEval_RowDataBound" PageSize="20">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chk" Checked='<%# Eval("allotdate").ToString()=="" ? false  : true %>' />
                                        <asp:HiddenField runat="server" ID="tenreallotid_i" Value='<%# Int32.Parse(Eval("tenreallotid_i").ToString()) %>'></asp:HiddenField>

                                        <asp:HiddenField runat="server" ID="HdnDepoID" Value='<%# Eval("depoid_i") %>'></asp:HiddenField>
                                        <asp:HiddenField runat="server" ID="HndTitleid" Value='<%# Eval("titleid_i") %>'></asp:HiddenField>
                                        <asp:HiddenField runat="server" ID="HndTenderid" Value='<%# Eval("tenderid_i") %>'></asp:HiddenField>
                                        <asp:HiddenField runat="server" ID="HndGrpid_i" Value='<%# Eval("grpid_i") %>'></asp:HiddenField>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:BoundField DataField="tenderno_v" HeaderText="Tender No" />
                                <asp:BoundField DataField="deponame_v" HeaderText="Depo" />
                                <%--<asp:BoundField DataField="qty" HeaderText="Qty." />--%>

                                <asp:TemplateField HeaderText="No of Books">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtQty" runat="server" Text='<%# Eval("qty") %>' CssClass="txtbox reqirerd"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                               <%-- <asp:TemplateField HeaderText="Printers" ItemStyle-Width="350px">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlPrinter" runat="server" Width="350px" CssClass="txtbox reqirerd"></asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Rate" ItemStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtRate" Text='<%# Eval("ratequoated_n") %>' runat="server" Width="100px" CssClass="txtbox reqirerd" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtDate" runat="server" Text='<%# Eval("allotdate") %>' MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                            Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>

                                    </ItemTemplate>
                                </asp:TemplateField>


                                 <asp:TemplateField HeaderText="Yojna/Samanya">
                                     <ItemTemplate>
                                        <asp:DropDownList ID="ddlYojna" runat="server" CssClass="txtbox reqirerd">
                                            <asp:ListItem Text="Yojna" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Samanya" Value="1"></asp:ListItem>
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
                    <td>
                        <asp:Button runat="server" ID="btnSave" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;/Save "
                            OnClick="btnSave_Click" Visible="false" />
                    </td>

                </tr>
            </table>


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

