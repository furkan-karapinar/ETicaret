using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ETicaret
{
    public partial class Urun_Yonetimi : Form
    {
        Baglanti baglanti = new Baglanti(); // Bağlantı sınıfından baglanti adında bir nesne oluşturulur.
        public Urun_Yonetimi()
        {
            InitializeComponent();
            DataTable urunler = baglanti.urunler_listesi(); // Bağlantı sınıfındaki urunler_listesi fonksiyonu çağrılarak ürünler listesi alınır.
            dataGridView1.DataSource = urunler; // Alınan ürünler listesi DataGridView'e yüklenir.
            comboBox1.DataSource = urunler; // Alınan ürünler listesi ComboBox'a yüklenir.
            comboBox1.DisplayMember = "Ürün Adı"; // ComboBox'ta görünecek olan değer belirlenir.
            comboBox1.ValueMember = "ID"; // ComboBox'ta seçilen değer belirlenir.
            comboBox1.Text = ""; // ComboBox'ta seçili olan değer boşaltılır.

            txt_kategory.DataSource = baglanti.kategoriler_listesi(); // Bağlantı sınıfındaki kategoriler_listesi fonksiyonu çağrılarak kategoriler listesi alınır.
            txt_kategory.DisplayMember = "kategori_adi"; // ComboBox'ta görünecek olan değer belirlenir.
            txt_kategory.ValueMember = "id"; // ComboBox'ta seçilen değer belirlenir.
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Ürün güncelleme işlemi yapılır. Eğer ürün adedi 0 değilse ve boş değilse ürün güncellenir.
            if (!string.IsNullOrEmpty(txt_adet.Text) && txt_adet.Text != "0")
            {
                
                baglanti.urun_guncelle(Convert.ToInt32(comboBox1.SelectedValue), comboBox1.Text , txt_aciklama.Text , Convert.ToInt32(txt_fiyat.Text) , Convert.ToInt32(txt_adet.Text));

                baglanti = new Baglanti();
                DataTable urunler = baglanti.urunler_listesi();
                dataGridView1.DataSource = urunler;
                comboBox1.DataSource = urunler;
                comboBox1.DisplayMember = "Ürün Adı";
                comboBox1.ValueMember = "ID";
                comboBox1.Text = "";
            }


        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // DataGridView'de seçilen satır değiştiğinde ürün bilgileri TextBox'lara yüklenir.
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txt_adet.Text = dataGridView1.SelectedRows[0].Cells["Adet"].Value.ToString();
                label11.Text = "Seçilen Ürün: " + dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString() + " - " +  dataGridView1.SelectedRows[0].Cells["Ürün Adı"].Value.ToString(); ;
                txt_aciklama.Text = dataGridView1.SelectedRows[0].Cells["Açıklama"].Value.ToString();
                txt_fiyat.Text = dataGridView1.SelectedRows[0].Cells["Fiyat"].Value.ToString();
                txt_kategory.Text = dataGridView1.SelectedRows[0].Cells["Kategori"].Value.ToString();


            }
        }

        private void btn_urun_ekle_Click(object sender, EventArgs e)
        {
            // Ürün ekleme işlemi yapılır. Eğer ürün adı, kategori, fiyat, adet ve açıklama boş değilse ürün eklenir.
            if (!String.IsNullOrEmpty(comboBox1.Text) || !String.IsNullOrEmpty(txt_kategory.Text) || !String.IsNullOrEmpty(txt_fiyat.Text) || !String.IsNullOrEmpty(txt_adet.Text) || !String.IsNullOrEmpty(txt_aciklama.Text))
            {
               if  (baglanti.urun_ekle(comboBox1.Text, Convert.ToInt32(txt_kategory.SelectedValue), Convert.ToInt32(txt_fiyat.Text), Convert.ToInt32(txt_adet.Text), txt_aciklama.Text))
                {
                    MessageBox.Show("Ürün Eklendi");
                    txt_aciklama.Clear();
                    txt_adet.ResetText();
                    txt_fiyat.ResetText();
                    txt_kategory.SelectedIndex = 0;
                    baglanti = new Baglanti();
                    DataTable urunler = baglanti.urunler_listesi();
                    dataGridView1.DataSource = urunler;
                    comboBox1.DataSource = urunler;
                    comboBox1.DisplayMember = "Ürün Adı";
                    comboBox1.ValueMember = "ID";
                    comboBox1.Text = "";
                }
            }
        }

        private void btn_urun_sil_Click(object sender, EventArgs e)
        {
            // Ürün silme işlemi yapılır. Eğer bir ürün seçilmişse ürün silinir.
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
                baglanti.urun_sil(id);
                DataTable urunler = baglanti.urunler_listesi();
                dataGridView1.DataSource = urunler;
                comboBox1.DataSource = urunler;
                comboBox1.DisplayMember = "Ürün Adı";
                comboBox1.ValueMember = "ID";
                comboBox1.Text = "";
                MessageBox.Show("Ürün Silindi");
            }
            else
            {
                MessageBox.Show("Lütfen bir ürün seçiniz");
            }
        }
    }
}
