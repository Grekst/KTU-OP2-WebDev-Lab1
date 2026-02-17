<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forma1.aspx.cs" Inherits="Laboratorinis_1.Forma1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
    <title>Skorpiono Grafo Analizė</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="FileUpload1" runat="server" ValidateRequestMode="Disabled" onchange="triggerAutoUpload(this)" Style="display: none;" />

            <label for="<%=FileUpload1.ClientID%>" class="custom-file-upload">
                Įkelti iš disko
            </label>
            <br />
            <asp:Button ID="UploadButton" runat="server" Text="-" OnClick="UploadButton_Click" BorderStyle="None" Style="display: none;" />
            <script>
                function triggerAutoUpload(input) {
                    if (input.files && input.files[0]) {
                        document.getElementById('<%= UploadButton.ClientID %>').click();
                    }
                }
            </script>


            <br />

            <asp:Button ID="UploadInternalButton" runat="server" Text="Įkelti pavyzdį iš App_Data" BorderStyle="None" CssClass="upload-internal-button" OnClick="UploadInternalButton_Click" />

            <br />
        </div>

        <div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            <asp:Label ID="FileUploadErrorLabel" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
            <br />
        </div>

        <div>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Įrašykite pradinius duomenis"></asp:Label>
            <br />
            <asp:TextBox class="result-textbox" ID="DataTextBox" runat="server" BorderStyle="Solid"
                ReadOnly="false" TextMode="MultiLine"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="UpdateStartingData" runat="server" CssClass="upload-internal-button" Text="Rašyti pradinius duomenis į App_Data" BorderStyle="None" OnClick="UpdateStartingData_Click" />
            <br />
            <br />
            <asp:Button ID="CalculationButton" runat="server" OnClick="CalculationButton_Click"
                Text="Tikrinti" CssClass="calculate-button" BorderStyle="None" />
        </div>

        <br />
        <br />
        <br />

        <div>
            <asp:Label ID="ResultLabel" runat="server" Text="Rezultatai"></asp:Label>
            <br />
            <asp:TextBox class="result-textbox" ID="ResultTextBox" runat="server" BorderStyle="Solid"
                ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="WriteToAppData_Button" runat="server" Text="Rašyti rezultatus į App_Data" CssClass="upload-internal-button" OnClick="WriteToAppData_Button_Click" BorderStyle="None" />

            <br />
            <br />

            <br />
            <asp:Label ID="FileWriteErrorLabel" runat="server" ForeColor="Red" Text="*"></asp:Label>

        </div>
    </form>
</body>
</html>
