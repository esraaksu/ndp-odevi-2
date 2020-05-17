using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Kütüphane
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //SQL veri tabanını c# dosyasına bağladım
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-A7HMLRP\\SQLEXPRESS;Initial Catalog=Kütüphane;Integrated Security=True");

        //SQL'de oluşr-turduğum veri tablosundaki öğeleri aktarmak için ekle komutunu kullandım ve bağlantı oluşturdum
        private void verilerigörüntüle()
        {
            listView1.Items.Clear(); 
            baglan.Open();
            SqlCommand komut = new SqlCommand("select *from kitaplar", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["kitabınadı"].ToString());
                ekle.SubItems.Add(oku["yazar"].ToString());
                ekle.SubItems.Add(oku["yayınevi"].ToString());
                ekle.SubItems.Add(oku["sayfasayısı"].ToString());

                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }

        //SQL'deki verileri listview tablosunda göstermek için kullanılan kod
        private void button1_Click(object sender, EventArgs e)
        {
            verilerigörüntüle();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        //yeni kayıt girer
        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into kitaplar(id,kitap,yazar,yayınevi,sayfa) values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "')", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigörüntüle();
        }

        //sseçili sıradaki verileri sırar ve id ile çalışır
        int id = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Delete from kitaplar where id=(" + id + ")", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigörüntüle();

        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[4].Text;
        }

        //kutuları yeni kayıt için boşaltır
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        //listviewdaki verileri döngü kurarak form2'deki listbox'a aktarılmasını sağlar
        public static int liste;

        public static string[] elemanlar = new string[100];
        private void veriaktar()
        {
            liste = listView1.Items.Count;
            for (int i = 0; i < liste; i++)
            {
                elemanlar[i] = Convert.ToString(listView1.Items[i]);
            }
        }

        //verileri diğer forma aktarır ve ekrana da diğer formu getirir
        private void button5_Click(object sender, EventArgs e)
        {
            veriaktar();
            Form2 yeni = new Form2();
            yeni.Show();
            this.Hide();

        }
    }   
}
