using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeautySalonApp
{
    public partial class FormLogin : Form
    {
        private SqlDB db = new SqlDB();
        public FormLogin()
        {
            InitializeComponent();
            textBoxPassword.PasswordChar = '*';
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string enteredLogin = textBoxLogin.Text;
            string enteredPassword = textBoxPassword.Text;

            if (db.CheckUser(enteredLogin, enteredPassword))
            {
                Form1 formMain = new Form1();
                formMain.StartPosition = FormStartPosition.Manual;
                formMain.Location = new Point(this.Location.X, this.Location.Y);
                formMain.Show();
                this.Hide();
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            FormRegister form = new FormRegister();
            form.ShowDialog();
        }
    }
}
