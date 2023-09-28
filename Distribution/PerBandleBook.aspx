<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PerBandleBook.aspx.cs" Inherits="Distribution_PerBandleBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
            <h2>प्रति बंडल पुस्तक संख्या</h2>
        </div>
        <div class="card-body">
            <div class="row g-3">
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DdlACYear" runat="server" AutoPostBack="True"
                            CssClass="form-select" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged">
                            <asp:ListItem>..Select..</asp:ListItem>
                            <asp:ListItem>2012-13</asp:ListItem>
                            <asp:ListItem>2013-14</asp:ListItem>
                            <asp:ListItem>2014-15</asp:ListItem>
                        </asp:DropDownList>
                        <label>शिक्षा सत्र</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlMedium" runat="server" CssClass="form-select reqirerd" OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                        <label>माध्यम</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="form-select" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                            <asp:ListItem Value="0">Select...</asp:ListItem>
                            <asp:ListItem Value="1,2,3,4,5,6,7,8">1-8</asp:ListItem>
                            <asp:ListItem Value="9,10,11,12">9-12</asp:ListItem>
                        </asp:DropDownList>
                        <label>कक्षा</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlTital" runat="server" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="ddlTital_SelectedIndexChanged">
                        </asp:DropDownList>
                        <label>शीर्षक का नाम चुने</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtHeadname" runat="server" CssClass="form-control reqirerd" MaxLength="3" onkeypress="javascript:tbx_fnSignedNumericCheck(event, this)"></asp:TextBox>
                        <label>प्रति बंडल संख्या</label>
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-submit" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; " OnClientClick="return ValidateAllTextForm();"
                        OnClick="btnSave_Click" />
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                </div>
                <div class="col-md-12">                     
                    <div id="ExportDiv" runat="server">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                    <asp:BoundField DataField="BookNumber" HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2306;&#2337;&#2354; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " />
                                </Columns>
                            </asp:GridView>
                        </div>
                    <asp:Button ID="btnExport" runat="server" CssClass="btn btn-defaul" OnClick="btnExport_Click" Text="Export to Excel" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

