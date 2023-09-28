<%@ Page Title="Binding Details" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BindingDetails.aspx.cs" Inherits="Printing_BindingDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
            <h2>बाइंडिंग की जानकारी</h2>
        </div>
        <div class="card-body">

            <div class="row g-3">
                <div class="col-md-12">
                    <asp:HiddenField runat="server" ID="hdnPriBindID_I" Value="0" />
                </div>
                <div class="col-md-12">
                    <strong>Details Binding</strong>
                </div>
                <div class="col-md-12">
                    <table class="table table-bordered table-hover">
                        <tr>
                            <th>Machinery installation
                            </th>
                            <th>Make
                            </th>
                            <th>Size
                            </th>
                            <th>Nos
                            </th>
                            <th>Owned
                            </th>
                        </tr>
                        <tr>
                            <td>1. Folding m/cs 16pp/32 *</td>
                            <td>
                                <asp:TextBox ID="txtMac_FoldingMake_V" MaxLength="80" runat="server" Width="150px" CssClass="txtbox reqirerd" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMac_FoldingSize_V" MaxLength="15" runat="server" Width="150px" CssClass="txtbox reqirerd" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMac_FoldingNos_I" MaxLength="4" runat="server" Width="80px" CssClass="txtbox reqirerd" onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMac_FoldingOwned_V" MaxLength="4" runat="server" Width="80px" CssClass="txtbox reqirerd" onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>2. Stitching m/cs( Power operated) *</td>
                            <td>
                                <asp:TextBox ID="txtMac_StichgMake_V" MaxLength="80" runat="server" Width="150px" CssClass="txtbox reqirerd" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMac_StichgSize_V" MaxLength="15" runat="server" Width="150px" CssClass="txtbox reqirerd" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMac_StichgNos_I" MaxLength="4" runat="server" Width="80px" CssClass="txtbox reqirerd" onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMac_StichgOwned_V" MaxLength="4" runat="server" Width="80px" CssClass="txtbox reqirerd" onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>3. cutting m/cs( Hand clamp/ Self clamp/ automatic)*
                            </td>
                            <td>
                                <asp:TextBox ID="txtMac_CutMake_V" MaxLength="80" runat="server" Width="150px" CssClass="txtbox reqirerd" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMac_CutSize_V" MaxLength="15" runat="server" Width="150px" CssClass="txtbox reqirerd" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMac_CutNos_I" MaxLength="4" runat="server" Width="80px" CssClass="txtbox reqirerd" onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMac_CutOwned_V" MaxLength="4" runat="server" Width="80px" CssClass="txtbox reqirerd" onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>4. Other
                            </td>
                            <td>
                                <asp:TextBox ID="txtMac_othMake_V" MaxLength="80" runat="server" Width="150px" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMac_othSize_V" MaxLength="15" runat="server" Width="150px" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMac_othNos_I" MaxLength="4" runat="server" Width="80px" onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtMac_othOwned_V" MaxLength="4" runat="server" Width="80px" onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="col-md-12">
                    <strong>State binding capacity(s) upto ?</strong>
                </div>
                <div class="col-md-12">
                    <table class="table table-bordered table-hover">
                        <tr>
                            <th colspan="3">Nos of Books per day in terms of Books</th>
                        </tr>
                        <tr>
                            <th width="5%"></th>
                            <th width="20%">Description</th>
                            <th width="75%">No.</th>
                        </tr>
                        <tr>
                            <td>(a) *</td>
                            <td>
                                <asp:TextBox ID="txtBookname_V" MaxLength="50" runat="server" CssClass="txtbox reqirerd" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBookBindCapNo_I" MaxLength="6" runat="server" CssClass="txtbox reqirerd" onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>(b)
                            </td>
                            <td>
                                <asp:TextBox ID="txtBookname1_V" MaxLength="50" runat="server" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBook1BindCapNo_I" MaxLength="6" runat="server" onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>(c)
                            </td>
                            <td>
                                <asp:TextBox ID="txtBookname2_V" MaxLength="50" runat="server" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBook2BindCapNo_I" MaxLength="6" runat="server" onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="col-md-12">
                    <strong>Particulars of offset</strong>
                </div>
                <div class="col-md-12">
                    <table class="table table-bordered table-hover">
                        <tr>
                            <th>Processing equipment
                            </th>
                            <th>Size
                            </th>
                            <th>Make
                            </th>
                        </tr>
                        <tr>
                            <td>a. Camera
                            </td>
                            <td>
                                <asp:TextBox ID="txtOffsetCameraSize_V" MaxLength="40" runat="server" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtOffsetCameraMake_V" MaxLength="80" runat="server" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>b. Whiralar
                            </td>
                            <td>
                                <asp:TextBox ID="txtOffsetWhirlarSize_V" MaxLength="40" runat="server" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtOffsetWhirlarMake_V" MaxLength="80" runat="server" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>c. any other equipment
                            </td>
                            <td>
                                <asp:TextBox ID="txtOffsetOthSize_V" MaxLength="40" runat="server" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtOffsetOthMake_V" MaxLength="80" runat="server" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                            </td>
                        </tr>



                        <tr>
                            <td>d. Contact Cabinet
                            </td>
                            <td>
                                <asp:TextBox ID="txtOffsetConCabSize_V" MaxLength="40" runat="server" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtOffsetConCabMake_V" MaxLength="80" runat="server" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                            </td>
                        </tr>


                        <tr>
                            <td>e. Contact Cabinet 1
                            </td>
                            <td>
                                <asp:TextBox ID="txtOffsetConCabSize_V1" MaxLength="40" runat="server" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtOffsetConCabMake_V1" MaxLength="80" runat="server" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="col-md-12">
                    <asp:Button ID="BtnBindingSave" runat="server" Text="सुरक्षित करे" CssClass="btn btn-submit" OnClick="BtnBindingSave_Click" OnClientClick="return ValidateAllTextForm();" />
                    <asp:Button ID="BtnBack" runat="server" Text="वापस जाये" CssClass="btn btn-default" OnClick="BtnBack_Click" />
                </div>
            </div>
        </div>
    </div>
    <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
    </div>
    <div id="SuccessDiv" class="popupnew" style="display: none">
        <div align="right">
            <table>
                <tr>
                    <td><a href="#" onclick="document.getElementById('fadeDiv').style.display='none'; document.getElementById('SuccessDiv').style.display='none';">Closessfully. </b></td>


                    <td>
                        <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" /></td>
                    <td>
                        <asp:Button ID="btnView" runat="server" Text="Go to View form" OnClick="btnView_Click" /></td>
                </tr>


            </table>



        </div>
    </div>
</asp:Content>

