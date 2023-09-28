<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="DepartmentMaster.aspx.cs" Inherits="DistributionB_DepartmentMaster" Title="माँड्यूल मास्टर" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>मांगकर्ता विभाग का विवरण /Demand Receive from Department Information </span></h2>
        </div>
        <div style="padding: 0 10px 15px;">
            <asp:Panel class="form-message error" runat="server" ID="mainDiv" Style="display: none;
                padding-top: 10px; padding-bottom: 10px;">
                <asp:Label ID="lblmsg" class="notification" runat="server">
                
                </asp:Label>
            </asp:Panel>
            <asp:Panel ID="pnlDepartmentMaster" runat="server">
                <asp:Button ID="btnNewModule" OnClick="btnNewDepartment_Click" runat="server" Text="नया विभाग जोड़ें/ Add New Department"
                    CssClass="btn"></asp:Button>
                <asp:GridView ID="gvDepartmentMaster" CssClass="tab" AutoGenerateColumns="false"  PageSize= "20" 
                    AllowPaging="true"  OnPageIndexChanging="gvDepartmentMaster_PageIndexChanging" 
                    DataKeyNames="DepartmentID_I" OnRowEditing="gvDepartmentMaster_RowEditing" OnRowDeleting="gvDepartmentMaster_RowDeleting" 
                    runat="server">
                    <Columns>
                        <asp:TemplateField HeaderText="क्रमांक / S.No.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                      <%--  <asp:BoundField DataField="DepTrno_I" ReadOnly="true" HeaderText="विभाग आई. डी. " />--%>
                        <asp:BoundField DataField="DepartmentName_V" ReadOnly="true" HeaderText="मांगकर्ता विभाग का नाम / Demand Receive from Department " />                      
                        <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn" HeaderText="सुधार करें / Edit" CommandName="Edit" Text="सुधार करें"  />
                        <asp:TemplateField HeaderText="हटाएँ / Delete">
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" CssClass="btn" runat="server" CommandName="Delete" Text="हटाएं" 
                                OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" />   
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>  <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                </asp:GridView>
                <asp:HiddenField ID="hdnDepTrno" runat="server" />
            </asp:Panel>
            <asp:Panel ID="pnlNewDepartment" Visible="false" runat="server">
                <table>
                    <tr>
                        <td width="15%">
                          मांगकर्ता विभाग का नाम /Demand Receive from Department
                        </td>
                        <td width="85%">
                            <asp:TextBox ID="txtDepartment" MaxLength="50" runat="server" onkeypress='javascript:tbx_fnAlphaNumeric(event, this);' CssClass="txtbox reqirerd" >
                            </asp:TextBox>
                           
                        </td>
                    </tr>                   
                    <tr>
                        <td style="text-align: center" colspan="2">
                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Text="सुरक्षित करें /Save"
                              OnClientClick="return ValidateAllTextForm();"  CssClass="btn"></asp:Button>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
