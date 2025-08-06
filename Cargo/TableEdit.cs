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
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;


namespace Cargo
{
    public partial class TableEdit : Form
    {
        BaglantiCumlem bc = new BaglantiCumlem();

        public TableEdit()
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
                        KargoAdi = c.CargoName.Cargo_Name,
                        Lokasyon = c.Cargo_Location.Cargo_Location_Name,
                        Durum = c.Cargo_Status.Cargo_Status_Name,
                        KargoyaVerilmeTarihi = c.Cargo_Date,
                        TahminiTeslimTarihi = c.Cargo_Delivery_Date
                    })
                    .ToList();

                dataGridView1.DataSource = list;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}");
            }
        }
        private void ComboLoadData()
        {
            combo_location.DataSource = bc.Cargo_Locations.ToList();
            combo_location.DisplayMember = "Cargo_Location_Name";
            combo_location.ValueMember = "Cargo_Location_ID";

            combo_status.DataSource = bc.Cargo_Statuses.ToList();
            combo_status.DisplayMember = "Cargo_Status_Name";
            combo_status.ValueMember = "Cargo_Status_ID";

            combo_user.DataSource = bc.Cargo_User
                         .OrderBy(u => u.Cargo_User_Name)
                         .Select(u => new
                         {
                             u.Cargo_User_Name_ID,
                             u.Cargo_User_Name
                         })
                         .ToList();
            combo_user.DisplayMember = "Cargo_User_Name";
            combo_user.ValueMember = "Cargo_User_Name_ID";

            combo_name.DataSource = bc.Cargo_Name
                .OrderBy(n => n.Cargo_Name)
                .Select(n => new
                {
                    n.Cargo_Name_ID,
                    n.Cargo_Name,
                })
                .ToList();
            combo_name.DisplayMember = "Cargo_Name";
            combo_name.ValueMember = "Cargo_Name_ID";

            combo_user.SelectedIndex = -1;
            combo_name.SelectedIndex = -1;
            combo_status.SelectedIndex = -1;
            combo_location.SelectedIndex = -1;


        }


        private void button2_Click(object sender, EventArgs e)
        {


            customer newCargo = new customer()
            {
                Cargo_User_Name_ID = (int)combo_user.SelectedValue,
                Cargo_Name_ID = (int)combo_name.SelectedValue,
                Cargo_Date = dateTimePicker1.Value,
               Cargo_Location_ID = (int)combo_location.SelectedValue,
                Cargo_Status_ID = (byte)combo_status.SelectedValue
            };

            bc.customer.Add(newCargo);
            bc.SaveChanges();
            MessageBox.Show("Kargo kaydı eklendi.");
            btnlistele.PerformClick();

        }

        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string musteriAdi = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["MusteriAdi"].Value);
                string kargoAdi = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["KargoAdi"].Value);

                combo_user.SelectedValue = bc.Cargo_User.FirstOrDefault(u => u.Cargo_User_Name == musteriAdi)?.Cargo_User_Name_ID;
                combo_name.SelectedValue = bc.Cargo_Name.FirstOrDefault(n => n.Cargo_Name == kargoAdi)?.Cargo_Name_ID;

                string lokasyonn = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Lokasyon"].Value);
                string status = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Durum"].Value);


                combo_location.SelectedValue = bc.Cargo_Locations.FirstOrDefault(u => u.Cargo_Location_Name == lokasyonn)?.Cargo_Location_ID;
                combo_status.SelectedValue = bc.Cargo_Statuses.FirstOrDefault(u => u.Cargo_Status_Name == status)?.Cargo_Status_ID;
                dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["KargoyaVerilmeTarihi"].Value);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
                try
                {
                    if (dataGridView1.CurrentRow != null)
                    {
                        int cargo_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Cargo_ID"].Value);

                        var cargo = bc.customer.Find(cargo_id);

                        if (cargo != null)
                        {
                            cargo.Cargo_User_Name_ID = Convert.ToInt32(combo_user.SelectedValue);
                            cargo.Cargo_Name_ID = Convert.ToInt32(combo_name.SelectedValue);
                            cargo.Cargo_Date = dateTimePicker1.Value;
                            cargo.Cargo_Status_ID = Convert.ToByte(combo_status.SelectedValue);
                            cargo.Cargo_Location_ID = Convert.ToInt32(combo_location.SelectedValue);

                            bc.SaveChanges();

                            MessageBox.Show("Güncelleme işlemi başarıyla yapıldı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnlistele.PerformClick();
                        }
                        else
                        {
                            MessageBox.Show("Seçilen kargo bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen güncellemek için bir satır seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            

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
                    int selectedId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Cargo_ID"].Value);
                    customer customer = bc.customer.Find(selectedId);

                    if (customer != null)
                    {
                        bc.customer.Remove(customer);
                        bc.SaveChanges();

                        MessageBox.Show("Silme işlemi Başarılı");

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

        private void TableEdit_Load(object sender, EventArgs e)
        {
            ComboLoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminnLogin admin = new AdminnLogin();
            this.Hide();
            admin.ShowDialog();
            this.Close();
        }
    }

}
