<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeFile="PTPGDCASearch.aspx.cs" Inherits="UniversityProject.PTPGDCASearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



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
    <br />
    <br />
    <div align="center">
        <br />
        <br />
       <asp:label ID="LblTitle" runat="server" text="PART TIME P.G.D.C.A COURSE SEARCH" Font-Bold="True" Font-Names="Copperplate Gothic Bold" Font-Size="X-Large" Font-Underline="True"></asp:label>
    </div>
    <br />
        <div style="width:100%">
            <table cellspacing="20px">
            <tr>
                <td>
                    <asp:Label ID="LblEmpid" runat="server" Text="EMPLOYEE ID:" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtEmpid" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="TxtEmpid" ErrorMessage="Enter valid number" ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>  
                </td>
                <td>
                    <asp:Label ID="LblMth" runat="server" Text="MONTH" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListMonth" runat="server"></asp:DropDownList>  
                </td>
                <td>
                    <asp:Label ID="LblYear" runat="server" Text="YEAR" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListYear" runat="server" ></asp:DropDownList>
                </td>
            </tr>
             <tr>
                 <td colspan="7" align="center">
                     <asp:Button ID="BtnSearch" runat="server" Text="Search" CssClass="btnCss" OnClick="BtnSearch_Click" />
                 </td>
            </tr>
            <tr>
                <td>
                    <asp:LinkButton ID="LinkButtonLogIn" runat="server" OnClick="LinkButtonLogIn_Click">ADD NEW</asp:LinkButton>
                </td>
                <td colspan="6">

                </td>
            </tr>
        </table>
        </div>
    <br />
    <div style="float: left; width:70%">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="141%" EmptyDataText="NO RECORD FOUND TO YOUR SEARCH CRITERIA!!" CellPadding="4" ForeColor="#333333" GridLines="None" ShowHeaderWhenEmpty="true">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="EMPNO" HeaderText="EMPNO" SortExpression="EMPNO" />
                <asp:BoundField DataField="MONTH" HeaderText="MONTH" SortExpression="MONTH" />
                <asp:BoundField DataField="YEAR" HeaderText="YEAR" SortExpression="YEAR" />
                <asp:HyperLinkField DataNavigateUrlFields="EMPNO,MONTH,YEAR" DataNavigateUrlFormatString="PTPGDCAModification.aspx?EMPNO={0}&amp;MONTH={1}&amp;YEAR={2}" HeaderText="Click To Edit" Text="Edit" />
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
