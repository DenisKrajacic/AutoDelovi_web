using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Globalization;

namespace AutoDelovi
{
    public partial class Admin : System.Web.UI.Page
    {
        static public DataTable delovi;
        static public int broj_sloga = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_Data();
                DropDownFill();
            }
        }

        private void Load_Data()
        {
            SqlConnection veza = Konekcija.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Artikal", veza);
            delovi = new DataTable();
            adapter.Fill(delovi);
        }

        private void DropDownFill()
        {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            SqlConnection veza = Konekcija.Connect();
            SqlDataAdapter adapter;
            DataTable dt_jedmer, dt_katego, dt_proizv;

            adapter = new SqlDataAdapter("SELECT id, naziv as naziv FROM JedinicaMere", veza);
            dt_jedmer = new DataTable();
            adapter.Fill(dt_jedmer);

            adapter = new SqlDataAdapter("SELECT id, naziv as naziv FROM Kategorija", veza);
            dt_katego = new DataTable();
            adapter.Fill(dt_katego);

            adapter = new SqlDataAdapter("SELECT id, naziv as naziv FROM Proizvodjac", veza);
            dt_proizv = new DataTable();
            adapter.Fill(dt_proizv);

            ddl_jedmer.DataSource = dt_jedmer;
            ddl_jedmer.DataValueField = "id";
            ddl_jedmer.DataTextField = "naziv";
            ddl_jedmer.DataBind();

            ddl_kateg.DataSource = dt_katego;
            ddl_kateg.DataValueField = "id";
            ddl_kateg.DataTextField = "naziv";
            ddl_kateg.DataBind();

            ddl_proizv.DataSource = dt_proizv;
            ddl_proizv.DataValueField = "id";
            ddl_proizv.DataTextField = "naziv";
            ddl_proizv.DataBind();

            txt_id.Text = delovi.Rows[broj_sloga]["id"].ToString();
            txt_katbr.Text = delovi.Rows[broj_sloga]["KataloskiBroj"].ToString();
            txt_oebr.Text = delovi.Rows[broj_sloga]["OEBroj"].ToString();
            txt_naziv.Text = delovi.Rows[broj_sloga]["Naziv"].ToString();
            txt_kol.Text = delovi.Rows[broj_sloga]["Kolicina"].ToString();
            txt_bruto.Text = delovi.Rows[broj_sloga]["BrutoCena"].ToString();
            txt_rabat.Text = delovi.Rows[broj_sloga]["Rabat"].ToString();
            txt_pdv.Text = delovi.Rows[broj_sloga]["PDV"].ToString();
            txt_neto.Text = delovi.Rows[broj_sloga]["Neto"].ToString();
            txt_cena.Text = delovi.Rows[broj_sloga]["Cena"].ToString();

            if (delovi.Rows.Count == 0)
            {
                ddl_jedmer.ClearSelection();
                ddl_kateg.ClearSelection();
                ddl_proizv.ClearSelection();
            }
            else
            {
                ddl_jedmer.SelectedValue = delovi.Rows[broj_sloga]["JedinicaMere_id"].ToString();
                ddl_kateg.SelectedValue = delovi.Rows[broj_sloga]["Kategorija_id"].ToString();
                ddl_proizv.SelectedValue = delovi.Rows[broj_sloga]["Proizvodjac_id"].ToString();
            }

            if (broj_sloga == 0)
            {
                btn_first.Enabled = false;
                btn_prev.Enabled = false;
            }
            else
            {
                btn_first.Enabled = true;
                btn_prev.Enabled = true;
            }

            if (broj_sloga == delovi.Rows.Count - 1)
            {
                btn_last.Enabled = false;
                btn_next.Enabled = false;
            }
            else
            {
                btn_last.Enabled = true;
                btn_next.Enabled = true;
            }
        }

        protected void btn_first_Click(object sender, EventArgs e)
        {
            broj_sloga = 0;
            DropDownFill();
        }

        protected void btn_prev_Click(object sender, EventArgs e)
        {
            broj_sloga--;
            DropDownFill();
        }

        protected void btn_next_Click(object sender, EventArgs e)
        {
            broj_sloga++;
            DropDownFill();
        }

        protected void btn_last_Click(object sender, EventArgs e)
        {
            broj_sloga = delovi.Rows.Count - 1;
            DropDownFill();
        }

        protected void btn_insert_Click(object sender, EventArgs e)
        {
            StringBuilder naredba = new StringBuilder("EXECUTE Dodaj_Artikal '");
            naredba.Append(txt_katbr.Text + "', '");
            naredba.Append(txt_oebr.Text + "', '");
            naredba.Append(txt_naziv.Text + "', '");
            naredba.Append(ddl_jedmer.SelectedValue + "', '");
            naredba.Append(Convert.ToInt32(txt_kol.Text) + "', '");
            naredba.Append(ddl_kateg.SelectedValue + "', '");
            naredba.Append(ddl_proizv.SelectedValue + "', '");
            naredba.Append(txt_bruto.Text + "', '");
            naredba.Append(txt_rabat.Text + "', '");
            naredba.Append(txt_pdv.Text + "'");

            SqlConnection veza = Konekcija.Connect();
            SqlCommand komanda = new SqlCommand(naredba.ToString(), veza);

            try
            {
                veza.Open();
                komanda.ExecuteNonQuery();
                veza.Close();
            }
            catch (Exception greska)
            {
                Console.WriteLine(greska.Message);
            }

            Load_Data();
            broj_sloga = delovi.Rows.Count - 1;
            DropDownFill();
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            StringBuilder naredba = new StringBuilder("EXECUTE  Izmeni_Artikal '");
            naredba.Append(txt_id.Text + "', '");
            naredba.Append(txt_katbr.Text + "', '");
            naredba.Append(txt_oebr.Text + "', '");
            naredba.Append(txt_naziv.Text + "', '");
            naredba.Append(ddl_jedmer.SelectedValue + "', '");
            naredba.Append(Convert.ToInt32(txt_kol.Text) + "', '");
            naredba.Append(ddl_kateg.SelectedValue + "', '");
            naredba.Append(ddl_proizv.SelectedValue + "', '");
            naredba.Append(txt_bruto.Text + "', '");
            naredba.Append(txt_rabat.Text + "', '");
            naredba.Append(txt_pdv.Text + "'");

            SqlConnection veza = Konekcija.Connect();
            SqlCommand komanda = new SqlCommand(naredba.ToString(), veza);

            try
            {
                veza.Open();
                komanda.ExecuteNonQuery();
                veza.Close();
            }
            catch (Exception greska)
            {
                Console.WriteLine(greska.Message);
            }

            Load_Data();
            DropDownFill();
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            string naredba = "EXECUTE Obrisi_Artikal " + txt_id.Text;

            SqlConnection veza = Konekcija.Connect();
            SqlCommand komanda = new SqlCommand(naredba, veza);

            bool brisano = false;

            try
            {
                veza.Open();
                komanda.ExecuteNonQuery();
                veza.Close();

                brisano = true;
            }
            catch (Exception greska)
            {
                Console.WriteLine(greska.Message);
            }

            if (brisano)
            {
                Load_Data();
                if (broj_sloga > 0) broj_sloga--;
                DropDownFill();
            }
        }

        protected void b_pregled_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pregled.aspx");
        }
    }
}