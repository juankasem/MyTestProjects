using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalesManagementSystem.BusinessLayer;

namespace SalesManagementSystem.Presentation
{
    public partial class Frm_Customers_List : Form
    {
        Customer customer = new Customer();
        public Frm_Customers_List()
        {
            InitializeComponent();
            dgvCustomerList.DataSource = customer.Get_All_Customers();
            dgvCustomerList.Columns[0].Visible = true;
            dgvCustomerList.Columns[5].Visible = true;
        }

        private void dgvCustomerList_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
