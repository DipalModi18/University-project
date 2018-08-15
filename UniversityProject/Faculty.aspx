<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeFile="Faculty.aspx.cs" Inherits="UniversityProject.Faculty" %>

<%--   --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <br />
    <br />
    <br />
    <style>
        .btnCss {
            background-color: #323299;
            border: none;
            color: white;
            padding: 10px 16px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
        }

        .lblStyle {
            font-family: "Lucida Fax","Times New Roman";
            color: #00688b;
        }

        </style>
    <table style="width: 100%;">
        <tr>
            <td colspan="3" style="float: center; text-align: center; height: 10%;">
                <asp:Label ID="LabelFaculty" runat="server" Text="FACULTY" Font-Bold="True" Font-Underline="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 300px">
                <asp:Label ID="LabelFacID" runat="server" Text="FACULTY ID :"></asp:Label>
                <asp:TextBox ID="TextBoxFacID" runat="server"></asp:TextBox>
            </td>
            <td style="width: 259px">
                <asp:Label ID="LabelFacName" runat="server" Text="FACULTY NAME"></asp:Label>
                <asp:TextBox ID="TextBoxFacName" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="ButtonSearch" runat="server" Text="SEARCH" OnClick="ButtonSearch_Click" CssClass="btnCss" />
            </td>
        </tr>

        <tr>
            <td style="width: 300px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxFacID" ErrorMessage="Please enter a valid number" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator></td>
            <td style="width: 259px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxFacName" ErrorMessage="Please enter a valid name" ValidationExpression="^[a-zA-Z\s]+$"></asp:RegularExpressionValidator></td>
            <td>&nbsp;</td>
        </tr>

        <tr>
            <td style="width: 300px">&nbsp;</td>
            <td style="width: 259px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>

        <tr>
            <td style="width: 300px">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/FacultyInsertion.aspx">Create New</asp:HyperLink>
            </td>
            <td style="width: 259px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>

        <tr>
            <td colspan="3">&nbsp;</td>
        </tr>

        <tr>
            <td colspan="3">
                <asp:Button ID="ButtonDelete" runat="server" Text="Delete Records" OnClick="ButtonDelete_Click" CssClass="btnCss" />
            </td>
        </tr>


        <tr style="width: 100%">
            <td colspan="3">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1039px" EmptyDataText="NO RECORD FOUND TO YOUR SEARCH CRITERIA!!" ShowHeaderWhenEmpty="True">
                    <%-- DataSourceID="SqlDataSource1" --%>
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBoxDelete" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="FACID" HeaderText="FACID" SortExpression="FACID" />
                        <asp:BoundField DataField="FACNAME" HeaderText="FACNAME" SortExpression="FACNAME" />
                        <asp:HyperLinkField HeaderText="Click to Edit" Text="Edit" DataNavigateUrlFields="FACID"
                            DataNavigateUrlFormatString="FacultyModification.aspx?FACID={0}" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:UniversityDatabaseConnectionString %>" SelectCommand="SELECT [FACID], [FACNAME] FROM [FACULTY_PROFILE$]"></asp:SqlDataSource>

            </td>
        </tr>

    </table>

    <%-- <script>
        function DeleteConfirm(facid)
        {
            var confirmation = document.createElement("INPUT");
            confirmation.type = "hidden";
            confirmation.name = "confirm_value";

            if (confirm("Are you sure want to delete Faculty =" + facid + "?"))
                confirmation.value = "Yes";
            else
                confirmation.value = "no";
        }
    </script>--%>
</asp:Content>
