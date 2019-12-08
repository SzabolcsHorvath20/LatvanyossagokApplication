using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LatvanyossagokApplication
{
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        public Form1()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=latvanyossagokdb;Uid=root;Pwd=;");
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"CREATE TABLE IF NOT EXISTS varosok (
                                id INT PRIMARY KEY AUTO_INCREMENT,
                                nev VARCHAR(128) UNIQUE NOT NULL,
                                lakossag INT NOT NULL)
                                ENGINE=InnoDB;";
            cmd.ExecuteNonQuery();
            cmd.CommandText = @"CREATE TABLE IF NOT EXISTS latvanyossagok (
                                id INT PRIMARY KEY AUTO_INCREMENT,
                                nev VARCHAR(128) NOT NULL,
                                leiras VARCHAR(256) NOT NULL,
                                ar INT DEFAULT 0 NOT NULL,
                                varos_id INT NOT NULL,
                                FOREIGN KEY (varos_ID)
                                    REFERENCES varosok(id))
                                ENGINE=InnoDB;";
            cmd.ExecuteNonQuery();
            VarosListazas();

        }

        void VarosListazas()
        {
            latvanyossag_varos.Items.Clear();
            lbVarosok.Items.Clear();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id, nev, lakossag from varosok";
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var id = reader.GetInt32("id");
                    var nev = reader.GetString("nev");
                    var lakossag = reader.GetInt32("lakossag");
                    latvanyossag_varos.Items.Add(new Varos(id, nev, lakossag));
                    lbVarosok.Items.Add(new Varos(id, nev, lakossag));
                }
            }
        }

        void LatvanyossagListazas()
        {
            if (lbVarosok.SelectedIndex != -1)
            {
                lbLatvanyossagok.Items.Clear();
                var cmd = conn.CreateCommand();
                var varos = (Varos)lbVarosok.SelectedItem;
                cmd.CommandText = "SELECT id, nev, leiras, ar, varos_id from latvanyossagok WHERE varos_id = @id";
                cmd.Parameters.AddWithValue("@id", varos.Id);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt32("id");
                        var nev = reader.GetString("nev");
                        var leiras = reader.GetString("leiras");
                        var ar = reader.GetInt32("ar");
                        var varos_id = reader.GetInt32("varos_id");
                        lbLatvanyossagok.Items.Add(new Latvanyossag(id, nev, leiras, ar, varos_id));
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void varos_beszuras_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(varos_nev.Text))
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"INSERT INTO varosok (nev, lakossag) VALUES (@nev, @lakossag)";
                    cmd.Parameters.AddWithValue("@nev", varos_nev.Text);
                    cmd.Parameters.AddWithValue("@lakossag", varos_lakossag.Value);
                    cmd.ExecuteNonQuery();
                    latvanyossag_varos.Items.Clear();
                    lbVarosok.Items.Clear();
                    VarosListazas();
                }
                else
                {
                    MessageBox.Show("Minden mezőt ki kell tölteni!");

                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageBox.Show("Ez a város már szerepel az adatbázisban!");
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
            }

        private void btn_varos_delete_Click(object sender, EventArgs e)
        {
            if (lbLatvanyossagok.Items.Count > 0)
            {
                MessageBox.Show("Nem törölhet olyan várost, aminek van látávnyossága.");
            }
            else
            {
                if (lbVarosok.SelectedIndex == -1)
                {
                    MessageBox.Show("Nincs város kivalasztva!");
                    return;
                }
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM varosok WHERE id = @id";
                var varos = (Varos)lbVarosok.SelectedItem;
                cmd.Parameters.AddWithValue("@id", varos.Id);
                cmd.ExecuteNonQuery();
                latvanyossag_varos.Items.Clear();
                lbVarosok.Items.Clear();
                VarosListazas();
            }
        }

        private void lbVarosok_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbLatvanyossagok.Items.Clear();
                var varos = (Varos)lbVarosok.SelectedItem;
                tbModositVarosNev.Text = varos.Nev;
                nudModositVarosLakossag.Value = varos.Lakossag;
                LatvanyossagListazas();
            }
            catch (Exception)
            {

            }

        }

        private void latvanyossag_hozzaad_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(latvanyossag_nev.Text) && !String.IsNullOrWhiteSpace(latvanyossag_leiras.Text) && latvanyossag_varos.SelectedIndex != -1)
                {
                    var cmd = conn.CreateCommand();
                    var varos = (Varos)latvanyossag_varos.SelectedItem;
                    cmd.CommandText = @"INSERT INTO latvanyossagok (nev, leiras, ar, varos_id) VALUES (@nev, @leiras, @ar, @varos_id)";
                    cmd.Parameters.AddWithValue("@nev", latvanyossag_nev.Text);
                    cmd.Parameters.AddWithValue("@leiras", latvanyossag_leiras.Text);
                    cmd.Parameters.AddWithValue("@ar", latvanyossag_ar.Value);
                    cmd.Parameters.AddWithValue("@varos_id", varos.Id);
                    cmd.ExecuteNonQuery();
                    lbLatvanyossagok.Items.Clear();
                    LatvanyossagListazas();
                    VarosListazas();
                }
                else
                {
                    MessageBox.Show("Minden mezőt ki kell tölteni!");

                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageBox.Show("Ez a város már szerepel az adatbázisban!");
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnModosit_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbModositVarosNev.Text) && lbVarosok.SelectedIndex != -1)
            {
                var varos = (Varos)lbVarosok.SelectedItem;
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE varosok SET nev = @nev, lakossag = @lakossag WHERE id = @id;";
                cmd.Parameters.AddWithValue("@nev", tbModositVarosNev.Text);
                cmd.Parameters.AddWithValue("@lakossag", nudModositVarosLakossag.Value);
                cmd.Parameters.AddWithValue("@id", varos.Id);
                cmd.ExecuteNonQuery();
                VarosListazas();
            }
        }

        private void lbLatvanyossagok_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var Latvanyossag = (Latvanyossag)lbLatvanyossagok.SelectedItem;
                tbLatvanyossagNevModosit.Text = Latvanyossag.Nev;
                tbLatvanyossagLeirasModosit.Text = Latvanyossag.Leiras;
                nudLatvanyossagArModosit.Value = Latvanyossag.Ar;
            }
            catch (Exception)
            {

            }
        }

        private void btnLatvanyossagModosit_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbLatvanyossagLeirasModosit.Text) && !String.IsNullOrWhiteSpace(tbLatvanyossagNevModosit.Text))
            {
                var latvanyossag = (Latvanyossag)lbLatvanyossagok.SelectedItem;
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE latvanyossagok SET nev = @nev, ar = @ar, leiras = @leiras WHERE id = @id;";
                cmd.Parameters.AddWithValue("@nev", tbLatvanyossagNevModosit.Text);
                cmd.Parameters.AddWithValue("@leiras", tbLatvanyossagLeirasModosit.Text);
                cmd.Parameters.AddWithValue("@ar", nudLatvanyossagArModosit.Value);
                cmd.Parameters.AddWithValue("@id", latvanyossag.Id);
                cmd.ExecuteNonQuery();
                lbLatvanyossagok.Items.Clear();
                LatvanyossagListazas();
            }
        }

        private void btnLatvanyossagDelete_Click(object sender, EventArgs e)
        {
            if (lbLatvanyossagok.SelectedIndex == -1)
            {
                MessageBox.Show("Nincs látványosság kivalasztva!");
                return;
            }
            var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM latvanyossagok WHERE id = @id";
            var latvanyossag = (Latvanyossag)lbLatvanyossagok.SelectedItem;
            cmd.Parameters.AddWithValue("@id", latvanyossag.Id);
            cmd.ExecuteNonQuery();
            lbLatvanyossagok.Items.Clear();
            LatvanyossagListazas();
        }
    }
}
