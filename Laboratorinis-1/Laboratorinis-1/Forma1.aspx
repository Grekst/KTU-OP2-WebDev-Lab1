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
            <asp:FileUpload ID="FileUpload1" runat="server" ValidateRequestMode="Disabled"
                onchange="triggerAutoUpload(this)" Style="display: none;" />

            <label for="<%=FileUpload1.ClientID%>" class="custom-file-upload">
                Įkelti iš kompiuterio
            </label>
            <br />
            <span id="fileNameDisplay">Nėra failo</span>
            <br />

            <script>
                function triggerAutoUpload(input) {
                    if (input.files && input.files[0]) {
                        document.getElementById('fileNameDisplay').innerHTML = "Kraunama: " + input.files[0].name;

                        document.getElementById('<%= UploadButton.ClientID %>').click();
                    }
                }
            </script>

            <br />
            <asp:Button ID="UploadButton" runat="server" Text="Įkelti" OnClick="UploadButton_Click"
                CssClass="copy-button" BorderStyle="None" Style="display: none;" />

            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            <asp:Label ID="FileUploadErrorLabel" runat="server" ForeColor="Red" Text="*" Visible="False"></asp:Label>
            <br />
        </div>

        <div>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Pradiniai duomenys"></asp:Label>
            <br />
            <asp:TextBox class="result-textbox" ID="DataTextBox" runat="server" BorderStyle="Solid"
                ReadOnly="false" TextMode="MultiLine"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="CalculationButton" runat="server" OnClick="CalculationButton_Click"
                Text="Tikrinti" CssClass="calculate-button" BorderStyle="None" />
            <br />
        </div>

        <br />
        <br />
        <div>
            <asp:Label ID="ResultLabel" runat="server" Text="Rezultatai"></asp:Label>
            <br />
            <asp:TextBox class="result-textbox" ID="ResultTextBox" runat="server" BorderStyle="Solid"
                ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
        </div>
    </form>
</body>
</html>
