using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Cargo
{
    public partial class KargoTakip : Form
    {
        BaglantiCumlem context = new BaglantiCumlem();

        public KargoTakip(string cargoNo, string cargoName)
        {
            InitializeComponent();

            listView1.View = View.Details;
            listView1.Columns.Clear();
            listView1.Columns.Add("Kargo Takip Numarası", 350);
            listView1.Columns.Add("Kargo Sahibi", 380);
            listView1.Columns.Add("Kargo Adı", 350);
            listView1.Columns.Add("Kargo Lokasyonu", 450);
            listView1.Columns.Add("Kargo Durumu", 350);
            listView1.Columns.Add("Teslimat Adresi", 350);
            listView1.Columns.Add("Kargoya Verilme Tarihi", 350);
            listView1.Columns.Add("Kargo Tahmini Teslim Tarihi", 450);

            listView1.Items.Clear();

            try
            {
                var userId = context.Cargo_User
                    .Where(u => u.Cargo_User_Name == cargoName)
                    .Select(u => u.Cargo_User_Name_ID)
                    .FirstOrDefault();

                if (userId == 0)
                {
                    MessageBox.Show("Kullanıcı bulunamadı.");
                    return;
                }

                var kargoListesi = context.customer
                    .Where(c => c.Cargo_ID.ToString() == cargoNo && c.Cargo_User_Name_ID == userId)
                    .Select(c => new
                    {
                        c.Cargo_ID,
                        KullaniciAdi = context.Cargo_User
                            .Where(u => u.Cargo_User_Name_ID == c.Cargo_User_Name_ID)
                            .Select(u => u.Cargo_User_Name)
                            .FirstOrDefault(),
                        CargoName = context.Cargo_Name
                            .Where(l => l.Cargo_Name_ID == c.Cargo_Name_ID)
                            .Select(l => l.Cargo_Name)
                            .FirstOrDefault(),
                        LokasyonAdi = context.Cargo_Locations
                            .Where(l => l.Cargo_Location_ID == c.Cargo_Location_ID)
                            .Select(l => l.Cargo_Location_Name)
                            .FirstOrDefault(),
                        DurumAdi = context.Cargo_Statuses
                            .Where(s => s.Cargo_Status_ID == c.Cargo_Status_ID)
                            .Select(s => s.Cargo_Status_Name)
                            .FirstOrDefault(),
                        Adres = context.Cargo_User
                            .Where(s => s.Cargo_User_Name_ID == c.Cargo_User_Name_ID)
                            .Select(s => s.Cargo_User_Adress)
                            .FirstOrDefault(),
                        c.Cargo_Date,
                        c.Cargo_Delivery_Date
                    }).ToList();

                foreach (var cargo in kargoListesi)
                {
                    var item = new ListViewItem(cargo.Cargo_ID.ToString());
                    item.SubItems.Add(cargo.KullaniciAdi ?? "Bilinmiyor");
                    item.SubItems.Add(cargo.CargoName);
                    item.SubItems.Add(cargo.LokasyonAdi ?? "Bilinmiyor");
                    item.SubItems.Add(cargo.DurumAdi ?? "Bilinmiyor");
                    item.SubItems.Add(cargo.Adres ?? "Bilinmiyor");
                    item.SubItems.Add(cargo.Cargo_Date.ToString("dd.MM.yyyy"));
                    item.SubItems.Add(cargo.Cargo_Delivery_Date.ToString("dd.MM.yyyy"));

                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}");
            }
        }

        private void KargoTakip_Load(object sender, EventArgs e)
        {

        }
    }
}
