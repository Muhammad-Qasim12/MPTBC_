<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddPrinterPenalty.aspx.cs" Inherits="Printing_AddPrinterPenalty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
                <h2>प्रिंटर पेनाल्टी</h2>
            </div>
        <div class="card-body">            
            <div class="row g-3">
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlprinterName" runat="server" CssClass="form-select">
                        </asp:DropDownList>
                        <label>प्रिंटर का नाम</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlTital" runat="server" CssClass="form-select">
                        </asp:DropDownList>
                        <label>पुस्तक का नाम</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="TextBox2" onkeypress="tbx_fnSignedNumeric(event, this);"></asp:TextBox>
                        <label>पेनल्टी प्रतिशत</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="remark" TextMode="MultiLine"></asp:TextBox>
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <label>रिमार्क डाले</label>
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-submit" OnClick="Button1_Click" Text="सुरक्षित करें" />
                </div>
                <div class="col-md-12">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" DataKeyNames="ID" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="NameofPress_V" HeaderText="प्रिंटर का नाम" />
                        <asp:BoundField DataField="TitleHindi_V" HeaderText="पुस्तक का नाम" />
                        <asp:BoundField DataField="Percetage" HeaderText="प्रतिशत" />
                        <asp:BoundField DataField="Remark" HeaderText="रिमार्क" />
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

