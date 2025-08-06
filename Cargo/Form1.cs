using System;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Cargo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AcceptButton = btnuser;
        }

        public string CargoNo
        {
            get { return txtcargono.Text.Trim(); }
            set { txtcargono.Text = value; }
        }

        public string CargoName
        {
            get { return Regex.Replace(txtname.Text.Trim(), @"\s+", " "); }
            set { txtname.Text = value; }
        }

        private void btnuser_Click(object sender, EventArgs e)
        {
            using (var bg = new BaglantiCumlem())
            {
                int cargoID;
                if (!int.TryParse(CargoNo, out cargoID))
                {
                    MessageBox.Show("Kargo Numarası geçerli değil.");
                    return;
                }

                var user = bg.Cargo_User
                    .FirstOrDefault(u => u.Cargo_User_Name == CargoName);

                if (user == null)
                {
                    MessageBox.Show("Kullanıcı bulunamadı.");
                    return;
                }

                var kargo = bg.customer
                    .FirstOrDefault(c => c.Cargo_ID == cargoID &&
                                       c.Cargo_User_Name_ID == user.Cargo_User_Name_ID);

                if (kargo != null)
                {
                    KargoTakip form2 = new KargoTakip(CargoNo, CargoName);
                    this.Hide();
                    form2.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Girdiğiniz Bilgilere Ait Kargo Bulunamadı.\nLütfen Girdiğiniz Bilgileri Kontrol Ediniz.",
                                  "Hata!",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }
        }

        private void txtcargono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void btnadmin_Click(object sender, EventArgs e)
        {
            PersonalLogin adminLogin = new PersonalLogin();
            this.Hide();
            adminLogin.ShowDialog();
            this.Close();
        }
    }
}
