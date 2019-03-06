using Northwind.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.ORM.Facade
{
    public class Urunler
    {
       

        public static DataTable Listele()
        {            
            return Tools.Listele("UrunleriListele");
        }

        public static bool Ekle(Urun entity)
        {
            SqlCommand komut = new SqlCommand("UrunEkle", Tools.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@adi", entity.UrunAdi);
            komut.Parameters.AddWithValue("@fiyat", entity.BirimFİyati);
            komut.Parameters.AddWithValue("@stok", entity.HedefStokDuzeyi);

            return Tools.ExecuteNonQuery(komut);
        }

        public static bool Sil(Urun entity)
        {
            SqlCommand komut = new SqlCommand("UrunSil", Tools.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@id", entity.UrunID);
          
            return Tools.ExecuteNonQuery(komut);
        }

        public static bool Guncelle(Urun entity)
        {
            SqlCommand komut = new SqlCommand("UrunGuncelle", Tools.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@id", entity.UrunID);
            komut.Parameters.AddWithValue("@adi", entity.UrunAdi);
            komut.Parameters.AddWithValue("@fiyat", entity.BirimFİyati);
            komut.Parameters.AddWithValue("@stok", entity.HedefStokDuzeyi);

            return Tools.ExecuteNonQuery(komut);
        }
    }
}
