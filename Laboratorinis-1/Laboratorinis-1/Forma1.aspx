<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forma1.aspx.cs" Inherits="Laboratorinis_1.Forma1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Įkelkite duomenų failą"></asp:Label>
            <br />
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" ValidateRequestMode="Disabled" />
            <br />
            <br />
            <asp:Button ID="UploadButton" runat="server" Text="Įkelti" OnClick="UploadButton_Click" />
            <br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            <asp:Label ID="FileUploadErrorLabel" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Pradiniai duomenys"></asp:Label>
            <br />
            <asp:TextBox class="result-textbox" ID="DataTextBox" runat="server" BorderStyle="Solid" ReadOnly="false" TextMode="MultiLine"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="CalculationButton" runat="server" OnClick="CalculationButton_Click" Text="Tikrinti" />
            <br />
        </div>
        <br />
        <br />
        <div>
            <asp:Label ID="ResultLabel" runat="server" Text="Rezultatai"></asp:Label>
            <br />
            <asp:TextBox class="result-textbox" ID="ResultTextBox" runat="server" BorderStyle="Solid" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
        </div>
    </form>
</body>
</html>
