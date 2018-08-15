<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeFile="IncomeTaxSearch.aspx.cs" Inherits="UniversityProject.IncomeTaxSearch" %>
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
       <asp:label ID="LblTitle" runat="server" text="INCOME TAX SEARCH" Font-Bold="True" Font-Names="Copperplate Gothic Bold" Font-Size="X-Large" Font-Underline="True"></asp:label>
    </div>
    <br />
    <div>
        <table cellspacing="20px">
            <tr>
                <td>
                    <asp:Label ID="LblYear" runat="server" Text="YEAR 1:" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtYear" runat="server"></asp:TextBox>
                </td>
               
                <td>
                    <asp:Button ID="BtnSearch" runat="server" Text="SEARCH" CssClass="btnCss" OnClick="BtnSearch_Click" />
                </td>

            </tr>
            <tr>
                    <td>
                        <asp:LinkButton ID="BtnAdd" runat="server" OnClick="BtnAdd_Click" >ADD NEW</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
    <div>
    </div>
    <br />
    <div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="YEAR1,SLABNO,AGEGROUP,GENDER" ForeColor="#333333" GridLines="None" ShowHeaderWhenEmpty="True" Width="1071px"  emptydatatext="NO RECORD FOUND TO YOUR SEARCH CRITERIA!!">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="YEAR1" HeaderText="YEAR1" ReadOnly="True" SortExpression="YEAR1" />
                        <asp:BoundField DataField="YEAR2" HeaderText="YEAR2" SortExpression="YEAR2" />
                        <asp:BoundField DataField="SLABNO" HeaderText="SLABNO" ReadOnly="True" SortExpression="SLABNO" />
                        <asp:BoundField DataField="LOWERBOUND" HeaderText="LOWERBOUND" SortExpression="LOWERBOUND" />
                        <asp:BoundField DataField="UPPERBOUND" HeaderText="UPPERBOUND" SortExpression="UPPERBOUND" />
                        <asp:BoundField DataField="AGEGROUP" HeaderText="AGEGROUP" ReadOnly="True" SortExpression="AGEGROUP" />
                        <asp:BoundField DataField="GENDER" HeaderText="GENDER" ReadOnly="True" SortExpression="GENDER" />
                        <asp:BoundField DataField="PERCENTAGE" HeaderText="PERCENTAGE" SortExpression="PERCENTAGE" />
                        <asp:HyperLinkField DataNavigateUrlFields="YEAR1,SLABNO,GENDER,AGEGROUP" DataNavigateUrlFormatString="IncomeTaxModification.aspx?YEAR1={0}&amp;SLABNO={1}&amp;GENDER={2}&amp;AGEGROUP={3}" HeaderText="Click to Edit" Text="Edit" />
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
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:UniversityDatabaseConnectionString %>" SelectCommand="SELECT * FROM [INCOMETAXSLAB] WHERE ([YEAR1] = @YEAR1)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TxtYear" Name="YEAR1" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
    </div>

</asp:Content>
