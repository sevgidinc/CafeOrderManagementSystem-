using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeOrderManagementSystem
{
    public partial class Form1 : Form
    {
        List<Product> products = new List<Product>();
        List<Customer> customers = new List<Customer>();
        Order currentOrder;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            string name = txtProductName.Text;
            decimal price;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Ürün adı boş olamaz.");
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out price))
            {
                MessageBox.Show("Geçersiz fiyat.");
                return;
            }

            Product product = new Product(name);
            product.Price = price;

            products.Add(product);

            lstProducts.Items.Add(product.Name + " - " + product.Price + " TL");
            cmbProducts.Items.Add(product);


            MessageBox.Show("Ürün başarıyla eklendi.");

            txtProductName.Clear();
            txtPrice.Clear();


        }

        private void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            string name = txtCustomerName.Text;
            string phone = txtPhone.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Müşteri adı boş olamaz.");
                return;
            }

            Customer customer = new Customer(name, phone);
            customers.Add(customer);

            lstCustomers.Items.Add(customer.Name + " - " + customer.PhoneNumber);
            cmbCustomers.Items.Add(customer);

            MessageBox.Show("Müşteri eklendi.");

            txtCustomerName.Clear();
            txtPhone.Clear();

        }

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            if (cmbCustomers.SelectedItem == null || cmbProducts.SelectedItem == null)
            {
                MessageBox.Show("Lütfen müşteri ve ürün seçin.");
                return;
            }

            Customer selectedCustomer = (Customer)cmbCustomers.SelectedItem;
            Product selectedProduct = (Product)cmbProducts.SelectedItem;

            int quantity = (int)numQuantity.Value;

            if (currentOrder == null)
            {
                currentOrder = new Order(selectedCustomer);
            }

            currentOrder.AddItem(selectedProduct, quantity);

            decimal total = currentOrder.CalculateTotalPrice();
            lblTotal.Text = "Toplam: " + total + " TL";

        }
    }
}
