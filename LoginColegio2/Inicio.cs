using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginColegio2
{
    public partial class Inicio : Form
    {
        private Panel leftBordenBtn;
        private Form currenChildForm;
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        private void OpenChildForm(Form ChildForm)
        {
            if (currenChildForm != null)
            {
                currenChildForm.Close();
            }
            currenChildForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            PnlContenedor.Controls.Add(ChildForm);
            PnlContenedor.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
            btnGuardar.Text = ChildForm.Text;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
