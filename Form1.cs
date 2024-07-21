using MySql.Data.MySqlClient;
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

namespace ETicaret
{
    public partial class Form1 : Form
    {
        Baglanti baglanti = new Baglanti();

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (baglanti.giris_kontrol(txt_eposta.Text,txt_sifre.Text)) // Giriş Kontrolü. Eğer E-Posta ve Şifre bilgileri doğruysa Anasayfa Formu açılır.
            {
                Anasayfa anasayfa = new Anasayfa();
                this.Hide();
                anasayfa.ShowDialog();
                this.Show();
                // Giriş formu gizlenir ve Anasayfa formu açılır. Anasayfa formu kapatıldığında Giriş formu tekrar gösterilir.
            }
            else
            {
                MessageBox.Show("Hatalı E-Posta / Şifre Girişi ya da Yetkisiz Giriş");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); // Çıkış komutu. Program kapatılır.
        }

    }
}
