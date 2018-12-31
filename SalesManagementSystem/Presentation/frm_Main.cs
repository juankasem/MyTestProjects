using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagementSystem.Presentation
{
    public partial class frm_Main : Form
    {
        private static frm_Main frm;

        static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static frm_Main GetMainForm
        {
            get
            {
                if(frm==null)
                {
                    frm = new frm_Main();
                    frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                }
                return frm;
            }
        }
        public frm_Main()
        {
            InitializeComponent();
            if (frm == null)
                frm = this;
            this.productsToolStripMenuItem.Enabled = false;
            this.customersToolStripMenuItem.Enabled = false;
            this.usersToolStripMenuItem.Enabled = false;
            this.createBackupToolStripMenuItem.Enabled = false;
            this.restoreASavedCopyToolStripMenuItem.Enabled = false;
        }

        private void signInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin loginForm = new frmLogin();

            loginForm.ShowDialog();

        }

        private void addNewProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Add_Product frm = new Frm_Add_Product();
            frm.ShowDialog();
        }

        private void productsManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Products frm = new Frm_Products();
            frm.ShowDialog();
        }

        private void categoriesManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Categories frm = new Frm_Categories();
            frm.ShowDialog();
        }

        private void customersManagemntToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Customers frm = new Frm_Customers();
            frm.ShowDialog();
        }

        private void addNewSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Orders frm = new Frm_Orders();
            frm.ShowDialog();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Add_User frm = new Frm_Add_User();
            frm.ShowDialog();
        }

        private void usersManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Users_List frm = new Frm_Users_List();
            frm.ShowDialog();
        }

        private void createBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Backup frm = new Frm_Backup();
            frm.ShowDialog();
        }

        private void restoreASavedCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Restore frm = new Frm_Restore();
            frm.ShowDialog();
        }
    }
}
