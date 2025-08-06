using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Cargo
{
    public partial class PersonalLogin : Form
    {
        BaglantiCumlem bc = new BaglantiCumlem();

        public PersonalLogin()
        {
            InitializeComponent();
        }

        private void btnadminlogin_Click(object sender, EventArgs e)
        {
            using (var context = new BaglantiCumlem())
            {
                string PersonUsername = txtauser.Text.Trim();
                string PersonPass = txtapass.Text.Trim();

                var admin = context.Personal_Information
                    .FirstOrDefault(a => a.Personal_Username == PersonUsername && a.Personal_Password == PersonPass);

                if (admin != null)
                {
                    PersonalPanel PersonPanel = new PersonalPanel();
                    this.Hide();
                    PersonPanel.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı Veya Parola Hatalı.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
