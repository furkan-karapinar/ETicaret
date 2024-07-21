using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ETicaret
{
    internal class Baglanti
    {
        public static string baglan // Bağlantı bilgileri
        {
            get { return "Server=localhost;Database=eticaret;Uid=root;Pwd='';"; }
        }

        public bool giris_kontrol(string eposta, string sifre) // Giriş kontrolü yapmak için bir fonksiyon
        {
            using (MySqlConnection baglanti = new MySqlConnection(baglan)) // Kısa bir süreliğine bir bağlantı oluşturur ve gerekli konrolleri yapar
            {
                string query = $"Select id from uyeler where eposta='{eposta}' and sifre='{sifre}' and yetki=1";
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand(query, baglanti);
                MySqlDataReader dr = komut.ExecuteReader();


                if (dr.Read()) // Eğer bir sonuç varsa true döner ve giriş izni verilir.
                {
                    return true;
                }
            }
            return false;
        }

        public List<string> musteriye_baglan(string eposta) // Müşteri bilgilerini getirir. Bilgileri bir liste olarak döndürür.
        {
            using (MySqlConnection baglanti = new MySqlConnection(baglan))
            {
                string query = $"Select id , tam_ad , tel_no , eposta , adres from uyeler where eposta='{eposta}'";
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand(query, baglanti);
                MySqlDataReader dr = komut.ExecuteReader();


                if (dr.Read())
                {
                    return new List<string>() { dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString() };
                }
            }

            return new List<string>() { "", "", "", "", "" };
        }

        public bool musteri_kaydi_olustur(string tam_ad, string tel_no, string eposta, string adres, string sifre) // Müşteri kaydı oluşturur. Başarılı olursa true döner.
        {
            using (MySqlConnection baglanti = new MySqlConnection(baglan))
            {
                string query = $"INSERT INTO uyeler (tam_ad , tel_no , eposta , adres , sifre) VALUES ('{tam_ad}','{tel_no}','{eposta}','{adres}','{sifre}'); SELECT LAST_INSERT_ID(); ";
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand(query, baglanti);
                MySqlDataReader dr = komut.ExecuteReader();
                int insertedId = 0;

                if (dr.Read())
                {
                    insertedId = Convert.ToInt32(dr[0]);
}
                baglanti.Close();
                baglanti.Open();

                string query2 = $"INSERT INTO sepet (uye_id) VALUES ('{insertedId}'); SELECT uye_id FROM sepet WHERE id = (LAST_INSERT_ID()); ";
                    MySqlCommand komut2 = new MySqlCommand(query2, baglanti);
                    MySqlDataReader dr2 = komut2.ExecuteReader();

                    if (dr2.Read())
                    {
                       if (dr2[0].ToString() == insertedId.ToString())
                        {
                            return true;

                        }
                       else { return false; }
                    }
                
            }

            return false;
        }

        public DataTable musteri_sepeti(int uye_id) // Müşterinin sepetini datatable olarak döndürür
        {
            using (MySqlConnection baglanti = new MySqlConnection(baglan))
            {
                DataTable dt = new DataTable();
                string query = $"Select so.id As 'ID', u.urun_adi As 'Ürün Adı', u.fiyat As 'Fiyat' , so.adet As 'Adet' from sepet_ogeleri so Left Join urunler u On so.urun_id = u.id  Where sepet_id=(Select id from sepet where uye_id='{uye_id}')";
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand(query, baglanti);


                using (MySqlDataReader dr = komut.ExecuteReader())
                {
                    // Load the data into the DataTable
                    dt.Load(dr);
                    return dt;
                }
            }
        }

        public void sepete_ekle(int uye_id, int urun_id, int adet) // Sepete ürün ekler
        {
            using (MySqlConnection baglanti = new MySqlConnection(baglan))
            {
                string query = $"INSERT INTO sepet_ogeleri (sepet_id, urun_id, adet) VALUES ((SELECT id FROM sepet WHERE uye_id = '{uye_id}'), '{urun_id}', '{adet}');";
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand(query, baglanti);
                komut.ExecuteNonQuery();
            }
        }

        public List<string> sepetten_cikar(int id) 
            // Sepetten ürün çıkarır ve çıkarılan ürünün bilgilerini döndürür.
            // List olarak döndürülmesinin sebebi alışveriş tamamlama işlemi sırasında ürün sepetten çıkarılır ve geri dönen bilgi ile satış işlemi yapılır.
        {
            using (MySqlConnection baglanti = new MySqlConnection(baglan))
            {
                List<string> list = new List<string>();
                string query1 = $"SELECT * FROM sepet_ogeleri WHERE id = {id}";
                string query = $"DELETE FROM sepet_ogeleri WHERE id = {id};";
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand(query1, baglanti);
                MySqlDataReader dr = komut.ExecuteReader();


                if (dr.Read())
                {
                    list = new List<string>() { dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString() };
                }
                baglanti.Close();
                baglanti.Open();
                komut = new MySqlCommand(query, baglanti);
                dr = komut.ExecuteReader();

                return list;
            }
        }

        public DataTable urunler_listesi() // Ürünlerin listesini datatable olarak döndürür
        {
            using (MySqlConnection baglanti = new MySqlConnection(baglan))
            {
                DataTable dt = new DataTable();
                string query = "Select u.id as 'ID' , u.urun_adi as 'Ürün Adı' , u.aciklama as 'Açıklama' , u.fiyat as 'Fiyat', u.adet as 'Adet', k.kategori_adi as 'Kategori' From urunler u Left Join kategoriler k On u.kategori = k.id";
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand(query, baglanti);


                using (MySqlDataReader dr = komut.ExecuteReader())
                {
                    // datatable'a verileri yükle
                    dt.Load(dr);
                    return dt;
                }
            }
        }

        public bool satis_tamamla(List<string> urun) // Satış işlemini yapan fonksiyon. Sepetten çıkarılan ürünlerin bilgilerini alır. Bilgileri sipariş geçmişine ekleyip ürün stoklarını günceller.
        {
            try
            {
                int sepet_id = Convert.ToInt32(urun[1]);
                int urun_id = Convert.ToInt32(urun[2]);
                int adet = Convert.ToInt32(urun[3]);

                using (MySqlConnection baglanti = new MySqlConnection(baglan))
                {
                    string query = $"INSERT INTO siparis_gecmisi (uye_id, urun_id, adet) VALUES ((SELECT uye_id FROM sepet WHERE id = '{sepet_id}'), '{urun_id}', '{adet}');";
                    baglanti.Open();
                    MySqlCommand komut = new MySqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();

                    baglanti.Close();
                    baglanti.Open();

                    string query2 = $"UPDATE urunler SET  adet = adet - '{adet}' WHERE id = '{urun_id}'";
                    MySqlCommand komut2 = new MySqlCommand(query2, baglanti);
                    komut2.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }




        }


        public void urun_guncelle(int urun_id, string urun_adi , string aciklama , int fiyat , int adet) // Ürün güncelleme işlemi yapar
        {
            using (MySqlConnection baglanti = new MySqlConnection(baglan))
            {
                string query = $"UPDATE urunler SET urun_adi='{urun_adi}' , aciklama='{aciklama}' , fiyat='{fiyat}' , adet = '{adet}' WHERE id = {urun_id}";
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand(query, baglanti);
                komut.ExecuteNonQuery();
            }
        }


        public bool urun_ekle(string urun_adi, int kategori, double fiyat, int adet, string aciklama) // Ürün ekleme işlemi yapar
        {
            using (MySqlConnection baglanti = new MySqlConnection(baglan))
            {
                string query = $"INSERT INTO urunler (urun_adi, kategori, fiyat, adet, aciklama) VALUES ('{urun_adi}', '{kategori}', '{fiyat}', '{adet}', '{aciklama}');";
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand(query, baglanti);
                komut.ExecuteNonQuery();
                return true;
            }
        }   

        public DataTable kategoriler_listesi() // Kategorilerin listesini datatable olarak döndürür
        {
            using (MySqlConnection baglanti = new MySqlConnection(baglan))
            {
                DataTable dt = new DataTable();
                string query = "Select * From kategoriler";
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand(query, baglanti);
                MySqlDataReader dr = komut.ExecuteReader();

                if (dr.Read())
                {
                    dt.Load(dr);
                    return dt;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool urun_sil(int id) // Ürün silme işlemi yapar
        {
            using (MySqlConnection baglanti = new MySqlConnection(baglan))
            {
                string query = $"DELETE FROM urunler WHERE id = {id}";
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand(query, baglanti);
                 komut.ExecuteNonQuery();
                return true;
            }
        }
    }
}
