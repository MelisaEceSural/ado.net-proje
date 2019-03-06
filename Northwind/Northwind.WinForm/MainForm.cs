using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Northwind.WinForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnUrunForm_Click(object sender, EventArgs e)
        {
            UrunForm urnForm = new UrunForm();
            urnForm.ShowDialog();
        }
    }
}
