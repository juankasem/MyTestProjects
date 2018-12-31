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
using System.Globalization;
//using System.Data.SqlClient;
using SalesManagementSystem.BusinessLayer;

namespace SalesManagementSystem.Presentation
{
    public partial class Frm_Orders : Form
    {
        Order order = new Order();
        DataTable dt = new DataTable();
        
        public Frm_Orders()
        {
            InitializeComponent();
            CreateDataTable();
            ResizeDataGridView();
            CenteringContent();
            txtSalesman.Text = Program.salesman;
        }

        private void CreateDataTable()
        {
            dt.Columns.Add("Product_ID");
            dt.Columns.Add("Product_Label");
            dt.Columns.Add("Unit_Price");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Amount");
            dt.Columns.Add("Discount(%)");
            dt.Columns.Add("Total_Amount");

            dgvProducts.DataSource = dt;

            //Add Button to datagridview
            /*DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Select a Product ";
            btn.Text = "Search";
            btn.UseColumnTextForButtonValue = true;
            dgvProducts.Columns.Insert(0, btn);*/
        }

        private void ResizeDataGridView()
        {
            dgvProducts.RowHeadersWidth = 72;
            dgvProducts.Columns[0].Width = 98;
            dgvProducts.Columns[1].Width = 198;
            dgvProducts.Columns[2].Width = 98;
            dgvProducts.Columns[3].Width = 82;
            dgvProducts.Columns[4].Width = 69;
            dgvProducts.Columns[5].Width = 146;
            dgvProducts.Columns[6].Width = 153;
        }

        private void CenteringContent()
        {
            for (int i=0; i<7; i++)
            {
                dgvProducts.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void CalculateAmount()
        {
            if (txtPrice.Text != string.Empty && txtQuantity.Text != string.Empty)
            {
                double amount = Convert.ToDouble(txtPrice.Text) * Convert.ToInt32(txtQuantity.Text);
                txtAmount.Text = amount.ToString();
            }    
        }

        private void CalculateTotalAmount()
        {
            if (txtDiscount.Text != string.Empty && txtAmount.Text != string.Empty)
            {
                double discount = Convert.ToDouble(txtDiscount.Text);
                double amount = Convert.ToDouble(txtAmount.Text);
                double totalAmount;
                totalAmount= amount - (amount * (discount/100));
                txtTotalAmount.Text = totalAmount.ToString();
            }
        }

        private void ClearTextBoxes()
        {
            txtProductID.Clear();
            txtProductLabel.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            txtAmount.Clear();
            txtDiscount.Clear();
            txtTotalAmount.Clear();
            btnBrowse.Focus();
        }

        private void ClearOrderData()
        {
            txtOrderID.Clear();
            txtDescription.Clear();
            orderDatePicker.ResetText();
            txtCustomerID.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtSumOfTotals.Clear();
            ClearTextBoxes();
            dt.Clear();
            dgvProducts.DataSource = null;
            picboxImage.Image = null;
            btnSaveOrder.Enabled = false;
            btnNewOrder.Enabled = true;
            btnPrintInvoice.Enabled = true;
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            txtOrderID.Text = order.GetLastOrderID().Rows[0][0].ToString();
            btnNewOrder.Enabled = false;
            btnSaveOrder.Enabled = true;
        }

        

        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            Frm_Customers_List frm = new Frm_Customers_List();
            frm.ShowDialog();
            txtCustomerID.Text = frm.dgvCustomerList.CurrentRow.Cells[0].Value.ToString();
            txtFirstName.Text = frm.dgvCustomerList.CurrentRow.Cells[1].Value.ToString();
            txtLastName.Text = frm.dgvCustomerList.CurrentRow.Cells[2].Value.ToString();
            txtPhone.Text = frm.dgvCustomerList.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = frm.dgvCustomerList.CurrentRow.Cells[4].Value.ToString();

            //Checks if the customer has got an image in the database or not
            if (frm.dgvCustomerList.CurrentRow.Cells[5].Value is DBNull)
            {
                picboxImage.Image = null;
                MessageBox.Show("The selected customer does not have an image in the database");
                return;
            }
            else
            {
                byte[] customerImage = (byte[])frm.dgvCustomerList.CurrentRow.Cells[5].Value;
                MemoryStream ms = new MemoryStream(customerImage);
                picboxImage.Image = Image.FromStream(ms);
            }  
        }

        private void grpboxProducts_Enter(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            Frm_Products_List frm = new Frm_Products_List();
            frm.ShowDialog();
            txtProductID.Text = frm.dgvProducts.CurrentRow.Cells[0].Value.ToString();
            txtProductLabel.Text = frm.dgvProducts.CurrentRow.Cells[1].Value.ToString();
            txtPrice.Text = frm.dgvProducts.CurrentRow.Cells[3].Value.ToString();
            txtQuantity.Focus();
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar !=8)
            {
                e.Handled = true;
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar!= Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter && txtPrice.Text != string.Empty)
            {
                txtQuantity.Focus();
            }
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtQuantity.Text != string.Empty)
            {
                txtDiscount.Focus();
            }
        }

        private void txtPrice_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateAmount();
            CalculateTotalAmount();
        }

        private void txtQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateAmount();
            CalculateTotalAmount();
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                e.Handled = true;
            }
        }

        private void txtDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateTotalAmount();
        }

        private void txtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtDiscount.Text != string.Empty)
            {
                if (order.VerifyQuantity(txtProductID.Text, Convert.ToInt32(txtQuantity.Text)).Rows.Count < 1)
                {
                    MessageBox.Show("The quantity you entered exeeds the quantity in Stock", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //For loop to check if the product already exists in the datagridview or not
                for (int i=0; i<dgvProducts.Rows.Count-1; i++)
                {
                    if (dgvProducts.Rows[i].Cells[0].Value.ToString() == txtProductID.Text)
                    {
                        MessageBox.Show("This product has already been entered", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                  
                }
                //Setup a DataRow object wit values from text boxes
                DataRow r = dt.NewRow();
            
                r[0] = txtProductID.Text;
                r[1] = txtProductLabel.Text;
                r[2] = txtPrice.Text;
                r[3] = txtQuantity.Text;
                r[4] = txtAmount.Text;
                r[5] = txtDiscount.Text;
                r[6] = txtTotalAmount.Text;

                //Add the row to the data table
                dt.Rows.Add(r);

                dgvProducts.DataSource = dt;
                ClearTextBoxes();

                //Calcualte the sum of totalAmount values in the dtagridview using Linq code
                txtSumOfTotals.Text = (from DataGridViewRow row in dgvProducts.Rows
                                       where row.Cells[6].FormattedValue.ToString() != string.Empty
                                       select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
            }
        }

        //Method to edit the row's data by filling text boxes with data of the selected row 
        private void dgvProducts_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txtProductID.Text = dgvProducts.CurrentRow.Cells[0].Value.ToString();
                txtProductLabel.Text = dgvProducts.CurrentRow.Cells[1].Value.ToString();
                txtPrice.Text = dgvProducts.CurrentRow.Cells[2].Value.ToString();
                txtQuantity.Text = dgvProducts.CurrentRow.Cells[3].Value.ToString();
                txtAmount.Text = dgvProducts.CurrentRow.Cells[4].Value.ToString();
                txtDiscount.Text = dgvProducts.CurrentRow.Cells[5].Value.ToString();
                txtTotalAmount.Text = dgvProducts.CurrentRow.Cells[6].Value.ToString();
                dgvProducts.Rows.RemoveAt(dgvProducts.CurrentRow.Index);
                txtQuantity.Focus();

            }
            catch (Exception)
            {

                return;
            }
           
        }

        private void dgvProducts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //Calcualte the sum of totalAmount values in the dtagridview using Linq code
            txtSumOfTotals.Text = (from DataGridViewRow row in dgvProducts.Rows
                                   where row.Cells[6].FormattedValue.ToString() != string.Empty
                                   select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvProducts_DoubleClick(sender,  e);
        }

        private void deleteCurrentRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvProducts.Rows.RemoveAt(dgvProducts.CurrentRow.Index);
        }

        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dt.Clear();
                dgvProducts.Refresh();
            }
            catch (Exception)
            {

                return;
            }        
        }

        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            try
            {
                
                
                //Check Invoice Inputs
                if (txtOrderID.Text==string.Empty)
                {
                    MessageBox.Show("Please add an Order ID for the invoice", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtCustomerID.Text == string.Empty)
                {
                    MessageBox.Show("Please select a customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (dgvProducts.Rows.Count < 1)
                {
                    MessageBox.Show("Please select some products to be registered", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtDescription.Text == string.Empty)
                {
                    MessageBox.Show("please add description to the order", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int orderID = Convert.ToInt32(txtOrderID.Text);
                DateTime orderDate = orderDatePicker.Value;
                int customerID = Convert.ToInt32(txtCustomerID.Text);
                string description = txtDescription.Text;
                string salesman = txtSalesman.Text;
                //Add invoice basic info
                order.AddOrder(orderID, orderDate, customerID, description, salesman);

                //Add products details of the invoice
                for (int i = 0; i < dgvProducts.Rows.Count - 1; i++)
                {
                    order.AddOrderDetails(orderID, dgvProducts.Rows[i].Cells[0].Value.ToString(), Convert.ToInt32(dgvProducts.Rows[i].Cells[3].Value),
                                           Convert.ToDouble(dgvProducts.Rows[i].Cells[2].Value), Convert.ToDouble(dgvProducts.Rows[i].Cells[5].Value),
                                           Convert.ToDouble(dgvProducts.Rows[i].Cells[4].Value), Convert.ToDouble(dgvProducts.Rows[i].Cells[6].Value));

                }
                MessageBox.Show("An order has been saved into database successfully!", "Save Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearOrderData();
            }
            catch (Exception)
            {
                MessageBox.Show("Missing Order Details...Please try again", "Save Order", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
