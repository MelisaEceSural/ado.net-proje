using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Northwind.ORM.Entity;
using Northwind.ORM.Facade;

namespace Northwind.WinForm
{
    public partial class UrunForm : Form
    {
        public UrunForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void Listele()
        {
            dataGridView1.DataSource = Urunler.Listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUrunAd.Text))
                return;

            Urun urn = new Urun();
            urn.UrunAdi = txtUrunAd.Text;
            urn.BirimFİyati = numFiyat.Value;
            urn.HedefStokDuzeyi = (short)numStok.Value;

            if (Urunler.Ekle(urn))
                MessageBox.Show("Ürün Eklendi.");
            else
                MessageBox.Show("Ürün Eklenemedi.");

            Listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            Urun silinecekUrun = new Urun();
            silinecekUrun.UrunID = (int)dataGridView1.CurrentRow.Cells["UrunID"].Value;
            if (Urunler.Sil(silinecekUrun))
                MessageBox.Show("Ürün Silindi.");
            else
                MessageBox.Show("Ürün Silinemedi.");

            Listele();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            DataGridViewRow satir = dataGridView1.CurrentRow;
            txtUrunAd.Text = satir.Cells["UrunAdi"].Value.ToString();
            numFiyat.Value = (decimal)satir.Cells["BirimFiyati"].Value;
            numStok.Value = (short)satir.Cells["HedefStokDuzeyi"].Value;
            txtUrunAd.Tag = satir.Cells["UrunID"].Value;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUrunAd.Text) || txtUrunAd.Tag==null)
                return;

            Urun urn = new Urun();
            urn.UrunID = (int)txtUrunAd.Tag;
            urn.UrunAdi = txtUrunAd.Text;
            urn.BirimFİyati = numFiyat.Value;
            urn.HedefStokDuzeyi = (short)numStok.Value;

            if (Urunler.Guncelle(urn))
                MessageBox.Show("Ürün Güncellendi.");
            else
                MessageBox.Show("Ürün Güncelenemedi.");

            Listele();
        }
    }
}
