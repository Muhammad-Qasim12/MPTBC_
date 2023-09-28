<%@ Page Title="Depot Profile" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DepotMaster.aspx.cs" Inherits="Admin_DepotMaster" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
            <h2>Depot Profile</h2>
        </div>
        <div class="card-body">
            <div class="row g-3">
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtDepotName" onkeypress="javascript:tbx_fnAlphaNumeric(event, this);" placeholder="" runat="server" MaxLength="25" CssClass="form-control reqirerd"></asp:TextBox>
                        <label>Depot Name</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtTelephone" runat="server" onkeypress='javascript:fnSetPhoneDigits(event, this);' placeholder="" MaxLength="13" CssClass="form-control reqirerd"></asp:TextBox>
                        <label>Telephone No.</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtMobileNo" runat="server" onblur='javascript:fnIsValidPhoneFormat(this);' placeholder="" onkeypress='javascript:fnSetPhoneDigits(event, this);' MaxLength="10" CssClass="form-control reqirerd"></asp:TextBox>
                        <label>Mobile No.</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtDepotAddress" runat="server" CssClass="form-control reqirerd" placeholder="" TextMode="MultiLine" onkeypress="MaxLengthCount('ContentPlaceHolder1_txtIns_CoverDetail_V',250);"></asp:TextBox>
                        <label>Depot Address</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-select reqirerd">
                            <asp:ListItem>Madhya Pradesh</asp:ListItem>
                        </asp:DropDownList>
                        <label>State</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-select reqirerd">
                        </asp:DropDownList>
                        <label>District</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-select reqirerd">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                            <asp:ListItem Value="1">भोपाल</asp:ListItem>
                            <asp:ListItem Value="2">चम्बल</asp:ListItem>
                            <asp:ListItem Value="3">ग्वालियर</asp:ListItem>
                            <asp:ListItem Value="4">इंदौर</asp:ListItem>
                            <asp:ListItem Value="5">जबलपुर</asp:ListItem>
                            <asp:ListItem Value="6">नर्मदापुरम</asp:ListItem>
                            <asp:ListItem Value="7">रीवा</asp:ListItem>
                            <asp:ListItem Value="8">सागर</asp:ListItem>
                            <asp:ListItem Value="9">शहडोल</asp:ListItem>
                            <asp:ListItem Value="10">उज्जैन</asp:ListItem>
                            <asp:ListItem Value="11">ग्वालियर</asp:ListItem>
                        </asp:DropDownList>
                        <label>City</label>
                    </div>
                </div>
                <%--<div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtFaxNo" runat="server" onkeypress='javascript:fnSetPhoneDigits(event, this);' CssClass="form-control reqirerd" MaxLength="13"></asp:TextBox>
                        <label>फैक्स नंबर</label>
                    </div>
                </div>--%>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtEmailID" runat="server" placeholder="" CssClass="form-control reqirerd"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailID"
                            ErrorMessage="कृपया सही ई-मेल आई.डी. दर्ज करें" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                        </asp:RegularExpressionValidator>
                        <label>Email Id</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtDepoManager" onkeypress="tbx_fnAlphaNumeric(event, this);" placeholder="" CssClass="form-control reqirerd" MaxLength="60" runat="server"></asp:TextBox>
                        <label>Depot Manager Name</label>
                    </div>
                </div>
                <div class="col-md-2">
                    
                        <asp:CheckBox ID="chkIsStatelite" AutoPostBack="true" OnCheckedChanged="chkIsStatelite_OnCheckedChanged" runat="server" Text="Satellite Depot " />
                        
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlMainDepo" CssClass="form-select" Visible="false" runat="server">
                        </asp:DropDownList>
                        <label id="lblDepoTitle" visible="false" runat="server">Main Depot</label>
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-submit" OnClientClick="return validateform();"
                        OnClick="btnSave_Click" />
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function validateform() {
            var msg = "";
            if (document.getElementById('<%=txtDepotName.ClientID%>').value.trim() == "") {
                msg += "डिपो का नाम भरें \n";
            }
            if (document.getElementById('<%=txtMobileNo.ClientID%>').value.trim() == "") {
                msg += "मोबाइल नंबर भरें \n";
            }
            if (document.getElementById('<%=ddlDistrict.ClientID%>').selectedIndex == 0) {
                msg = msg + "जिला चुनें  \n";
            }
            if (document.getElementById('<%=txtDepoManager.ClientID%>').value.trim() == "") {
                msg += "डिपो मैनेजर का नाम भरें \n";
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

    </script>
    <script type="text/javascript">

        function MaxLengthCount(txt, MaxLen) {
            var form-control = document.getElementById(txt);
            var len = MaxLen;


            if (form - control.value.length > len) {

                form - control.value = form - control.value.substring(0, len);
                alert("Character length is Exeed from " + len);
            }
            else { }
        }
    </script>
</asp:Content>

