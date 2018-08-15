<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeFile="PartTimeDegreeCourse.aspx.cs" Inherits="UniversityProject.PartTimeDegreeCourse" %>
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
    <table style="width:100%;">
        <tr>
                <td style="width: 199px">&nbsp;</td>
                <td colspan="2">
                    <asp:Label ID="lblExamRmn" runat="server" Text="PART TIME DEGREE COURSE" Font-Bold="True" Font-Underline="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 199px">
                    <asp:Label ID="lblEmpno" runat="server" Text="EMPNO :"></asp:Label>
                    <asp:TextBox ID="txtSearchEmpno" runat="server"></asp:TextBox>
                </td>
                <td style="width: 187px">
                    <asp:Label ID="lblMonth" runat="server" Text="MONTH :"></asp:Label>
                    <asp:DropDownList ID="ddlSearchMonth" runat="server">
                        <asp:ListItem Selected="True" Value="">Select</asp:ListItem>
                        <asp:ListItem>JAN</asp:ListItem>
                        <asp:ListItem>FEB</asp:ListItem>
                        <asp:ListItem>MAR</asp:ListItem>
                        <asp:ListItem>APR</asp:ListItem>
                        <asp:ListItem>MAY</asp:ListItem>
                        <asp:ListItem>JUN</asp:ListItem>
                        <asp:ListItem>JUL</asp:ListItem>
                        <asp:ListItem>AUG</asp:ListItem>
                        <asp:ListItem>SEP</asp:ListItem>
                        <asp:ListItem>OCT</asp:ListItem>
                        <asp:ListItem>NOV</asp:ListItem>
                        <asp:ListItem>DEC</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 169px">
                    <asp:Label ID="lblYear" runat="server" Text="YEAR :"></asp:Label>
                    <asp:DropDownList ID="ddlSearchYear" runat="server"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:UniversityDatabaseConnectionString %>" SelectCommand="SELECT DISTINCT [YEAR] FROM [PTD$]"></asp:SqlDataSource>
                </td>
            </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="ButtonSearch" runat="server" Text="SEARCH" CssClass="btnCss"  OnClick="ButtonSearch_Click"/><%--  CommandName="SearchCommandButton"  OnCommand="ImgCalender_Command" --%>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><asp:linkbutton id="LinkButtonAddNew" runat="server" OnClick="LinkButtonAddNew_Click">ADD NEW</asp:linkbutton></td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3"></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="ButtonDelete" runat="server" Text="Delete Records" CssClass="btnCss" OnClick="ButtonDelete_Click" /> <%--  OnCommand="ImgCalender_Command"  CommandName="DeleteCommandButton" --%>
            </td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="EMPNO,MONTH,YEAR,BANK_TRANDATE" ForeColor="#333333" GridLines="None" Width="100%" ShowHeaderWhenEmpty="True" EmptyDataText="NO RECORD FOUND TO YOUR SEARCH CRITERIA!!" ShowFooter="True"><%--  OnSelectedIndexChanged="GridView1_SelectedIndexChanged"  DataSourceID="SqlDataSource2" --%>
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField HeaderText="Delete">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBoxDelete" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="EMPNO" SortExpression="EMPNO">
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("EMPNO") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("EMPNO") %>'></asp:Label>
                </ItemTemplate>
                <%-- <FooterTemplate>
                    <asp:TextBox ID="txtEmpno" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter Employee number" ControlToValidate="txtEmpno" ValidationGroup="INSERT"></asp:RequiredFieldValidator>
                </FooterTemplate>--%>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="MONTH" SortExpression="MONTH">
                <EditItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("MONTH") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("MONTH") %>'></asp:Label>
                </ItemTemplate>
                <%--<FooterTemplate>
                    <asp:DropDownList ID="ddlMonth" runat="server">
                        <asp:ListItem Selected="True">Select</asp:ListItem>
                        <asp:ListItem>JAN</asp:ListItem>
                        <asp:ListItem>FEB</asp:ListItem>
                        <asp:ListItem>MAR</asp:ListItem>
                        <asp:ListItem>APR</asp:ListItem>
                        <asp:ListItem>MAY</asp:ListItem>
                        <asp:ListItem>JUN</asp:ListItem>
                        <asp:ListItem>JUL</asp:ListItem>
                        <asp:ListItem>AUG</asp:ListItem>
                        <asp:ListItem>SEP</asp:ListItem>
                        <asp:ListItem>OCT</asp:ListItem>
                        <asp:ListItem>NOV</asp:ListItem>
                        <asp:ListItem>DEC</asp:ListItem>
                    </asp:DropDownList>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ValidationGroup="INSERT" ErrorMessage="Please select a month" ValueToCompare="Select" ControlToValidate="ddlMonth" Operator="NotEqual"></asp:CompareValidator>
                </FooterTemplate>--%>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="YEAR" SortExpression="YEAR">
                <EditItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("YEAR") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("YEAR") %>'></asp:Label>
                </ItemTemplate>
                <%-- <FooterTemplate>
                    <asp:TextBox ID="txtYear" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtYear" ValidationGroup="INSERT" runat="server" ErrorMessage="Please enter Year"></asp:RequiredFieldValidator>
                </FooterTemplate>--%>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="PTD" SortExpression="PTD">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("PTD") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("PTD") %>'></asp:Label>
                </ItemTemplate>
                <%-- <FooterTemplate>
                    <asp:TextBox ID="txtPTD" runat="server"></asp:TextBox>
                </FooterTemplate>--%>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="INC_TAX" SortExpression="INC_TAX">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("INC_TAX") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("INC_TAX") %>'></asp:Label>
                </ItemTemplate>
                <%-- <FooterTemplate>
                    <asp:TextBox ID="txtIncTax" runat="server"></asp:TextBox>
                </FooterTemplate>--%>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="NET_PTD" SortExpression="NET_PTD">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("NET_PTD") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("NET_PTD") %>'></asp:Label>
                </ItemTemplate>
                <%-- <FooterTemplate>
                    <asp:TextBox ID="txtNetPTD" runat="server"></asp:TextBox>
                </FooterTemplate>--%>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="BANK_TRANDATE" SortExpression="BANK_TRANDATE">
                <EditItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("BANK_TRANDATE") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("BANK_TRANDATE") %>'></asp:Label>
                </ItemTemplate>
                <%--<FooterTemplate>
                     <asp:DropDownList ID="ddlBankDay" runat="server">
                        <asp:ListItem Selected="True">Select</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>26</asp:ListItem>
                        <asp:ListItem>27</asp:ListItem>
                        <asp:ListItem>28</asp:ListItem>
                        <asp:ListItem>29</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>31</asp:ListItem>
                    </asp:DropDownList>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ValidationGroup="INSERT" ErrorMessage="Please enter Bank Transfer Day" ControlToValidate="ddlBankDay" ValueToCompare="Select" Operator="NotEqual"></asp:CompareValidator>
                    <asp:DropDownList ID="ddlBankMonth" runat="server">
                        <asp:ListItem Selected="True">Select</asp:ListItem>
                        <asp:ListItem>JAN</asp:ListItem>
                        <asp:ListItem>FEB</asp:ListItem>
                        <asp:ListItem>MAR</asp:ListItem>
                        <asp:ListItem>APR</asp:ListItem>
                        <asp:ListItem>MAY</asp:ListItem>
                        <asp:ListItem>JUN</asp:ListItem>
                        <asp:ListItem>JUL</asp:ListItem>
                        <asp:ListItem>AUG</asp:ListItem>
                        <asp:ListItem>SEP</asp:ListItem>
                        <asp:ListItem>OCT</asp:ListItem>
                        <asp:ListItem>NOV</asp:ListItem>
                        <asp:ListItem>DEC</asp:ListItem>
                    </asp:DropDownList>
                    <asp:CompareValidator ID="CompareValidator3" runat="server" ValidationGroup="INSERT" ErrorMessage="Please enter Bank Transfer Month" ControlToValidate="ddlBankMonth" ValueToCompare="Select" Operator="NotEqual"></asp:CompareValidator>
                    <asp:TextBox ID="txtBankYear" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"  ValidationGroup="INSERT" runat="server" ErrorMessage="Please enter a valid year" ControlToValidate="txtBankYear" ValidationExpression="^\d{4}$"></asp:RegularExpressionValidator>--%>
                    
                    <%-- <asp:TextBox ID="txtBankTransDate" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ErrorMessage="Please enter Bank transfer date" ControlToValidate="txtBankTransDate"  ValidationGroup="INSERT"></asp:RequiredFieldValidator>
                    <asp:ImageButton ID="ImgCalender" runat="server"  ImageUrl="~/images/Calender.png" OnClick="ImgCalender_Click" CausesValidation="false" OnCommand="ImgCalender_Command" CommandName="ImgCalenderCommand"></asp:ImageButton>
                     <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" OnSelectionChanged="Calendar1_SelectionChanged" Width="350px">
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                        <TodayDayStyle BackColor="#CCCCCC" />
                    </asp:Calendar>
                </FooterTemplate>--%>
            </asp:TemplateField>
            <asp:HyperLinkField DataNavigateUrlFields="EMPNO,MONTH,YEAR" DataNavigateUrlFormatString="PartTimeDegreeCourseModification.aspx?EMPNO={0}&amp;MONTH={1}&amp;YEAR={2}" HeaderText="Edit" Text="Edit" />
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
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:UniversityDatabaseConnectionString %>" 
        DeleteCommand="DELETE FROM [PTD$] WHERE [EMPNO] = @EMPNO AND [MONTH] = @MONTH AND [YEAR] = @YEAR AND [BANK_TRANDATE] = @BANK_TRANDATE" 
        InsertCommand="INSERT INTO [PTD$] ([EMPNO], [MONTH], [YEAR], [PTD], [INC_TAX], [NET_PTD], [BANK_TRANDATE]) VALUES (@EMPNO, @MONTH, @YEAR, @PTD, @INC_TAX, @NET_PTD, @BANK_TRANDATE)" 
        SelectCommand="SELECT * FROM [PTD$] WHERE (([EMPNO] =  @EMPNO or isnull(@EMPNO,'')='') AND ([MONTH] = @MONTH  or isnull(@month,'')='') AND ([YEAR] = @YEAR or isnull(@year,'')=''))" 
        UpdateCommand="UPDATE [PTD$] SET [PTD] = @PTD, [INC_TAX] = @INC_TAX, [NET_PTD] = @NET_PTD WHERE [EMPNO] = @EMPNO AND [MONTH] = @MONTH AND [YEAR] = @YEAR AND [BANK_TRANDATE] = @BANK_TRANDATE"
         CancelSelectOnNullParameter="false">
        <DeleteParameters>
            <asp:Parameter Name="EMPNO" Type="Double" />
            <asp:Parameter Name="MONTH" Type="String" />
            <asp:Parameter Name="YEAR" Type="String" />
            <asp:Parameter Name="BANK_TRANDATE" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="EMPNO" Type="Double" />
            <asp:Parameter Name="MONTH" Type="String" />
            <asp:Parameter Name="YEAR" Type="String" />
            <asp:Parameter Name="PTD" Type="Double" />
            <asp:Parameter Name="INC_TAX" Type="Double" />
            <asp:Parameter Name="NET_PTD" Type="Double" />
            <asp:Parameter Name="BANK_TRANDATE" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="txtSearchEmpno" Name="EMPNO" PropertyName="Text" Type="Double" />
            <asp:ControlParameter ControlID="ddlSearchMonth" Name="MONTH" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="false"/>
            <asp:ControlParameter ControlID="ddlSearchYear" Name="YEAR" PropertyName="SelectedValue" Type="String" ConvertEmptyStringToNull="false" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="PTD" Type="Double" />
            <asp:Parameter Name="INC_TAX" Type="Double" />
            <asp:Parameter Name="NET_PTD" Type="Double" />
            <asp:Parameter Name="EMPNO" Type="Double" />
            <asp:Parameter Name="MONTH" Type="String" />
            <asp:Parameter Name="YEAR" Type="String" />
            <asp:Parameter Name="BANK_TRANDATE" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <%-- <asp:LinkButton ID="LinkButton1" runat="server" ValidationGroup="INSERT" OnClick="LinkButton1_Click"  OnCommand="ImgCalender_Command" CommandName="InsertCommandLinkButton">Insert</asp:LinkButton>
    <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="INSERT" ShowMessageBox="true"/>--%>
</asp:Content>
