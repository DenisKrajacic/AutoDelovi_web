using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace AutoDelovi
{
    public partial class Pregled : System.Web.UI.Page
    {
        static public DataTable tabela;
        static public SqlDataAdapter adapter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                adapter = new SqlDataAdapter("Select Artikal.id, Artikal.KataloskiBroj, Artikal.OEBroj, Artikal.Naziv, JedinicaMere.naziv AS 'Jedinica mere', Artikal.Kolicina, Proizvodjac.naziv AS 'Proizvodjac', Artikal.Cena FROM Artikal INNER JOIN JedinicaMere ON Artikal.JedinicaMere_id = JedinicaMere.id  INNER JOIN Proizvodjac ON Artikal.Proizvodjac_id = Proizvodjac.id ", Konekcija.Connect());
                tabela = new DataTable();
                adapter.Fill(tabela);
                gv_tabela.DataSource = tabela;
                gv_tabela.DataBind();

                ddl_kateg.Enabled = false;
                txt_katbr.Enabled = false;
                b_search.Enabled = false;

                DataTable dt_katego;
                adapter = new SqlDataAdapter("SELECT id, naziv as naziv FROM Kategorija", Konekcija.Connect());
                dt_katego = new DataTable();
                adapter.Fill(dt_katego);

                ddl_kateg.DataSource = dt_katego;
                ddl_kateg.DataValueField = "id";
                ddl_kateg.DataTextField = "naziv";
                ddl_kateg.DataBind();
            }
        }

        protected void rb_izbor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rb_izbor.SelectedValue == "1")
            {
                txt_katbr.Enabled = true;
                b_search.Enabled = true;
                ddl_kateg.Enabled = false;
            }
            else if (rb_izbor.SelectedValue == "2")
            {
                ddl_kateg.Enabled = true;
                b_search.Enabled = true;
                txt_katbr.Enabled = false;
            }
        }

        protected void b_search_Click(object sender, EventArgs e)
        {
            if (rb_izbor.SelectedValue == "1")
            {
                adapter = new SqlDataAdapter("Select Artikal.id, Artikal.KataloskiBroj, Artikal.OEBroj, Artikal.Naziv, JedinicaMere.naziv AS 'Jedinica mere', Artikal.Kolicina, Proizvodjac.naziv AS 'Proizvodjac', Artikal.Cena FROM Artikal INNER JOIN JedinicaMere ON Artikal.JedinicaMere_id = JedinicaMere.id  INNER JOIN Proizvodjac ON Artikal.Proizvodjac_id = Proizvodjac.id WHERE Artikal.KataloskiBroj = '" + txt_katbr.Text + "'", Konekcija.Connect());
                tabela = new DataTable();
                adapter.Fill(tabela);
                gv_tabela.DataSource = tabela;
                gv_tabela.DataBind();
            }
            else if (rb_izbor.SelectedValue == "2")
            {
                adapter = new SqlDataAdapter("Select Artikal.id, Artikal.KataloskiBroj, Artikal.OEBroj, Artikal.Naziv, JedinicaMere.naziv AS 'Jedinica mere', Artikal.Kolicina, Proizvodjac.naziv AS 'Proizvodjac', Artikal.Cena FROM Artikal INNER JOIN JedinicaMere ON Artikal.JedinicaMere_id = JedinicaMere.id  INNER JOIN Proizvodjac ON Artikal.Proizvodjac_id = Proizvodjac.id  WHERE Artikal.Kategorija_id = '" + ddl_kateg.SelectedValue + "'", Konekcija.Connect());
                tabela = new DataTable();
                adapter.Fill(tabela);
                gv_tabela.DataSource = tabela;
                gv_tabela.DataBind();
            }
        }
    }
}