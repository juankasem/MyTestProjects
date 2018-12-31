using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using SalesManagementSystem.BusinessLayer;

namespace SalesManagementSystem.Presentation
{
   
    public partial class Frm_Products : Form
    {
        Product product = new Product();
        private static Frm_Products frm;

        static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static Frm_Products GetMainForm
        {
            get
            {
                if (frm == null)
                {
                    frm = new Frm_Products();
                    frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                }
                return frm;
            }
        }
        public Frm_Products()
        {
            InitializeComponent();
            if (frm == null)
                frm = this;
            this.dgvProducts.DataSource = product.Get_All_Products();
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = product.SearchProduct(txtSearch.Text);
            this.dgvProducts.DataSource = dt;
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            Frm_Add_Product frm = new Frm_Add_Product();
            frm.ShowDialog();
            frm.txtID.ReadOnly = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
          if  (MessageBox.Show("Are you sure you want to delete the selected product?", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)==DialogResult.Yes)
            {
                try
                {
                    product.DeleteProduct(dgvProducts.CurrentRow.Cells[0].Value.ToString());

                    //Show a confirmation message and clear all text boxes
                    MessageBox.Show("One row has been deleted successfully from the Database", "Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvProducts.DataSource = product.Get_All_Products();
                    
                }
                catch
                {
                    MessageBox.Show("Delete operation failed!", "Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
            }
            else
            {
                MessageBox.Show("Delete operation has been cancelled", "Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void grpboxProducts_Enter(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Frm_Add_Product frm = new Frm_Add_Product();
            frm.txtID.Text = dgvProducts.CurrentRow.Cells[0].Value.ToString();
            frm.txtDescription.Text = dgvProducts.CurrentRow.Cells[1].Value.ToString();
            frm.txtQuantity.Text = dgvProducts.CurrentRow.Cells[2].Value.ToString();
            frm.txtPrice.Text = dgvProducts.CurrentRow.Cells[3].Value.ToString();
            frm.comboxCategory.Text = dgvProducts.CurrentRow.Cells[4].Value.ToString();
            frm.Text="Update Product"+ dgvProducts.CurrentRow.Cells[1].Value.ToString();
            frm.btnOk.Text = "Update";
            frm.state = "update";
            frm.txtID.ReadOnly = true;
            byte[] image = (byte[])product.GetProductImage(dgvProducts.CurrentRow.Cells[0].Value.ToString()).Rows[0][0];
            MemoryStream ms = new MemoryStream(image);
            frm.picboxImage.Image = Image.FromStream(ms);
            frm.ShowDialog();
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            Frm_Preview frm = new Frm_Preview();
            byte[] image = (byte[])product.GetProductImage(dgvProducts.CurrentRow.Cells[0].Value.ToString()).Rows[0][0];
            MemoryStream ms = new MemoryStream(image);
            frm.picboxPreview.Image = Image.FromStream(ms);
            frm.ShowDialog();
        }

        
    }
}
