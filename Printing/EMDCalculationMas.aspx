<%@ Page Title="EMD Calculation Master" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EMDCalculationMas.aspx.cs" Inherits="Printing_EMDCalculationMas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
            <h2>EMD Calculation Master</h2>
        </div>
        <div class="card-body">

            <div class="row g-3">
                <div class="col-md-12">
                    <div id="messageDiv" runat="server" class="alert alert-danger" style="display: none;">
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlACYear_I" runat="server" CssClass="form-select">
                        </asp:DropDownList>
                        <label>Academic Year</label>
                    </div>
                </div>
                <div class="col-md-2">
                    <div class="form-floating">
                        <asp:TextBox ID="txtfrom" runat="server" CssClass="form-control reqirerd" MaxLength="9" onkeypress="return validateNum(event)"></asp:TextBox>
                        <label>Capacity in Tons From</label>
                    </div>
                </div>
                <div class="col-md-2">
                    <div class="form-floating">
                        <asp:TextBox ID="txtto" runat="server" CssClass="form-control reqirerd" MaxLength="9" onkeypress="return validateNum(event)"></asp:TextBox>
                        <label>Capacity in Tons To</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control reqirerd" MaxLength="9" onkeypress="return validateDec(this,event)"></asp:TextBox>
                        <label>EMD Amount</label>
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-submit" OnClick="Button1_Click" Text="Save" OnClientClick="return validateform();" />
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                </div>
                <div class="col-md-12">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" DataKeyNames="ID" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="fy" HeaderText="Academic Year" />
                            <asp:BoundField DataField="FromTan" HeaderText="Capacity in Tons From" />
                            <asp:BoundField DataField="ToTan" HeaderText="Capacity in Tons To" />
                            <asp:BoundField DataField="totalAmount" HeaderText="EMD Amount" />
                            <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-sm btn-primary" HeaderText="Edit/Update" SelectText='<i class="bi bi-pencil-square"></i>' />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function validateform() {
            var msg = "";
            if (document.getElementById('<%=ddlACYear_I.ClientID%>').selectedIndex == 0) {
                msg = msg + "शिक्षा सत्र चुनें  \n";
            }
            if (document.getElementById('<%=txtfrom.ClientID%>').value.trim() == "") {
                msg += "क्षमता (टन में ) से भरें \n";
            }
            if (document.getElementById('<%=txtAmount.ClientID%>').value.trim() == "") {
                msg += "क्षमता (टन में ) तक भरें \n";
            }
            if (document.getElementById('<%=txtto.ClientID%>').value.trim() == "") {
                msg += "ई.एम. डी की राशि भरें \n";
            }
            <%--if (document.getElementById('<%=chkDepots.ClientID%>').length > 0 ) {
                msg = msg + "डिपो का नाम चुनें\n";
            }--%>
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
</asp:Content>

