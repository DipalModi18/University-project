<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeFile="DepartmentModification.aspx.cs" Inherits="UniversityProject.DepartmentModification" %>
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
<div style="text-align:center; text-decoration:underline; height:10%">
       <asp:label ID="LblTitle" runat="server" text="DEPARTMENT MODIFICATION" Font-Bold="True" Font-Names="Copperplate Gothic Bold" Font-Size="Large"></asp:label>
    </div>
  
    <div style="height:50%">
    
    <div style="float: left; width:50%">
       <table cellspacing="20px">
           <tr>
               <td>
                   <asp:label ID="lbldptid" runat="server" text="DEPARTMENT ID:" CssClass="lblStyle"></asp:label>
               </td>
               <td>
                   <asp:Label ID="LblDptidDisplay" runat="server" Text="Label"></asp:Label>
               </td>
               
           </tr>
           <tr>
               <td>
                   <asp:label ID="LblDptName" runat="server" text="DEPARTMENT NAME:" CssClass="lblStyle"></asp:label>
               </td>
               <td>
                   <asp:TextBox ID="Txtdptname" runat="server"></asp:TextBox>
               </td>
               <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtdptname" ErrorMessage="This field is compulsory."></asp:RequiredFieldValidator>
        </td>
               <td>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtdptname" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="Enter Alphabets and space." />
        </td>
           </tr>
           <tr>
               <td>
                   <asp:label ID="LblFacultyId" runat="server" text="FACULTY ID:" CssClass="lblStyle"></asp:label>
               </td>
               <td>
                   <asp:DropDownList ID="Ddlfacultyid" runat="server" Height="17px"  AutoPostBack="true" OnSelectedIndexChanged="Ddlfacultyid_SelectedIndexChanged"></asp:DropDownList>
                   <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:UniversityDatabaseConnectionString %>" SelectCommand="SELECT [FACID] FROM [FACULTY_PROFILE$]"></asp:SqlDataSource>
               </td>
               <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Ddlfacultyid" ErrorMessage="This field is compulsory."></asp:RequiredFieldValidator>
        </td>
           </tr>
           <tr>
               <td>

               </td>
               <td colspan="3">
                   <asp:Label ID="lblFacName" runat="server" Text="Label"></asp:Label>
               </td>
           </tr>
           <tr>
               <td>
                   <asp:label ID="Lblabbreviation" runat="server" text="ABBREVIATION:" CssClass="lblStyle"></asp:label>
               </td>
               <td>
                   <asp:TextBox ID="Txtabbreviation" runat="server"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td>
                   <asp:label ID="Lbladdr1" runat="server" text="ADDRESS 1:" CssClass="lblStyle"></asp:label>
               </td>
               <td>
                   <asp:TextBox ID="Txtaddr1" runat="server"></asp:TextBox>
               </td>
               <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Txtaddr1" ErrorMessage="This field is compulsory."></asp:RequiredFieldValidator>
        </td>
           </tr>
           <tr>
               <td>
                   <asp:label ID="Lbladdr2" runat="server" text="ADDRESS 2:" CssClass="lblStyle"></asp:label>
               </td>
               <td>
                   <asp:TextBox ID="Txtaddr2" runat="server"></asp:TextBox>
               </td>
           </tr>
       </table> 
    </div>
    <div style="float: right; width:50%">
        <table cellspacing="20px">
            <tr>
               <td>
                   <asp:label ID="Lblcity" runat="server" text="CITY:" CssClass="lblStyle"></asp:label>
               </td>
               <td>
                   <asp:TextBox ID="Txtcity" runat="server"></asp:TextBox>
               </td>
               <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Txtcity" ErrorMessage="This field is compulsory."></asp:RequiredFieldValidator>
        </td>
                <td>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Txtcity" ValidationExpression="[a-zA-Z ]*$" ErrorMessage="Enter Alphabets and space." />
        </td>
           </tr>
            <tr>
               <td>
                   <asp:label ID="Lblpincode" runat="server" text="PINCODE:" CssClass="lblStyle"></asp:label>
               </td>
               <td>
                   <asp:TextBox ID="Txtpincode" runat="server"></asp:TextBox>
               </td>
                <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Txtpincode" ErrorMessage="This field is compulsory."></asp:RequiredFieldValidator>
        </td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="Txtpincode" ErrorMessage="Enter valid pincode" ValidationExpression="[0-9]{6}"></asp:RegularExpressionValidator>  
                </td>
           </tr>
            <tr>
               <td>
                   <asp:label ID="Lblphone" runat="server" text="PHONE:" CssClass="lblStyle"></asp:label>
               </td>
               <td>
                   <asp:TextBox ID="Txtphone" runat="server"></asp:TextBox>
               </td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="Txtphone" ErrorMessage="Enter valid phone number" ValidationExpression="[0-9]+"></asp:RegularExpressionValidator>  
                </td>
           </tr>
            <tr>
               <td>
                   <asp:label ID="Lblfax" runat="server" text="FAX:" CssClass="lblStyle"></asp:label>
               </td>
               <td>
                   <asp:TextBox ID="txtfax" runat="server"></asp:TextBox>
               </td>
           </tr>
            <tr>
               <td>
                   <asp:label ID="Lblhod" runat="server" text="HOD:" CssClass="lblStyle"></asp:label>
               </td>
               <td>
                   <asp:TextBox ID="Txthod" runat="server"></asp:TextBox>
               </td>
                <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Txthod" ErrorMessage="This field is compulsory."></asp:RequiredFieldValidator>
        </td>
                <td>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="Txthod" ValidationExpression="[A-Za-z]+[. ]*([A-Za-z]+[ ]*)*" ErrorMessage="Enter Alphabets and space." />
        </td>
           </tr>
        </table>
    </div>
    </div>
    <div>
        <table cellspacing="20px">
            <tr>
                <td>
                </td>
            </tr>
            </table>
    </div>
        <div align="center">
            
                   <asp:button ID="btnsave" runat="server" text="SAVE" CssClass="btnCss" OnClick="btnsave_Click"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;       
            <asp:button ID="Btncancel" runat="server" text="CANCEL" CssClass="btnCss" OnClick="Btncancel_Click" CausesValidation="false" />           
    </div>

</asp:Content>
