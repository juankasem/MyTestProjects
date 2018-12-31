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
    public partial class Frm_Customers : Form
    {
        Customer customer = new Customer();
        int id,position;
        public Frm_Customers()
        {
            InitializeComponent();
            lblImage.BringToFront();
            lblImage.Location = new Point(0, 20);
            picboxImage.Controls.Add(lblImage);
            this.dgvList.DataSource = customer.Get_All_Customers();
            dgvList.Columns[0].Visible = false;
            dgvList.Columns[5].Visible = false;
            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearInputs();
            btnNew.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {    
            try
            {
                if (txtFirstName .Text == string.Empty || txtLastName .Text == string.Empty || txtPhone.Text == string.Empty ||
                 txtEmail.Text == string.Empty)
                {
                    MessageBox.Show("Please complete all New Customer details", "Add New Customer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //Initialize the procedure variables
                string firstName = txtFirstName.Text;
                string lastName = txtLastName.Text;
                string phone = txtPhone.Text;
                string email = txtEmail.Text;
                byte[] image;

                if (picboxImage.Image == null)
                {
                    image = new byte[0];
                    //Call the procedure without selecting an image for the customer
                    customer.AddCustomer(firstName, lastName, phone, email, image, "Without_Image");
                }
                else
                {
                    MemoryStream ms = new MemoryStream();
                    picboxImage.Image.Save(ms, picboxImage.Image.RawFormat);
                    image = ms.ToArray();

                    //Call the procedure
                    customer.AddCustomer(firstName, lastName, phone, email, image, "With_Image");
                }
                btnNew.Enabled = true;
                btnAdd.Enabled = false;
                MessageBox.Show("A new Customer row has been added successfully!", "Add New Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvList.DataSource = customer.Get_All_Customers();

            }
            catch
            {
                MessageBox.Show("Operation Failed...please try again...", "Add New Customer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (position == customer.Get_All_Customers().Rows.Count-1)
            {
                MessageBox.Show("This is the last record");
                return;
            }

            position += 1;
            NavigateRecords(position);
        }
         
        private void picboxImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter= "Images Files (*.BMP;*.JPG;*.GIF)|*.jpg; *.png; *.gif; *.bmp";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                picboxImage.Image = Image.FromFile(opf.FileName);
            }
        }


        private void ClearInputs()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            picboxImage.Image = null;
            txtFirstName.Focus();
        }

        private void txtFirstName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLastName.Focus();
            }
        }

        private void txtLastName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPhone.Focus();
            }
        }

        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmail.Focus();
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd.Focus();
            }
        }

      

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFirstName.Text == string.Empty || txtLastName.Text == string.Empty || txtPhone.Text == string.Empty ||
                 txtEmail.Text == string.Empty)
                {
                    MessageBox.Show("Please complete all Customer details", "Edit Customer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //Initialize the procedure variables
                string firstName = txtFirstName.Text;
                string lastName = txtLastName.Text;
                string phone = txtPhone.Text;
                string email = txtEmail.Text;
                byte[] image;
                id= Convert.ToInt32(dgvList.CurrentRow.Cells[0].Value.ToString());
                if (id == 0)
                {
                    MessageBox.Show("The customer you want to update does not exist in database");
                    return;
                }

                if (picboxImage.Image == null)
                {
                    image = new byte[0];
                    //Call the procedure without selecting an image for the customer
                    customer.EditCustomer(firstName, lastName, phone, email, image, "Without_Image",id);
                }
                else
                {
                    MemoryStream ms = new MemoryStream();
                    picboxImage.Image.Save(ms, picboxImage.Image.RawFormat);
                    image = ms.ToArray();

                    //Call the procedure
                    customer.EditCustomer(firstName, lastName, phone, email, image, "With_Image",id);
                }
                btnNew.Enabled = true;
                btnAdd.Enabled = false;
                MessageBox.Show("A customer has been updated successfully!", "Update Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvList.DataSource = customer.Get_All_Customers();
            }
            catch
            {
                MessageBox.Show("Operation Failed...please try again...", "Update Customerr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void dgvList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                picboxImage.Image = null;
                txtFirstName.Text = dgvList.CurrentRow.Cells[1].Value.ToString();
                txtLastName.Text = dgvList.CurrentRow.Cells[2].Value.ToString();
                txtPhone.Text = dgvList.CurrentRow.Cells[3].Value.ToString();
                txtEmail.Text = dgvList.CurrentRow.Cells[4].Value.ToString();

                byte[] image = (byte[])(dgvList.CurrentRow.Cells[5].Value);
                MemoryStream ms = new MemoryStream(image);
                picboxImage.Image = Image.FromStream(ms);
            }
            catch
            {
                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dgvList.CurrentRow.Cells[0].Value.ToString());
            if (id == 0)
            {
                MessageBox.Show("This customer does not exist");
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete this customer from database?", "Delete Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                customer.DeleteCustomer(id);
                MessageBox.Show("A customer has been deleted successfully!", "Delete Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvList.DataSource = customer.Get_All_Customers();
                ClearInputs();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
             
            dgvList.DataSource = customer.SearchCustomer(txtSearch.Text);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk_Click(sender, e);
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            NavigateRecords(0);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            position = customer.Get_All_Customers().Rows.Count - 1;
            NavigateRecords(position);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (position == 0)
            {
                MessageBox.Show("This is the first record");
                    return;
            }
            position -= 1;
            NavigateRecords(position);
        }

        private void NavigateRecords(int index)
        {
            try
            {
                picboxImage.Image = null;

                //Create a DataRowCollection object to retrieve & store rows of dataset 
                DataRowCollection drc = customer.Get_All_Customers().Rows;
                dgvList.ClearSelection();
                dgvList.Rows[index].Selected = true;
                id = Convert.ToInt32(drc[index][0]);
                txtFirstName.Text = drc[index][1].ToString();
                txtLastName.Text = drc[index][2].ToString();
                txtPhone.Text = drc[index][3].ToString();
                txtEmail.Text = drc[index][4].ToString();
                byte[] image = (byte[])drc[index][5];
                MemoryStream ms = new MemoryStream(image);
                picboxImage.Image = Image.FromStream(ms);
             
            }
            catch (Exception)
            {
                return;
            }
            
        }
    }
}
