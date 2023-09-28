<%@ Page Title="मुद्रणालय स्तर पर निरिक्षण की जानकारी / Inspection of Printing" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InspectionDetails.aspx.cs" Inherits="Printing_InspectionDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:UpdatePanel runat="server" ID="UpdatePnl">
        <ContentTemplate>
            <div class="card">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePnl">
                    <ProgressTemplate>
                        <div class="fade">
                        </div>
                        <div class="progress">
                            <img src="../images/loading.gif" alt="Loading..." width="110" height="110" />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <div class="card-header">
                    <div class="row">
                        <div class="col-md-6">
                            <h2>मुद्रणालय स्तर पर निरिक्षण की जानकारी</h2>
                        </div>
                        <div class="col-md-6 text-right">
                            <asp:Button runat="server" ID="btnAdd" Text="नई जानकारी जोड़े" CssClass="btn-add" OnClick="btnAdd_Click" />
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <div class="row g-3">
                        <div class="col-md-12">
                            <asp:GridView runat="server" ID="grdAvas" AutoGenerateColumns="false" CssClass="table table-bordered table-hover">
                                <Columns>
                                    <asp:TemplateField HeaderText="क्रमांक ">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>

                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="मुद्रणालय का नाम / Printer Name">
                                        <ItemTemplate>
                                            <%# Eval("NameofPress_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="निरिक्षण दिनांक / Inspection Date">
                                        <ItemTemplate>
                                            <%# Eval("Inspectiondate_D")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="अधिकारी का नाम / Officer Name">
                                        <ItemTemplate>
                                            <%# Eval("OfficerName_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="पद / Designation">
                                        <ItemTemplate>
                                            <%# Eval("OfficerDesignation_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="निरिक्षण रिपोर्ट / Inspection Report">
                                        <ItemTemplate>
                                            <%# Eval("InspectionReport_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="प्रपत्र / Document">
                                        <ItemTemplate>
                                            <a href='<%# Eval("InspectionReportFile_V")%>'>प्रपत्र देखे </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <a href="PRI007_Inspection.aspx?Cid=<%#new APIProcedure().Encrypt( Eval("InspectionTrno_I").ToString()) %>">सुधार करे </a>

                                        </ItemTemplate>
                                    </asp:TemplateField>


                                </Columns>
                                <PagerStyle CssClass="Gvpaging" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

