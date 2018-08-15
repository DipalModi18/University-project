<%@ Page Title="" Language="C#" MasterPageFile="~/Site3.Master" AutoEventWireup="true" CodeFile="SavingsModification.aspx.cs" Inherits="UniversityProject.SavingsModification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <p>
        <br />
    </p>
    <p>
    </p>
    <p>
    </p>
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

    <div style="float:center; text-align:center; text-decoration: underline; height:10%;">
        <asp:label ID="lblFacInfo"  runat="server" text="SAVINGS MODIFICATION" Font-Names="Copperplate Gothic Bold" Font-Size="Large" Font-Bold="True"></asp:label>
     </div>

    <div style="width:100%">
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="lblEmployeeNo" runat="server" Text="EMPLOYEE NO :" CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblEmployeeNoValue" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblSavingsYear" runat="server" Text="YEAR OF SAVINGS :"  CssClass="lblStyle"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblSavingYearValue" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>           
        </table>
    </div>

    <br />
    <hr />
    <br />

    <div style="height:50%">


        <div style="float:left; width:50%">
            <table style="width: 100%;">
                <tr>
                    <td>
                        <asp:Label ID="lblConToPension" runat="server" Text="Contribution To The Pension Funds U/s 80-CCC."  CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtConToPension" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server" ControlToValidate="txtConToPension" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" ValidationGroup="INSERT" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMediPremium" runat="server" Text="Medical Premium U/s 80-D."  CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMediPremium" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMediPremium" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" ValidationGroup="INSERT" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblHandicappedDepend" runat="server" Text="Handicapped Dependents U/s 80-DD."  CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtHandicappedDepend" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtHandicappedDepend" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" ValidationGroup="INSERT" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMediTreatment" runat="server" Text="Medical Treatment For Certain Diseases U/s 80-E."  CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMediTreatment" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtMediTreatment" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" ValidationGroup="INSERT" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblRepayLoan" runat="server" Text="Repayment of Loan Taken For Higher Education U/s 80-E."  CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRepayLoan" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtRepayLoan" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" ValidationGroup="INSERT" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDonationCmrf" runat="server" Text="Donation to MSU or U/s 80-G."  CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDonationCmrf" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtDonationCmrf" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" ValidationGroup="INSERT" />
                    </td>
                </tr>
                 <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblBlindOrPh" runat="server" Text="Blind/ Physical Disabled Person U/s 80-U."  CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtBlindOrPh" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtBlindOrPh" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" ValidationGroup="INSERT" />
                    </td>
                </tr>
                 <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPPF" runat="server" Text="Public ProvidentFund"  CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPPF" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtPPF" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" ValidationGroup="INSERT" />
                    </td>
                </tr>
                 <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblRepayHouseLoan" runat="server" Text="Repayment of House Loan"  CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtRepayHouseLoan" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtRepayHouseLoan" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" ValidationGroup="INSERT" />
                    </td>
                </tr>
                 <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblInterestHouseLoan" runat="server" Text="Interest on House Loan"  CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtInterestHouseLoan" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtInterestHouseLoan" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" ValidationGroup="INSERT" />
                    </td>
                </tr>
                 <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAccureudInterestNSC" runat="server" Text="Accreud Interest On N.S.C"  CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAccureudInterestNSC" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="txtAccureudInterestNSC" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" ValidationGroup="INSERT" />
                    </td>
                </tr>
                 <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSec80CCG" runat="server" Text="Section 80CCG :" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSec80CCG" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator30" runat="server" ControlToValidate="txtSec80CCG" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" ValidationGroup="INSERT" />
                    </td>
                </tr>
                 <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNPS" runat="server" Text="New Pension Scheme :" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNPS" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator24" runat="server" ControlToValidate="txtNPS" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" ValidationGroup="INSERT" />
                    </td>
                </tr>
            </table>
        </div>





        <div style="float:right; width:50%">
             <table style="width: 100%;">
                <tr>
                    <td>
                        <asp:Label ID="lblNSS" runat="server" Text="National Savings Scheme"  CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNSS" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="txtNSS" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" ValidationGroup="INSERT" />
                    </td>
                </tr>
                  <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMutualFund" runat="server" Text="Mutual Funds"  CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMutualFund" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ControlToValidate="txtMutualFund" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" ValidationGroup="INSERT" />
                    </td>
                </tr>
                  <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEquityLinked" runat="server" Text="Equity Linked Savings Scheme"  CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEquityLinked" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ControlToValidate="txtEquityLinked" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" ValidationGroup="INSERT" />
                    </td>
                </tr>
                  <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTutionFees" runat="server" Text="Tution Fees"  CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTutionFees" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ControlToValidate="txtTutionFees" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" ValidationGroup="INSERT" />
                    </td>
                </tr>
                  <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNSC" runat="server" Text="National Savings Certificate"  CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNSC" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ControlToValidate="txtNSC" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" ValidationGroup="INSERT" />
                    </td>
                </tr>
                  <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblLicPremium" runat="server" Text="L.I.C. Premium"  CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLicPremium" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" ControlToValidate="txtLicPremium" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" ValidationGroup="INSERT" />
                    </td>
                </tr>
                  <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblJeevanSuraksha" runat="server" Text="Jeevan Suraksha"  CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtJeevanSuraksha" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server" ControlToValidate="txtJeevanSuraksha" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" ValidationGroup="INSERT" />
                    </td>
                </tr>
                  <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPostalInvestment" runat="server" Text="LI_Postal Investment"  CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPostalInvestment" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator18" runat="server" ControlToValidate="txtPostalInvestment" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" ValidationGroup="INSERT" />
                    </td>
                </tr>
                  <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblUnitInsurance" runat="server" Text="Unit Linked Insurance Plan"  CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUnitInsurance" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" ControlToValidate="txtUnitInsurance" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" ValidationGroup="INSERT" />
                    </td>
                </tr>
                  <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblInfrastructureBond" runat="server" Text="Infrastructure Bond"  CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtInfrastructureBond" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server" ControlToValidate="txtInfrastructureBond" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" ValidationGroup="INSERT" />
                    </td>
                </tr>
                  <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblInvestmentInfrastructure" runat="server" Text="Investment In Infrastructure"  CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtInvestmentInfrastructure" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server" ControlToValidate="txtInvestmentInfrastructure" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" ValidationGroup="INSERT" />
                    </td>
                </tr>
                  <tr>
                    <td colspan="2"></td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lblOthers" runat="server" Text="Others"  CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtOthers" runat="server"></asp:TextBox>
                    </td>
                     <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator23" runat="server" ControlToValidate="txtOthers" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" ValidationGroup="INSERT" />
                    </td>
                </tr>
                 <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSec80DDB" runat="server" Text="Section 80DDB :" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSec80DDB" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator25" runat="server" ControlToValidate="txtSec80DDB" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" ValidationGroup="INSERT" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSec80GG" runat="server" Text="Section 80GG : " CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSec80GG" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator26" runat="server" ControlToValidate="txtSec80GG" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" ValidationGroup="INSERT" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSec80GGC" runat="server" Text="Section 80GGC :" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSec80GGC" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator27" runat="server" ControlToValidate="txtSec80GGC" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" ValidationGroup="INSERT" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSec80TTA" runat="server" Text="Section 80TTA :" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSec80TTA" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator28" runat="server" ControlToValidate="txtSec80TTA" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" ValidationGroup="INSERT" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSec80U" runat="server" Text="Section 80U :" CssClass="lblStyle"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSec80U" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator29" runat="server" ControlToValidate="txtSec80U" ErrorMessage="Enter a valid Number" ValidationExpression="[+-]?([0-9]*[.])?[0-9]+" ValidationGroup="INSERT" />
                    </td>
                </tr>
            </table>
        </div>
   </div>

    <div>
        <div style="width: 50%; float:left">
            <asp:PlaceHolder runat="server" ID="placeholder"></asp:PlaceHolder>
        </div>
        <div style="width:50%; float:right">
            <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
        </div>
    </div>

    <div align="center">
        <asp:Button ID="btnSave" runat="server" Text="SAVE"  ValidationGroup="INSERT" OnClick="btnSave_Click" CssClass="btnCss" />
        <asp:Button ID="btnCancel" runat="server" Text="CANCEL" CausesValidation="false" OnClick="btnCancel_Click" CssClass="btnCss" />
    </div>



</asp:Content>
