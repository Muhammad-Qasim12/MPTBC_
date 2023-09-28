<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookSellerAccountMaster.aspx.cs" Inherits="Depo_BookSellerAccountMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>Bank Account Master </span>
            </h2>
        </div>
        <div style="padding: 0 10px;">
             <asp:Panel ID="mainDiv" runat="server" class="form-message success" Style="display: none; padding-top: 10px; padding-bottom: 10px;">
                <asp:Label ID="lblmsg" runat="server" class="notification">
                
                </asp:Label></asp:Panel> 
            <table width="100%">
                <tr>
                    <td >&#2348;&#2376;&#2306;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; /Bank Name</td>
                    <td >
                                                                                <asp:DropDownList ID="DDLBank" runat="server" Width="187px" Height="27px" CssClass="ddl" >
                                                                                </asp:DropDownList>
                    </td>
                    <td >&#2358;&#2366;&#2326;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350;&nbsp; /Branch Name</td>
                    <td >
                                                                                <asp:TextBox ID="txtBranch" runat="server" CssClass="txtbox reqirerd" MaxLength="20"></asp:TextBox>
                                                                               
                    </td>
                </tr>
                <tr>
                    <td>&#2319;&#2325;&#2366;&#2313;&#2306;&#2335; &#2344;&#2306;&#2348;&#2352; /A/C No.</td>
                    <td>
                                                                                <asp:TextBox ID="txtAcNo" runat="server" CssClass="txtbox reqirerd" MaxLength="20"></asp:TextBox>
                                                                               
                    </td>
                    
                    <td>&nbsp;</td>
                    <td>
                                                                                &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Save" OnClientClick="return ValidateAllTextForm();" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="ID" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                            <Columns>
                                  <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                <asp:BoundField DataField="BankName" HeaderText="&#2348;&#2376;&#2306;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; /Bank Name" />
                                <asp:BoundField DataField="BranchAddress" HeaderText="&#2358;&#2366;&#2326;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350;&nbsp; /Branch Name" />
                                <asp:BoundField DataField="AccountNo" HeaderText="&#2319;&#2325;&#2366;&#2313;&#2306;&#2335; &#2344;&#2306;&#2348;&#2352; /A/C No." />
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr></table> 

        </div> </div> 
</asp:Content>

