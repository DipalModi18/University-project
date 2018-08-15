<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeFile="SavingsSections.aspx.cs" Inherits="UniversityProject.SavingsSections" %>

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
    <p>
        <br />
    </p>
    <p>
    </p>
    <p>
    </p>
    <div align="center">
        <br />
        <asp:label id="LblTitle" runat="server" text="SAVINGS SECTIONS" font-bold="True" font-names="Copperplate Gothic Bold" font-size="X-Large" font-underline="True"></asp:label>
        <br />
    </div>
    <asp:LinkButton ID="lbAddNew" runat="server" OnClick="lbAddNew_Click">ADD NEW</asp:LinkButton>
    <br />
    <div>
        <asp:gridview ID="GridView1" runat="server" autogeneratecolumns="False" cellpadding="4" datakeynames="ID,NAME" datasourceid="SqlDataSource1" forecolor="#333333" gridlines="None" width="1000px" showfooter="True" ShowHeaderWhenEmpty="True" EmptyDataText="NO RECORD FOUND TO YOUR SEARCH CRITERIA!!">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>

                <asp:TemplateField ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="NAME" SortExpression="NAME">
                    <EditItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("NAME") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("NAME") %>'></asp:Label>
                    </ItemTemplate>
                     <%-- <FooterTemplate>
                        <asp:TextBox ID="txtInsertName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Enter Section name" ValidationGroup="INSERT" ControlToValidate="txtInsertName"></asp:RequiredFieldValidator>
                    </FooterTemplate>--%>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="AMOUNT" SortExpression="AMOUNT">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("AMOUNT") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("AMOUNT") %>'></asp:Label>
                    </ItemTemplate>
                     <%-- <FooterTemplate>
                        <asp:TextBox ID="txtInsertAmount" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Enter Section Amount" ValidationGroup="INSERT" ControlToValidate="txtInsertAmount"></asp:RequiredFieldValidator>
                    </FooterTemplate>--%>
                </asp:TemplateField>

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
        </asp:gridview>
        <asp:sqldatasource id="SqlDataSource1" runat="server" connectionstring="<%$ ConnectionStrings:UniversityDatabaseConnectionString %>" deletecommand="DELETE FROM [SAVINGS_SECTIONS$] WHERE [ID] = @ID AND [NAME] = @NAME" insertcommand="INSERT INTO [SAVINGS_SECTIONS$] ([NAME], [AMOUNT], [YEAR1], [YEAR2]) VALUES (@NAME, @AMOUNT, @YEAR1, @YEAR2)" selectcommand="SELECT * FROM [SAVINGS_SECTIONS$] WHERE ([NAME] &lt;&gt; @NAME)" updatecommand="UPDATE [SAVINGS_SECTIONS$] SET [AMOUNT] = @AMOUNT, [YEAR1] = @YEAR1, [YEAR2] = @YEAR2 WHERE [ID] = @ID AND [NAME] = @NAME">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
                <asp:Parameter Name="NAME" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="NAME" Type="String" />
                <asp:Parameter Name="AMOUNT" Type="String" />
                <asp:Parameter Name="YEAR1" Type="String" />
                <asp:Parameter Name="YEAR2" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:Parameter DefaultValue="80C" Name="NAME" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="AMOUNT" Type="String" />
                <asp:Parameter Name="YEAR1" Type="String" />
                <asp:Parameter Name="YEAR2" Type="String" />
                <asp:Parameter Name="ID" Type="Int32" />
                <asp:Parameter Name="NAME" Type="String" />
            </UpdateParameters>
        </asp:sqldatasource>
        <%-- <asp:button id="btnInsert" runat="server" text="INSERT" validationgroup="INSERT" cssclass="btnCss" onclick="btnInsert_Click" />--%>
        <br />
    </div>
</asp:Content>
