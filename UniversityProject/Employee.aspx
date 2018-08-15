<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeFile="Employee.aspx.cs" Inherits="UniversityProject.Employee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <p>
        <br />
    </p>
    <p>
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
        
        <table style="width:100%;">
            <tr>
                <td style="width: 327px">
                    <asp:Label ID="lblEmployeeId" runat="server" Text="EMPLOYEE ID :"></asp:Label>
                </td>
                <td style="width: 347px">
                    <asp:TextBox ID="txtEmployeeId" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmployeeId" ErrorMessage="Please enter a valid number" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 327px">
                    <asp:Label ID="lblEmployeeName" runat="server" Text="EMPLOYEE NAME :"></asp:Label>
                </td>
                <td style="width: 347px">
                    <asp:TextBox ID="txtEmployeeName" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmployeeName" ErrorMessage="Please enter a valid name" ValidationExpression="^[a-zA-Z\s]+$"></asp:RegularExpressionValidator>
                </td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" cssclass="btnCss" />
                </td>
            </tr>
            <tr>
                <td style="width: 327px">
                    <asp:Label ID="lblDept" runat="server" Text="DEPARTMENT :"></asp:Label>
                </td>
                <td style="width: 347px">
                    <asp:DropDownList ID="ddlDeptName" runat="server" DataTextField="DEPTNAME" DataValueField="DEPTNAME">
                        <asp:ListItem Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:UniversityDatabaseConnectionString %>" SelectCommand="SELECT DISTINCT [DEPTNAME] FROM [DEPT_PROFILE$]"></asp:SqlDataSource>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 327px">
                    <asp:HyperLink ID="HyperLinkCreateNew" NavigateUrl="~/EmployeeInsertion.aspx" runat="server">Create New</asp:HyperLink>
                </td>
                <td style="width: 347px">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 327px">
                    &nbsp;</td>
                <td style="width: 347px">
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 327px">
                    <asp:Button ID="ButtonDelete" runat="server" Text="Delete Records" OnClick="ButtonDelete_Click" cssclass="btnCss" />
                </td>
                <td style="width: 347px">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </p>
    <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"  ShowHeaderWhenEmpty="True" EmptyDataText="NO RECORD FOUND TO YOUR SEARCH CRITERIA!!" >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBoxDelete" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="EMPNO" HeaderText="EMPNO" SortExpression="EMPNO" />
            <asp:BoundField DataField="EMPNAME" HeaderText="EMPNAME" SortExpression="EMPNAME" />
            <asp:BoundField DataField="DEPTNO" HeaderText="DEPTNO" SortExpression="DEPTNO" />
            <asp:HyperLinkField DataNavigateUrlFields="EMPNO" DataNavigateUrlFormatString="EmployeeModification.aspx?EMPNO={0}" HeaderText="Click to Edit" Text="Edit" />
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:UniversityDatabaseConnectionString %>" SelectCommand="SELECT [EMPNO], [EMPNAME], [DEPTNO] FROM [EMP_PROFILE$]"></asp:SqlDataSource>
</asp:Content>