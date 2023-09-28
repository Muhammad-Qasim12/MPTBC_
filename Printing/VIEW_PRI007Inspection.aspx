<%@ Page Title="मुद्रणालय स्तर पर निरिक्षण की जानकारी / Inspection of Printing" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VIEW_PRI007Inspection.aspx.cs" Inherits="Printing_VIEW_PRI007Inspection" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:UpdatePanel runat="server" ID="UpdatePnl">
        <ContentTemplate>




            <div class="portlet-header ui-widget-header">मुद्रणालय स्तर पर निरिक्षण की जानकारी / Inspection of Printing Press</div>
            <div class="portlet-content">
                <div class="table-responsive ">


                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePnl">
                        <ProgressTemplate>
                            <div class="fade">
                            </div>
                            <div class="progress">
                                <img src="../images/loading.gif" alt="Loading..." width="110" height="110" />
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>

                    <table width="100%">
                        <tr>
                            <td>
                                <asp:Button runat="server" ID="btnAdd" Text="नई जानकारी जोड़े / Add New Record" CssClass="btn" OnClick="btnAdd_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>

                                <asp:GridView runat="server" ID="grdAvas" AutoGenerateColumns="false" CssClass="tab hastable">

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


                            </td>
                        </tr>
                    </table>
                </div>
            </div>


        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

