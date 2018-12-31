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
    public partial class Frm_Products_List : Form
    {
        Product product = new Product();
        public Frm_Products_List()
        {
            InitializeComponent();
            dgvProducts.DataSource = product.Get_All_Products();
        }

        private void dgvProducts_DoubleClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
