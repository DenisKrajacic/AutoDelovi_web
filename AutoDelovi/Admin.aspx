<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="AutoDelovi.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Uređivanje baze podataka
        </div>
        <div>
            <asp:Label ID="lbl_id" runat="server" Text="ID"></asp:Label>
            <asp:TextBox ID="txt_id" runat="server" Enabled="False" Width="300px"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_katbr" runat="server" Text="Kataloški broj"></asp:Label>
            <asp:TextBox ID="txt_katbr" runat="server" Width="300px"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_oebr" runat="server" Text="OE Broj"></asp:Label>
            <asp:TextBox ID="txt_oebr" runat="server" Width="300px"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_naziv" runat="server" Text="Naziv"></asp:Label>
            <asp:TextBox ID="txt_naziv" runat="server" Width="300px"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_jedmer" runat="server" Text="Jedinica mere"></asp:Label>
            <asp:DropDownList ID="ddl_jedmer" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Label ID="lbl_kol" runat="server" Text="Količina"></asp:Label>
            <asp:TextBox ID="txt_kol" runat="server" Width="300px"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_kateg" runat="server" Text="Kategorija"></asp:Label>
            <asp:DropDownList ID="ddl_kateg" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Label ID="lbl_proiz" runat="server" Text="Proizvođač"></asp:Label>
            <asp:DropDownList ID="ddl_proizv" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Label ID="lbl_brut" runat="server" Text="Bruto cena"></asp:Label>
            <asp:TextBox ID="txt_bruto" runat="server" Width="300px"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_raba" runat="server" Text="Rabat (%)"></asp:Label>
            <asp:TextBox ID="txt_rabat" runat="server" Width="300px"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_pdv" runat="server" Text="PDV (%)"></asp:Label>
            <asp:TextBox ID="txt_pdv" runat="server" Width="300px"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_neto" runat="server" Text="Neto cena"></asp:Label>
            <asp:TextBox ID="txt_neto" runat="server" Enabled="False" Width="300px"></asp:TextBox>
            <br />
            <asp:Label ID="lbl_cena" runat="server" Text="Cena"></asp:Label>
            <asp:TextBox ID="txt_cena" runat="server" Enabled="False" Width="300px"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btn_first" runat="server" OnClick="btn_first_Click" Text="&lt;&lt;" />
            <asp:Button ID="btn_prev" runat="server" OnClick="btn_prev_Click" Text="&lt;" />
            <asp:Button ID="btn_next" runat="server" OnClick="btn_next_Click" Text="&gt;" />
            <asp:Button ID="btn_last" runat="server" OnClick="btn_last_Click" Text="&gt;&gt;" />
            <br />
            <asp:Button ID="btn_insert" runat="server" OnClick="btn_insert_Click" Text="Dodaj" />
            <asp:Button ID="btn_update" runat="server" OnClick="btn_update_Click" Text="Izmeni" />
            <asp:Button ID="btn_delete" runat="server" OnClick="btn_delete_Click" Text="Briši" />
        </div>
        <div>
            <asp:Button ID="b_pregled" runat="server" OnClick="b_pregled_Click" Text="Pregled" />
        </div>
    </form>
</body>
</html>
