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
    public partial class Anasayfa : Form
    {
        Baglanti baglanti = new Baglanti(); // Veritabanı bağlantısı
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti = new Baglanti(); // Yeni Veritabanı bağlantısı
            List<string> musteri =  baglanti.musteriye_baglan(txt_eposta.Text); // Müşteri sepetine bağlan ve müşteri bilgileri getir

            if (musteri[0] != "") // Müşteri varsa
            {
                label6.Tag = musteri[0]; // Müşteri ID'sini label6'nın Tag özelliğine ata
                label6.Text = "Müşteri: " +  musteri[1]; // Müşteri adını label6'ya yaz
                label7.Text = "Telefon: " + musteri[2]; // Müşteri telefonunu label7'ye yaz
                label8.Text = "E-posta: " + musteri[3]; // Müşteri e-postasını label8'e yaz
                label9.Text = "Adres: " + musteri[4]; // Müşteri adresini label9'a yaz

                dataGridView1.DataSource = baglanti.musteri_sepeti(Convert.ToInt32(musteri[0])); // Müşteri sepetini getir
                groupBox1.Enabled = true; // Sepete ürün ekleme ve satış yapma kısmını aktif et
                DataTable data = baglanti.urunler_listesi(); // Ürünler listesini getir

                dataGridView2.DataSource = data; // Ürünler listesini dataGridView2'ye ata
                comboBox1.DataSource = data; // Ürünler listesini comboBox1'e ata
                comboBox1.DisplayMember = "Ürün Adı"; // comboBox1'de görünecek değeri belirle
                comboBox1.ValueMember = "ID"; // comboBox1'de seçilen değeri belirle
            }
            else
            {
                if (MessageBox.Show("Kullanıcı Bulunamadı! Yeni Kayıt Oluşturulsun mu?", "Kullanıcı Bulunamadı", MessageBoxButtons.YesNo) == DialogResult.Yes) 
                    // Kullanıcı bulunamadıysa yeni kayıt oluşturulsun mu sorusu
                {
                    Musteri_Ekle musteri_Ekle = new Musteri_Ekle(txt_eposta.Text); // Yeni müşteri ekleme formunu aç
                    musteri_Ekle.ShowDialog(); // Formu aç ve işlem bitene kadar anasayfa formunu beklet
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows) // Sepetteki ürünleri boşalt ve veritabanından sil. Arayüzü temizle
            {
                
                if (!row.IsNewRow)
                {
 
                    var cellValue = row.Cells["ID"].Value;
                    if (cellValue != null)
                    {
                        baglanti.sepetten_cikar(Convert.ToInt32(cellValue));
                    }
                }
            }


            dataGridView1.DataSource = null;
            dataGridView2.DataSource= null;
            comboBox1.DataSource = null;

            label6.Tag = "";
            label6.Text = "Müşteri: -";
            label7.Text = "Telefon: -";
            label8.Text = "E-posta: -";
            label9.Text = "Adres: -";

            groupBox1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e) // Satışı tamamlama. Sepetteki ürünleri tek tek çıkarır ve ayrı bir listeye ekler. Bu listeyi satis_tamamla fonksiyonuna gönderir. O da satışı tamamlar.
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                if (!row.IsNewRow)
                {

                    var cellValue = row.Cells["ID"].Value;
                    if (cellValue != null)
                    {
                       List<string> list = baglanti.sepetten_cikar(Convert.ToInt32(cellValue));
                       baglanti.satis_tamamla(list);
                    }
                }
            }


            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            comboBox1.DataSource = null;

            label6.Tag = "";
            label6.Text = "Müşteri: -";
            label7.Text = "Telefon: -";
            label8.Text = "E-posta: -";
            label9.Text = "Adres: -";
            groupBox1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e) // Sepete ürün ekleme. Ürün ID'si ve adeti alır ve sepete ekler.
        {
            
            if (numericUpDown1.Text != "0")
            {
                baglanti.sepete_ekle(Convert.ToInt32(label6.Tag),Convert.ToInt32(comboBox1.SelectedValue),Convert.ToInt32(numericUpDown1.Text));
                dataGridView1.DataSource = baglanti.musteri_sepeti(Convert.ToInt32(label6.Tag));
            }
            else
            {
                MessageBox.Show("Geçersiz Adet Değeri");
            }
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e) // Sepet (Datagridview1) güncellendiğinde sepetteki ürünlerin fiyatlarını toplar ve label10'a yazar.
        {
            decimal toplam = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                if (row.Cells["Fiyat"].Value != null && !row.IsNewRow)
                {
                    // Satırlardaki fiyatları toplar
                    if (decimal.TryParse(row.Cells["Fiyat"].Value.ToString(), out decimal fiyat))
                    {
                        toplam += fiyat;
                    }
                }
            }

            label10.Text = "Toplam: " + toplam.ToString();
        }

        private void button5_Click(object sender, EventArgs e) // Sepetten ürün çıkarma. Seçili ürünü sepetten çıkarır.
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int id = Convert.ToInt32(selectedRow.Cells["ID"].Value.ToString());
                baglanti.sepetten_cikar(id);
                dataGridView1.DataSource = baglanti.musteri_sepeti(Convert.ToInt32(label6.Tag));
            }
            else
            {
                MessageBox.Show("Sepetten bir ürün seçin.");
            }
        }

        private void button6_Click(object sender, EventArgs e) // Ürün yönetimi formunu açar.
        {
            Urun_Yonetimi urun_yonetimi = new Urun_Yonetimi();
            urun_yonetimi.ShowDialog();
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e) // Ürün listesinde seçili ürünün adetini alır ve numericUpDown1'in maximum değerine atar.
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
                int adet = Convert.ToInt32(selectedRow.Cells["Adet"].Value.ToString());
                numericUpDown1.Maximum = adet;
            }
        }

    }
}
