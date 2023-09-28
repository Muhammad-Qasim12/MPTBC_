<%@ Page Title="प्रिंटर की क्षमता वित्तीय सत्र के अनुसार" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrinterCapacityFinYearWise.aspx.cs" Inherits="Printing_PrinterCapacityFinYearWise" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
                <h2>प्रिंटर की क्षमता वित्तीय सत्र के अनुसार</h2>
            </div>
        <div class="card-body">
            
            <div class="row g-3">
                <div class="col-md-12">
                    <asp:Panel ID="messDiv" runat="server" Style="display:none;">
                        <asp:Label runat="server" ID="lblMess" class="alert alert-success" ></asp:Label>
                    </asp:Panel>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList runat="server" ID="ddlACYear_I" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlACYear_I_SelectedIndexChanged">
                        </asp:DropDownList>
                        <label>शैक्षणिक सत्र</label>
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:GridView runat="server" ID="grdPrinterCapacity" AutoGenerateColumns="false" CssClass="table table-bordered table-hover">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <tr>
                                        <th rowspan="2">क्र. </th>
                                        <th rowspan="2">प्रिंटर का नाम / Printer Name</th>
                                        <th rowspan="2">मशीन का प्रकार / Machine Type </th>
                                        <th colspan="3">मशीन की क्षमता (टन में ) / Machine Capacity (in Ton)</th>
                                        <th colspan="3">मशीन की अनुमानित  क्षमता (टन में ) / Machine Tentative Capacity (in Ton)</th>
                                    </tr>
                                    <tr>
                                        <th>एक रंगीय / One Color</th>
                                        <th>दो रंगीय / Two Color </th>
                                        <th>चार रंगीय / Four Color</th>
                                        <th>एक रंगीय / One Color </th>
                                        <th>दो रंगीय / Two Color </th>
                                        <th>चार रंगीय / Four Color </th>
                                    </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%# Container.DataItemIndex+1 %>
                                            <asp:HiddenField runat="server" ID="HDNPrinter_RedID_I" Value='<%# Eval("Printer_RedID_I")%>' />
                                            <asp:HiddenField runat="server" ID="HDNMachineID_I" Value='<%# Eval("MachineID_I")%>' />
                                            <asp:HiddenField runat="server" ID="HDNMachineCapID_I" Value='<%# Eval("MachineCapID_I")%>' />
                                        </td>
                                        <td><%# Eval("NameofPress_V")%></td>
                                        <td><%# Eval("MachineType_V")%></td>
                                        <td><%# Eval("OneColor")%></td>
                                        <td><%# Eval("TwoColor")%></td>
                                        <td><%# Eval("fourColor")%></td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtOneColor" Text='<%# Eval("MCOneColor_N") %>' Width="80px" onkeypress="tbx_fnAlphaNumericOnly(event, this);" MaxLength="8"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtTwoColor" Text='<%# Eval("MCTwoColor_N") %>' Width="80px" onkeypress="tbx_fnAlphaNumericOnly(event, this);" MaxLength="8"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtFourColor" Text='<%# Eval("MCFourColor_N") %>' Width="80px" onkeypress="tbx_fnAlphaNumericOnly(event, this);" MaxLength="8"></asp:TextBox></td>

                                    </tr>


                                </ItemTemplate>

                            </asp:TemplateField>

                        </Columns>
                        <PagerStyle CssClass="Gvpaging" />
                        <EmptyDataRowStyle CssClass="GvEmptyText" />

                    </asp:GridView>
                </div>
                <div class="col-md-12">
                    <asp:Button runat="server" ID="BtnSave" Text="सुरक्षित करे" OnClick="BtnSave_Click" CssClass="btn btn-submit" />
                        <asp:Button runat="server" ID="btnBack" Text="वापस जाये" OnClick="btnBack_Click" CssClass="btn btn-default" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

