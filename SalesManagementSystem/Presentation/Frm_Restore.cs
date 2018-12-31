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
    public partial class Frm_Restore : Form
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductDBConnection"].ConnectionString);
        SqlCommand command;
        public Frm_Restore()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRestoreBackup_Click(object sender, EventArgs e)
        {
            try
            {
                txtFileName.Text = openFileDialog1.FileName;
                string query = "Alter Database ProductDB Set OFFLINE With ROLLBACK IMMEDIATE; Restore Database ProductDB From Disk='" + txtFileName.Text + "'";
                command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("A database backup file has been restored successfully! ","Restore Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {
                MessageBox.Show("Restore Backup operation failed...please try again! ", "Restore Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = openFileDialog1.FileName;
            }
        }
    }
}
