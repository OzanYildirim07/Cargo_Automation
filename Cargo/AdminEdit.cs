using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cargo
{
    public partial class AdminEdit : Form
    {
        BaglantiCumlem bc = new BaglantiCumlem();

        public AdminEdit()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtusername.Text = row.Cells["Cargo_User_Name"].Value.ToString();
                txttel.Text = row.Cells["Cargo_User_Tel"].Value.ToString();
                txtmail.Text = row.Cells["Cargo_User_Mail"].Value.ToString();
                txtadres.Text = row.Cells["Cargo_User_Adress"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                dataGridView1.DataSource = bc.Cargo_User.ToList();
                dataGridView1.Columns["customer"].Visible = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Listeleme sırasında hata oluştu: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int selectedId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Cargo_User_Name_ID"].Value);

                    
                        var user = bc.Cargo_User.Find(selectedId);
                        if (user != null)
                        {
                            user.Cargo_User_Name = txtusername.Text;
                            user.Cargo_User_Tel = txttel.Text;
                            user.Cargo_User_Mail = txtmail.Text;
                            user.Cargo_User_Adress = txtadres.Text;

                            bc.SaveChanges();
                            MessageBox.Show("Kullanıcı bilgileri güncellendi!");
                            button1.PerformClick(); 
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı bulunamadı!");
                        }
                    
                }
                else
                {
                    MessageBox.Show("Lütfen güncellenecek satırı seçin!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme sırasında hata oluştu: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                
                    CargoUser newUser = new CargoUser
                    {
                        Cargo_User_Name = txtusername.Text,
                        Cargo_User_Tel = txttel.Text,
                        Cargo_User_Mail = txtmail.Text,
                        Cargo_User_Adress = txtadres.Text
                    };

                    bc.Cargo_User.Add(newUser);
                    bc.SaveChanges();
                    MessageBox.Show("Yeni kullanıcı eklendi!");
                    button1.PerformClick(); 
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ekleme sırasında hata oluştu: " + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show(
                "Silmek istediğinize emin misiniz?",
                "Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (sonuc == DialogResult.Yes)
            {
                try
                {
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        int selectedId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Cargo_User_Name_ID"].Value);


                        var user = bc.Cargo_User.Find(selectedId);
                        if (user != null)
                        {
                            bc.Cargo_User.Remove(user);
                            bc.SaveChanges();
                            MessageBox.Show("Kullanıcı silindi!");
                            button1.PerformClick();
                        }
                        else
                        {
                            MessageBox.Show("Silinecek kullanıcı bulunamadı!");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Lütfen silinecek satırı seçin!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Silme sırasında hata oluştu: " + ex.Message);
                }
            }

        }

       
    }
}
