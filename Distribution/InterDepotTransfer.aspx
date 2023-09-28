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
    <div class="card">
        <div class="card-body">
            <div class="card-header">
                <h2>अंतर डिपो ट्रान्सफर</h2>
            </div>
            <div class="row g-3">
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">मध्यवर्ती मांग</asp:ListItem>
                            <asp:ListItem Value="2">यू एंड ई ग्रुप</asp:ListItem>
                            <asp:ListItem Value="3">आंकलित डिमांड</asp:ListItem>
                            <asp:ListItem Value="4">खुले बाजार की मांग</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DdlACYear" runat="server" CssClass="form-select" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged">
                        </asp:DropDownList>
                        <label id="Label7" runat="server">शिक्षा सत्र </label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DdlScheme" runat="server" CssClass="form-select">
                        </asp:DropDownList>
                        <label id="Label1" runat="server">माध्यम</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlReqDepo" runat="server" CssClass="form-select" AutoPostBack="True"
                            OnInit="ddlReqDepo_Init"
                            OnSelectedIndexChanged="ddlReqDepo_SelectedIndexChanged">
                        </asp:DropDownList>
                        <label id="Label2" runat="server">डिपो चुने</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlOrderNo" CssClass="form-select" runat="server"
                            OnInit="ddlOrderNo_Init"
                            OnSelectedIndexChanged="ddlOrderNo_SelectedIndexChanged">
                        </asp:DropDownList>
                        <label id="Label3" runat="server">आर्डर नं.</label>
                    </div>
                </div>
                <div id="tr1" runat="server" visible="false">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:TextBox runat="server" ID="txtChallanDate" CssClass="form-control reqirerd" MaxLength="10"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtRecivedDate_CalendarExtender" runat="server" TargetControlID="txtChallanDate"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                                <label id="Label4" runat="server">आर्डर दिनांक</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:TextBox runat="server" ID="txtOrderNo" CssClass="form-control reqirerd" ReadOnly="true"></asp:TextBox>
                                <label id="Label5" runat="server">आर्डर नं</label>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="tr2" runat="server">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="">
                                <asp:TextBox ID="TextBox1" runat="server" Visible="False" CssClass="form-control" Width="104px" Text="100"></asp:TextBox>
                                <label id="Label6" runat="server">प्रतिशत </label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-12" id="tr4" runat="server">
                    <div class="form-floating">
                        <asp:Button ID="Button3" runat="server" CssClass="btn btn-primary" OnClick="Button3_Click" Text="Show Data" />
                    </div>
                </div>
                <div class="col-md-4" id="tr121" runat="server">
                    <div class="form-floating">
                        <asp:DropDownList ID="DropDownList1" CssClass="form-select" runat="server">
                        </asp:DropDownList>
                        <asp:Button ID="Button4" runat="server" CssClass="btn btn-defaul" OnClick="Button4_Click" Text="क्लिक करें " />
                        <label id="Label8" runat="server">यदि प्रेषक डिपो सभी एक हो तो इस ड्रापडाउन को सेलेक्ट करें </label>
                    </div>
                </div>
                <div class="table-responsive">
                    <asp:GridView ID="GrdDepoQtyMaster" runat="server" AutoGenerateColumns="false" GridLines="None"
                        CssClass="table table-bordered" Width="100%" EmptyDataText="Record Not Found."
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
                </div>
                <div>
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Visible="false"
                        Text="&#2335;&#2381;&#2352;&#2366;&#2306;&#2360;&#2347;&#2352; &#2325;&#2352;&#2375; / Transfer"
                        OnClick="btnSave_Click" OnClientClick="return ValidateAllTextForm();" />
                </div>
            </div>
        </div>
    </div>

    <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
    </div>
    <!-- Modal -->
    <div class="modal fade" id="Messages" style="display: none; height: 300px; overflow: auto;" runat="server">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <asp:GridView ID="GrdPopUp" runat="server" AutoGenerateColumns="false" GridLines="None"
                        CssClass="table table-bordered" Width="100%" EmptyDataText="Record Not Found.">
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
                </div>
                <div class="modal-footer">
                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-defaul" Text="Close" OnClick="Button2_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
