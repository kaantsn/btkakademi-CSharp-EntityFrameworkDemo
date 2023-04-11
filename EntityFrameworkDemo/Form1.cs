using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProductDal _productDal = new ProductDal();
        private void LoadProducts()
        {
            dgwProducts.DataSource = _productDal.GetAll();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                Name = tbxAddName.Text,
                UnitPrice = Convert.ToDecimal(tbxAddPrice.Text),
                StockAmount = Convert.ToInt32(tbxAddStock.Text)

            });
            LoadProducts();
            MessageBox.Show("Added!");
        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxUptadeName.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString(); 
            tbxUptadePrice.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxUptadeStock.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnUptade_Click(object sender, EventArgs e)
        {
            _productDal.Update(new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                Name = tbxUptadeName.Text,
                UnitPrice = Convert.ToDecimal(tbxUptadePrice.Text),
                StockAmount = Convert.ToInt32(tbxUptadeStock.Text)

            });
            LoadProducts();
            MessageBox.Show("Uptaded!");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value)
            });
            LoadProducts();
            MessageBox.Show("Deleted!");
        }

        private void SearchProducts(string key)
        {
            var result = _productDal.GetByName(key);
            dgwProducts.DataSource = result;
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            SearchProducts(tbxSearch.Text);
        }
    }
}
