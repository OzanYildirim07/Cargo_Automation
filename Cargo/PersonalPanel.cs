using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Data.Entity;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace Cargo
{
    public partial class PersonalPanel : Form
    {
        BaglantiCumlem bc = new BaglantiCumlem();

        public PersonalPanel()
        {
            InitializeComponent();
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            try
            {
                
                    var list = bc.customer
                        .Include(c => c.CargoUser)
                        .Include(c => c.CargoName)
                        .Include(c => c.Cargo_Location)
                        .Include(c => c.Cargo_Status)
                        .Select(c => new
                        {
                            c.Cargo_ID,
                            MusteriAdi = c.CargoUser.Cargo_User_Name,
                            MusteriTelefon = c.CargoUser.Cargo_User_Tel,
                            KargoAdi = c.CargoName.Cargo_Name,
                            Lokasyon = c.Cargo_Location.Cargo_Location_Name,
                            Durum = c.Cargo_Status.Cargo_Status_Name,
                            KargoyaVerilmeTarihi = c.Cargo_Date,
                            TahminiTeslimTarihi = c.Cargo_Delivery_Date
                        })
                        .ToList();

                    dataGridView1.DataSource = list;
                    dataGridView1.Columns["Cargo_ID"].Visible = false;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}");
            }
        }

        private void ComboLoadData()
        {
            try
            {
                
                    CrgUser.DataSource = bc.Cargo_User
                        .OrderBy(u => u.Cargo_User_Name)
                        .Select(u => new
                        {
                            u.Cargo_User_Name_ID,
                            FullInfo = u.Cargo_User_Name +" - "+ u.Cargo_User_Tel,
                        })
                        .ToList();
                    CrgUser.DisplayMember = "FullInfo";
                    CrgUser.ValueMember = "Cargo_User_Name_ID";

                    CrgName.DataSource = bc.Cargo_Name
                        .OrderBy(n => n.Cargo_Name)
                        .Select(n => new
                        {
                            n.Cargo_Name_ID,
                            n.Cargo_Name,
                        })
                        .ToList();
                    CrgName.DisplayMember = "Cargo_Name";
                    CrgName.ValueMember = "Cargo_Name_ID";

                   

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}");
            }


        }


        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                int selectedCargoNameId = (int)CrgName.SelectedValue;

                var selectedCargo = bc.Cargo_Name
                                    .Include(c => c.Cargo_Location_Table)
                                    .Include(c => c.Cargo_Status_Table)
                                    .FirstOrDefault(c => c.Cargo_Name_ID == selectedCargoNameId);

                if (selectedCargo == null)
                {
                    MessageBox.Show("Seçilen kargo adı bulunamadı!");
                    return;
                }

                customer newCargo = new customer()
                {
                    Cargo_User_Name_ID = (int)CrgUser.SelectedValue,
                    Cargo_Name_ID = selectedCargoNameId,
                    Cargo_Location_ID = selectedCargo.Cargo_Location_ID, // CargoName'den otomatik al
                    Cargo_Status_ID = selectedCargo.Cargo_Status_ID,     // CargoName'den otomatik al
                    Cargo_Date = dateTimePicker1.Value,
                };

                bc.customer.Add(newCargo);
                bc.SaveChanges();

                MessageBox.Show("Kargo kaydı başarıyla eklendi.");

                btnlistele.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kargo eklenirken hata oluştu: {ex.Message}\n\nDetay: {ex.InnerException?.Message}");
            }
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            ComboLoadData();
        }
        


        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show(
                "Silmek istediğinize emin misiniz?",
                "Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (sonuc == DialogResult.Yes)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    int selectedId = (int)dataGridView1.CurrentRow.Cells["Cargo_ID"].Value;
                    var cargoToDelete = bc.customer.Find(selectedId);

                    if (cargoToDelete != null)
                    {
                        bc.customer.Remove(cargoToDelete);
                        bc.SaveChanges();
                        MessageBox.Show("Kargo başarıyla silindi!");
                        btnlistele.PerformClick();
                    }
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            TableEdit tableEdit = new TableEdit();
            this.Hide();
            tableEdit.ShowDialog();
            this.Close();
        }

        private void rd_1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rd_1.Checked)
                {
                    
                        var sonuc = bc.customer
                            .GroupBy(c => c.CargoUser.Cargo_User_Name)
                            .Select(g => new
                            {
                                Musteri = g.Key,
                                KargoSayisi = g.Count()
                            })
                            .OrderByDescending(x => x.KargoSayisi)
                            .FirstOrDefault();


                    if (sonuc != null)
                    {
                        lbl_1.Text = $"{sonuc.Musteri} - {sonuc.KargoSayisi} kez kargo almıştır";
                    }
                    else
                    {
                        lbl_1.Text = "Sonuç Bulunamadı";

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}");
            }
        }

        private void rd_2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rd_2.Checked)
                {

                    var sonuc2 = bc.customer
                        .GroupBy(c => c.CargoName.Cargo_Name)
                        .Select(g => new
                        {
                            Urun = g.Key,
                            SatisSayisi = g.Count()
                        })
                        .OrderByDescending(x => x.SatisSayisi)
                        .FirstOrDefault();


                    if (sonuc2 != null)
                    {
                        lbl_2.Text = $"{sonuc2.Urun} - {sonuc2.SatisSayisi} kez kargoya verilmiş";
                    }
                    else
                    {
                        lbl_2.Text = "Sonuç Bulunamadı";

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}");
            }
        }
    }

}
