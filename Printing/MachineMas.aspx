<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MachineMas.aspx.cs" Inherits="Printing_MachineMas" Title="Machine Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .ui-widget-content .ui-icon {
            background-image: url(../images/ui-icons_469bdd_256x240.png);
        }

        .ui-widget-content .ui-icon {
            background-image: url(../images/ui-icons_469bdd_256x240.png);
        }

        .ui-icon {
            width: 16px;
            height: 16px;
            background-image: url(../images/icons-lgray.png);
        }

        .ui-icon {
            width: 16px;
            height: 16px;
            background-image: url(../images/icons-lgray.png);
        }

        .ui-icon-check {
            background-position: -64px -144px;
        }

        .ui-helper-clearfix:after {
            content: ".";
            display: block;
            height: 0;
            clear: both;
            visibility: hidden;
        }
    </style>
    <div class="card">
        <div class="card-header">
                <h2>Machine Master </h2>
            </div>
        <div class="card-body">            
            <div class="row g-3">
                <div class="col-md-12">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    <asp:HiddenField ID="HdnMachineMasterID" runat="server" Value="0"></asp:HiddenField>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlMachineType_V" runat="server" CssClass="form-select reqirerd">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                            <asp:ListItem Text="Sheet Fed" Value="Sheet Fed"></asp:ListItem>
                            <asp:ListItem Text="Web offset" Value="Web offset"> </asp:ListItem>
                        </asp:DropDownList>
                        <label>Machine Type</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox runat="server" ID="txtVal1" Style="width: 40%; display: inline;" CssClass="form-control reqirerd" MaxLength="4"></asp:TextBox>
                        <asp:TextBox runat="server" ID="txtVal2" Style="width: 40%; display: inline;" CssClass="form-control reqirerd" MaxLength="4" onblur="Concate();"></asp:TextBox>
                        <br />
                        <b>
                            <asp:HiddenField runat="server" ID="HdnMachineSize_V" />
                            <asp:Label runat="server" ID="txtMachineSize_V" Style="font-size: 14px;"></asp:Label></b>
                        <label>Machine Size</label>

                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlMachineCat_V" runat="server" CssClass="form-select reqirerd">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                            <asp:ListItem Text="Single Unit" Value="Single Unit"></asp:ListItem>
                            <asp:ListItem Text="Two Unit" Value="Two Unit"> </asp:ListItem>
                            <asp:ListItem Text="Four Unit" Value="Four Unit"></asp:ListItem>
                        </asp:DropDownList>
                        <label>Machine Category</label>
                    </div>
                </div>
                <div class="col-md-12">
                    <strong>Printing Capacity of Printing Paper in Tons</strong>
                </div>
                <div class="col-md-2">
                    <div class="form-floating">
                        <asp:TextBox runat="server" ID="txtMacPrintCapOneColor_V" placeholder="एक रंगीय" CssClass="form-control reqirerd" onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox>
                         <label>Single Color</label>
                    </div>
                </div>
                 <div class="col-md-2">
                    <div class="form-floating">
                    <asp:TextBox runat="server" ID="txtMacPrintCapTwoColor_V" placeholder="दो रंगीय" CssClass="form-control reqirerd" onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox>
                        <label>Double Color </label>
                    </div>   
                </div>
                 <div class="col-md-2">
                    <div class="form-floating">
                        <asp:TextBox runat="server" ID="txtMacPrintCapFourColor_V" placeholder="चार रंगीय" CssClass="form-control reqirerd" onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox>
                        <label>Four Color</label>
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-submit" OnClick="btnSave_Click" OnClientClick="return validateform();" />
                    <asp:Button ID="btnClear" runat="server" Text="Cancel" CssClass="btn btn-default" OnClick="btnClear_Click" />
                </div>
                <div class="col-md-12">
                    <div class="table-responsive">
                        <asp:GridView runat="server" ID="grdMachineMaster" AutoGenerateColumns="false"
                            CssClass="table table-bordered hastable" OnRowUpdating="grdMachineMaster_RowUpdating"
                            AllowPaging="True" OnPageIndexChanging="grdMachineMaster_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                                        <asp:HiddenField ID="HdnMachineMasterGrdID" runat="server" Value='<%# Eval("MachineID_I")%>'></asp:HiddenField>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Machine Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMachineType" runat="server" Text='<%# Eval("MachineType_V")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Machine Size">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMachineSize" runat="server" Text='<%# Eval("MachineSize_V")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Machine Categry">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMachineCat" runat="server" Text='<%# Eval("MachineCat_V")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Single Color">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMacPrintCapOne" runat="server" Text='<%# Eval("MacPrintCapOneColor_V")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Double Color">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMacPrintCapTwo" runat="server" Text='<%# Eval("MacPrintCapTwoColor_V")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Four Color">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMacPrintCapFour" runat="server" Text='<%# Eval("MacPrintCapFourColor_V")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit/Update">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Button1" runat="server" CausesValidation="False" CommandName="Update" class="btn btn-sm btn-primary" Text='<i class="bi bi-pencil-square"></i>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function validateform() {
            var msg = "";
            if (document.getElementById('<%=ddlMachineType_V.ClientID%>').selectedIndex == 0) {
                msg = msg + "मशीन का प्रकार चुनें  \n";
            }
            if (document.getElementById('<%=txtVal1.ClientID%>').value.trim() == "" && document.getElementById('<%=txtVal2.ClientID%>').value.trim() == "") {
                msg += "मशीन का आकार भरें \n";
            }
            if (document.getElementById('<%=ddlMachineCat_V.ClientID%>').selectedIndex == 0) {
                msg = msg + "मशीन केटेगरी चुनें\n";
            }
            if (document.getElementById('<%=txtMacPrintCapOneColor_V.ClientID%>').value.trim() == "" && document.getElementById('<%=txtMacPrintCapTwoColor_V.ClientID%>').value.trim() == "" && document.getElementById('<%=txtMacPrintCapFourColor_V.ClientID%>').value.trim() == "") {
                msg += "प्रिंटर की क्षमता भरें \n";
            }
            if (msg != "") {
                alert(msg);
                return false;
            }
            else {

                if (confirm("Do you want to Save Details ?")) {
                    return true;
                }
                else {
                    return false;
                }
            }

        }
        function Concate() {

            var val1 = document.getElementById("<%= txtVal1.ClientID  %>").value;
            var val2 = document.getElementById("<%= txtVal2.ClientID  %>").value;

            var ddl = document.getElementById("<%= ddlMachineType_V.ClientID  %>");

            if (ddl.options[ddl.selectedIndex].value == 'Sheet Fed') {

                document.getElementById("<%= txtMachineSize_V.ClientID  %>").innerHTML = val1 + 'X' + val2 + 'CM';
                document.getElementById("<%= HdnMachineSize_V.ClientID  %>").value = val1 + 'X' + val2 + 'CM';
            }
            else
                if (ddl.options[ddl.selectedIndex].value == 'Web offset') {

                    document.getElementById("<%= txtMachineSize_V.ClientID  %>").innerHTML = val1 + val2;
                    document.getElementById("<%= HdnMachineSize_V.ClientID  %>").value = val1 + val2;
                }
                else {

                    alert('Slect Machine Type.');
                }
        }

    </script>

</asp:Content>



