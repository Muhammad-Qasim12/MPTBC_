<%@ Page Title="Printer Related Details" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrinterRegDetails.aspx.cs" Inherits="Printing_PrinterRegDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
         <div class="card-header">
                <div class="row">
                    <div class="col-md-6">
                        <h2>List of Registered Printer </h2>
                    </div>
                    <div class="col-md-6 text-right">
                        <asp:Button runat="server" ID="btnAdd" CssClass="btn-add" OnClick="btnAdd_Click" Text="Add New Data" />
                    </div>
                </div>
            </div>
        <div class="card-body">           
            <div class="row g-3">
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtSearch" CssClass="form-control" placeholder="Search" runat="server"></asp:TextBox>
                        <label>Search</label>
                    </div>
                    
                </div>
                <div class="col-md-4">
                    <asp:Button runat="server" ID="Button2" CssClass="btn btn-submit" OnClick="Button2_Click" Text="Search" />
                </div>
                <div class="col-md-12">
                    <div class="table-responsive">
                        <asp:Panel runat="server" ID="PnlPrinterRegistration" GroupingText="Registered Printer" ScrollBars="Auto">
                            <asp:GridView runat="server" ID="grdPrinterRegistration" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" AllowPaging="True" OnPageIndexChanging="grdPrinterRegistration_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No">
                                        <ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Name of printer/press">
                                        <ItemTemplate>
                                            <%# Eval("NameofPress_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Registration of printer/press">
                                        <ItemTemplate>
                                            <a href="Printer_Registration.aspx?Cid=<%#new APIProcedure().Encrypt(Eval("Printer_RedID_I").ToString())%> " class="btn btn-primary">
                                                <i class="bi bi-printer-fill"></i>
                                                <%--<img src="../images/Printer registration.png" alt="Printer Registration" style="height: 30px; width: 30px;" title="<%# Eval("NameofPress_V")%> &#2325;&#2368; &#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2381;&#2352;&#2375;&#2358;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; " />--%>
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Machine Details">
                                        <ItemTemplate>
                                            <a  class="btn btn-secondary" href="PRI001_MachineDetails.aspx?PriId=<%#new APIProcedure().Encrypt(Eval("Printer_RedID_I").ToString()) %>&MachineId=<%#new APIProcedure().Encrypt(Eval("PriMacID_I").ToString()) %>">
                                                <i class="bi bi-ubuntu"></i>
                                                <%--<img src="../images/MachinesBinding.png" alt="Machines Details" style="height: 30px; width: 30px;" title="<%# Eval("NameofPress_V")%> &#2325;&#2368; &#2350;&#2358;&#2368;&#2344;&#2379;  &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;" />--%>
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Binding Details">
                                        <ItemTemplate>
                                            <a class="btn btn-danger" href="BindingDetails.aspx?PriId=<%#new APIProcedure().Encrypt(Eval("Printer_RedID_I").ToString()) %>&BindId=<%#new APIProcedure().Encrypt(Eval("PriBindID_I").ToString()) %>">
                                                <i class="bi bi-journal-text"></i>
                                                <%--<img src="../images/Binding.png" alt="Binding Details" style="height: 30px; width: 30px;" title="<%# Eval("NameofPress_V")%> &#2325;&#2368; &#2348;&#2366;&#2311;&#2306;&#2337;&#2367;&#2306;&#2327; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;" />--%>
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Other Details">
                                        <ItemTemplate>
                                            <a class="btn btn-success" href="OtherDetails.aspx?PriId=<%#new APIProcedure().Encrypt( Eval("Printer_RedID_I").ToString()) %>&OthId=<%#new APIProcedure().Encrypt( Eval("RegOthID").ToString()) %>">
                                                <i class="bi bi-list-check"></i>
                                                <%--<img src="../images/Other.png" alt="Binding Details" style="height: 30px; width: 30px;" title="<%# Eval("NameofPress_V")%>   &#2325;&#2368; &#2309;&#2344;&#2381;&#2351; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;" />--%>
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Checklist Details">
                                        <ItemTemplate>
                                            <a class="btn btn-warning" href="CheckboxDetails.aspx?PriId=<%#new APIProcedure().Encrypt(Eval("Printer_RedID_I").ToString())%>&ChkId=<%#new APIProcedure().Encrypt( Eval("RegChkLSTID_I").ToString()) %>">
                                                <i class="bi bi-card-checklist"></i>
                                                <%--<img src="../images/Clipboard_3.png" alt="Binding Details" style="height: 30px; width: 30px;" title="<%# Eval("NameofPress_V")%>  &#2325;&#2375; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2330;&#2351;&#2344; &#2325;&#2367;&#2351;&#2375; &#2327;&#2319; &#2344;&#2367;&#2351;&#2350;&#2379; &#2325;&#2375; &#2346;&#2366;&#2354;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; " />--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="User login and password Details">
                                        <ItemTemplate>

                                            <a class="btn btn-info" href="UserIdAndPassword.aspx?PriId=<%#new APIProcedure().Encrypt(Eval("Printer_RedID_I").ToString())%>">
                                                <i class="bi bi-person-lines-fill"></i>
                                                <%--<img src="../images/UserLogin.png" alt="Binding Details" style="height: 30px; width: 30px;" title="<%# Eval("NameofPress_V")%>  &#2325;&#2375; &#2351;&#2370;&#2332;&#2352; &#2354;&#2377;&#2327;&#2311;&#2344; &#2319;&#2357;&#2306; &#2351;&#2370;&#2332;&#2352; &#2346;&#2366;&#2360;&#2357;&#2352;&#2381;&#2337; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; " />--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" />
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

