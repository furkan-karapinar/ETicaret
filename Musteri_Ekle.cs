using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ETicaret
{
    public partial class Musteri_Ekle : Form
    {
        Baglanti baglanti = new Baglanti(); // Bağlantı sınıfından nesne oluşturulur ve bağlantı sağlanır.

        public Musteri_Ekle(string eposta) // Müşteri Ekleme Formunun Constructor'ı. E-Posta bilgisi alınır. Bu nesne oluşturulurken E-Posta bilgisi alınır.
        {
            InitializeComponent();
            txt_eposta.Text = eposta; // E-Posta bilgisi TextBox'a yazdırılır.
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Müşteri Ekleme Formundaki Kaydet butonuna tıklandığında çalışacak kodlar. Textbox'lardaki bilgiler alınır ve veritabanına kaydedilir.
            if (String.IsNullOrEmpty(txt_ad.Text) || String.IsNullOrEmpty(txt_eposta.Text) || String.IsNullOrEmpty(txt_tel.Text)  || String.IsNullOrEmpty(txt_adres.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz veya doğru girdiğinizden emin olunuz.");
                return;
            }
            else
            {
               if (baglanti.musteri_kaydi_olustur(txt_ad.Text, txt_tel.Text, txt_eposta.Text, txt_adres.Text, txt_tel.Text))
                {
                    MessageBox.Show("Müşteri başarıyla oluşturuldu.");
                    this.Close();
                }
               else
                {
                    MessageBox.Show("Müşteri oluşturulurken bir hata oluştu.");
                }
            }
        }
    }
}
