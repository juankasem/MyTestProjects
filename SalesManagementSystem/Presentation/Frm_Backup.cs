using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;


namespace SalesManagementSystem.Presentation
{
    public partial class Frm_Backup : Form
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductDBConnection"].ConnectionString);
        SqlCommand command;
        public Frm_Backup()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreateBackup_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = txtFileName.Text + "//ProductDB" + DateTime.Now.ToShortDateString().Replace("/", "-")
                                                + " - " + DateTime.Now.ToLongTimeString().Replace(":", "-");
                string query = " Backup Database ProductDB to Disk='" + filename + ".bak'";
                command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("A database backup file has been created successfully! ", "Create Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Create Backup operation failed...please try again! ", "Create Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

    }
}