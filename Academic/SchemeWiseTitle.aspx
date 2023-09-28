<%@ Page Title="योजना वार शीर्षक / Schemewise Title " Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
    CodeFile="SchemeWiseTitle.aspx.cs" Inherits="Academic_SchemeWiseTitle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="table-responsive">
        <div class="portlet-header ui-widget-header">योजना वार शीर्षक / Schemewise Title  </div>
        <div class="portlet-content">

            <table width="100%">
                <tr>
                    <td>&#2325;&#2325;&#2381;&#2359;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350;
                        <br />
                        Class Name </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlClass" CssClass="txtbox reqirerd" AutoPostBack="true" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                        </asp:DropDownList>

                        <asp:Label ID="lblClass" runat="server" Text="*" ForeColor="Red"></asp:Label>

                    </td>
                </tr>

                <tr>
                    <td>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325;
                        <br />
                        Title </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlTitle" CssClass="txtbox reqirerd" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlTitle_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:Label ID="lblTitle" runat="server" Text="*" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&#2351;&#2379;&#2332;&#2344;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350;
                        <br />
                        Scheme</td>

                    <td>
                        <asp:CheckBoxList runat="server" ID="ChkScheme" Width="800px" RepeatColumns="3" RepeatDirection="Horizontal"></asp:CheckBoxList>

                        <asp:Label ID="lblChk" runat="server" Text="*" ForeColor="Red"></asp:Label>

                    </td>

                </tr>

                <tr>
                    <td>&#2357;&#2367;&#2357;&#2352;&#2339;
                        <br />
                        Remark</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtRemark" TextMode="MultiLine" Width="370px" onkeypress="MaxLengthCount('ContentPlaceHolder1_txtRemark',250);"></asp:TextBox>
                    </td>

                </tr>


                <tr>
                    <td></td>
                    <td>
                        <asp:Button runat="server" ID="btnSave" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save" CssClass="btn" OnClick="btnSave_Click" />

                    </td>
                </tr>

            </table>



        </div>

    </div>
    <script type="text/javascript">

        function MaxLengthCount(txt, MaxLen) {
            var txtBox = document.getElementById(txt);
            var len = MaxLen;


            if (txtBox.value.length > len) {

                txtBox.value = txtBox.value.substring(0, len);
                alert("Charactor length is Exeed from " + len);

            }
            else { }

        }


    </script>

</asp:Content>

