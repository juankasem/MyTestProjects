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
    public partial class Frm_Add_Product : Form
    {
        Product product = new Product();
        public string state = "add";
        Frm_Products frm = new Frm_Products();
        public Frm_Add_Product()
        {
            InitializeComponent();
            comboxCategory.DataSource = product.Get_All_Categories();
            comboxCategory.DisplayMember = "Category-Description";
            comboxCategory.ValueMember = "Category-ID";
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Images Files (*.BMP;*.JPG;*.GIF)|*.jpg; *.png; *.gif; *.bmp";

            if(ofd.ShowDialog()==DialogResult.OK)
            {
                picboxImage.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (state == "add")
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    picboxImage.Image.Save(ms, picboxImage.Image.RawFormat);

                    byte[] byteImage = ms.ToArray();

                    int catID = Convert.ToInt32(comboxCategory.SelectedValue);
                    string productID = txtID.Text;
                    string label = txtDescription.Text;
                    int quantity = Convert.ToInt32(txtQuantity.Text);
                    double price = Convert.ToDouble(txtPrice.Text);

                    product.AddProduct(productID, label, quantity, price, byteImage, catID);
                
                    //Show a confirmation message and clear all text boxes
                    MessageBox.Show("A new Product row has been appended successfully into the Database!", "Add New Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearTextBoxes();
                }
                catch
                {
                    MessageBox.Show("Operation Failed!...Please try again", "Add New Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                   
            }
            //If the required operation is to edit and update a row
            else
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    picboxImage.Image.Save(ms, picboxImage.Image.RawFormat);

                    byte[] byteImage = ms.ToArray();

                    int catID = Convert.ToInt32(comboxCategory.SelectedValue);
                    string productID = txtID.Text;
                    string label = txtDescription.Text;
                    int quantity = Convert.ToInt32(txtQuantity.Text);
                    double price = Convert.ToDouble(txtPrice.Text);

                    product.UpdateProduct(productID, label, quantity, price, byteImage, catID);

                    //Show a confirmation message and clear all text boxes
                     MessageBox.Show("One row has been updated successfully to the Database", "Update Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     ClearTextBoxes();  
                }
                catch
                {
                    MessageBox.Show("Operation Failed!...Please try again", "Update Product", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
               
                
            }
            Frm_Products.GetMainForm.dgvProducts.DataSource = product.Get_All_Products();

        }

        private void txtID_Validated(object sender, EventArgs e)
        {
            if (state == "add")
            {
                DataTable dt = new DataTable();
                dt = product.VerifyProductID(txtID.Text);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("This Product ID already exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtID.Focus();
                    txtID.SelectionStart = 0;
                    txtID.SelectionLength = txtID.TextLength;
                }
            }

           
        }

        private void ClearTextBoxes()
        {
            txtID.Clear();
            txtDescription.Clear();
            txtQuantity.Clear();
            txtPrice.Clear();
            picboxImage.Image = null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
