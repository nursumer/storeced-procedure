using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace storeced_procedure
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        string baglanticumlesi = "Data Source=216-02\\SQLEXPRESS;Initial Catalog=Northwind;User ID=sa; Password=Fbu123456";
        private void Form1_Load(object sender, EventArgs e)
        {



            try
            {
                  string komut = "";
               
                    komut = "select*from Customers";
                


                using (SqlConnection baglanti = new SqlConnection())
                {
                    baglanti.ConnectionString = baglanticumlesi;
                    using (SqlCommand listelemekomut = new SqlCommand(komut, baglanti))
                    {
                        baglanti.Open();
                        using (DataTable datatablosu = new DataTable())
                        {
                            datatablosu.Columns.Add("Müşteri Adı");
                            datatablosu.Columns.Add("Firma Adı");
                            datatablosu.Columns.Add("Yetkili Kişi");
                            datatablosu.Columns.Add("Ülkesi");
                            using (SqlDataReader okuyucu = listelemekomut.ExecuteReader())
                            {
                                while (okuyucu.Read())
                                {
                                    DataRow row = datatablosu.NewRow();
                                    row["Müşteri Adı"] = okuyucu["CustomerID"];
                                    row["Firma Adı"] = okuyucu["CompanyName"];
                                    row["Yetkili Kişi"] = okuyucu["ContactName"];
                                    row["Ülkesi"] = okuyucu["Country"];
                                    datatablosu.Rows.Add(row);
                                }
                                dataGridView1.DataSource = datatablosu;
                            }
                        }
                        baglanti.Close();

                    }

                }

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen müşteri bilgilerinizi giriniz.");
                textBox1.Select();
                return;
            }

            using (SqlConnection cn = new SqlConnection(baglanticumlesi))
            {
                using (SqlCommand cmd = new SqlCommand("benimprosedurum", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@customerID1", textBox1.Text);
                    cmd.Parameters.AddWithValue("@CompanyName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@ContactName", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Country", textBox4.Text);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            Form1_Load(this, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen müşteri bilgilerinizi giriniz.");
                textBox1.Select();
                return;
            }

            using (SqlConnection cn = new SqlConnection(baglanticumlesi))
            {
                using (SqlCommand cmd = new SqlCommand("benimprosedurum", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Insert");
                    cmd.Parameters.AddWithValue("@customerID1", textBox1.Text);
                    cmd.Parameters.AddWithValue("@CompanyName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@ContactName", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Country", textBox4.Text);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            Form1_Load(this, null);
        }
    }
}
