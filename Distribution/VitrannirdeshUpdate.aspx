<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VitrannirdeshUpdate.aspx.cs" Inherits="Distribution_VitrannirdeshUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-body">
            <div class="card-header">
                <h2>वितरण निर्देश की रिपोर्ट</h2>
            </div>
            <div class="row g-3">
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DdlACYear" AutoPostBack="true" runat="server" CssClass="form-control reqirerd" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged">
                        </asp:DropDownList>
                        <label id="Label2" runat="server">शिक्षा सत्र </label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DDLPrinter" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="DDLPrinter_SelectedIndexChanged">
                        </asp:DropDownList>
                        <label id="Label3" runat="server">मुद्रक </label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlOrderNo" CssClass="form-control" runat="server">
                        </asp:DropDownList>
                        <label id="Label4" runat="server">आर्डर नंबर</label>
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-secondary" OnClick="Button1_Click" Text="रिपोर्ट देखे " />
                </div>
                <div class="col-md-12">
                    <asp:GridView runat="server" ID="GrdVitranNirdesh" CssClass="table table-bordered hastable" RowStyle-CssClass="none" HeaderStyle-CssClass="none" AutoGenerateColumns="False" ShowFooter="True">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>

                                    <tr>
                                        <th rowspan="3" align="center">&#2325;&#2381;&#2352;&#2406;
                                                                                    
                                                                                    
                                                                                    
                                        </th>

                                        <th rowspan="3" align="center">&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350;
                                        </th>

                                        <th rowspan="3" style="width: 80Px;" align="center">&#2337;&#2367;&#2346;&#2379; &#2361;&#2375;&#2340;&#2369; &#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;
                                                                                  
                                                                                  
                                        </th>

                                        <th colspan="2" align="center">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2344;&#2306;&#2348;&#2352;&#2367;&#2306;&#2327; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339;
                                                                                     
                                        </th>
                                        <th colspan="3">&#2337;&#2367;&#2346;&#2379;&#2348;&#2366;&#2352; &#2348;&#2306;&#2337;&#2354;&#2379; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339;
                                                                                   
                                        </th>

                                        <th rowspan="3">&#2325;&#2369;&#2354; &#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;  
                                                                                   
                                                                                    
                                        </th>

                                        <th rowspan="3">&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; 
                                                                                   
                                                                                 
                                        </th>

                                    </tr>
                                    <tr>
                                        <th rowspan="2">&#2325;&#2361;&#2366;&#2305; &#2360;&#2375;
                                                                                   
                                                                                  
                                        </th>

                                        <th rowspan="2">&#2325;&#2361;&#2366;&#2305; &#2340;&#2325;
                                                                                    
                                                                                   
                                        </th>
                                        <th rowspan="2">&#2348;&#2306;&#2337;&#2354;&#2379; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;
                                                                                    
                                                                                  
                                        </th>
                                        <th colspan="2">&#2348;&#2306;&#2337;&#2354; &#2344;&#2350;&#2381;&#2348;&#2352;   
                                        </th>
                                    </tr>
                                    <tr>
                                        <th>&#2325;&#2361;&#2366;&#2305; &#2360;&#2375;
                                                                                  
                                                                                 
                                        </th>
                                        <th></th>
                                    </tr>
                                    <tr>
                                        <th>1</th>
                                        <th>2</th>
                                        <th>3</th>
                                        <th>4</th>
                                        <th>5</th>
                                        <th>6</th>
                                        <th>7</th>
                                        <th>8</th>
                                        <th>9</th>
                                        <th>10</th>
                                    </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td align="center"><%# Container.DataItemIndex+1 %>.
                                                                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("Trno") %>' />

                                        </td>

                                        <td align="center">
                                            <asp:Label ID="lblDepoName_V" runat="server" Text='<%#Eval("DepoName_V")%>'></asp:Label>
                                        </td>


                                        <td align="center">
                                            <asp:TextBox ID="lblNoOfBooks" runat="server" Text='<%#Eval("NoOfBooks")%>' OnTextChanged="txtChange" AutoPostBack="true"></asp:TextBox>
                                        </td>


                                        <td align="center">
                                            <asp:Label ID="LblBookNoFrom" runat="server" Text='<%#Eval("BookNumberFrom")%>'></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="LblBookNoTo" runat="server" Text='<%#Eval("BookNumberTo")%>'></asp:Label>
                                        </td>
                                        <td align="center">प्रति बंडल पुस्तक संख्या 
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%#Eval("BooksPerBundle")%>' OnTextChanged="txtChange" AutoPostBack="true" Enabled="false"></asp:TextBox><br />
                                            <asp:TextBox ID="lblTotalBundles" runat="server" Text='<%#Eval("TotalBundels")%>' Enabled="false"></asp:TextBox>
                                        </td>

                                        <td align="center">
                                            <asp:Label ID="LblBundleNoFrom" runat="server" Text='<%#Eval("BundleNoFrom")%>'></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="LblBundleNOTo" runat="server" Text='<%#Eval("BundleNoTo")%>'></asp:Label>
                                        </td>

                                        <td align="center">
                                            <asp:Label ID="LblPrinter" runat="server" Text='<%#Eval("NoOfBooks")%>'></asp:Label>
                                        </td>

                                        <td align="center">
                                            <asp:Label ID="Label9" runat="server" Text='<%#Eval("TitleHindi_V")%>'></asp:Label>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("BookType")%>'></asp:Label>
                                        </td>


                                    </tr>

                                </ItemTemplate>
                                <FooterTemplate>
                                    <tr>
                                        <th>Total</th>
                                        <th></th>
                                        <th>
                                            <asp:Label ID="lbl1" runat="server"></asp:Label></th>
                                        <th></th>
                                        <th></th>
                                        <th>
                                            <asp:Label ID="lbl2" runat="server"></asp:Label></th>
                                        <th></th>
                                        <th></th>
                                        <th>
                                            <asp:Label ID="lbl3" runat="server"></asp:Label></th>
                                        <th></th>
                                    </tr>
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle CssClass="Gvpaging" />
                        <EmptyDataRowStyle CssClass="GvEmptyText" />
                    </asp:GridView>
                </div>
                <div class="col-md-12">
                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary" OnClick="Button2_Click" Text="सुरक्षित करें" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

