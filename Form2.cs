using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kütüphane
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        //listview'deki verilerin listbox'ta görülmesini sağlar
        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Form1.liste; i++)
            {
                listBox1.Items.Add(Form1.elemanlar[i]);
            }
        }

        //listbox içindeki verileri alfabettik sıralar
        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Sorted = true;
        }

        //listbox içinde arama kutucuğuna giren kelimeyi arar
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.Items[i].ToString().ToLower().Contains(textBox1.Text.ToLower()))
                {
                    listBox1.SetSelected(i, true);
                }
            }
        }

        //seçili öğeyi siler
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        //tüm öğeleri siler ve listbox'ı boşaltır
        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        //yeni kayıt için kitap ekleme formuna geri döner ve ekranda da ilk formu gösterir
        private void button5_Click(object sender, EventArgs e)
        {
            Form1 yeni = new Form1();
            yeni.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        //class'la oluşturulan ve okuyucuya tavsiye vermek amaçlı gösterilen kısım
        private void button7_Click(object sender, EventArgs e)
        {
            oneri oto = new oneri();

            oto.sıra = "#1";
            oto.kitap = "Şeker Portakalı";
            oto.yazar = "Jose Mauro De Vasconcelos";
            oto.yayınevi = "Can Yayınları";
            oto.sayfa = "182";

            string sıra = oto.sıragetir();

            label7.Text = oto.sıra.ToString();
            label8.Text = oto.kitap.ToString();
            label9.Text = oto.yazar.ToString();
            label10.Text = oto.yayınevi.ToString();
            label11.Text = oto.sayfa.ToString();

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        //class'la oluşturulan ve okuyucuya tavsiye vermek amaçlı gösterilen kısım
        private void button8_Click(object sender, EventArgs e)
        {
            oneri oto = new oneri();

            oto.sıra = "#1";
            oto.kitap = "Hayvan Çiftliği";
            oto.yazar = "George Orwell";
            oto.yayınevi = "Can Yayınları";
            oto.sayfa = "112";

            string sıra = oto.sıragetir();

            label16.Text = oto.sıra.ToString();
            label15.Text = oto.kitap.ToString();
            label14.Text = oto.yazar.ToString();
            label13.Text = oto.yayınevi.ToString();
            label12.Text = oto.sayfa.ToString();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
