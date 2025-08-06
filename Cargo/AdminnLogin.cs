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
    public partial class AdminnLogin : Form
    {
        public AdminnLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new BaglantiCumlem())
            {
                string adminUsername = txtauser.Text.Trim();
                string adminPass = txtapass.Text.Trim();

                var admin = context.Admin_Information
                    .FirstOrDefault(a => a.Admin_Username == adminUsername && a.Admin_Password == adminPass);

                if (admin != null)
                {
                    AdminEdit adminEdit = new AdminEdit();
                    this.Hide();
                    adminEdit.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı Veya Parola Hatalı.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
