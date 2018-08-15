<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DepartmentSearch.aspx.cs" Inherits="UniversityProject.DepartmentSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div  style="height:30%">
        <div style="float: left; width:40%">
            <table cellspacing="20px">
            <tr>
                <td>
                    <asp:Label ID="LblDeptId" runat="server" Text="DEPARTMENT ID:" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtDeptId" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        </div>
        <div style="float: right; width:50%">
            <table cellspacing="20px">
                <tr>
                <td>
                    <asp:Label ID="LblDeptName" runat="server" Text="DEPARTMENT NAME:" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtDeptlName" runat="server"></asp:TextBox>
                </td>
            </tr>
            </table>
        </div>
        <div style="float: left; width:40%">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="BtnSearch" runat="server" Text="Search" OnClick="BtnSearch_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div style="float: right; width:50%">
            <table>
                <tr>
                    <td>
                        <asp:LinkButton ID="LinkButtonLogIn" runat="server" OnClick="LinkButtonLogIn_Click">ADD NEW</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div style="float: left; width:70%">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="DEPTNO" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="DEPTNO" HeaderText="DEPTNO" ReadOnly="True" SortExpression="DEPTNO" />
                <asp:BoundField DataField="DEPTNAME" HeaderText="DEPTNAME" SortExpression="DEPTNAME" />
                <asp:BoundField DataField="FACID" HeaderText="FACID" SortExpression="FACID" />
                <asp:BoundField DataField="ABBRE" HeaderText="ABBRE" SortExpression="ABBRE" />
                <asp:BoundField DataField="ADDR1" HeaderText="ADDR1" SortExpression="ADDR1" />
                <asp:BoundField DataField="ADDR2" HeaderText="ADDR2" SortExpression="ADDR2" />
                <asp:BoundField DataField="CITY" HeaderText="CITY" SortExpression="CITY" />
                <asp:BoundField DataField="PINCODE" HeaderText="PINCODE" SortExpression="PINCODE" />
                <asp:BoundField DataField="PHONE" HeaderText="PHONE" SortExpression="PHONE" />
                <asp:BoundField DataField="FAX" HeaderText="FAX" SortExpression="FAX" />
                <asp:BoundField DataField="HOD" HeaderText="HOD" SortExpression="HOD" />
                <asp:HyperLinkField DataNavigateUrlFields="DEPTNO" DataNavigateUrlFormatString="DepartmentModification.aspx?DEPTNO={0}" HeaderText="Click To Edit" Text="Edit" />
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
        </div>
</asp:Content>
