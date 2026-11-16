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
    public partial class FormRegister : Form
    {
        private SqlDB db = new SqlDB();

        public FormRegister()
        {
            InitializeComponent();
            comboBoxUserType.Items.AddRange(new string[] { "User", "Worker" });
            comboBoxUserType.SelectedIndex = 0;
            textBoxPassword.PasswordChar = '*';
            textBoxFirstName.MaxLength = 50;
            textBoxLastName.MaxLength = 50;
            textBoxLogin.MaxLength = 45;
            textBoxPassword.MaxLength = 100;
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {

        }

        private void textBoxFirstName_TextChanged(object sender, EventArgs e)
        {
            db.firstName = textBoxFirstName.Text;
        }

        private void textBoxLastName_TextChanged(object sender, EventArgs e)
        {
            db.lastName = textBoxLastName.Text;
        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            db.login = textBoxLogin.Text;
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            db.password = textBoxPassword.Text;
        }

        private void comboBoxUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            db.status = comboBoxUserType.SelectedItem.ToString();
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked)
            {
                textBoxPassword.PasswordChar = '\0'; 
            }
            else
            {
                textBoxPassword.PasswordChar = '*';  
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(db.firstName) ||
           string.IsNullOrWhiteSpace(db.lastName) ||
           string.IsNullOrWhiteSpace(db.login) ||
           string.IsNullOrWhiteSpace(db.password))
            {
                MessageBox.Show("Заполните все поля.");
                return;
            }
            if (db.CreateUser())
            {
                this.Close();
            }
        }
    }
}
