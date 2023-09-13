using RecapProject1.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecapProject1
{
    public partial class frmProduct : Form
    {
        public frmProduct()
        {
            InitializeComponent();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            ListCategories();
            ListProduct();
        }

        private void ListProduct()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dgwProduct.DataSource = context.Products.ToList();

            }
        }
        private void ListProductsByProductName(string productName)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dgwProduct.DataSource = context.Products.Where(p => p.ProductName.ToLower().Contains(productName.ToLower())).ToList();
            }
        }
        private void ListProductsByCategory(int categoryId)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dgwProduct.DataSource = context.Products.Where(p=>p.CategoryId==categoryId).ToList();

            }
        }
        private void ListCategories()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
               cbxCategory.DataSource = context.Categories.ToList();
                cbxCategory.DisplayMember = "CategoryName";
                cbxCategory.ValueMember = "CategoryId";
            }
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ListProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));
            }
            catch { }
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            string key=tbxSearch.Text;
            if(string.IsNullOrEmpty(key))
            {
                ListProduct();
            }
            else
            {
                ListProductsByProductName((string)tbxSearch.Text);
            }
        }
    }
}




