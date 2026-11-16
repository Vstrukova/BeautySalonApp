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
    public partial class Form1 : Form
    {
        SqlDB db = new SqlDB();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            db.showTable(dataGridViewManager);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            db.saveTable(dataGridViewManager);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            db.searchInTable(dataGridViewManager, textBoxSearch.Text);
        }

        private void buttonFired_Click(object sender, EventArgs e)
        {
            db.searchByStatus(dataGridViewManager, "Уволен");
        }

        private void buttonWorking_Click(object sender, EventArgs e)
        {
            db.searchByStatus(dataGridViewManager, "Работает");
        }

        private void dataGridViewManager_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            db.rows.Add(e.RowIndex);
        }

        private void dataGridViewManager_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
