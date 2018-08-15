<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeFile="MedicalPremiumAllowanceSearch.aspx.cs" Inherits="UniversityProject.MedicalPremiumAllowanceSearch" %>
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
       <asp:label ID="LblTitle" runat="server" text="MEDICAL PREMIUM ALLOWANCE SEARCH" Font-Bold="True" Font-Names="Copperplate Gothic Bold" Font-Size="X-Large" Font-Underline="True"></asp:label>
    </div>
    <br />
    <div>
        <table cellspacing="20px">
            <tr>
                <td>
                    <asp:Label ID="LblYear" runat="server" Text="YEAR:" CssClass="lblStyle"></asp:Label>
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
                        <asp:LinkButton ID="LinkButtonAddNew" runat="server" OnClick="LinkButtonAddNew_Click">ADD NEW</asp:LinkButton>
                        </td>
                </tr>
            </table>
        </div>
    <div>
    </div>
    <br />
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="4" DataKeyNames="WHOM,AGE,YEAR" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                     
                <asp:TemplateField HeaderText="WHOM" SortExpression="WHOM">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("WHOM") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("WHOM") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AGE" SortExpression="AGE">
                    <EditItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("AGE") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("AGE") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="YEAR" SortExpression="YEAR">
                    <EditItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("YEAR") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("YEAR") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="AMOUNT" SortExpression="AMOUNT">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("AMOUNT") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("AMOUNT") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:UniversityDatabaseConnectionString %>" 
            DeleteCommand="DELETE FROM [MEDICALPREMIUMALLOWANCE] WHERE [WHOM] = @original_WHOM AND [AGE] = @original_AGE AND [YEAR] = @original_YEAR AND [AMOUNT] = @original_AMOUNT" 
            InsertCommand="INSERT INTO [MEDICALPREMIUMALLOWANCE] ([WHOM], [AGE], [YEAR], [AMOUNT]) VALUES (@WHOM, @AGE, @YEAR, @AMOUNT)" OldValuesParameterFormatString="original_{0}" 
            SelectCommand="SELECT * FROM [MEDICALPREMIUMALLOWANCE] WHERE ([YEAR] = @YEAR)" 
            UpdateCommand="UPDATE [MEDICALPREMIUMALLOWANCE] SET [AMOUNT] = @AMOUNT WHERE [WHOM] = @original_WHOM AND [AGE] = @original_AGE AND [YEAR] = @original_YEAR AND [AMOUNT] = @original_AMOUNT">
            <DeleteParameters>
                <asp:Parameter Name="original_WHOM" Type="String" />
                <asp:Parameter Name="original_AGE" Type="String" />
                <asp:Parameter Name="original_YEAR" Type="String" />
                <asp:Parameter Name="original_AMOUNT" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="WHOM" Type="String" />
                <asp:Parameter Name="AGE" Type="String" />
                <asp:Parameter Name="YEAR" Type="String" />
                <asp:Parameter Name="AMOUNT" Type="Int32" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtYear" Name="YEAR" PropertyName="Text" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="AMOUNT" Type="Int32" />
                <asp:Parameter Name="original_WHOM" Type="String" />
                <asp:Parameter Name="original_AGE" Type="String" />
                <asp:Parameter Name="original_YEAR" Type="String" />
                <asp:Parameter Name="original_AMOUNT" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        
    </div>


</asp:Content>
