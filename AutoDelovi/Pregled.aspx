<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pregled.aspx.cs" Inherits="AutoDelovi.Pregled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Katalog
        </div>
        <div>
            <asp:RadioButtonList ID="rb_izbor" runat="server" OnSelectedIndexChanged="rb_izbor_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Value="1">Kataloški broj</asp:ListItem>
                <asp:ListItem Value="2">Kategorija</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div>
            <asp:TextBox ID="txt_katbr" runat="server" Enabled="False" Width="200px">1111</asp:TextBox>
            <br />
            <asp:DropDownList ID="ddl_kateg" runat="server" Enabled="False">
            </asp:DropDownList>
        </div>
        <div>

            <asp:Button ID="b_search" runat="server" Text="Tragaj" OnClick="b_search_Click" />

        </div>
        <div>
            <asp:GridView ID="gv_tabela" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
    </form>
</body>
</html>
