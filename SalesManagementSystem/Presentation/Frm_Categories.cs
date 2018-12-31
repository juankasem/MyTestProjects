using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace SalesManagementSystem.Presentation
{
    public partial class Frm_Categories : Form
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ProductDBConnection"].ConnectionString);
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        BindingManagerBase bmb;
        SqlCommandBuilder commandBuilder;
       
        public Frm_Categories()
        {
            InitializeComponent();
            da = new SqlDataAdapter("Select [Category-ID], [Category-Description] from Categories", sqlConnection);
            da.Fill(dt);
            dgvCategoryList.DataSource = dt;
            txtCategoryID.DataBindings.Add("Text", dt, "Category-ID");
            txtDescription.DataBindings.Add("Text", dt, "Category-Description");
            bmb = this.BindingContext[dt];
            lblPosition.Text = (bmb.Position+1) + "/" + bmb.Count;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            bmb.Position = 0;
            lblPosition.Text = (bmb.Position + 1) + "/" + bmb.Count;

        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            bmb.Position = bmb.Count;
            lblPosition.Text = (bmb.Position + 1) + "/" + bmb.Count;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            bmb.Position -= 1;
            lblPosition.Text = (bmb.Position +1) + "/" + bmb.Count;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bmb.Position += 1;
            lblPosition.Text = (bmb.Position +1) + "/" + bmb.Count;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            bmb.AddNew();
            btnNew.Enabled = false;
            btnAdd.Enabled = true;
            int id = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0]) + 1;
            txtCategoryID.Text = id.ToString();
            txtDescription.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bmb.EndCurrentEdit();
            commandBuilder = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("A new row is added successfully!","Add Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnAdd.Enabled = false;
            btnNew.Enabled = true;
            lblPosition.Text = (bmb.Position + 1) + "/" + bmb.Count;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bmb.RemoveAt(bmb.Position);
            bmb.EndCurrentEdit();
            commandBuilder = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("One row has been deleted successfully!", "Add Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblPosition.Text = (bmb.Position + 1) + "/" + bmb.Count;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bmb.EndCurrentEdit();
            commandBuilder = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("A row has been updated successfully!", "Edit Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblPosition.Text = (bmb.Position + 1) + "/" + bmb.Count;
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {

        }
    }
}
