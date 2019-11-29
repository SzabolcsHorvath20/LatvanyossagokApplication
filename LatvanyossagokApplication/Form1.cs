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
                                lakossag INT NOT NULL);";
            cmd.ExecuteNonQuery();
            cmd.CommandText = @"CREATE TABLE IF NOT EXISTS latvanyossagok (
                                id INT PRIMARY KEY AUTO_INCREMENT,
                                nev VARCHAR(128) NOT NULL,
                                leiras VARCHAR(256) NOT NULL,
                                ar INT DEFAULT 0 NOT NULL,
                                varos_id INT NOT NULL,
                                FOREIGN KEY (varos_ID)
                                    REFERENCES varosok(id));";
            cmd.ExecuteNonQuery();
            VarosListazas();

        }

        void VarosListazas()
        {
            latvanyossag_varos.Items.Clear();
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
    }
}
